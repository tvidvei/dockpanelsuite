using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using ThemeEditor;

namespace WeifenLuo.Docking
{
    public class Theme
    {
        private Color _dockBackColor;

        private bool _showAutoHideContentOnHover;

        public Theme() {
            Skin = new DockPanelSkin();
            PaintingService = new PaintingService();
            Measures = new Measures();
            Measures.SplitterSize = 6;
            Measures.AutoHideSplitterSize = 3;
            Measures.DockPadding = 6;
            ShowAutoHideContentOnHover = false;
        }

        /// <summary>
        /// Setup to be called after initialization
        /// </summary>
        internal void Setup()
        {
            ImageService = new ImageService(this);
            ToolStripRenderer = new VisualStudioToolStripRenderer(ColorPalette)
            {
                UseGlassOnMenuStrip = false,
            };
        }

        /// <summary>
        /// Filepath for this Theme
        /// </summary>
        [JsonIgnore]
        [Browsable(false)]
        public string FileName { get; protected set; }

        /// <summary>
        /// Dummy name for unsaved Theme
        /// </summary>
        [JsonIgnore]
        [Browsable(false)]
        public string TempName { get; protected set; }

        /// <summary>
        /// DisplayPath - Either FileName only (without path and extension)  or TempName
        /// </summary>
        [JsonIgnore]
        [Browsable(false)]
        public string DisplayName => Path.GetFileNameWithoutExtension(FileName) ?? TempName;

        /// <summary>
        /// DisplayPath - Either full filePath (if saved) or TempName
        /// </summary>
        [JsonIgnore]
        [Browsable(false)]
        public string DisplayPath => FileName ?? TempName;



        [Category("Colors")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DockPanelColorPalette ColorPalette { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public DockPanelSkin Skin { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public IImageService ImageService { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public IPaintingService PaintingService { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        protected ToolStripRenderer ToolStripRenderer { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public Measures Measures { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public bool ShowAutoHideContentOnHover { get; set; } //= true;

        private Dictionary<ToolStrip, KeyValuePair<ToolStripRenderMode, ToolStripRenderer>> _stripBefore
            = new Dictionary<ToolStrip, KeyValuePair<ToolStripRenderMode, ToolStripRenderer>>();

        public void ApplyTo(ToolStrip toolStrip)
        {
            if (toolStrip == null)
                return;

            _stripBefore[toolStrip] = new KeyValuePair<ToolStripRenderMode, ToolStripRenderer>(toolStrip.RenderMode, toolStrip.Renderer);
            if(ToolStripRenderer != null)
                toolStrip.Renderer = ToolStripRenderer;

            if (Win32Helper.IsRunningOnMono)
            {
                foreach (var item in toolStrip.Items.OfType<ToolStripDropDownItem>())
                {
                    ItemResetOwnerHack(item);
                }
            }
        }

        private void ItemResetOwnerHack(ToolStripDropDownItem item)
        {
            var oldOwner = item.DropDown.OwnerItem;
            item.DropDown.OwnerItem = null;
            item.DropDown.OwnerItem = oldOwner;

            foreach (var child in item.DropDownItems.OfType<ToolStripDropDownItem>())
            {
                ItemResetOwnerHack(child);
            }
        }

        private KeyValuePair<ToolStripManagerRenderMode, ToolStripRenderer> _managerBefore;

        public void ApplyToToolStripManager()
        {
            _managerBefore = new KeyValuePair<ToolStripManagerRenderMode, ToolStripRenderer>(ToolStripManager.RenderMode, ToolStripManager.Renderer);
        }

        public void ApplyTo(DockPanel dockPanel)
        {
            if (dockPanel.Panes.Count > 0)
                throw new InvalidOperationException(Strings.Theme_PaneNotClosed);

            if (dockPanel.FloatWindows.Count > 0)
                throw new InvalidOperationException(Strings.Theme_FloatWindowNotClosed);

            if (dockPanel.Contents.Count > 0)
                throw new InvalidOperationException(Strings.Theme_DockContentNotClosed);

            if (ColorPalette == null)
            {
                dockPanel.ResetDummy();
            }
            else
            {
                _dockBackColor = dockPanel.DockBackColor;
                dockPanel.DockBackColor = ColorPalette.MainWindowActive.Background;
                dockPanel.SetDummy();
            }

            _showAutoHideContentOnHover = dockPanel.ShowAutoHideContentOnHover;
            dockPanel.ShowAutoHideContentOnHover = ShowAutoHideContentOnHover;
        }

        internal void PostApply(DockPanel dockPanel)
        {
            dockPanel.ResetAutoHideStripControl();
            dockPanel.ResetAutoHideStripWindow();
            dockPanel.ResetDockWindows();
        }

        public virtual void CleanUp(DockPanel dockPanel)
        {
            PaintingService.CleanUp();
            if (dockPanel != null)
            {
                if (ColorPalette != null)
                {
                    dockPanel.DockBackColor = _dockBackColor;
                }

                dockPanel.ShowAutoHideContentOnHover = _showAutoHideContentOnHover;
            }

            foreach (var item in _stripBefore)
            {
                var strip = item.Key;
                var cache = item.Value;
                if (cache.Key == ToolStripRenderMode.Custom)
                {
                    if (cache.Value != null)
                        strip.Renderer = cache.Value;
                }
                else
                {
                    strip.RenderMode = cache.Key;
                }
            }

            _stripBefore.Clear();
            if (_managerBefore.Key == ToolStripManagerRenderMode.Custom)
            {
                if (_managerBefore.Value != null)
                    ToolStripManager.Renderer = _managerBefore.Value;
            }
            else
            {
                ToolStripManager.RenderMode = _managerBefore.Key;
            }
        }

        private static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions();

        [JsonIgnore]
        [Browsable(false)]
        public static string ThemesPath { get; set; }

        public static Theme LoadFromFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new Exception("No Theme file given");
            }
            Theme result = null;
            if (Path.GetDirectoryName(fileName) == String.Empty)
            {
                fileName = Path.Combine(ThemesPath, fileName);
            }
            var fileExt = Path.GetExtension(fileName);
            if (fileExt == null)
            {
                fileName += ".json";
                fileExt = "json";
            }
            if (fileExt.ToLower() == ".json")
            {
                if (!File.Exists(fileName))
                {
                    throw new Exception($"Can't find Theme file '{fileName}'");
                }
                var jsonString = File.ReadAllText(fileName);
                result = JsonSerializer.Deserialize<Theme>(jsonString, JsonSerializerOptions);
                result.Setup();
            }
            else
            {
                throw new Exception("Error in Theme.LoadFromFile: File must have extension '.json'");
            }
            result.FileName = fileName;
            return result;
        }

        private static int newThemeCount = 1;

        public static Theme CreateNew(string tempName = null)
        {
            var result = new Theme();
            result.TempName = tempName ?? "NewTheme" + newThemeCount++;
            return result;
        }


        static Theme()
        {
            JsonSerializerOptions.WriteIndented = true;
            JsonSerializerOptions.Converters.Add(new ColorJsonConverter());
            ThemesPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),"Themes");
        }
    }
}

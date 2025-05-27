using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using ThemeEditor;

namespace WeifenLuo.Docking
{
    public class Theme
    {
        private Color _dockBackColor;

        private bool _showAutoHideContentOnHover;

        public Theme() { 
        
        }

        public Theme(byte[] resources) {
            ColorPalette = new DockPanelColorPalette(new PaletteFactory(resources));
            Skin = new DockPanelSkin();
            PaintingService = new PaintingService();
            ImageService = new ImageService(this);
            ToolStripRenderer = new VisualStudioToolStripRenderer(ColorPalette) {
                UseGlassOnMenuStrip = false,
            };

            Measures = new Measures();
            Measures.SplitterSize = 6;
            Measures.AutoHideSplitterSize = 3;
            Measures.DockPadding = 6;

            ShowAutoHideContentOnHover = false;
        }

        /// <summary>
        /// Filepath for this Theme
        /// </summary>
        [Browsable(false)]
        public string FileName { get; protected set; }


        [Category("Colors")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DockPanelColorPalette ColorPalette { get; set; }

        [Browsable(false)]
        public DockPanelSkin Skin { get; set; }

        [Browsable(false)]
        public IImageService ImageService { get; set; }

        [Browsable(false)]
        public IPaintingService PaintingService { get; set; }

        [Browsable(false)]
        protected ToolStripRenderer ToolStripRenderer { get; set; }

        [Browsable(false)]
        public Measures Measures { get; set; }

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


        public static Theme LoadFromFile(string fileName)
        {
            Theme result = null;
            var fileExt = Path.GetExtension(fileName);
            if (fileExt == null)
            {
                fileName += ".json";
                fileExt = "json";
            }
            if (fileExt.ToLower() == ".gz")
            {
                result = Theme.loadFromCompressedFile(fileName);
            }
            else if (fileExt.ToLower() == ".json")
            {
                var jsonString = File.ReadAllText(fileName);
                result = JsonSerializer.Deserialize<Theme>(jsonString, JsonSerializerOptions);
            }
            else
            {
                throw new Exception("Error in Theme.LoadFromFile: File must have extension '.json' or '.gz'");
            }
            result.FileName = fileName;
            return result;
        }

        private static Theme loadFromCompressedFile(string fileName)
        {
            byte[] gzdata = File.ReadAllBytes(fileName);
            var data = Decompress(gzdata);
            return new Theme(data);
        }

        public static byte[] Decompress(byte[] fileToDecompress)
        {
            using (MemoryStream originalFileStream = new MemoryStream(fileToDecompress))
            {
                using (MemoryStream decompressedFileStream = new MemoryStream())
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        //Copy the decompression stream into the output file.
                        byte[] buffer = new byte[4096];
                        int numRead;
                        while ((numRead = decompressionStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            decompressedFileStream.Write(buffer, 0, numRead);
                        }

                        return decompressedFileStream.ToArray();
                    }
                }
            }
        }

        static Theme()
        {
            JsonSerializerOptions.WriteIndented = true;
            JsonSerializerOptions.Converters.Add(new ColorJsonConverter());
        }
    }
}

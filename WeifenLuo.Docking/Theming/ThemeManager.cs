using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using ThemeEditor;
using WeifenLuo.Docking;

namespace WeifenLuo.Docking
{

    public delegate void SetThemeAction(Theme theme = null);

    public static class ThemeManager
    {
        public static Theme EmptyTheme = new Theme();

        public static Theme DefaultTheme { get; set; }

        public static List<ThemeEditorWindow> ThemeEditorWindows = new();

        public static void CloseAllThemeEditorWindows()
        {
            //foreach (var wnd in ThemeEditorWindows) {
            while (ThemeEditorWindows.Count > 0)
            {
                var wnd = ThemeEditorWindows[0];
                wnd.DockHandler.DockPanel = null;
                wnd.DockHandler.Close();
                //wnd.Close(); 
            }
#if old
            while (ThemeEditorWindows.Count > 0) {
                var wnd = ThemeEditorWindows[0];
                wnd.DockHandler.DockPanel = null;
                wnd.DockHandler.Close();
                ThemeEditorWindows.RemoveAt(0); 
            }
#endif
        }

        public static void UpdateTabTexts()
        {
            foreach (var window in ThemeEditorWindows) { window.SetTabText(); }
        }

        /// <summary>
        /// Searches for a ThemeEditorWindow with the given name
        /// </summary>
        /// <param name="fileName">full filepath with extension or filename only (without extension)</param>
        /// <returns>A ThemeEditorWindow with matching name or null</returns>
        /// Search is done first assuming fileName is a full filePath with extension, then on the fileName only (without path and extension)
        public static ThemeEditorWindow? FindThemeEditorWindow(string fileName)
        {
            var fileNameOnly = Path.GetFileNameWithoutExtension(fileName);
            var result = ThemeEditorWindows.FirstOrDefault(w => w.FileName == fileName) ?? ThemeEditorWindows.FirstOrDefault(w => w.FileName == fileNameOnly);
            return result;
        }


        public static ThemeEditorWindow CreateOrReuseThemeEditorWindow(string? filePath = null)
        {
            // Check if a window for this file already exists
            ThemeEditorWindow wnd = ThemeEditorWindows.FirstOrDefault(w => w.FileName?.ToLower() == filePath?.ToLower());
            if (wnd != null)
            {
                wnd.Activate();
                return wnd;
            }

            // Check if the fileName is the Current Theme, then open a window to that theme
            wnd = new ThemeEditorWindow();
            wnd.DockPanel = DockPanel;
            if (!string.IsNullOrWhiteSpace(filePath)) {
                if (DockPanel.Theme.FilePath.ToLower() == filePath?.ToLower()) wnd.Theme = DockPanel.Theme;
                else wnd.FilePath = filePath;
            }
            wnd.Show(DockPanel);
            wnd.Activate();
            return wnd;
        }

        public static OpenFileDialog OpenFileDialog { get; set; }

        public static SaveFileDialog SaveFileDialog { get; set; }


        private static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions();

        public static string ThemesPath { get; set; }

        public static string GetFileName(string filePath)
        {
            if (Path.GetExtension(filePath).ToLower() != ".json")
            {
                throw new Exception($"Illegal theme file '{filePath}: Extension '.json' required.");
            }
            var res = Path.GetRelativePath(ThemesPath, filePath);
            return res.Substring(0, res.Length - 5);
        }

        public static string GetFilePath(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return null;
            if (File.Exists(fileName)) return fileName;
            return Path.Combine(ThemeManager.ThemesPath, fileName + ".json");
        }


        public static Theme? LoadFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new Exception("No Theme file given");
            }
            Theme result = null;
            if (Path.GetDirectoryName(filePath) == String.Empty)
            {
                filePath = Path.Combine(ThemesPath, filePath);
            }
            var fileExt = Path.GetExtension(filePath);
            if (string.IsNullOrEmpty(fileExt))
            {
                filePath += ".json";
                fileExt = ".json";
            }
            if (fileExt.ToLower() == ".json")
            {
                if (!File.Exists(filePath))
                {
                    throw new Exception($"Can't find Theme file '{filePath}'");
                }
                var jsonString = File.ReadAllText(filePath);
                result = JsonSerializer.Deserialize<Theme>(jsonString, JsonSerializerOptions);
                result.Setup();
            }
            else
            {
                throw new Exception("Theme file must have extension '.json'");
            }
            result.FilePath = filePath;
            return result;
        }

        private static int newThemeCount = 1;

        public static Theme CreateNew(string tempName = null)
        {
            var result = new Theme();
            result.TempName = tempName ?? "NewTheme" + newThemeCount++;
            return result;
        }

        public static SetThemeAction SetThemeAction { get; set; } = (x) => throw new Exception("ThemeManager.SetThemeAction not set");


        public static void SetTheme(string filePath = null)
        {
            //var theme = fileName != null ? LoadFromFile(fileName) : new Theme();
            Theme theme = null;
            if (filePath != null)
            {
                if (DockPanel.Theme.FilePath.ToLower() == filePath.ToLower()) return;
                var wnd = ThemeEditorWindows.FirstOrDefault(w => w.FileName.ToLower() == filePath.ToLower());
                if (wnd != null) theme = wnd.Theme;
                else theme = LoadFromFile(filePath);
            } else
            {
                theme = DefaultTheme;  
            }
            SetThemeAction(theme);
        }


        // Commands


        public static void CmdThemeChange()
        {
            var result = OpenFileDialog.ShowDialog(MainForm);  // Todo: Shold we call ShowDialog(MainForm instead?)
            if (result == DialogResult.OK)
            {
                SetTheme(OpenFileDialog.FileName);
                UpdateTabTexts();
            }
            MainForm.Activate();
        }

        public static void CmdThemeOpen()
        {
            ThemeEditorWindow wnd = null;
            var result = OpenFileDialog.ShowDialog(MainForm);
            if (result == DialogResult.OK)
            {
                CreateOrReuseThemeEditorWindow(OpenFileDialog.FileName);
                return;
            }
            MainForm.Activate();
        }


        // Setup

        public static void Setup(string defaultThemeName = "default")
        {

            JsonSerializerOptions.WriteIndented = true;
            JsonSerializerOptions.Converters.Add(new ColorJsonConverter());
            ThemesPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Themes");


            OpenFileDialog = new OpenFileDialog();
            SaveFileDialog = new SaveFileDialog();

            // 
            // openFileDialog1
            // 
            OpenFileDialog.DefaultExt = "json";
            OpenFileDialog.FileName = "openFileDialog1";
            OpenFileDialog.Filter = "JSON files|*.json|All files|*.*";
            OpenFileDialog.Title = "Open Theme";
            OpenFileDialog.InitialDirectory = ThemesPath;
            // 
            // saveFileDialog1
            // 
            SaveFileDialog.DefaultExt = "json";
            SaveFileDialog.Filter = "JSON files|*.json|All files|*.*";
            SaveFileDialog.Title = "Save Theme";
            SaveFileDialog.InitialDirectory = ThemesPath;

            try
            {
                DefaultTheme = LoadFromFile(defaultThemeName);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error: Attempt to load default theme '{defaultThemeName}' failed:\r\n"
                        + ex.Message + "\r\n\r\nThe program will terminate."
                    );
            }
        }

        public static Form MainForm { get; private set; }

        public static DockPanel DockPanel { get; private set; }

        public static void SetMainForm(Form mainForm, DockPanel dockPanel, SetThemeAction setThemeAction)
        {
            MainForm = mainForm;
            DockPanel = dockPanel;
            SetThemeAction = setThemeAction;
        }


    }

}

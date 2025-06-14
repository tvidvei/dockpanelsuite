using System.Drawing;
using System.Globalization;
using Utilities;
using WeifenLuo.Docking;
using WinFormsUtilities;

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
            while (ThemeEditorWindows.Count > 0)
            {
                var wnd = ThemeEditorWindows[0];
                wnd.DockHandler.DockPanel = null;
                wnd.DockHandler.Close();
            }
        }

        public static void UpdateTabTexts()
        {
            foreach (var window in ThemeEditorWindows) { window.SetTabText(); }
        }

        public static int ComparePaths(string strA, string strB) => String.Compare(strA, strB, true, CultureInfo.CurrentCulture);

        public static bool AreEqualPaths(string strA, string strB) => ComparePaths(strA, strB) == 0;

        /// <summary>
        /// Searches for a ThemeEditorWindow with the given name
        /// </summary>
        /// <param name="filePath">full filepath with extension or filename only (without extension)</param>
        /// <returns>A ThemeEditorWindow with matching name or null</returns>
        /// Search is done first assuming fileName is a full filePath with extension, then on the fileName only (without path and extension)
        public static ThemeEditorWindow? FindThemeEditorWindow(string filePath)
        {
            var result = ThemeEditorWindows.FirstOrDefault(w => AreEqualPaths(w.FilePath, filePath));
            return result;
        }

        //public static ThemeEditorWindow? FindCurrentThemeEditorWindow() => FindThemeEditorWindow(DockPanel.Theme.FilePath);

        public static ThemeEditorWindow? FindCurrentThemeEditorWindow() =>
            ThemeEditorWindows.FirstOrDefault(w => w.IsCurrent);

        public static ThemeEditorWindow? FindActiveThemeEditorWindow() =>
            ThemeEditorWindows.FirstOrDefault(w => w.IsActivated);


        public static ThemeEditorWindow CreateNewThemeEditorWindow()
        {
            ThemeEditorWindow wnd = new ThemeEditorWindow();
            wnd.DockPanel = DockPanel;
            wnd.Theme = CreateNew();
            wnd.Show(DockPanel);
            wnd.Activate();
            return wnd;
        }

        public static ThemeEditorWindow CreateOrReuseThemeEditorWindow(string? filePath = null)
        {
            // Check if a window for this file already exists
            ThemeEditorWindow wnd = ThemeEditorWindows.FirstOrDefault(w => AreEqualPaths(w.FilePath, filePath));
            if (wnd != null)
            {
                wnd.Activate();
                return wnd;
            }

            // Check if the fileName is the Current Theme, then open a window to that theme
            wnd = new ThemeEditorWindow();
            wnd.DockPanel = DockPanel;
            if (!string.IsNullOrWhiteSpace(filePath)) {
                wnd.LoadFromFile(filePath);
            }
            wnd.Show(DockPanel);
            wnd.Activate();
            return wnd;
        }

        public static OpenFileDialog OpenFileDialog { get; set; }

        public static SaveFileDialog SaveFileDialog { get; set; }

        private static ThemeSerializer Serializer = new();

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


        public static Theme? LoadFromFile(string filePath, bool useDefault = false)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                if (useDefault) return DefaultTheme;
                throw new Exception("No Theme file given");
            }
            if (filePath.StartsWith(".."))
            {
                filePath = Path.Combine(ThemeManager.ThemesPath, filePath);
                filePath = Path.GetFullPath(filePath);
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
                    if (useDefault) return DefaultTheme;
                    throw new Exception($"Can't find Theme file '{filePath}'");
                }
                var jsonString = File.ReadAllText(filePath);
                result = Serializer.Deserialize(jsonString);
                result.Setup();
            }
            else
            {
                if (useDefault) return DefaultTheme;
                throw new Exception("Theme file must have extension '.json'");
            }
            result.FilePath = filePath;
            return result;
        }

        public static void SaveToFile(ThemeEditorWindow wnd, string filePath)
        {
            try
            {
                var fileExt = Path.GetExtension(filePath);
                if (fileExt == null)
                {
                    filePath += ".json";
                    fileExt = "json";
                }
                if (fileExt.ToLower() != ".json")
                {
                    MessageBox.Show("Error: File must have extension '.json'");
                    return;
                }
                string jsonString = Serializer.Serialize(wnd.Theme);
                File.WriteAllText(filePath, jsonString);
                //wnd.FilePath = filePath;
                wnd.Theme.FilePath = filePath;
                UpdateTabTexts();
                if (wnd.IsCurrent) SetTheme(wnd.FilePath);
            }
            catch (Exception ex)
            {
                UserMessages.ErrorMessage(ex.Message, "ThemeManager.SaveToFile");
            }
        }

        private static int newThemeCount = 1;

        public static Theme CreateNew(string tempName = null)
        {
            var result = CopyTheme(DockPanel.GetDefaultTheme());  // Should DockPane.GetDefaultTheme() be used instead?
            result.TempName = tempName ?? "New" + newThemeCount++;
            return result;
        }

        public static SetThemeAction SetThemeAction { get; set; } = (x) => throw new Exception("ThemeManager.SetThemeAction not set");


        public static void SetTheme(string filePath = null)
        {
            try
            {
                var theme = LoadFromFile(filePath);
                SetThemeAction(theme);
            }
            catch (Exception e)
            {
                UserMessages.ErrorMessage(e.Message, "ThemeManager.SetTheme");
            }
        }

        public static Theme CopyTheme(Theme theme = null)
        {
            if (theme == null) return null;
            Theme result = null;
            var jsonString = Serializer.Serialize(theme);
            result = Serializer.Deserialize(jsonString);
            result.Setup();
            return result;
        }


        // Commands

        public static void CmdThemeChangeTo(ThemeEditorWindow wnd = null)
        {
            if (wnd == null) wnd = FindActiveThemeEditorWindow();
            SetTheme(wnd.FilePath);
            UpdateTabTexts();
        }


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

        public static void CmdThemeNew()
        {
            CreateNewThemeEditorWindow();  
        }


        public static void CmdThemeOpenCurrent()
        {
            ThemeEditorWindow wnd = FindCurrentThemeEditorWindow();
            if (wnd != null) wnd.Activate();
            else CreateOrReuseThemeEditorWindow(DockPanel.Theme.FilePath);
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

        public static void CmdThemeReset(ThemeEditorWindow wnd = null)
        {
            if (wnd == null) wnd = FindActiveThemeEditorWindow();
            if (wnd != null)
            {
                try
                {
                    wnd.Theme = ThemeManager.LoadFromFile(wnd.FilePath);
                }
                catch (Exception e)
                {
                    UserMessages.ErrorMessage(e.Message, "ThemeManager.CmdThemeSaveAs");
                }
            }
            else
            {
                UserMessages.InfoMessage("No active Theme editor window found", "ThemeManager.CmdThemeSaveAs");
            }
        }

        public static void CmdThemeSaveAs(ThemeEditorWindow wnd = null)
        {
            if (wnd == null) wnd = FindActiveThemeEditorWindow();
            if (wnd != null)
            {
                var result = SaveFileDialog.ShowDialog(MainForm);
                if (result == DialogResult.OK)
                {
                    try
                    {
                        SaveToFile(wnd, SaveFileDialog.FileName);
                    }
                    catch (Exception e)
                    {
                        UserMessages.ErrorMessage(e.Message, "ThemeManager.CmdThemeSaveAs");
                    }
                }
                MainForm.Activate();
            }
            else
            {
                UserMessages.InfoMessage("No active Theme editor window found", "ThemeManager.CmdThemeSaveAs");
            }
        }

        public static void CmdThemeSave(ThemeEditorWindow wnd = null)
        {
            if (wnd == null) wnd = FindActiveThemeEditorWindow();
            if (wnd != null)
            {
                try
                {
                    SaveToFile(wnd, wnd.FilePath);
                }
                catch (Exception e)
                {
                    UserMessages.ErrorMessage(e.Message, "ThemeManager.CmdThemeSave");
                }
            }
            else
            {
                UserMessages.InfoMessage("No active Theme editor window found", "Information from ThemeManager.CmdThemeSave");
            }
        }


        // Setup

        public static void Setup(string defaultThemeName = "default")
        {
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
                //DefaultTheme = LoadFromFile(defaultThemeName);
                DefaultTheme = new Theme();
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

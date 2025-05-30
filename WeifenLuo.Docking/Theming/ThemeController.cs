using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using ThemeEditor;
using WeifenLuo.Docking;

namespace WeifenLuo.Docking
{

    public static class ThemeController
    {
        public static Theme EmptyTheme = new Theme();

        public static Theme DefaultTheme { get; set; }

        public static List<ThemeEditorWindow> ThemeEditorWindows = new();

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


        public static ThemeEditorWindow CreateNewThemeEditor(string? fileName = null)
        {
            ThemeEditorWindow newWnd = new ThemeEditorWindow();
            if (!string.IsNullOrWhiteSpace(fileName)) newWnd.FileName = fileName;
            return newWnd;
        }

        public static OpenFileDialog OpenFileDialog { get; set; }

        public static SaveFileDialog SaveFileDialog { get; set; }


        private static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions();

        public static string ThemesPath { get; set; }

        public static Theme? LoadFromFile(string fileName)
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
            if (string.IsNullOrEmpty(fileExt))
            {
                fileName += ".json";
                fileExt = ".json";
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
                throw new Exception("Theme file must have extension '.json'");
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


    }

}

using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using ThemeEditor;
using WeifenLuo.Docking;

namespace WeifenLuo.Docking
{

    public class ThemeController : Component
    {

        public Theme EmptyTheme = new Theme();

        public List<ThemeEditorWindow> ThemeEditorWindows = new();




        /// <summary>
        /// Searches for a ThemeEditorWindow with the given name
        /// </summary>
        /// <param name="fileName">full filepath with extension or filename only (without extension)</param>
        /// <returns>A ThemeEditorWindow with matching name or null</returns>
        /// Search is done first assuming fileName is a full filePath with extension, then on the fileName only (without path and extension)
        public ThemeEditorWindow? FindThemeEditorWindow(string fileName)
        {
            var fileNameOnly = Path.GetFileNameWithoutExtension(fileName);
            var result = ThemeEditorWindows.FirstOrDefault(w => w.FileName == fileName) ?? ThemeEditorWindows.FirstOrDefault(w => w.FileName == fileNameOnly);
            return result;
        }


        public ThemeEditorWindow CreateNewThemeEditor(string? fileName = null)
        {
            ThemeEditorWindow newWnd = new ThemeEditorWindow();
            if (!string.IsNullOrWhiteSpace(fileName)) newWnd.FileName = fileName;
            return newWnd;
        }

        public OpenFileDialog openThemeFileDialog { get; set; }

        public SaveFileDialog saveThemeFileDialog { get; set; }


        private static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions();

        public string ThemesPath { get; set; }

        public Theme LoadFromFile(string fileName)
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

        private int newThemeCount = 1;

        public Theme CreateNew(string tempName = null)
        {
            var result = new Theme();
            result.TempName = tempName ?? "NewTheme" + newThemeCount++;
            return result;
        }

        public ThemeController() : base()
        {
            JsonSerializerOptions.WriteIndented = true;
            JsonSerializerOptions.Converters.Add(new ColorJsonConverter());
            ThemesPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Themes");


            openThemeFileDialog = new OpenFileDialog();
            saveThemeFileDialog = new SaveFileDialog();

            // 
            // openFileDialog1
            // 
            openThemeFileDialog.DefaultExt = "json";
            openThemeFileDialog.FileName = "openFileDialog1";
            openThemeFileDialog.Filter = "JSON files|*.json|All files|*.*";
            openThemeFileDialog.Title = "Open Theme";
            openThemeFileDialog.InitialDirectory = ThemesPath;
            // 
            // saveFileDialog1
            // 
            saveThemeFileDialog.DefaultExt = "json";
            saveThemeFileDialog.Filter = "JSON files|*.json|All files|*.*";
            saveThemeFileDialog.Title = "Save Theme";
            saveThemeFileDialog.InitialDirectory = ThemesPath;


        }


    }

}

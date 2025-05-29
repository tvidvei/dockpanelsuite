using System.ComponentModel;
using System.Windows.Forms;
using WeifenLuo.Docking;

namespace ThemeEditor
{

    public class ThemeController : Component
    {

        public static Theme EmptyTheme = new Theme();

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


        public static ThemeEditorWindow CreateNew(string? fileName = null)
        {
            ThemeEditorWindow newWnd = new ThemeEditorWindow();
            if (!string.IsNullOrWhiteSpace(fileName)) newWnd.FileName = fileName;
            return newWnd;
        }

        public OpenFileDialog openThemeFileDialog { get; set; }

        public SaveFileDialog saveThemeFileDialog { get; set; }


        public ThemeController() : base()
        {
            openThemeFileDialog = new OpenFileDialog();
            saveThemeFileDialog = new SaveFileDialog();

            // 
            // openFileDialog1
            // 
            openThemeFileDialog.DefaultExt = "json";
            openThemeFileDialog.FileName = "openFileDialog1";
            openThemeFileDialog.Filter = "JSON files|*.json|All files|*.*";
            openThemeFileDialog.Title = "Open Theme";
            // 
            // saveFileDialog1
            // 
            saveThemeFileDialog.DefaultExt = "json";
            saveThemeFileDialog.Filter = "JSON files|*.json|All files|*.*";
            saveThemeFileDialog.Title = "Save Theme";


        }


    }

}

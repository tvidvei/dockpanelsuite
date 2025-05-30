namespace WeifenLuo.Docking
{
    public partial class ThemeEditorWindow : DockContent
    {

        public ThemeEditorWindow()
        {
            InitializeComponent();
            Theme = Theme.CreateNew();
        }

        public ThemeEditorWindow(string? fileName)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(fileName)) Theme = Theme.CreateNew();
            else FileName = fileName;
        }

        public Theme Theme
        {
            get { return (propertyGrid.SelectedObject as Theme)!; }
            set {
                var theme = value ?? Theme.CreateNew();
                propertyGrid.SelectedObject = theme;
                this.TabText = "Theme: " 
                    + theme.DisplayName
                    + (theme == (DockPanel?.Theme ?? null) ? " (Current)" : null)
                    ;
                this.ToolTipText = ""
                    + theme.DisplayPath
                    ;
            }
        }

        public string FileName
        {
            get { return Theme.FileName; }
            set
            {
                try
                {
                    Theme = ThemeController.LoadFromFile(value);
                    this.ToolTipText = value;
                }
                catch (Exception e)
                {
                    MessageBox.Show(Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        protected override string GetPersistString()
        {
            // Add extra information into the persist string for this document
            // so that it is available when deserialized.
            return GetType().ToString() + "," + FileName + "," + Text;
        }


        // Static methods

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

    }
}
namespace WeifenLuo.Docking
{
    public partial class ThemeEditorWindow : DockContent
    {

        public ThemeEditorWindow() : base()
        {
            InitializeComponent();
            ThemeManager.ThemeEditorWindows.Add(this);
        }

        public ThemeEditorWindow(string? fileName)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(fileName)) Theme = ThemeManager.CreateNew();
            else FileName = fileName;
        }

        public void SetTabText()
        {
            if (Theme == null)
            {
                this.TabText = "Theme: null"
                    ;
                this.ToolTipText = ""
                    ;
            }
            else
            {
                this.TabText = "Theme: "
                    + Theme.DisplayName
                    + (DockPanel!= null && ThemeManager.AreEqualPaths(FileName, DockPanel.Theme.FileName) ? " (Current)" : null)
                    ;
                this.ToolTipText = ""
                    + Theme.DisplayPath
                    ;
            }
        }

        public Theme Theme
        {
            get { return (propertyGrid.SelectedObject as Theme)!; }
            set
            {
                var theme = value ?? ThemeManager.CreateNew();
                propertyGrid.SelectedObject = theme;
                SetTabText();
            }
        }

        public string FileName
        {
            get { return Theme.FileName; }
            set
            {
                try
                {
                    Theme = ThemeManager.LoadFromFile(value);
                }
                catch (Exception e)
                {
                    UserMessages.ErrorMessage(e.Message, Text);
                }

            }
        }

        public string FilePath
        {
            get { return Theme.FilePath; }
            set
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        Theme = ThemeManager.LoadFromFile(value);
                    }
                }
                catch (Exception e)
                {
                    UserMessages.ErrorMessage(e.Message, Text);
                }

            }
        }

        public bool IsCurrent => ThemeManager.AreEqualPaths(FilePath, DockPanel?.Theme.FilePath);

        protected override string GetPersistString()
        {
            if (string.IsNullOrWhiteSpace(FileName))
            {
                // New unsaved Theme. Save under temporary name
                ThemeManager.SaveToFile(this, ThemeManager.GetFilePath("~" + Theme.TempName));

            }
            // Add extra information into the persist string for this document
            // so that it is available when deserialized.
            return GetType().ToString() + "," + FileName + "," + Text;
        }

        private void ThemeEditorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThemeManager.ThemeEditorWindows.Remove(this);
        }

    }

}
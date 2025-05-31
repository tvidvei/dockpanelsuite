namespace WeifenLuo.Docking
{
    public partial class ThemeEditorWindow : DockContent
    {

        public ThemeEditorWindow() : base()
        {
            InitializeComponent();
            ThemeManager.ThemeEditorWindows.Add(this);
            //Theme = ThemeManager.CreateNew();
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
                    + (Theme == (DockPanel?.Theme ?? null) ? " (Current)" : null)
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

        private void ThemeEditorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThemeManager.ThemeEditorWindows.Remove(this);
        }

        private void ThemeEditorWindow_VisibleChanged(object sender, EventArgs e)
        {
            int i = 10;  // Dummy
        }
    }

}
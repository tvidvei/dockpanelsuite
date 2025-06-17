using WinFormsUtilities;

namespace WeifenLuo.Docking
{
    public partial class ThemeEditorWindow : DockContent
    {

        private PropertyGridEditHistoryManager EditHistoryManager;

        public ThemeEditorWindow() : base()
        {
            InitializeComponent();
            EditHistoryManager = new(propertyGrid);
            ThemeManager.ThemeEditorWindows.Add(this);
        }

        public ThemeEditorWindow(string? fileName)
        {
            InitializeComponent();
            EditHistoryManager = new(propertyGrid);
            if (string.IsNullOrEmpty(fileName)) Theme = ThemeManager.CreateNew();
            else LoadFromFile(fileName);
        }

        public bool IsChanged => EditHistoryManager.IsChanged;

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
                    + (IsChanged ? "*" : null)
                    + (DockPanel != null && ThemeManager.AreEqualPaths(FileName, DockPanel.Theme.FileName) ? " (Current)" : null)
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
                EditHistoryManager.Clear();
                SetTabText();
            }
        }


        public string FileName => Theme?.FileName ?? "null";

        public void LoadFromFile(string filePath)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    Theme = ThemeManager.LoadFromFile(filePath);
                }
            }
            catch (Exception e)
            {
                UserMessages.ErrorMessage(e.Message, Text);
            }
        }


        public string FilePath => Theme?.FilePath ?? "null";

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

        private void PropertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            EditHistoryManager.AddEdit(e.ChangedItem!, e.OldValue, e.ChangedItem!.Value);
            EditHistoryManager.PropertyGrid.Refresh();
            SetTabText();
        }

        private void ThemeEditorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThemeManager.ThemeEditorWindows.Remove(this);
        }

        private void miThemeUseThis_Click(object sender, EventArgs e)
        {
            ThemeManager.CmdThemeChangeTo(this);
        }

        private void miThemeReset_Click(object sender, EventArgs e)
        {
            ThemeManager.CmdThemeReset(this);
            SetTabText();
        }

        private void miThemeSave_Click(object sender, EventArgs e)
        {
            EditHistoryManager.SaveCurrentPos();
            ThemeManager.CmdThemeSave(this);
            SetTabText();
        }

        private void miThemeSaveAs_Click(object sender, EventArgs e)
        {
            EditHistoryManager.SaveCurrentPos();
            ThemeManager.CmdThemeSaveAs(this);
            SetTabText();
        }


        private void miThemeUndo_Click(object sender, EventArgs e)
        {
            EditHistoryManager.UndoEdit();
            SetTabText();
        }

        private void miThemeRedo_Click(object sender, EventArgs e)
        {
            EditHistoryManager.RedoEdit();
            SetTabText();
        }

    }

}
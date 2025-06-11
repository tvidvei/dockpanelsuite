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
            else FileName = fileName;
        }

        private bool isChanged = false;

        public bool IsChanged
        {
            get { return isChanged; }
            set
            {
                if (value == isChanged) return;
                isChanged = value;
                SetTabText();
            }
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
                    + (isChanged ? "*" : null)
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
                SetTabText();
            }
        }

        public string FileName
        {
            get { return Theme?.FileName ?? "null"; }
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
            get { return Theme?.FilePath ?? "null"; }
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

        private void PropertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            IsChanged = true;
            EditHistoryManager.AddEdit(e.ChangedItem!, e.OldValue, e.ChangedItem!.Value);
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
            IsChanged = false;
        }

        private void miThemeSave_Click(object sender, EventArgs e)
        {
            ThemeManager.CmdThemeSave(this);
            IsChanged = false;
        }

        private void miThemeSaveAs_Click(object sender, EventArgs e)
        {
            ThemeManager.CmdThemeSaveAs(this);
            IsChanged = false;
        }


        private void miThemeUndo_Click(object sender, EventArgs e)
        {
            EditHistoryManager.UndoEdit();
            IsChanged = EditHistoryManager.CurrentPos > 0;
        }

        private void miThemeRedo_Click(object sender, EventArgs e)
        {
            EditHistoryManager.RedoEdit();
            IsChanged = EditHistoryManager.CurrentPos > 0;
        }

    }

}
using System;

namespace ThemeEditor
{
    public partial class DummySolutionExplorer : ToolWindow
    {
        public DummySolutionExplorer()
        {
            InitializeComponent();
        }

        protected override void OnRightToLeftLayoutChanged(EventArgs e)
        {
            treeView1.RightToLeftLayout = RightToLeftLayout;
        }
    }
}
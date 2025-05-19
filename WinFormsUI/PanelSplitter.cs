namespace WeifenLuo.Docking
{
    internal class PanelSplitter : SplitterBase
    {
        public PanelSplitter(AutoHidePanelBase autoHidePanel) {
            m_autoHidePanel = autoHidePanel;
        }

        private AutoHidePanelBase m_autoHidePanel;
        private AutoHidePanelBase AutoHidePanel {
            get { return m_autoHidePanel; }
        }

        protected override int SplitterSize {
            get { return AutoHidePanel.DockPanel.Theme.Measures.AutoHideSplitterSize; }
        }

        protected override void StartDrag() {
            AutoHidePanel.DockPanel.BeginDrag(AutoHidePanel, AutoHidePanel.RectangleToScreen(Bounds));
        }
    }

}

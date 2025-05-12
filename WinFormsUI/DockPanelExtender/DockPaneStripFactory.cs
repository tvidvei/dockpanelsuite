namespace WeifenLuo.WinFormsUI.Docking
{
    public class DockPaneStripFactory : DockPanelExtender.IDockPaneStripFactory
    {
        public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
        {
            return new DockPaneStrip(pane);
        }
    }
}

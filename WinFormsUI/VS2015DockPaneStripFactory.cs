using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2013
{
    public class VS2015DockPaneStripFactory : DockPanelExtender.IDockPaneStripFactory
    {
        public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
        {
            return new DockPaneStrip(pane);
        }
    }
}

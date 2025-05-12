namespace WeifenLuo.WinFormsUI.Docking
{
    internal class DockWindowFactory : DockPanelExtender.IDockWindowFactory
    {
        public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
        {
            return new DockWindow(dockPanel, dockState);
        }
    }
}

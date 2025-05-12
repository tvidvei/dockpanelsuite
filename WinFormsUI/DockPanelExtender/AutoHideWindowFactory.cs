namespace WeifenLuo.Docking
{
    internal class AutoHideWindowFactory : DockPanelExtender.IAutoHideWindowFactory
    {
        public AutoHideWindowControlBase CreateAutoHideWindow(DockPanel panel)
        {
            return new AutoHideWindowControl(panel);
        }
    }
}

namespace WeifenLuo.WinFormsUI.Docking
{
    [VS2015]
    internal class AutoHideStripFactory : DockPanelExtender.IAutoHideStripFactory
    {
        public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
        {
            return new AutoHideStrip(panel);
        }
    }
}

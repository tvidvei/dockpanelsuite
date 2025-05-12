namespace WeifenLuo.WinFormsUI.Docking
{
    internal class AutoHideStripFactory : DockPanelExtender.IAutoHideStripFactory
    {
        public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
        {
            return new AutoHideStrip(panel);
        }
    }
}

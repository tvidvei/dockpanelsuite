using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012
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

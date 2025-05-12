using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012
{
    internal class VS2015AutoHideWindowFactory : DockPanelExtender.IAutoHideWindowFactory
    {
        public AutoHideWindowControlBase CreateAutoHideWindow(DockPanel panel)
        {
            return new AutoHideWindowControl(panel);
        }
    }
}

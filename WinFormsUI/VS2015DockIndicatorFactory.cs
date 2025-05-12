using WeifenLuo.WinFormsUI.Docking;

namespace WeifenLuo.WinFormsUI.ThemeVS2012
{
    internal class VS2015DockIndicatorFactory : DockPanelExtender.IDockIndicatorFactory
    {
        public DockDragHandler.DockIndicator CreateDockIndicator(DockDragHandler dockDragHandler)
        {
            return new DockDragHandler.DockIndicator(dockDragHandler) { Opacity = 0.7 };
        }
    }
}
namespace WeifenLuo.WinFormsUI.Docking
{
    internal class DockIndicatorFactory : DockPanelExtender.IDockIndicatorFactory
    {
        public DockDragHandler.DockIndicator CreateDockIndicator(DockDragHandler dockDragHandler)
        {
            return new DockDragHandler.DockIndicator(dockDragHandler) { Opacity = 0.7 };
        }
    }
}
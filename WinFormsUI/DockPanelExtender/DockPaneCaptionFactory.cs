namespace WeifenLuo.WinFormsUI.Docking
{
    internal class DockPaneCaptionFactory : DockPanelExtender.IDockPaneCaptionFactory
    {
        public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
        {
            return new DockPaneCaption(pane);
        }
    }
}

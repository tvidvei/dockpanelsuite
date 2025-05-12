namespace WeifenLuo.Docking
{
    internal class DockPaneSplitterControlFactory : DockPanelExtender.IDockPaneSplitterControlFactory
    {
        public PaneSplitterControlBase CreateSplitterControl(DockPane pane)
        {
            return new PaneSplitterControl(pane);
        }
    }
}

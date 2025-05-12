namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2015DockPaneSplitterControlFactory : DockPanelExtender.IDockPaneSplitterControlFactory
    {
        public PaneSplitterControlBase CreateSplitterControl(DockPane pane)
        {
            return new PaneSplitterControl(pane);
        }
    }
}

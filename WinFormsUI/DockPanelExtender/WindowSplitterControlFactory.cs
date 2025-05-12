namespace WeifenLuo.WinFormsUI.Docking
{
    internal class WindowSplitterControlFactory : DockPanelExtender.IWindowSplitterControlFactory
    {
        public SplitterBase CreateSplitterControl(ISplitterHost host)
        {
            return new WindowSplitterControl(host);
        }
    }
}

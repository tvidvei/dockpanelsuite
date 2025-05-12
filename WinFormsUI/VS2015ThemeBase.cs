namespace WeifenLuo.WinFormsUI.ThemeVS2015
{
    using ThemeVS2012;
    using ThemeVS2013;
    using Docking;

    /// <summary>
    /// Visual Studio 2015 theme base.
    /// </summary>
    public abstract class VS2015ThemeBase : ThemeBase
    {
        public VS2015ThemeBase(byte[] resources)
        {
            ColorPalette = new DockPanelColorPalette(new VS2015PaletteFactory(resources));
            Skin = new DockPanelSkin();
            PaintingService = new PaintingService();
            ImageService = new ImageService(this);
            ToolStripRenderer = new VisualStudioToolStripRenderer(ColorPalette)
            {
                UseGlassOnMenuStrip = false,
            };
            Measures.SplitterSize = 6;
            Measures.AutoHideSplitterSize = 3;
            Measures.DockPadding = 6;
            ShowAutoHideContentOnHover = false;
            Extender.AutoHideStripFactory = new AutoHideStripFactory();
            Extender.AutoHideWindowFactory = new VS2015AutoHideWindowFactory();
            Extender.DockPaneFactory = new VS2015DockPaneFactory();
            Extender.DockPaneCaptionFactory = new VS2015DockPaneCaptionFactory();
            Extender.DockPaneStripFactory = new VS2015DockPaneStripFactory();
            Extender.DockPaneSplitterControlFactory = new VS2015DockPaneSplitterControlFactory();
            Extender.WindowSplitterControlFactory = new VS2015WindowSplitterControlFactory();
            Extender.DockWindowFactory = new VS2015DockWindowFactory();
            Extender.PaneIndicatorFactory = new VS2015PaneIndicatorFactory();
            Extender.PanelIndicatorFactory = new VS2015PanelIndicatorFactory();
            Extender.DockOutlineFactory = new VS2015DockOutlineFactory();
            Extender.DockIndicatorFactory = new VS2015DockIndicatorFactory();
        }

        public override void CleanUp(DockPanel dockPanel)
        {
            PaintingService.CleanUp();
            base.CleanUp(dockPanel);
        }
    }
}

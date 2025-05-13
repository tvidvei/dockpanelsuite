namespace WeifenLuo.Docking
{

    /// <summary>
    /// Visual Studio 2015 theme base.
    /// </summary>
    public abstract class VS2015ThemeBase : ThemeBase
    {
        public VS2015ThemeBase(byte[] resources)
        {
            ColorPalette = new DockPanelColorPalette(new PaletteFactory(resources));
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
            Extender.AutoHideWindowFactory = new AutoHideWindowFactory();
            Extender.DockPaneCaptionFactory = new DockPaneCaptionFactory();
            Extender.DockPaneStripFactory = new DockPaneStripFactory();
            Extender.DockWindowFactory = new DockWindowFactory();
            Extender.PaneIndicatorFactory = new PaneIndicatorFactory();
            Extender.PanelIndicatorFactory = new PanelIndicatorFactory();
            Extender.DockOutlineFactory = new DockOutlineFactory();
            Extender.DockIndicatorFactory = new DockIndicatorFactory();
        }

        public override void CleanUp(DockPanel dockPanel)
        {
            PaintingService.CleanUp();
            base.CleanUp(dockPanel);
        }
    }
}

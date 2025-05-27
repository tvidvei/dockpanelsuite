using System.Drawing;

namespace WeifenLuo.Docking
{
    public class ImageService : IImageService
    {
        public Bitmap Dockindicator_PaneDiamond { get; internal set; }
        public Bitmap Dockindicator_PaneDiamond_Fill { get; internal set; }
        public Bitmap Dockindicator_PaneDiamond_Hotspot { get; internal set; }
        public Bitmap DockIndicator_PaneDiamond_HotspotIndex { get; internal set; }
        public Image DockIndicator_PanelBottom { get; internal set; }
        public Image DockIndicator_PanelFill { get; internal set; }
        public Image DockIndicator_PanelLeft { get; internal set; }
        public Image DockIndicator_PanelRight { get; internal set; }
        public Image DockIndicator_PanelTop { get; internal set; }
        public Bitmap DockPane_Close { get; internal set; }
        public Bitmap DockPane_List { get; internal set; }
        public Bitmap DockPane_Dock { get; internal set; }
        public Bitmap DockPaneActive_AutoHide { get; internal set; }
        public Bitmap DockPane_Option { get; internal set; }
        public Bitmap DockPane_OptionOverflow { get; internal set; }
        public Bitmap DockPaneActive_Close { get; }
        public Bitmap DockPaneActive_Dock { get; }
        public Bitmap DockPaneActive_Option { get; }
        public Bitmap DockPaneHover_Close { get; internal set; }
        public Bitmap DockPaneHover_List { get; internal set; }
        public Bitmap DockPaneHover_Dock { get; internal set; }
        public Bitmap DockPaneActiveHover_AutoHide { get; internal set; }
        public Bitmap DockPaneHover_Option { get; internal set; }
        public Bitmap DockPaneHover_OptionOverflow { get; internal set; }
        public Bitmap DockPanePress_Close { get; internal set; }
        public Bitmap DockPanePress_List { get; internal set; }
        public Bitmap DockPanePress_Dock { get; internal set; }
        public Bitmap DockPanePress_AutoHide { get; internal set; }
        public Bitmap DockPanePress_Option { get; internal set; }
        public Bitmap DockPanePress_OptionOverflow { get; internal set; }
        public Bitmap DockPaneActiveHover_Close { get; }
        public Bitmap DockPaneActiveHover_Dock { get; }
        public Bitmap DockPaneActiveHover_Option { get; }
        public Image TabHoverActive_Close { get; internal set; }
        public Image TabActive_Close { get; internal set; }
        public Image TabInactive_Close { get; internal set; }
        public Image TabHoverInactive_Close { get; internal set; }
        public Image TabHoverLostFocus_Close { get; internal set; }
        public Image TabLostFocus_Close { get; internal set; }
        public Image TabPressActive_Close { get; }
        public Image TabPressInactive_Close { get; }
        public Image TabPressLostFocus_Close { get; }

        readonly DockPanelColorPalette _palette;

        public ImageService(ThemeBase theme)
        {
            _palette = theme.ColorPalette;
            Dockindicator_PaneDiamond_Hotspot = Resources.GetBitmap("Dockindicator_PaneDiamond_Hotspot.png");
            DockIndicator_PaneDiamond_HotspotIndex = Resources.GetBitmap("DockIndicator_PaneDiamond_HotspotIndex.png");

            var arrow = _palette.DockTarget.GlyphArrow;
            var outerBorder = _palette.DockTarget.Border;
            var separator = _palette.DockTarget.ButtonBorder;
            var innerBorder = _palette.DockTarget.Background;
            var background = _palette.DockTarget.ButtonBackground;
            var window = _palette.DockTarget.GlyphBorder;
            var core = _palette.DockTarget.GlyphBackground;
            var drawCore = core.ToArgb() != background.ToArgb();

            using (var layerArrow = ImageServiceHelper.GetLayerImage(arrow, 32, theme.PaintingService))
            using (var layerWindow = ImageServiceHelper.GetLayerImage(window, 32, theme.PaintingService))
            using (var layerCore = drawCore ? ImageServiceHelper.GetLayerImage(core, 32, theme.PaintingService) : null)
            using (var layerBorder = ImageServiceHelper.GetBackground(innerBorder, outerBorder, 40, theme.PaintingService))
            using (var bottom = ImageServiceHelper.GetDockIcon(
                Resources.GetBitmap("MaskArrowBottom.png"),
                layerArrow,
                Resources.GetBitmap("MaskWindowBottom.png"),
                layerWindow,
                Resources.GetBitmap("MaskDock.png"),
                background,
                theme.PaintingService,
                Resources.GetBitmap("MaskCoreBottom.png"),
                layerCore,
                separator))
            using (var center = ImageServiceHelper.GetDockIcon(
                null,
                null,
                Resources.GetBitmap("MaskWindowCenter.png"),
                layerWindow,
                Resources.GetBitmap("MaskDock.png"),
                background,
                theme.PaintingService,
                Resources.GetBitmap("MaskCoreCenter.png"),
                layerCore,
                separator))
            using (var left = ImageServiceHelper.GetDockIcon(
                Resources.GetBitmap("MaskArrowLeft.png"),
                layerArrow,
                Resources.GetBitmap("MaskWindowLeft.png"),
                layerWindow,
                Resources.GetBitmap("MaskDock.png"),
                background,
                theme.PaintingService,
                Resources.GetBitmap("MaskCoreLeft.png"),
                layerCore,
                separator))
            using (var right = ImageServiceHelper.GetDockIcon(
                Resources.GetBitmap("MaskArrowRight.png"),
                layerArrow,
                Resources.GetBitmap("MaskWindowRight.png"),
                layerWindow,
                Resources.GetBitmap("MaskDock.png"),
                background,
                theme.PaintingService,
                Resources.GetBitmap("MaskCoreRight.png"),
                layerCore,
                separator))
            using (var top = ImageServiceHelper.GetDockIcon(
                Resources.GetBitmap("MaskArrowTop.png"),
                layerArrow,
                Resources.GetBitmap("MaskWindowTop.png"),
                layerWindow,
                Resources.GetBitmap("MaskDock.png"),
                background,
                theme.PaintingService,
                Resources.GetBitmap("MaskCoreTop.png"),
                layerCore,
                separator))
            {
                DockIndicator_PanelBottom = ImageServiceHelper.GetDockImage(bottom, layerBorder);
                DockIndicator_PanelFill = ImageServiceHelper.GetDockImage(center, layerBorder);
                DockIndicator_PanelLeft = ImageServiceHelper.GetDockImage(left, layerBorder);
                DockIndicator_PanelRight = ImageServiceHelper.GetDockImage(right, layerBorder);
                DockIndicator_PanelTop = ImageServiceHelper.GetDockImage(top, layerBorder);

                using (var five = ImageServiceHelper.GetFiveBackground(Resources.GetBitmap("MaskDockFive.png"), innerBorder, outerBorder, theme.PaintingService))
                {
                    Dockindicator_PaneDiamond = ImageServiceHelper.CombineFive(five, bottom, center, left, right, top);
                    Dockindicator_PaneDiamond_Fill = ImageServiceHelper.CombineFive(five, bottom, center, left, right, top);
                }
            }

            TabActive_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabClose.png"), _palette.TabSelectedActive.Button, _palette.TabSelectedActive.Background);
            TabInactive_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabClose.png"), _palette.TabUnselectedHovered.Button, _palette.TabUnselectedHovered.Background);
            TabLostFocus_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabClose.png"), _palette.TabSelectedInactive.Button, _palette.TabSelectedInactive.Background);
            TabHoverActive_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabClose.png"), _palette.TabButtonSelectedActiveHovered.Glyph, _palette.TabButtonSelectedActiveHovered.Background, _palette.TabButtonSelectedActiveHovered.Border);
            TabHoverInactive_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabClose.png"), _palette.TabButtonUnselectedTabHoveredButtonHovered.Glyph, _palette.TabButtonUnselectedTabHoveredButtonHovered.Background, _palette.TabButtonUnselectedTabHoveredButtonHovered.Border);
            TabHoverLostFocus_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabClose.png"), _palette.TabButtonSelectedInactiveHovered.Glyph, _palette.TabButtonSelectedInactiveHovered.Background, _palette.TabButtonSelectedInactiveHovered.Border);

            TabPressActive_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabClose.png"), _palette.TabButtonSelectedActivePressed.Glyph, _palette.TabButtonSelectedActivePressed.Background, _palette.TabButtonSelectedActivePressed.Border);
            TabPressInactive_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabClose.png"), _palette.TabButtonUnselectedTabHoveredButtonPressed.Glyph, _palette.TabButtonUnselectedTabHoveredButtonPressed.Background, _palette.TabButtonUnselectedTabHoveredButtonPressed.Border);
            TabPressLostFocus_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabClose.png"), _palette.TabButtonSelectedInactivePressed.Glyph, _palette.TabButtonSelectedInactivePressed.Background, _palette.TabButtonSelectedInactivePressed.Border);

            DockPane_List = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabList.png"), _palette.OverflowButtonDefault.Glyph, _palette.MainWindowActive.Background);
            DockPane_OptionOverflow = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabOverflow.png"), _palette.OverflowButtonDefault.Glyph, _palette.MainWindowActive.Background);

            DockPaneHover_List = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabList.png"), _palette.OverflowButtonHovered.Glyph, _palette.OverflowButtonHovered.Background, _palette.OverflowButtonHovered.Border);
            DockPaneHover_OptionOverflow = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabOverflow.png"), _palette.OverflowButtonHovered.Glyph, _palette.OverflowButtonHovered.Background, _palette.OverflowButtonHovered.Border);

            DockPanePress_List = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabList.png"), _palette.OverflowButtonPressed.Glyph, _palette.OverflowButtonPressed.Background, _palette.OverflowButtonPressed.Border);
            DockPanePress_OptionOverflow = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskTabOverflow.png"), _palette.OverflowButtonPressed.Glyph, _palette.OverflowButtonPressed.Background, _palette.OverflowButtonPressed.Border);

            DockPane_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowClose.png"), _palette.ToolWindowCaptionInactive.Button, _palette.ToolWindowCaptionInactive.Background);
            DockPane_Dock = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowDock.png"), _palette.ToolWindowCaptionInactive.Button, _palette.ToolWindowCaptionInactive.Background);
            DockPane_Option = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowOption.png"), _palette.ToolWindowCaptionInactive.Button, _palette.ToolWindowCaptionInactive.Background);

            DockPaneActive_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowClose.png"), _palette.ToolWindowCaptionActive.Button, _palette.ToolWindowCaptionActive.Background);
            DockPaneActive_Dock = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowDock.png"), _palette.ToolWindowCaptionActive.Button, _palette.ToolWindowCaptionActive.Background);
            DockPaneActive_Option = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowOption.png"), _palette.ToolWindowCaptionActive.Button, _palette.ToolWindowCaptionActive.Background);
            DockPaneActive_AutoHide = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowAutoHide.png"), _palette.ToolWindowCaptionActive.Button, _palette.ToolWindowCaptionActive.Background);

            DockPaneHover_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowClose.png"), _palette.ToolWindowCaptionButtonInactiveHovered.Glyph, _palette.ToolWindowCaptionButtonInactiveHovered.Background, _palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneHover_Dock = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowDock.png"), _palette.ToolWindowCaptionButtonInactiveHovered.Glyph, _palette.ToolWindowCaptionButtonInactiveHovered.Background, _palette.ToolWindowCaptionButtonInactiveHovered.Border);
            DockPaneHover_Option = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowOption.png"), _palette.ToolWindowCaptionButtonInactiveHovered.Glyph, _palette.ToolWindowCaptionButtonInactiveHovered.Background, _palette.ToolWindowCaptionButtonInactiveHovered.Border);

            DockPaneActiveHover_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowClose.png"), _palette.ToolWindowCaptionButtonActiveHovered.Glyph, _palette.ToolWindowCaptionButtonActiveHovered.Background, _palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPaneActiveHover_Dock = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowDock.png"), _palette.ToolWindowCaptionButtonActiveHovered.Glyph, _palette.ToolWindowCaptionButtonActiveHovered.Background, _palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPaneActiveHover_Option = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowOption.png"), _palette.ToolWindowCaptionButtonActiveHovered.Glyph, _palette.ToolWindowCaptionButtonActiveHovered.Background, _palette.ToolWindowCaptionButtonActiveHovered.Border);
            DockPaneActiveHover_AutoHide = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowAutoHide.png"), _palette.ToolWindowCaptionButtonActiveHovered.Glyph, _palette.ToolWindowCaptionButtonActiveHovered.Background, _palette.ToolWindowCaptionButtonActiveHovered.Border);

            DockPanePress_Close = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowClose.png"), _palette.ToolWindowCaptionButtonPressed.Glyph, _palette.ToolWindowCaptionButtonPressed.Background, _palette.ToolWindowCaptionButtonPressed.Border);
            DockPanePress_Dock = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowDock.png"), _palette.ToolWindowCaptionButtonPressed.Glyph, _palette.ToolWindowCaptionButtonPressed.Background, _palette.ToolWindowCaptionButtonPressed.Border);
            DockPanePress_Option = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowOption.png"), _palette.ToolWindowCaptionButtonPressed.Glyph, _palette.ToolWindowCaptionButtonPressed.Background, _palette.ToolWindowCaptionButtonPressed.Border);
            DockPanePress_AutoHide = ImageServiceHelper.GetImage(Resources.GetBitmap("MaskToolWindowAutoHide.png"), _palette.ToolWindowCaptionButtonPressed.Glyph, _palette.ToolWindowCaptionButtonPressed.Background, _palette.ToolWindowCaptionButtonPressed.Border);
        }
    }
}
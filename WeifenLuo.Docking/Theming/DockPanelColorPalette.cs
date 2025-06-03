using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeifenLuo.Docking
{

    public class DockPanelColorPalette
    {

        public DockPanelColorPalette() { }

        public DockPanelColorPalette(bool setup) : this() 
        {
            var res = new DockPanelColorPalette();

            if (setup) {
                AutoHideStripDefault = new AutoHideStripPalette();
                AutoHideStripHovered = new AutoHideStripPalette();
                OverflowButtonDefault = new ButtonPalette();
                OverflowButtonHovered = new HoveredButtonPalette();
                OverflowButtonPressed = new HoveredButtonPalette();
                TabSelectedActive = new TabPalette();
                TabSelectedInactive = new TabPalette();
                TabUnselected = new UnselectedTabPalette();
                TabUnselectedHovered = new TabPalette();
                TabButtonSelectedActiveHovered = new HoveredButtonPalette();
                TabButtonSelectedActivePressed = new HoveredButtonPalette();
                TabButtonSelectedInactiveHovered = new HoveredButtonPalette();
                TabButtonSelectedInactivePressed = new HoveredButtonPalette();
                TabButtonUnselectedTabHoveredButtonHovered = new HoveredButtonPalette();
                TabButtonUnselectedTabHoveredButtonPressed = new HoveredButtonPalette();
                MainWindowActive = new MainWindowPalette();
                MainWindowStatusBarDefault = new MainWindowStatusBarPalette();
                ToolWindowCaptionActive = new ToolWindowCaptionPalette();
                ToolWindowCaptionInactive = new ToolWindowCaptionPalette();
                ToolWindowCaptionButtonActiveHovered = new HoveredButtonPalette();
                ToolWindowCaptionButtonPressed = new HoveredButtonPalette();
                ToolWindowCaptionButtonInactiveHovered = new HoveredButtonPalette();
                ToolWindowTabSelectedActive = new ToolWindowTabPalette();
                ToolWindowTabSelectedInactive = new ToolWindowTabPalette();
                ToolWindowTabUnselected = new ToolWindowUnselectedTabPalette();
                ToolWindowTabUnselectedHovered = new ToolWindowTabPalette();
                DockTarget = new DockTargetPalette();
                CommandBarMenuDefault = new CommandBarMenuPalette();
                CommandBarMenuPopupDefault = new CommandBarMenuPopupPalette();
                CommandBarMenuPopupDisabled = new CommandBarMenuPopupDisabledPalette();
                CommandBarMenuPopupHovered = new CommandBarMenuPopupHoveredPalette();
                CommandBarMenuTopLevelHeaderHovered = new CommandBarMenuTopLevelHeaderPalette();
                CommandBarToolbarDefault = new CommandBarToolbarPalette();
                CommandBarToolbarButtonChecked = new CommandBarToolbarButtonCheckedPalette();
                CommandBarToolbarButtonCheckedHovered = new CommandBarToolbarButtonCheckedHoveredPalette();
                CommandBarToolbarButtonDefault = new CommandBarToolbarButtonPalette();
                CommandBarToolbarButtonHovered = new CommandBarToolbarButtonHoveredPalette();
                CommandBarToolbarButtonPressed = new CommandBarToolbarButtonPressedPalette();
                CommandBarToolbarOverflowHovered = new CommandBarToolbarOverflowButtonPalette();
                CommandBarToolbarOverflowPressed = new CommandBarToolbarOverflowButtonPalette();
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public AutoHideStripPalette AutoHideStripDefault { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public AutoHideStripPalette AutoHideStripHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ButtonPalette OverflowButtonDefault { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HoveredButtonPalette OverflowButtonHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HoveredButtonPalette OverflowButtonPressed { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TabPalette TabSelectedActive { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TabPalette TabSelectedInactive { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public UnselectedTabPalette TabUnselected { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TabPalette TabUnselectedHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HoveredButtonPalette TabButtonSelectedActiveHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HoveredButtonPalette TabButtonSelectedActivePressed { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HoveredButtonPalette TabButtonSelectedInactiveHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HoveredButtonPalette TabButtonSelectedInactivePressed { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HoveredButtonPalette TabButtonUnselectedTabHoveredButtonHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HoveredButtonPalette TabButtonUnselectedTabHoveredButtonPressed { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public MainWindowPalette MainWindowActive { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public MainWindowStatusBarPalette MainWindowStatusBarDefault { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ToolWindowCaptionPalette ToolWindowCaptionActive { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ToolWindowCaptionPalette ToolWindowCaptionInactive { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HoveredButtonPalette ToolWindowCaptionButtonActiveHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HoveredButtonPalette ToolWindowCaptionButtonPressed { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HoveredButtonPalette ToolWindowCaptionButtonInactiveHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ToolWindowTabPalette ToolWindowTabSelectedActive { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ToolWindowTabPalette ToolWindowTabSelectedInactive { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ToolWindowUnselectedTabPalette ToolWindowTabUnselected { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ToolWindowTabPalette ToolWindowTabUnselectedHovered { get; set; }

        public Color ToolWindowBorder { get; set; }

        public Color ToolWindowSeparator { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DockTargetPalette DockTarget { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarMenuPalette CommandBarMenuDefault { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarMenuPopupPalette CommandBarMenuPopupDefault { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarMenuPopupDisabledPalette CommandBarMenuPopupDisabled { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarMenuPopupHoveredPalette CommandBarMenuPopupHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarMenuTopLevelHeaderPalette CommandBarMenuTopLevelHeaderHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarToolbarPalette CommandBarToolbarDefault { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarToolbarButtonCheckedPalette CommandBarToolbarButtonChecked { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarToolbarButtonCheckedHoveredPalette CommandBarToolbarButtonCheckedHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarToolbarButtonPalette CommandBarToolbarButtonDefault { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarToolbarButtonHoveredPalette CommandBarToolbarButtonHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarToolbarButtonPressedPalette CommandBarToolbarButtonPressed { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarToolbarOverflowButtonPalette CommandBarToolbarOverflowHovered { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CommandBarToolbarOverflowButtonPalette CommandBarToolbarOverflowPressed { get; set; }

    }


    /// <summary>
    ///  Color palette that is source for all other colors
    /// </summary>
    public class Colors
    {

        [Description("Background color for main window (DockPanel)")]
        public Color MainBackground { get; set; } = Color.FromArgb(93, 107, 153);

        [Description("Borders around docked windows.\r\nHide borders by setting this equal to MainBackground")]
        public Color MainBorders { get; set; } = Color.FromArgb(93, 107, 153);

        [Description("Background color for menues and toolbars")]
        public Color ToolStripBackground { get; set; } = Color.FromArgb(204, 213, 240);

        [Description("Default background color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabBackgroundNormal { get; set; } = Color.FromArgb(64, 86, 141);

        [Description("Default text color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabTextNormal { get; set; } = Color.White;

        [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabButtonNormal { get; set; } = Color.FromArgb(160,172,210);

        [Description("Background color of currently active element, either document tab or caption of active tool window")]
        public Color TabBackgroundActive { get; set; } = Color.FromArgb(245, 204, 132);

        [Description("Text color of currently active element, either document tab or caption of active tool window")]
        public Color TabTextActive { get; set; } = Color.Black;

        [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabButtonActive { get; set; } = Color.FromArgb(116, 75, 35);

        [Description("Hoovered button color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabButtonHoovered { get; set; } = Color.FromArgb(52, 42, 33);

        [Description("Color of currently selected but not active document tab")]
        public Color DocTabBackgroundSelected { get; set; } = Color.FromArgb(204, 213, 240);

        [Description("Color of currently selected but not active document tab")]
        public Color DocTabBackgroundHoovered { get; set; } = Color.FromArgb(187, 198, 241);

        [Description("Background of tool window")]
        public Color ToolWinBackground { get; set; } = Color.FromArgb(255, 255, 255);

        [Description("Color of currently selected toolwindow tab")]
        public Color ToolTabSelected => ToolWinBackground;

        [Description("Color of currently selected but not active document tab")]
        public Color ToolTabHovered { get; set; } = Color.FromArgb(187, 198, 241);

        [Description("Background of pressed two-state button")]
        public Color ButtonPressedBackground { get; set; } = Color.FromArgb(255, 237, 200);

        [Description("Border of pressed two-state button")]
        public Color ButtonPressedBorder { get; set; } = Color.FromArgb(130, 93, 7);

        [Description("Background of hoovered button (either normal or two-state)")]
        public Color ButtonHooveredBackground { get; set; } = Color.FromArgb(236, 244, 255);

        [Description("Border of hoovered button (either normal or two-state)")]
        public Color ButtonHoveredBorder { get; set; } = Color.FromArgb(93, 107, 153);

        [Description("Border of hoovered button (either normal or two-state)")]
        public Color GridHeaderBackground { get; set; } = Color.FromArgb(246, 246, 246);

        [Description("Border of hoovered button (either normal or two-state)")]
        public Color GridHeaderBars { get; set; } = Color.FromArgb(204, 206, 219);

        public Colors() { }

    }



    public class CommandBarToolbarOverflowButtonPalette
    {
        public Color Background { get; set; }
        public Color Glyph { get; set; }
    }

    public class CommandBarToolbarButtonPressedPalette
    {
        public Color Arrow { get; set; }
        public Color Background { get; set; }
        public Color Text { get; set; }
    }

    public class CommandBarToolbarButtonHoveredPalette
    {
        public Color Arrow { get; set; }
        public Color Separator { get; set; }
    }

    public class CommandBarToolbarButtonPalette
    {
        public Color Arrow { get; set; }
    }

    public class CommandBarToolbarButtonCheckedHoveredPalette
    {
        public Color Border { get; set; }
        public Color Text { get; set; }
    }

    public class CommandBarToolbarButtonCheckedPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Text { get; set; }
    }

    public class CommandBarToolbarPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Grip { get; set; }
        public Color OverflowButtonBackground { get; set; }
        public Color OverflowButtonGlyph { get; set; }
        public Color Separator { get; set; }
        public Color SeparatorAccent { get; set; }
        public Color Tray { get; set; }
    }

    public class CommandBarMenuTopLevelHeaderPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Text { get; set; }
    }

    public class CommandBarMenuPopupHoveredPalette
    {
        public Color Arrow { get; set; }
        public Color Checkmark { get; set; }
        public Color CheckmarkBackground { get; set; }
        public Color ItemBackground { get; set; }
        public Color Text { get; set; }
    }

    public class CommandBarMenuPopupDisabledPalette
    {
        public Color Checkmark { get; set; }
        public Color CheckmarkBackground { get; set; }
        public Color Text { get; set; }
    }

    public class CommandBarMenuPopupPalette
    {
        public Color Arrow { get; set; }
        public Color BackgroundBottom { get; set; }
        public Color BackgroundTop { get; set; }
        public Color Border { get; set; }
        public Color Checkmark { get; set; }
        public Color CheckmarkBackground { get; set; }
        public Color IconBackground { get; set; }
        public Color Separator { get; set; }
    }

    public class CommandBarMenuPalette
    {
        public Color Background { get; set; }
        public Color Text { get; set; }
    }

    public class DockTargetPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color ButtonBackground { get; set; }
        public Color ButtonBorder { get; set; }
        public Color GlyphBackground { get; set; }
        public Color GlyphArrow { get; set; }
        public Color GlyphBorder { get; set; }
    }

    public class HoveredButtonPalette
    {
        public Color Background { get; set; }
        public Color Border { get; set; }
        public Color Glyph { get; set; }
    }

    public class ButtonPalette
    {
        public Color Glyph { get; set; }
    }

    public class MainWindowPalette
    {
        public Color Background { get; set; }
    }

    public class MainWindowStatusBarPalette
    {
        public Color Background { get; set; }
        public Color Highlight { get; set; }
        public Color HighlightText { get; set; }
        public Color ResizeGrip { get; set; }
        public Color ResizeGripAccent { get; set; }
        public Color Text { get; set; }
    }

    public class ToolWindowTabPalette
    {
        public Color Background { get; set; }
        public Color Text { get; set; }
    }

    public class ToolWindowUnselectedTabPalette
    {
        public Color Background { get; set; } // VS2013
        public Color Text { get; set; }
    }

    public class ToolWindowCaptionPalette
    {
        public Color Background { get; set; }
        public Color Button { get; set; }
        public Color Grip { get; set; }
        public Color Text { get; set; }
    }

    public class TabPalette
    {
        public Color Background { get; set; }
        public Color Button { get; set; }
        public Color Text { get; set; }
    }

    public class UnselectedTabPalette
    {
        public Color Background { get; set; } // VS2013 only

        public Color Text { get; set; }
    }

    public class AutoHideStripPalette
    {
        public Color Background { get; set; }

        public Color Border { get; set; }

        public Color Text { get; set; }
    }


}

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

        public DockPanelColorPalette()
        {
            ColorTable = new VisualStudioColorTable(this);
        }

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

        [JsonIgnore]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public VisualStudioColorTable ColorTable { get; private set; }
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

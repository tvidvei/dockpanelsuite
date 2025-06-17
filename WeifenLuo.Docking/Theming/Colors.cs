using System.ComponentModel;
using System.Text.Json.Serialization;
using Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WeifenLuo.Docking
{
    /// <summary>
    ///  Color palette that is source for all other colors
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectWithDynamicDefaultsConverter))]
    public class Colors
    {

        // Main Backgrounds and borders

        [Description("Background color for main window (DockPanel)")]
        public Color MainBackground { get; set; } = Color.FromArgb(93, 107, 153);

        [Description("Background color for menues and toolbars")]
        public Color ToolsBackground { get; set; } = Color.FromArgb(204, 213, 240);

        [Description("Background color for menues and toolbars")]
        [JsonIgnore]
        public Color MenuBackground
        {
            get { return menuBackground != default ? menuBackground : ToolsBackground; }
            set { menuBackground = value; }
        }
        [JsonInclude]
        private Color menuBackground;

        [Description("Background color for menues and toolbars")]
        [JsonIgnore]
        public Color ToolBarBackground
        {
            get => toolBarBackground != default ? toolBarBackground : ToolsBackground;
            set { toolBarBackground = value; }
        }
        [JsonInclude]
        private Color toolBarBackground;


        [Description("Background color for menues and toolbars")]
        public Color StatusBarBackground { get; set; } = Color.FromArgb(204, 213, 240);

        // Borders

        [Description("Borders around docked windows.\r\nHide borders by setting this equal to MainBackground")]
        public Color MainBorder { get; set; } = Color.Empty;  // Color.FromArgb(93, 107, 153);    // Tidl ColorPalette.ToolWindowBorder
                                                              // Color Empty, fører til at det ikke tegnes.


        // TabNormal

        [Description("Default background color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabNormalBackground { get; set; } = Color.FromArgb(59, 79, 129);  //Color.FromArgb(64, 86, 141);

        [Description("Text color in Captions and Tabs")]
        public Color TabNormalText { get; set; } = Color.White;

        [Description("Grip color in Captions and Tabs")]
        public Color TabNormalGrip { get; set; } = Color.White;

        [Description("Glyph color in Captions and Tabs")]
        public Color TabNormalButtonNormalGlyph { get; set; } = Color.FromArgb(160, 172, 210);  // Bare for ToolWin Captions.  Ellers Color.Empty

        [Description("Glyph background color in Captions and Tabs")]
        public Color TabNormalButtonNormalBackground { get; set; } = Color.Empty;

        [Description("Glyph border color in Captions and Tabs")]
        public Color TabNormalButtonNormalBorder { get; set; } = Color.Empty;

        [Description("Glyph color in Captions and Tabs")]
        public Color TabNormalButtonHooveredGlyph { get; set; } = Color.FromArgb(30, 30, 30);  // Bare for ToolWin Captions.  Ellers Color.Empty

        [Description("Glyph background color in Captions and Tabs")]
        public Color TabNormalButtonHooveredBackground { get; set; } = Color.FromArgb(236, 244, 255);  // Bare for ToolWinCaptions.  Ellers Color.Empty

        [Description("Glyph border color in Captions and Tabs")]
        public Color TabNormalButtonHooveredBorder { get; set; } = Color.Empty;

        // TabHoovered

        [Description("Default background color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabHooveredBackground { get; set; } = Color.FromArgb(187, 198, 241);

        [Description("Default background color for Tabs.  Used when inactive and not selected")]
        public Color TabHooveredText { get; set; } = Color.Black;

        [Description("Grip color in Captions and Tabs")]
        public Color TabHooveredGrip { get; set; } = Color.Black;

        [Description("Glyph color in Captions and Tabs")]
        public Color TabHooveredButtonNormalGlyph { get; set; } = Color.FromArgb(64, 86, 141);

        [Description("Glyph background color in Captions and Tabs")]
        public Color TabHooveredButtonNormalBackground { get; set; } = Color.Empty;

        [Description("Glyph border color in Captions and Tabs")]
        public Color TabHooveredButtonNormalBorder { get; set; } = Color.Empty;

        [Description("Glyph color in Captions and Tabs")]
        public Color TabHooveredButtonHooveredGlyph { get; set; } = Color.FromArgb(30, 30, 30);

        [Description("Glyph background color in Captions and Tabs")]
        public Color TabHooveredButtonHooveredBackground { get; set; } = Color.Empty;

        [Description("Glyph border color in Captions and Tabs")]
        public Color TabHooveredButtonHooveredBorder { get; set; } = Color.Empty;


        // TabSelected

        [Description("Color of currently selected but not active document tab")]
        public Color TabSelectedBackground { get; set; } = Color.FromArgb(204, 213, 240);

        [Description("Default background color for Tabs.  Used when inactive and not selected")]
        public Color TabSelectedText { get; set; } = Color.Black;

        [Description("Grip color in Captions and Tabs")]
        public Color TabSelectedGrip { get; set; } = Color.Black;

        [Description("Glyph color in Captions and Tabs")]
        public Color TabSelectedButtonNormalGlyph { get; set; } = Color.FromArgb(105, 130, 171);

        [Description("Glyph background color in Captions and Tabs")]
        public Color TabSelectedButtonNormalBackground { get; set; } = Color.Empty;

        [Description("Glyph border color in Captions and Tabs")]
        public Color TabSelectedButtonNormalBorder { get; set; } = Color.Empty;

        [Description("Glyph color in Captions and Tabs")]
        public Color TabSelectedButtonHooveredGlyph { get; set; } = Color.FromArgb(30, 30, 30);

        [Description("Glyph background color in Captions and Tabs")]
        public Color TabSelectedButtonHooveredBackground { get; set; } = Color.Empty;

        [Description("Glyph border color in Captions and Tabs")]
        public Color TabSelectedButtonHooveredBorder { get; set; } = Color.Empty;


        // TabActive

        [Description("Background color of currently active element, either document tab or caption of active tool window")]
        public Color TabActiveBackground { get; set; } = Color.FromArgb(245, 204, 132);

        [Description("Text color of currently active element, either document tab or caption of active tool window")]
        public Color TabActiveText { get; set; } = Color.Black;

        [Description("Grip color in Captions and Tabs")]
        public Color TabActiveGrip { get; set; } = Color.Black;

        [Description("Glyph color in Captions and Tabs")]
        public Color TabActiveButtonNormalGlyph { get; set; } = Color.FromArgb(116, 75, 35);

        [Description("Glyph background color in Captions and Tabs")]
        public Color TabActiveButtonNormalBackground { get; set; } = Color.Empty;

        [Description("Glyph border color in Captions and Tabs")]
        public Color TabActiveButtonNormalBorder { get; set; } = Color.Empty;

        [Description("Glyph color in Captions and Tabs")]
        public Color TabActiveButtonHooveredGlyph { get; set; } = Color.FromArgb(52, 42, 33);

        [Description("Glyph background color in Captions and Tabs")]
        public Color TabActiveButtonHooveredBackground { get; set; } = Color.Empty;

        [Description("Glyph border color in Captions and Tabs")]
        public Color TabActiveButtonHooveredBorder { get; set; } = Color.Empty;


        // Button

        [Description("Background of pressed two-state button")]
        public Color ButtonPressedBackground { get; set; } = Color.FromArgb(255, 237, 200);

        [Description("Border of pressed two-state button")]
        public Color ButtonPressedBorder { get; set; } = Color.FromArgb(130, 93, 7);

        [Description("Background of hoovered button (either normal or two-state)")]
        public Color ButtonHooveredBackground { get; set; } = Color.FromArgb(236, 244, 255);

        [Description("Border of hoovered button (either normal or two-state)")]
        public Color ButtonHoveredBorder { get; set; } = Color.FromArgb(93, 107, 153);


        // ToolWindows

        [Description("Background of tool window")]
        public Color ToolWinBackground { get; set; } = Color.FromArgb(255, 255, 255);

        [Description("Border of hoovered button (either normal or two-state)")]
        public Color GridHeaderBackground { get; set; } = Color.FromArgb(246, 246, 246);

        [Description("Border of hoovered button (either normal or two-state)")]
        public Color GridHeaderBars { get; set; } = Color.FromArgb(204, 206, 219);


        public ToolCaptionColors ToolCaptionColors { get; set; }

        public ToolTabColors ToolTabColors { get; set; }

        public DocTabColors DocTabColors { get; set; }


        public Colors() { }

        public void Setup()
        {
            ToolCaptionColors = new ToolCaptionColors(this);
            ToolTabColors = new ToolTabColors(this);
            DocTabColors = new DocTabColors(this);
        }

    }



    /// <summary>
    ///  Colors for Captions and Tabs in a given state, one of Normal, Hoovered, Selected or Active
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectWithDynamicDefaultsConverter))]
    public class ToolCaptionColors
    {

        [Browsable(false)]
        public Colors Parent { get; set; }


        // Normal

        [Description("Default Text color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalText
        {
            get => normalText != default ? normalText : Parent.TabNormalText;
            set { normalText = value; }
        }
        [JsonInclude]
        private Color normalText;

        [Description("Default background color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalBackground
        {
            get => normalBackground != default ? normalBackground : Parent.TabNormalBackground;
            set { normalBackground = value; }
        }
        [JsonInclude]
        private Color normalBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalGrip
        {
            get => normalGrip != default ? normalGrip : Parent.TabNormalGrip;
            set { normalGrip = value; }
        }
        [JsonInclude]
        private Color normalGrip;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonNormalGlyph
        {
            get => normalButtonNormalGlyph != default ? normalButtonNormalGlyph : Parent.TabNormalButtonNormalGlyph;
            set { normalButtonNormalGlyph = value; }
        }
        [JsonInclude]
        private Color normalButtonNormalGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonNormalBackground
        {
            get => normalButtonNormalBackground != default ? normalButtonNormalBackground : Parent.TabNormalButtonNormalBackground;
            set { normalButtonNormalBackground = value; }
        }
        [JsonInclude]
        private Color normalButtonNormalBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonNormalBorder
        {
            get => normalButtonNormalBorder != default ? normalButtonNormalBorder : Parent.TabNormalButtonNormalBorder;
            set { normalButtonNormalBorder = value; }
        }
        [JsonInclude]
        private Color normalButtonNormalBorder;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonHooveredGlyph
        {
            get => normalButtonHooveredGlyph != default ? normalButtonHooveredGlyph : Parent.TabNormalButtonHooveredGlyph;
            set { normalButtonHooveredGlyph = value; }
        }
        [JsonInclude]
        private Color normalButtonHooveredGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonHooveredBackground
        {
            get => normalButtonHooveredBackground != default ? normalButtonHooveredBackground : Parent.TabNormalButtonHooveredBackground;
            set { normalButtonHooveredBackground = value; }
        }
        [JsonInclude]
        private Color normalButtonHooveredBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonHooveredBorder
        {
            get => normalButtonHooveredBorder != default ? normalButtonHooveredBorder : Parent.TabNormalButtonHooveredBorder;
            set { normalButtonHooveredBorder = value; }
        }
        [JsonInclude]
        private Color normalButtonHooveredBorder;


        // Active

        [Description("Default Text color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveText
        {
            get => activeText != default ? activeText : Parent.TabActiveText;
            set { activeText = value; }
        }
        [JsonInclude]
        private Color activeText;

        [Description("Default background color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveBackground
        {
            get => activeBackground != default ? activeBackground : Parent.TabActiveBackground;
            set { activeBackground = value; }
        }
        [JsonInclude]
        private Color activeBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveGrip
        {
            get => activeGrip != default ? activeGrip : Parent.TabActiveGrip;
            set { activeGrip = value; }
        }
        [JsonInclude]
        private Color activeGrip;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveButtonNormalGlyph
        {
            get => activeButtonNormalGlyph != default ? activeButtonNormalGlyph : Parent.TabActiveButtonNormalGlyph;
            set { activeButtonNormalGlyph = value; }
        }
        [JsonInclude]
        private Color activeButtonNormalGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveButtonNormalBackground
        {
            get => activeButtonNormalBackground != default ? activeButtonNormalBackground : Parent.TabActiveButtonNormalBackground;
            set { activeButtonNormalBackground = value; }
        }
        [JsonInclude]
        private Color activeButtonNormalBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveButtonNormalBorder
        {
            get => activeButtonNormalBorder != default ? activeButtonNormalBorder : Parent.TabActiveButtonNormalBorder;
            set { activeButtonNormalBorder = value; }
        }
        [JsonInclude]
        private Color activeButtonNormalBorder;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveButtonHooveredGlyph
        {
            get => activeButtonHooveredGlyph != default ? activeButtonHooveredGlyph : Parent.TabActiveButtonHooveredGlyph;
            set { activeButtonHooveredGlyph = value; }
        }
        [JsonInclude]
        private Color activeButtonHooveredGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveButtonHooveredBackground
        {
            get => activeButtonHooveredBackground != default ? activeButtonHooveredBackground : Parent.TabActiveButtonHooveredBackground;
            set { activeButtonHooveredBackground = value; }
        }
        [JsonInclude]
        private Color activeButtonHooveredBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveButtonHooveredBorder
        {
            get => activeButtonHooveredBorder != default ? activeButtonHooveredBorder : Parent.TabActiveButtonHooveredBorder;
            set { activeButtonHooveredBorder = value; }
        }
        [JsonInclude]
        private Color activeButtonHooveredBorder;

        public ToolCaptionColors() { }

        public ToolCaptionColors(Colors parent)
        {
            Parent = parent;
        }

    }



    /// <summary>
    ///  Colors for Captions and Tabs in a given state, one of Normal, Hoovered, Selected or Active
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectWithDynamicDefaultsConverter))]
    public class ToolTabColors
    {

        [Browsable(false)]
        public Colors Parent { get; set; }


        // Normal

        [Description("Default Text color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalText
        {
            get => normalText != default ? normalText : Parent.TabNormalText;
            set { normalText = value; }
        }
        [JsonInclude]
        private Color normalText;

        [Description("Default background color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalBackground
        {
            get => normalBackground != default ? normalBackground : Parent.TabNormalBackground;
            set { normalBackground = value; }
        }
        [JsonInclude]
        private Color normalBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonNormalGlyph
        {
            get => normalButtonNormalGlyph != default ? normalButtonNormalGlyph : Parent.TabNormalButtonNormalGlyph;
            set { normalButtonNormalGlyph = value; }
        }
        [JsonInclude]
        private Color normalButtonNormalGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonNormalBackground
        {
            get => normalButtonNormalBackground != default ? normalButtonNormalBackground : Parent.TabNormalButtonNormalBackground;
            set { normalButtonNormalBackground = value; }
        }
        [JsonInclude]
        private Color normalButtonNormalBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonNormalBorder
        {
            get => normalButtonNormalBorder != default ? normalButtonNormalBorder : Parent.TabNormalButtonNormalBorder;
            set { normalButtonNormalBorder = value; }
        }
        [JsonInclude]
        private Color normalButtonNormalBorder;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonHooveredGlyph
        {
            get => normalButtonHooveredGlyph != default ? normalButtonHooveredGlyph : Parent.TabNormalButtonHooveredGlyph;
            set { normalButtonHooveredGlyph = value; }
        }
        [JsonInclude]
        private Color normalButtonHooveredGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonHooveredBackground
        {
            get => normalButtonHooveredBackground != default ? normalButtonHooveredBackground : Parent.TabNormalButtonHooveredBackground;
            set { normalButtonHooveredBackground = value; }
        }
        [JsonInclude]
        private Color normalButtonHooveredBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonHooveredBorder
        {
            get => normalButtonHooveredBorder != default ? normalButtonHooveredBorder : Parent.TabNormalButtonHooveredBorder;
            set { normalButtonHooveredBorder = value; }
        }
        [JsonInclude]
        private Color normalButtonHooveredBorder;


        // Hoovered

        [Description("Default Text color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredText
        {
            get => hooveredText != default ? hooveredText : Parent.TabHooveredText;
            set { hooveredText = value; }
        }
        [JsonInclude]
        private Color hooveredText;

        [Description("Default background color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredBackground
        {
            get => hooveredBackground != default ? hooveredBackground : Parent.TabHooveredBackground;
            set { hooveredBackground = value; }
        }
        [JsonInclude]
        private Color hooveredBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredButtonNormalGlyph
        {
            get => hooveredButtonNormalGlyph != default ? hooveredButtonNormalGlyph : Parent.TabHooveredButtonNormalGlyph;
            set { hooveredButtonNormalGlyph = value; }
        }
        [JsonInclude]
        private Color hooveredButtonNormalGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredButtonNormalBackground
        {
            get => hooveredButtonNormalBackground != default ? hooveredButtonNormalBackground : Parent.TabHooveredButtonNormalBackground;
            set { hooveredButtonNormalBackground = value; }
        }
        [JsonInclude]
        private Color hooveredButtonNormalBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredButtonNormalBorder
        {
            get => hooveredButtonNormalBorder != default ? hooveredButtonNormalBorder : Parent.TabHooveredButtonNormalBorder;
            set { hooveredButtonNormalBorder = value; }
        }
        [JsonInclude]
        private Color hooveredButtonNormalBorder;

        [Description("Default Border color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredButtonHooveredGlyph
        {
            get => hooveredButtonHooveredGlyph != default ? hooveredButtonHooveredGlyph : Parent.TabHooveredButtonHooveredGlyph;
            set { hooveredButtonHooveredGlyph = value; }
        }
        [JsonInclude]
        private Color hooveredButtonHooveredGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredButtonHooveredBackground
        {
            get => hooveredButtonHooveredBackground != default ? hooveredButtonHooveredBackground : Parent.TabHooveredButtonHooveredBackground;
            set { hooveredButtonHooveredBackground = value; }
        }
        [JsonInclude]
        private Color hooveredButtonHooveredBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredButtonHooveredBorder
        {
            get => hooveredButtonHooveredBorder != default ? hooveredButtonHooveredBorder : Parent.TabHooveredButtonHooveredBorder;
            set { hooveredButtonHooveredBorder = value; }
        }
        [JsonInclude]
        private Color hooveredButtonHooveredBorder;


        // Selected

        [Description("Default Text color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedText
        {
            get => selectedText != default ? selectedText : Parent.TabSelectedText;
            set { selectedText = value; }
        }
        [JsonInclude]
        private Color selectedText;

        [Description("Default background color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedBackground
        {
            get => selectedBackground != default ? selectedBackground : Parent.TabSelectedBackground;
            set { selectedBackground = value; }
        }
        [JsonInclude]
        private Color selectedBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedButtonNormalGlyph
        {
            get => selectedButtonNormalGlyph != default ? selectedButtonNormalGlyph : Parent.TabSelectedButtonNormalGlyph;
            set { selectedButtonNormalGlyph = value; }
        }
        [JsonInclude]
        private Color selectedButtonNormalGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedButtonNormalBackground
        {
            get => selectedButtonNormalBackground != default ? selectedButtonNormalBackground : Parent.TabSelectedButtonNormalBackground;
            set { selectedButtonNormalBackground = value; }
        }
        [JsonInclude]
        private Color selectedButtonNormalBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedButtonNormalBorder
        {
            get => selectedButtonNormalBorder != default ? selectedButtonNormalBorder : Parent.TabSelectedButtonNormalBorder;
            set { selectedButtonNormalBorder = value; }
        }
        [JsonInclude]
        private Color selectedButtonNormalBorder;

        [Description("Default Border color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedButtonHooveredGlyph
        {
            get => selectedButtonHooveredGlyph != default ? selectedButtonHooveredGlyph : Parent.TabSelectedButtonHooveredGlyph;
            set { selectedButtonHooveredGlyph = value; }
        }
        [JsonInclude]
        private Color selectedButtonHooveredGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedButtonHooveredBackground
        {
            get => selectedButtonHooveredBackground != default ? selectedButtonHooveredBackground : Parent.TabSelectedButtonHooveredBackground;
            set { selectedButtonHooveredBackground = value; }
        }
        [JsonInclude]
        private Color selectedButtonHooveredBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedButtonHooveredBorder
        {
            get => selectedButtonHooveredBorder != default ? selectedButtonHooveredBorder : Parent.TabSelectedButtonHooveredBorder;
            set { selectedButtonHooveredBorder = value; }
        }
        [JsonInclude]
        private Color selectedButtonHooveredBorder;


        public ToolTabColors() { }

        public ToolTabColors(Colors parent)
        {
            Parent = parent;
        }

    }

    /// <summary>
    ///  Colors for Captions and Tabs in a given state, one of Normal, Hoovered, Selected or Active
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectWithDynamicDefaultsConverter))]
    public class DocTabColors
    {

        [Browsable(false)]
        public Colors Parent { get; set; }


        // Normal

        [Description("Default Text color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalText
        {
            get => normalText != default ? normalText : Parent.TabNormalText;
            set { normalText = value; }
        }
        [JsonInclude]
        private Color normalText;

        [Description("Default background color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalBackground
        {
            get => normalBackground != default ? normalBackground : Parent.TabNormalBackground;
            set { normalBackground = value; }
        }
        [JsonInclude]
        private Color normalBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonNormalGlyph
        {
            get => normalButtonNormalGlyph != default ? normalButtonNormalGlyph : Parent.TabNormalButtonNormalGlyph;
            set { normalButtonNormalGlyph = value; }
        }
        [JsonInclude]
        private Color normalButtonNormalGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonNormalBackground
        {
            get => normalButtonNormalBackground != default ? normalButtonNormalBackground : Parent.TabNormalButtonNormalBackground;
            set { normalButtonNormalBackground = value; }
        }
        [JsonInclude]
        private Color normalButtonNormalBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonNormalBorder
        {
            get => normalButtonNormalBorder != default ? normalButtonNormalBorder : Parent.TabNormalButtonNormalBorder;
            set { normalButtonNormalBorder = value; }
        }
        [JsonInclude]
        private Color normalButtonNormalBorder;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonHooveredGlyph
        {
            get => normalButtonHooveredGlyph != default ? normalButtonHooveredGlyph : Parent.TabNormalButtonHooveredGlyph;
            set { normalButtonHooveredGlyph = value; }
        }
        [JsonInclude]
        private Color normalButtonHooveredGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonHooveredBackground
        {
            get => normalButtonHooveredBackground != default ? normalButtonHooveredBackground : Parent.TabNormalButtonHooveredBackground;
            set { normalButtonHooveredBackground = value; }
        }
        [JsonInclude]
        private Color normalButtonHooveredBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color NormalButtonHooveredBorder
        {
            get => normalButtonHooveredBorder != default ? normalButtonHooveredBorder : Parent.TabNormalButtonHooveredBorder;
            set { normalButtonHooveredBorder = value; }
        }
        [JsonInclude]
        private Color normalButtonHooveredBorder;


        // Hoovered

        [Description("Default Text color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredText
        {
            get => hooveredText != default ? hooveredText : Parent.TabHooveredText;
            set { hooveredText = value; }
        }
        [JsonInclude]
        private Color hooveredText;

        [Description("Default background color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredBackground
        {
            get => hooveredBackground != default ? hooveredBackground : Parent.TabHooveredBackground;
            set { hooveredBackground = value; }
        }
        [JsonInclude]
        private Color hooveredBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredButtonNormalGlyph
        {
            get => hooveredButtonNormalGlyph != default ? hooveredButtonNormalGlyph : Parent.TabHooveredButtonNormalGlyph;
            set { hooveredButtonNormalGlyph = value; }
        }
        [JsonInclude]
        private Color hooveredButtonNormalGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredButtonNormalBackground
        {
            get => hooveredButtonNormalBackground != default ? hooveredButtonNormalBackground : Parent.TabHooveredButtonNormalBackground;
            set { hooveredButtonNormalBackground = value; }
        }
        [JsonInclude]
        private Color hooveredButtonNormalBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredButtonNormalBorder
        {
            get => hooveredButtonNormalBorder != default ? hooveredButtonNormalBorder : Parent.TabHooveredButtonNormalBorder;
            set { hooveredButtonNormalBorder = value; }
        }
        [JsonInclude]
        private Color hooveredButtonNormalBorder;

        [Description("Default Border color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredButtonHooveredGlyph
        {
            get => hooveredButtonHooveredGlyph != default ? hooveredButtonHooveredGlyph : Parent.TabHooveredButtonHooveredGlyph;
            set { hooveredButtonHooveredGlyph = value; }
        }
        [JsonInclude]
        private Color hooveredButtonHooveredGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredButtonHooveredBackground
        {
            get => hooveredButtonHooveredBackground != default ? hooveredButtonHooveredBackground : Parent.TabHooveredButtonHooveredBackground;
            set { hooveredButtonHooveredBackground = value; }
        }
        [JsonInclude]
        private Color hooveredButtonHooveredBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inhoovered and not selected")]
        [JsonIgnore]
        public Color HooveredButtonHooveredBorder
        {
            get => hooveredButtonHooveredBorder != default ? hooveredButtonHooveredBorder : Parent.TabHooveredButtonHooveredBorder;
            set { hooveredButtonHooveredBorder = value; }
        }
        [JsonInclude]
        private Color hooveredButtonHooveredBorder;


        // Selected

        [Description("Default Text color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedText
        {
            get => selectedText != default ? selectedText : Parent.TabSelectedText;
            set { selectedText = value; }
        }
        [JsonInclude]
        private Color selectedText;

        [Description("Default background color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedBackground
        {
            get => selectedBackground != default ? selectedBackground : Parent.TabSelectedBackground;
            set { selectedBackground = value; }
        }
        [JsonInclude]
        private Color selectedBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedButtonNormalGlyph
        {
            get => selectedButtonNormalGlyph != default ? selectedButtonNormalGlyph : Parent.TabSelectedButtonNormalGlyph;
            set { selectedButtonNormalGlyph = value; }
        }
        [JsonInclude]
        private Color selectedButtonNormalGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedButtonNormalBackground
        {
            get => selectedButtonNormalBackground != default ? selectedButtonNormalBackground : Parent.TabSelectedButtonNormalBackground;
            set { selectedButtonNormalBackground = value; }
        }
        [JsonInclude]
        private Color selectedButtonNormalBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedButtonNormalBorder
        {
            get => selectedButtonNormalBorder != default ? selectedButtonNormalBorder : Parent.TabSelectedButtonNormalBorder;
            set { selectedButtonNormalBorder = value; }
        }
        [JsonInclude]
        private Color selectedButtonNormalBorder;

        [Description("Default Border color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedButtonHooveredGlyph
        {
            get => selectedButtonHooveredGlyph != default ? selectedButtonHooveredGlyph : Parent.TabSelectedButtonHooveredGlyph;
            set { selectedButtonHooveredGlyph = value; }
        }
        [JsonInclude]
        private Color selectedButtonHooveredGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedButtonHooveredBackground
        {
            get => selectedButtonHooveredBackground != default ? selectedButtonHooveredBackground : Parent.TabSelectedButtonHooveredBackground;
            set { selectedButtonHooveredBackground = value; }
        }
        [JsonInclude]
        private Color selectedButtonHooveredBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inselected and not selected")]
        [JsonIgnore]
        public Color SelectedButtonHooveredBorder
        {
            get => selectedButtonHooveredBorder != default ? selectedButtonHooveredBorder : Parent.TabSelectedButtonHooveredBorder;
            set { selectedButtonHooveredBorder = value; }
        }
        [JsonInclude]
        private Color selectedButtonHooveredBorder;

        // Active

        [Description("Default Text color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveText
        {
            get => activeText != default ? activeText : Parent.TabActiveText;
            set { activeText = value; }
        }
        [JsonInclude]
        private Color activeText;

        [Description("Default background color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveBackground
        {
            get => activeBackground != default ? activeBackground : Parent.TabActiveBackground;
            set { activeBackground = value; }
        }
        [JsonInclude]
        private Color activeBackground;


        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveButtonNormalGlyph
        {
            get => activeButtonNormalGlyph != default ? activeButtonNormalGlyph : Parent.TabActiveButtonNormalGlyph;
            set { activeButtonNormalGlyph = value; }
        }
        [JsonInclude]
        private Color activeButtonNormalGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveButtonNormalBackground
        {
            get => activeButtonNormalBackground != default ? activeButtonNormalBackground : Parent.TabActiveButtonNormalBackground;
            set { activeButtonNormalBackground = value; }
        }
        [JsonInclude]
        private Color activeButtonNormalBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveButtonNormalBorder
        {
            get => activeButtonNormalBorder != default ? activeButtonNormalBorder : Parent.TabActiveButtonNormalBorder;
            set { activeButtonNormalBorder = value; }
        }
        [JsonInclude]
        private Color activeButtonNormalBorder;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveButtonHooveredGlyph
        {
            get => activeButtonHooveredGlyph != default ? activeButtonHooveredGlyph : Parent.TabActiveButtonHooveredGlyph;
            set { activeButtonHooveredGlyph = value; }
        }
        [JsonInclude]
        private Color activeButtonHooveredGlyph;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveButtonHooveredBackground
        {
            get => activeButtonHooveredBackground != default ? activeButtonHooveredBackground : Parent.TabActiveButtonHooveredBackground;
            set { activeButtonHooveredBackground = value; }
        }
        [JsonInclude]
        private Color activeButtonHooveredBackground;

        [Description("Default Border color for Captions and and Tabs.  Used when inactive and not selected")]
        [JsonIgnore]
        public Color ActiveButtonHooveredBorder
        {
            get => activeButtonHooveredBorder != default ? activeButtonHooveredBorder : Parent.TabActiveButtonHooveredBorder;
            set { activeButtonHooveredBorder = value; }
        }
        [JsonInclude]
        private Color activeButtonHooveredBorder;

        public DocTabColors() { }

        public DocTabColors(Colors parent)
        {
            Parent = parent;
        }

    }

}

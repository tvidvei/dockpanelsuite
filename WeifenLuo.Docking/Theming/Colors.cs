using System.ComponentModel;
using Utilities;
using System.Text.Json.Serialization;

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
            get { return toolBarBackground != default ? toolBarBackground : ToolsBackground; }
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

        //[Description("Hoovered button color for Captions and and Tabs.  Used when inactive and not selected")]
        //public Color TabHooveredGlyph { get; set; } = Color.FromArgb(52, 42, 33);

        //[Description("Glyph background color in Captions and Tabs")]
        //public Color TabHooveredGlyphBackground { get; set; } = Color.Empty;

        //[Description("Glyph border color in Captions and Tabs")]
        //public Color TabHooveredGlyphBorder { get; set; } = Color.Empty;

        //[Description("Hoovered button color for Captions and and Tabs.  Used when inactive and not selected")]
        //public Color TabHooveredGlyphHoovered { get; set; } = Color.FromArgb(52, 42, 33);

        //[Description("Glyph background color in Captions and Tabs")]
        //public Color TabHooveredGlyphHooveredBackground { get; set; } = Color.Empty;

        //[Description("Glyph border color in Captions and Tabs")]
        //public Color TabHooveredGlyphHooveredBorder { get; set; } = Color.Empty;



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
        //[Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
        //public Color TabSelectedGlyph { get; set; } = Color.FromArgb(116, 75, 35);

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



        public Colors() { }

        /// <summary>
        ///  Colors for Captions and Tabs in a given state, one of Normal, Hoovered, Selected or Active
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectWithDynamicDefaultsConverter))]
        public class CaptionColors
        {

            [Description("Default background color for Captions and and Tabs.  Used when inactive and not selected")]
            public Color NormalBackground { get; set; } = Color.FromArgb(64, 86, 141);

            [Description("Default text color for Captions and and Tabs.  Used when inactive and not selected")]
            public Color NormalText { get; set; } = Color.White;

            [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
            public Color NormalBorder { get; set; } = Color.FromArgb(93, 107, 153);

            [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
            public Color NormalGlyphForeground { get; set; } = Color.FromArgb(93, 107, 153);

            [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
            public Color NormalGlyphBackground { get; set; } = Color.FromArgb(93, 107, 153);

            [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
            public Color NormalGlyphBorder { get; set; } = Color.FromArgb(93, 107, 153);

            [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
            public Color NormalGlyphHooveredForeground { get; set; } = Color.FromArgb(93, 107, 153);

            [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
            public Color NormalGlyphHooveredBackground { get; set; } = Color.FromArgb(93, 107, 153);

            [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
            public Color NormalGlyphHooveredBorder { get; set; } = Color.FromArgb(93, 107, 153);


            public CaptionColors() { }

        }


    }


}

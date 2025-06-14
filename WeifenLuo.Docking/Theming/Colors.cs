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

        // Main Backgrounds

        [Description("Background color for main window (DockPanel)")]
        public Color MainBackground { get; set; } = Color.FromArgb(93, 107, 153);

        [Description("Background color for menues and toolbars")]
        public Color ToolsBackground { get; set; } = Color.FromArgb(204, 213, 240);

        [Description("Background color for menues and toolbars")]
        [DefaultValueProperty(nameof(ToolsBackground))]
        [JsonIgnore]
        public Color MenuBackground
        {
            get { return menuBackground != default(Color) ? menuBackground : ToolsBackground; }
            set { menuBackground = value; }
        }
        [JsonInclude]
        private Color menuBackground;

        [Description("Background color for menues and toolbars")]
        //public Color ToolBarBackground { get; set; } = Color.FromArgb(204, 213, 240);
        public Color ToolBarBackground
        {
            get { return toolBarBackground != default(Color) ? toolBarBackground : toolBarBackgroundDefault; }
            set { toolBarBackground = value; }
        }
        private Color toolBarBackground;
        private Color toolBarBackgroundDefault => ToolsBackground;


        [Description("Background color for menues and toolbars")]
        public Color StatusBarBackground { get; set; } = Color.FromArgb(204, 213, 240);

        // Borders

        [Description("Borders around docked windows.\r\nHide borders by setting this equal to MainBackground")]
        public Color MainBorders { get; set; } = Color.FromArgb(93, 107, 153);


        // TabActive

        [Description("Background color of currently active element, either document tab or caption of active tool window")]
        public Color TabActiveBackground { get; set; } = Color.FromArgb(245, 204, 132);

        [Description("Text color of currently active element, either document tab or caption of active tool window")]
        public Color TabActiveText { get; set; } = Color.Black;

        [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabActiveGlyph { get; set; } = Color.FromArgb(116, 75, 35);

        [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabActiveBorder { get; set; } = Color.FromArgb(93, 107, 153);


        // TabHoovered

        [Description("Default background color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabHooveredBackground { get; set; } = Color.FromArgb(187, 198, 241);

        [Description("Default background color for Tabs.  Used when inactive and not selected")]
        public Color TabHooveredText { get; set; } = Color.Black;

        [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabHooveredBorder { get; set; } = Color.FromArgb(93, 107, 153);

        [Description("Hoovered button color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabHooveredGlyph { get; set; } = Color.FromArgb(52, 42, 33);


        // TabNormal

        [Description("Default background color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabNormalBackground { get; set; } = Color.FromArgb(64, 86, 141);

        [Description("Text color in Captions and Tabs")]
        public Color TabNormalText { get; set; } = Color.White;

        [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabNormalBorder { get; set; } = Color.FromArgb(93, 107, 153);

        [Description("Glyph color in Captions and Tabs")]
        public Color TabNormalGlyph { get; set; } = Color.FromArgb(160, 172, 210);


        // TabSelected

        [Description("Color of currently selected but not active document tab")]
        public Color TabSelectedBackground { get; set; } = Color.FromArgb(204, 213, 240);

        [Description("Background color in Captions and Tabs")]
        public Color TabSelectedBackground_ToolWin { get; set; } = Color.White;

        [Description("Default background color for Tabs.  Used when inactive and not selected")]
        public Color TabSelectedText { get; set; } = Color.Black;

        [Description("Default button color for Captions and and Tabs.  Used when inactive and not selected")]
        public Color TabSelectedBorder { get; set; } = Color.FromArgb(93, 107, 153);



        [Description("Background of tool window")]
        public Color ToolWinBackground { get; set; } = Color.FromArgb(255, 255, 255);

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

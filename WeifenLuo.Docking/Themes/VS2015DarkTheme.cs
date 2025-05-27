namespace WeifenLuo.Docking
{
    /// <summary>
    /// Visual Studio 2015 Dark theme.
    /// </summary>
    public class VS2015DarkTheme : Theme
    {
        public VS2015DarkTheme()
            : base(Decompress(Resources.GetBytes("vs2015dark.vstheme.gz")))
        {
        }
    }
}

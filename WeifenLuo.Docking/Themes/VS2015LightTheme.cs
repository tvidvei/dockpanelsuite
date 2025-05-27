namespace WeifenLuo.Docking
{
    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class VS2015LightTheme : Theme
    {
        public VS2015LightTheme()
            : base(Decompress(Resources.GetBytes("vs2015light.vstheme.gz")))
        {
        }
    }
}

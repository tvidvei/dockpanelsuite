namespace WeifenLuo.WinFormsUI.Docking
{
    /// <summary>
    /// Visual Studio 2015 Light theme.
    /// </summary>
    public class VS2015BlueTheme : VS2015ThemeBase
    {
        public VS2015BlueTheme()
            : base(Decompress(Resources.GetBytes("vs2015blue.vstheme.gz")))
        {
        }
    }
}

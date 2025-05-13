using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using static WeifenLuo.Docking.DockPanel;
using static WeifenLuo.Docking.DockDragHandler;

namespace WeifenLuo.Docking
{
    public sealed class DockPanelExtender
    {

        public interface IPaneIndicatorFactory
        {
            IPaneIndicator CreatePaneIndicator(ThemeBase theme);
        }

        public interface IPanelIndicatorFactory
        {
            IPanelIndicator CreatePanelIndicator(DockStyle style, ThemeBase theme);
        }

        public interface IDockOutlineFactory
        {
            DockOutlineBase CreateDockOutline();
        }

        public interface IDockIndicatorFactory
        {
            DockIndicator CreateDockIndicator(DockDragHandler dockDragHandler);
        }

        public IPanelIndicatorFactory PanelIndicatorFactory { get; set; }

        public IDockOutlineFactory DockOutlineFactory { get; set; }

        public IDockIndicatorFactory DockIndicatorFactory { get; set; }
    }
}

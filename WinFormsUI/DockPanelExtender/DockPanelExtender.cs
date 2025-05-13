using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using static WeifenLuo.Docking.DockPanel;
using static WeifenLuo.Docking.DockDragHandler;

namespace WeifenLuo.Docking
{
    public sealed class DockPanelExtender
    {

        public interface IDockIndicatorFactory
        {
            DockIndicator CreateDockIndicator(DockDragHandler dockDragHandler);
        }

        public IDockIndicatorFactory DockIndicatorFactory { get; set; }
    }
}

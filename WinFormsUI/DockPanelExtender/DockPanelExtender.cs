using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using static WeifenLuo.Docking.DockPanel;
using static WeifenLuo.Docking.DockDragHandler;

namespace WeifenLuo.Docking
{
    public sealed class DockPanelExtender
    {

        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IDockPaneCaptionFactory
        {
            DockPaneCaptionBase CreateDockPaneCaption(DockPane pane);
        }

        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IDockPaneStripFactory
        {
            DockPaneStripBase CreateDockPaneStrip(DockPane pane);
        }

        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IAutoHideStripFactory
        {
            AutoHideStripBase CreateAutoHideStrip(DockPanel panel);
        }

        public interface IAutoHideWindowFactory
        {
            AutoHideWindowControlBase CreateAutoHideWindow(DockPanel panel);
        }

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

        public IDockPaneCaptionFactory DockPaneCaptionFactory { get; set; }

        public IDockPaneStripFactory DockPaneStripFactory { get; set; }

        private IAutoHideStripFactory m_autoHideStripFactory = null;

        public IAutoHideStripFactory AutoHideStripFactory
        {
            get
            {
                return m_autoHideStripFactory;
            }
            set
            {
                if (m_autoHideStripFactory == value)
                {
                    return;
                }

                m_autoHideStripFactory = value;
            }
        }

        private IAutoHideWindowFactory m_autoHideWindowFactory;
        
        public IAutoHideWindowFactory AutoHideWindowFactory
        {
            get { return m_autoHideWindowFactory; }
            set
            {
                if (m_autoHideWindowFactory == value)
                {
                    return;
                }

                m_autoHideWindowFactory = value;
            }
        }

        public IPaneIndicatorFactory PaneIndicatorFactory { get; set; }

        public IPanelIndicatorFactory PanelIndicatorFactory { get; set; }

        public IDockOutlineFactory DockOutlineFactory { get; set; }

        public IDockIndicatorFactory DockIndicatorFactory { get; set; }
    }
}

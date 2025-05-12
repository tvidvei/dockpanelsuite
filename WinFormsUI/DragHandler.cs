using System.Windows.Forms;
using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{

    public abstract class DragHandler : DragHandlerBase
    {
        private DockPanel m_dockPanel;

        protected DragHandler(DockPanel dockPanel) {
            m_dockPanel = dockPanel;
        }

        public DockPanel DockPanel {
            get { return m_dockPanel; }
        }

        private IDragSource m_dragSource;
        protected IDragSource DragSource {
            get { return m_dragSource; }
            set { m_dragSource = value; }
        }

        protected sealed override Control DragControl {
            get { return DragSource == null ? null : DragSource.DragControl; }
        }

        protected sealed override bool OnPreFilterMessage(ref Message m) {
            if ((m.Msg == (int)Win32.Msgs.WM_KEYDOWN || m.Msg == (int)Win32.Msgs.WM_KEYUP) &&
                ((int)m.WParam == (int)Keys.ControlKey || (int)m.WParam == (int)Keys.ShiftKey))
                OnDragging();

            return base.OnPreFilterMessage(ref m);
        }
    }

}

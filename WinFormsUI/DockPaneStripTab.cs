using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeifenLuo.Docking
{

    internal class DockPaneStripTab : IDisposable
    {
        private IDockContent m_content;

        public DockPaneStripTab(IDockContent content) {
            m_content = content;
        }

        ~DockPaneStripTab() {
            Dispose(false);
        }

        public IDockContent Content {
            get { return m_content; }
        }

        public Form ContentForm {
            get { return m_content as Form; }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
        }

        private Rectangle? _rect;

        public Rectangle? Rectangle {
            get {
                if (_rect != null) {
                    return _rect;
                }

                return _rect = System.Drawing.Rectangle.Empty;
            }

            set {
                _rect = value;
            }
        }
    }

}

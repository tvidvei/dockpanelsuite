using System;

namespace WeifenLuo.Docking
{
    public class AutoHideStripTab : IDisposable
    {
        private IDockContent m_content;

        protected internal AutoHideStripTab(IDockContent content) {
            m_content = content;
        }

        ~AutoHideStripTab() {
            Dispose(false);
        }

        public IDockContent Content {
            get { return m_content; }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
        }
    }

}

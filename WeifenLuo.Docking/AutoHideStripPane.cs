using System;

namespace WeifenLuo.Docking
{

    public class AutoHideStripPane : IDisposable
    {
        private DockPane m_dockPane;

        protected internal AutoHideStripPane(DockPane dockPane) {
            m_dockPane = dockPane;
        }

        ~AutoHideStripPane() {
            Dispose(false);
        }

        public DockPane DockPane {
            get { return m_dockPane; }
        }

        public AutoHideStripTabCollection AutoHideTabs {
            get {
                if (DockPane.AutoHideTabs == null)
                    DockPane.AutoHideTabs = new AutoHideStripTabCollection(DockPane);
                return DockPane.AutoHideTabs as AutoHideStripTabCollection;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
        }
    }

}

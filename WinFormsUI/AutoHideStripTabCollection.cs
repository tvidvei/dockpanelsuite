using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeifenLuo.Docking
{

    public sealed class AutoHideStripTabCollection : IEnumerable<AutoHideStripTab>
    {
        #region IEnumerable Members
        IEnumerator<AutoHideStripTab> IEnumerable<AutoHideStripTab>.GetEnumerator() {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator() {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }
        #endregion

        internal AutoHideStripTabCollection(DockPane pane) {
            m_dockPane = pane;
        }

        private DockPane m_dockPane = null;
        public DockPane DockPane {
            get { return m_dockPane; }
        }

        public DockPanel DockPanel {
            get { return DockPane.DockPanel; }
        }

        public int Count {
            get { return DockPane.DisplayingContents.Count; }
        }

        public AutoHideStripTab this[int index] {
            get {
                IDockContent content = DockPane.DisplayingContents[index];
                if (content == null)
                    throw new ArgumentOutOfRangeException(nameof(index));
                if (content.DockHandler.AutoHideTab == null)
                    content.DockHandler.AutoHideTab = (DockPanel.AutoHideStripControl.CreateTab(content));
                return content.DockHandler.AutoHideTab as AutoHideStripTab;
            }
        }

        public bool Contains(AutoHideStripTab tab) {
            return (IndexOf(tab) != -1);
        }

        public bool Contains(IDockContent content) {
            return (IndexOf(content) != -1);
        }

        public int IndexOf(AutoHideStripTab tab) {
            if (tab == null)
                return -1;

            return IndexOf(tab.Content);
        }

        public int IndexOf(IDockContent content) {
            return DockPane.DisplayingContents.IndexOf(content);
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeifenLuo.Docking
{
    internal sealed class DockPaneStripTabCollection : IEnumerable<DockPaneStripTabBase>
    {
        #region IEnumerable Members
        IEnumerator<DockPaneStripTabBase> IEnumerable<DockPaneStripTabBase>.GetEnumerator() {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator() {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }
        #endregion

        internal DockPaneStripTabCollection(DockPane pane) {
            m_dockPane = pane;
        }

        private DockPane m_dockPane;
        public DockPane DockPane {
            get { return m_dockPane; }
        }

        public int Count {
            get { return DockPane.DisplayingContents.Count; }
        }

        public DockPaneStripTabBase this[int index] {
            get {
                IDockContent content = DockPane.DisplayingContents[index];
                if (content == null)
                    throw (new ArgumentOutOfRangeException(nameof(index)));
                return content.DockHandler.GetTab(DockPane.TabStripControl);
            }
        }

        public bool Contains(DockPaneStripTabBase tab) {
            return (IndexOf(tab) != -1);
        }

        public bool Contains(IDockContent content) {
            return (IndexOf(content) != -1);
        }

        public int IndexOf(DockPaneStripTabBase tab) {
            if (tab == null)
                return -1;

            return DockPane.DisplayingContents.IndexOf(tab.Content);
        }

        public int IndexOf(IDockContent content) {
            return DockPane.DisplayingContents.IndexOf(content);
        }
    }

}

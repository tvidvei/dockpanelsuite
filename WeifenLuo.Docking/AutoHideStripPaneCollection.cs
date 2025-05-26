using System;
using System.Collections;
using System.Collections.Generic;

namespace WeifenLuo.Docking
{

    public sealed class AutoHideStripPaneCollection : IEnumerable<AutoHideStripPane>
    {
        private class AutoHideState
        {
            public DockState m_dockState;
            public bool m_selected = false;

            public AutoHideState(DockState dockState) {
                m_dockState = dockState;
            }

            public DockState DockState {
                get { return m_dockState; }
            }

            public bool Selected {
                get { return m_selected; }
                set { m_selected = value; }
            }
        }

        private class AutoHideStateCollection
        {
            private AutoHideState[] m_states;

            public AutoHideStateCollection() {
                m_states = new[]{
                                        new AutoHideState(DockState.DockTopAutoHide),
                                        new AutoHideState(DockState.DockBottomAutoHide),
                                        new AutoHideState(DockState.DockLeftAutoHide),
                                        new AutoHideState(DockState.DockRightAutoHide)
                                    };
            }

            public AutoHideState this[DockState dockState] {
                get {
                    for (int i = 0; i < m_states.Length; i++) {
                        if (m_states[i].DockState == dockState)
                            return m_states[i];
                    }
                    throw new ArgumentOutOfRangeException(nameof(dockState));
                }
            }

            public bool ContainsPane(DockPane pane) {
                if (pane.IsHidden)
                    return false;

                for (int i = 0; i < m_states.Length; i++) {
                    if (m_states[i].DockState == pane.DockState && m_states[i].Selected)
                        return true;
                }
                return false;
            }
        }

        internal AutoHideStripPaneCollection(DockPanel panel, DockState dockState) {
            m_dockPanel = panel;
            m_states = new AutoHideStateCollection();
            States[DockState.DockTopAutoHide].Selected = (dockState == DockState.DockTopAutoHide);
            States[DockState.DockBottomAutoHide].Selected = (dockState == DockState.DockBottomAutoHide);
            States[DockState.DockLeftAutoHide].Selected = (dockState == DockState.DockLeftAutoHide);
            States[DockState.DockRightAutoHide].Selected = (dockState == DockState.DockRightAutoHide);
        }

        private DockPanel m_dockPanel;
        public DockPanel DockPanel {
            get { return m_dockPanel; }
        }

        private AutoHideStateCollection m_states;
        private AutoHideStateCollection States {
            get { return m_states; }
        }

        public int Count {
            get {
                int count = 0;
                foreach (DockPane pane in DockPanel.Panes) {
                    if (States.ContainsPane(pane))
                        count++;
                }

                return count;
            }
        }

        public AutoHideStripPane this[int index] {
            get {
                int count = 0;
                foreach (DockPane pane in DockPanel.Panes) {
                    if (!States.ContainsPane(pane))
                        continue;

                    if (count == index) {
                        if (pane.AutoHidePane == null)
                            pane.AutoHidePane = DockPanel.AutoHideStripControl.CreatePane(pane);
                        return pane.AutoHidePane as AutoHideStripPane;
                    }

                    count++;
                }
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public bool Contains(AutoHideStripPane pane) {
            return (IndexOf(pane) != -1);
        }

        public int IndexOf(AutoHideStripPane pane) {
            if (pane == null)
                return -1;

            int index = 0;
            foreach (DockPane dockPane in DockPanel.Panes) {
                if (!States.ContainsPane(pane.DockPane))
                    continue;

                if (pane == dockPane.AutoHidePane)
                    return index;

                index++;
            }
            return -1;
        }

        #region IEnumerable Members

        IEnumerator<AutoHideStripPane> IEnumerable<AutoHideStripPane>.GetEnumerator() {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator() {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }

        #endregion
    }

}

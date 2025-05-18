using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeifenLuo.Docking
{
    public class AutoHideStripAccessibleObject : AccessibleObject
    {
        private AutoHideStripBase _strip;
        private DockState _state;
        private AccessibleObject _parent;

        public AutoHideStripAccessibleObject(AutoHideStripBase strip, DockState state, AccessibleObject parent) {
            _strip = strip;
            _state = state;

            _parent = parent;
        }

        public override AccessibleObject Parent {
            get {
                return _parent;
            }
        }

        public override AccessibleRole Role {
            get {
                return AccessibleRole.PageTabList;
            }
        }

        public override int GetChildCount() {
            int count = 0;
            foreach (AutoHideStripPane pane in _strip.GetPanes(_state)) {
                count += pane.AutoHideTabs.Count;
            }
            return count;
        }

        public override AccessibleObject GetChild(int index) {
            List<AutoHideStripTab> tabs = new List<AutoHideStripTab>();
            foreach (AutoHideStripPane pane in _strip.GetPanes(_state)) {
                tabs.AddRange(pane.AutoHideTabs);
            }

            return new AutoHideStripTabAccessibleObject(_strip, tabs[index], this);
        }

        public override Rectangle Bounds {
            get {
                Rectangle rectangle = _strip.GetTabStripRectangle(_state);
                return AutoHideStripBase.ToScreen(rectangle, _strip);
            }
        }
    }
}

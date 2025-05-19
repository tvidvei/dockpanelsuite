using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeifenLuo.Docking
{
    public class DockPaneStripAccessibleObject : Control.ControlAccessibleObject
    {
        private DockPaneStripBase _strip;

        public DockPaneStripAccessibleObject(DockPaneStripBase strip)
            : base(strip) {
            _strip = strip;
        }

        public override AccessibleRole Role {
            get {
                return AccessibleRole.PageTabList;
            }
        }

        public override int GetChildCount() {
            return _strip.Tabs.Count;
        }

        public override AccessibleObject GetChild(int index) {
            return new DockPaneStripTabAccessibleObject(_strip, _strip.Tabs[index], this);
        }

        public override AccessibleObject HitTest(int x, int y) {
            Point point = new Point(x, y);
            foreach (DockPaneStripTabBase tab in _strip.Tabs) {
                Rectangle rectangle = _strip.GetTabBounds(tab);
                if (DockPaneStripBase.ToScreen(rectangle, _strip).Contains(point))
                    return new DockPaneStripTabAccessibleObject(_strip, tab, this);
            }

            return null;
        }
    }

}

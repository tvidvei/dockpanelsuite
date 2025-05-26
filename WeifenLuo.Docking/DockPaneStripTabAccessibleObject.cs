using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeifenLuo.Docking
{
    internal class DockPaneStripTabAccessibleObject : AccessibleObject
    {
        private DockPaneStripBase _strip;
        private DockPaneStripTabBase _tab;

        private AccessibleObject _parent;

        internal DockPaneStripTabAccessibleObject(DockPaneStripBase strip, DockPaneStripTabBase tab, AccessibleObject parent) {
            _strip = strip;
            _tab = tab;

            _parent = parent;
        }

        public override AccessibleObject Parent {
            get {
                return _parent;
            }
        }

        public override AccessibleRole Role {
            get {
                return AccessibleRole.PageTab;
            }
        }

        public override Rectangle Bounds {
            get {
                Rectangle rectangle = _strip.GetTabBounds(_tab);
                return DockPaneStrip.ToScreen(rectangle, _strip);
            }
        }

        public override string Name {
            get {
                return _tab.Content.DockHandler.TabText;
            }
            set {
                //base.Name = value;
            }
        }
    }

}

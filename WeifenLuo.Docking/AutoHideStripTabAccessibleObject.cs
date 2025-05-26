using System.Drawing;
using System.Windows.Forms;

namespace WeifenLuo.Docking
{
    public class AutoHideStripTabAccessibleObject : AccessibleObject
    {
        private AutoHideStripBase _strip;
        private AutoHideStripTab _tab;

        private AccessibleObject _parent;

        internal AutoHideStripTabAccessibleObject(AutoHideStripBase strip, AutoHideStripTab tab, AccessibleObject parent) {
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
                return AutoHideStripBase.ToScreen(rectangle, _strip);
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

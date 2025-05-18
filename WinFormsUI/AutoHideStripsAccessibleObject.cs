using System.Collections.Generic;
using System.Drawing;
using static WeifenLuo.Docking.AutoHideStripBase;
using System.Windows.Forms;

namespace WeifenLuo.Docking
{
    public class AutoHideStripsAccessibleObject : Control.ControlAccessibleObject
    {
        private AutoHideStripBase _strip;

        public AutoHideStripsAccessibleObject(AutoHideStripBase strip)
            : base(strip) {
            _strip = strip;
        }

        public override AccessibleRole Role {
            get {
                return AccessibleRole.Window;
            }
        }

        public override int GetChildCount() {
            // Top, Bottom, Left, Right
            return 4;
        }

        public override AccessibleObject GetChild(int index) {
            switch (index) {
                case 0:
                    return new AutoHideStripAccessibleObject(_strip, DockState.DockTopAutoHide, this);
                case 1:
                    return new AutoHideStripAccessibleObject(_strip, DockState.DockBottomAutoHide, this);
                case 2:
                    return new AutoHideStripAccessibleObject(_strip, DockState.DockLeftAutoHide, this);
                case 3:
                default:
                    return new AutoHideStripAccessibleObject(_strip, DockState.DockRightAutoHide, this);
            }
        }

        public override AccessibleObject HitTest(int x, int y) {
            Dictionary<DockState, Rectangle> rectangles = new Dictionary<DockState, Rectangle> {
                    { DockState.DockTopAutoHide,    _strip.GetTabStripRectangle(DockState.DockTopAutoHide) },
                    { DockState.DockBottomAutoHide, _strip.GetTabStripRectangle(DockState.DockBottomAutoHide) },
                    { DockState.DockLeftAutoHide,   _strip.GetTabStripRectangle(DockState.DockLeftAutoHide) },
                    { DockState.DockRightAutoHide,  _strip.GetTabStripRectangle(DockState.DockRightAutoHide) },
                };

            Point point = _strip.PointToClient(new Point(x, y));
            foreach (var rectangle in rectangles) {
                if (rectangle.Value.Contains(point))
                    return new AutoHideStripAccessibleObject(_strip, rectangle.Key, this);
            }

            return null;
        }
    }

}

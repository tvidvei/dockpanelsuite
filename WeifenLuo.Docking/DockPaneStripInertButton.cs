using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeifenLuo.Docking
{
    [ToolboxItem(false)]
    internal sealed class DockPaneStripInertButton : InertButtonBase
    {
        private Bitmap _hovered, _normal, _pressed;

        public DockPaneStripInertButton(Bitmap hovered, Bitmap normal, Bitmap pressed)
            : base() {
            _hovered = hovered;
            _normal = normal;
            _pressed = pressed;
        }

        public override Bitmap Image {
            get { return _normal; }
        }

        public override Bitmap HoverImage {
            get { return _hovered; }
        }

        public override Bitmap PressImage {
            get { return _pressed; }
        }
    }

}

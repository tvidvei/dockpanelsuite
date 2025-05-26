using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WeifenLuo.Docking
{
    public abstract class AutoHideStripBase : Control
    {

        protected AutoHideStripBase(DockPanel panel)
        {
            DockPanel = panel;
            PanesTop = new AutoHideStripPaneCollection(panel, DockState.DockTopAutoHide);
            PanesBottom = new AutoHideStripPaneCollection(panel, DockState.DockBottomAutoHide);
            PanesLeft = new AutoHideStripPaneCollection(panel, DockState.DockLeftAutoHide);
            PanesRight = new AutoHideStripPaneCollection(panel, DockState.DockRightAutoHide);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.Selectable, false);
        }

        protected DockPanel DockPanel { get; private set; }

        protected AutoHideStripPaneCollection PanesTop { get; private set; }
        protected AutoHideStripPaneCollection PanesBottom { get; private set; }
        protected AutoHideStripPaneCollection PanesLeft { get; private set; }
        protected AutoHideStripPaneCollection PanesRight { get; private set; }

        internal AutoHideStripPaneCollection GetPanes(DockState dockState)
        {
            if (dockState == DockState.DockTopAutoHide)
                return PanesTop;
            else if (dockState == DockState.DockBottomAutoHide)
                return PanesBottom;
            else if (dockState == DockState.DockLeftAutoHide)
                return PanesLeft;
            else if (dockState == DockState.DockRightAutoHide)
                return PanesRight;
            else
                throw new ArgumentOutOfRangeException(nameof(dockState));
        }

        internal int GetNumberOfPanes(DockState dockState)
        {
            return GetPanes(dockState).Count;
        }

        /// <summary>
        /// The top left rectangle in auto hide strip area.
        /// </summary>
        protected Rectangle RectangleTopLeft
        {
            get
            {
                int standard = MeasureHeight();
                var padding = DockPanel.Theme.Measures.DockPadding;
                var width = PanesLeft.Count > 0 ? standard : padding;
                var height = PanesTop.Count > 0 ? standard : padding;
                return new Rectangle(0, 0, width, height);
            }
        }

        /// <summary>
        /// The top right rectangle in auto hide strip area.
        /// </summary>
        protected Rectangle RectangleTopRight
        {
            get
            {
                int standard = MeasureHeight();
                var padding = DockPanel.Theme.Measures.DockPadding;
                var width = PanesRight.Count > 0 ? standard : padding;
                var height = PanesTop.Count > 0 ? standard : padding;
                return new Rectangle(Width - width, 0, width, height);
            }
        }

        /// <summary>
        /// The bottom left rectangle in auto hide strip area.
        /// </summary>
        protected Rectangle RectangleBottomLeft
        {
            get
            {
                int standard = MeasureHeight();
                var padding = DockPanel.Theme.Measures.DockPadding;
                var width = PanesLeft.Count > 0 ? standard : padding;
                var height = PanesBottom.Count > 0 ? standard : padding;
                return new Rectangle(0, Height - height, width, height);
            }
        }

        /// <summary>
        /// The bottom right rectangle in auto hide strip area.
        /// </summary>
        protected Rectangle RectangleBottomRight
        {
            get
            {
                int standard = MeasureHeight();
                var padding = DockPanel.Theme.Measures.DockPadding;
                var width = PanesRight.Count > 0 ? standard : padding;
                var height = PanesBottom.Count > 0 ? standard : padding;
                return new Rectangle(Width - width, Height - height, width, height);
            }
        }

        /// <summary>
        /// Gets one of the four auto hide strip rectangles.
        /// </summary>
        /// <param name="dockState">Dock state.</param>
        /// <returns>The desired rectangle.</returns>
        /// <remarks>
        /// As the corners are represented by <see cref="RectangleTopLeft"/>, <see cref="RectangleTopRight"/>, <see cref="RectangleBottomLeft"/>, and <see cref="RectangleBottomRight"/>,
        /// the four strips can be easily calculated out as the borders.
        /// </remarks>
        protected internal Rectangle GetTabStripRectangle(DockState dockState)
        {
            if (dockState == DockState.DockTopAutoHide)
                return new Rectangle(RectangleTopLeft.Width, 0, Width - RectangleTopLeft.Width - RectangleTopRight.Width, RectangleTopLeft.Height);

            if (dockState == DockState.DockBottomAutoHide)
                return new Rectangle(RectangleBottomLeft.Width, Height - RectangleBottomLeft.Height, Width - RectangleBottomLeft.Width - RectangleBottomRight.Width, RectangleBottomLeft.Height);

            if (dockState == DockState.DockLeftAutoHide)
                return new Rectangle(0, RectangleTopLeft.Height, RectangleTopLeft.Width, Height - RectangleTopLeft.Height - RectangleBottomLeft.Height);

            if (dockState == DockState.DockRightAutoHide)
                return new Rectangle(Width - RectangleTopRight.Width, RectangleTopRight.Height, RectangleTopRight.Width, Height - RectangleTopRight.Height - RectangleBottomRight.Height);

            return Rectangle.Empty;
        }

        private GraphicsPath m_displayingArea;

        private GraphicsPath DisplayingArea
        {
            get
            {
                if (m_displayingArea == null)
                    m_displayingArea = new GraphicsPath();

                return m_displayingArea;
            }
        }

        private void SetRegion()
        {
            DisplayingArea.Reset();
            DisplayingArea.AddRectangle(RectangleTopLeft);
            DisplayingArea.AddRectangle(RectangleTopRight);
            DisplayingArea.AddRectangle(RectangleBottomLeft);
            DisplayingArea.AddRectangle(RectangleBottomRight);
            DisplayingArea.AddRectangle(GetTabStripRectangle(DockState.DockTopAutoHide));
            DisplayingArea.AddRectangle(GetTabStripRectangle(DockState.DockBottomAutoHide));
            DisplayingArea.AddRectangle(GetTabStripRectangle(DockState.DockLeftAutoHide));
            DisplayingArea.AddRectangle(GetTabStripRectangle(DockState.DockRightAutoHide));
            Region = new Region(DisplayingArea);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button != MouseButtons.Left)
                return;

            IDockContent content = HitTest();
            if (content == null)
                return;

            SetActiveAutoHideContent(content);

            content.DockHandler.Activate();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);

            if (!DockPanel.ShowAutoHideContentOnHover)
                return;

            // IMPORTANT: VS2003/2005 themes only.
            IDockContent content = HitTest();
            SetActiveAutoHideContent(content);

            // requires further tracking of mouse hover behavior,
            ResetMouseEventArgs();
        }

        private void SetActiveAutoHideContent(IDockContent content)
        {
            if (content != null)
                if (DockPanel.ActiveAutoHideContent != content)
                    DockPanel.ActiveAutoHideContent = content;
                else if (!DockPanel.ShowAutoHideContentOnHover)
                    DockPanel.ActiveAutoHideContent = null; // IMPORTANT: Not needed for VS2003/2005 themes.
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            RefreshChanges();
            base.OnLayout (levent);
        }

        internal void RefreshChanges()
        {
            if (IsDisposed)
                return;

            SetRegion();
            OnRefreshChanges();
        }

        protected virtual void OnRefreshChanges()
        {
        }

        protected internal abstract int MeasureHeight();

        private IDockContent HitTest()
        {
            Point ptMouse = PointToClient(Control.MousePosition);
            return HitTest(ptMouse);
        }

        public virtual AutoHideStripTab CreateTab(IDockContent content)
        {
            return new AutoHideStripTab(content);
        }

        public virtual AutoHideStripPane CreatePane(DockPane dockPane)
        {
            return new AutoHideStripPane(dockPane);
        }

        protected abstract IDockContent HitTest(Point point);

        protected override AccessibleObject CreateAccessibilityInstance()
        {
            return new AutoHideStripsAccessibleObject(this);
        }

        internal abstract Rectangle GetTabBounds(AutoHideStripTab tab);

        internal static Rectangle ToScreen(Rectangle rectangle, Control parent)
        {
            if (parent == null)
                return rectangle;

            return new Rectangle(parent.PointToScreen(new Point(rectangle.Left, rectangle.Top)), new Size(rectangle.Width, rectangle.Height));
        }

    }
}

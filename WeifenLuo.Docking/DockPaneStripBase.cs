using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Diagnostics.CodeAnalysis;

namespace WeifenLuo.Docking
{
    public abstract class DockPaneStripBase : Control
    {

        protected DockPaneStripBase(DockPane pane)
        {
            m_dockPane = pane;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.Selectable, false);
            AllowDrop = true;
        }

        private DockPane m_dockPane;
        protected DockPane DockPane
        {
            get { return m_dockPane; }
        }

        protected DockPane.AppearanceStyle Appearance
        {
            get { return DockPane.Appearance; }
        }

        private DockPaneStripTabCollection m_tabs;

        internal DockPaneStripTabCollection Tabs
        {
            get
            {
                return m_tabs ?? (m_tabs = new DockPaneStripTabCollection(DockPane));
            }
        }

        internal void RefreshChanges()
        {
            if (IsDisposed)
                return;

            OnRefreshChanges();
        }

        protected virtual void OnRefreshChanges()
        {
        }

        protected internal abstract int MeasureHeight();

        protected internal abstract void EnsureTabVisible(IDockContent content);

        protected int HitTest()
        {
            return HitTest(PointToClient(Control.MousePosition));
        }

        protected internal abstract int HitTest(Point point);

        protected virtual bool MouseDownActivateTest(MouseEventArgs e)
        {
            return true;
        }

        public abstract GraphicsPath GetOutline(int index);

        internal virtual DockPaneStripTabBase CreateTab(IDockContent content)
        {
            return new DockPaneStripTabBase(content);
        }

        private Rectangle _dragBox = Rectangle.Empty;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int index = HitTest();
            if (index != -1)
            {
                if (e.Button == MouseButtons.Middle)
                {
                    // Close the specified content.
                    TryCloseTab(index);
                }
                else
                {
                    IDockContent content = Tabs[index].Content;
                    if (DockPane.ActiveContent != content)
                    {
                        // Test if the content should be active
                        if (MouseDownActivateTest(e))
                            DockPane.ActiveContent = content;
                    }

                }
            }

            if (e.Button == MouseButtons.Left)
            {
                var dragSize = SystemInformation.DragSize;
                _dragBox = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                e.Y - (dragSize.Height / 2)), dragSize);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button != MouseButtons.Left || _dragBox.Contains(e.Location)) 
                return;

            if (DockPane.ActiveContent == null)
                return;

            if (DockPane.DockPanel.AllowEndUserDocking && DockPane.AllowDockDragAndDrop && DockPane.ActiveContent.DockHandler.AllowEndUserDocking)
                DockPane.DockPanel.BeginDrag(DockPane.ActiveContent.DockHandler);
        }

        protected bool HasTabPageContextMenu
        {
            get { return DockPane.HasTabPageContextMenu; }
        }

        protected void ShowTabPageContextMenu(Point position)
        {
            DockPane.ShowTabPageContextMenu(this, position);
        }

        protected bool TryCloseTab(int index)
        {
            if (index >= 0 || index < Tabs.Count)
            {
                // Close the specified content.
                IDockContent content = Tabs[index].Content;
                DockPane.CloseContent(content);
                if (PatchController.EnableSelectClosestOnClose == true)
                    SelectClosestPane(index);

                return true;
            }
            return false;
        }

        private void SelectClosestPane(int index)
        {
            if (index > 0 && DockPane.DockPanel.DocumentStyle == DocumentStyle.DockingWindow)
            {
                index = index - 1;

                if (index >= 0 || index < Tabs.Count)                
                    DockPane.ActiveContent = Tabs[index].Content;                
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Right)
                ShowTabPageContextMenu(new Point(e.X, e.Y));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)Win32.Msgs.WM_LBUTTONDBLCLK)
            {
                base.WndProc(ref m);

                int index = HitTest();
                if (DockPane.DockPanel.AllowEndUserDocking && index != -1)
                {
                    IDockContent content = Tabs[index].Content;
                    if (content.DockHandler.CheckDockState(!content.DockHandler.IsFloat) != DockState.Unknown)
                        content.DockHandler.IsFloat = !content.DockHandler.IsFloat;	
                }

                return;
            }

            base.WndProc(ref m);
            return;
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);

            int index = HitTest();
            if (index != -1)
            {
                IDockContent content = Tabs[index].Content;
                if (DockPane.ActiveContent != content)
                    DockPane.ActiveContent = content;
            }
        }

        protected void ContentClosed()
        {
            if (m_tabs.Count == 0)
            {
                DockPane.ClearLastActiveContent();
            }
        }

        internal abstract Rectangle GetTabBounds(DockPaneStripTabBase tab);

        internal static Rectangle ToScreen(Rectangle rectangle, Control parent)
        {
            if (parent == null)
                return rectangle;

            return new Rectangle(parent.PointToScreen(new Point(rectangle.Left, rectangle.Top)), new Size(rectangle.Width, rectangle.Height));
        }

        protected override AccessibleObject CreateAccessibilityInstance()
        {
            return new DockPaneStripAccessibleObject(this);
        }
 
    }
}

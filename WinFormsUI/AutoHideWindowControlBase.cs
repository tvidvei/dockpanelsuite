using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WeifenLuo.Docking
{
    [ToolboxItem(false)]
    public class AutoHideWindowControlBase : Panel, ISplitterHost
    {
        protected class SplitterControl : WindowSplitterBase
        {
            public SplitterControl(AutoHideWindowControlBase autoHideWindow) {
                m_autoHideWindow = autoHideWindow;
            }

            private AutoHideWindowControlBase m_autoHideWindow;
            private AutoHideWindowControlBase AutoHideWindow {
                get { return m_autoHideWindow; }
            }

            protected override int SplitterSize {
                get { return AutoHideWindow.DockPanel.Theme.Measures.AutoHideSplitterSize; }
            }

            protected override void StartDrag() {
                AutoHideWindow.DockPanel.BeginDrag(AutoHideWindow, AutoHideWindow.RectangleToScreen(Bounds));
            }
        }

        #region consts
        private const int ANIMATE_TIME = 100;    // in mini-seconds
        #endregion

        private Timer m_timerMouseTrack;
        protected WindowSplitterBase m_splitter { get; private set; }

        public AutoHideWindowControlBase(DockPanel dockPanel) {
            m_dockPanel = dockPanel;

            m_timerMouseTrack = new Timer();
            m_timerMouseTrack.Tick += new EventHandler(TimerMouseTrack_Tick);

            Visible = false;
            m_splitter = DockPanel.CreateWindowSplitterControl(this);
            Controls.Add(m_splitter);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                m_timerMouseTrack.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool IsDockWindow {
            get { return false; }
        }

        private DockPanel m_dockPanel = null;
        public DockPanel DockPanel {
            get { return m_dockPanel; }
        }

        private DockPane m_activePane = null;
        public DockPane ActivePane {
            get { return m_activePane; }
        }

        private void SetActivePane() {
            DockPane value = (ActiveContent == null ? null : ActiveContent.DockHandler.Pane);

            if (value == m_activePane)
                return;

            m_activePane = value;
        }

        private static readonly object AutoHideActiveContentChangedEvent = new object();

        public event EventHandler ActiveContentChanged {
            add { Events.AddHandler(AutoHideActiveContentChangedEvent, value); }
            remove { Events.RemoveHandler(AutoHideActiveContentChangedEvent, value); }
        }

        protected virtual void OnActiveContentChanged(EventArgs e) {
            EventHandler handler = (EventHandler)Events[DockPanel.ActiveContentChangedEvent];
            if (handler != null)
                handler(this, e);
        }

        private IDockContent m_activeContent = null;
        public IDockContent ActiveContent {
            get { return m_activeContent; }
            set {
                if (value == m_activeContent)
                    return;

                if (value != null) {
                    if (!DockHelper.IsDockStateAutoHide(value.DockHandler.DockState) || value.DockHandler.DockPanel != DockPanel)
                        throw (new InvalidOperationException(Strings.DockPanel_ActiveAutoHideContent_InvalidValue));
                }

                DockPanel.SuspendLayout();

                if (m_activeContent != null) {
                    if (m_activeContent.DockHandler.Form.ContainsFocus) {
                        if (!Win32Helper.IsRunningOnMono) {
                            DockPanel.ContentFocusManager.GiveUpFocus(m_activeContent);
                        }
                    }

                    AnimateWindow(false);
                }

                m_activeContent = value;
                SetActivePane();
                if (ActivePane != null)
                    ActivePane.ActiveContent = m_activeContent;

                if (m_activeContent != null)
                    AnimateWindow(true);

                DockPanel.ResumeLayout();
                DockPanel.RefreshAutoHideStrip();

                SetTimerMouseTrack();

                OnActiveContentChanged(EventArgs.Empty);
            }
        }

        public DockState DockState {
            get { return ActiveContent == null ? DockState.Unknown : ActiveContent.DockHandler.DockState; }
        }

        private bool m_flagAnimate = true;
        private bool FlagAnimate {
            get { return m_flagAnimate; }
            set { m_flagAnimate = value; }
        }

        private bool m_flagDragging = false;
        internal bool FlagDragging {
            get { return m_flagDragging; }
            set {
                if (m_flagDragging == value)
                    return;

                m_flagDragging = value;
                SetTimerMouseTrack();
            }
        }

        private void AnimateWindow(bool show) {
            if (!FlagAnimate && Visible != show) {
                Visible = show;
                return;
            }

            Parent.SuspendLayout();

            Rectangle rectSource = GetRectangle(!show);
            Rectangle rectTarget = GetRectangle(show);
            int dxLoc, dyLoc;
            int dWidth, dHeight;
            dxLoc = dyLoc = dWidth = dHeight = 0;
            if (DockState == DockState.DockTopAutoHide)
                dHeight = show ? 1 : -1;
            else if (DockState == DockState.DockLeftAutoHide)
                dWidth = show ? 1 : -1;
            else if (DockState == DockState.DockRightAutoHide) {
                dxLoc = show ? -1 : 1;
                dWidth = show ? 1 : -1;
            } else if (DockState == DockState.DockBottomAutoHide) {
                dyLoc = (show ? -1 : 1);
                dHeight = (show ? 1 : -1);
            }

            if (show) {
                Bounds = DockPanel.GetAutoHideWindowBounds(new Rectangle(-rectTarget.Width, -rectTarget.Height, rectTarget.Width, rectTarget.Height));
                if (Visible == false)
                    Visible = true;
                PerformLayout();
            }

            SuspendLayout();

            LayoutAnimateWindow(rectSource);
            if (Visible == false)
                Visible = true;

            int speedFactor = 1;
            int totalPixels = (rectSource.Width != rectTarget.Width) ?
                Math.Abs(rectSource.Width - rectTarget.Width) :
                Math.Abs(rectSource.Height - rectTarget.Height);
            int remainPixels = totalPixels;
            DateTime startingTime = DateTime.Now;
            while (rectSource != rectTarget) {
                DateTime startPerMove = DateTime.Now;

                rectSource.X += dxLoc * speedFactor;
                rectSource.Y += dyLoc * speedFactor;
                rectSource.Width += dWidth * speedFactor;
                rectSource.Height += dHeight * speedFactor;
                if (Math.Sign(rectTarget.X - rectSource.X) != Math.Sign(dxLoc))
                    rectSource.X = rectTarget.X;
                if (Math.Sign(rectTarget.Y - rectSource.Y) != Math.Sign(dyLoc))
                    rectSource.Y = rectTarget.Y;
                if (Math.Sign(rectTarget.Width - rectSource.Width) != Math.Sign(dWidth))
                    rectSource.Width = rectTarget.Width;
                if (Math.Sign(rectTarget.Height - rectSource.Height) != Math.Sign(dHeight))
                    rectSource.Height = rectTarget.Height;

                LayoutAnimateWindow(rectSource);
                if (Parent != null)
                    Parent.Update();

                remainPixels -= speedFactor;

                while (true) {
                    TimeSpan time = new TimeSpan(0, 0, 0, 0, ANIMATE_TIME);
                    TimeSpan elapsedPerMove = DateTime.Now - startPerMove;
                    TimeSpan elapsedTime = DateTime.Now - startingTime;
                    if (((int)((time - elapsedTime).TotalMilliseconds)) <= 0) {
                        speedFactor = remainPixels;
                        break;
                    } else
                        speedFactor = remainPixels * (int)elapsedPerMove.TotalMilliseconds / (int)((time - elapsedTime).TotalMilliseconds);
                    if (speedFactor >= 1)
                        break;
                }
            }
            ResumeLayout();
            Parent.ResumeLayout();
        }

        private void LayoutAnimateWindow(Rectangle rect) {
            Bounds = DockPanel.GetAutoHideWindowBounds(rect);

            Rectangle rectClient = ClientRectangle;

            if (DockState == DockState.DockLeftAutoHide)
                ActivePane.Location = new Point(rectClient.Right - 2 - DockPanel.Theme.Measures.AutoHideSplitterSize - ActivePane.Width, ActivePane.Location.Y);
            else if (DockState == DockState.DockTopAutoHide)
                ActivePane.Location = new Point(ActivePane.Location.X, rectClient.Bottom - 2 - DockPanel.Theme.Measures.AutoHideSplitterSize - ActivePane.Height);
        }

        private Rectangle GetRectangle(bool show) {
            if (DockState == DockState.Unknown)
                return Rectangle.Empty;

            Rectangle rect = DockPanel.AutoHideWindowRectangle;

            if (show)
                return rect;

            if (DockState == DockState.DockLeftAutoHide)
                rect.Width = 0;
            else if (DockState == DockState.DockRightAutoHide) {
                rect.X += rect.Width;
                rect.Width = 0;
            } else if (DockState == DockState.DockTopAutoHide)
                rect.Height = 0;
            else {
                rect.Y += rect.Height;
                rect.Height = 0;
            }

            return rect;
        }

        private void SetTimerMouseTrack() {
            if (ActivePane == null || ActivePane.IsActivated || FlagDragging) {
                m_timerMouseTrack.Enabled = false;
                return;
            }

            // start the timer
            int hovertime = SystemInformation.MouseHoverTime;

            // assign a default value 400 in case of setting Timer.Interval invalid value exception
            if (hovertime <= 0)
                hovertime = 400;

            m_timerMouseTrack.Interval = 2 * (int)hovertime;
            m_timerMouseTrack.Enabled = true;
        }

        protected virtual Rectangle DisplayingRectangle {
            get {
                Rectangle rect = ClientRectangle;

                // exclude the border and the splitter
                if (DockState == DockState.DockBottomAutoHide) {
                    rect.Y += 2 + DockPanel.Theme.Measures.AutoHideSplitterSize;
                    rect.Height -= 2 + DockPanel.Theme.Measures.AutoHideSplitterSize;
                } else if (DockState == DockState.DockRightAutoHide) {
                    rect.X += 2 + DockPanel.Theme.Measures.AutoHideSplitterSize;
                    rect.Width -= 2 + DockPanel.Theme.Measures.AutoHideSplitterSize;
                } else if (DockState == DockState.DockTopAutoHide)
                    rect.Height -= 2 + DockPanel.Theme.Measures.AutoHideSplitterSize;
                else if (DockState == DockState.DockLeftAutoHide)
                    rect.Width -= 2 + DockPanel.Theme.Measures.AutoHideSplitterSize;

                return rect;
            }
        }

        public void RefreshActiveContent() {
            if (ActiveContent == null)
                return;

            if (!DockHelper.IsDockStateAutoHide(ActiveContent.DockHandler.DockState)) {
                FlagAnimate = false;
                ActiveContent = null;
                FlagAnimate = true;
            }
        }

        public void RefreshActivePane() {
            SetTimerMouseTrack();
        }

        private void TimerMouseTrack_Tick(object sender, EventArgs e) {
            if (IsDisposed)
                return;

            if (ActivePane == null || ActivePane.IsActivated) {
                m_timerMouseTrack.Enabled = false;
                return;
            }

            DockPane pane = ActivePane;
            Point ptMouseInAutoHideWindow = PointToClient(Control.MousePosition);
            Point ptMouseInDockPanel = DockPanel.PointToClient(Control.MousePosition);

            Rectangle rectTabStrip = DockPanel.GetTabStripRectangle(pane.DockState);

            if (!ClientRectangle.Contains(ptMouseInAutoHideWindow) && !rectTabStrip.Contains(ptMouseInDockPanel)) {
                ActiveContent = null;
                m_timerMouseTrack.Enabled = false;
            }
        }

        #region ISplitterDragSource Members

        void ISplitterDragSource.BeginDrag(Rectangle rectSplitter) {
            FlagDragging = true;
        }

        void ISplitterDragSource.EndDrag() {
            FlagDragging = false;
        }

        bool ISplitterDragSource.IsVertical {
            get { return (DockState == DockState.DockLeftAutoHide || DockState == DockState.DockRightAutoHide); }
        }

        Rectangle ISplitterDragSource.DragLimitBounds {
            get {
                Rectangle rectLimit = DockPanel.DockArea;

                if ((this as ISplitterDragSource).IsVertical) {
                    rectLimit.X += MeasurePane.MinSize;
                    rectLimit.Width -= 2 * MeasurePane.MinSize;
                } else {
                    rectLimit.Y += MeasurePane.MinSize;
                    rectLimit.Height -= 2 * MeasurePane.MinSize;
                }

                return DockPanel.RectangleToScreen(rectLimit);
            }
        }

        void ISplitterDragSource.MoveSplitter(int offset) {
            Rectangle rectDockArea = DockPanel.DockArea;
            IDockContent content = ActiveContent;
            if (DockState == DockState.DockLeftAutoHide && rectDockArea.Width > 0) {
                if (content.DockHandler.AutoHidePortion < 1)
                    content.DockHandler.AutoHidePortion += ((double)offset) / (double)rectDockArea.Width;
                else
                    content.DockHandler.AutoHidePortion = Width + offset;
            } else if (DockState == DockState.DockRightAutoHide && rectDockArea.Width > 0) {
                if (content.DockHandler.AutoHidePortion < 1)
                    content.DockHandler.AutoHidePortion -= ((double)offset) / (double)rectDockArea.Width;
                else
                    content.DockHandler.AutoHidePortion = Width - offset;
            } else if (DockState == DockState.DockBottomAutoHide && rectDockArea.Height > 0) {
                if (content.DockHandler.AutoHidePortion < 1)
                    content.DockHandler.AutoHidePortion -= ((double)offset) / (double)rectDockArea.Height;
                else
                    content.DockHandler.AutoHidePortion = Height - offset;
            } else if (DockState == DockState.DockTopAutoHide && rectDockArea.Height > 0) {
                if (content.DockHandler.AutoHidePortion < 1)
                    content.DockHandler.AutoHidePortion += ((double)offset) / (double)rectDockArea.Height;
                else
                    content.DockHandler.AutoHidePortion = Height + offset;
            }
        }

        #region IDragSource Members

        Control IDragSource.DragControl {
            get { return this; }
        }

        #endregion

        #endregion
    }

}

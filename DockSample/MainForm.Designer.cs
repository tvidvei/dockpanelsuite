namespace DockSample
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainMenu = new System.Windows.Forms.MenuStrip();
            menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            menuItemCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            menuItemCloseAllButThisOne = new System.Windows.Forms.ToolStripMenuItem();
            menuItem4 = new System.Windows.Forms.ToolStripSeparator();
            menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            exitWithoutSavingLayout = new System.Windows.Forms.ToolStripMenuItem();
            menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            menuItemSolutionExplorer = new System.Windows.Forms.ToolStripMenuItem();
            menuItemPropertyWindow = new System.Windows.Forms.ToolStripMenuItem();
            menuItemToolbox = new System.Windows.Forms.ToolStripMenuItem();
            menuItemOutputWindow = new System.Windows.Forms.ToolStripMenuItem();
            menuItemTaskList = new System.Windows.Forms.ToolStripMenuItem();
            menuItem1 = new System.Windows.Forms.ToolStripSeparator();
            menuItemToolBar = new System.Windows.Forms.ToolStripMenuItem();
            menuItemStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            menuItem2 = new System.Windows.Forms.ToolStripSeparator();
            menuItemLayoutByCode = new System.Windows.Forms.ToolStripMenuItem();
            menuItemLayoutByXml = new System.Windows.Forms.ToolStripMenuItem();
            menuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            menuItemLockLayout = new System.Windows.Forms.ToolStripMenuItem();
            menuItemShowDocumentIcon = new System.Windows.Forms.ToolStripMenuItem();
            menuItem3 = new System.Windows.Forms.ToolStripSeparator();
            menuItemSchemaVS2015Light = new System.Windows.Forms.ToolStripMenuItem();
            menuItemSchemaVS2015Blue = new System.Windows.Forms.ToolStripMenuItem();
            menuItemSchemaVS2015Dark = new System.Windows.Forms.ToolStripMenuItem();
            menuItem6 = new System.Windows.Forms.ToolStripSeparator();
            menuItemDockingMdi = new System.Windows.Forms.ToolStripMenuItem();
            menuItemDockingSdi = new System.Windows.Forms.ToolStripMenuItem();
            menuItemDockingWindow = new System.Windows.Forms.ToolStripMenuItem();
            menuItemSystemMdi = new System.Windows.Forms.ToolStripMenuItem();
            menuItem5 = new System.Windows.Forms.ToolStripSeparator();
            showRightToLeft = new System.Windows.Forms.ToolStripMenuItem();
            menuItemWindow = new System.Windows.Forms.ToolStripMenuItem();
            menuItemNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            statusBar = new System.Windows.Forms.StatusStrip();
            imageList = new System.Windows.Forms.ImageList(components);
            toolBar = new System.Windows.Forms.ToolStrip();
            toolBarButtonNew = new System.Windows.Forms.ToolStripButton();
            toolBarButtonOpen = new System.Windows.Forms.ToolStripButton();
            toolBarButtonSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolBarButtonSolutionExplorer = new System.Windows.Forms.ToolStripButton();
            toolBarButtonPropertyWindow = new System.Windows.Forms.ToolStripButton();
            toolBarButtonToolbox = new System.Windows.Forms.ToolStripButton();
            toolBarButtonOutputWindow = new System.Windows.Forms.ToolStripButton();
            toolBarButtonTaskList = new System.Windows.Forms.ToolStripButton();
            toolBarButtonSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolBarButtonLayoutByCode = new System.Windows.Forms.ToolStripButton();
            toolBarButtonLayoutByXml = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            subMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            itemAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            itemBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            disabledItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dockPanel = new WeifenLuo.Docking.DockPanel();
            vsToolStripExtender1 = new WeifenLuo.Docking.VisualStudioToolStripExtender(components);
            mainMenu.SuspendLayout();
            toolBar.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            menuItemFile,
            menuItemView,
            menuItemTools,
            menuItemWindow,
            menuItemHelp});
            mainMenu.Location = new System.Drawing.Point(0, 0);
            mainMenu.MdiWindowListItem = menuItemWindow;
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new System.Drawing.Size(579, 24);
            mainMenu.TabIndex = 7;
            // 
            // menuItemFile
            // 
            menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            menuItemNew,
            menuItemOpen,
            menuItemClose,
            menuItemCloseAll,
            menuItemCloseAllButThisOne,
            menuItem4,
            menuItemExit,
            exitWithoutSavingLayout});
            menuItemFile.Name = "menuItemFile";
            menuItemFile.Size = new System.Drawing.Size(37, 20);
            menuItemFile.Text = "&File";
            menuItemFile.DropDownOpening += new System.EventHandler(menuItemFile_Popup);
            // 
            // menuItemNew
            // 
            menuItemNew.Name = "menuItemNew";
            menuItemNew.Size = new System.Drawing.Size(215, 22);
            menuItemNew.Text = "&New";
            menuItemNew.Click += new System.EventHandler(menuItemNew_Click);
            // 
            // menuItemOpen
            // 
            menuItemOpen.Name = "menuItemOpen";
            menuItemOpen.Size = new System.Drawing.Size(215, 22);
            menuItemOpen.Text = "&Open...";
            menuItemOpen.Click += new System.EventHandler(menuItemOpen_Click);
            // 
            // menuItemClose
            // 
            menuItemClose.Name = "menuItemClose";
            menuItemClose.Size = new System.Drawing.Size(215, 22);
            menuItemClose.Text = "&Close";
            menuItemClose.Click += new System.EventHandler(menuItemClose_Click);
            // 
            // menuItemCloseAll
            // 
            menuItemCloseAll.Name = "menuItemCloseAll";
            menuItemCloseAll.Size = new System.Drawing.Size(215, 22);
            menuItemCloseAll.Text = "Close &All";
            menuItemCloseAll.Click += new System.EventHandler(menuItemCloseAll_Click);
            // 
            // menuItemCloseAllButThisOne
            // 
            menuItemCloseAllButThisOne.Name = "menuItemCloseAllButThisOne";
            menuItemCloseAllButThisOne.Size = new System.Drawing.Size(215, 22);
            menuItemCloseAllButThisOne.Text = "Close All &But This One";
            menuItemCloseAllButThisOne.Click += new System.EventHandler(menuItemCloseAllButThisOne_Click);
            // 
            // menuItem4
            // 
            menuItem4.Name = "menuItem4";
            menuItem4.Size = new System.Drawing.Size(212, 6);
            // 
            // menuItemExit
            // 
            menuItemExit.Name = "menuItemExit";
            menuItemExit.Size = new System.Drawing.Size(215, 22);
            menuItemExit.Text = "&Exit";
            menuItemExit.Click += new System.EventHandler(menuItemExit_Click);
            // 
            // exitWithoutSavingLayout
            // 
            exitWithoutSavingLayout.Name = "exitWithoutSavingLayout";
            exitWithoutSavingLayout.Size = new System.Drawing.Size(215, 22);
            exitWithoutSavingLayout.Text = "Exit &Without Saving Layout";
            exitWithoutSavingLayout.Click += new System.EventHandler(exitWithoutSavingLayout_Click);
            // 
            // menuItemView
            // 
            menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            menuItemSolutionExplorer,
            menuItemPropertyWindow,
            menuItemToolbox,
            menuItemOutputWindow,
            menuItemTaskList,
            menuItem1,
            menuItemToolBar,
            menuItemStatusBar,
            menuItem2,
            menuItemLayoutByCode,
            menuItemLayoutByXml,
            toolStripSeparator1,
            subMenuToolStripMenuItem,
            disabledItemToolStripMenuItem});
            menuItemView.MergeIndex = 1;
            menuItemView.Name = "menuItemView";
            menuItemView.Size = new System.Drawing.Size(44, 20);
            menuItemView.Text = "&View";
            // 
            // menuItemSolutionExplorer
            // 
            menuItemSolutionExplorer.Name = "menuItemSolutionExplorer";
            menuItemSolutionExplorer.Size = new System.Drawing.Size(185, 22);
            menuItemSolutionExplorer.Text = "&Solution Explorer";
            menuItemSolutionExplorer.Click += new System.EventHandler(menuItemSolutionExplorer_Click);
            // 
            // menuItemPropertyWindow
            // 
            menuItemPropertyWindow.Name = "menuItemPropertyWindow";
            menuItemPropertyWindow.ShortcutKeys = System.Windows.Forms.Keys.F4;
            menuItemPropertyWindow.Size = new System.Drawing.Size(185, 22);
            menuItemPropertyWindow.Text = "&Property Window";
            menuItemPropertyWindow.Click += new System.EventHandler(menuItemPropertyWindow_Click);
            // 
            // menuItemToolbox
            // 
            menuItemToolbox.Name = "menuItemToolbox";
            menuItemToolbox.Size = new System.Drawing.Size(185, 22);
            menuItemToolbox.Text = "&Toolbox";
            menuItemToolbox.Click += new System.EventHandler(menuItemToolbox_Click);
            // 
            // menuItemOutputWindow
            // 
            menuItemOutputWindow.Name = "menuItemOutputWindow";
            menuItemOutputWindow.Size = new System.Drawing.Size(185, 22);
            menuItemOutputWindow.Text = "&Output Window";
            menuItemOutputWindow.Click += new System.EventHandler(menuItemOutputWindow_Click);
            // 
            // menuItemTaskList
            // 
            menuItemTaskList.Name = "menuItemTaskList";
            menuItemTaskList.Size = new System.Drawing.Size(185, 22);
            menuItemTaskList.Text = "Task &List";
            menuItemTaskList.Click += new System.EventHandler(menuItemTaskList_Click);
            // 
            // menuItem1
            // 
            menuItem1.Name = "menuItem1";
            menuItem1.Size = new System.Drawing.Size(182, 6);
            // 
            // menuItemToolBar
            // 
            menuItemToolBar.Checked = true;
            menuItemToolBar.CheckState = System.Windows.Forms.CheckState.Checked;
            menuItemToolBar.Name = "menuItemToolBar";
            menuItemToolBar.Size = new System.Drawing.Size(185, 22);
            menuItemToolBar.Text = "Tool &Bar";
            menuItemToolBar.Click += new System.EventHandler(menuItemToolBar_Click);
            // 
            // menuItemStatusBar
            // 
            menuItemStatusBar.Checked = true;
            menuItemStatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            menuItemStatusBar.Name = "menuItemStatusBar";
            menuItemStatusBar.Size = new System.Drawing.Size(185, 22);
            menuItemStatusBar.Text = "Status B&ar";
            menuItemStatusBar.Click += new System.EventHandler(menuItemStatusBar_Click);
            // 
            // menuItem2
            // 
            menuItem2.Name = "menuItem2";
            menuItem2.Size = new System.Drawing.Size(182, 6);
            // 
            // menuItemLayoutByCode
            // 
            menuItemLayoutByCode.Name = "menuItemLayoutByCode";
            menuItemLayoutByCode.Size = new System.Drawing.Size(185, 22);
            menuItemLayoutByCode.Text = "Layout By &Code";
            menuItemLayoutByCode.Click += new System.EventHandler(menuItemLayoutByCode_Click);
            // 
            // menuItemLayoutByXml
            // 
            menuItemLayoutByXml.Name = "menuItemLayoutByXml";
            menuItemLayoutByXml.Size = new System.Drawing.Size(185, 22);
            menuItemLayoutByXml.Text = "Layout By &XML";
            menuItemLayoutByXml.Click += new System.EventHandler(menuItemLayoutByXml_Click);
            // 
            // menuItemTools
            // 
            menuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            menuItemLockLayout,
            menuItemShowDocumentIcon,
            menuItem3,
            menuItemSchemaVS2015Light,
            menuItemSchemaVS2015Blue,
            menuItemSchemaVS2015Dark,
            menuItem6,
            menuItemDockingMdi,
            menuItemDockingSdi,
            menuItemDockingWindow,
            menuItemSystemMdi,
            menuItem5,
            showRightToLeft});
            menuItemTools.MergeIndex = 2;
            menuItemTools.Name = "menuItemTools";
            menuItemTools.Size = new System.Drawing.Size(47, 20);
            menuItemTools.Text = "&Tools";
            menuItemTools.DropDownOpening += new System.EventHandler(menuItemTools_Popup);
            // 
            // menuItemLockLayout
            // 
            menuItemLockLayout.Name = "menuItemLockLayout";
            menuItemLockLayout.Size = new System.Drawing.Size(255, 22);
            menuItemLockLayout.Text = "&Lock Layout";
            menuItemLockLayout.Click += new System.EventHandler(menuItemLockLayout_Click);
            // 
            // menuItemShowDocumentIcon
            // 
            menuItemShowDocumentIcon.Name = "menuItemShowDocumentIcon";
            menuItemShowDocumentIcon.Size = new System.Drawing.Size(255, 22);
            menuItemShowDocumentIcon.Text = "&Show Document Icon";
            menuItemShowDocumentIcon.Click += new System.EventHandler(menuItemShowDocumentIcon_Click);
            // 
            // menuItem3
            // 
            menuItem3.Name = "menuItem3";
            menuItem3.Size = new System.Drawing.Size(252, 6);
            // 
            // menuItemSchemaVS2015Light
            // 
            menuItemSchemaVS2015Light.Name = "menuItemSchemaVS2015Light";
            menuItemSchemaVS2015Light.Size = new System.Drawing.Size(255, 22);
            menuItemSchemaVS2015Light.Text = "Schema: VS2015 Light";
            menuItemSchemaVS2015Light.Click += new System.EventHandler(SetSchema);
            // 
            // menuItemSchemaVS2015Blue
            // 
            menuItemSchemaVS2015Blue.Name = "menuItemSchemaVS2015Blue";
            menuItemSchemaVS2015Blue.Size = new System.Drawing.Size(255, 22);
            menuItemSchemaVS2015Blue.Text = "Schema: VS2015 Blue";
            menuItemSchemaVS2015Blue.Click += new System.EventHandler(SetSchema);
            // 
            // menuItemSchemaVS2015Dark
            // 
            menuItemSchemaVS2015Dark.Name = "menuItemSchemaVS2015Dark";
            menuItemSchemaVS2015Dark.Size = new System.Drawing.Size(255, 22);
            menuItemSchemaVS2015Dark.Text = "Schema: VS2015 Dark";
            menuItemSchemaVS2015Dark.Click += new System.EventHandler(SetSchema);
            // 
            // menuItem6
            // 
            menuItem6.Name = "menuItem6";
            menuItem6.Size = new System.Drawing.Size(252, 6);
            // 
            // menuItemDockingMdi
            // 
            menuItemDockingMdi.Checked = true;
            menuItemDockingMdi.CheckState = System.Windows.Forms.CheckState.Checked;
            menuItemDockingMdi.Name = "menuItemDockingMdi";
            menuItemDockingMdi.Size = new System.Drawing.Size(255, 22);
            menuItemDockingMdi.Text = "Document Style: Docking &MDI";
            menuItemDockingMdi.Click += new System.EventHandler(SetDocumentStyle);
            // 
            // menuItemDockingSdi
            // 
            menuItemDockingSdi.Name = "menuItemDockingSdi";
            menuItemDockingSdi.Size = new System.Drawing.Size(255, 22);
            menuItemDockingSdi.Text = "Document Style: Docking &SDI";
            menuItemDockingSdi.Click += new System.EventHandler(SetDocumentStyle);
            // 
            // menuItemDockingWindow
            // 
            menuItemDockingWindow.Name = "menuItemDockingWindow";
            menuItemDockingWindow.Size = new System.Drawing.Size(255, 22);
            menuItemDockingWindow.Text = "Document Style: Docking &Window";
            menuItemDockingWindow.Click += new System.EventHandler(SetDocumentStyle);
            // 
            // menuItemSystemMdi
            // 
            menuItemSystemMdi.Name = "menuItemSystemMdi";
            menuItemSystemMdi.Size = new System.Drawing.Size(255, 22);
            menuItemSystemMdi.Text = "Document Style: S&ystem MDI";
            menuItemSystemMdi.Click += new System.EventHandler(SetDocumentStyle);
            // 
            // menuItem5
            // 
            menuItem5.Name = "menuItem5";
            menuItem5.Size = new System.Drawing.Size(252, 6);
            // 
            // showRightToLeft
            // 
            showRightToLeft.Name = "showRightToLeft";
            showRightToLeft.Size = new System.Drawing.Size(255, 22);
            showRightToLeft.Text = "Show &Right-To-Left";
            showRightToLeft.Click += new System.EventHandler(showRightToLeft_Click);
            // 
            // menuItemWindow
            // 
            menuItemWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            menuItemNewWindow});
            menuItemWindow.MergeIndex = 2;
            menuItemWindow.Name = "menuItemWindow";
            menuItemWindow.Size = new System.Drawing.Size(63, 20);
            menuItemWindow.Text = "&Window";
            // 
            // menuItemNewWindow
            // 
            menuItemNewWindow.Name = "menuItemNewWindow";
            menuItemNewWindow.Size = new System.Drawing.Size(145, 22);
            menuItemNewWindow.Text = "&New Window";
            menuItemNewWindow.Click += new System.EventHandler(menuItemNewWindow_Click);
            // 
            // menuItemHelp
            // 
            menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            menuItemAbout});
            menuItemHelp.MergeIndex = 3;
            menuItemHelp.Name = "menuItemHelp";
            menuItemHelp.Size = new System.Drawing.Size(44, 20);
            menuItemHelp.Text = "&Help";
            // 
            // menuItemAbout
            // 
            menuItemAbout.Name = "menuItemAbout";
            menuItemAbout.Size = new System.Drawing.Size(185, 22);
            menuItemAbout.Text = "&About DockSample...";
            menuItemAbout.Click += new System.EventHandler(menuItemAbout_Click);
            // 
            // statusBar
            // 
            statusBar.BackColor = System.Drawing.Color.Black;
            statusBar.Location = new System.Drawing.Point(0, 387);
            statusBar.Name = "statusBar";
            statusBar.Size = new System.Drawing.Size(579, 22);
            statusBar.TabIndex = 4;
            // 
            // imageList
            // 
            imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            imageList.TransparentColor = System.Drawing.Color.Transparent;
            imageList.Images.SetKeyName(0, "");
            imageList.Images.SetKeyName(1, "");
            imageList.Images.SetKeyName(2, "");
            imageList.Images.SetKeyName(3, "");
            imageList.Images.SetKeyName(4, "");
            imageList.Images.SetKeyName(5, "");
            imageList.Images.SetKeyName(6, "");
            imageList.Images.SetKeyName(7, "");
            imageList.Images.SetKeyName(8, "");
            // 
            // toolBar
            // 
            toolBar.ImageList = imageList;
            toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolBarButtonNew,
            toolBarButtonOpen,
            toolBarButtonSeparator1,
            toolBarButtonSolutionExplorer,
            toolBarButtonPropertyWindow,
            toolBarButtonToolbox,
            toolBarButtonOutputWindow,
            toolBarButtonTaskList,
            toolBarButtonSeparator2,
            toolBarButtonLayoutByCode,
            toolBarButtonLayoutByXml});
            toolBar.Location = new System.Drawing.Point(0, 24);
            toolBar.Name = "toolBar";
            toolBar.Size = new System.Drawing.Size(579, 25);
            toolBar.TabIndex = 6;
            toolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(toolBar_ButtonClick);
            // 
            // toolBarButtonNew
            // 
            toolBarButtonNew.ImageIndex = 0;
            toolBarButtonNew.Name = "toolBarButtonNew";
            toolBarButtonNew.Size = new System.Drawing.Size(23, 22);
            toolBarButtonNew.ToolTipText = "Show Layout From XML";
            // 
            // toolBarButtonOpen
            // 
            toolBarButtonOpen.ImageIndex = 1;
            toolBarButtonOpen.Name = "toolBarButtonOpen";
            toolBarButtonOpen.Size = new System.Drawing.Size(23, 22);
            toolBarButtonOpen.ToolTipText = "Open";
            // 
            // toolBarButtonSeparator1
            // 
            toolBarButtonSeparator1.Name = "toolBarButtonSeparator1";
            toolBarButtonSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBarButtonSolutionExplorer
            // 
            toolBarButtonSolutionExplorer.ImageIndex = 2;
            toolBarButtonSolutionExplorer.Name = "toolBarButtonSolutionExplorer";
            toolBarButtonSolutionExplorer.Size = new System.Drawing.Size(23, 22);
            toolBarButtonSolutionExplorer.ToolTipText = "Solution Explorer";
            // 
            // toolBarButtonPropertyWindow
            // 
            toolBarButtonPropertyWindow.ImageIndex = 3;
            toolBarButtonPropertyWindow.Name = "toolBarButtonPropertyWindow";
            toolBarButtonPropertyWindow.Size = new System.Drawing.Size(23, 22);
            toolBarButtonPropertyWindow.ToolTipText = "Property Window";
            // 
            // toolBarButtonToolbox
            // 
            toolBarButtonToolbox.ImageIndex = 4;
            toolBarButtonToolbox.Name = "toolBarButtonToolbox";
            toolBarButtonToolbox.Size = new System.Drawing.Size(23, 22);
            toolBarButtonToolbox.ToolTipText = "Tool Box";
            // 
            // toolBarButtonOutputWindow
            // 
            toolBarButtonOutputWindow.ImageIndex = 5;
            toolBarButtonOutputWindow.Name = "toolBarButtonOutputWindow";
            toolBarButtonOutputWindow.Size = new System.Drawing.Size(23, 22);
            toolBarButtonOutputWindow.ToolTipText = "Output Window";
            // 
            // toolBarButtonTaskList
            // 
            toolBarButtonTaskList.ImageIndex = 6;
            toolBarButtonTaskList.Name = "toolBarButtonTaskList";
            toolBarButtonTaskList.Size = new System.Drawing.Size(23, 22);
            toolBarButtonTaskList.ToolTipText = "Task List";
            // 
            // toolBarButtonSeparator2
            // 
            toolBarButtonSeparator2.Name = "toolBarButtonSeparator2";
            toolBarButtonSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBarButtonLayoutByCode
            // 
            toolBarButtonLayoutByCode.ImageIndex = 7;
            toolBarButtonLayoutByCode.Name = "toolBarButtonLayoutByCode";
            toolBarButtonLayoutByCode.Size = new System.Drawing.Size(23, 22);
            toolBarButtonLayoutByCode.ToolTipText = "Show Layout By Code";
            // 
            // toolBarButtonLayoutByXml
            // 
            toolBarButtonLayoutByXml.ImageIndex = 8;
            toolBarButtonLayoutByXml.Name = "toolBarButtonLayoutByXml";
            toolBarButtonLayoutByXml.Size = new System.Drawing.Size(23, 22);
            toolBarButtonLayoutByXml.ToolTipText = "Show layout by predefined XML file";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // subMenuToolStripMenuItem
            // 
            subMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            itemAToolStripMenuItem,
            itemBToolStripMenuItem});
            subMenuToolStripMenuItem.Name = "subMenuToolStripMenuItem";
            subMenuToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            subMenuToolStripMenuItem.Text = "Sub menu";
            // 
            // itemAToolStripMenuItem
            // 
            itemAToolStripMenuItem.Name = "itemAToolStripMenuItem";
            itemAToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            itemAToolStripMenuItem.Text = "Item A";
            // 
            // itemBToolStripMenuItem
            // 
            itemBToolStripMenuItem.Name = "itemBToolStripMenuItem";
            itemBToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            itemBToolStripMenuItem.Text = "Item B";
            // 
            // disabledItemToolStripMenuItem
            // 
            disabledItemToolStripMenuItem.Enabled = false;
            disabledItemToolStripMenuItem.Name = "disabledItemToolStripMenuItem";
            disabledItemToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            disabledItemToolStripMenuItem.Text = "Disabled Item";
            // 
            // dockPanel
            // 
            dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            dockPanel.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            dockPanel.DockBottomPortion = 150D;
            dockPanel.DockLeftPortion = 200D;
            dockPanel.DockRightPortion = 200D;
            dockPanel.DockTopPortion = 150D;
            dockPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            dockPanel.Location = new System.Drawing.Point(0, 49);
            dockPanel.Name = "dockPanel";
            dockPanel.Padding = new System.Windows.Forms.Padding(6);
            dockPanel.RightToLeftLayout = true;
            dockPanel.ShowAutoHideContentOnHover = false;
            dockPanel.Size = new System.Drawing.Size(579, 338);
            dockPanel.TabIndex = 0;
            //dockPanel.Theme = vS2013BlueTheme1;
            // 
            // vsToolStripExtender1
            // 
            vsToolStripExtender1.DefaultRenderer = null;
            // 
            // MainForm
            // 
            ClientSize = new System.Drawing.Size(579, 409);
            Controls.Add(dockPanel);
            Controls.Add(toolBar);
            Controls.Add(mainMenu);
            Controls.Add(statusBar);
            Icon = ((System.Drawing.Icon)(resources.GetObject("$Icon")));
            IsMdiContainer = true;
            MainMenuStrip = mainMenu;
            Name = "MainForm";
            Text = "DockSample";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Closing += new System.ComponentModel.CancelEventHandler(MainForm_Closing);
            Load += new System.EventHandler(MainForm_Load);
            SizeChanged += new System.EventHandler(MainForm_SizeChanged);
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            toolBar.ResumeLayout(false);
            toolBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
#endregion

        private WeifenLuo.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton toolBarButtonNew;
        private System.Windows.Forms.ToolStripButton toolBarButtonOpen;
        private System.Windows.Forms.ToolStripSeparator toolBarButtonSeparator1;
        private System.Windows.Forms.ToolStripButton toolBarButtonSolutionExplorer;
        private System.Windows.Forms.ToolStripButton toolBarButtonPropertyWindow;
        private System.Windows.Forms.ToolStripButton toolBarButtonToolbox;
        private System.Windows.Forms.ToolStripButton toolBarButtonOutputWindow;
        private System.Windows.Forms.ToolStripButton toolBarButtonTaskList;
        private System.Windows.Forms.ToolStripSeparator toolBarButtonSeparator2;
        private System.Windows.Forms.ToolStripButton toolBarButtonLayoutByCode;
        private System.Windows.Forms.ToolStripButton toolBarButtonLayoutByXml;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemNew;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseAllButThisOne;
        private System.Windows.Forms.ToolStripSeparator menuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemSolutionExplorer;
        private System.Windows.Forms.ToolStripMenuItem menuItemPropertyWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolbox;
        private System.Windows.Forms.ToolStripMenuItem menuItemOutputWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemTaskList;
        private System.Windows.Forms.ToolStripSeparator menuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemStatusBar;
        private System.Windows.Forms.ToolStripSeparator menuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutByCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutByXml;
        private System.Windows.Forms.ToolStripMenuItem menuItemTools;
        private System.Windows.Forms.ToolStripMenuItem menuItemLockLayout;
        private System.Windows.Forms.ToolStripSeparator menuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2005;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2003;
        private System.Windows.Forms.ToolStripSeparator menuItem6;
        private System.Windows.Forms.ToolStripMenuItem menuItemDockingMdi;
        private System.Windows.Forms.ToolStripMenuItem menuItemDockingSdi;
        private System.Windows.Forms.ToolStripMenuItem menuItemDockingWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemSystemMdi;
        private System.Windows.Forms.ToolStripSeparator menuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowDocumentIcon;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem showRightToLeft;
        private System.Windows.Forms.ToolStripMenuItem exitWithoutSavingLayout;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2015Light;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2015Blue;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2015Dark;
        private WeifenLuo.Docking.VisualStudioToolStripExtender vsToolStripExtender1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem subMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledItemToolStripMenuItem;
    }
}
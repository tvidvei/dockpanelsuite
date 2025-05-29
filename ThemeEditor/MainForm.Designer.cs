namespace ThemeEditor
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
            mainMenu = new MenuStrip();
            menuItemFile = new ToolStripMenuItem();
            menuItemNew = new ToolStripMenuItem();
            menuItemOpen = new ToolStripMenuItem();
            menuItemClose = new ToolStripMenuItem();
            menuItemCloseAll = new ToolStripMenuItem();
            menuItemCloseAllButThisOne = new ToolStripMenuItem();
            menuItem4 = new ToolStripSeparator();
            menuItemExit = new ToolStripMenuItem();
            exitWithoutSavingLayout = new ToolStripMenuItem();
            menuItemView = new ToolStripMenuItem();
            menuItemSolutionExplorer = new ToolStripMenuItem();
            menuItemPropertyWindow = new ToolStripMenuItem();
            menuItemThemeEditorWindow = new ToolStripMenuItem();
            menuItemToolbox = new ToolStripMenuItem();
            menuItemOutputWindow = new ToolStripMenuItem();
            menuItemTaskList = new ToolStripMenuItem();
            menuItem1 = new ToolStripSeparator();
            menuItemToolBar = new ToolStripMenuItem();
            menuItemStatusBar = new ToolStripMenuItem();
            menuItem2 = new ToolStripSeparator();
            menuItemLayoutByCode = new ToolStripMenuItem();
            menuItemLayoutByXml = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            subMenuToolStripMenuItem = new ToolStripMenuItem();
            itemAToolStripMenuItem = new ToolStripMenuItem();
            itemBToolStripMenuItem = new ToolStripMenuItem();
            disabledItemToolStripMenuItem = new ToolStripMenuItem();
            menuItemTools = new ToolStripMenuItem();
            menuItemLockLayout = new ToolStripMenuItem();
            menuItemShowDocumentIcon = new ToolStripMenuItem();
            menuItem3 = new ToolStripSeparator();
            themesToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            opToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            useThemeToolStripMenuItem = new ToolStripMenuItem();
            menuItemSchemaVS2015Light = new ToolStripMenuItem();
            menuItemSchemaVS2015Blue = new ToolStripMenuItem();
            menuItemSchemaVS2015Dark = new ToolStripMenuItem();
            menuItem6 = new ToolStripSeparator();
            menuItemDockingMdi = new ToolStripMenuItem();
            menuItemDockingSdi = new ToolStripMenuItem();
            menuItemDockingWindow = new ToolStripMenuItem();
            menuItemSystemMdi = new ToolStripMenuItem();
            menuItem5 = new ToolStripSeparator();
            showRightToLeft = new ToolStripMenuItem();
            menuItemWindow = new ToolStripMenuItem();
            menuItemNewWindow = new ToolStripMenuItem();
            menuItemHelp = new ToolStripMenuItem();
            menuItemAbout = new ToolStripMenuItem();
            statusBar = new StatusStrip();
            imageList = new ImageList(components);
            toolBar = new ToolStrip();
            toolBarButtonNew = new ToolStripButton();
            toolBarButtonOpen = new ToolStripButton();
            toolBarButtonSeparator1 = new ToolStripSeparator();
            toolBarButtonSolutionExplorer = new ToolStripButton();
            toolBarButtonPropertyWindow = new ToolStripButton();
            toolBarButtonToolbox = new ToolStripButton();
            toolBarButtonOutputWindow = new ToolStripButton();
            toolBarButtonTaskList = new ToolStripButton();
            toolBarButtonSeparator2 = new ToolStripSeparator();
            toolBarButtonLayoutByCode = new ToolStripButton();
            toolBarButtonLayoutByXml = new ToolStripButton();
            mainMenu.SuspendLayout();
            toolBar.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new ToolStripItem[] { menuItemFile, menuItemView, menuItemTools, menuItemWindow, menuItemHelp });
            mainMenu.Location = new Point(0, 0);
            mainMenu.MdiWindowListItem = menuItemWindow;
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(579, 24);
            mainMenu.TabIndex = 7;
            // 
            // menuItemFile
            // 
            menuItemFile.DropDownItems.AddRange(new ToolStripItem[] { menuItemNew, menuItemOpen, menuItemClose, menuItemCloseAll, menuItemCloseAllButThisOne, menuItem4, menuItemExit, exitWithoutSavingLayout });
            menuItemFile.Name = "menuItemFile";
            menuItemFile.Size = new Size(37, 20);
            menuItemFile.Text = "&File";
            menuItemFile.DropDownOpening += menuItemFile_Popup;
            // 
            // menuItemNew
            // 
            menuItemNew.Name = "menuItemNew";
            menuItemNew.ShortcutKeys = Keys.Control | Keys.N;
            menuItemNew.Size = new Size(215, 22);
            menuItemNew.Text = "&New";
            menuItemNew.Click += menuItemNew_Click;
            // 
            // menuItemOpen
            // 
            menuItemOpen.Name = "menuItemOpen";
            menuItemOpen.ShortcutKeys = Keys.Control | Keys.O;
            menuItemOpen.Size = new Size(215, 22);
            menuItemOpen.Text = "&Open...";
            menuItemOpen.Click += menuItemOpen_Click;
            // 
            // menuItemClose
            // 
            menuItemClose.Name = "menuItemClose";
            menuItemClose.ShortcutKeys = Keys.Control | Keys.W;
            menuItemClose.Size = new Size(215, 22);
            menuItemClose.Text = "&Close";
            menuItemClose.Click += menuItemClose_Click;
            // 
            // menuItemCloseAll
            // 
            menuItemCloseAll.Name = "menuItemCloseAll";
            menuItemCloseAll.Size = new Size(215, 22);
            menuItemCloseAll.Text = "Close &All";
            menuItemCloseAll.Click += menuItemCloseAll_Click;
            // 
            // menuItemCloseAllButThisOne
            // 
            menuItemCloseAllButThisOne.Name = "menuItemCloseAllButThisOne";
            menuItemCloseAllButThisOne.Size = new Size(215, 22);
            menuItemCloseAllButThisOne.Text = "Close All &But This One";
            menuItemCloseAllButThisOne.Click += menuItemCloseAllButThisOne_Click;
            // 
            // menuItem4
            // 
            menuItem4.Name = "menuItem4";
            menuItem4.Size = new Size(212, 6);
            // 
            // menuItemExit
            // 
            menuItemExit.Name = "menuItemExit";
            menuItemExit.ShortcutKeys = Keys.Alt | Keys.F4;
            menuItemExit.Size = new Size(215, 22);
            menuItemExit.Text = "&Exit";
            menuItemExit.Click += menuItemExit_Click;
            // 
            // exitWithoutSavingLayout
            // 
            exitWithoutSavingLayout.Name = "exitWithoutSavingLayout";
            exitWithoutSavingLayout.Size = new Size(215, 22);
            exitWithoutSavingLayout.Text = "Exit &Without Saving Layout";
            exitWithoutSavingLayout.Click += exitWithoutSavingLayout_Click;
            // 
            // menuItemView
            // 
            menuItemView.DropDownItems.AddRange(new ToolStripItem[] { menuItemSolutionExplorer, menuItemPropertyWindow, menuItemThemeEditorWindow, menuItemToolbox, menuItemOutputWindow, menuItemTaskList, menuItem1, menuItemToolBar, menuItemStatusBar, menuItem2, menuItemLayoutByCode, menuItemLayoutByXml, toolStripSeparator1, subMenuToolStripMenuItem, disabledItemToolStripMenuItem });
            menuItemView.MergeIndex = 1;
            menuItemView.Name = "menuItemView";
            menuItemView.Size = new Size(44, 20);
            menuItemView.Text = "&View";
            // 
            // menuItemSolutionExplorer
            // 
            menuItemSolutionExplorer.Name = "menuItemSolutionExplorer";
            menuItemSolutionExplorer.Size = new Size(243, 22);
            menuItemSolutionExplorer.Text = "&Solution Explorer";
            menuItemSolutionExplorer.Click += menuItemSolutionExplorer_Click;
            // 
            // menuItemPropertyWindow
            // 
            menuItemPropertyWindow.Name = "menuItemPropertyWindow";
            menuItemPropertyWindow.ShortcutKeys = Keys.F4;
            menuItemPropertyWindow.Size = new Size(243, 22);
            menuItemPropertyWindow.Text = "&Property Window";
            menuItemPropertyWindow.Click += menuItemPropertyWindow_Click;
            // 
            // menuItemThemeEditorWindow
            // 
            menuItemThemeEditorWindow.Name = "menuItemThemeEditorWindow";
            menuItemThemeEditorWindow.ShortcutKeys = Keys.Shift | Keys.F4;
            menuItemThemeEditorWindow.Size = new Size(243, 22);
            menuItemThemeEditorWindow.Text = "Theme &Editor Window";
            menuItemThemeEditorWindow.Click += menuItemThemeEditorWindow_Click;
            // 
            // menuItemToolbox
            // 
            menuItemToolbox.Name = "menuItemToolbox";
            menuItemToolbox.Size = new Size(243, 22);
            menuItemToolbox.Text = "&Toolbox";
            menuItemToolbox.Click += menuItemToolbox_Click;
            // 
            // menuItemOutputWindow
            // 
            menuItemOutputWindow.Name = "menuItemOutputWindow";
            menuItemOutputWindow.Size = new Size(243, 22);
            menuItemOutputWindow.Text = "&Output Window";
            menuItemOutputWindow.Click += menuItemOutputWindow_Click;
            // 
            // menuItemTaskList
            // 
            menuItemTaskList.Name = "menuItemTaskList";
            menuItemTaskList.Size = new Size(243, 22);
            menuItemTaskList.Text = "Task &List";
            menuItemTaskList.Click += menuItemTaskList_Click;
            // 
            // menuItem1
            // 
            menuItem1.Name = "menuItem1";
            menuItem1.Size = new Size(240, 6);
            // 
            // menuItemToolBar
            // 
            menuItemToolBar.Checked = true;
            menuItemToolBar.CheckState = CheckState.Checked;
            menuItemToolBar.Name = "menuItemToolBar";
            menuItemToolBar.Size = new Size(243, 22);
            menuItemToolBar.Text = "Tool &Bar";
            menuItemToolBar.Click += menuItemToolBar_Click;
            // 
            // menuItemStatusBar
            // 
            menuItemStatusBar.Checked = true;
            menuItemStatusBar.CheckState = CheckState.Checked;
            menuItemStatusBar.Name = "menuItemStatusBar";
            menuItemStatusBar.Size = new Size(243, 22);
            menuItemStatusBar.Text = "Status B&ar";
            menuItemStatusBar.Click += menuItemStatusBar_Click;
            // 
            // menuItem2
            // 
            menuItem2.Name = "menuItem2";
            menuItem2.Size = new Size(240, 6);
            // 
            // menuItemLayoutByCode
            // 
            menuItemLayoutByCode.Name = "menuItemLayoutByCode";
            menuItemLayoutByCode.Size = new Size(243, 22);
            menuItemLayoutByCode.Text = "Layout By &Code";
            menuItemLayoutByCode.Click += menuItemLayoutByCode_Click;
            // 
            // menuItemLayoutByXml
            // 
            menuItemLayoutByXml.Name = "menuItemLayoutByXml";
            menuItemLayoutByXml.Size = new Size(243, 22);
            menuItemLayoutByXml.Text = "Layout By &XML";
            menuItemLayoutByXml.Click += menuItemLayoutByXml_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(240, 6);
            // 
            // subMenuToolStripMenuItem
            // 
            subMenuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { itemAToolStripMenuItem, itemBToolStripMenuItem });
            subMenuToolStripMenuItem.Name = "subMenuToolStripMenuItem";
            subMenuToolStripMenuItem.Size = new Size(243, 22);
            subMenuToolStripMenuItem.Text = "Sub menu";
            // 
            // itemAToolStripMenuItem
            // 
            itemAToolStripMenuItem.Name = "itemAToolStripMenuItem";
            itemAToolStripMenuItem.Size = new Size(109, 22);
            itemAToolStripMenuItem.Text = "Item A";
            // 
            // itemBToolStripMenuItem
            // 
            itemBToolStripMenuItem.Name = "itemBToolStripMenuItem";
            itemBToolStripMenuItem.Size = new Size(109, 22);
            itemBToolStripMenuItem.Text = "Item B";
            // 
            // disabledItemToolStripMenuItem
            // 
            disabledItemToolStripMenuItem.Enabled = false;
            disabledItemToolStripMenuItem.Name = "disabledItemToolStripMenuItem";
            disabledItemToolStripMenuItem.Size = new Size(243, 22);
            disabledItemToolStripMenuItem.Text = "Disabled Item";
            // 
            // menuItemTools
            // 
            menuItemTools.DropDownItems.AddRange(new ToolStripItem[] { menuItemLockLayout, menuItemShowDocumentIcon, menuItem3, themesToolStripMenuItem, menuItemSchemaVS2015Light, menuItemSchemaVS2015Blue, menuItemSchemaVS2015Dark, menuItem6, menuItemDockingMdi, menuItemDockingSdi, menuItemDockingWindow, menuItemSystemMdi, menuItem5, showRightToLeft });
            menuItemTools.MergeIndex = 2;
            menuItemTools.Name = "menuItemTools";
            menuItemTools.Size = new Size(47, 20);
            menuItemTools.Text = "&Tools";
            menuItemTools.DropDownOpening += menuItemTools_Popup;
            // 
            // menuItemLockLayout
            // 
            menuItemLockLayout.Name = "menuItemLockLayout";
            menuItemLockLayout.Size = new Size(255, 22);
            menuItemLockLayout.Text = "&Lock Layout";
            menuItemLockLayout.Click += menuItemLockLayout_Click;
            // 
            // menuItemShowDocumentIcon
            // 
            menuItemShowDocumentIcon.Name = "menuItemShowDocumentIcon";
            menuItemShowDocumentIcon.Size = new Size(255, 22);
            menuItemShowDocumentIcon.Text = "&Show Document Icon";
            menuItemShowDocumentIcon.Click += menuItemShowDocumentIcon_Click;
            // 
            // menuItem3
            // 
            menuItem3.Name = "menuItem3";
            menuItem3.Size = new Size(252, 6);
            // 
            // themesToolStripMenuItem
            // 
            themesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, opToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, useThemeToolStripMenuItem });
            themesToolStripMenuItem.Name = "themesToolStripMenuItem";
            themesToolStripMenuItem.Size = new Size(255, 22);
            themesToolStripMenuItem.Text = "&Theme";
            themesToolStripMenuItem.Click += themesToolStripMenuItem_Click;
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "&New";
            newToolStripMenuItem.Click += cmdThemeNew_Click;
            // 
            // opToolStripMenuItem
            // 
            opToolStripMenuItem.Name = "opToolStripMenuItem";
            opToolStripMenuItem.Size = new Size(180, 22);
            opToolStripMenuItem.Text = "Open &Current";
            opToolStripMenuItem.Click += cmdThemeOpenCurrent_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "&Open...";
            openToolStripMenuItem.Click += cmdThemeOpen_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "&Save";
            saveToolStripMenuItem.Click += cmdThemeSave_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save &As...";
            saveAsToolStripMenuItem.Click += cmdThemeSaveAs_Click;
            // 
            // useThemeToolStripMenuItem
            // 
            useThemeToolStripMenuItem.Name = "useThemeToolStripMenuItem";
            useThemeToolStripMenuItem.Size = new Size(180, 22);
            useThemeToolStripMenuItem.Text = "Use &Theme...";
            useThemeToolStripMenuItem.Click += cmdThemeUseTheme_Click;
            // 
            // menuItemSchemaVS2015Light
            // 
            menuItemSchemaVS2015Light.Name = "menuItemSchemaVS2015Light";
            menuItemSchemaVS2015Light.Size = new Size(255, 22);
            menuItemSchemaVS2015Light.Text = "Schema: VS2015 Light";
            menuItemSchemaVS2015Light.Click += SetSchema;
            // 
            // menuItemSchemaVS2015Blue
            // 
            menuItemSchemaVS2015Blue.Name = "menuItemSchemaVS2015Blue";
            menuItemSchemaVS2015Blue.Size = new Size(255, 22);
            menuItemSchemaVS2015Blue.Text = "Schema: VS2015 Blue";
            menuItemSchemaVS2015Blue.Click += SetSchema;
            // 
            // menuItemSchemaVS2015Dark
            // 
            menuItemSchemaVS2015Dark.Name = "menuItemSchemaVS2015Dark";
            menuItemSchemaVS2015Dark.Size = new Size(255, 22);
            menuItemSchemaVS2015Dark.Text = "Schema: VS2015 Dark";
            menuItemSchemaVS2015Dark.Click += SetSchema;
            // 
            // menuItem6
            // 
            menuItem6.Name = "menuItem6";
            menuItem6.Size = new Size(252, 6);
            // 
            // menuItemDockingMdi
            // 
            menuItemDockingMdi.Checked = true;
            menuItemDockingMdi.CheckState = CheckState.Checked;
            menuItemDockingMdi.Name = "menuItemDockingMdi";
            menuItemDockingMdi.Size = new Size(255, 22);
            menuItemDockingMdi.Text = "Document Style: Docking &MDI";
            menuItemDockingMdi.Click += SetDocumentStyle;
            // 
            // menuItemDockingSdi
            // 
            menuItemDockingSdi.Name = "menuItemDockingSdi";
            menuItemDockingSdi.Size = new Size(255, 22);
            menuItemDockingSdi.Text = "Document Style: Docking &SDI";
            menuItemDockingSdi.Click += SetDocumentStyle;
            // 
            // menuItemDockingWindow
            // 
            menuItemDockingWindow.Name = "menuItemDockingWindow";
            menuItemDockingWindow.Size = new Size(255, 22);
            menuItemDockingWindow.Text = "Document Style: Docking &Window";
            menuItemDockingWindow.Click += SetDocumentStyle;
            // 
            // menuItemSystemMdi
            // 
            menuItemSystemMdi.Name = "menuItemSystemMdi";
            menuItemSystemMdi.Size = new Size(255, 22);
            menuItemSystemMdi.Text = "Document Style: S&ystem MDI";
            menuItemSystemMdi.Click += SetDocumentStyle;
            // 
            // menuItem5
            // 
            menuItem5.Name = "menuItem5";
            menuItem5.Size = new Size(252, 6);
            // 
            // showRightToLeft
            // 
            showRightToLeft.Name = "showRightToLeft";
            showRightToLeft.Size = new Size(255, 22);
            showRightToLeft.Text = "Show &Right-To-Left";
            showRightToLeft.Click += showRightToLeft_Click;
            // 
            // menuItemWindow
            // 
            menuItemWindow.DropDownItems.AddRange(new ToolStripItem[] { menuItemNewWindow });
            menuItemWindow.MergeIndex = 2;
            menuItemWindow.Name = "menuItemWindow";
            menuItemWindow.Size = new Size(63, 20);
            menuItemWindow.Text = "&Window";
            // 
            // menuItemNewWindow
            // 
            menuItemNewWindow.Name = "menuItemNewWindow";
            menuItemNewWindow.Size = new Size(145, 22);
            menuItemNewWindow.Text = "&New Window";
            menuItemNewWindow.Click += menuItemNewWindow_Click;
            // 
            // menuItemHelp
            // 
            menuItemHelp.DropDownItems.AddRange(new ToolStripItem[] { menuItemAbout });
            menuItemHelp.MergeIndex = 3;
            menuItemHelp.Name = "menuItemHelp";
            menuItemHelp.Size = new Size(44, 20);
            menuItemHelp.Text = "&Help";
            // 
            // menuItemAbout
            // 
            menuItemAbout.Name = "menuItemAbout";
            menuItemAbout.Size = new Size(187, 22);
            menuItemAbout.Text = "&About ThemeEditor...";
            menuItemAbout.Click += menuItemAbout_Click;
            // 
            // statusBar
            // 
            statusBar.BackColor = Color.Black;
            statusBar.Location = new Point(0, 387);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(579, 22);
            statusBar.TabIndex = 4;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth8Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
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
            toolBar.Items.AddRange(new ToolStripItem[] { toolBarButtonNew, toolBarButtonOpen, toolBarButtonSeparator1, toolBarButtonSolutionExplorer, toolBarButtonPropertyWindow, toolBarButtonToolbox, toolBarButtonOutputWindow, toolBarButtonTaskList, toolBarButtonSeparator2, toolBarButtonLayoutByCode, toolBarButtonLayoutByXml });
            toolBar.Location = new Point(0, 24);
            toolBar.Name = "toolBar";
            toolBar.Size = new Size(579, 25);
            toolBar.TabIndex = 6;
            toolBar.ItemClicked += toolBar_ButtonClick;
            // 
            // toolBarButtonNew
            // 
            toolBarButtonNew.ImageIndex = 0;
            toolBarButtonNew.Name = "toolBarButtonNew";
            toolBarButtonNew.Size = new Size(23, 22);
            toolBarButtonNew.ToolTipText = "Show Layout From XML";
            // 
            // toolBarButtonOpen
            // 
            toolBarButtonOpen.ImageIndex = 1;
            toolBarButtonOpen.Name = "toolBarButtonOpen";
            toolBarButtonOpen.Size = new Size(23, 22);
            toolBarButtonOpen.ToolTipText = "Open";
            // 
            // toolBarButtonSeparator1
            // 
            toolBarButtonSeparator1.Name = "toolBarButtonSeparator1";
            toolBarButtonSeparator1.Size = new Size(6, 25);
            // 
            // toolBarButtonSolutionExplorer
            // 
            toolBarButtonSolutionExplorer.ImageIndex = 2;
            toolBarButtonSolutionExplorer.Name = "toolBarButtonSolutionExplorer";
            toolBarButtonSolutionExplorer.Size = new Size(23, 22);
            toolBarButtonSolutionExplorer.ToolTipText = "Solution Explorer";
            // 
            // toolBarButtonPropertyWindow
            // 
            toolBarButtonPropertyWindow.ImageIndex = 3;
            toolBarButtonPropertyWindow.Name = "toolBarButtonPropertyWindow";
            toolBarButtonPropertyWindow.Size = new Size(23, 22);
            toolBarButtonPropertyWindow.ToolTipText = "Property Window";
            // 
            // toolBarButtonToolbox
            // 
            toolBarButtonToolbox.ImageIndex = 4;
            toolBarButtonToolbox.Name = "toolBarButtonToolbox";
            toolBarButtonToolbox.Size = new Size(23, 22);
            toolBarButtonToolbox.ToolTipText = "Tool Box";
            // 
            // toolBarButtonOutputWindow
            // 
            toolBarButtonOutputWindow.ImageIndex = 5;
            toolBarButtonOutputWindow.Name = "toolBarButtonOutputWindow";
            toolBarButtonOutputWindow.Size = new Size(23, 22);
            toolBarButtonOutputWindow.ToolTipText = "Output Window";
            // 
            // toolBarButtonTaskList
            // 
            toolBarButtonTaskList.ImageIndex = 6;
            toolBarButtonTaskList.Name = "toolBarButtonTaskList";
            toolBarButtonTaskList.Size = new Size(23, 22);
            toolBarButtonTaskList.ToolTipText = "Task List";
            // 
            // toolBarButtonSeparator2
            // 
            toolBarButtonSeparator2.Name = "toolBarButtonSeparator2";
            toolBarButtonSeparator2.Size = new Size(6, 25);
            // 
            // toolBarButtonLayoutByCode
            // 
            toolBarButtonLayoutByCode.ImageIndex = 7;
            toolBarButtonLayoutByCode.Name = "toolBarButtonLayoutByCode";
            toolBarButtonLayoutByCode.Size = new Size(23, 22);
            toolBarButtonLayoutByCode.ToolTipText = "Show Layout By Code";
            // 
            // toolBarButtonLayoutByXml
            // 
            toolBarButtonLayoutByXml.ImageIndex = 8;
            toolBarButtonLayoutByXml.Name = "toolBarButtonLayoutByXml";
            toolBarButtonLayoutByXml.Size = new Size(23, 22);
            toolBarButtonLayoutByXml.ToolTipText = "Show layout by predefined XML file";
            // 
            // MainForm
            // 
            ClientSize = new Size(579, 409);
            Controls.Add(toolBar);
            Controls.Add(mainMenu);
            Controls.Add(statusBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = mainMenu;
            Name = "MainForm";
            Text = "ThemeEditor";
            WindowState = FormWindowState.Maximized;
            Closing += MainForm_Closing;
            Load += MainForm_Load;
            SizeChanged += MainForm_SizeChanged;
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            toolBar.ResumeLayout(false);
            toolBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

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
        private System.Windows.Forms.ToolStripMenuItem menuItemThemeEditorWindow;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem subMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledItemToolStripMenuItem;
        private ToolStripMenuItem themesToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem opToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem useThemeToolStripMenuItem;
    }
}
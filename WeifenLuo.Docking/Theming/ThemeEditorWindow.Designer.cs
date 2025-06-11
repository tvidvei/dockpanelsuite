using System.Windows.Forms;

namespace WeifenLuo.Docking
{
    partial class ThemeEditorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemeEditorWindow));
            propertyGrid = new PropertyGrid();
            miThemeUse = new ToolStripMenuItem();
            miThemeReset = new ToolStripMenuItem();
            miThemeSave = new ToolStripMenuItem();
            miThemeSaveAs = new ToolStripMenuItem();
            miThemeUndo = new ToolStripMenuItem();
            miThemeRedo = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // propertyGrid
            // 
            propertyGrid.BackColor = SystemColors.Control;
            propertyGrid.Dock = DockStyle.Fill;
            propertyGrid.LineColor = Color.FromArgb(240, 240, 240);
            propertyGrid.Location = new Point(0, 3);
            propertyGrid.Name = "propertyGrid";
            propertyGrid.Size = new Size(208, 283);
            propertyGrid.TabIndex = 0;
            propertyGrid.PropertyValueChanged += PropertyGrid_PropertyValueChanged;
            // 
            // miThemeUse
            // 
            miThemeUse.Name = "miThemeUse";
            miThemeUse.Size = new Size(180, 22);
            miThemeUse.Text = "Use this &Theme";
            miThemeUse.Click += miThemeUseThis_Click;
            // 
            // miThemeReset
            // 
            miThemeReset.Name = "miThemeReset";
            miThemeReset.Size = new Size(180, 22);
            miThemeReset.Text = "&Reset";
            miThemeReset.Click += miThemeReset_Click;
            // 
            // miThemeSave
            // 
            miThemeSave.Name = "miThemeSave";
            miThemeSave.Size = new Size(180, 22);
            miThemeSave.Text = "&Save";
            miThemeSave.Click += miThemeSave_Click;
            // 
            // miThemeSaveAs
            // 
            miThemeSaveAs.Name = "miThemeSaveAs";
            miThemeSaveAs.Size = new Size(180, 22);
            miThemeSaveAs.Text = "Save &As...";
            miThemeSaveAs.Click += miThemeSaveAs_Click;
            // 
            // miThemeUndo
            // 
            miThemeUndo.Name = "miThemeUndo";
            miThemeUndo.Size = new Size(180, 22);
            miThemeUndo.Text = "&Undo";
            miThemeUndo.Click += miThemeUndo_Click;
            // 
            // miThemeRedo
            // 
            miThemeRedo.Name = "miThemeRedo";
            miThemeRedo.Size = new Size(180, 22);
            miThemeRedo.Text = "Re&do";
            miThemeRedo.Click += miThemeRedo_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { miThemeUse, miThemeReset, miThemeSave, miThemeSaveAs, miThemeUndo, miThemeRedo });
            contextMenuStrip1.Name = "cmenuThemeEditor";
            contextMenuStrip1.Size = new Size(181, 114);
            // 
            // ThemeEditorWindow
            // 
            ClientSize = new Size(208, 289);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(propertyGrid);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ThemeEditorWindow";
            Padding = new Padding(0, 3, 0, 3);
            ShowHint = DockState.DockRight;
            TabPageContextMenuStrip = contextMenuStrip1;
            TabText = "Theme1";
            Text = "Theme Editor";
            FormClosing += ThemeEditorWindow_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid;
        // public ContextMenuStrip ContextMenuStrip;
        private ToolStripMenuItem miThemeUse;
        private ToolStripMenuItem miThemeReset;
        private ToolStripMenuItem miThemeSave;
        private ToolStripMenuItem miThemeSaveAs;
        private ToolStripMenuItem miThemeUndo;
        private ToolStripMenuItem miThemeRedo;
        private ContextMenuStrip contextMenuStrip1;
    }
}
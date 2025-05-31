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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemeEditorWindow));
            propertyGrid = new PropertyGrid();
            SuspendLayout();
            // 
            // propertyGrid
            // 
            propertyGrid.BackColor = SystemColors.Control;
            propertyGrid.Dock = DockStyle.Fill;
            propertyGrid.LineColor = SystemColors.ScrollBar;
            propertyGrid.Location = new Point(0, 3);
            propertyGrid.Name = "propertyGrid";
            propertyGrid.Size = new Size(208, 283);
            propertyGrid.TabIndex = 0;
            // 
            // ThemeEditorWindow
            // 
            ClientSize = new Size(208, 289);
            Controls.Add(propertyGrid);
            HideOnClose = false;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ThemeEditorWindow";
            Padding = new Padding(0, 3, 0, 3);
            ShowHint = DockState.DockRight;
            TabText = "Theme1";
            Text = "Theme Editor";
            FormClosing += ThemeEditorWindow_FormClosing;
            ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid;
    }
}
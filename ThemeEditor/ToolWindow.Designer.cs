namespace ThemeEditor
{
    partial class ToolWindow
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
            contextMenuStrip1 = new ContextMenuStrip(components);
            option1ToolStripMenuItem = new ToolStripMenuItem();
            option2ToolStripMenuItem = new ToolStripMenuItem();
            option3ToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { option1ToolStripMenuItem, option2ToolStripMenuItem, option3ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(118, 70);
            // 
            // option1ToolStripMenuItem
            // 
            option1ToolStripMenuItem.Name = "option1ToolStripMenuItem";
            option1ToolStripMenuItem.Size = new Size(117, 22);
            option1ToolStripMenuItem.Text = "Option&1";
            // 
            // option2ToolStripMenuItem
            // 
            option2ToolStripMenuItem.Name = "option2ToolStripMenuItem";
            option2ToolStripMenuItem.Size = new Size(117, 22);
            option2ToolStripMenuItem.Text = "Option&2";
            // 
            // option3ToolStripMenuItem
            // 
            option3ToolStripMenuItem.Name = "option3ToolStripMenuItem";
            option3ToolStripMenuItem.Size = new Size(117, 22);
            option3ToolStripMenuItem.Text = "Option&3";
            // 
            // ToolWindow
            // 
            ClientSize = new Size(292, 266);
            DockAreas = WeifenLuo.Docking.DockAreas.Float | WeifenLuo.Docking.DockAreas.DockLeft | WeifenLuo.Docking.DockAreas.DockRight | WeifenLuo.Docking.DockAreas.DockTop | WeifenLuo.Docking.DockAreas.DockBottom;
            Name = "ToolWindow";
            TabPageContextMenuStrip = contextMenuStrip1;
            TabText = "ToolWindow";
            Text = "ToolWindow";
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem option1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem option2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem option3ToolStripMenuItem;
    }
}
namespace Xtream_ToolBox.Sensors {
    partial class SensorQuickLauncher {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.quickLaunchFlowLayoutPanelDown = new System.Windows.Forms.FlowLayoutPanel();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.quickLaunchFlowLayoutPanelUp = new System.Windows.Forms.FlowLayoutPanel();
            this.shortcutContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSeparatorAfterThisItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moveShortcutPictureBox = new System.Windows.Forms.PictureBox();
            this.shortcutContextMenu.SuspendLayout();
            this.separatorContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveShortcutPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // quickLaunchFlowLayoutPanelDown
            // 
            this.quickLaunchFlowLayoutPanelDown.AllowDrop = true;
            this.quickLaunchFlowLayoutPanelDown.AutoSize = true;
            this.quickLaunchFlowLayoutPanelDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.quickLaunchFlowLayoutPanelDown.Location = new System.Drawing.Point(0, 23);
            this.quickLaunchFlowLayoutPanelDown.Margin = new System.Windows.Forms.Padding(0);
            this.quickLaunchFlowLayoutPanelDown.MaximumSize = new System.Drawing.Size(0, 24);
            this.quickLaunchFlowLayoutPanelDown.MinimumSize = new System.Drawing.Size(48, 24);
            this.quickLaunchFlowLayoutPanelDown.Name = "quickLaunchFlowLayoutPanelDown";
            this.quickLaunchFlowLayoutPanelDown.Size = new System.Drawing.Size(48, 24);
            this.quickLaunchFlowLayoutPanelDown.TabIndex = 1;
            this.quickLaunchFlowLayoutPanelDown.WrapContents = false;
            this.quickLaunchFlowLayoutPanelDown.DragDrop += new System.Windows.Forms.DragEventHandler(this.QuickLaunchFlowLayoutPanelDown_DragDrop);
            this.quickLaunchFlowLayoutPanelDown.DragEnter += new System.Windows.Forms.DragEventHandler(this.QuickLaunchFlowLayoutPanelUp_DragEnter);
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 60000;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // quickLaunchFlowLayoutPanelUp
            // 
            this.quickLaunchFlowLayoutPanelUp.AllowDrop = true;
            this.quickLaunchFlowLayoutPanelUp.AutoSize = true;
            this.quickLaunchFlowLayoutPanelUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.quickLaunchFlowLayoutPanelUp.Location = new System.Drawing.Point(0, 0);
            this.quickLaunchFlowLayoutPanelUp.Margin = new System.Windows.Forms.Padding(0);
            this.quickLaunchFlowLayoutPanelUp.MaximumSize = new System.Drawing.Size(0, 48);
            this.quickLaunchFlowLayoutPanelUp.MinimumSize = new System.Drawing.Size(48, 24);
            this.quickLaunchFlowLayoutPanelUp.Name = "quickLaunchFlowLayoutPanelUp";
            this.quickLaunchFlowLayoutPanelUp.Size = new System.Drawing.Size(48, 24);
            this.quickLaunchFlowLayoutPanelUp.TabIndex = 2;
            this.quickLaunchFlowLayoutPanelUp.WrapContents = false;
            this.quickLaunchFlowLayoutPanelUp.DragDrop += new System.Windows.Forms.DragEventHandler(this.QuickLaunchFlowLayoutPanelDown_DragDrop);
            this.quickLaunchFlowLayoutPanelUp.DragEnter += new System.Windows.Forms.DragEventHandler(this.QuickLaunchFlowLayoutPanelUp_DragEnter);
            // 
            // shortcutContextMenu
            // 
            this.shortcutContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem,
            this.addSeparatorAfterThisItemToolStripMenuItem,
            this.toolStripSeparator1,
            this.removeToolStripMenuItem});
            this.shortcutContextMenu.Name = "contextMenuStrip1";
            this.shortcutContextMenu.ShowItemToolTips = false;
            this.shortcutContextMenu.Size = new System.Drawing.Size(243, 76);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.properties;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.propertiesToolStripMenuItem.Text = "View or change item\'s properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
            // 
            // addSeparatorAfterThisItemToolStripMenuItem
            // 
            this.addSeparatorAfterThisItemToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.add_16;
            this.addSeparatorAfterThisItemToolStripMenuItem.Name = "addSeparatorAfterThisItemToolStripMenuItem";
            this.addSeparatorAfterThisItemToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.addSeparatorAfterThisItemToolStripMenuItem.Text = "Insert separator before this item";
            this.addSeparatorAfterThisItemToolStripMenuItem.Click += new System.EventHandler(this.AddSeparatorBeforeThisItemToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(239, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.trash_16;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.removeToolStripMenuItem.Text = "Remove this item";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // separatorContextMenu
            // 
            this.separatorContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.separatorContextMenu.Name = "contextMenuStrip1";
            this.separatorContextMenu.ShowItemToolTips = false;
            this.separatorContextMenu.Size = new System.Drawing.Size(195, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::Xtream_ToolBox.Properties.Resources.trash_16;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem1.Text = "Remove this separator";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // moveShortcutPictureBox
            // 
            this.moveShortcutPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.moveShortcutPictureBox.Location = new System.Drawing.Point(0, 0);
            this.moveShortcutPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.moveShortcutPictureBox.Name = "moveShortcutPictureBox";
            this.moveShortcutPictureBox.Size = new System.Drawing.Size(25, 24);
            this.moveShortcutPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.moveShortcutPictureBox.TabIndex = 0;
            this.moveShortcutPictureBox.TabStop = false;
            this.moveShortcutPictureBox.Visible = false;
            // 
            // SensorQuickLauncher
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.moveShortcutPictureBox);
            this.Controls.Add(this.quickLaunchFlowLayoutPanelUp);
            this.Controls.Add(this.quickLaunchFlowLayoutPanelDown);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(0, 48);
            this.MinimumSize = new System.Drawing.Size(48, 48);
            this.Name = "SensorQuickLauncher";
            this.Size = new System.Drawing.Size(48, 48);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.QuickLaunchFlowLayoutPanelDown_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.QuickLaunchFlowLayoutPanelUp_DragEnter);
            this.shortcutContextMenu.ResumeLayout(false);
            this.separatorContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moveShortcutPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel quickLaunchFlowLayoutPanelDown;
        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.FlowLayoutPanel quickLaunchFlowLayoutPanelUp;
        private System.Windows.Forms.ContextMenuStrip shortcutContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip separatorContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addSeparatorAfterThisItemToolStripMenuItem;
        private System.Windows.Forms.PictureBox moveShortcutPictureBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

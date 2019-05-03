namespace XtreamToolbox
{
    partial class Toolbox
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toolbox));
            this.toolboxContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.eXIFPhotosRenamerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBoxOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolBoxFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.autoTimeSynchTimer = new System.Windows.Forms.Timer(this.components);
            this.timeSyncBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.initBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.actionTimer = new System.Windows.Forms.Timer(this.components);
            this.networkDetectorTimer = new System.Windows.Forms.Timer(this.components);
            this.toolboxContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolboxContextMenu
            // 
            resources.ApplyResources(this.toolboxContextMenu, "toolboxContextMenu");
            this.toolboxContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolboxContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripSeparator1,
            this.eXIFPhotosRenamerToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolBoxOptionsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.toolboxContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolboxContextMenu.Name = "toolboxContextMenu";
            this.toolboxContextMenu.ShowImageMargin = false;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AProposToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // eXIFPhotosRenamerToolStripMenuItem
            // 
            this.eXIFPhotosRenamerToolStripMenuItem.Name = "eXIFPhotosRenamerToolStripMenuItem";
            resources.ApplyResources(this.eXIFPhotosRenamerToolStripMenuItem, "eXIFPhotosRenamerToolStripMenuItem");
            this.eXIFPhotosRenamerToolStripMenuItem.Click += new System.EventHandler(this.PhotosRenamerToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolBoxOptionsToolStripMenuItem
            // 
            this.toolBoxOptionsToolStripMenuItem.Name = "toolBoxOptionsToolStripMenuItem";
            resources.ApplyResources(this.toolBoxOptionsToolStripMenuItem, "toolBoxOptionsToolStripMenuItem");
            this.toolBoxOptionsToolStripMenuItem.Click += new System.EventHandler(this.ContextMenu_options_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.QuiterLaToolBoxToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.ContextMenuStrip = this.toolboxContextMenu;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // toolBoxFlowLayoutPanel
            // 
            resources.ApplyResources(this.toolBoxFlowLayoutPanel, "toolBoxFlowLayoutPanel");
            this.toolBoxFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolBoxFlowLayoutPanel.Name = "toolBoxFlowLayoutPanel";
            // 
            // autoTimeSynchTimer
            // 
            this.autoTimeSynchTimer.Interval = 3600000;
            this.autoTimeSynchTimer.Tick += new System.EventHandler(this.AutoTimeSynchTimer_Tick);
            // 
            // timeSyncBackgroundWorker
            // 
            this.timeSyncBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.TimeSyncBackgroundWorker_DoWork);
            this.timeSyncBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.TimeSyncBackgroundWorker_RunWorkerCompleted);
            // 
            // initBackgroundWorker
            // 
            this.initBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InitBackgroundWorker_DoWork);
            // 
            // actionTimer
            // 
            this.actionTimer.Enabled = true;
            this.actionTimer.Tick += new System.EventHandler(this.ActionTimer_Tick);
            // 
            // networkDetectorTimer
            // 
            this.networkDetectorTimer.Enabled = true;
            this.networkDetectorTimer.Interval = 1000;
            this.networkDetectorTimer.Tick += new System.EventHandler(this.NetworkDetectorTimer_Tick);
            // 
            // Toolbox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::XtreamToolbox.Properties.Resources.background;
            this.CausesValidation = false;
            this.ControlBox = false;
            this.Controls.Add(this.toolBoxFlowLayoutPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Toolbox";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolBox_FormClosing);
            this.Move += new System.EventHandler(this.ToolBox_Move);
            this.toolboxContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip toolboxContextMenu;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.FlowLayoutPanel toolBoxFlowLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem eXIFPhotosRenamerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolBoxOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer autoTimeSynchTimer;
        private System.ComponentModel.BackgroundWorker timeSyncBackgroundWorker;
        private System.ComponentModel.BackgroundWorker initBackgroundWorker;
        private System.Windows.Forms.Timer actionTimer;
        private System.Windows.Forms.Timer networkDetectorTimer;
    }
}


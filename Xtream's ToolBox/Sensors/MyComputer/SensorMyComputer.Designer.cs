namespace Xtream_ToolBox.Sensors
{
    partial class SensorMyComputer
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorMyComputer));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.windowsUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microsoftStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationLaunchedOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionalFeaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displaySettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legacyToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addOrRemoveProgramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.microsoftManagementConsoleMMCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsViewerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsUpdateToolStripMenuItem,
            this.microsoftStoreToolStripMenuItem,
            this.windowsSettingsToolStripMenuItem,
            this.systemInformationToolStripMenuItem,
            this.applicationLaunchedOnStartupToolStripMenuItem,
            this.applicationsToolStripMenuItem,
            this.defaultApplicationsToolStripMenuItem,
            this.optionalFeaturesToolStripMenuItem,
            this.displaySettingsToolStripMenuItem,
            this.printersToolStripMenuItem,
            this.legacyToolsToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // windowsUpdateToolStripMenuItem
            // 
            this.windowsUpdateToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.MyComputer_Refresh;
            this.windowsUpdateToolStripMenuItem.Name = "windowsUpdateToolStripMenuItem";
            resources.ApplyResources(this.windowsUpdateToolStripMenuItem, "windowsUpdateToolStripMenuItem");
            this.windowsUpdateToolStripMenuItem.Click += new System.EventHandler(this.WindowsUpdateToolStripMenuItem_Click);
            // 
            // microsoftStoreToolStripMenuItem
            // 
            this.microsoftStoreToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.MyComputer_MsStore;
            this.microsoftStoreToolStripMenuItem.Name = "microsoftStoreToolStripMenuItem";
            resources.ApplyResources(this.microsoftStoreToolStripMenuItem, "microsoftStoreToolStripMenuItem");
            this.microsoftStoreToolStripMenuItem.Click += new System.EventHandler(this.MicrosoftStoreToolStripMenuItem_Click);
            // 
            // windowsSettingsToolStripMenuItem
            // 
            this.windowsSettingsToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.MyComputer_WindowsSettings;
            this.windowsSettingsToolStripMenuItem.Name = "windowsSettingsToolStripMenuItem";
            resources.ApplyResources(this.windowsSettingsToolStripMenuItem, "windowsSettingsToolStripMenuItem");
            this.windowsSettingsToolStripMenuItem.Click += new System.EventHandler(this.WindowsSettingsToolStripMenuItem_Click);
            // 
            // systemInformationToolStripMenuItem
            // 
            this.systemInformationToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.MyComputer_SysInfo;
            this.systemInformationToolStripMenuItem.Name = "systemInformationToolStripMenuItem";
            resources.ApplyResources(this.systemInformationToolStripMenuItem, "systemInformationToolStripMenuItem");
            this.systemInformationToolStripMenuItem.Click += new System.EventHandler(this.SystemInformationToolStripMenuItem_Click);
            // 
            // applicationLaunchedOnStartupToolStripMenuItem
            // 
            this.applicationLaunchedOnStartupToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.MyComputer_StartupApp;
            this.applicationLaunchedOnStartupToolStripMenuItem.Name = "applicationLaunchedOnStartupToolStripMenuItem";
            resources.ApplyResources(this.applicationLaunchedOnStartupToolStripMenuItem, "applicationLaunchedOnStartupToolStripMenuItem");
            this.applicationLaunchedOnStartupToolStripMenuItem.Click += new System.EventHandler(this.ApplicationLaunchedOnStartupToolStripMenuItem_Click);
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.MyComputer_InstalledApps;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            resources.ApplyResources(this.applicationsToolStripMenuItem, "applicationsToolStripMenuItem");
            this.applicationsToolStripMenuItem.Click += new System.EventHandler(this.ApplicationsToolStripMenuItem_Click);
            // 
            // defaultApplicationsToolStripMenuItem
            // 
            this.defaultApplicationsToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.MyComputer_DefaultApps;
            this.defaultApplicationsToolStripMenuItem.Name = "defaultApplicationsToolStripMenuItem";
            resources.ApplyResources(this.defaultApplicationsToolStripMenuItem, "defaultApplicationsToolStripMenuItem");
            this.defaultApplicationsToolStripMenuItem.Click += new System.EventHandler(this.DefaultApplicationsToolStripMenuItem_Click);
            // 
            // optionalFeaturesToolStripMenuItem
            // 
            this.optionalFeaturesToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.MyComputer_OptionalFeatures;
            this.optionalFeaturesToolStripMenuItem.Name = "optionalFeaturesToolStripMenuItem";
            resources.ApplyResources(this.optionalFeaturesToolStripMenuItem, "optionalFeaturesToolStripMenuItem");
            this.optionalFeaturesToolStripMenuItem.Click += new System.EventHandler(this.OptionalFeaturesToolStripMenuItem_Click);
            // 
            // displaySettingsToolStripMenuItem
            // 
            this.displaySettingsToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.MyComputer_DisplaySettings;
            this.displaySettingsToolStripMenuItem.Name = "displaySettingsToolStripMenuItem";
            resources.ApplyResources(this.displaySettingsToolStripMenuItem, "displaySettingsToolStripMenuItem");
            this.displaySettingsToolStripMenuItem.Click += new System.EventHandler(this.DisplaySettingsToolStripMenuItem_Click);
            // 
            // printersToolStripMenuItem
            // 
            this.printersToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.MyComputer_Printer;
            this.printersToolStripMenuItem.Name = "printersToolStripMenuItem";
            resources.ApplyResources(this.printersToolStripMenuItem, "printersToolStripMenuItem");
            this.printersToolStripMenuItem.Click += new System.EventHandler(this.PrintersToolStripMenuItem_Click);
            // 
            // legacyToolsToolStripMenuItem
            // 
            this.legacyToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.addOrRemoveProgramsToolStripMenuItem,
            this.servicesManagementToolStripMenuItem1,
            this.microsoftManagementConsoleMMCToolStripMenuItem,
            this.eventsViewerToolStripMenuItem1});
            this.legacyToolsToolStripMenuItem.Image = global::Xtream_ToolBox.Properties.Resources.MyComputer_Legacy;
            this.legacyToolsToolStripMenuItem.Name = "legacyToolsToolStripMenuItem";
            resources.ApplyResources(this.legacyToolsToolStripMenuItem, "legacyToolsToolStripMenuItem");
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.OpenControlPanelToolStripMenuItem_Click);
            // 
            // addOrRemoveProgramsToolStripMenuItem
            // 
            resources.ApplyResources(this.addOrRemoveProgramsToolStripMenuItem, "addOrRemoveProgramsToolStripMenuItem");
            this.addOrRemoveProgramsToolStripMenuItem.Name = "addOrRemoveProgramsToolStripMenuItem";
            this.addOrRemoveProgramsToolStripMenuItem.Click += new System.EventHandler(this.AddOrRemoveProgramToolStripMenuItem_Click);
            // 
            // servicesManagementToolStripMenuItem1
            // 
            resources.ApplyResources(this.servicesManagementToolStripMenuItem1, "servicesManagementToolStripMenuItem1");
            this.servicesManagementToolStripMenuItem1.Name = "servicesManagementToolStripMenuItem1";
            this.servicesManagementToolStripMenuItem1.Click += new System.EventHandler(this.ServicesManagementToolStripMenuItem_Click);
            // 
            // microsoftManagementConsoleMMCToolStripMenuItem
            // 
            resources.ApplyResources(this.microsoftManagementConsoleMMCToolStripMenuItem, "microsoftManagementConsoleMMCToolStripMenuItem");
            this.microsoftManagementConsoleMMCToolStripMenuItem.Name = "microsoftManagementConsoleMMCToolStripMenuItem";
            this.microsoftManagementConsoleMMCToolStripMenuItem.Click += new System.EventHandler(this.MicrosoftManagmentConsoleMMCToolStripMenuItem_Click);
            // 
            // eventsViewerToolStripMenuItem1
            // 
            resources.ApplyResources(this.eventsViewerToolStripMenuItem1, "eventsViewerToolStripMenuItem1");
            this.eventsViewerToolStripMenuItem1.Name = "eventsViewerToolStripMenuItem1";
            this.eventsViewerToolStripMenuItem1.Click += new System.EventHandler(this.EventsViewerToolStripMenuItem_Click);
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 60000;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // SensorMyComputer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.myComputer;
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "SensorMyComputer";
            this.Click += new System.EventHandler(this.SensorMyComputer_Click);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.ToolStripMenuItem windowsSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationLaunchedOnStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionalFeaturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displaySettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem microsoftStoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legacyToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addOrRemoveProgramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicesManagementToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem microsoftManagementConsoleMMCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsViewerToolStripMenuItem1;
    }
}

﻿namespace Xtream_ToolBox.Sensors {
    partial class SensorWeatherExtendedPanel {
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorWeatherExtendedPanel));
            this.closeExtendedInfosPictureBox = new System.Windows.Forms.PictureBox();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.weatherPictureBox = new System.Windows.Forms.PictureBox();
            this.localisationLabel = new System.Windows.Forms.Label();
            this.localisationPositionLabel = new System.Windows.Forms.Label();
            this.temperatureGroupbox = new System.Windows.Forms.GroupBox();
            this.humidityLabel = new System.Windows.Forms.Label();
            this.tempLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pressureAndVisibilityGroupBox = new System.Windows.Forms.GroupBox();
            this.visibilityLabel = new System.Windows.Forms.Label();
            this.pressureLabel = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.windGroupBox = new System.Windows.Forms.GroupBox();
            this.windLabel = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lastMesureLabel = new System.Windows.Forms.Label();
            this.weatherLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.weatherLinkLabel = new System.Windows.Forms.LinkLabel();
            this.cityIdLabel = new System.Windows.Forms.Label();
            this.sunLabel = new System.Windows.Forms.Label();
            this.findCityIdLabel = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.closeExtendedInfosPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherPictureBox)).BeginInit();
            this.temperatureGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pressureAndVisibilityGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.windGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // closeExtendedInfosPictureBox
            // 
            this.closeExtendedInfosPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.closeExtendedInfosPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.closeExtendedInfosPictureBox, "closeExtendedInfosPictureBox");
            this.closeExtendedInfosPictureBox.Name = "closeExtendedInfosPictureBox";
            this.closeExtendedInfosPictureBox.TabStop = false;
            this.helpToolTip.SetToolTip(this.closeExtendedInfosPictureBox, resources.GetString("closeExtendedInfosPictureBox.ToolTip"));
            this.closeExtendedInfosPictureBox.Click += new System.EventHandler(this.CloseExtendedInfosPictureBox_Click);
            // 
            // helpToolTip
            // 
            this.helpToolTip.ShowAlways = true;
            // 
            // weatherPictureBox
            // 
            this.weatherPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.weatherPictureBox.Image = global::Xtream_ToolBox.Properties.Resources.weather_na;
            resources.ApplyResources(this.weatherPictureBox, "weatherPictureBox");
            this.weatherPictureBox.Name = "weatherPictureBox";
            this.weatherPictureBox.TabStop = false;
            // 
            // localisationLabel
            // 
            resources.ApplyResources(this.localisationLabel, "localisationLabel");
            this.localisationLabel.BackColor = System.Drawing.Color.Transparent;
            this.localisationLabel.Name = "localisationLabel";
            // 
            // localisationPositionLabel
            // 
            resources.ApplyResources(this.localisationPositionLabel, "localisationPositionLabel");
            this.localisationPositionLabel.BackColor = System.Drawing.Color.Transparent;
            this.localisationPositionLabel.Name = "localisationPositionLabel";
            // 
            // temperatureGroupbox
            // 
            this.temperatureGroupbox.BackColor = System.Drawing.Color.Transparent;
            this.temperatureGroupbox.Controls.Add(this.humidityLabel);
            this.temperatureGroupbox.Controls.Add(this.tempLabel);
            this.temperatureGroupbox.Controls.Add(this.pictureBox2);
            resources.ApplyResources(this.temperatureGroupbox, "temperatureGroupbox");
            this.temperatureGroupbox.Name = "temperatureGroupbox";
            this.temperatureGroupbox.TabStop = false;
            // 
            // humidityLabel
            // 
            resources.ApplyResources(this.humidityLabel, "humidityLabel");
            this.humidityLabel.BackColor = System.Drawing.Color.Transparent;
            this.humidityLabel.Name = "humidityLabel";
            // 
            // tempLabel
            // 
            resources.ApplyResources(this.tempLabel, "tempLabel");
            this.tempLabel.BackColor = System.Drawing.Color.Transparent;
            this.tempLabel.Name = "tempLabel";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Xtream_ToolBox.Properties.Resources.thermometre;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pressureAndVisibilityGroupBox
            // 
            this.pressureAndVisibilityGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.pressureAndVisibilityGroupBox.Controls.Add(this.visibilityLabel);
            this.pressureAndVisibilityGroupBox.Controls.Add(this.pressureLabel);
            this.pressureAndVisibilityGroupBox.Controls.Add(this.pictureBox3);
            resources.ApplyResources(this.pressureAndVisibilityGroupBox, "pressureAndVisibilityGroupBox");
            this.pressureAndVisibilityGroupBox.Name = "pressureAndVisibilityGroupBox";
            this.pressureAndVisibilityGroupBox.TabStop = false;
            // 
            // visibilityLabel
            // 
            resources.ApplyResources(this.visibilityLabel, "visibilityLabel");
            this.visibilityLabel.BackColor = System.Drawing.Color.Transparent;
            this.visibilityLabel.Name = "visibilityLabel";
            // 
            // pressureLabel
            // 
            resources.ApplyResources(this.pressureLabel, "pressureLabel");
            this.pressureLabel.BackColor = System.Drawing.Color.Transparent;
            this.pressureLabel.Name = "pressureLabel";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Xtream_ToolBox.Properties.Resources.barometer;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // windGroupBox
            // 
            this.windGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.windGroupBox.Controls.Add(this.windLabel);
            this.windGroupBox.Controls.Add(this.pictureBox4);
            resources.ApplyResources(this.windGroupBox, "windGroupBox");
            this.windGroupBox.Name = "windGroupBox";
            this.windGroupBox.TabStop = false;
            // 
            // windLabel
            // 
            resources.ApplyResources(this.windLabel, "windLabel");
            this.windLabel.BackColor = System.Drawing.Color.Transparent;
            this.windLabel.Name = "windLabel";
            // 
            // pictureBox4
            // 
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Image = global::Xtream_ToolBox.Properties.Resources.Wind_Logo;
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // lastMesureLabel
            // 
            resources.ApplyResources(this.lastMesureLabel, "lastMesureLabel");
            this.lastMesureLabel.BackColor = System.Drawing.Color.Transparent;
            this.lastMesureLabel.Name = "lastMesureLabel";
            // 
            // weatherLabel
            // 
            resources.ApplyResources(this.weatherLabel, "weatherLabel");
            this.weatherLabel.BackColor = System.Drawing.Color.Transparent;
            this.weatherLabel.Name = "weatherLabel";
            // 
            // locationTextBox
            // 
            resources.ApplyResources(this.locationTextBox, "locationTextBox");
            this.locationTextBox.Name = "locationTextBox";
            // 
            // weatherLinkLabel
            // 
            resources.ApplyResources(this.weatherLinkLabel, "weatherLinkLabel");
            this.weatherLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.weatherLinkLabel.Name = "weatherLinkLabel";
            this.weatherLinkLabel.TabStop = true;
            this.weatherLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WeatherLinkLabel_LinkClicked);
            // 
            // cityIdLabel
            // 
            resources.ApplyResources(this.cityIdLabel, "cityIdLabel");
            this.cityIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.cityIdLabel.Name = "cityIdLabel";
            // 
            // sunLabel
            // 
            resources.ApplyResources(this.sunLabel, "sunLabel");
            this.sunLabel.BackColor = System.Drawing.Color.Transparent;
            this.sunLabel.Name = "sunLabel";
            // 
            // findCityIdLabel
            // 
            resources.ApplyResources(this.findCityIdLabel, "findCityIdLabel");
            this.findCityIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.findCityIdLabel.Name = "findCityIdLabel";
            // 
            // ApplyButton
            // 
            resources.ApplyResources(this.ApplyButton, "ApplyButton");
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // SensorWeatherExtendedPanel
            // 
            this.AcceptButton = this.ApplyButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.extendInfosBackground;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.findCityIdLabel);
            this.Controls.Add(this.sunLabel);
            this.Controls.Add(this.cityIdLabel);
            this.Controls.Add(this.weatherLinkLabel);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.weatherLabel);
            this.Controls.Add(this.lastMesureLabel);
            this.Controls.Add(this.windGroupBox);
            this.Controls.Add(this.pressureAndVisibilityGroupBox);
            this.Controls.Add(this.temperatureGroupbox);
            this.Controls.Add(this.localisationPositionLabel);
            this.Controls.Add(this.localisationLabel);
            this.Controls.Add(this.weatherPictureBox);
            this.Controls.Add(this.closeExtendedInfosPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SensorWeatherExtendedPanel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.closeExtendedInfosPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherPictureBox)).EndInit();
            this.temperatureGroupbox.ResumeLayout(false);
            this.temperatureGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pressureAndVisibilityGroupBox.ResumeLayout(false);
            this.pressureAndVisibilityGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.windGroupBox.ResumeLayout(false);
            this.windGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox closeExtendedInfosPictureBox;
        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.PictureBox weatherPictureBox;
        private System.Windows.Forms.Label localisationLabel;
        private System.Windows.Forms.Label localisationPositionLabel;
        private System.Windows.Forms.GroupBox temperatureGroupbox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox pressureAndVisibilityGroupBox;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox windGroupBox;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Label humidityLabel;
        private System.Windows.Forms.Label visibilityLabel;
        private System.Windows.Forms.Label pressureLabel;
        private System.Windows.Forms.Label windLabel;
        private System.Windows.Forms.Label lastMesureLabel;
        private System.Windows.Forms.Label weatherLabel;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.LinkLabel weatherLinkLabel;
        private System.Windows.Forms.Label cityIdLabel;
        private System.Windows.Forms.Label sunLabel;
        private System.Windows.Forms.Label findCityIdLabel;
        private System.Windows.Forms.Button ApplyButton;
    }
}
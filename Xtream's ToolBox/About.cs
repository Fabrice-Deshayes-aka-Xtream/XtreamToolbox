using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace Xtream_ToolBox {
    public partial class About : Form {

        /** variable necessaire la gestion du d�placement de la fenetre par la souris */
        private bool mouseIsDown = false;
        private int lastMousePositionX = 0;
        private int lastMousePositionY = 0;

        // ressource manager pour acc�der aux chaines localis�es
        ResourceManager resources = Properties.Resources.ResourceManager;

        public About() {
            InitializeComponent();

            this.Text = resources.GetString("FormName_About");
            labelFramework.Text = String.Format(".NET Framework {0}", Environment.Version);

            this.Icon = Properties.Resources.icoHome;            
        }

        // gestion du d�placement de la toolbox : initialisation du d�placement
        private void MoveBox_MouseDown(object sender, MouseEventArgs e) {
            mouseIsDown = true;
            lastMousePositionX = e.X;
            lastMousePositionY = e.Y;
        }

        // gestion du d�placement de la toolbox : d�placement
        private void MoveBox_MouseMove(object sender, MouseEventArgs e) {
            if (mouseIsDown) {
                Left = Left - (lastMousePositionX - e.X);
                Top = Top - (lastMousePositionY - e.Y);
            }
        }

        // gestion du d�placement de la toolbox : sauvegarde du d�placement
        private void MoveBox_MouseUp(object sender, MouseEventArgs e) {
            mouseIsDown = false;
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void HomepageLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            SystemUtils.openInDefaultBrowser("http://www.xtream.be");
        }
    }
}
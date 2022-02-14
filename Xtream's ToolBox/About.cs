using System;
using System.Resources;
using System.Windows.Forms;

namespace XtreamToolbox
{
    public partial class About : Form
    {

        /** variable necessaire la gestion du déplacement de la fenetre par la souris */
        private bool mouseIsDown = false;
        private int lastMousePositionX = 0;
        private int lastMousePositionY = 0;

        // ressource manager pour accéder aux chaines localisées
        ResourceManager resources = Properties.Resources.ResourceManager;

        public About()
        {
            InitializeComponent();

            this.Text = resources.GetString("FormName_About");
            this.Icon = Properties.Resources.icoHome;
            this.versionLabel.Text = "version " + Properties.Settings.Default._version;

        }

        // gestion du déplacement de la toolbox : initialisation du déplacement
        private void MoveBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsDown = true;
            lastMousePositionX = e.X;
            lastMousePositionY = e.Y;
        }

        // gestion du déplacement de la toolbox : déplacement
        private void MoveBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                Left -= (lastMousePositionX - e.X);
                Top -= (lastMousePositionY - e.Y);
            }
        }

        // gestion du déplacement de la toolbox : sauvegarde du déplacement
        private void MoveBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HomepageLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SystemUtils.OpenInDefaultBrowser("http://www.xtream.be");
        }

        private void OpenChangeLogOnGithub_Click(object sender, EventArgs e)
        {
            SystemUtils.OpenInDefaultBrowser("https://github.com/Fabrice-Deshayes-aka-Xtream/XtreamToolbox/blob/master/CHANGELOG.md#version-" + Properties.Settings.Default._version.Replace(".", ""));
        }
    }
}
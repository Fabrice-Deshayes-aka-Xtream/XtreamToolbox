using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using XtreamToolbox.Utils;

namespace XtreamToolbox
{

    public partial class ToolBoxStarter : UserControl, ISensor
    {

        // reference on toolbox
        private Toolbox toolbox = null;

        /** variable necessaire la gestion du déplacement de la fenetre par la souris */
        private bool mouseIsDown = false;
        private int lastMousePositionX = 0;
        private int lastMousePositionY = 0;

        // ressource manager pour accéder aux chaines localisées
        ResourceManager resources = Properties.Resources.ResourceManager;

        // constructor
        public ToolBoxStarter(Toolbox toolbox)
        {
            InitializeComponent();
            this.toolbox = toolbox;
            InitUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form GetExtendedPanel()
        {
            return null;
        }

        // init UI
        public void InitUI()
        {
            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            // tooltips & lock move
            if (Properties.Settings.Default.lockPosition)
            {
                moveBox.Cursor = Cursors.Default;
            }
            else
            {
                moveBox.Cursor = Cursors.NoMove2D;
                helpToolTip.SetToolTip(moveBox, resources.GetString("Toolbox_move"));
            }
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void InitSensorData()
        {
            // nothing to do on this sensor
        }

        // refresh UI based on sensor Data
        public void RefreshUI()
        {
            // nothing to do on this sensor
        }

        // update location of extended panel if needed
        public void UpdateLocation()
        {
            // nothing to do on this sensor
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
            if (mouseIsDown && !Properties.Settings.Default.lockPosition)
            {
                Rectangle toolboxArea = ToolBoxUtils.ManageMagneticPosition(new Rectangle(toolbox.Left - (lastMousePositionX - e.X), toolbox.Top - (lastMousePositionY - e.Y), toolbox.Width, toolbox.Height), toolbox.MagneticXPositions, toolbox.MagneticYPositions, 16, Properties.Settings.Default.magneticScreenBorder);
                toolbox.Top = toolboxArea.Top;
                toolbox.Left = toolboxArea.Left;
            }
        }

        // gestion du déplacement de la toolbox : sauvegarde du déplacement
        private void MoveBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;

            // save position in property
            Properties.Settings.Default.posX = toolbox.Left;
            Properties.Settings.Default.posY = toolbox.Top;
            Properties.Settings.Default.Save();
        }
    }
}

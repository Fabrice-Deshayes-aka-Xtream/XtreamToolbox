using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Resources;
using System.Threading;
using System.Globalization;

namespace Xtream_ToolBox
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ressource manager pour accéder aux chaines localisées
            ResourceManager resources = Properties.Resources.ResourceManager;

            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);

            using (SingleInstanceApp app = new SingleInstanceApp("{Xtream ToolBox}"))
            {
                if (app.IsRunning())
                {
                    MessageBox.Show(resources.GetString("Toolbox_one_Instance"));
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new ToolBox());
                }
            }
        }
    }
}
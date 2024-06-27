using System;
using System.Windows.Forms;

namespace Manag_ph
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Main().Visible = false;
            Application.Run(new Main());


        }
    }
}

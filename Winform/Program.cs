using BTL_Prj.Frm.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Prj
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

                frmMain frm;
            do
            {
                Application.Run(frm = new frmMain());
            } while (frm.isReload);

            //Application.Run(new Frm.Main.frmMain());
            //Application.Run(new Form_Login());
        }
    }

}

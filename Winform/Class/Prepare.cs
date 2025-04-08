using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Prj.Class
{
    internal class Prepare
    {
        private static readonly string ProjectName = Assembly.GetExecutingAssembly().GetName().Name; //get project name
        private static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;  //get current directory
        private static readonly string ProjectDirectory = getDatabaseDirectory();
        private static readonly string MediaDirectoryInProject =    "\\Database\\Media\\";
        private static readonly string DatabaseDirectoryInProject = "\\Database\\Database_BTL.mdf";
        private static readonly string IconFilename = "32x32-LogoUTC.ico";
        private static int TTL = 60;

        public Prepare()
        {
            //getProjectDirectory();
        }
        public static string getProjectDirectory()
        {
            return CurrentDirectory.Substring(0, CurrentDirectory.IndexOf(ProjectName)) + ProjectName;
        }
        public static string getDatabaseDirectory()
        {
            //MessageBox.Show(getProjectDirectory() + DatabaseDirectoryInProject);
            return getProjectDirectory() + DatabaseDirectoryInProject;
        }
        public static string getMediaDirectoryInProject() { return MediaDirectoryInProject;}
        public static int getTTL() { return TTL; }
        public static void setFormProperties(Form  frm)
        {
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            try
            {
                frm.Icon = new Icon(ProjectDirectory + MediaDirectoryInProject + "Logo\\" + IconFilename);

            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data: " + ex.Message);
            }
        }
        public static void setDgvProperties(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Font = new System.Drawing.Font("Times New Roman", 12F);
            dgv.AllowUserToAddRows = true;

        }
    }
}

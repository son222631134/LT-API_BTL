using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BTL_Prj.Class
{
    internal class Function
    {
        public static void CopyFile(string src, string des)
        {
            if (src == des) return;
            string path = des.Substring(0, des.LastIndexOf("\\"));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                File.Copy(src, des, true);
            } catch (Exception ex) {
                if (ex is IOException)
                {
                    File.Delete(des);
                    File.Copy(src, des, true);
                }
            }
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static string CheckLastLogin()
        {
            DataTable dt = ProcessingData.GetData(
                "SELECT TOP 1 *" +
                " FROM Account" +
                " ORDER BY LastLogin DESC"
                );
            //username = dt.Rows[0]["Username"].ToString();
            //LastLogin = dt.Rows[0]["LastLogin"].ToString();
            //LastLogin = dt.Rows[0]["KeepLogin"].ToString();
            //Timeout = dt.Rows[0]["Timeout"].ToString();

            if (dt.Rows[0]["KeepLoginExpDate"].ToString() != "")
            {
                if (DateTime.Parse(dt.Rows[0]["KeepLoginExpDate"].ToString()) > DateTime.Now)
                {
                    return dt.Rows[0]["Username"].ToString();
                }
            }
            return "";
        }
        public static bool CheckLogin(string username, string password)
        {
            DataTable dt = ProcessingData.GetData(
                "SELECT * " +
                "FROM Account " +
                "WHERE Username = " + "\'" + username + "\'" + " AND Password = " + "\'" + password + "\'"
                );
            return dt.Rows.Count == 0 ? false : true;
        }
        public static void Logout(string username, bool KeepLogin)
        {
            DateTime KeepLoginExpDate = KeepLogin ? DateTime.Now + TimeSpan.FromSeconds(Prepare.getTTL()) : DateTime.Now;
            ProcessingData.ExecuteQuery("UPDATE Account " +
                "SET KeepLoginExpDate = " + "\'" + KeepLoginExpDate.ToString() + "\'" +
                " WHERE Username = " + "\'" + username + "\'"
                );
        }

    }
}

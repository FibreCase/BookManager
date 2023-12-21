using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
        }
    }

    public static class Global
    {
        public static string databaseurl = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.Environment.CurrentDirectory + "\\bookinfo.mdf;Integrated Security=True;Connect Timeout=30";
    }
}

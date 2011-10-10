using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace BMDevice_New
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                String dllPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\zkemkeeper.dll";
                //FileInfo fi = new FileInfo(@"zkemkeeper.dll");
                //bool b = fi.Exists;
                //"/s" + " " + "\"" + filePath + "\"";
                //MessageBox.Show(dllPath);
                Process reg = new Process();
                reg.StartInfo.FileName = "regsvr32.exe";
                reg.StartInfo.Arguments = "/s" + " " + "\"" + dllPath + "\"";
                reg.StartInfo.UseShellExecute = false;
                reg.StartInfo.CreateNoWindow = true;
                reg.StartInfo.RedirectStandardOutput = true;
                reg.Start();
                reg.WaitForExit();
                reg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DLL Registration failed.");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmBMDeviceMain());
            //Application.Run(new frmTestEmpInfo());
        }
    }
    static class Global
    {
        public static int Indexrow = 0;

        public static int selMech = -1;
        public static string selMechIp = "";
        public static string selMechPort = "";

        public static string selURL = "";
        public static string selUrlIp = "";
    }
}

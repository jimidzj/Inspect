using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.WinPAD.Common;
using GENLSYS.MES.WinPAD.Common.Classes;
using GENLSYS.MES.WinPAD.Common.Forms;
using GENLSYS.MES.WinPAD.SEC;
using GENLSYS.MES.AutoUpdate;

namespace GENLSYS.MES.WinPAD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);   
      
            ///
            #if DEBUG
            #else
                GENLSYS.MES.AutoUpdate.UpdateInfo info = new UpdateInfo();
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(info.ExecuteFile);
                string currVesion = myFileVersionInfo.FileVersion;

                if (info.checkUpdate(currVesion))
                {
                    if (MessageBox.Show("当前版本是" + currVesion + ",最新版本为" + info.Version + ",是否更新？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        Process.Start(Application.StartupPath + @"\GENLSYS.MES.AutoUpdate.exe");
                        Application.Exit();
                        return;
                    }

                } 
            #endif
            PrepareBeforeRun();                     
            Application.Run(new frmLogon());
            
        }

        static void PrepareBeforeRun()
        {
            SqlHelper.ConnectionString = Parameter.MES_DATABASE_CONNECTION;
            UtilCulture.InitialResource("GENLSYS.MES.Res", Application.StartupPath + "\\Resources", ConfigReader.getDefaultLanguage());
            string x = UtilCulture.GetString("Label.R00001");
        }

        static bool CheckInstance()
        {
            string proc = Process.GetCurrentProcess().ProcessName;
            string procId = Process.GetCurrentProcess().Id.ToString();
            Process[] processes = Process.GetProcessesByName(proc);
            if (processes.Length > 1)
            {
                MESMsgBox.ShowError(UtilCulture.GetString("Msg.R00189"));
                return false;
            }

            return true;
        }

        //static void CheckVersion(){
        //    GENLSYS.MES.AutoUpdate.UpdateInfo info = new UpdateInfo();
        //    FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(info.ExecuteFile);
        //    string currVesion = myFileVersionInfo.FileVersion;

        //     if (info.checkUpdate(currVesion))
        //     {
        //         if (MessageBox.Show("当前版本是" + currVesion + ",最新版本为" + info.Version + ",是否更新？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
        //        {
        //            Process.Start(Application.StartupPath + @"\GENLSYS.MES.AutoUpdate.exe");
        //            Application.Exit();
        //        }
        //    } 
        //}

        //static bool CheckSmartClient(string[] args)
        //{
        //    bool b = false;
        //    if (args.Length < 1)
        //    {
        //        MessageBox.Show("Please run the program from Smart Client. ");
        //        b = false;
        //    }
        //    else if (args[0].ToLower() == "openmode=8d5e13e416c05684e044001cc4fb7f7f")
        //    {
        //        b = true;
        //    }
        //    else if (args[0].ToLower() == "openmode=admin")
        //    {
        //        b = true;
        //    }
        //    else
        //        b = false;

        //    return b;
        //}
    }
}

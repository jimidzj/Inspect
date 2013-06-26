using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace GENLSYS.MES.AutoUpdate
{
    public partial class frmAutoUpdate : Form
    {

        string updateFolder = Application.StartupPath+"\\_Update\\";

        private clsLog mLog = null;
        private clsConfig mConfig = null;

        public frmAutoUpdate()
        {
            InitializeComponent();
        }
        
      
        public void DownloadDir(  )
        {
            try
            {
                clsFTP ftp = new clsFTP(mLog);
                ftp.setFace(this);
                clsConfig config = new clsConfig();
                string[] monitorDirectory = config.GetConfigValue(clsConfig.ConfigItem.MonitorRootFolder).Split(new char[] { '\\', '\\' });
                int FtpPort = 21;

                try
                {
                    string portStr = config.GetConfigValue(clsConfig.ConfigItem.FTPServerPort);
                    FtpPort = int.Parse(portStr);
                }
                catch
                {
                    FtpPort = 21;
                }

                mLog.WriteSingleLog("Start to connect to FTP.");
                ftp.Connect(config.GetConfigValue(clsConfig.ConfigItem.FTPServerIP),
                            FtpPort,
                            config.GetConfigValue(clsConfig.ConfigItem.FTPAccount),
                            config.GetConfigValue(clsConfig.ConfigItem.FTPPassword),
                            string.Empty,
                            "DEFAULT");
                mLog.WriteSingleLog("Connect to FTP success.");

 
                //if exists,add additional sequence to identify
                for (int i = 0; i < monitorDirectory.Length; i++)
                {

                    if (ftp.Exists(monitorDirectory[i]))
                    {   string localFile =updateFolder ;
                        ftp.FTPDownloadDir(localFile, monitorDirectory[i]);
                        mLog.WriteSingleLog("FTP get  OK ==> " + "local file: " + localFile + " | remote file: " + monitorDirectory[i]);
                    }
                    else
                    {
                        mLog.WriteSingleLog("FTP get  faild ==>   | remote file: " + monitorDirectory[i]);
                        MessageBox.Show( "服务器上没有" + monitorDirectory[i] ,"提示" );
                        return;
                    }
                }


                ftp.Disconnect();
                setPersent(100);
                setInfo("下载完成！");
                Install();
                return;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 

        #region ini log
        private clsLog InitLog()
        {
            try
            {
                mLog = new clsLog(mConfig);
                if (mLog != null)
                {
                    mLog.DeleteExpiredLog();
                    return mLog;
                }
                else
                {
                    MessageBox.Show("Init log fail.");
                }
                return null;
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Init log fail." + ex.Message);
                return null;
            }
        }
        #endregion
        #region ini FTP
        private void ftpConfig(){
         try
            {
                Cursor.Current = Cursors.WaitCursor;
                mConfig = new clsConfig();
                if (mConfig.GetConfigValue(clsConfig.ConfigItem.FTPServerIP).Trim() != string.Empty)
                {
                    mLog = InitLog();
                    mLog.WriteSingleLog("###");
                    mLog.WriteSingleLog(">>>>>>Monitor was opened at " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "<<<<<<");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
 
                this.Close();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        public void setInfo(string _text)
        {
            this.lblUpdateInfo.Text = _text;
        }

        public void setPersent(int _per)
        {
            this.processTotal.Value = _per; 
        }

        private void frmAutoUpdate_Load(object sender, EventArgs e)
        {
            mConfig = new clsConfig();
            InitLog();
            ftpConfig();


            UpdateInfo info = new UpdateInfo();
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(info.ExecuteFile);
            string currVesion = myFileVersionInfo.FileVersion;



            if (currVesion == info.Version)
            {
                MessageBox.Show("当前已经是最新版本");                
            }
            else
            {
                this.lblVersionInfo.Text = "从版本" + currVesion + "更新至版本" + info.Version;
                KillProcess();
                if (!Directory.Exists(updateFolder))
                {
                    Directory.CreateDirectory(updateFolder);
                }
                //if (updateInfo.UpdateFileList.Count > 0)
                //{
                //    DownloadFiles(updateInfo.URLAddress, updateInfo.UpdateFileList[0]);
                //    fileCount++;
                //}
                /////////////////////download dir from FTP
               // DownloadDir();
            }
        }

        private void Install()
        {
            this.lblUpdateInfo.Text = "正在安装更新...";            
            Thread.Sleep(2000);
            this.lblUpdateInfo.Text = "开始拷贝文件...";    
            Copy(updateFolder, Application.StartupPath);
            this.lblUpdateInfo.Text = "清除安装文件...";  
            DeleteFolder(updateFolder);
            mConfig = new clsConfig();
            
            string executeFile = mConfig.GetConfigValue(clsConfig.ConfigItem.Execute);
            this.lblUpdateInfo.Text = "开始重新启动..." + Application.StartupPath + @"\" + executeFile;  
            Process.Start(Application.StartupPath + @"\" + executeFile);
          
            Application.Exit();
        }

        //private bool IsUseFile()
        //{
        //    bool flag1 = false;
        //    Process[] processArray1 = Process.GetProcesses();
        //    Process[] processArray2 = processArray1;
        //    for (int i = 0; i < processArray2.Length; i++)
        //    {
        //        Process process1 = processArray2[i];
        //        foreach (string appName in updateInfo.AppList)
        //        {
        //            if (process1.ProcessName.ToLower() == appName.ToLower())
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return flag1;
        //}

        private void KillProcess()
        {
            Process[] processArray1 = Process.GetProcesses();
            Process[] processArray2 = processArray1;
            mConfig = new clsConfig();

            string App = mConfig.GetConfigValue(clsConfig.ConfigItem.Execute);
            for (int i = 0; i < processArray2.Length; i++)
            {
                Process process1 = processArray2[i];

                if (process1.ProcessName.ToLower() == App.ToLower())
                    {
                        for (int j = 0; j < process1.Threads.Count; j++)
                        {                            
                            process1.Threads[j].Dispose();                            
                        }
                        //process1.CloseMainWindow();
                        process1.Kill();
                    }
                
            }
        }

        private void Copy(string stSourcePath, string stDestPath)
        {
            DirectoryInfo info1 = new DirectoryInfo(stSourcePath);
            DirectoryInfo info2 = new DirectoryInfo(stDestPath);
            if (info1.Exists)
            {
                if (!info2.Exists)
                {
                    info2.Create();
                }
                FileInfo[] infoArray1 = info1.GetFiles();
               
                for (int i = 0; i < infoArray1.Length; i++)
                {
                    this.lblUpdateInfo.Text = "开始拷贝文件... " + infoArray1[i].Name; 
                    File.Copy(infoArray1[i].FullName, info2.FullName + @"\" + infoArray1[i].Name, true);                   
                }
                DirectoryInfo[] infoArray2 = info1.GetDirectories();
                for (int j = 0; j < infoArray2.Length; j++)
                {
                    this.Copy(infoArray2[j].FullName, info2.FullName + @"\" + infoArray2[j].Name);
                }
            }
        }
                
        private void DeleteFolder(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists)
            {
                FileInfo[] infoArray1 = dir.GetFiles();
                for (int i = 0; i < infoArray1.Length; i++)
                {
                    infoArray1[i].Delete();
                }
                DirectoryInfo[] infoArray2 = dir.GetDirectories();
                for (int j = 0; j < infoArray2.Length; j++)
                {
                    DeleteFolder(infoArray2[j].FullName);
                }
                dir.Delete();
            }
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            DownloadDir();
           
        }

               
    }
}

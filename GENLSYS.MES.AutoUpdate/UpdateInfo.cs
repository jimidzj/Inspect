using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace GENLSYS.MES.AutoUpdate
{
    public class UpdateInfo
    {
        clsLog mLog;
         
         public UpdateInfo( )
        {
           
            mLog = new clsLog( new clsConfig() );
           
            getUpdateInfo(GetServerDoc());
        }

        public UpdateInfo(clsLog _mLog)
        {  
            mLog =_mLog;
            getUpdateInfo(GetServerDoc());
        }

        public string   Version { get; set; }
        public string   ExecuteFile { get; set; }
        public string   ClientVersion { get; set; }
        
        public bool checkUpdate(string ClientVersion)
        {
            return !Version.Equals(ClientVersion);
        }

        private void getUpdateInfo(XmlDocument doc)
        {
            try
            {
                XmlNode node;
                node = doc.SelectSingleNode("config/Version");
                Version = node.InnerText;
                node = doc.SelectSingleNode("config/Execute");
                ExecuteFile = node.InnerText;
              }
            catch
            {
                throw;
            }
        }

        private string getUpdateURL()
        {
            try
            {
                string result = "";
                XmlDocument doc = new XmlDocument();
                doc.Load("UpdateFile.xml");

                XmlNode node = doc.SelectSingleNode("AutoUpdater/URLAddress");
                result = node.Attributes["URL"].Value;

                return result;
            }
            catch
            {
                throw;
            }
        }

        private XmlDocument GetServerDoc()
        {
            //获取服务器信息   
            getConfigFile();
            XmlDocument serverDoc = new XmlDocument();
            try
            {
                serverDoc.Load("UpdateFile_tmp.xml");
                return serverDoc;
            }
            catch
            {
                throw new Exception("Read server update file failed");
            }

        }


        public void getConfigFile(  )
        {
            //string updateFolder = Application.StartupPath + "\\_Update\\";
            //DirectoryInfo info1 = new DirectoryInfo(updateFolder);
            //if (!info1.Exists)
            //{
            //    info1.Create();
            //}


            try
            {
                clsFTP ftp = new clsFTP(mLog);
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

                mLog.WriteSingleLog(  "Start to connect to FTP.");
                ftp.Connect(config.GetConfigValue(clsConfig.ConfigItem.FTPServerIP),
                            FtpPort,
                            config.GetConfigValue(clsConfig.ConfigItem.FTPAccount),
                            config.GetConfigValue(clsConfig.ConfigItem.FTPPassword),
                            string.Empty,
                            "DEFAULT");
                mLog.WriteSingleLog(  "Connect to FTP success.");
 

                string remoteFileName =monitorDirectory[0] + "\\UpdateFile.xml";
                string localFile = "UpdateFile_tmp.xml";
                //if exists,add additional sequence to identify
               if (ftp.Exists(remoteFileName))
               {
                   ftp.FTPDownloadFile(localFile, remoteFileName);
                   mLog.WriteSingleLog("FTP get config file OK ==> " + "local file: " + localFile + " | remote file: " + remoteFileName);
               }
               else
               {
                   mLog.WriteSingleLog("FTP get t config file faild ==> " + "local file: " + localFile + " | remote file: " + remoteFileName);
               }

               
                ftp.Disconnect();
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
namespace GENLSYS.MES.AutoUpdate
{
    public class clsConfig
    {
        public enum ConfigItem
        {
            FTPServerIP,
            FTPServerPort,
            FTPAccount,
            FTPPassword,
            MonitorRootFolder,
            LogFilePath,
            LogFileKeepDays,  
            Version ,
            Execute,
            AppName,
        }
        private XmlDocument doc;
        private string xmlFile = "UpdateFile.xml";
        public clsConfig()
        {
            try
            {
                FileInfo fi = new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + xmlFile);
                if (!fi.Exists)
                {
                    throw new Exception("没有发现自动更新所需要的配置文件");
                }
                else
                {
                    doc = new XmlDocument();
                    doc.Load(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + xmlFile);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("加载配置文件错误: " + ex.Message);
            }
        }

        public string GetConfigValue(ConfigItem configItem)
        {
            try
            {
                XmlNode node = doc.SelectSingleNode("/config/" + configItem.ToString());
                return  node.InnerText ;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void SetConfigValue(ConfigItem configItem, string value)
        {
            XmlNode node = doc.SelectSingleNode("/config/" + configItem.ToString());
            node.InnerText =  value ;
        }

        public void SaveConfig()
        {
            doc.Save(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + xmlFile);
        }

        public void WriteConfigToLog(clsLog log)
        {
            log.WriteSingleLog("FTPServerIP: " + GetConfigValue(clsConfig.ConfigItem.FTPServerIP));
            log.WriteSingleLog("FTPServerPort: " + GetConfigValue(clsConfig.ConfigItem.FTPServerPort));
            log.WriteSingleLog("FTPAccount: " + GetConfigValue(clsConfig.ConfigItem.FTPAccount));
            log.WriteSingleLog("MonitorRootFolder: " + GetConfigValue(clsConfig.ConfigItem.MonitorRootFolder));
            log.WriteSingleLog("MES Version: " + GetConfigValue(clsConfig.ConfigItem.Version));
                  
        }
    }
}

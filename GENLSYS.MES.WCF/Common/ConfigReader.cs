using System;
using System.Data;
using System.Configuration;
using System.Web;

/// <summary>
/// Summary description for ConfigReader
/// </summary>
/// 
namespace GENLSYS.MES.WCF.Common
{
    public class ConfigReader
    {
        public static string getDBConnectionString_MES()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.WCF/Connections/MES_ConnectionString");
            return config.DBConnectionString;
        }

        public static string getLogLevel()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
              "GENLSYS.MES.WCF/Logging");
            return config.Level;
        }

        public static string getLogFileSize()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
              "GENLSYS.MES.WCF/Logging");
            return config.LogFileSize;
        }

        public static string getLogFileName()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
              "GENLSYS.MES.WCF/Logging");
            return config.LogFileName;
        }

        public static string getEnvironmentName()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
              "GENLSYS.MES.WCF/Application");
            return config.EnvironmentName;
        }

        public static string getCurrentRevision()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.WCF/Application");
            return config.CurrentRevision;
        }

        public static string getCustomerName()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.WCF/Customer");
            return config.CustomerName;
        }

        public static string getApplicationName()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.WCF/Application");
            return config.ApplicationName;
        }

        public static string getDownloadURL()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.WCF/Application");
            return config.DownloadURL;
        }
    }
}

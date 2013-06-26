using System;
using System.Data;
using System.Configuration;
using System.Web;

/// <summary>
/// Summary description for ConfigReader
/// </summary>
/// 
namespace GENLSYS.MES.Win.Common
{
    public class ConfigReader
    {
        public static string getDBConnectionString_MES()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.Win/Connections/MES_ConnectionString");
            return config.DBConnectionString;
        }

        public static string getLogLevel()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
              "GENLSYS.MES.Win/Logging");
            return config.Level;
        }

        public static string getLogFileSize()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
              "GENLSYS.MES.Win/Logging");
            return config.LogFileSize;
        }

        public static string getLogFileName()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
              "GENLSYS.MES.Win/Logging");
            return config.LogFileName;
        }

        public static string getEnvironmentName()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
              "GENLSYS.MES.Win/Application");
            return config.EnvironmentName;
        }

        public static string getCurrentRevision()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.Win/Application");
            return config.CurrentRevision;
        }

        public static string getCustomerName()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.Win/Customer");
            return config.CustomerName;
        }

        public static string getApplicationName()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.Win/Application");
            return config.ApplicationName;
        }

        public static string getDownloadURL()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.Win/Application");
            return config.DownloadURL;
        }

        public static string getSetupFileName()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.Win/Application");
            return config.SetupFileName;
        }

        public static string getReportingURL()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.Win/Application");
            return config.ReportingURL;
        }

        public static string getDefaultLanguage()
        {
            ConfigHandler config = (ConfigHandler)System.Configuration.ConfigurationManager.GetSection(
                "GENLSYS.MES.Win/Application");
            return config.DefaultLanguage;
        }
        
    }
}

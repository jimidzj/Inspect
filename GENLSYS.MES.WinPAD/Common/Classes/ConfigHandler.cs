using System;
using System.Data;
using System.Configuration;
using System.Web;

/// <summary>
/// Summary description for ConfigHandler
/// </summary>
/// 
namespace GENLSYS.MES.WinPAD.Common
{
    public class ConfigHandler : ConfigurationSection
    {
        /// <summary>
        /// 得到当前的数据库类型
        /// </summary>
        [ConfigurationProperty("DB_Type")]
        public String DB_Type
        {
            get
            { return (String)this["DB_Type"]; }
            set
            { this["DB_Type"] = value; }
        }

        /// <summary>
        /// 得到连接字符串
        /// </summary>
        [ConfigurationProperty("DB_ConnectionString")]
        public String DBConnectionString
        {
            get
            { return (String)this["DB_ConnectionString"]; }
            set
            { this["DB_ConnectionString"] = value; }
        }
 
        [ConfigurationProperty("level", DefaultValue = "0", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 500)]
        public String Level
        {
            get
            { return (String)this["level"]; }
            set
            { this["level"] = value; }
        }

        [ConfigurationProperty("logfilesize", DefaultValue = "0", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 500)]
        public String LogFileSize
        {
            get
            { return (String)this["logfilesize"]; }
            set
            { this["logfilesize"] = value; }
        }

        [ConfigurationProperty("logfilename", DefaultValue = "0", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 500)]
        public String LogFileName
        {
            get
            { return (String)this["logfilename"]; }
            set
            { this["logfilename"] = value; }
        }

        [ConfigurationProperty("currentrevision", DefaultValue = " ", IsRequired = false)]
        [StringValidator(InvalidCharacters = "", MinLength = 1, MaxLength = 500)]
        public String CurrentRevision
        {
            get
            { return (String)this["currentrevision"]; }
            set
            { this["currentrevision"] = value; }
        }

        [ConfigurationProperty("environmentname", DefaultValue = " ", IsRequired = false)]
        [StringValidator(InvalidCharacters = "", MinLength = 1, MaxLength = 500)]
        public String EnvironmentName
        {
            get
            { return (String)this["environmentname"]; }
            set
            { this["environmentname"] = value; }
        }

        [ConfigurationProperty("customername", DefaultValue = " ", IsRequired = false)]
        [StringValidator(InvalidCharacters = "", MinLength = 1, MaxLength = 500)]
        public String CustomerName
        {
            get
            { return (String)this["customername"]; }
            set
            { this["customername"] = value; }
        }

        [ConfigurationProperty("applicationname", DefaultValue = " ", IsRequired = false)]
        [StringValidator(InvalidCharacters = "", MinLength = 1, MaxLength = 500)]
        public String ApplicationName
        {
            get
            { return (String)this["applicationname"]; }
            set
            { this["applicationname"] = value; }
        }

        [ConfigurationProperty("downloadurl", DefaultValue = " ", IsRequired = false)]
        [StringValidator(InvalidCharacters = "", MinLength = 1, MaxLength = 500)]
        public String DownloadURL
        {
            get
            { return (String)this["downloadurl"]; }
            set
            { this["downloadurl"] = value; }
        }

        [ConfigurationProperty("setupfilename", DefaultValue = " ", IsRequired = false)]
        [StringValidator(InvalidCharacters = "", MinLength = 1, MaxLength = 500)]
        public String SetupFileName
        {
            get
            { return (String)this["setupfilename"]; }
            set
            { this["setupfilename"] = value; }
        }

        [ConfigurationProperty("reportingurl", DefaultValue = " ", IsRequired = false)]
        [StringValidator(InvalidCharacters = "", MinLength = 1, MaxLength = 500)]
        public String ReportingURL
        {
            get
            { return (String)this["reportingurl"]; }
            set
            { this["reportingurl"] = value; }
        }

        [ConfigurationProperty("defaultlanguage", DefaultValue = " ", IsRequired = false)]
        [StringValidator(InvalidCharacters = "", MinLength = 1, MaxLength = 500)]
        public String DefaultLanguage
        {
            get
            { return (String)this["defaultlanguage"]; }
            set
            { this["defaultlanguage"] = value; }
        }
    }
}





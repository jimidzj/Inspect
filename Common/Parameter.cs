/**********************************************************************/
/*
 * Define system variables or parameters in this class
 * 
/**********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GENLSYS.MES.Common
{
    public class Parameter
    {
        #region General

        //定义系统的标题
        public static string SYSTEM_TITLE;
        public static string VIRTURE_DIRECT;
        
        //定义系统输出Log的级别
        //目前有4种级别，依次为Admin,Normal,None
        public static string LOGGING_FILE_NAME =string.Empty;
        public static string LOGGING_FILE_SIZE = string.Empty;
        public static Log_LoggingLevel LOGGING_LEVEL;

        public static string LOGON_USER = string.Empty;
        public static string SHIFT = string.Empty;
        public static string WORKGROUP = string.Empty;
        public static string SESSION_ID = string.Empty;
        public static bool SESSION_LOCKED = false;
        public static string LANGUAGE = string.Empty;

        public static DataTable ALL_FUNCTIONS;
        public static DataTable USER_FUNCTIONS;
        public static DataTable USER_STEPS;

        public static string FUNC_SEPARATOR = "_";
        public static string MENU_STRING_PARAMETERS = string.Empty;
        public static List<string> MENU_PARAMETERS = new List<string>();

        public static int SEQNO_FIRST = 10;
        public static string FUTACT_TEMPLATE = "WaitingFor";
        
        public static string CURRENT_LOTSYSID = string.Empty;
        public static string CURRENT_EQPSYSID = string.Empty;
        public static string CURRENT_LOTID = string.Empty;
        public static decimal CURRENT_STEPUID = -1;    
        #endregion

        public static string MES_DATABASE_CONNECTION = string.Empty;
        
        public static object MAIN_FORM_WIPCLIENT = null;
        public static object MAIN_FORM_MODELING = null;
        public static object LOGON_FORM = null;

        public static object CURRENT_SYSTEM_CONFIG = null;
        public static object CURRENT_STATIC_VALUE = null;
        public static object CURRENT_USER_OBJECTS = null;

        public static string DATE_FORMAT = "yyyy-MM-dd";
        public static string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public static bool ApplicationExitFlag = false;

        public static object CURRENT_SESSIONS = null;
        public static object CURRENT_IPCONTROL = null;
        public static object CURRENT_USER_OBJECT= null;

        public static string CURRENT_ENVIRONMENT = string.Empty;
        public static string CURRENT_VERSION = string.Empty;
    }
}

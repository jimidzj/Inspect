/**********************************************************************/
/*
 * Define system constanct in this class
 * 
/**********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GENLSYS.MES.Common
{
    public class Constant
    {
        //系统参数

        //系统内的值常量
        public const string APPLICATION_ALL = "ALL";

        public const string SPLITLABEL = "@@@";
        public const string SPLITDBERRORMSG = "@@";
        public const string SPLITDATAFIELD = "|";
        public const string NULLSTRING = "NA";

        public static string JOB_DATAMAP_SCHDULE_MDL = "SCHEDULE_MDL";
        public static string JOB_DATAMAP_TASK_MDL = "TASK_MDL";
        public static string JOB_DATAMAP_LOG = "LOG";

        //系统参数
        public const DayOfWeek FRIST_DAYOFWEEK = DayOfWeek.Monday;
        public const DayOfWeek LAST_DAYOFWEEK = DayOfWeek.Friday;

        //MES
        public const int RULE_INDEX_SEQNO_INCREMENT = 10;
        public const int CHILDLOT_ID_EXT_LENGTH = 2;

        public const string SESSION_CULTURE = "CURRENT_CULTURE";
        public const string SESSION_AUTHORIZATION = "CURRENT_AUTH";
        public const string SESSION_ALL_FUNCTION = "ALL_FUNCTION";
        public const string SESSION_USER_FUNCTION = "USER_FUNCTION";
        public const string SESSION_CURRENT_USER = "CURRENT_USER";
        public const string SESSION_CURRENT_ADUSER = "CURRENT_ADUSER";
    }
}

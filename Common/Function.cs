/**********************************************************************/
/*
 * Define public functions used in solution in this class
 * 
/**********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Xml;
using System.Reflection;
using System.Linq;

namespace GENLSYS.MES.Common
{
    public class Function
    {
        /// <summary>
        /// Get a new GUID
        /// </summary>
        /// <returns></returns>
        public static string GetGUID()
        {
            return System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Get Business transaction ID  
        /// </summary>
        /// <returns></returns>
        public static string GetBusinessTransactionID ()
        {
            return System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Get 16 byte short string ID based on GUID
        /// </summary>
        /// <returns></returns>
        public static string GetShortStringID()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        /// <summary>
        /// Get number ID based on GUID
        /// </summary>
        /// <returns></returns>
        public static Int64 GetNumberID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// Get MSSql sysdate, used in SQL string
        /// </summary>
        /// <returns></returns>
        public static string GetMSSqlSystemDate()
        {
            return "getdate()";
        }

        /// <summary>
        /// Get Oracle sysdate, used in SQL string
        /// </summary>
        /// <returns></returns>
        public static string GetOracleSystemDate()
        {
            return "sysdate";
        }

        /// <summary>
        /// Get system time, you can format it here
        /// </summary>
        /// <returns></returns>
        public static DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// If the value of datatime field is empty, 
        /// replace it with '1900-01-01 00:00:00'
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNullDateTime()
        {
            return DateTime.Parse("1900-01-01 00:00:00");
        }

        public static DateTime GetNullableDateTime()
        {
            Nullable<DateTime> nullDate = null;
            return Convert.ToDateTime(nullDate);
        }

        /// <summary>
        /// if the value of datatime field is '1900-01-01 00:00:00'
        /// replace it with null
        /// </summary>
        /// <param name="_ds"></param>
        public static void SetNullDateTime(DataSet _ds)
        {
            for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < _ds.Tables[0].Columns.Count; j++)
                {
                    object obj = _ds.Tables[0].Rows[i][j];
                    if (obj is DateTime && (obj.Equals(Function.GetNullDateTime()) || obj.Equals(DateTime.MinValue)))
                    {
                        _ds.Tables[0].Rows[i][j] = DBNull.Value;
                    }

                }
            }
        }

        /// <summary>
        /// Return current login user, from AD
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUser()
        {
            string user = string.Empty;// HttpContext.Current.Session[Constant.SESSION_CURRENT_USER] as string;
            if (!string.IsNullOrEmpty(user))
            {
                int index = user.IndexOf("\\");
                if (index >= 0)
                {
                    user = user.Substring(index + 1);
                }
                return user;
            }
            return Parameter.LOGON_USER;
            //return "Admin";
        }

        public static string GetExceptionMsg(string str)
        {
            string result = str;
            if (result.IndexOf("@@") >= 0)
            {
                result = Regex.Split(result, "@@")[1];
            }
            return result;
        }

        public static int GetWeekOfYear(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        public static int GetWeekAmount(int year)
        {
            DateTime end = new DateTime(year, 12, 31);  //该年最后一天
            System.Globalization.GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(end, CalendarWeekRule.FirstDay, DayOfWeek.Monday);  //该年星期数
        }

        public static DateTime AddWeeks(DateTime dt, int weeks)
        {
            System.Globalization.GregorianCalendar gc = new GregorianCalendar();
            return gc.AddWeeks(dt, weeks);
        }

        public static string GenerateAlarmXmlString(string subject, string recipients, string bodyText)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlNode node;
                XmlText textNode;

                XmlNode root = doc.CreateNode(XmlNodeType.Element, "Alarms", "");

                XmlNode alarmNode = doc.CreateNode(XmlNodeType.Element, "Alarm", "");

                root.AppendChild(alarmNode);

                node = doc.CreateNode(XmlNodeType.Element, "AlarmType", "");
                textNode = doc.CreateTextNode("Email");
                node.AppendChild(textNode);
                alarmNode.AppendChild(node);

                node = doc.CreateNode(XmlNodeType.Element, "Subject", "");
                textNode = doc.CreateTextNode(subject);
                node.AppendChild(textNode);
                alarmNode.AppendChild(node);

                node = doc.CreateNode(XmlNodeType.Element, "Recipients", ""); 
                textNode = doc.CreateTextNode(recipients);
                node.AppendChild(textNode);
                alarmNode.AppendChild(node);

                node = doc.CreateNode(XmlNodeType.Element, "CC", "");
                alarmNode.AppendChild(node);

                node = doc.CreateNode(XmlNodeType.Element, "BodyText", "");
                textNode = doc.CreateTextNode(bodyText);
                node.AppendChild(textNode);
                alarmNode.AppendChild(node);

                node = doc.CreateNode(XmlNodeType.Element, "Comments", "");
                alarmNode.AppendChild(node);

                node = doc.CreateNode(XmlNodeType.Element, "Application", "");
                textNode = doc.CreateTextNode("PP");
                node.AppendChild(textNode);
                alarmNode.AppendChild(node);

                node = doc.CreateNode(XmlNodeType.Element, "Creator", "");
                textNode = doc.CreateTextNode("PP System");  
                node.AppendChild(textNode);
                alarmNode.AppendChild(node);

                node = doc.CreateNode(XmlNodeType.Element, "CreatedTime", "");
                textNode = doc.CreateTextNode(Function.GetCurrentTime().ToString("yyyy-MM-dd HH:mm:ss"));
                node.AppendChild(textNode);
                alarmNode.AppendChild(node);

                doc.AppendChild(root);
                return doc.OuterXml;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetValueToObject<T>(T obj, Dictionary<string, object> dic) where T : class
        {
            foreach (KeyValuePair<string, object> kvp in dic)
            {
                PropertyInfo prop = typeof(T).GetProperty(kvp.Key);
                if (prop != null)
                {
                    prop.SetValue(obj, kvp.Value, null);
                }
            }
        }

        public static T CopyObject<T>(T obj) where T : class
        {
            ConstructorInfo ct = typeof(T).GetConstructor(System.Type.EmptyTypes);
            T newObj = (T)ct.Invoke(null);
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (!prop.Name.Equals("EntityState"))
                {
                    prop.SetValue(newObj, prop.GetValue(obj, null), null);
                }
            }
            return newObj;
        }

        public static string GetWaferString(List<string> lstWafer)
        {
            return GetWaferString(lstWafer,",");
        }

        public static string GetWaferString(List<string> lstWafer,string splitStr)
        {
            string result = string.Empty;
            List<string> lst = new List<string>();
            foreach (string str in lstWafer)
            {
                int index = str.LastIndexOf('-');
                if (index >= 0)
                {
                    lst.Add(str.Substring(index + 1));
                }
                else
                {
                    lst.Add(str);
                }
            }

            var q = (from p in lst
                     orderby Convert.ToInt16(p) ascending
                     select new
                     {
                         WaferNum = Convert.ToInt16(p),
                         WaferId = p.PadLeft(2, '0')
                     }).ToList();

            int tmpNum = -1;
            string tmpId = string.Empty;
            int seqCount = 0;
            for (int i = 0; i < q.Count; i++)
            {
                if (result == string.Empty)
                {
                    result += q[i].WaferId;
                    tmpNum = q[i].WaferNum;
                    tmpId = q[i].WaferId;
                    seqCount = 1;
                    continue;
                }
                if (tmpNum + 1 == q[i].WaferNum)
                {
                    tmpNum = q[i].WaferNum;
                    tmpId = q[i].WaferId;
                    seqCount++;
                }
                else
                {
                    if (seqCount > 1)
                    {
                        result += "-" + tmpId + splitStr + q[i].WaferId;
                    }
                    else
                    {
                        result += splitStr + q[i].WaferId;
                    }
                    tmpNum = q[i].WaferNum;
                    tmpId = q[i].WaferId;
                    seqCount = 1;
                }
            }

            if (seqCount > 1)
            {
                result += "-" + tmpId;
            }
            return result;
        }

        public static string convertStepToWipStatus(string step)
        {
            string status = null;
            if (step.Equals(MES_Step.Inspection.ToString()))
            {
                status = MES_WIPStatus.I.ToString();
            }
            else if (step.Equals(MES_Step.XRay.ToString()))
            {
                status = MES_WIPStatus.X.ToString();
            }
            return status;
        }
        //public static bool CheckLotStatusBeforeAction(string lotStatus, string action)
        //{
        //    bool result = false;
        //    if (action.Trim().EndsWith(MES_Events.UpdateCPLot.ToString()) || action.Trim().EndsWith(MES_Events.DeleteCPLot.ToString()))
        //    {
        //        if (lotStatus.Trim().Equals(MES_WIPStatus.Created.ToString()))
        //        {
        //            return true;
        //        }
        //    }
        //    return result;
        //}

        /******************************************
         * Add Method by Jane
         * ****************************************/
        #region --GetWeek--
        public static string GetWeek(DateTime p_time_id)
        {
            string week = WeekOfYear(p_time_id).ToString();
            //return p_time_id.Year + week.PadLeft(2, '0');
            return "ww" + week.PadLeft(2, '0');
        }

        //周五--下周四为一周（包括周六，周日），即周五是第一天，下周四为最后一天
        public static int GetWeekOfYearByFriday(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Friday);
        }

        public static int WeekOfYear(DateTime p_Date)
        {
            System.Globalization.CultureInfo myCI = new System.Globalization.CultureInfo("zh-CN");

            System.Globalization.Calendar myCal = myCI.Calendar;

            System.Globalization.CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;

            DayOfWeek myFirstDOW = DayOfWeek.Monday;

            int wd = myCal.GetWeekOfYear(p_Date, myCWR, myFirstDOW);

            return wd;
        }
        public static bool isNumber(String str)
        {
            if(str!=null&&str.Length>0)
            {
                int len = str.Length;
                for(int i=0;i<len;i++)
                {
                    char c = str[i];
                    if(c<'0'||c>'9')
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        #endregion
    }
}

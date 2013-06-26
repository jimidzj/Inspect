using System;
using System.Collections.Generic;
using System.Text;

namespace GENLSYS.MES.Utility
{
    public sealed class UtilDatetime
    {
        public static string FormatDate1(DateTime _datetime)
        {
            string format = "yyyy-MM-dd";
            return _datetime.ToString(format);
        }

        public static string FormatTime1(DateTime _datetime)
        {
            string format = "HH:mm:ss";
            return _datetime.ToString(format);
        }

        public static string FormateDateTime1(DateTime _datetime)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            return _datetime.ToString(format);
        }

        public static string FormatDate2(DateTime _datetime)
        {
            string format = "yyyy/MM/dd";
            return _datetime.ToString(format);
        }

        public static string FormatTime2(DateTime _datetime)
        {
            string format = "HH:mm:ss";
            return _datetime.ToString(format);
        }

        public static string FormateDateTime2(DateTime _datetime)
        {
            string format = "yyyy/MM/dd HH:mm:ss";
            return _datetime.ToString(format);
        }

        public static string FormatDate3(DateTime _datetime)
        {
            string format = "yyyyMMdd";
            return _datetime.ToString(format);
        }

        public static string FormatTime3(DateTime _datetime)
        {
            string format = "HHmmss";
            return _datetime.ToString(format);
        }

        public static string FormatDateTime3(DateTime _datetime)
        {
            string format = "yyyyMMdd HH:mm:ss";
            return _datetime.ToString(format);
        }

        public static string FormatDateTime4(DateTime _datetime)
        {
            string format = "yyyyMMddHHmmss";
            return _datetime.ToString(format);
        }

        public static string FormatDateTime5(DateTime _datetime)
        {
            string format = "yyyyMMddHHmmssfff";
            return _datetime.ToString(format);
        }

        public static string FormatDateTime6(DateTime _datetime)
        {
            string format = "yyyyMMddHHmm";
            return _datetime.ToString(format);
        }
    }

}

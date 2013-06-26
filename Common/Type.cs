/**********************************************************************/
/*
 * Define enum,structure,type in this class
 * 
/**********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GENLSYS.MES.Common
{

    #region Parameter Item
    [Serializable]
    public class ParameterItem
    {
        public ParameterItem()
        {
        }

        public string ParameterName;
        public object ParameterValue;

        public ParameterItem(string parameter_name, object parameter_value)
        {
            ParameterName = parameter_name;
            ParameterValue = parameter_value;
        }
    }
    #endregion Parameter Item

    #region ReturnValue
    public class ReturnValue
    {
        private int _code;
        private string _text;

        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public ReturnValue()
        {
        }

        public ReturnValue(int code)
        {
            _code = code;
            _text = "";
        }

        public ReturnValue(string text)
        {
            _code = -1;
            _text = text;
        }

        public ReturnValue(int code, string text)
        {
            _code = code;
            _text = text;
        }
    }

    #endregion Return Value
    
    #region MonthWeek
    public class MonthWeek
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public int Week { get; set; }

        public MonthWeek()
        {
           Week = 0;
        }
    }
    #endregion
}

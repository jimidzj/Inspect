using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections;

namespace GENLSYS.MES.DataContracts.Common
{
    [Serializable]
    public class MESParameterInfo
    {
        //Now, for exporting Excel
        public string ParamDisplayName { set; get; }
        public string ParamName { set; get; }        
        public string ParamValue { get; set; }
        //public string IsPrimaryKey { get; set; }
        public string ParamOldValue { get; set; }
        public string ParamType { get; set; }

        public MESParameterInfo() 
        {
            ParamType = "string";
            ParamName = string.Empty;
            ParamValue = string.Empty;
        }

        public static List<MESParameterInfo> ObejctToColumnInfoList(object obj)
        {
            List<MESParameterInfo> list = new List<MESParameterInfo>();
            foreach (PropertyInfo p in obj.GetType().GetProperties())
            {
                list.Add(new MESParameterInfo() { ParamName = p.Name, ParamValue = p.GetValue(obj, null).ToString() });
            }
            return list;

        }

        public static List<MESParameterInfo> HashtableToColumnInfoList(Hashtable ht)
        {
            List<MESParameterInfo> list = new List<MESParameterInfo>();
            foreach(DictionaryEntry de in ht){
                list.Add(new MESParameterInfo() { ParamName =de.Key.ToString(), ParamValue = de.Value.ToString() });
            }
            return list;

        }

        public static string GetColumnValue(List<MESParameterInfo> list, string columnName)
        {
            string result = null;
            for (int i = 0; i < list.Count; i++)
            {
                MESParameterInfo col = list[i];
                if (col.ParamName.Equals(columnName))
                {
                    result = col.ParamValue;
                }
            }
            return result;
        }

        public static MESParameterInfo GetColumnInfoByName(List<MESParameterInfo> list, string columnName)
        {
            MESParameterInfo result = null;
            for (int i = 0; i < list.Count; i++)
            {
                MESParameterInfo col = list[i];
                if (col.ParamName.Equals(columnName))
                {
                    result = col;
                }
            }
            return result;
        }

        public static List<MESParameterInfo> SetColumnValue(List<MESParameterInfo> list, string columnName, string columnValue)
        {
            for (int i = 0; i < list.Count; i++)
            {
                MESParameterInfo col = list[i];
                if (col.ParamName.Equals(columnName))
                {
                    col.ParamValue = columnValue;
                }
            }
            return list;
        }

        public static List<MESParameterInfo> RemoveColumnInfo(List<MESParameterInfo> list, string columnName)
        {
            for (int i = 0; i < list.Count; i++)
            {
                MESParameterInfo col = list[i];
                if (col.ParamName.Equals(columnName))
                {
                    list.Remove(col);
                }
            }
            return list;
        }

        public static List<List<MESParameterInfo>> DataTableToList(DataTable dt)
        {
            List<List<MESParameterInfo>> result = new List<List<MESParameterInfo>>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List<MESParameterInfo> list = new List<MESParameterInfo>();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    MESParameterInfo col = new MESParameterInfo();
                    col.ParamName = dt.Columns[j].ColumnName.ToLower(); ;
                    col.ParamValue = dt.Rows[i][dt.Columns[j]].ToString();
                    list.Add(col);
                }
                result.Add(list);
            }
            return result;
        }

        public static List<MESParameterInfo> DataTableToList(DataRow row)
        {
            List<MESParameterInfo> result = new List<MESParameterInfo>();
            DataTable dt = row.Table;
            for (int i = 0; i <dt.Columns.Count; i++)
            {
                MESParameterInfo col = new MESParameterInfo();
                col.ParamName = dt.Columns[i].ColumnName.ToLower(); ;
                col.ParamValue = row[dt.Columns[i]].ToString();
                result.Add(col);
            }
            return result;
        }

        public static List<MESParameterInfo> GetOneColumnInfoList(List<List<MESParameterInfo>> list,List<MESParameterInfo> keys)
        {
            List<MESParameterInfo> result =new List<MESParameterInfo>();
            foreach (List<MESParameterInfo> colList in list)
            {
                bool flag = true;
                foreach (MESParameterInfo key in keys)
                {
                    if (!GetColumnValue(colList, key.ParamName).Equals(key.ParamValue))
                    {
                        flag = false;
                    }
                }
                if (flag == true)
                {
                    result = colList;
                    break;
                }
            }
            return result;
        }

        public static List<List<MESParameterInfo>> GetInColumnInfoList(List<List<MESParameterInfo>> fList, List<List<MESParameterInfo>> sList, string[] keyArr)
        {
            List<List<MESParameterInfo>> result = new List<List<MESParameterInfo>>();
            foreach (List<MESParameterInfo> colList in fList)
            {
                List<MESParameterInfo> keys = new List<MESParameterInfo>();
                foreach (string keyStr in keyArr)
                {
                    keys.Add(GetColumnInfoByName(colList,keyStr));
                }
                if (GetOneColumnInfoList(sList, keys).Count > 0)
                {
                    result.Add(colList);
                }
            }
            return result;
        }

        public static List<List<MESParameterInfo>> GetNotInColumnInfoList(List<List<MESParameterInfo>> fList, List<List<MESParameterInfo>> sList, string[] keyArr)
        {
            List<List<MESParameterInfo>> result = new List<List<MESParameterInfo>>();
            foreach (List<MESParameterInfo> colList in fList)
            {
                List<MESParameterInfo> keys = new List<MESParameterInfo>();
                foreach (string keyStr in keyArr)
                {
                    keys.Add(GetColumnInfoByName(colList, keyStr));
                }
                if (GetOneColumnInfoList(sList, keys).Count == 0)
                {
                    result.Add(colList);
                }
            }
            return result;
        }


        public static string ConvertColumnInfoToString(List<MESParameterInfo> _parameters)
        {
            string re = string.Empty;
            for (int i = 0; i < _parameters.Count; i++)
            {
                re += (re == string.Empty ? "" : ",") + _parameters[i].ParamName + ":" + _parameters[i].ParamValue;
            }
            return re;
        }

        public static List<MESParameterInfo> CopyColumnInfoList(List<MESParameterInfo> list)
        {
            List<MESParameterInfo> result = new List<MESParameterInfo>();
            foreach (MESParameterInfo col in list)
            {
                result.Add(new MESParameterInfo() { ParamName=col.ParamName,ParamValue=col.ParamValue,ParamType=col.ParamType});
            }
            return result;
        }
    }
}

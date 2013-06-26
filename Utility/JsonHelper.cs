using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GENLSYS.MES.Utility
{
    public class JsonHelper
    {
        /// <summary>
        /// Toes the json.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 08-10-20 15:29
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static string toJson(DataTable table)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(getJsonListByRow(row, table.Columns, "yyyyMMdd"));
            }

            return GetJsonString(table.Rows.Count,JavaScriptConvert.SerializeObject(list));
        }

        /// <summary>
        ///Datatable to json string
        /// </summary>
        public static string toJson4Java(DataTable table)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(getJsonListByRow(row, table.Columns, "yyyyMMdd"));
            }

            String josnstr = JavaScriptConvert.SerializeObject(list);
            string rs = josnstr.Replace("\"", "");
            return rs;
        }

        /// <summary>
        /// Toes the data table.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 08-11-11 21:43
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static DataTable toDataTable(string json)
        {
            DataTable jsonTable = new DataTable();

            List<Dictionary<string, string>> list = JavaScriptConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

            if (list != null && list.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in list[0])
                {
                    jsonTable.Columns.Add(new DataColumn() { ColumnName = kvp.Key });
                }

                foreach (Dictionary<string, string> dic in list)
                {
                    DataRow dataRow = jsonTable.NewRow();

                    foreach (KeyValuePair<string, string> kvp in dic)
                    {
                        dataRow[kvp.Key] = kvp.Value;
                    }

                    jsonTable.Rows.Add(dataRow);
                }
            }

            return jsonTable;
        }
        /// <summary>
        /// Toes the json.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-9-1 16:17
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks> 
        public static string toJson(DataTable table, int total)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(getJsonListByRow(row, table.Columns, "yyyyMMdd"));
            }

            return GetJsonString(total, JavaScriptConvert.SerializeObject(list));
        }

        /// <summary>
        /// Toes the json.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="total">The total.</param>
        /// /// <param name="dateformat">Date format.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-10-22 16:17
        /// Created By: Jame 
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks> 
        public static string toJson(DataTable table, int total,string dateformat)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(getJsonListByRow(row, table.Columns, dateformat));
            }

            return GetJsonString(total, JavaScriptConvert.SerializeObject(list));
        }

        /// <summary>
        /// Toes the json.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns></returns>
        /// <Remarks
        /// Created Time: 2008-9-1 16:17
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static string toJson(DataTable table, int start, int end)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            int startIndex = Math.Min(start, table.Rows.Count);
            int endIndex = Math.Max(startIndex, Math.Min(end, table.Rows.Count));
            int total = endIndex - startIndex;

            for (int i = startIndex; i < endIndex; i++)
            {
                DataRow row = table.Rows[i];
                list.Add(getJsonListByRow(row, table.Columns, "yyyyMMdd"));
            }
            return GetJsonString(total, JavaScriptConvert.SerializeObject(list));
        }

        /// <summary>
        /// Toes the json with time.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-9-1 16:17
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static string toJsonWithTime(DataTable table, int total)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(getJsonListByRow(row, table.Columns, "yyyyMMdd H:mm:ss"));
            }
            return GetJsonString(total, JavaScriptConvert.SerializeObject(list));
        }

        /// <summary>
        /// Gets the json list by row.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 08-10-14 12:38
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static Dictionary<string, string> getJsonListByRow(DataRow row, DataColumnCollection columns, string format)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (DataColumn column in columns)
            {
                string columnName = column.ColumnName.ToLower();
                object value = row[column];
                string valueString = string.Empty;

                if (column.DataType.FullName.Equals("System.DateTime") && !value.ToString().Equals(string.Empty))
                {
                    valueString = ((DateTime)value).ToString(format);
                }
                else if (column.DataType.FullName.Equals("System.Decimal") && !value.ToString().Equals(string.Empty))
                {
                    valueString = GetDecimalString(value, columnName);
                }
                else
                {
                    valueString = value.ToString();
                }
                dic.Add(columnName, valueString);
            }

            return dic;
        }

        /// <summary>
        /// Gets the decimal string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="builder">The builder.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <Remarks>
        /// Created Time: 2008-9-1 16:17
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        private static string GetDecimalString(object value, string columnName)
        {
            int x = value.ToString().IndexOf('.') > 0 ? value.ToString().IndexOf('.') : 0;
            x = x == 0 ? 0 : value.ToString().Length - x - 1;
            return string.Format("{0:N" + x.ToString() + "}", value);
        }

        /// <summary>
        /// Gets the json string.
        /// </summary>
        /// <param name="total">The total.</param>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 08-10-14 11:38
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        private static string GetJsonString(int total, string json)
        {
            return "{results:" + total + ",rows:" + json + "}";
        }
    }
}

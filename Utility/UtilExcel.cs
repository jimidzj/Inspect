using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Utility
{

    /// <summary>
    /// 
    /// </summary>
    /// <Remarks>
    /// Created Time: 2008-8-4 10:59
    /// Created By: jack_que
    /// Last Modified Time:  
    /// Last Modified By: 
    /// </Remarks>
    public class UtilExcel
    {

        /// <summary>
        /// Exports the specified response.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="myPageName">Name of my page.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="ds">The ds.</param>
        /// <Remarks>
        /// Created Time: 2008-8-4 10:59
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static void Export(HttpResponseBase response, string myPageName, List<MESParameterInfo> columns, DataSet ds)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\Excel\" + myPageName + ".xls";

            response.Clear();
            response.Buffer = true;
            response.Charset = "utf-8";
            response.AppendHeader("Content-Disposition", "attachment;filename=" + myPageName + ".xls");
            response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            response.ContentType = "application/ms-excel";

            ExcelWriter excel = new ExcelWriter(path);
            try
            {
                excel.BeginWrite();

                short row = 0;

                for (short k = 0; k < columns.Count; k++)
                {
                    excel.WriteString(row, k, columns[k].ParamDisplayName);
                }

                DataTable dt = ds.Tables[0];

                for (short i = 0; i < dt.Rows.Count; i++)
                {
                    row++;
                    for (short j = 0; j < columns.Count; j++)
                    {
                        MESParameterInfo column = columns[j];
                        string columnType = column.ParamType;
                        string columnName = column.ParamName;
                        object value = ds.Tables[0].Rows[i][columnName];

                        if (columnType != null && columnType.Equals("date"))
                        {
                            value = value.ToString().Split(new char[] { ' ' }, StringSplitOptions.None)[0];
                        }
                        excel.WriteString(row, j, value.ToString());
                    }
                }
            }
            finally
            {
                excel.EndWrite();
            }

            FileInfo file = new FileInfo(path);

            if (file.Exists)
            {
                response.WriteFile(path);
                response.Flush();
                file.Delete();
            }
        }

        /// <summary>
        /// Exports to excel with out header.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="myPageName">Name of my page.</param>
        /// <param name="ds">The ds.</param>
        /// <Remarks>
        /// Created Time: 08-12-24 14:20
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static void ExportToExcelWithOutHeader(HttpResponseBase response, string myPageName, DataSet ds)
        {
            response.Clear();
            response.Buffer = true;
            response.Charset = "utf-8";
            response.AppendHeader("Content-Disposition", "attachment;filename=Sheet1.xls" );
            response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            response.ContentType = "application/ms-excel";
            //response.ContentType = "text/csv";

            StringBuilder builder = new StringBuilder();
            builder.Append("<html><meta http-equiv='Content-Type' content='text/html; charset=utf-8'>")
                  .Append("<body><table width='100%' border='1'><tr bgcolor='gray' style='COLOR: white'>");

            foreach (DataColumn column in ds.Tables[0].Columns)
            {
                builder.Append("<td align='center'>").Append(column.ColumnName.ToLower()).Append("</td>");
            }
            builder.Append("</tr>");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                builder.Append("<tr>");
                foreach (DataColumn column in ds.Tables[0].Columns)
                {
                    builder.Append("<td>").Append(row[column].ToString()).Append("</td>");
                }
                builder.Append("</tr>");
            }
            builder.Append("</table></body></html>");
            response.Output.Write(builder.ToString());
        }
        /// <summary>
        /// Exports to excel.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="myPageName">Name of my page.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="ds">The ds.</param>
        /// <Remarks>
        /// Created Time: 2008-8-4 9:46
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static void ExportToExcel(HttpResponseBase response, string myPageName, List<MESParameterInfo> columns, DataSet ds,bool usedAlias)
        {
            string FileName = myPageName + ".xls";

            response.Clear();
            response.Buffer = true;
            response.Charset = "utf-8";
            response.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
            string ss = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            response.ContentType = "application/ms-excel";

            StringBuilder builder = new StringBuilder();
            builder.Append("<html><meta http-equiv='Content-Type' content='text/html; charset=utf-8'>")
                  .Append("<body><table width='100%' border='1'><tr bgcolor='gray' style='COLOR: white'>");

            for (int k = 0; k < columns.Count; k++)
            {
                string name = (usedAlias ? columns[k].ParamDisplayName : columns[k].ParamName);
                builder.Append("<td align='center'>").Append(name).Append("</td>");
            }
            builder.Append("</tr>");

            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                builder.Append("<tr>");
                for (int j = 0; j < columns.Count; j++)
                {
                    MESParameterInfo column = columns[j];
                    string columnType = column.ParamType;
                    string columnName = column.ParamName;
                    object value = ds.Tables[0].Rows[i][columnName];

                    if (columnType != null && columnType.Equals("date"))
                    {
                        value = value.ToString().Split(new char[] { ' ' }, StringSplitOptions.None)[0];
                    }
                    builder.Append("<td>").Append(value.ToString()).Append("</td>");

                }
                builder.Append("</tr>");
            }
            builder.Append("</table></body></html>");

            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            response.Output.Write(builder.ToString());
        }

        public static void ExportToExcel(HttpResponseBase response, string myPageName, List<MESParameterInfo> columns, DataSet ds)
        {
            ExportToExcel(response, myPageName, columns, ds,true);
        }

        /// <summary>
        /// Exports to excel.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="myPageName">Name of my page.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="list">The list.</param>
        /// <Remarks>
        /// Created Time: 2008-7-8 15:40
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static void ExportToExcel(HttpResponseBase response, string myPageName, List<MESParameterInfo> columns,List<Dictionary<string,string>> list)
        {
            string FileName = myPageName + ".xls";

            response.Clear();
            response.Buffer = true;
            response.Charset = "utf-8";
            response.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
            string ss = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            response.ContentType = "application/ms-excel";

            StringBuilder builder = new StringBuilder();
            builder.Append("<html><meta http-equiv='Content-Type' content='text/html; charset=utf-8'>")
                  .Append("<body><table width='100%' border='1'><tr bgcolor='gray' style='COLOR: white'>");

            for (int k = 0; k < columns.Count; k++)
            {
                builder.Append("<td align='center'>").Append(columns[k].ParamDisplayName).Append("</td>");
            }
            builder.Append("</tr>");

            for (int i = 0; i < list.Count; i++)
            {
                Dictionary<string, string> dic = list[i];
                builder.Append("<tr>");
                for (int j = 0; j < columns.Count; j++)
                {
                    MESParameterInfo column = columns[j];
                    string columnType = column.ParamType;
                    string columnName = column.ParamName;
                    string value = dic[columnName];

                    if (columnType != null && columnType.Equals("date"))
                    {
                        value = value.Split(new char[] { ' ' }, StringSplitOptions.None)[0];
                    }

                    builder.Append("<td>").Append(value.ToString()).Append("</td>");

                }
                builder.Append("</tr>");
            }
            builder.Append("</table></body></html>");
            response.Output.Write(builder.ToString());
        }
    }
}

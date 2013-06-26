using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GENLSYS.MES.Utility.Database
{
   public static class DataHelper
   {
       /// <summary>
       /// Gets the type of the column.
       /// </summary>
       /// <param name="javascriptType">Type of the javascript.</param>
       /// <returns></returns>
       /// <Remarks>
       /// Created Time: 2008-6-11 13:48
       /// Created By: jack_que
       /// Last Modified Time:  
       /// Last Modified By: 
       /// </Remarks>
       public static Type getColumnType(string javascriptType)
       {
           if (javascriptType.Equals("datetime"))
           {
               return Type.GetType("System.DateTime");
           }
           else if (javascriptType.Equals("int"))
           {
               return Type.GetType("System.Int32");
           }
           else if (javascriptType.Equals("float"))
           {
               return Type.GetType("System.Single");
           }
           else
           {
               return Type.GetType("System.String");
           }
       }

       /// <summary>
       /// Mappings the type of the net.
       /// </summary>
       /// <param name="netType">Type of the net.</param>
       /// <returns></returns>
       /// <Remarks>
       /// Created Time: 2008-6-25 19:54
       /// Created By: jack_que
       /// Last Modified Time:  
       /// Last Modified By: 
       /// </Remarks>
       public static  SqlDbType MappingNetType(string javascriptType)
       {
           if (javascriptType.Equals("System.DateTime") || javascriptType.Equals("datetime"))
           {
               return SqlDbType.DateTime;
           }
           else if (javascriptType.Equals("int") || javascriptType.Equals("System.Int32"))
           {
               return SqlDbType.Int;
           }
           else if (javascriptType.Equals("float") || javascriptType.Equals("System.Single"))
           {
               return SqlDbType.Decimal;
           }
           else
           {
               return SqlDbType.VarChar;
           }
       }

       /// <summary>
       /// Gets the SQL values.
       /// </summary>
       /// <param name="javascriptType">Type of the javascript.</param>
       /// <param name="value">The value.</param>
       /// <returns></returns>
       /// <Remarks>
       /// Created Time: 2008-6-11 13:48
       /// Created By: jack_que
       /// Last Modified Time:  
       /// Last Modified By: 
       /// </Remarks>
       public static string GetSqlValues(string javascriptType, string value)
       {
           StringBuilder builer = new StringBuilder();

           if (javascriptType.Equals("string"))
           {
               builer.Append("'").Append(value).Append("'");
           }
           else if (javascriptType.Equals("datetime"))
           {
               if (value.Equals(string.Empty))
               {
                   builer.Append("null");
               }
               else
               {
                   builer.Append("to_date('" + value + "','yyyy-MM-dd hh24:mi:ss')");
               }

           }
           else if (javascriptType.Equals("int") || javascriptType.Equals("float"))
           {
               if (value.Equals(string.Empty))
               {
                   builer.Append("null");
               }
               else
               {
                   builer.Append(Convert.ToDouble(value));
               }
           }

           return builer.ToString();
       }

       /// <summary>
       /// Gets the SQL values.
       /// </summary>
       /// <param name="columnType">Type of the column.</param>
       /// <param name="value">The value.</param>
       /// <returns></returns>
       /// <Remarks>
       /// Created Time: 2008-6-11 13:48
       /// Created By: jack_que
       /// Last Modified Time:  
       /// Last Modified By: 
       /// </Remarks>
       public static string GetSqlValues(Type columnType, string value)
       {
           StringBuilder builer = new StringBuilder();

           if (columnType.Equals(Type.GetType("System.String")))
           {
               builer.Append("'").Append(value).Append("'");
           }
           else if (columnType.Equals(Type.GetType("System.DateTime")))
           {
               if (value.Equals(string.Empty))
               {
                   builer.Append("null");
               }
               else
               {
                   builer.Append("to_date('" + value + "','yyyy-MM-dd hh24:mi:ss')");
               }

           }
           else if (columnType.Equals(Type.GetType("System.Int32"))
                                       || columnType.Equals(Type.GetType("System.Single"))
                                       || columnType.Equals(Type.GetType("System.Decimal"))
                                       || columnType.Equals(Type.GetType("System.Double")))
           {
               if (value.Equals(string.Empty))
               {
                   builer.Append("null");
               }
               else
               {
                   builer.Append(Convert.ToDecimal(value));
               }
           }
           else
           {
               builer.Append(value);
           }

           return builer.ToString();
       }

       /// <summary>
       /// Gets the SQL values.
       /// </summary>
       /// <param name="oracleType">Type of the oracle.</param>
       /// <param name="value">The value.</param>
       /// <returns></returns>
       /// <Remarks>
       /// Created Time: 2008-6-13 17:55
       /// Created By: jack_que
       /// Last Modified Time:  
       /// Last Modified By: 
       /// </Remarks>
       public static object GetSqlValues(SqlDbType oracleType, string value)
       {
           if (value.Equals(string.Empty))
           {
               return Convert.DBNull;
           }
           if (oracleType.Equals(SqlDbType.DateTime))
           {
               return Convert.ToDateTime(value);
           }
           if (oracleType.Equals(SqlDbType.Int))
           {
               return Convert.ToInt32(value);
           }

           if (oracleType.Equals(SqlDbType.Decimal))
           {
               return Convert.ToSingle(value);
           }
           return value;
       }
    }
}

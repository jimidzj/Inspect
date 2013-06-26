using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;

namespace GENLSYS.MES.Utility.Database
{
    /// <summary>
    /// 
    /// </summary>
    /// <Remarks>
    /// Created Time: 2008-6-11 13:47
    /// Created By: jack_que
    /// Last Modified Time:
    /// Last Modified By:
    /// </Remarks>
    public class QueryHelper
    { 

        /// <summary>
        /// Gets the record count.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-6-13 17:46
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static int GetRecordCount(DBInstance dbInstance, string tableName,List<MESParameterInfo> list)
        {
            DataSet ds = GetAllRecords(dbInstance, tableName, list);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows.Count;
            }
            return 0;
        }

        /// <summary>
        /// Gets the record count.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 08-10-10 16:26
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static int GetRecordCount(DBInstance dbInstance, string tableName, List<MESParameterInfo> list, string filterSql)
        {
            DataSet ds = GetAllRecords(dbInstance, tableName, list, filterSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows.Count;
            }
            return 0;
        }

        /// <summary>
        /// Gets the record count with out row ID.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-7-24 13:50
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static int GetRecordCountWithOutRowID(DBInstance dbInstance, string tableName, List<MESParameterInfo> list)
        {
            DataSet ds = GetAllRecordsWithOutRowID(dbInstance, tableName, list, "");
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows.Count;
            }
            return 0;
        }

        /// <summary>
        /// Gets the record count with filter with out row ID.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <param name="filterSql">The filter SQL.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 08-10-10 16:27
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static int GetRecordCountWithOutRowID(DBInstance dbInstance, string tableName, List<MESParameterInfo> list, string filterSql)
        {
            DataSet ds = GetAllRecordsWithOutRowID(dbInstance,tableName, list, filterSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows.Count;
            }
            return 0;
        }

        /// <summary>
        /// Gets all record.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-6-13 17:58
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static DataSet GetAllRecords(DBInstance dbInstance, string tableName, List<MESParameterInfo> list)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectSql(tableName, list.FindAll(NullValues), parameters, true, "");
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection.ConnectionString, CommandType.Text, sql, parameters.ToArray());
            return ds;
        }
        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <param name="filterSql">The filter SQL.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 08-10-10 16:18
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static DataSet GetAllRecords(DBInstance dbInstance, string tableName, List<MESParameterInfo> list, string filterSql)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectSql(tableName, list.FindAll(NullValues), parameters, true, filterSql);
            if (!filterSql.Equals(string.Empty))
            {
                sql += " and " + filterSql;
            }
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection.ConnectionString, CommandType.Text, sql, parameters.ToArray());
            return ds;
        }
        /// <summary>
        /// Gets all record.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-6-13 17:58
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        

        public static DataSet GetAllRecords(string tableName, List<MESParameterInfo> list, string filterSql, DBInstance dbInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectSql(tableName, list.FindAll(NullValues), parameters, true, filterSql);
            if (!filterSql.Equals(string.Empty))
            {
                sql += " and " + filterSql;
            }
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, dbInstance.Transaction, sql, parameters.ToArray());
            return ds;
        }


        /// <summary>
        /// Gets all Equal record.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-10-23
        /// Created By: Jame
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static DataSet GetAllEqualRecords(DBInstance dbInstance, string tableName, List<MESParameterInfo> list)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectEqualSql(tableName, list.FindAll(NullValues), parameters, true, "");
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection.ConnectionString, CommandType.Text, sql, parameters.ToArray());
            return ds;
        }

        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <param name="filterSql">The filter SQL.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 08-10-10 16:18
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static DataSet GetAllEqualRecords(DBInstance dbInstance, string tableName, List<MESParameterInfo> list, string filterSql)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectEqualSql(tableName, list.FindAll(NullValues), parameters, true, filterSql);
            if (!filterSql.Equals(string.Empty))
            {
                sql += " and " + filterSql;
            }
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection.ConnectionString, CommandType.Text, sql, parameters.ToArray());
            return ds;
        }


        public static DataSet GetAllEqualRecords(string tableName, List<MESParameterInfo> list, string filterSql, DBInstance dbInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectEqualSql(tableName, list.FindAll(NullValues), parameters, true, filterSql);
            if (!filterSql.Equals(string.Empty))
            {
                sql += " and " + filterSql;
            }
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection,dbInstance.Transaction, sql, parameters.ToArray());
            return ds;
        }

        public static DataSet GetAllEqualRecordsHasNullParam(string tableName, List<MESParameterInfo> list, string filterSql, DBInstance dbInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectEqualSql(tableName, list, parameters, true, filterSql);
            if (!filterSql.Equals(string.Empty))
            {
                sql += " and " + filterSql;
            }
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, dbInstance.Transaction, sql, parameters.ToArray());
            return ds;
        }

        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-7-24 13:48
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static DataSet GetAllRecordsWithOutRowID(DBInstance dbInstance,string tableName, List<MESParameterInfo> list,string filterSql)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectSql(tableName, list.FindAll(NullValues), parameters,false,filterSql);
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, dbInstance.Transaction, sql, parameters.ToArray());
            return ds;
        }

        private static bool NullValues(MESParameterInfo column)
        {
            return !column.ParamValue.Equals(string.Empty);
        }


        /// <summary>
        /// Creates the select Equal SQL.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-10-23
        /// Created By: Jame
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        private static string CreateSelectEqualSql(string tableName, List<MESParameterInfo> list, List<SqlParameter> parameters, bool needRowId, string filterSql)
        {
            StringBuilder selectSql = new StringBuilder();
            selectSql.Append("select ");
            if (needRowId)
            {
                selectSql.Append("rowid rw,");
            }
            selectSql.Append("rownum rowss,").Append(tableName).Append(".* from ").Append(tableName)
                     .Append(" where 1=1 ");

            if (list == null || list.Count == 0)
            {
                if (!filterSql.Equals(string.Empty))
                {
                    selectSql.Append(" and ").Append(filterSql);
                }
                return selectSql.ToString();
            }

            for (int i = 0; i < list.Count; i++)
            {
                MESParameterInfo column = list[i];
                string columnName = column.ParamName;
                string columnValue = column.ParamValue;
                string columnType = column.ParamType;

                SqlDbType oracleType = DataHelper.MappingNetType(columnType);
                SqlParameter parameter=null;
                if (columnValue != null && !columnValue.Trim().Equals(""))
                {
                    parameter = new SqlParameter(":" + columnName, oracleType);
                }
                selectSql.Append(" and ");

                if (oracleType.Equals(SqlDbType.VarChar))
                {
                    if (columnValue == null || columnValue.Trim().Equals(""))
                    {
                        selectSql.Append(columnName).Append(" is null");
                    }
                    else
                    {
                        selectSql.Append(columnName).Append(" =@").Append(columnName);
                        parameter.Value = DataHelper.GetSqlValues(oracleType, columnValue);
                    }
                    
                }
                else if (oracleType.Equals(SqlDbType.DateTime))
                {
                    string[] realName = columnName.Split(new string[] { "#" }, StringSplitOptions.None);
                    if (realName.Length > 0)
                    {
                        string prefix = realName[0];
                        if (prefix.Equals("from"))
                        {
                            selectSql.Append(realName[1]).Append(">=@").Append(columnName);
                            parameter.Value = DataHelper.GetSqlValues(oracleType, columnValue);
                        }
                        else
                        {
                            selectSql.Append(realName[1]).Append("<@").Append(columnName);
                            parameter.Value = ((DateTime)DataHelper.GetSqlValues(oracleType, columnValue)).AddDays(1);
                        }
                    }
                }
                if (parameter != null)
                {
                    parameters.Add(parameter);
                }
            }

            if (!filterSql.Equals(string.Empty))
            {
                selectSql.Append(" and ").Append(filterSql);
            }

            return selectSql.ToString();
        }
        /// <summary>
        /// Creates the select SQL.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-6-13 18:08
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        private static string CreateSelectSql(string tableName, List<MESParameterInfo> list, List<SqlParameter> parameters,bool needRowId,string filterSql)
        {
            StringBuilder selectSql = new StringBuilder();
            selectSql.Append("select ");
            if (needRowId)
            {
                selectSql.Append("rowid rw,");
            }
            selectSql.Append("rownum rowss,").Append(tableName).Append(".* from ").Append(tableName)
                     .Append(" where 1=1 ");

            if (list == null || list.Count == 0)
            {
                if (!filterSql.Equals(string.Empty))
                {
                    selectSql.Append(" and ").Append(filterSql);
                }
                return selectSql.ToString();
            }

            for (int i = 0; i < list.Count; i++)
            {
                MESParameterInfo column = list[i];
                string columnName = column.ParamName;
                string columnValue = column.ParamValue;
                string columnType = column.ParamType;

                SqlDbType oracleType = DataHelper.MappingNetType(columnType);
                SqlParameter parameter = new SqlParameter("@" + columnName, oracleType);
                selectSql.Append(" and ");

                if (oracleType.Equals(SqlDbType.VarChar))
                {
                    if (columnValue.IndexOf(",") != -1)
                    {
                        selectSql.Append("upper(").Append(columnName).Append(")"); 

                        string[] splits = columnValue.Split(",".ToCharArray());
                        string single = string.Empty;

                        for (int j = 0; j < splits.Length; j++)
                        {
                            single += string.Format("'{0}'",splits[j]);

                            if (j < splits.Length - 1)
                            {
                                single += string.Format(",");
                            }
                        }

                        selectSql.Append(string.Format(" in({0})", single.ToUpper()));
                    }
                    else
                    {
                        selectSql.Append("upper(").Append(columnName).Append(") like @").Append(columnName);
                        parameter.Value = "%" + DataHelper.GetSqlValues(oracleType, columnValue).ToString().ToUpper() + "%";
                    }          
                }
                else if (oracleType.Equals(SqlDbType.DateTime))
                {
                    string[] realName = columnName.Split(new string[] {"#" }, StringSplitOptions.None);
                    if (realName.Length > 0)
                    {
                        string prefix = realName[0];
                        if (prefix.Equals("from"))
                        {
                            selectSql.Append(realName[1]).Append(">=@").Append(columnName);
                            parameter.Value = DataHelper.GetSqlValues(oracleType, columnValue);
                        }
                        else
                        {
                            selectSql.Append(realName[1]).Append("<@").Append(columnName);
                            parameter.Value = ((DateTime)DataHelper.GetSqlValues(oracleType, columnValue)).AddDays(1);
                        }
                    }
                }
                parameters.Add(parameter);
            }

            if (!filterSql.Equals(string.Empty))
            {
                selectSql.Append(" and ").Append(filterSql);
            }

            return selectSql.ToString();
        }

        /// <summary>
        /// Paginates the records.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="filterSql">The filter SQL.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 08-10-10 16:28
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static DataSet PaginateRecords(DBInstance dbInstance, string tableName, List<MESParameterInfo> list, int start, int end, string filterSql)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectSql(tableName, list.FindAll(NullValues), parameters, true, filterSql);
            StringBuilder selectSql = new StringBuilder();
            selectSql.Append("select * from(").Append(sql).Append(")")
                   .Append(" where ").Append("rowss>").Append(start)
                   .Append(" and ").Append("rowss<=").Append(end);
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection.ConnectionString, CommandType.Text, selectSql.ToString(), parameters.ToArray());
            return ds;
        }
        /// <summary>
        /// Paginates the records.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-6-13 18:01
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static DataSet PaginateRecords(DBInstance dbInstance, string tableName, List<MESParameterInfo> list, int start, int end)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectSql(tableName, list.FindAll(NullValues), parameters,true,"");
            StringBuilder selectSql = new StringBuilder();
            selectSql.Append("select * from(").Append(sql).Append(")")
                   .Append(" where ").Append("rowss>").Append(start)
                   .Append(" and ").Append("rowss<=").Append(end);
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection.ConnectionString, CommandType.Text, selectSql.ToString(), parameters.ToArray());
            return ds;
        }

        /// <summary>
        /// Paginates the record with out row ID.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="filterSql">The filter SQL.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 08-10-10 16:29
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static DataSet PaginateRecordWithOutRowID(DBInstance dbInstance, string tableName, List<MESParameterInfo> list, int start, int end, string filterSql)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectSql(tableName, list.FindAll(NullValues), parameters, false,filterSql);
            StringBuilder selectSql = new StringBuilder();
            selectSql.Append("select * from(").Append(sql).Append(")")
                   .Append(" where ").Append("rowss>").Append(start)
                   .Append(" and ").Append("rowss<=").Append(end);
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection.ConnectionString, CommandType.Text, selectSql.ToString(), parameters.ToArray());
            return ds;
        }

        /// <summary>
        /// Paginates the records.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-7-24 13:47
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static DataSet PaginateRecordWithOutRowID(DBInstance dbInstance, string tableName, List<MESParameterInfo> list, int start, int end)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectSql(tableName, list.FindAll(NullValues), parameters,false,"");
            StringBuilder selectSql = new StringBuilder();
            selectSql.Append("select * from(").Append(sql).Append(")")
                   .Append(" where ").Append("rowss>").Append(start)
                   .Append(" and ").Append("rowss<=").Append(end);
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection.ConnectionString, CommandType.Text, selectSql.ToString(), parameters.ToArray());
            return ds;
        }

        public static DataSet CallStoredProcedure(DBInstance dbInstance, string _Sql, ParameterItem[] _inParameters, ParameterItem[] _outParameters)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {

                if (_inParameters != null)
                {
                    foreach (ParameterItem item in _inParameters)
                    {
                        if (item != null) 
                        {
                            if (item.ParameterName != null && item.ParameterValue != null)
                            {
                                SqlParameter parm = new SqlParameter(item.ParameterName, SqlDbType.VarChar);
                                parm.Direction = ParameterDirection.Input;
                                parm.Value = item.ParameterValue;
                                parameters.Add(parm);
                            }
                        }
                    }
                }

                if (_outParameters != null)
                {
                    foreach (ParameterItem item in _outParameters)
                    {
                        if (item != null)
                        {
                            if (item.ParameterName != null)
                            {
                                SqlParameter parm = new SqlParameter(item.ParameterName, SqlDbType.VarChar);//сп╢М 
                                parm.Direction = ParameterDirection.Output;
                                parameters.Add(parm);
                            }
                        }
                    }
                }

                DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection.ConnectionString, CommandType.StoredProcedure, _Sql, parameters.ToArray());
                return ds;

            }
            catch (UtilException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new UtilException(ex.Message, ex);
            }
        }

        //mrp code


        /// <summary>
        /// Gets all Equal record.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-10-23
        /// Created By: Jame
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static DataSet GetAllEqualRecords(string tableName, List<MESParameterInfo> list)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectEqualSql(tableName, list.FindAll(NullValues), parameters, true, "");
            DataSet ds = SqlHelper.ExecuteQuery(sql, parameters.ToArray());
            return ds;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDistinct"></param>
        /// <param name="tableName"></param>
        /// <param name="list"></param>
        /// <param name="filterSql"></param>
        /// <returns></returns>
        public static DataSet GetRecords(DBInstance dbInstance, bool isDistinct, string tableName, List<MESParameterInfo> list, string filterSql)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sql = CreateSelectSql(tableName, list.FindAll(NullValues), parameters, true, filterSql);
            if (!filterSql.Equals(string.Empty))
            {
                sql += " and " + filterSql;
            }

            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection.ConnectionString, CommandType.Text, sql, parameters.ToArray());
            return ds;
        }


    }
}

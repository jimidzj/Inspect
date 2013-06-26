using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility.Database;
using System.Data.Objects.DataClasses;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.Common
{
    public class SQLSet
    {
        public string SQLStatement { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public SQLSet()
        {
            SQLStatement = string.Empty;
            Parameters = new List<SqlParameter>();
        }
    }
    
    public class BaseDal
    {
        public string TableName { get; set; }
        public DBInstance dbInstance { get; set; }

        public BaseDal()
        {
        }

        public BaseDal(DBInstance dbi)
        {
            dbInstance = dbi;
        }
        
        #region DoInsert
        public virtual void DoInsert<T>(T obj, string tableName) where T : class
        {
            if (obj == null) return;

            try
            {
                SQLSet sqlSet = BuildInsertSQL<T>(obj, tableName);

                SqlHelper.ExecuteNonQuery(dbInstance, sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void DoInsert<T>(T obj) where T : class
        {
            DoInsert<T>(obj, string.Empty);
        }
        #endregion

       // added by George 2009/11/6
        #region DoMultiInsert
        public void DoMultiInsert<T>(List<T> lstObj, string _tableName) where T : class
        {
            try
            { 
                foreach (T obj in lstObj)
                {
                    PrepareObject<T>(obj, "INSERT");
                    DoInsert<T>(obj, _tableName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion

        // added by George 2009/11/10
        #region DoMultiUpdate
        public void DoMultiUpdate<T>(List<T> lstObj, string _tableName) where T : class
        {
            try
            {
                foreach (T obj in lstObj)
                {
                    PrepareObject<T>(obj, "UPDATE");
                    DoDelete<T>(obj, _tableName);
                    DoInsert<T>(obj, _tableName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region DoUpdate
        public virtual void DoUpdate<T>(T obj, string tableName) where T : class
        {
            if (obj == null) return;

            try
            {
                SQLSet sqlSet = BuildUpdateSQL<T>(obj, tableName);

                SqlHelper.ExecuteNonQuery(dbInstance, sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void DoUpdate<T>(T obj) where T : class
        {
            DoUpdate<T>(obj, string.Empty);
        }
        #endregion

        #region DoDelete
        public virtual void DoDelete<T>(T obj, string tableName) where T : class
        {
            if (obj == null) return;

            try
            {
                SQLSet sqlSet = BuildDeleteSQL<T>(obj, tableName);

                SqlHelper.ExecuteNonQuery(dbInstance, sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void DoDelete<T>(T obj) where T : class
        {
            DoDelete<T>(obj, string.Empty);
        }

        public virtual void DoDelete<T>(List<MESParameterInfo> lstParameters, string tableName) where T : class
        {
            try
            {
                SQLSet sqlSet = BuildDeleteSQL<T>(lstParameters, tableName, true);

                SqlHelper.ExecuteNonQuery(dbInstance, sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void DoDelete<T>(List<MESParameterInfo> lstParameters) where T : class
        {
            DoDelete<T>(lstParameters, string.Empty);
        }

        #endregion

        #region BuildInsertSQL
        private SQLSet BuildInsertSQL<T>(T obj, string tableName) where T : class
        {
            try
            {
                PrepareObject<T>(obj, "INSERT");

                SQLSet sqlSet = new SQLSet();
                StringBuilder sqlField = new StringBuilder();
                StringBuilder sqlValue = new StringBuilder();

                PropertyInfo[] props = typeof(T).GetProperties();

                if (typeof(T) is object) //add by george
                {
                    props = obj.GetType().GetProperties();
                }

                if (tableName.Trim() != string.Empty)
                    sqlField.Append("insert into " + tableName + "(");
                else
                    sqlField.Append("insert into " + typeof(T).Name + "(");

                foreach (PropertyInfo prop in props)
                {
                    if (prop.PropertyType.FullName != "System.Data.EntityState" &&
                        prop.PropertyType.FullName != "System.Data.EntityKey" &&
                        prop.PropertyType.BaseType.Name != "EntityObject" &&
                        prop.PropertyType.BaseType.Name != "EntityReference" &&
                        prop.PropertyType.BaseType.Name != "RelatedEnd")
                    {
                        sqlField.Append(prop.Name + ",");
                        sqlValue.Append("@" + prop.Name + ",");
                    }
                }

                sqlSet.SQLStatement = sqlField.ToString().Remove(sqlField.ToString().Length - 1, 1);
                sqlSet.SQLStatement += ") values (" + sqlValue.ToString().Remove(sqlValue.ToString().Length - 1, 1) + ")";

                foreach (PropertyInfo prop in props)
                {
                    if (prop.PropertyType.FullName != "System.Data.EntityState" &&
                        prop.PropertyType.FullName != "System.Data.EntityKey" &&
                        prop.PropertyType.BaseType.Name != "EntityObject" &&
                        prop.PropertyType.BaseType.Name != "EntityReference" &&
                        prop.PropertyType.BaseType.Name != "RelatedEnd")
                    {

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = prop.Name;
                        param.Value = prop.GetValue(obj, null);
                        param.SqlDbType = ConvertType(prop.PropertyType.ToString());
                        param.IsNullable = true;
                        //convert null
                        ConverNull(param);

                        sqlSet.Parameters.Add(param);
                    }
                }

                return sqlSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BuildUpdateSQL
        private SQLSet BuildUpdateSQL<T>(T obj, string tableName) where T : class
        {
            try
            {
                PrepareObject<T>(obj, "UPDATE");

                SQLSet sqlSet = new SQLSet();
                StringBuilder sqlField = new StringBuilder();
                StringBuilder sqlWhere = new StringBuilder();
                bool isPK = false;
                List<SqlParameter> lstField = new List<SqlParameter>();
                List<SqlParameter> lstWhere = new List<SqlParameter>();

                PropertyInfo[] props = typeof(T).GetProperties();
              
                if (typeof(T) is object) //add by george
                {
                    props = obj.GetType().GetProperties();
                }

                if (tableName.Trim() != string.Empty)
                    sqlField.Append("update " + tableName + " set ");
                else
                    sqlField.Append("update " + typeof(T).Name + " set ");

                foreach (PropertyInfo prop in props)
                {
                    if (prop.PropertyType.FullName == "System.Data.EntityState" ||
                        prop.PropertyType.FullName == "System.Data.EntityKey" ||
                        prop.PropertyType.BaseType.Name == "EntityObject" ||
                        prop.PropertyType.BaseType.Name == "EntityReference" ||
                        prop.PropertyType.BaseType.Name == "RelatedEnd")
                        continue;

                    object[] arrProp = prop.GetCustomAttributes(true);

                    foreach (Attribute att in arrProp)
                    {
                        if (att is EdmScalarPropertyAttribute)
                        {
                            if ((att as EdmScalarPropertyAttribute).EntityKeyProperty)
                            {
                                isPK = true;
                            }
                            else
                            {
                                isPK = false;
                            }
                        }
                    }

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = prop.Name;
                    param.Value = prop.GetValue(obj, null);
                    param.IsNullable = true;
                    param.SqlDbType = ConvertType(prop.PropertyType.ToString());

                    //convert null
                    ConverNull(param);

                    if (isPK)
                    {
                        sqlWhere.Append(" and " + prop.Name + "=@" + prop.Name);
                        lstWhere.Add(param);
                    }
                    else
                    {
                        sqlField.Append(" " + prop.Name + "=@" + prop.Name + ",");
                        lstField.Add(param);
                    }
                }

                sqlSet.SQLStatement = sqlField.ToString().Remove(sqlField.ToString().Length - 1, 1);
                sqlSet.SQLStatement += " where 1=1 " + sqlWhere.ToString();

                for (int i = 0; i < lstField.Count; i++)
                {
                    sqlSet.Parameters.Add(lstField[i]);
                }

                for (int i = 0; i < lstWhere.Count; i++)
                {
                    sqlSet.Parameters.Add(lstWhere[i]);
                }

                return sqlSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BuildDeleteSQL
        private SQLSet BuildDeleteSQL<T>(T obj, string tableName) where T : class
        {
            try
            {
                PrepareObject<T>(obj, "DELETE");

                SQLSet sqlSet = new SQLSet();
                StringBuilder sqlField = new StringBuilder();
                StringBuilder sqlWhere = new StringBuilder();
                bool isPK = false;
                List<SqlParameter> lstField = new List<SqlParameter>();
                List<SqlParameter> lstWhere = new List<SqlParameter>();

                PropertyInfo[] props = typeof(T).GetProperties();

                if (typeof(T) is object) //add by george
                {
                   props = obj.GetType().GetProperties();
                }

                if (tableName.Trim() != string.Empty)
                    sqlField.Append("delete from " + tableName + " ");
                else
                    sqlField.Append("delete from " + typeof(T).Name + " ");

                foreach (PropertyInfo prop in props)
                {
                    if (prop.PropertyType.FullName == "System.Data.EntityState" ||
                        prop.PropertyType.FullName == "System.Data.EntityKey" ||
                        prop.PropertyType.BaseType.Name == "EntityObject" ||
                        prop.PropertyType.BaseType.Name == "EntityReference" ||
                        prop.PropertyType.BaseType.Name == "RelatedEnd")
                        continue;

                    object[] arrProp = prop.GetCustomAttributes(true);

                    foreach (Attribute att in arrProp)
                    {
                        if (att is EdmScalarPropertyAttribute)
                        {
                            if ((att as EdmScalarPropertyAttribute).EntityKeyProperty)
                            {
                                isPK = true;
                            }
                            else
                            {
                                isPK = false;
                            }
                        }
                    }

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = prop.Name;
                    param.Value = prop.GetValue(obj, null);
                    param.IsNullable = true;
                    param.SqlDbType = ConvertType(prop.DeclaringType.ToString());

                    //convert null
                    ConverNull(param);

                    if (isPK)
                    {
                        sqlWhere.Append(" and " + prop.Name + "=@" + prop.Name);
                        lstWhere.Add(param);
                    }
                }

                sqlSet.SQLStatement = sqlField + " where 1=1 " + sqlWhere.ToString();

                sqlSet.Parameters = lstWhere;

                return sqlSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SQLSet BuildDeleteSQL<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract) where T : class
        {
            try
            {
                SQLSet sqlSet = new SQLSet();
                StringBuilder sqlField = new StringBuilder();
                StringBuilder sqlValue = new StringBuilder();

                PropertyInfo[] props = typeof(T).GetProperties();

                sqlField.Append("delete ");

                if (tableName.Trim() != string.Empty)
                    sqlField.Append(" from " + tableName);
                else
                    sqlField.Append(" from " + typeof(T).Name);

                sqlField.Append(" where 1=1 ");
                foreach (MESParameterInfo columnInfo in lstParameters)
                {
                    string oper = string.Empty;
                    if (columnInfo.ParamType == "string")
                    {
                        if (isExtract)
                            oper = " = ";
                        else
                            oper = " like ";
                    }
                    else
                    {
                        oper = " = ";
                    }

                    sqlField.Append(" and " + columnInfo.ParamName.ToLower() + oper + "@" + columnInfo.ParamName.ToLower() + " ");

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = columnInfo.ParamName;
                    param.Value = columnInfo.ParamValue;
                    param.IsNullable = true;
                    param.SqlDbType = ConvertJavaScriptType(columnInfo.ParamType);

                    //convert null
                    ConverNull(param);

                    sqlSet.Parameters.Add(param);
                }

                sqlSet.SQLStatement = sqlField.ToString();

                return sqlSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region PrepareObject
        private T PrepareObject<T>(T obj, string mode) where T : class
        {
            PropertyInfo prop = typeof(T).GetProperty("lastmodifiedtime");
            if (prop!=null)
                prop.SetValue(obj,Function.GetCurrentTime(),null);

            //prop = typeof(T).GetProperty("lastmodifieduser");
            //if (prop != null)
            //    prop.SetValue(obj, Function.GetCurrentUser(), null);

            if (mode == "INSERT")
            {
                prop = typeof(T).GetProperty("claimtime");
                if (prop != null)
                    prop.SetValue(obj, Function.GetCurrentTime(), null);

                //prop = typeof(T).GetProperty("claimuser");
                //if (prop != null)
                //    prop.SetValue(obj, Function.GetCurrentUser(), null);
            }
            return obj;
        }
        #endregion 

        #region ConvertType
        private SqlDbType ConvertType(string _type)
        {
            SqlDbType ret;

            switch (_type)
            {
                case "System.String":
                    ret = SqlDbType.VarChar;
                    break;
                case "System.Date":
                    ret = SqlDbType.DateTime;
                    break;
                case "System.DateTime":
                    ret = SqlDbType.DateTime;
                    break;
                case "System.Int32":
                    ret = SqlDbType.Int;
                    break;
                case "System.Int64":
                    ret = SqlDbType.BigInt;
                    break;
                case "System.Int16":
                    ret = SqlDbType.SmallInt;
                    break;
                case "System.Decimal":
                    ret = SqlDbType.Decimal;
                    break;
                case "System.Double":
                    ret = SqlDbType.Decimal;
                    break;
                default:
                    ret = CheckNullType(_type);
                    break;
            }

            return ret;
        }

        private SqlDbType CheckNullType(string _type)
        {
            SqlDbType ret = SqlDbType.VarChar;

            if (_type.IndexOf("System.String")>0) ret = SqlDbType.VarChar;
            if (_type.IndexOf("System.Date")>0) ret = SqlDbType.DateTime;
            if (_type.IndexOf("System.DateTime") > 0) ret = SqlDbType.DateTime;
            if (_type.IndexOf("System.Int32")>0) ret = SqlDbType.Int;
            if (_type.IndexOf("System.Int64")>0) ret = SqlDbType.BigInt;
            if (_type.IndexOf("System.Int16")>0) ret = SqlDbType.SmallInt;
            if (_type.IndexOf("System.Decimal")>0) ret = SqlDbType.Decimal;
            if (_type.IndexOf("System.Double")>0) ret = SqlDbType.Decimal;

            return ret;
        }
        #endregion


        public virtual List<T> GetSelectedObjects<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber) where T : class
        {
            SQLSet sqlSet = BuildSelectSQL<T>(lstParameters, tableName, isExtract, maxRecordNumber);

            DataSet ds = null;
            if (dbInstance==null)
                ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());
            else
                ds = SqlHelper.ExecuteQuery(dbInstance.Connection, dbInstance.Transaction, sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

            //Convert ds to object list
            List<T> lstRet = ConvertDatasetToObjectList<T>(ds);

            return lstRet;
        }

        public virtual List<T> GetSelectedObjects<T>(List<MESParameterInfo> lstParameters) where T : class
        {
            SQLSet sqlSet = BuildSelectSQL<T>(lstParameters, string.Empty, true, 10000000);

            DataSet ds = null;
            if (dbInstance == null)
                ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());
            else
                ds = SqlHelper.ExecuteQuery(dbInstance.Connection, dbInstance.Transaction, sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

            //Convert ds to object list
            List<T> lstRet = ConvertDatasetToObjectList<T>(ds);

            return lstRet;
        }

        public virtual SortableBindingList<T> GetSelectedObjectsSortableBindingList<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber) where T : class
        {
            SQLSet sqlSet = BuildSelectSQL<T>(lstParameters, tableName, isExtract, maxRecordNumber);

            DataSet ds = null;
            if (dbInstance == null)
                ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());
            else
                ds = SqlHelper.ExecuteQuery(dbInstance.Connection, sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

            //Convert ds to object list
            SortableBindingList<T> lstRet = ConvertDatasetToObjectSortableBindingList<T>(ds);

            return lstRet;
        }

        public virtual DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber) where T : class
        {
            SQLSet sqlSet = BuildSelectSQL<T>(lstParameters, tableName, isExtract, maxRecordNumber);

            DataSet ds = null;
            if (dbInstance == null)
                ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());
            else
                ds = SqlHelper.ExecuteQuery(dbInstance.Connection, sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

            return ds;
        }

        public virtual T GetSingleObject<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract) where T : class
        {
            List<T> lstRet = GetSelectedObjects<T>(lstParameters, tableName, isExtract, 0);

            if (lstRet.Count <= 0)
                return null;
            else
                return lstRet.First<T>();
        }

        public virtual SQLSet BuildSelectSQL<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber) where T : class
        {
            try
            {
                SQLSet sqlSet = new SQLSet();
                StringBuilder sqlField = new StringBuilder();
                StringBuilder sqlValue = new StringBuilder();
                string tSql = string.Empty;

                PropertyInfo[] props = typeof(T).GetProperties();

                sqlField.Append("select ");
                foreach (PropertyInfo prop in props)
                {
                    if (prop.PropertyType.FullName!="System.Data.EntityState" &&
                        prop.PropertyType.FullName != "System.Data.EntityKey" &&
                        prop.PropertyType.BaseType.Name != "EntityObject" &&
                        prop.PropertyType.BaseType.Name != "EntityReference" &&
                        prop.PropertyType.BaseType.Name != "RelatedEnd")
                        sqlField.Append(prop.Name + ",");
                }

                string sTemp = sqlField.ToString().Remove(sqlField.ToString().Length - 1, 1);
                sqlField.Clear();
                sqlField.Append(sTemp);

                if (tableName.Trim() != string.Empty)
                    sqlField.Append(" from " + tableName);
                else
                    sqlField.Append(" from " + typeof(T).Name);

                sqlField.Append(" where 1=1 ");
                foreach (MESParameterInfo columnInfo in lstParameters)
                {
                    string oper = string.Empty;
                    if (columnInfo.ParamType == "string")
                    {
                        if (isExtract)
                            oper = " = ";
                        else
                            oper = " like ";

                        if (columnInfo.ParamValue == null || columnInfo.ParamValue.Trim() == string.Empty)
                        {
                            //    
                        }
                        else
                        {
                            //% --> wildcard
                            if (columnInfo.ParamValue.Trim().Substring(0, 1) == "%" ||
                                columnInfo.ParamValue.Trim().Substring(columnInfo.ParamValue.Trim().Length - 1, 1) == "%")
                            {
                                oper = " like ";
                            }
                        }
                    }
                    else
                    {
                        oper = " = ";
                    }

                    sqlField.Append(" and " + columnInfo.ParamName.ToLower() + oper + "@" + columnInfo.ParamName.ToLower() + " ");

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = columnInfo.ParamName;
                    param.Value = columnInfo.ParamValue;
                    param.IsNullable = true;
                    param.SqlDbType = ConvertJavaScriptType(columnInfo.ParamType);

                    sqlSet.Parameters.Add(param);
                }


                if (maxRecordNumber > 0)
                {
                    //sqlField.Append(" and rownum<=" + maxRecordNumber.ToString());
                    tSql = "select top " + maxRecordNumber + " * from (" + sqlField.ToString() + ") as t1";
                }
                else
                {
                    tSql = sqlField.ToString();
                }

                sqlSet.SQLStatement = tSql;// sqlField.ToString();

                return sqlSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual SQLSet BuildSelectSQL(string sSql, List<MESParameterInfo> lstParameters, bool isExtract, int maxRecordNumber) 
        {
            try
            {
                SQLSet sqlSet = new SQLSet();
                StringBuilder sqlField = new StringBuilder();
                string tSql = string.Empty;
                string actualColumnName = string.Empty;

                sqlField.Append(sSql);
                foreach (MESParameterInfo columnInfo in lstParameters)
                {
                    string oper = string.Empty;
                    if (columnInfo.ParamType == "string")
                    {
                        if (isExtract)
                            oper = " = ";
                        else
                            oper = " like ";

                        //% --> wildcard
                        if (!columnInfo.ParamValue.Trim().Equals(""))
                        {
                            if (columnInfo.ParamValue.Trim().Substring(0, 1) == "%" ||
                                columnInfo.ParamValue.Trim().Substring(columnInfo.ParamValue.Trim().Length - 1, 1) == "%")
                            {
                                oper = " like ";
                            }
                        }
                    }
                    else
                    {
                        oper = " = ";
                    }

                    if (columnInfo.ParamName.Contains("."))
                    {
                        string[] arr = columnInfo.ParamName.Split('.');
                        if (arr.Length > 1)
                            actualColumnName = arr[1];
                        else
                            actualColumnName = columnInfo.ParamName;
                    }
                    else
                    {
                        actualColumnName = columnInfo.ParamName;
                    }

                    sqlField.Append(" and " + columnInfo.ParamName.ToLower() + oper + "@" + actualColumnName.ToLower() + " ");

                    SqlParameter param = new SqlParameter();

                    param.ParameterName = actualColumnName;
                    param.Value = columnInfo.ParamValue.Trim();
                    param.IsNullable = true;
                    param.SqlDbType = ConvertJavaScriptType(columnInfo.ParamType);

                    sqlSet.Parameters.Add(param);
                }


                if (maxRecordNumber > 0)
                {
                    //sqlField.Append(" and rownum<=" + maxRecordNumber.ToString());
                    tSql = "select top " + maxRecordNumber + " * from (" + sqlField.ToString() + ") as t1";
                }
                else
                {
                    tSql = sqlField.ToString();
                }

                sqlSet.SQLStatement = tSql;

                return sqlSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDbType ConvertJavaScriptType(string javascriptType)
        {
            if (javascriptType.Equals("datetime"))
            {
                return SqlDbType.DateTime;
            }
            else if (javascriptType.Equals("int"))
            {
                return SqlDbType.Int;
            }
            else if (javascriptType.Equals("float"))
            {
                return SqlDbType.Decimal;
            }
            else
            {
                return SqlDbType.VarChar;
            }
        }

        public List<T> ConvertDatasetToObjectList<T>(DataSet ds) where T : class
        {
            List<T> lstResult = new List<T>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                T obj = typeof(T).GetConstructor(new Type[] { }).Invoke(new object[] { }) as T;

                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    PropertyInfo prop = typeof(T).GetProperty(ds.Tables[0].Columns[i].ColumnName.ToLower());
                    if (prop != null)
                    {
                        if (dr[i] is DBNull)
                            prop.SetValue(obj, null, null);
                        else
                        {
                            if (prop.PropertyType.FullName.Contains("System.Double"))
                            {
                                prop.SetValue(obj, Double.Parse(dr[i].ToString()), null);
                            }
                            else if (prop.PropertyType.FullName.Contains("System.Decimal"))
                            {
                                prop.SetValue(obj, Decimal.Parse(dr[i].ToString()), null);
                            }
                            else
                            {
                                prop.SetValue(obj, dr[i], null);
                            }

                        }
                    }
                }
                lstResult.Add(obj);
            }

            return lstResult;
        }

        private SortableBindingList<T> ConvertDatasetToObjectSortableBindingList<T>(DataSet ds) where T : class
        {
            SortableBindingList<T> lstResult = new SortableBindingList<T>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                T obj = typeof(T).GetConstructor(new Type[] { }).Invoke(new object[] { }) as T;

                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    PropertyInfo prop = typeof(T).GetProperty(ds.Tables[0].Columns[i].ColumnName.ToLower());
                    if (prop != null)
                    {
                        if (dr[i] is DBNull)
                            prop.SetValue(obj, null, null);
                        else
                            prop.SetValue(obj, dr[i], null);
                    }
                }
                lstResult.Add(obj);
            }

            return lstResult;
        }

        public DataSet LockLot(string lotSysID)
        {
            try
            {
                string sSql = "select lotid from twiplot where lotsysid='" + lotSysID + "' for update";
                DataSet ds = SqlHelper.ExecuteQuery(sSql);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SqlParameter> ConvertMESParameter2SqlParameter(List<MESParameterInfo> lstParameters)
        {
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();

            for (int i = 0; i < lstParameters.Count; i++)
            {
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = lstParameters[i].ParamName,
                    IsNullable = true,
                    SqlDbType = ConvertMESType2OracleType(lstParameters[i].ParamType),
                    Value = lstParameters[i].ParamValue
                };

                lstSqlParameter.Add(param);
            }

            return lstSqlParameter;
        }

        private SqlDbType ConvertMESType2OracleType(string paramType)
        {
            SqlDbType oracleType = new SqlDbType();

            switch (paramType)
            {
                case "string":
                    oracleType = SqlDbType.VarChar;
                    break;
                case "float":
                    oracleType = SqlDbType.Decimal;
                    break;
                case "int":
                    oracleType = SqlDbType.Int;
                    break;
                default:
                    oracleType = SqlDbType.VarChar;
                    break;
            }

            return oracleType;
        }

        private void ConverNull(SqlParameter param)
        {
            if (param == null) return;

            if (param.SqlDbType == SqlDbType.DateTime || param.SqlDbType == SqlDbType.Int)
            {
                if (param.Value == null)
                    param.Value = DBNull.Value;
            }

            if (param.SqlDbType == SqlDbType.VarChar)
            {
                if (param.Value ==null || param.Value.ToString() == string.Empty)
                    param.Value = DBNull.Value;
            }
        }
    }
}

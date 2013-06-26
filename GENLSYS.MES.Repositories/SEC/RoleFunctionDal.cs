using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using System.Data;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Repositories.SEC
{
    public class RoleFunctionDal:BaseDal
    {
        public RoleFunctionDal(DBInstance dbi)            : base(dbi)
        {
        }

        public override DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber)
        {
            try
            {
                string sSql = @"select * from (select 'N' as rolefunction,a.* from tsecfunctions a) rt where 1=1";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, isExtract, maxRecordNumber);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetRoleFunctionRecordsByRoleId(string roleid)
        {
            try
            {
                string sSql = @"SELECT case when b.roleid is NULL then 'N' else 'Y' end AS rolefunction, a.*
                          FROM tsecfunctions a
                               LEFT JOIN
                               (SELECT *
                                  FROM tsecrolefunction
                                 WHERE roleid ='" + roleid + "') b ON a.funcid = b.funcid where a.functype='" + MES_FuncType.Menu.ToString() + "'";

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                /*lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "roleid",
                    ParamValue = roleid,
                    ParamType = "string"
                });*/

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, true, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }           

        }

        public DataSet GetFunctionsByUserId(string userid)
        {
            try
            {
                string sSql = @"SELECT DISTINCT a.*
                           FROM tsecfunctions a, tsecrolefunction b, tsecuserrole c
                          WHERE a.funcid = b.funcid
                            AND b.roleid = c.roleid
                            AND c.userid =@userid";

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "userid",
                    ParamValue = userid,
                    ParamType = "string"
                });

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, true, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }
    }
}

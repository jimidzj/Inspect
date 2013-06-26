using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.Repositories.Common;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.SEC
{
    public class RoleEqpGroupDal:BaseDal
    {
        public RoleEqpGroupDal(DBInstance dbi)
            : base(dbi)
        {
        }

        public override DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber)
        {
            try
            {
                string sSql = @"select 'N' as roleeqpgroup,a.* from teqpeqpgroup a";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, isExtract, maxRecordNumber);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetRoleEqpGroupRecordsByRoleId(string roleid)
        {
            try
            {
                string sSql = @"SELECT case then b.roleid is NULL then 'N' else 'Y' end AS roleeqpgroup, a.eqpgroup,
                               a.eqpgroupdesc
                          FROM teqpeqpgroup a
                               LEFT JOIN
                               (SELECT *
                                  FROM tsecroleeqpgroup
                                 WHERE roleid =@roleid) b ON a.eqpgroup = b.eqpgroup";

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "roleid",
                    ParamValue = roleid,
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

        public DataSet GetEqpGroupRecordsByUserId(string userId)
        {
            try
            {
                string sSql = @"select * from tsecroleeqpgroup c,tsecuserrole d
                                 where c.roleid = d.roleid
                                 and   d.userid=@userid";

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "userid",
                    ParamValue = userId,
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

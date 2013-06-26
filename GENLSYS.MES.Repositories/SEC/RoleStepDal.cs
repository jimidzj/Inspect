using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Utility.Database;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.SEC
{
    public class RoleStepDal:BaseDal
    {
        public RoleStepDal(DBInstance dbi)            : base(dbi)
        {
        }

        public DataSet GetStepsByUserId(string userid)
        {
            try
            {
                string sSql = @"select funcid from tsecuserrole a ,  tsecrolefunction b
                where a.roleid = b.roleid 
                and funcid like 'FA%' and a.userid= @userid ";

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

        public DataSet GetAreaByUserId(string userid)
        {
            try
            {
                string sSql = @"select e.areasysid,e.areaid,e.areadesc 
                                from tsecrole a,tsecuserrole b,tsecrolestep c,tprpstep d,tmdlarea e
                                where a.roleid = b.roleid
                                and a.roleid = c.roleid
                                and c.stepid = d.stepsysid
                                and d.areasysid = e.areasysid
                                and d.revstate='Active'
                                and e.areastatus='Valid'
                                and b.userid =@userid
                                group by e.areasysid,e.areaid,e.areadesc
                                order by e.areaid";

                List<SqlParameter> lstParameters = new List<SqlParameter>();
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName="userid",
                    SqlDbType = SqlDbType.VarChar,
                    Value = userid
                });

                DataSet ds = SqlHelper.ExecuteQuery(sSql, lstParameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.SYS
{
    public class SessionHisDal : BaseDal
    {
        public SessionHisDal(DBInstance dbi)
            : base(dbi)
        {
            
        }
        public DataSet GetSelectedRecords(string userid, string machine,string ipaddress, string shift, DateTime fromlogontime, DateTime tologontime)
        {
            try
            {
                string sSql = @"SELECT *
                                  FROM tsyssessionhis
                                 WHERE userid like @userid AND ipaddress like @ipaddress AND machine like @machine AND shift Like @shift
                                  AND logontime>=@fromlogontime AND logontime<=@tologontime";
                
                List<SqlParameter> lstParameters = new List<SqlParameter>();
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "userid",
                    SqlDbType = SqlDbType.VarChar,
                    Value = "%" + userid + "%"
                });
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "machine",
                    SqlDbType = SqlDbType.VarChar,
                    Value = "%" + machine + "%"
                });
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "ipaddress",
                    SqlDbType = SqlDbType.VarChar,
                    Value = "%" + ipaddress + "%"
                });
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "shift",
                    SqlDbType = SqlDbType.VarChar,
                    Value = "%" + shift + "%"
                });
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "fromlogontime",
                    SqlDbType = SqlDbType.DateTime,
                    Value = fromlogontime
                });
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "tologontime",
                    SqlDbType = SqlDbType.DateTime,
                    Value = tologontime
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

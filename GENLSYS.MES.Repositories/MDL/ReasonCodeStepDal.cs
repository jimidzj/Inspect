using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.MDL
{
    public class ReasonCodeStepDal : BaseDal
    {
        public ReasonCodeStepDal(DBInstance dbi)
            : base(dbi)
        {
        }

        public DataSet GetReasonCodeStep(string reasoncode)
        {
            try
            {
                /*string sSql = @"select case when b.stepsysid is null then 'N' else 'Y' end as custfield1,
                                     a.stepsysid,a.stepid,a.stepversion,a.stepname,a.stepdesc 
                                from tprpstep a,(select * from tmdlreasoncodestep c where c.reasoncode =@reasoncode) b
                                where a.stepsysid = b.stepsysid(+)
                                order by a.stepno";*/
                string sSql = @"select case when b.stepsysid is null then 'N' else 'Y' end as custfield1,
                                     a.stepsysid,a.stepid,a.stepversion 
                                from tprpstep a
                                where 1=1
                                order by a.stepno";

                List<SqlParameter> lstParameters = new List<SqlParameter>();
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "reasoncode",
                    SqlDbType = SqlDbType.VarChar,
                    Value = reasoncode
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

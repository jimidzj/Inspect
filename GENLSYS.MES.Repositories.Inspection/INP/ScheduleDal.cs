using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class ScheduleDal : BaseDal
    {
        public ScheduleDal(DBInstance dbi)
            : base(dbi)
        {
        }

        public DataSet GetDailySchedule(string startdate, string enddate)
        {
            try
            {
                string sSql = @"with tmp as ( select convert(char(10),c.schdlydate,121) as prddate,sum(a.pairqty) as pairqty
                                from tinpreceivingdtl a, tinpreceiving b,tinpworkorderdtl c
                                where a.recsysid = b.recsysid 
                                and a.custorderno = c.custorderno
                                group by c.schdlydate)
                                
                                select convert(char(10),c.schdlydate,121) as prddate,a.checktype, a.custorderno,
                                       a.styleno,a.size,sum(a.pairqty) as pairqty,min(d.pairqty) as ttlpairqty
                                from tinpreceivingdtl a, tinpreceiving b,tinpworkorderdtl c,tmp d
                                where a.recsysid = b.recsysid 
                                and a.custorderno = c.custorderno
                                and convert(char(10),c.schdlydate,121) = d.prddate
                                and convert(char(10),c.schdlydate,121)>=@startdate
                                and convert(char(10),c.schdlydate,121)<=@enddate
                                group by c.schdlydate,a.checktype, a.custorderno,a.styleno,a.size";

                List<SqlParameter> lstParameters = new List<SqlParameter>();
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "@startdate",
                    SqlDbType = SqlDbType.VarChar,
                    Value = startdate
                });
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "@enddate",
                    SqlDbType = SqlDbType.VarChar,
                    Value = enddate
                });


                DataSet ds = SqlHelper.ExecuteQuery(sSql, lstParameters.ToArray());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

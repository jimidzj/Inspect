using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.MDL
{
    public class ExchangeDal:BaseDal
    {
        public ExchangeDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tmdlexchange";
        }

        public DataSet GetValidExchange(DateTime dt)
        {
            try
            {
                string sSql = @"select * from tmdlexchange a 
                                where exists (select * from  (
                                select fromcurrency,tocurrency,MAX(lastmodifiedtime) as lastmodifiedtime from tmdlexchange
                                where cast(convert(varchar, startdate,23)+' 00:00:00' as datetime)<=cast('" + dt.ToString("yyyy-MM-dd HH:mm:ss") + @"' as datetime)
                                and cast(convert(varchar, expirydate,23)+' 23:59:59' as datetime)>=cast('" + dt.ToString("yyyy-MM-dd HH:mm:ss") + @"' as datetime)
                                group by fromcurrency,tocurrency) b 
                                where a.fromcurrency=b.fromcurrency and a.tocurrency=b.tocurrency and a.lastmodifiedtime=b.lastmodifiedtime
                                )";

                SQLSet sqlSet = BuildSelectSQL(sSql, new List<MESParameterInfo>(), false, 0);

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

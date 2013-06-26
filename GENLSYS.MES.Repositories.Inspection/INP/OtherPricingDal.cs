using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.Repositories.Common;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class OtherPricingDal:BaseDal
    {
        public OtherPricingDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinpotherpricing";
        }

        public override DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber)
        {
            try
            {
                string sSql = @"select * from (
                                select a.*,b.customername from tinpotherpricing a,tmdlcustomer b
                                where a.customerid=b.customerid) rt where 1=1";


                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, isExtract, maxRecordNumber);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetValidOtherPricing(string customerid,DateTime dt)
        {
            try
            {
                string sSql = @"select * from tinpotherpricing a
                            where exists ( select *  from 
                            (select customerid,itemname,MAX(lastmodifiedtime) as lastmodifiedtime from tinpotherpricing
                            where customerid='"+customerid+ @"'
                            and cast(convert(varchar, effectivedate,23)+' 00:00:00' as datetime)<=cast('"+dt.ToString("yyyy-MM-dd HH:mm:ss")+@"' as datetime)
                            and cast(convert(varchar, expireddate,23)+' 23:59:59' as datetime)>=cast('" + dt.ToString("yyyy-MM-dd HH:mm:ss") + @"' as datetime)
                            group by customerid,itemname) b 
                            where a.customerid=b.customerid and a.itemname=b.itemname and a.lastmodifiedtime=b.lastmodifiedtime)
                            order by a.itemname";

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

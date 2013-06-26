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
    public class PricingDal: BaseDal
    {
        public PricingDal(DBInstance dbi)
            : base(dbi)
        {
        }

        public DataSet GetPricingRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from (select a.prisysid,b.pridtlsysid,a.customerid,d.customername,b.reworkratio,b.reworkprice,b.category,b.checktype,c.effectivedate,c.expireddate,
                                    c.currency,c.price,c.unit,c.remark,b.sbootheight,b.ebootheight 
                                from tinppricing a,tinppricingdtl b,tinppricingdtldef c,tmdlcustomer d
                                where a.prisysid = b.prisysid and a.customerid = d.customerid
                                and   b.pridtlsysid = c.pridtlsysid) as t1 where 1=1 ";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, true, 10000000);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDtl(string prisysid)
        {
            try
            {
                string sSql = @"delete from tinppricingdtl where prisysid='" + prisysid + "'";

                SqlHelper.ExecuteNonQuery(dbInstance, sSql, new List<SqlParameter>().ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDef(string prisysid)
        {
            try
            {
                string sSql = @"delete tinppricingdtldef 
                                from tinppricingdtldef a,tinppricingdtl b 
                                where a.pridtlsysid = b.pridtlsysid and b.prisysid='" + prisysid + "'";

                SqlHelper.ExecuteNonQuery(dbInstance, sSql, new List<SqlParameter>().ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetValidPricing(string customerid,DateTime dt)
        {
            try
            {
                string sSql = @"select * from (
                                select a.prisysid,b.pridtlsysid,a.customerid,d.customername,b.reworkratio,b.reworkprice,b.category,b.checktype,c.effectivedate,c.expireddate,
                                c.currency,c.price,c.unit,c.remark,b.sbootheight,b.ebootheight,a.lastmodifiedtime 
                                from tinppricing a,tinppricingdtl b,tinppricingdtldef c,tmdlcustomer d
                                where a.prisysid = b.prisysid and a.customerid = d.customerid
                                and   b.pridtlsysid = c.pridtlsysid) t1
                                where exists (select * from (
                                select a.customerid,b.category,b.checktype,b.sbootheight,b.ebootheight,MAX(a.lastmodifiedtime) as lastmodifiedtime
                                from tinppricing a,tinppricingdtl b,tinppricingdtldef c
                                where a.prisysid = b.prisysid and  b.pridtlsysid = c.pridtlsysid and a.customerid='"+customerid+@"'
                                and cast(convert(varchar, c.effectivedate,23)+' 00:00:00' as datetime)<=cast('" + dt.ToString("yyyy-MM-dd HH:mm:ss") + @"' as datetime)
                                and cast(convert(varchar, c.expireddate,23)+' 23:59:59' as datetime)>=cast('" + dt.ToString("yyyy-MM-dd HH:mm:ss") + @"' as datetime)
                                group by a.customerid,b.category,b.checktype,b.sbootheight,b.ebootheight) t2
                                where t1.customerid=t2.customerid and t1.category=t2.category and t1.checktype=t2.checktype
                                and t1.sbootheight=t2.sbootheight and t1.ebootheight=t2.ebootheight and t1.lastmodifiedtime=t2.lastmodifiedtime
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

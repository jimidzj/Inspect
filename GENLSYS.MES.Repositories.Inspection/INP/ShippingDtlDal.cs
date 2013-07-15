using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class ShippingDtlDal:BaseDal
    {
        public ShippingDtlDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinpshipping";
        }

        public override DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber)
        {
            try
            {
                string sSql = @"select * from (select t1.*,t2.shippeddate from (select a.*,b.customername,c.factory
                                from tinpshippingdtl a,tmdlcustomer b,(select distinct a1.customerid,b1.custorderno,a1.factory from tinpreceiving a1,tinpreceivingctndtl b1
                                where a1.recsysid=b1.recsysid) c
                                where a.customerid=b.customerid and a.customerid=c.customerid and a.custorderno=c.custorderno) t1
                                left join tinpshipping t2 on t1.shippingsysid=t2.shippingsysid ) rt
                                where 1=1";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, isExtract, maxRecordNumber);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetShippingPlanRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from (select a.*,b.customername,c.loadingdate
                                from tinpshippingdtl a,tmdlcustomer b,tinpshippingplan c
                                where a.customerid=b.customerid and a.shippingplanno=c.shippingplanno) rt
                                where shippingstatus<>'" + MES_ShippingStatus.Shipped.ToString() + "'";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, false, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetShippingPlanNoRecords(string shippingsysid)
        {
            try
            {
                string sSql = string.Empty;
                if (shippingsysid != null && !shippingsysid.Equals(""))
                {
                    sSql = @"select distinct shippingsysid, shippingplanno from tinpshippingdtl
                                where shippingsysid='" + shippingsysid + "'";
                }
                else
                {
                     sSql = @"select distinct shippingsysid, shippingplanno from tinpshippingdtl
                                where shippingstatus<>'" + MES_ShippingStatus.Shipped.ToString() + "'";
                }

                DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DoUpdateStatusByShippingSysId(string shippingSysId,string status)
        {
            try
            {
                string sSql = @"update tinpshippingdtl set shippingstatus='" + status + "' where shippingsysid='" + shippingSysId + "'";

                SqlHelper.ExecuteNonQuery(dbInstance, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

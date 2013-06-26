using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class ReceivingCtnDtlDal : BaseDal
    {
        public ReceivingCtnDtlDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinpreceivingctndtl";
        }
        
        public override List<T> GetSelectedObjects<T>(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from (select a.* from tinpreceivingctndtl a,tinpreceiving b
                                where a.recsysid=b.recsysid ) rt
                                where 1=1";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, true, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                List<T> lstRet = ConvertDatasetToObjectList<T>(ds);

                return lstRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public DataSet GetReceivingSumCtnDtlRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string subSql = "select distinct recsysid,custorderno,cartonno from tinpreceivingctndtl where 1=1";
                if (MESParameterInfo.GetColumnValue(lstParameters, "styleno") != null)
                {
                    subSql += " and styleno like '%" + MESParameterInfo.GetColumnValue(lstParameters, "styleno") + "%'";
                    MESParameterInfo.RemoveColumnInfo(lstParameters, "styleno");
                }
                if (MESParameterInfo.GetColumnValue(lstParameters, "color") != null)
                {
                    subSql += " and color like '%" + MESParameterInfo.GetColumnValue(lstParameters, "color") + "%'";
                    MESParameterInfo.RemoveColumnInfo(lstParameters, "color");
                }
                if (MESParameterInfo.GetColumnValue(lstParameters, "size") != null)
                {
                    subSql += " and size like '%" + MESParameterInfo.GetColumnValue(lstParameters, "size") + "%'";
                    MESParameterInfo.RemoveColumnInfo(lstParameters, "size");
                }

                string sSql = @"select * from (select a.custorderno,a.cartonno,a.checktype,a.cartonlocation,a.cartonstatus,SUM(a.pairqty) as pairqty,b.customerid,c.customername  
                                from tinpreceivingctndtl a,tinpreceiving b,tmdlcustomer c,(" + subSql + @") d
                                where a.recsysid=b.recsysid and b.customerid=c.customerid
                                and a.recsysid=d.recsysid and a.custorderno=d.custorderno and a.cartonno=d.cartonno
                                group by a.custorderno,a.cartonno,a.checktype,a.cartonlocation,a.cartonstatus,b.customerid,c.customername  
                                ) rt
                                where 1=1";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, false, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetReceivingCtnDtlRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string subSql = "select distinct recsysid,custorderno,cartonno from tinpreceivingctndtl where 1=1";
                if (MESParameterInfo.GetColumnValue(lstParameters, "styleno") != null)
                {
                    subSql += " and styleno like '%" + MESParameterInfo.GetColumnValue(lstParameters, "styleno") + "%'";
                    MESParameterInfo.RemoveColumnInfo(lstParameters, "styleno");
                }
                if (MESParameterInfo.GetColumnValue(lstParameters, "color") != null)
                {
                    subSql += " and color like '%" + MESParameterInfo.GetColumnValue(lstParameters, "color") + "%'";
                    MESParameterInfo.RemoveColumnInfo(lstParameters, "color");
                }
                if (MESParameterInfo.GetColumnValue(lstParameters, "size") != null)
                {
                    subSql += " and size like '%" + MESParameterInfo.GetColumnValue(lstParameters, "size") + "%'";
                    MESParameterInfo.RemoveColumnInfo(lstParameters, "size");
                }

                string sSql = @"select * from (select a.custorderno,a.cartonno,a.checktype,a.cartonlocation,a.cartonstatus,a.pairqty,b.customerid,c.customername,a.styleno,a.color,a.size  
                                from tinpreceivingctndtl a,tinpreceiving b,tmdlcustomer c,("+subSql+@") d
                                where a.recsysid=b.recsysid and b.customerid=c.customerid 
                                and a.recsysid=d.recsysid and a.custorderno=d.custorderno and a.cartonno=d.cartonno 
                                ) rt
                                where 1=1";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, false, 0);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using System.Data.SqlClient;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class ShippingDal:BaseDal
    {
        public ShippingDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinpshipping";
        }

        public override DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber)
        {
            try
            {
                string sSql = @"select * from (select a.*,b.customername,b.customerid,b.invoicetitle,b.factory,b.cartonqty,emty.emptycartonqty,b.cartonqty-isnull(emty.emptycartonqty,0) as actcartonqty ,c.svtext as loadingtypetext from tinpshipping a
                                inner join
                                (select a1.shippingsysid,SUM(a1.ttlcantonqty) as cartonqty ,c1.customername,c1.customerid ,c1.invoicetitle,b1.factory
                                 from tinpshippingdtl a1,(select distinct b11.customerid,b12.custorderno,b11.factory from tinpworkorder b11,tinpworkorderdtl b12
                                 where b11.workordersysid =b12.workordersysid) b1,tmdlcustomer c1
                                 where a1.custorderno=b1.custorderno and b1.customerid=c1.customerid
                                  group by a1.shippingsysid,c1.customername,c1.customerid,c1.invoicetitle,b1.factory
                                ) b
                                on a.shippingsysid=b.shippingsysid
                                left join (select shippingsysid,customerid,COUNT(*) as emptycartonqty 
                                from tinpshippingdtlctn where pairqty=0 group by shippingsysid,customerid) emty
                                on a.shippingsysid=emty.shippingsysid and b.customerid=emty.customerid
                                left join tsysstaticvalue c on c.svvalue=a.loadingtype and c.svtype='" + MES_StaticValue_Type.LoadingType.ToString() + @"'
                                ) rt
                                where 1=1";

                if (MESParameterInfo.GetColumnValue(lstParameters, "custorderno") != null)
                {
                     sSql = @"select * from (select a.*,b.customername,b.customerid,b.invoicetitle,b.factory,b.cartonqty,c.svtext as loadingtypetext from tinpshipping a
                            inner join
                            (select a1.shippingsysid,SUM(a1.ttlcantonqty) as cartonqty ,c1.customername,c1.customerid ,c1.invoicetitle,b1.factory
                                from tinpshippingdtl a1,(select distinct b11.customerid,b12.custorderno,b11.factory from tinpworkorder b11,tinpworkorderdtl b12
                                where b11.workordersysid =b12.workordersysid) b1,tmdlcustomer c1
                                where a1.custorderno=b1.custorderno and b1.customerid=c1.customerid
                                group by a1.shippingsysid,c1.customername,c1.customerid,c1.invoicetitle,b1.factory
                            ) b
                            on a.shippingsysid=b.shippingsysid and a.shippingsysid in (select distinct shippingsysid from tinpshippingdtl where custorderno like '%" + MESParameterInfo.GetColumnValue(lstParameters, "custorderno") + @"%')
                            left join tsysstaticvalue c on c.svvalue=a.loadingtype and c.svtype='" + MES_StaticValue_Type.LoadingType.ToString() + @"'
                            ) rt
                            where 1=1";

                     MESParameterInfo.RemoveColumnInfo(lstParameters, "custorderno");
                }



                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, isExtract, maxRecordNumber);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetShippingDtlForReport(string shippingsysid)
        {
            try
            {
                string sSql = @"select a.custorderno,a.cartonno,c.styleno,c.color,c.size,c.pairqty ,d.pairqty as orgpairty,e.checktype,f.factory
                                from tinpshippingdtlctn a,tinppackingrec b,tinppackingrecdtl c,
                                (select b1.* from tinppackingrec a1,tinppackingrecdtl b1
                                where a1.pksysid=b1.pksysid and a1.pktype='" + MES_PackingType.Unpacking.ToString() + @"') d ,tinpreceivingctndtl e,tinpreceiving f
                                where a.customerid=b.customerid and a.custorderno=b.custorderno and a.cartonno=c.cartonno and b.pksysid=c.pksysid
                                and b.pktype='" +MES_PackingType.Packing.ToString()+"' and a.shippingsysid='" + shippingsysid + @"'
                                and a.customerid=d.customerid and a.custorderno=d.custorderno and a.cartonno=d.cartonno
                                and c.styleno=d.styleno and c.color=d.color and c.size=d.size
                                and a.customerid=e.customerid and a.custorderno=e.custorderno 
                                and a.cartonno=e.cartonno and c.styleno=e.styleno and c.color=e.color and c.size=e.size and e.recsysid=f.recsysid";

                DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetShippingOrigDtlForReport(string shippingsysid)
        {
            try
            {
                string sSql = @"select a.custorderno,a.cartonno,b.styleno,b.color,b.size,b.pairqty,c.checktype,d.factory 
                                from tinpshippingdtlctn a,(select b1.* from tinppackingrec a1,tinppackingrecdtl b1
                                where a1.pksysid=b1.pksysid and a1.pktype='" + MES_PackingType.Unpacking.ToString() + @"') b,tinpreceivingctndtl c,tinpreceiving d
                                where a.customerid=b.customerid and a.custorderno=b.custorderno and a.cartonno=b.cartonno 
                                and a.customerid=c.customerid and a.custorderno=c.custorderno 
                                and a.cartonno=c.cartonno and b.styleno=c.styleno and b.color=c.color and b.size=c.size and c.recsysid=d.recsysid
                                and a.shippingsysid='" + shippingsysid + @"'";

                DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetShippingDtlForWarehouseOut(string shippingsysid)
        {
            try
            {
                string sSql = @"select a.custorderno,b.styleno, COUNT(*) as stylecartonqty ,sum(b.pairqty) as pairqty
                                from tinpshippingdtlctn a,(select a1.customerid,a1.custorderno,b1.cartonno,b1.styleno,SUM(b1.pairqty) as pairqty
                                from tinppackingrec a1 ,tinppackingrecdtl b1
                                where a1.pksysid=b1.pksysid and a1.pktype='" + MES_PackingType.Packing.ToString() + @"'
                                group by a1.customerid,a1.custorderno,b1.cartonno,b1.styleno) b
                                where a.customerid=b.customerid and a.custorderno=b.custorderno and a.cartonno=b.cartonno and b.pairqty<>0
                                and a.shippingsysid ='" + shippingsysid + @"'
                                group by a.custorderno,b.styleno";

                DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBillForBillingReport(string shippingsysid)
        {
            try
            {
                string sSql = @"select * from (
                                select o1.custorderno,o1.cartonno,o1.styleno,o3.svtext as checktype,o1.pairqty,o2.unit,o2.price, o1.pairqty*o2.price as amount,o2.currency
                                from (
                                select b.custorderno,b.cartonno,d.styleno,e.checktype,sum(d.pairqty) as pairqty,f.customerid,a.shippeddate
                                from tinpshipping a,tinpshippingdtlctn b,tinppackingrec c,tinppackingrecdtl d,tinpreceivingctndtl e,
                                (select distinct b1.customerid,b2.custorderno from tinpworkorder b1,tinpworkorderdtl b2
                                                                where b1.workordersysid =b2.workordersysid) f
                                where a.shippingsysid=b.shippingsysid 
                                and c.pksysid=d.pksysid and b.custorderno=c.custorderno and b.cartonno=d.cartonno
                                and c.custorderno=e.custorderno and d.cartonno=e.cartonno 
                                and d.styleno=e.styleno and  d.color=e.color and d.size=e.size
                                and c.pktype='" + MES_PackingType.Packing.ToString() + @"' and a.shippingsysid ='" + shippingsysid + @"'
                                and b.custorderno=f.custorderno
                                group by b.custorderno,b.cartonno,d.styleno,e.checktype,f.customerid,a.shippeddate) o1
                                left join (
                                select a.customerid,b.styleno,b.checktype,b.reworkratio,c.effectivedate,c.expireddate,c.unit,c.currency,c.price
                                from tinppricing a,tinppricingdtl b,tinppricingdtldef c
                                where a.prisysid=b.prisysid and b.pridtlsysid=c.pridtlsysid) o2
                                on o1.customerid=o2.customerid and o1.checktype=o2.checktype and o1.styleno=o2.styleno
                                and o1.shippeddate>=o2.effectivedate and o1.shippeddate<=ISNULL(o2.expireddate,'2999-1-1')
                                inner join tsysstaticvalue o3 on o1.checktype=o3.svvalue and o3.svtype='CheckType'
                                union
                                select o1.custorderno,o1.cartonno,o1.styleno,'再检 - '+o3.svtext as checktype,o1.pairqty,o2.unit,o2.price*(o2.reworkratio/100) as price, o1.pairqty*o2.price*(o2.reworkratio/100) as amount,o2.currency
                                from (
                                select c.custorderno,c.cartonno,c.styleno,c.step as checktype, SUM(c.pairqty) as pairqty,e.customerid,a.shippeddate
                                from tinpshipping a,tinpshippingdtlctn b,tinppackingrecretrieve c,
                                (select distinct b1.customerid,b2.custorderno from tinpworkorder b1,tinpworkorderdtl b2
                                                                where b1.workordersysid =b2.workordersysid) e
                                where a.shippingsysid=b.shippingsysid and a.shippingsysid ='" + shippingsysid + @"'
                                and  b.custorderno=c.custorderno and b.cartonno=c.cartonno
                                 and b.custorderno=e.custorderno
                                group by c.custorderno,c.cartonno,c.styleno,c.step, e.customerid,a.shippeddate) o1
                                left join (
                                select a.customerid,b.styleno,b.checktype,b.reworkratio,c.effectivedate,c.expireddate,c.unit,c.currency,c.price
                                from tinppricing a,tinppricingdtl b,tinppricingdtldef c
                                where a.prisysid=b.prisysid and b.pridtlsysid=c.pridtlsysid) o2 
                                on o1.customerid=o2.customerid and o1.checktype=o2.checktype and o1.styleno=o2.styleno
                                and o1.shippeddate>=o2.effectivedate and o1.shippeddate<=ISNULL(o2.expireddate,'2999-1-1')
                                inner join tsysstaticvalue o3 on o1.checktype=o3.svvalue and o3.svtype='" + MES_StaticValue_Type.Step.ToString() + @"'
                                ) o order by o.custorderno,o.cartonno,o.checktype";

                DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetShippingSumRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string subSql = "select distinct customerid,custorderno,cartonno from tinppackingrecdtl where 1=1";
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

                string sSql = @"select * from (
                                select a.custorderno,a.cartonno,d.checktype,b.customerid,b.customername  ,SUM(a.pairqty) as pairqty,a.pktype,a.isshipped
                                from tinppackingrecdtl a,tmdlcustomer b,("+subSql+@") c,
                                (select distinct customerid,custorderno,cartonno,checktype from tinpreceivingctndtl) d,
                                (select distinct customerid,custorderno,cartonno from tinpshipping a,tinpshippingdtlctn b
                                where a.shippingsysid=b.shippingsysid and a.shippingstatus='"+MES_ShippingStatus.Shipped.ToString()+@"') e
                                where a.customerid=b.customerid and a.customerid=c.customerid 
                                and a.custorderno=c.custorderno and a.cartonno=c.cartonno
                                and a.customerid=d.customerid 
                                and a.custorderno=d.custorderno and a.cartonno=d.cartonno 
                                and a.customerid=e.customerid 
                                and a.custorderno=e.custorderno and e.cartonno=c.cartonno and a.pktype='"+MES_PackingType.Packing.ToString()+@"'
                                group by a.custorderno,a.cartonno,d.checktype,b.customerid,b.customername ,a.pktype,a.isshipped 
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

        public DataSet GetShippingSumDtlRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string subSql = "select distinct customerid,custorderno,cartonno from tinppackingrecdtl where 1=1";
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

                string sSql = @"select * from (
                                select a.custorderno,a.cartonno,b.customerid,b.customername,a.pktype,a.isshipped,a.styleno,a.size,a.color,a.pairqty
                                from tinppackingrecdtl a,tmdlcustomer b,("+subSql+@") c,
                                (select distinct customerid,custorderno,cartonno from tinpshipping a,tinpshippingdtlctn b
                                where a.shippingsysid=b.shippingsysid and a.shippingstatus='"+MES_ShippingStatus.Shipped.ToString()+@"') d
                                where a.customerid=b.customerid and a.customerid=c.customerid 
                                and a.custorderno=c.custorderno and a.cartonno=c.cartonno 
                                and a.customerid=d.customerid 
                                and a.custorderno=d.custorderno and d.cartonno=c.cartonno and a.pktype='"+MES_PackingType.Packing.ToString()+@"'
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

        public DataSet GetUnShippingSumRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string subSql = "select distinct customerid,custorderno,cartonno from tinppackingrecdtl where 1=1";
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

                string sSql = @"select * from (
                                select a.custorderno,a.cartonno,b.customerid,b.customername,a.pktype,a.isshipped,sum(a.pairqty) as pairqty
                                from tinppackingrecdtl a,tmdlcustomer b,(" + subSql+@") c,
                                (select distinct customerid,custorderno,cartonno,checktype from tinpreceivingctndtl) d
                                where a.customerid=b.customerid and a.customerid=c.customerid 
                                and a.custorderno=c.custorderno and a.cartonno=c.cartonno
                                and a.customerid=d.customerid 
                                and a.custorderno=d.custorderno and a.cartonno=d.cartonno 
                                and a.pktype='"+MES_PackingType.Packing.ToString()+@"'
                                and not exists (select * from tinpshipping sa,tinpshippingdtlctn sb
                                where sa.shippingsysid=sb.shippingsysid and sa.shippingstatus='"+MES_ShippingStatus.Shipped.ToString()+ @"' 
                                and a.customerid=sb.customerid and a.custorderno=sb.custorderno and a.cartonno=sb.cartonno)
                                group by a.custorderno,a.cartonno,b.customerid,b.customername,a.pktype,a.isshipped
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

        public DataSet GetUnShippingSumDtlRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string subSql = "select distinct customerid,custorderno,cartonno from tinppackingrecdtl where 1=1";
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

                string sSql = @"select * from (
                                select a.custorderno,a.cartonno,b.customerid,b.customername,a.pktype,a.isshipped,a.styleno,a.size,a.color,a.pairqty
                                from tinppackingrecdtl a,tmdlcustomer b,("+subSql+@") c,
                                (select distinct customerid,custorderno,cartonno,checktype from tinpreceivingctndtl) d
                                where a.customerid=b.customerid and a.customerid=c.customerid 
                                and a.custorderno=c.custorderno and a.cartonno=c.cartonno
                                and a.customerid=d.customerid 
                                and a.custorderno=d.custorderno and a.cartonno=d.cartonno 
                                and a.pktype='"+MES_PackingType.Packing.ToString()+@"'
                                and not exists (select * from tinpshipping sa,tinpshippingdtlctn sb
                                where sa.shippingsysid=sb.shippingsysid and sa.shippingstatus='"+MES_ShippingStatus.Shipped.ToString()+@"' 
                                and a.customerid=sb.customerid and a.custorderno=sb.custorderno and a.cartonno=sb.cartonno)
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


        public bool HasShipByPlanNo(string shippingplanno)
        {
            try
            {
                string sSql = @"select * from 
                                tinpshippingplan a,tinpshippingdtl b,tinpshipping c
                                where a.shippingplanno=b.shippingplanno and b.shippingsysid=c.shippingsysid and b.shippingstatus='" + MES_ShippingStatus.Shipped.ToString() + @"'
                                and a.shippingplanno='" + shippingplanno+@"'";

                DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using System.Data.SqlClient;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class PackingRecDtlDal:BaseDal
    {
        public PackingRecDtlDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinppackingrecdtl";
        }


        public DataSet GetPackingCartonRecords()
        {
            try
            {
                string sSql = @"select b.customerid, a.custorderno,c.customername,b.cartonno,sum(pairqty) as pairqty from tinppackingrec a,tinppackingrecdtl b,tmdlcustomer c
                                where a.pksysid=b.pksysid and c.customerid=b.customerid and (b.isshipped<>'" + Public_Flag.Y.ToString() + @"' or b.isshipped is null)
                                and a.pktype='" + MES_PackingType.Packing.ToString() + @"'
                                group by b.customerid,a.custorderno,c.customername,b.cartonno";

                DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPackingCartonSummaryRecords()
        {
            try
            {
                /*string sSql = @"select o.custorderno,o.customerid,o.customername,COUNT(*) as cartonqty from (
                                select distinct a.custorderno,c.customerid,d.customername,b.cartonno 
                                from tinppackingrec a,tinppackingrecdtl b,(select distinct b1.customerid,b2.custorderno from tinpworkorder b1,tinpworkorderdtl b2
                                where b1.workordersysid =b2.workordersysid) c,tmdlcustomer d
                                where a.pksysid=b.pksysid and a.custorderno=c.custorderno and c.customerid=d.customerid and (b.isshipped<>'" + Public_Flag.Y.ToString() + @"' or b.isshipped is null) and a.pktype='" + MES_PackingType.Packing.ToString() + @"') o                               
                                group by o.custorderno,o.customerid,o.customername";*/
                string sSql = @"select b.custorderno,a.customerid,a.factory,c.customername,COUNT(*) as cartonqty 
                                from tinpreceiving a,tinpreceivingctndtl b,tmdlcustomer c
                                where a.recsysid=b.recsysid and b.cartonlocation<>'" +MES_CartonLocation.Shipped.ToString()+@"'
                                and a.customerid=c.customerid
                                group by b.custorderno,a.customerid,a.factory,c.customername";


                DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateIsShipped(string customerid,string custorderno, string cartonno, string isshipped)
        {
            try
            {
                string sSql = @"update a set a.isshipped='" + isshipped + @"'
                                from tinppackingrecdtl a,tinppackingrec b
                                where a.pksysid=b.pksysid and a.customerid='" + customerid + @"' and a.cartonno='" + cartonno + "' and b.custorderno='" + custorderno + "' and  b.pktype='" + MES_PackingType.Packing.ToString() + "'";

                SqlHelper.ExecuteNonQuery(dbInstance, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPackingDtlSumRecords(List<MESParameterInfo> lstParameters)
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
                                (select distinct customerid,custorderno,cartonno,checktype from tinpreceivingctndtl) d
                                where a.customerid=b.customerid and a.customerid=c.customerid 
                                and a.custorderno=c.custorderno and a.cartonno=c.cartonno
                                and a.customerid=d.customerid 
                                and a.custorderno=d.custorderno and a.cartonno=d.cartonno
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

        public DataSet GetPackingDtlRecords(List<MESParameterInfo> lstParameters)
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
                                select a.custorderno,a.cartonno,b.customerid,b.customername,a.pktype,a.isshipped,a.styleno,a.size,a.color,a.pairqty,a.reqairqty
                                from (select t.*,t1.pairqty as reqairqty from tinppackingrecdtl t left join (select pksysid,custorderno,cartonno,styleno,color,size,SUM(pairqty) as pairqty
                                    from tinppackingrecretrieve group by pksysid,custorderno,cartonno,styleno,color,size) t1
                                    on t.pksysid=t1.pksysid and t.custorderno=t1.custorderno
                                    and t.cartonno=t1.cartonno and t.styleno=t1.styleno
                                    and t.color=t1.color and t.size=t1.size) a,tmdlcustomer b,(" + subSql + @") c
                                where a.customerid=b.customerid and a.customerid=c.customerid 
                                and a.custorderno=c.custorderno and a.cartonno=c.cartonno
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


        public DataSet GetHaveNotMovingDtlSumRecords(List<MESParameterInfo> lstParameters)
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
                                from tinppackingrecdtl a,tmdlcustomer b,(" + subSql + @") c,
                                (select distinct customerid,custorderno,cartonno,checktype from tinpreceivingctndtl) d
                                where a.customerid=b.customerid and a.customerid=c.customerid 
                                and a.custorderno=c.custorderno and a.cartonno=c.cartonno
                                and a.customerid=d.customerid 
                                and a.custorderno=d.custorderno and a.cartonno=d.cartonno
                                group by a.custorderno,a.cartonno,d.checktype,b.customerid,b.customername ,a.pktype,a.isshipped 
                                ) rt
                                where checktype='IX' and pktype='" + MES_PackingType.Unpacking.ToString() + @"' 
                                and not exists (select * from tinppackingrecdtl t where t.customerid=rt.customerid and t.custorderno=rt.custorderno and t.cartonno=rt.cartonno and t.pktype='" + MES_PackingType.Moving.ToString() + @"')";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, false, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetHaveNotMovingDtlRecords(List<MESParameterInfo> lstParameters)
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
                                select a.custorderno,a.cartonno,b.customerid,b.customername,a.pktype,a.isshipped,a.styleno,a.size,a.color,a.pairqty,d.checktype
                                from tinppackingrecdtl a,tmdlcustomer b,(" + subSql + @") c,
                                (select distinct customerid,custorderno,cartonno,checktype from tinpreceivingctndtl) d
                                where a.customerid=b.customerid and a.customerid=c.customerid 
                                and a.custorderno=c.custorderno and a.cartonno=c.cartonno
                                and a.customerid=d.customerid 
                                and a.custorderno=d.custorderno and a.cartonno=d.cartonno
                                ) rt
                                where checktype='IX' and pktype='" + MES_PackingType.Unpacking.ToString() + @"' 
                                and not exists (select * from tinppackingrecdtl t where t.customerid=rt.customerid and t.custorderno=rt.custorderno and t.cartonno=rt.cartonno and t.pktype='" + MES_PackingType.Moving.ToString() + @"')";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, false, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetHaveNotPackingDtlSumRecords(List<MESParameterInfo> lstParameters)
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
                                from tinppackingrecdtl a,tmdlcustomer b,(" + subSql + @") c,
                                (select distinct customerid,custorderno,cartonno,checktype from tinpreceivingctndtl) d
                                where a.customerid=b.customerid and a.customerid=c.customerid 
                                and a.custorderno=c.custorderno and a.cartonno=c.cartonno
                                and a.customerid=d.customerid 
                                and a.custorderno=d.custorderno and a.cartonno=d.cartonno
                                group by a.custorderno,a.cartonno,d.checktype,b.customerid,b.customername ,a.pktype,a.isshipped 
                                ) rt
                                where (((checktype='I' or checktype='X') and pktype='" + MES_PackingType.Unpacking.ToString() + @"' 
                                and not exists (select * from tinppackingrecdtl t where t.customerid=rt.customerid and t.custorderno=rt.custorderno and t.cartonno=rt.cartonno and t.pktype='" + MES_PackingType.Packing.ToString() + @"'))
                                or ((checktype='IX') and pktype='" + MES_PackingType.Moving.ToString() + @"' 
                                and not exists (select * from tinppackingrecdtl t where t.customerid=rt.customerid and t.custorderno=rt.custorderno and t.cartonno=rt.cartonno and t.pktype='" + MES_PackingType.Packing.ToString() + @"')))";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, false, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetHaveNotPackingDtlRecords(List<MESParameterInfo> lstParameters)
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
                                select a.custorderno,a.cartonno,b.customerid,b.customername,a.pktype,a.isshipped,a.styleno,a.size,a.color,a.pairqty,d.checktype
                                from tinppackingrecdtl a,tmdlcustomer b,(" + subSql + @") c,
                                (select distinct customerid,custorderno,cartonno,checktype from tinpreceivingctndtl) d
                                where a.customerid=b.customerid and a.customerid=c.customerid 
                                and a.custorderno=c.custorderno and a.cartonno=c.cartonno
                                 and a.customerid=d.customerid 
                                and a.custorderno=d.custorderno and a.cartonno=d.cartonno
                                ) rt
                                where (((checktype='I' or checktype='X') and pktype='" + MES_PackingType.Unpacking.ToString() + @"' 
                                and not exists (select * from tinppackingrecdtl t where t.customerid=rt.customerid and t.custorderno=rt.custorderno and t.cartonno=rt.cartonno and t.pktype='" + MES_PackingType.Packing.ToString() + @"'))
                                or ((checktype='IX') and pktype='" + MES_PackingType.Moving.ToString() + @"' 
                                and not exists (select * from tinppackingrecdtl t where t.customerid=rt.customerid and t.custorderno=rt.custorderno and t.cartonno=rt.cartonno and t.pktype='" + MES_PackingType.Packing.ToString() + @"')))";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, false, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetLineWarehouseSumRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string subSql = "select distinct customerid,custorderno,cartonNumber from tinpLineWarehouse where 1=1";
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
                                select a.customerid,b.customername, a.custorderno,a.cartonNumber as cartonno,a.checktype, sum(a.pairqty) as  pairqty 
                                from tinpLineWarehouse a ,tmdlcustomer b,(" + subSql+ @") c
                                where a.customerid=b.customerid and a.customerid=c.customerid 
                                and a.custorderno=c.custorderno and a.cartonNumber=c.cartonNumber
                                group by a.customerid,b.customername, a.custorderno,a.cartonNumber,a.checktype
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


        public DataSet GetLineWarehouseSumDtlRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string subSql = "select distinct customerid,custorderno,cartonNumber from tinpLineWarehouse where 1=1";
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
                                select a.customerid,b.customername, a.custorderno,a.cartonNumber as cartonno,a.checktype, a.pairqty,a.styleno,a.size,a.color
                                from tinpLineWarehouse a ,tmdlcustomer b,(" + subSql+@") c
                                where a.customerid=b.customerid and a.customerid=c.customerid 
                                and a.custorderno=c.custorderno and a.cartonNumber=c.cartonNumber
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

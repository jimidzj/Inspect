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
    public class RepairFailDal:BaseDal
    {
        public RepairFailDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinprepairfail";
        }

        public override DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber)
        {
            try
            {
                string sSql = @"select * from (
                                select a.*,b.reasoncodedesc from tinprepairfail a,tmdlreasoncode b
                                where a.reasoncode=b.reasoncode) rt where 1=1";
               

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, isExtract, maxRecordNumber);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetLeftRepairSuccessQty(string custorderno, string styleno, string color, string size,string step)
        {
            int result=0;
            try
            {
                string sSql =  @"select a.custorderno,a.styleno,a.color,a.size,a.step,a.pairqty-ISNULL(b.pairqty,0) as leftqty
                                from
                                (select custorderno,styleno,color,size,step,SUM(pairqty) as pairqty 
                                from tinprepairhis where reptype='RepairSuccess'
                                and custorderno='" + custorderno + @"' and styleno='" + styleno + @"' and color='" + color + @"' and size='" + size + @"' and step='"+step+@"'
                                group by custorderno,styleno,color,size,step) a
                                left join
                                (select custorderno,styleno,color,size,step,SUM(pairqty) as pairqty 
                                from tinppackingrecretrieve
                                where custorderno='" + custorderno + @"' and styleno='" + styleno + @"' and color='" + color + @"' and size='" + size + @"' and step='" + step + @"'
                                group by custorderno,styleno,color,size,step) b 
                                on a.custorderno=b.custorderno and a.styleno=b.styleno
                                and a.color=b.color and a.size=b.size and a.step=b.step";

                DataTable dt = SqlHelper.ExecuteQuery(sSql, new SqlParameter[]{}).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    result = Convert.ToInt16(dt.Rows[0]["leftqty"]);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataSet GetRepairInfoForInspectRpt(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from
                                (select a.*,b.unpackingpairqty,c.movingpairqty from
                                (select customerid,custorderno,styleno,color,size,checktype,SUM(pairqty) as orderpairqty
                                from tinpreceivingctndtl 
                                group by customerid,custorderno,styleno,color,size,checktype) a
                                left join
                                (select customerid,custorderno,styleno,color,size,SUM(pairqty) as unpackingpairqty
                                from tinppackingrecdtl where pktype='Unpacking'
                                group by customerid,custorderno,styleno,color,size) b
                                on a.customerid=b.customerid and a.custorderno=b.custorderno 
                                and a.styleno=b.styleno and a.color=b.color and a.size=b.size
                                left join
                                (select customerid,custorderno,styleno,color,size,SUM(pairqty) as movingpairqty
                                from tinppackingrecdtl where pktype='Moving'
                                group by customerid,custorderno,styleno,color,size) c
                                on a.customerid=c.customerid and a.custorderno=c.custorderno 
                                and a.styleno=c.styleno and a.color=c.color and a.size=c.size) rt where 1=1";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, false, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetRepairFailForInspectRpt(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from
                                (select a.customerid,a.custorderno,a.styleno,a.color,a.size,c.reasoncategory,c.reasoncodedesc,c.jpdesc,SUM(b.pairqty) as pairqty,a.isfirst,a.reptype,a.step
                                from tinprepairhis a,tinprepairfail b,tmdlreasoncode c
                                where a.repsysid=b.repsysid and b.reasoncode=c.reasoncode
                                group by a.customerid,a.custorderno,a.styleno,a.color,a.size,c.reasoncategory,c.reasoncodedesc,c.jpdesc,a.isfirst,a.reptype,a.step) rt where 1=1";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, false, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetShippedForInspectRpt(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from
                                (select b.customerid,b.custorderno,c.styleno,c.color,c.size,SUM(c.pairqty) as pairqty
                                from tinpshipping a,tinpshippingdtlctn b,tinppackingrecdtl c
                                where a.shippingsysid=b.shippingsysid and b.customerid=c.customerid and b.custorderno=c.custorderno
                                and b.cartonno=c.cartonno and a.shippingstatus='" +MES_ShippingStatus.Shipped.ToString() + @"' and c.pktype='"+MES_PackingType.Packing.ToString()+@"'
                                group by b.customerid,b.custorderno,c.styleno,c.color,c.size) rt where 1=1";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, false, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetHeaderInfoForInspectRpt(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from
                                (select distinct a.customerid,c.customername,a.factory,b.custorderno
                                from tinpreceiving a,tinpreceivingctndtl b, tmdlcustomer c
                                where a.recsysid=b.recsysid and a.customerid=c.customerid
                                ) rt where 1=1";

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

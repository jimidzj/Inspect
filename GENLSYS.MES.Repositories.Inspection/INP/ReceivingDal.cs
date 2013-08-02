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
    public class ReceivingDal: BaseDal
    {
        public ReceivingDal(DBInstance dbi)
            : base(dbi)
        {
        }

        public bool CheckUsed(string recsysid)
        {
            try
            {
                string sSql = @"select * from tinpreceivingctndtl a,tinppackingrecdtl b
                                where a.customerid=b.customerid and a.custorderno=b.custorderno and a.cartonno=b.cartonno
                                and a.color=b.color and a.size=b.size and a.styleno=b.styleno
                                and a.recsysid='" + recsysid + @"'";

                DataSet ds = SqlHelper.ExecuteQuery(sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());
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

        public DataSet GetReceivingRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select distinct recsysid,recno,customername as customerid,deliverydate,weather,receivedate,receiver,remark,lastmodifiedtime,lastmodifieduser,factory from ( 
                                  select a.*,b.styleno,c.customername,b.custorderno
                                  from tinpreceiving a,tinpreceivingdtl b,tmdlcustomer c
                                  where a.recsysid = b.recsysid and a.customerid=c.customerid) rt where 1=1";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters,false, 10000000);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetReceivingDetailRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from ( 
                                select '' as flag,a.recsysid,a.reclineno,b.customerid,a.custorderno,a.styleno,a.color,a.size,a.cartonno,a.cartonqty,a.pairqty,a.checktype,a.ismixed,a.logo,a.linetype,a.linereason,a.remark,b.receivedate
                                from tinpreceivingdtl a,tinpreceiving b 
                                where a.recsysid=b.recsysid) rt where 1=1 ";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, true, 10000000);

                sqlSet.SQLStatement += " order by cast(reclineno as int)";

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetReceivingCartonDetailRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from (select b.recsysid,a.reclineno, b.custorderno,a.cartonno,a.styleno,a.color,a.size,a.pairqty,b.checktype,a.ismixed,a.cartonstatus,a.cartonlocation
                                from tinpreceivingctndtl a,tinpreceivingdtl b 
                                where a.recsysid = b.recsysid and a.reclineno = b.reclineno) as t where 1=1 ";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, true, 10000000);

                sqlSet.SQLStatement += " order by custorderno,cartonno asc ";
                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetReceivingHeader_Print(string recno)
        {
            try
            {
                string sSql = @"select recno as wono,CONVERT(char(10), receivedate, 111) as indate,customerid as customer,factory from tinpreceiving where recno=@recno";

                List<SqlParameter> lstParameters = new List<SqlParameter>(){
                    new SqlParameter(){ ParameterName="recno",Value=recno,SqlDbType= SqlDbType.VarChar}
                };

                DataSet ds = SqlHelper.ExecuteQuery(sSql, lstParameters.ToArray());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetReceivingDetail_Print(string recno)
        {
            try
            {
                string sSql = @"select custorderno as orderno,styleno,count(*) as cartonqty,sum(pairqty) as pairqty,min(a.remark) as remark
                                from tinpreceivingctndtl a,tinpreceiving b
                                where a.recsysid = b.recsysid
                                and   b.recno=@recno
                                group by custorderno,styleno";

                List<SqlParameter> lstParameters = new List<SqlParameter>(){
                    new SqlParameter(){ ParameterName="recno",Value=recno,SqlDbType= SqlDbType.VarChar}
                };

                DataSet ds = SqlHelper.ExecuteQuery(sSql, lstParameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CheckDuplicate(string custorderno,string styleno,string color,string size,string cartonno)
        {
            string sql = @"select distinct b.recno from tinpreceivingctndtl a,tinpreceiving b
                                            where a.recsysid = b.recsysid and custorderno='" + custorderno + @"' 
                                            and styleno='" + styleno + @"' 
                                            and color='" + color + @"' 
                                            and size='" + size + @"'
                                            and cartonno='" + cartonno + "'";
            DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection,dbInstance.Transaction, sql, new SqlParameter[] { });
            string recno = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (recno == string.Empty)
                    recno = ds.Tables[0].Rows[i][0].ToString();
                else
                    recno += "," + ds.Tables[0].Rows[i][0].ToString();
            }

            return recno;
        }
    }
}

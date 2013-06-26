using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.Repositories.Common;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class IQCDal : BaseDal
    {
        public IQCDal(DBInstance dbi)
            : base(dbi)
        {
        }

        public DataSet GetIQCRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from (select a.iqcsysid,b.customername,b.customerid,a.factory,a.styleno,a.bootheight,a.checkrequest,a.checktype,
	                                   a.checkresult,a.returntype,a.returncartonqty,a.iqcdate,a.remark,
	                                   a.createdtime,a.createduser,a.lastmodifiedtime,a.lastmodifieduser,a.category
                                from tinpiqc a,tmdlcustomer b where a.customerid = b.customerid) as t where 1=1  ";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, true, 10000000);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetIQCFail(string iqcsysid)
        {
            try
            {
                string sSql = @"SELECT a.reasoncategory as reasoncategoryid,a.reasoncategorydesc as reasoncategory,
                                       b.reasoncode as reasoncodeid,b.reasoncodedesc as reasoncode,
                                       isnull(c.reasoncomment,'') as reasoncomment,
	                                   case when c.reasoncode is null then 'N' else 'Y' end as selected 
                                FROM  tmdlreasoncategory a inner join tmdlreasoncode b on a.reasoncategory = b.reasoncategory
                                left join (select * from tinpiqcfail where iqcsysid='" + iqcsysid + @"') c on b.reasoncode = c.reasoncode where 1=1 and a.reasoncategory like '%IQC%'";

                DataSet ds = SqlHelper.ExecuteQuery(sSql, new List<SqlParameter> { }.ToArray());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetIQCReturn(string iqcsysid,string styleno)
        {
            string sSql = string.Empty;
            try
            {
                string sAddition = string.Empty;

                if (iqcsysid == string.Empty)
                {
                    sAddition = "1=1";

                    sSql = @"select case when c.cartonno is null then 'N' else 'Y' end as selected,
	                                b.custorderno,a.cartonno,b.styleno,b.color,b.size,a.pairqty 
                                from tinpreceivingctndtl a inner join tinpreceivingdtl b 
                                 on a.recsysid = b.recsysid and a.reclineno = b.reclineno left join (select * from tinpiqcreturn where " + sAddition + @") c 
                                 on b.custorderno = c.custorderno and a.cartonno = c.cartonno where b.styleno='" + styleno + "' " +
                                @" and cartonlocation='" + MES_CartonLocation.Warehouse.ToString() + "' " +
                                @" and cartonstatus='" + MES_CartonStatus.Active.ToString() + "' order by b.custorderno,a.cartonno  ";
                }
                else
                {
                    sAddition = "iqcsysid='" + iqcsysid + "'";

                    sSql = @"select case when c.cartonno is null then 'N' else 'Y' end as selected,
	                                b.custorderno,a.cartonno,b.styleno,b.color,b.size,a.pairqty 
                                from tinpreceivingctndtl a inner join tinpreceivingdtl b 
                                 on a.recsysid = b.recsysid and a.reclineno = b.reclineno left join (select * from tinpiqcreturn where " + sAddition + @") c 
                                 on b.custorderno = c.custorderno and a.cartonno = c.cartonno where b.styleno='" + styleno + "' order by b.custorderno,a.cartonno  ";
                }

                DataSet ds = SqlHelper.ExecuteQuery(sSql, new List<SqlParameter> { }.ToArray());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCartonStatus(string custorderno,string cartonno)
        {
            try
            {
                string sSql = @"update tinpreceivingctndtl
                                set cartonstatus='" + MES_CartonStatus.Terminated.ToString() + @"',
                                    cartonlocation='" + MES_CartonLocation.Returned.ToString() + @"'
                                from tinpreceivingctndtl a, tinpreceivingdtl b 
                                where a.recsysid = b.recsysid and a.reclineno = b.reclineno
                                and b.custorderno = '" + custorderno + @"'
                                and a.cartonno = '" + cartonno + "'";

                SqlHelper.ExecuteNonQuery(sSql, new List<SqlParameter> { }.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RecoverCartonStatus(string custorderno, string cartonno)
        {
            try
            {
                string sSql = @"update tinpreceivingctndtl
                                set cartonstatus='" + MES_CartonStatus.Active.ToString() + @"',
                                    cartonlocation='" + MES_CartonLocation.Warehouse.ToString() + @"'
                                from tinpreceivingctndtl a,tinpreceivingdtl b 
                                where a.recsysid = b.recsysid and a.reclineno = b.reclineno
                                and b.custorderno = '" + custorderno + @"'
                                and a.cartonno = '" + cartonno + @"'
                                and a.cartonstatus='" + MES_CartonStatus.Terminated.ToString() + @"'
                                and a.cartonlocation='" + MES_CartonLocation.Returned.ToString() + @"'";

                SqlHelper.ExecuteNonQuery(sSql, new List<SqlParameter> { }.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetValidIQC(string customerid)
        {
            try
            {
                string sSql = @"select * from tinpiqc a
                                where exists (select * from (
                                select customerid,styleno,MAX(lastmodifiedtime) as lastmodifiedtime from tinpiqc 
                                group by customerid,styleno) b 
                                where a.customerid=b.customerid and a.styleno=b.styleno and a.lastmodifiedtime=b.lastmodifiedtime)";

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

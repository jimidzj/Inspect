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
    public class ReturnDtlDal:BaseDal
    {
        public ReturnDtlDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinpreturndtl";
        }

        public override DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber)
        {
            try
            {
                string sSql = @"select * from (select a.retsysid,a.returnno,a.returntype,a.returndate,a.returnuser,c.customerid,c.customername,b.custorderno,b.styleno,b.color,b.size,b.checktype,b.pairqty,b.remark 
                                from tinpreturn a,tinpreturndtl b,tmdlcustomer c
                                where a.retsysid=b.retsysid and a.customerid=c.customerid) rt
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
    }
}

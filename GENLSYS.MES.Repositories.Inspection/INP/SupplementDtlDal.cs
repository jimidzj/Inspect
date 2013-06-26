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
    public class SupplementDtlDal : BaseDal
    {
        public SupplementDtlDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinpsupplementdtl";
        }

        public override DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber)
        {
            try
            {
                string sSql = @"select * from (select a.supplementno,a.step,a.workgroup,a.factory,b.*,c.customername,a.supplementdate,a.supplementuser 
                                from tinpsupplement a,tinpsupplementdtl b,tmdlcustomer c
                                where a.suplsysid=b.suplsysid and c.customerid=a.customerid) rt
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

        public object GetSelectedRecords(List<MESParameterInfo> lstParams, string p, bool p_2, int p_3)
        {
            throw new NotImplementedException();
        }
    }
}

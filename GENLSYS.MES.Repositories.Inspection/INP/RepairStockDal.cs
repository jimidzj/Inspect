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
    public class RepairStockDal : BaseDal
    {
        public RepairStockDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinprepairstock";
        }


        public DataSet GetRepairStockRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from (select a.*,b.customername
                                from tinprepairstock a,tmdlcustomer b
                                where a.customerid=b.customerid) rt
                                where curpairqty>0";

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

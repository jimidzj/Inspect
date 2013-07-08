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
    public class RepairHisDal:BaseDal
    {
        public RepairHisDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinprepairhis";
        }

        public DataSet GetRepairHisRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string whereSql = "";
                if (MESParameterInfo.GetColumnValue(lstParameters, "fromdate") != null)
                {
                    whereSql += " and claimtime >= '" + MESParameterInfo.GetColumnValue(lstParameters, "fromdate") + "'";
                    MESParameterInfo.RemoveColumnInfo(lstParameters, "fromdate");
                }
                if (MESParameterInfo.GetColumnValue(lstParameters, "todate") != null)
                {
                    whereSql += " and claimtime < '" + MESParameterInfo.GetColumnValue(lstParameters, "todate") + "'";
                    MESParameterInfo.RemoveColumnInfo(lstParameters, "todate");
                }
                
                string sSql = @"select * from
                                (select a.*,b.reasoncode, isnull(b.pairqty,a.pairqty) as qty,c.customername from 
                                tinprepairhis a left join tinprepairfail b on a.repsysid=b.repsysid
                                inner join tmdlcustomer c on a.customerid=c.customerid) rt where 1=1" + whereSql;

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

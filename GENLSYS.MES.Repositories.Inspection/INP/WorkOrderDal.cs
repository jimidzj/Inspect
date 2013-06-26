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
    public class WorkOrderDal: BaseDal
    {
        public WorkOrderDal(DBInstance dbi)
            : base(dbi)
        {
        }

        public DataSet GetWorkOrderRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from (select a.workordersysid,a.workorderno,b.customerid as customerid,b.customername,a.factory,
                                        a.workorderstatus,a.remark,a.createdtime,a.createduser,a.lastmodifiedtime,a.lastmodifieduser
                                from tinpworkorder a,tmdlcustomer b
                                where a.customerid = b.customerid) as t1 where 1=1  ";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, true, 10000000);

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

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
    public class WorkOrderDtlDal: BaseDal
    {
        public WorkOrderDtlDal(DBInstance dbi)
            : base(dbi)
        {
        }

        /// <summary>
        /// for work order edit
        /// </summary>
        /// <param name="lstParameters"></param>
        /// <returns></returns>
        public DataSet GetWorkOrderDetailRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select a.workordersysid,a.workorderlineno,a.custorderno,a.styleno,
	                                   a.schcartonqty,a.schpairqty,a.schdlydate,a.schshpdate,a.checktype,
	                                   a.remark,a.completedtime,a.completeduser
                                from tinpworkorderdtl a where 1=1";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, true, 10000000);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCustOrderForReceiving(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select a.*
                                from tinpworkorderdtl a,tinpworkorder b     
                                where a.workordersysid = b.workordersysid
                                and b.workorderstatus='Active'";

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

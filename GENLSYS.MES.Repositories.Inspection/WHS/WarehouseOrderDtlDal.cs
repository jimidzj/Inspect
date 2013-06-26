using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.Inspection.WHS
{
    public class WarehouseOrderDtlDal: BaseDal
    {
        public WarehouseOrderDtlDal(DBInstance dbi)
            : base(dbi)
        {
        }

        public DataSet GetWarehouseOrderDetailRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select a.wosysid,a.wolineno,b.custorderno,b.styleno,
	                                   b.color,b.size,a.cartonno,a.pairqty,a.trayno
                                from twhsorderdtl a,tinpcustorder b
                                where a.custordersysid = b.custordersysid";

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
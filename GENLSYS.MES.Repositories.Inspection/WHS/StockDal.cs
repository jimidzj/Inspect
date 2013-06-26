using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using System.Data.SqlClient;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Repositories.Inspection.WHS
{
    public class StockDal : BaseDal
    {
        public StockDal(DBInstance dbi)
            : base(dbi)
        {
        }

        public DataSet GetStockRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select a.whno,a.location,a.cartonno,b.custorderno,b.styleno,
	                                   b.color,b.size,a.pairqty,a.lastupdatedtime,a.lastupdateduser
                                from twhsstock a,tinpcustorder b
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

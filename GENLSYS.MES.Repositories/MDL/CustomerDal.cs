using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.MDL
{
    public class CustomerDal:BaseDal
    {
        public CustomerDal(DBInstance dbi)    : base(dbi)
        {
        }

        public DataSet GetContactRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from tmdlcontact where 1=1 ";

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

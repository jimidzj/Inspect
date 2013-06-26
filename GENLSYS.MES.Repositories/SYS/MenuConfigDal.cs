using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using GENLSYS.MES.Utility.Database;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.SYS
{
    public class MenuConfigDal:BaseDal
    {
        public MenuConfigDal(DBInstance dbi)           : base(dbi)
        {
        }

        public List<tsysmenuconfig> GetTopMenuList(string menutype)
        {
            try
            {
                string sSql = @"SELECT *
                                  FROM tsysmenuconfig
                                 WHERE parentmenuitemid IS NULL AND menutype =@menutype";

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "menutype",
                    ParamValue = menutype,
                    ParamType = "string"
                });

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, true, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());


                return this.ConvertDatasetToObjectList<tsysmenuconfig>(ds); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

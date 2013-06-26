using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using System.Data.SqlClient;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Repositories.SYS
{
    public class StaticValueDal : BaseDal
    {
        public StaticValueDal(DBInstance dbi)
            : base(dbi)
        {
        }

        public DataSet getStaticValue(string svType)
        {
            try
            {
                string sSql = @"SELECT svtext , svvalue
                                FROM         tsysstaticvalue
                                WHERE     (svtype = @svtype) and svstatus='Active'
                                ORDER BY svtext";

                List<SqlParameter> lstParameters = new List<SqlParameter>();
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "svtype",
                    SqlDbType = SqlDbType.VarChar,
                    Value = svType
                });

                DataSet ds = SqlHelper.ExecuteQuery(sSql, lstParameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void autoInsertColor(string svtext,string svvalue,string currentuser)
        {
            try
            {
                string sSql = @"insert into tsysstaticvalue(svid,svtype,svtext,svvalue,svstatus,lastmodifiedtime,lastmodifieduser) 
                                  select top 1 '" + Function.GetGUID() + "', 'ShoeColor','" + svtext +"','"+svvalue+"','Active',GETDATE(),'" + currentuser + @"'
                                  from tsysstaticvalue where  not exists (select 1 from tsysstaticvalue where svtype='ShoeColor' and
                                  svtext='" + svtext + "') ";

                List<SqlParameter> lstParameters = new List<SqlParameter>();

                SqlHelper.ExecuteNonQuery(dbInstance.Transaction, CommandType.Text,sSql, lstParameters.ToArray<SqlParameter>());

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

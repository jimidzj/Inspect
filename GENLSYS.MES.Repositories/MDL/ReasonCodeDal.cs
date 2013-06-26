using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.MDL
{
    public class ReasonCodeDal : BaseDal
    {
        public ReasonCodeDal(DBInstance dbi)      : base(dbi)
        {
        }

        public override DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber)
        {
            try
            {
                string sSql = @"select * from (select a.*,b.reasoncategorydesc 
                                from tmdlreasoncode a,tmdlreasoncategory b
                                where a.reasoncategory=b.reasoncategory) rt
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

        public List<tmdlreasoncode> GetReasonCodeList_ByCategoryStep(string reasonCodeCategory,string stepsysid)
        {
            try
            {
                string sSql = @"SELECT a.*
                                  FROM tmdlreasoncode a
                                 WHERE reasoncategory=@reasoncategory1 
                                 AND NOT EXISTS (SELECT 1
                                                     FROM tmdlreasoncodestep b
                                                    WHERE a.reasoncode = b.reasoncode)
                                UNION
                                SELECT a.*
                                  FROM tmdlreasoncode a, tmdlreasoncodestep b
                                 WHERE a.reasoncode = b.reasoncode 
                                 AND  a.reasoncategory=@reasoncategory2 ";

                List<SqlParameter> lstParameters = new List<SqlParameter>();
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "reasoncategory1",
                    SqlDbType = SqlDbType.VarChar,
                    Value = reasonCodeCategory
                });
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "reasoncategory2",
                    SqlDbType = SqlDbType.VarChar,
                    Value = reasonCodeCategory
                });

                if (stepsysid != string.Empty)
                {
                    sSql += " AND b.stepsysid =@stepsysid";

                    lstParameters.Add(new SqlParameter()
                    {
                        ParameterName = "stepsysid",
                        SqlDbType = SqlDbType.VarChar,
                        Value = stepsysid
                    });
                }

                DataSet ds = SqlHelper.ExecuteQuery(sSql, lstParameters.ToArray<SqlParameter>());

                return ConvertDatasetToObjectList<tmdlreasoncode>(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

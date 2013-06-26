using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.SYS
{
    public class AttributeTemplateDetailDal : BaseDal
    {
        public AttributeTemplateDetailDal(DBInstance dbi)
            : base(dbi)
        {
            TableName = "tsysattrtplatedtl";
        }

        public override DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber)
        {
            try
            {
                string sSql = @"select attributename,attributetype,valuetype,'' as attributevalue,seqno,
                                        lastmodifieduser,lastmodifiedtime 
                                from tsysattrtplatedtl
                                where attrtplatid=@attrtplatid";

                DataSet ds = SqlHelper.ExecuteQuery(sSql, ConvertMESParameter2SqlParameter(lstParameters).ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetMaxSeqno(string usedby)
        {
            string sSql = "select max(seqno) as seqno from " + TableName + " where usedby =@usedby";
            List<SqlParameter> lstParameters = new List<SqlParameter>();
            lstParameters.Add(new SqlParameter()
            {
                ParameterName = "usedby",
                SqlDbType = SqlDbType.VarChar,
                Value = usedby
            });

            DataSet ds = SqlHelper.ExecuteQuery(sSql, lstParameters.ToArray<SqlParameter>());

            if (ds.Tables[0].Rows[0][0].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
        }
    }
}

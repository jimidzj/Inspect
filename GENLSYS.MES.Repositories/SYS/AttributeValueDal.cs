using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.DataContracts;
using System.Data;
using GENLSYS.MES.Utility.Database;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.SYS
{
    public class AttributeValueDal : BaseDal
    {
        public AttributeValueDal(DBInstance dbi)        : base(dbi)
        {
            TableName = "tsysattributetable";
        }

         

        public decimal GetMaxAttributeId()
        {
            string sSql = "select max(attributeid) as attributeid from " + TableName;

            DataSet ds = SqlHelper.ExecuteQuery(sSql, new SqlParameter[] { });

            if (ds.Tables[0].Rows[0][0].ToString()==string.Empty)
            {
                return 0;
            }
            else
            {
                return Decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
        }

        public void CopyAttribute(string oldAttributeId, string newAttributeId,string eventUser,DateTime  eventTime)
        {
            try
            {
                string sSql = @"insert into tsysattributevalue(attributeid,seqno,attributename,attributevalue,
                                attributetype,valuetype,usedby,lastmodifieduser,lastmodifiedtime) 
                            select '" + newAttributeId + @"',seqno,attributename,attributevalue,attributetype,valuetype,
                                   usedby,'" + eventUser + "',to_date('" + eventTime.ToString("yyyy-MM-dd HH:mm:ss") + @"','yyyy-mm-dd hh24:mi:ss')
                            from tsysattributevalue
                            where attributeid='" + oldAttributeId + "'";

                SqlHelper.ExecuteNonQuery(dbInstance, sSql, new SqlParameter[] { });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

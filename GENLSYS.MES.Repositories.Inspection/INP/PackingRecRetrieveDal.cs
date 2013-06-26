using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data.SqlClient;
using GENLSYS.MES.Common;
using System.Data;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class PackingRecRetrieveDal:BaseDal
    {
        public PackingRecRetrieveDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinpshippingretrieve";
        }

        public void InsertRetrieve(string pksysid, string cartonno,string custorderno,string styleno,string color,string size)
        {
            try
            {
                string sSql = @"insert into tinppackingrecretrieve (retrievesysid,pksysid,cartonno,custorderno,styleno,color,size,step,pairqty)
                                select NEWID(),'" + pksysid + @"','" + cartonno + @"',a.custorderno,a.styleno,a.color,a.size,a.step,a.pairqty-ISNULL(b.pairqty,0)
                                from
                                (select custorderno,styleno,color,size,step,SUM(pairqty) as pairqty 
                                from tinprepairhis where reptype='" + MES_RepairType.RepairSuccess.ToString() + @"'
                                and custorderno='" + custorderno + @"' and styleno='" + styleno + @"' and color='" + color + @"' and size='" + size + @"'
                                group by custorderno,styleno,color,size,step) a
                                left join
                                (select custorderno,styleno,color,size,step,SUM(pairqty) as pairqty 
                                from tinppackingrecretrieve
                                where custorderno='" + custorderno + @"' and styleno='" + styleno + @"' and color='" + color + @"' and size='" + size + @"'
                                group by custorderno,styleno,color,size,step) b 
                                on a.custorderno=b.custorderno and a.styleno=b.styleno
                                and a.color=b.color and a.size=b.size and a.step=b.step
                                where a.pairqty-ISNULL(b.pairqty,0)>0";

                SqlHelper.ExecuteNonQuery(dbInstance, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber)
        {
            try
            {
                string sSql = @"select * from (
                                select a.customerid,b.*,d.checktype,c.shippingsysid,e.factory  
                                from tinppackingrec a,tinppackingrecretrieve b,tinpshippingdtlctn c,tinpreceivingctndtl d,tinpreceiving e
                                where a.pksysid=b.pksysid and a.customerid=c.customerid and b.custorderno=c.custorderno and b.cartonno=c.cartonno
                                and d.recsysid=e.recsysid and a.customerid=d.customerid and b.custorderno=d.custorderno 
                                and b.cartonno=d.cartonno and b.styleno=d.styleno and b.color=d.color and b.size=d.size) rt where 1=1";


                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, isExtract, maxRecordNumber);

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

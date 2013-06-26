using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class UnpackingDtlDal:BaseDal
    {
        public UnpackingDtlDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinpunpackingdtl";
        }


        public DataSet GetPackingCartonRecords()
        {
            try
            {
                string sSql = @"select a.custorderno,d.customername,b.cartonno,sum(pairqty) as pairqty from tinppackingrec a,tinpunpackingdtl b,tinpcustorder c,tmdlcustomer d
                                where a.pksysid=b.pksysid and a.custorderno=c.custorderno and c.customerid=d.customerid and b.pktype='" + MES_PackingType.Packing.ToString()+ @"'
                                group by a.custorderno,d.customername,b.cartonno";                               
               
                DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPackingCartonSummaryRecords()
        {
            try
            {
                string sSql = @"select o.custorderno,o.customername,COUNT(*) as cartonqty from (
                                select distinct a.custorderno,d.customername,b.cartonno from tinppackingrec a,tinpunpackingdtl b,tinpcustorder c,tmdlcustomer d
                                where a.pksysid=b.pksysid and a.custorderno=c.custorderno and c.customerid=d.customerid and b.pktype='"+MES_PackingType.Packing.ToString()+@"') o
                                group by o.custorderno,o.customername";


                DataSet ds = SqlHelper.ExecuteQuery(dbInstance.Connection, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePKType(string custorderno,string cartonno, string status)
        {
            try
            {
                string sSql = @"update a set a.pktype='" + status + @"'
                                from tinpunpackingdtl a,tinppackingrec b
                                where a.pksysid=b.pksysid and a.cartonno='" + cartonno + "' and b.custorderno='" + custorderno + "'";

                SqlHelper.ExecuteNonQuery(dbInstance, sSql, (new List<SqlParameter>()).ToArray<SqlParameter>());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class OpenBoxDal : BaseDal
    {
        public OpenBoxDal(DBInstance dbi)
            : base(dbi)
        {

        }

        public DataSet GetPORecords(List<MESParameterInfo> lstParameters)
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


        public String OpenBoxCheckGroupCounter(String cartonno, String poid)
        {
            try
            {
                string sSql = @"SELECT     COUNT(*) AS count"
+ " FROM         tinpreceivingctndtl where cartonno='" + cartonno + "'   and  custorderno='" + poid
+ "' GROUP BY cartonno, custorderno  ";


                DataSet ds = SqlHelper.ExecuteQuery(sSql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return "0";
                }
                else
                {
                    return ds.Tables[0].Rows[0]["count"].ToString();
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCartonLocation(string customer,string custorderno, string cartonno , string user, string location)
        {
            try
            {
                string sSql = "update tinpreceivingctndtl set cartonlocation='" + location + "' where custorderno="
                                + " '" + custorderno + "' and  cartonno='" + cartonno + "'  and  customerid='" + customer + "'";
                 SqlHelper.ExecuteNonQuery(dbInstance, sSql, new SqlParameter[] { });
                 return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool OpenBoxDeleteBox(string cartonno, string poid)
        {
            try
            {
                string sSql = "delete tinppackingrecdtl where cartonno ="
                                + " '" + cartonno + "' and custorderno='" + poid + "'";
                SqlHelper.ExecuteNonQuery(dbInstance, sSql, new SqlParameter[] { });


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

     /** 是否已经开过箱子*/
     public bool isOpened(string customer, string custorderno,string cartonno)
        {
            try
            {
                string sSql1 = "  select count(*) count  from    tinppackingrecdtl "
                             + " where  customerid='" + customer + "' and custorderno='" + custorderno + "' and cartonno='" + cartonno + "'  ";
                DataSet ds1 = SqlHelper.ExecuteQuery(sSql1);
                if (int.Parse ( ds1.Tables[0].Rows[0]["count"].ToString() )  > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
     /** 是否已经装箱子*/
     public bool isBoxing(string customer, string custorderno, string cartonno)
     {
         try
         {
             string sSql1 = "  select count(*) count  from    tinppackingrecdtl "
                          + " where  customerid='" + customer + "' and custorderno='" + custorderno + "' and cartonno='" + cartonno + "' and ( pktype='Moving' or  pktype='Packing') ";
             DataSet ds1 = SqlHelper.ExecuteQuery(sSql1);
             if (int.Parse(ds1.Tables[0].Rows[0]["count"].ToString()) > 0)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }
         catch (Exception ex)
         {
             return false;
             throw ex;
         }
     }


    /** 大货入库是否有该箱子*/
     public bool existsCarton(string customer, string custorderno, string cartonno)
     {
         try
         {
             string sSql1 = " select * from tinpreceivingctndtl a, tinpreceiving b where a.recsysid = b.recsysid "
                          + " and  b.customerid='" + customer + "' and custorderno='" + custorderno + "' and cartonno='" + cartonno + "'  ";
             DataSet ds1 = SqlHelper.ExecuteQuery(sSql1);
             if ( ds1.Tables[0].Rows.Count    > 0)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }
         catch (Exception ex)
         {
             return false;
             throw ex;
         }
     }

     /** 大货入库是否有该组*/
     public bool existsGroup(string customer, string custorderno, string cartonno, string type , string color , string size, string qty)
     {
         try
         {
             string sSql1 = " select * from tinpreceivingctndtl a, tinpreceiving b where a.recsysid = b.recsysid "
                          + " and  b.customerid='" + customer + "' and custorderno='" + custorderno + "' and cartonno='" + cartonno + "'  "
                           + " and  styleno='" + type + "' and color='" + color + "' and size='" + size + "'  and pairqty=" + qty + " "; 
                          ;
             DataSet ds1 = SqlHelper.ExecuteQuery(sSql1);
             if ( ds1.Tables[0].Rows.Count > 0)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }
         catch (Exception ex)
         {
             return false;
             throw ex;
         }
     }


     /** 用户输入是否和大货入库组数相同*/
     public bool groupsEquals(string customer, string custorderno, string cartonno ,int inputGroupsCount )
     {  
         try
         {
             string sSql1 = " select * from tinpreceivingctndtl a, tinpreceiving b where a.recsysid = b.recsysid "
                          + " and  b.customerid='" + customer + "' and custorderno='" + custorderno + "' and cartonno='" + cartonno + "'  ";
                      
             ;
             DataSet ds1 = SqlHelper.ExecuteQuery(sSql1);
             if (ds1.Tables[0].Rows.Count == inputGroupsCount)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }
         catch (Exception ex)
         {
             return false;
             throw ex;
         }
     }



     public DataSet GetMixDetail(string customerid ,string custorderno,string cartonno)
     {
            try
            {
                string sSql = " select  cartonno cartonNumber,  styleno type, color, size, pairqty qty  "
                          + "    from tinpreceivingctndtl  where "
                          + "         CUSTOMERID='" + customerid + "' AND custorderno='" + custorderno + "'  and cartonno='" + cartonno + "' "
                          + "         and cartonstatus='Active'    "
                          + "         AND ismixed='Y'  ";

                DataSet ds = SqlHelper.ExecuteQuery(sSql);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
      }


    }
}

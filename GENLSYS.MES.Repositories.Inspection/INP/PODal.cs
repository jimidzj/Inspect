using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using System.Data.SqlClient;
namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class PODal : BaseDal
    {
        public PODal(DBInstance dbi)
            : base(dbi)
        {
        }

        public DataSet GetWaitingOrderByStep(string funcid, string user,string workgroup , List<MESParameterInfo> lstParameters) 
        {
            try
            {
                String poid;
                String customer;
                String factory;

                int poqty;
                int waitingqty;
                string sSql = "";
                if (funcid == "fai01")  //检品开
                {
                    sSql = @" select  CUSTOMERNAME customer,b.customerid ,c.factory,a.CUSTORDERNO poid ,
styleno,   SUM(PAIRQTY) poqty,
(case a.CHECKTYPE when 'I' then '检品' when 'X' then 'X线' else '检品+X线' end) AS checktype   ,   ''status 
from tinpreceivingctndtl A , tinpreceiving b ,    tmdlcustomer d  ,tinpreceiving c
where cartonstatus='Active' and cartonlocation='Warehouse' AND ( a.CHECKTYPE ='I' OR a.CHECKTYPE ='IX')
AND A.recsysid = B.recsysid
AND a.CUSTOMERID = d.CUSTOMERID
and a.recsysid = c.recsysid
GROUP BY a.CUSTORDERNO,CUSTOMERNAME,b.customerid  , a.checktype ,styleno,c.factory";
                }
                if (funcid == "fai02") //检品封箱
                {
                    sSql = @"  select a.CUSTORDERNO poid , CUSTOMERNAME customer  ,d.customerid ,   '' factory,SUM(PAIRQTY) poqty ,(case a.CHECKTYPE when 'I' then '检品' when 'X' then 'X线' else '检品+X线' end) AS checktype   ,    ''status ,styleno
from tinpwip a,   tmdlcustomer d  
where
   status='I'  
AND a.CUSTOMERID = d.CUSTOMERID
AND ( A.CHECKTYPE='I'  )" ;
                    sSql = sSql + "and workgroup='" + workgroup + "'";
sSql = sSql+ " group by  a.custorderno,   customername ,d.customerid,A.CHECKTYPE ,styleno ";
                }
                if (funcid == "fai03") //检品装箱  moving
                {
                    sSql = @"    select a.CUSTORDERNO poid , CUSTOMERNAME customer ,d.customerid ,  ''   factory
,SUM(PAIRQTY) poqty ,(case a.CHECKTYPE when 'I' then '检品' when 'X' then 'X线' else '检品+X线' end) AS checktype   ,    ''status  ,styleno
from tinpwip a,    tmdlcustomer d    
where  status='I'  
AND a.CUSTOMERID = d.CUSTOMERID
AND A.CHECKTYPE='IX'  ";
  sSql = sSql + "and workgroup='" +workgroup +"'";
  sSql = sSql + " group by  a.custorderno,   customername ,d.customerid,A.CHECKTYPE ,styleno ";
                }
                if (funcid == "fax01")  //X线封箱
                {
                    sSql = @"     select a.CUSTORDERNO poid , CUSTOMERNAME customer ,   d.customerid , '' factory ,SUM(a.PAIRQTY) poqty ,(case a.CHECKTYPE when 'I' then '检品' when 'X' then 'X线' else '检品+X线' end) AS checktype   ,   ''status ,styleno
from tinpwip a  , tmdlcustomer d  
where
  status='X'  
AND a.CUSTOMERID = d.CUSTOMERID
group by  a.custorderno, customername ,d.customerid,A.CHECKTYPE ,styleno ";
                }

                /*  List<SqlParameter> lstParameters = new List<SqlParameter>();
                  lstParameters.Add(new SqlParameter()
                  {
                      ParameterName = "step",
                      SqlDbType = SqlDbType.VarChar,
                      Value = step
                  });*/
                sSql = "select * from (" + sSql + ") temTab  where 1=1 ";
                foreach (MESParameterInfo item in lstParameters)
                {
                    if (item.ParamName == "customerid")
                    {
                        sSql =sSql + " and  customerid='"  + item.ParamValue + "'";
                        break;
                    }
                    if (item.ParamName == "styleno")
                    {

                        sSql = sSql + " and  styleno like '%" + item.ParamValue + "%'";
                        break;
                    }
                    if (item.ParamName == "custorderno")
                    {
                        sSql = sSql + " and  poid like '%" + item.ParamValue + "%'";
                        break;
                    }
            
                }

                DataSet ds = SqlHelper.ExecuteQuery(sSql);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetColorByPo(string orderNumber)
        {
            try
            {
                string sSql = @"SELECT DISTINCT color  FROM   tinpreceivingctndtl  WHERE     (custorderno = @ponumber)  ORDER BY color";
                /*@"SELECT DISTINCT color
                 FROM         tinpcustorder
                 WHERE     (custorderno = @ponumber)
                 ORDER BY color";*/

                List<SqlParameter> lstParameters = new List<SqlParameter>();
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "ponumber",
                    SqlDbType = SqlDbType.VarChar,
                    Value = orderNumber
                });

                DataSet ds = SqlHelper.ExecuteQuery(sSql, lstParameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetTypeByPo(string orderNumber)
        {
            try
            {
                string sSql = @"SELECT DISTINCT styleno  FROM   tinpreceivingctndtl  WHERE     (custorderno = @ponumber)  ORDER BY styleno";


                List<SqlParameter> lstParameters = new List<SqlParameter>();
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "ponumber",
                    SqlDbType = SqlDbType.VarChar,
                    Value = orderNumber
                });

                DataSet ds = SqlHelper.ExecuteQuery(sSql, lstParameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSizeByPo(string orderNumber)
        {
            try
            {
                string sSql = @"SELECT DISTINCT size  FROM   tinpreceivingctndtl  WHERE     (custorderno = @ponumber)  ORDER BY size";


                List<SqlParameter> lstParameters = new List<SqlParameter>();
                lstParameters.Add(new SqlParameter()
                {
                    ParameterName = "ponumber",
                    SqlDbType = SqlDbType.VarChar,
                    Value = orderNumber
                });

                DataSet ds = SqlHelper.ExecuteQuery(sSql, lstParameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetCancelableCarton( string user,  List<MESParameterInfo> lstParameters)
        {
            try
            {
                String poid="";
                String customer="";
                String action="";
                String carton="";
                foreach (MESParameterInfo item in lstParameters)
                {
                    if (item.ParamName == "customerid")
	               {
                       customer = item.ParamValue;
                      // break;
	               }
                    if (item.ParamName == "custorderno")
                    {
                        poid = item.ParamValue;
                      //  break;
                    }
                    if (item.ParamName == "cartonno")
                    {
                        carton = item.ParamValue;
                      //  break;
                    }
                    if (item.ParamName == "action")
                    {
                        action = item.ParamValue;
                      //  break;
                    }  
                }
               string   sSql = "";
               if (action == "检品开箱")
                {
                  sSql = sSql + "  SELECT DISTINCT a.customerid, d.customername customer, a.custorderno poid, a.cartonno, '取消开箱' AS status ";
                  sSql = sSql + " FROM         tinppackingrecdtl AS a INNER JOIN  ";
                  sSql = sSql + "     tmdlcustomer AS d ON a.customerid = d.customerid AND a.pktype = 'Unpacking' AND not EXISTS  ";
                  sSql = sSql + "         (SELECT DISTINCT cartonno  ";
                  sSql = sSql + "            FROM          tinppackingrecdtl  c";
                  sSql = sSql + "            WHERE       (a.customerid = customerid) AND (a.custorderno = custorderno)and a.cartonno = cartonno  and  (pktype = 'Packing' or pktype = 'Moving')) ";
                }

               if (action == "检品装箱")
               {
                   sSql = sSql + "  SELECT DISTINCT a.customerid, d.customername customer, a.custorderno poid, a.cartonno, '取消装箱' AS status ";
                   sSql = sSql + " FROM         tinppackingrecdtl AS a INNER JOIN  ";
                   sSql = sSql + "     tmdlcustomer AS d ON a.customerid = d.customerid AND a.pktype = 'Moving' AND not EXISTS  ";
                   sSql = sSql + "         (SELECT DISTINCT cartonno  ";
                   sSql = sSql + "            FROM          tinppackingrecdtl  c";
                   sSql = sSql + "            WHERE       (a.customerid = customerid) AND (a.custorderno = custorderno)and a.cartonno = cartonno  and  (pktype = 'Packing' )) ";
               }
               if (action == "检品封箱")
               {
                   sSql = sSql + "  SELECT DISTINCT a.customerid, d.customername customer, a.custorderno poid, a.cartonno, '取消封箱' AS status ";
                   sSql = sSql + " FROM         tinppackingrecdtl AS a ,  tmdlcustomer AS d ,tinpreceivingctndtl c where a.customerid = d.customerid AND c.customerid = a.customerid and c.custorderno = a.custorderno and c.cartonno = a.cartonno and  a.pktype = 'Packing' and c.checktype='I' ";
               }
               if (action == "X线开箱")
               {
                   sSql = sSql + "  SELECT DISTINCT a.customerid, d.customername customer, a.custorderno poid, a.cartonno, '取消开箱' AS status ";
                   sSql = sSql + " FROM         tinppackingrecdtl AS a ,  tmdlcustomer  d ,tinpreceivingctndtl c where a.customerid = d.customerid AND c.customerid = a.customerid and c.custorderno = a.custorderno and c.cartonno = a.cartonno and  a.customerid = d.customerid AND a.pktype = 'Unpacking' and c.checktype='X' AND not EXISTS  ";
                   sSql = sSql + "         (SELECT DISTINCT cartonno  ";
                   sSql = sSql + "            FROM          tinppackingrecdtl  c";
                   sSql = sSql + "            WHERE       (a.customerid = customerid) AND (a.custorderno = custorderno)and a.cartonno = cartonno  and  (pktype = 'Packing' or pktype = 'Moving')) ";
               }
               if (action == "X线封箱")
               {
                   sSql = sSql + "  SELECT DISTINCT a.customerid, d.customername customer, a.custorderno poid, a.cartonno, '取消封箱' AS status ";
                   sSql = sSql + " FROM         tinppackingrecdtl AS a ,  tmdlcustomer AS d ,tinpreceivingctndtl c where a.customerid = d.customerid AND c.customerid = a.customerid and c.custorderno = a.custorderno and c.cartonno = a.cartonno and  a.pktype = 'Packing' and c.checktype='IX' ";
               }

                if (customer != null && customer != string.Empty)
	            {
		           sSql = sSql + " and  ( d.customerid = '"+customer+"')";
	             }
                 if (carton != null && carton != string.Empty)
	            {
		           sSql = sSql + "  AND (a.cartonno LIKE '"+carton+"%')";
	             }
                 if (poid != null && poid != string.Empty)
	            {
		           sSql = sSql + " and a.custorderno = '"+poid+"'";
	             }

               
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


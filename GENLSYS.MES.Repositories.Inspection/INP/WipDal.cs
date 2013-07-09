using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using System.Data.SqlClient;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class WipDal:BaseDal
    {
        public WipDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinpwip";
        }

        public override DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber) 
        {
            try
            {
                string sSql = @"select * from (select a.*,b.customername from tinpwip a,tmdlcustomer b
                                where a.customerid=b.customerid) rt
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

        public DataSet GetLeftWipRecords(List<MESParameterInfo> lstParameters)
        {
            try
            {
                string sSql = @"select * from (select a.*,b.customername, (a.pairqty- ISNULL(c.pairqty,0)) as leftqty  from tinpwip a inner join tmdlcustomer b
                                on a.customerid=b.customerid 
                                left join (select customerid,custorderno,styleno,color,size,workgroup,step ,SUM(pairqty) as pairqty from  tinpLineWarehouse group by customerid,custorderno,styleno,color,size,workgroup,step ) c 
                                on a.customerid=c.customerid and a.custorderno=c.custorderno
                                and a.styleno=c.styleno and a.color=c.color and a.size=c.size and a.workgroup=c.workgroup and a.status=c.step) rt
                                where 1=1 ";

                SQLSet sqlSet = BuildSelectSQL(sSql, lstParameters, false, 0);

                DataSet ds = SqlHelper.ExecuteQuery(sqlSet.SQLStatement, sqlSet.Parameters.ToArray<SqlParameter>());

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

          
        public   DataSet GetGoodWIP(String po, String style, String size , String color  )
        {
            try
            {
                string sSql = @"select * from  tinpwip
                                 where  custorderno = '"+po+"'   and styleno = '"+style+"' and color= '"+color+"' and size= '"+size+"' and status!= '"+MES_WIPStatus.BAD.ToString()+"'";

          DataSet ds = SqlHelper.ExecuteQuery(sSql);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveOrUpdate(string customerid, string custorderno, string styleno, string color, string size, string status, string workgroup, int pairqty)
        {
            SaveOrUpdate(  customerid,   custorderno,   styleno,   color,   size,   status,   workgroup,   pairqty,"IX");
        }
      
        public void SaveOrUpdate(string customerid,string custorderno, string styleno,string color,string size,string status,string workgroup, int pairqty,string checktype) 
        {
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "customerid",
                    ParamValue = customerid,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "custorderno",
                    ParamValue = custorderno,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "styleno",
                    ParamValue = styleno,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "color",
                    ParamValue = color,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "size",
                    ParamValue = size,
                    ParamType = "string"
                });
                if (status != null && !status.Equals(""))
                {
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "status",
                        ParamValue = status,
                        ParamType = "string"
                    });
                }
                if (workgroup != null && !workgroup.Equals(""))
                {
                    lstParameters.Add(new MESParameterInfo()
                       {
                           ParamName = "workgroup",
                           ParamValue = workgroup,
                           ParamType = "string"
                       });
                }

                if (checktype != null && !workgroup.Equals(""))
                {
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "checktype",
                        ParamValue = checktype,
                        ParamType = "string"
                    });
                }

                List<tinpwip> lstwip= GetSelectedObjects<tinpwip>(lstParameters);
                if (lstwip.Count > 0)
                {
                    tinpwip wip = lstwip[0];
                    wip.pairqty = wip.pairqty + pairqty;
                    if (wip.pairqty == 0)
                    {
                        DoDelete(wip);
                    }
                    else
                    {
                        DoUpdate(wip);
                    }
                }
                else
                {
                    if (pairqty != 0)
                    {
                        tinpwip wip = new tinpwip();
                        wip.customerid = customerid;
                        wip.custorderno = custorderno;
                        wip.styleno = styleno;
                        wip.color = color;
                        wip.size = size;
                        wip.pairqty = pairqty;
                        wip.status = status;
                        wip.workgroup = workgroup;
                        wip.checktype = checktype;
                        DoInsert(wip);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

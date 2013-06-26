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
    public class AssyBoxDal : BaseDal
    {
        public AssyBoxDal(DBInstance dbi)
            : base(dbi)
        {

        }

        public DataSet getOpenDetail(string customerid, string custorderno, string cartonno, string action, string currStep)
        {
            //Pack -X  -I
            //Moving
            try
            {
                string sSql = "";

                if (action == "Moving")
                {
                    sSql = sSql + "  SELECT   customerid,custorderno, cartonno, styleno, color, size,pairqty ";
                    sSql = sSql + "   FROM    tinppackingrecdtl ";
                    sSql = sSql + "   where customerid= '" + customerid + "'   and cartonno='" + cartonno + "' and custorderno= '" + custorderno + "'  and pktype = 'Unpacking'";

                }
                else
                {   //pack -I
                    if (currStep == "I")
                    {
                        sSql = sSql + "  SELECT   customerid,custorderno, cartonno, styleno, color, size,pairqty ";
                        sSql = sSql + "   FROM    tinppackingrecdtl ";
                        sSql = sSql + "   where customerid= '" + customerid + "'   and cartonno='" + cartonno + "' and custorderno= '" + custorderno + "'  and pktype = 'Unpacking'";

                    }
                    else
                    {   //pack -X
                        /*   if (currStep == "X")
                           {
                               sSql = sSql + "  SELECT   customerid,custorderno, cartonno, styleno, color, size,pairqty ";
                               sSql = sSql + "   FROM    tinppackingrecdtl ";
                               sSql = sSql + "   where customerid= '" + customerid + "'   and cartonno='" + cartonno + "' and custorderno= '" + custorderno + "'  and ( pktype = ( ";
                               sSql = sSql + "       select  distinct     case   when  checktype  =  'IX'   then   'Moving'        else   'Pack'  end  ";
                               sSql = sSql + "       from       tinpreceivingctndtl  ";
                               sSql = sSql + "       where customerid=  '" + customerid + "'  ";
                               sSql = sSql + "       and cartonno='" + cartonno + "'  and custorderno= '" + custorderno + "'   ";
                               sSql = sSql + "      ))";

                           }*/
                        sSql = sSql + "  SELECT   customerid,custorderno, cartonno, styleno, color, size,pairqty ";
                        sSql = sSql + "   FROM    tinppackingrecdtl ";
                        sSql = sSql + "   where customerid= '" + customerid + "'   and cartonno='" + cartonno + "' and custorderno= '" + custorderno + "'  and pktype = 'Unpacking'";


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



        /** 是否已经ship*/
        public bool isShipped(string customer, string custorderno, string cartonno)
        {
            try
            {
                string sSql1 = " select count(*) count from tinppackingrecdtl where isshipped='Y' "
                             + " and  customerid='" + customer + "' and custorderno='" + custorderno + "' and cartonno='" + cartonno + "'    pktype='Packing') ";
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


        /**获得当前WIP数量*/
        public int getWIPByPO(string customerid, string custorderno, string styleno, string color, string size, string workgroup, string action, string currStep)
        {
            try
            {
                string sSql1 = " ";
                if (action == "Moving")
                {
                    sSql1 = @" SELECT     ISNULL(SUM(pairqty), 0) AS qty
                               FROM         tinpwip
                               WHERE     (customerid = '#customerid') AND (custorderno = '#custorderno') AND (styleno = '#styleno') AND (color = '#color') AND (size = '#size') AND (status = 'I') AND (workgroup = '#workgroup') AND (checktype = 'IX') ";
                    sSql1 = sSql1.Replace("#customerid", customerid).Replace("#custorderno", custorderno).Replace("#styleno", styleno).Replace("#color", color).Replace("#size", size).Replace("#workgroup", workgroup);
                }
                if (action == "Pack")
                {
                    if (currStep == "I")
                    {
                        sSql1 = @" SELECT     ISNULL(SUM(pairqty), 0) AS qty
                               FROM         tinpwip
                               WHERE     (customerid = '#customerid') AND (custorderno = '#custorderno') AND (styleno = '#styleno') AND (color = '#color') AND (size = '#size') AND (status = 'I') AND (workgroup = '#workgroup') AND (checktype = 'I') ";
                        sSql1 = sSql1.Replace("#customerid", customerid).Replace("#custorderno", custorderno).Replace("#styleno", styleno).Replace("#color", color).Replace("#size", size).Replace("#workgroup", workgroup);

                    }
                    if (currStep == "X")
                    {
                        sSql1 = @" SELECT     ISNULL(SUM(pairqty), 0) AS qty
                               FROM         tinpwip
                               WHERE     (customerid = '#customerid') AND (custorderno = '#custorderno') AND (styleno = '#styleno') AND (color = '#color') AND (size = '#size') AND (status = 'X') ";
                        sSql1 = sSql1.Replace("#customerid", customerid).Replace("#custorderno", custorderno).Replace("#styleno", styleno).Replace("#color", color).Replace("#size", size).Replace("#workgroup", workgroup);

                    }

                }
                DataSet ds1 = SqlHelper.ExecuteQuery(sSql1);
                return int.Parse(ds1.Tables[0].Rows[0]["qty"].ToString());

            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }


        public DataSet getLineWarehouse(string customerid, string custorderno, string cartonno, string workgroup)
        {
            //Pack -X  -I
            //Moving
            try
            {
                string sSql = "";
                sSql = sSql + "    SELECT  a.customerid,a.custorderno, a.cartonNumber, a.styleno, a.color, a.size,b.pairqty qty1, a.pairqty  qty2  ";
                sSql = sSql + "  FROM    tinpLineWarehouse  a ,tinpreceivingctndtl b ";
                sSql = sSql + "   where a.customerid= '" + customerid + "'    and a.cartonNumber='" + cartonno + "'  ";
                sSql = sSql + "   and a.custorderno=  '" + custorderno + "'  and a.workgroup =  '" + workgroup + "' ";
                sSql = sSql + "  and a.customerid= b.customerid ";
                sSql = sSql + "  and a.custorderno = b.custorderno ";
                sSql = sSql + "  and a.cartonNumber = b.cartonno ";
                sSql = sSql + "  and a.styleno = b.styleno ";
                sSql = sSql + "  and a.color = b.color ";
                sSql = sSql + "  and a.size = b.size ";
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

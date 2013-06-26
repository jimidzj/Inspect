using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class PackingRecBll:BaseBll
    {
        private PackingRecDal localDal = null;
        private PackingRecDtlDal packingRecDtlDal = null;
        private ReceivingCtnDtlDal receivingCtnDtlDal = null;
        private WipDal wipDal = null;
        private CustOrderHistoryDal custOrderHistoryDal = null;

        public PackingRecBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new PackingRecDal(dbInstance);
            baseDal = localDal;
            packingRecDtlDal = new PackingRecDtlDal(dbInstance);
            wipDal = new WipDal(dbInstance);
            receivingCtnDtlDal = new ReceivingCtnDtlDal(dbInstance);
            custOrderHistoryDal = new CustOrderHistoryDal(dbInstance);
        }

        public void DoXUnpacking(List<string[]> lstunpacking)
        {
            try
            {
                dbInstance.BeginTransaction();

                string eventgroup = Function.GetGUID();
                List<tinppackingrec> lstpacking = new List<tinppackingrec>();
                List<tinppackingrecdtl> lstpackingdtl = new List<tinppackingrecdtl>();
                List<tinpreceivingctndtl> lstreceivingctn = new List<tinpreceivingctndtl>();

                foreach (string[] strarr in lstunpacking)
                {
                    List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="customerid",ParamValue=strarr[0]},
                            new MESParameterInfo(){ParamName="custorderno",ParamValue=strarr[1]},
                            new MESParameterInfo(){ParamName="cartonno",ParamValue=strarr[2]},
                            new MESParameterInfo(){ParamName="cartonstatus",ParamValue=MES_CartonStatus.Active.ToString()},
                            new MESParameterInfo(){ParamName="cartonlocation",ParamValue=MES_CartonLocation.Warehouse.ToString()},
                            new MESParameterInfo(){ParamName="checktype",ParamValue=MES_WIPStatus.X.ToString()}
                        };
                    List<tinpreceivingctndtl> lstrec = receivingCtnDtlDal.GetSelectedObjects<tinpreceivingctndtl>(lstParams);

                    foreach (tinpreceivingctndtl rec in lstrec)
                    {
                        var q = from p in lstpacking
                                where p.custorderno.Equals(rec.custorderno)
                                select p;

                        tinppackingrec packing = null;
                        if (q.Count() > 0)
                        {
                            packing = q.ElementAt(0);
                            packing.ttlqty += rec.pairqty;
                        }
                        else
                        {
                            packing = new tinppackingrec();
                            packing.pksysid = Function.GetGUID();
                            packing.workgroup = strarr[3];
                            packing.customerid = strarr[0];
                            packing.custorderno = rec.custorderno;
                            packing.pktype = MES_PackingType.Unpacking.ToString();
                            packing.actiondate = Function.GetCurrentTime();
                            packing.ttlqty = rec.pairqty;
                            lstpacking.Add(packing);
                        }

                        tinppackingrecdtl packingdtl = new tinppackingrecdtl();
                        packingdtl.pksysid = packing.pksysid;
                        packingdtl.customerid = rec.customerid;
                        packingdtl.custorderno = rec.custorderno;
                        packingdtl.cartonno = rec.cartonno;
                        packingdtl.styleno = rec.styleno;
                        packingdtl.color = rec.color;
                        packingdtl.size = rec.size;
                        packingdtl.pairqty = rec.pairqty;
                        packingdtl.confirmqty = 0;
                        packingdtl.difference = 0;
                        packingdtl.isshipped = MES_Misc.N.ToString();
                        packingdtl.pktype = MES_PackingType.Unpacking.ToString();
                        lstpackingdtl.Add(packingdtl);

                        wipDal.SaveOrUpdate(packing.customerid, packingdtl.custorderno, packingdtl.styleno, packingdtl.color, packingdtl.size, MES_WIPStatus.X.ToString(), packing.workgroup, Convert.ToInt16(rec.pairqty), rec.checktype);

                        rec.cartonlocation = MES_CartonLocation.WIP.ToString();
                        //receivingCtnDtlDal.DoUpdate(rec);
                        lstreceivingctn.Add(rec);

                        #region Update CustomerOrder History
                        tinpcustorderhistory history = new tinpcustorderhistory();
                        history.customerid = packing.customerid;
                        history.cartonno = packingdtl.cartonno;
                        history.cartonqty = packingdtl.pairqty;
                        history.custorderno = packingdtl.custorderno;
                        history.size = packingdtl.size;
                        history.styleno = packingdtl.styleno;
                        history.color = packingdtl.color;
                        history.eventgroup = eventgroup;
                        history.eventname = "XUnpacking";
                        history.pairqty = packingdtl.pairqty;
                        history.refsysid = packingdtl.pksysid;
                        history.remark = "";

                        history.eventtime = Function.GetCurrentTime();
                        history.eventuser = CurrentContextInfo.CurrentUser;
                        history.ohsysid = Function.GetGUID();
                        history.shift = CurrentContextInfo.Shift;
                        history.workgroup = CurrentContextInfo.WorkGroup;

                        custOrderHistoryDal.DoInsert<tinpcustorderhistory>(history);
                        #endregion
                    }
                }

                foreach (tinppackingrec packing in lstpacking)
                {
                    localDal.DoInsert(packing);
                }
                foreach (tinppackingrecdtl packingdtl in lstpackingdtl)
                {
                    packingRecDtlDal.DoInsert(packingdtl);
                }
                foreach (tinpreceivingctndtl receivingctn in lstreceivingctn)
                {
                    receivingCtnDtlDal.DoUpdate(receivingctn);
                }
                dbInstance.Commit();
            }
            catch (Exception ex)
            {
                dbInstance.Rollback();
                throw ex;
            }
            finally
            {
                dbInstance.CloseConnection();
            }
        }
    }
}

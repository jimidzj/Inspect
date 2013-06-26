using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using GENLSYS.MES.Services.Common;
using System.Data;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class RepairStockBll:BaseBll
    {
        private RepairStockDal localDal = null;
        private RepairHisDal repairHisDal = null;
        private RepairFailDal repairFailDal = null;
        private WipDal wipDal = null;
        private CustOrderHistoryDal custOrderHistoryDal = null;

        public RepairStockBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new RepairStockDal(dbInstance);
            baseDal = localDal;

            repairHisDal = new RepairHisDal(dbInstance);
            repairFailDal = new RepairFailDal(dbInstance);
            wipDal = new WipDal(dbInstance);
            custOrderHistoryDal = new CustOrderHistoryDal(dbInstance);

        }


        public DataSet GetRepairStockRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetRepairStockRecords(lstParameters);
        }

        public void DoRepaireAdjust(string repsysid,string reasoncode,int qty)
        {
            try
            {
                dbInstance.BeginTransaction();
                int difqty = 0;

                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="repsysid",ParamValue=repsysid}
                        };
                tinprepairhis repairhis = repairHisDal.GetSingleObject<tinprepairhis>(lstParams, string.Empty, true);


                List<MESParameterInfo> lstFailParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="repsysid",ParamValue=repsysid},
                            new MESParameterInfo(){ParamName="reasoncode",ParamValue=reasoncode}
                        };
                tinprepairfail repairfail = repairFailDal.GetSingleObject<tinprepairfail>(lstFailParams, string.Empty, true);


                if (repairhis != null)
                {                    
                    if (repairhis.reptype.Equals(MES_RepairType.ToRepair.ToString()))
                    {
                        difqty = Convert.ToInt16(repairfail.pairqty) - qty;
                        wipDal.SaveOrUpdate(repairhis.customerid, repairhis.custorderno, repairhis.styleno, repairhis.color, repairhis.size, repairhis.step, repairhis.workgroup, difqty, repairhis.checktype);
                        wipDal.SaveOrUpdate(repairhis.customerid, repairhis.custorderno, repairhis.styleno, repairhis.color, repairhis.size, MES_WIPStatus.Repair.ToString(), repairhis.workgroup, -difqty, repairhis.checktype);
                    }
                    else if (repairhis.reptype.Equals(MES_RepairType.RepairFail.ToString()))
                    {
                        difqty = Convert.ToInt16(repairfail.pairqty) - qty;
                        wipDal.SaveOrUpdate(repairhis.customerid, repairhis.custorderno, repairhis.styleno, repairhis.color, repairhis.size, MES_WIPStatus.BAD.ToString(), MES_Misc.BadStock.ToString(), -difqty, repairhis.checktype);
                        wipDal.SaveOrUpdate(repairhis.customerid, repairhis.custorderno, repairhis.styleno, repairhis.color, repairhis.size, MES_WIPStatus.Repair.ToString(), repairhis.workgroup, difqty, repairhis.checktype);
                    }
                    else
                    {
                        difqty = Convert.ToInt16(repairhis.pairqty) - qty;
                        wipDal.SaveOrUpdate(repairhis.customerid, repairhis.custorderno, repairhis.styleno, repairhis.color, repairhis.size, repairhis.step, repairhis.workgroup, -difqty, repairhis.checktype);
                        wipDal.SaveOrUpdate(repairhis.customerid, repairhis.custorderno, repairhis.styleno, repairhis.color, repairhis.size, MES_WIPStatus.Repair.ToString(), repairhis.workgroup, difqty, repairhis.checktype);
                    }
                    
                    List<MESParameterInfo> lstStockParams = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="customerid",ParamValue=repairhis.customerid},
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=repairhis.custorderno},
                        new MESParameterInfo(){ParamName="styleno",ParamValue=repairhis.styleno},
                        new MESParameterInfo(){ParamName="color",ParamValue=repairhis.color},
                        new MESParameterInfo(){ParamName="size",ParamValue=repairhis.size},
                        new MESParameterInfo(){ParamName="checktype",ParamValue=repairhis.checktype},
                        new MESParameterInfo(){ParamName="workgroup",ParamValue=repairhis.workgroup},
                        new MESParameterInfo(){ParamName="step",ParamValue=repairhis.step}
                    };
                    List<tinprepairstock> lstStock = baseDal.GetSelectedObjects<tinprepairstock>(lstStockParams);
                    if (lstStock.Count >= 0)
                    {
                        tinprepairstock stock = lstStock[0];
                        if (repairhis.reptype.Equals(MES_RepairType.ToRepair.ToString()))
                        {
                            stock.curpairqty = stock.curpairqty - difqty;
                            repairfail.pairqty = repairfail.pairqty - difqty;                            
                        }
                        else
                        {
                            stock.curpairqty = stock.curpairqty + difqty;
                        }
                        if (repairhis.reptype.Equals(MES_RepairType.RepairFail.ToString()))
                        {
                            stock.ttlbadqty = stock.ttlbadqty - difqty;
                            repairfail.pairqty = repairfail.pairqty - difqty;
                        }
                        else if (repairhis.reptype.Equals(MES_RepairType.RepairSuccess.ToString()))
                        {
                            stock.ttlpairgoodqty = stock.ttlpairgoodqty - difqty;
                        }
                        baseDal.DoUpdate<tinprepairstock>(stock);
                    }

                    repairhis.pairqty = repairhis.pairqty-difqty;
                    //repairhis.pairqty = qty;
                    if (repairhis.pairqty == 0)
                    {
                        repairHisDal.DoDelete<tinprepairhis>(repairhis);
                    }
                    else
                    {
                        repairHisDal.DoUpdate<tinprepairhis>(repairhis);
                    }
                    if (qty == 0)
                    {                        
                        if (repairfail != null)
                        {
                            repairFailDal.DoDelete<tinprepairfail>(repairfail);
                        }
                    }
                    else
                    {                        
                        if (repairfail != null)
                        {
                            repairFailDal.DoUpdate<tinprepairfail>(repairfail);
                        }
                    }
                }
                else
                {
                    throw new Exception("No data found");
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

        public void DoInsertRepair(tinprepairhis repairhis,List<tinprepairfail> lstreasoncode)
        {
            try
            {
                dbInstance.BeginTransaction();

                repairHisDal.DoInsert(repairhis);

                foreach (tinprepairfail repairfail in lstreasoncode)
                {
                    repairfail.repsysid = repairhis.repsysid;
                    repairFailDal.DoInsert(repairfail);
                }

                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="customerid",ParamValue=repairhis.customerid},
                            new MESParameterInfo(){ParamName="custorderno",ParamValue=repairhis.custorderno},
                            new MESParameterInfo(){ParamName="styleno",ParamValue=repairhis.styleno},
                            new MESParameterInfo(){ParamName="color",ParamValue=repairhis.color},
                            new MESParameterInfo(){ParamName="size",ParamValue=repairhis.size},
                            new MESParameterInfo(){ParamName="checktype",ParamValue=repairhis.checktype},
                            new MESParameterInfo(){ParamName="workgroup",ParamValue=repairhis.workgroup},
                            new MESParameterInfo(){ParamName="step",ParamValue=repairhis.step}
                        };

                List<tinprepairstock> lstRepairStock = baseDal.GetSelectedObjects<tinprepairstock>(lstParams, string.Empty, true, -1);
                if (lstRepairStock.Count > 0)
                {
                    tinprepairstock repairStock = lstRepairStock[0];
                    repairStock.curpairqty = repairStock.curpairqty + repairhis.pairqty;
                    baseDal.DoUpdate(repairStock);
                }
                else
                {
                    tinprepairstock repairStock = new tinprepairstock();
                    repairStock.customerid = repairhis.customerid;
                    repairStock.custorderno = repairhis.custorderno;
                    repairStock.styleno = repairhis.styleno;
                    repairStock.color = repairhis.color;
                    repairStock.size = repairhis.size;
                    repairStock.checktype = repairhis.checktype;
                    repairStock.curpairqty = repairhis.pairqty;
                    repairStock.ttlbadqty = 0;
                    repairStock.ttlpairgoodqty = 0;
                    repairStock.workgroup = repairhis.workgroup;
                    repairStock.step = repairhis.step;
                    repairStock.lastupdatetime = Function.GetCurrentTime();
                    baseDal.DoInsert(repairStock);
                }

                #region Update WIP
                wipDal.SaveOrUpdate(repairhis.customerid, repairhis.custorderno, repairhis.styleno, repairhis.color, repairhis.size, repairhis.step, repairhis.workgroup, Convert.ToInt16(-repairhis.pairqty), repairhis.checktype);
                wipDal.SaveOrUpdate(repairhis.customerid, repairhis.custorderno, repairhis.styleno, repairhis.color, repairhis.size, MES_WIPStatus.Repair.ToString(), repairhis.workgroup, Convert.ToInt16(repairhis.pairqty), repairhis.checktype);                
                #endregion

                #region Update CustomerOrder History
                tinpcustorderhistory history = new tinpcustorderhistory();
                history.customerid = "";
                history.cartonno = "";
                history.cartonqty = 0;                
                history.custorderno = repairhis.custorderno;
                history.size = repairhis.size;
                history.styleno = repairhis.styleno;
                history.color = repairhis.color;
                history.eventgroup = Function.GetGUID();
                history.eventname = "To Repair";
                history.pairqty = repairhis.pairqty;
                history.refsysid = repairhis.repsysid;
                history.remark = "";

                history.eventtime = Function.GetCurrentTime();
                history.eventuser = CurrentContextInfo.CurrentUser;
                history.ohsysid = Function.GetGUID();
                history.shift = CurrentContextInfo.Shift;
                history.workgroup = CurrentContextInfo.WorkGroup;

                custOrderHistoryDal.DoInsert<tinpcustorderhistory>(history);
                #endregion

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

        public void DoRepairBack(tinprepairstock repairstock, List<tinprepairfail> lstreasoncode, string jointtype, string signature)
        {
            try
            {
                dbInstance.BeginTransaction();

                #region repairhis
                tinprepairhis goodhis = new tinprepairhis();
                if (repairstock.ttlpairgoodqty > 0)
                {                   
                    goodhis.repsysid = Function.GetGUID();
                    goodhis.workgroup = repairstock.workgroup;
                    goodhis.step = repairstock.step;
                    goodhis.reptype = MES_RepairType.RepairSuccess.ToString();
                    goodhis.customerid = repairstock.customerid;
                    goodhis.custorderno = repairstock.custorderno;
                    goodhis.styleno = repairstock.styleno;
                    goodhis.color = repairstock.color;
                    goodhis.size = repairstock.size;
                    goodhis.checktype = repairstock.checktype;
                    goodhis.pairqty = repairstock.ttlpairgoodqty;
                    goodhis.claimtime = Function.GetCurrentTime();
                    goodhis.claimuser = CurrentContextInfo.CurrentUser;
                    if (jointtype != null && signature != null)
                    {
                        goodhis.jointtype = jointtype;
                        goodhis.signature = signature;
                    }
                    repairHisDal.DoInsert(goodhis);
                }
                tinprepairhis badhis = new tinprepairhis();
                if (repairstock.ttlbadqty > 0)
                {                   
                    badhis.repsysid = Function.GetGUID();
                    badhis.workgroup = repairstock.workgroup;
                    badhis.step = repairstock.step;
                    badhis.reptype = MES_RepairType.RepairFail.ToString();
                    badhis.customerid = repairstock.customerid;
                    badhis.custorderno = repairstock.custorderno;
                    badhis.styleno = repairstock.styleno;
                    badhis.color = repairstock.color;
                    badhis.size = repairstock.size; 
                    badhis.checktype = repairstock.checktype;
                    badhis.pairqty = repairstock.ttlbadqty;
                    badhis.claimtime = Function.GetCurrentTime();
                    badhis.claimuser = CurrentContextInfo.CurrentUser;
                    repairHisDal.DoInsert(badhis);

                    foreach (tinprepairfail repairfail in lstreasoncode)
                    {
                        repairfail.repsysid = badhis.repsysid;
                        repairFailDal.DoInsert(repairfail);
                    }
                }
                #endregion

                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="customerid",ParamValue=repairstock.customerid},
                            new MESParameterInfo(){ParamName="custorderno",ParamValue=repairstock.custorderno},
                            new MESParameterInfo(){ParamName="styleno",ParamValue=repairstock.styleno},
                            new MESParameterInfo(){ParamName="color",ParamValue=repairstock.color},
                            new MESParameterInfo(){ParamName="size",ParamValue=repairstock.size},
                            new MESParameterInfo(){ParamName="checktype",ParamValue=repairstock.checktype},
                            new MESParameterInfo(){ParamName="step",ParamValue=repairstock.step},
                            new MESParameterInfo(){ParamName="workgroup",ParamValue=repairstock.workgroup}
                        };

                List<tinprepairstock> lstRepairStock = baseDal.GetSelectedObjects<tinprepairstock>(lstParams, string.Empty, true, -1);
                if (lstRepairStock.Count > 0)
                {
                    tinprepairstock rsk = lstRepairStock[0];
                    rsk.curpairqty = rsk.curpairqty - repairstock.ttlpairgoodqty - repairstock.ttlbadqty;
                    rsk.ttlbadqty = rsk.ttlbadqty + repairstock.ttlbadqty;
                    rsk.ttlpairgoodqty = rsk.ttlpairgoodqty + repairstock.ttlpairgoodqty;
                    rsk.lastupdatetime = Function.GetCurrentTime();
                    baseDal.DoUpdate(rsk);
                }

                #region Update WIP
                wipDal.SaveOrUpdate(repairstock.customerid, repairstock.custorderno, repairstock.styleno, repairstock.color, repairstock.size, repairstock.step, repairstock.workgroup, Convert.ToInt16(repairstock.ttlpairgoodqty), repairstock.checktype);
                wipDal.SaveOrUpdate(repairstock.customerid, repairstock.custorderno, repairstock.styleno, repairstock.color, repairstock.size, MES_WIPStatus.BAD.ToString(), MES_Misc.BadStock.ToString(), Convert.ToInt16(repairstock.ttlbadqty), repairstock.checktype);
                wipDal.SaveOrUpdate(repairstock.customerid, repairstock.custorderno, repairstock.styleno, repairstock.color, repairstock.size, MES_WIPStatus.Repair.ToString(), repairstock.workgroup, -Convert.ToInt16(repairstock.ttlpairgoodqty + repairstock.ttlbadqty), repairstock.checktype);
                #endregion

                #region Update CustomerOrder History
                string eventgroup = Function.GetGUID();
                if (goodhis.pairqty > 0)
                {
                    tinpcustorderhistory goodhistory = new tinpcustorderhistory();
                    goodhistory.customerid = goodhis.customerid;
                    goodhistory.cartonno = "";
                    goodhistory.cartonqty = 0;
                    goodhistory.custorderno = goodhis.custorderno;
                    goodhistory.size = goodhis.size;
                    goodhistory.styleno = goodhis.styleno;
                    goodhistory.color = goodhis.color;
                    goodhistory.eventgroup = eventgroup;
                    goodhistory.eventname = "Repair";
                    goodhistory.pairqty = goodhis.pairqty;
                    goodhistory.refsysid = goodhis.repsysid;
                    goodhistory.remark = "";


                    goodhistory.eventtime = Function.GetCurrentTime();
                    goodhistory.eventuser = CurrentContextInfo.CurrentUser;
                    goodhistory.ohsysid = Function.GetGUID();
                    goodhistory.shift = CurrentContextInfo.Shift;
                    goodhistory.workgroup = CurrentContextInfo.WorkGroup;

                    custOrderHistoryDal.DoInsert<tinpcustorderhistory>(goodhistory);
                }

                if (badhis.pairqty > 0)
                {
                    tinpcustorderhistory badhistory = new tinpcustorderhistory();
                    badhistory.customerid = badhis.customerid;
                    badhistory.cartonno = "";
                    badhistory.cartonqty = 0;
                    badhistory.custorderno = badhis.custorderno;
                    badhistory.size = badhis.size;
                    badhistory.styleno = badhis.styleno;
                    badhistory.color = badhis.color;
                    badhistory.eventgroup = eventgroup;
                    badhistory.eventname = "Repair";
                    badhistory.pairqty = badhis.pairqty;
                    badhistory.refsysid = badhis.repsysid;
                    badhistory.remark = "";

                    badhistory.eventtime = Function.GetCurrentTime();
                    badhistory.eventuser = CurrentContextInfo.CurrentUser;
                    badhistory.ohsysid = Function.GetGUID();
                    badhistory.shift = CurrentContextInfo.Shift;
                    badhistory.workgroup = CurrentContextInfo.WorkGroup;

                    custOrderHistoryDal.DoInsert<tinpcustorderhistory>(badhistory);
                }

                #endregion
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

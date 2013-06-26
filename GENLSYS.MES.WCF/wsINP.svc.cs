using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Services.Inspection.INP;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;

namespace GENLSYS.MES.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wsINP" in code, svc and config file together.
    public class wsINP : IwsINP
    {
        public void DoWork()
        {

        }

        #region Order
        public DataSet GetCustOrderRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            CustOrderBll bll =new CustOrderBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = null;// bll.GetSelectedRecords<tinpcustorder>(lstParameters);
            GC.Collect();
            return rs;
        }

        #endregion

        #region Wip
        public List<tinpwip> GetWipList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            WipBll bll = new WipBll(contextInfo);
            bll.CallAccessControl();
            List<tinpwip> rs = bll.GetSelectedObjects<tinpwip>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetWipRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            WipBll bll = new WipBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinpwip>(lstParameters);
            GC.Collect();
            return rs;
        }

        public tinpwip GetSingleWip(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            WipBll bll = new WipBll(contextInfo);
            bll.CallAccessControl();
            tinpwip rs = bll.GetSingleObject<tinpwip>(lstParameters);
            GC.Collect();
            return rs;
        }
        #endregion

        #region Work Order
        public List<tinpworkorder> GetWorkOrderList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            WorkOrderBll bll = new WorkOrderBll(contextInfo);
            bll.CallAccessControl();
            List<tinpworkorder> rs = bll.GetSelectedObjects<tinpworkorder>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetWorkOrderRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            WorkOrderBll bll = new WorkOrderBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetWorkOrderRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public tinpworkorder GetSingleWorkOrder(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            WorkOrderBll bll = new WorkOrderBll(contextInfo);
            bll.CallAccessControl();
            tinpworkorder rs = bll.GetSingleObject<tinpworkorder>(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DoInsertWorkOrder(ContextInfo contextInfo, tinpworkorder workorder,
            List<tinpworkorderdtl> lstDtl)
        {
            contextInfo.Action = MES_ActionType.Insert;
            WorkOrderBll bll = new WorkOrderBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsertWorkOrder(workorder, lstDtl);
            GC.Collect();
        }
        public void DoUpdateWorkOrder(ContextInfo contextInfo, tinpworkorder workorder,
            List<tinpworkorderdtl> lstDtl)
        {
            contextInfo.Action = MES_ActionType.Update;
            WorkOrderBll bll = new WorkOrderBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdateWorkOrder(workorder, lstDtl);
            GC.Collect();
        }

        public void DoDeleteWorkOrder(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            WorkOrderBll bll = new WorkOrderBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDeleteWorkOrder(lstParameters);
            GC.Collect();
        }

        public DataSet GetWorkOrderDetailRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            WorkOrderBll bll = new WorkOrderBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetWorkOrderDetailRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetCustOrderForReceiving(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            WorkOrderBll bll = new WorkOrderBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetCustOrderForReceiving(lstParameters);
            GC.Collect();
            return rs;
        }
        #endregion

        #region Pricing
        public tinppricing GetSinglePricing(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            PricingBll bll = new PricingBll(contextInfo);
            bll.CallAccessControl();
            tinppricing rs = bll.GetSingleObject<tinppricing>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetPricingRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            PricingBll bll = new PricingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetPricingRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DoInsertPricing(ContextInfo contextInfo, tinppricing prc, List<tinppricingdtl> lstPrcDtl,
            List<tinppricingdtldef> lstDef)
        {
            contextInfo.Action = MES_ActionType.Update;
            PricingBll bll = new PricingBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsertPricing(prc, lstPrcDtl, lstDef);
            GC.Collect();
        }

        public void DoUpdatePricing(ContextInfo contextInfo, tinppricing prc, List<tinppricingdtl> lstPrcDtl,
            List<tinppricingdtldef> lstDef)
        {
            contextInfo.Action = MES_ActionType.Update;
            PricingBll bll = new PricingBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdatePricing(prc, lstPrcDtl, lstDef);
            GC.Collect();
        }

        public DataSet GetValidPricing(ContextInfo contextInfo, string customerid, DateTime dt)
        {
            contextInfo.Action = MES_ActionType.Query;
            PricingBll bll = new PricingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetValidPricing(customerid, dt);
            GC.Collect();
            return rs;
        }
        #endregion

        #region Receiving
        public List<tinpreceiving> GetReceivingList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            List<tinpreceiving> rs = bll.GetSelectedObjects<tinpreceiving>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetReceivingRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetReceivingRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public tinpreceiving GetSingleReceiving(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            tinpreceiving rs = bll.GetSingleObject<tinpreceiving>(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DoInsertReceiving(ContextInfo contextInfo, tinpreceiving rec,
            List<tinpreceivingdtl> lstDtl)
        {
            contextInfo.Action = MES_ActionType.Insert;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsertReceiving(rec, lstDtl);
            GC.Collect();
        }
        public void DoUpdateReceiving(ContextInfo contextInfo, tinpreceiving rec,
            List<tinpreceivingdtl> lstDtlNew, List<tinpreceivingdtl> lstDtlUpdated, List<string> lstDeleted)
        {
            contextInfo.Action = MES_ActionType.Update;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdateReceiving(rec, lstDtlNew, lstDtlUpdated, lstDeleted);
            GC.Collect();
        }

        public void DoDeleteReceiving(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDeleteReceiving(lstParameters);
            GC.Collect();
        }

        public DataSet GetReceivingDetailRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetReceivingDetailRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetReceivingCartonDetailRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetReceivingCartonDetailRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetReceivingHeader_Print(ContextInfo contextInfo, string recno)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetReceivingHeader_Print(recno);
            GC.Collect();
            return rs;
        }

        public DataSet GetReceivingDetail_Print(ContextInfo contextInfo, string recno)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetReceivingDetail_Print(recno);
            GC.Collect();
            return rs;
        }

        public DataSet GetReceivingSumCtnDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReceivingCtnDtlBll bll = new ReceivingCtnDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetReceivingSumCtnDtlRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetReceivingCtnDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReceivingCtnDtlBll bll = new ReceivingCtnDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetReceivingCtnDtlRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public void UpdateCartonQty(ContextInfo contextInfo, string recsysid,
            string cartonno,string oldstyleno,string oldcolor,string oldsize, int quantity,string color,string size,string styleno)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            bll.UpdateCartonQty(recsysid, cartonno,oldstyleno,oldcolor,oldsize, quantity,color,size,styleno);
            GC.Collect();
        }

        public void DeleteSingleCarton(ContextInfo contextInfo, string recsysid,string cartonno,string oldstyleno,string oldcolor,string oldsize)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            bll.DeleteSingleCarton(recsysid, cartonno,oldstyleno,oldcolor,oldsize);
            GC.Collect();
        }

        public bool CheckReceivingUsed(ContextInfo contextInfo, string recsysid)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReceivingBll bll = new ReceivingBll(contextInfo);
            bll.CallAccessControl();
            bool result = bll.CheckUsed(recsysid);
            GC.Collect();
            return result;
        }
        #endregion

        #region IQC
        public List<tinpiqc> GetIQCList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            IQCBll bll = new IQCBll(contextInfo);
            bll.CallAccessControl();
            List<tinpiqc> rs = bll.GetSelectedObjects<tinpiqc>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetIQCRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            IQCBll bll = new IQCBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetIQCRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public tinpiqc GetSingleIQC(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            IQCBll bll = new IQCBll(contextInfo);
            bll.CallAccessControl();
            tinpiqc rs = bll.GetSingleObject<tinpiqc>(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DoInsertIQC(ContextInfo contextInfo, tinpiqc iqc, 
            List<tinpiqcfail> lstFail,List<tinpiqcreturn> lstReturn)
        {
            contextInfo.Action = MES_ActionType.Insert;
            IQCBll bll = new IQCBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsertIQC(iqc, lstFail, lstReturn);
            GC.Collect();
        }
        public void DoUpdateIQC(ContextInfo contextInfo, tinpiqc iqc,
            List<tinpiqcfail> lstFail, List<tinpiqcreturn> lstReturn)
        {
            contextInfo.Action = MES_ActionType.Update;
            IQCBll bll = new IQCBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdateIQC(iqc, lstFail, lstReturn);
            GC.Collect();
        }

        public void DoDeleteIQC(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            IQCBll bll = new IQCBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDeleteIQC(lstParameters);
            GC.Collect();
        }

        public DataSet GetIQCFail(ContextInfo contextInfo, string iqcsysid)
        {
            contextInfo.Action = MES_ActionType.Delete;
            IQCBll bll = new IQCBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetIQCFail(iqcsysid);
            GC.Collect();
            return rs;
        }

        public DataSet GetIQCReturn(ContextInfo contextInfo, string iqcsysid, string styleno)
        {
            contextInfo.Action = MES_ActionType.Delete;
            IQCBll bll = new IQCBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetIQCReturn(iqcsysid,styleno);
            GC.Collect();
            return rs;
        }

        public DataSet GetValidIQC(ContextInfo contextInfo, string customerid)
        {
            contextInfo.Action = MES_ActionType.Query;
            IQCBll bll = new IQCBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetValidIQC(customerid);
            GC.Collect();
            return rs;
        }
        #endregion

        #region Schedule
        public List<tinpschedule> GetScheduleList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ScheduleBll bll = new ScheduleBll(contextInfo);
            bll.CallAccessControl();
            List<tinpschedule> rs = bll.GetSelectedObjects<tinpschedule>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetScheduleRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ScheduleBll bll = new ScheduleBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinpschedule>(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DoDeleteSchedule(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            IQCBll bll = new IQCBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tinpschedule>(lstParameters);
            GC.Collect();
        }

        public void DoInsertSchedule(ContextInfo contextInfo, string yearmonth, List<tinpschedule> lstSchedule)
        {
            contextInfo.Action = MES_ActionType.Insert;
            ScheduleBll bll = new ScheduleBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsertSchedule(yearmonth, lstSchedule);
            GC.Collect();
        }
        public void DoUpdateSchedule(ContextInfo contextInfo, string yearmonth, List<tinpschedule> lstSchedule)
        {
            contextInfo.Action = MES_ActionType.Update;
            ScheduleBll bll = new ScheduleBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdateSchedule(yearmonth, lstSchedule);
            GC.Collect();
        }

        public DataSet GetDailySchedule(ContextInfo contextInfo, string startdate, string enddate)
        {
            contextInfo.Action = MES_ActionType.Update;
            ScheduleBll bll = new ScheduleBll(contextInfo);
            bll.CallAccessControl();
            GC.Collect();
            return bll.GetDailySchedule(startdate, enddate);
        }
        #endregion

        #region Cust Order History
        public DataSet GetCustOrderHistoryRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            CustOrderHistoryBll bll = new CustOrderHistoryBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinpcustorderhistory>(lstParameters);
            GC.Collect();
            return rs;
        }
        #endregion

        #region Repair
        public DataSet GetRepairFailRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RepairFailBll bll = new RepairFailBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinprepairfail>(lstParameters);
            GC.Collect();
            return rs;
        }
        public DataSet GetRepairStockRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RepairStockBll bll = new RepairStockBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetRepairStockRecords(lstParameters);
            GC.Collect();
            return rs;
        }
        public tinprepairstock GetSingleRepairStock(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RepairStockBll bll = new RepairStockBll(contextInfo);
            bll.CallAccessControl();
            tinprepairstock stock = bll.GetSingleObject<tinprepairstock>(lstParameters);
            GC.Collect();
            return stock;
        }

        public void DoInsertRepair(ContextInfo contextInfo, tinprepairhis repairhis, List<tinprepairfail> lstreasoncode)
        {
            contextInfo.Action = MES_ActionType.Insert;
            RepairStockBll bll = new RepairStockBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsertRepair(repairhis, lstreasoncode);
            GC.Collect();
        }

        public void DoRepairBack(ContextInfo contextInfo, tinprepairstock repairstock, List<tinprepairfail> lstreasoncode, string jointtype, string signature)
        {
            contextInfo.Action = MES_ActionType.Insert;
            RepairStockBll bll = new RepairStockBll(contextInfo);
            bll.CallAccessControl();
            bll.DoRepairBack(repairstock, lstreasoncode, jointtype, signature);
            GC.Collect();
        }
        public DataSet GetRepairHisRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RepairHisBll bll = new RepairHisBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetRepairHisRecords(lstParameters);
            GC.Collect();
            return rs;
        }
        public tinprepairhis GetSingleRepairHis(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RepairHisBll bll = new RepairHisBll(contextInfo);
            bll.CallAccessControl();
            tinprepairhis his = bll.GetSingleObject<tinprepairhis>(lstParameters);
            GC.Collect();
            return his;
        }
        public void DoRepaireAdjust(ContextInfo contextInfo, string repsysid, string reasoncode, int qty)
        {
            contextInfo.Action = MES_ActionType.Insert;
            RepairStockBll bll = new RepairStockBll(contextInfo);
            bll.CallAccessControl();
            bll.DoRepaireAdjust(repsysid,reasoncode, qty);
            GC.Collect();
        }

        public int GetLeftRepairSuccessQty(ContextInfo contextInfo, string custorderno, string styleno, string color, string size, string step)
        {
            contextInfo.Action = MES_ActionType.Query;
            RepairFailBll bll = new RepairFailBll(contextInfo);
            bll.CallAccessControl();
            int result = bll.GetLeftRepairSuccessQty(custorderno,styleno,color,size,step);
            GC.Collect();
            return result;
        }

        public DataSet GetRepairInfoForInspectRpt(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RepairFailBll bll = new RepairFailBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetRepairInfoForInspectRpt(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetRepairFailForInspectRpt(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RepairFailBll bll = new RepairFailBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetRepairFailForInspectRpt(lstParameters);
            GC.Collect();
            return rs;
        }
        public DataSet GetShippedForInspectRpt(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RepairFailBll bll = new RepairFailBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetShippedForInspectRpt(lstParameters);
            GC.Collect();
            return rs;
        }
        public DataSet GetHeaderInfoForInspectRpt(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RepairFailBll bll = new RepairFailBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetHeaderInfoForInspectRpt(lstParameters);
            GC.Collect();
            return rs;
        }
        #endregion

        #region Return
        public void DoReturn(ContextInfo contextInfo, tinpreturn inpreturn, List<tinpreturndtl> lstreturndtl)
        {
            contextInfo.Action = MES_ActionType.Insert;
            ReturnBll bll = new ReturnBll(contextInfo);
            bll.CallAccessControl();
            bll.DoReturn(inpreturn,lstreturndtl);
            GC.Collect();
        }

        public DataSet GetReturnDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReturnDtlBll bll = new ReturnDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinpreturndtl>(lstParameters);
            GC.Collect();
            return rs;
        }
        public tinpreturn GetSingleReturn(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReturnBll bll = new ReturnBll(contextInfo);
            bll.CallAccessControl();
            tinpreturn ret = bll.GetSingleObject<tinpreturn>(lstParameters);
            GC.Collect();
            return ret;
        }
        #endregion

        #region Supplement
        public void DoSupplement(ContextInfo contextInfo, tinpsupplement supplement, List<tinpsupplementdtl> lstsupplementdtl)
        {
            contextInfo.Action = MES_ActionType.Insert;
            SupplementBll bll = new SupplementBll(contextInfo);
            bll.CallAccessControl();
            bll.DoSupplement(supplement, lstsupplementdtl);
            GC.Collect();
        }

        public DataSet GetSupplementDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            SupplementDtlBll bll = new SupplementDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinpsupplementdtl>(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DoSupplementAdjust(ContextInfo contextInfo, string supldtlsysid, int qty, string isreinspect)
        {
            contextInfo.Action = MES_ActionType.Insert;
            SupplementBll bll = new SupplementBll(contextInfo);
            bll.CallAccessControl();
            bll.DoSupplementAdjust(supldtlsysid, qty, isreinspect);
            GC.Collect();
        }
        #endregion

        #region Shipping
        public tinpshipping GetSingleShipping(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            tinpshipping shipping = bll.GetSingleObject<tinpshipping>(lstParameters);
            GC.Collect();
            return shipping;
        }
        public DataSet GetShippingRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinpshipping>(lstParameters);
            GC.Collect();
            return rs;
        }
        public tinpshippingdtl GetSingleShippingDtl(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingDtlBll bll = new ShippingDtlBll(contextInfo);
            bll.CallAccessControl();
            tinpshippingdtl shippingdtl = bll.GetSingleObject<tinpshippingdtl>(lstParameters);
            GC.Collect();
            return shippingdtl;
        }

        public DataSet GetShippingDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingDtlBll bll = new ShippingDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinpshippingdtl>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetShippingPlanNoRecords(ContextInfo contextInfo, string shippingsysid)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingDtlBll bll = new ShippingDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetShippingPlanNoRecords(shippingsysid);
            GC.Collect();
            return rs;
        }

        public void DoDeleteShipping(ContextInfo contextInfo, string shippingsysid)
        {
            contextInfo.Action = MES_ActionType.Delete;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDeleteShipping(shippingsysid);
            GC.Collect();
        }

        public DataSet GetShippingDtlForReport(ContextInfo contextInfo, string shippingsysid)
        {
            contextInfo.Action = MES_ActionType.Delete;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetShippingDtlForReport(shippingsysid);
            GC.Collect();
            return rs;
        }

        public DataSet GetShippingOrigDtlForReport(ContextInfo contextInfo, string shippingsysid)
        {
            contextInfo.Action = MES_ActionType.Delete;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetShippingOrigDtlForReport(shippingsysid);
            GC.Collect();
            return rs;
        }

        public DataSet GetShippingDtlForWarehouseOut(ContextInfo contextInfo, string shippingsysid)
        {
            contextInfo.Action = MES_ActionType.Delete;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetShippingDtlForWarehouseOut(shippingsysid);
            GC.Collect();
            return rs;
        }

        public DataSet GetBillForBillingReport(ContextInfo contextInfo, string shippingsysid)
        {
            contextInfo.Action = MES_ActionType.Delete;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetBillForBillingReport(shippingsysid);
            GC.Collect();
            return rs;
        }

        public DataSet GetShippingDtlCtnRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingDtlCtnBll bll = new ShippingDtlCtnBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinpshippingdtlctn>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetShippingPlanRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingDtlBll bll = new ShippingDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetShippingPlanRecords(lstParameters);
            GC.Collect();
            return rs;
        }


        public void DoShipPlan(ContextInfo contextInfo, List<tinpshippingdtl> lstshippingdtl, tinpshippingplan shippingplan)
        {
            contextInfo.Action = MES_ActionType.Insert;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            bll.DoShipPlan(lstshippingdtl, shippingplan);
            GC.Collect();
        }

        public void DoShipping(ContextInfo contextInfo, tinpshipping shipping, List<tinpshippingdtlctn> lstshippingdtlctn, tinpshippingplan shippingplan, bool isDoShipping)
        {
            contextInfo.Action = MES_ActionType.Insert;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            bll.DoShipping(shipping, lstshippingdtlctn,shippingplan, isDoShipping);
            GC.Collect();
        }

        public tinpshippingplan GetSingleShippingPlan(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingPlanBll bll = new ShippingPlanBll(contextInfo);
            bll.CallAccessControl();
            tinpshippingplan shippingdtl = bll.GetSingleObject<tinpshippingplan>(lstParameters);
            GC.Collect();
            return shippingdtl;
        }

        public DataSet GetShippingSumRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetShippingSumRecords(lstParameters);
            GC.Collect();
            return rs;
        }


        public DataSet GetShippingSumDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetShippingSumDtlRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetUnShippingSumRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetUnShippingSumRecords(lstParameters);
            GC.Collect();
            return rs;
        }


        public DataSet GetUnShippingSumDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetUnShippingSumDtlRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public bool HasShipByPlanNo(ContextInfo contextInfo, string shippingplanno)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShippingBll bll = new ShippingBll(contextInfo);
            bll.CallAccessControl();
            bool result = bll.HasShipByPlanNo(shippingplanno);
            GC.Collect();
            return result;
        }
        #endregion

        #region Packing
        public DataSet GetPackingCartonRecords(ContextInfo contextInfo)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecDtlBll bll = new PackingRecDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetPackingCartonRecords();
            GC.Collect();
            return rs;
        }

        public DataSet GetPackingCartonSummaryRecords(ContextInfo contextInfo)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecDtlBll bll = new PackingRecDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetPackingCartonSummaryRecords();
            GC.Collect();
            return rs;
        }

        public void DoXUnpacking(ContextInfo contextInfo, List<string[]> lstunpacking)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecBll bll = new PackingRecBll(contextInfo);
            bll.CallAccessControl();
            bll.DoXUnpacking(lstunpacking);
            GC.Collect();
        }

        public DataSet GetPackingRecDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecDtlBll bll = new PackingRecDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinppackingrecdtl>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetPackingDtlSumRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecDtlBll bll = new PackingRecDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetPackingDtlSumRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetPackingDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecDtlBll bll = new PackingRecDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetPackingDtlRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetHaveNotMovingDtlSumRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecDtlBll bll = new PackingRecDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetHaveNotMovingDtlSumRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetHaveNotMovingDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecDtlBll bll = new PackingRecDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetHaveNotMovingDtlRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetHaveNotPackingDtlSumRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecDtlBll bll = new PackingRecDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetHaveNotPackingDtlSumRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetHaveNotPackingDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecDtlBll bll = new PackingRecDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetHaveNotPackingDtlRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetLineWarehouseSumRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecDtlBll bll = new PackingRecDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetLineWarehouseSumRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetLineWarehouseSumDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecDtlBll bll = new PackingRecDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetLineWarehouseSumDtlRecords(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetPackingRecRetrieveRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            PackingRecRetrieveBll bll = new PackingRecRetrieveBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinppackingrecretrieve>(lstParameters);
            GC.Collect();
            return rs;
        }
        #endregion

        #region Other Pricing
        public List<tinpotherpricing> GetOtherPricingList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            OtherPricingBll bll = new OtherPricingBll(contextInfo);
            bll.CallAccessControl();
            List<tinpotherpricing> rs = bll.GetSelectedObjects<tinpotherpricing>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetOtherPricingRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            OtherPricingBll bll = new OtherPricingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinpotherpricing>(lstParameters);
            GC.Collect();
            return rs;
        }

        public tinpotherpricing GetSingleOtherPricing(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            OtherPricingBll bll = new OtherPricingBll(contextInfo);
            bll.CallAccessControl();
            tinpotherpricing rs = bll.GetSingleObject<tinpotherpricing>(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DoInsertOtherPricing(ContextInfo contextInfo, tinpotherpricing otherpricing)
        {
            contextInfo.Action = MES_ActionType.Insert;
            OtherPricingBll bll = new OtherPricingBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert(otherpricing);
            GC.Collect();
        }
        public void DoUpdateOtherPricing(ContextInfo contextInfo, tinpotherpricing otherpricing)
        {
            contextInfo.Action = MES_ActionType.Update;
            OtherPricingBll bll = new OtherPricingBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate(otherpricing);
            GC.Collect();
        }

        public void DoDeleteOtherPricing(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            OtherPricingBll bll = new OtherPricingBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tinpotherpricing>(lstParameters);
            GC.Collect();
        }
        public DataSet GetValidOtherPricing(ContextInfo contextInfo, string customerid, DateTime dt)
        {
            contextInfo.Action = MES_ActionType.Query;
            OtherPricingBll bll = new OtherPricingBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetValidOtherPricing(customerid, dt);
            GC.Collect();
            return rs;
        }
        #endregion

        #region Request Pay
        public void DoInsertRequestPay(ContextInfo contextInfo, tinprequestpay requestPay, List<tinprequestpaydtl> lstDtl)
        {
            contextInfo.Action = MES_ActionType.Insert;
            RequestPayBll bll = new RequestPayBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsertRequestPay(requestPay, lstDtl);
            GC.Collect();
        }

        public tinprequestpay GetSingleRequestPay(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RequestPayBll bll = new RequestPayBll(contextInfo);
            bll.CallAccessControl();
            tinprequestpay rs = bll.GetSingleObject<tinprequestpay>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetRequestPayDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RequestPayDtlBll bll = new RequestPayDtlBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tinprequestpaydtl>(lstParameters);
            GC.Collect();
            return rs;
        }
        #endregion
    }
}

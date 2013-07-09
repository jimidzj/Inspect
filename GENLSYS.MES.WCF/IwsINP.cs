using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;

namespace GENLSYS.MES.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IwsINP" in both code and config file together.
    [ServiceContract]
    public interface IwsINP
    {
        [OperationContract]
        void DoWork();

        #region Order
        [OperationContract]
        DataSet GetCustOrderRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region WIP
        [OperationContract]
        List<tinpwip> GetWipList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        
        [OperationContract]
        DataSet GetWipRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        
        [OperationContract]
        tinpwip GetSingleWip(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetLeftWipRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion


        #region Work Order
        [OperationContract]
        List<tinpworkorder> GetWorkOrderList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetWorkOrderRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tinpworkorder GetSingleWorkOrder(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertWorkOrder(ContextInfo contextInfo, tinpworkorder workorder,
            List<tinpworkorderdtl> lstDtl);

        [OperationContract]
        void DoUpdateWorkOrder(ContextInfo contextInfo, tinpworkorder workorder,
            List<tinpworkorderdtl> lstDtl);

        [OperationContract]
        void DoDeleteWorkOrder(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetWorkOrderDetailRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetCustOrderForReceiving(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Pricing
        [OperationContract]
        tinppricing GetSinglePricing(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetPricingRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertPricing(ContextInfo contextInfo, tinppricing prc, List<tinppricingdtl> lstPrcDtl,
            List<tinppricingdtldef> lstDef);

        [OperationContract]
        void DoUpdatePricing(ContextInfo contextInfo, tinppricing prc, List<tinppricingdtl> lstPrcDtl,
            List<tinppricingdtldef> lstDef);

        [OperationContract]
        DataSet GetValidPricing(ContextInfo contextInfo, string customerid, DateTime dt);
        #endregion

        #region Receiving
        [OperationContract]
        List<tinpreceiving> GetReceivingList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetReceivingRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tinpreceiving GetSingleReceiving(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertReceiving(ContextInfo contextInfo, tinpreceiving rec, List<tinpreceivingdtl> lstDtl);

        [OperationContract]
        void DoUpdateReceiving(ContextInfo contextInfo, tinpreceiving rec, List<tinpreceivingdtl> lstDtlNew, List<tinpreceivingdtl> lstDtlUpdated, List<string> lstDeleted);

        [OperationContract]
        void DoDeleteReceiving(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetReceivingDetailRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetReceivingCartonDetailRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetReceivingHeader_Print(ContextInfo contextInfo, string recno);

        [OperationContract]
        DataSet GetReceivingDetail_Print(ContextInfo contextInfo, string recno);

        [OperationContract]
        DataSet GetReceivingSumCtnDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetReceivingCtnDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void UpdateCartonQty(ContextInfo contextInfo, string recsysid,
            string cartonno, string oldstyleno, string oldcolor, string oldsize, int quantity, string color, string size, string styleno);

        [OperationContract]
        void DeleteSingleCarton(ContextInfo contextInfo, string recsysid, string cartonno,string oldstyleno,string oldcolor,string oldsize);

        [OperationContract]
        bool CheckReceivingUsed(ContextInfo contextInfo, string recsysid);
        #endregion

        #region IQC
        [OperationContract]
        List<tinpiqc> GetIQCList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetIQCRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tinpiqc GetSingleIQC(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertIQC(ContextInfo contextInfo, tinpiqc iqc,
            List<tinpiqcfail> lstFail, List<tinpiqcreturn> lstReturn);

        [OperationContract]
        void DoUpdateIQC(ContextInfo contextInfo, tinpiqc iqc,
            List<tinpiqcfail> lstFail, List<tinpiqcreturn> lstReturn);

        [OperationContract]
        void DoDeleteIQC(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetIQCFail(ContextInfo contextInfo, string iqcsysid);

        [OperationContract]
        DataSet GetIQCReturn(ContextInfo contextInfo, string iqcsysid, string styleno);

        [OperationContract]
        DataSet GetValidIQC(ContextInfo contextInfo, string customerid);
        #endregion

        #region Schedule
        [OperationContract]
        List<tinpschedule> GetScheduleList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetScheduleRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoDeleteSchedule(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertSchedule(ContextInfo contextInfo, string yearmonth, List<tinpschedule> lstSchedule);

        [OperationContract]
        void DoUpdateSchedule(ContextInfo contextInfo, string yearmonth, List<tinpschedule> lstSchedule);

        [OperationContract]
        DataSet GetDailySchedule(ContextInfo contextInfo, string startdate, string enddate);
        #endregion

        #region Cust Order History
        [OperationContract]
        DataSet GetCustOrderHistoryRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Repair
        [OperationContract]
        DataSet GetRepairFailRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetRepairStockRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        tinprepairstock GetSingleRepairStock(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        void DoInsertRepair(ContextInfo contextInfo, tinprepairhis repairhis, List<tinprepairfail> lstreasoncode);
        [OperationContract]
        void DoRepairBack(ContextInfo contextInfo, tinprepairstock repairstock, List<tinprepairfail> lstreasoncode, string jointtype, string signature);
        [OperationContract]
        DataSet GetRepairHisRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        tinprepairhis GetSingleRepairHis(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        void DoRepaireAdjust(ContextInfo contextInfo, string repsysid, string reasoncode, int qty);
        [OperationContract]
        int GetLeftRepairSuccessQty(ContextInfo contextInfo, string custorderno, string styleno, string color, string size, string step);
        [OperationContract]
        DataSet GetRepairInfoForInspectRpt(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetRepairFailForInspectRpt(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetShippedForInspectRpt(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetHeaderInfoForInspectRpt(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Return
        [OperationContract]
        void DoReturn(ContextInfo contextInfo, tinpreturn inpreturn, List<tinpreturndtl> lstreturndtl);
        [OperationContract]
        DataSet GetReturnDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        tinpreturn GetSingleReturn(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Supplement
        [OperationContract]
        void DoSupplement(ContextInfo contextInfo, tinpsupplement supplement, List<tinpsupplementdtl> lstsupplementdtl);
        [OperationContract]
        DataSet GetSupplementDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        void DoSupplementAdjust(ContextInfo contextInfo, string supldtlsysid, int qty, string isreinspect);
        #endregion

        #region Shipping
        [OperationContract]
        tinpshipping GetSingleShipping(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetShippingRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        tinpshippingdtl GetSingleShippingDtl(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetShippingDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetShippingPlanNoRecords(ContextInfo contextInfo, string shippingsysid);
        [OperationContract]
        void DoDeleteShipping(ContextInfo contextInfo, string shippingsysid);
        [OperationContract]
        DataSet GetShippingDtlForReport(ContextInfo contextInfo, string shippingsysid);
        [OperationContract]
        DataSet GetShippingOrigDtlForReport(ContextInfo contextInfo, string shippingsysid);
        [OperationContract]
        DataSet GetShippingDtlForWarehouseOut(ContextInfo contextInfo, string shippingsysid);
        [OperationContract]
        DataSet GetBillForBillingReport(ContextInfo contextInfo, string shippingsysid);
        [OperationContract]
        DataSet GetShippingDtlCtnRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetShippingPlanRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        void DoShipPlan(ContextInfo contextInfo, List<tinpshippingdtl> lstshippingdtl,tinpshippingplan shippingplan);
        [OperationContract]
        void DoShipping(ContextInfo contextInfo, tinpshipping shipping, List<tinpshippingdtlctn> lstshippingdtlctn, tinpshippingplan shippingplan, bool isDoShipping);
        [OperationContract]
        tinpshippingplan GetSingleShippingPlan(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetShippingSumRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetShippingSumDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetUnShippingSumRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetUnShippingSumDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        bool HasShipByPlanNo(ContextInfo contextInfo, string shippingplanno);
        #endregion

        #region Packing
        [OperationContract]
        DataSet GetPackingCartonRecords(ContextInfo contextInfo);
        [OperationContract]
        DataSet GetPackingCartonSummaryRecords(ContextInfo contextInfo);
        [OperationContract]
        void DoXUnpacking(ContextInfo contextInfo, List<string[]> lstunpacking);
        [OperationContract]
        DataSet GetPackingRecDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetPackingDtlSumRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetPackingDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetHaveNotMovingDtlSumRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetHaveNotMovingDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetHaveNotPackingDtlSumRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetHaveNotPackingDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetLineWarehouseSumRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetLineWarehouseSumDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetPackingRecRetrieveRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Other Pricing
        [OperationContract]
        List<tinpotherpricing> GetOtherPricingList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetOtherPricingRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        tinpotherpricing GetSingleOtherPricing(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        void DoInsertOtherPricing(ContextInfo contextInfo, tinpotherpricing otherpricing);
        [OperationContract]
        void DoUpdateOtherPricing(ContextInfo contextInfo, tinpotherpricing otherpricing);
        [OperationContract]
        void DoDeleteOtherPricing(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetValidOtherPricing(ContextInfo contextInfo, string customerid, DateTime dt);
        #endregion

        #region Request Pay
        [OperationContract]
        void DoInsertRequestPay(ContextInfo contextInfo, tinprequestpay requestPay, List<tinprequestpaydtl> lstDtl);
        [OperationContract]
        tinprequestpay GetSingleRequestPay(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        [OperationContract]
        DataSet GetRequestPayDtlRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

    }
}

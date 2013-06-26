using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IwsBasis" in both code and config file together.
    [ServiceContract]
    public interface IwsMDL
    {
        #region Employee
        [OperationContract]
        List<tmdlemployee> GetEmployeeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetEmployeeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tmdlemployee GetSingleEmployee(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertEmployee(ContextInfo contextInfo, tmdlemployee employee);

        [OperationContract]
        void DoUpdateEmployee(ContextInfo contextInfo, tmdlemployee employee);

        [OperationContract]
        void DoDeleteEmployee(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Employee Type
        [OperationContract]
        List<tmdlemployeetype> GetEmployeeTypeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetEmployeeTypeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tmdlemployeetype GetSingleEmployeeType(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertEmployeeType(ContextInfo contextInfo, tmdlemployeetype employeetype);

        [OperationContract]
        void DoUpdateEmployeeType(ContextInfo contextInfo, tmdlemployeetype employeetype);

        [OperationContract]
        void DoDeleteEmployeeType(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Customer
        [OperationContract]
        List<tmdlcustomer> GetCustomerList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetCustomerRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tmdlcustomer GetSingleCustomer(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertCustomer(ContextInfo contextInfo, tmdlcustomer customer, List<tmdlcontact> lstContact);

        [OperationContract]
        void DoUpdateCustomer(ContextInfo contextInfo, tmdlcustomer customer, List<tmdlcontact> lstContact);               

        [OperationContract]
        void DoDeleteCustomer(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetContactRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion     

        #region Reason Category
        [OperationContract]
        List<tmdlreasoncategory> GetReasonCategoryList(ContextInfo contextInfo,List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetReasonCategoryRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tmdlreasoncategory GetSingleReasonCategory(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertReasonCategory(ContextInfo contextInfo, tmdlreasoncategory reasoncategory);

        [OperationContract]
        void DoUpdateReasonCategory(ContextInfo contextInfo, tmdlreasoncategory reasoncategory);

        [OperationContract]
        void DoDeleteReasonCategory(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Reason Code
        [OperationContract]
        List<tmdlreasoncode> GetReasonCodeList_ByCategoryStep(ContextInfo contextInfo,
            string reasonCodeCategory, string stepsysid);

        [OperationContract]
        List<tmdlreasoncode> GetReasonCodeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetReasonCodeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tmdlreasoncode GetSingleReasonCode(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertReasonCode(ContextInfo contextInfo, tmdlreasoncode reasoncode, 
            List<tmdlreasoncodestep> lstReasonCodeStep,List<tsysattributevalue> lstAttribute);

        [OperationContract]
        void DoUpdateReasonCode(ContextInfo contextInfo, tmdlreasoncode reasoncode, 
            List<tmdlreasoncodestep> lstReasonCodeStep,List<tsysattributevalue> lstAttribute);

        [OperationContract]
        void DoDeleteReasonCode(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //List<tmdlreasoncoderls> GetReasonCodeRlsList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Reason Code Step
        [OperationContract]
        DataSet GetReasonCodeStep(ContextInfo contextInfo, string reasoncode);
        
        #endregion

        #region Shift
        [OperationContract]
        DataSet GetShiftRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        List<tmdlshift> GetShiftList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tmdlshift GetSingleShift(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertShift(ContextInfo contextInfo, tmdlshift shift);

        [OperationContract]
        void DoUpdateShift(ContextInfo contextInfo, tmdlshift shift);

        [OperationContract]
        void DoDeleteShift(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region WorkGroup
        [OperationContract]
        List<tmdlworkgroup> GetWorkGroupList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetWorkGroupRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tmdlworkgroup GetSingleWorkGroup(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertWorkGroup(ContextInfo contextInfo, tmdlworkgroup location);

        [OperationContract]
        void DoUpdateWorkGroup(ContextInfo contextInfo, tmdlworkgroup location);

        [OperationContract]
        void DoDeleteWorkGroup(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Exchange
        [OperationContract]
        List<tmdlexchange> GetExchangeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetExchangeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tmdlexchange GetSingleExchange(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertExchange(ContextInfo contextInfo, tmdlexchange exchange);

        [OperationContract]
        void DoUpdateExchange(ContextInfo contextInfo, tmdlexchange exchange);

        [OperationContract]
        void DoDeleteExchange(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetValidExchange(ContextInfo contextInfo, DateTime dt);
        #endregion
    }
}

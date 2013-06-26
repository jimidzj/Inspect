using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Services.MDL;
using System.Data;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wsBasis" in code, svc and config file together.
    public class wsMDL : IwsMDL
    {
        #region Employee
        public List<tmdlemployee> GetEmployeeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            EmployeeBll bll = new EmployeeBll(contextInfo);
            bll.CallAccessControl();
            List<tmdlemployee> rs = bll.GetSelectedObjects<tmdlemployee>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetEmployeeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            EmployeeBll bll = new EmployeeBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tmdlemployee>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public tmdlemployee GetSingleEmployee(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            EmployeeBll bll = new EmployeeBll(contextInfo);
            bll.CallAccessControl();
            tmdlemployee rs = bll.GetSingleObject<tmdlemployee>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public void DoInsertEmployee(ContextInfo contextInfo, tmdlemployee employee)
        {
            contextInfo.Action = MES_ActionType.Insert;
            EmployeeBll bll = new EmployeeBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert<tmdlemployee>(employee);
            GC.Collect();
        }
        public void DoUpdateEmployee(ContextInfo contextInfo, tmdlemployee employee)
        {
            contextInfo.Action = MES_ActionType.Update;
            EmployeeBll bll = new EmployeeBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate<tmdlemployee>(employee);
            GC.Collect();
        }
        public void DoDeleteEmployee(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            EmployeeBll bll = new EmployeeBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tmdlemployee>(lstParameters);
            GC.Collect();
        }

        #endregion

        #region Employee Type
        public List<tmdlemployeetype> GetEmployeeTypeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            EmployeeTypeBll bll = new EmployeeTypeBll(contextInfo);
            bll.CallAccessControl();
            List<tmdlemployeetype> rs = bll.GetSelectedObjects<tmdlemployeetype>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetEmployeeTypeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            EmployeeTypeBll bll = new EmployeeTypeBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tmdlemployeetype>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public tmdlemployeetype GetSingleEmployeeType(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            EmployeeTypeBll bll = new EmployeeTypeBll(contextInfo);
            bll.CallAccessControl();
            tmdlemployeetype rs = bll.GetSingleObject<tmdlemployeetype>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public void DoInsertEmployeeType(ContextInfo contextInfo, tmdlemployeetype employeetype)
        {
            contextInfo.Action = MES_ActionType.Insert;
            EmployeeTypeBll bll = new EmployeeTypeBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert<tmdlemployeetype>(employeetype);
            GC.Collect();
        }
        public void DoUpdateEmployeeType(ContextInfo contextInfo, tmdlemployeetype employeetype)
        {
            contextInfo.Action = MES_ActionType.Delete;
            EmployeeTypeBll bll = new EmployeeTypeBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate<tmdlemployeetype>(employeetype);
            GC.Collect();
        }
        public void DoDeleteEmployeeType(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            EmployeeTypeBll bll = new EmployeeTypeBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tmdlemployeetype>(lstParameters);
            GC.Collect();
        }
        
        #endregion

        #region Customer
        public List<tmdlcustomer> GetCustomerList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            CustomerBll bll = new CustomerBll(contextInfo);
            bll.CallAccessControl();
            List<tmdlcustomer> rs = bll.GetSelectedObjects<tmdlcustomer>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetCustomerRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            CustomerBll bll = new CustomerBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tmdlcustomer>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public tmdlcustomer GetSingleCustomer(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            CustomerBll bll = new CustomerBll(contextInfo);
            bll.CallAccessControl();
            tmdlcustomer rs = bll.GetSingleObject<tmdlcustomer>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public void DoInsertCustomer(ContextInfo contextInfo, tmdlcustomer customer,List<tmdlcontact> lstContact)
        {
            contextInfo.Action = MES_ActionType.Insert;
            CustomerBll bll = new CustomerBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsertCustomer(customer,lstContact);
            GC.Collect();
        }
        public void DoUpdateCustomer(ContextInfo contextInfo, tmdlcustomer customer,List<tmdlcontact> lstContact)
        {
            contextInfo.Action = MES_ActionType.Update;
            CustomerBll bll = new CustomerBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdateCustomer(customer,lstContact);
            GC.Collect();
        }

        public void DoDeleteCustomer(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            CustomerBll bll = new CustomerBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDeleteCustomer(lstParameters);
            GC.Collect();
        }

        public DataSet GetContactRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            CustomerBll bll = new CustomerBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetContactRecords(lstParameters);
            GC.Collect();
            return rs;
        }
        #endregion

        #region Reason Category
        public List<tmdlreasoncategory> GetReasonCategoryList(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReasonCategoryBll bll = new ReasonCategoryBll(contextInfo);
            bll.CallAccessControl();
            List<tmdlreasoncategory> rs = bll.GetSelectedObjects<tmdlreasoncategory>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetReasonCategoryRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReasonCategoryBll bll = new ReasonCategoryBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tmdlreasoncategory>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public tmdlreasoncategory GetSingleReasonCategory(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReasonCategoryBll bll = new ReasonCategoryBll(contextInfo);
            bll.CallAccessControl();
            tmdlreasoncategory rs = bll.GetSingleObject<tmdlreasoncategory>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public void DoInsertReasonCategory(ContextInfo contextInfo, tmdlreasoncategory reasoncategory)
        {
            contextInfo.Action = MES_ActionType.Insert;
            ReasonCategoryBll bll = new ReasonCategoryBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert(reasoncategory);
            GC.Collect();
        }
        public void DoUpdateReasonCategory(ContextInfo contextInfo, tmdlreasoncategory reasoncategory)
        {
            contextInfo.Action = MES_ActionType.Update;
            ReasonCategoryBll bll = new ReasonCategoryBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate(reasoncategory);
            GC.Collect();
        }

        public void DoDeleteReasonCategory(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            ReasonCategoryBll bll = new ReasonCategoryBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tmdlreasoncategory>(lstParameters);
            GC.Collect();
        }       
        #endregion

        #region Reason Code
        public List<tmdlreasoncode> GetReasonCodeList_ByCategoryStep(ContextInfo contextInfo, 
            string reasonCodeCategory, string stepsysid)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReasonCodeBll bll = new ReasonCodeBll(contextInfo);
            bll.CallAccessControl();
            List<tmdlreasoncode> rs = bll.GetReasonCodeList_ByCategoryStep(reasonCodeCategory, stepsysid);
            GC.Collect();
            return rs;
        }

        public List<tmdlreasoncode> GetReasonCodeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReasonCodeBll bll = new ReasonCodeBll(contextInfo);
            bll.CallAccessControl();
            List<tmdlreasoncode> rs = bll.GetSelectedObjects<tmdlreasoncode>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetReasonCodeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReasonCodeBll bll = new ReasonCodeBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tmdlreasoncode>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public tmdlreasoncode GetSingleReasonCode(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReasonCodeBll bll = new ReasonCodeBll(contextInfo);
            bll.CallAccessControl();
            tmdlreasoncode rs = bll.GetSingleObject<tmdlreasoncode>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public void DoInsertReasonCode(ContextInfo contextInfo, tmdlreasoncode reasoncode,
            List<tmdlreasoncodestep> lstReasonCodeStep, List<tsysattributevalue> lstAttribute)
        {
            contextInfo.Action = MES_ActionType.Insert;
            ReasonCodeBll bll = new ReasonCodeBll(contextInfo);
            bll.CallAccessControl();
            bll.InsertReasonCode(reasoncode,lstReasonCodeStep, lstAttribute);
            GC.Collect();
        }

        public void DoUpdateReasonCode(ContextInfo contextInfo, tmdlreasoncode reasoncode,
            List<tmdlreasoncodestep> lstReasonCodeStep, List<tsysattributevalue> lstAttribute)
        {
            contextInfo.Action = MES_ActionType.Update;
            ReasonCodeBll bll = new ReasonCodeBll(contextInfo);
            bll.CallAccessControl();
            bll.UpdateReasonCode(reasoncode,lstReasonCodeStep, lstAttribute);
            GC.Collect();
        }

        public void DoDeleteReasonCode(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            ReasonCodeBll bll = new ReasonCodeBll(contextInfo);
            bll.CallAccessControl();
            bll.DeleteReasonCode(lstParameters);
            GC.Collect();
        }

        //public List<tmdlreasoncoderls> GetReasonCodeRlsList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    ReasonCodeRlsBll bll = new ReasonCodeRlsBll(contextInfo);
        //    bll.CallAccessControl();
        //    List<tmdlreasoncoderls> rs = bll.GetSelectedObjects<tmdlreasoncoderls>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}
        #endregion

        #region Reason Code Step
        public DataSet GetReasonCodeStep(ContextInfo contextInfo, string reasoncode)
        {
            contextInfo.Action = MES_ActionType.Query;
            ReasonCodeStepBll bll = new ReasonCodeStepBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetReasonCodeStep(reasoncode);
            GC.Collect();
            return rs; 
        }
        #endregion

        #region Shift
        public DataSet GetShiftRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShiftBll bll = new ShiftBll(contextInfo);
            //不需要Access Control
            //bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tmdlshift>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public List<tmdlshift> GetShiftList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShiftBll bll = new ShiftBll(contextInfo);
            //不需要Access Control
            //bll.CallAccessControl();
            List<tmdlshift> rs = bll.GetSelectedObjects<tmdlshift>(lstParameters);
            GC.Collect();
            return rs; 
        }
        public tmdlshift GetSingleShift(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ShiftBll bll = new ShiftBll(contextInfo);
            bll.CallAccessControl();
            tmdlshift rs = bll.GetSingleObject<tmdlshift>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public void DoInsertShift(ContextInfo contextInfo, tmdlshift shift)
        {
            contextInfo.Action = MES_ActionType.Insert;
            ShiftBll bll = new ShiftBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert<tmdlshift>(shift);
            GC.Collect();
        }
        public void DoUpdateShift(ContextInfo contextInfo, tmdlshift shift)
        {
            contextInfo.Action = MES_ActionType.Delete;
            ShiftBll bll = new ShiftBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate<tmdlshift>(shift);
            GC.Collect();
        }
        public void DoDeleteShift(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            ShiftBll bll = new ShiftBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tmdlshift>(lstParameters);
            GC.Collect();
        }
        #endregion

        #region WorkGroup
        public List<tmdlworkgroup> GetWorkGroupList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            WorkGroupBll bll = new WorkGroupBll(contextInfo);
            bll.CallAccessControl();
            List<tmdlworkgroup> rs = bll.GetSelectedObjects<tmdlworkgroup>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetWorkGroupRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            WorkGroupBll bll = new WorkGroupBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tmdlworkgroup>(lstParameters);
            GC.Collect();
            return rs;
        }

        public tmdlworkgroup GetSingleWorkGroup(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            WorkGroupBll bll = new WorkGroupBll(contextInfo);
            bll.CallAccessControl();
            tmdlworkgroup rs = bll.GetSingleObject<tmdlworkgroup>(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DoInsertWorkGroup(ContextInfo contextInfo, tmdlworkgroup location)
        {
            contextInfo.Action = MES_ActionType.Insert;
            WorkGroupBll bll = new WorkGroupBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert(location);
            GC.Collect();
        }
        public void DoUpdateWorkGroup(ContextInfo contextInfo, tmdlworkgroup location)
        {
            contextInfo.Action = MES_ActionType.Update;
            WorkGroupBll bll = new WorkGroupBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate(location);
            GC.Collect();
        }

        public void DoDeleteWorkGroup(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            WorkGroupBll bll = new WorkGroupBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tmdlworkgroup>(lstParameters);
            GC.Collect();
        }
        #endregion


        #region Exchange
        public List<tmdlexchange> GetExchangeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ExchangeBll bll = new ExchangeBll(contextInfo);
            bll.CallAccessControl();
            List<tmdlexchange> rs = bll.GetSelectedObjects<tmdlexchange>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetExchangeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ExchangeBll bll = new ExchangeBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tmdlexchange>(lstParameters);
            GC.Collect();
            return rs;
        }

        public tmdlexchange GetSingleExchange(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            ExchangeBll bll = new ExchangeBll(contextInfo);
            bll.CallAccessControl();
            tmdlexchange rs = bll.GetSingleObject<tmdlexchange>(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DoInsertExchange(ContextInfo contextInfo, tmdlexchange exchange)
        {
            contextInfo.Action = MES_ActionType.Insert;
            ExchangeBll bll = new ExchangeBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert(exchange);
            GC.Collect();
        }
        public void DoUpdateExchange(ContextInfo contextInfo, tmdlexchange exchange)
        {
            contextInfo.Action = MES_ActionType.Update;
            ExchangeBll bll = new ExchangeBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate(exchange);
            GC.Collect();
        }

        public void DoDeleteExchange(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            ExchangeBll bll = new ExchangeBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tmdlexchange>(lstParameters);
            GC.Collect();
        }
        public DataSet GetValidExchange(ContextInfo contextInfo, DateTime dt)
        {
            contextInfo.Action = MES_ActionType.Query;
            ExchangeBll bll = new ExchangeBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetValidExchange(dt);
            GC.Collect();
            return rs;
        }
        #endregion

    }

}

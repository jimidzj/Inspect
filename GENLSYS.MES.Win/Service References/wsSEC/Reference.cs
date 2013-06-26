﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GENLSYS.MES.Win.wsSEC {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wsSEC.IwsSEC")]
    public interface IwsSEC {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/Logout", ReplyAction="http://tempuri.org/IwsSEC/LogoutResponse")]
        void Logout(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string sessionid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/UpdateLogonTime", ReplyAction="http://tempuri.org/IwsSEC/UpdateLogonTimeResponse")]
        void UpdateLogonTime(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string sessionid, string userid, string machine, string shift);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/ChangePassword", ReplyAction="http://tempuri.org/IwsSEC/ChangePasswordResponse")]
        void ChangePassword(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string userid, string oldPassword, string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/ValidatePassword", ReplyAction="http://tempuri.org/IwsSEC/ValidatePasswordResponse")]
        void ValidatePassword(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string userid, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetAreaByUserId", ReplyAction="http://tempuri.org/IwsSEC/GetAreaByUserIdResponse")]
        System.Data.DataSet GetAreaByUserId(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetUserList", ReplyAction="http://tempuri.org/IwsSEC/GetUserListResponse")]
        GENLSYS.MES.DataContracts.tsecuser[] GetUserList(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetUserRecords", ReplyAction="http://tempuri.org/IwsSEC/GetUserRecordsResponse")]
        System.Data.DataSet GetUserRecords(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetSingleUser", ReplyAction="http://tempuri.org/IwsSEC/GetSingleUserResponse")]
        GENLSYS.MES.DataContracts.tsecuser GetSingleUser(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/DoInsertUser", ReplyAction="http://tempuri.org/IwsSEC/DoInsertUserResponse")]
        void DoInsertUser(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.tsecuser user, GENLSYS.MES.DataContracts.tsecuserrole[] lstUserRole);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/DoUpdateUser", ReplyAction="http://tempuri.org/IwsSEC/DoUpdateUserResponse")]
        void DoUpdateUser(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.tsecuser user, GENLSYS.MES.DataContracts.tsecuserrole[] lstUserRole);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/DoDeleteUser", ReplyAction="http://tempuri.org/IwsSEC/DoDeleteUserResponse")]
        void DoDeleteUser(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetRoleList", ReplyAction="http://tempuri.org/IwsSEC/GetRoleListResponse")]
        GENLSYS.MES.DataContracts.tsecrole[] GetRoleList(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetRoleRecords", ReplyAction="http://tempuri.org/IwsSEC/GetRoleRecordsResponse")]
        System.Data.DataSet GetRoleRecords(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetSingleRole", ReplyAction="http://tempuri.org/IwsSEC/GetSingleRoleResponse")]
        GENLSYS.MES.DataContracts.tsecrole GetSingleRole(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/DoInsertRole", ReplyAction="http://tempuri.org/IwsSEC/DoInsertRoleResponse")]
        void DoInsertRole(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.tsecrole role, GENLSYS.MES.DataContracts.tsecrolefunction[] lstRoleFunctions, GENLSYS.MES.DataContracts.tsecrolestep[] lstRoleSteps, GENLSYS.MES.DataContracts.tsecroleeqpgroup[] lstRoleEqpGroups);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/DoUpdateRole", ReplyAction="http://tempuri.org/IwsSEC/DoUpdateRoleResponse")]
        void DoUpdateRole(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.tsecrole role, GENLSYS.MES.DataContracts.tsecrolefunction[] lstRoleFunctions, GENLSYS.MES.DataContracts.tsecrolestep[] lstRoleSteps, GENLSYS.MES.DataContracts.tsecroleeqpgroup[] lstRoleEqpGroups);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/DoDeleteRole", ReplyAction="http://tempuri.org/IwsSEC/DoDeleteRoleResponse")]
        void DoDeleteRole(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetRoleFunctionRecords", ReplyAction="http://tempuri.org/IwsSEC/GetRoleFunctionRecordsResponse")]
        System.Data.DataSet GetRoleFunctionRecords(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetRoleFunctionRecordsByRoleId", ReplyAction="http://tempuri.org/IwsSEC/GetRoleFunctionRecordsByRoleIdResponse")]
        System.Data.DataSet GetRoleFunctionRecordsByRoleId(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string roleid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetFunctionsByUserId", ReplyAction="http://tempuri.org/IwsSEC/GetFunctionsByUserIdResponse")]
        System.Data.DataSet GetFunctionsByUserId(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string roleid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetRoleStepList", ReplyAction="http://tempuri.org/IwsSEC/GetRoleStepListResponse")]
        GENLSYS.MES.DataContracts.tsecrolestep[] GetRoleStepList(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetStepsByUserId", ReplyAction="http://tempuri.org/IwsSEC/GetStepsByUserIdResponse")]
        System.Data.DataSet GetStepsByUserId(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetRoleEqpGroupRecords", ReplyAction="http://tempuri.org/IwsSEC/GetRoleEqpGroupRecordsResponse")]
        System.Data.DataSet GetRoleEqpGroupRecords(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetRoleEqpGroupRecordsByRoleId", ReplyAction="http://tempuri.org/IwsSEC/GetRoleEqpGroupRecordsByRoleIdResponse")]
        System.Data.DataSet GetRoleEqpGroupRecordsByRoleId(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string roleid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetUserRoleList", ReplyAction="http://tempuri.org/IwsSEC/GetUserRoleListResponse")]
        GENLSYS.MES.DataContracts.tsecuserrole[] GetUserRoleList(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetUserRoleRecords", ReplyAction="http://tempuri.org/IwsSEC/GetUserRoleRecordsResponse")]
        System.Data.DataSet GetUserRoleRecords(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetFunctionsList", ReplyAction="http://tempuri.org/IwsSEC/GetFunctionsListResponse")]
        GENLSYS.MES.DataContracts.tsecfunctions[] GetFunctionsList(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetFunctionsRecords", ReplyAction="http://tempuri.org/IwsSEC/GetFunctionsRecordsResponse")]
        System.Data.DataSet GetFunctionsRecords(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/GetSingleFunctions", ReplyAction="http://tempuri.org/IwsSEC/GetSingleFunctionsResponse")]
        GENLSYS.MES.DataContracts.tsecfunctions GetSingleFunctions(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/DoInsertFunctions", ReplyAction="http://tempuri.org/IwsSEC/DoInsertFunctionsResponse")]
        void DoInsertFunctions(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.tsecfunctions functions);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/DoUpdateFunctions", ReplyAction="http://tempuri.org/IwsSEC/DoUpdateFunctionsResponse")]
        void DoUpdateFunctions(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.tsecfunctions functions);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/DoDeleteFunctions", ReplyAction="http://tempuri.org/IwsSEC/DoDeleteFunctionsResponse")]
        void DoDeleteFunctions(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsSEC/Logon", ReplyAction="http://tempuri.org/IwsSEC/LogonResponse")]
        void Logon(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string userid, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IwsSECChannel : GENLSYS.MES.Win.wsSEC.IwsSEC, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IwsSECClient : System.ServiceModel.ClientBase<GENLSYS.MES.Win.wsSEC.IwsSEC>, GENLSYS.MES.Win.wsSEC.IwsSEC {
        
        public IwsSECClient() {
        }
        
        public IwsSECClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IwsSECClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IwsSECClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IwsSECClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Logout(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string sessionid) {
            base.Channel.Logout(contextInfo, sessionid);
        }
        
        public void UpdateLogonTime(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string sessionid, string userid, string machine, string shift) {
            base.Channel.UpdateLogonTime(contextInfo, sessionid, userid, machine, shift);
        }
        
        public void ChangePassword(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string userid, string oldPassword, string newPassword) {
            base.Channel.ChangePassword(contextInfo, userid, oldPassword, newPassword);
        }
        
        public void ValidatePassword(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string userid, string password) {
            base.Channel.ValidatePassword(contextInfo, userid, password);
        }
        
        public System.Data.DataSet GetAreaByUserId(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string userid) {
            return base.Channel.GetAreaByUserId(contextInfo, userid);
        }
        
        public GENLSYS.MES.DataContracts.tsecuser[] GetUserList(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetUserList(contextInfo, lstParameters);
        }
        
        public System.Data.DataSet GetUserRecords(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetUserRecords(contextInfo, lstParameters);
        }
        
        public GENLSYS.MES.DataContracts.tsecuser GetSingleUser(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetSingleUser(contextInfo, lstParameters);
        }
        
        public void DoInsertUser(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.tsecuser user, GENLSYS.MES.DataContracts.tsecuserrole[] lstUserRole) {
            base.Channel.DoInsertUser(contextInfo, user, lstUserRole);
        }
        
        public void DoUpdateUser(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.tsecuser user, GENLSYS.MES.DataContracts.tsecuserrole[] lstUserRole) {
            base.Channel.DoUpdateUser(contextInfo, user, lstUserRole);
        }
        
        public void DoDeleteUser(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            base.Channel.DoDeleteUser(contextInfo, lstParameters);
        }
        
        public GENLSYS.MES.DataContracts.tsecrole[] GetRoleList(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetRoleList(contextInfo, lstParameters);
        }
        
        public System.Data.DataSet GetRoleRecords(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetRoleRecords(contextInfo, lstParameters);
        }
        
        public GENLSYS.MES.DataContracts.tsecrole GetSingleRole(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetSingleRole(contextInfo, lstParameters);
        }
        
        public void DoInsertRole(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.tsecrole role, GENLSYS.MES.DataContracts.tsecrolefunction[] lstRoleFunctions, GENLSYS.MES.DataContracts.tsecrolestep[] lstRoleSteps, GENLSYS.MES.DataContracts.tsecroleeqpgroup[] lstRoleEqpGroups) {
            base.Channel.DoInsertRole(contextInfo, role, lstRoleFunctions, lstRoleSteps, lstRoleEqpGroups);
        }
        
        public void DoUpdateRole(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.tsecrole role, GENLSYS.MES.DataContracts.tsecrolefunction[] lstRoleFunctions, GENLSYS.MES.DataContracts.tsecrolestep[] lstRoleSteps, GENLSYS.MES.DataContracts.tsecroleeqpgroup[] lstRoleEqpGroups) {
            base.Channel.DoUpdateRole(contextInfo, role, lstRoleFunctions, lstRoleSteps, lstRoleEqpGroups);
        }
        
        public void DoDeleteRole(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            base.Channel.DoDeleteRole(contextInfo, lstParameters);
        }
        
        public System.Data.DataSet GetRoleFunctionRecords(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetRoleFunctionRecords(contextInfo, lstParameters);
        }
        
        public System.Data.DataSet GetRoleFunctionRecordsByRoleId(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string roleid) {
            return base.Channel.GetRoleFunctionRecordsByRoleId(contextInfo, roleid);
        }
        
        public System.Data.DataSet GetFunctionsByUserId(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string roleid) {
            return base.Channel.GetFunctionsByUserId(contextInfo, roleid);
        }
        
        public GENLSYS.MES.DataContracts.tsecrolestep[] GetRoleStepList(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetRoleStepList(contextInfo, lstParameters);
        }
        
        public System.Data.DataSet GetStepsByUserId(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string userid) {
            return base.Channel.GetStepsByUserId(contextInfo, userid);
        }
        
        public System.Data.DataSet GetRoleEqpGroupRecords(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetRoleEqpGroupRecords(contextInfo, lstParameters);
        }
        
        public System.Data.DataSet GetRoleEqpGroupRecordsByRoleId(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string roleid) {
            return base.Channel.GetRoleEqpGroupRecordsByRoleId(contextInfo, roleid);
        }
        
        public GENLSYS.MES.DataContracts.tsecuserrole[] GetUserRoleList(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetUserRoleList(contextInfo, lstParameters);
        }
        
        public System.Data.DataSet GetUserRoleRecords(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetUserRoleRecords(contextInfo, lstParameters);
        }
        
        public GENLSYS.MES.DataContracts.tsecfunctions[] GetFunctionsList(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetFunctionsList(contextInfo, lstParameters);
        }
        
        public System.Data.DataSet GetFunctionsRecords(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetFunctionsRecords(contextInfo, lstParameters);
        }
        
        public GENLSYS.MES.DataContracts.tsecfunctions GetSingleFunctions(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetSingleFunctions(contextInfo, lstParameters);
        }
        
        public void DoInsertFunctions(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.tsecfunctions functions) {
            base.Channel.DoInsertFunctions(contextInfo, functions);
        }
        
        public void DoUpdateFunctions(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.tsecfunctions functions) {
            base.Channel.DoUpdateFunctions(contextInfo, functions);
        }
        
        public void DoDeleteFunctions(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            base.Channel.DoDeleteFunctions(contextInfo, lstParameters);
        }
        
        public void Logon(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string userid, string password) {
            base.Channel.Logon(contextInfo, userid, password);
        }
    }
}

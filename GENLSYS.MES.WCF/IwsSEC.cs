using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using System.Data;

namespace GENLSYS.MES.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IwsSecurity" in both code and config file together.
    [ServiceContract]
    public interface IwsSEC
    {
        #region User
        [OperationContract]
        List<tsecuser> GetUserList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetUserRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tsecuser GetSingleUser(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertUser(ContextInfo contextInfo, tsecuser user, List<tsecuserrole> lstUserRole);

        [OperationContract]
        void DoUpdateUser(ContextInfo contextInfo, tsecuser user, List<tsecuserrole> lstUserRole);

        [OperationContract]
        void DoDeleteUser(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Role
        [OperationContract]
        List<tsecrole> GetRoleList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetRoleRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tsecrole GetSingleRole(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertRole(ContextInfo contextInfo, tsecrole role, List<tsecrolefunction> lstRoleFunctions, List<tsecrolestep> lstRoleSteps, List<tsecroleeqpgroup> lstRoleEqpGroups);

        [OperationContract]
        void DoUpdateRole(ContextInfo contextInfo, tsecrole role, List<tsecrolefunction> lstRoleFunctions, List<tsecrolestep> lstRoleSteps, List<tsecroleeqpgroup> lstRoleEqpGroups);

        [OperationContract]
        void DoDeleteRole(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Role Function
        [OperationContract]
        DataSet GetRoleFunctionRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetRoleFunctionRecordsByRoleId(ContextInfo contextInfo, string roleid);

        [OperationContract]
        DataSet GetFunctionsByUserId(ContextInfo contextInfo, string roleid);
        #endregion

        #region Role Step
        [OperationContract]
        List<tsecrolestep> GetRoleStepList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetStepsByUserId(ContextInfo contextInfo, string userid);
        #endregion

        #region Role EqpGroup
        [OperationContract]
        DataSet GetRoleEqpGroupRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetRoleEqpGroupRecordsByRoleId(ContextInfo contextInfo, string roleid);
        #endregion

        #region User Role
        [OperationContract]
        List<tsecuserrole> GetUserRoleList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetUserRoleRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Functions
        [OperationContract]
        List<tsecfunctions> GetFunctionsList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetFunctionsRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tsecfunctions GetSingleFunctions(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertFunctions(ContextInfo contextInfo, tsecfunctions functions);

        [OperationContract]
        void DoUpdateFunctions(ContextInfo contextInfo, tsecfunctions functions);

        [OperationContract]
        void DoDeleteFunctions(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Logon
        [OperationContract]
        void Logon(ContextInfo contextInfo, string userid, string password);

        [OperationContract]
        void Logout(ContextInfo contextInfo, string sessionid);

        [OperationContract]
        void UpdateLogonTime(ContextInfo contextInfo, string sessionid, string userid, string machine, string shift);

        [OperationContract]
        void ChangePassword(ContextInfo contextInfo, string userid, string oldPassword, string newPassword);

        [OperationContract]
        void ValidatePassword(ContextInfo contextInfo, string userid, string password);

        [OperationContract]
        bool ValidateLineAdmin(ContextInfo contextInfo, string userid, string password);
        #endregion

        #region Misc
        [OperationContract]
        DataSet GetAreaByUserId(ContextInfo contextInfo, string userid);
        #endregion
    }
}

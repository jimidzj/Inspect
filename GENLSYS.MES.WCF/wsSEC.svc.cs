using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using GENLSYS.MES.Services.SEC;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using System.ServiceModel.Channels;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wsSecurity" in code, svc and config file together.
    public class wsSEC : IwsSEC
    {
        #region User
        public List<tsecuser> GetUserList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            UserBll bll = new UserBll(contextInfo);
            bll.CallAccessControl();
            List<tsecuser> rs = bll.GetSelectedObjects<tsecuser>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetUserRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            UserBll bll = new UserBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsecuser>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public tsecuser GetSingleUser(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            UserBll bll = new UserBll(contextInfo);
            bll.CallAccessControl();
            tsecuser rs = bll.GetSingleObject<tsecuser>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public void DoInsertUser(ContextInfo contextInfo, tsecuser user, List<tsecuserrole> lstUserRole)
        {
            contextInfo.Action = MES_ActionType.Insert;
            UserBll bll = new UserBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsertUser(user, lstUserRole);
            GC.Collect();
        }
        public void DoUpdateUser(ContextInfo contextInfo, tsecuser user, List<tsecuserrole> lstUserRole)
        {
            contextInfo.Action = MES_ActionType.Update;
            UserBll bll = new UserBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdateUser(user, lstUserRole);
            GC.Collect();
        }

        public void DoDeleteUser(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            UserBll bll = new UserBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tsecuser>(lstParameters);
            GC.Collect();
        }
        #endregion

        #region Role
        public List<tsecrole> GetRoleList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RoleBll bll = new RoleBll(contextInfo);
            bll.CallAccessControl();
            List<tsecrole> rs = bll.GetSelectedObjects<tsecrole>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetRoleRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RoleBll bll = new RoleBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsecrole>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public tsecrole GetSingleRole(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RoleBll bll = new RoleBll(contextInfo);
            bll.CallAccessControl();
            tsecrole rs = bll.GetSingleObject<tsecrole>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public void DoInsertRole(ContextInfo contextInfo, tsecrole role, List<tsecrolefunction> lstRoleFunctions, List<tsecrolestep> lstRoleSteps, List<tsecroleeqpgroup> lstRoleEqpGroups)
        {
            contextInfo.Action = MES_ActionType.Insert ;
            RoleBll bll = new RoleBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert(role, lstRoleFunctions, lstRoleSteps,lstRoleEqpGroups);
            GC.Collect();
        }
        public void DoUpdateRole(ContextInfo contextInfo, tsecrole role, List<tsecrolefunction> lstRoleFunctions, List<tsecrolestep> lstRoleSteps, List<tsecroleeqpgroup> lstRoleEqpGroups)
        {
            contextInfo.Action = MES_ActionType.Update;
            RoleBll bll = new RoleBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate(role, lstRoleFunctions, lstRoleSteps,lstRoleEqpGroups);
            GC.Collect();
        }

        public void DoDeleteRole(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            RoleBll bll = new RoleBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete(lstParameters);
            GC.Collect();
        }
        #endregion

        #region Role Function
        public DataSet GetRoleFunctionRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RoleFunctionBll bll = new RoleFunctionBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsecrolefunction>(lstParameters);
            GC.Collect();
            return rs; 
        }
        public DataSet GetRoleFunctionRecordsByRoleId(ContextInfo contextInfo, string roleid)
        {
            contextInfo.Action = MES_ActionType.Query;
            RoleFunctionBll bll = new RoleFunctionBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetRoleFunctionRecordsByRoleId(roleid);
            GC.Collect();
            return rs; 
        }

        public DataSet GetFunctionsByUserId(ContextInfo contextInfo, string userid)
        {
            contextInfo.Action = MES_ActionType.Query;
            RoleFunctionBll bll = new RoleFunctionBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetFunctionsByUserId(userid);
            GC.Collect();
            return rs; 
        }
        #endregion

        #region Role Step
        public List<tsecrolestep> GetRoleStepList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RoleStepBll bll = new RoleStepBll(contextInfo);
            bll.CallAccessControl();
            List<tsecrolestep> rs = bll.GetSelectedObjects<tsecrolestep>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetStepsByUserId(ContextInfo contextInfo, string userid)
        {
            contextInfo.Action = MES_ActionType.Query;
            RoleStepBll bll = new RoleStepBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetStepsByUserId(userid);
            GC.Collect();
            return rs; 
        }
        #endregion

        #region Role EqpGroup
        public DataSet GetRoleEqpGroupRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            RoleEqpGroupBll bll = new RoleEqpGroupBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsecrolefunction>(lstParameters);
            GC.Collect();
            return rs; 
        }
        public DataSet GetRoleEqpGroupRecordsByRoleId(ContextInfo contextInfo, string roleid)
        {
            contextInfo.Action = MES_ActionType.Query;
            RoleEqpGroupBll bll = new RoleEqpGroupBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetRoleEqpGroupRecordsByRoleId(roleid);
            GC.Collect();
            return rs; 
        }

        #endregion

        #region User Role
        public List<tsecuserrole> GetUserRoleList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            UserRoleBll bll = new UserRoleBll(contextInfo);
            bll.CallAccessControl();
            List<tsecuserrole> rs = bll.GetSelectedObjects<tsecuserrole>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetUserRoleRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            UserRoleBll bll = new UserRoleBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsecuserrole>(lstParameters);
            GC.Collect();
            return rs; 
        }
        #endregion

        #region Functions
        public List<tsecfunctions> GetFunctionsList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            FunctionsBll bll = new FunctionsBll(contextInfo);
            bll.CallAccessControl();
            List<tsecfunctions> rs = bll.GetSelectedObjects<tsecfunctions>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetFunctionsRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            FunctionsBll bll = new FunctionsBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsecfunctions>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public tsecfunctions GetSingleFunctions(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            FunctionsBll bll = new FunctionsBll(contextInfo);
            bll.CallAccessControl();
            tsecfunctions rs = bll.GetSingleObject<tsecfunctions>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public void DoInsertFunctions(ContextInfo contextInfo, tsecfunctions functions)
        {
            contextInfo.Action = MES_ActionType.Insert ;
            FunctionsBll bll = new FunctionsBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert<tsecfunctions>(functions);
            GC.Collect();
        }
        public void DoUpdateFunctions(ContextInfo contextInfo, tsecfunctions functions)
        {
            contextInfo.Action = MES_ActionType.Update;
            FunctionsBll bll = new FunctionsBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate<tsecfunctions>(functions);
            GC.Collect();
        }

        public void DoDeleteFunctions(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            FunctionsBll bll = new FunctionsBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tsecfunctions>(lstParameters);
            GC.Collect();
        }
        #endregion

        #region Logon
        public void Logon(ContextInfo contextInfo, string userid, string password)
        {
            contextInfo.Action = MES_ActionType.Update;
            LogonBll bll = new LogonBll(contextInfo);
            //不需要access control
            //bll.CallAccessControl();
            bll.Logon(userid, password);
            GC.Collect();
        }

        public void Logout(ContextInfo contextInfo, string sessionid)
        {
            contextInfo.Action = MES_ActionType.Update;
            LogonBll bll = new LogonBll(contextInfo);
            //不需要access control
            //bll.CallAccessControl();
            bll.Logout(sessionid);
            GC.Collect();
        }

        public void UpdateLogonTime(ContextInfo contextInfo, string sessionid, string userid, string machine, string shift)
        {
            contextInfo.Action = MES_ActionType.Update;
            LogonBll bll = new LogonBll(contextInfo);
            //不需要access control
            //bll.CallAccessControl();
            OperationContext context = OperationContext.Current;
            MessageProperties messageProperties = context.IncomingMessageProperties; 
            RemoteEndpointMessageProperty endpointProperty = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            AccessController control = new AccessController(contextInfo);

            //control.CallIPAddressControl(endpointProperty.Address.ToString());

            bll.UpdateLogonTime(sessionid, userid, machine, endpointProperty.Address.ToString(), shift);
            GC.Collect();
        }

        public void ChangePassword(ContextInfo contextInfo, string userid, string oldPassword, string newPassword)
        {
            contextInfo.Action = MES_ActionType.Update;
            LogonBll bll = new LogonBll(contextInfo);
            bll.CallAccessControl();
            bll.ChangePassword(userid, oldPassword, newPassword);
            GC.Collect();
        }

        public void ValidatePassword(ContextInfo contextInfo, string userid, string password)
        {
            contextInfo.Action = MES_ActionType.Query;
            LogonBll bll = new LogonBll(contextInfo);
            bll.CallAccessControl();
            bll.ValidatePassword(userid, password);
            GC.Collect();
        }

        public bool ValidateLineAdmin(ContextInfo contextInfo, string userid, string password)
        {
            contextInfo.Action = MES_ActionType.Query;
            LogonBll bll = new LogonBll(contextInfo);
            bll.CallAccessControl();
            return bll.ValidateLineAdmin(userid, password);
            GC.Collect();
        }
        #endregion

        #region Misc
        public DataSet GetAreaByUserId(ContextInfo contextInfo, string userid)
        {
            contextInfo.Action = MES_ActionType.Query;
            RoleStepBll bll = new RoleStepBll(contextInfo);
            bll.CallAccessControl();
            DataSet ds = bll.GetAreaByUserId(userid);
            GC.Collect();
            return ds; 
        }
        #endregion
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GENLSYS.MES.Win.wsPAD {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wsPAD.IwsPAD")]
    public interface IwsPAD {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/GetFuncByUser", ReplyAction="http://tempuri.org/IwsPAD/GetFuncByUserResponse")]
        string GetFuncByUser(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/GetPOListByStep", ReplyAction="http://tempuri.org/IwsPAD/GetPOListByStepResponse")]
        System.Data.DataSet GetPOListByStep(string funcid, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/GetColorListByPO", ReplyAction="http://tempuri.org/IwsPAD/GetColorListByPOResponse")]
        string[] GetColorListByPO(string po, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/GetTypeListByPO", ReplyAction="http://tempuri.org/IwsPAD/GetTypeListByPOResponse")]
        string[] GetTypeListByPO(string po, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/OpenBoxCheckGroup", ReplyAction="http://tempuri.org/IwsPAD/OpenBoxCheckGroupResponse")]
        string OpenBoxCheckGroup(System.Data.DataTable dt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/OpenBoxSaveCarton", ReplyAction="http://tempuri.org/IwsPAD/OpenBoxSaveCartonResponse")]
        bool OpenBoxSaveCarton(System.Data.DataTable dt, string trayID, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/OpenBoxUpdateCarton", ReplyAction="http://tempuri.org/IwsPAD/OpenBoxUpdateCartonResponse")]
        void OpenBoxUpdateCarton(System.Data.DataTable dt, string trayID, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string customer, string cartonno, string poid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/lineWarehouseSave", ReplyAction="http://tempuri.org/IwsPAD/lineWarehouseSaveResponse")]
        bool lineWarehouseSave(System.Data.DataTable dt, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/DeleteBox", ReplyAction="http://tempuri.org/IwsPAD/DeleteBoxResponse")]
        bool DeleteBox(string customer, string cartonno, string poid, string user, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/isBoxing", ReplyAction="http://tempuri.org/IwsPAD/isBoxingResponse")]
        bool isBoxing(string customer, string poid, string cartonno, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/GetMixBox", ReplyAction="http://tempuri.org/IwsPAD/GetMixBoxResponse")]
        System.Data.DataSet GetMixBox(string customer, string poid, string cartonno, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/GetOpenBox", ReplyAction="http://tempuri.org/IwsPAD/GetOpenBoxResponse")]
        System.Data.DataSet GetOpenBox(string customer, string poid, string cartonno, string action, string currStep, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/PackBoxSaveCarton", ReplyAction="http://tempuri.org/IwsPAD/PackBoxSaveCartonResponse")]
        bool PackBoxSaveCarton(System.Data.DataTable dt, string trayID, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/PackBoxCheckGroup", ReplyAction="http://tempuri.org/IwsPAD/PackBoxCheckGroupResponse")]
        string PackBoxCheckGroup(System.Data.DataTable dt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/isShipped", ReplyAction="http://tempuri.org/IwsPAD/isShippedResponse")]
        bool isShipped(string customer, string poid, string cartonno, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/MoveBoxCheckGroup", ReplyAction="http://tempuri.org/IwsPAD/MoveBoxCheckGroupResponse")]
        string MoveBoxCheckGroup(System.Data.DataTable dt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/MoveBoxSaveCarton", ReplyAction="http://tempuri.org/IwsPAD/MoveBoxSaveCartonResponse")]
        bool MoveBoxSaveCarton(System.Data.DataTable dt, string trayID, string workgroup, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/getWIPByPO", ReplyAction="http://tempuri.org/IwsPAD/getWIPByPOResponse")]
        int getWIPByPO(string customerid, string custorderno, string styleno, string color, string size, string workgroup, string action, string currStep, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/GetSizeListByPO", ReplyAction="http://tempuri.org/IwsPAD/GetSizeListByPOResponse")]
        string[] GetSizeListByPO(string po, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/getLineWarehouse", ReplyAction="http://tempuri.org/IwsPAD/getLineWarehouseResponse")]
        System.Data.DataSet getLineWarehouse(string customer, string poid, string cartonno, string workgroup, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/GetCancelableCarton", ReplyAction="http://tempuri.org/IwsPAD/GetCancelableCartonResponse")]
        System.Data.DataSet GetCancelableCarton(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/CancelPack", ReplyAction="http://tempuri.org/IwsPAD/CancelPackResponse")]
        bool CancelPack(string customer, string cartonno, string poid, string user, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/CancelMove", ReplyAction="http://tempuri.org/IwsPAD/CancelMoveResponse")]
        bool CancelMove(string customer, string cartonno, string poid, string user, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IwsPAD/CancelOpen", ReplyAction="http://tempuri.org/IwsPAD/CancelOpenResponse")]
        bool CancelOpen(string customer, string cartonno, string poid, string user, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IwsPADChannel : GENLSYS.MES.Win.wsPAD.IwsPAD, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IwsPADClient : System.ServiceModel.ClientBase<GENLSYS.MES.Win.wsPAD.IwsPAD>, GENLSYS.MES.Win.wsPAD.IwsPAD {
        
        public IwsPADClient() {
        }
        
        public IwsPADClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IwsPADClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IwsPADClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IwsPADClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetFuncByUser(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.GetFuncByUser(contextInfo);
        }
        
        public System.Data.DataSet GetPOListByStep(string funcid, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetPOListByStep(funcid, contextInfo, lstParameters);
        }
        
        public string[] GetColorListByPO(string po, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.GetColorListByPO(po, contextInfo);
        }
        
        public string[] GetTypeListByPO(string po, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.GetTypeListByPO(po, contextInfo);
        }
        
        public string OpenBoxCheckGroup(System.Data.DataTable dt) {
            return base.Channel.OpenBoxCheckGroup(dt);
        }
        
        public bool OpenBoxSaveCarton(System.Data.DataTable dt, string trayID, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.OpenBoxSaveCarton(dt, trayID, contextInfo);
        }
        
        public void OpenBoxUpdateCarton(System.Data.DataTable dt, string trayID, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, string customer, string cartonno, string poid) {
            base.Channel.OpenBoxUpdateCarton(dt, trayID, contextInfo, customer, cartonno, poid);
        }
        
        public bool lineWarehouseSave(System.Data.DataTable dt, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.lineWarehouseSave(dt, contextInfo);
        }
        
        public bool DeleteBox(string customer, string cartonno, string poid, string user, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.DeleteBox(customer, cartonno, poid, user, contextInfo);
        }
        
        public bool isBoxing(string customer, string poid, string cartonno, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.isBoxing(customer, poid, cartonno, contextInfo);
        }
        
        public System.Data.DataSet GetMixBox(string customer, string poid, string cartonno, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.GetMixBox(customer, poid, cartonno, contextInfo);
        }
        
        public System.Data.DataSet GetOpenBox(string customer, string poid, string cartonno, string action, string currStep, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.GetOpenBox(customer, poid, cartonno, action, currStep, contextInfo);
        }
        
        public bool PackBoxSaveCarton(System.Data.DataTable dt, string trayID, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.PackBoxSaveCarton(dt, trayID, contextInfo);
        }
        
        public string PackBoxCheckGroup(System.Data.DataTable dt) {
            return base.Channel.PackBoxCheckGroup(dt);
        }
        
        public bool isShipped(string customer, string poid, string cartonno, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.isShipped(customer, poid, cartonno, contextInfo);
        }
        
        public string MoveBoxCheckGroup(System.Data.DataTable dt) {
            return base.Channel.MoveBoxCheckGroup(dt);
        }
        
        public bool MoveBoxSaveCarton(System.Data.DataTable dt, string trayID, string workgroup, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.MoveBoxSaveCarton(dt, trayID, workgroup, contextInfo);
        }
        
        public int getWIPByPO(string customerid, string custorderno, string styleno, string color, string size, string workgroup, string action, string currStep, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.getWIPByPO(customerid, custorderno, styleno, color, size, workgroup, action, currStep, contextInfo);
        }
        
        public string[] GetSizeListByPO(string po, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.GetSizeListByPO(po, contextInfo);
        }
        
        public System.Data.DataSet getLineWarehouse(string customer, string poid, string cartonno, string workgroup, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.getLineWarehouse(customer, poid, cartonno, workgroup, contextInfo);
        }
        
        public System.Data.DataSet GetCancelableCarton(GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo, GENLSYS.MES.DataContracts.Common.MESParameterInfo[] lstParameters) {
            return base.Channel.GetCancelableCarton(contextInfo, lstParameters);
        }
        
        public bool CancelPack(string customer, string cartonno, string poid, string user, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.CancelPack(customer, cartonno, poid, user, contextInfo);
        }
        
        public bool CancelMove(string customer, string cartonno, string poid, string user, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.CancelMove(customer, cartonno, poid, user, contextInfo);
        }
        
        public bool CancelOpen(string customer, string cartonno, string poid, string user, GENLSYS.MES.DataContracts.Common.ContextInfo contextInfo) {
            return base.Channel.CancelOpen(customer, cartonno, poid, user, contextInfo);
        }
    }
}

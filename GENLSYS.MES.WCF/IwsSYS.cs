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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IwsSystem" in both code and config file together.
    [ServiceContract]
    public interface IwsSYS
    {
        #region Public
        //[OperationContract]
        //T GetSingleObject<T>(List<MESParameterInfo> lstParameters) where T : class;

        //[OperationContract]
        //List<T> GetSelectedObjects<T>(List<MESParameterInfo> lstParameters) where T : class;

        //[OperationContract]
        //DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters) where T : class;

        [OperationContract]
        string GetServerDateTime();

        [OperationContract]
        List<string> GetServerIPAddress();
        #endregion

        #region Attribute
        [OperationContract]
        List<tsysattributevalue> GetAttributeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetAttributeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tsysattributevalue GetSingleAttribute(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DeleteMultiAttribute(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DeleteSingleAttribute(ContextInfo contextInfo, tsysattributevalue obj);

        [OperationContract]
        void InsertMultiAttribute(ContextInfo contextInfo, List<tsysattributevalue> lstAttributes);

        [OperationContract]
        void InsertSingleAttribute(ContextInfo contextInfo, tsysattributevalue objAttribute);

        [OperationContract]
        List<tsysattrtplate> GetAttributeTemplateList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetAttributeTemplateRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tsysattrtplate GetSingleAttributeTemplate(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        decimal GetMaxAttributeId(ContextInfo contextInfo);

        [OperationContract]
        void InsertAttributeTemplate(ContextInfo contextInfo, tsysattrtplate template, List<tsysattrtplatedtl> lstAttribute);

        [OperationContract]
        void UpdateAttributeTemplate(ContextInfo contextInfo, tsysattrtplate template, List<tsysattrtplatedtl> lstAttribute);

        [OperationContract]
        void DeleteAttributeTemplate(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        decimal GetMaxSeqno(ContextInfo contextInfo, string usedby);

        [OperationContract]
        List<tsysattrtplatedtl> GetAttributeTemplateDetailList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetAttributeTemplateDetailRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Static Value
        [OperationContract]
        List<tsysstaticvalue> GetStaticValueList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetStaticValueRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tsysstaticvalue GetSingleStaticValue(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertStaticValue(ContextInfo contextInfo, tsysstaticvalue staticValue);

        [OperationContract]
        void DoUpdateStaticValue(ContextInfo contextInfo, tsysstaticvalue staticValue);

        [OperationContract]
        void DoDeleteStaticValue(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region MenuConfig
        [OperationContract]
        List<tsysmenuconfig> GetMenuConfigList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        List<tsysmenuconfig> GetTopMenuList(ContextInfo contextInfo, string menutype);
        #endregion

        #region Bill Code Rule
        [OperationContract]
        List<tsysbillcoderule> GetBillCodeRuleList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetBillCodeRuleRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tsysbillcoderule GetSingleBillCodeRule(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertBillCodeRule(ContextInfo contextInfo, tsysbillcoderule bcr, List<tsysbillcode> lstBillCode);

        [OperationContract]
        void DoUpdateBillCodeRule(ContextInfo contextInfo, tsysbillcoderule bcr, List<tsysbillcode> lstBillCode);

        [OperationContract]
        void DoDeleteBillCodeRule(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region Bill Code
        [OperationContract]
        string GetSingleBillNo(ContextInfo contextInfo, string bcrid, string lockRefId,
            string baseValue, List<MESParameterInfo> lstVariablesParameters);

        [OperationContract]
        List<string> GetBatchBillNo(ContextInfo contextInfo, string bcrid, int batchNum, string lockRefId,
            string baseValue, List<MESParameterInfo> lstVariablesParameters);

        [OperationContract]
        List<tsysbillcode> GetBillCodeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetBillCodeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tsysbillcode GetSingleBillCode(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertBillCode(ContextInfo contextInfo, tsysbillcode billCode);

        [OperationContract]
        void DoUpdateBillCode(ContextInfo contextInfo, tsysbillcode billCode);

        [OperationContract]
        void DoDeleteBillCode(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void UnlockBill(ContextInfo contextInfo, string bcrid, string lockRefId);

        [OperationContract]
        void ResetBill(ContextInfo contextInfo, string bcrid, string lockRefId);
        #endregion

        #region Session
        [OperationContract]
        DataSet GetSessionRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tsyssession GetSingleSession(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoUpdateSession(ContextInfo contextInfo, tsyssession session);

        [OperationContract]
        void DoUpdateLock(ContextInfo contextInfo, List<string> lstSessionId, string flag);

        [OperationContract]
        void DoUpdateKill(ContextInfo contextInfo, List<string> lstSessionId);
        #endregion

        #region SessionHis
        [OperationContract]
        DataSet GetSessionHisRecords(ContextInfo contextInfo, string userid, string machine, string ipaddress, string shift, DateTime fromlogontime, DateTime tologontime);

        [OperationContract]
        void DoSessionMultiDelete(ContextInfo contextInfo, List<string> lstSessionId);
        #endregion

        #region System Config
        [OperationContract]
        List<tsyssystemconfig> GetAllSystemConfigValue();

        [OperationContract]
        List<tsyssystemconfig> GetSystemConfigList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetSystemConfigRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        tsyssystemconfig GetSingleSystemConfig(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        void DoInsertSystemConfig(ContextInfo contextInfo, tsyssystemconfig systemConfig);

        [OperationContract]
        void DoUpdateSystemConfig(ContextInfo contextInfo, tsyssystemconfig systemConfig);

        [OperationContract]
        void DoDeleteSystemConfig(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion

        #region AppInfo
        [OperationContract]
        List<tsysappinfo> GetAppInfoList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        [OperationContract]
        DataSet GetAppInfoRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        #endregion
    }
}

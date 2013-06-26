using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Services.SYS;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;
using System.Web.Services.Protocols;
using System.Xml;
using System.Net;

namespace GENLSYS.MES.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wsSystem" in code, svc and config file together.
    public class wsSYS : IwsSYS
    {
        #region Public
        //public T GetSingleObject<T>(List<MESParameterInfo> lstParameters) where T:class
        //{
        //    BaseBll bll = new BaseBll();
        //    return bll.GetSingleObject<T>(lstParameters);
        //}

        //public List<T> GetSelectedObjects<T>(List<MESParameterInfo> lstParameters) where T : class
        //{
        //    BaseBll bll = new BaseBll();
        //    return bll.GetSelectedObjects<T>(lstParameters);
        //}

        //public DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters) where T : class
        //{
        //    BaseBll bll = new BaseBll();
        //    return bll.GetSelectedRecords<T>(lstParameters);
        //}
        public string GetServerDateTime()
        {
            return UtilDatetime.FormatDate1(DateTime.Now);
        }

        public List<string> GetServerIPAddress()
        {
            string sHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(sHostName);
            IPAddress[] arrIPAddress = ipEntry.AddressList;
            List<string> lstIPAddress = new List<string>();

            for (int i = 0; i < arrIPAddress.Length; i++) 
            {
                lstIPAddress.Add(arrIPAddress[i].ToString());
            }

            return lstIPAddress;
        }
        #endregion

        #region Attribute Value
        public List<tsysattributevalue> GetAttributeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            AttributeValueBll bll = new AttributeValueBll(contextInfo);
            bll.CallAccessControl();
            List<tsysattributevalue> rs = bll.GetSelectedObjects<tsysattributevalue>(lstParameters);
            GC.Collect();
            return rs;
            
        }

        public DataSet GetAttributeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            AttributeValueBll bll = new AttributeValueBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsysattributevalue>(lstParameters);
            GC.Collect();
            return rs;
        }

        public tsysattributevalue GetSingleAttribute(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            AttributeValueBll bll = new AttributeValueBll(contextInfo);
            bll.CallAccessControl();
            tsysattributevalue rs = bll.GetSingleObject<tsysattributevalue>(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DeleteMultiAttribute(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            AttributeValueBll bll = new AttributeValueBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tsysattributevalue>(lstParameters);
            GC.Collect();
            
        }

        public void DeleteSingleAttribute(ContextInfo contextInfo, tsysattributevalue obj)
        {
            contextInfo.Action = MES_ActionType.Delete;
            AttributeValueBll bll = new AttributeValueBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tsysattributevalue>(obj);
            GC.Collect();
        }

        public void InsertMultiAttribute(ContextInfo contextInfo, List<tsysattributevalue> lstAttributes)
        {
            contextInfo.Action = MES_ActionType.Insert;
            AttributeValueBll bll = new AttributeValueBll(contextInfo);
            bll.CallAccessControl();
            bll.DoMultiInsert<tsysattributevalue>(lstAttributes);
            GC.Collect();
        }

        public void InsertSingleAttribute(ContextInfo contextInfo, tsysattributevalue objAttribute)
        {
            contextInfo.Action = MES_ActionType.Insert;
            AttributeValueBll bll = new AttributeValueBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert<tsysattributevalue>(objAttribute);
            GC.Collect();
        }

        public decimal GetMaxAttributeId(ContextInfo contextInfo)
        {
            contextInfo.Action = MES_ActionType.Query;
            AttributeValueBll bll = new AttributeValueBll(contextInfo);
            bll.CallAccessControl();
           decimal rs = bll.GetMaxAttributeId();
            GC.Collect();
            return rs;
        }

       #endregion

        #region Attribute Template
        #region Template Header
        public List<tsysattrtplate> GetAttributeTemplateList(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            AttributeTemplateBll bll = new AttributeTemplateBll(contextInfo);
            bll.CallAccessControl();
            List<tsysattrtplate> rs = bll.GetSelectedObjects<tsysattrtplate>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetAttributeTemplateRecords(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            AttributeTemplateBll bll = new AttributeTemplateBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsysattrtplate>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public tsysattrtplate GetSingleAttributeTemplate(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            AttributeTemplateBll bll = new AttributeTemplateBll(contextInfo);
            bll.CallAccessControl();
            tsysattrtplate rs = bll.GetSingleObject<tsysattrtplate>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public void InsertAttributeTemplate(ContextInfo contextInfo,tsysattrtplate template,List<tsysattrtplatedtl> lstAttribute)
        {
            contextInfo.Action = MES_ActionType.Insert;
            AttributeTemplateBll bll = new AttributeTemplateBll(contextInfo);
            bll.CallAccessControl();
            bll.InsertAttributeTemplate(template, lstAttribute);
            GC.Collect();
             
        }

        public void UpdateAttributeTemplate(ContextInfo contextInfo,tsysattrtplate template,List<tsysattrtplatedtl> lstAttribute)
        {
            contextInfo.Action = MES_ActionType.Update;
            AttributeTemplateBll bll = new AttributeTemplateBll(contextInfo);
            bll.CallAccessControl();
            bll.UpdateAttributeTemplate(template, lstAttribute);
            GC.Collect();
            
        }

        public void DeleteAttributeTemplate(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            AttributeTemplateBll bll = new AttributeTemplateBll(contextInfo);
            bll.CallAccessControl();
            bll.DeleteAttributeTemplate(lstParameters);
            GC.Collect();
            
        }
        #endregion

        #region Template Detail
        public List<tsysattrtplatedtl> GetAttributeTemplateDetailList(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            AttributeTemplateDetailBll bll = new AttributeTemplateDetailBll(contextInfo);
            bll.CallAccessControl();
            List<tsysattrtplatedtl> rs = bll.GetSelectedObjects<tsysattrtplatedtl>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetAttributeTemplateDetailRecords(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            AttributeTemplateDetailBll bll = new AttributeTemplateDetailBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<DataSet>(lstParameters);
            GC.Collect();
            return rs; 
        }
        #endregion

        public decimal GetMaxSeqno(ContextInfo contextInfo,string usedby)
        {
            contextInfo.Action = MES_ActionType.Query;
            AttributeTemplateDetailBll bll = new AttributeTemplateDetailBll(contextInfo);
            bll.CallAccessControl();
            decimal rs = bll.GetMaxSeqno(usedby);
            GC.Collect();
            return rs; 
        }
        #endregion

        #region Static Value
        public List<tsysstaticvalue> GetStaticValueList(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            StaticValueBll bll = new StaticValueBll(contextInfo);
            bll.CallAccessControl();
            List<tsysstaticvalue> rs = bll.GetSelectedObjects<tsysstaticvalue>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public DataSet GetStaticValueRecords(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            StaticValueBll bll = new StaticValueBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsysstaticvalue>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public tsysstaticvalue GetSingleStaticValue(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            StaticValueBll bll = new StaticValueBll(contextInfo);
            bll.CallAccessControl();
            tsysstaticvalue rs = bll.GetSingleObject<tsysstaticvalue>(lstParameters);
            GC.Collect();
            return rs; 
        }

        public void DoInsertStaticValue(ContextInfo contextInfo,tsysstaticvalue staticValue)
        {
            contextInfo.Action = MES_ActionType.Insert;
            StaticValueBll bll = new StaticValueBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert(staticValue);
            GC.Collect();
        }
        public void DoUpdateStaticValue(ContextInfo contextInfo,tsysstaticvalue staticValue)
        {
            contextInfo.Action = MES_ActionType.Update;
            StaticValueBll bll = new StaticValueBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate(staticValue);
            GC.Collect();
        }

        public void DoDeleteStaticValue(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            StaticValueBll bll = new StaticValueBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tsysstaticvalue>(lstParameters);
            GC.Collect();
            
        }
        #endregion

        #region MenuConfig
        public List<tsysmenuconfig> GetMenuConfigList(ContextInfo contextInfo,List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            MenuConfigBll bll = new MenuConfigBll(contextInfo);
            bll.CallAccessControl();
            List<tsysmenuconfig> rs = bll.GetSelectedObjects<tsysmenuconfig>(lstParameters);
            GC.Collect();
            return rs;
        }

        public List<tsysmenuconfig> GetTopMenuList(ContextInfo contextInfo,string menutype)
        {
            contextInfo.Action = MES_ActionType.Query;
            MenuConfigBll bll = new MenuConfigBll(contextInfo);
            bll.CallAccessControl();
            List<tsysmenuconfig> rs = bll.GetTopMenuList(menutype);
            GC.Collect();
            return rs;
        }
        #endregion

        #region Bill Code Rule
        public List<tsysbillcoderule> GetBillCodeRuleList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            BillCodeRuleBll bll = new BillCodeRuleBll(contextInfo);
            bll.CallAccessControl();
             List<tsysbillcoderule>  rs = bll.GetSelectedObjects<tsysbillcoderule>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetBillCodeRuleRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            BillCodeRuleBll bll = new BillCodeRuleBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsysbillcoderule>(lstParameters);
            GC.Collect();
            return rs;
        }

        public tsysbillcoderule GetSingleBillCodeRule(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            BillCodeRuleBll bll = new BillCodeRuleBll(contextInfo);
            bll.CallAccessControl();
            tsysbillcoderule rs = bll.GetSingleObject<tsysbillcoderule>(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DoInsertBillCodeRule(ContextInfo contextInfo, tsysbillcoderule bcr,List<tsysbillcode> lstBillCode)
        {
            contextInfo.Action = MES_ActionType.Insert;
            BillCodeRuleBll bll = new BillCodeRuleBll(contextInfo);
            bll.CallAccessControl();
            bll.InsertBill(bcr, lstBillCode);
            GC.Collect();
             
        }
        public void DoUpdateBillCodeRule(ContextInfo contextInfo, tsysbillcoderule bcr, List<tsysbillcode> lstBillCode)
        {
            contextInfo.Action = MES_ActionType.Update;
            BillCodeRuleBll bll = new BillCodeRuleBll(contextInfo);
            bll.CallAccessControl();
            bll.UpdateBill(bcr, lstBillCode);
            GC.Collect();
             
        }

        public void DoDeleteBillCodeRule(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            BillCodeRuleBll bll = new BillCodeRuleBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete(lstParameters);
            GC.Collect();
            
        }
        #endregion

        #region Bill Code
        
        public string GetSingleBillNo(ContextInfo contextInfo, string bcrid, string lockRefId,
            string baseValue, List<MESParameterInfo> lstVariablesParameters)
        {

            contextInfo.Action = MES_ActionType.Query;
            BillCodeBll bll = new BillCodeBll(contextInfo);
            bll.CallAccessControl();
            string rs = bll.GetSingleBillNo(bcrid, lockRefId, baseValue, lstVariablesParameters);
            GC.Collect();
            return rs;

        }

        public List<string> GetBatchBillNo(ContextInfo contextInfo, string bcrid, int batchNum, string lockRefId, 
            string baseValue,List<MESParameterInfo> lstVariablesParameters)
        {

            contextInfo.Action = MES_ActionType.Query;
            BillCodeBll bll = new BillCodeBll(contextInfo);
            bll.CallAccessControl();
            List<string> rs = bll.GetBillNo(bcrid, batchNum, lockRefId, baseValue, lstVariablesParameters);
            GC.Collect();
            return rs;

        }

        public List<tsysbillcode> GetBillCodeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            BillCodeBll bll = new BillCodeBll(contextInfo);
            bll.CallAccessControl();
            List<tsysbillcode> rs = bll.GetSelectedObjects<tsysbillcode>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetBillCodeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            BillCodeBll bll = new BillCodeBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsysbillcode>(lstParameters);
            GC.Collect();
            return rs;
        }

        public tsysbillcode GetSingleBillCode(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            BillCodeBll bll = new BillCodeBll(contextInfo);
            bll.CallAccessControl();
            tsysbillcode  rs = bll.GetSingleObject<tsysbillcode>(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DoInsertBillCode(ContextInfo contextInfo, tsysbillcode billCode)
        {
            contextInfo.Action = MES_ActionType.Insert;
            BillCodeBll bll = new BillCodeBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert(billCode);
            GC.Collect();
        }
        public void DoUpdateBillCode(ContextInfo contextInfo, tsysbillcode billCode)
        {
            contextInfo.Action = MES_ActionType.Update;
            BillCodeBll bll = new BillCodeBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate(billCode);
            GC.Collect();
        }

        public void DoDeleteBillCode(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            BillCodeBll bll = new BillCodeBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tsysbillcode>(lstParameters);
            GC.Collect();
        }

        public void UnlockBill(ContextInfo contextInfo, string bcrid, string lockRefId)
        {
            contextInfo.Action = MES_ActionType.Delete;
            BillCodeBll bll = new BillCodeBll(contextInfo);
            bll.CallAccessControl();
            bll.UnlockBill(bcrid, lockRefId);
            GC.Collect();
        }

        public void ResetBill(ContextInfo contextInfo, string bcrid, string lockRefId)
        {
            contextInfo.Action = MES_ActionType.Delete;
            BillCodeBll bll = new BillCodeBll(contextInfo);
            bll.CallAccessControl();
            bll.ResetBill(bcrid, lockRefId);
            GC.Collect();
        }
        #endregion

        #region Session
        public DataSet GetSessionRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            SessionBll bll = new SessionBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsyssession>(lstParameters);
            GC.Collect();
            return rs;
        }
        public tsyssession GetSingleSession(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            SessionBll bll = new SessionBll(contextInfo);
            bll.CallAccessControl();
            tsyssession rs = bll.GetSingleObject<tsyssession>(lstParameters);
            GC.Collect();
            return rs;
        }
        public void DoUpdateSession(ContextInfo contextInfo, tsyssession session)
        {
            contextInfo.Action = MES_ActionType.Update;
            SessionBll bll = new SessionBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate<tsyssession>(session);
            GC.Collect();
             
        }
        public void DoUpdateLock(ContextInfo contextInfo, List<string> lstSessionId, string flag)
        {
            contextInfo.Action = MES_ActionType.Update;
            SessionBll bll = new SessionBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdateLock(lstSessionId, flag);
            GC.Collect();
            
        }

        public void DoUpdateKill(ContextInfo contextInfo, List<string> lstSessionId)
        {
            contextInfo.Action = MES_ActionType.Update;
            SessionBll bll = new SessionBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdateKill(lstSessionId);
            GC.Collect();
             
        }
        #endregion

        #region Session History
        public DataSet GetSessionHisRecords(ContextInfo contextInfo, string userid, string machine, string ipaddress, string shift, DateTime fromlogontime, DateTime tologontime)
        {
            contextInfo.Action = MES_ActionType.Query;
            SessionHisBll bll = new SessionHisBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords(userid,machine,ipaddress,shift,fromlogontime,tologontime);
            GC.Collect();
            return rs;
        }

        public void DoSessionMultiDelete(ContextInfo contextInfo, List<string> lstSessionId)
        {
            contextInfo.Action = MES_ActionType.Update;
            SessionHisBll bll = new SessionHisBll(contextInfo);
            bll.CallAccessControl();
            bll.DoMultiDelete(lstSessionId);
            GC.Collect();
             
        }
        #endregion

        #region System Config
        public List<tsyssystemconfig> GetAllSystemConfigValue()
        {
            SystemConfigBll bll = new SystemConfigBll();
            List<tsyssystemconfig> rs = bll.GetAllSystemConfigValue();
            GC.Collect();
            return rs;
        }

        public List<tsyssystemconfig> GetSystemConfigList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            SystemConfigBll bll = new SystemConfigBll(contextInfo);
            bll.CallAccessControl();
            List<tsyssystemconfig>  rs =  bll.GetSelectedObjects<tsyssystemconfig>(lstParameters);
            GC.Collect();
            return rs;
        }

        public DataSet GetSystemConfigRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            SystemConfigBll bll = new SystemConfigBll(contextInfo);
            bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsyssystemconfig>(lstParameters);
            GC.Collect();
            return rs;
        }

        public tsyssystemconfig GetSingleSystemConfig(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            SystemConfigBll bll = new SystemConfigBll(contextInfo);
            bll.CallAccessControl();
            tsyssystemconfig rs = bll.GetSingleObject<tsyssystemconfig>(lstParameters);
            GC.Collect();
            return rs;
        }

        public void DoInsertSystemConfig(ContextInfo contextInfo, tsyssystemconfig systemConfig)
        {
            contextInfo.Action = MES_ActionType.Insert;
            SystemConfigBll bll = new SystemConfigBll(contextInfo);
            bll.CallAccessControl();
            bll.DoInsert(systemConfig);

            Parameter.CURRENT_SYSTEM_CONFIG = null;

            GC.Collect();
    
        }

        public void DoUpdateSystemConfig(ContextInfo contextInfo, tsyssystemconfig systemConfig)
        {
            contextInfo.Action = MES_ActionType.Update;
            SystemConfigBll bll = new SystemConfigBll(contextInfo);
            bll.CallAccessControl();
            bll.DoUpdate(systemConfig);

            Parameter.CURRENT_SYSTEM_CONFIG = null;

            GC.Collect();
 
        }

        public void DoDeleteSystemConfig(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Delete;
            SystemConfigBll bll = new SystemConfigBll(contextInfo);
            bll.CallAccessControl();
            bll.DoDelete<tsyssystemconfig>(lstParameters);

            Parameter.CURRENT_SYSTEM_CONFIG = null;

            GC.Collect();
         }
        #endregion

        #region AppInfo
        public List<tsysappinfo> GetAppInfoList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            AppInfoBll bll = new AppInfoBll(contextInfo);
            //不需要Access Control
            //bll.CallAccessControl();
            List<tsysappinfo> rs = bll.GetSelectedObjects<tsysappinfo>(lstParameters);
            GC.Collect();
            return rs;

        }

        public DataSet GetAppInfoRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            contextInfo.Action = MES_ActionType.Query;
            AppInfoBll bll = new AppInfoBll(contextInfo);
            //不需要Access Control
            //bll.CallAccessControl();
            DataSet rs = bll.GetSelectedRecords<tsysappinfo>(lstParameters);
            GC.Collect();
            return rs;
        }
        #endregion
    }
}

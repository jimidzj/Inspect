using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;

namespace GENLSYS.MES.Win.Common.Classes
{
    public class BaseWCF
    {
        public ContextInfo CurrentContextInfo { get; set; }

        #region MISC
        public void CloseWCF(object client)
        {
 
            if (client is wsMDL.IwsMDLClient)
            {
                if ((client as wsMDL.IwsMDLClient).State == System.ServiceModel.CommunicationState.Opened)
                {
                    (client as wsMDL.IwsMDLClient).Close();
                }
            }

            if (client is wsSEC.IwsSECClient)
            {
                if ((client as wsSEC.IwsSECClient).State == System.ServiceModel.CommunicationState.Opened)
                {
                    (client as wsSEC.IwsSECClient).Close();
                }
            }

            if (client is wsSYS.IwsSYSClient)
            {
                if ((client as wsSYS.IwsSYSClient).State == System.ServiceModel.CommunicationState.Opened)
                {
                    (client as wsSYS.IwsSYSClient).Close();
                }
            }

       }
        #endregion
        
        #region MDL
        #endregion

        #region SYS
        #region Bill
        public string GetBillNo(string bcrid)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            string result = string.Empty;
            try
            {
                result = client.GetSingleBillNo(CurrentContextInfo, bcrid, string.Empty, string.Empty,
                    new List<MESParameterInfo>() { }.ToArray<MESParameterInfo>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWCF(client);
            }

            return result;
        }

        public string GetBillNo(string bcrid, string lockRefId)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            string result = string.Empty;
            try
            {
                result = client.GetSingleBillNo(CurrentContextInfo, bcrid, lockRefId, string.Empty,
                    new List<MESParameterInfo>() { }.ToArray<MESParameterInfo>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWCF(client);
            }

            return result;
        }

        public string GetBillNo(string bcrid, string lockRefId, string baseValue, List<MESParameterInfo> lstVariablesParameters)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            string result = string.Empty;
            try
            {
                result = client.GetSingleBillNo(CurrentContextInfo, bcrid, lockRefId, baseValue,
                    lstVariablesParameters.ToArray<MESParameterInfo>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWCF(client);
            }

            return result;
        }

        public List<string> GetBillNoBatch(string bcrid, int batchNum, string lockRefId)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            List<string> lstResult = new List<string>();
            try
            {
                lstResult = client.GetBatchBillNo(CurrentContextInfo, bcrid, batchNum, lockRefId,
                    string.Empty, new List<MESParameterInfo>() { }.ToArray<MESParameterInfo>()).ToList<string>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWCF(client);
            }

            return lstResult;
        }

        public List<string> GetBillNoBatch(string bcrid, int batchNum, string lockRefId, string baseValue,
            List<MESParameterInfo> lstVariablesParameters)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            List<string> lstResult = new List<string>();
            try
            {
                lstResult = client.GetBatchBillNo(CurrentContextInfo, bcrid, batchNum, lockRefId,
                    baseValue, lstVariablesParameters.ToArray<MESParameterInfo>()).ToList<string>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWCF(client);
            }

            return lstResult;
        }

        public void UnlockBill(string bcrid, string lockRefId)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            try
            {
                client.UnlockBill(CurrentContextInfo, bcrid, lockRefId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWCF(client);
            }
        }

        public void ResetBill(string bcrid, string lockRefId)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            try
            {
                client.ResetBill(CurrentContextInfo, bcrid, lockRefId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWCF(client);
            }
        }
        #endregion

        #region Attribute
        public tsysattrtplate GetAttributeTemplateObject(string attributeTemplateId)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                    new MESParameterInfo(){
                        ParamName="attrtplatid",
                        ParamValue=attributeTemplateId,
                        ParamType="string"
                    }
                };

                tsysattrtplate template = client.GetSingleAttributeTemplate(CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                return template;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWCF(client);
            }
        }
        #endregion

        #region System Config & Static Value
        public List<tsyssystemconfig> GetAllSystemConfig()
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();

            List<tsyssystemconfig> lstConfig = new List<tsyssystemconfig>();
            try
            {
                lstConfig = client.GetAllSystemConfigValue().ToList<tsyssystemconfig>();

                return lstConfig;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWCF(client);
            }
        }

        public List<tsysstaticvalue> GetAllStaticValue()
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();

            List<tsysstaticvalue> lstConfig = new List<tsysstaticvalue>();
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "svstatus",
                    ParamValue = "Active",
                    ParamType = "string"
                });
                lstConfig = client.GetStaticValueList(CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tsysstaticvalue>();

                return lstConfig;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWCF(client);
            }
        }
        #endregion

        #endregion

    }
}

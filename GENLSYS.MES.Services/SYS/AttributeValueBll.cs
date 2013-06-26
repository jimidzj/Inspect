using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SYS;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility.Database;

namespace GENLSYS.MES.Services.SYS
{
    public class AttributeValueBll :  BaseBll
    {
        AttributeValueDal localDal = null;
        public AttributeValueBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new AttributeValueDal(dbInstance);
            baseDal = localDal; 
        }

        public AttributeValueBll(ContextInfo contextInfo, DBInstance dbInstance) :
            base(contextInfo)
        {
            localDal = new AttributeValueDal(dbInstance);
            baseDal = localDal;
        }

        public decimal GetMaxAttributeId()
        {
            return localDal.GetMaxAttributeId();
        }
        public string GetAttributeValue(string AttributeID, string AttributeName)
        {
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "attributeid",
                    ParamValue = AttributeID
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "attributename",
                    ParamValue = AttributeName
                });

                tsysattributevalue value = GetSingleObject<tsysattributevalue>(lstParameters);
                if (value != null)
                {
                    return value.attributevalue;
                }
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public void CopyAttribute(string oldAttributeId, string newAttributeId)
        {
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo() { 
                    ParamName="attributeid",
                    ParamValue=oldAttributeId
                });

                List<tsysattributevalue> lstValue = GetSelectedObjects<tsysattributevalue>(lstParameters);

                for (int i = 0; i < lstValue.Count; i++)
                {
                    lstValue[i].attributeid = newAttributeId;
                    lstValue[i].lastmodifiedtime = Function.GetCurrentTime();
                    lstValue[i].lastmodifieduser = CurrentContextInfo.CurrentUser;

                    DoInsert<tsysattributevalue>(lstValue[i]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

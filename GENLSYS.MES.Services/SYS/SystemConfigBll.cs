using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.SYS;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility.Database;

namespace GENLSYS.MES.Services.SYS
{
    public class SystemConfigBll : BaseBll
    {
        SystemConfigDal localDal = null;

        public SystemConfigBll() 
        {
            localDal = new SystemConfigDal(dbInstance);
            baseDal = localDal;
        }

        public SystemConfigBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new SystemConfigDal(dbInstance);
            baseDal = localDal;
        }

        public SystemConfigBll(ContextInfo contextInfo,DBInstance dbInstance) :
            base(contextInfo)
        {
            this.dbInstance = dbInstance;
            localDal = new SystemConfigDal(dbInstance);
            baseDal = localDal;
        }

        public List<tsyssystemconfig> GetAllSystemConfigValue()
        {
            List<tsyssystemconfig> lstConfig = GetSelectedObjects<tsyssystemconfig>(new List<MESParameterInfo>());

            for (int i = 0; i < lstConfig.Count; i++)
            {
                lstConfig[i].configvalue = CheckValue(lstConfig[i].configname, lstConfig[i].configvalue);
            }

            return lstConfig;
        }

        public string GetSystemConfigValue(string systemConfigName)
        {
            if (systemConfigName.Trim() == string.Empty)
                return string.Empty;

            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
            lstParameters.Add(new MESParameterInfo() { 
                ParamName ="configname",
                ParamValue = systemConfigName
            });

            tsyssystemconfig config = GetSingleObject<tsyssystemconfig>(lstParameters);

            if (config == null) return string.Empty;

            return CheckValue(systemConfigName, config.configvalue);
        }

        /// <summary>
        /// check system config value
        /// 1. If value is legal, if illegal, return default value
        /// 2. If value is assigned, if no value assigned, return default value
        /// 3.
        /// </summary>
        /// <param name="systemConfigName"></param>
        /// <param name="value"></param>
        private string CheckValue(string systemConfigName,string value)
        {
            string ret = string.Empty;
            switch (systemConfigName)
            {
                case "SYS_DISBILLNO":
                    if (value == null)
                        ret = MES_Misc.N.ToString();
                    else
                    {
                        if (value.Trim() != MES_Misc.N.ToString() || value.Trim() != MES_Misc.Y.ToString())
                        {
                            ret = MES_Misc.N.ToString();
                        }
                        else
                            ret = value.Trim();
                    }
                    break;
                default:
                    if (value == null)
                        ret = string.Empty;
                    else
                        ret = value.Trim();
                    break;
            }

            return ret;
        }

        public void SetParameter()
        {
        }
    }
}

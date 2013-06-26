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
    public class AttributeTemplateDetailBll : BaseBll
    {
        AttributeTemplateDetailDal localDal = null;
        public AttributeTemplateDetailBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new AttributeTemplateDetailDal(dbInstance);
            baseDal = localDal; 
        }

        public decimal GetMaxSeqno(string usedby)
        {
            return localDal.GetMaxSeqno(usedby);
        }

        public List<tsysattrtplatedtl> GetAttributesByTemplate(string attributeTempalteId,
            MES_AttributeTemplate_UsedBy usedBy)
        {
            List<tsysattrtplatedtl> lstResult = new List<tsysattrtplatedtl>();

            if (attributeTempalteId == null) attributeTempalteId = string.Empty;

            if (attributeTempalteId.Trim() == "*")
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>();
                lstParams.Add(new MESParameterInfo()
                {
                    ParamName = "usedby",
                    ParamValue = usedBy.ToString(),
                    ParamType = "string"
                });

                lstParams.Add(new MESParameterInfo()
                {
                    ParamName = "isdefault",
                    ParamValue = MES_Misc.Y.ToString(),
                    ParamType = "string"
                });

                tsysattrtplate template = GetSingleObject<tsysattrtplate>(lstParams);

                if (template != null)
                {
                    attributeTempalteId = template.attrtplatid;
                }
                else
                {
                    attributeTempalteId = string.Empty;
                }

            }

            if (attributeTempalteId.Trim() != string.Empty)
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "attrtplatid",
                    ParamValue = attributeTempalteId,
                    ParamType = "string"
                });

                lstResult = GetSelectedObjects<tsysattrtplatedtl>(lstParameters);
            }

            return lstResult;
        }
    }
}

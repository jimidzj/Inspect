using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using GENLSYS.MES.DataContracts.Common;
using System.Data;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class RepairFailBll : BaseBll
    {
        private RepairFailDal localDal = null;

        public RepairFailBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new RepairFailDal(dbInstance);
            baseDal = localDal;
        }

        public int GetLeftRepairSuccessQty(string custorderno, string styleno, string color, string size,string step)
        {
            return localDal.GetLeftRepairSuccessQty(custorderno,styleno,color,size,step);
        }

        public DataSet GetRepairInfoForInspectRpt(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetRepairInfoForInspectRpt(lstParameters);
        }
        public DataSet GetRepairFailForInspectRpt(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetRepairFailForInspectRpt(lstParameters);
        }
        public DataSet GetShippedForInspectRpt(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetShippedForInspectRpt(lstParameters);
        }

        public DataSet GetHeaderInfoForInspectRpt(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetHeaderInfoForInspectRpt(lstParameters);
        }
    }
}

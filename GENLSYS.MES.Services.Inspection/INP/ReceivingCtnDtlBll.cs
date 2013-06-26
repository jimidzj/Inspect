using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using System.Data;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class ReceivingCtnDtlBll : BaseBll
    {
        private ReceivingCtnDtlDal localDal = null;

        public ReceivingCtnDtlBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new ReceivingCtnDtlDal(dbInstance);
            baseDal = localDal;
        }

        public DataSet GetReceivingSumCtnDtlRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetReceivingSumCtnDtlRecords(lstParameters);
        }

        public DataSet GetReceivingCtnDtlRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetReceivingCtnDtlRecords(lstParameters);
        }
    }
}

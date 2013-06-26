using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.MDL;
using GENLSYS.MES.DataContracts.Common;
using System.Data;

namespace GENLSYS.MES.Services.MDL
{
    public class ReasonCodeStepBll : BaseBll
    {
        ReasonCodeStepDal localDal = null;

        public ReasonCodeStepBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new ReasonCodeStepDal(dbInstance);
            baseDal = localDal;
        }

        public DataSet GetReasonCodeStep(string reasoncode)
        {
            return localDal.GetReasonCodeStep(reasoncode);
        }
    }
}

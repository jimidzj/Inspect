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

    public class RepairHisBll : BaseBll
    {
        private RepairHisDal localDal = null;

        public RepairHisBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new RepairHisDal(dbInstance);
            baseDal = localDal;
        }

        public DataSet GetRepairHisRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetRepairHisRecords(lstParameters);
        }
    }
}

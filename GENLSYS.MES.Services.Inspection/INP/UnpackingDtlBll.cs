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
    public class UnpackingDtlBll:BaseBll
    {
        private UnpackingDtlDal localDal = null;

        public UnpackingDtlBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new UnpackingDtlDal(dbInstance);
            baseDal = localDal;
        }

        public DataSet GetPackingCartonRecords()
        {
            return localDal.GetPackingCartonRecords();
        }

        public DataSet GetPackingCartonSummaryRecords()
        {
            return localDal.GetPackingCartonSummaryRecords();
        }
    }
}

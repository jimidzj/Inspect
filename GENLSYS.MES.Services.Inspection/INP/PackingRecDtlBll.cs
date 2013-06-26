using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using System.Data;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class PackingRecDtlBll:BaseBll
    {
        private PackingRecDtlDal localDal = null;

        public PackingRecDtlBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new PackingRecDtlDal(dbInstance);
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
        public DataSet GetPackingDtlSumRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetPackingDtlSumRecords(lstParameters);
        }
        public DataSet GetPackingDtlRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetPackingDtlRecords(lstParameters);
        }
        public DataSet GetHaveNotMovingDtlSumRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetHaveNotMovingDtlSumRecords(lstParameters);
        }
        public DataSet GetHaveNotMovingDtlRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetHaveNotMovingDtlRecords(lstParameters);
        }
        public DataSet GetHaveNotPackingDtlSumRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetHaveNotPackingDtlSumRecords(lstParameters);
        }
        public DataSet GetHaveNotPackingDtlRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetHaveNotPackingDtlRecords(lstParameters);
        }
        public DataSet GetLineWarehouseSumRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetLineWarehouseSumRecords(lstParameters);
        }
        public DataSet GetLineWarehouseSumDtlRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetLineWarehouseSumDtlRecords(lstParameters);
        }
    }
}

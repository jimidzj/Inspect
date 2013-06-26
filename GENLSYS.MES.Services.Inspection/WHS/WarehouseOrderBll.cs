using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.Inspection.WHS;
using System.Data;

namespace GENLSYS.MES.Services.Inspection.WHS
{
    public class WarehouseOrderBll : BaseBll
    {
        public WarehouseOrderBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            baseDal = new WarehouseOrderDal(dbInstance);
        }

        public DataSet GetWarehouseOrderDetailRecords(List<MESParameterInfo> lstParameters)
        {
            WarehouseOrderDtlDal wodtlDal = new WarehouseOrderDtlDal(dbInstance);
            return wodtlDal.GetWarehouseOrderDetailRecords(lstParameters);
        }
    }
}

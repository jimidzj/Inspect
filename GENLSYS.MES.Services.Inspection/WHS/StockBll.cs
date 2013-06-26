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
    public class StockBll: BaseBll
    {
        public StockBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            baseDal = new StockDal(dbInstance);
        }

        public DataSet GetStockRecords(List<MESParameterInfo> lstParameters)
        {
            StockDal wodtlDal = new StockDal(dbInstance);
            return wodtlDal.GetStockRecords(lstParameters);
        }
    }
}
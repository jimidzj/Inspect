using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;

namespace GENLSYS.MES.Repositories.Inspection.WHS
{
    public class WarehouseOrderDal : BaseDal
    {
        public WarehouseOrderDal(DBInstance dbi)
            : base(dbi)
        {
        }
    }
}

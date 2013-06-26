using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;

namespace GENLSYS.MES.Repositories.Inspection.WHS
{
    public class LocationDal : BaseDal
    {
        public LocationDal(DBInstance dbi)
            : base(dbi)
        {
        }
    }
}

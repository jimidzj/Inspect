﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.Inspection.WHS;

namespace GENLSYS.MES.Services.Inspection.WHS
{
    public class LocationBll : BaseBll
    {
        public LocationBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            baseDal = new LocationDal(dbInstance);
        }
    }
}

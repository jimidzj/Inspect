﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;

namespace GENLSYS.MES.Repositories.SYS
{
    public class SystemConfigDal : BaseDal
    {
        public SystemConfigDal(DBInstance dbi)
            : base(dbi)
        {
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.MDL;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Services.MDL
{
    public class EmployeeBll:BaseBll
    {
        public EmployeeBll(ContextInfo contextInfo) : 
            base(contextInfo)
        {
            baseDal = new EmployeeDal(dbInstance );
        }
    }
}

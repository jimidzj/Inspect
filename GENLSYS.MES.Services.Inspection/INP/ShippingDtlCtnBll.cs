﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class ShippingDtlCtnBll:BaseBll
    {
        private ShippingDtlCtnDal localDal = null;

        public ShippingDtlCtnBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new ShippingDtlCtnDal(dbInstance);
            baseDal = localDal;
        }
    }
}

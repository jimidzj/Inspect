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
    public class OtherPricingBll:BaseBll
    {
        private OtherPricingDal localDal = null;

        public OtherPricingBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new OtherPricingDal(dbInstance);
            baseDal = localDal;
        }

        public DataSet GetValidOtherPricing(string customerid, DateTime dt)
        {
            return localDal.GetValidOtherPricing(customerid, dt);
        }
    }
}

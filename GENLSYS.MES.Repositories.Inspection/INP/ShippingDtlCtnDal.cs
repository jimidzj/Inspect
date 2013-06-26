using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.Repositories.Common;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class ShippingDtlCtnDal:BaseDal
    {
        public ShippingDtlCtnDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinpshippingdtlctn";
        }
        
    }
}

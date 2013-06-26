using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using GENLSYS.MES.DataContracts.Common;
using System.Data;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class ShippingDtlBll:BaseBll
    {
        private ShippingDtlDal localDal = null;

        public ShippingDtlBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new ShippingDtlDal(dbInstance);
            baseDal = localDal;
        }

        public DataSet GetShippingPlanRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetShippingPlanRecords(lstParameters);
        }

        public DataSet GetShippingPlanNoRecords(string shippingsysid)
        {
            return localDal.GetShippingPlanNoRecords(shippingsysid);
        }
    }
}

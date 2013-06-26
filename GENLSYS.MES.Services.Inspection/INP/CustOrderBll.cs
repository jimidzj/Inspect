using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.Inspection.INP;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class CustOrderBll: BaseBll
    {
        public CustOrderBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            baseDal = new CustOrderDal(dbInstance);
        }
    }
}
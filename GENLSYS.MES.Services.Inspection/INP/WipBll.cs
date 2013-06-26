using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using System.Data;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class WipBll:BaseBll
    {
        private WipDal localDal = null;

        public WipBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new WipDal(dbInstance);
            baseDal = localDal;            
        }


    }
}

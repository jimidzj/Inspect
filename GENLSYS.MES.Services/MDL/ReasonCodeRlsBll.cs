using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.MDL;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Services.MDL
{
    public class ReasonCodeRlsBll : BaseBll
    {
        ReasonCodeRlsDal localDal = null;

        public ReasonCodeRlsBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new ReasonCodeRlsDal(dbInstance);
            baseDal = localDal;
        }
    }
}

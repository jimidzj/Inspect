using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.SEC;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Services.Common;

namespace GENLSYS.MES.Services.SEC
{
    public class IPControlBll : BaseBll
    {
        IPControlDal localDal = null;
        public IPControlBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new IPControlDal(dbInstance);
            baseDal = localDal;
        }
    }
}

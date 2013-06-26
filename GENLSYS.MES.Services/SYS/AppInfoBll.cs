using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SYS;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Services.SYS
{
    public class AppInfoBll : BaseBll
    {
        AppInfoDal localDal = null;
        public AppInfoBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new AppInfoDal(dbInstance);
            baseDal = localDal;
        }
    }
}

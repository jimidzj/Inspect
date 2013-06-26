using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.MDL;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Services.MDL
{
    public class WorkGroupBll : BaseBll
    {
        WorkGroupDal localDal = null;

        public WorkGroupBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new WorkGroupDal(dbInstance);
            baseDal = localDal;
        }
    }
}

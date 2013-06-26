using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SEC;
using System.Data;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Services.SEC
{
    public class RoleStepBll:BaseBll
    {
        RoleStepDal localDal = null;
        public RoleStepBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new RoleStepDal(dbInstance);
            baseDal = localDal;
        }

        public DataSet GetStepsByUserId(string userid)
        {
            return localDal.GetStepsByUserId(userid);
        }

        public DataSet GetAreaByUserId(string userid)
        {
            return localDal.GetAreaByUserId(userid);
        }
    }
}

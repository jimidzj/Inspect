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
    public class RoleFunctionBll:BaseBll
    {
        RoleFunctionDal localDal = null;
        public RoleFunctionBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new RoleFunctionDal(dbInstance);
            baseDal = localDal;
        }

        public DataSet GetRoleFunctionRecordsByRoleId(string roleid)
        {
            return localDal.GetRoleFunctionRecordsByRoleId(roleid);
        }

        public DataSet GetFunctionsByUserId(string userid)
        {
            return localDal.GetFunctionsByUserId(userid);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.SEC;
using System.Data;

namespace GENLSYS.MES.Services.SEC
{
    public class RoleEqpGroupBll:BaseBll
    {
        RoleEqpGroupDal localDal = null;
        public RoleEqpGroupBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new RoleEqpGroupDal(dbInstance);
            baseDal = localDal;
        }

        public DataSet GetRoleEqpGroupRecordsByRoleId(string roleid)
        {
            return localDal.GetRoleEqpGroupRecordsByRoleId(roleid);
        }
    }
}

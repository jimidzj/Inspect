using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SYS;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Services.SYS
{
    public class MenuConfigBll:BaseBll
    {
        MenuConfigDal localDal = null;
        public MenuConfigBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new MenuConfigDal(dbInstance);
            baseDal = localDal;
        }

        public List<tsysmenuconfig> GetTopMenuList(string menutype)
        {
            return localDal.GetTopMenuList(menutype);
        }
    }
}

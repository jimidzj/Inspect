using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;

namespace GENLSYS.MES.Repositories.SYS
{
    public class SessionDal:BaseDal
    {
        public SessionDal(DBInstance dbi)
            : base(dbi)
        {
            
        }
    }
}

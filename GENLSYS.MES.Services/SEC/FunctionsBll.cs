using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SEC;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Services.SEC
{
    public class FunctionsBll:BaseBll
    {
        public FunctionsBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            baseDal = new FunctionsDal(dbInstance);
        }
    }
}

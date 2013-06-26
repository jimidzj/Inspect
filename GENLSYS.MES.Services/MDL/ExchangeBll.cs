using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.MDL;
using System.Data;

namespace GENLSYS.MES.Services.MDL
{
    public class ExchangeBll:BaseBll
    {
        private ExchangeDal localDal = null;

        public ExchangeBll(ContextInfo contextInfo) : 
            base(contextInfo)
        {
            localDal = new ExchangeDal(dbInstance);
            baseDal = localDal;
        }

        public DataSet GetValidExchange(DateTime dt)
        {
            return localDal.GetValidExchange(dt);
        }
    }
}

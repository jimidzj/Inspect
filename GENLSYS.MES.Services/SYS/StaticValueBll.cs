using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SYS;
using GENLSYS.MES.DataContracts.Common;
using System.Data;

namespace GENLSYS.MES.Services.SYS
{
    public class StaticValueBll : BaseBll
    {
        StaticValueDal localDal = null;
        public StaticValueBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new StaticValueDal(dbInstance);
            baseDal = localDal;
        }
        //george
        public DataSet getStaticValue(string svType)
        {
            try
            {
                // dbInstance.BeginTransaction();
                DataSet ds = localDal.getStaticValue(svType);
                //  dbInstance.Commit();
                return ds;
            }
            catch (Exception ex)
            {
                dbInstance.Rollback();
                throw ex;
            }
            finally
            {
                dbInstance.CloseConnection();
            }
        }
    }
}

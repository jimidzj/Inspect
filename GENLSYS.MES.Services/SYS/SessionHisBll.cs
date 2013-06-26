using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SYS;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using GENLSYS.MES.DataContracts;

namespace GENLSYS.MES.Services.SYS
{
    public class SessionHisBll : BaseBll
    {
        private SessionHisDal localDal=null;
        public SessionHisBll(ContextInfo contextInfo) : 
            base(contextInfo)
        {
            localDal = new SessionHisDal(dbInstance);
            baseDal = localDal;
        }

        public DataSet GetSelectedRecords(string userid, string machine,string ipaddress, string shift, DateTime fromlogontime, DateTime tologontime)
        {
            return localDal.GetSelectedRecords(userid,machine,ipaddress,shift,fromlogontime,tologontime);
        }

        public void DoMultiDelete(List<string> lstSessionId)
        {
            try
            {
                dbInstance.BeginTransaction();
                foreach (string sessionid in lstSessionId)
                {
                    List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "sessionid",
                        ParamValue = sessionid,
                        ParamType = "string"
                    });
                    baseDal.DoDelete<tsyssessionhis>(lstParameters);
                }
                dbInstance.Commit();
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

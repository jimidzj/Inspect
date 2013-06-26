using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SYS;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Services.SYS
{
    public class SessionBll : BaseBll
    {
        public SessionBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            baseDal = new SessionDal(dbInstance);
        }        

        public void DoUpdateLock(List<string> lstSessionId, string flag)
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
                    tsyssession session = baseDal.GetSingleObject<tsyssession>(lstParameters, string.Empty, true);
                    session.islocked = flag;
                    baseDal.DoUpdate<tsyssession>(session);

                    #region update memory
                    string config = GetSystemConfig("SYS_ENABLE_ACCESSCONTROL");
                    if (config == MES_Misc.Y.ToString())
                    {
                        var q = (from p in (Parameter.CURRENT_SESSIONS as List<tsyssession>)
                                    where p.sessionid == session.sessionid
                                    select p).ToList();
                        if (q.Count > 0)
                            q[0].islocked = session.islocked;
                    }
                    #endregion
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

        public void DoUpdateKill(List<string> lstSessionId)
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
                    tsyssession session = baseDal.GetSingleObject<tsyssession>(lstParameters, string.Empty, true);
                    session.iskilled = MES_Misc.Y.ToString();
                    session.islocked = MES_Misc.Y.ToString();
                    baseDal.DoUpdate<tsyssession>(session);

                    #region update memory
                    string config = GetSystemConfig("SYS_ENABLE_ACCESSCONTROL");
                    if (config == MES_Misc.Y.ToString())
                    {
                        var q = (from p in (Parameter.CURRENT_SESSIONS as List<tsyssession>)
                                 where p.sessionid == session.sessionid
                                 select p).ToList();
                        if (q.Count > 0)
                        {
                            q[0].islocked = session.islocked;
                            q[0].iskilled = session.iskilled;
                        }
                    }
                    #endregion

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

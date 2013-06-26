using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Services.SYS;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Services.Common
{
    public class AccessController : BaseBll
    {
        private string IPAddress = string.Empty;
        private tsecuser UserObject = null;

        public AccessController(ContextInfo contextInfo)
            : base(contextInfo)
        {
            GetAllSystemConfig();
        }

        public void DoCheck()
        {
            if (CurrentContextInfo.Action != MES_ActionType.Query)
                CheckSystemLock();

            //marked by joe at 20110604, cause it's unstable and halt the program frequently
            //CheckSessionStatus(CurrentContextInfo.SessionId);

            CheckIPAddress(IPAddress);
        }

        private void CheckSessionStatus(string sessionId)
        {
            try
            {
                string config = GetSystemConfig("SYS_ENABLE_ACCESSCONTROL");
                if (config == MES_Misc.N.ToString()) return;

                if (Parameter.CURRENT_SESSIONS == null) return;

                //Check session status, locked,killed
                var q = (from p in (Parameter.CURRENT_SESSIONS as List<tsyssession>)
                         where p.sessionid == sessionId
                         select p).ToList<tsyssession>();

                if (q.Count <= 0)
                {
                    //session is not exists now.
                    throw new Exception("-200024");
                }

                IPAddress = q[0].ipaddress;

                if (q[0].iskilled == MES_Misc.Y.ToString())
                {
                    //session is killed
                    (Parameter.CURRENT_SESSIONS as List<tsyssession>).Remove(q[0]);
                    throw new Exception("-200025");
                }

                if (q[0].islocked == MES_Misc.Y.ToString())
                {
                    //session is locked
                    throw new Exception("-200026");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CheckSystemLock()
        {
            try
            {
                //check system constraints
                //Parameter.CURRENT_SYSTEM_CONFIG 
                string config = GetSystemConfig("SYS_SYSTEMLOCK");

                if (config == MES_Misc.Y.ToString())
                {
                    var q = (from p in (Parameter.CURRENT_USER_OBJECTS as List<tsecuser>)
                            where p.userid == CurrentContextInfo.CurrentUser
                            select p).ToList();

                    if (q.Count < 0)
                    {
                        throw new Exception("Unknown user.");
                    }
                    else
                    {
                        if (q[0].usertype != "Super")
                        {
                            throw new Exception("-200023");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CheckIPAddress(string ipAddress)
        {
            //check IP address
            if (Parameter.CURRENT_IPCONTROL == null) return;
            if ((Parameter.CURRENT_IPCONTROL as List<tsecipcontrol>).Count < 1) return;
            if (ipAddress.Trim()==string.Empty)
            {
                throw new Exception("Your IP address is illegal.");
            }

            var q = (from p in (Parameter.CURRENT_IPCONTROL as List<tsecipcontrol>)
                     where p.effectdate <= DateTime.Now
                     && (p.expireddate == null || p.expireddate.Value > DateTime.Now)
                     select p).ToList<tsecipcontrol>();

            if (q.Count < 1) return;

            bool b = false;
            for (int i = 0; i < q.Count; i++)
            {
                if (ipAddress.Substring(0, q[0].ipaddress.Trim().Length) == q[0].ipaddress.Trim())
                {
                    b = true;
                    break;
                }
            }

            if (!b)
            {
                throw new Exception("");
            }
        }
    }
}

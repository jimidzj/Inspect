using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Repositories.SEC;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Common;
using GENLSYS.MES.Repositories.SYS;
using System.Net;

namespace GENLSYS.MES.Services.SEC
{
    public class LogonBll : BaseBll
    {
        UserDal localDal = null;
        private SessionDal sessionDal = null;
        private SessionHisDal sessionhisDal = null;

        public LogonBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new UserDal(dbInstance);
            baseDal = localDal;
            sessionDal = new SessionDal(dbInstance);
            sessionhisDal = new SessionHisDal(dbInstance);
        }

        public void Logon(string userid, string password)
        {
            List<MESParameterInfo> lstParameter = new List<MESParameterInfo>() { 
                new MESParameterInfo()
                {
                    ParamName="userid",
                    ParamValue = userid.Trim(),
                    ParamType="string"
                }
            };

            List<MESParameterInfo> lstSessionParameter = new List<MESParameterInfo>() { 
                new MESParameterInfo()
                {
                    ParamName="userid",
                    ParamValue = userid.Trim(),
                    ParamType="string"
                },
                new MESParameterInfo()
                {
                    ParamName="iskilled",
                    ParamValue = "N",
                    ParamType="string"
                }
            };

            tsecuser user = GetSingleObject<tsecuser>(lstParameter);

            if (user == null)
            {
                throw new UtilException("-300004");
            }
            else
            {

                if (user.userstatus == "Inactive")
                {
                    throw new UtilException("-300001");
                }

                if (user.userstatus == "Locked")
                {
                    throw new UtilException("-300002");
                }

                if (user.password != password)
                {
                    throw new UtilException("-300003");
                }
            }
            //tsyssession syssession = sessionDal.GetSingleObject<tsyssession>(lstSessionParameter,string.Empty,false);
            //if (syssession!=null){
            //     throw new UtilException("-300005");
            //}
        }

        public void Logout(string sessionid)
        {
            try
            {
                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>() { 
                    new MESParameterInfo()
                    {
                        ParamName="sessionid",
                        ParamValue = sessionid.Trim(),
                        ParamType="string"
                    }
                };
                dbInstance.BeginTransaction();

                tsyssession syssession = sessionDal.GetSingleObject<tsyssession>(lstParameter,string.Empty,false);

                if (syssession != null)
                {
                    
                    tsyssessionhis syssessionhis = new tsyssessionhis();
                    syssessionhis.sessionid = syssession.sessionid;
                    syssessionhis.userid = syssession.userid;
                    syssessionhis.machine = syssession.machine;
                    syssessionhis.terminal = syssession.terminal;
                    syssessionhis.ipaddress = syssession.ipaddress;
                    syssessionhis.logontime = syssession.logontime;
                    syssessionhis.shift = syssession.shift;
                    syssessionhis.systemname = syssession.systemname;
                    syssessionhis.modulename = syssession.modulename;
                    syssessionhis.logonuser = string.Empty;
                    sessionhisDal.DoInsert<tsyssessionhis>(syssessionhis);

                    string config = GetSystemConfig("SYS_ENABLE_ACCESSCONTROL");
                    if (config == MES_Misc.Y.ToString())
                        (Parameter.CURRENT_SESSIONS as List<tsyssession>).Remove(syssession);

                    sessionDal.DoDelete<tsyssession>(lstParameter);
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

        public void UpdateLogonTime(string sessionid,string userid, string machine, string ipaddress, string shift)
        {
            try
            {
                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>() { 
                new MESParameterInfo()
                {
                    ParamName="userid",
                    ParamValue = userid.Trim(),
                    ParamType="string"
                }
            };

                dbInstance.BeginTransaction();

                tsecuser user = GetSingleObject<tsecuser>(lstParameter);

                if (user != null)
                {
                    user.lastlogontime = Function.GetCurrentTime();

                    localDal.DoUpdate<tsecuser>(user);                                      

                    tsyssession syssession = new tsyssession();
                    syssession.sessionid = sessionid;
                    syssession.userid = userid;
                    syssession.machine = machine;
                    syssession.terminal = string.Empty;
                    syssession.ipaddress = ipaddress;
                    syssession.logontime = Function.GetCurrentTime();
                    syssession.shift = shift;
                    syssession.islocked = MES_Misc.N.ToString();
                    syssession.iskilled = MES_Misc.N.ToString();
                    syssession.modulename = CurrentContextInfo.MiscValue1;
                    syssession.systemname = string.Empty;

                    sessionDal.DoInsert<tsyssession>(syssession);

                    string config = GetSystemConfig("SYS_ENABLE_ACCESSCONTROL");
                    if (config == MES_Misc.Y.ToString())
                    {
                        if (Parameter.CURRENT_SESSIONS == null)
                            Parameter.CURRENT_SESSIONS = new List<tsyssession>() { };

                        (Parameter.CURRENT_SESSIONS as List<tsyssession>).Add(syssession);
                    }
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

        public void ChangePassword(string userid, string oldPassword, string newPassword)
        {
            List<MESParameterInfo> lstParameter = new List<MESParameterInfo>() { 
                new MESParameterInfo()
                {
                    ParamName="userid",
                    ParamValue = userid.Trim(),
                    ParamType="string"
                }
            };

            tsecuser user = GetSingleObject<tsecuser>(lstParameter);

            if (user == null)
            {
                throw new UtilException("-300004");
            }
            else
            {

                if (user.userstatus == "Inactive")
                {
                    throw new UtilException("-300001");
                }

                if (user.userstatus == "Locked")
                {
                    throw new UtilException("-300002");
                }

                if (user.password != oldPassword)
                {
                    throw new UtilException("-300003");
                }
            }

            user.password = newPassword;

            DoUpdate<tsecuser>(user);
        }

        public void ValidatePassword(string userid, string password)
        {
            List<MESParameterInfo> lstParameter = new List<MESParameterInfo>() { 
                new MESParameterInfo()
                {
                    ParamName="userid",
                    ParamValue = userid.Trim(),
                    ParamType="string"
                }
            };

            tsecuser user = GetSingleObject<tsecuser>(lstParameter);

            if (user == null)
            {
                throw new UtilException("-300004");
            }
            else
            {

                if (user.userstatus == "Inactive")
                {
                    throw new UtilException("-300001");
                }

                if (user.userstatus == "Locked")
                {
                    throw new UtilException("-300002");
                }

                if (user.password != password)
                {
                    throw new UtilException("-300003");
                }
            }
        }

        public bool ValidateLineAdmin(string userid, string password)
        {
            List<MESParameterInfo> lstParameter = new List<MESParameterInfo>() { 
                new MESParameterInfo()
                {
                    ParamName="userid",
                    ParamValue = userid.Trim(),
                    ParamType="string"
                }
            };

            tsecuser user = GetSingleObject<tsecuser>(lstParameter);

            if (user == null)
            {
                throw new UtilException("-300004");
            }
            else
            {

                if (user.userstatus == "Inactive")
                {
                    throw new UtilException("-300001");
                }

                if (user.userstatus == "Locked")
                {
                    throw new UtilException("-300002");
                }

                if (user.password != password)
                {
                    throw new UtilException("-300003");

                }

                if (user.usertype != "LineAdmin")
                {
                    throw new UtilException("-300005");
                }
            }
            return true;
        }
   
    }
}

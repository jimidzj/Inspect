using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SEC;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Services.SEC
{
    public class UserBll : BaseBll
    {
        UserDal localDal = null;
        public UserBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new UserDal(dbInstance);
            baseDal = localDal;
        }

        public void DoInsertUser(tsecuser user, List<tsecuserrole> lstUserRole)
        {
            try
            {
                dbInstance.BeginTransaction();

                localDal.DoInsert<tsecuser>(user);

                #region Flow
                for (int i = 0; i < lstUserRole.Count; i++)
                {
                    localDal.DoInsert<tsecuserrole>(lstUserRole[i]);
                }
                #endregion

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

        public void DoUpdateUser(tsecuser user, List<tsecuserrole> lstUserRole)
        {
            try
            {
                dbInstance.BeginTransaction();

                localDal.DoUpdate<tsecuser>(user);

                #region Flow
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "userid",
                    ParamValue = user.userid,
                    ParamType = "string"
                });
                localDal.DoDelete<tsecuserrole>(lstParameters);

                for (int i = 0; i < lstUserRole.Count; i++)
                {
                    localDal.DoInsert<tsecuserrole>(lstUserRole[i]);
                }
                #endregion

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

        public void DoDeleteUser(List<MESParameterInfo> lstParameters)
        {
            try
            {
                dbInstance.BeginTransaction();

                localDal.DoDelete<tsecuserrole>(lstParameters);

                localDal.DoDelete<tsecuser>(lstParameters);

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

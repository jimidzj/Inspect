using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SEC;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;

namespace GENLSYS.MES.Services.SEC
{
    public class RoleBll : BaseBll
    {
        RoleFunctionDal roleFunctionDal = null;
        UserRoleDal userRoleDal = null;
        RoleStepDal roleStepDal = null;
        RoleEqpGroupDal roleEqpGroupDal = null;

        public RoleBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            baseDal = new RoleDal(dbInstance);
            roleFunctionDal = new RoleFunctionDal(dbInstance);
            userRoleDal = new UserRoleDal(dbInstance);
            roleStepDal = new RoleStepDal(dbInstance);
            roleEqpGroupDal = new RoleEqpGroupDal(dbInstance);
        }


        public void DoDelete(List<MESParameterInfo> lstParameters)
        {
            try
            {
                dbInstance.BeginTransaction();

                userRoleDal.DoDelete<tsecuserrole>(lstParameters);
                roleFunctionDal.DoDelete<tsecrolefunction>(lstParameters);
                roleStepDal.DoDelete<tsecrolestep>(lstParameters);
                roleEqpGroupDal.DoDelete<tsecroleeqpgroup>(lstParameters);
                baseDal.DoDelete<tsecrole>(lstParameters);


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

        public void DoInsert(tsecrole role, List<tsecrolefunction> lstRoleFunctions, List<tsecrolestep> lstRoleSteps, List<tsecroleeqpgroup> lstRoleEqpGroups)
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoInsert(role, string.Empty);
                foreach (tsecrolefunction obj in lstRoleFunctions)
                {
                    roleFunctionDal.DoInsert(obj, string.Empty);
                }
                foreach (tsecrolestep obj in lstRoleSteps)
                {
                    roleStepDal.DoInsert(obj, string.Empty);
                }
                foreach (tsecroleeqpgroup obj in lstRoleEqpGroups)
                {
                    roleEqpGroupDal.DoInsert(obj, string.Empty);
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

        public void DoUpdate(tsecrole role, List<tsecrolefunction> lstRoleFunctions, List<tsecrolestep> lstRoleSteps, List<tsecroleeqpgroup> lstRoleEqpGroups)
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoUpdate(role, string.Empty);
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "roleid",
                    ParamValue = role.roleid,
                    ParamType = "string"
                });
                roleFunctionDal.DoDelete<tsecrolefunction>(lstParameters);
                roleStepDal.DoDelete<tsecrolestep>(lstParameters);
                roleEqpGroupDal.DoDelete<tsecroleeqpgroup>(lstParameters);
                foreach (tsecrolefunction obj in lstRoleFunctions)
                {
                    roleFunctionDal.DoInsert(obj, string.Empty);
                }
                foreach (tsecrolestep obj in lstRoleSteps)
                {
                    roleStepDal.DoInsert(obj, string.Empty);
                }
                foreach (tsecroleeqpgroup obj in lstRoleEqpGroups)
                {
                    roleEqpGroupDal.DoInsert(obj, string.Empty);
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

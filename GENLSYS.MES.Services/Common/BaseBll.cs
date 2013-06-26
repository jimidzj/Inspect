using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.Common;
using System.Data;
using GENLSYS.MES.Services.SYS;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Services.SEC;

namespace GENLSYS.MES.Services.Common
{
    public class BaseBll
    {
        protected BaseDal baseDal = null;
        protected DBInstance dbInstance = null;
        protected ContextInfo CurrentContextInfo = null;

        public BaseBll(ContextInfo contextInfo)
        {
            CurrentContextInfo = contextInfo;
            dbInstance = new DBInstance(Parameter.MES_DATABASE_CONNECTION);
            //GetAllSystemConfig();
        }

        public BaseBll()
        {
            dbInstance = new DBInstance(Parameter.MES_DATABASE_CONNECTION);

            //GetAllSystemConfig();
        }

        public void GetAllSystemConfig()
        {
            if (Parameter.CURRENT_SYSTEM_CONFIG == null)
            {
                SystemConfigBll configBll = new SystemConfigBll(CurrentContextInfo);
                Parameter.CURRENT_SYSTEM_CONFIG = configBll.GetAllSystemConfigValue();

                IPControlBll ipBll = new IPControlBll(CurrentContextInfo);
                Parameter.CURRENT_IPCONTROL = ipBll.GetSelectedObjects<tsecipcontrol>(new List<MESParameterInfo>() { });

                UserBll userBll = new UserBll(CurrentContextInfo);
                Parameter.CURRENT_USER_OBJECTS = userBll.GetSelectedObjects<tsecuser>(new List<MESParameterInfo>() { });

                configBll.SetParameter();
            }
        }

        public string GetSystemConfig(string configName)
        {
            if (configName.Trim() == string.Empty) return string.Empty;
            if (Parameter.CURRENT_SYSTEM_CONFIG == null)
                GetAllSystemConfig();

            var q = (from p in ((Parameter.CURRENT_SYSTEM_CONFIG) as List<tsyssystemconfig>)
                     where p.configname == configName.Trim()
                     select p).SingleOrDefault();

            if (q == null) return string.Empty;

            return q.configvalue;
        }

        //Control Access
        public void CallAccessControl()
        {
            AccessController control = new AccessController(CurrentContextInfo);
            control.DoCheck();
        }

        #region Insert
        public void DoInsert<T>(T obj) where T : class
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoInsert<T>(obj, string.Empty);
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

        public void DoInsert<T>(T obj, string tableName) where T : class
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoInsert<T>(obj, tableName);
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

        public void DoMultiInsert<T>(List<T> lstObj) where T : class
        {
            try
            {
                dbInstance.BeginTransaction();
                foreach (T obj in lstObj)
                {
                    baseDal.DoInsert<T>(obj, string.Empty);
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

        public void DoMultiInsert<T>(List<T> lstObj,string tableName) where T : class
        {
            try
            {
                dbInstance.BeginTransaction();
                foreach (T obj in lstObj)
                {
                    baseDal.DoInsert<T>(obj, tableName);
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

        #endregion

        #region Update
        public void DoUpdate<T>(T obj) where T : class
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoUpdate<T>(obj, string.Empty);
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

        public void DoUpdate<T>(T obj, string tableName) where T : class
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoUpdate<T>(obj, tableName);
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

        public void DoMultiUpdate<T>(List<T> lstObj) where T : class
        {
            try
            {
                dbInstance.BeginTransaction();
                foreach (T obj in lstObj)
                {
                    baseDal.DoUpdate<T>(obj, string.Empty);
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
        #endregion

        #region Delete
        public void DoDelete<T>(T obj) where T : class
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoDelete<T>(obj, string.Empty);
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

        public void DoDelete<T>(T obj, string tableName) where T : class
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoDelete<T>(obj, tableName);
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

        public void DoDelete<T>(List<MESParameterInfo> lstParameters) where T : class
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoDelete<T>(lstParameters, string.Empty);
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

        public void DoDelete<T>(List<MESParameterInfo> lstParameters, string tableName) where T : class
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoDelete<T>(lstParameters, tableName);
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

        #endregion

        #region Get objects
        public List<T> GetSelectedObjects<T>(List<MESParameterInfo> lstParameters) where T : class
        {
            return baseDal.GetSelectedObjects<T>(lstParameters, string.Empty, false, 0);
        }

        public List<T> GetSelectedObjects<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber) where T : class
        {
            return baseDal.GetSelectedObjects<T>(lstParameters, tableName, isExtract, maxRecordNumber);
        }

        public SortableBindingList<T> GetSelectedObjectsSortableBindingList<T>(List<MESParameterInfo> lstParameters) where T : class
        {
            return baseDal.GetSelectedObjectsSortableBindingList<T>(lstParameters, string.Empty, false, 0);
        }

        public SortableBindingList<T> GetSelectedObjectsSortableBindingList<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber) where T : class
        {
            return baseDal.GetSelectedObjectsSortableBindingList<T>(lstParameters, tableName, isExtract, maxRecordNumber);
        }

        public DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters) where T : class
        {
            return baseDal.GetSelectedRecords<T>(lstParameters, string.Empty, false, 0);
        }

        public DataSet GetSelectedRecords<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract, int maxRecordNumber) where T : class
        {
            return baseDal.GetSelectedRecords<T>(lstParameters, tableName, isExtract, maxRecordNumber);
        }
        #endregion

        #region Get single object
        public T GetSingleObject<T>(List<MESParameterInfo> lstParameters) where T : class
        {
            return baseDal.GetSingleObject<T>(lstParameters, string.Empty, false);
        }

        public T GetSingleObject<T>(List<MESParameterInfo> lstParameters, string tableName, bool isExtract) where T : class
        {
            return baseDal.GetSingleObject<T>(lstParameters, tableName, isExtract);
        }
        #endregion
    }
}

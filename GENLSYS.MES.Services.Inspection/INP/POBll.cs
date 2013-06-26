using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using System.Data;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class POBll : BaseBll
    {
        PODal localDal = null;
        public POBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new PODal(dbInstance);
            baseDal = localDal;
        }

        public DataSet getPODtl(string funcid, string user, string workgroup, List<MESParameterInfo> lstParameters)  
        {
            try
            {
                // dbInstance.BeginTransaction();
                DataSet ds = localDal.GetWaitingOrderByStep(funcid, user, workgroup, lstParameters);
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

        public DataSet getColorByPo(string ponumber)
        {
            try
            {
                // dbInstance.BeginTransaction();
                DataSet ds = localDal.GetColorByPo(ponumber);
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

        public DataSet getTypeByPo(string ponumber)
        {
            try
            {
                // dbInstance.BeginTransaction();
                DataSet ds = localDal.GetTypeByPo(ponumber);
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

        public DataSet getSizeByPo(string ponumber)
        {
            try
            {
                // dbInstance.BeginTransaction();
                DataSet ds = localDal.GetSizeByPo(ponumber);
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

        public DataSet GetCancelableCarton(string  user , List<MESParameterInfo> lstParameters){

            try
            {
                // dbInstance.BeginTransaction();
                DataSet ds = localDal.GetCancelableCarton(  user,   lstParameters);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.MDL;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Services.MDL
{
    public class ReasonCodeBll : BaseBll
    {
        ReasonCodeDal localDal = null;

        public ReasonCodeBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new ReasonCodeDal(dbInstance);
            baseDal = localDal;
        }

        public List<tmdlreasoncode> GetReasonCodeList_ByCategoryStep(string reasonCodeCategory, string stepsysid)
        {
            return localDal.GetReasonCodeList_ByCategoryStep(reasonCodeCategory, stepsysid);
        }

        public void InsertReasonCode(tmdlreasoncode reasoncode, List<tmdlreasoncodestep> lstReasonCodeStep,
            List<tsysattributevalue> lstAttribute)
        {
            try
            {
                dbInstance.BeginTransaction();

                //Insert reason code
                localDal.DoInsert<tmdlreasoncode>(reasoncode);

                //insert reason code step
                for (int i = 0; i < lstReasonCodeStep.Count; i++)
                {
                    localDal.DoInsert<tmdlreasoncodestep>(lstReasonCodeStep[i]);
                }

                //Insert attribute
                for (int i = 0; i < lstAttribute.Count; i++)
                {
                    localDal.DoInsert<tsysattributevalue>(lstAttribute[i]);
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

        public void UpdateReasonCode(tmdlreasoncode reasoncode, List<tmdlreasoncodestep> lstReasonCodeStep,
            List<tsysattributevalue> lstAttribute)
        {
            try
            {
                dbInstance.BeginTransaction();

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>()
                {
                    new MESParameterInfo(){
                        ParamName="attributeid",
                        ParamValue=reasoncode.attributeid,
                        ParamType="string"
                    }
                };
                //delete attribute
                localDal.DoDelete<tsysattributevalue>(lstParameters);
                //delete reason code step
                lstParameters = new List<MESParameterInfo>()
                {
                    new MESParameterInfo(){
                        ParamName="reasoncode",
                        ParamValue=reasoncode.reasoncode,
                        ParamType="string"
                    }
                };
                localDal.DoDelete<tmdlreasoncodestep>(lstParameters);

                //Insert reason code
                localDal.DoUpdate<tmdlreasoncode>(reasoncode);

                //insert reason code step
                for (int i = 0; i < lstReasonCodeStep.Count; i++)
                {
                    localDal.DoInsert<tmdlreasoncodestep>(lstReasonCodeStep[i]);
                }

                //Insert attribute
                for (int i = 0; i < lstAttribute.Count; i++)
                {
                    localDal.DoInsert<tsysattributevalue>(lstAttribute[i]);
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

        public void DeleteReasonCode(List<MESParameterInfo> lstParameters)
        {
            try
            {
                dbInstance.BeginTransaction();

                tmdlreasoncode reasonCode = GetSingleObject<tmdlreasoncode>(lstParameters);

                if (reasonCode != null)
                {
                    List<MESParameterInfo> lstParams = new List<MESParameterInfo>()
                    {
                        new MESParameterInfo(){
                            ParamName="attributeid",
                            ParamValue=reasonCode.attributeid,
                            ParamType="string"
                        }
                    };

                    //delete attribute
                    localDal.DoDelete<tsysattributevalue>(lstParams);

                    //delete reason code step
                    localDal.DoDelete<tmdlreasoncodestep>(lstParameters);

                    //delete reason code
                    localDal.DoDelete<tmdlreasoncode>(lstParameters);
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

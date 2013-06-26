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
    public class IQCBll : BaseBll
    {
        public IQCBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            baseDal = new IQCDal(dbInstance);
        }

        public DataSet GetIQCRecords(List<MESParameterInfo> lstParameters)
        {
            IQCDal dal = new IQCDal(dbInstance);
            return dal.GetIQCRecords(lstParameters);
        }

        public DataSet GetIQCFail(string iqcsysid)
        {
            IQCDal dal = new IQCDal(dbInstance);
            return dal.GetIQCFail(iqcsysid);
        }

        public DataSet GetIQCReturn(string iqcsysid, string styleno)
        {
            IQCDal dal = new IQCDal(dbInstance);
            return dal.GetIQCReturn(iqcsysid, styleno);
        }

        public void DoInsertIQC(tinpiqc iqc,List<tinpiqcfail> lstFail, List<tinpiqcreturn> lstReturn)
        {
            IQCDal iqcDal = new IQCDal(dbInstance);

            CustOrderHistoryBll historyBll = new CustOrderHistoryBll(dbInstance, CurrentContextInfo);
            string eventGroup = Function.GetGUID();

            try
            {
                dbInstance.BeginTransaction();

                iqcDal.DoInsert<tinpiqc>(iqc);

                for (int i = 0; i < lstFail.Count; i++)
                {
                    iqcDal.DoInsert<tinpiqcfail>(lstFail[i]);
                }

                for (int i = 0; i < lstReturn.Count; i++)
                {
                    iqcDal.DoInsert<tinpiqcreturn>(lstReturn[i]);
                    iqcDal.UpdateCartonStatus(lstReturn[i].custorderno, lstReturn[i].cartonno);

                    List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=lstReturn[i].custorderno},
                        new MESParameterInfo(){ParamName="cartonno",ParamValue=lstReturn[i].cartonno}
                    };
                    List<tinpreceivingctndtl> ctlDtl = baseDal.GetSelectedObjects<tinpreceivingctndtl>(lstParam);

                    if (ctlDtl.Count > 0)
                    {
                        historyBll.WriteHistory("IQCReturn", eventGroup,iqc.customerid, lstReturn[i].custorderno,
                                    lstReturn[i].cartonno, ctlDtl[0].styleno, ctlDtl[0].color,
                                    ctlDtl[0].size, 1, ctlDtl[0].pairqty, iqc.iqcsysid,
                                    iqc.remark);
                    }
                    else
                    {
                        historyBll.WriteHistory("IQCReturn", eventGroup,iqc.customerid, lstReturn[i].custorderno,
                                    lstReturn[i].cartonno, string.Empty, string.Empty,
                                    string.Empty, 1, 0, iqc.iqcsysid,
                                    iqc.remark);
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
        public void DoUpdateIQC(tinpiqc iqc, List<tinpiqcfail> lstFail, List<tinpiqcreturn> lstReturn)
        {
            IQCDal iqcDal = new IQCDal(dbInstance);
            CustOrderHistoryBll historyBll = new CustOrderHistoryBll(dbInstance, CurrentContextInfo);
            string eventGroup = Function.GetGUID();

            try
            {
                dbInstance.BeginTransaction();

                iqcDal.DoUpdate<tinpiqc>(iqc);

                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>()
                {
                    new MESParameterInfo(){ ParamName="iqcsysid", ParamValue=iqc.iqcsysid}
                };

                List<tinpiqcreturn> lstOldReturn = iqcDal.GetSelectedObjects<tinpiqcreturn>(lstParameter);
                for (int i = 0; i < lstOldReturn.Count; i++)
                {
                    iqcDal.RecoverCartonStatus(lstOldReturn[i].custorderno, lstOldReturn[i].cartonno);
                }

                iqcDal.DoDelete<tinpiqcfail>(lstParameter);
                iqcDal.DoDelete<tinpiqcreturn>(lstParameter);
                historyBll.RemoveHistory("IQCReturn", iqc.iqcsysid);

                for (int i = 0; i < lstFail.Count; i++)
                {
                    iqcDal.DoInsert<tinpiqcfail>(lstFail[i]);
                }

                for (int i = 0; i < lstReturn.Count; i++)
                {
                    iqcDal.DoInsert<tinpiqcreturn>(lstReturn[i]);
                    iqcDal.UpdateCartonStatus(lstReturn[i].custorderno, lstReturn[i].cartonno);

                    List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=lstReturn[i].custorderno},
                        new MESParameterInfo(){ParamName="cartonno",ParamValue=lstReturn[i].cartonno}
                    };
                    List<tinpreceivingctndtl> ctlDtl = baseDal.GetSelectedObjects<tinpreceivingctndtl>(lstParam);

                    if (ctlDtl.Count > 0)
                    {
                        historyBll.WriteHistory("IQCReturn", eventGroup,iqc.customerid, lstReturn[i].custorderno,
                                    lstReturn[i].cartonno, ctlDtl[0].styleno, ctlDtl[0].color,
                                    ctlDtl[0].size, 1, ctlDtl[0].pairqty, iqc.iqcsysid,
                                    iqc.remark);
                    }
                    else
                    {
                        historyBll.WriteHistory("IQCReturn", eventGroup,iqc.customerid, lstReturn[i].custorderno,
                                    lstReturn[i].cartonno, string.Empty, string.Empty,
                                    string.Empty, 1, 0, iqc.iqcsysid,
                                    iqc.remark);
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

        public void DoDeleteIQC(List<MESParameterInfo> lstParameters)
        {
            IQCDal iqcDal = new IQCDal(dbInstance);
            CustOrderHistoryBll historyBll = new CustOrderHistoryBll(dbInstance, CurrentContextInfo);
            string eventGroup = Function.GetGUID();

            try
            {
                dbInstance.BeginTransaction();

                List<tinpiqcreturn> lstOldReturn = iqcDal.GetSelectedObjects<tinpiqcreturn>(lstParameters);
                for (int i = 0; i < lstOldReturn.Count; i++)
                {
                    iqcDal.RecoverCartonStatus(lstOldReturn[i].custorderno, lstOldReturn[i].cartonno);
                }

                baseDal.DoDelete<tinpiqcfail>(lstParameters);
                baseDal.DoDelete<tinpiqcreturn>(lstParameters);
                baseDal.DoDelete<tinpiqc>(lstParameters);
                historyBll.RemoveHistory("IQCReturn", lstParameters[0].ParamValue);

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

        public DataSet GetValidIQC(string customerid)
        {
            IQCDal dal = new IQCDal(dbInstance);
            return dal.GetValidIQC(customerid);
        }
    }
}

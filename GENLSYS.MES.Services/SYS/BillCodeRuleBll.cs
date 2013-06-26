using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SYS;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Services.SYS
{
    public class BillCodeRuleBll:BaseBll
    {
        BillCodeRuleDal localDal = null;
        public BillCodeRuleBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new BillCodeRuleDal(dbInstance);
            baseDal = localDal;
        }

        #region Insert/Update
        public void InsertBill(tsysbillcoderule billCodeRule, List<tsysbillcode> lstBillCode)
        {
            try
            {
                dbInstance.BeginTransaction();

                //Insert bill code rule
                localDal.DoInsert<tsysbillcoderule>(billCodeRule);

                //Insert bill code value
                for (int i = 0; i < lstBillCode.Count; i++)
                {
                    localDal.DoInsert<tsysbillcode>(lstBillCode[i]);
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

        public void UpdateBill(tsysbillcoderule billCodeRule, List<tsysbillcode> lstBillCode)
        {
            try
            {
                dbInstance.BeginTransaction();

                for (int i = 0; i < lstBillCode.Count; i++)
                {
                    List<MESParameterInfo> lstParameters = new List<MESParameterInfo>()
                    {
                        new MESParameterInfo(){
                            ParamName="bcrid",
                            ParamValue=billCodeRule.bcrid,
                            ParamType="string"
                        }
                    };

                    lstParameters.Add(
                        new MESParameterInfo()
                        {
                            ParamName = "timevalue",
                            ParamValue = lstBillCode[i].timevalue,
                            ParamType = "string"
                        }
                    );

                    if (lstBillCode[i].currentseqvalue <= 0)
                    {
                        localDal.DoDelete<tsysbillcode>(lstParameters);
                    }
                    else
                    {
                        tsysbillcode billCode = localDal.GetSingleObject<tsysbillcode>(lstParameters, string.Empty, true);

                        if (billCode != null)
                        {
                            billCode.bcrid = lstBillCode[i].bcrid;
                            billCode.currentseqvalue = lstBillCode[i].currentseqvalue;
                            billCode.fullbillnotext = lstBillCode[i].fullbillnotext;
                            billCode.isclosed = lstBillCode[i].isclosed;
                            billCode.islocked = lstBillCode[i].islocked;
                            billCode.lockrefid = lstBillCode[i].lockrefid;
                            billCode.prevseqvalue = lstBillCode[i].prevseqvalue;
                            billCode.timevalue = lstBillCode[i].timevalue;
                            billCode.lastmodifiedtime = Function.GetCurrentTime();
                            billCode.lastmodifieduser = CurrentContextInfo.CurrentUser;

                            localDal.DoUpdate<tsysbillcode>(billCode);
                        }
                    }

                }
                //Insert bill code rule
                localDal.DoUpdate<tsysbillcoderule>(billCodeRule);

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

        public void DoDelete(List<MESParameterInfo> lstParameters)
        {
            try
            {
                dbInstance.BeginTransaction();

                tsysbillcoderule rule = GetSingleObject<tsysbillcoderule>(lstParameters);
                if (rule != null)
                {
                    if (rule.bcrstatus != MES_BillCodeRule_BCRStatus.Unused.ToString())
                    {
                        throw new UtilException("BCR was used, it cannot be deleted!");
                    }
                    else
                    {
                        baseDal.DoDelete<tsysbillcoderule>(lstParameters, string.Empty);
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

    }
}

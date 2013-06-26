using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class ReturnBll:BaseBll
    {
        private ReturnDal localDal = null;
        private ReturnDtlDal returnDtlDal = null;
        private WipDal wipDal = null;
        private CustOrderHistoryDal custOrderHistoryDal = null;

        public ReturnBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new ReturnDal(dbInstance);
            baseDal = localDal;
            returnDtlDal = new ReturnDtlDal(dbInstance);
            wipDal = new WipDal(dbInstance);
            custOrderHistoryDal = new CustOrderHistoryDal(dbInstance);
        }


        public void DoReturn(tinpreturn inpreturn, List<tinpreturndtl> lstreturndtl)
        {
            try
            {
                dbInstance.BeginTransaction();

                var sumqty = lstreturndtl.Select(p => p.pairqty).Sum();

                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="retsysid",ParamValue=inpreturn.retsysid}
                        };

                List<tinpreturn> lstreturn = baseDal.GetSelectedObjects<tinpreturn>(lstParams);
                if (lstreturn.Count > 0)
                {
                    List<tinpreturndtl> lstdtl = baseDal.GetSelectedObjects<tinpreturndtl>(lstParams);
                    foreach (tinpreturndtl dtl in lstdtl)
                    {
                        wipDal.SaveOrUpdate(dtl.customerid,dtl.custorderno, dtl.styleno, dtl.color, dtl.size, MES_WIPStatus.BAD.ToString(), MES_Misc.BadStock.ToString(), Convert.ToInt16(dtl.pairqty),dtl.checktype);
                        returnDtlDal.DoDelete<tinpreturndtl>(dtl);

                    }
                    if (sumqty.Value == 0)
                    {
                        baseDal.DoDelete<tinpreturn>(inpreturn);
                    }
                }
                else
                {

                    if (sumqty.Value > 0)
                    {
                        baseDal.DoInsert(inpreturn);
                    }
                }

                string eventgroup=Function.GetGUID();

                foreach (tinpreturndtl returndtl in lstreturndtl)
                {
                    if (returndtl.pairqty > 0)
                    {
                        returnDtlDal.DoInsert(returndtl);

                        #region Update WIP
                        wipDal.SaveOrUpdate(returndtl.customerid, returndtl.custorderno, returndtl.styleno, returndtl.color, returndtl.size, MES_WIPStatus.BAD.ToString(), MES_Misc.BadStock.ToString(), Convert.ToInt16(-returndtl.pairqty),returndtl.checktype);
                        #endregion

                        #region Update CustomerOrder History
                        tinpcustorderhistory history = new tinpcustorderhistory();
                        history.customerid = inpreturn.customerid;
                        history.cartonno = "";
                        history.cartonqty = 0;
                        history.custorderno = returndtl.custorderno;
                        history.size = returndtl.size;
                        history.styleno = returndtl.styleno;
                        history.color = returndtl.color;
                        history.eventgroup = eventgroup;
                        history.eventname = "Return";
                        history.pairqty = returndtl.pairqty;
                        history.refsysid = returndtl.retdtlsysid;
                        history.remark = "";

                        history.eventtime = Function.GetCurrentTime();
                        history.eventuser = CurrentContextInfo.CurrentUser;
                        history.ohsysid = Function.GetGUID();
                        history.shift = CurrentContextInfo.Shift;
                        history.workgroup = CurrentContextInfo.WorkGroup;

                        custOrderHistoryDal.DoInsert<tinpcustorderhistory>(history);
                        #endregion
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

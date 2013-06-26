using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;
using System.Data;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class SupplementBll:BaseBll
    {
        private SupplementDal localDal = null;
        private SupplementDtlDal supplementDtlDal = null;
        private WipDal wipDal = null;
        private CustOrderHistoryDal custOrderHistoryDal = null;

        public SupplementBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new SupplementDal(dbInstance);
            baseDal = localDal;
            supplementDtlDal = new SupplementDtlDal(dbInstance);
            wipDal = new WipDal(dbInstance);
            custOrderHistoryDal = new CustOrderHistoryDal(dbInstance);
        }

        public void DoSupplementAdjust(string supldtlsysid, int qty, string isreinspect)
        {
            try
            {
                dbInstance.BeginTransaction();
               
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="supldtlsysid",ParamValue=supldtlsysid}
                        };
                tinpsupplementdtl dtl = supplementDtlDal.GetSingleObject<tinpsupplementdtl>(lstParams,string.Empty,true);
                DataTable dtlDt = supplementDtlDal.GetSelectedRecords<tinpsupplementdtl>(lstParams, string.Empty, true,0).Tables[0];

                if (dtl!=null)
                {
                    int difqty = qty - Convert.ToInt16(dtl.pairqty);
                    wipDal.SaveOrUpdate(dtl.customerid, dtl.custorderno, dtl.styleno, dtl.color, dtl.size, dtlDt.Rows[0]["step"].ToString(), dtlDt.Rows[0]["workgroup"].ToString(), difqty, dtl.checktype);
                    dtl.pairqty = qty;
                    dtl.isreinspect = isreinspect;
                    if (qty == 0)
                    {
                        supplementDtlDal.DoDelete<tinpsupplementdtl>(dtl);
                    }
                    else
                    {
                        supplementDtlDal.DoUpdate<tinpsupplementdtl>(dtl);
                    }

                }
                else
                {
                    throw new Exception("No data found");
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

        public void DoSupplement(tinpsupplement supplement, List<tinpsupplementdtl> lstsupplementdtl)
        {
            try
            {
                dbInstance.BeginTransaction();

                baseDal.DoInsert(supplement);

                string eventgroup = Function.GetGUID();

                foreach (tinpsupplementdtl supplementdtl in lstsupplementdtl)
                {
                    supplementDtlDal.DoInsert(supplementdtl);

                    #region Update WIP
                    wipDal.SaveOrUpdate(supplementdtl.customerid, supplementdtl.custorderno, supplementdtl.styleno, supplementdtl.color, supplementdtl.size, supplement.step, supplement.workgroup, Convert.ToInt16(supplementdtl.pairqty), supplementdtl.checktype);
                    #endregion

                    #region Update CustomerOrder History
                    tinpcustorderhistory history = new tinpcustorderhistory();
                    history.customerid = supplementdtl.customerid;
                    history.cartonno = "";
                    history.cartonqty = 0;
                    history.custorderno = supplementdtl.custorderno;
                    history.size = supplementdtl.size;
                    history.styleno = supplementdtl.styleno;
                    history.color = supplementdtl.color;
                    history.eventgroup = eventgroup;
                    history.eventname = "Supplement";
                    history.pairqty = supplementdtl.pairqty;
                    history.refsysid = supplementdtl.supldtlsysid;
                    history.remark = "";

                    history.eventtime = Function.GetCurrentTime();
                    history.eventuser = CurrentContextInfo.CurrentUser;
                    history.ohsysid = Function.GetGUID();
                    history.shift = CurrentContextInfo.Shift;
                    history.workgroup = CurrentContextInfo.WorkGroup;

                    custOrderHistoryDal.DoInsert<tinpcustorderhistory>(history);
                    #endregion
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

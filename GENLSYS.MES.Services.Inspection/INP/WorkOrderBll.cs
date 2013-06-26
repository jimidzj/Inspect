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
    public class WorkOrderBll: BaseBll
    {
        public WorkOrderBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            baseDal = new WorkOrderDal(dbInstance);
        }

        public DataSet GetWorkOrderDetailRecords(List<MESParameterInfo> lstParameters)
        {
            WorkOrderDtlDal wodtlDal = new WorkOrderDtlDal(dbInstance);
            return wodtlDal.GetWorkOrderDetailRecords(lstParameters);
        }

        public DataSet GetWorkOrderRecords(List<MESParameterInfo> lstParameters)
        {
            WorkOrderDal woDal = new WorkOrderDal(dbInstance);
            return woDal.GetWorkOrderRecords(lstParameters);
        }

        public void DoInsertWorkOrder(tinpworkorder workorder,
            List<tinpworkorderdtl> lstDtl)
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoInsert(workorder);

                WorkOrderDtlDal dtlDal = new WorkOrderDtlDal(dbInstance);
                CustOrderDal custOrderDal = new CustOrderDal(dbInstance);
                for (int i = 0; i < lstDtl.Count; i++)
                {
                    dtlDal.DoInsert<tinpworkorderdtl>(lstDtl[i]);
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

        public void DoUpdateWorkOrder(tinpworkorder workorder,
            List<tinpworkorderdtl> lstDtl)
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoUpdate(workorder);

                WorkOrderDtlDal dtlDal = new WorkOrderDtlDal(dbInstance);
                CustOrderDal custOrderDal = new CustOrderDal(dbInstance);
                for (int i = 0; i < lstDtl.Count; i++)
                {
                    List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="custorderno",ParamValue=lstDtl[i].custorderno},
                            new MESParameterInfo(){ParamName="styleno",ParamValue=lstDtl[i].styleno},
                            new MESParameterInfo(){ParamName="checktype",ParamValue=lstDtl[i].checktype}
                        };

                    #region check work order detail
                    List<tinpworkorderdtl> lstWorkOrderDtl = baseDal.GetSelectedObjects<tinpworkorderdtl>(lstParams, string.Empty, true, -1);
                    if (lstWorkOrderDtl.Count <= 0)
                    {
                        //insert
                        dtlDal.DoInsert<tinpworkorderdtl>(lstDtl[i]);
                    }
                    else
                    {
                        //update
                        lstWorkOrderDtl[0].schcartonqty = lstDtl[i].schcartonqty;
                        lstWorkOrderDtl[0].checktype = lstDtl[i].checktype;
                        lstWorkOrderDtl[0].completedtime = lstDtl[i].completedtime;
                        lstWorkOrderDtl[0].completeduser = lstDtl[i].completeduser;
                        lstWorkOrderDtl[0].schshpdate = lstDtl[i].schshpdate;
                        lstWorkOrderDtl[0].custorderno = lstDtl[i].custorderno;
                        lstWorkOrderDtl[0].schdlydate = lstDtl[i].schdlydate;
                        lstWorkOrderDtl[0].schpairqty = lstDtl[i].schpairqty;
                        lstWorkOrderDtl[0].remark = lstDtl[i].remark;
                        lstWorkOrderDtl[0].styleno = lstDtl[i].styleno;
                        lstWorkOrderDtl[0].workorderlineno = lstDtl[i].workorderlineno;
                        lstWorkOrderDtl[0].workordersysid = lstDtl[i].workordersysid;

                        dtlDal.DoUpdate<tinpworkorderdtl>(lstWorkOrderDtl[0]);
                    }
                    #endregion
                }

                #region check delete
                CheckDelete(custOrderDal, dtlDal, workorder, lstDtl);
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

        private void InsertIntoCustOrder(CustOrderDal custOrderDal,List<MESParameterInfo> lstParams,tinpworkorderdtl workOrderDtl)
        {
            //List<tinpcustorder> lstCustOrder = custOrderDal.GetSelectedObjects<tinpcustorder>(lstParams, string.Empty, true, -1);

            //if (lstCustOrder.Count <= 0)
            //{
            //    #region New
            //    //build cust order
            //    tinpcustorder custorder = new tinpcustorder();
            //    custorder.custordersysid = Function.GetGUID();
            //    custorder.size = workOrderDtl.size;
            //    custorder.styleno = workOrderDtl.styleno;
            //    custorder.color = workOrderDtl.color;
            //    custorder.custorderno = workOrderDtl.custorderno;
            //    custorder.custorderstatus = MES_CustOrder_Status.Active.ToString();
            //    custorder.inqty = workOrderDtl.pairqty;
            //    custorder.addpairqty = 0;
            //    custorder.inspectionqty = 0;
            //    custorder.inventoryqty = 0;
            //    custorder.repairqty = 0;
            //    custorder.returnqty = 0;
            //    custorder.scrapqty = 0;
            //    custorder.shippedqty = 0;
            //    custorder.wiqcqty = 0;
            //    custorder.xrayqty = 0;

            //    custOrderDal.DoInsert<tinpcustorder>(custorder);
            //    #endregion
            //}
        }

        private void CheckDelete(CustOrderDal custOrderDal,WorkOrderDtlDal dtlDal,
            tinpworkorder workorder,List<tinpworkorderdtl> lstDtl)
        {
            List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="workordersysid",ParamValue=workorder.workordersysid}
                        };

            List<tinpworkorderdtl> lstOldDtl = dtlDal.GetSelectedObjects<tinpworkorderdtl>(lstParams, string.Empty, true, -1);
            for (int i = 0; i < lstOldDtl.Count; i++)
            {
                var q = (from p in lstDtl
                         where p.custorderno == lstOldDtl[i].custorderno
                         && p.styleno == lstOldDtl[i].styleno
                         && p.checktype == lstOldDtl[i].checktype
                         select p).ToList();
                if (q.Count <= 0)
                {
                    //need to delete

                    //do delete
                    dtlDal.DoDelete<tinpworkorderdtl>(lstParams);
                }
            }
        }

        public void DoDeleteWorkOrder(List<MESParameterInfo> lstParameters)
        {
            try
            {
                dbInstance.BeginTransaction();
                WorkOrderDtlDal dtlDal = new WorkOrderDtlDal(dbInstance);

                //List<tinpworkorderdtl> lstDtl = dtlDal.GetSelectedObjects<tinpworkorderdtl>(lstParameters, string.Empty, true, -1);

                //for (int i = 0; i < lstDtl.Count; i++)
                //{
                //    List<MESParameterInfo> lstCustOrderParams = new List<MESParameterInfo>() { 
                //            new MESParameterInfo(){ParamName="custorderno",ParamValue=lstDtl[i].custorderno},
                //            new MESParameterInfo(){ParamName="styleno",ParamValue=lstDtl[i].styleno},
                //            new MESParameterInfo(){ParamName="checktype",ParamValue=lstDtl[i].checktype}
                //        };
                    
                //    //do delete

                //}

                //delete detail
                dtlDal.DoDelete<tinpworkorderdtl>(lstParameters);

                //delete main
                baseDal.DoDelete<tinpworkorder>(lstParameters);

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

        public DataSet GetCustOrderForReceiving(List<MESParameterInfo> lstParameters)
        {
            WorkOrderDtlDal dtlDal = new WorkOrderDtlDal(dbInstance);
            return dtlDal.GetCustOrderForReceiving(lstParameters);
        }
    }
}
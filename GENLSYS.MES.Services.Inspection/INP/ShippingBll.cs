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
    public class ShippingBll : BaseBll
    {
        private ShippingDal localDal = null;
        private ShippingDtlDal shippingDtlDal = null;
        private ShippingDtlCtnDal shippingDtlCtnDal = null;
        private ShippingPlanDal shippingPlanDal = null;
        private CustOrderHistoryDal custOrderHistoryDal = null;
        private PackingRecDtlDal packingRecDtlDal = null;
        private ReceivingCtnDtlDal receivingCtnDtlDal = null;


        public ShippingBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new ShippingDal(dbInstance);
            baseDal = localDal;

            shippingDtlDal = new ShippingDtlDal(dbInstance);
            shippingDtlCtnDal = new ShippingDtlCtnDal(dbInstance);
            custOrderHistoryDal = new CustOrderHistoryDal(dbInstance);
            packingRecDtlDal = new PackingRecDtlDal(dbInstance);
            receivingCtnDtlDal = new ReceivingCtnDtlDal(dbInstance);
            shippingPlanDal = new ShippingPlanDal(dbInstance);
        }

        public void DoDeleteShipping(string shippingsysid)
        {
            try
            {
                dbInstance.BeginTransaction();

                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=shippingsysid}
                        };

                List<tinpshippingdtlctn> lstctn = shippingDtlCtnDal.GetSelectedObjects<tinpshippingdtlctn>(lstParams);
                foreach (tinpshippingdtlctn shippingdtlctn in lstctn)
                {
                    packingRecDtlDal.UpdateIsShipped(shippingdtlctn.customerid, shippingdtlctn.custorderno, shippingdtlctn.cartonno, Public_Flag.N.ToString());
                }

                string shippingplanno = "";
                List<tinpshippingdtl> lstdtl = shippingDtlDal.GetSelectedObjects<tinpshippingdtl>(lstParams);
                if (lstdtl.Count > 0)
                {
                    shippingplanno = lstdtl[0].shippingplanno.ToString();
                }
                List<MESParameterInfo> lstPlanParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingplanno",ParamValue=shippingplanno}
                        };

                shippingPlanDal.DoDelete<tinpshippingplan>(lstPlanParams);
                shippingDtlCtnDal.DoDelete<tinpshippingdtlctn>(lstParams);
                shippingDtlDal.DoDelete<tinpshippingdtl>(lstParams);
                baseDal.DoDelete<tinpshipping>(lstParams);

                #region Update CustomerOrder History
                tinpcustorderhistory history = new tinpcustorderhistory();
                history.customerid = "";
                history.cartonno = "";
                history.cartonqty = 0;
                history.custorderno = "";
                history.size = "";
                history.styleno = "";
                history.color = "";
                history.eventgroup = Function.GetGUID(); ;
                history.eventname = "Delete Shipping";
                history.pairqty = 0;
                history.refsysid = shippingsysid;
                history.remark = "";

                history.eventtime = Function.GetCurrentTime();
                history.eventuser = CurrentContextInfo.CurrentUser;
                history.ohsysid = Function.GetGUID();
                history.shift = CurrentContextInfo.Shift;
                history.workgroup = CurrentContextInfo.WorkGroup;

                custOrderHistoryDal.DoInsert<tinpcustorderhistory>(history);
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

        public void DoShipping(tinpshipping shipping, List<tinpshippingdtlctn> lstshippingdtlctn, tinpshippingplan shippingplan, bool isDoShipping)
        {
            try
            {
                dbInstance.BeginTransaction();

                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=shipping.shippingsysid}
                        };

                List<tinpshippingdtlctn> lstctn = shippingDtlCtnDal.GetSelectedObjects<tinpshippingdtlctn>(lstParams);
                foreach (tinpshippingdtlctn shippingdtlctn in lstctn)
                {
                    packingRecDtlDal.UpdateIsShipped(shippingdtlctn.customerid,shippingdtlctn.custorderno, shippingdtlctn.cartonno, Public_Flag.N.ToString());
                }

                shippingDtlCtnDal.DoDelete<tinpshippingdtlctn>(lstParams);

                shippingDtlDal.DoUpdateStatusByShippingSysId(shipping.shippingsysid, isDoShipping ? MES_ShippingStatus.Shipped.ToString() : MES_ShippingStatus.Created.ToString());


                List<MESParameterInfo> lstPlanParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingplanno",ParamValue=shippingplan.shippingplanno}
                        };
                List<tinpshippingplan> lstShippingplan = shippingPlanDal.GetSelectedObjects<tinpshippingplan>(lstPlanParams);
                if (lstShippingplan.Count > 0)
                {
                    shippingPlanDal.DoUpdate<tinpshippingplan>(shippingplan);
                }
                else
                {
                    shippingPlanDal.DoInsert<tinpshippingplan>(shippingplan);
                }

                List<tinpshipping> lstShipping = baseDal.GetSelectedObjects<tinpshipping>(lstParams);
                if (lstShipping.Count > 0)
                {
                    tinpshipping shippingmdl = lstShipping[0];
                    shippingmdl.packingboxno = shipping.packingboxno;
                    shippingmdl.blno = shipping.blno;
                    shippingmdl.containerno = shipping.containerno;
                    shippingmdl.loadingtype = shipping.loadingtype;
                    //shippingmdl.contractno = shipping.contractno;
                    shippingmdl.shippingstatus = isDoShipping ? MES_ShippingStatus.Shipped.ToString() : MES_ShippingStatus.Created.ToString();
                    shippingmdl.lastmodifeduser = CurrentContextInfo.CurrentUser;
                    shippingmdl.lastmodifiedtime = Function.GetCurrentTime();
                    if (isDoShipping)
                    {
                        shippingmdl.shippeddate = Function.GetCurrentTime();
                    }
                    baseDal.DoUpdate<tinpshipping>(shippingmdl);
                }
                else
                {
                    shipping.shippingstatus = isDoShipping ? MES_ShippingStatus.Shipped.ToString() : MES_ShippingStatus.Created.ToString();
                    shipping.lastmodifeduser = CurrentContextInfo.CurrentUser;
                    shipping.lastmodifiedtime = Function.GetCurrentTime();
                    shipping.createduser = CurrentContextInfo.CurrentUser;
                    shipping.createdtime = Function.GetCurrentTime();
                    if (isDoShipping)
                    {
                        shipping.shippeddate = Function.GetCurrentTime();
                    }
                    baseDal.DoInsert<tinpshipping>(shipping);
                }



                string eventgroup = Function.GetGUID();
                List<tinpreceivingctndtl> lstReceivingRec = new List<tinpreceivingctndtl>();
                foreach (tinpshippingdtlctn shippingdtlctn in lstshippingdtlctn)
                {
                    shippingDtlCtnDal.DoInsert<tinpshippingdtlctn>(shippingdtlctn);
                    packingRecDtlDal.UpdateIsShipped(shippingdtlctn.customerid,shippingdtlctn.custorderno, shippingdtlctn.cartonno,Public_Flag.Y.ToString());

                    if (isDoShipping)
                    {
                        List<MESParameterInfo> lstRecParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="customerid",ParamValue=shippingdtlctn.customerid},
                            new MESParameterInfo(){ParamName="custorderno",ParamValue=shippingdtlctn.custorderno},
                            new MESParameterInfo(){ParamName="cartonno",ParamValue=shippingdtlctn.cartonno}
                        };

                        List<tinpreceivingctndtl> lstRec = receivingCtnDtlDal.GetSelectedObjects<tinpreceivingctndtl>(lstRecParams);
                        foreach (tinpreceivingctndtl rec in lstRec)
                        {
                            rec.cartonstatus = MES_CartonStatus.Finished.ToString();
                            rec.cartonlocation = MES_CartonLocation.Shipped.ToString();
                            lstReceivingRec.Add(rec);
                            //receivingCtnDtlDal.DoUpdate(rec);
                        }
                    }

                    #region Update CustomerOrder History
                    tinpcustorderhistory history = new tinpcustorderhistory();
                    history.customerid = shippingdtlctn.customerid;
                    history.cartonno = shippingdtlctn.cartonno;
                    history.cartonqty = 0;
                    history.custorderno = shippingdtlctn.custorderno;
                    history.size = "";
                    history.styleno = "";
                    history.color = "";
                    history.eventgroup = eventgroup; ;
                    history.eventname = "Shipping";
                    history.pairqty = 0;
                    history.refsysid = shipping.shippingsysid;
                    history.remark = "";

                    history.eventtime = Function.GetCurrentTime();
                    history.eventuser = CurrentContextInfo.CurrentUser;
                    history.ohsysid = Function.GetGUID();
                    history.shift = CurrentContextInfo.Shift;
                    history.workgroup = CurrentContextInfo.WorkGroup;

                    custOrderHistoryDal.DoInsert<tinpcustorderhistory>(history);
                    #endregion
                }

                foreach (tinpreceivingctndtl rec in lstReceivingRec)
                {
                    receivingCtnDtlDal.DoUpdate(rec);
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

        public void DoShipPlan(List<tinpshippingdtl> lstshippingdtl,tinpshippingplan shippingplan)
        {
            try
            {
                dbInstance.BeginTransaction();
                List<MESParameterInfo> lstPlanParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingplanno",ParamValue=shippingplan.shippingplanno}
                        };
                List<tinpshippingplan> lstShippingplan = shippingPlanDal.GetSelectedObjects<tinpshippingplan>(lstPlanParams);
                if (lstShippingplan.Count > 0)
                {
                    shippingPlanDal.DoUpdate<tinpshippingplan>(shippingplan);
                }
                else
                {
                    shippingPlanDal.DoInsert<tinpshippingplan>(shippingplan);
                }

                List<MESParameterInfo> lstDelParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=lstshippingdtl[0].shippingsysid}
                        };
                shippingDtlDal.DoDelete<tinpshippingdtl>(lstDelParams);

                string eventgroup = Function.GetGUID();
                foreach (tinpshippingdtl shippingdtl in lstshippingdtl)
                {
                    shippingdtl.createduser = CurrentContextInfo.CurrentUser;
                    shippingdtl.createdtime = Function.GetCurrentTime();
                    shippingdtl.lastmodifeduser = CurrentContextInfo.CurrentUser;
                    shippingdtl.lastmodifiedtime = Function.GetCurrentTime();
                    shippingdtl.shippingstatus = MES_ShippingStatus.Plan.ToString();
                    shippingdtl.ttlpairqty = 0;
                    shippingDtlDal.DoInsert<tinpshippingdtl>(shippingdtl);

                    #region Update CustomerOrder History
                    tinpcustorderhistory history = new tinpcustorderhistory();
                    history.customerid = shippingdtl.customerid;
                    history.cartonno = "";
                    history.cartonqty = shippingdtl.ttlcantonqty;
                    history.custorderno = shippingdtl.custorderno;
                    history.size = "";
                    history.styleno = "";
                    history.color = "";
                    history.eventgroup = eventgroup; ;
                    history.eventname = "ShipPlan";
                    history.pairqty = 0;
                    history.refsysid = shippingdtl.shippingsysid;
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

        public DataSet GetShippingDtlForReport(string shippingsysid)
        {
            return localDal.GetShippingDtlForReport(shippingsysid);
        }

        public DataSet GetShippingOrigDtlForReport(string shippingsysid)
        {
            return localDal.GetShippingOrigDtlForReport(shippingsysid);
        }

        public DataSet GetShippingDtlForWarehouseOut(string shippingsysid)
        {
            return localDal.GetShippingDtlForWarehouseOut(shippingsysid);
        }

        public DataSet GetBillForBillingReport(string shippingsysid)
        {
            return localDal.GetBillForBillingReport(shippingsysid);
        }

        public DataSet GetShippingSumRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetShippingSumRecords(lstParameters);
        }

        public DataSet GetShippingSumDtlRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetShippingSumDtlRecords(lstParameters);
        }

        public DataSet GetUnShippingSumRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetUnShippingSumRecords(lstParameters);
        }

        public DataSet GetUnShippingSumDtlRecords(List<MESParameterInfo> lstParameters)
        {
            return localDal.GetUnShippingSumDtlRecords(lstParameters);
        }

        public bool HasShipByPlanNo(string shippingplanno)
        {
            return localDal.HasShipByPlanNo(shippingplanno);
        }
    }
}

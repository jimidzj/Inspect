using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using GENLSYS.MES.DataContracts;
using System.Data;
using GENLSYS.MES.Common;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Repositories.SYS;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class ReceivingBll: BaseBll
    {
        public ReceivingBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            baseDal = new ReceivingDal(dbInstance);
        }

        public DataSet GetReceivingRecords(List<MESParameterInfo> lstParameters)
        {
            ReceivingDal dal = new ReceivingDal(dbInstance);
            return dal.GetReceivingRecords(lstParameters);
        }

        public bool CheckUsed(string recsysid)
        {
            ReceivingDal dal = new ReceivingDal(dbInstance);
            return dal.CheckUsed(recsysid);
        }

        public void DoInsertReceiving(tinpreceiving rec, List<tinpreceivingdtl> lstDtl)
        {
            string n1 = string.Empty;
            string n2 = string.Empty;

             ReceivingDal dal = new ReceivingDal(dbInstance);
            CustOrderHistoryBll historyBll = new CustOrderHistoryBll(dbInstance, CurrentContextInfo);
            string eventGroup = Function.GetGUID();

            try
            {
                dbInstance.BeginTransaction();

                baseDal.DoInsert<tinpreceiving>(rec);

                //List<tinpreceivingctndtl> lstCTN = new List<tinpreceivingctndtl>();

                for (int i = 0; i < lstDtl.Count; i++)
                {
                    baseDal.DoInsert<tinpreceivingdtl>(lstDtl[i]);

                    if (lstDtl[i].cartonno.IndexOf("-") > 0)
                    {
                        n1 = lstDtl[i].cartonno.Substring(0, lstDtl[i].cartonno.IndexOf("-"));
                        n2 = lstDtl[i].cartonno.Substring(lstDtl[i].cartonno.IndexOf("-") + 1);

                        for (int j = 0; j < (int.Parse(n2) - int.Parse(n1) + 1); j++)
                        {
                            tinpreceivingctndtl ctn = BuildCartonDtlObject(lstDtl[i].recsysid,
                               lstDtl[i].reclineno, lstDtl[i].custorderno, (int.Parse(n1) + j).ToString(), lstDtl[i].styleno,
                               lstDtl[i].color, lstDtl[i].size,lstDtl[i].pairqty / lstDtl[i].cartonqty,
                               lstDtl[i].checktype,lstDtl[i].remark,lstDtl[i].ismixed,rec.customerid);

                            string recno = dal.CheckDuplicate(lstDtl[i].custorderno, lstDtl[i].styleno,
                                lstDtl[i].color, lstDtl[i].size, (int.Parse(n1) + j).ToString());
                            if (recno.Trim()!=string.Empty)
                            {
                                throw new Exception("订单号[" + lstDtl[i].custorderno +
                                    "],箱号[" + (int.Parse(n1) + j).ToString() +
                                    "],款式[" + lstDtl[i].styleno +
                                    "],颜色[" + lstDtl[i].color +
                                    "],尺码[" + lstDtl[i].size + "]有重复[来料单号:" + recno + "].");
                            }

                            baseDal.DoInsert<tinpreceivingctndtl>(ctn);

                            historyBll.WriteHistory("Receiving", eventGroup,rec.customerid, lstDtl[i].custorderno,
                                (int.Parse(n1) + j).ToString(), lstDtl[i].styleno, lstDtl[i].color,
                                lstDtl[i].size, 1, lstDtl[i].pairqty / lstDtl[i].cartonqty, rec.recsysid,
                                rec.remark);

                            StaticValueDal svDal = new StaticValueDal(dbInstance);
                            svDal.autoInsertColor(lstDtl[i].color, lstDtl[i].color, CurrentContextInfo.CurrentUser);
                        }
                    }
                    else
                    {
                        tinpreceivingctndtl ctn = BuildCartonDtlObject(lstDtl[i].recsysid,
                           lstDtl[i].reclineno, lstDtl[i].custorderno, lstDtl[i].cartonno, lstDtl[i].styleno,
                               lstDtl[i].color, lstDtl[i].size, lstDtl[i].pairqty, lstDtl[i].checktype, 
                               lstDtl[i].remark,lstDtl[i].ismixed,rec.customerid);

                        string recno = dal.CheckDuplicate(lstDtl[i].custorderno, lstDtl[i].styleno,
                                lstDtl[i].color, lstDtl[i].size, lstDtl[i].cartonno);
                        if (recno.Trim() != string.Empty)
                        {
                            throw new Exception("订单号[" + lstDtl[i].custorderno +
                                   "],箱号[" + lstDtl[i].cartonno +
                                   "],款式[" + lstDtl[i].styleno +
                                   "],颜色[" + lstDtl[i].color +
                                   "],尺码[" + lstDtl[i].size + "]有重复[来料单号:" + recno + "].");
                        }

                        baseDal.DoInsert<tinpreceivingctndtl>(ctn);

                        historyBll.WriteHistory("Receiving", eventGroup,rec.customerid, lstDtl[i].custorderno,
                                lstDtl[i].cartonno, lstDtl[i].styleno, lstDtl[i].color,
                                lstDtl[i].size, 1, lstDtl[i].pairqty, rec.recsysid,
                                rec.remark);

                        StaticValueDal svDal = new StaticValueDal(dbInstance);
                        svDal.autoInsertColor(lstDtl[i].color, lstDtl[i].color, CurrentContextInfo.CurrentUser);
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

        //public void DoUpdateReceiving(tinpreceiving rec, List<tinpreceivingdtl> lstDtl)
        //{
        //    string n1 = string.Empty;
        //    string n2 = string.Empty;

        //    ReceivingDal dal = new ReceivingDal(dbInstance);
        //    CustOrderHistoryBll historyBll = new CustOrderHistoryBll(dbInstance, CurrentContextInfo);
        //    string eventGroup = Function.GetGUID();

        //    try
        //    {
        //        dbInstance.BeginTransaction();
        //        List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
        //            new MESParameterInfo(){ ParamName="recsysid",ParamValue=rec.recsysid}
        //        };

        //        baseDal.DoDelete<tinpreceivingctndtl>(lstParameters);
        //        baseDal.DoDelete<tinpreceivingdtl>(lstParameters);
        //        historyBll.RemoveHistory("Receiving", rec.recsysid);

        //        baseDal.DoUpdate<tinpreceiving>(rec);

        //        for (int i = 0; i < lstDtl.Count; i++)
        //        {
        //            baseDal.DoInsert<tinpreceivingdtl>(lstDtl[i]);

        //            if (lstDtl[i].cartonno.IndexOf("-") > 0)
        //            {
        //                n1 = lstDtl[i].cartonno.Substring(0, lstDtl[i].cartonno.IndexOf("-"));
        //                n2 = lstDtl[i].cartonno.Substring(lstDtl[i].cartonno.IndexOf("-") + 1);

        //                for (int j = 0; j < (int.Parse(n2) - int.Parse(n1) + 1 ); j++)
        //                {
        //                    tinpreceivingctndtl ctn = BuildCartonDtlObject(lstDtl[i].recsysid,
        //                       lstDtl[i].reclineno,lstDtl[i].custorderno, (int.Parse(n1) + j).ToString(), lstDtl[i].styleno,
        //                       lstDtl[i].color, lstDtl[i].size, lstDtl[i].pairqty / lstDtl[i].cartonqty,
        //                       lstDtl[i].checktype, lstDtl[i].remark,lstDtl[i].ismixed,rec.customerid);
        //                    string recno = dal.CheckDuplicate(lstDtl[i].custorderno, lstDtl[i].styleno,
        //                                                   lstDtl[i].color, lstDtl[i].size, (int.Parse(n1) + j).ToString());
        //                    if (recno.Trim() != string.Empty)
        //                    {
        //                        throw new Exception("订单号[" + lstDtl[i].custorderno +
        //                           "],箱号[" + (int.Parse(n1) + j).ToString() +
        //                           "],款式[" + lstDtl[i].styleno +
        //                           "],颜色[" + lstDtl[i].color +
        //                           "],尺码[" + lstDtl[i].size + "]有重复[来料单号:" + recno + "].");
        //                    }

        //                    baseDal.DoInsert<tinpreceivingctndtl>(ctn);

        //                    historyBll.WriteHistory("Receiving", eventGroup,rec.customerid, lstDtl[i].custorderno,
        //                        (int.Parse(n1) + j).ToString(), lstDtl[i].styleno, lstDtl[i].color,
        //                        lstDtl[i].size, 1, lstDtl[i].pairqty / lstDtl[i].cartonqty, rec.recsysid,
        //                        rec.remark);

        //                    StaticValueDal svDal = new StaticValueDal(dbInstance);
        //                    svDal.autoInsertColor(lstDtl[i].color, lstDtl[i].color, CurrentContextInfo.CurrentUser);
        //                }
        //            }
        //            else
        //            {
        //                tinpreceivingctndtl ctn = BuildCartonDtlObject(lstDtl[i].recsysid,
        //                   lstDtl[i].reclineno,lstDtl[i].custorderno, lstDtl[i].cartonno, lstDtl[i].styleno,
        //                       lstDtl[i].color, lstDtl[i].size, lstDtl[i].pairqty, lstDtl[i].checktype, 
        //                       lstDtl[i].remark,lstDtl[i].ismixed,rec.customerid);

        //                string recno = dal.CheckDuplicate(lstDtl[i].custorderno, lstDtl[i].styleno,
        //                       lstDtl[i].color, lstDtl[i].size, lstDtl[i].cartonno);
        //                if (recno.Trim() != string.Empty)
        //                {
        //                    throw new Exception("订单号[" + lstDtl[i].custorderno +
        //                          "],箱号[" + lstDtl[i].cartonno +
        //                          "],款式[" + lstDtl[i].styleno +
        //                          "],颜色[" + lstDtl[i].color +
        //                          "],尺码[" + lstDtl[i].size + "]有重复[来料单号:" + recno + "].");
        //                }

        //                baseDal.DoInsert<tinpreceivingctndtl>(ctn);

        //                historyBll.WriteHistory("Receiving", eventGroup,rec.customerid, lstDtl[i].custorderno,
        //                        lstDtl[i].cartonno, lstDtl[i].styleno, lstDtl[i].color,
        //                        lstDtl[i].size, 1, lstDtl[i].pairqty, rec.recsysid,
        //                        rec.remark);

        //                StaticValueDal svDal = new StaticValueDal(dbInstance);
        //                svDal.autoInsertColor(lstDtl[i].color, lstDtl[i].color, CurrentContextInfo.CurrentUser);
        //            }
        //        }

        //        dbInstance.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        dbInstance.Rollback();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbInstance.CloseConnection();
        //    }
        //}

        public void DoUpdateReceiving(tinpreceiving rec, List<tinpreceivingdtl> lstDtlNew, List<tinpreceivingdtl> lstDtlUpdated, List<string> lstDeleted)
        {
            string n1 = string.Empty;
            string n2 = string.Empty;

            ReceivingDal dal = new ReceivingDal(dbInstance);
            CustOrderHistoryBll historyBll = new CustOrderHistoryBll(dbInstance, CurrentContextInfo);
            string eventGroup = Function.GetGUID();

            try
            {
                dbInstance.BeginTransaction();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                    new MESParameterInfo(){ ParamName="recsysid",ParamValue=rec.recsysid}
                };

                DataSet dsCartonDetail = GetReceivingCartonDetailRecords(lstParameters);

                baseDal.DoUpdate<tinpreceiving>(rec);

                #region check delete
                bool canDeleted = true;
                for (int i = 0; i < lstDeleted.Count; i++)
                {
                    canDeleted = true;
                    for (int x = 0; x < dsCartonDetail.Tables[0].Rows.Count; x++)
                    {
                        if (lstDeleted[i] == dsCartonDetail.Tables[0].Rows[x]["reclineno"].ToString() &&
                                            (dsCartonDetail.Tables[0].Rows[x]["cartonlocation"].ToString() != "Warehouse" ||
                                            dsCartonDetail.Tables[0].Rows[x]["cartonstatus"].ToString() != "Active"))
                        {
                            canDeleted = false;
                            throw new Exception("行号[" + dsCartonDetail.Tables[0].Rows[x]["reclineno"].ToString() + "]里的箱号状态不允许删除");
                        }
                    }

                    if (canDeleted)
                    {
                        List<MESParameterInfo> lstParametersDeleted = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ ParamName="recsysid",ParamValue=rec.recsysid},
                            new MESParameterInfo(){ ParamName="reclineno",ParamValue=lstDeleted[i]}
                        };

                        baseDal.DoDelete<tinpreceivingctndtl>(lstParametersDeleted);
                        baseDal.DoDelete<tinpreceivingdtl>(lstParametersDeleted);
                    }
                }
                #endregion

                #region check insert
                for (int i = 0; i < lstDtlNew.Count; i++)
                {
                    baseDal.DoInsert<tinpreceivingdtl>(lstDtlNew[i]);

                    #region all to carton detail
                    if (lstDtlNew[i].cartonno.IndexOf("-") > 0)
                    {
                        n1 = lstDtlNew[i].cartonno.Substring(0, lstDtlNew[i].cartonno.IndexOf("-"));
                        n2 = lstDtlNew[i].cartonno.Substring(lstDtlNew[i].cartonno.IndexOf("-") + 1);

                        for (int j = 0; j < (int.Parse(n2) - int.Parse(n1) + 1); j++)
                        {
                            tinpreceivingctndtl ctn = BuildCartonDtlObject(lstDtlNew[i].recsysid,
                               lstDtlNew[i].reclineno, lstDtlNew[i].custorderno, (int.Parse(n1) + j).ToString(), lstDtlNew[i].styleno,
                               lstDtlNew[i].color, lstDtlNew[i].size, lstDtlNew[i].pairqty / lstDtlNew[i].cartonqty,
                               lstDtlNew[i].checktype, lstDtlNew[i].remark, lstDtlNew[i].ismixed, rec.customerid);

                            string recno = dal.CheckDuplicate(lstDtlNew[i].custorderno, lstDtlNew[i].styleno,
                                lstDtlNew[i].color, lstDtlNew[i].size, (int.Parse(n1) + j).ToString());
                            if (recno.Trim() != string.Empty)
                            {
                                throw new Exception("订单号[" + lstDtlNew[i].custorderno +
                                    "],箱号[" + (int.Parse(n1) + j).ToString() +
                                    "],款式[" + lstDtlNew[i].styleno +
                                    "],颜色[" + lstDtlNew[i].color +
                                    "],尺码[" + lstDtlNew[i].size + "]有重复[来料单号:" + recno + "].");
                            }

                            baseDal.DoInsert<tinpreceivingctndtl>(ctn);

                            historyBll.WriteHistory("Receiving", eventGroup, rec.customerid, lstDtlNew[i].custorderno,
                                (int.Parse(n1) + j).ToString(), lstDtlNew[i].styleno, lstDtlNew[i].color,
                                lstDtlNew[i].size, 1, lstDtlNew[i].pairqty / lstDtlNew[i].cartonqty, rec.recsysid,
                                rec.remark);

                            StaticValueDal svDal = new StaticValueDal(dbInstance);
                            svDal.autoInsertColor(lstDtlNew[i].color, lstDtlNew[i].color, CurrentContextInfo.CurrentUser);
                        }
                    }
                    else
                    {
                        tinpreceivingctndtl ctn = BuildCartonDtlObject(lstDtlNew[i].recsysid,
                           lstDtlNew[i].reclineno, lstDtlNew[i].custorderno, lstDtlNew[i].cartonno, lstDtlNew[i].styleno,
                               lstDtlNew[i].color, lstDtlNew[i].size, lstDtlNew[i].pairqty, lstDtlNew[i].checktype,
                               lstDtlNew[i].remark, lstDtlNew[i].ismixed, rec.customerid);

                        string recno = dal.CheckDuplicate(lstDtlNew[i].custorderno, lstDtlNew[i].styleno,
                                lstDtlNew[i].color, lstDtlNew[i].size, lstDtlNew[i].cartonno);
                        if (recno.Trim() != string.Empty)
                        {
                            throw new Exception("订单号[" + lstDtlNew[i].custorderno +
                                   "],箱号[" + lstDtlNew[i].cartonno +
                                   "],款式[" + lstDtlNew[i].styleno +
                                   "],颜色[" + lstDtlNew[i].color +
                                   "],尺码[" + lstDtlNew[i].size + "]有重复[来料单号:" + recno + "].");
                        }

                        baseDal.DoInsert<tinpreceivingctndtl>(ctn);

                        historyBll.WriteHistory("Receiving", eventGroup, rec.customerid, lstDtlNew[i].custorderno,
                                lstDtlNew[i].cartonno, lstDtlNew[i].styleno, lstDtlNew[i].color,
                                lstDtlNew[i].size, 1, lstDtlNew[i].pairqty, rec.recsysid,
                                rec.remark);

                        StaticValueDal svDal = new StaticValueDal(dbInstance);
                        svDal.autoInsertColor(lstDtlNew[i].color, lstDtlNew[i].color, CurrentContextInfo.CurrentUser);
                    }
                    #endregion
                }
                #endregion

                #region check Update
                bool canUpdated = true;
                for (int i = 0; i < lstDtlUpdated.Count; i++)
                {
                    baseDal.DoUpdate<tinpreceivingdtl>(lstDtlUpdated[i]);

                    canUpdated = true;
                    for (int x = 0; x < dsCartonDetail.Tables[0].Rows.Count; x++)
                    {
                        if (lstDtlUpdated[i].reclineno == dsCartonDetail.Tables[0].Rows[x]["reclineno"].ToString() &&
                                            (dsCartonDetail.Tables[0].Rows[x]["cartonlocation"].ToString() != "Warehouse" ||
                                            dsCartonDetail.Tables[0].Rows[x]["cartonstatus"].ToString() != "Active"))
                        {
                            canUpdated = false;
                            throw new Exception("行号[" + dsCartonDetail.Tables[0].Rows[x]["reclineno"].ToString() + "]里的箱号状态不允许更改");
                        }
                    }

                    if (canUpdated)
                    {
                        List<MESParameterInfo> lstParametersUpdated = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ ParamName="recsysid",ParamValue=rec.recsysid},
                            new MESParameterInfo(){ ParamName="reclineno",ParamValue=lstDtlUpdated[i].reclineno}
                        };

                        baseDal.DoDelete<tinpreceivingctndtl>(lstParametersUpdated);

                        #region add to carton detail
                        if (lstDtlUpdated[i].cartonno.IndexOf("-") > 0)
                        {
                            n1 = lstDtlUpdated[i].cartonno.Substring(0, lstDtlUpdated[i].cartonno.IndexOf("-"));
                            n2 = lstDtlUpdated[i].cartonno.Substring(lstDtlUpdated[i].cartonno.IndexOf("-") + 1);

                            for (int j = 0; j < (int.Parse(n2) - int.Parse(n1) + 1); j++)
                            {
                                tinpreceivingctndtl ctn = BuildCartonDtlObject(lstDtlUpdated[i].recsysid,
                                   lstDtlUpdated[i].reclineno, lstDtlUpdated[i].custorderno, (int.Parse(n1) + j).ToString(), lstDtlUpdated[i].styleno,
                                   lstDtlUpdated[i].color, lstDtlUpdated[i].size, lstDtlUpdated[i].pairqty / lstDtlUpdated[i].cartonqty,
                                   lstDtlUpdated[i].checktype, lstDtlUpdated[i].remark, lstDtlUpdated[i].ismixed, rec.customerid);

                                string recno = dal.CheckDuplicate(lstDtlUpdated[i].custorderno, lstDtlUpdated[i].styleno,
                                    lstDtlUpdated[i].color, lstDtlUpdated[i].size, (int.Parse(n1) + j).ToString());
                                if (recno.Trim() != string.Empty)
                                {
                                    throw new Exception("订单号[" + lstDtlUpdated[i].custorderno +
                                        "],箱号[" + (int.Parse(n1) + j).ToString() +
                                        "],款式[" + lstDtlUpdated[i].styleno +
                                        "],颜色[" + lstDtlUpdated[i].color +
                                        "],尺码[" + lstDtlUpdated[i].size + "]有重复[来料单号:" + recno + "].");
                                }

                                baseDal.DoInsert<tinpreceivingctndtl>(ctn);

                                historyBll.WriteHistory("Receiving", eventGroup, rec.customerid, lstDtlUpdated[i].custorderno,
                                    (int.Parse(n1) + j).ToString(), lstDtlUpdated[i].styleno, lstDtlUpdated[i].color,
                                    lstDtlUpdated[i].size, 1, lstDtlUpdated[i].pairqty / lstDtlUpdated[i].cartonqty, rec.recsysid,
                                    rec.remark);

                                StaticValueDal svDal = new StaticValueDal(dbInstance);
                                svDal.autoInsertColor(lstDtlUpdated[i].color, lstDtlUpdated[i].color, CurrentContextInfo.CurrentUser);
                            }
                        }
                        else
                        {
                            tinpreceivingctndtl ctn = BuildCartonDtlObject(lstDtlUpdated[i].recsysid,
                               lstDtlUpdated[i].reclineno, lstDtlUpdated[i].custorderno, lstDtlUpdated[i].cartonno, lstDtlUpdated[i].styleno,
                                   lstDtlUpdated[i].color, lstDtlUpdated[i].size, lstDtlUpdated[i].pairqty, lstDtlUpdated[i].checktype,
                                   lstDtlUpdated[i].remark, lstDtlUpdated[i].ismixed, rec.customerid);

                            string recno = dal.CheckDuplicate(lstDtlUpdated[i].custorderno, lstDtlUpdated[i].styleno,
                                    lstDtlUpdated[i].color, lstDtlUpdated[i].size, lstDtlUpdated[i].cartonno);
                            if (recno.Trim() != string.Empty)
                            {
                                throw new Exception("订单号[" + lstDtlUpdated[i].custorderno +
                                       "],箱号[" + lstDtlUpdated[i].cartonno +
                                       "],款式[" + lstDtlUpdated[i].styleno +
                                       "],颜色[" + lstDtlUpdated[i].color +
                                       "],尺码[" + lstDtlUpdated[i].size + "]有重复[来料单号:" + recno + "].");
                            }

                            baseDal.DoInsert<tinpreceivingctndtl>(ctn);

                            historyBll.WriteHistory("Receiving", eventGroup, rec.customerid, lstDtlUpdated[i].custorderno,
                                    lstDtlUpdated[i].cartonno, lstDtlUpdated[i].styleno, lstDtlUpdated[i].color,
                                    lstDtlUpdated[i].size, 1, lstDtlUpdated[i].pairqty, rec.recsysid,
                                    rec.remark);

                            StaticValueDal svDal = new StaticValueDal(dbInstance);
                            svDal.autoInsertColor(lstDtlUpdated[i].color, lstDtlUpdated[i].color, CurrentContextInfo.CurrentUser);
                        }
                        #endregion
                    }
                }
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

        public void DoDeleteReceiving(List<MESParameterInfo> lstParameters)
        {
            CustOrderHistoryBll historyBll = new CustOrderHistoryBll(dbInstance, CurrentContextInfo);
            try
            {
                dbInstance.BeginTransaction();

                baseDal.DoDelete<tinpreceivingctndtl>(lstParameters);
                baseDal.DoDelete<tinpreceivingdtl>(lstParameters);
                baseDal.DoDelete<tinpreceiving>(lstParameters);

                historyBll.RemoveHistory("Receiving", lstParameters[0].ParamValue);

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

        public void UpdateCartonQty(string recsysid,string cartonno,string oldstyleno,string oldcolor,string oldsize,int quantity,
            string color,string size,string styleno)
        {
            try
            {

                dbInstance.BeginTransaction();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                new MESParameterInfo(){ParamName="recsysid",ParamValue=recsysid},
                new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                new MESParameterInfo(){ParamName="styleno",ParamValue=oldstyleno},
                new MESParameterInfo(){ParamName="color",ParamValue=oldcolor},
                new MESParameterInfo(){ParamName="size",ParamValue=oldsize}
            };

                tinpreceivingctndtl ctn = baseDal.GetSingleObject<tinpreceivingctndtl>(lstParameters, "", true);

                if (ctn != null)
                {
                    ctn.pairqty = quantity;
                    ctn.size = size.Trim();
                    ctn.color = color.Trim();
                    ctn.styleno = styleno.Trim();
                    baseDal.DoUpdate<tinpreceivingctndtl>(ctn);
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

        public void DeleteSingleCarton(string recsysid, string cartonno,string oldstyleno,string oldcolor,string oldsize)
        {
            try
            {

                dbInstance.BeginTransaction();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                new MESParameterInfo(){ParamName="recsysid",ParamValue=recsysid},
                new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                new MESParameterInfo(){ParamName="styleno",ParamValue=oldstyleno},
                new MESParameterInfo(){ParamName="color",ParamValue=oldcolor},
                new MESParameterInfo(){ParamName="size",ParamValue=oldsize}
                };

                baseDal.DoDelete<tinpreceivingctndtl>(lstParameters);                

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

        private tinpreceivingctndtl BuildCartonDtlObject(string recsysid, string reclineno,
            string custorderno,string cartonno,string styleno,string color,string size, 
            decimal? pairqty,string checktype, string remark,string ismixed,string customerId)
        {
            tinpreceivingctndtl ctn = new tinpreceivingctndtl();
            ctn.cartonno = cartonno;
            ctn.pairqty = pairqty;
            ctn.reclineno = reclineno;
            ctn.recsysid = recsysid;
            ctn.remark = remark;
            ctn.styleno = styleno;
            ctn.custorderno = custorderno;
            ctn.size = size;
            ctn.color = color;
            ctn.checktype = checktype;
            ctn.ismixed = ismixed;
            ctn.cartonstatus = MES_CartonStatus.Active.ToString();
            ctn.cartonlocation = MES_CartonLocation.Warehouse.ToString();
            ctn.customerid = customerId;

            return ctn;
        }

        public DataSet GetReceivingDetailRecords(List<MESParameterInfo> lstParameters)
        {
            ReceivingDal dal = new ReceivingDal(dbInstance);
            return dal.GetReceivingDetailRecords(lstParameters);
        }

        public DataSet GetReceivingCartonDetailRecords(List<MESParameterInfo> lstParameters)
        {
            ReceivingDal dal = new ReceivingDal(dbInstance);
            return dal.GetReceivingCartonDetailRecords(lstParameters);
        }

        public DataSet GetReceivingHeader_Print(string recno)
        {
            ReceivingDal dal = new ReceivingDal(dbInstance);
            return dal.GetReceivingHeader_Print(recno);
        }

        public DataSet GetReceivingDetail_Print(string recno)
        {
            ReceivingDal dal = new ReceivingDal(dbInstance);
            return dal.GetReceivingDetail_Print(recno);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.Inspection.INP;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SYS;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Repositories.Inspection.INP;
using System.Data;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class AssyBoxBll : BaseBll
    {
        AssyBoxDal localDal = null;
        public AssyBoxBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new AssyBoxDal(dbInstance);
            baseDal = localDal;
        }



        public string CheckGroup(DataTable dt)
        {
            try
            {
                dbInstance.BeginTransaction();
                string customerid = dt.Rows[0]["customerid"].ToString();
                string custorderno = dt.Rows[0]["poid"].ToString();
                string cartonno = dt.Rows[0]["cartonNumber"].ToString();
                string styleno = dt.Rows[0]["type"].ToString();
                string size = dt.Rows[0]["size"].ToString();
                string color = dt.Rows[0]["color"].ToString();
                string qty = dt.Rows[0]["qty"].ToString();

                List<MESParameterInfo> lstParam0 = new List<MESParameterInfo>() { 
                             new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                                new MESParameterInfo(){ParamName="cartonno",ParamValue= cartonno},
                                new MESParameterInfo(){ParamName="customerid",ParamValue= customerid}
                     };

                List<tinpreceivingctndtl> ctlDtl0 = baseDal.GetSelectedObjects<tinpreceivingctndtl>(lstParam0);
                string checktype = ctlDtl0[0].checktype;

                #region 有没有入库信息
                OpenBoxDal dal = new OpenBoxDal(dbInstance);
                bool exist = dal.existsCarton(customerid, custorderno, cartonno);
                if (!exist)
                {
                    return "没有入库信息！";
                }
                #endregion

                List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="customerid",ParamValue=customerid},
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                        new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                       // new MESParameterInfo(){ParamName="styleno",ParamValue=styleno},
                       // new MESParameterInfo(){ParamName="size",ParamValue=size},
                       // new MESParameterInfo(){ParamName="color",ParamValue=color},  
                        new MESParameterInfo(){ParamName="pktype",ParamValue="Packing"} 
                    };
                List<tinppackingrecdtl> ctlDtl = baseDal.GetSelectedObjects<tinppackingrecdtl>(lstParam);
                #region  已经封箱
                if (ctlDtl.Count > 0)
                {
                    if (ctlDtl[0].isshipped == "Y")
                    {
                        return "已经发货，不可修改";
                    }
                    else
                    {
                        return "已经封箱，不可修改";
                    }

                }
                # endregion
                #region   没有封箱记录
                else
                {
                    List<MESParameterInfo> lstParam2 = new List<MESParameterInfo>() { 
                          new MESParameterInfo(){ParamName="customerid",ParamValue=customerid},
                          new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                          new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                       // new MESParameterInfo(){ParamName="styleno",ParamValue=styleno},
                       // new MESParameterInfo(){ParamName="size",ParamValue=size},
                      //  new MESParameterInfo(){ParamName="color",ParamValue=color},  
                          new MESParameterInfo(){ParamName="pktype",ParamValue="Unpacking"} 
                      };
                    List<tinppackingrecdtl> ctlDtl2 = baseDal.GetSelectedObjects<tinppackingrecdtl>(lstParam2);
                    #region    有开箱记录
                    if (ctlDtl2.Count > 0)
                    {
                        #region   IX 类型
                        if (checktype == "IX")
                        {  //有开箱记录，没有封箱记录，且是IX的
                            List<MESParameterInfo> lstParam3 = new List<MESParameterInfo>() { 
                                        new MESParameterInfo(){ParamName="customerid",ParamValue=customerid},
                                        new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                                        new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                                      //  new MESParameterInfo(){ParamName="styleno",ParamValue=styleno},
                                       // new MESParameterInfo(){ParamName="size",ParamValue=size},
                                       // new MESParameterInfo(){ParamName="color",ParamValue=color},  
                                        new MESParameterInfo(){ParamName="pktype",ParamValue="Moving"} 
                                      };
                            List<tinppackingrecdtl> ctlDtl3 = baseDal.GetSelectedObjects<tinppackingrecdtl>(lstParam3);
                            if (ctlDtl3.Count > 0)
                            { //有开箱，已经moving，没封箱，且是IX，
                                return "OK";
                            }
                            else
                            {
                                //有开箱， 且是IX，但没有moving
                                return "没有经过检品装箱";
                            }
                        }
                        #endregion
                        #region   I类型 或 X 类型；有开箱，没有封箱记录
                        else
                        {
                            //有开箱记录单没有封箱记录，且不是IX的
                            return "OK";
                        }
                        #endregion
                    }
                    # endregion
                    #region  没有开箱记录
                    else
                    {
                        return "没有开箱记录";
                    }
                    # endregion
                }
                # endregion
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

        public string MoveBoxCheckGroup(DataTable dt)
        {
            try
            {
                dbInstance.BeginTransaction();
                string customerid = dt.Rows[0]["customerid"].ToString();
                string custorderno = dt.Rows[0]["poid"].ToString();
                string cartonno = dt.Rows[0]["cartonNumber"].ToString();
                string styleno = dt.Rows[0]["type"].ToString();
                string size = dt.Rows[0]["size"].ToString();
                string color = dt.Rows[0]["color"].ToString();
                string qty = dt.Rows[0]["qty"].ToString();

                List<MESParameterInfo> lstParam0 = new List<MESParameterInfo>() { 
                                new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                                new MESParameterInfo(){ParamName="cartonno",ParamValue= cartonno},
                                new MESParameterInfo(){ParamName="customerid",ParamValue= customerid}
                     };

                List<tinpreceivingctndtl> ctlDtl0 = baseDal.GetSelectedObjects<tinpreceivingctndtl>(lstParam0);
                string checktype = ctlDtl0[0].checktype;

                #region check reciveing
                OpenBoxDal dal = new OpenBoxDal(dbInstance);
                bool exist = dal.existsCarton(customerid, custorderno, cartonno);
                if (!exist)
                {
                    return "没有入库信息！";
                }
                #endregion

                List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                     new MESParameterInfo(){ParamName="customerid",ParamValue=customerid},
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                        new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                       // new MESParameterInfo(){ParamName="styleno",ParamValue=styleno},
                       // new MESParameterInfo(){ParamName="size",ParamValue=size},
                       // new MESParameterInfo(){ParamName="color",ParamValue=color},  
                        new MESParameterInfo(){ParamName="pktype",ParamValue="Moving"} 
                    };
                List<tinppackingrecdtl> ctlDtl = baseDal.GetSelectedObjects<tinppackingrecdtl>(lstParam);

                if (ctlDtl.Count > 0)
                {
                    return "已经装箱";
                }
                else
                {
                    List<MESParameterInfo> lstParam2 = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="customerid",ParamValue=customerid},
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                        new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                       // new MESParameterInfo(){ParamName="styleno",ParamValue=styleno},
                       // new MESParameterInfo(){ParamName="size",ParamValue=size},
                      //  new MESParameterInfo(){ParamName="color",ParamValue=color},  
                        new MESParameterInfo(){ParamName="pktype",ParamValue="Unpacking"} 
                      };
                    List<tinppackingrecdtl> ctlDtl2 = baseDal.GetSelectedObjects<tinppackingrecdtl>(lstParam2);
                    if (ctlDtl2.Count > 0)
                    {
                        if (checktype == "IX")
                        {  //有开箱记录，没有装箱记录，且是IX的
                            return "OK";
                        }
                        else
                        {
                            //有开箱记录，没有装箱记录，不是是IX的
                            return "需要直接封箱";
                        }
                    }
                    else
                    {
                        return "没有开箱记录";
                    }
                }
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


        //封箱保存
        public bool AssyBoxSave(DataTable dt, string trayID, string user, string workGroup)
        {
            String recid = GENLSYS.MES.Common.Function.GetGUID();
            String pktype = MES_PackingType.Packing.ToString();
            DateTime actiondate = System.DateTime.Now;
            String factory = "";
            String userid = user;
            decimal? ttlqty = 0;
            string custorderno = "";
            String cartonno = "";
            String customerid = "";
            int dtl = dt.Rows.Count;
            dbInstance.BeginTransaction();
            try
            {  //delete line warehouse if exists
                customerid = dt.Rows[0]["customerid"].ToString();
                custorderno = dt.Rows[0]["poid"].ToString();
                cartonno = dt.Rows[0]["cartonNumber"].ToString();

                List<MESParameterInfo> lstParam2 = new List<MESParameterInfo>() { 
                          new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                          new MESParameterInfo(){ParamName="cartonNumber",ParamValue= cartonno},
                          new MESParameterInfo(){ParamName="customerid",ParamValue= customerid}
                     };
                baseDal.DoDelete<tinplinewarehouse>(lstParam2);
                //insert 
                for (int i = 0; i < dtl; i++)
                {
                    tinppackingrecdtl obj = new tinppackingrecdtl();
                    cartonno = dt.Rows[i]["cartonNumber"].ToString();
                    customerid = dt.Rows[i]["customerid"].ToString();
                    custorderno = dt.Rows[i]["poid"].ToString();

                    obj.custorderno = custorderno;
                    obj.cartonno = dt.Rows[i]["cartonNumber"].ToString();
                    customerid = dt.Rows[i]["customerid"].ToString();
                    obj.color = dt.Rows[i]["color"].ToString();
                    decimal? qty = decimal.Parse((dt.Rows[i]["qty2"].ToString()));
                    obj.pairqty = qty;
                    obj.pksysid = recid;
                    obj.size = dt.Rows[i]["size"].ToString();
                    obj.styleno = dt.Rows[i]["type"].ToString();
                    obj.pksysid = recid;
                    obj.confirmqty = qty;
                    obj.difference = 0;
                    obj.isshipped = "N";
                    obj.remark = "封箱";
                    obj.pktype = pktype;
                    obj.customerid = dt.Rows[i]["customerid"].ToString();

                    ttlqty = ttlqty + qty;
                    localDal.DoInsert<tinppackingrecdtl>(obj);
                    //get checktype from receiving

                    List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                              new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                                 new MESParameterInfo(){ParamName="cartonno",ParamValue=obj.cartonno},
                                 new MESParameterInfo(){ParamName="customerid",ParamValue=obj.customerid}
                      };

                    List<tinpreceivingctndtl> ctlDtl = baseDal.GetSelectedObjects<tinpreceivingctndtl>(lstParam);
                    string checktype = ctlDtl[0].checktype;
                    WipDal wip = new WipDal(dbInstance);
                    //wip
                    if (checktype == "IX")
                    {
                        wip.SaveOrUpdate(obj.customerid, obj.custorderno, obj.styleno, obj.color, obj.size, "X", "Line0", -1 * (int)qty, checktype);
                    }
                    if (checktype == "I")
                    {
                        wip.SaveOrUpdate(obj.customerid, obj.custorderno, obj.styleno, obj.color, obj.size, "I", workGroup, -1 * (int)qty, checktype);

                    }

                    if (checktype == "X")
                    {
                        wip.SaveOrUpdate(obj.customerid, obj.custorderno, obj.styleno, obj.color, obj.size, "X", workGroup, -1 * (int)qty, checktype);

                    }



                    Repositories.Inspection.INP.PackingRecRetrieveDal recRetrieveDal = new Repositories.Inspection.INP.PackingRecRetrieveDal(this.dbInstance);
                    recRetrieveDal.InsertRetrieve(recid, obj.cartonno, obj.custorderno, obj.styleno, obj.color, obj.size);
                }

                tinppackingrec headObj = new tinppackingrec();
                headObj.custorderno = custorderno;
                headObj.pksysid = recid;
                headObj.pktype = pktype;
                headObj.ttlqty = ttlqty;
                headObj.userid = user;
                headObj.workgroup = workGroup;
                headObj.customerid = customerid;
                headObj.remark = trayID;
                headObj.actiondate = System.DateTime.Now;
                localDal.DoInsert<tinppackingrec>(headObj);
                dbInstance.Commit();
                return true;
            }
            catch (Exception e)
            {
                dbInstance.Rollback();
                return false;
            }

        }

        ////201306 George --begin
        //空箱封箱保存
        public bool AssyBoxSaveDummy(string _customerid, string _poid, string _cartonNumber, string user, string workGroup)
        {
            String recid = GENLSYS.MES.Common.Function.GetGUID();
            String pktype = MES_PackingType.Packing.ToString();
            DateTime actiondate = System.DateTime.Now;
            String factory = "";
            String userid = user;
            decimal? ttlqty = 0;
            string custorderno = "";
            String cartonno = "";
            String customerid = "";

            dbInstance.BeginTransaction();
            try
            {
                customerid = _customerid;
                custorderno = _poid;
                cartonno = _cartonNumber;
                //delete line warehouse if exists
                List<MESParameterInfo> lstParam2 = new List<MESParameterInfo>() { 
                          new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                          new MESParameterInfo(){ParamName="cartonNumber",ParamValue= cartonno},
                          new MESParameterInfo(){ParamName="customerid",ParamValue= customerid}
                     };
                baseDal.DoDelete<tinplinewarehouse>(lstParam2);

                //insert 
                tinppackingrecdtl obj = new tinppackingrecdtl();
                obj.custorderno = custorderno;
                obj.cartonno = cartonno;
                obj.color = "$";
                obj.pairqty = 0;
                obj.pksysid = recid;
                obj.size = "$";
                obj.styleno = "$";

                obj.confirmqty = 0;
                obj.difference = 0;
                obj.isshipped = "N";
                obj.remark = "封箱";
                obj.pktype = pktype;
                obj.customerid = customerid;
                localDal.DoInsert<tinppackingrecdtl>(obj);

                //wip  no change

                //  Repositories.Inspection.INP.PackingRecRetrieveDal recRetrieveDal = new Repositories.Inspection.INP.PackingRecRetrieveDal(this.dbInstance);
                //  recRetrieveDal.InsertRetrieve(recid, obj.cartonno, obj.custorderno, obj.styleno, obj.color, obj.size);


                tinppackingrec headObj = new tinppackingrec();
                headObj.custorderno = custorderno;
                headObj.pksysid = recid;
                headObj.pktype = pktype;
                headObj.ttlqty = ttlqty;
                headObj.userid = user;
                headObj.workgroup = workGroup;
                headObj.customerid = customerid;
                headObj.remark = "Dummy";
                headObj.actiondate = System.DateTime.Now;
                localDal.DoInsert<tinppackingrec>(headObj);
                dbInstance.Commit();
                return true;
            }
            catch (Exception e)
            {
                dbInstance.Rollback();
                return false;
            }

        }
        ////200306 George --end

        //获得开箱明细
        public DataSet getOpenDetail(string customerid, string custorderno, string cartonno, string action, string currStep)
        {
            try
            {
                dbInstance.BeginTransaction();
                DataSet ctlDtl = localDal.getOpenDetail(customerid, custorderno, cartonno, action, currStep);

                dbInstance.Commit();
                return ctlDtl;
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


        //获得开箱明细
        public int getWIPByPO(string customerid, string custorderno, string styleno, string color, string size, string workgroup, string action, string currStep)
        {
            try
            {
                dbInstance.BeginTransaction();
                int wipCount = localDal.getWIPByPO(customerid, custorderno, styleno, color, size, workgroup, action, currStep);

                dbInstance.Commit();
                return wipCount;
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

        /** 是否已经ship*/
        public bool isShipped(string customer, string custorderno, string cartonno)
        {
            try
            {
                if (localDal.isShipped(customer, custorderno, cartonno))
                {
                    return true;
                }
                else
                {
                    return false;
                }
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


        //装箱保存
        public bool MoveBoxSave(DataTable dt, string trayID, string user, string workGroup, string oldWorkGroup)
        {
            String recid = GENLSYS.MES.Common.Function.GetGUID();
            String pktype = MES_PackingType.Moving.ToString();
            DateTime actiondate = System.DateTime.Now;
            String factory = "";
            String userid = user;
            decimal? ttlqty = 0;
            string custorderno = "";
            String cartonno = "";
            String customerid = "";
            int dtl = dt.Rows.Count;
            dbInstance.BeginTransaction();
            try
            {
                for (int i = 0; i < dtl; i++)
                {
                    tinppackingrecdtl obj = new tinppackingrecdtl();
                    cartonno = dt.Rows[i]["cartonNumber"].ToString();
                    customerid = dt.Rows[i]["customerid"].ToString();
                    custorderno = dt.Rows[i]["poid"].ToString();

                    obj.custorderno = custorderno;
                    obj.cartonno = dt.Rows[i]["cartonNumber"].ToString();
                    customerid = dt.Rows[i]["customerid"].ToString();
                    obj.color = dt.Rows[i]["color"].ToString();
                    decimal? qty = decimal.Parse((dt.Rows[i]["qty2"].ToString()));
                    obj.pairqty = qty;
                    obj.pksysid = recid;
                    obj.size = dt.Rows[i]["size"].ToString();
                    obj.styleno = dt.Rows[i]["type"].ToString();
                    obj.pksysid = recid;
                    obj.confirmqty = qty;
                    obj.difference = 0;
                    obj.isshipped = "N";
                    obj.remark = "装箱";
                    obj.pktype = pktype;
                    obj.customerid = dt.Rows[i]["customerid"].ToString();

                    ttlqty = ttlqty + qty;
                    localDal.DoInsert<tinppackingrecdtl>(obj);
                    //get checktype from receiving

                    List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                              new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                                 new MESParameterInfo(){ParamName="cartonno",ParamValue=obj.cartonno},
                                 new MESParameterInfo(){ParamName="customerid",ParamValue=obj.customerid}
                      };

                    List<tinpreceivingctndtl> ctlDtl = baseDal.GetSelectedObjects<tinpreceivingctndtl>(lstParam);
                    string checktype = ctlDtl[0].checktype;
                    WipDal wip = new WipDal(dbInstance);
                    wip.SaveOrUpdate(obj.customerid, obj.custorderno, obj.styleno, obj.color, obj.size, "I", oldWorkGroup, -1 * (int)qty, checktype);
                    wip.SaveOrUpdate(obj.customerid, obj.custorderno, obj.styleno, obj.color, obj.size, "X", workGroup, (int)qty, checktype);  //workGroup是固定值Line0，从UI传过来

                    //  Repositories.Inspection.INP.PackingRecRetrieveDal recRetrieveDal = new Repositories.Inspection.INP.PackingRecRetrieveDal(this.dbInstance);
                    //   recRetrieveDal.InsertRetrieve(recid, obj.cartonno, obj.custorderno, obj.styleno, obj.color, obj.size);
                }

                tinppackingrec headObj = new tinppackingrec();
                headObj.custorderno = custorderno;
                headObj.pksysid = recid;
                headObj.pktype = pktype;
                headObj.ttlqty = ttlqty;
                headObj.userid = user;
                headObj.workgroup = workGroup;
                headObj.actiondate = System.DateTime.Now;
                headObj.remark = trayID;
                headObj.customerid = customerid;
                localDal.DoInsert<tinppackingrec>(headObj);
                dbInstance.Commit();
                return true;
            }
            catch (Exception e)
            {
                dbInstance.Rollback();
                return false;
            }

        }

        ////201306 George --Begin
        //空箱装箱保存
        public bool MoveBoxSaveDummy(string _customerid, string _poid, string _cartonNumber, string user, string workGroup)
        {
            String recid = GENLSYS.MES.Common.Function.GetGUID();
            String pktype = MES_PackingType.Moving.ToString();
            DateTime actiondate = System.DateTime.Now;
            String factory = "";
            String userid = user;
            decimal? ttlqty = 0;
            string custorderno = "";
            String cartonno = "";
            String customerid = "";

            dbInstance.BeginTransaction();
            try
            {
                tinppackingrecdtl obj = new tinppackingrecdtl();

                customerid = _customerid;
                custorderno = _poid;
                cartonno = _cartonNumber;

                obj.custorderno = custorderno;
                obj.cartonno = cartonno;
                obj.color = "$";
                obj.pairqty = 0;
                obj.pksysid = recid;
                obj.size = "$";
                obj.styleno = "$";
                obj.pksysid = recid;
                obj.confirmqty = 0;
                obj.difference = 0;
                obj.isshipped = "N";
                obj.remark = "装箱";
                obj.pktype = pktype;
                obj.customerid = customerid;
                localDal.DoInsert<tinppackingrecdtl>(obj);
                //WIP no change
                //  Repositories.Inspection.INP.PackingRecRetrieveDal recRetrieveDal = new Repositories.Inspection.INP.PackingRecRetrieveDal(this.dbInstance);
                //   recRetrieveDal.InsertRetrieve(recid, obj.cartonno, obj.custorderno, obj.styleno, obj.color, obj.size);

                tinppackingrec headObj = new tinppackingrec();
                headObj.custorderno = custorderno;
                headObj.pksysid = recid;
                headObj.pktype = pktype;
                headObj.ttlqty = ttlqty;
                headObj.userid = user;
                headObj.workgroup = workGroup;
                headObj.actiondate = System.DateTime.Now;
                headObj.remark = "Dummy";
                headObj.customerid = customerid;
                localDal.DoInsert<tinppackingrec>(headObj);
                dbInstance.Commit();
                return true;
            }
            catch (Exception e)
            {
                dbInstance.Rollback();
                return false;
            }

        }
        ////201306 George --End

        //获得line warehouse 信息
        public DataSet getLineWarehouse(string customerid, string custorderno, string cartonno, string workgroup)
        {
            try
            {
                dbInstance.BeginTransaction();
                DataSet ctlDtl = localDal.getLineWarehouse(customerid, custorderno, cartonno, workgroup);

                dbInstance.Commit();
                return ctlDtl;
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


        //取消装箱
        public bool CancelMove(string customer, string cartonno, string poid, string user)
        {
            try
            {
                dbInstance.BeginTransaction();
                OpenBoxDal dal = new OpenBoxDal(dbInstance);
                //get checktype from receiving
                List<MESParameterInfo> param = new List<MESParameterInfo>() { 
                         new MESParameterInfo(){ParamName="custorderno",ParamValue=poid },
                         new MESParameterInfo(){ParamName="cartonno",ParamValue= cartonno} ,
                         new MESParameterInfo(){ParamName="customerid",ParamValue= customer} 
                    };

                List<tinpreceivingctndtl> rs = baseDal.GetSelectedObjects<tinpreceivingctndtl>(param);
                string checktype = rs[0].checktype;

                //get detail record of Opening  box  --tinppackingrecdtl
                List<MESParameterInfo> lstParam0 = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=poid},
                        new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                         new MESParameterInfo(){ParamName="pktype",ParamValue=MES_PackingType.Unpacking.ToString()},
                         new MESParameterInfo(){ParamName="customerid",ParamValue= customer} 
                    };
                List<tinppackingrecdtl> ctlDtl0 = baseDal.GetSelectedObjects<tinppackingrecdtl>(lstParam0);
                string sysid = ctlDtl0[0].pksysid;

                List<MESParameterInfo> lstParam1 = new List<MESParameterInfo>() { 
                         new MESParameterInfo(){ParamName="pksysid",ParamValue=sysid} 
                    };
                List<tinppackingrec> ctlDtl1 = baseDal.GetSelectedObjects<tinppackingrec>(lstParam1);
                string oldWorkGroup = ctlDtl1[0].workgroup;


                //get detail record of Moving  box  --tinppackingrecdtl
                List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=poid},
                        new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                         new MESParameterInfo(){ParamName="pktype",ParamValue=MES_PackingType.Moving.ToString()},
                         new MESParameterInfo(){ParamName="customerid",ParamValue= customer} 
                    };
                List<tinppackingrecdtl> ctlDtl = baseDal.GetSelectedObjects<tinppackingrecdtl>(lstParam);
                //sum qty

                for (int i = 0; i < ctlDtl.Count; i++)
                {
                    //process wip-------把X线上Line0的WIP扣除--------
                    WipDal wip = new WipDal(dbInstance);
                    wip.SaveOrUpdate(customer, ctlDtl[i].custorderno, ctlDtl[i].styleno, ctlDtl[i].color, ctlDtl[i].size, "X", "Line0", -1 * (int)ctlDtl[i].pairqty, checktype);

                    wip.SaveOrUpdate(customer, ctlDtl[i].custorderno, ctlDtl[i].styleno, ctlDtl[i].color, ctlDtl[i].size, "I", oldWorkGroup, (int)ctlDtl[i].pairqty, checktype);

                }
                //delete Moving detail
                baseDal.DoDelete<tinppackingrecdtl>(lstParam);
                //delete moving header
                if (ctlDtl.Count > 0)
                {
                    string sysid2 = ctlDtl[0].pksysid;
                    List<MESParameterInfo> lstParam2 = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="pksysid",ParamValue=sysid2}  };
                    baseDal.DoDelete<tinppackingrec>(lstParam2);
                }

                dbInstance.Commit();
                return true;


            }
            catch (Exception ex)
            {
                dbInstance.Rollback();
                return false;
                throw ex;
            }
            finally
            {
                dbInstance.CloseConnection();
            }
        }

        //取消封箱
        public bool CancelPack(string customer, string cartonno, string poid, string user)
        {
            try
            {
                dbInstance.BeginTransaction();
                OpenBoxDal dal = new OpenBoxDal(dbInstance);
                //get checktype from receiving
                List<MESParameterInfo> param = new List<MESParameterInfo>() { 
                         new MESParameterInfo(){ParamName="custorderno",ParamValue=poid },
                         new MESParameterInfo(){ParamName="cartonno",ParamValue= cartonno} ,
                         new MESParameterInfo(){ParamName="customerid",ParamValue= customer} 
                    };

                List<tinpreceivingctndtl> rs = baseDal.GetSelectedObjects<tinpreceivingctndtl>(param);
                string checktype = rs[0].checktype;

                //get detail record of Opening  box  --tinppackingrecdtl
                List<MESParameterInfo> lstParam0 = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=poid},
                        new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                         new MESParameterInfo(){ParamName="pktype",ParamValue=MES_PackingType.Unpacking.ToString()},
                         new MESParameterInfo(){ParamName="customerid",ParamValue= customer} 
                    };
                List<tinppackingrecdtl> ctlDtl0 = baseDal.GetSelectedObjects<tinppackingrecdtl>(lstParam0);
                string sysid = ctlDtl0[0].pksysid;

                List<MESParameterInfo> lstParam1 = new List<MESParameterInfo>() { 
                         new MESParameterInfo(){ParamName="pksysid",ParamValue=sysid} 
                    };
                List<tinppackingrec> ctlDtl1 = baseDal.GetSelectedObjects<tinppackingrec>(lstParam1);
                string oldWorkGroup = ctlDtl1[0].workgroup;

                //get detail record of packing  box  --tinppackingrecdtl
                List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                         new MESParameterInfo(){ParamName="custorderno",ParamValue=poid},
                         new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                         new MESParameterInfo(){ParamName="pktype",ParamValue=MES_PackingType.Packing.ToString()},
                         new MESParameterInfo(){ParamName="customerid",ParamValue= customer} 
                    };
                List<tinppackingrecdtl> ctlDtl = baseDal.GetSelectedObjects<tinppackingrecdtl>(lstParam);
                //sum qty

                for (int i = 0; i < ctlDtl.Count; i++)
                {
                    //process wip-------把X线上Line0的WIP扣除--------
                    WipDal wip = new WipDal(dbInstance);

                    if (checktype == "IX")
                    {
                        wip.SaveOrUpdate(customer, ctlDtl[i].custorderno, ctlDtl[i].styleno, ctlDtl[i].color, ctlDtl[i].size, "X", "Line0", (int)ctlDtl[i].pairqty, checktype);
                    }
                    else
                    {
                        wip.SaveOrUpdate(customer, ctlDtl[i].custorderno, ctlDtl[i].styleno, ctlDtl[i].color, ctlDtl[i].size, "I", oldWorkGroup, (int)ctlDtl[i].pairqty, checktype);
                    }

                }
                //delete Moving detail
                baseDal.DoDelete<tinppackingrecdtl>(lstParam);
                //delete moving header
                if (ctlDtl.Count > 0)
                {
                    string sysid2 = ctlDtl[0].pksysid;
                    List<MESParameterInfo> lstParam2 = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="pksysid",ParamValue=sysid2}  };
                    baseDal.DoDelete<tinppackingrec>(lstParam2);
                }

                ////////////////delete   tinppackingrecretrieve//////////////////2012-6-30//////
                List<MESParameterInfo> param5 = new List<MESParameterInfo>() { 
                         new MESParameterInfo(){ParamName="custorderno",ParamValue=poid },
                         new MESParameterInfo(){ParamName="cartonno",ParamValue= cartonno} ,
                         new MESParameterInfo(){ParamName="customerid",ParamValue= customer} 
                    };

                List<tinppackingrecdtl> rs5 = baseDal.GetSelectedObjects<tinppackingrecdtl>(param5);

                for (int i = 0; i < rs5.Count; i++)
                {
                    string pksysid = rs5[i].pksysid;

                    List<MESParameterInfo> lstParamX = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="pksysid",ParamValue= pksysid} 
                    };
                    baseDal.DoDelete<tinppackingrecretrieve>(lstParamX);
                }
                ////////////////////////////////////////////////////////////////////////////////

                dbInstance.Commit();
                return true;


            }
            catch (Exception ex)
            {
                dbInstance.Rollback();
                return false;
                throw ex;
            }
            finally
            {
                dbInstance.CloseConnection();
            }
        }


    }
}
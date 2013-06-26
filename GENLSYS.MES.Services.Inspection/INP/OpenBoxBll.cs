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
using GENLSYS.MES.Common;
using System.Data;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class OpenBoxBll : BaseBll
    {
        OpenBoxDal localDal = null;
        public OpenBoxBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new OpenBoxDal(dbInstance);
            baseDal = localDal;
        }


        //save carton
        public bool openBoxSave(DataTable dt, string trayID, string user, string workGroup)
        {
            try
            {
                dbInstance.BeginTransaction();
                OpenBoxDal dal = new OpenBoxDal(dbInstance);
                //
                String recid = GENLSYS.MES.Common.Function.GetGUID();
                String pktype = MES_PackingType.Unpacking.ToString();
                DateTime actiondate = System.DateTime.Now;
                String factory = "";
                String userid = user;
                String cartonno = "";
                String customerid = "";

                decimal? ttlqty = 0;
                string custorderno = "";
                int dtl = dt.Rows.Count;
                for (int i = 0; i < dtl; i++)
                {
                    tinppackingrecdtl obj = new tinppackingrecdtl();
                    cartonno = dt.Rows[i]["cartonNumber"].ToString();
                    customerid = dt.Rows[i]["customerid"].ToString();
                    custorderno = dt.Rows[i]["poid"].ToString();

                    obj.custorderno = custorderno;
                    obj.cartonno = dt.Rows[i]["cartonNumber"].ToString();
                    obj.color = dt.Rows[i]["color"].ToString();
                    decimal? qty = decimal.Parse((dt.Rows[i]["qty"].ToString()));
                    obj.pairqty = qty;
                    obj.pksysid = recid;
                    obj.size = dt.Rows[i]["size"].ToString();
                    obj.styleno = dt.Rows[i]["type"].ToString();

                    obj.confirmqty = 0;
                    obj.difference = 0;
                    obj.isshipped = "N";
                    obj.remark = "开箱";
                    obj.pktype = pktype;
                    obj.customerid = dt.Rows[i]["customerid"].ToString();
                    ttlqty = ttlqty + qty;
                    //insert opening box detail
                    localDal.DoInsert<tinppackingrecdtl>(obj);
                    //get checktype from receiving
                    List<MESParameterInfo> lstParam = new List<MESParameterInfo>()
                       { 
                           new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                           new MESParameterInfo(){ParamName="cartonno",ParamValue=obj.cartonno} ,
                            new MESParameterInfo(){ParamName="customerid",ParamValue=obj.customerid}
                    
                       };

                    List<tinpreceivingctndtl> ctlDtl = baseDal.GetSelectedObjects<tinpreceivingctndtl>(lstParam);
                    string checktype = ctlDtl[0].checktype;
                    //insert wip
                    WipDal wip = new WipDal(dbInstance);
                    wip.SaveOrUpdate(obj.customerid , obj.custorderno, obj.styleno, obj.color, obj.size, "I",workGroup, (int)qty, checktype);
                    //update carton.location of receiving  
                    localDal.UpdateCartonLocation(obj.customerid,custorderno, obj.cartonno, user, MES_CartonLocation.WIP.ToString());
                }
                //insert opening box summary table
                tinppackingrec headObj = new tinppackingrec();
                headObj.custorderno = custorderno;
                headObj.pksysid = recid;
                headObj.pktype = pktype;
                headObj.ttlqty = ttlqty;
                headObj.userid = user;
                headObj.workgroup = workGroup;
                headObj.actiondate = System.DateTime.Now;
                headObj.customerid = customerid;
                headObj.remark = trayID;
                localDal.DoInsert<tinppackingrec>(headObj);
                //delete line warehouse, if exists
                List<MESParameterInfo> lstParam2 = new List<MESParameterInfo>() { 
                          new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                          new MESParameterInfo(){ParamName="cartonNumber",ParamValue= cartonno},
                          new MESParameterInfo(){ParamName="customerid",ParamValue= customerid}
                };
                baseDal.DoDelete<tinplinewarehouse>(lstParam2);

                dbInstance.Commit();
                return true;
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
        /** 未封/装箱前修改*/
        public void openBoxUpdate(DataTable dt, string trayID, string user, string workGroup, string customer, string cartonno, string poid)
        {
            OpenBoxDeleteBox(customer, cartonno, poid, user, workGroup);
            openBoxSave(dt,trayID, user, workGroup);
            return;
        }
        /** check before save*/
        public String CheckGroup(DataTable dt)
        {
            // bool res = false;
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
                string status = MES_CartonStatus.Active.ToString();
                string cartonlocation = MES_CartonLocation.Warehouse.ToString();


                #region check reciveing
                OpenBoxDal dal = new OpenBoxDal(dbInstance);
                bool exist = dal.existsCarton(customerid, custorderno, cartonno);
                if (!exist)
                {
                    return "NoCarton";
                }
                #endregion

                #region alread pack / box
                bool isBoxing = dal.isBoxing(customerid, custorderno, cartonno);
                if (isBoxing)
                {
                    return "boxing";
                }
                #endregion

                #region alread unpack
                bool opened = dal.isOpened(customerid, custorderno, cartonno);
                string result = "";
                if (opened)
                {
                    result = result + "Opened";
                }
                #endregion
                #region roupsEquals
                int groups = dt.Rows.Count;
                bool groupsEquals = dal.groupsEquals(customerid, custorderno, cartonno, groups);
                if (!groupsEquals)
                {
                    result = result + "|groupMiss";
                }

                #endregion



                for (int i = 0; i < groups; i++)
                {
                    string customerid2 = dt.Rows[i]["customerid"].ToString();
                    string custorderno2 = dt.Rows[i]["poid"].ToString();
                    string cartonno2 = dt.Rows[i]["cartonNumber"].ToString();
                    string styleno2 = dt.Rows[i]["type"].ToString();
                    string size2 = dt.Rows[i]["size"].ToString();
                    string color2 = dt.Rows[i]["color"].ToString();
                    string qty2 = dt.Rows[i]["qty"].ToString();
                    bool existsGroup = dal.existsGroup(customerid, custorderno, cartonno, styleno2, color2, size2, qty2);
                    if (!existsGroup)
                    {
                        result = result + "|NOGroup";
                    }
                }
                if (result.Length > 0)
                {
                    return result;
                }
                return "OK";
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

        /** x线封箱不满箱暂时存放产线*/
        public bool lineWarehouseSave(DataTable dt, string user, string workGroup)
        {
            try
            {
                dbInstance.BeginTransaction();
                OpenBoxDal dal = new OpenBoxDal(dbInstance);
                ///////////////////////////
                String recid = GENLSYS.MES.Common.Function.GetGUID();
                String pktype = MES_PackingType.Unpacking.ToString();
                DateTime actiondate = System.DateTime.Now;
                String factory = "";
                String userid = user;
                decimal? ttlqty = 0;
                string custorderno = "";
                int dtl = dt.Rows.Count;

              

                //delete old carton if exists
                //delete line warehouse, if exists
                string customerid= dt.Rows[0]["customerid"].ToString();
                custorderno = dt.Rows[0]["poid"].ToString();
                string cartonno=   dt.Rows[0]["cartonNumber"].ToString();

                //get checktype from receiving
                List<MESParameterInfo> lstParam = new List<MESParameterInfo>()
                       { 
                           new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                           new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno} ,
                            new MESParameterInfo(){ParamName="customerid",ParamValue=customerid}
                    
                       };

                List<tinpreceivingctndtl> ctlDtl = baseDal.GetSelectedObjects<tinpreceivingctndtl>(lstParam);
                string checktype = ctlDtl[0].checktype;
                  
                List<MESParameterInfo> lstParam2 = new List<MESParameterInfo>() { 
                          new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                          new MESParameterInfo(){ParamName="cartonNumber",ParamValue= cartonno},
                          new MESParameterInfo(){ParamName="customerid",ParamValue= customerid}
                     };
                baseDal.DoDelete<tinplinewarehouse>(lstParam2);

                for (int i = 0; i < dtl; i++)
                {
                      //
                    tinplinewarehouse obj = new tinplinewarehouse();
                    obj.customerid = dt.Rows[i]["customerid"].ToString();
                    custorderno = dt.Rows[i]["poid"].ToString();
                    obj.custorderno = custorderno;
                    obj.cartonNumber = dt.Rows[i]["cartonNumber"].ToString();
                    obj.color = dt.Rows[i]["color"].ToString();
                    obj.size = dt.Rows[i]["size"].ToString();
                    obj.styleno = dt.Rows[i]["type"].ToString();

                    obj.step = "X";   //目前只有X线才暂存
                    decimal qty = decimal.Parse((dt.Rows[i]["qty2"].ToString()));
                    obj.pairqty = qty;
                    obj.checktype = checktype;

                    // obj.lastmodifiedtime =   DateTime.Now;
                    //  obj.user = user;        
                    obj.workgroup = workGroup;

                    //insert opening box detail
                    localDal.DoInsert<tinplinewarehouse>(obj);

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

        #region 废弃
        public void InsertOpenBoxGroup(DataTable reasoncode)
        {
            try
            {
                dbInstance.BeginTransaction();

                //和收货明细比较

                //如果不存在（carton/style/color/size） 
                //err:1001   该箱号不存在
                //err:1002   该箱不存在这种款式/颜色/尺码的鞋子
                //err:1003   数量不对



                //如果相等则 记录开箱明细
                //localDal.DoInsert<tmdlreasoncode>(reasoncode);




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
        public String OpenBoxCheckGroupCounter(String cartonno, String poid)
        {

            try
            {
                dbInstance.BeginTransaction();
                String grpCount = localDal.OpenBoxCheckGroupCounter(cartonno, poid);
                return grpCount;
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
        public DataSet getGroupDetail(string custorderno, string cartonno)
        {
            bool res = false;
            try
            {
                dbInstance.BeginTransaction();



                List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                        new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno} 
                    };
                DataSet ctlDtl = baseDal.GetSelectedRecords<tinppackingrecdtl>(lstParam, "tinppackingrecdtl", true, 1000);




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

        #endregion

        public bool OpenBoxDeleteBox(string customer, string cartonno, string poid, string user,string workgroup)
        {
            bool res = false;
            try
            {
                dbInstance.BeginTransaction();
                OpenBoxDal dal = new OpenBoxDal(dbInstance);
                 //get detail record of opening  box  --tinppackingrecdtl
                List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=poid},
                        new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                        new MESParameterInfo(){ParamName="pktype",ParamValue=MES_PackingType.Unpacking.ToString()},
                         new MESParameterInfo(){ParamName="customerid",ParamValue= customer} 
                    };
                List<tinppackingrecdtl> ctlDtl = baseDal.GetSelectedObjects<tinppackingrecdtl>(lstParam);
                //sum qty

                for (int i = 0; i < ctlDtl.Count; i++)
                {
                    //process wip---------------
                    WipDal wip = new WipDal(dbInstance);
                    wip.SaveOrUpdate(customer, ctlDtl[i].custorderno, ctlDtl[i].styleno, ctlDtl[i].color, ctlDtl[i].size, "I", workgroup, -1 * (int)ctlDtl[i].pairqty);
                }
                //delete opening detail
                baseDal.DoDelete<tinppackingrecdtl>(lstParam);
                //delete opening header
                if (ctlDtl.Count > 0)
                {
                    string sysid = ctlDtl[0].pksysid;
                    List<MESParameterInfo> lstParam2 = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="pksysid",ParamValue=sysid}  };
                    baseDal.DoDelete<tinppackingrec>(lstParam2);

                    //update carton-location of receiving 
                    localDal.UpdateCartonLocation(customer,poid, cartonno, user, MES_CartonLocation.Warehouse.ToString());
                }
                dbInstance.Commit();
                return true;
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


        public int getWipQtyByPo(string custorderno, string styleno, string size, string color)
        {
            bool res = false;
            try
            {
                WipDal dal = new WipDal(this.dbInstance);

                DataSet ctlDtl = dal.GetGoodWIP(custorderno, styleno, size, color);

                if (ctlDtl.Tables[0].Rows.Count <= 0)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(ctlDtl.Tables[0].Rows[0]["pairqty"].ToString());
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
        /**获取套装信息*/
        public DataSet GetMixDetail(string customer, string custorderno, string cartonno)
        {
            bool res = false;
            try
            {
                dbInstance.BeginTransaction();
                DataSet ctlDtl = localDal.GetMixDetail( customer,custorderno, cartonno);
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

        /** 是否已经开箱*/
        public bool isOpened(string customer, string custorderno, string cartonno)
        {
            try
            {
                if (localDal.isOpened(customer, custorderno, cartonno))
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

        /** 是否已经装箱或封箱*/
        public bool isBoxing(string customer, string custorderno, string cartonno)
        {
            try
            {
                if (localDal.isBoxing(customer, custorderno, cartonno))
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
        /**删除未装箱信息*/
        public bool DeleteBox(string customer, string cartonno, string poid, string user,string workgroup)
        {
            bool res = false;
            try
            {
                #region 没有开过箱
                if (!isOpened(customer, poid, cartonno))
                {
                    return true;
                }
                #endregion


                if (!isBoxing(customer, poid, cartonno))
                {
                    #region  开过箱但没有封箱
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

                    //get detail record of opening  box  --tinppackingrecdtl
                    List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=poid},
                        new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                         new MESParameterInfo(){ParamName="pktype",ParamValue=MES_PackingType.Unpacking.ToString()},
                         new MESParameterInfo(){ParamName="customerid",ParamValue= customer} 
                    };
                    List<tinppackingrecdtl> ctlDtl = baseDal.GetSelectedObjects<tinppackingrecdtl>(lstParam);
                    //sum qty

                    for (int i = 0; i < ctlDtl.Count; i++)
                    {
                        //process wip---------------
                        WipDal wip = new WipDal(dbInstance);
                        wip.SaveOrUpdate(customer, ctlDtl[i].custorderno, ctlDtl[i].styleno, ctlDtl[i].color, ctlDtl[i].size, "I", workgroup, -1 * (int)ctlDtl[i].pairqty, checktype);
                    }
                    //delete opening detail
                    baseDal.DoDelete<tinppackingrecdtl>(lstParam);
                    //delete opening header
                    if (ctlDtl.Count > 0)
                    {
                        string sysid = ctlDtl[0].pksysid;
                        List<MESParameterInfo> lstParam2 = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="pksysid",ParamValue=sysid}  };
                        baseDal.DoDelete<tinppackingrec>(lstParam2);

                        //update carton-location of receiving 
                        localDal.UpdateCartonLocation(customer,poid, cartonno, user, MES_CartonLocation.Warehouse.ToString());
                    }

                    dbInstance.Commit();
                    return true;
                    #endregion
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

        /**取消开箱*/
        public bool cancelOpen(string customer, string cartonno, string poid, string user)
        {
            bool res = false;
            try
            {
                #region 没有开过箱
                if (!isOpened(customer, poid, cartonno))
                {
                    return true;
                }
                #endregion


                if (!isBoxing(customer, poid, cartonno))
                {
                    #region  开过箱但没有封箱
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

                    //get detail record of opening  box  --tinppackingrecdtl
                    List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="custorderno",ParamValue=poid},
                        new MESParameterInfo(){ParamName="cartonno",ParamValue=cartonno},
                         new MESParameterInfo(){ParamName="pktype",ParamValue=MES_PackingType.Unpacking.ToString()},
                         new MESParameterInfo(){ParamName="customerid",ParamValue= customer} 
                    };
                    List<tinppackingrecdtl> ctlDtl = baseDal.GetSelectedObjects<tinppackingrecdtl>(lstParam);

                    string pksysid = ctlDtl[0].pksysid;

                    List<MESParameterInfo> lstParam1 = new List<MESParameterInfo>() { 
                         new MESParameterInfo(){ParamName="pksysid",ParamValue=pksysid} 
                    };
                    List<tinppackingrec> ctlDtl1 = baseDal.GetSelectedObjects<tinppackingrec>(lstParam1);
                    string oldWorkGroup = ctlDtl1[0].workgroup;

                    //sum qty

                    for (int i = 0; i < ctlDtl.Count; i++)
                    {
                        //process wip---------------
                        WipDal wip = new WipDal(dbInstance);
                        wip.SaveOrUpdate(customer, ctlDtl[i].custorderno, ctlDtl[i].styleno, ctlDtl[i].color, ctlDtl[i].size, "I", oldWorkGroup, -1 * (int)ctlDtl[i].pairqty, checktype);
                    }
                    //delete opening detail
                    baseDal.DoDelete<tinppackingrecdtl>(lstParam);
                    //delete opening header
                    if (ctlDtl.Count > 0)
                    {
                        string sysid = ctlDtl[0].pksysid;
                        List<MESParameterInfo> lstParam2 = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){ParamName="pksysid",ParamValue=sysid}  };
                        baseDal.DoDelete<tinppackingrec>(lstParam2);

                        //update carton-location of receiving 
                        localDal.UpdateCartonLocation(customer, poid, cartonno, user, MES_CartonLocation.Warehouse.ToString());
                    }

                    dbInstance.Commit();
                    return true;
                    #endregion
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



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Services.MDL;
using System.Data;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Common;
using GENLSYS.MES.Services.SEC;
using GENLSYS.MES.Services.SYS;

namespace GENLSYS.MES.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wsPAD" in code, svc and config file together.
    public class wsPAD : IwsPAD
    {
        public string GetFuncByUser(ContextInfo contextInfo){
           string step = "";
            try
            {
                contextInfo.Action = MES_ActionType.Query;
                RoleStepBll bll = new RoleStepBll(contextInfo);
                bll.CallAccessControl();
                DataSet rs = bll.GetStepsByUserId(contextInfo.CurrentUser);
                GC.Collect();
                foreach (DataRow row in rs.Tables[0].Rows)
                {
                    if (step.Length == 0)
                    {
                        step = row["funcid"].ToString();
                    }
                    else
                    {
                        step = step + "|" + row["funcid"];
                    }
                }
                return step;
            }
            catch (Exception ex)
            {
                return "*";
            }
        }

        public DataSet GetPOListByStep(string funcid, ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        {
            try
            {
                contextInfo.Action = MES_ActionType.Query;
                GENLSYS.MES.Services.Inspection.INP.POBll bll = new GENLSYS.MES.Services.Inspection.INP.POBll(contextInfo);
                bll.CallAccessControl();
                DataSet rs = bll.getPODtl(funcid, contextInfo.CurrentUser, contextInfo.WorkGroup,lstParameters);
                GC.Collect();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
 
        //按订单获得颜色列表

        public string[] GetColorListByPO(string po, ContextInfo contextInfo)
        {
            try
            {
                contextInfo.Action = MES_ActionType.Query;
                GENLSYS.MES.Services.Inspection.INP.POBll bll = new GENLSYS.MES.Services.Inspection.INP.POBll(contextInfo);
                bll.CallAccessControl();
                DataSet rs = bll.getColorByPo(po);
                GC.Collect();
                DataTable dt = rs.Tables[0];

                List<  string>  list = new List< string> ();

                foreach (DataRow row in dt.Rows)
                {
                  string color=  row["color"].ToString();
                  list.Add(color);
                }


                return list.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //按订单获得型号列表

        public string[] GetTypeListByPO(string po, ContextInfo contextInfo)
        {
            try
            {
                contextInfo.Action = MES_ActionType.Query;
                GENLSYS.MES.Services.Inspection.INP.POBll bll = new GENLSYS.MES.Services.Inspection.INP.POBll(contextInfo);
                bll.CallAccessControl();
                DataSet rs = bll.getTypeByPo(po);
                GC.Collect();
                DataTable dt = rs.Tables[0];

                List<string> list = new List<string>();

                foreach (DataRow row in dt.Rows)
                {
                    string color = row["styleno"].ToString();
                    list.Add(color);
                }


                return list.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        //按订单获得size列表
        public string[] GetSizeListByPO(string po, ContextInfo contextInfo)
        {
            try
            {
                contextInfo.Action = MES_ActionType.Query;
                GENLSYS.MES.Services.Inspection.INP.POBll bll = new GENLSYS.MES.Services.Inspection.INP.POBll(contextInfo);
                bll.CallAccessControl();
                DataSet rs = bll.getSizeByPo(po);
                GC.Collect();
                DataTable dt = rs.Tables[0];

                List<string> list = new List<string>();

                foreach (DataRow row in dt.Rows)
                {
                    string color = row["size"].ToString();
                    list.Add(color);
                }


                return list.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        //开箱时的和大货入库比较/看是否已经开过箱子
        public String OpenBoxCheckGroup(DataTable dt)
        {
             ContextInfo contextInfo = new ContextInfo();
            contextInfo.Action = MES_ActionType.Query;
            GENLSYS.MES.Services.Inspection.INP.OpenBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.OpenBoxBll(contextInfo);
            bll.CallAccessControl();
            String rs = bll.CheckGroup(dt);
            GC.Collect();
            return rs;
        }
        //开箱时保存 by carton
        public bool OpenBoxSaveCarton(DataTable dt, string trayID ,ContextInfo contextInfo)
        {
       
            contextInfo.Action = MES_ActionType.Query;
            GENLSYS.MES.Services.Inspection.INP.OpenBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.OpenBoxBll(contextInfo);
            bll.CallAccessControl();
            bool rs = bll.openBoxSave(dt,trayID, contextInfo.CurrentUser, contextInfo.WorkGroup);
            GC.Collect();
            return rs;
        }
         //开箱时修改
        public void OpenBoxUpdateCarton(DataTable dt, string trayID,ContextInfo contextInfo, string customer, string cartonno, string poid)
        {
       
            contextInfo.Action = MES_ActionType.Query;
            GENLSYS.MES.Services.Inspection.INP.OpenBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.OpenBoxBll(contextInfo);
            bll.CallAccessControl();
            bll.openBoxUpdate( dt,trayID, contextInfo.CurrentUser,  contextInfo.WorkGroup, customer,   cartonno,  poid);
            GC.Collect();
            return ;
        }

         //开箱时暂存线上
        public bool lineWarehouseSave(DataTable dt, ContextInfo contextInfo)
        {
       
            contextInfo.Action = MES_ActionType.Query;
            GENLSYS.MES.Services.Inspection.INP.OpenBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.OpenBoxBll(contextInfo);
            bll.CallAccessControl();
           bool res =  bll.lineWarehouseSave(dt ,contextInfo.CurrentUser,  contextInfo.WorkGroup);
            GC.Collect();
            return res;
        }
        //删除未装箱信息
         public bool DeleteBox(string customer, string cartonno, string poid, string user, ContextInfo contextInfo)
        {
       
            contextInfo.Action = MES_ActionType.Query;
            GENLSYS.MES.Services.Inspection.INP.OpenBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.OpenBoxBll(contextInfo);
            bll.CallAccessControl();
            bool res = bll.DeleteBox(customer, cartonno, poid, user, contextInfo.WorkGroup);
            GC.Collect();
            return res;
        }

         //是否已经封箱
         public bool isBoxing(string customer,  string poid,string cartonno,  ContextInfo contextInfo)
         {

             contextInfo.Action = MES_ActionType.Query;
             GENLSYS.MES.Services.Inspection.INP.OpenBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.OpenBoxBll(contextInfo);
             bll.CallAccessControl();
             bool res = bll.isBoxing(customer,  poid ,cartonno );
             GC.Collect();
             return res;
         }
        //套装信息
         public DataSet GetMixBox(string customer, string poid, string cartonno, ContextInfo contextInfo)
         {
             try
             {
                 contextInfo.Action = MES_ActionType.Query;
                 GENLSYS.MES.Services.Inspection.INP.OpenBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.OpenBoxBll(contextInfo);
                 bll.CallAccessControl();
                 DataSet rs = bll.GetMixDetail(customer,poid,cartonno);
                 GC.Collect();
                 return rs;
             }
             catch (Exception ex)
             {
                 return null;
             }

         }


         //开箱明细信息
         public DataSet GetOpenBox(string customer, string poid, string cartonno,string action,string currStep, ContextInfo contextInfo)
         {
             try
             {
                 contextInfo.Action = MES_ActionType.Query;
                 GENLSYS.MES.Services.Inspection.INP.AssyBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.AssyBoxBll(contextInfo);
                 bll.CallAccessControl();
                 DataSet rs = bll.getOpenDetail(customer, poid, cartonno, action, currStep);
                 GC.Collect();
                 return rs;
             }
             catch (Exception ex)
             {
                 return null;
             }

         }

         //封箱时保存 by carton
         public bool PackBoxSaveCarton(DataTable dt,string trayID, ContextInfo contextInfo)
         {

             contextInfo.Action = MES_ActionType.Query;
             GENLSYS.MES.Services.Inspection.INP.AssyBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.AssyBoxBll(contextInfo);
             bll.CallAccessControl();
             bool rs = bll.AssyBoxSave(dt,trayID, contextInfo.CurrentUser, contextInfo.WorkGroup);
             GC.Collect();
             return rs;
         }

         //Move时保存 by carton
         public bool MoveBoxSaveCarton(DataTable dt, string trayID,string workgroup, ContextInfo contextInfo)
         {

             contextInfo.Action = MES_ActionType.Query;
             GENLSYS.MES.Services.Inspection.INP.AssyBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.AssyBoxBll(contextInfo);
             bll.CallAccessControl();
             bool rs = bll.MoveBoxSave(dt, trayID ,contextInfo.CurrentUser, workgroup , contextInfo.WorkGroup);
             GC.Collect();
             return rs;
         }



         //封箱时防呆
         public String PackBoxCheckGroup(DataTable dt)
         {
             ContextInfo contextInfo = new ContextInfo();
             contextInfo.Action = MES_ActionType.Query;
             GENLSYS.MES.Services.Inspection.INP.AssyBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.AssyBoxBll(contextInfo);
             bll.CallAccessControl();
             String rs = bll.CheckGroup(dt);
             GC.Collect();
             return rs;
         }

         //装箱时防呆
         public String MoveBoxCheckGroup(DataTable dt)
         {
             ContextInfo contextInfo = new ContextInfo();
             contextInfo.Action = MES_ActionType.Query;
             GENLSYS.MES.Services.Inspection.INP.AssyBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.AssyBoxBll(contextInfo);
             bll.CallAccessControl();
             String rs = bll.MoveBoxCheckGroup(dt);
             GC.Collect();
             return rs;
         }
        
         //是否已经ship
         public bool isShipped(string customer, string poid, string cartonno, ContextInfo contextInfo)
         {

             contextInfo.Action = MES_ActionType.Query;
             GENLSYS.MES.Services.Inspection.INP.AssyBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.AssyBoxBll(contextInfo);
             bll.CallAccessControl();
             bool res = bll.isShipped(customer,  poid ,cartonno );
             GC.Collect();
             return res;
         }

        //当前WIP
         public int getWIPByPO(string customerid, string custorderno, string styleno, string color, string size, string workgroup, string action, string currStep, ContextInfo contextInfo)
         {

             contextInfo.Action = MES_ActionType.Query;
             GENLSYS.MES.Services.Inspection.INP.AssyBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.AssyBoxBll(contextInfo);
             bll.CallAccessControl();
              int wip =bll.getWIPByPO(  customerid,   custorderno,   styleno,   color,   size,   workgroup,   action,   currStep);
             GC.Collect();
             return wip;
         }

         public DataSet getLineWarehouse(string customer, string poid, string cartonno, string workgroup,ContextInfo contextInfo)
         {
             try
             {
                 contextInfo.Action = MES_ActionType.Query;
                 GENLSYS.MES.Services.Inspection.INP.AssyBoxBll   bll = new GENLSYS.MES.Services.Inspection.INP.AssyBoxBll(contextInfo);
                 bll.CallAccessControl();
                 DataSet rs = bll.getLineWarehouse(customer, poid, cartonno, workgroup);
                 GC.Collect();
                 return rs;
             }
             catch (Exception ex)
             {
                 return null;
             }

         }

        //获得可以cancel的箱子
         public DataSet GetCancelableCarton(  ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
         {
             try
             {
                 contextInfo.Action = MES_ActionType.Query;
                 GENLSYS.MES.Services.Inspection.INP.POBll bll = new GENLSYS.MES.Services.Inspection.INP.POBll(contextInfo);
                 bll.CallAccessControl();
                 DataSet rs = bll.GetCancelableCarton(  contextInfo.CurrentUser, lstParameters);
                 GC.Collect();
                 return rs;
             }
             catch (Exception ex)
             {
                 return null;
             }

         }

         public bool CancelPack(string customer, string cartonno, string poid, string user,ContextInfo contextInfo)
         {
             try
             {
                 contextInfo.Action = MES_ActionType.Query;
                 GENLSYS.MES.Services.Inspection.INP.AssyBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.AssyBoxBll(contextInfo);
                 bll.CallAccessControl();
                 bool rs = bll.CancelPack(customer,   cartonno,   poid,   user);
                 GC.Collect();
                 return rs;
             }
             catch (Exception ex)
             {
                 return false;
             }
         }

         public bool CancelMove(string customer, string cartonno, string poid, string user, ContextInfo contextInfo)
         {
             try
             {
                 contextInfo.Action = MES_ActionType.Query;
                 GENLSYS.MES.Services.Inspection.INP.AssyBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.AssyBoxBll(contextInfo);
                 bll.CallAccessControl();
                 bool rs = bll.CancelMove(customer, cartonno, poid, user);
                 GC.Collect();
                 return rs;
             }
             catch (Exception ex)
             {
                 return false;
             }
         }

         //删除未装箱信息
         public bool CancelOpen(string customer, string cartonno, string poid, string user, ContextInfo contextInfo)
         {

             contextInfo.Action = MES_ActionType.Query;
             GENLSYS.MES.Services.Inspection.INP.OpenBoxBll bll = new GENLSYS.MES.Services.Inspection.INP.OpenBoxBll(contextInfo);
             bll.CallAccessControl();
             bool res = bll.cancelOpen(customer, cartonno, poid, user );
             GC.Collect();
             return res;
         }
    }


    
}

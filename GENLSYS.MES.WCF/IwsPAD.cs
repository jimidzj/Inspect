using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.WCF
{
      [ServiceContract]
    public interface IwsPAD
    {
 
        //获得用户权限
        [OperationContract]
         string GetFuncByUser(ContextInfo contextInfo);
       
        //获得某站别需要处理的PO
        [OperationContract]
        DataSet GetPOListByStep(string funcid, ContextInfo contextInfo,  List<MESParameterInfo> lstParameters) ;

        //按订单获得颜色列表
            [OperationContract]
        string[] GetColorListByPO(string po, ContextInfo contextInfo);

       
        //按订单获得型号列表
            [OperationContract]
        string[] GetTypeListByPO(string po, ContextInfo contextInfo);


       //开箱时的和大货入库比较
            [OperationContract]
        String OpenBoxCheckGroup(DataTable dt);

       //开箱时save carton
            [OperationContract]
            bool OpenBoxSaveCarton(DataTable dt, string trayID, ContextInfo contextInfo);
         
       //开箱时修改
            [OperationContract]
            void OpenBoxUpdateCarton(DataTable dt, string trayID, ContextInfo contextInfo, string customer, string cartonno, string poid);

        //开箱时暂存线上
            [OperationContract]
            bool lineWarehouseSave(DataTable dt, ContextInfo contextInfo);
        //删除未装箱信息
            [OperationContract]
            bool DeleteBox(string customer, string cartonno, string poid, string user, ContextInfo contextInfo);

         //是否已经封箱
            [OperationContract]
            bool isBoxing(string customer, string poid, string cartonno, ContextInfo contextInfo);

          //套装信息
            [OperationContract]
            DataSet GetMixBox(string customer, string poid, string cartonno, ContextInfo contextInfo);

            //开箱信息
            [OperationContract]
            DataSet GetOpenBox(string customer, string poid, string cartonno,string action,string currStep, ContextInfo contextInfo);

            //封箱时save carton
            [OperationContract]
            bool PackBoxSaveCarton(DataTable dt,string trayID, ContextInfo contextInfo);

            //封箱时防呆
            [OperationContract]
            String PackBoxCheckGroup(DataTable dt);

          
            //是否已经ship
            [OperationContract]
            bool isShipped(string customer, string poid, string cartonno, ContextInfo contextInfo);
           
            //是否已经ship
            [OperationContract]
            String MoveBoxCheckGroup(DataTable dt);

           //move box Save
            [OperationContract]
              bool MoveBoxSaveCarton(DataTable dt, string trayID , string workgroup, ContextInfo contextInfo);

            //Get WIP by PO
            [OperationContract]
            int getWIPByPO(string customerid, string custorderno, string styleno, string color, string size, string workgroup, string action, string currStep, ContextInfo contextInfo);
    
            //Get Size by PO
            [OperationContract]
            string[] GetSizeListByPO(string po, ContextInfo contextInfo);

            [OperationContract]
            DataSet getLineWarehouse(string customer, string poid, string cartonno, string workgroup, ContextInfo contextInfo);
       
  
        //获得可以cancel的箱子
            [OperationContract]
            DataSet GetCancelableCarton(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

           [OperationContract]
           bool CancelPack(string customer, string cartonno, string poid, string user, ContextInfo contextInfo);

           [OperationContract]
           bool CancelMove(string customer, string cartonno, string poid, string user, ContextInfo contextInfo);
          
     
           [OperationContract]
           bool CancelOpen(string customer, string cartonno, string poid, string user, ContextInfo contextInfo);
      
      }
}

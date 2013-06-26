using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using System.Data;

namespace GENLSYS.MES.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IwsWHS" in both code and config file together.
    [ServiceContract]
    public interface IwsWHS
    {
        //#region WOType
        //[OperationContract]
        //List<twhswotype> GetWOTypeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //DataSet GetWOTypeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //twhswotype GetSingleWOType(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //void DoInsertWOType(ContextInfo contextInfo, twhswotype location);

        //[OperationContract]
        //void DoUpdateWOType(ContextInfo contextInfo, twhswotype location);

        //[OperationContract]
        //void DoDeleteWOType(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        //#endregion

        //#region Warehouse
        //[OperationContract]
        //List<twhswarehouse> GetWarehouseList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //DataSet GetWarehouseRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //twhswarehouse GetSingleWarehouse(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //void DoInsertWarehouse(ContextInfo contextInfo, twhswarehouse location);

        //[OperationContract]
        //void DoUpdateWarehouse(ContextInfo contextInfo, twhswarehouse location);

        //[OperationContract]
        //void DoDeleteWarehouse(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        //#endregion

        //#region 
        //[OperationContract]
        //List<twhslocation> GetLocationList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //DataSet GetLocationRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //twhslocation GetSingleLocation(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //void DoInsertLocation(ContextInfo contextInfo, twhslocation location);

        //[OperationContract]
        //void DoUpdateLocation(ContextInfo contextInfo, twhslocation location);

        //[OperationContract]
        //void DoDeleteLocation(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        //#endregion

        //#region Warehouse Order
        //[OperationContract]
        //List<twhsorder> GetWarehouseOrderList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //DataSet GetWarehouseOrderRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //twhsorder GetSingleWarehouseOrder(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //void DoInsertWarehouseOrder(ContextInfo contextInfo, twhsorder order);

        //[OperationContract]
        //void DoUpdateWarehouseOrder(ContextInfo contextInfo, twhsorder order);

        //[OperationContract]
        //void DoDeleteWarehouseOrder(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);

        //[OperationContract]
        //DataSet GetWarehouseOrderDetailRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        //#endregion

        //#region Stock
        //[OperationContract]
        //DataSet GetStockRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters);
        //#endregion
    }
}

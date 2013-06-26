using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Common;
using System.Data;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Services.Inspection.WHS;

namespace GENLSYS.MES.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wsWHS" in code, svc and config file together.
    public class wsWHS : IwsWHS
    {
        //#region WOType
        //public List<twhswotype> GetWOTypeList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    WOTypeBll bll = new WOTypeBll(contextInfo);
        //    bll.CallAccessControl();
        //    List<twhswotype> rs = bll.GetSelectedObjects<twhswotype>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}

        //public DataSet GetWOTypeRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    WOTypeBll bll = new WOTypeBll(contextInfo);
        //    bll.CallAccessControl();
        //    DataSet rs = bll.GetSelectedRecords<twhswotype>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}

        //public twhswotype GetSingleWOType(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    WOTypeBll bll = new WOTypeBll(contextInfo);
        //    bll.CallAccessControl();
        //    twhswotype rs = bll.GetSingleObject<twhswotype>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}

        //public void DoInsertWOType(ContextInfo contextInfo, twhswotype location)
        //{
        //    contextInfo.Action = MES_ActionType.Insert;
        //    WOTypeBll bll = new WOTypeBll(contextInfo);
        //    bll.CallAccessControl();
        //    bll.DoInsert(location);
        //    GC.Collect();
        //}
        //public void DoUpdateWOType(ContextInfo contextInfo, twhswotype location)
        //{
        //    contextInfo.Action = MES_ActionType.Update;
        //    WOTypeBll bll = new WOTypeBll(contextInfo);
        //    bll.CallAccessControl();
        //    bll.DoUpdate(location);
        //    GC.Collect();
        //}

        //public void DoDeleteWOType(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Delete;
        //    WOTypeBll bll = new WOTypeBll(contextInfo);
        //    bll.CallAccessControl();
        //    bll.DoDelete<twhswotype>(lstParameters);
        //    GC.Collect();
        //}
        //#endregion

        //#region Warehouse
        //public List<twhswarehouse> GetWarehouseList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    WarehouseBll bll = new WarehouseBll(contextInfo);
        //    bll.CallAccessControl();
        //    List<twhswarehouse> rs = bll.GetSelectedObjects<twhswarehouse>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}

        //public DataSet GetWarehouseRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    WarehouseBll bll = new WarehouseBll(contextInfo);
        //    bll.CallAccessControl();
        //    DataSet rs = bll.GetSelectedRecords<twhswarehouse>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}

        //public twhswarehouse GetSingleWarehouse(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    WarehouseBll bll = new WarehouseBll(contextInfo);
        //    bll.CallAccessControl();
        //    twhswarehouse rs = bll.GetSingleObject<twhswarehouse>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}

        //public void DoInsertWarehouse(ContextInfo contextInfo, twhswarehouse location)
        //{
        //    contextInfo.Action = MES_ActionType.Insert;
        //    WarehouseBll bll = new WarehouseBll(contextInfo);
        //    bll.CallAccessControl();
        //    bll.DoInsert(location);
        //    GC.Collect();
        //}
        //public void DoUpdateWarehouse(ContextInfo contextInfo, twhswarehouse location)
        //{
        //    contextInfo.Action = MES_ActionType.Update;
        //    WarehouseBll bll = new WarehouseBll(contextInfo);
        //    bll.CallAccessControl();
        //    bll.DoUpdate(location);
        //    GC.Collect();
        //}

        //public void DoDeleteWarehouse(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Delete;
        //    WarehouseBll bll = new WarehouseBll(contextInfo);
        //    bll.CallAccessControl();
        //    bll.DoDelete<twhswarehouse>(lstParameters);
        //    GC.Collect();
        //}
        //#endregion

        //#region Location
        //public List<twhslocation> GetLocationList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    LocationBll bll = new LocationBll(contextInfo);
        //    bll.CallAccessControl();
        //    List<twhslocation> rs = bll.GetSelectedObjects<twhslocation>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}

        //public DataSet GetLocationRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    LocationBll bll = new LocationBll(contextInfo);
        //    bll.CallAccessControl();
        //    DataSet rs = bll.GetSelectedRecords<twhslocation>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}

        //public twhslocation GetSingleLocation(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    LocationBll bll = new LocationBll(contextInfo);
        //    bll.CallAccessControl();
        //    twhslocation rs = bll.GetSingleObject<twhslocation>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}

        //public void DoInsertLocation(ContextInfo contextInfo, twhslocation location)
        //{
        //    contextInfo.Action = MES_ActionType.Insert;
        //    LocationBll bll = new LocationBll(contextInfo);
        //    bll.CallAccessControl();
        //    bll.DoInsert(location);
        //    GC.Collect();
        //}
        //public void DoUpdateLocation(ContextInfo contextInfo, twhslocation location)
        //{
        //    contextInfo.Action = MES_ActionType.Update;
        //    LocationBll bll = new LocationBll(contextInfo);
        //    bll.CallAccessControl();
        //    bll.DoUpdate(location);
        //    GC.Collect();
        //}

        //public void DoDeleteLocation(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Delete;
        //    LocationBll bll = new LocationBll(contextInfo);
        //    bll.CallAccessControl();
        //    bll.DoDelete<twhslocation>(lstParameters);
        //    GC.Collect();
        //}
        //#endregion

        //#region Warehouse Order
        //public List<twhsorder> GetWarehouseOrderList(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    WarehouseOrderBll bll = new WarehouseOrderBll(contextInfo);
        //    bll.CallAccessControl();
        //    List<twhsorder> rs = bll.GetSelectedObjects<twhsorder>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}

        //public DataSet GetWarehouseOrderRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    WarehouseOrderBll bll = new WarehouseOrderBll(contextInfo);
        //    bll.CallAccessControl();
        //    DataSet rs = bll.GetSelectedRecords<twhsorder>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}

        //public twhsorder GetSingleWarehouseOrder(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    WarehouseOrderBll bll = new WarehouseOrderBll(contextInfo);
        //    bll.CallAccessControl();
        //    twhsorder rs = bll.GetSingleObject<twhsorder>(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}

        //public void DoInsertWarehouseOrder(ContextInfo contextInfo, twhsorder order)
        //{
        //    contextInfo.Action = MES_ActionType.Insert;
        //    WarehouseOrderBll bll = new WarehouseOrderBll(contextInfo);
        //    bll.CallAccessControl();
        //    bll.DoInsert(order);
        //    GC.Collect();
        //}
        //public void DoUpdateWarehouseOrder(ContextInfo contextInfo, twhsorder order)
        //{
        //    contextInfo.Action = MES_ActionType.Update;
        //    WarehouseOrderBll bll = new WarehouseOrderBll(contextInfo);
        //    bll.CallAccessControl();
        //    bll.DoUpdate(order);
        //    GC.Collect();
        //}

        //public void DoDeleteWarehouseOrder(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Delete;
        //    WarehouseOrderBll bll = new WarehouseOrderBll(contextInfo);
        //    bll.CallAccessControl();
        //    bll.DoDelete<twhsorder>(lstParameters);
        //    GC.Collect();
        //}

        //public DataSet GetWarehouseOrderDetailRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    WarehouseOrderBll bll = new WarehouseOrderBll(contextInfo);
        //    bll.CallAccessControl();
        //    DataSet rs = bll.GetWarehouseOrderDetailRecords(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}
        //#endregion

        //#region Stock
        //public DataSet GetStockRecords(ContextInfo contextInfo, List<MESParameterInfo> lstParameters)
        //{
        //    contextInfo.Action = MES_ActionType.Query;
        //    StockBll bll = new StockBll(contextInfo);
        //    bll.CallAccessControl();
        //    DataSet rs = bll.GetStockRecords(lstParameters);
        //    GC.Collect();
        //    return rs;
        //}
        //#endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility.Database;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class CustOrderHistoryBll : BaseBll
    {
        public CustOrderHistoryBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            baseDal = new CustOrderHistoryDal(dbInstance);
        }

        public CustOrderHistoryBll(DBInstance _dbInstance, ContextInfo contextInfo)
            : base(contextInfo)
        {
            dbInstance = _dbInstance;
            baseDal = new CustOrderHistoryDal(dbInstance);
        }

        public void WriteHistory(string eventName, string eventGroup,string customerid, string custOrderNo,
            string cartonNo, string styleNo, string color, string size, decimal cartonQty,
            decimal? pairQty, string refSysId, string remark)
        {
            tinpcustorderhistory history = new tinpcustorderhistory();
            history.customerid = customerid;
            history.cartonno = cartonNo;
            history.cartonqty = cartonQty;
            history.color = color;
            history.custorderno = custOrderNo;
            history.eventgroup = eventGroup;
            history.eventname = eventName;
            history.pairqty = pairQty;
            history.refsysid = refSysId;
            history.remark = remark;
            history.size = size;
            history.styleno = styleNo;

            history.eventtime = Function.GetCurrentTime();
            history.eventuser = Function.GetCurrentUser();
            history.ohsysid = Function.GetGUID();
            history.shift = CurrentContextInfo.Shift;
            history.workgroup = CurrentContextInfo.WorkGroup;

            baseDal.DoInsert<tinpcustorderhistory>(history);
        }

        public void WriteHistory(tinpcustorderhistory history)
        {
            history.eventtime = Function.GetCurrentTime();
            history.eventuser = Function.GetCurrentUser();
            history.ohsysid = Function.GetGUID();
            history.shift = CurrentContextInfo.Shift;
            history.workgroup = CurrentContextInfo.WorkGroup;

            baseDal.DoInsert<tinpcustorderhistory>(history);
        }

        public void RemoveHistory(string eventName, string refsysid)
        {
            List<MESParameterInfo> lstParam = new List<MESParameterInfo>() { 
                new MESParameterInfo(){ParamName="eventname",ParamValue=eventName},
                new MESParameterInfo(){ParamName="refsysid",ParamValue=refsysid}
            };

            baseDal.DoDelete<tinpcustorderhistory>(lstParam);
        }
    }
}

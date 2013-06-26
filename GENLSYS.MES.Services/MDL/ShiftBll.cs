using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.MDL;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;

namespace GENLSYS.MES.Services.MDL
{
    public class ShiftBll : BaseBll
    {
        public ShiftBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            baseDal = new ShiftDal(dbInstance);
        }

        public DateTime GetShiftStartTime(string shift)
        {
            try
            {
                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>();
                lstParameter.Add(new MESParameterInfo() { 
                    ParamName="shift",
                    ParamValue=shift
                });
                tmdlshift shiftObj = baseDal.GetSingleObject<tmdlshift>(lstParameter, string.Empty, true);

                if (shiftObj == null) return DateTime.Now;

                DateTime d1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + shiftObj.starttime.Value.ToString("HH:mm:ss"));
                DateTime d2 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + shiftObj.endtime.Value.ToString("HH:mm:ss"));

                if (d1 > DateTime.Now)
                    return d1.AddDays(-1);
                else
                    return d1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime GetShiftEndTime(string shift)
        {
            try
            {
                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>();
                lstParameter.Add(new MESParameterInfo()
                {
                    ParamName = "shift",
                    ParamValue = shift
                });
                tmdlshift shiftObj = baseDal.GetSingleObject<tmdlshift>(null, string.Empty, true);

                if (shiftObj == null) return DateTime.Now;

                DateTime d1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + shiftObj.starttime.Value.ToString("HH:mm:ss"));
                DateTime d2 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + shiftObj.endtime.Value.ToString("HH:mm:ss"));

                if (d2 < DateTime.Now)
                    return d2.AddDays(1);
                else
                    return d2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

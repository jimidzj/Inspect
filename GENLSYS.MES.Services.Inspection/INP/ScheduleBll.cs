using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using GENLSYS.MES.DataContracts;
using System.Data;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class ScheduleBll: BaseBll
    {
        ScheduleDal dal;

        public ScheduleBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            dal = new ScheduleDal(dbInstance);
            baseDal = dal;
        }

        public void DoInsertSchedule(string yearmonth, List<tinpschedule> lstSchedule)
        {
            try
            {
                dbInstance.BeginTransaction();

                for (int i = 0; i < lstSchedule.Count; i++)
                {
                    baseDal.DoInsert<tinpschedule>(lstSchedule[i]);
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

        public void DoUpdateSchedule(string yearmonth, List<tinpschedule> lstSchedule)
        {
            try
            {
                dbInstance.BeginTransaction();

                //delete
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                        new MESParameterInfo(){
                            ParamName="yearmonth",
                            ParamValue=yearmonth,
                            ParamType="string"
                        }
                    };
                baseDal.DoDelete<tinpschedule>(lstParameters);

                //insert
                for (int i = 0; i < lstSchedule.Count; i++)
                {
                    baseDal.DoInsert<tinpschedule>(lstSchedule[i]);
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

        public DataSet GetDailySchedule(string startdate, string enddate)
        {
            return dal.GetDailySchedule(startdate, enddate);
        }
    }
}

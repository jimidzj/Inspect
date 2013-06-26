using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class RequestPayBll : BaseBll
    {
        private RequestPayDal localDal = null;
        private RequestPayDtlDal requestPayDtlDal = null;

        public RequestPayBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new RequestPayDal(dbInstance);
            requestPayDtlDal = new RequestPayDtlDal(dbInstance);
            baseDal = localDal;
        }

        public void DoInsertRequestPay(tinprequestpay requestPay, List<tinprequestpaydtl> lstDtl)
        {
            try
            {
                dbInstance.BeginTransaction();

                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                    new MESParameterInfo(){ParamName="shippingsysid",ParamValue=requestPay.shippingsysid}
                };
                requestPayDtlDal.DoDelete<tinprequestpaydtl>(lstParams);
                localDal.DoDelete<tinprequestpay>(lstParams);

                localDal.DoInsert<tinprequestpay>(requestPay);
                foreach (tinprequestpaydtl dtl in lstDtl)
                {
                    requestPayDtlDal.DoInsert<tinprequestpaydtl>(dtl);
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
    }
}

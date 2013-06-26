using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.Inspection.INP;
using System.Data;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Services.Inspection.INP
{
    public class PricingBll: BaseBll
    {
        private PricingDal localDal = null;
  
        public PricingBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            localDal = new PricingDal(dbInstance);
            baseDal = localDal;
        }

        public DataSet GetValidPricing(string customerid, DateTime dt)
        {
            return localDal.GetValidPricing(customerid, dt);
        }

        public DataSet GetPricingRecords(List<MESParameterInfo> lstParameters)
        {
            PricingDal pricDal = new PricingDal(dbInstance);
            return pricDal.GetPricingRecords(lstParameters);
        }

        public void DoInsertPricing(tinppricing prc, List<tinppricingdtl> lstPrcDtl,
            List<tinppricingdtldef> lstDef)
        {
            try
            {
                dbInstance.BeginTransaction();

                PricingDal prcDal = new PricingDal(dbInstance);

                prcDal.DoInsert<tinppricing>(prc);

                for (int i = 0; i < lstPrcDtl.Count; i++)
                {
                    prcDal.DoInsert<tinppricingdtl>(lstPrcDtl[i]);
                }

                for (int i = 0; i < lstDef.Count; i++)
                {
                    prcDal.DoInsert<tinppricingdtldef>(lstDef[i]);
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

        public void DoUpdatePricing(tinppricing prc, List<tinppricingdtl> lstPrcDtl,
            List<tinppricingdtldef> lstDef)
        {
            try
            {
                dbInstance.BeginTransaction();

                PricingDal prcDal = new PricingDal(dbInstance);

                prcDal.DeleteDef(prc.prisysid);
                prcDal.DeleteDtl(prc.prisysid);

                for (int i = 0; i < lstPrcDtl.Count; i++)
                {
                    prcDal.DoInsert<tinppricingdtl>(lstPrcDtl[i]);
                }

                for (int i = 0; i < lstDef.Count; i++)
                {
                    prcDal.DoInsert<tinppricingdtldef>(lstDef[i]);
                }

                if (lstDef.Count <= 0)
                {
                    prcDal.DoDelete<tinppricing>(new List<MESParameterInfo>() { 
                        new MESParameterInfo(){
                            ParamName="prisysid",ParamValue=prc.prisysid
                        }
                    });
                }
                else
                {
                    prcDal.DoUpdate<tinppricing>(prc);
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

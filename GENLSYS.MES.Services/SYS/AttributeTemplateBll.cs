using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.SYS;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;

namespace GENLSYS.MES.Services.SYS
{
    public class AttributeTemplateBll : BaseBll
    {
        AttributeTemplateDal localDal = null;
        public AttributeTemplateBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new AttributeTemplateDal(dbInstance);
            baseDal = localDal; 
        }

        public void InsertAttributeTemplate(tsysattrtplate template, List<tsysattrtplatedtl> lstAttribute)
        {
            try
            {
                dbInstance.BeginTransaction();

                //Insert header
                localDal.DoInsert<tsysattrtplate>(template);

                //Insert detail
                for (int i = 0; i < lstAttribute.Count; i++)
                {
                    localDal.DoInsert<tsysattrtplatedtl>(lstAttribute[i]);
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

        public void UpdateAttributeTemplate(tsysattrtplate template, List<tsysattrtplatedtl> lstAttribute)
        {
            try
            {
                dbInstance.BeginTransaction();

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>()
                {
                    new MESParameterInfo(){
                        ParamName="attrtplatid",
                        ParamValue=template.attrtplatid,
                        ParamType="string"
                    }
                };
                //delete detail first
                localDal.DoDelete<tsysattrtplatedtl>(lstParameters);

                //Insert header
                localDal.DoUpdate<tsysattrtplate>(template);

                //Insert detail
                for (int i = 0; i < lstAttribute.Count; i++)
                {
                    localDal.DoInsert<tsysattrtplatedtl>(lstAttribute[i]);
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

        public void DeleteAttributeTemplate(List<MESParameterInfo> lstParameters)
        {
            try
            {
                dbInstance.BeginTransaction();

                //delete detail
                localDal.DoDelete<tsysattrtplatedtl>(lstParameters);

                //detail header
                localDal.DoDelete<tsysattrtplate>(lstParameters);

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

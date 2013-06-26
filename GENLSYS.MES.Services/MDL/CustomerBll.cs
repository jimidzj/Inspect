using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.Repositories.MDL;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using GENLSYS.MES.DataContracts;

namespace GENLSYS.MES.Services.MDL
{
    public class CustomerBll:BaseBll
    {
        public CustomerBll(ContextInfo contextInfo)
            : base(contextInfo)
        {
            baseDal = new CustomerDal(dbInstance);
        }

        public DataSet GetContactRecords(List<MESParameterInfo> lstParameters)
        {
            CustomerDal custDal = new CustomerDal(dbInstance);
            return custDal.GetContactRecords(lstParameters);
        }

        public void DoInsertCustomer(tmdlcustomer customer, List<tmdlcontact> lstContact)
        {
            try
            {
                dbInstance.BeginTransaction();
                baseDal.DoInsert(customer);

                ContactDal contactDal = new ContactDal(dbInstance);
                for (int i = 0; i < lstContact.Count; i++)
                {
                    lstContact[i].customerid = customer.customerid;
                    contactDal.DoInsert<tmdlcontact>(lstContact[i]);
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

        public void DoUpdateCustomer(tmdlcustomer customer, List<tmdlcontact> lstContact)
        {
            try
            {
                dbInstance.BeginTransaction();

                ContactDal contactDal = new ContactDal(dbInstance);
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="customerid",ParamValue=customer.customerid}
                        };

                List<tmdlcontact> lstOld = contactDal.GetSelectedObjects<tmdlcontact>(lstParams);

                for (int i = 0; i < lstContact.Count; i++)
                {
                    if (lstContact[i].customerid == null || lstContact[i].customerid == string.Empty)
                    {
                        //new 
                        lstContact[i].customerid = customer.customerid;
                        contactDal.DoInsert<tmdlcontact>(lstContact[i]);
                    }
                    else
                    {
                        //do update
                        contactDal.DoUpdate<tmdlcontact>(lstContact[i]);
                    }
                }

                #region check Delete
                bool bDeleted = true;
                List<int> lstDeleteIdx = new List<int>();
                for (int i = 0; i < lstOld.Count; i++)
                {
                    bDeleted = true;
                    for (int j = 0; j < lstContact.Count; j++)
                    {
                        if (lstOld[i].contactname == lstContact[j].contactname)
                        {
                            bDeleted = false;
                        }
                    }

                    if (bDeleted)
                        lstDeleteIdx.Add(i);
                }

                for (int i = 0; i < lstDeleteIdx.Count; i++)
                {
                    contactDal.DoDelete<tmdlcontact>(lstOld[lstDeleteIdx[i]]);
                }
                #endregion

                baseDal.DoUpdate<tmdlcustomer>(customer);
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

        public void DoDeleteCustomer(List<MESParameterInfo> lstParameters)
        {
            try
            {
                dbInstance.BeginTransaction();

                ContactDal contactDal = new ContactDal(dbInstance);
                contactDal.DoDelete<tmdlcontact>(lstParameters);

                baseDal.DoDelete<tmdlcustomer>(lstParameters);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Services.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Repositories.SYS;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Utility.Database;

namespace GENLSYS.MES.Services.SYS
{
    public class BillCodeBll : BaseBll
    {
        #region Construct
        BillCodeDal localDal = null;
        public BillCodeBll(ContextInfo contextInfo) :
            base(contextInfo)
        {
            localDal = new BillCodeDal(dbInstance);
            baseDal = localDal;
        }

        public BillCodeBll(ContextInfo contextInfo, DBInstance _dbInstance) :
            base(contextInfo)
        {
            dbInstance = _dbInstance;
            localDal = new BillCodeDal(dbInstance);
            baseDal = localDal;
        }
        #endregion

        #region get bill
        #region TimeFormat
        public string GetSingleBillNo(string bcrid, string lockRefId)
        {
            List<MESParameterInfo> lstVariablesParameters = new List<MESParameterInfo>();
            return GetSingleBillNo(bcrid, lockRefId,string.Empty, lstVariablesParameters);
        }

        public List<string> GetBillNo(string bcrid, int batchNum, string lockRefId)
        {
            List<MESParameterInfo> lstVariablesParameters = new List<MESParameterInfo>();
            return GetBillNoBatch(bcrid, batchNum, lockRefId,string.Empty, lstVariablesParameters);
        }
        #endregion

        #region Parameter or Both
        public List<string> GetBillNo(string bcrid, int batchNum, string lockRefId, string baseValue, List<MESParameterInfo> lstVariablesParameters)
        {
            return GetBillNoBatch(bcrid, batchNum, lockRefId, baseValue, lstVariablesParameters);
        }

        public string GetSingleBillNo(string bcrid, string lockRefId,string baseValue, List<MESParameterInfo> lstVariablesParameters)
        {
            List<string> lstBillNo = new List<string>();

            try
            {
                dbInstance.BeginTransaction();

                lstBillNo = SubGetBillNoBatch(bcrid, 1, lockRefId, baseValue,lstVariablesParameters);

                if (lstBillNo.Count < 1) return string.Empty;

                dbInstance.Commit();

                return lstBillNo[0];
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

        private List<string> GetBillNoBatch(string bcrid, int batchNum, string lockRefId, string baseValue, List<MESParameterInfo> lstVariablesParameters)
        {
            try
            {
                dbInstance.BeginTransaction();

                List<string> lstBillNo = SubGetBillNoBatch(bcrid, batchNum, lockRefId,baseValue, lstVariablesParameters);

                dbInstance.Commit();

                return lstBillNo;
            }
            catch (UtilException ex)
            {
                dbInstance.Rollback();
                throw ex;
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
        #endregion

        public List<string> SubGetBillNoBatch(string bcrid, int batchNum, string lockRefId,
            string baseValue, List<MESParameterInfo> lstVariablesParameters)
        {
            #region prepare
            List<string> lstBillNo = new List<string>();

            if (bcrid.Trim() == string.Empty)
            {
                return lstBillNo;
            }

            decimal prevseqvalue = 0;
            #endregion

            try
            {
                //get system config
                string sysConfig = new SystemConfigBll(CurrentContextInfo).GetSystemConfigValue("SYS_CONTBILLNO");

                #region get objects
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "bcrid",
                    ParamValue = bcrid,
                    ParamType = "string"
                });

                //get rule object
                tsysbillcoderule rule = GetSingleObject<tsysbillcoderule>(lstParameters);

                if (rule == null) return lstBillNo;

                //get time format
                string timeformat = rule.timeformat;
                if (timeformat == null || timeformat.Trim() == string.Empty)
                    timeformat = "yyyyMMdd";//default

                string currentTimeValue = Function.GetCurrentTime().ToString(timeformat);

                currentTimeValue = ConvertSpecialTimeFormat(currentTimeValue, timeformat);

                if (rule.basevalue == MES_BillCodeRule_BCRBaseValue.TimeFormat.ToString())
                {
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "basevalue",
                        ParamValue = currentTimeValue,
                        ParamType = "string"
                    });
                }
                else if(rule.basevalue == MES_BillCodeRule_BCRBaseValue.Parameter.ToString())
                {
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "basevalue",
                        ParamValue = baseValue,
                        ParamType = "string"
                    });
                }
                else
                {
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "basevalue",
                        ParamValue = baseValue,
                        ParamType = "string"
                    });

                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "timevalue",
                        ParamValue = currentTimeValue,
                        ParamType = "string"
                    });
                }

                //get bill code object
                tsysbillcode billCode = localDal.GetSingleObject<tsysbillcode>(lstParameters, string.Empty, false);
                #endregion

                if (billCode != null)
                {
                    #region if exists,update

                    if (sysConfig == MES_Misc.Y.ToString())
                    {
                        //check lock flag first
                        if (billCode.islocked == MES_Misc.Y.ToString())
                        {
                            if (billCode.lockrefid != null && billCode.lockrefid == lockRefId)
                            {
                            }
                            else
                            {
                                throw new UtilException("-200015");
                            }
                        }
                    }

                    prevseqvalue = billCode.currentseqvalue;

                    for (int i = 0; i < batchNum; i++)
                    {
                        #region check max & min value & iscycle
                        if (billCode.currentseqvalue < rule.maxvalue && billCode.currentseqvalue >= rule.minvalue)
                        {
                            billCode.currentseqvalue = billCode.currentseqvalue + (rule.incrementby == null ? 1 : (rule.incrementby <= 0 ? 1 : rule.incrementby));
                            billCode.lastmodifiedtime = Function.GetCurrentTime();
                            billCode.lastmodifieduser = CurrentContextInfo.CurrentUser;
                            
                            if (rule.billformat==null || rule.billformat.Trim()==string.Empty)
                            {
                                billCode.fullbillnotext = rule.ffchars + currentTimeValue + billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0');
                            }
                            else
                            {
                                billCode.fullbillnotext = ParseVariables(rule, currentTimeValue,
                                    billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0'),
                                    lstVariablesParameters);
                            }
                        }
                        else
                        {
                            if (rule.iscycle == MES_Misc.Y.ToString())
                            {
                                //reset
                                billCode.currentseqvalue = rule.startwith.HasValue ? 1 : (rule.startwith.Value < 0 ? 1 : rule.startwith.Value);
                                billCode.lastmodifiedtime = Function.GetCurrentTime();
                                billCode.lastmodifieduser = CurrentContextInfo.CurrentUser;
                                //billCode.fullbillnotext = rule.ffchars + currentTimeValue + billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0');

                                if (rule.billformat == null || rule.billformat.Trim() == string.Empty)
                                {
                                    billCode.fullbillnotext = rule.ffchars + currentTimeValue + billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0');
                                }
                                else
                                {
                                    billCode.fullbillnotext = ParseVariables(rule, currentTimeValue,
                                        billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0'),
                                        lstVariablesParameters);
                                }
                            }
                            else
                            {
                                //error
                                //billCode.fullbillnotext = "-1";
                                throw new Exception("-200028");
                            }
                        }
                        #endregion

                        lstBillNo.Add(billCode.fullbillnotext);
                    }

                    if (sysConfig == MES_Misc.Y.ToString() && lockRefId!=string.Empty)
                    {
                        billCode.islocked = MES_Misc.Y.ToString();
                    }

                    billCode.lockrefid = lockRefId;
                    billCode.prevseqvalue = prevseqvalue;

                    localDal.DoUpdate<tsysbillcode>(billCode);
                    #endregion
                }
                else
                {
                    if (rule.basevalue == MES_BillCodeRule_BCRBaseValue.TimeFormat.ToString())
                    {
                        //close the last one first
                        ClosePrevBill(bcrid);
                    }

                    #region if new, insert
                    billCode = new tsysbillcode();
                    billCode.bcrid = bcrid;

                    prevseqvalue = billCode.currentseqvalue;

                    for (int i = 0; i < batchNum; i++)
                    {
                        if (rule.basevalue == MES_BillCodeRule_BCRBaseValue.TimeFormat.ToString())
                        {
                            billCode.basevalue = currentTimeValue;
                        }
                        else
                        {
                            billCode.basevalue = baseValue;
                        }
                        billCode.timevalue = currentTimeValue;
                        if (i == 0)
                        {
                            //first one
                            billCode.currentseqvalue = rule.startwith.HasValue ? 1 : (rule.startwith.Value < 0 ? 1 : rule.startwith.Value);
                        }
                        else
                        {
                            #region check max & min value & iscycle
                            if (billCode.currentseqvalue < rule.maxvalue && billCode.currentseqvalue >= rule.minvalue)
                            {
                                billCode.currentseqvalue = billCode.currentseqvalue + (rule.incrementby == null ? 1 : (rule.incrementby <= 0 ? 1 : rule.incrementby));
                                billCode.lastmodifiedtime = Function.GetCurrentTime();
                                billCode.lastmodifieduser = CurrentContextInfo.CurrentUser;
                                //billCode.fullbillnotext = rule.ffchars + currentTimeValue + billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0');

                                if (rule.billformat == null || rule.billformat.Trim() == string.Empty)
                                {
                                    billCode.fullbillnotext = rule.ffchars + currentTimeValue + billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0');
                                }
                                else
                                {
                                    billCode.fullbillnotext = ParseVariables(rule, currentTimeValue,
                                        billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0'),
                                        lstVariablesParameters);
                                }
                            }
                            else
                            {
                                if (rule.iscycle == MES_Misc.Y.ToString())
                                {
                                    //reset
                                    billCode.currentseqvalue = rule.startwith.HasValue ? 1 : (rule.startwith.Value < 0 ? 1 : rule.startwith.Value);
                                    billCode.lastmodifiedtime = Function.GetCurrentTime();
                                    billCode.lastmodifieduser = CurrentContextInfo.CurrentUser;
                                    //billCode.fullbillnotext = rule.ffchars + currentTimeValue + billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0');

                                    if (rule.billformat == null || rule.billformat.Trim() == string.Empty)
                                    {
                                        billCode.fullbillnotext = rule.ffchars + currentTimeValue + billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0');
                                    }
                                    else
                                    {
                                        billCode.fullbillnotext = ParseVariables(rule, currentTimeValue,
                                            billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0'),
                                            lstVariablesParameters);
                                    }
                                }
                                else
                                {
                                    //error
                                    //billCode.fullbillnotext = "-1";
                                    throw new Exception("-200028");
                                }
                            }
                            #endregion
                        }

                        billCode.lastmodifiedtime = Function.GetCurrentTime();
                        billCode.lastmodifieduser = CurrentContextInfo.CurrentUser;
                        //billCode.fullbillnotext = rule.ffchars + currentTimeValue + billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0');

                        if (rule.billformat == null || rule.billformat.Trim() == string.Empty)
                        {
                            billCode.fullbillnotext = rule.ffchars + currentTimeValue + billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0');
                        }
                        else
                        {
                            billCode.fullbillnotext = ParseVariables(rule, currentTimeValue,
                                billCode.currentseqvalue.ToString().PadLeft(Int16.Parse(rule.seqvaluelength.ToString()), '0'),
                                lstVariablesParameters);
                        }

                        lstBillNo.Add(billCode.fullbillnotext);
                    }

                    billCode.prevseqvalue = prevseqvalue;
                    if (sysConfig == MES_Misc.Y.ToString() && lockRefId != string.Empty)
                    {
                        billCode.islocked = MES_Misc.Y.ToString();
                        billCode.isclosed = MES_Misc.N.ToString();
                    }

                    billCode.lockrefid = lockRefId;
                    
                    localDal.DoInsert<tsysbillcode>(billCode);
                    #endregion
                }

                #region update rule's status
                if (rule.bcrstatus == MES_BillCodeRule_BCRStatus.Unused.ToString())
                {
                    //update rule status to used
                    rule.bcrstatus = MES_BillCodeRule_BCRStatus.Used.ToString();
                    rule.lastmodifiedtime = Function.GetCurrentTime();
                    rule.lastmodifieduser = CurrentContextInfo.CurrentUser;

                    localDal.DoUpdate<tsysbillcoderule>(rule);
                }
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstBillNo;
        }
        #endregion

        #region ParseVariables
        private string ParseVariables(tsysbillcoderule rule, string timeFormat, string seqNo,List<MESParameterInfo> lstVariablesParameters)
        {
            //predefined:
            //{@TIMEFORMAT}
            //{@SEQUENCE}
            //{@FFCHARS}

            //cust
            //{@PrdTarget}

            string result = rule.billformat.ToLower().Trim();

            for (int i = 0; i < lstVariablesParameters.Count; i++)
            {
                string replaceStr = "{@" + lstVariablesParameters[i].ParamName.ToLower().Trim() + "}";
                string valueStr = lstVariablesParameters[i].ParamValue.Trim();
                result = result.Replace(replaceStr, valueStr);
            }

            string ffchars = rule.ffchars == null || rule.ffchars.Trim() == string.Empty ? string.Empty : rule.ffchars;
            result = result.Replace("{@ffchars}", ffchars);
            result = result.Replace("{@timeformat}", timeFormat);
            result = result.Replace("{@sequence}", seqNo);

            return result;
        }
        #endregion

        #region ClosePrevBill
        /// <summary>
        /// Close the bill if passed
        /// </summary>
        /// <param name="bcrid"></param>
        /// <param name="prevtimevalue"></param>
        private void ClosePrevBill(string bcrid)
        {
            try
            {
                #region get objects
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "bcrid",
                    ParamValue = bcrid,
                    ParamType = "string"
                });

                //get bill code object
                List<tsysbillcode> lstBillCode = localDal.GetSelectedObjects<tsysbillcode>(lstParameters, string.Empty, true, -1);
                #endregion

                if (lstBillCode.Count>0)
                {
                    var q = (from p in lstBillCode
                         orderby p.timevalue descending
                         select p).ToList<tsysbillcode>();

                    lstBillCode[0].islocked = MES_Misc.N.ToString();
                    lstBillCode[0].isclosed = MES_Misc.Y.ToString();
                    lstBillCode[0].lockrefid = string.Empty;
                    lstBillCode[0].lastmodifiedtime = Function.GetCurrentTime();
                    lstBillCode[0].lastmodifieduser = CurrentContextInfo.CurrentUser;

                    localDal.DoUpdate<tsysbillcode>(lstBillCode[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        #endregion

        #region update bill
        /// <summary>
        /// if bill got success, we need to remove bill's lock
        /// </summary>
        /// <param name="bcrid"></param>
        public void UnlockBill(string bcrid,string lockRefId)
        {
            try
            {
                dbInstance.BeginTransaction();

                SubUnlockBill(bcrid, lockRefId);

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

        public void SubUnlockBill(string bcrid, string lockRefId)
        {
            try
            {
                #region get objects
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "bcrid",
                    ParamValue = bcrid,
                    ParamType = "string"
                });

                //get rule object
                tsysbillcoderule rule = localDal.GetSingleObject<tsysbillcoderule>(lstParameters, string.Empty, true);

                ////get time format
                //string timeformat = rule.timeformat;
                //if (timeformat == null || timeformat.Trim() == string.Empty)
                //    timeformat = MES_BillCodeRule_TimeFormat.yyyyMMdd.ToString();//default

                //string currentTimeValue = Function.GetCurrentTime().ToString(timeformat);
                //if (rule.basevalue == MES_BillCodeRule_BCRBaseValue.TimeFormat.ToString())
                //{
                //    lstParameters.Add(new MESParameterInfo()
                //    {
                //        ParamName = "timevalue",
                //        ParamValue = currentTimeValue,
                //        ParamType = "string"
                //    });
                //}
                //else
                //{
                //    lstParameters.Add(new MESParameterInfo()
                //    {
                //        ParamName = "basevalue",
                //        ParamValue = basevalue,
                //        ParamType = "string"
                //    });
                //}

                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "lockrefid",
                    ParamValue = lockRefId,
                    ParamType = "string"
                });

                //get bill code object
                tsysbillcode billCode = localDal.GetSingleObject<tsysbillcode>(lstParameters, string.Empty, true);
                #endregion

                if (billCode != null)
                {
                    billCode.islocked = MES_Misc.N.ToString();
                    billCode.lockrefid = string.Empty;
                    billCode.lastmodifiedtime = Function.GetCurrentTime();
                    billCode.lastmodifieduser = CurrentContextInfo.CurrentUser;

                    localDal.DoUpdate<tsysbillcode>(billCode);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        #endregion

        #region ResetBill
        public void ResetBill(string bcrid, string lockRefId)
        {
            try
            {
                ////get system config
                //check from client
                //string sysConfig = new SystemConfigBll(CurrentContextInfo).GetSystemConfigValue("SYS_CONTBILLNO");
                //if (sysConfig == MES_Misc.N.ToString())
                //    return;

                dbInstance.BeginTransaction();

                #region get objects
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "bcrid",
                    ParamValue = bcrid,
                    ParamType = "string"
                });

                //get rule object
                tsysbillcoderule rule = GetSingleObject<tsysbillcoderule>(lstParameters);

                ////get time format
                //string timeformat = rule.timeformat;
                //if (timeformat == null || timeformat.Trim() == string.Empty)
                //    timeformat = MES_BillCodeRule_TimeFormat.yyyyMMdd.ToString();//default

                //string currentTimeValue = Function.GetCurrentTime().ToString(timeformat);
                //if (rule.basevalue == MES_BillCodeRule_BCRBaseValue.TimeFormat.ToString())
                //{
                //    lstParameters.Add(new MESParameterInfo()
                //    {
                //        ParamName = "timevalue",
                //        ParamValue = currentTimeValue,
                //        ParamType = "string"
                //    });
                //}
                //else
                //{
                //    lstParameters.Add(new MESParameterInfo()
                //    {
                //        ParamName = "basevalue",
                //        ParamValue = baseValue,
                //        ParamType = "string"
                //    });
                //}

                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "lockrefid",
                    ParamValue = lockRefId,
                    ParamType = "string"
                });

                //get bill code object
                tsysbillcode billCode = localDal.GetSingleObject<tsysbillcode>(lstParameters, string.Empty, false);
                #endregion

                if (billCode != null)
                {
                    if (billCode.prevseqvalue == null || billCode.prevseqvalue < rule.minvalue)
                    {
                        localDal.DoDelete<tsysbillcode>(billCode);
                    }
                    else
                    {
                        billCode.islocked = MES_Misc.N.ToString();
                        billCode.lockrefid = string.Empty;
                        billCode.currentseqvalue = billCode.prevseqvalue.Value;
                        billCode.prevseqvalue = 0;
                        billCode.lastmodifiedtime = Function.GetCurrentTime();
                        billCode.lastmodifieduser = CurrentContextInfo.CurrentUser;

                        localDal.DoUpdate<tsysbillcode>(billCode);
                    }
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

        private string ConvertSpecialTimeFormat(string currentTimeValue, string timeformat)
        {
            if (timeformat.ToUpper() == "YMMDD")
            {
                return currentTimeValue.Substring(currentTimeValue.Length - 5, 5);
            }
            
            return currentTimeValue;
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.INP.Adjust
{
    public partial class frmRepairAdjust : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public string repSysId { get; set; }
        public tinprepairhis RepairHis { get; set; }
        public string Customer { get; set; }
        public string ReaseanCode { get; set; }
        private DataTable failDt = null;
        private decimal orgqty = 0;

        #region Construct
        public frmRepairAdjust()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events
        private void frmRepairAdjust_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            
            DropDown.InitCMB_StaticValue(this.cmbToStep, MES_StaticValue_Type.Step);
            DropDown.InitCMB_WorkGroup(this.cmbWorkGroup);

            this.txtCustOrderNo.Text = RepairHis.custorderno;
            this.txtCustomer.Text = Customer;
            this.txtStyleNo.Text = RepairHis.styleno;
            this.txtColor.Text = RepairHis.color;
            this.txtSize.Text = RepairHis.size;
            this.txtRepType.Text = RepairHis.reptype;
            DropDown.SelectCMBValue(this.cmbToStep,RepairHis.step);
            DropDown.SelectCMBValue(this.cmbWorkGroup, RepairHis.workgroup);
            

            failDt = GetRepairFail(RepairHis.repsysid, ReaseanCode);
            if (failDt.Rows.Count > 0)
            {
                this.txtReasonCode.Text = failDt.Rows[0]["reasoncodedesc"].ToString();
                this.numPairQty.Value = Convert.ToDecimal(failDt.Rows[0]["pairqty"].ToString());                
            }
            if (RepairHis.reptype.Equals(MES_RepairType.RepairSuccess.ToString()))
            {
                this.numPairQty.Value = Convert.ToDecimal(RepairHis.pairqty);
            }
            orgqty = this.numPairQty.Value;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Method
        private void DoSave()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();
                baseForm.ValidateData(this);
                if (this.numPairQty.Value == orgqty)
                {
                    throw new Exception(UtilCulture.GetString("Msg.R01025"));
                }
                if (this.numPairQty.Value > orgqty)
                {
                    if (RepairHis.reptype.Equals(MES_RepairType.ToRepair.ToString()))
                    {
                        tinpwip wip = GetSingleWip();
                        if (wip != null)
                        {
                            if ((this.numPairQty.Value - orgqty) > wip.pairqty)
                            {
                                throw new Exception(UtilCulture.GetString("Msg.R01027"));
                            }
                        }
                        else
                        {
                            if ((this.numPairQty.Value - orgqty) > 0)
                            {
                                throw new Exception(UtilCulture.GetString("Msg.R01027"));
                            }
                        }
                    }

                    if (RepairHis.reptype.Equals(MES_RepairType.RepairFail.ToString()) || RepairHis.reptype.Equals(MES_RepairType.RepairSuccess.ToString()))
                    {
                        tinprepairstock stock = GetSingleRepairStock();
                        if (stock != null)
                        {
                            if ((this.numPairQty.Value - orgqty) > stock.curpairqty)
                            {
                                throw new Exception(UtilCulture.GetString("Msg.R01026"));
                            }
                        }
                        else
                        {
                            throw new Exception("No data found");
                        }
                    }
                }
                else
                {
                    if (RepairHis.reptype.Equals(MES_RepairType.ToRepair.ToString()))
                    {
                        tinprepairstock stock = GetSingleRepairStock();
                        if (stock != null)
                        {
                            if ((orgqty-this.numPairQty.Value) > stock.curpairqty)
                            {
                                throw new Exception(UtilCulture.GetString("Msg.R01026"));
                            }
                        }
                        else
                        {
                            throw new Exception("No data found");
                        }
                    }
                    else if (RepairHis.reptype.Equals(MES_RepairType.RepairSuccess.ToString()))
                    {
                        int leftSuccessQty = GetLeftRepairSuccessQty();
                        if ((orgqty - this.numPairQty.Value) > leftSuccessQty)
                        {
                            throw new Exception(UtilCulture.GetString("Msg.R01027"));
                        }

                    }
                }
                client.DoRepaireAdjust(baseForm.CurrentContextInfo, RepairHis.repsysid, ReaseanCode, Convert.ToInt16(this.numPairQty.Value));
                baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));
                this.Close();
            }
            catch (Exception ex)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, ex.Message);
            }
            finally
            {
                baseForm.ResetCursor();
            }
            
        }

        public int GetLeftRepairSuccessQty()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            int reuslt = 0;
            try
            {
                reuslt = client.GetLeftRepairSuccessQty(baseForm.CurrentContextInfo, RepairHis.custorderno, RepairHis.styleno, RepairHis.color, RepairHis.size, RepairHis.step);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return reuslt;
        }

        private tinpwip GetSingleWip()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            tinpwip wip = null;
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "customerid",
                    ParamValue = RepairHis.customerid,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "custorderno",
                    ParamValue = RepairHis.custorderno,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "styleno",
                    ParamValue = RepairHis.styleno,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "color",
                    ParamValue = RepairHis.color,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "size",
                    ParamValue = RepairHis.size,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "status",
                    ParamValue = RepairHis.step,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "workgroup",
                    ParamValue = RepairHis.workgroup,
                    ParamType = "string"
                });
                wip = client.GetSingleWip(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return wip;
        }
        private tinprepairstock GetSingleRepairStock()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            tinprepairstock stock = null;
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "custorderno",
                    ParamValue = RepairHis.custorderno,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "styleno",
                    ParamValue = RepairHis.styleno,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "color",
                    ParamValue = RepairHis.color,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "size",
                    ParamValue = RepairHis.size,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "step",
                    ParamValue = RepairHis.step,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "workgroup",
                    ParamValue = RepairHis.workgroup,
                    ParamType = "string"
                });
                stock = client.GetSingleRepairStock(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return stock;
        }

        private DataTable GetRepairFail(string repsysid,string reasoncode)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "repsysid",
                    ParamValue = repsysid,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "reasoncode",
                    ParamValue = reasoncode,
                    ParamType = "string"
                });
                dt = client.GetRepairFailRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return dt;
        }
        #endregion
    }
}

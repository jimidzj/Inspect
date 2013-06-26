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
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.INP.Adjust
{
    public partial class frmSupplementAdjust : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public string suplDtlSysId { get; set; }
        private DataTable dtlDt;

        #region Construct
        public frmSupplementAdjust()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events
        private void frmSupplementAdjust_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);

            DropDown.InitCMB_StaticValue(this.cmbToStep, MES_StaticValue_Type.Step);
            DropDown.InitCMB_WorkGroup(this.cmbWorkGroup);

            dtlDt = GetSupplementDtl();
            if (dtlDt.Rows.Count > 0)
            {
                this.txtSupplementNo.Text = dtlDt.Rows[0]["supplementno"].ToString();
                this.txtCustomer.Text = dtlDt.Rows[0]["customername"].ToString();
                this.txtCustOrderNo.Text = dtlDt.Rows[0]["custorderno"].ToString();
                this.txtStyleNo.Text = dtlDt.Rows[0]["styleno"].ToString();
                this.txtColor.Text = dtlDt.Rows[0]["color"].ToString();
                this.txtSize.Text = dtlDt.Rows[0]["size"].ToString();
                this.numPairQty.Value = Convert.ToDecimal(dtlDt.Rows[0]["pairqty"]);
                if (dtlDt.Rows[0]["isreinspect"].ToString().Equals(MES_Misc.Y.ToString()))
                {
                    this.ckTwiceInspect.Checked = true;
                }
                else
                {
                    this.ckTwiceInspect.Checked = false;
                }
                DropDown.SelectCMBValue(this.cmbToStep, dtlDt.Rows[0]["step"].ToString());
                DropDown.SelectCMBValue(this.cmbWorkGroup, dtlDt.Rows[0]["workgroup"].ToString());
            }
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
                if (dtlDt.Rows.Count > 0)
                {
                    tinpwip wip = GetSingleWip();
                    if ((Convert.ToDecimal(dtlDt.Rows[0]["pairqty"]) - this.numPairQty.Value) > wip.pairqty)
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01027"));
                    }

                    client.DoSupplementAdjust(baseForm.CurrentContextInfo, dtlDt.Rows[0]["supldtlsysid"].ToString(), Convert.ToInt16(this.numPairQty.Value), this.ckTwiceInspect.Checked ? MES_Misc.Y.ToString() : MES_Misc.N.ToString());


                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));
                    this.Close();
                }
                else
                {
                    throw new Exception("No data found");
                }
                
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

        private DataTable GetSupplementDtl()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "supldtlsysid",
                    ParamValue = suplDtlSysId,
                    ParamType = "string"
                });
                
                dt = client.GetSupplementDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).Tables[0];
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
        private tinpwip GetSingleWip()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            tinpwip wip = null;            
            try
            {
                if (dtlDt.Rows.Count > 0)
                {
                    List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "custorderno",
                        ParamValue = dtlDt.Rows[0]["custorderno"].ToString(),
                        ParamType = "string"
                    });
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "styleno",
                        ParamValue = dtlDt.Rows[0]["styleno"].ToString(),
                        ParamType = "string"
                    });
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "color",
                        ParamValue = dtlDt.Rows[0]["color"].ToString(),
                        ParamType = "string"
                    });
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "size",
                        ParamValue = dtlDt.Rows[0]["size"].ToString(),
                        ParamType = "string"
                    });
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "status",
                        ParamValue = dtlDt.Rows[0]["step"].ToString(),
                        ParamType = "string"
                    });
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "workgroup",
                        ParamValue = dtlDt.Rows[0]["workgroup"].ToString(),
                        ParamType = "string"
                    });
                    wip = client.GetSingleWip(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                }
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
        #endregion
    }
}

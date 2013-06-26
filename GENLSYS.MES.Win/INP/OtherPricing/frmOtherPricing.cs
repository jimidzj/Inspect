using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.INP.OtherPricing
{
    public partial class frmOtherPricing : Form
    {
        public string OpriSysId { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode { get; set; }
        public frmOtherPricingList parentForm { get; set; }

        #region Construct
        public frmOtherPricing()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events
        private void frmOtherPricing_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            DropDown.InitCMB_StaticValue(this.cmbCurrency, MES_StaticValue_Type.Currency);
            DropDown.InitCMB_StaticValue(this.cmbUnit, MES_StaticValue_Type.Unit);
            DropDown.InitCMB_Customer_All(this.cmbCustomerId);
            this.btSaveContinue.Size = new Size(106,23);

            if (OpriSysId != null)
            {
                UpdateMode = Public_UpdateMode.Update;
                this.btSaveContinue.Enabled = false;
                this.cmbCustomerId.Enabled = false;
                //this.txtItemName.Enabled = false;
                baseForm.SetControlReadOnly(this.txtItemName,true);
            }
            else
            {
                UpdateMode = Public_UpdateMode.Insert;
            }

            if (UpdateMode == Public_UpdateMode.Update)
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "oprisysid",
                    ParamValue = OpriSysId,
                    ParamType = "string"
                });
                DoShowSingleObject<tinpotherpricing>(lstParameters);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSaveSingleObject();
            this.Close();
        }

        private void btSaveContinue_Click(object sender, EventArgs e)
        {
            DoSaveSingleObject();
            parentForm.RefreshGrid();
            OpriSysId = null;
            UpdateMode = Public_UpdateMode.Insert;
            this.txtItemName.Text = "";
            this.numPrice.Value = 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Methods
        public void DoSaveSingleObject()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                baseForm.ValidateData(this);
                tinpotherpricing otherpricing = new tinpotherpricing();

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    otherpricing.oprisysid = Function.GetGUID();
                }
                else
                {
                    otherpricing = baseForm.OriginalObject as tinpotherpricing;
                }


                baseForm.CreateSingleObject<tinpotherpricing>(otherpricing, this, UpdateMode);


                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.DoInsertOtherPricing(baseForm.CurrentContextInfo, otherpricing);
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.DoUpdateOtherPricing(baseForm.CurrentContextInfo, otherpricing);
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                else if (UpdateMode == Public_UpdateMode.Update)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));

                //this.Close();
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
        }

        public void DoShowSingleObject<T>(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                tinpotherpricing otherpricing = client.GetSingleOtherPricing(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                baseForm.OriginalObject = otherpricing;
                baseForm.ShowSingleObjectToUI<tinpotherpricing>(otherpricing, this);
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }

        }
        #endregion
    }
}

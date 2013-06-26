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
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Win.MDL.Exchange
{
    public partial class frmExchange : Form
    {
        public string ExSysId { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode { get; set; }

        #region Construct
        public frmExchange()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events
        private void frmExchange_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            DropDown.InitCMB_StaticValue(this.cmbFromCurrency, MES_StaticValue_Type.Currency);
            DropDown.InitCMB_StaticValue(this.cmbToCurrency, MES_StaticValue_Type.Currency);

            if (ExSysId != null)
            {
                UpdateMode = Public_UpdateMode.Update;
            }
            else
            {
                UpdateMode =Public_UpdateMode.Insert;
            }

            if (UpdateMode == Public_UpdateMode.Update)
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "exsysid",
                    ParamValue = ExSysId,
                    ParamType = "string"
                });
                DoShowSingleObject<tmdlexchange>(lstParameters);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSaveSingleObject();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Methods
        public void DoSaveSingleObject()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                baseForm.SetCursor();

                baseForm.ValidateData(this);
                tmdlexchange exchange = new tmdlexchange();

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    exchange.exsysid = Function.GetGUID();
                }
                else
                {
                    exchange = baseForm.OriginalObject as tmdlexchange;
                }


                baseForm.CreateSingleObject<tmdlexchange>(exchange, this, UpdateMode);


                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.DoInsertExchange(baseForm.CurrentContextInfo, exchange);
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.DoUpdateExchange(baseForm.CurrentContextInfo, exchange);
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                else if (UpdateMode == Public_UpdateMode.Update)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));

                this.Close();
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
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                baseForm.SetCursor();

                tmdlexchange exchange = client.GetSingleExchange(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                baseForm.OriginalObject = exchange;
                baseForm.ShowSingleObjectToUI<tmdlexchange>(exchange, this);
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

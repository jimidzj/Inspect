using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Common;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;
using Infragistics.Win.UltraWinGrid;

namespace GENLSYS.MES.Win.SYS.BillCodeRule
{
    public partial class frmBillCodeRuleEdit : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;

        #region Construct
        public frmBillCodeRuleEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdBillCode, new string[] { "bcrid", "basevalue","timevalue", "currentseqvalue", "fullbillnotext","islocked","prevseqvalue","lockrefid","isclosed" });
        }
        #endregion

        #region Events
        private void frmBillCodeRuleEdit_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdBillCode);
            this.grdBillCode.DisplayLayout.Bands[0].Columns["BCRID"].Hidden = true;

            SetLayout();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                DoShowSingleObject<tsysbillcoderule>(PrimaryKeys);
            }
            else
            {
                this.cmbBCRStatus.Text = MES_BillCodeRule_BCRStatus.Unused.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSaveSingleObject();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdBillCode_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdBillCode.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;

            //islocked
            this.grdBillCode.DisplayLayout.Bands[0].Columns["islocked"].CellActivation = Activation.AllowEdit;
            this.grdBillCode.DisplayLayout.Bands[0].Columns["islocked"].CellClickAction = CellClickAction.Edit;
            this.grdBillCode.DisplayLayout.Bands[0].Columns["islocked"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            this.grdBillCode.DisplayLayout.Bands[0].Columns["islocked"].Editor.DataFilter = new CheckEditorStringDataFilter();

            //prevseqvalue
            this.grdBillCode.DisplayLayout.Bands[0].Columns["prevseqvalue"].CellActivation = Activation.AllowEdit;
            this.grdBillCode.DisplayLayout.Bands[0].Columns["prevseqvalue"].CellClickAction = CellClickAction.Edit;
            this.grdBillCode.DisplayLayout.Bands[0].Columns["prevseqvalue"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegative;

            //lockrefid
            this.grdBillCode.DisplayLayout.Bands[0].Columns["lockrefid"].CellActivation = Activation.AllowEdit;
            this.grdBillCode.DisplayLayout.Bands[0].Columns["lockrefid"].CellClickAction = CellClickAction.Edit;

            //currentseqvalue
            this.grdBillCode.DisplayLayout.Bands[0].Columns["currentseqvalue"].CellActivation = Activation.AllowEdit;
            this.grdBillCode.DisplayLayout.Bands[0].Columns["currentseqvalue"].CellClickAction = CellClickAction.Edit;
            this.grdBillCode.DisplayLayout.Bands[0].Columns["currentseqvalue"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegative;

            //fullbillnotext
            this.grdBillCode.DisplayLayout.Bands[0].Columns["fullbillnotext"].CellActivation = Activation.AllowEdit;
            this.grdBillCode.DisplayLayout.Bands[0].Columns["fullbillnotext"].CellClickAction = CellClickAction.Edit;

            //isclosed
            this.grdBillCode.DisplayLayout.Bands[0].Columns["isclosed"].CellActivation = Activation.NoEdit;
            this.grdBillCode.DisplayLayout.Bands[0].Columns["isclosed"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            this.grdBillCode.DisplayLayout.Bands[0].Columns["isclosed"].Editor.DataFilter = new CheckEditorStringDataFilter();
        }

        private void grdBillCode_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            string isclosed = e.Row.Cells["isclosed"].Value.ToString();

            if (isclosed == MES_Misc.Y.ToString())
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Activation = Activation.NoEdit;
                    e.Row.Cells[i].Appearance.BackColor = Color.SkyBlue;
                }
            }
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();

            if (UpdateMode == GENLSYS.MES.Common.Public_UpdateMode.Update)
            {
                this.txtBCRId.Enabled = false;
            }
        }

        private void SetCombobox()
        {
            #region Combobox
            DropDown.InitCMB_StaticValue(this.cmbTimeFormat, MES_StaticValue_Type.BillRuleTimeFormat);
            DropDown.InitCMB_Enums(this.cmbBCRStatus, typeof(MES_BillCodeRule_BCRStatus));
            DropDown.InitCMB_Enums(this.cmbBaseValue, typeof(MES_BillCodeRule_BCRBaseValue));
            #endregion
        }

        public void DoSaveSingleObject()
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();

            try
            {
                baseForm.SetCursor();

                #region Validate & build object from UI
                baseForm.ValidateData(this);

                tsysbillcoderule bcr = new tsysbillcoderule();

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    bcr = baseForm.OriginalObject as tsysbillcoderule;
                }

                baseForm.CreateSingleObject<tsysbillcoderule>(bcr, this, UpdateMode);
                #endregion

                #region Build Bill Code Value
                List<tsysbillcode> lstBillCode = new List<tsysbillcode>();
                for (int i = 0; i < this.grdBillCode.Rows.Count; i++)
                {
                    if (this.grdBillCode.Rows[i].Cells["isclosed"].Value.ToString() == MES_Misc.N.ToString())
                    { 
                        //ignore closed rows
                        if (this.grdBillCode.Rows[i].Cells["currentseqvalue"].Value.ToString() != string.Empty)
                        {
                            tsysbillcode code = new tsysbillcode();
                            code.bcrid = bcr.bcrid;
                            code.timevalue = this.grdBillCode.Rows[i].Cells["timevalue"].Value.ToString();
                            code.currentseqvalue = Decimal.Parse(this.grdBillCode.Rows[i].Cells["currentseqvalue"].Value.ToString());
                            code.fullbillnotext = this.grdBillCode.Rows[i].Cells["fullbillnotext"].Value.ToString();
                            code.isclosed = this.grdBillCode.Rows[i].Cells["isclosed"].Value.ToString();
                            code.islocked = this.grdBillCode.Rows[i].Cells["islocked"].Value.ToString();
                            code.lockrefid = this.grdBillCode.Rows[i].Cells["lockrefid"].Value.ToString();
                            if (this.grdBillCode.Rows[i].Cells["prevseqvalue"].Value.ToString() == string.Empty)
                                code.prevseqvalue = null;
                            else
                                code.prevseqvalue = Decimal.Parse(this.grdBillCode.Rows[i].Cells["prevseqvalue"].Value.ToString());

                            lstBillCode.Add(code);
                        }
                    }
                }
                #endregion

                #region call WCF

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.DoInsertBillCodeRule(baseForm.CurrentContextInfo, bcr, lstBillCode.ToArray<tsysbillcode>());
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.DoUpdateBillCodeRule(baseForm.CurrentContextInfo, bcr, lstBillCode.ToArray<tsysbillcode>());
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                }
                else if (UpdateMode == Public_UpdateMode.Update)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));
                }

                this.Close();
                #endregion

            }
            catch (Exception ex)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, ExceptionParser.Parse(ex));
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }

        }

        public void DoShowSingleObject<T>(List<MESParameterInfo> lstParameters)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();

            try
            {
                baseForm.SetCursor();

                tsysbillcoderule bcr = client.GetSingleBillCodeRule(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                baseForm.OriginalObject = bcr;
                baseForm.ShowSingleObjectToUI<tsysbillcoderule>(bcr, this);

                #region Show Value List
                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>()
                {
                    new MESParameterInfo()
                    {
                        ParamName="bcrid",
                        ParamValue=bcr.bcrid,
                        ParamType="bcrid"
                    }
                };

                DataSet ds = client.GetBillCodeRecords(baseForm.CurrentContextInfo, lstParameter.ToArray<MESParameterInfo>());
                
                this.grdBillCode.SetDataBinding(ds.Tables[0], "");

                #endregion
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

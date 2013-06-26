using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Win.MDL.Exchange
{
    public partial class frmExchangeList : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmExchangeList()
        {
            InitializeComponent();

            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { "exsysid", "fromcurrency", "tocurrency", "startdate", "expirydate", "rate", "lastmodifieduser", "lastmodifiedtime" });
        }
        #endregion

        #region Event
        private void frmExchangeList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            this.grdQuery.DisplayLayout.Bands[0].Columns["exsysid"].Hidden = true;
           
            this.pQuery.BackColor = Color.FromName("Info");

            DropDown.InitCMB_StaticValue(this.cmbFromCurrency,MES_StaticValue_Type.Currency);
            DropDown.InitCMB_StaticValue(this.cmbToCurrency, MES_StaticValue_Type.Currency);
        }

        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["startdate"].Format = "yyyy-MM-dd";
            e.Layout.Bands[0].Columns["expirydate"].Format = "yyyy-MM-dd";
            e.Layout.Bands[0].Columns["lastmodifiedtime"].Format = "yyyy-MM-dd HH:mm:ss";
        }

        private void grdQuery_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.grdQuery.ActiveRow != null)
            {
                this.ucToolbar1.SetToolbarWithSelection();
            }
            else
            {
                this.ucToolbar1.SetToolbarWithoutSelection();
            }
        }

        private void ucToolbar1_NewEventHandler(object sender, EventArgs e)
        {
            frmExchange f = new frmExchange();
            f.ShowDialog();
            RefreshGrid();
        }

        private void ucToolbar1_DeleteEventHandler(object sender, EventArgs e)
        {
            DoDelete();
            RefreshGrid();
        }

        private void ucToolbar1_EditEventHandler(object sender, EventArgs e)
        {
            if (this.grdQuery.ActiveRow != null)
            {
                frmExchange f = new frmExchange();
                f.ExSysId = this.grdQuery.ActiveRow.Cells["exsysid"].Value.ToString();
                f.ShowDialog(this);
                RefreshGrid();
            }
        }

        private void ucToolbar1_QueryEventHandler(object sender, EventArgs e)
        {
            if (pQuery.Visible == false)
                pQuery.Visible = true;
            else
                pQuery.Visible = false;
        }

        private void ucToolbar1_ExitEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucToolbar1_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.grdQuery);
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        #endregion

        #region Methods
        private void RefreshGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue = "%" + param.ParamValue + "%";
            }
            GetData(lstParameters);
        }
        private void GetData(List<MESParameterInfo> lstParameters)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetExchangeRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                this.grdQuery.SetDataBinding(ds.Tables[0], "");

                this.ucStatusBar1.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + ds.Tables[0].Rows.Count.ToString());
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

        public void DoDelete()
        {
            if (this.grdQuery.ActiveRow == null) return;

            DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                        MessageBoxButtons.OKCancel,
                        UtilCulture.GetString("Msg.R00004"),
                        "" + UtilCulture.GetString("Label.R00705") + ": "
                            + this.grdQuery.ActiveRow.Cells["fromcurrency"].Value.ToString() + "->" + this.grdQuery.ActiveRow.Cells["tocurrency"].Value.ToString());

            if (result == DialogResult.Cancel) return;

            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                baseForm.SetCursor();

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                    new MESParameterInfo(){
                        ParamName="exsysid",
                        ParamValue=this.grdQuery.ActiveRow.Cells["exsysid"].Value.ToString(),
                        ParamType="string"
                    }
                };
                client.DoDeleteExchange(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00003"));
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

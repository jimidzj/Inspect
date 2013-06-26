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

namespace GENLSYS.MES.Win.INP.WorkOrder
{
    public partial class frmWorkOrderList : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmWorkOrderList()
        {
            InitializeComponent();

            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { "workordersysid","workorderno", "customername", "factory", "workorderstatus","createduser","createdtime", "lastmodifieduser", "lastmodifiedtime" });
        }
        #endregion

        #region Events
        private void ucToolbar1_DeleteEventHandler(object sender, EventArgs e)
        {
            DoDelete();
        }

        private void ucToolbar1_EditEventHandler(object sender, EventArgs e)
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
            lstParameters.Add(new MESParameterInfo()
            {
                ParamName = "workordersysid",
                ParamValue = this.grdQuery.ActiveRow.Cells["workordersysid"].Value.ToString(),
                ParamType = "string"
            });

            frmWorkOrderEdit f = new frmWorkOrderEdit();
            f.UpdateMode = GENLSYS.MES.Common.Public_UpdateMode.Update;
            f.PrimaryKeys = lstParameters;
            f.ShowDialog();
            GetData(QueryParameters);
        }

        private void ucToolbar1_ExitEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucToolbar1_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.grdQuery);
        }

        private void ucToolbar1_NewEventHandler(object sender, EventArgs e)
        {
            frmWorkOrderEdit f = new frmWorkOrderEdit();
            f.UpdateMode = GENLSYS.MES.Common.Public_UpdateMode.Insert;
            f.ShowDialog();
            GetData(QueryParameters);
        }

        private void ucToolbar1_QueryEventHandler(object sender, EventArgs e)
        {
            if (pQuery.Visible == false)
                pQuery.Visible = true;
            else
                pQuery.Visible = false;
        }

        private void frmWorkOrderList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);

            DropDown.InitCMB_Customer_All(this.cboCustomer);
            DropDown.InitCMB_StaticValue(this.cboWOStatus, MES_StaticValue_Type.WOStatus);

            GetData(new List<MESParameterInfo>() { });

            this.grdQuery.DisplayLayout.Bands[0].Columns["workordersysid"].Hidden = true;
            this.pQuery.BackColor = Color.FromName("Info");
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            GetData(lstParameters);
        }

        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            if (!this.grdQuery.DisplayLayout.ValueLists.Exists("vlwostatus"))
            {
                this.grdQuery.DisplayLayout.ValueLists.Add("vlwostatus");
                this.grdQuery.DisplayLayout.ValueLists["vlwostatus"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.WOStatus));
                this.grdQuery.DisplayLayout.Bands[0].Columns["workorderstatus"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdQuery.DisplayLayout.Bands[0].Columns["workorderstatus"].ValueList = this.grdQuery.DisplayLayout.ValueLists["vlwostatus"];
            }
        }

        #endregion

        #region Methods
        private void GetData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetWorkOrderRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                this.grdQuery.SetDataBinding(ds.Tables[0], "");

                if (this.grdQuery.Rows.Count < 1)
                {
                    this.ucToolbar1.SetToolbarWithoutRows();
                }
                else
                {
                    this.ucToolbar1.SetToolbarWithRows();
                }

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
                        "<span style='font-weight:bold;'>" + UtilCulture.GetString("Label.R01023") + ": </span> " +
                            this.grdQuery.ActiveRow.Cells["workorderno"].Value.ToString());

            if (result == DialogResult.Cancel) return;

            wsINP.IwsINPClient client = new wsINP.IwsINPClient(); 
            try
            {
                baseForm.SetCursor();

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                    new MESParameterInfo(){
                        ParamName="workordersysid",
                        ParamValue=this.grdQuery.ActiveRow.Cells["workordersysid"].Value.ToString(),
                        ParamType="string"
                    }
                };

                client.DoDeleteWorkOrder(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                MESMsgBox.ShowInformation(UtilCulture.GetString("Msg.R00003"));

                GetData(QueryParameters);
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

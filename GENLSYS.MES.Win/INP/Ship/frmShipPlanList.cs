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
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace GENLSYS.MES.Win.INP.Ship
{
    public partial class frmShipPlanList : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmShipPlanList()
        {
            InitializeComponent();
            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { "shippingsysid", "shippingplanno", "custorderno", "customername", "ttlcantonqty", "createdtime", "createduser" });
        }
        #endregion

        #region Event
        private void frmShipPlanList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            this.ucToolbar1.SetExportVisible(false);

            this.pQuery.BackColor = Color.FromName("Info");

            QueryParameters = new List<MESParameterInfo>();
            GetData(QueryParameters);
            RefreshGrid();
        }

        private void ucToolbar1_NewEventHandler(object sender, EventArgs e)
        {
            frmShipPlan frm = new frmShipPlan();
            frm.ShowDialog(this);
            RefreshGrid();
        }

        private void ucToolbar1_EditEventHandler(object sender, EventArgs e)
        {
            if (this.grdQuery.ActiveRow != null)
            {
                frmShipPlan frm = new frmShipPlan();
                frm.ShipingSysId = this.grdQuery.ActiveRow.Cells["shippingsysid"].Value.ToString();
                frm.ShowDialog(this);
                RefreshGrid();
            }
        }

        private void ucToolbar1_DeleteEventHandler(object sender, EventArgs e)
        {
            DeleteShipPlan();
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
            this.Dispose();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["shippingsysid"].Hidden = true;
            e.Layout.Bands[0].Columns["createdtime"].Format = "yyyy-MM-dd HH:mm:ss";

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumTtlcantonqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumTtlcantonqty", SummaryType.Sum, e.Layout.Bands[0].Columns["ttlcantonqty"], SummaryPosition.UseSummaryPositionColumn);
            }
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
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetShippingPlanRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

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

        private void DeleteShipPlan()
        {
            if (this.grdQuery.ActiveRow != null)
            {
                Dictionary<string, object> dir = new Dictionary<string, object>();
                dir.Add(UtilCulture.GetString("Label.R02057"), this.grdQuery.ActiveRow.Cells["shippingplanno"].Value.ToString());
                DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                MessageBoxButtons.OKCancel,
                                                                UtilCulture.GetString("Msg.R00004"),
                                                                dir);
                if (result == DialogResult.OK)
                {
                    baseForm.SetCursor();
                    wsINP.IwsINPClient client = new wsINP.IwsINPClient();
                    try
                    {
                        if (client.HasShipByPlanNo(baseForm.CurrentContextInfo, this.grdQuery.ActiveRow.Cells["shippingplanno"].Value.ToString()))
                        {
                            baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00095"));
                        }
                        else
                        {
                            client.DoDeleteShipping(baseForm.CurrentContextInfo, this.grdQuery.ActiveRow.Cells["shippingsysid"].Value.ToString());
                            RefreshGrid();
                            baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00003"));
                        }
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
            }
        }

        #endregion
    }
}

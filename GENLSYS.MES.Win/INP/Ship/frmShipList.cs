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
using GENLSYS.MES.Win.Common.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace GENLSYS.MES.Win.INP.Ship
{
    public partial class frmShipList : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmShipList()
        {
            InitializeComponent();
             QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { "shippingsysid", "shippingno", "packingboxno", "containerno", "blno", "loadingtypetext", "actcartonqty", "emptycartonqty", "shippingstatus", "shippeddate" });
        }
        #endregion

        #region Events
        private void frmShipList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            ucToolbar1.SetPrintVisible(true);
            ucToolbar1.SetExportVisible(false);
            ucToolbar1.SetDeleteVisible(false);
            this.pQuery.BackColor = Color.FromName("Info");

            DropDown.InitCMB_Enums(this.cmbShippingStatus, typeof(MES_ShippingStatus));
            this.grdQuery.SetDataBinding(createEmptyTable(), "");
        }

        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["shippingsysid"].Hidden = true;
            e.Layout.Bands[0].Columns["shippeddate"].Format = "yyyy-MM-dd HH:mm:ss";

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumCartonqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumCartonqty", SummaryType.Sum, e.Layout.Bands[0].Columns["actcartonqty"], SummaryPosition.UseSummaryPositionColumn);
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
            if (RSALicense.LICENSEN_INFO.ValidateLicense())
            {
                this.ucToolbar1.btnPrint.Enabled = true;
            }
            else
            {
                this.ucToolbar1.btnPrint.Enabled = false;
            }
        }
        private void ucToolbar1_NewEventHandler(object sender, EventArgs e)
        {
            frmShip f = new frmShip();
            f.ShowDialog();
            RefreshGrid();
        }

        
        private void ucToolbar1_QueryEventHandler(object sender, EventArgs e)
        {
            if (pQuery.Visible == false)
                pQuery.Visible = true;
            else
                pQuery.Visible = false;
        }

        
        private void ucToolbar1_EditEventHandler(object sender, EventArgs e)
        {
            if (this.grdQuery.ActiveRow != null )
            {
                frmShip frm = new frmShip();
                frm.ShipingSysId = this.grdQuery.ActiveRow.Cells["shippingsysid"].Value.ToString();
                frm.ShowDialog(this);
                RefreshGrid();
            }
        }

        private void ucToolbar1_ExitEventHandler(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ucToolbar1_PrintEventHandler(object sender, EventArgs e)
        {
            if (this.grdQuery.ActiveRow != null && this.grdQuery.ActiveRow.Cells["shippingstatus"].Value.ToString().Equals(MES_ShippingStatus.Shipped.ToString()))
            {
                frmShipRpt frm = new frmShipRpt();
                frm.ShipingSysId=this.grdQuery.ActiveRow.Cells["shippingsysid"].Value.ToString();
                frm.ShowDialog(this);                
            }
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
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetShippingRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

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
        private DataTable createEmptyTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("shippingsysid");
            dt.Columns.Add("shippingno");
            dt.Columns.Add("packingboxno");
            dt.Columns.Add("containerno");
            dt.Columns.Add("blno");
            dt.Columns.Add("loadingtypetext");
            dt.Columns.Add("actcartonqty");
            dt.Columns.Add("emptycartonqty");            
            dt.Columns.Add("shippingstatus");
            dt.Columns.Add("shippeddate");
            return dt;
        }

        private DataTable GetSingleShipping(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=sysid}
                        };
                dt = client.GetShippingRecords(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];
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

        private DataTable GetShippingDtlForReport(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {                
                dt = client.GetShippingDtlForReport(baseForm.CurrentContextInfo, sysid).Tables[0];
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

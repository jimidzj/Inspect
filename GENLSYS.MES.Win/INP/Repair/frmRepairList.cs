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
using GENLSYS.MES.Utility;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace GENLSYS.MES.Win.INP.Repair
{
    public partial class frmRepairList : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmRepairList()
        {
            InitializeComponent();
            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { "customerid", "customername", "custorderno", "step", "workgroup", "styleno", "color", "size", "checktype", "curpairqty" });
        }
        #endregion

        #region Event
        private void frmRepairList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            this.grdQuery.DisplayLayout.Bands[0].Columns["customerid"].Hidden = true;

            this.ucToolbar1.SetRepairVisible(true);
            this.ucToolbar1.SetPrintVisible(true);
            this.ucToolbar1.SetNewVisible(false);
            this.ucToolbar1.SetDeleteVisible(false);
            this.ucToolbar1.SetEditVisible(false);
            this.ucToolbar1.SetExportVisible(false);

            this.pQuery.BackColor = Color.FromName("Info");

            GetData(new List<MESParameterInfo>() { });
        }

        private void ucToolbar1_QueryEventHandler(object sender, EventArgs e)
        {
            if (pQuery.Visible == false)
                pQuery.Visible = true;
            else
                pQuery.Visible = false;
        }

        private void ucToolbar1_RepairEventHandler(object sender, EventArgs e)
        {
            if (this.grdQuery.ActiveRow != null)
            {
                frmRepair f = new frmRepair();
                tinprepairstock repairstock = new tinprepairstock();
                repairstock.customerid = this.grdQuery.ActiveRow.Cells["customerid"].Value.ToString();
                repairstock.custorderno = this.grdQuery.ActiveRow.Cells["custorderno"].Value.ToString();
                repairstock.styleno = this.grdQuery.ActiveRow.Cells["styleno"].Value.ToString();
                repairstock.size = this.grdQuery.ActiveRow.Cells["size"].Value.ToString();
                repairstock.color = this.grdQuery.ActiveRow.Cells["color"].Value.ToString();
                repairstock.checktype = this.grdQuery.ActiveRow.Cells["checktype"].Value.ToString();
                repairstock.curpairqty = Convert.ToInt16(this.grdQuery.ActiveRow.Cells["curpairqty"].Value.ToString());
                repairstock.step = this.grdQuery.ActiveRow.Cells["step"].Value.ToString();
                repairstock.workgroup = this.grdQuery.ActiveRow.Cells["workgroup"].Value.ToString();
                f.Customer = this.grdQuery.ActiveRow.Cells["customername"].Value.ToString();
                f.RepairStock = repairstock;
                f.ShowDialog();
                RefreshGrid();
            }
        }

        private void ucToolbar1_PrintEventHandler(object sender, EventArgs e)
        {
            frmRepairRpt frm = new frmRepairRpt();
            frm.ShowDialog(this);
        }

        private void ucToolbar1_ExitEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["size"].SortComparer = new SizeComparer();

            if (!e.Layout.ValueLists.Exists("vlstep"))
            {
                e.Layout.ValueLists.Add("vlstep");
                e.Layout.ValueLists["vlstep"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.Step));
                e.Layout.Bands[0].Columns["step"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["step"].ValueList = e.Layout.ValueLists["vlstep"];
            }
            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }
            if (!e.Layout.ValueLists.Exists("vlworkgroup"))
            {
                e.Layout.ValueLists.Add("vlworkgroup");
                e.Layout.ValueLists["vlworkgroup"].ValueListItems.AddRange(DropDown.GetValueList_DataTable(GetWorkGroup(), "workgroupdesc", "workgroup"));
                e.Layout.Bands[0].Columns["workgroup"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["workgroup"].ValueList = e.Layout.ValueLists["vlworkgroup"];
            }
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumCurpairqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumCurpairqty", SummaryType.Sum, e.Layout.Bands[0].Columns["curpairqty"], SummaryPosition.UseSummaryPositionColumn);
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

                DataSet ds = client.GetRepairStockRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

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
        private DataTable GetWorkGroup()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            DataTable dt = null;
            try
            {
                dt = client.GetWorkGroupRecords(baseForm.CurrentContextInfo, (new List<MESParameterInfo>()).ToArray<MESParameterInfo>()).Tables[0];
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

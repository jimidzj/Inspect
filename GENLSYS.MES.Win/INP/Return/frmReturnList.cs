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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace GENLSYS.MES.Win.INP.Return
{
    public partial class frmReturnList : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmReturnList()
        {
            InitializeComponent();
            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { "retsysid", "returnno","returntype", "customername", "custorderno", "styleno", "color", "size","checktype", "pairqty", "returndate", "returnuser" });
        }
        #endregion

        #region Event
        private void frmReturnList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            this.grdQuery.DisplayLayout.Bands[0].Columns["retsysid"].Hidden = true;
            //this.ucToolbar1.SetEditVisible(false);
            this.ucToolbar1.SetDeleteVisible(false);
            this.ucToolbar1.SetExportVisible(false);

            this.pQuery.BackColor = Color.FromName("Info");
        }

        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["returndate"].Format = "yyyy-MM-dd HH:mm:ss";

            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumPairqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[0].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
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
        private void ucToolbar1_NewEventHandler(object sender, EventArgs e)
        {
            frmReturn f = new frmReturn();
            f.ShowDialog();
            RefreshGrid();
        }
        private void ucToolbar1_EditEventHandler(object sender, EventArgs e)
        {
            if (this.grdQuery.ActiveRow != null)
            {
                frmReturn f = new frmReturn();
                f.retSysId = this.grdQuery.ActiveRow.Cells["retsysid"].Value.ToString();
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

                DataSet ds = client.GetReturnDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

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
        #endregion
                     

        
    }
}

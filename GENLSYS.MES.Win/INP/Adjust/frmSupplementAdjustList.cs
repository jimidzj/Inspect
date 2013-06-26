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
using Infragistics.Win.UltraWinGrid;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Win.INP.Adjust
{
    public partial class frmSupplementAdjustList : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmSupplementAdjustList()
        {
            InitializeComponent();
            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { "supldtlsysid", "supplementno", "customername", "custorderno", "step", "workgroup", "styleno", "color", "size","checktype", "pairqty", "isreinspect", "supplementdate", "supplementuser" });
        }
        #endregion

        #region Events
        private void frmSupplementAdjustList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            this.grdQuery.DisplayLayout.Bands[0].Columns["supldtlsysid"].Hidden = true;

            this.ucToolbar1.SetAdjustVisible(true);
            this.ucToolbar1.SetNewVisible(false);
            this.ucToolbar1.SetEditVisible(false);
            this.ucToolbar1.SetDeleteVisible(false);
            this.ucToolbar1.SetExportVisible(false);
            this.pQuery.BackColor = Color.FromName("Info");
        }

        private void ucToolbar1_AdjustEventHandler(object sender, EventArgs e)
        {
            frmSupplementAdjust f = new frmSupplementAdjust();
            f.suplDtlSysId = this.grdQuery.ActiveRow.Cells["supldtlsysid"].Value.ToString();
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

        private void ucToolbar1_ExitEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["supplementdate"].Format = "yyyy-MM-dd HH:mm:ss";

            UltraGridColumn column = e.Layout.Bands[0].Columns["isreinspect"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            column.Editor.DataFilter = new CheckEditorStringDataFilter();

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

                DataSet ds = client.GetSupplementDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

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

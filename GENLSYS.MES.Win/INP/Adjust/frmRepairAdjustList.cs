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
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Win.INP.Adjust
{
    public partial class frmRepairAdjustList : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmRepairAdjustList()
        {
            InitializeComponent();
            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { "repsysid", "customerid", "customername", "custorderno", "step", "workgroup", "reptype", "styleno", "color", "size", "checktype", "qty", "reasoncode", "isfirst", "claimuser", "claimtime" });
        }
        #endregion

        #region Event
        private void frmRepairAdjustList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            this.grdQuery.DisplayLayout.Bands[0].Columns["repsysid"].Hidden = true;
            this.grdQuery.DisplayLayout.Bands[0].Columns["customerid"].Hidden = true;

            this.ucToolbar1.SetAdjustVisible(true);
            this.ucToolbar1.SetNewVisible(false);
            this.ucToolbar1.SetDeleteVisible(false);
            this.ucToolbar1.SetEditVisible(false);
            //this.ucToolbar1.SetExportVisible(false);

            this.dtFromDate.Value = Function.GetCurrentTime();
            this.dtToDate.Value = Function.GetCurrentTime();
            DropDown.InitCMB_StaticValue(this.cmbRepairType, MES_StaticValue_Type.RepairType,true);
            this.cmbRepairType.SelectedIndex = 0;

            this.pQuery.BackColor = Color.FromName("Info");
        }

        private void ucToolbar1_AdjustEventHandler(object sender, EventArgs e)
        {
            frmRepairAdjust f = new frmRepairAdjust();
            tinprepairhis repairhis = new tinprepairhis();
            repairhis.repsysid = this.grdQuery.ActiveRow.Cells["repsysid"].Value.ToString();
            repairhis.customerid = this.grdQuery.ActiveRow.Cells["customerid"].Value.ToString();
            repairhis.custorderno = this.grdQuery.ActiveRow.Cells["custorderno"].Value.ToString();
            repairhis.styleno = this.grdQuery.ActiveRow.Cells["styleno"].Value.ToString();
            repairhis.size = this.grdQuery.ActiveRow.Cells["size"].Value.ToString();
            repairhis.color = this.grdQuery.ActiveRow.Cells["color"].Value.ToString();
            repairhis.pairqty = Convert.ToInt16(this.grdQuery.ActiveRow.Cells["pairqty"].Value.ToString());
            repairhis.step = this.grdQuery.ActiveRow.Cells["step"].Value.ToString();
            repairhis.workgroup = this.grdQuery.ActiveRow.Cells["workgroup"].Value.ToString();
            repairhis.reptype = this.grdQuery.ActiveRow.Cells["reptype"].Value.ToString();
            f.Customer = this.grdQuery.ActiveRow.Cells["customername"].Value.ToString();
            f.ReaseanCode = this.grdQuery.ActiveRow.Cells["reasoncode"].Value.ToString();
            f.RepairHis = repairhis;
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

        private void ucToolbar1_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.grdQuery);
        }

        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["repsysid"].Hidden = true;
            e.Layout.Bands[0].Columns["claimtime"].Format = "yyyy-MM-dd HH:mm:ss";
            e.Layout.Bands[0].Columns["size"].Width = 50;
            e.Layout.Bands[0].Columns["isfirst"].Width = 70;

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
            if (!e.Layout.ValueLists.Exists("vlreasoncode"))
            {
                e.Layout.ValueLists.Add("vlreasoncode");
                e.Layout.ValueLists["vlreasoncode"].ValueListItems.AddRange(DropDown.GetValueList_DataTable(GetReasonCode(), "reasoncodedesc", "reasoncode"));
                e.Layout.Bands[0].Columns["reasoncode"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["reasoncode"].ValueList = e.Layout.ValueLists["vlreasoncode"];
            }
        }

        private void grdQuery_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            if (e.Row.Cells["isfirst"].Value.ToString().Equals("Y"))
            {
                e.Row.Appearance.BackColor = Color.LightGreen;
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
                if (param.ParamName.Equals("reptype"))
                {
                    param.ParamValue = param.ParamValue + "%";
                }
                else
                {
                    param.ParamValue = "%" + param.ParamValue + "%";
                }
            }
            lstParameters.Add(new MESParameterInfo()
            {
                ParamName = "fromdate",
                ParamValue = dtFromDate.Value.ToString("yyyy-MM-dd")+" 00:00:00",
                ParamType = "date"
            });
            lstParameters.Add(new MESParameterInfo()
            {
                ParamName = "todate",
                ParamValue = dtToDate.Value.ToString("yyyy-MM-dd") + " 23:59:59",
                ParamType = "date"
            });
            GetData(lstParameters);
        }
        private void GetData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetRepairHisRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

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
        private DataTable GetReasonCode()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "reasoncategory",
                    ParamValue = "%" + MES_ReasonCategory.Repair.ToString() + "%",
                    ParamType = "string"
                });
                dt= client.GetReasonCodeRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).Tables[0];
               
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

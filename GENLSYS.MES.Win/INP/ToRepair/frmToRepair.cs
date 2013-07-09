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
using Infragistics.Win.UltraWinGrid;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.DataContracts;
using Infragistics.Win;

namespace GENLSYS.MES.Win.INP.ToRepair
{
    public partial class frmToRepair : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        private DataTable reasonCodeDt;
        
        #region Construct
        public frmToRepair()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdDetail, new string[] {"categoryindex", "reasoncode", "reasoncategorydesc", "ck", "reasoncodedesc", "pairqty", "remark" });
            baseForm.CreateUltraComboColumns(this.ucmbCustOrderNo, new string[] { "customerid", "custorderno", "styleno", "color", "size", "checktype", "leftqty" });
        }
        #endregion

        #region Event
        private void frmToRepair_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdDetail);
            baseForm.SetUltraComboStyle(this.ucmbCustOrderNo);
            baseForm.SetUltraComboResource(this.ucmbCustOrderNo, "|Label.R01025|Label.R01026|Label.R01027|Label.R01028|Label.R01065|Label.R02026");

            this.ucmbCustOrderNo.DisplayMember = "custorderno";
            this.ucmbCustOrderNo.ValueMember = "custorderno";
            this.ucmbCustOrderNo.DisplayLayout.Bands[0].Columns["customerid"].Hidden = true;
            this.ucmbCustOrderNo.DisplayLayout.Bands[0].Columns["size"].SortComparer = new SizeComparer();

            DropDown.InitCMB_StaticValue(this.cmbStep, MES_StaticValue_Type.Step);
            reasonCodeDt=GetReasonCodeDataTable();
            GetReasonCode("");

        }

        private void grdDetail_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Bands[0].Columns["ck"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.HeaderCheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
            e.Layout.Override.HeaderCheckBoxAlignment = HeaderCheckBoxAlignment.Center;
            e.Layout.Override.BorderStyleCell = UIElementBorderStyle.Solid;
            e.Layout.Override.BorderStyleRow = UIElementBorderStyle.Solid;

            UltraGridColumn column = e.Layout.Bands[0].Columns["ck"];
            //column.Header.Caption = "";
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            column.Editor.DataFilter = new CheckEditorStringDataFilter();
            column.Width = 40;

            e.Layout.Bands[0].Columns["reasoncategorydesc"].MergedCellStyle = MergedCellStyle.Always;
            e.Layout.Bands[0].Columns["reasoncategorydesc"].Width = 80;

            e.Layout.Bands[0].Columns["reasoncodedesc"].Width = 100;
            e.Layout.Bands[0].Columns["pairqty"].Width = 60;
            e.Layout.Bands[0].Columns["remark"].Width = 250;

            e.Layout.Bands[0].Columns["reasoncode"].Hidden = true;
            e.Layout.Bands[0].Columns["categoryindex"].Hidden = true;

            e.Layout.Bands[0].Columns["pairqty"].CellActivation = Activation.AllowEdit;
            e.Layout.Bands[0].Columns["pairqty"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegativeWithSpin;

            e.Layout.Bands[0].Columns["remark"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumPairqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[0].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
            }
        }

        private void grdDetail_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "pairqty" || e.Cell.Column.Key == "ck")
            {
                int total=0;
                foreach (UltraGridRow row in this.grdDetail.Rows)
                {
                    if (row.Cells["ck"].Value.ToString().Equals("Y"))
                    {
                        total  += (int)row.Cells["pairqty"].Value;
                    }
                }
                this.numRepairQty.Value = total;
            }
        }

        private void grdDetail_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if ((Convert.ToInt16(e.Row.Cells["categoryindex"].Value) % 2) == 0)
            {
                e.Row.Appearance.BackColor = Color.LightGreen;
            }
            else
            {
                e.Row.Appearance.BackColor = Color.White;
            }
        }

        private void cmbStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string step = ((ValueInfo)this.cmbStep.SelectedItem).ValueField;
            DataTable wgDt = GetWorkGroupRecordsByStep(step).Tables[0];
            DropDown.InitCMB_DataTable(this.cmbWorkGroup, wgDt,  "workgroupdesc","workgroup");
            GetCustOrder(step, "");
            GetReasonCode(step);
        }

        private void cmbWorkGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbWorkGroup.SelectedItem != null)
            {
                string step = ((ValueInfo)this.cmbStep.SelectedItem).ValueField;
                string workgroup = ((ValueInfo)this.cmbWorkGroup.SelectedItem).ValueField;
                GetCustOrder(step, workgroup);
            }
        }


        private void ucmbCustOrderNo_ValueChanged(object sender, EventArgs e)
        {
            if (this.ucmbCustOrderNo.SelectedRow != null)
            {
                this.txtStyleNo.Text = this.ucmbCustOrderNo.SelectedRow.Cells["styleno"].Value.ToString();
                this.txtColor.Text = this.ucmbCustOrderNo.SelectedRow.Cells["color"].Value.ToString();
                this.txtSize.Text = this.ucmbCustOrderNo.SelectedRow.Cells["size"].Value.ToString();
                this.txtPairQty.Text = this.ucmbCustOrderNo.SelectedRow.Cells["leftqty"].Value.ToString();
                this.numRepairQty.Enabled = true;
            }
            else
            {
                this.txtStyleNo.Text = "";
                this.txtColor.Text = "";
                this.txtSize.Text = "";
                this.txtPairQty.Text = "";
                this.numRepairQty.Enabled = false;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnToRepair_Click(object sender, EventArgs e)
        {
            DoRepair(true);
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            DoRepair(false);
        }
        #endregion

        #region Method
        private void DoRepair(bool closeFlag)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try{
                baseForm.SetCursor();
                baseForm.ValidateData(this);
                if (this.numRepairQty.Value > Convert.ToInt16(this.txtPairQty.Text))
                {
                    throw new Exception(UtilCulture.GetString("Msg.R01014", UtilCulture.GetString("Label.R02026"), UtilCulture.GetString("Label.R02036")));
                }

                tinprepairhis his = new tinprepairhis();
                his.repsysid = Function.GetGUID();
                his.workgroup = ((ValueInfo)this.cmbWorkGroup.SelectedItem).ValueField;
                his.step = ((ValueInfo)this.cmbStep.SelectedItem).ValueField;
                his.reptype = MES_RepairType.ToRepair.ToString();
                his.customerid = this.ucmbCustOrderNo.SelectedRow.Cells["customerid"].Value.ToString();
                his.custorderno = this.ucmbCustOrderNo.Value.ToString();
                his.styleno = this.txtStyleNo.Text;
                his.color = this.txtColor.Text;
                his.size = this.txtSize.Text;
                his.checktype = this.ucmbCustOrderNo.SelectedRow.Cells["checktype"].Value.ToString();
                his.isfirst = this.ckIsFirst.Checked ? MES_Misc.Y.ToString() : MES_Misc.N.ToString();
                his.pairqty = this.numRepairQty.Value;
                his.claimtime = Function.GetCurrentTime();
                his.claimuser = Function.GetCurrentUser();

                List<tinprepairfail> lstreasoncode = new List<tinprepairfail>();

                foreach (UltraGridRow row in this.grdDetail.Rows)
                {
                    if (row.Cells["ck"].Value.ToString().Equals("Y"))
                    {
                        if (Convert.ToDecimal(row.Cells["pairqty"].Value)==0)
                        {
                            throw new Exception(UtilCulture.GetString("Msg.R01016", UtilCulture.GetString("Label.R02036")));
                        }
                        tinprepairfail repairfail = new tinprepairfail();
                        repairfail.reasoncode = row.Cells["reasoncode"].Value.ToString();
                        repairfail.remark = row.Cells["remark"].Value.ToString();
                        repairfail.pairqty = Convert.ToDecimal(row.Cells["pairqty"].Value);
                        lstreasoncode.Add(repairfail);
                    }
                }

                if (this.numRepairQty.Value == 0)
                {
                    throw new Exception(UtilCulture.GetString("Msg.R01016", UtilCulture.GetString("Label.R02036")));
                }
                if (lstreasoncode.Count == 0)
                {
                    throw new Exception(UtilCulture.GetString("Msg.R01015"));
                }

                client.DoInsertRepair(baseForm.CurrentContextInfo, his, lstreasoncode.ToArray<tinprepairfail>());                
                baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));
                if (closeFlag)
                {
                    this.Close();
                }
                else
                {
                    Clean();
                }
                
            }
            catch (Exception ex)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, ex.Message);
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
        }

        private void Clean()
        {
            this.cmbStep.SelectedIndex = 0;
            string step = ((ValueInfo)this.cmbStep.SelectedItem).ValueField;
            DataTable wgDt = GetWorkGroupRecordsByStep(step).Tables[0];
            DropDown.InitCMB_DataTable(this.cmbWorkGroup, wgDt, "workgroupdesc", "workgroup");
            GetCustOrder(step, "");
            foreach (UltraGridRow row in this.grdDetail.Rows)
            {
                row.Cells["ck"].Value = "N";
                row.Cells["pairqty"].Value = 0;
                row.Cells["remark"].Value = "";
            }

        }
             
        private DataSet GetWorkGroupRecordsByStep(string step)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            DataSet ds = null;
            try
            {
                baseForm.SetCursor();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "step",
                    ParamValue = step,
                    ParamType = "string"
                });
                ds = client.GetWorkGroupRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
            return ds;
        }

        private void GetCustOrder(string step,string workgroup)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "status",
                    ParamValue = step,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "workgroup",
                    ParamValue = workgroup,
                    ParamType = "string"
                });
                DataSet ds = client.GetLeftWipRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                ds.Tables[0].DefaultView.Sort = "custorderno asc";
                this.ucmbCustOrderNo.SetDataBinding(ds.Tables[0], "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
        }


        private DataTable GetReasonCodeDataTable()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "reasoncategory",
                    ParamValue = "%" + MES_ReasonCategory.Repair.ToString() + "%",
                    ParamType = "string"
                });
                return client.GetReasonCodeRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
        }

        private void GetReasonCode(string step)
        {
            try
            {
                DataTable dt = reasonCodeDt;
                DataView dv = dt.DefaultView;
                if (step.Equals("I"))
                {
                    dv.RowFilter = "reasoncategory LIKE '%检品%'";
                }
                else if (step.Equals("X"))
                {
                    dv.RowFilter = "reasoncategory LIKE '%X线%'";
                }
                else
                {
                    dv.RowFilter = "reasoncategory =''";
                }
                dv.Sort = "reasoncategorydesc asc";
                dt = dv.ToTable();

                int categoryIndex = 0;
                string beforecategory = "";

                if (dt != null)
                {
                    dt.Columns.Add(new DataColumn("ck", typeof(string)));
                    dt.Columns.Add(new DataColumn("pairqty", typeof(int)));
                    dt.Columns.Add(new DataColumn("remark", typeof(string)));
                    dt.Columns.Add(new DataColumn("categoryindex", typeof(int)));

                    foreach (DataRow row in dt.Rows)
                    {
                        if (!row["reasoncategorydesc"].ToString().Equals(beforecategory))
                        {
                            beforecategory = row["reasoncategorydesc"].ToString();
                            categoryIndex++;
                        }
                        row["ck"] = "N";
                        row["pairqty"] = 0;
                        row["remark"] = "";
                        row["categoryindex"] = categoryIndex;
                    }
                    this.grdDetail.SetDataBinding(dt, "");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

               

        
    }
}

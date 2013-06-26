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
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace GENLSYS.MES.Win.INP.Repair
{
    public partial class frmRepair : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public string Customer { get; set; }
        public tinprepairstock RepairStock { get; set; }
        

        #region Construct
        public frmRepair()
        {
            InitializeComponent();

            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdDetail, new string[] { "categoryindex", "reasoncode", "reasoncategorydesc", "ck", "reasoncodedesc", "pairqty", "remark" });
        }
        #endregion

        #region Events
        private void frmRepair_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdDetail);
            this.txtCustOrderNo.Text = RepairStock.custorderno;
            this.txtCustomer.Text = Customer;
            this.txtStyleNo.Text = RepairStock.styleno;
            this.txtColor.Text = RepairStock.color;
            this.txtSize.Text = RepairStock.size;
            this.txtRepairQty.Text = RepairStock.curpairqty.ToString();

            DropDown.InitCMB_StaticValue(this.cmbToStep, MES_StaticValue_Type.Step);
            DropDown.InitCMB_StaticValue(this.cmbJointType, MES_StaticValue_Type.JointType,true);
            DropDown.SelectCMBValue(this.cmbToStep, RepairStock.step);
            this.cmbJointType.SelectedIndex = 0;

            this.cmbToStep.Enabled = false;
            this.cmbWorkGroup.Enabled = false;

            

            GetReasonCode();
        }
        private void cmbToStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string step = ((ValueInfo)this.cmbToStep.SelectedItem).ValueField;
            DataTable wgDt = GetWorkGroupRecordsByStep(step).Tables[0];
            DropDown.InitCMB_DataTable(this.cmbWorkGroup, wgDt, "workgroupdesc", "workgroup");
            DropDown.SelectCMBValue(this.cmbWorkGroup, RepairStock.workgroup);
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
        private void grdDetail_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Key == "pairqty" || e.Cell.Column.Key == "ck")
            {
                int total = 0;
                foreach (UltraGridRow row in this.grdDetail.Rows)
                {
                    if (row.Cells["ck"].Value.ToString().Equals("Y"))
                    {
                        total += (int)row.Cells["pairqty"].Value;
                    }
                }
                this.numFailedQty.Value = total;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoRepair();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
             

        #region Method
        private void DoRepair()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();
                baseForm.ValidateData(this);
                if (((ValueInfo)this.cmbJointType.SelectedItem).ValueField != "")
                {
                    if (((ValueInfo)this.cmbJointType.SelectedItem).ValueField.Equals("签名") && this.txtSignature.Text.Trim() == "")
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01020", UtilCulture.GetString("Label.R010763")));
                    }
                    if (this.numFailedQty.Value > 0)
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01014", UtilCulture.GetString("Label.R01076"), "0"));
                    }
                }

                if (this.numSuccessQty.Value == 0 && this.numFailedQty.Value == 0)
                {
                    throw new Exception(UtilCulture.GetString("Msg.R01017", UtilCulture.GetString("Label.R01075"), UtilCulture.GetString("Label.R01076")));
                }
                if ((this.numSuccessQty.Value + this.numFailedQty.Value) > RepairStock.curpairqty)
                {
                    throw new Exception(UtilCulture.GetString("Msg.R01014", UtilCulture.GetString("Label.R01075") + "+" + UtilCulture.GetString("Label.R01076"), UtilCulture.GetString("Label.R01074")));
                }

                tinprepairstock repairstock = new tinprepairstock();
                repairstock.customerid = RepairStock.customerid;
                repairstock.custorderno = this.txtCustOrderNo.Text;
                repairstock.styleno = this.txtStyleNo.Text;
                repairstock.color = this.txtColor.Text;
                repairstock.size = this.txtSize.Text;
                repairstock.checktype = RepairStock.checktype;
                repairstock.ttlpairgoodqty = this.numSuccessQty.Value;
                repairstock.ttlbadqty = this.numFailedQty.Value;
                repairstock.step = ((ValueInfo)this.cmbToStep.SelectedItem).ValueField;
                repairstock.workgroup = ((ValueInfo)this.cmbWorkGroup.SelectedItem).ValueField;

                List<tinprepairfail> lstreasoncode = new List<tinprepairfail>();

                foreach (UltraGridRow row in this.grdDetail.Rows)
                {
                    if (row.Cells["ck"].Value.ToString().Equals("Y"))
                    {
                        if (Convert.ToDecimal(row.Cells["pairqty"].Value) == 0)
                        {
                            throw new Exception(UtilCulture.GetString("Msg.R01016", UtilCulture.GetString("Label.R010761")));
                        }
                        tinprepairfail repairfail = new tinprepairfail();
                        repairfail.reasoncode = row.Cells["reasoncode"].Value.ToString();
                        repairfail.remark = row.Cells["remark"].Value.ToString();
                        repairfail.pairqty = Convert.ToDecimal(row.Cells["pairqty"].Value);
                        lstreasoncode.Add(repairfail);
                    }
                }

                client.DoRepairBack(baseForm.CurrentContextInfo, repairstock, lstreasoncode.ToArray<tinprepairfail>(), ((ValueInfo)this.cmbJointType.SelectedItem).ValueField,this.txtSignature.Text.Trim());
                baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));
                this.Close();
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
        private void GetReasonCode()
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
                DataTable dt = client.GetReasonCodeRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).Tables[0];
                DataView dv = dt.DefaultView;
                dv.RowFilter = "reasoncategory LIKE '%全检%'";
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
            finally
            {
                baseForm.CloseWCF(client);
            }
        }
        #endregion

        

        

        
    }
}

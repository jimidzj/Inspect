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
using GENLSYS.MES.Common;
using Infragistics.Win.UltraWinGrid;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;
using Infragistics.Win;

namespace GENLSYS.MES.Win.INP.Supplement
{
    public partial class frmSupplement : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;
        private string ReceivingNoNamingRule = string.Empty;
        private string BillLockRefId = string.Empty;
        private bool IsNeedToUnlockBill = false;

        #region Construct
        public frmSupplement()
        {
            InitializeComponent();

            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdDetail, new string[] { "custorderno", "styleno", "color", "size", "checktype", "pairqty", "isreinspect" });
        }
        #endregion

        #region Events
        private void frmComplement_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdDetail);

            DataTable custDt = GetAllCustomer().Tables[0];
            DropDown.InitCMB_DataTable(this.cmbCustomer, custDt, "customername", "customerid");

            DropDown.InitCMB_StaticValue(this.cmbStep, MES_StaticValue_Type.Step);

            this.grdDetail.SetDataBinding(createEmptyTable(), "");


            BillLockRefId = Function.GetGUID();
            ReceivingNoNamingRule = baseForm.GetSystemConfig("SYS_SUPPLEMENTNO");
            List<string> lstRecNo = baseForm.GetBillNoBatch(ReceivingNoNamingRule, 1, BillLockRefId);
            this.txtSupplementNo.Text = lstRecNo[0];
            //this.txtSupplementNo.Enabled = false;
            baseForm.SetControlReadOnly(this.txtSupplementNo,true);
            IsNeedToUnlockBill = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSupplement();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdDetail_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.CellClickAction = CellClickAction.Edit;

            e.Layout.Bands[0].Columns["styleno"].CellActivation = Activation.AllowEdit;
            e.Layout.Bands[0].Columns["styleno"].CellClickAction = CellClickAction.Edit;

            if (!e.Layout.ValueLists.Exists("vlcolor"))
            {
                e.Layout.ValueLists.Add("vlcolor");
                e.Layout.ValueLists["vlcolor"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.ShoeColor));
                e.Layout.Bands[0].Columns["color"].CellActivation = Activation.AllowEdit;
                e.Layout.Bands[0].Columns["color"].CellClickAction = CellClickAction.Edit;
                e.Layout.Bands[0].Columns["color"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["color"].ValueList = e.Layout.ValueLists["vlcolor"];
            }
            if (!e.Layout.ValueLists.Exists("vlsize"))
            {
                e.Layout.ValueLists.Add("vlsize");
                e.Layout.ValueLists["vlsize"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.ShoeSize));
                e.Layout.Bands[0].Columns["size"].CellActivation = Activation.AllowEdit;
                e.Layout.Bands[0].Columns["size"].CellClickAction = CellClickAction.Edit;
                e.Layout.Bands[0].Columns["size"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["size"].ValueList = e.Layout.ValueLists["vlsize"];
                e.Layout.Bands[0].Columns["size"].Width = 40;
            }
            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].CellActivation = Activation.AllowEdit;
                e.Layout.Bands[0].Columns["checktype"].CellClickAction = CellClickAction.Edit;
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }
            e.Layout.Bands[0].Columns["pairqty"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            e.Layout.Bands[0].Columns["pairqty"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegativeWithSpin;
            e.Layout.Bands[0].Columns["pairqty"].Width = 40;

            e.Layout.Bands[0].Columns["isreinspect"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
           // e.Layout.Override.HeaderCheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
           // e.Layout.Override.HeaderCheckBoxAlignment = HeaderCheckBoxAlignment.Center;

            UltraGridColumn column = e.Layout.Bands[0].Columns["isreinspect"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            column.Editor.DataFilter = new CheckEditorStringDataFilter();

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumPairqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[0].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
            }
        }
        private void cmbStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string step = ((ValueInfo)this.cmbStep.SelectedItem).ValueField;
            DataTable wgDt = GetWorkGroupRecordsByStep(step).Tables[0];
            DropDown.InitCMB_DataTable(this.cmbWorkGroup, wgDt, "workgroupdesc", "workgroup");
        }
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            addDetail();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            delDetail();
        }

        #endregion

        #region Methods
        private void DoSupplement()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();
                baseForm.ValidateData(this);

                if (!isExistOrder(((ValueInfo)this.cmbCustomer.SelectedItem).ValueField,this.txtCustOrderNo.Text))
                {
                    throw new Exception(UtilCulture.GetString("Msg.R01021", this.txtCustOrderNo.Text));
                }

                tinpsupplement supplement = new tinpsupplement();
                supplement.suplsysid = Function.GetGUID();
                supplement.supplementno = this.txtSupplementNo.Text;
                supplement.customerid = ((ValueInfo)this.cmbCustomer.SelectedItem).ValueField;
                supplement.custorderno = this.txtCustOrderNo.Text;
                supplement.step = ((ValueInfo)this.cmbStep.SelectedItem).ValueField;
                supplement.workgroup = ((ValueInfo)this.cmbWorkGroup.SelectedItem).ValueField;
                supplement.factory = this.txtFactory.Text;
                supplement.supplementdate = Function.GetCurrentTime();
                supplement.supplementuser = Function.GetCurrentUser();
                supplement.lastmodifiedtime = Function.GetCurrentTime();
                supplement.lastmodifieduser = Function.GetCurrentUser();

                List<tinpsupplementdtl> lstsupplementdtl = new List<tinpsupplementdtl>();

                foreach (UltraGridRow row in this.grdDetail.Rows)
                {
                    if (row.Cells["styleno"].Value.ToString().Equals(string.Empty))
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01020", UtilCulture.GetString("Label.R01026")));
                    }
                    if (row.Cells["color"].Value.ToString().Equals(string.Empty))
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01020", UtilCulture.GetString("Label.R01027")));
                    }
                    if (row.Cells["size"].Value.ToString().Equals(string.Empty))
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01020", UtilCulture.GetString("Label.R01028")));
                    }
                    if (Convert.ToInt16(row.Cells["pairqty"].Value) == 0)
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01016", UtilCulture.GetString("Label.R02026")));
                    }

                    tinpsupplementdtl supplementdtl = new tinpsupplementdtl();
                    supplementdtl.supldtlsysid = Function.GetGUID();
                    supplementdtl.suplsysid = supplement.suplsysid;
                    supplementdtl.customerid = ((ValueInfo)this.cmbCustomer.SelectedItem).ValueField;
                    supplementdtl.custorderno = supplement.custorderno;
                    supplementdtl.styleno = row.Cells["styleno"].Value.ToString();
                    supplementdtl.color = row.Cells["color"].Value.ToString();
                    supplementdtl.size = row.Cells["size"].Value.ToString();
                    supplementdtl.checktype = row.Cells["checktype"].Value.ToString();
                    supplementdtl.pairqty = Convert.ToInt16(row.Cells["pairqty"].Value);
                    supplementdtl.isreinspect = row.Cells["isreinspect"].Value.ToString();
                    lstsupplementdtl.Add(supplementdtl);
                }

                if (lstsupplementdtl.Count == 0)
                {
                    throw new Exception(UtilCulture.GetString("Msg.R01019"));
                }

                client.DoSupplement(baseForm.CurrentContextInfo, supplement, lstsupplementdtl.ToArray<tinpsupplementdtl>());
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
        private DataSet GetAllCustomer()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            DataSet ds = null;
            try
            {
                baseForm.SetCursor();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                ds = client.GetCustomerRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
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

        private bool isExistOrder(string customerid, string custorderno)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            bool result=false;
            try
            {
                baseForm.SetCursor();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "customerid",
                    ParamValue = customerid,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "custorderno",
                    ParamValue = custorderno,
                    ParamType = "string"
                });
                DataSet ds = client.GetReceivingDetailRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
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
            return result;
        }

        private DataTable createEmptyTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("custorderno");
            dt.Columns.Add("styleno");
            dt.Columns.Add("color");
            dt.Columns.Add("size");
            dt.Columns.Add("checktype");
            dt.Columns.Add("pairqty");
            dt.Columns.Add("isreinspect");            
            return dt;
        }

        private void addDetail()
        {
            DataTable dt = this.grdDetail.DataSource as DataTable;
            DataRow row = dt.NewRow();
            row.ItemArray = new object[] {
                this.txtCustOrderNo.Text,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                0,
                MES_Misc.N.ToString()
            };
            dt.Rows.Add(row);
        }

        private void delDetail()
        {
            if (this.grdDetail.Selected.Rows.Count < 1) return;

            for (int i = this.grdDetail.Selected.Rows.Count - 1; i >= 0; i--)
            {
                this.grdDetail.Rows[this.grdDetail.Selected.Rows[i].Index].Delete(false);
            }
        }
        #endregion
                
    }
}

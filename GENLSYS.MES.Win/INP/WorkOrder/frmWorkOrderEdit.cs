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
using Infragistics.Win.UltraWinGrid;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Infragistics.Win;

namespace GENLSYS.MES.Win.INP.WorkOrder
{
    public partial class frmWorkOrderEdit : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;
        private tinpworkorder OriginalWorkOrder;
        private string WONoNamingRule = string.Empty;
        private string BillLockRefId = string.Empty;
        private bool IsNeedToUnlockBill = false;

        #region Construct
        public frmWorkOrderEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();

            baseForm.CreateUltraGridColumns(this.grdDetail, new string[] { "workordersysid","workorderlineno", "custorderno", 
                "styleno", "schcartonqty", "schpairqty", "schdlydate","schshpdate", "checktype", "remark","completedtime","completeduser" });
        }
        #endregion

        #region Events
        private void frmWorkOrderEdit_Load(object sender, EventArgs e)
        {
            try
            {
                baseForm.SetFace(this);
                baseForm.SetQueryGridStyle(this.grdDetail);
                SetLayout();

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    //this.txtWorkOrderNo.ReadOnly = true;
                    baseForm.SetControlReadOnly(this.txtWorkOrderNo, true);
                    DoShowSingleObject<tinpworkorder>(PrimaryKeys);
                }
                else
                {

                    BillLockRefId = Function.GetGUID();
                    WONoNamingRule = baseForm.GetSystemConfig("SYS_WONO");

                    List<string> lstRecNo = baseForm.GetBillNoBatch(WONoNamingRule, 1, BillLockRefId);
                    this.txtWorkOrderNo.Text = lstRecNo[0];

                    IsNeedToUnlockBill = true;

                    DoShowEmptyData();

                    this.cboWOStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
        }

        private void grdDetail_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdDetail.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.grdDetail.DisplayLayout.Override.CellClickAction = CellClickAction.Edit;

            //set check type
            if (!this.grdDetail.DisplayLayout.ValueLists.Exists("vlchecktype"))
            {
                this.grdDetail.DisplayLayout.ValueLists.Add("vlchecktype");
                this.grdDetail.DisplayLayout.ValueLists["vlchecktype"].ValueListItems.AddRange(GENLSYS.MES.Win.Common.Classes.DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                this.grdDetail.DisplayLayout.Bands[0].Columns["checktype"].CellActivation = Activation.AllowEdit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["checktype"].CellClickAction = CellClickAction.Edit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdDetail.DisplayLayout.Bands[0].Columns["checktype"].ValueList = this.grdDetail.DisplayLayout.ValueLists["vlchecktype"];
            }

            //others
            this.grdDetail.DisplayLayout.Bands[0].Columns["schcartonqty"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["schcartonqty"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegative;

            this.grdDetail.DisplayLayout.Bands[0].Columns["schpairqty"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["schpairqty"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegative;

            this.grdDetail.DisplayLayout.Bands[0].Columns["schdlydate"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["schdlydate"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.grdDetail.DisplayLayout.Bands[0].Columns["schdlydate"].Format = "yyyy-MM-dd";

            this.grdDetail.DisplayLayout.Bands[0].Columns["schshpdate"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["schshpdate"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.grdDetail.DisplayLayout.Bands[0].Columns["schshpdate"].Format = "yyyy-MM-dd";

            this.grdDetail.DisplayLayout.Bands[0].Columns["custorderno"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["styleno"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["remark"].CellActivation = Activation.AllowEdit;

            this.grdDetail.DisplayLayout.Bands[0].Columns["completedtime"].CellAppearance.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.grdDetail.DisplayLayout.Bands[0].Columns["completedtime"].CellAppearance.BackColor2 = Color.FromKnownColor(KnownColor.Control);

            this.grdDetail.DisplayLayout.Bands[0].Columns["completeduser"].CellAppearance.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.grdDetail.DisplayLayout.Bands[0].Columns["completeduser"].CellAppearance.BackColor2 = Color.FromKnownColor(KnownColor.Control);
            
            //hide column
            this.grdDetail.DisplayLayout.Bands[0].Columns["workordersysid"].Hidden = true;
            this.grdDetail.DisplayLayout.Bands[0].Columns["workorderlineno"].Hidden = true;
            this.grdDetail.DisplayLayout.Bands[0].Columns["completedtime"].Hidden = true;
            this.grdDetail.DisplayLayout.Bands[0].Columns["completeduser"].Hidden = true;

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumSchcartonqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumSchcartonqty", SummaryType.Sum, e.Layout.Bands[0].Columns["schcartonqty"], SummaryPosition.UseSummaryPositionColumn);
            }
            if (!e.Layout.Bands[0].Summaries.Exists("SumSchpairqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumSchpairqty", SummaryType.Sum, e.Layout.Bands[0].Columns["schpairqty"], SummaryPosition.UseSummaryPositionColumn);
            }
        }

        private void grdDetail_CellChange(object sender, CellEventArgs e)
        {
            
        }

        private void grdDetail_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell.Column.Key == "custorderno" || e.Cell.Column.Key == "styleno")
            {
                if (e.Cell.Text.ToString() == string.Empty)
                    e.Cancel = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSaveSingleObject();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            InsertCustOrder();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteCustOrder();
        }

        private void frmWorkOrderEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetBill();
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();

            if (UpdateMode == Public_UpdateMode.Update)
            {
            }
        }

        private void SetCombobox()
        {
            GENLSYS.MES.Win.Common.Classes.DropDown.InitCMB_Customer_All(this.cboCustomer);
            GENLSYS.MES.Win.Common.Classes.DropDown.InitCMB_StaticValue(this.cboWOStatus, MES_StaticValue_Type.WOStatus);
        }

        public void DoSaveSingleObject()
        {

            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                #region Validate & build object from UI
                baseForm.ValidateData(this);

                if (!CheckBeforeSave()) return;

                tinpworkorder workorder = new tinpworkorder();

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    workorder = OriginalWorkOrder;
                }

                //Build Product Ext Object
                baseForm.CreateSingleObject<tinpworkorder>(workorder, this, UpdateMode);

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    workorder.workordersysid = Function.GetGUID();
                }


                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    workorder.createdtime = Function.GetCurrentTime();
                    workorder.createduser = Function.GetCurrentUser();
                }

                workorder.lastmodifiedtime = Function.GetCurrentTime();
                workorder.lastmodifieduser = Function.GetCurrentUser();

                if (workorder.workorderstatus.Trim() == string.Empty)
                    workorder.workorderstatus = "Active";

                #endregion

                #region Prepare Work Order Detail
                List<tinpworkorderdtl> lstDtl = new List<tinpworkorderdtl>();
                for (int i = 0; i < grdDetail.Rows.Count; i++)
                {
                    tinpworkorderdtl dtl = new tinpworkorderdtl();

                    dtl.workordersysid = workorder.workordersysid;
                    dtl.custorderno = this.grdDetail.Rows[i].Cells["custorderno"].Value.ToString();
                    dtl.styleno = this.grdDetail.Rows[i].Cells["styleno"].Value.ToString();


                    if (this.grdDetail.Rows[i].Cells["schcartonqty"].Value == null)
                        dtl.schcartonqty = 0;
                    else
                        dtl.schcartonqty = decimal.Parse(this.grdDetail.Rows[i].Cells["schcartonqty"].Value.ToString());

                    if (this.grdDetail.Rows[i].Cells["schpairqty"].Value == null)
                        dtl.schpairqty = 0;
                    else
                        dtl.schpairqty = decimal.Parse(this.grdDetail.Rows[i].Cells["schpairqty"].Value.ToString());

                    dtl.completeduser = string.Empty;
                    if (this.grdDetail.Rows[i].Cells["schdlydate"].Value.ToString() == string.Empty)
                        dtl.schdlydate = null;
                    else
                        dtl.schdlydate = DateTime.Parse(this.grdDetail.Rows[i].Cells["schdlydate"].Value.ToString());

                    if (this.grdDetail.Rows[i].Cells["schshpdate"].Value.ToString() == string.Empty)
                        dtl.schshpdate = null;
                    else
                        dtl.schshpdate = DateTime.Parse(this.grdDetail.Rows[i].Cells["schshpdate"].Value.ToString());

                    dtl.checktype = this.grdDetail.Rows[i].Cells["checktype"].Value.ToString();
                    dtl.remark = this.grdDetail.Rows[i].Cells["remark"].Value.ToString();
                    dtl.workorderlineno = this.grdDetail.Rows[i].Cells["workorderlineno"].Value.ToString().ToString();

                    baseForm.PrepareObject<tinpworkorderdtl>(dtl, Public_UpdateMode.Insert);
                    lstDtl.Add(dtl);
                }
                #endregion

                #region call WCF

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.DoInsertWorkOrder(baseForm.CurrentContextInfo, workorder,
                        lstDtl.ToArray<tinpworkorderdtl>());
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.DoUpdateWorkOrder(baseForm.CurrentContextInfo, workorder,
                        lstDtl.ToArray<tinpworkorderdtl>());
                }
                #endregion

                if (UpdateMode == Public_UpdateMode.Insert)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                else if (UpdateMode == Public_UpdateMode.Update)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));

                IsNeedToUnlockBill = false;

                this.Close();
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

        public void DoShowSingleObject<T>(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                #region Show to UI
                tinpworkorder workorder = client.GetSingleWorkOrder(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                OriginalWorkOrder = workorder;
                baseForm.ShowSingleObjectToUI<tinpworkorder>(workorder, this);
                #endregion

                #region Show work order detail
                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>()
                {
                    new MESParameterInfo()
                    {
                        ParamName="workordersysid",
                        ParamValue=workorder.workordersysid,
                        ParamType="string"
                    }
                };

                DataSet ds = client.GetWorkOrderDetailRecords(baseForm.CurrentContextInfo, lstParameter.ToArray<MESParameterInfo>());
                this.grdDetail.DataSource = ds.Tables[0];
                #endregion
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

        public void DoShowEmptyData()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                #region Show flow
                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>()
                {
                    new MESParameterInfo()
                    {
                        ParamName="workordersysid",
                        ParamValue=MES_DummyData.Dummy_Data_XXX_111.ToString(),
                        ParamType="string"
                    }
                };

                DataSet ds = client.GetWorkOrderDetailRecords(baseForm.CurrentContextInfo, lstParameter.ToArray<MESParameterInfo>());
                this.grdDetail.DataSource = ds.Tables[0];
                #endregion
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
       
        private bool CheckBeforeSave()
        {
            if (!CheckDuplicated())
                return false;

            return true;          
        }

        private void InsertCustOrder()
        {
            System.Data.DataTable dt = this.grdDetail.DataSource as System.Data.DataTable;
            DataRow row = dt.NewRow();
            row.ItemArray = new object[] {string.Empty,
                ((this.grdDetail.Rows.Count+1)*10).ToString(), string.Empty, string.Empty,0,0,
                null,null,string.Empty, string.Empty, null,null};
            dt.Rows.Add(row);
        }

        private void DeleteCustOrder()
        {
            if (this.grdDetail.Selected.Rows.Count < 1) return;

            for (int i = this.grdDetail.Selected.Rows.Count - 1; i >= 0; i--)
            {
                this.grdDetail.Rows[this.grdDetail.Selected.Rows[i].Index].Delete(false);
            }
        }

        private bool CheckDuplicated()
        {
            string custorderno = string.Empty;
            string styleno = string.Empty;
            string checktype = string.Empty;
            string lineno = string.Empty;

            for (int i = 0; i < this.grdDetail.Rows.Count; i++)
            {
                custorderno = this.grdDetail.Rows[i].Cells["custorderno"].Value.ToString();
                styleno = this.grdDetail.Rows[i].Cells["styleno"].Value.ToString();
                checktype = this.grdDetail.Rows[i].Cells["checktype"].Value.ToString();
                lineno = this.grdDetail.Rows[i].Cells["workorderlineno"].Value.ToString();

                if (decimal.Parse(this.grdDetail.Rows[i].Cells["schcartonqty"].Value.ToString()) <= 0)
                {
                    MESMsgBox.ShowError("Line: " + lineno + "," + UtilCulture.GetString("Msg.R01002"));
                    return false;
                }

                if (decimal.Parse(this.grdDetail.Rows[i].Cells["schpairqty"].Value.ToString()) <= 0)
                {
                    MESMsgBox.ShowError("Line: " + lineno + "," + UtilCulture.GetString("Msg.R01003"));
                    return false;
                }

                for (int j = 0; j < this.grdDetail.Rows.Count; j++)
                {
                    if (custorderno == this.grdDetail.Rows[j].Cells["custorderno"].Value.ToString() &&
                        styleno == this.grdDetail.Rows[j].Cells["styleno"].Value.ToString() &&
                        checktype == this.grdDetail.Rows[j].Cells["checktype"].Value.ToString() &&
                        lineno != this.grdDetail.Rows[j].Cells["workorderlineno"].Value.ToString())
                    {
                        MESMsgBox.ShowError("[" + custorderno + "," + styleno + "," + checktype + "] " + UtilCulture.GetString("Msg.R01004"));
                        return false;
                    }
                }
            }

            return true;
        }

        private void ResetBill()
        {
            try
            {
                if (IsNeedToUnlockBill)
                {
                    baseForm.ResetBill(WONoNamingRule, BillLockRefId);
                }
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
        }
        #endregion

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cboWOStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = string.Empty;
            this.openFileDialog1.ShowDialog(this);
            string fileName = this.openFileDialog1.FileName;

            if (fileName.Trim() == string.Empty)
                return;

            Microsoft.Office.Interop.Excel.Application excel =
                new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = false;

            System.Data.DataTable dt = this.grdDetail.DataSource as System.Data.DataTable;

            try
            {
                Workbook wb = excel.Workbooks.Open(fileName, Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value);

                Worksheet sheet = wb.Sheets[1];

                string firstCell = sheet.Cells[5, 1].Value;

                if (firstCell.Trim() == string.Empty)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, "Excel没数据或数据格式错误");
                    return;
                }

                for (int i = 5; i < 5000; i++)
                {
                    if (sheet.Cells[i, 1].Value == null ||
                        sheet.Cells[i, 1].Value =="总   计：")
                        firstCell = string.Empty;
                    else
                        firstCell = sheet.Cells[i, 1].Value.ToString();

                    if (firstCell == null || firstCell.Trim() == string.Empty)
                        break;

                    DataRow dr = dt.NewRow();
                    dr.ItemArray = new object[] {
                        string.Empty,
                        ((this.grdDetail.Rows.Count+1)*10).ToString(),                        
                        sheet.Cells[i, 3].Value,
                        sheet.Cells[i, 4].Value,
                        int.Parse(sheet.Cells[i, 5].Value.ToString().Replace(".0","")),
                        int.Parse(sheet.Cells[i, 6].Value.ToString().Replace(".0","")),                        
                        sheet.Cells[i, 8].Value,
                        sheet.Cells[i, 9].Value,
                        sheet.Cells[i, 7].Value,
                        sheet.Cells[i, 10].Value,
                        null,
                        null
                    };
                    dt.Rows.Add(dr);
                }

                baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, "导入完成,请继续其他操作");

            }
            catch (Exception ex)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, "读取Excel错误." + ex.Message);
            }
            finally
            {
                excel.Quit();
            }
        }
        
    }
}

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

namespace GENLSYS.MES.Win.INP.Schedule
{
    public partial class frmSchedule : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;
        private decimal prevValue = 0;
        //private tinpworkorder OriginalWorkOrder;

        #region Construct
        public frmSchedule()
        {
            InitializeComponent();
            baseForm = new BaseForm();

            baseForm.CreateUltraGridColumns(this.grdDetail, new string[] { 
                "customerid","factory","fullcheckqty","xrayqty","ttlqty","remark"
            });
        }
        #endregion

        #region Events
        private void frmSchedule_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdDetail);
            SetLayout();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                this.cboYear.Enabled = false;
                this.cboMonth.Enabled = false;

                DoShowSingleObject<tinpschedule>(PrimaryKeys);
            }
            else
            {
                DoShowEmptyData();
            }
        }

        private void grdDetail_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdDetail.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.grdDetail.DisplayLayout.Override.CellClickAction = CellClickAction.Edit;

            //set customer
            if (!this.grdDetail.DisplayLayout.ValueLists.Exists("vlcustomer"))
            {
                this.grdDetail.DisplayLayout.ValueLists.Add("vlcustomer");
                this.grdDetail.DisplayLayout.ValueLists["vlcustomer"].ValueListItems.AddRange(DropDown.GetValueList_Customer_All());
                this.grdDetail.DisplayLayout.Bands[0].Columns["customerid"].CellActivation = Activation.AllowEdit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["customerid"].CellClickAction = CellClickAction.Edit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["customerid"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdDetail.DisplayLayout.Bands[0].Columns["customerid"].ValueList = this.grdDetail.DisplayLayout.ValueLists["vlcustomer"];
            }
           
            //others
            this.grdDetail.DisplayLayout.Bands[0].Columns["fullcheckqty"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["fullcheckqty"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegative;

            this.grdDetail.DisplayLayout.Bands[0].Columns["xrayqty"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["xrayqty"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegative;

            //misc
            this.grdDetail.DisplayLayout.Bands[0].Columns["factory"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["remark"].CellActivation = Activation.AllowEdit;

            //hide column
        }

        private void grdDetail_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell.Column.Key == "customerid" || e.Cell.Column.Key == "factory")
            {
                if (e.Cell.Text.ToString() == string.Empty)
                    e.Cancel = true;
            }

            if (e.Cell.Column.Key == "fullcheckqty" || e.Cell.Column.Key == "xrayqty")
            {
                prevValue = decimal.Parse(e.Cell.Value.ToString());
            }
         }

        private void grdDetail_AfterCellUpdate(object sender, CellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.Key == "fullcheckqty")
                {
                    grdDetail.ActiveRow.Cells["ttlqty"].Value =
                        decimal.Parse(grdDetail.ActiveRow.Cells["xrayqty"].Value.ToString()) +
                        decimal.Parse(e.Cell.Value.ToString());
                }

                if (e.Cell.Column.Key == "xrayqty")
                {
                    grdDetail.ActiveRow.Cells["ttlqty"].Value =
                        decimal.Parse(grdDetail.ActiveRow.Cells["fullcheckqty"].Value.ToString()) +
                        decimal.Parse(e.Cell.Value.ToString());
                }

            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ex.Message);
            }
        }

        private void grdDetail_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {

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
            InsertDetail();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteDetail();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboYear.Text != string.Empty && this.cboMonth.Text != string.Empty)
                ShowDetail();
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboYear.Text != string.Empty && this.cboMonth.Text != string.Empty)
                ShowDetail();
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
            DropDown.InitCMB_StaticValue(this.cboYear, MES_StaticValue_Type.Year);
            DropDown.InitCMB_StaticValue(this.cboMonth, MES_StaticValue_Type.Month);
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
                #endregion

                #region Prepare Work Order Detail
                List<tinpschedule> lstSchedule = new List<tinpschedule>();
                for (int i = 0; i < grdDetail.Rows.Count; i++)
                {
                    tinpschedule schedule = new tinpschedule();

                    schedule.customerid = this.grdDetail.Rows[i].Cells["customerid"].Value.ToString();
                    schedule.factory = this.grdDetail.Rows[i].Cells["factory"].Value.ToString();
                    schedule.remark = this.grdDetail.Rows[i].Cells["remark"].Value.ToString();
                    schedule.yearmonth = this.cboYear.Text + this.cboMonth.Text.PadLeft(2, '0');

                    if (this.grdDetail.Rows[i].Cells["fullcheckqty"].Value == null)
                        schedule.fullcheckqty = 0;
                    else
                        schedule.fullcheckqty = decimal.Parse(this.grdDetail.Rows[i].Cells["fullcheckqty"].Value.ToString());

                    if (this.grdDetail.Rows[i].Cells["xrayqty"].Value == null)
                        schedule.xrayqty = 0;
                    else
                        schedule.xrayqty = decimal.Parse(this.grdDetail.Rows[i].Cells["xrayqty"].Value.ToString());

                    if (this.grdDetail.Rows[i].Cells["ttlqty"].Value == null)
                        schedule.ttlqty = 0;
                    else
                        schedule.ttlqty = decimal.Parse(this.grdDetail.Rows[i].Cells["ttlqty"].Value.ToString());

                    baseForm.PrepareObject<tinpschedule>(schedule, Public_UpdateMode.Insert);
                    lstSchedule.Add(schedule);
                }
                #endregion

                #region call WCF
                client.DoUpdateSchedule(baseForm.CurrentContextInfo,
                        this.cboYear.Text + this.cboMonth.Text, lstSchedule.ToArray<tinpschedule>());

                //if (UpdateMode == Public_UpdateMode.Insert)
                //{
                //    client.DoInsertSchedule(baseForm.CurrentContextInfo,
                //        this.cboYear.Text + this.cboMonth.Text, lstSchedule.ToArray<tinpschedule>());
                //}

                //if (UpdateMode == Public_UpdateMode.Update)
                //{
                //    client.DoUpdateSchedule(baseForm.CurrentContextInfo,
                //        this.cboYear.Text + this.cboMonth.Text, lstSchedule.ToArray<tinpschedule>());
                //}
                #endregion

                if (UpdateMode == Public_UpdateMode.Insert)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                else if (UpdateMode == Public_UpdateMode.Update)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));

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
                this.cboYear.Text = lstParameters[0].ParamValue.Substring(0, 4);
                this.cboMonth.Text = lstParameters[0].ParamValue.Substring(4, 2);
                #endregion

                #region Show schedule detail
                List<MESParameterInfo> lstDtlParameter = new List<MESParameterInfo>() { 
                    new MESParameterInfo(){
                        ParamName="yearmonth",
                        ParamValue=this.cboYear.Text+this.cboMonth.Text.PadLeft(2,'0'),
                        ParamType="string"
                    }
                };

                DataSet ds = client.GetScheduleRecords(baseForm.CurrentContextInfo, lstDtlParameter.ToArray<MESParameterInfo>());
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
                        ParamName="yearmonth",
                        ParamValue=MES_DummyData.Dummy_Data_XXX_111.ToString(),
                        ParamType="string"
                    }
                };

                DataSet ds = client.GetScheduleRecords(baseForm.CurrentContextInfo, lstParameter.ToArray<MESParameterInfo>());
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

        private void ShowDetail()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                List<MESParameterInfo> lstDtlParameter = new List<MESParameterInfo>() { 
                    new MESParameterInfo(){
                        ParamName="yearmonth",
                        ParamValue=this.cboYear.Text+this.cboMonth.Text.PadLeft(2,'0'),
                        ParamType="string"
                    }
                };

                DataSet ds = client.GetScheduleRecords(baseForm.CurrentContextInfo, lstDtlParameter.ToArray<MESParameterInfo>());
                this.grdDetail.DataSource = ds.Tables[0];
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

        private void InsertDetail()
        {
            if (this.cboYear.Text == string.Empty ||
                this.cboMonth.Text == string.Empty)
            {
                MESMsgBox.ShowError(UtilCulture.GetString("Msg.R00261"));
                return;
            }

            DataTable dt = this.grdDetail.DataSource as DataTable;
            DataRow row = dt.NewRow();
            //"yearmonth","customerid","factory","fullcheckqty","xrayqty","ttlqty","remark","lastmodifiedtime","lastmodifieduser"
            row.ItemArray = new object[] {
               string.Empty,string.Empty,string.Empty,0,0,0,string.Empty,null,string.Empty
            };
            dt.Rows.Add(row);
        }

        private void DeleteDetail()
        {
            if (this.grdDetail.Selected.Rows.Count < 1) return;

            for (int i = this.grdDetail.Selected.Rows.Count - 1; i >= 0; i--)
            {
                this.grdDetail.Rows[this.grdDetail.Selected.Rows[i].Index].Delete(false);
            }
        }

        private bool CheckDuplicated()
        {
            string customerid = string.Empty;
            string customername = string.Empty;
            string factory = string.Empty;

            for (int i = 0; i < this.grdDetail.Rows.Count; i++)
            {
                customerid = this.grdDetail.Rows[i].Cells["customerid"].Value.ToString();
                customername = this.grdDetail.Rows[i].Cells["customerid"].Text;
                factory = this.grdDetail.Rows[i].Cells["factory"].Value.ToString();
                
                for (int j = 0; j < this.grdDetail.Rows.Count; j++)
                {
                    if (customerid == this.grdDetail.Rows[j].Cells["customerid"].Value.ToString() &&
                        factory == this.grdDetail.Rows[j].Cells["factory"].Value.ToString() &&
                        i != j)
                    {
                        MESMsgBox.ShowError("[" + customername + "," + factory + "] " + UtilCulture.GetString("Msg.R01004"));
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion
     }
}

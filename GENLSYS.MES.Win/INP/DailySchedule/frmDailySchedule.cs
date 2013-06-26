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
using Infragistics.Win.UltraWinGrid;

namespace GENLSYS.MES.Win.INP.DailySchedule
{
    public partial class frmDailySchedule : Form
    {
       private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmDailySchedule()
        {
            InitializeComponent();

            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();

            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { "prddate","checktype","custorderno","styleno","size","pairqty","ttlpairqty" });
        }
        #endregion

        #region Events
        private void ucToolbar1_DeleteEventHandler(object sender, EventArgs e)
        {
            DoDelete();
        }

        private void ucToolbar1_EditEventHandler(object sender, EventArgs e)
        {
            
        }

        private void ucToolbar1_ExitEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucToolbar1_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.grdQuery);
        }

        private void ucToolbar1_NewEventHandler(object sender, EventArgs e)
        {
           
        }

        private void ucToolbar1_QueryEventHandler(object sender, EventArgs e)
        {
            if (pQuery.Visible == false)
                pQuery.Visible = true;
            else
                pQuery.Visible = false;
        }

        private void frmDailySchedule_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            SetLayout();

            GetData();

            this.pQuery.BackColor = Color.FromName("Info");
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

        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.MergedCellStyle = MergedCellStyle.Always;
            e.Layout.Bands[0].Columns["prddate"].MergedCellEvaluator = new CustomMergedCellEvaluator();

            e.Layout.Bands[0].Columns["pairqty"].MergedCellStyle = MergedCellStyle.Never;
            e.Layout.Bands[0].Columns["styleno"].MergedCellStyle = MergedCellStyle.Never;
            e.Layout.Bands[0].Columns["size"].MergedCellStyle = MergedCellStyle.Never;

            //if (!this.grdQuery.DisplayLayout.ValueLists.Exists("vlchecktype"))
            //{
            //    this.grdQuery.DisplayLayout.ValueLists.Add("vlchecktype");
            //    this.grdQuery.DisplayLayout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.QCCheckType));
            //    this.grdQuery.DisplayLayout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            //    this.grdQuery.DisplayLayout.Bands[0].Columns["checktype"].ValueList = this.grdQuery.DisplayLayout.ValueLists["vlchecktype"];
            //}

            //if (!this.grdQuery.DisplayLayout.ValueLists.Exists("vlcheckresult"))
            //{
            //    this.grdQuery.DisplayLayout.ValueLists.Add("vlcheckresult");
            //    this.grdQuery.DisplayLayout.ValueLists["vlcheckresult"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.QCCheckResult));
            //    this.grdQuery.DisplayLayout.Bands[0].Columns["checkresult"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            //    this.grdQuery.DisplayLayout.Bands[0].Columns["checkresult"].ValueList = this.grdQuery.DisplayLayout.ValueLists["vlcheckresult"];
            //}
            //if (!this.grdQuery.DisplayLayout.ValueLists.Exists("vlreturnresult"))
            //{
            //    this.grdQuery.DisplayLayout.ValueLists.Add("vlreturnresult");
            //    this.grdQuery.DisplayLayout.ValueLists["vlreturnresult"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.QCReturnType));
            //    this.grdQuery.DisplayLayout.Bands[0].Columns["returntype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            //    this.grdQuery.DisplayLayout.Bands[0].Columns["returntype"].ValueList = this.grdQuery.DisplayLayout.ValueLists["vlreturnresult"];
            //}


            //this.grdQuery.DisplayLayout.Bands[0].Columns["iqcdate"].Format = "yyyy-MM-dd";
            //this.grdQuery.DisplayLayout.Bands[0].Columns["lastmodifiedtime"].Format = "yyyy-MM-dd HH:mm:ss";

            //this.grdQuery.DisplayLayout.Bands[0].Columns["createdtime"].Format = "yyyy-MM-dd HH:mm:ss";
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();
        }

        private void SetCombobox()
        {
            //DropDown.InitCMB_Customer_All(this.cboCustomer);
            //DropDown.InitCMB_StaticValue(this.cboCheckType, MES_StaticValue_Type.QCCheckType);
        }

        private void GetData()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetDailySchedule(baseForm.CurrentContextInfo,this.dateTimePicker1.Text,this.dateTimePicker2.Text);

                this.grdQuery.SetDataBinding(ds.Tables[0], "");

                if (this.grdQuery.Rows.Count < 1)
                {
                    this.ucToolbar1.SetToolbarWithoutRows();
                }
                else
                {
                    this.ucToolbar1.SetToolbarWithRows();
                }

                //this.ucStatusBar1.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + ds.Tables[0].Rows.Count.ToString());
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

        public void DoDelete()
        {
            //if (this.grdQuery.ActiveRow == null) return;

            //DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
            //            MessageBoxButtons.OKCancel,
            //            UtilCulture.GetString("Msg.R00004"),
            //            "" + UtilCulture.GetString("Label.R01023") + ": " +
            //                this.grdQuery.ActiveRow.Cells["iqcsysid"].Value.ToString());

            //if (result == DialogResult.Cancel) return;

            //wsINP.IwsINPClient client = new wsINP.IwsINPClient(); 
            //try
            //{
            //    baseForm.SetCursor();

            //    List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
            //        new MESParameterInfo(){
            //            ParamName="iqcsysid",
            //            ParamValue=this.grdQuery.ActiveRow.Cells["iqcsysid"].Value.ToString(),
            //            ParamType="string"
            //        }
            //    };

            //    client.DoDeleteIQC(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

            //    MESMsgBox.ShowInformation(UtilCulture.GetString("Msg.R00003"));

            //    GetData(QueryParameters);
            //}
            //catch (Exception ex)
            //{
            //    MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            //}
            //finally
            //{
            //    baseForm.ResetCursor();
            //    baseForm.CloseWCF(client);
            //}
        }
        #endregion

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = this.dateTimePicker1.Value.AddDays(-1);
            this.dateTimePicker2.Value = this.dateTimePicker1.Value;

            GetData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = this.dateTimePicker1.Value.AddDays(1);
            this.dateTimePicker2.Value = this.dateTimePicker1.Value;

            GetData();
        }

        private void grdQuery_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {

        }

        private void grdQuery_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (e.Cell.Column.Key == "pairqty")
            {
                frmDSAdjust frm = new frmDSAdjust();
                frm.ShowDialog(this);
            }
        }

    }
}

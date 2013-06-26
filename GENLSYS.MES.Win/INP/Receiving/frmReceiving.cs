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
using GENLSYS.MES.Utility;
using GENLSYS.MES.DataContracts;
using Infragistics.Win;
using GENLSYS.MES.Win.Common.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace GENLSYS.MES.Win.INP.Receiving
{
    public partial class frmReceiving : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;
        private tinpreceiving OriginalReceiving;
        private string PrevSelectedCustomer = string.Empty;
        private string ReceivingNoNamingRule = string.Empty;
        private string BillLockRefId = string.Empty;
        private bool IsNeedToUnlockBill = false;
        private bool isAutoSave = false;
        private bool isStarted = false;
        private int InsertStart = 0;
        private List<string> lstDeleted = new List<string>();
        private string activeCarton = string.Empty;
        private string oldColor = string.Empty;
        private string oldStyle = string.Empty;
        private string oldSize = string.Empty;

        #region Construct
        public frmReceiving()
        {
            InitializeComponent();
            baseForm = new BaseForm();

            baseForm.CreateUltraGridColumns(this.grdDetail, new string[] { 
                "flag","recsysid","reclineno","custorderno","cartonno","styleno", "color", 
                "size", "cartonqty","pairqty","checktype","ismixed","logo","linetype","linereason","remark" });

            baseForm.CreateUltraGridColumns(this.grdCartonDetail, new string[] { 
            "recsysid","custorderno","styleno","cartonno","color","size","pairqty","checktype","ismixed","cartonlocation","cartonstatus"});
        }
        #endregion

        #region Events
        private void frmReceiving_Load(object sender, EventArgs e)
        {
            try
            {
                this.Width = Screen.PrimaryScreen.Bounds.Width-50;
                this.Height = Screen.PrimaryScreen.Bounds.Height-50;
                this.Left = 10;
                this.Top = 10;

                baseForm.SetFace(this);
                baseForm.SetQueryGridStyle(this.grdDetail);
                baseForm.SetQueryGridStyle(this.grdCartonDetail);

                SetLayout();

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    isAutoSave = true;
                    //this.txtWorkOrderNo.ReadOnly = true;
                    this.grdCartonDetail.Visible = true;
                    //this.txtReceiveNo.Enabled = false;
                    baseForm.SetControlReadOnly(this.txtReceiveNo, true);
                    this.cboCustomer.Enabled = false;
                    DoShowSingleObject<tinpreceiving>(PrimaryKeys);
                }
                else
                {
                    isAutoSave = true;

                    BillLockRefId = Function.GetGUID();
                    ReceivingNoNamingRule = baseForm.GetSystemConfig("SYS_RECNO");

                    List<string> lstRecNo = baseForm.GetBillNoBatch(ReceivingNoNamingRule, 1, BillLockRefId);
                    this.txtReceiveNo.Text = lstRecNo[0];
                    IsNeedToUnlockBill = true;

                    this.grdCartonDetail.Visible = false;
                    DoShowEmptyData();
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

            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();
            e.Layout.Bands[0].Columns["size"].SortComparer = new SizeComparer();
            //set shoe color
            if (!this.grdDetail.DisplayLayout.ValueLists.Exists("vlcolor"))
            {
                this.grdDetail.DisplayLayout.ValueLists.Add("vlcolor");
                this.grdDetail.DisplayLayout.ValueLists["vlcolor"].ValueListItems.AddRange(GENLSYS.MES.Win.Common.Classes.DropDown.GetValueList_StaticValue(MES_StaticValue_Type.ShoeColor));
                this.grdDetail.DisplayLayout.Bands[0].Columns["color"].CellActivation = Activation.AllowEdit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["color"].CellClickAction = CellClickAction.Edit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["color"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
                this.grdDetail.DisplayLayout.Bands[0].Columns["color"].ValueList = this.grdDetail.DisplayLayout.ValueLists["vlcolor"];
            }

            //set shoe size
            if (!this.grdDetail.DisplayLayout.ValueLists.Exists("vlsize"))
            {
                this.grdDetail.DisplayLayout.ValueLists.Add("vlsize");
                this.grdDetail.DisplayLayout.ValueLists["vlsize"].ValueListItems.AddRange(GENLSYS.MES.Win.Common.Classes.DropDown.GetValueList_StaticValue(MES_StaticValue_Type.ShoeSize));
                this.grdDetail.DisplayLayout.Bands[0].Columns["size"].CellActivation = Activation.AllowEdit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["size"].CellClickAction = CellClickAction.Edit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["size"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
                this.grdDetail.DisplayLayout.Bands[0].Columns["size"].ValueList = this.grdDetail.DisplayLayout.ValueLists["vlsize"];
            }

            //set cust order no
            if (!this.grdDetail.DisplayLayout.ValueLists.Exists("vlcustorder"))
            {
                this.grdDetail.DisplayLayout.ValueLists.Add("vlcustorder");
                //this.grdDetail.DisplayLayout.ValueLists["vlcustorder"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.ShoeSize));
                this.grdDetail.DisplayLayout.Bands[0].Columns["custorderno"].CellActivation = Activation.AllowEdit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["custorderno"].CellClickAction = CellClickAction.Edit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["custorderno"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdDetail.DisplayLayout.Bands[0].Columns["custorderno"].ValueList = this.grdDetail.DisplayLayout.ValueLists["vlcustorder"];
                this.grdDetail.DisplayLayout.Bands[0].Columns["custorderno"].Editor.SelectionChanged += new EventHandler(CustOrderNo_Changed);                
            }

            //set style no
            if (!this.grdDetail.DisplayLayout.ValueLists.Exists("vlstyleno"))
            {
                this.grdDetail.DisplayLayout.ValueLists.Add("vlstyleno");
                //this.grdDetail.DisplayLayout.ValueLists["vlcustorder"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.ShoeSize));
                this.grdDetail.DisplayLayout.Bands[0].Columns["styleno"].CellActivation = Activation.AllowEdit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["styleno"].CellClickAction = CellClickAction.Edit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["styleno"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdDetail.DisplayLayout.Bands[0].Columns["styleno"].ValueList = this.grdDetail.DisplayLayout.ValueLists["vlstyleno"];
                this.grdDetail.DisplayLayout.Bands[0].Columns["styleno"].Editor.SelectionChanged += new EventHandler(StyleNo_Changed);
            }

            //checktype
            if (!this.grdDetail.DisplayLayout.ValueLists.Exists("vlchecktype"))
            {
                this.grdDetail.DisplayLayout.ValueLists.Add("vlchecktype");
                this.grdDetail.DisplayLayout.ValueLists["vlchecktype"].ValueListItems.AddRange(GENLSYS.MES.Win.Common.Classes.DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                this.grdDetail.DisplayLayout.Bands[0].Columns["checktype"].CellActivation = Activation.AllowEdit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["checktype"].CellClickAction = CellClickAction.Edit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdDetail.DisplayLayout.Bands[0].Columns["checktype"].ValueList = this.grdDetail.DisplayLayout.ValueLists["vlchecktype"];
            }

            //set ismixed
            if (!this.grdDetail.DisplayLayout.ValueLists.Exists("vlismixed"))
            {
                this.grdDetail.DisplayLayout.ValueLists.Add("vlismixed");
                this.grdDetail.DisplayLayout.ValueLists["vlismixed"].ValueListItems.AddRange(GENLSYS.MES.Win.Common.Classes.DropDown.GetValueList_StaticValue(MES_StaticValue_Type.IsMixed));
                this.grdDetail.DisplayLayout.Bands[0].Columns["ismixed"].CellActivation = Activation.AllowEdit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["ismixed"].CellClickAction = CellClickAction.Edit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["ismixed"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdDetail.DisplayLayout.Bands[0].Columns["ismixed"].ValueList = this.grdDetail.DisplayLayout.ValueLists["vlismixed"];
            }

            //others
            this.grdDetail.DisplayLayout.Bands[0].Columns["custorderno"].CellActivation = Activation.AllowEdit;

            this.grdDetail.DisplayLayout.Bands[0].Columns["pairqty"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["pairqty"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer;

            this.grdDetail.DisplayLayout.Bands[0].Columns["cartonno"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["styleno"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["logo"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["remark"].CellActivation = Activation.AllowEdit;

            this.grdDetail.DisplayLayout.Bands[0].Columns["linereason"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["linereason"].Hidden = true;
            //hide column
            this.grdDetail.DisplayLayout.Bands[0].Columns["recsysid"].Hidden = true;
            this.grdDetail.DisplayLayout.Bands[0].Columns["flag"].Hidden = true;
            this.grdDetail.DisplayLayout.Bands[0].Columns["linetype"].Hidden = true;
            this.grdDetail.DisplayLayout.Bands[0].Columns["cartonqty"].Hidden = true;
            this.grdDetail.DisplayLayout.Bands[0].Columns["reclineno"].Hidden = true;

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumPairqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[0].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
            }
            
        }

        private void grdDetail_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell.Column.Key == "cartonno" || e.Cell.Column.Key == "styleno" ||
                e.Cell.Column.Key == "color" || e.Cell.Column.Key == "size")
            {
                if (e.Cell.Text.ToString() == string.Empty)
                    e.Cancel = true;
            }

            try
            {
                if (e.Cell.Column.Key == "cartonno")
                {
                    int cartonqty = getCartonQty(e.Cell.Text);
                    e.Cancel = false;
                }
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ex.Message);
                e.Cancel = true;
            }
         }

        private void grdDetail_AfterCellUpdate(object sender, CellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.Key == "cartonno")
                {
                    int cartonqty = getCartonQty(e.Cell.Text);
                    grdDetail.ActiveRow.Cells["cartonqty"].Value = cartonqty.ToString();
                }

                if (e.Cell.Column.Key == "ismixed" && e.Cell.Row.Index==0)
                {
                    for (int i = 1; i < this.grdDetail.Rows.Count; i++)
                    {
                        if (this.grdDetail.Rows[i].Cells["ismixed"].Value == null ||
                            this.grdDetail.Rows[i].Cells["ismixed"].Value.ToString() == string.Empty)
                        {
                            this.grdDetail.Rows[i].Cells["ismixed"].Value = e.Cell.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            isAutoSave = false;
            DoSaveSingleObject();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            InsertDetail(false);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteDetail();
        }

        private void tsbAddDiff_Click(object sender, EventArgs e)
        {
            InsertDetail(true);
        }

        private void grdCartonDetail_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.grdCartonDetail.DisplayLayout.Bands[0].Columns["recsysid"].Hidden = true;
            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();
            e.Layout.Bands[0].Columns["size"].SortComparer = new SizeComparer();            

            //checktype
            if (!this.grdCartonDetail.DisplayLayout.ValueLists.Exists("vlchecktype"))
            {
                this.grdCartonDetail.DisplayLayout.ValueLists.Add("vlchecktype");
                this.grdCartonDetail.DisplayLayout.ValueLists["vlchecktype"].ValueListItems.AddRange(GENLSYS.MES.Win.Common.Classes.DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["checktype"].CellActivation = Activation.AllowEdit;
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["checktype"].CellClickAction = CellClickAction.Edit;
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["checktype"].ValueList = this.grdCartonDetail.DisplayLayout.ValueLists["vlchecktype"];
            }

            //set ismixed
            if (!this.grdCartonDetail.DisplayLayout.ValueLists.Exists("vlismixed"))
            {
                this.grdCartonDetail.DisplayLayout.ValueLists.Add("vlismixed");
                this.grdCartonDetail.DisplayLayout.ValueLists["vlismixed"].ValueListItems.AddRange(GENLSYS.MES.Win.Common.Classes.DropDown.GetValueList_StaticValue(MES_StaticValue_Type.IsMixed));
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["ismixed"].CellActivation = Activation.AllowEdit;
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["ismixed"].CellClickAction = CellClickAction.Edit;
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["ismixed"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["ismixed"].ValueList = this.grdCartonDetail.DisplayLayout.ValueLists["vlismixed"];
            }

            //set ismixed
            if (!this.grdCartonDetail.DisplayLayout.ValueLists.Exists("vlismixed"))
            {
                this.grdCartonDetail.DisplayLayout.ValueLists.Add("vlismixed");
                this.grdCartonDetail.DisplayLayout.ValueLists["vlismixed"].ValueListItems.AddRange(GENLSYS.MES.Win.Common.Classes.DropDown.GetValueList_StaticValue(MES_StaticValue_Type.IsMixed));
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["ismixed"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["ismixed"].ValueList = this.grdCartonDetail.DisplayLayout.ValueLists["vlismixed"];
            }

            //set ismixed
            if (!this.grdCartonDetail.DisplayLayout.ValueLists.Exists("vlismixed"))
            {
                this.grdCartonDetail.DisplayLayout.ValueLists.Add("vlismixed");
                this.grdCartonDetail.DisplayLayout.ValueLists["vlismixed"].ValueListItems.AddRange(GENLSYS.MES.Win.Common.Classes.DropDown.GetValueList_StaticValue(MES_StaticValue_Type.IsMixed));
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["ismixed"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["ismixed"].ValueList = this.grdCartonDetail.DisplayLayout.ValueLists["vlismixed"];
            }

            //set carton status
            if (!this.grdCartonDetail.DisplayLayout.ValueLists.Exists("vlcartonstatus"))
            {
                this.grdCartonDetail.DisplayLayout.ValueLists.Add("vlcartonstatus");
                this.grdCartonDetail.DisplayLayout.ValueLists["vlcartonstatus"].ValueListItems.AddRange(GENLSYS.MES.Win.Common.Classes.DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CartonStatus));
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["cartonstatus"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdCartonDetail.DisplayLayout.Bands[0].Columns["cartonstatus"].ValueList = this.grdCartonDetail.DisplayLayout.ValueLists["vlcartonstatus"];
            }

            this.grdCartonDetail.DisplayLayout.Bands[0].Columns["cartonlocation"].Hidden = true;
                        
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumCartonQty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumCartonQty", SummaryType.Count, e.Layout.Bands[0].Columns["cartonno"], SummaryPosition.UseSummaryPositionColumn);
            }
            if (!e.Layout.Bands[0].Summaries.Exists("SumPairqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[0].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
            }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool reloadGrid = true;

            if ((cboCustomer.SelectedItem as ValueInfo).ValueField == PrevSelectedCustomer)
            {
                return;
            }

            if (this.grdDetail.IsUpdating)
            {
                if (MESMsgBox.ShowQuestion("Question",UtilCulture.GetString("Msg.R01013"), Public_MessageBox.Question, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    reloadGrid = false;
            }
            
            if (reloadGrid)
            {
                if (this.grdDetail.DataSource != null)
                {
                    (this.grdDetail.DataSource as System.Data.DataTable).Rows.Clear();
                }

                PrevSelectedCustomer = (cboCustomer.SelectedItem as ValueInfo).ValueField;

                LoadCustOrderToValueList();
            }
        }

        private void CustOrderNo_Changed(object sender, EventArgs e)
        {
            if (this.grdDetail.ActiveCell.Column.Key != "custorderno") return;

            LoadStyleNoToValueList(this.grdDetail.ActiveCell.Column.Editor.Value.ToString());
        }

        private void StyleNo_Changed(object sender, EventArgs e)
        {
            if (this.grdDetail.ActiveCell.Column.Key != "styleno") return;

            this.grdDetail.ActiveRow.Cells["checktype"].Value = (this.grdDetail.DisplayLayout.ValueLists["vlstyleno"].ValueListItems.ValueList.SelectedItem as ValueListItem).Tag.ToString();
        }

        private void frmReceiving_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetBill();
        }

        private void grdDetail_AfterRowInsert(object sender, RowEventArgs e)
        {
            if (e.Row.Cells["linetype"].Value.ToString() == MES_LineType.Adjustment.ToString())
            {
                e.Row.Appearance.BackColor = Color.LightSalmon;
                e.Row.Appearance.BackColor2 = Color.LightSalmon;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dtHeader = GetReportHeader(this.txtReceiveNo.Text).Tables[0];
                System.Data.DataTable dtDetail =GetReportDetail(this.txtReceiveNo.Text).Tables[0]; 

                RDLCReportViewer rpt = new RDLCReportViewer();
                rpt.SetReportEmbeddedResource("GENLSYS.MES.Win.Report.Rdlc.rptWarehouseIn1.rdlc");
                Dictionary<string, System.Data.DataTable> dic = new Dictionary<string, System.Data.DataTable>();
                dic.Add("dsHeader", dtHeader);
                dic.Add("dsDetail", dtDetail);
                rpt.SetDataSource(dic);
                rpt.Show(this);

                rpt = new RDLCReportViewer();
                rpt.SetReportEmbeddedResource("GENLSYS.MES.Win.Report.Rdlc.rptWarehouseIn2.rdlc");
                dic = new Dictionary<string, System.Data.DataTable>();
                dic.Add("dsHeader", dtHeader);
                dic.Add("dsDetail", dtDetail);
                rpt.SetDataSource(dic);
                rpt.Show(this);

            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
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
            GENLSYS.MES.Win.Common.Classes.DropDown.InitCMB_StaticValue(this.cboCheckType, MES_StaticValue_Type.CheckType);
            GENLSYS.MES.Win.Common.Classes.DropDown.InitCMB_StaticValue(this.cboNewColor, MES_StaticValue_Type.ShoeColor);
            GENLSYS.MES.Win.Common.Classes.DropDown.InitCMB_StaticValue(this.cboNewSize, MES_StaticValue_Type.ShoeSize);

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

                tinpreceiving receiving = new tinpreceiving();

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    receiving = OriginalReceiving;
                }

                //Build Product Ext Object
                baseForm.CreateSingleObject<tinpreceiving>(receiving, this, UpdateMode);

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    receiving.recsysid = Function.GetGUID();
                }
                //receiving.
                receiving.lastmodifiedtime = Function.GetCurrentTime();
                receiving.lastmodifieduser = Function.GetCurrentUser();

                #endregion

                #region Prepare Receiving Detail
                List<tinpreceivingdtl> lstDtlNew = new List<tinpreceivingdtl>();
                List<tinpreceivingdtl> lstDtlUpdated = new List<tinpreceivingdtl>();
                for (int i = 0; i < grdDetail.Rows.Count; i++)
                {
                    tinpreceivingdtl dtl = new tinpreceivingdtl();

                    dtl.cartonno = this.grdDetail.Rows[i].Cells["cartonno"].Value.ToString();
                    dtl.color = this.grdDetail.Rows[i].Cells["color"].Value.ToString();
                    dtl.custorderno = this.grdDetail.Rows[i].Cells["custorderno"].Value.ToString();
                    dtl.logo = this.grdDetail.Rows[i].Cells["logo"].Value.ToString();
                    dtl.reclineno = this.grdDetail.Rows[i].Cells["reclineno"].Value.ToString();
                    dtl.recsysid = receiving.recsysid;
                    dtl.remark = this.grdDetail.Rows[i].Cells["remark"].Value.ToString();
                    dtl.size = this.grdDetail.Rows[i].Cells["size"].Value.ToString();
                    dtl.styleno = this.grdDetail.Rows[i].Cells["styleno"].Value.ToString();
                    dtl.checktype = this.grdDetail.Rows[i].Cells["checktype"].Value.ToString();
                    dtl.ismixed = this.grdDetail.Rows[i].Cells["ismixed"].Value.ToString();
                    dtl.linetype = this.grdDetail.Rows[i].Cells["linetype"].Value.ToString();
                    dtl.linereason = this.grdDetail.Rows[i].Cells["linereason"].Value.ToString();
                    

                    if (this.grdDetail.Rows[i].Cells["cartonqty"].Value == null)
                        dtl.cartonqty = 0;
                    else
                        dtl.cartonqty = decimal.Parse(this.grdDetail.Rows[i].Cells["cartonqty"].Value.ToString());

                    if (this.grdDetail.Rows[i].Cells["pairqty"].Value == null)
                        dtl.pairqty = 0;
                    else
                        dtl.pairqty = decimal.Parse(this.grdDetail.Rows[i].Cells["pairqty"].Value.ToString());

                    baseForm.PrepareObject<tinpreceivingdtl>(dtl, Public_UpdateMode.Insert);

                    if (grdDetail.Rows[i].Cells["flag"].Text == "NEW")
                        lstDtlNew.Add(dtl);
                    else
                        lstDtlUpdated.Add(dtl);
                }
                #endregion

                #region call WCF

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.DoInsertReceiving(baseForm.CurrentContextInfo, receiving,
                        lstDtlNew.ToArray<tinpreceivingdtl>());
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.DoUpdateReceiving(baseForm.CurrentContextInfo, receiving,
                        lstDtlNew.ToArray<tinpreceivingdtl>(),lstDtlUpdated.ToArray<tinpreceivingdtl>(),lstDeleted.ToArray());
                }
                #endregion

                baseForm.CurrentContextInfo.BCRId = ReceivingNoNamingRule;
                baseForm.CurrentContextInfo.BillRefId = BillLockRefId;

                if (!isAutoSave)
                {
                    if (UpdateMode == Public_UpdateMode.Insert)
                        baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                    else if (UpdateMode == Public_UpdateMode.Update)
                        baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));
                }

                IsNeedToUnlockBill = false;

                this.UpdateMode = Public_UpdateMode.Update;
                OriginalReceiving = receiving;

                isAutoSave = true;

                DoShowSingleObject<tinpreceiving>(new List<MESParameterInfo>(){
                        new MESParameterInfo() { ParamName="recsysid",ParamValue=receiving.recsysid }
                });
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
                tinpreceiving rec = client.GetSingleReceiving(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                //OriginalWorkOrder = rec;
                baseForm.ShowSingleObjectToUI<tinpreceiving>(rec, this);
                OriginalReceiving = rec;
                #endregion

                #region Show work order detail
                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>()
                {
                    new MESParameterInfo()
                    {
                        ParamName="recsysid",
                        ParamValue=rec.recsysid,
                        ParamType="string"
                    }
                };

                DataSet ds = client.GetReceivingDetailRecords(baseForm.CurrentContextInfo, lstParameter.ToArray<MESParameterInfo>());
                this.grdDetail.DataSource = ds.Tables[0];

                DataSet ds1 = client.GetReceivingCartonDetailRecords(baseForm.CurrentContextInfo, lstParameter.ToArray<MESParameterInfo>());
                this.grdCartonDetail.DataSource = ds1.Tables[0];

                LoadCustOrderToValueList();

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
                        ParamName="recsysid",
                        ParamValue=MES_DummyData.Dummy_Data_XXX_111.ToString(),
                        ParamType="string"
                    }
                };

                DataSet ds = client.GetReceivingDetailRecords(baseForm.CurrentContextInfo, lstParameter.ToArray<MESParameterInfo>());
                this.grdDetail.DataSource = ds.Tables[0];

                DataSet ds1 = client.GetReceivingCartonDetailRecords(baseForm.CurrentContextInfo, lstParameter.ToArray<MESParameterInfo>());
                this.grdCartonDetail.DataSource = ds1.Tables[0];
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

        private void InsertDetail(bool isAddDiff)
        {
            isAutoSave = true;

            if (this.grdDetail.Rows.Count > 0 & this.isAutoSave)
            {
                //DoSaveSingleObject();
            }
            

            System.Data.DataTable dt = this.grdDetail.DataSource as System.Data.DataTable;
            DataRow row = dt.NewRow();
            //"flag","recsysid","reclineno","customerid","custorderno","cartonno","styleno", "color", "size", 
            //"cartonqty","pairqty","ismixed","logo","linetype","linereason","remark"
            row.ItemArray = new object[] {
                "NEW",    
                string.Empty,
                ((dt.Rows.Count+1) *10).ToString(),
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                0,
                0,
                cboCheckType.SelectedItem==null?string.Empty:(cboCheckType.SelectedItem as ValueInfo).ValueField,
                string.Empty,
                string.Empty,
                isAddDiff?MES_LineType.Adjustment.ToString():MES_LineType.Original.ToString(),
                string.Empty,
                string.Empty
            };
            
            dt.Rows.Add(row);
        }

        private void DeleteDetail()
        {
            if (this.grdDetail.Selected.Rows.Count < 1) return;

            for (int i = this.grdDetail.Selected.Rows.Count - 1; i >= 0; i--)
            {
                lstDeleted.Add(this.grdDetail.Rows[this.grdDetail.Selected.Rows[i].Index].Cells[2].Text);

                this.grdDetail.Rows[this.grdDetail.Selected.Rows[i].Index].Delete(false);
            }

            
            isAutoSave = true;
            //DoSaveSingleObject();
        }

        private bool CheckDuplicated()
        {
            string custorderno = string.Empty;
            string styleno = string.Empty;
            string color = string.Empty;
            string size = string.Empty;
            string lineno = string.Empty;
            string cartonno = string.Empty;
            string checktype = string.Empty;

            for (int i = 0; i < this.grdDetail.Rows.Count; i++)
            {
                styleno = this.grdDetail.Rows[i].Cells["styleno"].Value.ToString();
                color = this.grdDetail.Rows[i].Cells["color"].Value.ToString();
                size = this.grdDetail.Rows[i].Cells["size"].Value.ToString();
                lineno = this.grdDetail.Rows[i].Cells["reclineno"].Value.ToString();
                cartonno = this.grdDetail.Rows[i].Cells["cartonno"].Value.ToString();
                custorderno = this.grdDetail.Rows[i].Cells["custorderno"].Value.ToString();
                checktype = this.grdDetail.Rows[i].Cells["checktype"].Value.ToString();

                if (custorderno==string.Empty || cartonno==string.Empty 
                    || styleno == string.Empty || color == string.Empty 
                    || size == string.Empty ||checktype==string.Empty)
                {
                    MESMsgBox.ShowError("Line: " + lineno + "," + UtilCulture.GetString("Msg.R01012"));
                    return false;
                }

                if (decimal.Parse(this.grdDetail.Rows[i].Cells["pairqty"].Value.ToString()) <= 0)
                {
                    MESMsgBox.ShowError("Line: " + lineno + "," + UtilCulture.GetString("Msg.R01003"));
                    return false;
                }
                
                for (int j = 0; j < this.grdDetail.Rows.Count; j++)
                {
                    if (styleno == this.grdDetail.Rows[j].Cells["styleno"].Value.ToString() &&
                        color == this.grdDetail.Rows[j].Cells["color"].Value.ToString() &&
                        size == this.grdDetail.Rows[j].Cells["size"].Value.ToString() &&
                        custorderno == this.grdDetail.Rows[j].Cells["custorderno"].Value.ToString() &&
                        cartonno == this.grdDetail.Rows[j].Cells["cartonno"].Value.ToString() &&
                        lineno != this.grdDetail.Rows[j].Cells["reclineno"].Value.ToString())
                    {
                        MESMsgBox.ShowError("[" + styleno + "," + color + "," + size + "] " + UtilCulture.GetString("Msg.R01004"));
                        return false;
                    }
                }
            }

            return true;
        }

        private int getCartonQty(string cartonno)
        {
            string n1 = string.Empty;
            string n2 = string.Empty;
            int i1,i2;

            if (cartonno.Trim() == string.Empty)
                return 0;

            if (cartonno.IndexOf("-") > 0)
            {
                n1 = cartonno.Substring(0, cartonno.IndexOf("-"));
                n2 = cartonno.Substring(cartonno.IndexOf("-") + 1);

                if (int.TryParse(n1, out i1) && int.TryParse(n2, out i2))
                {
                    if (i1 > i2)
                        throw new Exception("Incorrect carton no format");

                    return (i2 - i1 + 1);
                }
                else
                {
                    throw new Exception("Incorrect carton no format");
                }
            }
            else
            {
                return 1;
            }
        }

        private void LoadCustOrderToValueList()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>()
                {
                    new MESParameterInfo()
                    {
                        ParamName="customerid",
                        ParamValue= (this.cboCustomer.SelectedItem as ValueInfo).ValueField,
                        ParamType="string"
                    }
                };

                DataSet ds = client.GetCustOrderForReceiving(baseForm.CurrentContextInfo, lstParameter.ToArray<MESParameterInfo>());

                var q = (from p in ds.Tables[0].AsEnumerable()
                         group p by p.Field<string>("custorderno") into t1
                         select new { custorderno = t1.Key.ToString() }).ToList();

                if (this.grdDetail.DisplayLayout.ValueLists.Exists("vlcustorder"))
                {
                    this.grdDetail.DisplayLayout.ValueLists["vlcustorder"].ValueListItems.Clear();
                    for (int i = 0; i < q.Count; i++)
                    {
                        ValueListItem item = new ValueListItem()
                        {
                            DisplayText = q[i].custorderno,
                            DataValue = q[i].custorderno
                        };

                        this.grdDetail.DisplayLayout.ValueLists["vlcustorder"].ValueListItems.Add(item);
                    }
                }
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

        private void LoadStyleNoToValueList(string custorderno)
        {
            if (custorderno.Trim() == string.Empty) return;

            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>()
                {
                    new MESParameterInfo()
                    {
                        ParamName="customerid",
                        ParamValue= (this.cboCustomer.SelectedItem as ValueInfo).ValueField,
                        ParamType="string"
                    },
                    new MESParameterInfo()
                    {
                        ParamName="custorderno",
                        ParamValue= custorderno,
                        ParamType="string"
                    }
                };

                DataSet ds = client.GetCustOrderForReceiving(baseForm.CurrentContextInfo, lstParameter.ToArray<MESParameterInfo>());

                if (this.grdDetail.DisplayLayout.ValueLists.Exists("vlstyleno"))
                {
                    this.grdDetail.DisplayLayout.ValueLists["vlstyleno"].ValueListItems.Clear();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ValueListItem item = new ValueListItem()
                        {
                            DisplayText = ds.Tables[0].Rows[i]["styleno"].ToString(),
                            DataValue = ds.Tables[0].Rows[i]["styleno"].ToString(),
                            Tag = ds.Tables[0].Rows[i]["checktype"].ToString()
                        };

                        this.grdDetail.DisplayLayout.ValueLists["vlstyleno"].ValueListItems.Add(item);
                    }
                }
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

        private void ResetBill()
        {
            try
            {
                if (IsNeedToUnlockBill)
                {
                    baseForm.ResetBill(ReceivingNoNamingRule, BillLockRefId);
                }
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
        }

        private DataSet GetReportHeader(string recno)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                return client.GetReceivingHeader_Print(baseForm.CurrentContextInfo, recno);
                
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
        }

        private DataSet GetReportDetail(string recno)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                return client.GetReceivingDetail_Print(baseForm.CurrentContextInfo, recno);

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
        }
        #endregion

        private void grdCartonDetail_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            activeCarton = e.Cell.Row.Cells["cartonno"].Text;
            this.label7.Text = "箱号[" + activeCarton + "]变更后数量为:";

            if (e.Cell.Row.Cells["cartonlocation"].Value.ToString() != "Warehouse" ||
                e.Cell.Row.Cells["cartonstatus"].Value.ToString() != "Active")
            {
                //this.txtNewQuantity.Enabled = false;
                //this.btnSaveQuantity.Enabled = false;
                this.pEditCarton.Visible = false;
            }
            else
            {
                //this.txtNewQuantity.Enabled = true;
                //this.btnSaveQuantity.Enabled = true;

                //this.txtNewQuantity.Focus();
                oldStyle = e.Cell.Row.Cells["styleno"].Value.ToString();
                oldColor = e.Cell.Row.Cells["color"].Value.ToString();
                oldSize = e.Cell.Row.Cells["size"].Value.ToString();

                this.txtNewStyle.Text = e.Cell.Row.Cells["styleno"].Value.ToString();
                this.cboNewColor.Text = e.Cell.Row.Cells["color"].Value.ToString();
                this.cboNewSize.Text = e.Cell.Row.Cells["size"].Value.ToString();
                this.txtNewQuantity.Text = e.Cell.Row.Cells["pairqty"].Value.ToString(); 
                this.pEditCarton.Visible = true;
            }
        }

        private void btnSaveQuantity_Click(object sender, EventArgs e)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                if (this.txtNewQuantity.Text.Trim() == string.Empty)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, "请输入新数量");
                }

                int x = 0;
                bool b = int.TryParse(this.txtNewQuantity.Text, out x);

                if (!b)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, "数量格式错误,请输入数字");
                }

                if (activeCarton.Trim()!=string.Empty)
                {
                    client.UpdateCartonQty(baseForm.CurrentContextInfo, PrimaryKeys[0].ParamValue,
                        activeCarton,oldStyle,oldColor,oldSize, x, cboNewColor.Text,cboNewSize.Text, txtNewStyle.Text);
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, "保存成功");

                    this.pEditCarton.Visible = false;
                }

                DoShowSingleObject<tinpreceiving>(PrimaryKeys);
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

                string firstCell = sheet.Cells[9, 1].Value.ToString();

                if (firstCell.Trim() == string.Empty)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, "Excel没数据或数据格式错误");
                    return;
                }

                //List<int> lstSize = new List<int>();
                //for (int i = 6; i < 100; i++)
                //{
                //    string size = sheet.Cells[8, i].Value.ToString();
                //    lstSize.Add(int.Parse(size));
                //}

                for (int i = 9; i < 5000; i++)
                {
                    if (sheet.Cells[i, 1].Value == null)
                        firstCell = string.Empty;
                    else
                        firstCell = sheet.Cells[i, 1].Value.ToString();

                    if (firstCell == null || firstCell.Trim() == string.Empty)
                        break;

                    string orderno = sheet.Cells[i, 1].Value.ToString();
                    string prefix = string.Empty;
                    string carton1 = sheet.Cells[i, 3].Value.ToString();
                    string carton2 = sheet.Cells[i, 5].Value.ToString();
                    string styleno = sheet.Cells[i, 6].Value.ToString();
                    string color = sheet.Cells[i, 7].Value.ToString();

                    if (sheet.Cells[i, 2].Value == null)
                        prefix = string.Empty;
                    else
                        prefix = sheet.Cells[i, 2].Value.ToString();

                    for (int j = 8; j < 100; j++)
                    {
                        string qty = string.Empty;

                        if (sheet.Cells[i, j].Value == null)
                            qty = string.Empty;
                        else
                            qty = sheet.Cells[i, j].Value.ToString();

                        if (qty != null && qty.Trim() != string.Empty)
                        {
                            string size = sheet.Cells[8, j].Value.ToString();


                            for (int n = int.Parse(carton1); n <= int.Parse(carton2); n++)
                            {
                                DataRow dr = dt.NewRow();
                                //"flag","recsysid","reclineno","customerid","custorderno","styleno", "color", "size", 
                                //"cartonno","cartonqty","pairqty","ismixed","logo","linetype","linereason","remark"
                                dr.ItemArray = new object[] {
                                    "NEW",    
                                    string.Empty,
                                    ((dt.Rows.Count+1) *10).ToString(),
                                    string.Empty,
                                    orderno,                                    
                                    styleno,
                                    color,
                                    size,
                                    prefix + n.ToString(),
                                    1,//(int.Parse(carton1)-int.Parse(carton2) +1).ToString(),
                                    int.Parse(qty),//(int.Parse(carton1)-int.Parse(carton2) +1) * int.Parse(qty),
                                    cboCheckType.SelectedItem==null?string.Empty:(cboCheckType.SelectedItem as ValueInfo).ValueField,
                                    string.Empty,
                                    string.Empty,
                                    string.Empty,
                                    string.Empty
                                    };

                                dt.Rows.Add(dr);
                            }
                        }

                    }
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

        private void btnDeleteCarton_Click(object sender, EventArgs e)
        {
            DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                        MessageBoxButtons.OKCancel,
                        UtilCulture.GetString("Msg.R00004"),
                        "你确定要删除该箱吗?");

            if (result == DialogResult.Cancel) return;

            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                if (activeCarton.Trim() != string.Empty)
                {
                    client.DeleteSingleCarton(baseForm.CurrentContextInfo, PrimaryKeys[0].ParamValue,
                        activeCarton,oldStyle,oldColor,oldSize);
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, "删除成功");

                    this.pEditCarton.Visible = false;
                }

                DoShowSingleObject<tinpreceiving>(PrimaryKeys);
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
        }

        private void grdCartonDetail_Leave(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.pEditCarton.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

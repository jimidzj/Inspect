using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.WinPAD.Common.Classes;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Common;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace GENLSYS.MES.WinPAD
{
    public partial class frmMain : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;
        private string fun;
        public frmMain(string _fun)
        {
            fun = _fun;
            InitializeComponent();

            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] {"customerid", "customer", "factory", "poid","styleno", "poqty","checktype", "status" });
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            this.pQuery.BackColor = Color.FromName("Info");
            grdQuery.DisplayLayout.Bands[0].Columns["status"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            this.grdQuery.DisplayLayout.Override.CellButtonAppearance.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.hand_property;
            this.grdQuery.DisplayLayout.Override.CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Right;
            SetCombobox();
            RefreshGrid();
            grdQuery.DisplayLayout.Override.MinRowHeight = 30;
            grdQuery.DisplayLayout.Override.RowAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
           // this.grdQuery.DisplayLayout.Bands[0].Columns[3].Hidden = true;
           
           
        }
        private void SetCombobox()
        {
            DropDown.InitCMB_Customer_All(this.cboCustomer);

            DropDown.InitCMB_StaticValue(this.cboFactory, MES_StaticValue_Type.Factory);
        //    DropDown.InitCMB_StaticValue(this.cboFactory, MES_StaticValue_Type.QCCheckType);
          //  DropDown.InitCMB_StaticValue(this.cboReturnType, MES_StaticValue_Type.QCReturnType);
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        #region Methods
        private void RefreshGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue =  param.ParamValue ;
            }
            GetData(lstParameters);
        }
        private void GetData(List<MESParameterInfo> lstParameters)
        {
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {
                baseForm.SetCursor();

            //    DataSet ds = client.GetWipRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                DataSet ds = client.GetPOListByStep(fun, baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

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

        private void grdQuery_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            //shou option window
             int i = this.grdQuery.ActiveRow.Index;
             string poid = this.grdQuery.Rows[i].Cells["poid"].Value.ToString().Trim();
             string customerid = this.grdQuery.Rows[i].Cells["customerid"].Value.ToString().Trim();
             string customerName = this.grdQuery.Rows[i].Cells["customer"].Value.ToString().Trim();
             if (this.fun == "fai01")
            {
                frmOpenBox openWin = new frmOpenBox(poid, customerid, customerName);
                 openWin.Show();
            }
            if (this.fun == "fai02")
            {

                frmPackBox assyWin = new frmPackBox(poid, customerid, customerName,"I");
                assyWin.Show();
            }
            if (this.fun == "fai03")
            {
                frmMoveBox assyWin = new frmMoveBox(poid, customerid, customerName);
                assyWin.Show();
            }
            if (this.fun == "fax01")
            {
                frmPackBox assyWin = new frmPackBox(poid, customerid, customerName,"X");
                assyWin.Show();
            }
            
            //window.Show(id);
        }

        private void grdQuery_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            if (this.fun == "fai01")
            {
                e.Row.Cells["status"].Value = "点击开箱 ";
            }
            if (this.fun == "fai02")
            {
                e.Row.Cells["status"].Value = "点击封箱 ";
            }
            if (this.fun == "fai03")
            {
                e.Row.Cells["status"].Value = "点击装箱 ";
            }
            if (this.fun == "fax01")
            {
                e.Row.Cells["status"].Value = "点击封箱 ";
            }
        
        }

        private void txtCustOrderNo_Click(object sender, EventArgs e)
        {

            int x = txtCustOrderNo.Location.X;
            int y = txtCustOrderNo.Location.Y + 100;
           
            GENLSYS.MES.WinPAD.Common.Forms.vkForm.showKeyboard();
            GENLSYS.MES.WinPAD.Common.Forms.vkForm.move(x, y);
            txtCustOrderNo.Focus();
        }

        private void txtCustomer_Click(object sender, EventArgs e)
        {
            //int x= txtCustomer.Location.X ;
            //int y = txtCustomer.Location.Y + 100;
            //GENLSYS.MES.WinPAD.Common.Forms.vkForm.move(x , y );
            //GENLSYS.MES.WinPAD.Common.Forms.vkForm.showKeyboard();
            //txtCustomer.Focus();
        }

        private void txtType_Click(object sender, EventArgs e)
        { 
            GENLSYS.MES.WinPAD.Common.Forms.vkForm.showKeyboard();
             txtType.Focus();
      
        }

        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
             this.grdQuery.DisplayLayout.Bands[0].Columns["status"].CellAppearance.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.hand_property;
            this.grdQuery.DisplayLayout.Bands[0].Columns["status"].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Right;
          
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("Sumqty"))
            {
                e.Layout.Bands[0].Summaries.Add("Sumqty", SummaryType.Sum, e.Layout.Bands[0].Columns["poqty"], SummaryPosition.UseSummaryPositionColumn);
            }
  
        }

       
       
    }
}

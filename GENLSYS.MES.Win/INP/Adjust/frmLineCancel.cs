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
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.INP.Adjust
{
    public partial class frmLineCancel : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;
        private string fun;
        public frmLineCancel()
        {
            InitializeComponent();
            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { "customerid", "customer", "poid", "cartonno",  "status" });
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            this.pQuery.BackColor = Color.FromName("Info");
            grdQuery.DisplayLayout.Bands[0].Columns["status"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            this.grdQuery.DisplayLayout.Override.CellButtonAppearance.Image = global::GENLSYS.MES.Win.Properties.Resources.cancel;
            this.grdQuery.DisplayLayout.Override.CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Right;
            SetCombobox();
         //   RefreshGrid();
            grdQuery.DisplayLayout.Override.MinRowHeight = 30;
            grdQuery.DisplayLayout.Override.RowAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
           // this.grdQuery.DisplayLayout.Bands[0].Columns[3].Hidden = true;
         }
        private void SetCombobox()
        {
            DropDown.InitCMB_Customer_All(this.cboCustomer);
            DropDown.InitCMB_StaticValue(this.cmbAction, MES_StaticValue_Type.LineAction);
          }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.cmbAction.SelectedItem == null)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Warning, MessageBoxButtons.OK, "请选择...", "请选择需要取消的操作类型");
                return;
            }
            RefreshGrid();
        }
        
        #region Methods
        private void RefreshGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue =  param.ParamValue  ;
            }
            GetData(lstParameters);
        }
        private void GetData(List<MESParameterInfo> lstParameters)
        {
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetCancelableCarton(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

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
             string customer = this.grdQuery.Rows[i].Cells["customer"].Value.ToString().Trim();
             string cartonno = this.grdQuery.Rows[i].Cells["cartonno"].Value.ToString().Trim();
             string action = cmbAction.Text;
             string msg = "你是否要取消" + customer + "的" + poid + "订单的第" + cartonno + "箱的" + action + "?";
             baseForm.CreateMessageBox(Public_MessageBox.Question , MessageBoxButtons.YesNo , "请确认", msg);
            // frmOpenBox openWin = new frmOpenBox(poid, customerid, customerName);
            //  openWin.Show();
             wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {

                bool ds =false;

                if (action == "检品开箱")
                {
                    ds = client.CancelOpen(customerid, cartonno, poid, baseForm.CurrentContextInfo.CurrentUser, baseForm.CurrentContextInfo);
 
                }
                if (action == "检品装箱")
                {
                    ds = client.CancelMove(customerid, cartonno, poid, baseForm.CurrentContextInfo.CurrentUser, baseForm.CurrentContextInfo);

                }
                if (action == "检品封箱")
                {
                    ds = client.CancelPack(customerid, cartonno, poid, baseForm.CurrentContextInfo.CurrentUser, baseForm.CurrentContextInfo);

                }
                if (action == "X线开箱")
                {
                    ds = client.CancelOpen(customerid, cartonno, poid, baseForm.CurrentContextInfo.CurrentUser, baseForm.CurrentContextInfo);

                }
                if (action == "X线封箱")
                {
                    ds = client.CancelPack(customerid, cartonno, poid, baseForm.CurrentContextInfo.CurrentUser, baseForm.CurrentContextInfo);

                }
             
                if (ds)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, "消息提示", "成功取消");
                }
                else
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, "消息提示", "取消失败");
                }
                RefreshGrid();
              
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

        private void grdQuery_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {            
                e.Row.Cells["status"].Value = "点击取消";
        }

       
        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
             this.grdQuery.DisplayLayout.Bands[0].Columns["status"].CellAppearance.Image = global::GENLSYS.MES.Win.Properties.Resources.delete;
             this.grdQuery.DisplayLayout.Bands[0].Columns["status"].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Right;
            
        }

       
       
    }
}

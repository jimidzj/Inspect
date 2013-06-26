using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.DataContracts;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace GENLSYS.MES.Win.INP.Ship
{
    public partial class frmShipPlan : Form
    {
        public string ShipingSysId { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode { get; set; }
        private DataTable custordernoDt=null;
        private DataTable shippingdtlDt = null;
        private string ReceivingNoNamingRule = string.Empty;
        private string BillLockRefId = string.Empty;
        private bool IsNeedToUnlockBill = false;

        #region Construct
        public frmShipPlan()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdDetail, new string[] { "custorderno", "customername", "factory", "cartonqty" });
        }
        #endregion

        #region Event
        private void frmShipPlan_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdDetail);

            DataTable custDt = GetAllCustomer().Tables[0];
            DropDown.InitCMB_DataTable(this.cmbCustomer, custDt, "customername", "customerid");

            custordernoDt = GetCustOrder();
           
            if (ShipingSysId != null)
            {
                UpdateMode = Public_UpdateMode.Update;
            }
            else
            {
                UpdateMode = Public_UpdateMode.Insert;
            }

            if (UpdateMode == Public_UpdateMode.Insert)
            {
                this.grdDetail.SetDataBinding(createEmptyTable(), "");
                BillLockRefId = Function.GetGUID();
                ReceivingNoNamingRule = baseForm.GetSystemConfig("SYS_SHIPPINGPLANNO");
                List<string> lstRecNo = baseForm.GetBillNoBatch(ReceivingNoNamingRule, 1, BillLockRefId);
                this.txtShippingPlanNo.Text = lstRecNo[0];                
                IsNeedToUnlockBill = true;
            }
            else
            {
                shippingdtlDt = GetShippingDtlRecords();
                if (shippingdtlDt.Rows.Count > 0)
                {
                    this.txtShippingPlanNo.Text = shippingdtlDt.Rows[0]["shippingplanno"].ToString();
                    DropDown.SelectCMBValue(this.cmbCustomer, shippingdtlDt.Rows[0]["customerid"].ToString());
                    this.cmbCustomer.Enabled = false;
                }
                this.grdDetail.SetDataBinding(shippingdtlDt, "");

                tinpshippingplan shippingplan = GetShippingPlan(this.txtShippingPlanNo.Text);
                if (shippingplan != null)
                {
                    this.dtLoadingDt.Value = shippingplan.loadingdate;
                    this.txtBoxQty.Text = shippingplan.boxqty;
                    this.txtDeliveryBill.Text = shippingplan.deliverybill;
                    this.txtInShipNo.Text = shippingplan.inshipno;
                    this.numCommissionedQty.Value = Convert.ToDecimal(shippingplan.commissionedqty);
                    this.numCommissionedVolume.Value = Convert.ToDecimal(shippingplan.commissionedvolume);
                    this.numCommissionedWeight.Value = Convert.ToDecimal(shippingplan.commissionedweight);
                    this.txtStartPort.Text = shippingplan.startport;
                    this.txtDestinationPort.Text = shippingplan.destinationport;
                    this.txtUnloadPort.Text = shippingplan.unloadport;
                    this.txtVoyage.Text = shippingplan.voyage;
                    this.txtRemark.Text = shippingplan.remark;
                }                
            }
            //this.txtShippingPlanNo.Enabled = false;
        }
        private void grdDetail_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;

            if (custordernoDt == null)
            {
                custordernoDt = GetCustOrder();
            }
            string customerid = this.cmbCustomer.SelectedItem == null ? "" : ((ValueInfo)this.cmbCustomer.SelectedItem).ValueField;
            if (UpdateMode == Public_UpdateMode.Update)
            {
                //foreach (DataRow row in shippingdtlDt.Rows)
                //{
                //    var q = from p in custordernoDt.AsEnumerable()
                //            where p["customerid"].ToString().Equals(row["customerid"].ToString()) && p["custorderno"].ToString().Equals(row["custorderno"].ToString())
                //            select p;
                //    if (q.Count() > 0)
                //    {
                //        DataRow custordernoRow = q.ElementAt(0);
                //        custordernoRow["cartonqty"] = Convert.ToInt16(custordernoRow["cartonqty"]) + Convert.ToInt16(row["cartonqty"]);
                //    }
                //    else
                //    {
                //        DataRow custordernoRow = custordernoDt.NewRow();
                //        custordernoRow.ItemArray = new object[] {
                //            row["custorderno"].ToString(),
                //            customerid,
                //            row["customername"].ToString(),
                //            Convert.ToInt16(row["cartonqty"])
                //        };
                //        custordernoDt.Rows.Add(custordernoRow);
                //    }
                //}
            }
            var custorderq = from p in custordernoDt.AsEnumerable()
                             where p["customerid"].ToString().Equals(customerid)
                    select p;

            if (!e.Layout.ValueLists.Exists("vlcustorderno"))
            {
                e.Layout.ValueLists.Add("vlcustorderno");
                e.Layout.ValueLists["vlcustorderno"].ValueListItems.AddRange(DropDown.GetValueList_DataTable(custorderq.ToArray(), "custorderno", "custorderno"));
                e.Layout.Bands[0].Columns["custorderno"].CellActivation = Activation.AllowEdit;
                e.Layout.Bands[0].Columns["custorderno"].CellClickAction = CellClickAction.Edit;
                e.Layout.Bands[0].Columns["custorderno"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["custorderno"].ValueList = e.Layout.ValueLists["vlcustorderno"];
            }

            e.Layout.Bands[0].Columns["cartonqty"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            e.Layout.Bands[0].Columns["cartonqty"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegativeWithSpin;

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumCartonqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumCartonqty", SummaryType.Sum, e.Layout.Bands[0].Columns["cartonqty"], SummaryPosition.UseSummaryPositionColumn);
            }
        }


        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = this.grdDetail.Rows.Count - 1; i >= 0; i--)
            {
                this.grdDetail.Rows[this.grdDetail.Rows[i].Index].Delete(false);
            }
            string customerid = ((ValueInfo)this.cmbCustomer.SelectedItem).ValueField;
            var custorderq = from p in custordernoDt.AsEnumerable()
                             where p["customerid"].ToString().Equals(((ValueInfo)this.cmbCustomer.SelectedItem).ValueField)
                             select p;
            if (this.grdDetail.DisplayLayout.ValueLists.Exists("vlcustorderno"))
            {
                this.grdDetail.DisplayLayout.ValueLists["vlcustorderno"].ValueListItems.Clear();
                this.grdDetail.DisplayLayout.ValueLists["vlcustorderno"].ValueListItems.AddRange(DropDown.GetValueList_DataTable(custorderq.ToArray(), "custorderno", "custorderno"));
            }
        }
        private void grdDetail_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key.Equals("custorderno"))
            {
                changeCustOrder(e.Cell.Value.ToString(),e.Cell.Row);
            }
        }
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            addDetail();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            delDetail();
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            DoShipPlan();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion

        
        #region Method
        private void DoShipPlan()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();
                baseForm.ValidateData(this);

                if (ShipingSysId == null)
                {
                    ShipingSysId = Function.GetGUID();
                }
                List<string> lstcustorderno = new List<string>();
                List<tinpshippingdtl> lstshippingdtl = new List<tinpshippingdtl>();
                foreach (UltraGridRow row in this.grdDetail.Rows)
                {
                    if (lstcustorderno.Contains(row.Cells["custorderno"].Value.ToString()))
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01022", row.Cells["custorderno"].Value.ToString()));
                    }
                    else
                    {
                        lstcustorderno.Add(row.Cells["custorderno"].Value.ToString());
                    }
                    if ( Convert.ToInt16(row.Cells["cartonqty"].Value) <= 0)
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01016", UtilCulture.GetString("Label.R02021")));
                    }
                    int maxcartonqty = getMaxCartonQty(((ValueInfo)this.cmbCustomer.SelectedItem).ValueField,row.Cells["custorderno"].Value.ToString());
                    if (Convert.ToInt16(row.Cells["cartonqty"].Value) >maxcartonqty )
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01014", UtilCulture.GetString("Label.R02021"), maxcartonqty.ToString()));
                    }
                    tinpshippingdtl dtl = new tinpshippingdtl();
                    if (UpdateMode == Public_UpdateMode.Update)
                    {
                        List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="custorderno",ParamValue=row.Cells["custorderno"].Value.ToString()},
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=ShipingSysId}
                        };

                        DataSet ds = client.GetShippingDtlCtnRecords(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>());

                        if (ds.Tables[0].Rows.Count > Convert.ToInt16(row.Cells["cartonqty"].Value))
                        {
                            throw new Exception(UtilCulture.GetString("Msg.R01023", UtilCulture.GetString("Label.R02021"), ds.Tables[0].Rows.Count.ToString()));
                        }
                    }
                    dtl.shippingsysid = ShipingSysId;
                    dtl.shippingplanno = this.txtShippingPlanNo.Text;
                    dtl.customerid =((ValueInfo)this.cmbCustomer.SelectedItem).ValueField;
                    dtl.custorderno = row.Cells["custorderno"].Value.ToString();
                    dtl.ttlcantonqty = Convert.ToInt16(row.Cells["cartonqty"].Value);
                    lstshippingdtl.Add(dtl);
                }
                if (lstshippingdtl.Count == 0)
                {
                    throw new Exception(UtilCulture.GetString("Msg.R01019"));
                }
                tinpshippingplan shippingplan = new tinpshippingplan();
                shippingplan.shippingplanno = this.txtShippingPlanNo.Text;
                shippingplan.loadingdate = Convert.ToDateTime(this.dtLoadingDt.Value);
                shippingplan.boxqty = this.txtBoxQty.Text;
                shippingplan.deliverybill = this.txtDeliveryBill.Text;
                shippingplan.inshipno = this.txtInShipNo.Text;
                shippingplan.commissionedqty =Convert.ToInt16( this.numCommissionedQty.Value);
                shippingplan.commissionedvolume = this.numCommissionedVolume.Value;
                shippingplan.commissionedweight = this.numCommissionedWeight.Value;
                shippingplan.startport = this.txtStartPort.Text;
                shippingplan.destinationport = this.txtDestinationPort.Text;
                shippingplan.unloadport = this.txtUnloadPort.Text;
                shippingplan.voyage = this.txtVoyage.Text;
                shippingplan.remark = this.txtRemark.Text;

                client.DoShipPlan(baseForm.CurrentContextInfo, lstshippingdtl.ToArray<tinpshippingdtl>(), shippingplan);
                if (UpdateMode == Public_UpdateMode.Update)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));
                }
                else
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                }
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

        private DataTable GetCustOrder()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                dt = client.GetPackingCartonSummaryRecords(baseForm.CurrentContextInfo).Tables[0];

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

        private DataTable GetShippingDtlRecords()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=ShipingSysId}
                        };
                dt = client.GetShippingDtlRecords(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];
                dt.Columns.Add("cartonqty");
                foreach (DataRow row in dt.Rows)
                {
                    row["cartonqty"] = row["ttlcantonqty"];
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
            return dt;
        }

        private tinpshippingplan GetShippingPlan(string shippingplanno)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            tinpshippingplan shippingplan = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingplanno",ParamValue=shippingplanno}
                        };
                shippingplan = client.GetSingleShippingPlan(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>());
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return shippingplan;
        }

        private int getMaxCartonQty(string customerid,string custorderno)
        {
            var q = from p in custordernoDt.AsEnumerable()
                    where p["customerid"].ToString() == customerid && p["custorderno"].ToString() == custorderno
                    select p;
            if (q.Count() > 0)
            {
                return Convert.ToInt16(q.ToList<DataRow>()[0]["cartonqty"]);
            }
            else
            {
                return 0;
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

        private void changeCustOrder(string value,UltraGridRow row)
        {
            var q = from p in custordernoDt.AsEnumerable()
                    where p["custorderno"].ToString() == value && p["customerid"].ToString() == ((ValueInfo)this.cmbCustomer.SelectedItem).ValueField
                    select p;
            if (q.Count()>0){
                row.Cells["customername"].Value = q.ToList<DataRow>()[0]["customername"];
                row.Cells["factory"].Value = q.ToList<DataRow>()[0]["factory"];
                row.Cells["cartonqty"].Value = q.ToList<DataRow>()[0]["cartonqty"];
            }

        }
        private DataTable createEmptyTable()
        { 
            DataTable dt = new DataTable();
            dt.Columns.Add("custorderno");
            dt.Columns.Add("customername");
            dt.Columns.Add("factory");
            dt.Columns.Add("cartonqty");
            return dt;
        }
        private void addDetail()
        {
            DataTable dt = this.grdDetail.DataSource as DataTable;
            DataRow row = dt.NewRow();
            row.ItemArray = new object[] {
                string.Empty,
                string.Empty,
                string.Empty,
                0
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

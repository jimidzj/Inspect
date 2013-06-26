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
using GENLSYS.MES.Utility;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Win.Report;

namespace GENLSYS.MES.Win.INP.Ship
{
    public partial class frmRequestPay : Form
    {
        private BaseForm baseForm;
        public string ShipingSysId { get; set; }
        private DataTable opDt = null;       
        private DataTable dtlDt = null;
        private DateTime rptDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM")+"-01").AddDays(-1);
        private string customerId = "";

        #region Construct
        public frmRequestPay()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdDetail, new string[] { "shippingsysid", "itemname", "unit", "currency", "price", "qty" });
        }
        #endregion

        #region Events
        private void frmRequestPay_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdDetail);

            if (ShipingSysId != null)
            {
                DataTable dt = GetSingleShipping(ShipingSysId);
                if (dt.Rows.Count > 0)
                {
                    this.txtShipNo.Text = dt.Rows[0]["shippingno"].ToString();
                    this.txtCustomer.Text = dt.Rows[0]["customername"].ToString();
                }
                DropDown.InitCMB_StaticValue(this.cmbCurrency, MES_StaticValue_Type.Currency);
                DropDown.InitCMB_StaticValue(this.cmbTemplate, MES_StaticValue_Type.RequestPayTemplate);

                DataTable defaultDt = null;
                
                tinprequestpay rqpay = GetSingleRequestPay(ShipingSysId);
                if (rqpay != null)
                {
                    DropDown.SelectCMBValue(this.cmbCurrency, rqpay.currency);
                    DropDown.SelectCMBValue(this.cmbTemplate, rqpay.template);
                    rptDate = Convert.ToDateTime(rqpay.rptdate);
                    defaultDt=GetRequestPayDtl(ShipingSysId);                    
                }
                else
                {
                    this.cmbCurrency.SelectedIndex = 0;
                    this.cmbTemplate.SelectedIndex = 0;
                }

                customerId=dt.Rows[0]["customerid"].ToString();
                opDt = GetValidOtherPricing(customerId, rptDate);
                dtlDt = GetShippingDtlForReport(ShipingSysId);

                this.grdDetail.SetDataBinding(defaultDt == null ? createEmptyTable() : defaultDt, "");
            }

           
        }

        private void grdDetail_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.CellClickAction = CellClickAction.Edit;

            e.Layout.Bands[0].Columns["shippingsysid"].Hidden = true;

            e.Layout.Bands[0].Columns["qty"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            e.Layout.Bands[0].Columns["qty"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegativeWithSpin;
            e.Layout.Bands[0].Columns["qty"].Width = 80;

            if (!e.Layout.ValueLists.Exists("vlitemname"))
            {
                e.Layout.ValueLists.Add("vlitemname");
                e.Layout.ValueLists["vlitemname"].ValueListItems.AddRange(DropDown.GetValueList_DataTable(opDt, "itemname", "itemname"));
                e.Layout.Bands[0].Columns["itemname"].CellActivation = Activation.AllowEdit;
                e.Layout.Bands[0].Columns["itemname"].CellClickAction = CellClickAction.Edit;
                e.Layout.Bands[0].Columns["itemname"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["itemname"].ValueList = e.Layout.ValueLists["vlitemname"];
            }
        }
        private void grdDetail_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key.Equals("itemname"))
            {
                foreach (UltraGridRow row in this.grdDetail.Rows)
                {
                    if (row.Index != e.Cell.Row.Index && row.Cells["itemname"].Value.Equals(e.Cell.Value))
                    {
                        e.Cell.Row.Cells["itemname"].Value = "";
                        e.Cell.Row.Cells["unit"].Value = "";
                        e.Cell.Row.Cells["price"].Value = 0;
                        e.Cell.Row.Cells["currency"].Value = "";
                        e.Cell.Row.Cells["qty"].Value = 0;
                    }
                }

                if (!e.Cell.Value.ToString().Equals(""))
                {
                    var q = from p in opDt.AsEnumerable()
                            where p["itemname"].ToString() == e.Cell.Value.ToString()
                            select p;
                    if (q.Count() > 0)
                    {
                        e.Cell.Row.Cells["unit"].Value = q.ToList<DataRow>()[0]["unit"];
                        e.Cell.Row.Cells["price"].Value = q.ToList<DataRow>()[0]["price"];
                        e.Cell.Row.Cells["currency"].Value = q.ToList<DataRow>()[0]["currency"];
                        if (e.Cell.Row.Cells["unit"].Value.Equals("双"))
                        {
                            var sumq = dtlDt.AsEnumerable().Sum(p => Convert.ToInt16(p["pairqty"]));
                            e.Cell.Row.Cells["qty"].Value = sumq;      
                        }
                    }
                }
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            doPrint();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Methods
        private void doPrint()
        {
            try
            {
                
                #region Check Input
                foreach (UltraGridRow row in this.grdDetail.Rows)
                {
                    if (row.Cells["itemname"].Value.ToString().Equals(""))
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01020", UtilCulture.GetString("Label.R0104401")));
                    }
                    if (Convert.ToInt16(row.Cells["qty"].Value) <= 0)
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01016", UtilCulture.GetString("Label.R0104403")));
                    }
                }
                #endregion

                #region Save Input
                tinprequestpay requestPay = new tinprequestpay();
                requestPay.shippingsysid = ShipingSysId;
                requestPay.rptdate = rptDate;
                requestPay.currency = ((ValueInfo)this.cmbCurrency.SelectedItem).ValueField;
                requestPay.template = ((ValueInfo)this.cmbTemplate.SelectedItem).ValueField;

                List<tinprequestpaydtl> lstRequestPayDtl = new List<tinprequestpaydtl>();
                foreach (UltraGridRow row in this.grdDetail.Rows)
                {
                    tinprequestpaydtl requestpaydtl = new tinprequestpaydtl();
                    requestpaydtl.shippingsysid = ShipingSysId;
                    requestpaydtl.itemname = row.Cells["itemname"].Value.ToString();
                    requestpaydtl.currency = row.Cells["currency"].Value.ToString();
                    requestpaydtl.unit = row.Cells["unit"].Value.ToString();
                    requestpaydtl.price = Convert.ToDecimal(row.Cells["price"].Value);
                    requestpaydtl.qty = Convert.ToDecimal(row.Cells["qty"].Value);
                    lstRequestPayDtl.Add(requestpaydtl);
                }
                DoInsertRequestPay(requestPay, lstRequestPayDtl);
                #endregion

                #region Get Data
                DataTable pricingDt = GetValidPricing(customerId, rptDate);
                DataTable iqcDt = GetValidIQC(customerId);
                DataTable exDt = GetValidExchange(rptDate);
                string currency = ((ValueInfo)this.cmbCurrency.SelectedItem).ValueField.Trim();
                #endregion

                #region Check Shipping
                var qByStyleNo=from p in dtlDt.AsEnumerable()
                               group p by new
                               {
                                   styleno = p["styleno"].ToString(),
                                   checktype = p["checktype"].ToString()
                               } into g
                               select new
                               {
                                   g.Key.styleno,
                                   g.Key.checktype
                               };
                foreach (var data in qByStyleNo)
                {
                    var iqcckq=from p in iqcDt.AsEnumerable()
                               where p["styleno"].ToString().Equals(data.styleno.ToString())
                                   && p["customerid"].ToString().Equals(customerId)
                               select p;
                    //Check IQC
                    if (iqcckq.Count() == 0)
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01028", data.styleno.ToString()));
                    }
                    else
                    {
                        string shoeCategory = iqcckq.ElementAt(0)["category"].ToString();
                        Double bootHeight = Convert.ToDouble(iqcckq.ElementAt(0)["bootheight"]);
                        //Check Pricing
                        
                        var pricingckq = from p in pricingDt.AsEnumerable()
                                            where p["category"].ToString().Equals(shoeCategory)
                                            && Convert.ToDouble(p["sbootheight"]) <= bootHeight
                                            && Convert.ToDouble(p["ebootheight"]) >= bootHeight
                                            && p["checktype"].ToString().Equals(data.checktype)
                                            select p;
                        if (pricingckq.Count() == 0)
                        {
                            throw new Exception(UtilCulture.GetString("Msg.R01029", shoeCategory + "," + bootHeight + "," + data.checktype));
                        }
                        else
                        {
                            //Check Exchange
                            if (!pricingckq.ElementAt(0)["currency"].ToString().Trim().Equals(currency))
                            {
                                var exckq = from p in exDt.AsEnumerable()
                                            where p["fromcurrency"].ToString().Equals(pricingckq.ElementAt(0)["currency"].ToString())
                                            && p["tocurrency"].ToString().Equals(currency)
                                            select p;
                                if (exckq.Count() == 0)
                                {
                                    throw new Exception(UtilCulture.GetString("Msg.R01030", pricingckq.ElementAt(0)["currency"].ToString() + "->" + bootHeight + "," + currency));
                                }
                            }
                        }
                        if (data.checktype.Equals("IX"))
                        {
                            var pricingckiq = from p in pricingDt.AsEnumerable()
                                             where p["category"].ToString().Equals(shoeCategory)
                                             && Convert.ToDouble(p["sbootheight"]) <= bootHeight
                                             && Convert.ToDouble(p["ebootheight"]) >= bootHeight
                                             && p["checktype"].ToString().Equals("I")
                                             select p;

                            if (pricingckiq.Count() == 0)
                            {
                                throw new Exception(UtilCulture.GetString("Msg.R01029", shoeCategory + "," + bootHeight + ",I"));
                            }
                            else
                            {
                                //Check Exchange
                                if (!pricingckiq.ElementAt(0)["currency"].ToString().Trim().Equals(currency))
                                {
                                    var exckq = from p in exDt.AsEnumerable()
                                                where p["fromcurrency"].ToString().Equals(pricingckiq.ElementAt(0)["currency"].ToString())
                                                && p["tocurrency"].ToString().Equals(currency)
                                                select p;
                                    if (exckq.Count() == 0)
                                    {
                                        throw new Exception(UtilCulture.GetString("Msg.R01030", pricingckiq.ElementAt(0)["currency"].ToString() + "->"  + currency));
                                    }
                                }
                            }
                        }

                    }
                }
                #endregion

                #region Check Other Pricing has exchange rate
                foreach (tinprequestpaydtl requestpaydtl in lstRequestPayDtl)
                {
                    //Check Exchange
                    if (!requestpaydtl.currency.Trim().Equals(currency))
                    {
                        var exckq = from p in exDt.AsEnumerable()
                                    where p["fromcurrency"].ToString().Equals(requestpaydtl.currency)
                                    && p["tocurrency"].ToString().Equals(currency)
                                    select p;
                        if (exckq.Count() == 0)
                        {
                            throw new Exception(UtilCulture.GetString("Msg.R01030", requestpaydtl.currency + "->"  + currency));
                        }
                    }
                }
                #endregion

                WaitingForm.CreateWaitForm();
                WaitingForm.SetWaitMessage("正在生成请款单，请稍候...");
                (new ExcelExport()).ExportRequestPay(((ValueInfo)this.cmbTemplate.SelectedItem).ValueField,rptDate,
                    currency, GetSingleShipping(ShipingSysId), GetShippingOrigDtlForReport(ShipingSysId), GetPackingRecRetrieve(ShipingSysId), iqcDt, pricingDt, exDt, lstRequestPayDtl);

                WaitingForm.CloseWaitForm();

            }
            catch (Exception ex)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, ex.Message);
                
            }
        }
        private DataTable GetPackingRecRetrieve(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=sysid}
                        };
                dt = client.GetPackingRecRetrieveRecords(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];
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
        private DataTable GetSingleShipping(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=sysid}
                        };
                dt = client.GetShippingRecords(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];
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

        private DataTable GetValidOtherPricing(string customerid, DateTime date)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {                
                dt = client.GetValidOtherPricing(baseForm.CurrentContextInfo, customerid,date).Tables[0];
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

        private DataTable GetValidExchange(DateTime date)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            DataTable dt = null;
            try
            {
               dt = client.GetValidExchange(baseForm.CurrentContextInfo, date).Tables[0];
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

        private DataTable GetValidPricing(string customerid, DateTime date)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                dt = client.GetValidPricing(baseForm.CurrentContextInfo, customerid, date).Tables[0];
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

        private DataTable GetValidIQC(string customerid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                dt = client.GetValidIQC(baseForm.CurrentContextInfo, customerid).Tables[0];
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

        private DataTable GetShippingDtlForReport(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                dt = client.GetShippingDtlForReport(baseForm.CurrentContextInfo, sysid).Tables[0];
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

        private DataTable GetShippingOrigDtlForReport(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                dt = client.GetShippingOrigDtlForReport(baseForm.CurrentContextInfo, sysid).Tables[0];
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

        private void DoInsertRequestPay(tinprequestpay requestPay, List<tinprequestpaydtl> lstRequestPayDtl)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();            
            try
            {
                client.DoInsertRequestPay(baseForm.CurrentContextInfo, requestPay, lstRequestPayDtl.ToArray<tinprequestpaydtl>());
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

        private DataTable GetRequestPayDtl(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=sysid}
                        };
                dt = client.GetRequestPayDtlRecords(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];
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

        private tinprequestpay GetSingleRequestPay(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            tinprequestpay result = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=sysid}
                        };
                result = client.GetSingleRequestPay(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return result;
        }

        

        private DataTable createEmptyTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("shippingsysid");            
            dt.Columns.Add("itemname");
            dt.Columns.Add("unit");
            dt.Columns.Add("currency");
            dt.Columns.Add("price");
            dt.Columns.Add("qty");
            return dt;
        }

        private void addDetail()
        {
            DataTable dt = this.grdDetail.DataSource as DataTable;
            DataRow row = dt.NewRow();
            row.ItemArray = new object[] {
                ShipingSysId,
                string.Empty,
                string.Empty,
                string.Empty,
                0,
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

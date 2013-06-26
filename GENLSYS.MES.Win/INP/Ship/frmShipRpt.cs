using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.Win.Common.Forms;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Win.Report;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Win.INP.Ship
{
    public partial class frmShipRpt : Form
    {
        private BaseForm baseForm;
        public string ShipingSysId { get; set; }

        #region Construct
        public frmShipRpt()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events
        private void frmShipRpt_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            if (ShipingSysId != null)
            {
                DataTable dt = GetSingleShipping(ShipingSysId);
                if (dt.Rows.Count > 0)
                {
                    this.txtShipNo.Text = dt.Rows[0]["shippingno"].ToString();
                    this.txtCustomer.Text = dt.Rows[0]["customername"].ToString();
                    this.txtFactory.Text = dt.Rows[0]["factory"].ToString();
                    this.txtCartonQty.Text = dt.Rows[0]["cartonqty"].ToString();
                }
            }
            
        }
        

        private void txtShipNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable dt = GetSingleShippingByNo(this.txtShipNo.Text);
                if (dt.Rows.Count > 0)
                {
                    ShipingSysId = dt.Rows[0]["shippingsysid"].ToString();
                    this.txtCustomer.Text = dt.Rows[0]["customername"].ToString();
                    this.txtFactory.Text = dt.Rows[0]["factory"].ToString();
                    this.txtCartonQty.Text = dt.Rows[0]["cartonqty"].ToString();
                    this.btnPrint.Enabled = true;
                }
                else
                {
                    ShipingSysId = null;
                    this.txtCustomer.Text = "";
                    this.txtFactory.Text = "";
                    this.txtCartonQty.Text = "";
                    this.btnPrint.Enabled = false;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rdPackingList.Checked)
                {
                    WaitingForm.CreateWaitForm();
                    WaitingForm.SetWaitMessage("正在生成PackingList，请稍候...");
                    (new ExcelExport()).ExportPackingListRpt(GetSingleShipping(ShipingSysId), GetShippingDtlForReport(ShipingSysId));
                    WaitingForm.CloseWaitForm();
                    //RDLCReportViewer rpt = new RDLCReportViewer();
                    //rpt.SetReportEmbeddedResource("GENLSYS.MES.Win.Report.Rdlc.ShippingList.rdlc");
                    //Dictionary<string, DataTable> dic = new Dictionary<string, DataTable>();
                    //dic.Add("ShippingDS", GetSingleShipping(ShipingSysId));
                    //dic.Add("ShippingDtlDS", GetShippingDtlForReport(ShipingSysId));
                    //rpt.SetDataSource(dic);
                    //rpt.Show(this);
                }
                else if (this.rdShipForSaving.Checked)
                {
                    WaitingForm.CreateWaitForm();
                    WaitingForm.SetWaitMessage("正在生成出库单，请稍候...");
                    (new ExcelExport()).ExportWarehouseOutRpt(GetSingleShipping(ShipingSysId), GetShippingDtlForWarehouseOut(ShipingSysId), 1);
                    WaitingForm.CloseWaitForm();
                    //RDLCReportViewer rpt = new RDLCReportViewer();
                    //rpt.SetReportEmbeddedResource("GENLSYS.MES.Win.Report.Rdlc.rptWarehouseOut1.rdlc");
                    //Dictionary<string, DataTable> dic = new Dictionary<string, DataTable>();
                    //dic.Add("dsHeader", GetSingleShipping(ShipingSysId));
                    //dic.Add("dsDetail", GetShippingDtlForWarehouseOut(ShipingSysId));
                    //rpt.SetDataSource(dic);
                    //rpt.Show(this);
                }
                else if (this.rdShipForCustomer.Checked)
                {
                    WaitingForm.CreateWaitForm();
                    WaitingForm.SetWaitMessage("正在生成出库单，请稍候...");
                    (new ExcelExport()).ExportWarehouseOutRpt(GetSingleShipping(ShipingSysId), GetShippingDtlForWarehouseOut(ShipingSysId), 2);
                    WaitingForm.CloseWaitForm();
                    //RDLCReportViewer rpt = new RDLCReportViewer();
                    //rpt.SetReportEmbeddedResource("GENLSYS.MES.Win.Report.Rdlc.rptWarehouseOut2.rdlc");
                    //Dictionary<string, DataTable> dic = new Dictionary<string, DataTable>();
                    //dic.Add("dsHeader", GetSingleShipping(ShipingSysId));
                    //dic.Add("dsDetail", GetShippingDtlForWarehouseOut(ShipingSysId));
                    //rpt.SetDataSource(dic);
                    //rpt.Show(this);
                }
                else
                {
                    //RDLCReportViewer rpt = new RDLCReportViewer();
                    //rpt.SetReportEmbeddedResource("GENLSYS.MES.Win.Report.Rdlc.rptBilling.rdlc");
                    //Dictionary<string, DataTable> dic = new Dictionary<string, DataTable>();
                    //dic.Add("dsHeader", GetSingleShipping(ShipingSysId));
                    //dic.Add("dsDetail", GetBillForBillingReport(ShipingSysId));
                    //rpt.SetDataSource(dic);
                    //rpt.Show(this);
                    frmRequestPay frm = new frmRequestPay();
                    frm.ShipingSysId = ShipingSysId;
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Methods
        
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

        private DataTable GetSingleShippingByNo(string shippingno)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingno",ParamValue=shippingno}
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
        private DataTable GetShippingDtlForWarehouseOut(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                dt = client.GetShippingDtlForWarehouseOut(baseForm.CurrentContextInfo, sysid).Tables[0];
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
        private DataTable GetBillForBillingReport(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                dt = client.GetBillForBillingReport(baseForm.CurrentContextInfo, sysid).Tables[0];
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

        public bool CheckFunctionPrivilege(string funcurl)
        {
            bool result = false;
            foreach (DataRow row in Parameter.USER_FUNCTIONS.Rows)
            {
                if (funcurl.Trim().Equals(row["funcurl"].ToString().Trim()))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        #endregion


        
    }
}

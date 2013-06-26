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
using System.Collections;
using GENLSYS.MES.Utility;
using GENLSYS.MES.DataContracts;
using Infragistics.Win;

namespace GENLSYS.MES.Win.INP.Ship
{
    public partial class frmShip : Form
    {
        public string ShipingSysId { get; set; }
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        private DataTable packingCartonDt = null;
        private DataTable shippingDtlCtnDt = null;
        private DataTable ctnDtlDt = null;
        private Hashtable ht = null;
        private string ReceivingNoNamingRule = string.Empty;
        private string BillLockRefId = string.Empty;
        private bool IsNeedToUnlockBill = false;
        private string[] subColumns = new string[] { "styleno", "color", "size", "pairqty" };

        #region Construct
        public frmShip()
        {
            InitializeComponent();

            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdPlan, new string[] { "customerid", "custorderno", "customername", "factory", "ttlcantonqty" });
            baseForm.CreateUltraGridColumns(this.grdCarton, new string[] {"customerid","ck", "custorderno", "cartonno", "pairqty" });
        }
        #endregion

        #region Event
        private void frmShip_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdPlan);
            baseForm.SetQueryGridStyle(this.grdCarton);
            this.grdPlan.DisplayLayout.Bands[0].Columns["customerid"].Hidden = true;
            this.grdCarton.DisplayLayout.Bands[0].Columns["customerid"].Hidden = true;
            
            DropDown.InitCMB_StaticValue(this.cmbLoadingType, MES_StaticValue_Type.LoadingType);

            packingCartonDt = GetPackingCarton();
            ctnDtlDt = GetPackingRecDtl();

            if (ShipingSysId != null)
            {
                tinpshipping shipping = GetSingleShipping(ShipingSysId);
                this.txtShipNo.Text = shipping.shippingno;
                DropDown.InitCMB_DataTable(this.cmbShippingPlanNo, GetShippingPlanNo(shipping.shippingsysid), "shippingplanno", "shippingsysid");
                DropDown.SelectCMBValue(this.cmbShippingPlanNo, shipping.shippingsysid);
                this.cmbShippingPlanNo.Enabled = false;
                this.txtPackingBoxNo.Text = shipping.packingboxno;
                this.txtContainerNo.Text = shipping.containerno;
                this.txtBlNo.Text = shipping.blno;
                DropDown.SelectCMBValue(this.cmbLoadingType, shipping.loadingtype);
               
                if (shipping.shippingstatus.Equals(MES_ShippingStatus.Shipped.ToString()))
                {
                    this.btnSave.Enabled = false;
                    this.btnShip.Enabled = false;
                }
                GetTotalCartonQty();
            }
            else
            {
                DropDown.InitCMB_DataTable(this.cmbShippingPlanNo, GetShippingPlanNo(null), "shippingplanno", "shippingsysid");
                BillLockRefId = Function.GetGUID();
                ReceivingNoNamingRule = baseForm.GetSystemConfig("SYS_SHIPPINGNO");
                List<string> lstRecNo = baseForm.GetBillNoBatch(ReceivingNoNamingRule, 1, BillLockRefId);
                this.txtShipNo.Text = lstRecNo[0];
                IsNeedToUnlockBill = true;
            }

            //this.txtShipNo.Enabled = false;
            this.txtEmptyBoxQty.ForeColor = Color.Red;
            this.txtEmptyBoxQty.BackColor = Color.Gold;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoShipping(false);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DoShipping(true);
        }
        private void cmbShippingPlanNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShipingSysId = ((ValueInfo)this.cmbShippingPlanNo.SelectedItem).ValueField;
            DataTable dt = GetShippingDtlRecords(ShipingSysId);
            shippingDtlCtnDt = GetShippingDtlCtnRecords(ShipingSysId);
            this.grdPlan.SetDataBinding(dt, "");
            buildHashTable();

            tinpshippingplan shippingplan = GetShippingPlan(((ValueInfo)this.cmbShippingPlanNo.SelectedItem).DisplayField);
            if (shippingplan != null)
            {
                this.dtLoadingDt.Value = shippingplan.loadingdate;
                this.txtBoxQty.Text = shippingplan.boxqty;
                this.txtBlNo.Text = shippingplan.deliverybill;
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
            else
            {
                this.dtLoadingDt.Value = Function.GetCurrentTime();
                this.txtBoxQty.Text = "";
                this.txtBlNo.Text = "";
                this.txtInShipNo.Text = "";
                this.numCommissionedQty.Value = 0;
                this.numCommissionedVolume.Value = 0;
                this.numCommissionedWeight.Value = 0;
                this.txtStartPort.Text = "";
                this.txtDestinationPort.Text = "";
                this.txtUnloadPort.Text = "";
                this.txtVoyage.Text = "";
                this.txtRemark.Text = "";
            }
        }
        private void grdPlan_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.grdPlan.ActiveRow != null)
            {
                this.grdCarton.SetDataBinding(createEmptyCartonTable(), "");
                string custorderno = this.grdPlan.ActiveRow.Cells["custorderno"].Value.ToString();
                DataTable ctnDt = ht[custorderno] as DataTable;

                if (ctnDt.DataSet != null)
                {
                    ctnDt.DataSet.Relations.Clear();
                    ctnDt.DataSet.Tables.Clear();
                }
                if (ctnDtlDt.DataSet != null)
                {
                    ctnDtlDt.DataSet.Relations.Clear();
                    ctnDtlDt.DataSet.Tables.Clear();
                }

                DataSet ds = new DataSet();
                ctnDt.TableName = "Main";
                ctnDtlDt.TableName = "Sub";
                ds.Tables.Add(ctnDt);
                ds.Tables.Add(ctnDtlDt);
                ds.Relations.Add("ps", new DataColumn[] { ds.Tables["Main"].Columns["customerid"], ds.Tables["Main"].Columns["custorderno"], ds.Tables["Main"].Columns["cartonno"] }, new DataColumn[] { ds.Tables["Sub"].Columns["customerid"], ds.Tables["Sub"].Columns["custorderno"], ds.Tables["Sub"].Columns["cartonno"] },false);
                
                this.grdCarton.SetDataBinding(ds,"");
            }
        }
        private void grdCarton_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.NewColumnLoadStyle = NewColumnLoadStyle.Show;
            e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;
            e.Layout.Bands[0].Columns["ck"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.HeaderCheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
            e.Layout.Override.HeaderCheckBoxAlignment = HeaderCheckBoxAlignment.Center;

            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();

            UltraGridColumn column = e.Layout.Bands[0].Columns["ck"];
            column.Header.Caption = "";
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            column.Editor.DataFilter = new CheckEditorStringDataFilter();
            column.Width = 40;

            if (e.Layout.Bands.Count > 1)
            {
                foreach (UltraGridColumn col in e.Layout.Bands[1].Columns)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    if (!subColumns.Contains(col.Key))
                    {
                        col.Hidden = true;
                    }
                }
                for (int i = 0; i < subColumns.Count(); i++)
                {
                    e.Layout.Bands[1].Columns[subColumns[i]].Header.VisiblePosition = i;
                }

                e.Layout.Bands[1].Columns["styleno"].Header.Caption = UtilCulture.GetString("Label.R01026");
                e.Layout.Bands[1].Columns["color"].Header.Caption = UtilCulture.GetString("Label.R01027");
                e.Layout.Bands[1].Columns["size"].Header.Caption = UtilCulture.GetString("Label.R01028");
                e.Layout.Bands[1].Columns["pairqty"].Header.Caption = UtilCulture.GetString("Label.R02026");

                e.Layout.Bands[1].Columns["size"].SortComparer = new SizeComparer();
            }
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
        private void grdCarton_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "ck")
            {
                GetTotalCartonQty();
            }
        }

        private void grdPlan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumTtlcantonqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumTtlcantonqty", SummaryType.Sum, e.Layout.Bands[0].Columns["ttlcantonqty"], SummaryPosition.UseSummaryPositionColumn);
            }
        }
        private void grdCarton_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (Convert.ToInt16(e.Row.Cells["pairqty"].Value) == 0)
            {
                e.Row.Appearance.BackColor = Color.Pink;
            }
        }
        #endregion

        #region Method
       
        private void DoShipping(bool isDoShipping)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();
                baseForm.ValidateData(this);

                List<tinpshippingdtlctn> lstshippingdtlctn = new List<tinpshippingdtlctn>();
                                
                foreach (string key in ht.Keys)
                {
                    DataTable dt = ht[key] as DataTable;
                    int ctnqty = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["ck"].ToString().Equals("Y"))
                        {
                            tinpshippingdtlctn shippingdtlctn = new tinpshippingdtlctn();
                            shippingdtlctn.shippingsysid = ShipingSysId;
                            shippingdtlctn.customerid = row["customerid"].ToString(); 
                            shippingdtlctn.custorderno = key;
                            shippingdtlctn.cartonno = row["cartonno"].ToString();
                            shippingdtlctn.pairqty = Convert.ToInt16(row["pairqty"].ToString());
                            lstshippingdtlctn.Add(shippingdtlctn);
                            ctnqty++;
                        }
                    }
                    if (ctnqty > getPlanQty(key) || (isDoShipping && ctnqty != getPlanQty(key)))
                    {
                        throw new Exception(UtilCulture.GetString("Msg.R01024"));
                    }
                }

                tinpshipping shipping = new tinpshipping();
                shipping.shippingsysid = ShipingSysId;
                shipping.packingboxno = this.txtPackingBoxNo.Text;
                shipping.shippingno = this.txtShipNo.Text;
                shipping.containerno = this.txtContainerNo.Text;
                shipping.blno = this.txtBlNo.Text;
                //shipping.contractno = this.txtContractNo.Text;
                if (this.cmbLoadingType.SelectedItem != null)
                {
                    shipping.loadingtype = ((ValueInfo)this.cmbLoadingType.SelectedItem).ValueField;
                }

                tinpshippingplan shippingplan = new tinpshippingplan();
                shippingplan.shippingplanno = ((ValueInfo)this.cmbShippingPlanNo.SelectedItem).DisplayField;
                shippingplan.loadingdate = Convert.ToDateTime(this.dtLoadingDt.Value);
                shippingplan.boxqty = this.txtBoxQty.Text;
                shippingplan.deliverybill = this.txtBlNo.Text;
                shippingplan.inshipno = this.txtInShipNo.Text;
                shippingplan.commissionedqty = Convert.ToInt16(this.numCommissionedQty.Value);
                shippingplan.commissionedvolume = this.numCommissionedVolume.Value;
                shippingplan.commissionedweight = this.numCommissionedWeight.Value;
                shippingplan.startport = this.txtStartPort.Text;
                shippingplan.destinationport = this.txtDestinationPort.Text;
                shippingplan.unloadport = this.txtUnloadPort.Text;
                shippingplan.voyage = this.txtVoyage.Text;

                client.DoShipping(baseForm.CurrentContextInfo, shipping, lstshippingdtlctn.ToArray<tinpshippingdtlctn>(),shippingplan, isDoShipping);
                
                baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00028"));
                
                
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

        private int getPlanQty(string custorderno)
        {
            int result = 0;
            DataTable planDt = this.grdPlan.DataSource as DataTable;
            var q = from p in planDt.AsEnumerable()
                    where p["custorderno"].ToString().Equals(custorderno)
                    select p;
            foreach (DataRow qRow in q)
            {
                result = Convert.ToInt16(qRow["ttlcantonqty"]);
            }
            return result;

        }
        private void buildHashTable()
        {
            ht = new Hashtable();
            DataTable dt = this.grdPlan.DataSource as DataTable;

            foreach (DataRow row in dt.Rows)
            {
                string custorderno = row["custorderno"].ToString();
                string customerid = row["customerid"].ToString();
                DataTable cartonDt = createEmptyCartonTable();

                var q = from p in shippingDtlCtnDt.AsEnumerable()
                        where p["custorderno"].ToString().ToUpper().Equals(custorderno.ToUpper()) && p["customerid"].ToString().Equals(customerid)
                        select p;

                foreach (DataRow qRow in q)
                {
                    DataRow ctnRow = cartonDt.NewRow();
                    ctnRow.ItemArray = new object[] {
                        "Y",
                        qRow["customerid"],
                        qRow["custorderno"],
                        qRow["cartonno"],
                        qRow["pairqty"]
                    };
                    cartonDt.Rows.Add(ctnRow);
                }

                var pq =from p in packingCartonDt.AsEnumerable()
                        where p["custorderno"].ToString().ToUpper().Equals(custorderno.ToUpper()) && p["customerid"].ToString().Equals(customerid)
                        select p;

                foreach (DataRow pqRow in pq)
                {
                    DataRow ctnRow = cartonDt.NewRow();
                    ctnRow.ItemArray = new object[] {
                        "N",
                        pqRow["customerid"],
                        pqRow["custorderno"],
                        pqRow["cartonno"],
                        pqRow["pairqty"]
                    };
                    cartonDt.Rows.Add(ctnRow);
                }

                ht.Add(custorderno, cartonDt);

            }

        }

        private DataTable createEmptyCartonTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ck");
            dt.Columns.Add("customerid");
            dt.Columns.Add("custorderno");
            dt.Columns.Add("cartonno");
            dt.Columns.Add("pairqty");
            return dt;
        }

        private DataTable GetShippingDtlRecords(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=sysid}
                        };
                dt = client.GetShippingDtlRecords(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];
                
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

        private DataTable GetShippingDtlCtnRecords(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=sysid}
                        };
                dt = client.GetShippingDtlCtnRecords(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];

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
        private DataTable GetShippingPlanNo(string shippingsysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                dt = client.GetShippingPlanNoRecords(baseForm.CurrentContextInfo, shippingsysid).Tables[0];
                DataView dv = dt.DefaultView;
                dv.Sort = "shippingplanno desc";
                dt = dv.ToTable();
                
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

        private DataTable GetPackingCarton()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                dt = client.GetPackingCartonRecords(baseForm.CurrentContextInfo).Tables[0];
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

        private tinpshipping GetSingleShipping(string sysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            tinpshipping shipping = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="shippingsysid",ParamValue=sysid}
                        };
                shipping = client.GetSingleShipping(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return shipping;
        }

        private DataTable GetPackingRecDtl()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="pktype",ParamValue=MES_PackingType.Packing.ToString()}
                        };
                DataSet ds = client.GetPackingRecDtlRecords(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>());
                dt = ds.Tables[0];
                ds.Tables.Clear();
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

        private void GetTotalCartonQty()
        {
            int ctnqty = 0;
            int emptyctnqty = 0;
            foreach (string key in ht.Keys)
            {
                DataTable dt = ht[key] as DataTable;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["ck"].ToString().Equals("Y"))   
                    {
                        if (Convert.ToInt16(row["pairqty"].ToString()) == 0)
                        {
                            emptyctnqty++;
                        }
                        else
                        {
                            ctnqty++;
                        }
                    }
                }
            }
            this.txtActualBoxQty.Text = Convert.ToString(ctnqty);
            this.txtEmptyBoxQty.Text = Convert.ToString(emptyctnqty);
        }
        #endregion

        
        
    }
}

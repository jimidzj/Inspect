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

namespace GENLSYS.MES.Win.INP.Pricing
{
    public partial class frmPricing : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;
        private tinppricing OriginalPricing;

        #region Construct
        public frmPricing()
        {
            InitializeComponent();
            baseForm = new BaseForm();

            baseForm.CreateUltraGridColumns(this.grdDetail, new string[] { 
                "category","sbootheight","ebootheight","checktype","effectivedate","expireddate",
                "currency","price","unit","reworkratio","reworkprice","remark" });
        }
        #endregion

        #region Events
        private void frmPricing_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdDetail);
            SetLayout();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                this.cboCustomer.Enabled = false;
                DoShowSingleObject(PrimaryKeys);
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
            //set check type
            if (!this.grdDetail.DisplayLayout.ValueLists.Exists("vlchecktype"))
            {
                this.grdDetail.DisplayLayout.ValueLists.Add("vlchecktype");
                this.grdDetail.DisplayLayout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                this.grdDetail.DisplayLayout.Bands[0].Columns["checktype"].CellActivation = Activation.AllowEdit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["checktype"].CellClickAction = CellClickAction.Edit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdDetail.DisplayLayout.Bands[0].Columns["checktype"].ValueList = this.grdDetail.DisplayLayout.ValueLists["vlchecktype"];
            }

            //set currency
            if (!this.grdDetail.DisplayLayout.ValueLists.Exists("vlcurrency"))
            {
                this.grdDetail.DisplayLayout.ValueLists.Add("vlcurrency");
                this.grdDetail.DisplayLayout.ValueLists["vlcurrency"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.Currency));
                this.grdDetail.DisplayLayout.Bands[0].Columns["currency"].CellActivation = Activation.AllowEdit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["currency"].CellClickAction = CellClickAction.Edit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["currency"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdDetail.DisplayLayout.Bands[0].Columns["currency"].ValueList = this.grdDetail.DisplayLayout.ValueLists["vlcurrency"];
            }

            //set unit
            if (!this.grdDetail.DisplayLayout.ValueLists.Exists("vlunit"))
            {
                this.grdDetail.DisplayLayout.ValueLists.Add("vlunit");
                this.grdDetail.DisplayLayout.ValueLists["vlunit"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.Unit));
                this.grdDetail.DisplayLayout.Bands[0].Columns["unit"].CellActivation = Activation.AllowEdit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["unit"].CellClickAction = CellClickAction.Edit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["unit"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdDetail.DisplayLayout.Bands[0].Columns["unit"].ValueList = this.grdDetail.DisplayLayout.ValueLists["vlunit"];
            }

            if (!this.grdDetail.DisplayLayout.ValueLists.Exists("vlcategory"))
            {
                this.grdDetail.DisplayLayout.ValueLists.Add("vlcategory");
                this.grdDetail.DisplayLayout.ValueLists["vlcategory"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.ShoeCategory));
                this.grdDetail.DisplayLayout.Bands[0].Columns["category"].CellActivation = Activation.AllowEdit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["category"].CellClickAction = CellClickAction.Edit;
                this.grdDetail.DisplayLayout.Bands[0].Columns["category"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdDetail.DisplayLayout.Bands[0].Columns["category"].ValueList = this.grdDetail.DisplayLayout.ValueLists["vlcategory"];
            }
                       

            this.grdDetail.DisplayLayout.Bands[0].Columns["effectivedate"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["effectivedate"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.grdDetail.DisplayLayout.Bands[0].Columns["effectivedate"].Width = 110;
            this.grdDetail.DisplayLayout.Bands[0].Columns["effectivedate"].Format = "yyyy-MM-dd";

            this.grdDetail.DisplayLayout.Bands[0].Columns["expireddate"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["expireddate"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.grdDetail.DisplayLayout.Bands[0].Columns["expireddate"].Width = 110;
            this.grdDetail.DisplayLayout.Bands[0].Columns["expireddate"].Format = "yyyy-MM-dd";

            this.grdDetail.DisplayLayout.Bands[0].Columns["sbootheight"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["sbootheight"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive;

            this.grdDetail.DisplayLayout.Bands[0].Columns["ebootheight"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["ebootheight"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive;
            
            this.grdDetail.DisplayLayout.Bands[0].Columns["price"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["price"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive;

            this.grdDetail.DisplayLayout.Bands[0].Columns["reworkratio"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["reworkratio"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive;

            this.grdDetail.DisplayLayout.Bands[0].Columns["reworkprice"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["reworkprice"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive;

            this.grdDetail.DisplayLayout.Bands[0].Columns["remark"].CellActivation = Activation.AllowEdit;
            this.grdDetail.DisplayLayout.Bands[0].Columns["remark"].Width = 250;
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

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                new MESParameterInfo(){ParamName="customerid",ParamValue = (this.cboCustomer.SelectedItem as ValueInfo).ValueField}
            };
            DoShowSingleObject(lstParameters);

            if (this.grdDetail.Rows.Count > 0)
                UpdateMode = Public_UpdateMode.Update;
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
            DropDown.InitCMB_Customer_All(this.cboCustomer);
            //DropDown.InitCMB_StaticValue(this.cboCheckType, MES_StaticValue_Type.CheckType);
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

                tinppricing prc = new tinppricing();

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    prc = OriginalPricing;
                }

                //Build Pricing Object
                baseForm.CreateSingleObject<tinppricing>(prc, this, UpdateMode);

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    prc.prisysid = Function.GetGUID();
                }

                prc.lastmodifiedtime = Function.GetCurrentTime();
                prc.lastmodifieduser = Function.GetCurrentUser();

                #endregion

                #region Prepare Pricing Detail
                List<tinppricingdtl> lstDtl = new List<tinppricingdtl>();
                for (int i = 0; i < grdDetail.Rows.Count; i++)
                {
                    tinppricingdtl dtl = new tinppricingdtl();

                    dtl.checktype = this.grdDetail.Rows[i].Cells["checktype"].Value.ToString();
                    dtl.lastmodifiedtime = prc.lastmodifiedtime;
                    dtl.lastmodifieduser = prc.lastmodifieduser;
                    dtl.pridtlsysid = Function.GetGUID();
                    dtl.prisysid = prc.prisysid;
                    dtl.remark = string.Empty;
                    dtl.category = this.grdDetail.Rows[i].Cells["category"].Value.ToString();

                    if (this.grdDetail.Rows[i].Cells["reworkratio"].Value.ToString() == string.Empty)
                        dtl.reworkratio = null;
                    else
                        dtl.reworkratio = decimal.Parse(this.grdDetail.Rows[i].Cells["reworkratio"].Value.ToString());

                    if (this.grdDetail.Rows[i].Cells["reworkprice"].Value.ToString() == string.Empty)
                        dtl.reworkprice = null;
                    else
                        dtl.reworkprice = decimal.Parse(this.grdDetail.Rows[i].Cells["reworkprice"].Value.ToString());

                    if (this.grdDetail.Rows[i].Cells["sbootheight"].Value.ToString() == string.Empty)
                        dtl.sbootheight = 0;
                    else
                        dtl.sbootheight = decimal.Parse(this.grdDetail.Rows[i].Cells["sbootheight"].Value.ToString());

                    if (this.grdDetail.Rows[i].Cells["ebootheight"].Value.ToString() == string.Empty)
                        dtl.ebootheight = 0;
                    else
                        dtl.ebootheight = decimal.Parse(this.grdDetail.Rows[i].Cells["ebootheight"].Value.ToString());

                    lstDtl.Add(dtl);
                }

                var q = (from p in lstDtl
                         group p by new { p.category, p.checktype,p.sbootheight,p.ebootheight } into t1
                         select new
                         {
                             category = t1.Key.category,
                             checktype = t1.Key.checktype,
                             pridtlsysid = t1.Max(p => p.pridtlsysid),
                             prisysid = t1.Max(p => p.prisysid),
                             remark = t1.Max(p => p.remark),
                             reworkratio = t1.Max(p => p.reworkratio),
                             reworkprice = t1.Max(p => p.reworkprice),
                             sbootheight = t1.Key.sbootheight,
                             ebootheight = t1.Key.ebootheight,
                             lastmodifiedtime = t1.Max(p => p.lastmodifiedtime),
                             lastmodifieduser = t1.Max(p => p.lastmodifieduser)
                         }).ToList();

                List<tinppricingdtldef> lstDef = new List<tinppricingdtldef>();
                for (int i = 0; i < grdDetail.Rows.Count; i++)
                {
                    tinppricingdtldef def = new tinppricingdtldef();

                    var q1 = (from p in q
                              where p.category == this.grdDetail.Rows[i].Cells["category"].Value.ToString()
                              && p.checktype == this.grdDetail.Rows[i].Cells["checktype"].Value.ToString()
                              && p.sbootheight == Decimal.Parse(this.grdDetail.Rows[i].Cells["sbootheight"].Value.ToString())
                              && p.ebootheight == Decimal.Parse(this.grdDetail.Rows[i].Cells["ebootheight"].Value.ToString())
                              select p.pridtlsysid).Single();

                    def.currency = this.grdDetail.Rows[i].Cells["currency"].Value.ToString();

                    if (this.grdDetail.Rows[i].Cells["effectivedate"].Value.ToString() != string.Empty)
                        def.effectivedate = DateTime.Parse(this.grdDetail.Rows[i].Cells["effectivedate"].Value.ToString());

                    if (this.grdDetail.Rows[i].Cells["expireddate"].Value.ToString() != string.Empty)
                        def.expireddate = DateTime.Parse(this.grdDetail.Rows[i].Cells["expireddate"].Value.ToString());
                    else
                        def.expireddate = null;

                    def.price = decimal.Parse(this.grdDetail.Rows[i].Cells["price"].Value.ToString());
                    def.pridtldefsysid = Function.GetGUID();
                    def.pridtlsysid = q1;
                    def.remark = this.grdDetail.Rows[i].Cells["remark"].Value.ToString();
                    def.unit = this.grdDetail.Rows[i].Cells["unit"].Value.ToString();

                    lstDef.Add(def);
                }

                List<tinppricingdtl> lstDtlFinal = new List<tinppricingdtl>();
                for (int i = 0; i < q.Count; i++)
                {
                    tinppricingdtl dtl = new tinppricingdtl();

                    dtl.checktype = q[i].checktype;
                    dtl.lastmodifiedtime = q[i].lastmodifiedtime;
                    dtl.lastmodifieduser = q[i].lastmodifieduser;
                    dtl.pridtlsysid = q[i].pridtlsysid;
                    dtl.prisysid = q[i].prisysid;
                    dtl.remark = q[i].remark;
                    dtl.category = q[i].category;
                    dtl.reworkratio = q[i].reworkratio;
                    dtl.reworkprice = q[i].reworkprice;
                    dtl.sbootheight = q[i].sbootheight;
                    dtl.ebootheight = q[i].ebootheight;

                    lstDtlFinal.Add(dtl);
                }
                #endregion

                #region call WCF

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.DoInsertPricing(baseForm.CurrentContextInfo, prc,
                        lstDtlFinal.ToArray<tinppricingdtl>(), lstDef.ToArray<tinppricingdtldef>());
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.DoUpdatePricing(baseForm.CurrentContextInfo, prc,
                        lstDtlFinal.ToArray<tinppricingdtl>(), lstDef.ToArray<tinppricingdtldef>());
                }
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

        public void DoShowSingleObject(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                #region Show to UI
                tinppricing prc = client.GetSinglePricing(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                if (prc == null) return;

                baseForm.ShowSingleObjectToUI<tinppricing>(prc, this);
                OriginalPricing = prc;
                #endregion

                #region Show pricing detail
                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>()
                {
                    new MESParameterInfo()
                    {
                        ParamName="prisysid",
                        ParamValue=prc.prisysid,
                        ParamType="string"
                    }
                };

                DataSet ds = client.GetPricingRecords(baseForm.CurrentContextInfo, lstParameter.ToArray<MESParameterInfo>());
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
                        ParamName="prisysid",
                        ParamValue=MES_DummyData.Dummy_Data_XXX_111.ToString(),
                        ParamType="string"
                    }
                };

                DataSet ds = client.GetPricingRecords(baseForm.CurrentContextInfo, lstParameter.ToArray<MESParameterInfo>());
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

        private void InsertDetail()
        {            
            DataTable dt = this.grdDetail.DataSource as DataTable;
            DataRow row = dt.NewRow();
            // a.prisysid,b.pridtlsysid,a.customerid,customername,a.reworkratio,b.styleno,b.checktype,c.effectivedate,c.expireddate,
            //c.currency,c.price,c.unit,c.remark
            row.ItemArray = new object[] {
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                this.nudReworkRatio.Value,
                0,
                string.Empty,
                string.Empty,
                null,
                null,
                "RMB",
                0,
                "双",                
                string.Empty
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
            bool bCross = false;
            DateTime? df1 = null;
            DateTime? dt1 = null;
            DateTime? df2 = null;
            DateTime? dt2 = null;

            for (int i = 0; i < this.grdDetail.Rows.Count; i++)
            {
                if (this.grdDetail.Rows[i].Cells["effectivedate"].Value.ToString() == string.Empty)
                    df1 = null;
                else
                    df1 = DateTime.Parse(this.grdDetail.Rows[i].Cells["effectivedate"].Value.ToString());

                if (this.grdDetail.Rows[i].Cells["expireddate"].Value.ToString() == string.Empty)
                    dt1 = null;
                else
                    dt1 = DateTime.Parse(this.grdDetail.Rows[i].Cells["expireddate"].Value.ToString());

                if (this.grdDetail.Rows[i].Cells["price"].Value.ToString() == string.Empty)
                {
                    MESMsgBox.ShowError(UtilCulture.GetString("Msg.R01005"));
                    return false;
                }

                if (this.grdDetail.Rows[i].Cells["currency"].Value.ToString() == string.Empty)
                {
                    MESMsgBox.ShowError(UtilCulture.GetString("Msg.R01006"));
                    return false;
                }

                if (this.grdDetail.Rows[i].Cells["checktype"].Value.ToString() == string.Empty)
                {
                    MESMsgBox.ShowError(UtilCulture.GetString("Msg.R01010"));
                    return false;
                }

                if (this.grdDetail.Rows[i].Cells["category"].Value.ToString() == string.Empty)
                {
                    MESMsgBox.ShowError(UtilCulture.GetString("Msg.R01011"));
                    return false;
                }

                if (df1 == null)
                {
                    MESMsgBox.ShowError(UtilCulture.GetString("Msg.R01007"));
                    return false;
                }

                if (dt1 != null)
                {
                    if (dt1 < df1)
                    {
                        MESMsgBox.ShowError(UtilCulture.GetString("Msg.R01008"));
                        return false;
                    }
                }

                for (int j = 0; j < this.grdDetail.Rows.Count; j++)
                {
                    if (i != j &&
                        this.grdDetail.Rows[i].Cells["checktype"].Value.ToString() == this.grdDetail.Rows[j].Cells["checktype"].Value.ToString() &&
                        this.grdDetail.Rows[i].Cells["category"].Value.ToString() == this.grdDetail.Rows[j].Cells["category"].Value.ToString() &&
                        this.grdDetail.Rows[i].Cells["sbootheight"].Value.ToString() == this.grdDetail.Rows[j].Cells["sbootheight"].Value.ToString() &&
                        this.grdDetail.Rows[i].Cells["ebootheight"].Value.ToString() == this.grdDetail.Rows[j].Cells["ebootheight"].Value.ToString())
                    {
                        if (this.grdDetail.Rows[j].Cells["effectivedate"].Value.ToString() == string.Empty)
                            df2 = null;
                        else
                            df2 = DateTime.Parse(this.grdDetail.Rows[j].Cells["effectivedate"].Value.ToString());

                        if (this.grdDetail.Rows[j].Cells["expireddate"].Value.ToString() == string.Empty)
                            dt2 = null;
                        else
                            dt2 = DateTime.Parse(this.grdDetail.Rows[j].Cells["expireddate"].Value.ToString());

                        //    1------1
                        //  2-----2
                        //  3-----------3
                        //      4--4
                        //      5-------5
                        if (dt1 == null)
                        {
                            if (dt2 == null)
                            {
                                bCross = true;
                            }
                            else
                            {
                                if (df2 <= df1 || dt2 <= df1)
                                {
                                    //bCross = true;
                                }
                                else
                                    bCross = true;
                            }
                        }
                        else
                        {
                            if (df2 <= df1 && dt2 > df1)
                                bCross = true;
                            if (df2 <= df1 && dt2 >= dt1)
                                bCross = true;
                            if (df2 >= df1 && dt2 <= dt1)
                                bCross = true;
                            if (df2 <= df1 && dt2 > dt1)
                                bCross = true;
                        }
                    }
                }

                if (bCross)
                {
                    MESMsgBox.ShowError(UtilCulture.GetString("Msg.R01009"));
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}

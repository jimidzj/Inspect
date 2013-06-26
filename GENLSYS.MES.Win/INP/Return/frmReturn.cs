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
using Infragistics.Win.UltraWinGrid;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;
using Infragistics.Win;

namespace GENLSYS.MES.Win.INP.Return
{
    public partial class frmReturn : Form
    {
        public string retSysId { get; set; }
        public Public_UpdateMode UpdateMode { get; set; }
        private DataTable returndtlDt = null;
        private tinpreturn inpreturn = null;
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        private string ReceivingNoNamingRule = string.Empty;
        private string BillLockRefId = string.Empty;
        private bool IsNeedToUnlockBill = false;

        #region Construct
        public frmReturn()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdDetail, new string[] { "ck", "custorderno", "styleno", "color", "size","checktype", "pairqty" ,"returnqty"});
        }
        #endregion

        #region Event
        private void frmReturn_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdDetail);

            try
            {
                DataTable custDt = GetAllCustomer().Tables[0];
                DropDown.InitCMB_DataTable(this.cmbCustomer, custDt, "customername", "customerid");
                DropDown.InitCMB_StaticValue(this.cmbReturnType, MES_StaticValue_Type.ReturnType);

                if (retSysId != null)
                {
                    UpdateMode = Public_UpdateMode.Update;
                }
                else
                {
                    UpdateMode = Public_UpdateMode.Insert;
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    BillLockRefId = Function.GetGUID();
                    ReceivingNoNamingRule = baseForm.GetSystemConfig("SYS_RETURNNO");
                    List<string> lstRecNo = baseForm.GetBillNoBatch(ReceivingNoNamingRule, 1, BillLockRefId);
                    this.txtReturnNo.Text = lstRecNo[0];
                    this.txtReturnNo.Enabled = false;
                    IsNeedToUnlockBill = true;
                }
                else
                {
                    inpreturn = GetSingleReturn(retSysId);
                    returndtlDt = GetReturnDtl(retSysId).Tables[0];
                    this.txtReturnNo.Text = inpreturn.returnno;
                    DropDown.SelectCMBValue(this.cmbCustomer,inpreturn.customerid);
                    DropDown.SelectCMBValue(this.cmbReturnType, inpreturn.returntype);
                    this.txtReturnNo.Enabled = false;
                    this.cmbCustomer.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, ex.Message);
            }
        }

        private void grdDetail_AfterRowActivate(object sender, EventArgs e)
        {
            
        }

        private void grdDetail_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Bands[0].Columns["ck"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.HeaderCheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
            e.Layout.Override.HeaderCheckBoxAlignment = HeaderCheckBoxAlignment.Center;

            UltraGridColumn column = e.Layout.Bands[0].Columns["ck"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            column.Editor.DataFilter = new CheckEditorStringDataFilter();
            column.Width = 40;

            UltraGridColumn columnReturnQty = e.Layout.Bands[0].Columns["returnqty"];
            columnReturnQty.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            columnReturnQty.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegativeWithSpin;
            columnReturnQty.Header.Appearance.ForeColor = Color.Red;

            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumReturnqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumReturnqty", SummaryType.Sum, e.Layout.Bands[0].Columns["returnqty"], SummaryPosition.UseSummaryPositionColumn);
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string customerid = ((ValueInfo)this.cmbCustomer.SelectedItem).ValueField;
            GetBadWip(customerid);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoReturn();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Method
        private void DoReturn()
        {
             wsINP.IwsINPClient client = new wsINP.IwsINPClient();
             try
             {
                 baseForm.SetCursor();
                 baseForm.ValidateData(this);

                 if (UpdateMode == Public_UpdateMode.Insert)
                 {
                     inpreturn = new tinpreturn();
                     inpreturn.returnno = this.txtReturnNo.Text;
                     inpreturn.customerid = ((ValueInfo)this.cmbCustomer.SelectedItem).ValueField;                     
                     inpreturn.retsysid = Function.GetGUID();
                     inpreturn.returndate = Function.GetCurrentTime();
                     inpreturn.returnuser = Function.GetCurrentUser();
                 }
                 inpreturn.returntype = ((ValueInfo)this.cmbReturnType.SelectedItem).ValueField;
                 inpreturn.lastmodifiedtime = Function.GetCurrentTime();
                 inpreturn.lastmodifieduser = Function.GetCurrentUser();

                 List<tinpreturndtl> lstreturndtl = new List<tinpreturndtl>();

                 foreach (UltraGridRow row in this.grdDetail.Rows)
                 {
                     if (row.Cells["ck"].Value.ToString().Equals("Y"))
                     {
                         if (Convert.ToInt16(row.Cells["returnqty"].Value) == 0 && UpdateMode == Public_UpdateMode.Insert)
                         {
                             throw new Exception(UtilCulture.GetString("Msg.R01016", UtilCulture.GetString("Label.R02043")));
                         }
                         if (Convert.ToInt16(row.Cells["pairqty"].Value) < Convert.ToInt16(row.Cells["returnqty"].Value))
                         {
                             throw new Exception(UtilCulture.GetString("Msg.R01014", UtilCulture.GetString("Label.R02043"), UtilCulture.GetString("Label.R02026")));
                         }
                         tinpreturndtl returndtl = new tinpreturndtl();
                         returndtl.retdtlsysid = Function.GetGUID();
                         returndtl.retsysid = inpreturn.retsysid;
                         returndtl.customerid = inpreturn.customerid;
                         returndtl.custorderno = row.Cells["custorderno"].Value.ToString();
                         returndtl.styleno = row.Cells["styleno"].Value.ToString();
                         returndtl.color = row.Cells["color"].Value.ToString();
                         returndtl.size = row.Cells["size"].Value.ToString();
                         returndtl.checktype = row.Cells["checktype"].Value.ToString();
                         returndtl.pairqty = Convert.ToInt16(row.Cells["returnqty"].Value);
                         lstreturndtl.Add(returndtl);
                     }
                 }

                 if (lstreturndtl.Count == 0 && UpdateMode == Public_UpdateMode.Insert)
                 {
                     throw new Exception(UtilCulture.GetString("Msg.R01018"));
                 }
                 
                 client.DoReturn(baseForm.CurrentContextInfo,inpreturn,lstreturndtl.ToArray<tinpreturndtl>());
                 baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));
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
        private void GetBadWip(string customerid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "customerid",
                    ParamValue = customerid,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "status",
                    ParamValue = MES_WIPStatus.BAD.ToString(),
                    ParamType = "string"
                });
                DataTable dt = client.GetWipRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).Tables[0];
                if (dt != null)
                {
                    dt.Columns.Add(new DataColumn("ck", typeof(string)));
                    dt.Columns.Add(new DataColumn("returnqty", typeof(int)));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["ck"] = MES_Misc.N.ToString();
                        row["returnqty"] = 0;
                    }

                    if (UpdateMode == Public_UpdateMode.Update)
                    {
                        foreach (DataRow dtlRow in returndtlDt.Rows)
                        {
                            var q = from p in dt.AsEnumerable()
                                    where p["custorderno"].ToString() == dtlRow["custorderno"].ToString()
                                    && p["styleno"].ToString() == dtlRow["styleno"].ToString()
                                    && p["color"].ToString() == dtlRow["color"].ToString()
                                    && p["size"].ToString() == dtlRow["size"].ToString()
                                    && p["checktype"].ToString() == dtlRow["checktype"].ToString()
                                    select p;
                            if (q.Count() > 0)
                            {
                                DataRow row = q.ElementAt(0);
                                row["ck"] = MES_Misc.Y.ToString();
                                row["pairqty"] = Convert.ToDecimal(row["pairqty"]) +  Convert.ToDecimal(dtlRow["pairqty"]);
                                row["returnqty"] = dtlRow["pairqty"];
                            }
                            else
                            {
                                DataRow row = dt.Rows.Add();
                                row["ck"] = MES_Misc.Y.ToString();
                                row["custorderno"] = dtlRow["custorderno"];
                                row["styleno"] = dtlRow["styleno"];
                                row["color"] = dtlRow["color"];
                                row["size"] = dtlRow["size"];
                                row["checktype"] = dtlRow["checktype"];
                                row["pairqty"] =dtlRow["pairqty"];
                                row["returnqty"] = dtlRow["pairqty"];
                            }
                        }
                    }

                    

                    this.grdDetail.SetDataBinding(dt, "");
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

        private tinpreturn GetSingleReturn(string retsysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            tinpreturn ret = null;
            try
            {
                baseForm.SetCursor();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "retsysid",
                    ParamValue = retsysid,
                    ParamType = "string"
                });
                ret = client.GetSingleReturn(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
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
            return ret;
        }

        private DataSet GetReturnDtl(string retsysid)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataSet ds = null;
            try
            {
                baseForm.SetCursor();

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "retsysid",
                    ParamValue = retsysid,
                    ParamType = "string"
                });
                ds = client.GetReturnDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

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
        #endregion

        
    }
}

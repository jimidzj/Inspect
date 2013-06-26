using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;
using Infragistics.Win.UltraWinGrid;

namespace GENLSYS.MES.Win.MDL.Customer
{
    public partial class frmCustomerEdit : Form
    {
        public string CustomerId { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode { get; set; }

        #region Construct
        public frmCustomerEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdContact, new string[] { "customerid", "contactname", "sex", "title", 
                "telphone", "mobileno", "faxno", "email", "isdefault", "remark","lastmodifiedtime","lastmodifieduser" });
        }
        #endregion

        #region Event
        private void frmCustomerEdit_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdContact);

            if (CustomerId != null)
            {
                UpdateMode = Public_UpdateMode.Update;
            }
            else
            {
                UpdateMode = Public_UpdateMode.Insert;
            }
            SetLayout();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                tmdlcustomer customer = GetSingleCustomer(CustomerId);
                baseForm.OriginalObject = customer;
                baseForm.ShowSingleObjectToUI<tmdlcustomer>(customer, this);

                GetContactList(new List<MESParameterInfo>() { 
                    new MESParameterInfo(){ParamName="customerid",ParamValue=customer.customerid }
                });
            }
            else
            {
                GetContactList(new List<MESParameterInfo>() { 
                    new MESParameterInfo(){ParamName="customerid",ParamValue=MES_DummyData.Dummy_Data_XXX_111.ToString() }
                });
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void grdContact_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdContact.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.grdContact.DisplayLayout.Override.CellClickAction = CellClickAction.Edit;

            //set sex
            if (!this.grdContact.DisplayLayout.ValueLists.Exists("vlsex"))
            {
                this.grdContact.DisplayLayout.ValueLists.Add("vlsex");
                this.grdContact.DisplayLayout.ValueLists["vlsex"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.Sex));
                this.grdContact.DisplayLayout.Bands[0].Columns["sex"].CellActivation = Activation.AllowEdit;
                this.grdContact.DisplayLayout.Bands[0].Columns["sex"].CellClickAction = CellClickAction.Edit;
                this.grdContact.DisplayLayout.Bands[0].Columns["sex"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdContact.DisplayLayout.Bands[0].Columns["sex"].ValueList = this.grdContact.DisplayLayout.ValueLists["vlsex"];
            }

            //set title
            if (!this.grdContact.DisplayLayout.ValueLists.Exists("vltitle"))
            {
                this.grdContact.DisplayLayout.ValueLists.Add("vltitle");
                this.grdContact.DisplayLayout.ValueLists["vltitle"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.Title));
                this.grdContact.DisplayLayout.Bands[0].Columns["title"].CellActivation = Activation.AllowEdit;
                this.grdContact.DisplayLayout.Bands[0].Columns["title"].CellClickAction = CellClickAction.Edit;
                this.grdContact.DisplayLayout.Bands[0].Columns["title"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdContact.DisplayLayout.Bands[0].Columns["title"].ValueList = this.grdContact.DisplayLayout.ValueLists["vltitle"];
            }

            //set isdefault
            if (!this.grdContact.DisplayLayout.ValueLists.Exists("vlisdefault"))
            {
                this.grdContact.DisplayLayout.ValueLists.Add("vlisdefault");
                this.grdContact.DisplayLayout.ValueLists["vlisdefault"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.IsDefault));
                this.grdContact.DisplayLayout.Bands[0].Columns["isdefault"].CellActivation = Activation.AllowEdit;
                this.grdContact.DisplayLayout.Bands[0].Columns["isdefault"].CellClickAction = CellClickAction.Edit;
                this.grdContact.DisplayLayout.Bands[0].Columns["isdefault"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdContact.DisplayLayout.Bands[0].Columns["isdefault"].ValueList = this.grdContact.DisplayLayout.ValueLists["vlisdefault"];
            }

            //others
            this.grdContact.DisplayLayout.Bands[0].Columns["contactname"].CellActivation = Activation.AllowEdit;

            this.grdContact.DisplayLayout.Bands[0].Columns["telphone"].CellActivation = Activation.AllowEdit;
            this.grdContact.DisplayLayout.Bands[0].Columns["mobileno"].CellActivation = Activation.AllowEdit;
            this.grdContact.DisplayLayout.Bands[0].Columns["faxno"].CellActivation = Activation.AllowEdit;
            this.grdContact.DisplayLayout.Bands[0].Columns["email"].CellActivation = Activation.AllowEdit;
            this.grdContact.DisplayLayout.Bands[0].Columns["remark"].CellActivation = Activation.AllowEdit;
            this.grdContact.DisplayLayout.Bands[0].Columns["remark"].Width = 110;

            this.grdContact.DisplayLayout.Bands[0].Columns["lastmodifiedtime"].Width = 110;

            //hide
            this.grdContact.DisplayLayout.Bands[0].Columns["customerid"].Hidden = true;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            InsertContact();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }
        #endregion

        #region Method
        private void SetLayout()
        {
            SetCombobox();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                this.txtCustomerId.Enabled = false;
            }
        }

        private void SetCombobox()
        {
            DropDown.InitCMB_StaticValue(this.cmbInvoiceType, MES_StaticValue_Type.InvoiceType);
            DropDown.InitCMB_StaticValue(this.cmbTaxType, MES_StaticValue_Type.TaxType);
            DropDown.InitCMB_StaticValue(this.cmbCustomerType, MES_StaticValue_Type.CustomerType);
            DropDown.InitCMB_StaticValue(this.cmbCurrency, MES_StaticValue_Type.Currency);

        }

        private tmdlcustomer GetSingleCustomer(string _customerId)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            tmdlcustomer result = null;
            try
            {
                baseForm.SetCursor();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "customerid",
                    ParamValue = _customerId,
                    ParamType = "string"
                });
                result = client.GetSingleCustomer(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
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
            return result;
        }


        private void DoSave()
        {
            try
            {
                baseForm.SetCursor();
                baseForm.ValidateData(this);

                tmdlcustomer customer = new tmdlcustomer();
                if (UpdateMode == Public_UpdateMode.Update)
                {
                    customer = baseForm.OriginalObject as tmdlcustomer;
                }
                baseForm.CreateSingleObject<tmdlcustomer>(customer, this, UpdateMode);

                List<tmdlcontact> lstContact = new List<tmdlcontact>();

                for (int i = 0; i < this.grdContact.Rows.Count; i++)
                {
                    tmdlcontact contact = new tmdlcontact();
                    contact.contactname = this.grdContact.Rows[i].Cells["contactname"].Value.ToString();
                    contact.customerid = this.grdContact.Rows[i].Cells["customerid"].Value.ToString();
                    contact.email = this.grdContact.Rows[i].Cells["email"].Value.ToString();
                    contact.faxno = this.grdContact.Rows[i].Cells["faxno"].Value.ToString();
                    contact.isdefault = this.grdContact.Rows[i].Cells["isdefault"].Value.ToString();
                    contact.mobileno = this.grdContact.Rows[i].Cells["mobileno"].Value.ToString();
                    contact.remark = this.grdContact.Rows[i].Cells["remark"].Value.ToString();
                    contact.telphone = this.grdContact.Rows[i].Cells["telphone"].Value.ToString();
                    contact.title = this.grdContact.Rows[i].Cells["title"].Value.ToString();
                    contact.sex = this.grdContact.Rows[i].Cells["sex"].Value.ToString();

                    baseForm.PrepareObject<tmdlcontact>(contact, Public_UpdateMode.Insert);

                    lstContact.Add(contact);
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    InsertCustomer(customer, lstContact);
                }
                else
                {
                    UpdateCustomer(customer, lstContact);
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                else if (UpdateMode == Public_UpdateMode.Update)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));

                this.Dispose();
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
            finally
            {
                baseForm.ResetCursor();
            }
        }


        private void InsertCustomer(tmdlcustomer _customer, List<tmdlcontact> lstContact)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                client.DoInsertCustomer(baseForm.CurrentContextInfo, _customer, lstContact.ToArray());
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

        private void UpdateCustomer(tmdlcustomer _customer, List<tmdlcontact> lstContact)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                client.DoUpdateCustomer(baseForm.CurrentContextInfo, _customer, lstContact.ToArray());
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

        private void GetContactList(List<MESParameterInfo> lstParameters)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetContactRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                this.grdContact.SetDataBinding(ds.Tables[0], "");
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

        private void InsertContact()
        {
            DataTable dt = this.grdContact.DataSource as DataTable;
            DataRow row = dt.NewRow();
            //customerid,contactname,sex,title,telphone,mobileno,faxno,email,
            //isdefault,remark,lastmodifieduser,lastmodifiedtime
            row.ItemArray = new object[] {
                string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
                string.Empty,string.Empty,string.Empty, MES_Misc.N.ToString(),string.Empty,
                null,null
            };
            dt.Rows.Add(row);
        }

        private void DeleteContact()
        {
            if (this.grdContact.Selected.Rows.Count < 1) return;

            for (int i = this.grdContact.Selected.Rows.Count - 1; i >= 0; i--)
            {
                this.grdContact.Rows[this.grdContact.Selected.Rows[i].Index].Delete(false);
            }
        }
        #endregion

    }
}

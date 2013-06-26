using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Win.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.Common;
using Infragistics.Win.UltraWinGrid;

namespace GENLSYS.MES.Win.MDL.Customer
{
    public partial class frmCustomerList : Form
    {
        public List<MESParameterInfo> QueryParameters { get; set; }
        private BaseForm baseForm;

        #region Construct
        public frmCustomerList()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.gridCustomerList, new string[] { "CUSTOMERID","CUSTOMERNAME","SHORT_NAME",
                                                                                   "MANAGER","ADDRESS","SHIPTOADDRESS",
                                                                                   "INVOICETOADDRESS","INVOICETITLE","INVOICETYPE","PAYMENTCONDITION",
                                                                                   "TAXTYPE","CURRENCY",
                                                                                    "CUSTOMERTYPE","COMMENT1",
                                                                                   "COMMENT2","COMMENT3","LASTMODIFIEDUSER",
                                                                                   "LASTMODIFIEDTIME" });
        }
        #endregion

        #region Event
        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.gridCustomerList);

            this.gridCustomerList.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

            QueryParameters = new List<MESParameterInfo>();
            ShowCustomerList();
        }

        private void ucToolbarCustomerList_NewEventHandler(object sender, EventArgs e)
        {
            NewCustomer();
        }

        private void ucToolbarCustomerList_DeleteEventHandler(object sender, EventArgs e)
        {
            DeleteCustomer();
        }

        private void ucToolbarCustomerList_EditEventHandler(object sender, EventArgs e)
        {
            UpdateCustomer();
        }

        private void ucToolbarCustomerList_QueryEventHandler(object sender, EventArgs e)
        {
            QueryCustomer();
        }

        private void ucToolbarCustomerList_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.gridCustomerList);
        }

        private void ucToolbarCustomerList_ExitEventHandler(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void gridCustomerList_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.gridCustomerList.ActiveRow!=null)
            {
                this.ucToolbarCustomerList.SetToolbarWithSelection();
            }
            else
            {
                this.ucToolbarCustomerList.SetToolbarWithoutSelection();
            }
        }
        private void gridCustomerList_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["MANAGER"].Hidden = true;
            e.Layout.Bands[0].Columns["SHIPTOADDRESS"].Hidden = true;
        }
        #endregion

        #region Method
        public void ShowCustomerList()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                baseForm.SetCursor();
                DataSet ds = client.GetCustomerRecords(baseForm.CurrentContextInfo, QueryParameters.ToArray<MESParameterInfo>());
                this.gridCustomerList.SetDataBinding(ds.Tables[0],"");
                if (ds.Tables[0].Rows.Count < 1)
                {
                    this.ucToolbarCustomerList.SetToolbarWithoutRows();
                }
                else
                {
                    this.ucToolbarCustomerList.SetToolbarWithRows();
                }
                this.ucStatusBarCustomerList.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + ds.Tables[0].Rows.Count.ToString());
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

        private void UpdateCustomer()
        {
            if (this.gridCustomerList.ActiveRow!=null)
            {
                frmCustomerEdit frm = new frmCustomerEdit();
                frm.CustomerId = this.gridCustomerList.ActiveRow.Cells["CUSTOMERID"].Value.ToString();
                frm.ShowDialog(this);
                ShowCustomerList();
            }
        }

        private void NewCustomer()
        {
            frmCustomerEdit frm = new frmCustomerEdit();
            frm.ShowDialog(this);
            ShowCustomerList();
        }

        private void DeleteCustomer()
        {
            if (this.gridCustomerList.ActiveRow != null)
            {
                Dictionary<string, object> dir = new Dictionary<string, object>();
                dir.Add(UtilCulture.GetString("Label.R00042"), this.gridCustomerList.ActiveRow.Cells["CUSTOMERID"].Value.ToString());
                //DialogResult result = MessageBox.Show(UtilCulture.GetString("Msg.R00004"), UtilCulture.GetString("Msg.R00005"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                MessageBoxButtons.OKCancel,
                                                                UtilCulture.GetString("Msg.R00004"),
                                                                dir);
                if (result == DialogResult.OK)
                {
                    baseForm.SetCursor();
                    wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
                    try
                    {
                        List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                        lstParameters.Add(new MESParameterInfo()
                        {
                            ParamName = "customerid",
                            ParamValue = this.gridCustomerList.ActiveRow.Cells["CUSTOMERID"].Value.ToString(),
                            ParamType = "string"
                        });
                        client.DoDeleteCustomer(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                        ShowCustomerList();
                        baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00003"));
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
            }
        }

        private void QueryCustomer()
        {
            frmCustomerQuery frm = new frmCustomerQuery();
            frm.QueryParameters = QueryParameters;
            frm.ShowDialog(this);
            QueryParameters = frm.QueryParameters;
            ShowCustomerList();
        }
        #endregion

        

       
    }
}

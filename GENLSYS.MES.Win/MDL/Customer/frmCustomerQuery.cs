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
using GENLSYS.MES.Common;
using GENLSYS.MES.Win.Common.Classes;

namespace GENLSYS.MES.Win.MDL.Customer
{
    public partial class frmCustomerQuery : Form
    {
        public List<MESParameterInfo> QueryParameters { get; set; }
        private BaseForm baseForm;

        public frmCustomerQuery()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }

        private void frmCustomerQuery_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);

            DropDown.InitCMB_StaticValue(this.cmbInvoiceType, MES_StaticValue_Type.InvoiceType);
            DropDown.InitCMB_StaticValue(this.cmbTaxType, MES_StaticValue_Type.TaxType);
            DropDown.InitCMB_StaticValue(this.cmbCustomerType, MES_StaticValue_Type.CustomerType);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryParameters = new List<MESParameterInfo>();
            baseForm.BuildQueryParameters(QueryParameters, this); ;
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

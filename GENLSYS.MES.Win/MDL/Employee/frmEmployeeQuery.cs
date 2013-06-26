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

namespace GENLSYS.MES.Win.MDL.Employee
{
    public partial class frmEmployeeQuery : Form
    {
        public List<MESParameterInfo> QueryParameters { get; set; }
        private BaseForm baseForm;

        public frmEmployeeQuery()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }

        private void frmEmployeeQuery_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);

            DropDown.InitCMB_StaticValue(this.cmbEmployeeType, MES_StaticValue_Type.EmployeeType);
            DropDown.InitCMB_Enums(this.cmbEmployeeFlag, typeof(MES_Flag));
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

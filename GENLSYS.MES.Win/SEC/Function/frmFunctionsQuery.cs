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

namespace GENLSYS.MES.Win.SEC.Function
{
    public partial class frmFunctionsQuery : Form
    {
        public List<MESParameterInfo> QueryParameters { get; set; }
        private BaseForm baseForm;

        public frmFunctionsQuery()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }

        private void frmFunctionsQuery_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            DropDown.InitCMB_Enums(this.cmbFuncType,typeof(MES_FuncType));
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

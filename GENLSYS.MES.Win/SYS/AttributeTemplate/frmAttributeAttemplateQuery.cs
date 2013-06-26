using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Win.SYS.AttributeTemplate
{
    public partial class frmAttributeAttemplateQuery : Form
    {
        public List<MESParameterInfo> Parameters;
        private BaseForm baseForm;
        public bool IsCancel;

        #region Construct
        public frmAttributeAttemplateQuery()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events
        private void btnQuery_Click(object sender, EventArgs e)
        {
            Parameters = new List<MESParameterInfo>();
            baseForm.BuildQueryParameters(Parameters, this);
            IsCancel = false;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DoExit();
        }

        private void cmbUsedBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Methods
        private void frmAttributeAttemplateQuery_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            SetLayout();
        }

        private void SetLayout()
        {
            DropDown.InitCMB_StaticValue(this.cmbUsedBy, MES_StaticValue_Type.AttributeTemplateUsedBy);
        }

        public void DoExit()
        {
            IsCancel = true;
            this.Hide();
        }
        #endregion
    }
}

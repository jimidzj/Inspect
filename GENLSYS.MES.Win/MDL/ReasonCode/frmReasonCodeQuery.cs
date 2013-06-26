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

namespace GENLSYS.MES.Win.MDL.ReasonCode
{
    public partial class frmReasonCodeQuery : Form
    {
        public List<MESParameterInfo> Parameters;
        private BaseForm baseForm;
        public bool IsCancel;

        #region Construct
        public frmReasonCodeQuery()
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

        private void frmReasonCodeQuery_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            SetLayout();
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            DropDown.InitCMB_ReasonCategory_All(this.cmbReasonCategory);
        }

        public void DoExit()
        {
            IsCancel = true;
            this.Hide();
        }
        #endregion
    }
}

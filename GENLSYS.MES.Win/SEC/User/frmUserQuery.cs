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

namespace GENLSYS.MES.Win.SEC.User
{
    public partial class frmUserQuery : Form
    {
        public List<MESParameterInfo> Parameters;
        private BaseForm baseForm;
        public bool IsCancel;

        #region Construct
        public frmUserQuery()
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

        private void frmUserQuery_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            SetLayout();
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            DropDown.InitCMB_Enums(this.cmbUserStatus, typeof(Security_UserStatus));
            DropDown.InitCMB_StaticValue(this.cmbUserType, MES_StaticValue_Type.SecurityUserType);
            DropDown.InitCMB_Employee_Valid(this.cmbEmployeeId);
        }

        public void DoExit()
        {
            IsCancel = true;
            this.Hide();
        }
        #endregion
    }
}

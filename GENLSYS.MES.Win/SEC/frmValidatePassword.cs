using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.SEC
{
    public partial class frmValidatePassword : Form
    {
        private BaseForm baseForm;
        public bool ValidateSuccess = false;

        #region Construct
        public frmValidatePassword()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events
        private void frmValidatePassword_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this, false);
            SetLayout();

            this.txtUserId.Text = GENLSYS.MES.Common.Function.GetCurrentUser();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DoValidate();
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();
        }

        private void SetCombobox()
        {
        }

        private void DoValidate()
        {
            this.Cursor = Cursors.Default;
            baseForm.ValidateData(this);

            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();

            try
            {
                baseForm.SetCursor();
                client.ValidatePassword(baseForm.CurrentContextInfo, txtUserId.Text, UtilSecurity.EncryptPassword(txtPassword.Text));
                ValidateSuccess = true;
                this.Close();
            }
            catch (Exception ex)
            {
                switch (ExceptionParser.Parse(ex))
                {
                    case "-300001":
                        baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00011"));
                        break;
                    case "-300002":
                        baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00012"));
                        break;
                    case "-300003":
                        baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00013"));
                        break;
                    case "-300004":
                        baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00014"));
                        break;
                    case "-300005":
                        baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00046"));
                        break;
                    default:
                        baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, ExceptionParser.Parse(ex));
                        break;
                }
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
        }
        #endregion
    }
}

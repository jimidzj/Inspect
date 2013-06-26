using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Common;
using GENLSYS.MES.Win.Common.Classes;

namespace GENLSYS.MES.Win.SEC
{
    public partial class frmChangePassword : Form
    {
        private BaseForm baseForm;

        #region Construct
        public frmChangePassword()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events
        private void btnOK_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            SetLayout();
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

        public void ChangePassword()
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();

            try
            {
                baseForm.ValidateData(this);

                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MESMsgBox.ShowError(UtilCulture.GetString("Msg.R00015"));
                    return;
                }

                client.ChangePassword(baseForm.CurrentContextInfo, Parameter.LOGON_USER,
                    UtilSecurity.EncryptPassword(txtOldPassword.Text),
                    UtilSecurity.EncryptPassword(txtNewPassword.Text));

                MESMsgBox.ShowInformation(UtilCulture.GetString("Msg.R00016"));
                this.Close();
            }
            catch (Exception ex)
            {
                switch (ExceptionParser.Parse(ex))
                {
                    case "-300001":
                        MESMsgBox.ShowError(UtilCulture.GetString("Msg.R00011"));
                        break;
                    case "-300002":
                        MESMsgBox.ShowError(UtilCulture.GetString("Msg.R00012"));
                        break;
                    case "-300003":
                        MESMsgBox.ShowError(UtilCulture.GetString("Msg.R00013"));
                        break;
                    case "-300004":
                        MESMsgBox.ShowError(UtilCulture.GetString("Msg.R00014"));
                        break;
                    default:
                        MESMsgBox.ShowError(ExceptionParser.Parse(ex));
                        break;
                }
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
        }
        #endregion
    }
}

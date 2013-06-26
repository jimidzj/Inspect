using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.WinPAD.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Common;
using System.Net;
using GENLSYS.MES.DataContracts.Common;
using Infragistics.Win.UltraMessageBox;
using Infragistics.Win;
using GENLSYS.MES.WinPAD.Common.Classes;
using GENLSYS.MES.WinPAD.Common.Forms;
using GENLSYS.MES.DataContracts;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace GENLSYS.MES.WinPAD.SEC
{
    public partial class frmLineCheck : Form
    {
        private BaseForm baseForm;
        private int errorCount = 0;
     
        #region Construct
        public frmLineCheck(      )
        { 
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events


        private void frmLineCheck_Load(object sender, EventArgs e)
        {
            try
            {
                baseForm.SetFace(this, false);
                cmbUser.Height = 40;
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
            finally
            {
            }
        }
     

        private void cmbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;

            }
        }


        private void cmbUser_Enter(object sender, EventArgs e)
        {
             vkForm.showKeyboard();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
           vkForm.showKeyboard();
        }
      
        #endregion

        #region Methods
        

       
          public void ClearPassword()
        {
            this.txtPassword.Text = string.Empty;
        }
        #endregion

          private void btnOK_Click(object sender, EventArgs e)
          {
              bool res = ValidateLineAdmin();
              if (res)
              {
                  this.DialogResult = DialogResult.OK;
              }
              else
              {
                  this.DialogResult = DialogResult.Cancel;
              }

              this.Dispose();
          }


          private bool ValidateLineAdmin()
          {
              wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
              wsMDL.IwsMDLClient clientMDL = new wsMDL.IwsMDLClient();

              try
              {
               bool res = false;   
               res = client.ValidateLineAdmin(baseForm.CurrentContextInfo, this.cmbUser.Text, UtilSecurity.EncryptPassword(txtPassword.Text));
               return res;
              }
              catch (Exception ex)
              {
                  switch (ExceptionParser.Parse(ex))
                  {
                      case "-300001":
                          errorCount++;
                          baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00011"));
                          break;
                      case "-300002":
                          errorCount++;
                          baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00012"));
                          break;
                      case "-300003":
                          errorCount++;
                          baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00013"));
                          break;
                      case "-300004":
                          errorCount++;
                          baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00014"));
                          break;
                      case "-300005":
                          errorCount++;
                          baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("没有权限"));
                          break;
                      default:
                          baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, ExceptionParser.Parse(ex));
                          break;
                  }


                  if (errorCount >= 5)
                  {
                      baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00122"));
                      this.Dispose();
                  }
                  this.DialogResult = DialogResult.Cancel;
                  return false;
              }
              finally
              {
                  baseForm.ResetCursor();
                  if (client.State == System.ServiceModel.CommunicationState.Opened)
                      baseForm.CloseWCF(client);
              }
          }

          private void btnCancel_Click(object sender, EventArgs e)
          {
              this.DialogResult = DialogResult.Cancel;
              this.Dispose();
     
          }

             

    }
}

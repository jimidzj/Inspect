using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;

namespace GENLSYS.MES.Win.Common.Forms
{
    public partial class frmMessage : Form
    {
        public DialogResult ReturnDialogResult = DialogResult.Cancel;
        private DialogResult drBtn1 = DialogResult.OK;
        private DialogResult drBtn2 = DialogResult.Cancel;
        private DialogResult drBtn3 = DialogResult.Cancel;
        private BaseForm baseForm = null;

        public frmMessage()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ReturnDialogResult = drBtn2;
            this.Close();
        }

        public void ShowInformation(string message)
        {
            this.Text = UtilCulture.GetString("Label.R00905");
            this.lblMsg.Text = UtilCulture.GetString("Label.R00905");

            this.txtMessage.Text = message;
            this.txtMessage.ForeColor = System.Drawing.Color.Blue;

            SetFace(Public_MessageBox.Information, MessageBoxButtons.OK);
        }

        public void ShowInformation(string message,string title)
        {
            this.Text = UtilCulture.GetString("Label.R00905");
            this.lblMsg.Text = title;

            this.txtMessage.Text = message;
            this.txtMessage.ForeColor = System.Drawing.Color.Blue;

            SetFace(Public_MessageBox.Information, MessageBoxButtons.OK);
        }

        public void ShowError(string message)
        {
            this.Text = UtilCulture.GetString("Label.R00906");
            this.lblMsg.Text = UtilCulture.GetString("Label.R00906");

            this.txtMessage.Text = message;
            this.txtMessage.ForeColor = System.Drawing.Color.Red;

            SetFace(Public_MessageBox.Error, MessageBoxButtons.OK);
        }

        public void ShowError(string message, string title)
        {
            this.Text = UtilCulture.GetString("Label.R00906");
            this.lblMsg.Text = title;

            this.txtMessage.Text = message;
            this.txtMessage.ForeColor = System.Drawing.Color.Red;

            SetFace(Public_MessageBox.Error, MessageBoxButtons.OK);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ReturnDialogResult = drBtn1;

            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            ReturnDialogResult = drBtn3;

            this.Close();
        }

        public void ShowMessage(string msgHeader, string msgContext, 
            Public_MessageBox msgBox, MessageBoxButtons msgButtons)
        {
            this.lblMsg.Text = msgHeader;
            this.txtMessage.Text = msgContext;

            SetFace(msgBox, msgButtons);
        }

        private void SetFace(Public_MessageBox msgBox, MessageBoxButtons msgButtons)
        {
            ControlButton(msgButtons);

            if (msgBox == Public_MessageBox.Information)
            {
                this.txtMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                this.txtMessage.ForeColor = System.Drawing.Color.Red;
            }

            if (msgBox == Public_MessageBox.Error)
            {
                this.Text = UtilCulture.GetString("Label.R00906");
            }
            else if (msgBox == Public_MessageBox.Information)
            {
                this.Text = UtilCulture.GetString("Label.R00905");
            }
            else if (msgBox == Public_MessageBox.Warning)
            {
                this.Text = UtilCulture.GetString("Label.R00908");
            }
            else if (msgBox == Public_MessageBox.Question)
            {
                this.Text = UtilCulture.GetString("Label.R00907");
            }
            else if (msgBox == Public_MessageBox.Exclamation)
            {
                this.Text = UtilCulture.GetString("Label.R00909");
            }
        }

        private void ControlButton(MessageBoxButtons msgButtons)
        {
            if (msgButtons == MessageBoxButtons.OK)
            {
                this.btn1.Text = UtilCulture.GetString("Button.R00011");
                this.btn1.Visible = true;
                this.btn2.Visible = false;

                drBtn1 = DialogResult.OK;

                CenterButton(this.btn1);
            }

            if (msgButtons == MessageBoxButtons.OKCancel)
            {
                this.btn1.Text = UtilCulture.GetString("Button.R00011");
                this.btn2.Text = UtilCulture.GetString("Button.R00002");
                this.btn1.Visible = true;
                this.btn2.Visible = true;

                drBtn1 = DialogResult.OK;
                drBtn2 = DialogResult.Cancel;
            }

            if (msgButtons == MessageBoxButtons.YesNo)
            {
                this.btn1.Text = UtilCulture.GetString("Button.R00034");
                this.btn2.Text = UtilCulture.GetString("Button.R00035");
                this.btn1.Visible = true;
                this.btn2.Visible = true;

                drBtn1 = DialogResult.Yes;
                drBtn2 = DialogResult.No;
            }
            if (msgButtons == MessageBoxButtons.YesNoCancel)
            {
                this.btn1.Text = UtilCulture.GetString("Button.R00034");
                this.btn2.Text = UtilCulture.GetString("Button.R00035");
                this.btn3.Text = UtilCulture.GetString("Button.R00002");
                this.btn1.Visible = true;
                this.btn2.Visible = true;
                btn3.Visible = true;

                drBtn1 = DialogResult.Yes;
                drBtn2 = DialogResult.No;
                drBtn3 = DialogResult.Cancel;
               
            }
        }

        private void CenterButton(Button btn)
        {
            btn.Left = 139;
            btn.Top = 178;
        }

        private void frmMessage_Load(object sender, EventArgs e)
        {
            //baseForm.SetFace(this);
        }
    }
}

namespace GENLSYS.MES.WinPAD.Common.Forms
{
    partial class frmMessage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessage));
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn3 = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(12, 19);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(63, 177);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 17;
            this.logoPictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.logoPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(83, 218);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn3);
            this.panel2.Controls.Add(this.lblMsg);
            this.panel2.Controls.Add(this.btn1);
            this.panel2.Controls.Add(this.btn2);
            this.panel2.Controls.Add(this.txtMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(83, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 218);
            this.panel2.TabIndex = 19;
            // 
            // btn3
            // 
            this.btn3.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.scrollup;
            this.btn3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn3.Location = new System.Drawing.Point(277, 178);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 23);
            this.btn3.TabIndex = 21;
            this.btn3.Text = "Cancle";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Visible = false;
            this.btn3.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Blue;
            this.lblMsg.Location = new System.Drawing.Point(11, 15);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(364, 19);
            this.lblMsg.TabIndex = 20;
            this.lblMsg.Text = "label1";
            // 
            // btn1
            // 
            this.btn1.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.ok;
            this.btn1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn1.Location = new System.Drawing.Point(115, 178);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 23);
            this.btn1.TabIndex = 17;
            this.btn1.Tag = "rsid:Button.R00011";
            this.btn1.Text = "OK";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btn2
            // 
            this.btn2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn2.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.exit;
            this.btn2.Location = new System.Drawing.Point(196, 178);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 23);
            this.btn2.TabIndex = 18;
            this.btn2.Tag = "rsid:Button.R00010";
            this.btn2.Text = "&Close";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.LightYellow;
            this.txtMessage.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(15, 37);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(360, 126);
            this.txtMessage.TabIndex = 19;
            this.txtMessage.Text = "Test";
            // 
            // frmMessage
            // 
            this.AcceptButton = this.btn1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn2;
            this.ClientSize = new System.Drawing.Size(476, 218);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "rsid:Label.R00831";
            this.Text = "frmMessage";
            this.Load += new System.EventHandler(this.frmMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btn3;
    }
}
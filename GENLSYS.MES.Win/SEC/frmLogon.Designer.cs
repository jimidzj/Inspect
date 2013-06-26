using System.Windows.Forms;
namespace GENLSYS.MES.Win.SEC
{
    partial class frmLogon
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

            Application.Exit();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.label4 = new System.Windows.Forms.Label();
            this.chkLogonToBasis = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.lblRevision = new System.Windows.Forms.Label();
            this.lblEnvironment = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(103, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 8;
            this.label4.Tag = "rsid:Label.R001651,isrq:N";
            this.label4.Text = "Shift:";
            // 
            // chkLogonToBasis
            // 
            this.chkLogonToBasis.AutoSize = true;
            this.chkLogonToBasis.Location = new System.Drawing.Point(191, 138);
            this.chkLogonToBasis.Name = "chkLogonToBasis";
            this.chkLogonToBasis.Size = new System.Drawing.Size(114, 16);
            this.chkLogonToBasis.TabIndex = 5;
            this.chkLogonToBasis.Tag = "rsid:Label.R00166";
            this.chkLogonToBasis.Text = "System Modeling";
            this.chkLogonToBasis.UseVisualStyleBackColor = true;
            this.chkLogonToBasis.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassword.Location = new System.Drawing.Point(191, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(204, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Tag = "rsid:Label.R00164";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Tag = "rsid:Label.R00165,isrq:N";
            this.label3.Text = "Language:";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(103, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1;
            this.label2.Tag = "rsid:Label.R00164,isrq:Y";
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(103, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Tag = "rsid:Label.R00131,isrq:Y";
            this.label1.Text = "User Id:";
            // 
            // ultraPanel1
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.Transparent;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.ImageBackground = global::GENLSYS.MES.Win.Properties.Resources.ImageBackground;
            this.ultraPanel1.Appearance = appearance1;
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.lblRevision);
            this.ultraPanel1.ClientArea.Controls.Add(this.lblEnvironment);
            this.ultraPanel1.ClientArea.Controls.Add(this.lblAppName);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(498, 78);
            this.ultraPanel1.TabIndex = 3;
            // 
            // lblRevision
            // 
            this.lblRevision.AutoSize = true;
            this.lblRevision.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevision.ForeColor = System.Drawing.Color.Blue;
            this.lblRevision.Location = new System.Drawing.Point(270, 50);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(76, 19);
            this.lblRevision.TabIndex = 5;
            this.lblRevision.Text = "Revision";
            // 
            // lblEnvironment
            // 
            this.lblEnvironment.AutoSize = true;
            this.lblEnvironment.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnvironment.ForeColor = System.Drawing.Color.Red;
            this.lblEnvironment.Location = new System.Drawing.Point(360, 50);
            this.lblEnvironment.Name = "lblEnvironment";
            this.lblEnvironment.Size = new System.Drawing.Size(107, 19);
            this.lblEnvironment.TabIndex = 4;
            this.lblEnvironment.Text = "Environment";
            this.lblEnvironment.Visible = false;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAppName.Location = new System.Drawing.Point(99, 9);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(259, 34);
            this.lblAppName.TabIndex = 3;
            this.lblAppName.Text = "Application Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.cmbLanguage);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 46);
            this.panel1.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Image = global::GENLSYS.MES.Win.Properties.Resources.ok1;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(171, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Tag = "rsid:Button.R00011";
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(200, 23);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(204, 20);
            this.cmbLanguage.TabIndex = 4;
            this.cmbLanguage.Tag = "rsid:Label.R001654,isrq:N";
            this.cmbLanguage.Visible = false;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(252, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbUser);
            this.panel2.Controls.Add(this.cmbShift);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.chkLogonToBasis);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 150);
            this.panel2.TabIndex = 5;
            // 
            // cmbUser
            // 
            this.cmbUser.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(191, 24);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(204, 24);
            this.cmbUser.TabIndex = 1;
            this.cmbUser.Tag = "rsid:Label.R00131";
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            this.cmbUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUser_KeyDown);
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(191, 101);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(204, 24);
            this.cmbShift.TabIndex = 3;
            this.cmbShift.Tag = "rsid:Label.R001654,isrq:N";
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmLogon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 274);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ultraPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "rsid:Label.R00161";
            this.Text = "Logon";
            this.Activated += new System.EventHandler(this.frmLogon_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogon_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogon_FormClosed);
            this.Load += new System.EventHandler(this.frmLogon_Load);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ClientArea.PerformLayout();
            this.ultraPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkLogonToBasis;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.ComboBox cmbUser;
        private Label lblEnvironment;
        private Label lblRevision;
    }
}
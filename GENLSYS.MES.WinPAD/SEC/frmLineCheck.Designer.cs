using System.Windows.Forms;
namespace GENLSYS.MES.WinPAD.SEC
{
    partial class frmLineCheck
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.AllowDrop = true;
            this.panel3.Controls.Add(this.ultraPanel1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(541, 299);
            this.panel3.TabIndex = 10;
            // 
            // ultraPanel1
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.Transparent;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.ImageBackground = global::GENLSYS.MES.WinPAD.Properties.Resources.ImageBackground;
            this.ultraPanel1.Appearance = appearance1;
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.lblAppName);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(541, 105);
            this.ultraPanel1.TabIndex = 14;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAppName.Location = new System.Drawing.Point(34, 11);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(325, 34);
            this.lblAppName.TabIndex = 3;
            this.lblAppName.Text = "请输入用户名和密码：";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmbUser);
            this.panel4.Controls.Add(this.txtPassword);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(67, 111);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(415, 121);
            this.panel4.TabIndex = 12;
            // 
            // cmbUser
            // 
            this.cmbUser.Font = new System.Drawing.Font("SimSun", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(111, 8);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(204, 37);
            this.cmbUser.TabIndex = 10;
            this.cmbUser.Tag = "rsid:Label.R00131";
            this.cmbUser.Enter += new System.EventHandler(this.cmbUser_Enter);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("SimSun", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassword.Location = new System.Drawing.Point(111, 53);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(204, 41);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.Tag = "rsid:Label.R00164";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(-1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 9;
            this.label1.Tag = "rsid:Label.R00131,isrq:Y";
            this.label1.Text = "User Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(-1, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 11;
            this.label2.Tag = "rsid:Label.R00164,isrq:Y";
            this.label2.Text = "Password:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 245);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 54);
            this.panel1.TabIndex = 11;
            // 
            // btnOK
            // 
            this.btnOK.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.ok1;
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
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.exit;
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
            // frmLineCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 307);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLineCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "rsid:Label.R00161";
            this.Text = "Logon";
            this.Load += new System.EventHandler(this.frmLineCheck_Load);
            this.panel3.ResumeLayout(false);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ClientArea.PerformLayout();
            this.ultraPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel3;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Label lblAppName;
        private Panel panel4;
        private ComboBox cmbUser;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private Button btnOK;
        private Button btnCancel;
    }
}
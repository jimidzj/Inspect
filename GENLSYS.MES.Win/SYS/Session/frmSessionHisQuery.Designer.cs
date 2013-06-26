namespace GENLSYS.MES.Win.SYS.Session
{
    partial class frmSessionHisQuery
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblToLogonTime = new System.Windows.Forms.Label();
            this.dtToLogonTime = new System.Windows.Forms.DateTimePicker();
            this.dtFromLogonTime = new System.Windows.Forms.DateTimePicker();
            this.lblFromLogonTime = new System.Windows.Forms.Label();
            this.txtipaddress = new System.Windows.Forms.TextBox();
            this.lblipaddress = new System.Windows.Forms.Label();
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.lblMachine = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(183, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::GENLSYS.MES.Win.Properties.Resources.query;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(95, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 21);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Tag = "rsid:Button.R00003";
            this.btnQuery.Text = "&Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 34);
            this.panel1.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblToLogonTime);
            this.groupBox1.Controls.Add(this.dtToLogonTime);
            this.groupBox1.Controls.Add(this.dtFromLogonTime);
            this.groupBox1.Controls.Add(this.lblFromLogonTime);
            this.groupBox1.Controls.Add(this.txtipaddress);
            this.groupBox1.Controls.Add(this.lblipaddress);
            this.groupBox1.Controls.Add(this.txtMachine);
            this.groupBox1.Controls.Add(this.lblMachine);
            this.groupBox1.Controls.Add(this.cmbShift);
            this.groupBox1.Controls.Add(this.lblShift);
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Controls.Add(this.lblUserId);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 200);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // lblToLogonTime
            // 
            this.lblToLogonTime.AutoSize = true;
            this.lblToLogonTime.Location = new System.Drawing.Point(30, 158);
            this.lblToLogonTime.Name = "lblToLogonTime";
            this.lblToLogonTime.Size = new System.Drawing.Size(83, 12);
            this.lblToLogonTime.TabIndex = 83;
            this.lblToLogonTime.Tag = "rsid:Label.R00412";
            this.lblToLogonTime.Text = "To Logon Time";
            // 
            // dtToLogonTime
            // 
            this.dtToLogonTime.CustomFormat = "yyyy-MM-dd";
            this.dtToLogonTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToLogonTime.Location = new System.Drawing.Point(132, 152);
            this.dtToLogonTime.Name = "dtToLogonTime";
            this.dtToLogonTime.Size = new System.Drawing.Size(148, 21);
            this.dtToLogonTime.TabIndex = 82;
            this.dtToLogonTime.Tag = "rsid:Label.R00412,updt:Y,dbfd:tologontime";
            // 
            // dtFromLogonTime
            // 
            this.dtFromLogonTime.CustomFormat = "yyyy-MM-dd";
            this.dtFromLogonTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromLogonTime.Location = new System.Drawing.Point(132, 122);
            this.dtFromLogonTime.Name = "dtFromLogonTime";
            this.dtFromLogonTime.Size = new System.Drawing.Size(148, 21);
            this.dtFromLogonTime.TabIndex = 81;
            this.dtFromLogonTime.Tag = "rsid:Label.R00411,updt:Y,dbfd:fromlogontime";
            // 
            // lblFromLogonTime
            // 
            this.lblFromLogonTime.AutoSize = true;
            this.lblFromLogonTime.Location = new System.Drawing.Point(30, 128);
            this.lblFromLogonTime.Name = "lblFromLogonTime";
            this.lblFromLogonTime.Size = new System.Drawing.Size(95, 12);
            this.lblFromLogonTime.TabIndex = 80;
            this.lblFromLogonTime.Tag = "rsid:Label.R00411";
            this.lblFromLogonTime.Text = "From Logon Time";
            // 
            // txtipaddress
            // 
            this.txtipaddress.Location = new System.Drawing.Point(132, 68);
            this.txtipaddress.Name = "txtipaddress";
            this.txtipaddress.Size = new System.Drawing.Size(148, 21);
            this.txtipaddress.TabIndex = 41;
            this.txtipaddress.Tag = "rsid:Label.R00404,maxl:64,updt:Y,dbfd:ipaddress,dbty:string";
            // 
            // lblipaddress
            // 
            this.lblipaddress.AutoSize = true;
            this.lblipaddress.Location = new System.Drawing.Point(30, 71);
            this.lblipaddress.Name = "lblipaddress";
            this.lblipaddress.Size = new System.Drawing.Size(65, 12);
            this.lblipaddress.TabIndex = 40;
            this.lblipaddress.Tag = "rsid:Label.R00404";
            this.lblipaddress.Text = "IP Address";
            // 
            // txtMachine
            // 
            this.txtMachine.Location = new System.Drawing.Point(132, 42);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(148, 21);
            this.txtMachine.TabIndex = 39;
            this.txtMachine.Tag = "rsid:Label.R00402,maxl:64,updt:Y,dbfd:machine,dbty:string";
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Location = new System.Drawing.Point(30, 45);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(47, 12);
            this.lblMachine.TabIndex = 38;
            this.lblMachine.Tag = "rsid:Label.R00402";
            this.lblMachine.Text = "Machine";
            // 
            // cmbShift
            // 
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(132, 94);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(148, 20);
            this.cmbShift.TabIndex = 37;
            this.cmbShift.Tag = "rsid:Label.R00406,updt:Y,dbfd:shift,dbty:string";
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Location = new System.Drawing.Point(30, 96);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(35, 12);
            this.lblShift.TabIndex = 36;
            this.lblShift.Tag = "rsid:Label.R00406";
            this.lblShift.Text = "Shift";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(132, 15);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(148, 21);
            this.txtUserId.TabIndex = 33;
            this.txtUserId.Tag = "rsid:Label.R00401,maxl:64,updt:Y,dbfd:userid,dbty:string";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(30, 18);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(47, 12);
            this.lblUserId.TabIndex = 32;
            this.lblUserId.Tag = "rsid:Label.R00401";
            this.lblUserId.Text = "User Id";
            // 
            // frmSessionHisQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 234);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(369, 272);
            this.MinimumSize = new System.Drawing.Size(369, 272);
            this.Name = "frmSessionHisQuery";
            this.Tag = "rsid:Label.R00414";
            this.Text = "frmSessionHisQuery";
            this.Load += new System.EventHandler(this.frmSessionHisQuery_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblToLogonTime;
        private System.Windows.Forms.DateTimePicker dtToLogonTime;
        private System.Windows.Forms.DateTimePicker dtFromLogonTime;
        private System.Windows.Forms.Label lblFromLogonTime;
        private System.Windows.Forms.TextBox txtipaddress;
        private System.Windows.Forms.Label lblipaddress;
        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblUserId;
    }
}
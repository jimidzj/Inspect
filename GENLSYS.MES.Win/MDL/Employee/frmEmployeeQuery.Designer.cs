namespace GENLSYS.MES.Win.MDL.Employee
{
    partial class frmEmployeeQuery
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
            this.cmbEmployeeFlag = new System.Windows.Forms.ComboBox();
            this.lblEmployeeFlag = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.txtTelNo = new System.Windows.Forms.TextBox();
            this.lblTelNo = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbEmployeeType = new System.Windows.Forms.ComboBox();
            this.lblEmployeeType = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.txtEmployeeId = new System.Windows.Forms.TextBox();
            this.lblEmployeeId = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(185, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::GENLSYS.MES.Win.Properties.Resources.query;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(104, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 21);
            this.btnQuery.TabIndex = 3;
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
            this.panel1.Location = new System.Drawing.Point(0, 242);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 40);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEmployeeFlag);
            this.groupBox1.Controls.Add(this.lblEmployeeFlag);
            this.groupBox1.Controls.Add(this.txtMobileNo);
            this.groupBox1.Controls.Add(this.lblMobileNo);
            this.groupBox1.Controls.Add(this.txtTelNo);
            this.groupBox1.Controls.Add(this.lblTelNo);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.txtDepartment);
            this.groupBox1.Controls.Add(this.lblDepartment);
            this.groupBox1.Controls.Add(this.cmbEmployeeType);
            this.groupBox1.Controls.Add(this.lblEmployeeType);
            this.groupBox1.Controls.Add(this.txtEmployeeName);
            this.groupBox1.Controls.Add(this.lblEmployeeName);
            this.groupBox1.Controls.Add(this.txtEmployeeId);
            this.groupBox1.Controls.Add(this.lblEmployeeId);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 242);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // cmbEmployeeFlag
            // 
            this.cmbEmployeeFlag.FormattingEnabled = true;
            this.cmbEmployeeFlag.Location = new System.Drawing.Point(131, 205);
            this.cmbEmployeeFlag.Name = "cmbEmployeeFlag";
            this.cmbEmployeeFlag.Size = new System.Drawing.Size(189, 20);
            this.cmbEmployeeFlag.TabIndex = 31;
            this.cmbEmployeeFlag.Tag = "rsid:Label.R00029,dbfd:employeeflag,dbty:string";
            // 
            // lblEmployeeFlag
            // 
            this.lblEmployeeFlag.AutoSize = true;
            this.lblEmployeeFlag.Location = new System.Drawing.Point(20, 208);
            this.lblEmployeeFlag.Name = "lblEmployeeFlag";
            this.lblEmployeeFlag.Size = new System.Drawing.Size(83, 12);
            this.lblEmployeeFlag.TabIndex = 30;
            this.lblEmployeeFlag.Tag = "rsid:Label.R00029";
            this.lblEmployeeFlag.Text = "Employee Flag";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(131, 178);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(189, 21);
            this.txtMobileNo.TabIndex = 29;
            this.txtMobileNo.Tag = "rsid:Label.R00028,maxl:64,dbfd:mobileno,dbty:string";
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Location = new System.Drawing.Point(20, 181);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(59, 12);
            this.lblMobileNo.TabIndex = 28;
            this.lblMobileNo.Tag = "rsid:Label.R00028";
            this.lblMobileNo.Text = "Mobile No";
            // 
            // txtTelNo
            // 
            this.txtTelNo.Location = new System.Drawing.Point(131, 151);
            this.txtTelNo.Name = "txtTelNo";
            this.txtTelNo.Size = new System.Drawing.Size(189, 21);
            this.txtTelNo.TabIndex = 27;
            this.txtTelNo.Tag = "rsid:Label.R00027,maxl:64,dbfd:telno,dbty:string";
            // 
            // lblTelNo
            // 
            this.lblTelNo.AutoSize = true;
            this.lblTelNo.Location = new System.Drawing.Point(20, 154);
            this.lblTelNo.Name = "lblTelNo";
            this.lblTelNo.Size = new System.Drawing.Size(41, 12);
            this.lblTelNo.TabIndex = 26;
            this.lblTelNo.Tag = "rsid:Label.R00027";
            this.lblTelNo.Text = "Tel No";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(131, 124);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(189, 21);
            this.txtEmail.TabIndex = 25;
            this.txtEmail.Tag = "rsid:Label.R00026,maxl:64,dbfd:email,dbty:string";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 127);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 12);
            this.lblEmail.TabIndex = 24;
            this.lblEmail.Tag = "rsid:Label.R00026";
            this.lblEmail.Text = "Email";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(131, 97);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(189, 21);
            this.txtDepartment.TabIndex = 23;
            this.txtDepartment.Tag = "rsid:Label.R00025,maxl:64,dbfd:department,dbty:string";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(20, 100);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(65, 12);
            this.lblDepartment.TabIndex = 22;
            this.lblDepartment.Tag = "rsid:Label.R00025";
            this.lblDepartment.Text = "Department";
            // 
            // cmbEmployeeType
            // 
            this.cmbEmployeeType.FormattingEnabled = true;
            this.cmbEmployeeType.Location = new System.Drawing.Point(131, 71);
            this.cmbEmployeeType.Name = "cmbEmployeeType";
            this.cmbEmployeeType.Size = new System.Drawing.Size(189, 20);
            this.cmbEmployeeType.TabIndex = 21;
            this.cmbEmployeeType.Tag = "rsid:Label.R00024,dbfd:employeetype,dbty:string";
            // 
            // lblEmployeeType
            // 
            this.lblEmployeeType.AutoSize = true;
            this.lblEmployeeType.Location = new System.Drawing.Point(20, 74);
            this.lblEmployeeType.Name = "lblEmployeeType";
            this.lblEmployeeType.Size = new System.Drawing.Size(83, 12);
            this.lblEmployeeType.TabIndex = 20;
            this.lblEmployeeType.Tag = "rsid:Label.R00024";
            this.lblEmployeeType.Text = "Employee Type";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(131, 44);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(189, 21);
            this.txtEmployeeName.TabIndex = 19;
            this.txtEmployeeName.Tag = "rsid:Label.R00023,maxl:64,dbfd:employeename,dbty:string";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(20, 47);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(83, 12);
            this.lblEmployeeName.TabIndex = 18;
            this.lblEmployeeName.Tag = "rsid:Label.R00023";
            this.lblEmployeeName.Text = "Employee Name";
            // 
            // txtEmployeeId
            // 
            this.txtEmployeeId.Location = new System.Drawing.Point(131, 17);
            this.txtEmployeeId.Name = "txtEmployeeId";
            this.txtEmployeeId.Size = new System.Drawing.Size(189, 21);
            this.txtEmployeeId.TabIndex = 17;
            this.txtEmployeeId.Tag = "rsid:Label.R00022,maxl:64,dbfd:employeeid,dbty:string";
            // 
            // lblEmployeeId
            // 
            this.lblEmployeeId.AutoSize = true;
            this.lblEmployeeId.Location = new System.Drawing.Point(20, 20);
            this.lblEmployeeId.Name = "lblEmployeeId";
            this.lblEmployeeId.Size = new System.Drawing.Size(71, 12);
            this.lblEmployeeId.TabIndex = 16;
            this.lblEmployeeId.Tag = "rsid:Label.R00022";
            this.lblEmployeeId.Text = "Employee Id";
            // 
            // frmEmployeeQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 282);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 320);
            this.Name = "frmEmployeeQuery";
            this.ShowInTaskbar = false;
            this.Tag = "rsid:Label.R00030";
            this.Text = "frmEmployeeQuery";
            this.Load += new System.EventHandler(this.frmEmployeeQuery_Load);
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
        private System.Windows.Forms.ComboBox cmbEmployeeFlag;
        private System.Windows.Forms.Label lblEmployeeFlag;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.TextBox txtTelNo;
        private System.Windows.Forms.Label lblTelNo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbEmployeeType;
        private System.Windows.Forms.Label lblEmployeeType;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Label lblEmployeeId;
    }
}
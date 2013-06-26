namespace GENLSYS.MES.Win.MDL.Employee
{
    partial class frmEmployeeEdit
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
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControlEmployeeList = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.cboWorkGroup = new System.Windows.Forms.ComboBox();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.dtEffectDate = new System.Windows.Forms.DateTimePicker();
            this.lblEffectDate = new System.Windows.Forms.Label();
            this.dtProbAtionDate = new System.Windows.Forms.DateTimePicker();
            this.lblProbAtionDate = new System.Windows.Forms.Label();
            this.lblTrainer = new System.Windows.Forms.Label();
            this.lblDefaultShift = new System.Windows.Forms.Label();
            this.txtLastModifiedTime = new System.Windows.Forms.TextBox();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.lblLastModifiedTime = new System.Windows.Forms.Label();
            this.lblLastModifiedUser = new System.Windows.Forms.Label();
            this.cmbEmployeeStatus = new System.Windows.Forms.ComboBox();
            this.lblEmployeeStatus = new System.Windows.Forms.Label();
            this.cmbEmployeeType = new System.Windows.Forms.ComboBox();
            this.lblEmployeeType = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.txtEmployeeId = new System.Windows.Forms.TextBox();
            this.lblEmployeeId = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControlEmployeeList.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(320, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(239, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 2;
            this.btnSave.Tag = "rsid:Button.R00001";
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 40);
            this.panel1.TabIndex = 4;
            // 
            // tabControlEmployeeList
            // 
            this.tabControlEmployeeList.Controls.Add(this.tabGeneral);
            this.tabControlEmployeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEmployeeList.Location = new System.Drawing.Point(0, 0);
            this.tabControlEmployeeList.Name = "tabControlEmployeeList";
            this.tabControlEmployeeList.SelectedIndex = 0;
            this.tabControlEmployeeList.Size = new System.Drawing.Size(634, 192);
            this.tabControlEmployeeList.TabIndex = 5;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.cboWorkGroup);
            this.tabGeneral.Controls.Add(this.cmbShift);
            this.tabGeneral.Controls.Add(this.dtEffectDate);
            this.tabGeneral.Controls.Add(this.lblEffectDate);
            this.tabGeneral.Controls.Add(this.dtProbAtionDate);
            this.tabGeneral.Controls.Add(this.lblProbAtionDate);
            this.tabGeneral.Controls.Add(this.lblTrainer);
            this.tabGeneral.Controls.Add(this.lblDefaultShift);
            this.tabGeneral.Controls.Add(this.txtLastModifiedTime);
            this.tabGeneral.Controls.Add(this.txtLastModifiedUser);
            this.tabGeneral.Controls.Add(this.lblLastModifiedTime);
            this.tabGeneral.Controls.Add(this.lblLastModifiedUser);
            this.tabGeneral.Controls.Add(this.cmbEmployeeStatus);
            this.tabGeneral.Controls.Add(this.lblEmployeeStatus);
            this.tabGeneral.Controls.Add(this.cmbEmployeeType);
            this.tabGeneral.Controls.Add(this.lblEmployeeType);
            this.tabGeneral.Controls.Add(this.txtEmployeeName);
            this.tabGeneral.Controls.Add(this.lblEmployeeName);
            this.tabGeneral.Controls.Add(this.txtEmployeeId);
            this.tabGeneral.Controls.Add(this.lblEmployeeId);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(626, 166);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Tag = "rsid:Tab.R00001";
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // cboWorkGroup
            // 
            this.cboWorkGroup.FormattingEnabled = true;
            this.cboWorkGroup.Location = new System.Drawing.Point(449, 44);
            this.cboWorkGroup.Name = "cboWorkGroup";
            this.cboWorkGroup.Size = new System.Drawing.Size(150, 20);
            this.cboWorkGroup.TabIndex = 31;
            this.cboWorkGroup.Tag = "rsid:Label.R01016,maxl:64,updt:Y,dbfd:workgroup";
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(449, 73);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(150, 20);
            this.cmbShift.TabIndex = 30;
            this.cmbShift.Tag = "rsid:Label.R0003001,maxl:64,updt:Y,dbfd:defaultshift";
            // 
            // dtEffectDate
            // 
            this.dtEffectDate.CustomFormat = "yyyy-MM-dd";
            this.dtEffectDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEffectDate.Location = new System.Drawing.Point(449, 99);
            this.dtEffectDate.Name = "dtEffectDate";
            this.dtEffectDate.Size = new System.Drawing.Size(150, 21);
            this.dtEffectDate.TabIndex = 29;
            this.dtEffectDate.Tag = "rsid:Label.R0003005,maxl:64,updt:Y,dbfd:effectdate";
            // 
            // lblEffectDate
            // 
            this.lblEffectDate.AutoSize = true;
            this.lblEffectDate.Location = new System.Drawing.Point(328, 101);
            this.lblEffectDate.Name = "lblEffectDate";
            this.lblEffectDate.Size = new System.Drawing.Size(71, 12);
            this.lblEffectDate.TabIndex = 28;
            this.lblEffectDate.Tag = "rsid:Label.R0003005";
            this.lblEffectDate.Text = "Effect Date";
            // 
            // dtProbAtionDate
            // 
            this.dtProbAtionDate.CustomFormat = "yyyy-MM-dd";
            this.dtProbAtionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtProbAtionDate.Location = new System.Drawing.Point(151, 98);
            this.dtProbAtionDate.Name = "dtProbAtionDate";
            this.dtProbAtionDate.Size = new System.Drawing.Size(150, 21);
            this.dtProbAtionDate.TabIndex = 27;
            this.dtProbAtionDate.Tag = "rsid:Label.R0003004,maxl:64,updt:Y,dbfd:probationdate";
            // 
            // lblProbAtionDate
            // 
            this.lblProbAtionDate.AutoSize = true;
            this.lblProbAtionDate.Location = new System.Drawing.Point(20, 101);
            this.lblProbAtionDate.Name = "lblProbAtionDate";
            this.lblProbAtionDate.Size = new System.Drawing.Size(95, 12);
            this.lblProbAtionDate.TabIndex = 26;
            this.lblProbAtionDate.Tag = "rsid:Label.R0003004";
            this.lblProbAtionDate.Text = "Prob Ation Date";
            // 
            // lblTrainer
            // 
            this.lblTrainer.AutoSize = true;
            this.lblTrainer.Location = new System.Drawing.Point(328, 47);
            this.lblTrainer.Name = "lblTrainer";
            this.lblTrainer.Size = new System.Drawing.Size(65, 12);
            this.lblTrainer.TabIndex = 24;
            this.lblTrainer.Tag = "rsid:Label.R01016";
            this.lblTrainer.Text = "Work Group";
            // 
            // lblDefaultShift
            // 
            this.lblDefaultShift.AutoSize = true;
            this.lblDefaultShift.Location = new System.Drawing.Point(328, 76);
            this.lblDefaultShift.Name = "lblDefaultShift";
            this.lblDefaultShift.Size = new System.Drawing.Size(83, 12);
            this.lblDefaultShift.TabIndex = 20;
            this.lblDefaultShift.Tag = "rsid:Label.R0003001";
            this.lblDefaultShift.Text = "Default Shift";
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Enabled = false;
            this.txtLastModifiedTime.Location = new System.Drawing.Point(449, 126);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.Size = new System.Drawing.Size(150, 21);
            this.txtLastModifiedTime.TabIndex = 19;
            this.txtLastModifiedTime.Tag = "rsid:label.r00013,dbfd:lastmodifiedtime";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Enabled = false;
            this.txtLastModifiedUser.Location = new System.Drawing.Point(151, 125);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.Size = new System.Drawing.Size(150, 21);
            this.txtLastModifiedUser.TabIndex = 18;
            this.txtLastModifiedUser.Tag = "rsid:label.r00012,dbfd:lastmodifieduser";
            // 
            // lblLastModifiedTime
            // 
            this.lblLastModifiedTime.AutoSize = true;
            this.lblLastModifiedTime.Location = new System.Drawing.Point(328, 129);
            this.lblLastModifiedTime.Name = "lblLastModifiedTime";
            this.lblLastModifiedTime.Size = new System.Drawing.Size(113, 12);
            this.lblLastModifiedTime.TabIndex = 17;
            this.lblLastModifiedTime.Tag = "rsid:Label.R00013";
            this.lblLastModifiedTime.Text = "Last Modified Time";
            // 
            // lblLastModifiedUser
            // 
            this.lblLastModifiedUser.AutoSize = true;
            this.lblLastModifiedUser.Location = new System.Drawing.Point(20, 128);
            this.lblLastModifiedUser.Name = "lblLastModifiedUser";
            this.lblLastModifiedUser.Size = new System.Drawing.Size(113, 12);
            this.lblLastModifiedUser.TabIndex = 16;
            this.lblLastModifiedUser.Tag = "rsid:Label.R00012";
            this.lblLastModifiedUser.Text = "Last Modified User";
            // 
            // cmbEmployeeStatus
            // 
            this.cmbEmployeeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployeeStatus.FormattingEnabled = true;
            this.cmbEmployeeStatus.Location = new System.Drawing.Point(151, 72);
            this.cmbEmployeeStatus.Name = "cmbEmployeeStatus";
            this.cmbEmployeeStatus.Size = new System.Drawing.Size(150, 20);
            this.cmbEmployeeStatus.TabIndex = 15;
            this.cmbEmployeeStatus.Tag = "rsid:Label.R00029,isrq:Y,updt:Y,dbfd:employeestatus";
            // 
            // lblEmployeeStatus
            // 
            this.lblEmployeeStatus.AutoSize = true;
            this.lblEmployeeStatus.Location = new System.Drawing.Point(20, 75);
            this.lblEmployeeStatus.Name = "lblEmployeeStatus";
            this.lblEmployeeStatus.Size = new System.Drawing.Size(95, 12);
            this.lblEmployeeStatus.TabIndex = 14;
            this.lblEmployeeStatus.Tag = "rsid:Label.R00029,isrq:Y";
            this.lblEmployeeStatus.Text = "Employee Status";
            // 
            // cmbEmployeeType
            // 
            this.cmbEmployeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployeeType.FormattingEnabled = true;
            this.cmbEmployeeType.Location = new System.Drawing.Point(151, 44);
            this.cmbEmployeeType.Name = "cmbEmployeeType";
            this.cmbEmployeeType.Size = new System.Drawing.Size(150, 20);
            this.cmbEmployeeType.TabIndex = 5;
            this.cmbEmployeeType.Tag = "rsid:Label.R00024,isrq:Y,updt:Y,dbfd:employeetypeid";
            // 
            // lblEmployeeType
            // 
            this.lblEmployeeType.AutoSize = true;
            this.lblEmployeeType.Location = new System.Drawing.Point(20, 47);
            this.lblEmployeeType.Name = "lblEmployeeType";
            this.lblEmployeeType.Size = new System.Drawing.Size(83, 12);
            this.lblEmployeeType.TabIndex = 4;
            this.lblEmployeeType.Tag = "rsid:Label.R00024,isrq:Y";
            this.lblEmployeeType.Text = "Employee Type";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(449, 17);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(150, 21);
            this.txtEmployeeName.TabIndex = 3;
            this.txtEmployeeName.Tag = "rsid:Label.R00023,isrq:Y,maxl:64,updt:Y,dbfd:employeename";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(328, 20);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(83, 12);
            this.lblEmployeeName.TabIndex = 2;
            this.lblEmployeeName.Tag = "rsid:Label.R00023,isrq:Y";
            this.lblEmployeeName.Text = "Employee Name";
            // 
            // txtEmployeeId
            // 
            this.txtEmployeeId.Location = new System.Drawing.Point(151, 17);
            this.txtEmployeeId.Name = "txtEmployeeId";
            this.txtEmployeeId.Size = new System.Drawing.Size(150, 21);
            this.txtEmployeeId.TabIndex = 1;
            this.txtEmployeeId.Tag = "rsid:Label.R00022,isrq:Y,maxl:64,updt:Y,dbfd:employeeid";
            // 
            // lblEmployeeId
            // 
            this.lblEmployeeId.AutoSize = true;
            this.lblEmployeeId.Location = new System.Drawing.Point(20, 20);
            this.lblEmployeeId.Name = "lblEmployeeId";
            this.lblEmployeeId.Size = new System.Drawing.Size(71, 12);
            this.lblEmployeeId.TabIndex = 0;
            this.lblEmployeeId.Tag = "rsid:Label.R00022,isrq:Y";
            this.lblEmployeeId.Text = "Employee Id";
            // 
            // frmEmployeeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 232);
            this.Controls.Add(this.tabControlEmployeeList);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 270);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 270);
            this.Name = "frmEmployeeEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "rsid:Label.R00030";
            this.Text = "frmEmployee";
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            this.panel1.ResumeLayout(false);
            this.tabControlEmployeeList.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControlEmployeeList;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.DateTimePicker dtEffectDate;
        private System.Windows.Forms.Label lblEffectDate;
        private System.Windows.Forms.DateTimePicker dtProbAtionDate;
        private System.Windows.Forms.Label lblProbAtionDate;
        private System.Windows.Forms.Label lblTrainer;
        private System.Windows.Forms.Label lblDefaultShift;
        private System.Windows.Forms.TextBox txtLastModifiedTime;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.Label lblLastModifiedTime;
        private System.Windows.Forms.Label lblLastModifiedUser;
        private System.Windows.Forms.ComboBox cmbEmployeeStatus;
        private System.Windows.Forms.Label lblEmployeeStatus;
        private System.Windows.Forms.ComboBox cmbEmployeeType;
        private System.Windows.Forms.Label lblEmployeeType;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Label lblEmployeeId;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.ComboBox cboWorkGroup;
    }
}
namespace GENLSYS.MES.Win.SEC.User
{
    partial class frmUserEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.cmbUserStatus = new System.Windows.Forms.ComboBox();
            this.cmbEmployeeId = new System.Windows.Forms.ComboBox();
            this.txtLastModifiedTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCreatedTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCreatedUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstSelected = new System.Windows.Forms.ListBox();
            this.lstAvaiable = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 293);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 49);
            this.panel1.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(323, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(242, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Tag = "rsid:Button.R00001";
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 293);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.cmbPrinter);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.cmbUserType);
            this.tabPage1.Controls.Add(this.cmbUserStatus);
            this.tabPage1.Controls.Add(this.cmbEmployeeId);
            this.tabPage1.Controls.Add(this.txtLastModifiedTime);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtLastModifiedUser);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtCreatedTime);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtCreatedUser);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtUserName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtUserId);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(632, 268);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "rsid:Label.R00007";
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(459, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 21);
            this.textBox1.TabIndex = 50;
            this.textBox1.Tag = "rsid:Label.R00904,isrq:N,maxl:64,updt:Y,dbfd:aduserid";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(334, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 51;
            this.label11.Tag = "rsid:Label.R00904,isrq:N";
            this.label11.Text = "AD User Id:";
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.Enabled = false;
            this.cmbPrinter.FormattingEnabled = true;
            this.cmbPrinter.Location = new System.Drawing.Point(156, 100);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(149, 20);
            this.cmbPrinter.TabIndex = 7;
            this.cmbPrinter.Tag = "rsid:Label.R00415,isrq:N,maxl:64,updt:Y,dbfd:defaultprinter";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Location = new System.Drawing.Point(20, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 12);
            this.label14.TabIndex = 49;
            this.label14.Tag = "rsid:Label.R00415,isrq:N";
            this.label14.Text = "Default Printer:";
            // 
            // cmbUserType
            // 
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Location = new System.Drawing.Point(459, 47);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(149, 20);
            this.cmbUserType.TabIndex = 4;
            this.cmbUserType.Tag = "rsid:Label.R00134,isrq:Y,maxl:64,updt:Y,dbfd:usertype";
            // 
            // cmbUserStatus
            // 
            this.cmbUserStatus.FormattingEnabled = true;
            this.cmbUserStatus.Location = new System.Drawing.Point(459, 73);
            this.cmbUserStatus.Name = "cmbUserStatus";
            this.cmbUserStatus.Size = new System.Drawing.Size(149, 20);
            this.cmbUserStatus.TabIndex = 6;
            this.cmbUserStatus.Tag = "rsid:Label.R00136,isrq:Y,maxl:64,updt:Y,dbfd:userstatus";
            // 
            // cmbEmployeeId
            // 
            this.cmbEmployeeId.FormattingEnabled = true;
            this.cmbEmployeeId.Location = new System.Drawing.Point(156, 47);
            this.cmbEmployeeId.Name = "cmbEmployeeId";
            this.cmbEmployeeId.Size = new System.Drawing.Size(149, 20);
            this.cmbEmployeeId.TabIndex = 3;
            this.cmbEmployeeId.Tag = "rsid:Label.R00132,isrq:Y,maxl:64,updt:Y,dbfd:employeeid";
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Location = new System.Drawing.Point(459, 154);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.ReadOnly = true;
            this.txtLastModifiedTime.Size = new System.Drawing.Size(149, 21);
            this.txtLastModifiedTime.TabIndex = 11;
            this.txtLastModifiedTime.Tag = "rsid:Label.R00013,isrq:N,maxl:64,updt:N,dbfd:lastmodifiedtime";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(334, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 12);
            this.label9.TabIndex = 42;
            this.label9.Tag = "rsid:Label.R00013,isrq:N";
            this.label9.Text = "Last Modified Time:";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Location = new System.Drawing.Point(156, 154);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.ReadOnly = true;
            this.txtLastModifiedUser.Size = new System.Drawing.Size(149, 21);
            this.txtLastModifiedUser.TabIndex = 10;
            this.txtLastModifiedUser.Tag = "rsid:Label.R00012,isrq:N,maxl:64,updt:N,dbfd:lastmodifieduser";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 12);
            this.label10.TabIndex = 40;
            this.label10.Tag = "rsid:Label.R00012,isrq:N";
            this.label10.Text = "Last Modified User:";
            // 
            // txtCreatedTime
            // 
            this.txtCreatedTime.Location = new System.Drawing.Point(459, 127);
            this.txtCreatedTime.Name = "txtCreatedTime";
            this.txtCreatedTime.ReadOnly = true;
            this.txtCreatedTime.Size = new System.Drawing.Size(149, 21);
            this.txtCreatedTime.TabIndex = 9;
            this.txtCreatedTime.Tag = "rsid:Label.R00137,isrq:N,maxl:64,updt:N,dbfd:createdtime";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(334, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 38;
            this.label7.Tag = "rsid:Label.R00137,isrq:N";
            this.label7.Text = "Created Time:";
            // 
            // txtCreatedUser
            // 
            this.txtCreatedUser.Location = new System.Drawing.Point(156, 127);
            this.txtCreatedUser.Name = "txtCreatedUser";
            this.txtCreatedUser.ReadOnly = true;
            this.txtCreatedUser.Size = new System.Drawing.Size(149, 21);
            this.txtCreatedUser.TabIndex = 8;
            this.txtCreatedUser.Tag = "rsid:Label.R00138,isrq:N,maxl:64,updt:N,dbfd:createduser";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 36;
            this.label8.Tag = "rsid:Label.R00138,isrq:N";
            this.label8.Text = "Created User:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(334, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 25;
            this.label6.Tag = "rsid:Label.R00136,isrq:Y";
            this.label6.Text = "User Status:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(156, 73);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(149, 21);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Tag = "rsid:Label.R00135,isrq:Y,maxl:64,updt:Y,dbfd:password";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 23;
            this.label5.Tag = "rsid:Label.R00135,isrq:Y";
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 21;
            this.label4.Tag = "rsid:Label.R00134,isrq:Y";
            this.label4.Text = "User Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 19;
            this.label3.Tag = "rsid:Label.R00132,isrq:Y";
            this.label3.Text = "Employee Id:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(459, 20);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(149, 21);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.Tag = "rsid:Label.R00133,isrq:Y,maxl:64,updt:Y,dbfd:username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 17;
            this.label2.Tag = "rsid:Label.R00133,isrq:Y";
            this.label2.Text = "User Name:";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(156, 20);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(149, 21);
            this.txtUserId.TabIndex = 1;
            this.txtUserId.Tag = "rsid:Label.R00131,isrq:Y,maxl:64,updt:Y,dbfd:userid";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Tag = "rsid:Label.R00131,isrq:Y";
            this.label1.Text = "User Id:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.btnRemove);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.lstSelected);
            this.tabPage2.Controls.Add(this.lstAvaiable);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(632, 268);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "rsid:Tab.R00006";
            this.tabPage2.Text = "Roles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(361, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 5;
            this.label13.Tag = "rsid:Label.R00141";
            this.label13.Text = "Selected Roles";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 12);
            this.label12.TabIndex = 4;
            this.label12.Tag = "rsid:Label.R00142";
            this.label12.Text = "Available Roles";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(266, 112);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 14;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(266, 74);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstSelected
            // 
            this.lstSelected.FormattingEnabled = true;
            this.lstSelected.ItemHeight = 12;
            this.lstSelected.Location = new System.Drawing.Point(361, 43);
            this.lstSelected.Name = "lstSelected";
            this.lstSelected.Size = new System.Drawing.Size(222, 208);
            this.lstSelected.TabIndex = 15;
            // 
            // lstAvaiable
            // 
            this.lstAvaiable.FormattingEnabled = true;
            this.lstAvaiable.ItemHeight = 12;
            this.lstAvaiable.Location = new System.Drawing.Point(20, 43);
            this.lstAvaiable.Name = "lstAvaiable";
            this.lstAvaiable.Size = new System.Drawing.Size(222, 208);
            this.lstAvaiable.TabIndex = 12;
            // 
            // frmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 342);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserEdit";
            this.ShowInTaskbar = false;
            this.Tag = "rsid:Menu.M500030";
            this.Text = "frmUserEdit";
            this.Load += new System.EventHandler(this.frmUserEdit_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.ComboBox cmbUserStatus;
        private System.Windows.Forms.ComboBox cmbEmployeeId;
        private System.Windows.Forms.TextBox txtLastModifiedTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCreatedTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCreatedUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstSelected;
        private System.Windows.Forms.ListBox lstAvaiable;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;

    }
}
namespace GENLSYS.MES.Win.MDL.EmployeeType
{
    partial class frmEmployeeTypeEdit
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
            this.tabControlEqpType = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.txtEmployeeTypeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLastModifiedTime = new System.Windows.Forms.TextBox();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.lblLastModifiedTime = new System.Windows.Forms.Label();
            this.lblLastModifiedUser = new System.Windows.Forms.Label();
            this.txtEmployeeTypeId = new System.Windows.Forms.TextBox();
            this.lblEqpType = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControlEqpType.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(169, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(88, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 9;
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
            this.panel1.Location = new System.Drawing.Point(0, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 40);
            this.panel1.TabIndex = 11;
            // 
            // tabControlEqpType
            // 
            this.tabControlEqpType.Controls.Add(this.tabGeneral);
            this.tabControlEqpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEqpType.Location = new System.Drawing.Point(0, 0);
            this.tabControlEqpType.Name = "tabControlEqpType";
            this.tabControlEqpType.SelectedIndex = 0;
            this.tabControlEqpType.Size = new System.Drawing.Size(333, 162);
            this.tabControlEqpType.TabIndex = 12;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.txtEmployeeTypeName);
            this.tabGeneral.Controls.Add(this.label1);
            this.tabGeneral.Controls.Add(this.txtLastModifiedTime);
            this.tabGeneral.Controls.Add(this.txtLastModifiedUser);
            this.tabGeneral.Controls.Add(this.lblLastModifiedTime);
            this.tabGeneral.Controls.Add(this.lblLastModifiedUser);
            this.tabGeneral.Controls.Add(this.txtEmployeeTypeId);
            this.tabGeneral.Controls.Add(this.lblEqpType);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(325, 136);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Tag = "rsid:Tab.R00001";
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // txtEmployeeTypeName
            // 
            this.txtEmployeeTypeName.Location = new System.Drawing.Point(144, 44);
            this.txtEmployeeTypeName.Name = "txtEmployeeTypeName";
            this.txtEmployeeTypeName.Size = new System.Drawing.Size(148, 21);
            this.txtEmployeeTypeName.TabIndex = 39;
            this.txtEmployeeTypeName.Tag = "rsid:Label.R00381,isrq:Y,maxl:64,updt:Y,dbfd:employeetypename";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 38;
            this.label1.Tag = "rsid:Label.R00381,isrq:Y";
            this.label1.Text = "Employee Type Name";
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Enabled = false;
            this.txtLastModifiedTime.Location = new System.Drawing.Point(144, 98);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.Size = new System.Drawing.Size(148, 21);
            this.txtLastModifiedTime.TabIndex = 35;
            this.txtLastModifiedTime.Tag = "rsid:label.r00013,dbfd:lastmodifiedtime";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Enabled = false;
            this.txtLastModifiedUser.Location = new System.Drawing.Point(144, 71);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.Size = new System.Drawing.Size(148, 21);
            this.txtLastModifiedUser.TabIndex = 34;
            this.txtLastModifiedUser.Tag = "rsid:label.r00012,dbfd:lastmodifieduser";
            // 
            // lblLastModifiedTime
            // 
            this.lblLastModifiedTime.AutoSize = true;
            this.lblLastModifiedTime.Location = new System.Drawing.Point(20, 101);
            this.lblLastModifiedTime.Name = "lblLastModifiedTime";
            this.lblLastModifiedTime.Size = new System.Drawing.Size(113, 12);
            this.lblLastModifiedTime.TabIndex = 33;
            this.lblLastModifiedTime.Tag = "rsid:Label.R00013";
            this.lblLastModifiedTime.Text = "Last Modified Time";
            // 
            // lblLastModifiedUser
            // 
            this.lblLastModifiedUser.AutoSize = true;
            this.lblLastModifiedUser.Location = new System.Drawing.Point(20, 74);
            this.lblLastModifiedUser.Name = "lblLastModifiedUser";
            this.lblLastModifiedUser.Size = new System.Drawing.Size(113, 12);
            this.lblLastModifiedUser.TabIndex = 32;
            this.lblLastModifiedUser.Tag = "rsid:Label.R00012";
            this.lblLastModifiedUser.Text = "Last Modified User";
            // 
            // txtEmployeeTypeId
            // 
            this.txtEmployeeTypeId.Location = new System.Drawing.Point(144, 17);
            this.txtEmployeeTypeId.Name = "txtEmployeeTypeId";
            this.txtEmployeeTypeId.Size = new System.Drawing.Size(148, 21);
            this.txtEmployeeTypeId.TabIndex = 31;
            this.txtEmployeeTypeId.Tag = "rsid:Label.R00380,isrq:Y,maxl:64,updt:Y,dbfd:employeetypeid";
            // 
            // lblEqpType
            // 
            this.lblEqpType.AutoSize = true;
            this.lblEqpType.Location = new System.Drawing.Point(20, 20);
            this.lblEqpType.Name = "lblEqpType";
            this.lblEqpType.Size = new System.Drawing.Size(101, 12);
            this.lblEqpType.TabIndex = 30;
            this.lblEqpType.Tag = "rsid:Label.R00380,isrq:Y";
            this.lblEqpType.Text = "Employee Type ID";
            // 
            // frmEmployeeTypeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 202);
            this.Controls.Add(this.tabControlEqpType);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(349, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(349, 240);
            this.Name = "frmEmployeeTypeEdit";
            this.ShowInTaskbar = false;
            this.Tag = "rsid:Label.R00382";
            this.Text = "frmEmployeeTypeEdit";
            this.Load += new System.EventHandler(this.frmEmployeeTypeEdit_Load);
            this.panel1.ResumeLayout(false);
            this.tabControlEqpType.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControlEqpType;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TextBox txtEmployeeTypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLastModifiedTime;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.Label lblLastModifiedTime;
        private System.Windows.Forms.Label lblLastModifiedUser;
        private System.Windows.Forms.TextBox txtEmployeeTypeId;
        private System.Windows.Forms.Label lblEqpType;
    }
}
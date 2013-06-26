namespace GENLSYS.MES.Win.SEC.Role
{
    partial class frmRoleEdit
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
            this.tabFunctions = new System.Windows.Forms.TabPage();
            this.treeFunction = new System.Windows.Forms.TreeView();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.txtCreatedTime = new System.Windows.Forms.TextBox();
            this.txtCreatedUser = new System.Windows.Forms.TextBox();
            this.txtRoleDesc = new System.Windows.Forms.TextBox();
            this.txtLastModifiedTime = new System.Windows.Forms.TextBox();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.txtRoleId = new System.Windows.Forms.TextBox();
            this.lblCreatedTime = new System.Windows.Forms.Label();
            this.lblCreatedUser = new System.Windows.Forms.Label();
            this.cmbRoleStatus = new System.Windows.Forms.ComboBox();
            this.lblRoleStatus = new System.Windows.Forms.Label();
            this.lblRoleDesc = new System.Windows.Forms.Label();
            this.lblLastModifiedTime = new System.Windows.Forms.Label();
            this.lblLastModifiedUser = new System.Windows.Forms.Label();
            this.lblRoleId = new System.Windows.Forms.Label();
            this.tabControlRole = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.tabFunctions.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabControlRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(308, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(227, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 10;
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
            this.panel1.Location = new System.Drawing.Point(0, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 40);
            this.panel1.TabIndex = 12;
            // 
            // tabFunctions
            // 
            this.tabFunctions.Controls.Add(this.treeFunction);
            this.tabFunctions.Location = new System.Drawing.Point(4, 22);
            this.tabFunctions.Name = "tabFunctions";
            this.tabFunctions.Size = new System.Drawing.Size(602, 269);
            this.tabFunctions.TabIndex = 2;
            this.tabFunctions.Tag = "rsid:Tab.R00007";
            this.tabFunctions.Text = "Functions";
            this.tabFunctions.UseVisualStyleBackColor = true;
            // 
            // treeFunction
            // 
            this.treeFunction.CheckBoxes = true;
            this.treeFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFunction.FullRowSelect = true;
            this.treeFunction.HotTracking = true;
            this.treeFunction.ItemHeight = 16;
            this.treeFunction.Location = new System.Drawing.Point(0, 0);
            this.treeFunction.Name = "treeFunction";
            this.treeFunction.Size = new System.Drawing.Size(602, 269);
            this.treeFunction.TabIndex = 0;
            this.treeFunction.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeFunction_AfterCheck);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.txtCreatedTime);
            this.tabGeneral.Controls.Add(this.txtCreatedUser);
            this.tabGeneral.Controls.Add(this.txtRoleDesc);
            this.tabGeneral.Controls.Add(this.txtLastModifiedTime);
            this.tabGeneral.Controls.Add(this.txtLastModifiedUser);
            this.tabGeneral.Controls.Add(this.txtRoleId);
            this.tabGeneral.Controls.Add(this.lblCreatedTime);
            this.tabGeneral.Controls.Add(this.lblCreatedUser);
            this.tabGeneral.Controls.Add(this.cmbRoleStatus);
            this.tabGeneral.Controls.Add(this.lblRoleStatus);
            this.tabGeneral.Controls.Add(this.lblRoleDesc);
            this.tabGeneral.Controls.Add(this.lblLastModifiedTime);
            this.tabGeneral.Controls.Add(this.lblLastModifiedUser);
            this.tabGeneral.Controls.Add(this.lblRoleId);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(602, 269);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Tag = "rsid:Tab.R00001";
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // txtCreatedTime
            // 
            this.txtCreatedTime.Enabled = false;
            this.txtCreatedTime.Location = new System.Drawing.Point(428, 167);
            this.txtCreatedTime.Name = "txtCreatedTime";
            this.txtCreatedTime.Size = new System.Drawing.Size(148, 21);
            this.txtCreatedTime.TabIndex = 61;
            this.txtCreatedTime.Tag = "rsid:label.r00148,dbfd:createdtime";
            // 
            // txtCreatedUser
            // 
            this.txtCreatedUser.Enabled = false;
            this.txtCreatedUser.Location = new System.Drawing.Point(140, 164);
            this.txtCreatedUser.Name = "txtCreatedUser";
            this.txtCreatedUser.Size = new System.Drawing.Size(148, 21);
            this.txtCreatedUser.TabIndex = 60;
            this.txtCreatedUser.Tag = "rsid:label.r00147,dbfd:createduser";
            // 
            // txtRoleDesc
            // 
            this.txtRoleDesc.Location = new System.Drawing.Point(140, 44);
            this.txtRoleDesc.Multiline = true;
            this.txtRoleDesc.Name = "txtRoleDesc";
            this.txtRoleDesc.Size = new System.Drawing.Size(436, 114);
            this.txtRoleDesc.TabIndex = 53;
            this.txtRoleDesc.Tag = "rsid:label.r00169,maxl:250,updt:Y,dbfd:roledesc";
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Enabled = false;
            this.txtLastModifiedTime.Location = new System.Drawing.Point(428, 194);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.Size = new System.Drawing.Size(148, 21);
            this.txtLastModifiedTime.TabIndex = 51;
            this.txtLastModifiedTime.Tag = "rsid:label.r00013,dbfd:lastmodifiedtime";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Enabled = false;
            this.txtLastModifiedUser.Location = new System.Drawing.Point(140, 191);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.Size = new System.Drawing.Size(148, 21);
            this.txtLastModifiedUser.TabIndex = 50;
            this.txtLastModifiedUser.Tag = "rsid:label.r00012,dbfd:lastmodifieduser";
            // 
            // txtRoleId
            // 
            this.txtRoleId.Location = new System.Drawing.Point(140, 17);
            this.txtRoleId.Name = "txtRoleId";
            this.txtRoleId.Size = new System.Drawing.Size(148, 21);
            this.txtRoleId.TabIndex = 47;
            this.txtRoleId.Tag = "rsid:Label.R00167,isrq:Y,maxl:64,updt:Y,dbfd:roleid";
            // 
            // lblCreatedTime
            // 
            this.lblCreatedTime.AutoSize = true;
            this.lblCreatedTime.Location = new System.Drawing.Point(306, 170);
            this.lblCreatedTime.Name = "lblCreatedTime";
            this.lblCreatedTime.Size = new System.Drawing.Size(77, 12);
            this.lblCreatedTime.TabIndex = 59;
            this.lblCreatedTime.Tag = "rsid:Label.R00148";
            this.lblCreatedTime.Text = "Created Time";
            // 
            // lblCreatedUser
            // 
            this.lblCreatedUser.AutoSize = true;
            this.lblCreatedUser.Location = new System.Drawing.Point(20, 167);
            this.lblCreatedUser.Name = "lblCreatedUser";
            this.lblCreatedUser.Size = new System.Drawing.Size(77, 12);
            this.lblCreatedUser.TabIndex = 58;
            this.lblCreatedUser.Tag = "rsid:Label.R00147";
            this.lblCreatedUser.Text = "Created User";
            // 
            // cmbRoleStatus
            // 
            this.cmbRoleStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleStatus.FormattingEnabled = true;
            this.cmbRoleStatus.Location = new System.Drawing.Point(428, 17);
            this.cmbRoleStatus.Name = "cmbRoleStatus";
            this.cmbRoleStatus.Size = new System.Drawing.Size(148, 20);
            this.cmbRoleStatus.TabIndex = 55;
            this.cmbRoleStatus.Tag = "rsid:Label.R00168,isrq:Y,updt:Y,dbfd:rolestatus";
            // 
            // lblRoleStatus
            // 
            this.lblRoleStatus.AutoSize = true;
            this.lblRoleStatus.Location = new System.Drawing.Point(306, 17);
            this.lblRoleStatus.Name = "lblRoleStatus";
            this.lblRoleStatus.Size = new System.Drawing.Size(71, 12);
            this.lblRoleStatus.TabIndex = 54;
            this.lblRoleStatus.Tag = "rsid:Label.R00168,isrq:Y";
            this.lblRoleStatus.Text = "Role Status";
            // 
            // lblRoleDesc
            // 
            this.lblRoleDesc.AutoSize = true;
            this.lblRoleDesc.Location = new System.Drawing.Point(20, 47);
            this.lblRoleDesc.Name = "lblRoleDesc";
            this.lblRoleDesc.Size = new System.Drawing.Size(59, 12);
            this.lblRoleDesc.TabIndex = 52;
            this.lblRoleDesc.Tag = "rsid:Label.R00169";
            this.lblRoleDesc.Text = "Role Desc";
            // 
            // lblLastModifiedTime
            // 
            this.lblLastModifiedTime.AutoSize = true;
            this.lblLastModifiedTime.Location = new System.Drawing.Point(306, 197);
            this.lblLastModifiedTime.Name = "lblLastModifiedTime";
            this.lblLastModifiedTime.Size = new System.Drawing.Size(113, 12);
            this.lblLastModifiedTime.TabIndex = 49;
            this.lblLastModifiedTime.Tag = "rsid:Label.R00013";
            this.lblLastModifiedTime.Text = "Last Modified Time";
            // 
            // lblLastModifiedUser
            // 
            this.lblLastModifiedUser.AutoSize = true;
            this.lblLastModifiedUser.Location = new System.Drawing.Point(20, 194);
            this.lblLastModifiedUser.Name = "lblLastModifiedUser";
            this.lblLastModifiedUser.Size = new System.Drawing.Size(113, 12);
            this.lblLastModifiedUser.TabIndex = 48;
            this.lblLastModifiedUser.Tag = "rsid:Label.R00012";
            this.lblLastModifiedUser.Text = "Last Modified User";
            // 
            // lblRoleId
            // 
            this.lblRoleId.AutoSize = true;
            this.lblRoleId.Location = new System.Drawing.Point(20, 20);
            this.lblRoleId.Name = "lblRoleId";
            this.lblRoleId.Size = new System.Drawing.Size(47, 12);
            this.lblRoleId.TabIndex = 46;
            this.lblRoleId.Tag = "rsid:Label.R00167,isrq:Y";
            this.lblRoleId.Text = "Role Id";
            // 
            // tabControlRole
            // 
            this.tabControlRole.Controls.Add(this.tabGeneral);
            this.tabControlRole.Controls.Add(this.tabFunctions);
            this.tabControlRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlRole.Location = new System.Drawing.Point(0, 0);
            this.tabControlRole.Name = "tabControlRole";
            this.tabControlRole.SelectedIndex = 0;
            this.tabControlRole.Size = new System.Drawing.Size(610, 295);
            this.tabControlRole.TabIndex = 13;
            // 
            // frmRoleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 335);
            this.Controls.Add(this.tabControlRole);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoleEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "rsid:Label.R00170";
            this.Text = "frmRoleEdit";
            this.Load += new System.EventHandler(this.frmRoleEdit_Load);
            this.panel1.ResumeLayout(false);
            this.tabFunctions.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabControlRole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabFunctions;
        private System.Windows.Forms.TreeView treeFunction;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TextBox txtCreatedTime;
        private System.Windows.Forms.TextBox txtCreatedUser;
        private System.Windows.Forms.TextBox txtRoleDesc;
        private System.Windows.Forms.TextBox txtLastModifiedTime;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.TextBox txtRoleId;
        private System.Windows.Forms.Label lblCreatedTime;
        private System.Windows.Forms.Label lblCreatedUser;
        private System.Windows.Forms.ComboBox cmbRoleStatus;
        private System.Windows.Forms.Label lblRoleStatus;
        private System.Windows.Forms.Label lblRoleDesc;
        private System.Windows.Forms.Label lblLastModifiedTime;
        private System.Windows.Forms.Label lblLastModifiedUser;
        private System.Windows.Forms.Label lblRoleId;
        private System.Windows.Forms.TabControl tabControlRole;
    }
}
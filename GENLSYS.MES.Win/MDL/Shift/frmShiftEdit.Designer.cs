namespace GENLSYS.MES.Win.MDL.Shift
{
    partial class frmShiftEdit
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
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.txtShiftName = new System.Windows.Forms.TextBox();
            this.lblShiftName = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtLastModifiedTime = new System.Windows.Forms.TextBox();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.lblLastModifiedTime = new System.Windows.Forms.Label();
            this.lblLastModifiedUser = new System.Windows.Forms.Label();
            this.txtShift = new System.Windows.Forms.TextBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.dtStartTime = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dtEndTime = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.panel1.SuspendLayout();
            this.tabControlEqpType.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(203, 10);
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
            this.btnSave.Location = new System.Drawing.Point(122, 10);
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
            this.panel1.Location = new System.Drawing.Point(0, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 40);
            this.panel1.TabIndex = 11;
            // 
            // tabControlEqpType
            // 
            this.tabControlEqpType.Controls.Add(this.tabGeneral);
            this.tabControlEqpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEqpType.Location = new System.Drawing.Point(0, 0);
            this.tabControlEqpType.Name = "tabControlEqpType";
            this.tabControlEqpType.SelectedIndex = 0;
            this.tabControlEqpType.Size = new System.Drawing.Size(409, 336);
            this.tabControlEqpType.TabIndex = 12;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.dtEndTime);
            this.tabGeneral.Controls.Add(this.dtStartTime);
            this.tabGeneral.Controls.Add(this.lblEndTime);
            this.tabGeneral.Controls.Add(this.lblStartTime);
            this.tabGeneral.Controls.Add(this.txtShiftName);
            this.tabGeneral.Controls.Add(this.lblShiftName);
            this.tabGeneral.Controls.Add(this.txtRemark);
            this.tabGeneral.Controls.Add(this.lblRemark);
            this.tabGeneral.Controls.Add(this.txtLastModifiedTime);
            this.tabGeneral.Controls.Add(this.txtLastModifiedUser);
            this.tabGeneral.Controls.Add(this.lblLastModifiedTime);
            this.tabGeneral.Controls.Add(this.lblLastModifiedUser);
            this.tabGeneral.Controls.Add(this.txtShift);
            this.tabGeneral.Controls.Add(this.lblShift);
            this.tabGeneral.Location = new System.Drawing.Point(4, 21);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(401, 311);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Tag = "rsid:Tab.R00001";
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(20, 104);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(53, 12);
            this.lblEndTime.TabIndex = 79;
            this.lblEndTime.Tag = "rsid:Label.R00397";
            this.lblEndTime.Text = "End Time";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(20, 77);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(65, 12);
            this.lblStartTime.TabIndex = 40;
            this.lblStartTime.Tag = "rsid:Label.R00396";
            this.lblStartTime.Text = "Start Time";
            // 
            // txtShiftName
            // 
            this.txtShiftName.Location = new System.Drawing.Point(145, 44);
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.Size = new System.Drawing.Size(148, 21);
            this.txtShiftName.TabIndex = 39;
            this.txtShiftName.Tag = "rsid:Label.R00395,isrq:Y,maxl:64,updt:Y,dbfd:shiftname";
            // 
            // lblShiftName
            // 
            this.lblShiftName.AutoSize = true;
            this.lblShiftName.Location = new System.Drawing.Point(20, 47);
            this.lblShiftName.Name = "lblShiftName";
            this.lblShiftName.Size = new System.Drawing.Size(65, 12);
            this.lblShiftName.TabIndex = 38;
            this.lblShiftName.Tag = "rsid:Label.R00395,isrq:Y";
            this.lblShiftName.Text = "Shift Name";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(145, 179);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(225, 107);
            this.txtRemark.TabIndex = 37;
            this.txtRemark.Tag = "rsid:label.r00398,maxl:250,updt:Y,dbfd:remark";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(20, 182);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(41, 12);
            this.lblRemark.TabIndex = 36;
            this.lblRemark.Tag = "rsid:Label.R00398";
            this.lblRemark.Text = "Remark";
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Enabled = false;
            this.txtLastModifiedTime.Location = new System.Drawing.Point(145, 152);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.Size = new System.Drawing.Size(148, 21);
            this.txtLastModifiedTime.TabIndex = 35;
            this.txtLastModifiedTime.Tag = "rsid:label.r00013,dbfd:lastmodifiedtime";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Enabled = false;
            this.txtLastModifiedUser.Location = new System.Drawing.Point(145, 125);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.Size = new System.Drawing.Size(148, 21);
            this.txtLastModifiedUser.TabIndex = 34;
            this.txtLastModifiedUser.Tag = "rsid:label.r00012,dbfd:lastmodifieduser";
            // 
            // lblLastModifiedTime
            // 
            this.lblLastModifiedTime.AutoSize = true;
            this.lblLastModifiedTime.Location = new System.Drawing.Point(20, 155);
            this.lblLastModifiedTime.Name = "lblLastModifiedTime";
            this.lblLastModifiedTime.Size = new System.Drawing.Size(113, 12);
            this.lblLastModifiedTime.TabIndex = 33;
            this.lblLastModifiedTime.Tag = "rsid:Label.R00013";
            this.lblLastModifiedTime.Text = "Last Modified Time";
            // 
            // lblLastModifiedUser
            // 
            this.lblLastModifiedUser.AutoSize = true;
            this.lblLastModifiedUser.Location = new System.Drawing.Point(20, 128);
            this.lblLastModifiedUser.Name = "lblLastModifiedUser";
            this.lblLastModifiedUser.Size = new System.Drawing.Size(113, 12);
            this.lblLastModifiedUser.TabIndex = 32;
            this.lblLastModifiedUser.Tag = "rsid:Label.R00012";
            this.lblLastModifiedUser.Text = "Last Modified User";
            // 
            // txtShift
            // 
            this.txtShift.Location = new System.Drawing.Point(145, 17);
            this.txtShift.Name = "txtShift";
            this.txtShift.Size = new System.Drawing.Size(148, 21);
            this.txtShift.TabIndex = 31;
            this.txtShift.Tag = "rsid:Label.R00394,isrq:Y,maxl:64,updt:Y,dbfd:shift";
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Location = new System.Drawing.Point(20, 20);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(35, 12);
            this.lblShift.TabIndex = 30;
            this.lblShift.Tag = "rsid:Label.R00394,isrq:Y";
            this.lblShift.Text = "Shift";
            // 
            // dtStartTime
            // 
            this.dtStartTime.Location = new System.Drawing.Point(145, 71);
            this.dtStartTime.MaskInput = "{time}";
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(148, 21);
            this.dtStartTime.TabIndex = 80;
            this.dtStartTime.Tag = "rsid:Label.R00396,isrq:Y,maxl:64,updt:Y,dbfd:starttime";
            // 
            // dtEndTime
            // 
            this.dtEndTime.Location = new System.Drawing.Point(145, 98);
            this.dtEndTime.MaskInput = "{time}";
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(148, 21);
            this.dtEndTime.TabIndex = 81;
            this.dtEndTime.Tag = "rsid:Label.R00397,isrq:Y,maxl:64,updt:Y,dbfd:endtime";
            // 
            // frmShiftEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 376);
            this.Controls.Add(this.tabControlEqpType);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(417, 410);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(417, 410);
            this.Name = "frmShiftEdit";
            this.ShowInTaskbar = false;
            this.Tag = "rsid:Label.R00399";
            this.Text = "frmShiftEdit";
            this.Load += new System.EventHandler(this.frmShiftEdit_Load);
            this.panel1.ResumeLayout(false);
            this.tabControlEqpType.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControlEqpType;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.Label lblShiftName;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtLastModifiedTime;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.Label lblLastModifiedTime;
        private System.Windows.Forms.Label lblLastModifiedUser;
        private System.Windows.Forms.TextBox txtShift;
        private System.Windows.Forms.Label lblShift;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtStartTime;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtEndTime;
    }
}
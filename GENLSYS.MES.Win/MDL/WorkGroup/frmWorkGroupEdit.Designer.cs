namespace GENLSYS.MES.Win.MDL.WorkGroup
{
    partial class frmWorkGroupEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtLastModifiedTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWorkGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStep = new System.Windows.Forms.ComboBox();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cboStep);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtLastModifiedTime);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtLastModifiedUser);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtDesc);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtWorkGroup);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(409, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "rsid:Label.R00007";
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Location = new System.Drawing.Point(175, 208);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.ReadOnly = true;
            this.txtLastModifiedTime.Size = new System.Drawing.Size(217, 21);
            this.txtLastModifiedTime.TabIndex = 6;
            this.txtLastModifiedTime.Tag = "rsid:Label.R00013,isrq:N,maxl:64,updt:N,dbfd:lastmodifiedtime";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 34;
            this.label6.Tag = "rsid:Label.R00013,isrq:N";
            this.label6.Text = "Last Modified Time:";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Location = new System.Drawing.Point(175, 181);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.ReadOnly = true;
            this.txtLastModifiedUser.Size = new System.Drawing.Size(217, 21);
            this.txtLastModifiedUser.TabIndex = 5;
            this.txtLastModifiedUser.Tag = "rsid:Label.R00012,isrq:N,maxl:64,updt:N,dbfd:lastmodifieduser";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 32;
            this.label5.Tag = "rsid:Label.R00012,isrq:N";
            this.label5.Text = "Last Modified User:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(175, 47);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(217, 101);
            this.txtDesc.TabIndex = 4;
            this.txtDesc.Tag = "rsid:Label.R01017,isrq:N,maxl:250,updt:Y,dbfd:workgroupdesc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 30;
            this.label4.Tag = "rsid:Label.R01017,isrq:N";
            this.label4.Text = "Description:";
            // 
            // txtWorkGroup
            // 
            this.txtWorkGroup.Location = new System.Drawing.Point(175, 20);
            this.txtWorkGroup.Name = "txtWorkGroup";
            this.txtWorkGroup.Size = new System.Drawing.Size(217, 21);
            this.txtWorkGroup.TabIndex = 1;
            this.txtWorkGroup.Tag = "rsid:Label.R01016,isrq:Y,maxl:64,updt:Y,dbfd:workgroup";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 15;
            this.label1.Tag = "rsid:Label.R01016,isrq:Y";
            this.label1.Text = "Work Group:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(417, 259);
            this.tabControl1.TabIndex = 21;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(134, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Tag = "rsid:Button.R00001";
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(215, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 259);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 49);
            this.panel1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 36;
            this.label2.Tag = "rsid:Label.R00950,isrq:Y";
            this.label2.Text = "Step：";
            // 
            // cboStep
            // 
            this.cboStep.FormattingEnabled = true;
            this.cboStep.Location = new System.Drawing.Point(175, 155);
            this.cboStep.Name = "cboStep";
            this.cboStep.Size = new System.Drawing.Size(217, 20);
            this.cboStep.TabIndex = 37;
            this.cboStep.Tag = "rsid:Label.R00950,isrq:Y,maxl:64,updt:Y,dbfd:step";
            // 
            // frmWorkGroupEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 308);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWorkGroupEdit";
            this.Tag = "rsid:Label.R01018";
            this.Text = "frmWorkGroupEdit";
            this.Load += new System.EventHandler(this.frmWorkGroupEdit_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtLastModifiedTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWorkGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboStep;
        private System.Windows.Forms.Label label2;
    }
}
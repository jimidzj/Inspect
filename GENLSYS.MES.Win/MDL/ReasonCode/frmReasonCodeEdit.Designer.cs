namespace GENLSYS.MES.Win.MDL.ReasonCode
{
    partial class frmReasonCodeEdit
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
            this.txtLastModifiedTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReasonCategoryDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbReasonCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReasonCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtJpDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ucAttribute = new GENLSYS.MES.UserControls.ucAttribute();
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
            this.panel1.Location = new System.Drawing.Point(0, 323);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 49);
            this.panel1.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(202, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
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
            this.btnSave.Location = new System.Drawing.Point(121, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
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
            this.tabControl1.Size = new System.Drawing.Size(399, 323);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtJpDesc);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtLastModifiedTime);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtLastModifiedUser);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtReasonCategoryDesc);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmbReasonCategory);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtReasonCode);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(391, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "rsid:Label.R00007";
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Location = new System.Drawing.Point(148, 264);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.ReadOnly = true;
            this.txtLastModifiedTime.Size = new System.Drawing.Size(217, 21);
            this.txtLastModifiedTime.TabIndex = 35;
            this.txtLastModifiedTime.Tag = "rsid:Label.R00013,isrq:N,maxl:64,updt:N,dbfd:lastmodifiedtime";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 34;
            this.label6.Tag = "rsid:Label.R00013,isrq:N";
            this.label6.Text = "Last Modified Time:";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Location = new System.Drawing.Point(148, 237);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.ReadOnly = true;
            this.txtLastModifiedUser.Size = new System.Drawing.Size(217, 21);
            this.txtLastModifiedUser.TabIndex = 33;
            this.txtLastModifiedUser.Tag = "rsid:Label.R00012,isrq:N,maxl:64,updt:N,dbfd:lastmodifieduser";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 32;
            this.label5.Tag = "rsid:Label.R00012,isrq:N";
            this.label5.Text = "Last Modified User:";
            // 
            // txtReasonCategoryDesc
            // 
            this.txtReasonCategoryDesc.Location = new System.Drawing.Point(148, 72);
            this.txtReasonCategoryDesc.Multiline = true;
            this.txtReasonCategoryDesc.Name = "txtReasonCategoryDesc";
            this.txtReasonCategoryDesc.Size = new System.Drawing.Size(217, 76);
            this.txtReasonCategoryDesc.TabIndex = 31;
            this.txtReasonCategoryDesc.Tag = "rsid:Label.R00040,isrq:N,maxl:250,updt:Y,dbfd:reasoncodedesc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 30;
            this.label4.Tag = "rsid:Label.R00040,isrq:N";
            this.label4.Text = "Reason Code Desc:";
            // 
            // cmbReasonCategory
            // 
            this.cmbReasonCategory.FormattingEnabled = true;
            this.cmbReasonCategory.Items.AddRange(new object[] {
            "System",
            "User"});
            this.cmbReasonCategory.Location = new System.Drawing.Point(148, 46);
            this.cmbReasonCategory.Name = "cmbReasonCategory";
            this.cmbReasonCategory.Size = new System.Drawing.Size(217, 20);
            this.cmbReasonCategory.TabIndex = 27;
            this.cmbReasonCategory.Tag = "rsid:Label.R00035,isrq:Y,updt:Y,dbfd:reasoncategory";
            this.cmbReasonCategory.Click += new System.EventHandler(this.cmbReasonCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 17;
            this.label2.Tag = "rsid:Label.R00035,isrq:Y";
            this.label2.Text = "Reason Category:";
            // 
            // txtReasonCode
            // 
            this.txtReasonCode.Location = new System.Drawing.Point(148, 20);
            this.txtReasonCode.Name = "txtReasonCode";
            this.txtReasonCode.Size = new System.Drawing.Size(217, 21);
            this.txtReasonCode.TabIndex = 16;
            this.txtReasonCode.Tag = "rsid:Label.R00037,isrq:Y,maxl:64,updt:Y,dbfd:reasoncode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 15;
            this.label1.Tag = "rsid:Label.R00037,isrq:Y";
            this.label1.Text = "Reason Code:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucAttribute);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(391, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "rsid:Tab.R00002";
            this.tabPage2.Text = "Attribute";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtJpDesc
            // 
            this.txtJpDesc.Location = new System.Drawing.Point(148, 155);
            this.txtJpDesc.Multiline = true;
            this.txtJpDesc.Name = "txtJpDesc";
            this.txtJpDesc.Size = new System.Drawing.Size(217, 76);
            this.txtJpDesc.TabIndex = 37;
            this.txtJpDesc.Tag = "rsid:Label.R0004001,isrq:N,maxl:250,updt:Y,dbfd:jpdesc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 36;
            this.label3.Tag = "rsid:Label.R0004001,isrq:N";
            this.label3.Text = "JP Desc:";
            // 
            // ucAttribute
            // 
            this.ucAttribute.AllowToUpdate = false;
            this.ucAttribute.AttributeID = null;
            this.ucAttribute.AttributeTemplateID = null;
            this.ucAttribute.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucAttribute.CurrentContextInfo = null;
            this.ucAttribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAttribute.Location = new System.Drawing.Point(3, 3);
            this.ucAttribute.Name = "ucAttribute";
            this.ucAttribute.Size = new System.Drawing.Size(385, 291);
            this.ucAttribute.TabIndex = 0;
            this.ucAttribute.UpdateMode = GENLSYS.MES.Common.Public_UpdateMode.Insert;
            this.ucAttribute.WhereUsed = GENLSYS.MES.Common.MES_AttributeTemplate_UsedBy.Area;
            // 
            // frmReasonCodeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 372);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReasonCodeEdit";
            this.ShowInTaskbar = false;
            this.Tag = "rsid:Label.R00039";
            this.Text = "frmReasonCodeEdit";
            this.Load += new System.EventHandler(this.frmReasonCodeEdit_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtLastModifiedTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReasonCategoryDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbReasonCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReasonCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private UserControls.ucAttribute ucAttribute;
        private System.Windows.Forms.TextBox txtJpDesc;
        private System.Windows.Forms.Label label3;

    }
}
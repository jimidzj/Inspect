namespace GENLSYS.MES.Win.SYS.AttributeTemplate
{
    partial class frmAttributeAttemplateEdit
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
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtLastModifiedTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbUsedBy = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.txtTemplateId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grdAttribute = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttribute)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 386);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 49);
            this.panel1.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(318, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
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
            this.btnSave.Location = new System.Drawing.Point(237, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Tag = "rsid:Button.R00001";
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(631, 386);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdAttribute);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnAdd);
            this.tabPage1.Controls.Add(this.txtLastModifiedTime);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtLastModifiedUser);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cmbUsedBy);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtTemplateName);
            this.tabPage1.Controls.Add(this.txtTemplateId);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(623, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "rsid:Label.R00007";
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 59;
            this.label2.Tag = "rsid:Label.R00335,isrq:N";
            this.label2.Text = "Default for Used By:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(461, 76);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Tag = "rsid:Label.R00335,isrq:N,maxl:64,updt:Y,dbfd:isdefault";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::GENLSYS.MES.Win.Properties.Resources.deleteline;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(522, 167);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::GENLSYS.MES.Win.Properties.Resources.addline;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(522, 137);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Location = new System.Drawing.Point(461, 100);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.ReadOnly = true;
            this.txtLastModifiedTime.Size = new System.Drawing.Size(136, 21);
            this.txtLastModifiedTime.TabIndex = 6;
            this.txtLastModifiedTime.Tag = "rsid:Label.R00013,isrq:N,maxl:64,updt:N,dbfd:lastmodifiedtime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 53;
            this.label1.Tag = "rsid:Label.R00013,isrq:N";
            this.label1.Text = "Last Modified Time:";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Location = new System.Drawing.Point(161, 100);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.ReadOnly = true;
            this.txtLastModifiedUser.Size = new System.Drawing.Size(131, 21);
            this.txtLastModifiedUser.TabIndex = 5;
            this.txtLastModifiedUser.Tag = "rsid:Label.R00012,isrq:N,maxl:64,updt:N,dbfd:lastmodifieduser";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 51;
            this.label5.Tag = "rsid:Label.R00012,isrq:N";
            this.label5.Text = "Last Modified User:";
            // 
            // cmbUsedBy
            // 
            this.cmbUsedBy.FormattingEnabled = true;
            this.cmbUsedBy.Location = new System.Drawing.Point(161, 74);
            this.cmbUsedBy.Name = "cmbUsedBy";
            this.cmbUsedBy.Size = new System.Drawing.Size(131, 20);
            this.cmbUsedBy.TabIndex = 3;
            this.cmbUsedBy.Tag = "rsid:Label.R00004,isrq:Y,updt:Y,dbfd:usedby";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 49;
            this.label8.Tag = "rsid:Label.R00004,isrq:Y";
            this.label8.Text = "Used By:";
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Location = new System.Drawing.Point(161, 47);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(436, 21);
            this.txtTemplateName.TabIndex = 2;
            this.txtTemplateName.Tag = "rsid:Label.R00331,isrq:Y,maxl:64,updt:Y,dbfd:attrtplatname";
            // 
            // txtTemplateId
            // 
            this.txtTemplateId.Location = new System.Drawing.Point(161, 20);
            this.txtTemplateId.Name = "txtTemplateId";
            this.txtTemplateId.Size = new System.Drawing.Size(204, 21);
            this.txtTemplateId.TabIndex = 1;
            this.txtTemplateId.Tag = "rsid:Label.R00330,isrq:Y,maxl:64,updt:Y,dbfd:attrtplatid";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 46;
            this.label7.Tag = "rsid:Label.R00331,isrq:Y";
            this.label7.Text = "Template Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 45;
            this.label6.Tag = "rsid:Label.R00330,isrq:Y";
            this.label6.Text = "Template ID";
            // 
            // grdAttribute
            // 
            this.grdAttribute.Location = new System.Drawing.Point(22, 137);
            this.grdAttribute.Name = "grdAttribute";
            this.grdAttribute.Size = new System.Drawing.Size(486, 208);
            this.grdAttribute.TabIndex = 60;
            this.grdAttribute.Tag = "rsid:Label.R00517,colw:70|rsid:Label.R00001|rsid:Label.R00002|rsid:Label.R00003";
            this.grdAttribute.Text = "ultraGrid1";
            this.grdAttribute.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdAttribute_InitializeLayout);
            // 
            // frmAttributeAttemplateEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 435);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAttributeAttemplateEdit";
            this.ShowInTaskbar = false;
            this.Tag = "rsid:Label.R00006";
            this.Text = "frmAttributeAttemplateEdit";
            this.Load += new System.EventHandler(this.frmAttributeAttemplateEdit_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttribute)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtLastModifiedTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbUsedBy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTemplateName;
        private System.Windows.Forms.TextBox txtTemplateId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdAttribute;

    }
}
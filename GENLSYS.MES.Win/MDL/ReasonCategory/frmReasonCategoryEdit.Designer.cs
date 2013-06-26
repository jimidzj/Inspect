namespace GENLSYS.MES.Win.MDL.ReasonCategory
{
    partial class frmReasonCategoryEdit
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
            this.txtLocationDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLocationId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 260);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 49);
            this.panel1.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(216, 14);
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
            this.btnSave.Location = new System.Drawing.Point(135, 14);
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
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(426, 260);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLastModifiedTime);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtLastModifiedUser);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtLocationDesc);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtLocationId);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(418, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "rsid:Label.R00007";
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Location = new System.Drawing.Point(175, 156);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.ReadOnly = true;
            this.txtLastModifiedTime.Size = new System.Drawing.Size(217, 21);
            this.txtLastModifiedTime.TabIndex = 5;
            this.txtLastModifiedTime.Tag = "rsid:Label.R00013,isrq:N,maxl:64,updt:N,dbfd:lastmodifiedtime";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 34;
            this.label6.Tag = "rsid:Label.R00013,isrq:N";
            this.label6.Text = "Last Modified Time:";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Location = new System.Drawing.Point(175, 129);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.ReadOnly = true;
            this.txtLastModifiedUser.Size = new System.Drawing.Size(217, 21);
            this.txtLastModifiedUser.TabIndex = 4;
            this.txtLastModifiedUser.Tag = "rsid:Label.R00012,isrq:N,maxl:64,updt:N,dbfd:lastmodifieduser";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 32;
            this.label5.Tag = "rsid:Label.R00012,isrq:N";
            this.label5.Text = "Last Modified User:";
            // 
            // txtLocationDesc
            // 
            this.txtLocationDesc.Location = new System.Drawing.Point(175, 47);
            this.txtLocationDesc.Multiline = true;
            this.txtLocationDesc.Name = "txtLocationDesc";
            this.txtLocationDesc.Size = new System.Drawing.Size(217, 76);
            this.txtLocationDesc.TabIndex = 2;
            this.txtLocationDesc.Tag = "rsid:Label.R00036,isrq:Y,maxl:250,updt:Y,dbfd:reasoncategorydesc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 30;
            this.label4.Tag = "rsid:Label.R00036,isrq:Y";
            this.label4.Text = "Description:";
            // 
            // txtLocationId
            // 
            this.txtLocationId.Location = new System.Drawing.Point(175, 20);
            this.txtLocationId.Name = "txtLocationId";
            this.txtLocationId.Size = new System.Drawing.Size(217, 21);
            this.txtLocationId.TabIndex = 1;
            this.txtLocationId.Tag = "rsid:Label.R00035,isrq:Y,maxl:64,updt:Y,dbfd:reasoncategory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 15;
            this.label1.Tag = "rsid:Label.R00035,isrq:Y";
            this.label1.Text = "Reason Category:";
            // 
            // frmReasonCategoryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 309);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReasonCategoryEdit";
            this.ShowInTaskbar = false;
            this.Tag = "rsid:Label.R00038";
            this.Text = "frmReasonCategoryEdit";
            this.Load += new System.EventHandler(this.frmReasonCategoryEdit_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtLocationDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLocationId;
        private System.Windows.Forms.Label label1;

    }
}
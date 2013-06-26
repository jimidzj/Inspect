namespace GENLSYS.MES.Win.SYS.SystemConfig
{
    partial class frmSystemConfigEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtConfigDesc = new System.Windows.Forms.TextBox();
            this.txtConfigValue = new System.Windows.Forms.TextBox();
            this.txtLastModifiedTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfigName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.panel1.Location = new System.Drawing.Point(0, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 49);
            this.panel1.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(217, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
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
            this.btnSave.Location = new System.Drawing.Point(136, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
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
            this.tabControl1.Size = new System.Drawing.Size(429, 341);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtConfigDesc);
            this.tabPage1.Controls.Add(this.txtConfigValue);
            this.tabPage1.Controls.Add(this.txtLastModifiedTime);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtLastModifiedUser);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtConfigName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(421, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "rsid:Label.R00007";
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtConfigDesc
            // 
            this.txtConfigDesc.Location = new System.Drawing.Point(175, 47);
            this.txtConfigDesc.Multiline = true;
            this.txtConfigDesc.Name = "txtConfigDesc";
            this.txtConfigDesc.Size = new System.Drawing.Size(217, 71);
            this.txtConfigDesc.TabIndex = 2;
            this.txtConfigDesc.Tag = "rsid:Label.R00479,isrq:N,updt:Y,dbfd:configdesc";
            // 
            // txtConfigValue
            // 
            this.txtConfigValue.Location = new System.Drawing.Point(175, 124);
            this.txtConfigValue.Multiline = true;
            this.txtConfigValue.Name = "txtConfigValue";
            this.txtConfigValue.Size = new System.Drawing.Size(217, 66);
            this.txtConfigValue.TabIndex = 3;
            this.txtConfigValue.Tag = "rsid:Label.R00480,isrq:N,maxl:64,updt:Y,dbfd:configvalue";
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Location = new System.Drawing.Point(175, 250);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.ReadOnly = true;
            this.txtLastModifiedTime.Size = new System.Drawing.Size(217, 21);
            this.txtLastModifiedTime.TabIndex = 6;
            this.txtLastModifiedTime.Tag = "rsid:Label.R00013,isrq:N,maxl:64,updt:N,dbfd:lastmodifiedtime";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 34;
            this.label6.Tag = "rsid:Label.R00013,isrq:N";
            this.label6.Text = "Last Modified Time:";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Location = new System.Drawing.Point(175, 223);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.ReadOnly = true;
            this.txtLastModifiedUser.Size = new System.Drawing.Size(217, 21);
            this.txtLastModifiedUser.TabIndex = 5;
            this.txtLastModifiedUser.Tag = "rsid:Label.R00012,isrq:N,maxl:64,updt:N,dbfd:lastmodifieduser";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 32;
            this.label5.Tag = "rsid:Label.R00012,isrq:N";
            this.label5.Text = "Last Modified User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 30;
            this.label4.Tag = "rsid:Label.R00480,isrq:N";
            this.label4.Text = "Config Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 17;
            this.label2.Tag = "rsid:Label.R00479,isrq:N";
            this.label2.Text = "Config Desc:";
            // 
            // txtConfigName
            // 
            this.txtConfigName.Location = new System.Drawing.Point(175, 20);
            this.txtConfigName.Name = "txtConfigName";
            this.txtConfigName.Size = new System.Drawing.Size(217, 21);
            this.txtConfigName.TabIndex = 1;
            this.txtConfigName.Tag = "rsid:Label.R00478,isrq:Y,maxl:64,updt:Y,dbfd:configname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 15;
            this.label1.Tag = "rsid:Label.R00478,isrq:Y";
            this.label1.Text = "Config Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(175, 196);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.Tag = "rsid:Label.R00652,isrq:Y,maxl:64,updt:Y,dbfd:configcategory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 36;
            this.label3.Tag = "rsid:Label.R00652,isrq:Y";
            this.label3.Text = "Config Category:";
            // 
            // frmSystemConfigEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 390);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmSystemConfigEdit";
            this.ShowInTaskbar = false;
            this.Text = "frmSystemConfigEdit";
            this.Load += new System.EventHandler(this.frmSystemConfigEdit_Load);
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
        private System.Windows.Forms.TextBox txtConfigDesc;
        private System.Windows.Forms.TextBox txtConfigValue;
        private System.Windows.Forms.TextBox txtLastModifiedTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConfigName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;

    }
}
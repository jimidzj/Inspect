namespace GENLSYS.MES.Win.INP.OtherPricing
{
    partial class frmOtherPricing
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtExpiredDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.cmbCustomerId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btSaveContinue = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbUnit);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numPrice);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtExpiredDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtEffectiveDate);
            this.groupBox1.Controls.Add(this.cmbCurrency);
            this.groupBox1.Controls.Add(this.cmbCustomerId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 130);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 4;
            this.numPrice.Location = new System.Drawing.Point(107, 63);
            this.numPrice.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(164, 21);
            this.numPrice.TabIndex = 25;
            this.numPrice.Tag = "rsid:Label.R01041,isrq:Y,maxl:64,updt:Y,dbfd:price";
            this.numPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 24;
            this.label8.Tag = "rsid:Label.R01041,isrq:Y";
            this.label8.Text = "Rate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 19;
            this.label4.Tag = "rsid:Label.R01039,isrq:Y";
            this.label4.Text = "Expired Date:";
            // 
            // dtExpiredDate
            // 
            this.dtExpiredDate.Location = new System.Drawing.Point(402, 93);
            this.dtExpiredDate.Name = "dtExpiredDate";
            this.dtExpiredDate.Size = new System.Drawing.Size(164, 21);
            this.dtExpiredDate.TabIndex = 18;
            this.dtExpiredDate.Tag = "rsid:Label.R01039,maxl:64,updt:Y,dbfd:expireddate,dbty:datetime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 17;
            this.label2.Tag = "rsid:Label.R01038,isrq:Y";
            this.label2.Text = "Effective Date:";
            // 
            // dtEffectiveDate
            // 
            this.dtEffectiveDate.Location = new System.Drawing.Point(107, 91);
            this.dtEffectiveDate.Name = "dtEffectiveDate";
            this.dtEffectiveDate.Size = new System.Drawing.Size(164, 21);
            this.dtEffectiveDate.TabIndex = 16;
            this.dtEffectiveDate.Tag = "rsid:Label.R01038,maxl:64,updt:Y,dbfd:effectivedate,dbty:datetime";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(107, 38);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(164, 20);
            this.cmbCurrency.TabIndex = 15;
            this.cmbCurrency.Tag = "rsid:Label.R01040,maxl:64,updt:Y,dbfd:currency,dbty:string";
            // 
            // cmbCustomerId
            // 
            this.cmbCustomerId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerId.FormattingEnabled = true;
            this.cmbCustomerId.Location = new System.Drawing.Point(107, 12);
            this.cmbCustomerId.Name = "cmbCustomerId";
            this.cmbCustomerId.Size = new System.Drawing.Size(164, 20);
            this.cmbCustomerId.TabIndex = 14;
            this.cmbCustomerId.Tag = "rsid:Label.R01020,maxl:64,updt:Y,dbfd:customerid,dbty:string";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 13;
            this.label3.Tag = "rsid:Label.R01020,isrq:Y";
            this.label3.Text = "Customer:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 12;
            this.label1.Tag = "rsid:Label.R01040,isrq:Y";
            this.label1.Text = "Currency:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btSaveContinue);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 41);
            this.panel2.TabIndex = 34;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(157, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 12;
            this.btnSave.Tag = "rsid:Button.R00001";
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(350, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(402, 11);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(164, 21);
            this.txtItemName.TabIndex = 27;
            this.txtItemName.Tag = "rsid:Label.R0104401,maxl:64,updt:Y,dbfd:itemname,dbty:string";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 26;
            this.label5.Tag = "rsid:Label.R0104401,isrq:Y";
            this.label5.Text = "Item Name:";
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(402, 38);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(164, 20);
            this.cmbUnit.TabIndex = 29;
            this.cmbUnit.Tag = "rsid:Label.R01042,maxl:64,updt:Y,dbfd:unit,dbty:string";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 28;
            this.label6.Tag = "rsid:Label.R01042,isrq:Y";
            this.label6.Text = "Unit:";
            // 
            // btSaveContinue
            // 
            this.btSaveContinue.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btSaveContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSaveContinue.Location = new System.Drawing.Point(238, 10);
            this.btSaveContinue.Name = "btSaveContinue";
            this.btSaveContinue.Size = new System.Drawing.Size(106, 21);
            this.btSaveContinue.TabIndex = 14;
            this.btSaveContinue.Tag = "rsid:Button.R00050";
            this.btSaveContinue.Text = "&Save Continue";
            this.btSaveContinue.UseVisualStyleBackColor = true;
            this.btSaveContinue.Click += new System.EventHandler(this.btSaveContinue_Click);
            // 
            // frmOtherPricing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 171);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOtherPricing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "rsid:Menu.M200210";
            this.Text = "frmOtherPricing";
            this.Load += new System.EventHandler(this.frmOtherPricing_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtExpiredDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtEffectiveDate;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.ComboBox cmbCustomerId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btSaveContinue;
    }
}
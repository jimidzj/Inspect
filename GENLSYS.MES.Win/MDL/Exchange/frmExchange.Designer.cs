namespace GENLSYS.MES.Win.MDL.Exchange
{
    partial class frmExchange
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbToCurrency = new System.Windows.Forms.ComboBox();
            this.cmbFromCurrency = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.numRate = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 41);
            this.panel2.TabIndex = 32;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(69, 10);
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
            this.btnCancel.Location = new System.Drawing.Point(150, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numRate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtExpiryDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtStartDate);
            this.groupBox1.Controls.Add(this.cmbToCurrency);
            this.groupBox1.Controls.Add(this.cmbFromCurrency);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 150);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // cmbToCurrency
            // 
            this.cmbToCurrency.FormattingEnabled = true;
            this.cmbToCurrency.Location = new System.Drawing.Point(107, 38);
            this.cmbToCurrency.Name = "cmbToCurrency";
            this.cmbToCurrency.Size = new System.Drawing.Size(164, 20);
            this.cmbToCurrency.TabIndex = 15;
            this.cmbToCurrency.Tag = "rsid:Label.R00702,maxl:64,updt:Y,dbfd:tocurrency,dbty:string";
            // 
            // cmbFromCurrency
            // 
            this.cmbFromCurrency.FormattingEnabled = true;
            this.cmbFromCurrency.Location = new System.Drawing.Point(107, 12);
            this.cmbFromCurrency.Name = "cmbFromCurrency";
            this.cmbFromCurrency.Size = new System.Drawing.Size(164, 20);
            this.cmbFromCurrency.TabIndex = 14;
            this.cmbFromCurrency.Tag = "rsid:Label.R00701,maxl:64,updt:Y,dbfd:fromcurrency,dbty:string";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 13;
            this.label3.Tag = "rsid:Label.R00701,isrq:Y";
            this.label3.Text = "From Currency:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 12;
            this.label1.Tag = "rsid:Label.R00702,isrq:Y";
            this.label1.Text = "To Currency:";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(107, 64);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(164, 21);
            this.dtStartDate.TabIndex = 16;
            this.dtStartDate.Tag = "rsid:Label.R00703,maxl:64,updt:Y,dbfd:startdate,dbty:datetime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 17;
            this.label2.Tag = "rsid:Label.R00703,isrq:Y";
            this.label2.Text = "Start Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 19;
            this.label4.Tag = "rsid:Label.R00704,isrq:Y";
            this.label4.Text = "Expiry Date:";
            // 
            // dtExpiryDate
            // 
            this.dtExpiryDate.Location = new System.Drawing.Point(107, 91);
            this.dtExpiryDate.Name = "dtExpiryDate";
            this.dtExpiryDate.Size = new System.Drawing.Size(164, 21);
            this.dtExpiryDate.TabIndex = 18;
            this.dtExpiryDate.Tag = "rsid:Label.R00704,maxl:64,updt:Y,dbfd:expirydate,dbty:datetime";
            // 
            // numRate
            // 
            this.numRate.DecimalPlaces = 4;
            this.numRate.Location = new System.Drawing.Point(107, 119);
            this.numRate.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numRate.Name = "numRate";
            this.numRate.Size = new System.Drawing.Size(164, 21);
            this.numRate.TabIndex = 25;
            this.numRate.Tag = "rsid:Label.R00705,isrq:Y,maxl:64,updt:Y,dbfd:rate";
            this.numRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 24;
            this.label8.Tag = "rsid:Label.R00705,isrq:Y";
            this.label8.Text = "Rate:";
            // 
            // frmExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 191);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExchange";
            this.Tag = "rsid:Menu.M100180";
            this.Text = "frmExchange";
            this.Load += new System.EventHandler(this.frmExchange_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbToCurrency;
        private System.Windows.Forms.ComboBox cmbFromCurrency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtExpiryDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.NumericUpDown numRate;
        private System.Windows.Forms.Label label8;
    }
}
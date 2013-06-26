namespace GENLSYS.MES.Win.MDL.Customer
{
    partial class frmCustomerQuery
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupCustomer = new System.Windows.Forms.GroupBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoiceTitle = new System.Windows.Forms.TextBox();
            this.lblInvoiceTitle = new System.Windows.Forms.Label();
            this.cmbInvoiceType = new System.Windows.Forms.ComboBox();
            this.lblInvoiceType = new System.Windows.Forms.Label();
            this.cmbTaxType = new System.Windows.Forms.ComboBox();
            this.lblTaxType = new System.Windows.Forms.Label();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.lblShortName = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(180, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::GENLSYS.MES.Win.Properties.Resources.query;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(99, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 21);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Tag = "rsid:Button.R00003";
            this.btnQuery.Text = "&Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 40);
            this.panel1.TabIndex = 7;
            // 
            // groupCustomer
            // 
            this.groupCustomer.Controls.Add(this.txtCustomerName);
            this.groupCustomer.Controls.Add(this.label1);
            this.groupCustomer.Controls.Add(this.txtInvoiceTitle);
            this.groupCustomer.Controls.Add(this.lblInvoiceTitle);
            this.groupCustomer.Controls.Add(this.cmbInvoiceType);
            this.groupCustomer.Controls.Add(this.lblInvoiceType);
            this.groupCustomer.Controls.Add(this.cmbTaxType);
            this.groupCustomer.Controls.Add(this.lblTaxType);
            this.groupCustomer.Controls.Add(this.cmbCustomerType);
            this.groupCustomer.Controls.Add(this.lblCustomerType);
            this.groupCustomer.Controls.Add(this.txtShortName);
            this.groupCustomer.Controls.Add(this.lblShortName);
            this.groupCustomer.Controls.Add(this.txtCustomerId);
            this.groupCustomer.Controls.Add(this.lblCustomerId);
            this.groupCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupCustomer.Location = new System.Drawing.Point(0, 0);
            this.groupCustomer.Name = "groupCustomer";
            this.groupCustomer.Size = new System.Drawing.Size(362, 212);
            this.groupCustomer.TabIndex = 8;
            this.groupCustomer.TabStop = false;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(126, 20);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(189, 21);
            this.txtCustomerName.TabIndex = 45;
            this.txtCustomerName.Tag = "rsid:Label.R00043,maxl:64,dbfd:customername,dbty:string";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 44;
            this.label1.Tag = "rsid:Label.R00043";
            this.label1.Text = "Customer Name";
            // 
            // txtInvoiceTitle
            // 
            this.txtInvoiceTitle.Location = new System.Drawing.Point(126, 179);
            this.txtInvoiceTitle.Name = "txtInvoiceTitle";
            this.txtInvoiceTitle.Size = new System.Drawing.Size(189, 21);
            this.txtInvoiceTitle.TabIndex = 43;
            this.txtInvoiceTitle.Tag = "rsid:Label.R00049,maxl:255,dbfd:invoicetitle,dbty:string";
            // 
            // lblInvoiceTitle
            // 
            this.lblInvoiceTitle.AutoSize = true;
            this.lblInvoiceTitle.Location = new System.Drawing.Point(20, 182);
            this.lblInvoiceTitle.Name = "lblInvoiceTitle";
            this.lblInvoiceTitle.Size = new System.Drawing.Size(83, 12);
            this.lblInvoiceTitle.TabIndex = 42;
            this.lblInvoiceTitle.Tag = "rsid:Label.R00049";
            this.lblInvoiceTitle.Text = "Invoice Title";
            // 
            // cmbInvoiceType
            // 
            this.cmbInvoiceType.FormattingEnabled = true;
            this.cmbInvoiceType.Location = new System.Drawing.Point(126, 153);
            this.cmbInvoiceType.Name = "cmbInvoiceType";
            this.cmbInvoiceType.Size = new System.Drawing.Size(189, 20);
            this.cmbInvoiceType.TabIndex = 41;
            this.cmbInvoiceType.Tag = "rsid:Label.R00050,dbfd:invoicetype,dbty:string";
            // 
            // lblInvoiceType
            // 
            this.lblInvoiceType.AutoSize = true;
            this.lblInvoiceType.Location = new System.Drawing.Point(20, 156);
            this.lblInvoiceType.Name = "lblInvoiceType";
            this.lblInvoiceType.Size = new System.Drawing.Size(77, 12);
            this.lblInvoiceType.TabIndex = 40;
            this.lblInvoiceType.Tag = "rsid:Label.R00050";
            this.lblInvoiceType.Text = "Invoice Type";
            // 
            // cmbTaxType
            // 
            this.cmbTaxType.FormattingEnabled = true;
            this.cmbTaxType.Location = new System.Drawing.Point(126, 127);
            this.cmbTaxType.Name = "cmbTaxType";
            this.cmbTaxType.Size = new System.Drawing.Size(189, 20);
            this.cmbTaxType.TabIndex = 39;
            this.cmbTaxType.Tag = "rsid:Label.R00052,dbfd:taxtype,dbty:string";
            // 
            // lblTaxType
            // 
            this.lblTaxType.AutoSize = true;
            this.lblTaxType.Location = new System.Drawing.Point(20, 130);
            this.lblTaxType.Name = "lblTaxType";
            this.lblTaxType.Size = new System.Drawing.Size(53, 12);
            this.lblTaxType.TabIndex = 38;
            this.lblTaxType.Tag = "rsid:Label.R00052";
            this.lblTaxType.Text = "Tax Type";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(126, 101);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(189, 20);
            this.cmbCustomerType.TabIndex = 37;
            this.cmbCustomerType.Tag = "rsid:Label.R00055,dbfd:customertype,dbty:string";
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Location = new System.Drawing.Point(20, 104);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(83, 12);
            this.lblCustomerType.TabIndex = 36;
            this.lblCustomerType.Tag = "rsid:Label.R00055";
            this.lblCustomerType.Text = "Customer Type";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(126, 74);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(189, 21);
            this.txtShortName.TabIndex = 21;
            this.txtShortName.Tag = "rsid:Label.R00044,maxl:255,dbfd:short_name,dbty:string";
            // 
            // lblShortName
            // 
            this.lblShortName.AutoSize = true;
            this.lblShortName.Location = new System.Drawing.Point(20, 77);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(65, 12);
            this.lblShortName.TabIndex = 20;
            this.lblShortName.Tag = "rsid:Label.R00044";
            this.lblShortName.Text = "Short Name";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(126, 47);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(189, 21);
            this.txtCustomerId.TabIndex = 17;
            this.txtCustomerId.Tag = "rsid:Label.R00042,maxl:64,dbfd:customerid,dbty:string";
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(20, 50);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(71, 12);
            this.lblCustomerId.TabIndex = 16;
            this.lblCustomerId.Tag = "rsid:Label.R00042";
            this.lblCustomerId.Text = "Customer Id";
            // 
            // frmCustomerQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 252);
            this.Controls.Add(this.groupCustomer);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerQuery";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "rsid:Label.R00065";
            this.Text = "frmCustomerQuery";
            this.Load += new System.EventHandler(this.frmCustomerQuery_Load);
            this.panel1.ResumeLayout(false);
            this.groupCustomer.ResumeLayout(false);
            this.groupCustomer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupCustomer;
        private System.Windows.Forms.TextBox txtInvoiceTitle;
        private System.Windows.Forms.Label lblInvoiceTitle;
        private System.Windows.Forms.ComboBox cmbInvoiceType;
        private System.Windows.Forms.Label lblInvoiceType;
        private System.Windows.Forms.ComboBox cmbTaxType;
        private System.Windows.Forms.Label lblTaxType;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label lblCustomerType;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Label lblShortName;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label1;
    }
}
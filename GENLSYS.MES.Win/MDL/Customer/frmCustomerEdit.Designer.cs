namespace GENLSYS.MES.Win.MDL.Customer
{
    partial class frmCustomerEdit
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerEdit));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControlCustomer = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.txtLastModifiedTime = new System.Windows.Forms.TextBox();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.lblLastModifiedTime = new System.Windows.Forms.Label();
            this.lblLastModifiedUser = new System.Windows.Forms.Label();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.cmbTaxType = new System.Windows.Forms.ComboBox();
            this.lblTaxType = new System.Windows.Forms.Label();
            this.cmbInvoiceType = new System.Windows.Forms.ComboBox();
            this.lblInvoiceType = new System.Windows.Forms.Label();
            this.txtPaymentCondition = new System.Windows.Forms.TextBox();
            this.lblPaymentCondition = new System.Windows.Forms.Label();
            this.txtInvoiceTitle = new System.Windows.Forms.TextBox();
            this.lblInvoiceTitle = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.lblShortName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.tabAddress = new System.Windows.Forms.TabPage();
            this.txtComment2 = new System.Windows.Forms.TextBox();
            this.lblComment2 = new System.Windows.Forms.Label();
            this.txtComment1 = new System.Windows.Forms.TextBox();
            this.lblComment1 = new System.Windows.Forms.Label();
            this.lblFax2 = new System.Windows.Forms.Label();
            this.txtInvoiceToAddress = new System.Windows.Forms.TextBox();
            this.lblInvoiceToAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tabContact = new System.Windows.Forms.TabPage();
            this.grdContact = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.tabControlCustomer.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabAddress.SuspendLayout();
            this.tabContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(320, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(239, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 4;
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
            this.panel1.Location = new System.Drawing.Point(0, 308);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 45);
            this.panel1.TabIndex = 6;
            // 
            // tabControlCustomer
            // 
            this.tabControlCustomer.Controls.Add(this.tabGeneral);
            this.tabControlCustomer.Controls.Add(this.tabAddress);
            this.tabControlCustomer.Controls.Add(this.tabContact);
            this.tabControlCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCustomer.Location = new System.Drawing.Point(0, 0);
            this.tabControlCustomer.Name = "tabControlCustomer";
            this.tabControlCustomer.SelectedIndex = 0;
            this.tabControlCustomer.Size = new System.Drawing.Size(642, 308);
            this.tabControlCustomer.TabIndex = 7;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.txtLastModifiedTime);
            this.tabGeneral.Controls.Add(this.txtLastModifiedUser);
            this.tabGeneral.Controls.Add(this.lblLastModifiedTime);
            this.tabGeneral.Controls.Add(this.lblLastModifiedUser);
            this.tabGeneral.Controls.Add(this.cmbCustomerType);
            this.tabGeneral.Controls.Add(this.lblCustomerType);
            this.tabGeneral.Controls.Add(this.cmbCurrency);
            this.tabGeneral.Controls.Add(this.lblCurrency);
            this.tabGeneral.Controls.Add(this.cmbTaxType);
            this.tabGeneral.Controls.Add(this.lblTaxType);
            this.tabGeneral.Controls.Add(this.cmbInvoiceType);
            this.tabGeneral.Controls.Add(this.lblInvoiceType);
            this.tabGeneral.Controls.Add(this.txtPaymentCondition);
            this.tabGeneral.Controls.Add(this.lblPaymentCondition);
            this.tabGeneral.Controls.Add(this.txtInvoiceTitle);
            this.tabGeneral.Controls.Add(this.lblInvoiceTitle);
            this.tabGeneral.Controls.Add(this.txtShortName);
            this.tabGeneral.Controls.Add(this.lblShortName);
            this.tabGeneral.Controls.Add(this.txtCustomerName);
            this.tabGeneral.Controls.Add(this.lblCustomerName);
            this.tabGeneral.Controls.Add(this.txtCustomerId);
            this.tabGeneral.Controls.Add(this.lblCustomerId);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(634, 282);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Tag = "rsid:Tab.R00001";
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Enabled = false;
            this.txtLastModifiedTime.Location = new System.Drawing.Point(449, 224);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.Size = new System.Drawing.Size(150, 21);
            this.txtLastModifiedTime.TabIndex = 39;
            this.txtLastModifiedTime.Tag = "rsid:label.r00013,dbfd:lastmodifiedtime";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Enabled = false;
            this.txtLastModifiedUser.Location = new System.Drawing.Point(151, 224);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.Size = new System.Drawing.Size(150, 21);
            this.txtLastModifiedUser.TabIndex = 38;
            this.txtLastModifiedUser.Tag = "rsid:label.r00012,dbfd:lastmodifieduser";
            // 
            // lblLastModifiedTime
            // 
            this.lblLastModifiedTime.AutoSize = true;
            this.lblLastModifiedTime.Location = new System.Drawing.Point(321, 224);
            this.lblLastModifiedTime.Name = "lblLastModifiedTime";
            this.lblLastModifiedTime.Size = new System.Drawing.Size(113, 12);
            this.lblLastModifiedTime.TabIndex = 37;
            this.lblLastModifiedTime.Tag = "rsid:Label.R00013";
            this.lblLastModifiedTime.Text = "Last Modified Time";
            // 
            // lblLastModifiedUser
            // 
            this.lblLastModifiedUser.AutoSize = true;
            this.lblLastModifiedUser.Location = new System.Drawing.Point(23, 224);
            this.lblLastModifiedUser.Name = "lblLastModifiedUser";
            this.lblLastModifiedUser.Size = new System.Drawing.Size(113, 12);
            this.lblLastModifiedUser.TabIndex = 36;
            this.lblLastModifiedUser.Tag = "rsid:Label.R00012";
            this.lblLastModifiedUser.Text = "Last Modified User";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(449, 195);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(150, 20);
            this.cmbCustomerType.TabIndex = 35;
            this.cmbCustomerType.Tag = "rsid:Label.R00055,isrq:N,updt:Y,dbfd:customertype";
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Location = new System.Drawing.Point(321, 195);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(83, 12);
            this.lblCustomerType.TabIndex = 34;
            this.lblCustomerType.Tag = "rsid:Label.R00055,isrq:N";
            this.lblCustomerType.Text = "Customer Type";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(449, 169);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(150, 20);
            this.cmbCurrency.TabIndex = 31;
            this.cmbCurrency.Tag = "rsid:Label.R00053,isrq:N,updt:Y,dbfd:currency";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(321, 169);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(53, 12);
            this.lblCurrency.TabIndex = 30;
            this.lblCurrency.Tag = "rsid:Label.R00053,isrq:N";
            this.lblCurrency.Text = "Currency";
            // 
            // cmbTaxType
            // 
            this.cmbTaxType.FormattingEnabled = true;
            this.cmbTaxType.Location = new System.Drawing.Point(150, 169);
            this.cmbTaxType.Name = "cmbTaxType";
            this.cmbTaxType.Size = new System.Drawing.Size(150, 20);
            this.cmbTaxType.TabIndex = 29;
            this.cmbTaxType.Tag = "rsid:Label.R00052,isrq:N,updt:Y,dbfd:taxtype";
            // 
            // lblTaxType
            // 
            this.lblTaxType.AutoSize = true;
            this.lblTaxType.Location = new System.Drawing.Point(22, 169);
            this.lblTaxType.Name = "lblTaxType";
            this.lblTaxType.Size = new System.Drawing.Size(53, 12);
            this.lblTaxType.TabIndex = 28;
            this.lblTaxType.Tag = "rsid:Label.R00052,isrq:N";
            this.lblTaxType.Text = "Tax Type";
            // 
            // cmbInvoiceType
            // 
            this.cmbInvoiceType.FormattingEnabled = true;
            this.cmbInvoiceType.Location = new System.Drawing.Point(151, 195);
            this.cmbInvoiceType.Name = "cmbInvoiceType";
            this.cmbInvoiceType.Size = new System.Drawing.Size(150, 20);
            this.cmbInvoiceType.TabIndex = 27;
            this.cmbInvoiceType.Tag = "rsid:Label.R00050,isrq:N,updt:Y,dbfd:invoicetype";
            // 
            // lblInvoiceType
            // 
            this.lblInvoiceType.AutoSize = true;
            this.lblInvoiceType.Location = new System.Drawing.Point(22, 195);
            this.lblInvoiceType.Name = "lblInvoiceType";
            this.lblInvoiceType.Size = new System.Drawing.Size(77, 12);
            this.lblInvoiceType.TabIndex = 26;
            this.lblInvoiceType.Tag = "rsid:Label.R00050,isrq:N";
            this.lblInvoiceType.Text = "Invoice Type";
            // 
            // txtPaymentCondition
            // 
            this.txtPaymentCondition.Location = new System.Drawing.Point(150, 125);
            this.txtPaymentCondition.Multiline = true;
            this.txtPaymentCondition.Name = "txtPaymentCondition";
            this.txtPaymentCondition.Size = new System.Drawing.Size(449, 38);
            this.txtPaymentCondition.TabIndex = 25;
            this.txtPaymentCondition.Tag = "rsid:Label.R00051,maxl:1000,updt:Y,dbfd:paymentcondition";
            // 
            // lblPaymentCondition
            // 
            this.lblPaymentCondition.AutoSize = true;
            this.lblPaymentCondition.Location = new System.Drawing.Point(22, 128);
            this.lblPaymentCondition.Name = "lblPaymentCondition";
            this.lblPaymentCondition.Size = new System.Drawing.Size(107, 12);
            this.lblPaymentCondition.TabIndex = 24;
            this.lblPaymentCondition.Tag = "rsid:Label.R00051";
            this.lblPaymentCondition.Text = "Payment Condition";
            // 
            // txtInvoiceTitle
            // 
            this.txtInvoiceTitle.Location = new System.Drawing.Point(150, 98);
            this.txtInvoiceTitle.Name = "txtInvoiceTitle";
            this.txtInvoiceTitle.Size = new System.Drawing.Size(449, 21);
            this.txtInvoiceTitle.TabIndex = 23;
            this.txtInvoiceTitle.Tag = "rsid:Label.R00049,maxl:255,updt:Y,dbfd:invoicetitle";
            // 
            // lblInvoiceTitle
            // 
            this.lblInvoiceTitle.AutoSize = true;
            this.lblInvoiceTitle.Location = new System.Drawing.Point(21, 101);
            this.lblInvoiceTitle.Name = "lblInvoiceTitle";
            this.lblInvoiceTitle.Size = new System.Drawing.Size(83, 12);
            this.lblInvoiceTitle.TabIndex = 22;
            this.lblInvoiceTitle.Tag = "rsid:Label.R00049";
            this.lblInvoiceTitle.Text = "Invoice Title";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(449, 17);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(150, 21);
            this.txtShortName.TabIndex = 19;
            this.txtShortName.Tag = "rsid:Label.R00044,maxl:255,updt:Y,dbfd:short_name";
            // 
            // lblShortName
            // 
            this.lblShortName.AutoSize = true;
            this.lblShortName.Location = new System.Drawing.Point(321, 20);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(65, 12);
            this.lblShortName.TabIndex = 18;
            this.lblShortName.Tag = "rsid:Label.R00044,isrq:Y";
            this.lblShortName.Text = "Short Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(150, 44);
            this.txtCustomerName.Multiline = true;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(449, 48);
            this.txtCustomerName.TabIndex = 17;
            this.txtCustomerName.Tag = "rsid:Label.R00043,isrq:Y,maxl:500,updt:Y,dbfd:customername";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(20, 47);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(83, 12);
            this.lblCustomerName.TabIndex = 16;
            this.lblCustomerName.Tag = "rsid:Label.R00043,isrq:Y";
            this.lblCustomerName.Text = "Customer Name";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(150, 17);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(150, 21);
            this.txtCustomerId.TabIndex = 15;
            this.txtCustomerId.Tag = "rsid:Label.R00042,isrq:Y,maxl:64,updt:Y,dbfd:customerid";
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(20, 20);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(71, 12);
            this.lblCustomerId.TabIndex = 14;
            this.lblCustomerId.Tag = "rsid:Label.R00042,isrq:Y";
            this.lblCustomerId.Text = "Customer Id";
            // 
            // tabAddress
            // 
            this.tabAddress.Controls.Add(this.txtComment2);
            this.tabAddress.Controls.Add(this.lblComment2);
            this.tabAddress.Controls.Add(this.txtComment1);
            this.tabAddress.Controls.Add(this.lblComment1);
            this.tabAddress.Controls.Add(this.lblFax2);
            this.tabAddress.Controls.Add(this.txtInvoiceToAddress);
            this.tabAddress.Controls.Add(this.lblInvoiceToAddress);
            this.tabAddress.Controls.Add(this.txtAddress);
            this.tabAddress.Controls.Add(this.lblAddress);
            this.tabAddress.Location = new System.Drawing.Point(4, 22);
            this.tabAddress.Name = "tabAddress";
            this.tabAddress.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddress.Size = new System.Drawing.Size(634, 282);
            this.tabAddress.TabIndex = 1;
            this.tabAddress.Tag = "rsid:Tab.R00034";
            this.tabAddress.Text = "Address";
            this.tabAddress.UseVisualStyleBackColor = true;
            // 
            // txtComment2
            // 
            this.txtComment2.Location = new System.Drawing.Point(149, 151);
            this.txtComment2.Multiline = true;
            this.txtComment2.Name = "txtComment2";
            this.txtComment2.Size = new System.Drawing.Size(449, 47);
            this.txtComment2.TabIndex = 49;
            this.txtComment2.Tag = "rsid:Label.R00063,maxl:255,updt:Y,dbfd:comment2";
            // 
            // lblComment2
            // 
            this.lblComment2.AutoSize = true;
            this.lblComment2.Location = new System.Drawing.Point(20, 154);
            this.lblComment2.Name = "lblComment2";
            this.lblComment2.Size = new System.Drawing.Size(53, 12);
            this.lblComment2.TabIndex = 48;
            this.lblComment2.Tag = "rsid:Label.R00063";
            this.lblComment2.Text = "comment2";
            // 
            // txtComment1
            // 
            this.txtComment1.Location = new System.Drawing.Point(149, 98);
            this.txtComment1.Multiline = true;
            this.txtComment1.Name = "txtComment1";
            this.txtComment1.Size = new System.Drawing.Size(449, 47);
            this.txtComment1.TabIndex = 47;
            this.txtComment1.Tag = "rsid:Label.R00062,maxl:255,updt:Y,dbfd:comment1";
            // 
            // lblComment1
            // 
            this.lblComment1.AutoSize = true;
            this.lblComment1.Location = new System.Drawing.Point(20, 101);
            this.lblComment1.Name = "lblComment1";
            this.lblComment1.Size = new System.Drawing.Size(53, 12);
            this.lblComment1.TabIndex = 46;
            this.lblComment1.Tag = "rsid:Label.R00062";
            this.lblComment1.Text = "Comment1";
            // 
            // lblFax2
            // 
            this.lblFax2.AutoSize = true;
            this.lblFax2.Location = new System.Drawing.Point(930, 146);
            this.lblFax2.Name = "lblFax2";
            this.lblFax2.Size = new System.Drawing.Size(29, 12);
            this.lblFax2.TabIndex = 38;
            this.lblFax2.Tag = "rsid:Label.R00059";
            this.lblFax2.Text = "Fax2";
            this.lblFax2.Visible = false;
            // 
            // txtInvoiceToAddress
            // 
            this.txtInvoiceToAddress.Location = new System.Drawing.Point(149, 44);
            this.txtInvoiceToAddress.Multiline = true;
            this.txtInvoiceToAddress.Name = "txtInvoiceToAddress";
            this.txtInvoiceToAddress.Size = new System.Drawing.Size(449, 48);
            this.txtInvoiceToAddress.TabIndex = 31;
            this.txtInvoiceToAddress.Tag = "rsid:Label.R00048,maxl:1000,updt:Y,dbfd:invoicetoaddress";
            // 
            // lblInvoiceToAddress
            // 
            this.lblInvoiceToAddress.AutoSize = true;
            this.lblInvoiceToAddress.Location = new System.Drawing.Point(20, 47);
            this.lblInvoiceToAddress.Name = "lblInvoiceToAddress";
            this.lblInvoiceToAddress.Size = new System.Drawing.Size(113, 12);
            this.lblInvoiceToAddress.TabIndex = 30;
            this.lblInvoiceToAddress.Tag = "rsid:Label.R00048";
            this.lblInvoiceToAddress.Text = "Invoice To Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(149, 17);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(449, 21);
            this.txtAddress.TabIndex = 27;
            this.txtAddress.Tag = "rsid:Label.R00046,maxl:1000,updt:Y,dbfd:address";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 20);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(47, 12);
            this.lblAddress.TabIndex = 26;
            this.lblAddress.Tag = "rsid:Label.R00046";
            this.lblAddress.Text = "Address";
            // 
            // tabContact
            // 
            this.tabContact.Controls.Add(this.grdContact);
            this.tabContact.Controls.Add(this.toolStrip1);
            this.tabContact.Location = new System.Drawing.Point(4, 22);
            this.tabContact.Name = "tabContact";
            this.tabContact.Padding = new System.Windows.Forms.Padding(3);
            this.tabContact.Size = new System.Drawing.Size(634, 282);
            this.tabContact.TabIndex = 1;
            this.tabContact.Tag = "rsid:Tab.R00003";
            this.tabContact.Text = "Contact";
            this.tabContact.UseVisualStyleBackColor = true;
            // 
            // grdContact
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdContact.DisplayLayout.Appearance = appearance1;
            this.grdContact.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdContact.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdContact.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdContact.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grdContact.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdContact.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.grdContact.DisplayLayout.MaxColScrollRegions = 1;
            this.grdContact.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdContact.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdContact.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.grdContact.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdContact.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.grdContact.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdContact.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdContact.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdContact.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grdContact.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.grdContact.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.grdContact.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdContact.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.grdContact.DisplayLayout.Override.RowAppearance = appearance10;
            this.grdContact.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdContact.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.grdContact.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdContact.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdContact.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContact.Location = new System.Drawing.Point(3, 28);
            this.grdContact.Name = "grdContact";
            this.grdContact.Size = new System.Drawing.Size(628, 251);
            this.grdContact.TabIndex = 32;
            this.grdContact.Tag = resources.GetString("grdContact.Tag");
            this.grdContact.Text = "ultraGrid1";
            this.grdContact.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdContact_InitializeLayout);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.toolStripSeparator1,
            this.tsbDelete});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(628, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::GENLSYS.MES.Win.Properties.Resources.addline;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(52, 22);
            this.tsbAdd.Tag = "rsid:Button.R00007";
            this.tsbAdd.Text = "新增";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::GENLSYS.MES.Win.Properties.Resources.deleteline;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(52, 22);
            this.tsbDelete.Tag = "rsid:Button.R00008";
            this.tsbDelete.Text = "删除";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // frmCustomerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 353);
            this.Controls.Add(this.tabControlCustomer);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "rsid:Label.R00065";
            this.Text = "frmCustomerEdit";
            this.Load += new System.EventHandler(this.frmCustomerEdit_Load);
            this.panel1.ResumeLayout(false);
            this.tabControlCustomer.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabAddress.ResumeLayout(false);
            this.tabAddress.PerformLayout();
            this.tabContact.ResumeLayout(false);
            this.tabContact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControlCustomer;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TextBox txtLastModifiedTime;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.Label lblLastModifiedTime;
        private System.Windows.Forms.Label lblLastModifiedUser;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label lblCustomerType;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.ComboBox cmbTaxType;
        private System.Windows.Forms.Label lblTaxType;
        private System.Windows.Forms.ComboBox cmbInvoiceType;
        private System.Windows.Forms.Label lblInvoiceType;
        private System.Windows.Forms.TextBox txtPaymentCondition;
        private System.Windows.Forms.Label lblPaymentCondition;
        private System.Windows.Forms.TextBox txtInvoiceTitle;
        private System.Windows.Forms.Label lblInvoiceTitle;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Label lblShortName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TabPage tabAddress;
        private System.Windows.Forms.TextBox txtComment2;
        private System.Windows.Forms.Label lblComment2;
        private System.Windows.Forms.TextBox txtComment1;
        private System.Windows.Forms.Label lblComment1;
        private System.Windows.Forms.Label lblFax2;
        private System.Windows.Forms.TextBox txtInvoiceToAddress;
        private System.Windows.Forms.Label lblInvoiceToAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TabPage tabContact;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdContact;
    }
}
namespace GENLSYS.MES.Win.INP.Ship
{
    partial class frmShipPlan
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numCommissionedWeight = new System.Windows.Forms.NumericUpDown();
            this.numCommissionedVolume = new System.Windows.Forms.NumericUpDown();
            this.numCommissionedQty = new System.Windows.Forms.NumericUpDown();
            this.txtVoyage = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUnloadPort = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDestinationPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartPort = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.weight = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInShipNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeliveryBill = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtLoadingDt = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShippingPlanNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdDetail = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCommissionedWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCommissionedVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCommissionedQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLoadingDt)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 427);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(733, 41);
            this.panel2.TabIndex = 33;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(288, 10);
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
            this.btnCancel.Location = new System.Drawing.Point(369, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.numCommissionedWeight);
            this.panel1.Controls.Add(this.numCommissionedVolume);
            this.panel1.Controls.Add(this.numCommissionedQty);
            this.panel1.Controls.Add(this.txtVoyage);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtUnloadPort);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtDestinationPort);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtStartPort);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.weight);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtInShipNo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDeliveryBill);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBoxQty);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dtLoadingDt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbCustomer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtShippingPlanNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 152);
            this.panel1.TabIndex = 34;
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.White;
            this.txtRemark.Location = new System.Drawing.Point(349, 119);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(362, 21);
            this.txtRemark.TabIndex = 60;
            this.txtRemark.Tag = "rsid:Label.R01098,maxl:250,updt:Y,dbfd:remark";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(253, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 59;
            this.label13.Tag = "rsid:Label.R01098";
            this.label13.Text = "remark:";
            // 
            // numCommissionedWeight
            // 
            this.numCommissionedWeight.DecimalPlaces = 2;
            this.numCommissionedWeight.Location = new System.Drawing.Point(591, 63);
            this.numCommissionedWeight.Name = "numCommissionedWeight";
            this.numCommissionedWeight.Size = new System.Drawing.Size(121, 21);
            this.numCommissionedWeight.TabIndex = 58;
            this.numCommissionedWeight.Tag = "rsid:Label.R01092,isrq:Y,maxl:64,updt:Y,dbfd:commissionedweight";
            // 
            // numCommissionedVolume
            // 
            this.numCommissionedVolume.DecimalPlaces = 2;
            this.numCommissionedVolume.Location = new System.Drawing.Point(350, 65);
            this.numCommissionedVolume.Name = "numCommissionedVolume";
            this.numCommissionedVolume.Size = new System.Drawing.Size(121, 21);
            this.numCommissionedVolume.TabIndex = 57;
            this.numCommissionedVolume.Tag = "rsid:Label.R01091,isrq:Y,maxl:64,updt:Y,dbfd:commissionedvolume";
            // 
            // numCommissionedQty
            // 
            this.numCommissionedQty.Location = new System.Drawing.Point(109, 63);
            this.numCommissionedQty.Name = "numCommissionedQty";
            this.numCommissionedQty.Size = new System.Drawing.Size(121, 21);
            this.numCommissionedQty.TabIndex = 56;
            this.numCommissionedQty.Tag = "rsid:Label.R01090,isrq:Y,maxl:64,updt:Y,dbfd:commissionedqty";
            // 
            // txtVoyage
            // 
            this.txtVoyage.BackColor = System.Drawing.Color.White;
            this.txtVoyage.Location = new System.Drawing.Point(109, 117);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(121, 21);
            this.txtVoyage.TabIndex = 55;
            this.txtVoyage.Tag = "rsid:Label.R01096,maxl:64,updt:Y,dbfd:voyage";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 54;
            this.label11.Tag = "rsid:Label.R01096";
            this.label11.Text = "voyage:";
            // 
            // txtUnloadPort
            // 
            this.txtUnloadPort.BackColor = System.Drawing.Color.White;
            this.txtUnloadPort.Location = new System.Drawing.Point(590, 90);
            this.txtUnloadPort.Name = "txtUnloadPort";
            this.txtUnloadPort.Size = new System.Drawing.Size(121, 21);
            this.txtUnloadPort.TabIndex = 53;
            this.txtUnloadPort.Tag = "rsid:Label.R01095,maxl:64,updt:Y,dbfd:unloadport";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(494, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 52;
            this.label12.Tag = "rsid:Label.R01095";
            this.label12.Text = "Unload Port:";
            // 
            // txtDestinationPort
            // 
            this.txtDestinationPort.BackColor = System.Drawing.Color.White;
            this.txtDestinationPort.Location = new System.Drawing.Point(350, 92);
            this.txtDestinationPort.Name = "txtDestinationPort";
            this.txtDestinationPort.Size = new System.Drawing.Size(121, 21);
            this.txtDestinationPort.TabIndex = 51;
            this.txtDestinationPort.Tag = "rsid:Label.R01094,maxl:64,updt:Y,dbfd:destinationport";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 50;
            this.label5.Tag = "rsid:Label.R01094";
            this.label5.Text = "Destination Port:";
            // 
            // txtStartPort
            // 
            this.txtStartPort.BackColor = System.Drawing.Color.White;
            this.txtStartPort.Location = new System.Drawing.Point(109, 90);
            this.txtStartPort.Name = "txtStartPort";
            this.txtStartPort.Size = new System.Drawing.Size(121, 21);
            this.txtStartPort.TabIndex = 49;
            this.txtStartPort.Tag = "rsid:Label.R01093,maxl:64,updt:Y,dbfd:startport";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 48;
            this.label10.Tag = "rsid:Label.R01093";
            this.label10.Text = "Start Port:";
            // 
            // weight
            // 
            this.weight.AutoSize = true;
            this.weight.Location = new System.Drawing.Point(494, 72);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(47, 12);
            this.weight.TabIndex = 46;
            this.weight.Tag = "rsid:Label.R01092,isrq:Y";
            this.weight.Text = "weight:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(253, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 44;
            this.label7.Tag = "rsid:Label.R01091,isrq:Y";
            this.label7.Text = "volume:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 42;
            this.label8.Tag = "rsid:Label.R01090,isrq:Y";
            this.label8.Text = "Qty:";
            // 
            // txtInShipNo
            // 
            this.txtInShipNo.BackColor = System.Drawing.Color.White;
            this.txtInShipNo.Location = new System.Drawing.Point(591, 38);
            this.txtInShipNo.Name = "txtInShipNo";
            this.txtInShipNo.Size = new System.Drawing.Size(121, 21);
            this.txtInShipNo.TabIndex = 41;
            this.txtInShipNo.Tag = "rsid:Label.R01089,isrq:Y,maxl:64,updt:Y,dbfd:inshipno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 40;
            this.label4.Tag = "rsid:Label.R01089,isrq:Y";
            this.label4.Text = "In Ship No:";
            // 
            // txtDeliveryBill
            // 
            this.txtDeliveryBill.BackColor = System.Drawing.Color.White;
            this.txtDeliveryBill.Location = new System.Drawing.Point(350, 38);
            this.txtDeliveryBill.Name = "txtDeliveryBill";
            this.txtDeliveryBill.Size = new System.Drawing.Size(121, 21);
            this.txtDeliveryBill.TabIndex = 39;
            this.txtDeliveryBill.Tag = "rsid:Label.R01088,isrq:Y,maxl:64,updt:Y,dbfd:deliverybill";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 38;
            this.label1.Tag = "rsid:Label.R01088,isrq:Y";
            this.label1.Text = "B/L No:";
            // 
            // txtBoxQty
            // 
            this.txtBoxQty.BackColor = System.Drawing.Color.White;
            this.txtBoxQty.Location = new System.Drawing.Point(109, 36);
            this.txtBoxQty.Name = "txtBoxQty";
            this.txtBoxQty.Size = new System.Drawing.Size(121, 21);
            this.txtBoxQty.TabIndex = 37;
            this.txtBoxQty.Tag = "rsid:Label.R01087,isrq:Y,maxl:64,updt:Y,dbfd:loadingdate";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 36;
            this.label9.Tag = "rsid:Label.R01087,isrq:Y";
            this.label9.Text = "Box Qty:";
            // 
            // dtLoadingDt
            // 
            this.dtLoadingDt.FormatString = "yyyy-MM-dd";
            this.dtLoadingDt.Location = new System.Drawing.Point(591, 12);
            this.dtLoadingDt.Name = "dtLoadingDt";
            this.dtLoadingDt.Size = new System.Drawing.Size(120, 21);
            this.dtLoadingDt.TabIndex = 35;
            this.dtLoadingDt.Tag = "rsid:Label.R01086,isrq:Y,dbty:date,updt:Y,dbfd:loadingdate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(494, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 34;
            this.label6.Tag = "rsid:Label.R01086,isrq:Y";
            this.label6.Text = "Loading Date:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(350, 12);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(120, 20);
            this.cmbCustomer.TabIndex = 33;
            this.cmbCustomer.Tag = "rsid:Label.R01020,isrq:Y,maxl:64,updt:Y,dbfd:customerid";
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 32;
            this.label2.Tag = "rsid:Label.R01020,isrq:Y";
            this.label2.Text = "Customer:";
            // 
            // txtShippingPlanNo
            // 
            this.txtShippingPlanNo.BackColor = System.Drawing.Color.White;
            this.txtShippingPlanNo.Enabled = false;
            this.txtShippingPlanNo.Location = new System.Drawing.Point(110, 9);
            this.txtShippingPlanNo.Name = "txtShippingPlanNo";
            this.txtShippingPlanNo.Size = new System.Drawing.Size(120, 21);
            this.txtShippingPlanNo.TabIndex = 25;
            this.txtShippingPlanNo.Tag = "rsid:Label.R02057,isrq:Y,maxl:64,updt:Y,dbfd:shippingplanno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 24;
            this.label3.Tag = "rsid:Label.R02057,isrq:Y";
            this.label3.Text = "Ship No:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grdDetail);
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 152);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(733, 275);
            this.panel3.TabIndex = 35;
            // 
            // grdDetail
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdDetail.DisplayLayout.Appearance = appearance1;
            this.grdDetail.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdDetail.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdDetail.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdDetail.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grdDetail.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdDetail.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.grdDetail.DisplayLayout.MaxColScrollRegions = 1;
            this.grdDetail.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdDetail.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdDetail.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.grdDetail.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdDetail.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.grdDetail.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdDetail.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdDetail.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdDetail.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grdDetail.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.grdDetail.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.grdDetail.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdDetail.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.grdDetail.DisplayLayout.Override.RowAppearance = appearance10;
            this.grdDetail.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdDetail.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdDetail.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.grdDetail.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdDetail.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.Location = new System.Drawing.Point(0, 25);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.Size = new System.Drawing.Size(733, 250);
            this.grdDetail.TabIndex = 47;
            this.grdDetail.Tag = "rsid:Label.R01025|rsid:Label.R01020|rsid:Label.R01021|rsid:Label.R02021";
            this.grdDetail.Text = "ultraGrid1";
            this.grdDetail.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdDetail_AfterCellUpdate);
            this.grdDetail.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdDetail_InitializeLayout);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.toolStripSeparator1,
            this.tsbDelete,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(733, 25);
            this.toolStrip1.TabIndex = 46;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::GENLSYS.MES.Win.Properties.Resources.addline;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(52, 22);
            this.tsbAdd.Tag = "rsid:Button.R00007";
            this.tsbAdd.Text = "增行";
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
            this.tsbDelete.Text = "删行";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 22);
            // 
            // frmShipPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 468);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmShipPlan";
            this.Tag = "rsid:Label.R02056";
            this.Text = "frmShipPlan";
            this.Load += new System.EventHandler(this.frmShipPlan_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCommissionedWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCommissionedVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCommissionedQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLoadingDt)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdDetail;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.TextBox txtShippingPlanNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtLoadingDt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInShipNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeliveryBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label weight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVoyage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUnloadPort;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDestinationPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStartPort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numCommissionedQty;
        private System.Windows.Forms.NumericUpDown numCommissionedVolume;
        private System.Windows.Forms.NumericUpDown numCommissionedWeight;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRemark;

    }
}
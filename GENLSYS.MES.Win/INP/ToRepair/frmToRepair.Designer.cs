namespace GENLSYS.MES.Win.INP.ToRepair
{
    partial class frmToRepair
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
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
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnToRepair = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckIsFirst = new System.Windows.Forms.CheckBox();
            this.ucmbCustOrderNo = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.cmbWorkGroup = new System.Windows.Forms.ComboBox();
            this.cmbStep = new System.Windows.Forms.ComboBox();
            this.numRepairQty = new System.Windows.Forms.NumericUpDown();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPairQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStyleNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdDetail = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucmbCustOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepairQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnContinue);
            this.panel2.Controls.Add(this.btnToRepair);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 439);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(941, 41);
            this.panel2.TabIndex = 32;
            // 
            // btnContinue
            // 
            this.btnContinue.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinue.Location = new System.Drawing.Point(433, 10);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(72, 21);
            this.btnContinue.TabIndex = 14;
            this.btnContinue.Tag = "rsid:Button.R00051";
            this.btnContinue.Text = "&To Repair Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnToRepair
            // 
            this.btnToRepair.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnToRepair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToRepair.Location = new System.Drawing.Point(355, 10);
            this.btnToRepair.Name = "btnToRepair";
            this.btnToRepair.Size = new System.Drawing.Size(72, 21);
            this.btnToRepair.TabIndex = 12;
            this.btnToRepair.Tag = "rsid:Button.R00046";
            this.btnToRepair.Text = "&To Repair";
            this.btnToRepair.UseVisualStyleBackColor = true;
            this.btnToRepair.Click += new System.EventHandler(this.btnToRepair_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(511, 10);
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
            this.groupBox1.Controls.Add(this.ckIsFirst);
            this.groupBox1.Controls.Add(this.ucmbCustOrderNo);
            this.groupBox1.Controls.Add(this.cmbWorkGroup);
            this.groupBox1.Controls.Add(this.cmbStep);
            this.groupBox1.Controls.Add(this.numRepairQty);
            this.groupBox1.Controls.Add(this.txtSize);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPairQty);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtColor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtStyleNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(941, 106);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // ckIsFirst
            // 
            this.ckIsFirst.AutoSize = true;
            this.ckIsFirst.Checked = true;
            this.ckIsFirst.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsFirst.Location = new System.Drawing.Point(644, 75);
            this.ckIsFirst.Name = "ckIsFirst";
            this.ckIsFirst.Size = new System.Drawing.Size(72, 16);
            this.ckIsFirst.TabIndex = 43;
            this.ckIsFirst.Tag = "rsid:Label.R01084";
            this.ckIsFirst.Text = "Is First";
            this.ckIsFirst.UseVisualStyleBackColor = true;
            // 
            // ucmbCustOrderNo
            // 
            this.ucmbCustOrderNo.CheckedListSettings.CheckStateMember = "";
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucmbCustOrderNo.DisplayLayout.Appearance = appearance13;
            this.ucmbCustOrderNo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucmbCustOrderNo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.ucmbCustOrderNo.DisplayLayout.GroupByBox.Appearance = appearance14;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucmbCustOrderNo.DisplayLayout.GroupByBox.BandLabelAppearance = appearance16;
            this.ucmbCustOrderNo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance15.BackColor2 = System.Drawing.SystemColors.Control;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucmbCustOrderNo.DisplayLayout.GroupByBox.PromptAppearance = appearance15;
            this.ucmbCustOrderNo.DisplayLayout.MaxColScrollRegions = 1;
            this.ucmbCustOrderNo.DisplayLayout.MaxRowScrollRegions = 1;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            appearance21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucmbCustOrderNo.DisplayLayout.Override.ActiveCellAppearance = appearance21;
            appearance17.BackColor = System.Drawing.SystemColors.Highlight;
            appearance17.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucmbCustOrderNo.DisplayLayout.Override.ActiveRowAppearance = appearance17;
            this.ucmbCustOrderNo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucmbCustOrderNo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance24.BackColor = System.Drawing.SystemColors.Window;
            this.ucmbCustOrderNo.DisplayLayout.Override.CardAreaAppearance = appearance24;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucmbCustOrderNo.DisplayLayout.Override.CellAppearance = appearance20;
            this.ucmbCustOrderNo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucmbCustOrderNo.DisplayLayout.Override.CellPadding = 0;
            appearance18.BackColor = System.Drawing.SystemColors.Control;
            appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance18.BorderColor = System.Drawing.SystemColors.Window;
            this.ucmbCustOrderNo.DisplayLayout.Override.GroupByRowAppearance = appearance18;
            appearance19.TextHAlignAsString = "Left";
            this.ucmbCustOrderNo.DisplayLayout.Override.HeaderAppearance = appearance19;
            this.ucmbCustOrderNo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucmbCustOrderNo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.BorderColor = System.Drawing.Color.Silver;
            this.ucmbCustOrderNo.DisplayLayout.Override.RowAppearance = appearance22;
            this.ucmbCustOrderNo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucmbCustOrderNo.DisplayLayout.Override.TemplateAddRowAppearance = appearance23;
            this.ucmbCustOrderNo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucmbCustOrderNo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucmbCustOrderNo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucmbCustOrderNo.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.ucmbCustOrderNo.Location = new System.Drawing.Point(767, 16);
            this.ucmbCustOrderNo.Name = "ucmbCustOrderNo";
            this.ucmbCustOrderNo.Size = new System.Drawing.Size(158, 22);
            this.ucmbCustOrderNo.TabIndex = 42;
            this.ucmbCustOrderNo.Tag = "rsid:Label.R01025,isrq:Y,maxl:64,updt:Y,dbfd:custorderno";
            this.ucmbCustOrderNo.ValueChanged += new System.EventHandler(this.ucmbCustOrderNo_ValueChanged);
            // 
            // cmbWorkGroup
            // 
            this.cmbWorkGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkGroup.FormattingEnabled = true;
            this.cmbWorkGroup.Location = new System.Drawing.Point(456, 17);
            this.cmbWorkGroup.Name = "cmbWorkGroup";
            this.cmbWorkGroup.Size = new System.Drawing.Size(159, 20);
            this.cmbWorkGroup.TabIndex = 41;
            this.cmbWorkGroup.Tag = "rsid:Label.R01016,isrq:Y,maxl:64,updt:Y,dbfd:workgroup";
            this.cmbWorkGroup.SelectedIndexChanged += new System.EventHandler(this.cmbWorkGroup_SelectedIndexChanged);
            // 
            // cmbStep
            // 
            this.cmbStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStep.FormattingEnabled = true;
            this.cmbStep.Items.AddRange(new object[] {
            "检品",
            "X线"});
            this.cmbStep.Location = new System.Drawing.Point(146, 17);
            this.cmbStep.Name = "cmbStep";
            this.cmbStep.Size = new System.Drawing.Size(159, 20);
            this.cmbStep.TabIndex = 40;
            this.cmbStep.Tag = "rsid:Label.R00950,isrq:Y,maxl:64,,isrq:Y,maxl:64,updt:Y,updt:Y,dbfd:step";
            this.cmbStep.SelectedIndexChanged += new System.EventHandler(this.cmbStep_SelectedIndexChanged);
            // 
            // numRepairQty
            // 
            this.numRepairQty.Enabled = false;
            this.numRepairQty.Location = new System.Drawing.Point(457, 70);
            this.numRepairQty.Name = "numRepairQty";
            this.numRepairQty.Size = new System.Drawing.Size(158, 21);
            this.numRepairQty.TabIndex = 39;
            this.numRepairQty.Tag = "rsid:Label.R02029,isrq:N,maxl:64,updt:Y,dbfd:repairqty";
            // 
            // txtSize
            // 
            this.txtSize.Enabled = false;
            this.txtSize.Location = new System.Drawing.Point(767, 44);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(158, 21);
            this.txtSize.TabIndex = 35;
            this.txtSize.Tag = "rsid:Label.R02029,isrq:N,maxl:64,updt:Y,dbfd:factory";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(334, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 34;
            this.label8.Tag = "rsid:Label.R02036";
            this.label8.Text = "To Repair Qty:";
            // 
            // txtPairQty
            // 
            this.txtPairQty.Enabled = false;
            this.txtPairQty.Location = new System.Drawing.Point(145, 70);
            this.txtPairQty.Name = "txtPairQty";
            this.txtPairQty.Size = new System.Drawing.Size(159, 21);
            this.txtPairQty.TabIndex = 33;
            this.txtPairQty.Tag = "rsid:Label.R02026,isrq:N,maxl:64,updt:Y,dbfd:factory";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 32;
            this.label10.Tag = "rsid:Label.R02026";
            this.label10.Text = "Pair Qty:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(642, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 30;
            this.label6.Tag = "rsid:Label.R01028";
            this.label6.Text = "Size:";
            // 
            // txtColor
            // 
            this.txtColor.Enabled = false;
            this.txtColor.Location = new System.Drawing.Point(456, 43);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(159, 21);
            this.txtColor.TabIndex = 29;
            this.txtColor.Tag = "rsid:Label.R01027,isrq:N,maxl:64,updt:Y,dbfd:factory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 28;
            this.label5.Tag = "rsid:Label.R01027";
            this.label5.Text = "Color:";
            // 
            // txtStyleNo
            // 
            this.txtStyleNo.Enabled = false;
            this.txtStyleNo.Location = new System.Drawing.Point(146, 43);
            this.txtStyleNo.Name = "txtStyleNo";
            this.txtStyleNo.Size = new System.Drawing.Size(158, 21);
            this.txtStyleNo.TabIndex = 27;
            this.txtStyleNo.Tag = "rsid:Label.R01026,isrq:N,maxl:64,updt:Y,dbfd:factory";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 26;
            this.label7.Tag = "rsid:Label.R01026";
            this.label7.Text = "Style No:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(334, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 24;
            this.label9.Tag = "rsid:Label.R01016,isrq:Y";
            this.label9.Text = "Work Group:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 22;
            this.label3.Tag = "rsid:Label.R00950,isrq:Y";
            this.label3.Text = "Step:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(642, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 6;
            this.label1.Tag = "rsid:Label.R01025,isrq:Y";
            this.label1.Text = "Cust Order No:";
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
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdDetail.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.grdDetail.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdDetail.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.Location = new System.Drawing.Point(0, 106);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.Size = new System.Drawing.Size(941, 333);
            this.grdDetail.TabIndex = 35;
            this.grdDetail.Tag = "rsid:|rsid:|rsid:Label.R00038|rsid:Label.R02027|rsid:Label.R02037|rsid:Label.R020" +
                "361|rsid:Label.R02025";
            this.grdDetail.Text = "ultraGrid1";
            this.grdDetail.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdDetail_AfterCellUpdate);
            this.grdDetail.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdDetail_InitializeLayout);
            this.grdDetail.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.grdDetail_InitializeRow);
            // 
            // frmToRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 480);
            this.Controls.Add(this.grdDetail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmToRepair";
            this.Tag = "rsid:Label.R02035";
            this.Text = "frmToRepair";
            this.Load += new System.EventHandler(this.frmToRepair_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucmbCustOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepairQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnToRepair;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPairQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStyleNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numRepairQty;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdDetail;
        private System.Windows.Forms.ComboBox cmbWorkGroup;
        private System.Windows.Forms.ComboBox cmbStep;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucmbCustOrderNo;
        private System.Windows.Forms.CheckBox ckIsFirst;
        private System.Windows.Forms.Button btnContinue;
    }
}
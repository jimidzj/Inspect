namespace GENLSYS.MES.Win.INP.Pricing
{
    partial class frmPricingList
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPricingList));
            this.pQuery = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cboCheckType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdPricing = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ucToolbar1 = new GENLSYS.MES.UserControls.ucToolbar();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.pQuery.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPricing)).BeginInit();
            this.SuspendLayout();
            // 
            // pQuery
            // 
            this.pQuery.BackColor = System.Drawing.SystemColors.Info;
            this.pQuery.Controls.Add(this.groupBox2);
            this.pQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.pQuery.Location = new System.Drawing.Point(0, 26);
            this.pQuery.Name = "pQuery";
            this.pQuery.Size = new System.Drawing.Size(789, 76);
            this.pQuery.TabIndex = 34;
            this.pQuery.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboCategory);
            this.groupBox2.Controls.Add(this.btnQuery);
            this.groupBox2.Controls.Add(this.cboCheckType);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboCustomer);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(789, 76);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "rsid:Label.R01024";
            this.groupBox2.Text = "查询条件";
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::GENLSYS.MES.Win.Properties.Resources.query;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(652, 17);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 21);
            this.btnQuery.TabIndex = 35;
            this.btnQuery.Tag = "rsid:Button.R00003";
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cboCheckType
            // 
            this.cboCheckType.FormattingEnabled = true;
            this.cboCheckType.Location = new System.Drawing.Point(146, 43);
            this.cboCheckType.Name = "cboCheckType";
            this.cboCheckType.Size = new System.Drawing.Size(121, 20);
            this.cboCheckType.TabIndex = 34;
            this.cboCheckType.Tag = "rsid:Label.R02019,isrq:N,dbty:string,dbfd:checktype";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 33;
            this.label3.Tag = "rsid:Label.R01028";
            this.label3.Text = "Check Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 29;
            this.label4.Tag = "rsid:Label.R010701,isrq:N";
            this.label4.Text = "Category:";
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(146, 17);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(121, 20);
            this.cboCustomer.TabIndex = 28;
            this.cboCustomer.Tag = "rsid:Label.R01020,isrq:N,dbty:string,dbfd:customerid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 27;
            this.label2.Tag = "rsid:Label.R01020";
            this.label2.Text = "Customer:";
            // 
            // grdPricing
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdPricing.DisplayLayout.Appearance = appearance1;
            this.grdPricing.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdPricing.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdPricing.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdPricing.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grdPricing.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdPricing.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grdPricing.DisplayLayout.MaxColScrollRegions = 1;
            this.grdPricing.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPricing.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdPricing.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grdPricing.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdPricing.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grdPricing.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdPricing.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdPricing.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdPricing.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdPricing.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.grdPricing.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdPricing.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdPricing.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.grdPricing.DisplayLayout.Override.RowAppearance = appearance11;
            this.grdPricing.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdPricing.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grdPricing.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdPricing.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdPricing.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdPricing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPricing.Location = new System.Drawing.Point(0, 102);
            this.grdPricing.Name = "grdPricing";
            this.grdPricing.Size = new System.Drawing.Size(789, 343);
            this.grdPricing.TabIndex = 35;
            this.grdPricing.Tag = resources.GetString("grdPricing.Tag");
            this.grdPricing.Text = "ultraGrid1";
            this.grdPricing.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdPricing_InitializeLayout);
            this.grdPricing.AfterRowActivate += new System.EventHandler(this.grdPricing_AfterRowActivate);
            // 
            // ucToolbar1
            // 
            this.ucToolbar1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ucToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbar1.Location = new System.Drawing.Point(0, 0);
            this.ucToolbar1.Name = "ucToolbar1";
            this.ucToolbar1.Size = new System.Drawing.Size(789, 26);
            this.ucToolbar1.TabIndex = 32;
            this.ucToolbar1.Tag = "rsid:Label.R01005";
            this.ucToolbar1.NewEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarNewEventHandler(this.ucToolbar1_NewEventHandler);
            this.ucToolbar1.EditEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarEditEventHandler(this.ucToolbar1_EditEventHandler);
            this.ucToolbar1.ExportEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExportEventHandler(this.ucToolbar1_ExportEventHandler);
            this.ucToolbar1.ExitEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExitEventHandler(this.ucToolbar1_ExitEventHandler);
            this.ucToolbar1.QueryEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarQueryEventHandler(this.ucToolbar1_QueryEventHandler);
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(421, 14);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 20);
            this.cboCategory.TabIndex = 36;
            this.cboCategory.Tag = "rsid:Label.R010701,isrq:N,dbty:string,updt:Y,dbfd:category";
            // 
            // frmPricingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 445);
            this.Controls.Add(this.grdPricing);
            this.Controls.Add(this.pQuery);
            this.Controls.Add(this.ucToolbar1);
            this.Name = "frmPricingList";
            this.Tag = "rsid:Label.R01044";
            this.Text = "frmPricingList";
            this.Load += new System.EventHandler(this.frmPricingList_Load);
            this.pQuery.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPricing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucToolbar ucToolbar1;
        private System.Windows.Forms.Panel pQuery;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cboCheckType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdPricing;
        private System.Windows.Forms.ComboBox cboCategory;
    }
}
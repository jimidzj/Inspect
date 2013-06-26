namespace GENLSYS.MES.Win.INP.ToRepair
{
    partial class frmToRepairList
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
            this.grdQuery = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.pQuery = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStyleNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtCustOrderNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucStatusBar1 = new GENLSYS.MES.UserControls.ucStatusBar();
            this.ucToolbar1 = new GENLSYS.MES.UserControls.ucToolbar();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery)).BeginInit();
            this.pQuery.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdQuery
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdQuery.DisplayLayout.Appearance = appearance1;
            this.grdQuery.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdQuery.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdQuery.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdQuery.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grdQuery.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdQuery.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.grdQuery.DisplayLayout.MaxColScrollRegions = 1;
            this.grdQuery.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdQuery.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdQuery.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.grdQuery.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdQuery.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.grdQuery.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdQuery.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdQuery.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdQuery.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grdQuery.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.grdQuery.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.grdQuery.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdQuery.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.grdQuery.DisplayLayout.Override.RowAppearance = appearance10;
            this.grdQuery.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdQuery.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdQuery.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.grdQuery.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdQuery.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdQuery.Location = new System.Drawing.Point(0, 108);
            this.grdQuery.Name = "grdQuery";
            this.grdQuery.Size = new System.Drawing.Size(820, 373);
            this.grdQuery.TabIndex = 20;
            this.grdQuery.Tag = "rsid:Label.R01020|rsid:Label.R01025|rsid:Label.R00950|rsid:Label.R01016|rsid:Labe" +
                "l.R01026|rsid:Label.R01027|rsid:Label.R01028|rsid:Label.R02019|rsid:Label.R02015" +
                "";
            this.grdQuery.Text = "ultraGrid1";
            this.grdQuery.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdQuery_InitializeLayout);
            this.grdQuery.AfterRowActivate += new System.EventHandler(this.grdQuery_AfterRowActivate);
            // 
            // pQuery
            // 
            this.pQuery.BackColor = System.Drawing.SystemColors.Info;
            this.pQuery.Controls.Add(this.groupBox1);
            this.pQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.pQuery.Location = new System.Drawing.Point(0, 26);
            this.pQuery.Name = "pQuery";
            this.pQuery.Size = new System.Drawing.Size(820, 82);
            this.pQuery.TabIndex = 19;
            this.pQuery.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSize);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtColor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtStyleNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.txtCustOrderNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(820, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "rsid:Label.R01024";
            this.groupBox1.Text = "查询条件";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(104, 19);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(137, 21);
            this.txtCustomer.TabIndex = 16;
            this.txtCustomer.Tag = "rsid:Label.R01020,maxl:64,dbfd:customername,dbty:string";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 15;
            this.label5.Tag = "rsid:Label.R01020";
            this.label5.Text = "Customer:";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(575, 46);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(137, 21);
            this.txtSize.TabIndex = 14;
            this.txtSize.Tag = "rsid:Label.R01028,maxl:64,dbfd:size,dbty:string";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(517, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 13;
            this.label4.Tag = "rsid:Label.R01028";
            this.label4.Text = "Size:";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(357, 46);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(137, 21);
            this.txtColor.TabIndex = 12;
            this.txtColor.Tag = "rsid:Label.R01027,maxl:64,dbfd:color,dbty:string";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Tag = "rsid:Label.R01027";
            this.label3.Text = "Color:";
            // 
            // txtStyleNo
            // 
            this.txtStyleNo.Location = new System.Drawing.Point(104, 46);
            this.txtStyleNo.Name = "txtStyleNo";
            this.txtStyleNo.Size = new System.Drawing.Size(137, 21);
            this.txtStyleNo.TabIndex = 10;
            this.txtStyleNo.Tag = "rsid:Label.R01026,maxl:64,dbfd:styleno,dbty:string";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 9;
            this.label2.Tag = "rsid:Label.R01026";
            this.label2.Text = "Style No:";
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::GENLSYS.MES.Win.Properties.Resources.query;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(739, 44);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Tag = "rsid:Button.R00003";
            this.btnQuery.Text = "Query";
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtCustOrderNo
            // 
            this.txtCustOrderNo.Location = new System.Drawing.Point(357, 19);
            this.txtCustOrderNo.Name = "txtCustOrderNo";
            this.txtCustOrderNo.Size = new System.Drawing.Size(137, 21);
            this.txtCustOrderNo.TabIndex = 3;
            this.txtCustOrderNo.Tag = "rsid:Label.R01019,maxl:64,dbfd:custorderno,dbty:string";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Tag = "rsid:Label.R01025";
            this.label1.Text = "Cust Order No:";
            // 
            // ucStatusBar1
            // 
            this.ucStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStatusBar1.Location = new System.Drawing.Point(0, 481);
            this.ucStatusBar1.Name = "ucStatusBar1";
            this.ucStatusBar1.Size = new System.Drawing.Size(820, 22);
            this.ucStatusBar1.TabIndex = 2;
            // 
            // ucToolbar1
            // 
            this.ucToolbar1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ucToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbar1.Location = new System.Drawing.Point(0, 0);
            this.ucToolbar1.Name = "ucToolbar1";
            this.ucToolbar1.Size = new System.Drawing.Size(820, 26);
            this.ucToolbar1.TabIndex = 1;
            this.ucToolbar1.ExitEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExitEventHandler(this.ucToolbar1_ExitEventHandler);
            this.ucToolbar1.QueryEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarQueryEventHandler(this.ucToolbar1_QueryEventHandler);
            this.ucToolbar1.ToRepairEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarToRepairEventHandler(this.ucToolbar1_ToRepairEventHandler);
            // 
            // frmToRepairList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 503);
            this.Controls.Add(this.grdQuery);
            this.Controls.Add(this.pQuery);
            this.Controls.Add(this.ucStatusBar1);
            this.Controls.Add(this.ucToolbar1);
            this.Name = "frmToRepairList";
            this.Tag = "rsid:Label.R02035";
            this.Text = "frmToRepairList";
            this.Load += new System.EventHandler(this.frmToRepairList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery)).EndInit();
            this.pQuery.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucToolbar ucToolbar1;
        private UserControls.ucStatusBar ucStatusBar1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdQuery;
        private System.Windows.Forms.Panel pQuery;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtCustOrderNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStyleNo;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label5;
    }
}
﻿namespace GENLSYS.MES.WinPAD
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
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
            this.grdQuery = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.pQuery = new System.Windows.Forms.Panel();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboFactory = new System.Windows.Forms.ComboBox();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtCustOrderNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ucStatusBar1 = new GENLSYS.MES.UserControls.ucStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery)).BeginInit();
            this.pQuery.SuspendLayout();
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
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdQuery.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grdQuery.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdQuery.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grdQuery.DisplayLayout.MaxColScrollRegions = 1;
            this.grdQuery.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdQuery.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdQuery.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grdQuery.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdQuery.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grdQuery.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdQuery.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdQuery.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdQuery.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdQuery.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.grdQuery.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdQuery.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdQuery.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.grdQuery.DisplayLayout.Override.RowAppearance = appearance11;
            this.grdQuery.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdQuery.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdQuery.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grdQuery.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdQuery.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdQuery.Location = new System.Drawing.Point(0, 53);
            this.grdQuery.Name = "grdQuery";
            this.grdQuery.Size = new System.Drawing.Size(1040, 385);
            this.grdQuery.TabIndex = 19;
            this.grdQuery.Tag = "rsid:Label.R00042|rsid:Label.R00043|rsid:Label.R01021|rsid:Label.R01025|rsid:Labe" +
                "l.R01026|rsid:Label.R02026|rsid:Label.R01065|rsid:Label.R02027";
            this.grdQuery.Text = "ultraGrid1";
            this.grdQuery.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdQuery_InitializeLayout);
            this.grdQuery.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.grdQuery_InitializeRow);
            this.grdQuery.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdQuery_ClickCellButton);
            // 
            // pQuery
            // 
            this.pQuery.BackColor = System.Drawing.SystemColors.Info;
            this.pQuery.Controls.Add(this.txtType);
            this.pQuery.Controls.Add(this.label4);
            this.pQuery.Controls.Add(this.cboFactory);
            this.pQuery.Controls.Add(this.cboCustomer);
            this.pQuery.Controls.Add(this.label3);
            this.pQuery.Controls.Add(this.btnQuery);
            this.pQuery.Controls.Add(this.txtCustOrderNo);
            this.pQuery.Controls.Add(this.label2);
            this.pQuery.Controls.Add(this.label1);
            this.pQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.pQuery.Location = new System.Drawing.Point(0, 0);
            this.pQuery.Name = "pQuery";
            this.pQuery.Size = new System.Drawing.Size(1040, 53);
            this.pQuery.TabIndex = 16;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(450, 14);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(108, 21);
            this.txtType.TabIndex = 80;
            this.txtType.Tag = "rsid:Label.R01019,maxl:64,dbfd:styleno,dbty:string";
            this.txtType.Enter += new System.EventHandler(this.txtType_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(577, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 79;
            this.label4.Tag = "";
            this.label4.Text = "工厂:";
            this.label4.Visible = false;
            // 
            // cboFactory
            // 
            this.cboFactory.FormattingEnabled = true;
            this.cboFactory.Location = new System.Drawing.Point(618, 14);
            this.cboFactory.Name = "cboFactory";
            this.cboFactory.Size = new System.Drawing.Size(155, 20);
            this.cboFactory.TabIndex = 78;
            this.cboFactory.Tag = "rsid:Label.R01021,isrq:N,dbty:string,updt:N,dbfd:factory";
            this.cboFactory.Visible = false;
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(53, 14);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(121, 20);
            this.cboCustomer.TabIndex = 77;
            this.cboCustomer.Tag = "rsid:Label.R01020,isrq:N,dbty:string,updt:Y,dbfd:customerid";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 76;
            this.label3.Tag = "";
            this.label3.Text = "款号:";
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.query;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(799, 13);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 75;
            this.btnQuery.Tag = "Button.R00003";
            this.btnQuery.Text = "查询";
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtCustOrderNo
            // 
            this.txtCustOrderNo.Location = new System.Drawing.Point(295, 14);
            this.txtCustOrderNo.Name = "txtCustOrderNo";
            this.txtCustOrderNo.Size = new System.Drawing.Size(108, 21);
            this.txtCustOrderNo.TabIndex = 74;
            this.txtCustOrderNo.Tag = "rsid:Label.R01019,maxl:64,dbfd:custorderno,dbty:string";
            this.txtCustOrderNo.Enter += new System.EventHandler(this.txtCustOrderNo_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 73;
            this.label2.Tag = "rsid:Label.R01020";
            this.label2.Text = "客户:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 72;
            this.label1.Tag = "rsid:Label.R01025";
            this.label1.Text = "订单:";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 100000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ucStatusBar1
            // 
            this.ucStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStatusBar1.Location = new System.Drawing.Point(0, 438);
            this.ucStatusBar1.Name = "ucStatusBar1";
            this.ucStatusBar1.Size = new System.Drawing.Size(1040, 22);
            this.ucStatusBar1.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 460);
            this.Controls.Add(this.grdQuery);
            this.Controls.Add(this.pQuery);
            this.Controls.Add(this.ucStatusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.Text = "订单列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery)).EndInit();
            this.pQuery.ResumeLayout(false);
            this.pQuery.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucStatusBar ucStatusBar1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdQuery;
        private System.Windows.Forms.Panel pQuery;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFactory;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtCustOrderNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;


    }
}
namespace GENLSYS.MES.Win.SYS.Session
{
    partial class frmSessionList
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
            this.components = new System.ComponentModel.Container();
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
            this.toolStripSessionList = new System.Windows.Forms.ToolStrip();
            this.btnLock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUnlock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnKill = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.gridSessionList = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ucStatusBarSessionList = new GENLSYS.MES.UserControls.ucStatusBar();
            this.toolStripSessionList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSessionList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripSessionList
            // 
            this.toolStripSessionList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLock,
            this.toolStripSeparator1,
            this.btnUnlock,
            this.toolStripSeparator2,
            this.btnKill,
            this.toolStripSeparator3,
            this.btnExport,
            this.toolStripSeparator4,
            this.btnExit});
            this.toolStripSessionList.Location = new System.Drawing.Point(0, 0);
            this.toolStripSessionList.Name = "toolStripSessionList";
            this.toolStripSessionList.Size = new System.Drawing.Size(772, 25);
            this.toolStripSessionList.TabIndex = 1;
            this.toolStripSessionList.Text = "toolStrip1";
            // 
            // btnLock
            // 
            this.btnLock.Image = global::GENLSYS.MES.Win.Properties.Resources.Lock;
            this.btnLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(49, 22);
            this.btnLock.Text = "Lock";
            this.btnLock.Click += new System.EventHandler(this.toolStripButtonLock_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Image = global::GENLSYS.MES.Win.Properties.Resources.unlock;
            this.btnUnlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(61, 22);
            this.btnUnlock.Text = "UnLock";
            this.btnUnlock.Click += new System.EventHandler(this.toolStripButtonUnLock_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnKill
            // 
            this.btnKill.Image = global::GENLSYS.MES.Win.Properties.Resources.cancel;
            this.btnKill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(49, 22);
            this.btnKill.Text = "Kill";
            this.btnKill.Click += new System.EventHandler(this.toolStripButtonKill_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::GENLSYS.MES.Win.Properties.Resources.excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(61, 22);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.toolStripButtonExport_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(49, 22);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // gridSessionList
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridSessionList.DisplayLayout.Appearance = appearance1;
            this.gridSessionList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridSessionList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridSessionList.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridSessionList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.gridSessionList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridSessionList.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.gridSessionList.DisplayLayout.MaxColScrollRegions = 1;
            this.gridSessionList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridSessionList.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridSessionList.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.gridSessionList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridSessionList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.gridSessionList.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridSessionList.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridSessionList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridSessionList.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.gridSessionList.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.gridSessionList.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.gridSessionList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridSessionList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.gridSessionList.DisplayLayout.Override.RowAppearance = appearance10;
            this.gridSessionList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridSessionList.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.gridSessionList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridSessionList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridSessionList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridSessionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSessionList.Location = new System.Drawing.Point(0, 25);
            this.gridSessionList.Name = "gridSessionList";
            this.gridSessionList.Size = new System.Drawing.Size(772, 402);
            this.gridSessionList.TabIndex = 2;
            this.gridSessionList.Tag = "rsid:Label.R00400|rsid:Label.R00401|rsid:Label.R00402|rsid:Label.R00404|rsid:Labe" +
                "l.R00405|rsid:Label.R00406|rsid:Label.R00409|rsid:Label.R00410";
            this.gridSessionList.Text = "ultraGrid1";
            this.gridSessionList.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridSessionList_InitializeLayout);
            this.gridSessionList.AfterRowActivate += new System.EventHandler(this.gridSessionList_AfterRowActivate);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucStatusBarSessionList
            // 
            this.ucStatusBarSessionList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStatusBarSessionList.Location = new System.Drawing.Point(0, 427);
            this.ucStatusBarSessionList.Name = "ucStatusBarSessionList";
            this.ucStatusBarSessionList.Size = new System.Drawing.Size(772, 22);
            this.ucStatusBarSessionList.TabIndex = 0;
            // 
            // frmSessionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 449);
            this.Controls.Add(this.gridSessionList);
            this.Controls.Add(this.toolStripSessionList);
            this.Controls.Add(this.ucStatusBarSessionList);
            this.Name = "frmSessionList";
            this.Tag = "rsid:Label.R00413";
            this.Text = "frmSessionList";
            this.Load += new System.EventHandler(this.frmSessionList_Load);
            this.toolStripSessionList.ResumeLayout(false);
            this.toolStripSessionList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSessionList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ucStatusBar ucStatusBarSessionList;
        private System.Windows.Forms.ToolStrip toolStripSessionList;
        private System.Windows.Forms.ToolStripButton btnLock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnUnlock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnKill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnExit;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridSessionList;
        private System.Windows.Forms.Timer timer1;
    }
}
namespace GENLSYS.MES.Win.SYS.SystemConfig
{
    partial class frmSystemConfigList
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
            this.ucToolbar1 = new GENLSYS.MES.UserControls.ucToolbar();
            this.ucStatusBar1 = new GENLSYS.MES.UserControls.ucStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery)).BeginInit();
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
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdQuery.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.grdQuery.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdQuery.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdQuery.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdQuery.Location = new System.Drawing.Point(0, 26);
            this.grdQuery.Name = "grdQuery";
            this.grdQuery.Size = new System.Drawing.Size(596, 299);
            this.grdQuery.TabIndex = 5;
            this.grdQuery.Tag = "rsid:Label.R00478|rsid:Label.R00479,colw:300|rsid:Label.R00480|rsid:Label.R00652|" +
                "rsid:Label.R00013|rsid:Label.R00012";
            this.grdQuery.Text = "ultraGrid1";
            this.grdQuery.AfterRowActivate += new System.EventHandler(this.grdQuery_AfterRowActivate);
            // 
            // ucToolbar1
            // 
            this.ucToolbar1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ucToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbar1.Location = new System.Drawing.Point(0, 0);
            this.ucToolbar1.Name = "ucToolbar1";
            this.ucToolbar1.Size = new System.Drawing.Size(596, 26);
            this.ucToolbar1.TabIndex = 4;
            this.ucToolbar1.NewEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarNewEventHandler(this.ucToolbar1_NewEventHandler);
            this.ucToolbar1.DeleteEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarDeleteEventHandler(this.ucToolbar1_DeleteEventHandler);
            this.ucToolbar1.EditEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarEditEventHandler(this.ucToolbar1_EditEventHandler);
            this.ucToolbar1.ExportEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExportEventHandler(this.ucToolbar1_ExportEventHandler);
            this.ucToolbar1.ExitEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExitEventHandler(this.ucToolbar1_ExitEventHandler);
            this.ucToolbar1.QueryEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarQueryEventHandler(this.ucToolbar1_QueryEventHandler);
            // 
            // ucStatusBar1
            // 
            this.ucStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStatusBar1.Location = new System.Drawing.Point(0, 325);
            this.ucStatusBar1.Name = "ucStatusBar1";
            this.ucStatusBar1.Size = new System.Drawing.Size(596, 22);
            this.ucStatusBar1.TabIndex = 3;
            // 
            // frmSystemConfigList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 347);
            this.Controls.Add(this.grdQuery);
            this.Controls.Add(this.ucToolbar1);
            this.Controls.Add(this.ucStatusBar1);
            this.Name = "frmSystemConfigList";
            this.Text = "frmSystemConfigList";
            this.Load += new System.EventHandler(this.frmSystemConfigList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid grdQuery;
        private UserControls.ucToolbar ucToolbar1;
        private UserControls.ucStatusBar ucStatusBar1;
    }
}
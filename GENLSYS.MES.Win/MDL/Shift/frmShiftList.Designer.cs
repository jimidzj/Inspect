namespace GENLSYS.MES.Win.MDL.Shift
{
    partial class frmShiftList
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
            this.ucStatusBarShiftList = new GENLSYS.MES.UserControls.ucStatusBar();
            this.ucToolbarShiftList = new GENLSYS.MES.UserControls.ucToolbar();
            this.gridShiftList = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gridShiftList)).BeginInit();
            this.SuspendLayout();
            // 
            // ucStatusBarShiftList
            // 
            this.ucStatusBarShiftList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStatusBarShiftList.Location = new System.Drawing.Point(0, 359);
            this.ucStatusBarShiftList.Name = "ucStatusBarShiftList";
            this.ucStatusBarShiftList.Size = new System.Drawing.Size(651, 22);
            this.ucStatusBarShiftList.TabIndex = 0;
            // 
            // ucToolbarShiftList
            // 
            this.ucToolbarShiftList.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbarShiftList.Location = new System.Drawing.Point(0, 0);
            this.ucToolbarShiftList.Name = "ucToolbarShiftList";
            this.ucToolbarShiftList.Size = new System.Drawing.Size(651, 26);
            this.ucToolbarShiftList.TabIndex = 1;
            this.ucToolbarShiftList.NewEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarNewEventHandler(this.ucToolbarShiftList_NewEventHandler);
            this.ucToolbarShiftList.DeleteEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarDeleteEventHandler(this.ucToolbarShiftList_DeleteEventHandler);
            this.ucToolbarShiftList.EditEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarEditEventHandler(this.ucToolbarShiftList_EditEventHandler);
            this.ucToolbarShiftList.ExportEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExportEventHandler(this.ucToolbarShiftList_ExportEventHandler);
            this.ucToolbarShiftList.ExitEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExitEventHandler(this.ucToolbarShiftList_ExitEventHandler);
            this.ucToolbarShiftList.QueryEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarQueryEventHandler(this.ucToolbarShiftList_QueryEventHandler);
            // 
            // gridShiftList
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridShiftList.DisplayLayout.Appearance = appearance1;
            this.gridShiftList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridShiftList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridShiftList.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridShiftList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.gridShiftList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridShiftList.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.gridShiftList.DisplayLayout.MaxColScrollRegions = 1;
            this.gridShiftList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridShiftList.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridShiftList.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.gridShiftList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridShiftList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.gridShiftList.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridShiftList.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridShiftList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridShiftList.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.gridShiftList.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.gridShiftList.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.gridShiftList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridShiftList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.gridShiftList.DisplayLayout.Override.RowAppearance = appearance10;
            this.gridShiftList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridShiftList.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.gridShiftList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridShiftList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridShiftList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridShiftList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridShiftList.Location = new System.Drawing.Point(0, 26);
            this.gridShiftList.Name = "gridShiftList";
            this.gridShiftList.Size = new System.Drawing.Size(651, 333);
            this.gridShiftList.TabIndex = 2;
            this.gridShiftList.Tag = "rsid:Label.R00394|rsid:Label.R00395|rsid:Label.R00396|rsid:Label.R00397|rsid:Labe" +
                "l.R00398|rsid:Label.R00012|rsid:Label.R00013";
            this.gridShiftList.Text = "ultraGrid1";
            this.gridShiftList.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridShiftList_InitializeLayout);
            this.gridShiftList.AfterRowActivate += new System.EventHandler(this.gridShiftList_AfterRowActivate);
            // 
            // frmShiftList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 381);
            this.Controls.Add(this.gridShiftList);
            this.Controls.Add(this.ucToolbarShiftList);
            this.Controls.Add(this.ucStatusBarShiftList);
            this.Name = "frmShiftList";
            this.Tag = "rsid:Label.R00399";
            this.Text = "frmShiftList";
            this.Load += new System.EventHandler(this.frmShiftList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridShiftList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucStatusBar ucStatusBarShiftList;
        private UserControls.ucToolbar ucToolbarShiftList;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridShiftList;
    }
}
namespace GENLSYS.MES.Win.MDL.EmployeeType
{
    partial class frmEmployeeTypeList
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
            this.ucToolbarEmployeeTypeList = new GENLSYS.MES.UserControls.ucToolbar();
            this.ucStatusBarEmployeeTypeList = new GENLSYS.MES.UserControls.ucStatusBar();
            this.gridEmployeeTypeList = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployeeTypeList)).BeginInit();
            this.SuspendLayout();
            // 
            // ucToolbarEmployeeTypeList
            // 
            this.ucToolbarEmployeeTypeList.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbarEmployeeTypeList.Location = new System.Drawing.Point(0, 0);
            this.ucToolbarEmployeeTypeList.Name = "ucToolbarEmployeeTypeList";
            this.ucToolbarEmployeeTypeList.Size = new System.Drawing.Size(729, 26);
            this.ucToolbarEmployeeTypeList.TabIndex = 0;
            this.ucToolbarEmployeeTypeList.NewEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarNewEventHandler(this.ucToolbarEmployeeTypeList_NewEventHandler);
            this.ucToolbarEmployeeTypeList.DeleteEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarDeleteEventHandler(this.ucToolbarEmployeeTypeList_DeleteEventHandler);
            this.ucToolbarEmployeeTypeList.EditEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarEditEventHandler(this.ucToolbarEmployeeTypeList_EditEventHandler);
            this.ucToolbarEmployeeTypeList.ExportEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExportEventHandler(this.ucToolbarEmployeeTypeList_ExportEventHandler);
            this.ucToolbarEmployeeTypeList.ExitEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExitEventHandler(this.ucToolbarEmployeeTypeList_ExitEventHandler);
            this.ucToolbarEmployeeTypeList.QueryEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarQueryEventHandler(this.ucToolbarEmployeeTypeList_QueryEventHandler);
            // 
            // ucStatusBarEmployeeTypeList
            // 
            this.ucStatusBarEmployeeTypeList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStatusBarEmployeeTypeList.Location = new System.Drawing.Point(0, 402);
            this.ucStatusBarEmployeeTypeList.Name = "ucStatusBarEmployeeTypeList";
            this.ucStatusBarEmployeeTypeList.Size = new System.Drawing.Size(729, 22);
            this.ucStatusBarEmployeeTypeList.TabIndex = 1;
            // 
            // gridEmployeeTypeList
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridEmployeeTypeList.DisplayLayout.Appearance = appearance1;
            this.gridEmployeeTypeList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridEmployeeTypeList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridEmployeeTypeList.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridEmployeeTypeList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.gridEmployeeTypeList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridEmployeeTypeList.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.gridEmployeeTypeList.DisplayLayout.MaxColScrollRegions = 1;
            this.gridEmployeeTypeList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridEmployeeTypeList.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridEmployeeTypeList.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.gridEmployeeTypeList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridEmployeeTypeList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.gridEmployeeTypeList.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridEmployeeTypeList.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridEmployeeTypeList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridEmployeeTypeList.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.gridEmployeeTypeList.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.gridEmployeeTypeList.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.gridEmployeeTypeList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridEmployeeTypeList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.gridEmployeeTypeList.DisplayLayout.Override.RowAppearance = appearance10;
            this.gridEmployeeTypeList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridEmployeeTypeList.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.gridEmployeeTypeList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridEmployeeTypeList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridEmployeeTypeList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridEmployeeTypeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmployeeTypeList.Location = new System.Drawing.Point(0, 26);
            this.gridEmployeeTypeList.Name = "gridEmployeeTypeList";
            this.gridEmployeeTypeList.Size = new System.Drawing.Size(729, 376);
            this.gridEmployeeTypeList.TabIndex = 2;
            this.gridEmployeeTypeList.Tag = "rsid:label.r00380|rsid:label.r00381|rsid:label.r00012|rsid:label.r00013";
            this.gridEmployeeTypeList.Text = "ultraGrid1";
            this.gridEmployeeTypeList.AfterRowActivate += new System.EventHandler(this.gridEmployeeTypeList_AfterRowActivate);
            // 
            // frmEmployeeTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 424);
            this.Controls.Add(this.gridEmployeeTypeList);
            this.Controls.Add(this.ucStatusBarEmployeeTypeList);
            this.Controls.Add(this.ucToolbarEmployeeTypeList);
            this.Name = "frmEmployeeTypeList";
            this.Tag = "rsid:Label.R00382";
            this.Text = "frmEmployeeTypeList";
            this.Load += new System.EventHandler(this.frmEmployeeTypeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployeeTypeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucToolbar ucToolbarEmployeeTypeList;
        private UserControls.ucStatusBar ucStatusBarEmployeeTypeList;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridEmployeeTypeList;
    }
}
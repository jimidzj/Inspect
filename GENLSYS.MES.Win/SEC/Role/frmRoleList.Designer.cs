namespace GENLSYS.MES.Win.SEC.Role
{
    partial class frmRoleList
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
            this.ucStatusBarRoleList = new GENLSYS.MES.UserControls.ucStatusBar();
            this.ucToolbarRoleList = new GENLSYS.MES.UserControls.ucToolbar();
            this.gridRoleList = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.SuspendLayout();
            // 
            // ucStatusBarRoleList
            // 
            this.ucStatusBarRoleList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStatusBarRoleList.Location = new System.Drawing.Point(0, 382);
            this.ucStatusBarRoleList.Name = "ucStatusBarRoleList";
            this.ucStatusBarRoleList.Size = new System.Drawing.Size(763, 22);
            this.ucStatusBarRoleList.TabIndex = 0;
            // 
            // ucToolbarRoleList
            // 
            this.ucToolbarRoleList.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbarRoleList.Location = new System.Drawing.Point(0, 0);
            this.ucToolbarRoleList.Name = "ucToolbarRoleList";
            this.ucToolbarRoleList.Size = new System.Drawing.Size(763, 26);
            this.ucToolbarRoleList.TabIndex = 1;
            this.ucToolbarRoleList.NewEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarNewEventHandler(this.ucToolbarRoleList_NewEventHandler);
            this.ucToolbarRoleList.DeleteEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarDeleteEventHandler(this.ucToolbarRoleList_DeleteEventHandler);
            this.ucToolbarRoleList.EditEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarEditEventHandler(this.ucToolbarRoleList_EditEventHandler);
            this.ucToolbarRoleList.ExportEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExportEventHandler(this.ucToolbarRoleList_ExportEventHandler);
            this.ucToolbarRoleList.ExitEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExitEventHandler(this.ucToolbarRoleList_ExitEventHandler);
            this.ucToolbarRoleList.QueryEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarQueryEventHandler(this.ucToolbarRoleList_QueryEventHandler);
            // 
            // gridRoleList
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridRoleList.DisplayLayout.Appearance = appearance1;
            this.gridRoleList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridRoleList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridRoleList.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridRoleList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.gridRoleList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridRoleList.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.gridRoleList.DisplayLayout.MaxColScrollRegions = 1;
            this.gridRoleList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridRoleList.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridRoleList.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.gridRoleList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridRoleList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.gridRoleList.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridRoleList.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridRoleList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridRoleList.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.gridRoleList.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.gridRoleList.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.gridRoleList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridRoleList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.gridRoleList.DisplayLayout.Override.RowAppearance = appearance10;
            this.gridRoleList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridRoleList.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.gridRoleList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridRoleList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridRoleList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridRoleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRoleList.Location = new System.Drawing.Point(0, 26);
            this.gridRoleList.Name = "gridRoleList";
            this.gridRoleList.Size = new System.Drawing.Size(763, 356);
            this.gridRoleList.TabIndex = 2;
            this.gridRoleList.Tag = "rsid:Label.R00167|rsid:Label.R00168|rsid:Label.R00169|rsid:Label.R00148|rsid:Labe" +
                "l.R00147|rsid:Label.R00012|rsid:Label.R00013";
            this.gridRoleList.Text = "ultraGrid1";
            this.gridRoleList.AfterRowActivate += new System.EventHandler(this.gridRoleList_AfterRowActivate);
            // 
            // frmRoleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 404);
            this.Controls.Add(this.gridRoleList);
            this.Controls.Add(this.ucToolbarRoleList);
            this.Controls.Add(this.ucStatusBarRoleList);
            this.Name = "frmRoleList";
            this.Tag = "rsid:Label.R00170";
            this.Text = "frmRoleList";
            this.Load += new System.EventHandler(this.frmRoleList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucStatusBar ucStatusBarRoleList;
        private UserControls.ucToolbar ucToolbarRoleList;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridRoleList;
    }
}
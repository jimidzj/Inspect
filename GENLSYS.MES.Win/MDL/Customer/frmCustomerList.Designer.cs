namespace GENLSYS.MES.Win.MDL.Customer
{
    partial class frmCustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerList));
            this.ucToolbarCustomerList = new GENLSYS.MES.UserControls.ucToolbar();
            this.ucStatusBarCustomerList = new GENLSYS.MES.UserControls.ucStatusBar();
            this.gridCustomerList = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomerList)).BeginInit();
            this.SuspendLayout();
            // 
            // ucToolbarCustomerList
            // 
            this.ucToolbarCustomerList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ucToolbarCustomerList.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbarCustomerList.Location = new System.Drawing.Point(0, 0);
            this.ucToolbarCustomerList.Name = "ucToolbarCustomerList";
            this.ucToolbarCustomerList.Size = new System.Drawing.Size(796, 26);
            this.ucToolbarCustomerList.TabIndex = 0;
            this.ucToolbarCustomerList.NewEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarNewEventHandler(this.ucToolbarCustomerList_NewEventHandler);
            this.ucToolbarCustomerList.DeleteEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarDeleteEventHandler(this.ucToolbarCustomerList_DeleteEventHandler);
            this.ucToolbarCustomerList.EditEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarEditEventHandler(this.ucToolbarCustomerList_EditEventHandler);
            this.ucToolbarCustomerList.ExportEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExportEventHandler(this.ucToolbarCustomerList_ExportEventHandler);
            this.ucToolbarCustomerList.ExitEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExitEventHandler(this.ucToolbarCustomerList_ExitEventHandler);
            this.ucToolbarCustomerList.QueryEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarQueryEventHandler(this.ucToolbarCustomerList_QueryEventHandler);
            // 
            // ucStatusBarCustomerList
            // 
            this.ucStatusBarCustomerList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStatusBarCustomerList.Location = new System.Drawing.Point(0, 410);
            this.ucStatusBarCustomerList.Name = "ucStatusBarCustomerList";
            this.ucStatusBarCustomerList.Size = new System.Drawing.Size(796, 22);
            this.ucStatusBarCustomerList.TabIndex = 1;
            // 
            // gridCustomerList
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridCustomerList.DisplayLayout.Appearance = appearance1;
            this.gridCustomerList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridCustomerList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridCustomerList.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridCustomerList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.gridCustomerList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridCustomerList.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.gridCustomerList.DisplayLayout.MaxColScrollRegions = 1;
            this.gridCustomerList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridCustomerList.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridCustomerList.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.gridCustomerList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridCustomerList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.gridCustomerList.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridCustomerList.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridCustomerList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridCustomerList.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.gridCustomerList.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.gridCustomerList.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.gridCustomerList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridCustomerList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.gridCustomerList.DisplayLayout.Override.RowAppearance = appearance10;
            this.gridCustomerList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridCustomerList.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.gridCustomerList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridCustomerList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridCustomerList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridCustomerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCustomerList.Location = new System.Drawing.Point(0, 26);
            this.gridCustomerList.Name = "gridCustomerList";
            this.gridCustomerList.Size = new System.Drawing.Size(796, 384);
            this.gridCustomerList.TabIndex = 2;
            this.gridCustomerList.Tag = resources.GetString("gridCustomerList.Tag");
            this.gridCustomerList.Text = "ultraGrid1";
            this.gridCustomerList.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridCustomerList_InitializeLayout);
            this.gridCustomerList.AfterRowActivate += new System.EventHandler(this.gridCustomerList_AfterRowActivate);
            // 
            // frmCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 432);
            this.Controls.Add(this.gridCustomerList);
            this.Controls.Add(this.ucStatusBarCustomerList);
            this.Controls.Add(this.ucToolbarCustomerList);
            this.Name = "frmCustomerList";
            this.Tag = "rsid:Label.R00065";
            this.Text = "frmCustomerList";
            this.Load += new System.EventHandler(this.frmCustomerList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomerList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucToolbar ucToolbarCustomerList;
        private UserControls.ucStatusBar ucStatusBarCustomerList;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridCustomerList;
    }
}
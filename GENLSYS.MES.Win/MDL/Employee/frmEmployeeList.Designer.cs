namespace GENLSYS.MES.Win.MDL.Employee
{
    partial class frmEmployeeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeList));
            this.ucStatusBarEmployeeList = new GENLSYS.MES.UserControls.ucStatusBar();
            this.ucToolbarEmployeeList = new GENLSYS.MES.UserControls.ucToolbar();
            this.gridEmployeeList = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // ucStatusBarEmployeeList
            // 
            this.ucStatusBarEmployeeList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStatusBarEmployeeList.Location = new System.Drawing.Point(0, 436);
            this.ucStatusBarEmployeeList.Name = "ucStatusBarEmployeeList";
            this.ucStatusBarEmployeeList.Size = new System.Drawing.Size(809, 22);
            this.ucStatusBarEmployeeList.TabIndex = 0;
            // 
            // ucToolbarEmployeeList
            // 
            this.ucToolbarEmployeeList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ucToolbarEmployeeList.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbarEmployeeList.Location = new System.Drawing.Point(0, 0);
            this.ucToolbarEmployeeList.Name = "ucToolbarEmployeeList";
            this.ucToolbarEmployeeList.Size = new System.Drawing.Size(809, 26);
            this.ucToolbarEmployeeList.TabIndex = 1;
            this.ucToolbarEmployeeList.NewEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarNewEventHandler(this.ucToolbarEmployeeList_NewEventHandler);
            this.ucToolbarEmployeeList.DeleteEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarDeleteEventHandler(this.ucToolbarEmployeeList_DeleteEventHandler);
            this.ucToolbarEmployeeList.EditEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarEditEventHandler(this.ucToolbarEmployeeList_EditEventHandler);
            this.ucToolbarEmployeeList.ExportEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExportEventHandler(this.ucToolbarEmployeeList_ExportEventHandler);
            this.ucToolbarEmployeeList.ExitEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExitEventHandler(this.ucToolbarEmployeeList_ExitEventHandler);
            this.ucToolbarEmployeeList.QueryEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarQueryEventHandler(this.ucToolbarEmployeeList_QueryEventHandler);
            // 
            // gridEmployeeList
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridEmployeeList.DisplayLayout.Appearance = appearance1;
            this.gridEmployeeList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridEmployeeList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridEmployeeList.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridEmployeeList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.gridEmployeeList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridEmployeeList.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.gridEmployeeList.DisplayLayout.MaxColScrollRegions = 1;
            this.gridEmployeeList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridEmployeeList.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridEmployeeList.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.gridEmployeeList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridEmployeeList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.gridEmployeeList.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridEmployeeList.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridEmployeeList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridEmployeeList.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.gridEmployeeList.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.gridEmployeeList.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.gridEmployeeList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridEmployeeList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.gridEmployeeList.DisplayLayout.Override.RowAppearance = appearance10;
            this.gridEmployeeList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridEmployeeList.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.gridEmployeeList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridEmployeeList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridEmployeeList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridEmployeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmployeeList.Location = new System.Drawing.Point(0, 26);
            this.gridEmployeeList.Name = "gridEmployeeList";
            this.gridEmployeeList.Size = new System.Drawing.Size(809, 410);
            this.gridEmployeeList.TabIndex = 2;
            this.gridEmployeeList.Tag = resources.GetString("gridEmployeeList.Tag");
            this.gridEmployeeList.Text = "ultraGrid1";
            this.gridEmployeeList.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridEmployeeList_InitializeLayout);
            this.gridEmployeeList.AfterRowActivate += new System.EventHandler(this.gridEmployeeList_AfterRowActivate);
            // 
            // frmEmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 458);
            this.Controls.Add(this.gridEmployeeList);
            this.Controls.Add(this.ucToolbarEmployeeList);
            this.Controls.Add(this.ucStatusBarEmployeeList);
            this.Name = "frmEmployeeList";
            this.Tag = "rsid:Label.R00030";
            this.Text = "frmEmployeeList";
            this.Load += new System.EventHandler(this.frmEmployeeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployeeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucStatusBar ucStatusBarEmployeeList;
        private UserControls.ucToolbar ucToolbarEmployeeList;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridEmployeeList;
    }
}
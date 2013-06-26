namespace GENLSYS.MES.Win.SEC.Function
{
    partial class frmFunctionsList
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
            this.ucToolbarFunctionsList = new GENLSYS.MES.UserControls.ucToolbar();
            this.ucStatusBarFunctionsList = new GENLSYS.MES.UserControls.ucStatusBar();
            this.gridFunctionsList = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gridFunctionsList)).BeginInit();
            this.SuspendLayout();
            // 
            // ucToolbarFunctionsList
            // 
            this.ucToolbarFunctionsList.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbarFunctionsList.Location = new System.Drawing.Point(0, 0);
            this.ucToolbarFunctionsList.Name = "ucToolbarFunctionsList";
            this.ucToolbarFunctionsList.Size = new System.Drawing.Size(754, 26);
            this.ucToolbarFunctionsList.TabIndex = 0;
            this.ucToolbarFunctionsList.NewEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarNewEventHandler(this.ucToolbarFunctionsList_NewEventHandler);
            this.ucToolbarFunctionsList.DeleteEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarDeleteEventHandler(this.ucToolbarFunctionsList_DeleteEventHandler);
            this.ucToolbarFunctionsList.EditEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarEditEventHandler(this.ucToolbarFunctionsList_EditEventHandler);
            this.ucToolbarFunctionsList.ExportEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExportEventHandler(this.ucToolbarFunctionsList_ExportEventHandler);
            this.ucToolbarFunctionsList.ExitEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExitEventHandler(this.ucToolbarFunctionsList_ExitEventHandler);
            this.ucToolbarFunctionsList.QueryEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarQueryEventHandler(this.ucToolbarFunctionsList_QueryEventHandler);
            // 
            // ucStatusBarFunctionsList
            // 
            this.ucStatusBarFunctionsList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStatusBarFunctionsList.Location = new System.Drawing.Point(0, 399);
            this.ucStatusBarFunctionsList.Name = "ucStatusBarFunctionsList";
            this.ucStatusBarFunctionsList.Size = new System.Drawing.Size(754, 22);
            this.ucStatusBarFunctionsList.TabIndex = 1;
            // 
            // gridFunctionsList
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridFunctionsList.DisplayLayout.Appearance = appearance1;
            this.gridFunctionsList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridFunctionsList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridFunctionsList.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridFunctionsList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.gridFunctionsList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridFunctionsList.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.gridFunctionsList.DisplayLayout.MaxColScrollRegions = 1;
            this.gridFunctionsList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridFunctionsList.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridFunctionsList.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.gridFunctionsList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridFunctionsList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.gridFunctionsList.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridFunctionsList.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridFunctionsList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridFunctionsList.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.gridFunctionsList.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.gridFunctionsList.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.gridFunctionsList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridFunctionsList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.gridFunctionsList.DisplayLayout.Override.RowAppearance = appearance10;
            this.gridFunctionsList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridFunctionsList.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.gridFunctionsList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridFunctionsList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridFunctionsList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridFunctionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFunctionsList.Location = new System.Drawing.Point(0, 26);
            this.gridFunctionsList.Name = "gridFunctionsList";
            this.gridFunctionsList.Size = new System.Drawing.Size(754, 373);
            this.gridFunctionsList.TabIndex = 2;
            this.gridFunctionsList.Tag = "rsid:Label.R00143|rsid:Label.R00144|rsid:Label.R00145|rsid:Label.R0014901|rsid:La" +
                "bel.R0014902|rsid:Label.R0014903|rsid:Label.R00148|rsid:Label.R00147|rsid:Label." +
                "R00012|rsid:Label.R00013";
            this.gridFunctionsList.Text = "ultraGrid1";
            this.gridFunctionsList.AfterRowActivate += new System.EventHandler(this.gridFunctionsList_AfterRowActivate);
            // 
            // frmFunctionsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 421);
            this.Controls.Add(this.gridFunctionsList);
            this.Controls.Add(this.ucStatusBarFunctionsList);
            this.Controls.Add(this.ucToolbarFunctionsList);
            this.Name = "frmFunctionsList";
            this.Tag = "rsid:Label.R00149";
            this.Text = "frmFunctionsList";
            this.Load += new System.EventHandler(this.frmFunctionsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridFunctionsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucToolbar ucToolbarFunctionsList;
        private UserControls.ucStatusBar ucStatusBarFunctionsList;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridFunctionsList;
    }
}
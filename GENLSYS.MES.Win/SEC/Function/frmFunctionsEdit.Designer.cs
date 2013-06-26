namespace GENLSYS.MES.Win.SEC.Function
{
    partial class frmFunctionsEdit
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
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FUNCID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FUNCDESC");
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControlFunctions = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.ucmbParentFuncId = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.lblParentFuncId = new System.Windows.Forms.Label();
            this.numlevelno = new System.Windows.Forms.NumericUpDown();
            this.lblLevelNo = new System.Windows.Forms.Label();
            this.txtFuncUrl = new System.Windows.Forms.TextBox();
            this.lblFuncUrl = new System.Windows.Forms.Label();
            this.txtCreatedTime = new System.Windows.Forms.TextBox();
            this.txtCreatedUser = new System.Windows.Forms.TextBox();
            this.lblCreatedTime = new System.Windows.Forms.Label();
            this.lblCreatedUser = new System.Windows.Forms.Label();
            this.cmbFuncType = new System.Windows.Forms.ComboBox();
            this.lblFuncType = new System.Windows.Forms.Label();
            this.txtFuncDesc = new System.Windows.Forms.TextBox();
            this.lblFuncDesc = new System.Windows.Forms.Label();
            this.txtLastModifiedTime = new System.Windows.Forms.TextBox();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.lblLastModifiedTime = new System.Windows.Forms.Label();
            this.lblLastModifiedUser = new System.Windows.Forms.Label();
            this.txtFuncId = new System.Windows.Forms.TextBox();
            this.lblFuncId = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControlFunctions.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucmbParentFuncId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numlevelno)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(333, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(252, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 8;
            this.btnSave.Tag = "rsid:Button.R00001";
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 40);
            this.panel1.TabIndex = 10;
            // 
            // tabControlFunctions
            // 
            this.tabControlFunctions.Controls.Add(this.tabGeneral);
            this.tabControlFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlFunctions.Location = new System.Drawing.Point(0, 0);
            this.tabControlFunctions.Name = "tabControlFunctions";
            this.tabControlFunctions.SelectedIndex = 0;
            this.tabControlFunctions.Size = new System.Drawing.Size(660, 296);
            this.tabControlFunctions.TabIndex = 11;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.ucmbParentFuncId);
            this.tabGeneral.Controls.Add(this.lblParentFuncId);
            this.tabGeneral.Controls.Add(this.numlevelno);
            this.tabGeneral.Controls.Add(this.lblLevelNo);
            this.tabGeneral.Controls.Add(this.txtFuncUrl);
            this.tabGeneral.Controls.Add(this.lblFuncUrl);
            this.tabGeneral.Controls.Add(this.txtCreatedTime);
            this.tabGeneral.Controls.Add(this.txtCreatedUser);
            this.tabGeneral.Controls.Add(this.lblCreatedTime);
            this.tabGeneral.Controls.Add(this.lblCreatedUser);
            this.tabGeneral.Controls.Add(this.cmbFuncType);
            this.tabGeneral.Controls.Add(this.lblFuncType);
            this.tabGeneral.Controls.Add(this.txtFuncDesc);
            this.tabGeneral.Controls.Add(this.lblFuncDesc);
            this.tabGeneral.Controls.Add(this.txtLastModifiedTime);
            this.tabGeneral.Controls.Add(this.txtLastModifiedUser);
            this.tabGeneral.Controls.Add(this.lblLastModifiedTime);
            this.tabGeneral.Controls.Add(this.lblLastModifiedUser);
            this.tabGeneral.Controls.Add(this.txtFuncId);
            this.tabGeneral.Controls.Add(this.lblFuncId);
            this.tabGeneral.Location = new System.Drawing.Point(4, 21);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(652, 271);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Tag = "rsid:Tab.R00001";
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // ucmbParentFuncId
            // 
            this.ucmbParentFuncId.CheckedListSettings.CheckStateMember = "";
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            appearance21.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucmbParentFuncId.DisplayLayout.Appearance = appearance21;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.ucmbParentFuncId.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ucmbParentFuncId.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucmbParentFuncId.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance22.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance22.BorderColor = System.Drawing.SystemColors.Window;
            this.ucmbParentFuncId.DisplayLayout.GroupByBox.Appearance = appearance22;
            appearance23.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucmbParentFuncId.DisplayLayout.GroupByBox.BandLabelAppearance = appearance23;
            this.ucmbParentFuncId.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance24.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance24.BackColor2 = System.Drawing.SystemColors.Control;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance24.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucmbParentFuncId.DisplayLayout.GroupByBox.PromptAppearance = appearance24;
            this.ucmbParentFuncId.DisplayLayout.MaxColScrollRegions = 1;
            this.ucmbParentFuncId.DisplayLayout.MaxRowScrollRegions = 1;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucmbParentFuncId.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance14.BackColor = System.Drawing.SystemColors.Highlight;
            appearance14.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucmbParentFuncId.DisplayLayout.Override.ActiveRowAppearance = appearance14;
            this.ucmbParentFuncId.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucmbParentFuncId.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            this.ucmbParentFuncId.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance16.BorderColor = System.Drawing.Color.Silver;
            appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucmbParentFuncId.DisplayLayout.Override.CellAppearance = appearance16;
            this.ucmbParentFuncId.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucmbParentFuncId.DisplayLayout.Override.CellPadding = 0;
            appearance17.BackColor = System.Drawing.SystemColors.Control;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance17.BorderColor = System.Drawing.SystemColors.Window;
            this.ucmbParentFuncId.DisplayLayout.Override.GroupByRowAppearance = appearance17;
            appearance18.TextHAlignAsString = "Left";
            this.ucmbParentFuncId.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.ucmbParentFuncId.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucmbParentFuncId.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            this.ucmbParentFuncId.DisplayLayout.Override.RowAppearance = appearance19;
            this.ucmbParentFuncId.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucmbParentFuncId.DisplayLayout.Override.TemplateAddRowAppearance = appearance20;
            this.ucmbParentFuncId.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucmbParentFuncId.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucmbParentFuncId.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucmbParentFuncId.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucmbParentFuncId.Location = new System.Drawing.Point(479, 46);
            this.ucmbParentFuncId.Name = "ucmbParentFuncId";
            this.ucmbParentFuncId.Size = new System.Drawing.Size(148, 22);
            this.ucmbParentFuncId.TabIndex = 62;
            this.ucmbParentFuncId.Tag = "rsid:Label.R0014903,updt:Y,dbfd:parentfuncid";
            // 
            // lblParentFuncId
            // 
            this.lblParentFuncId.AutoSize = true;
            this.lblParentFuncId.Location = new System.Drawing.Point(338, 46);
            this.lblParentFuncId.Name = "lblParentFuncId";
            this.lblParentFuncId.Size = new System.Drawing.Size(89, 12);
            this.lblParentFuncId.TabIndex = 61;
            this.lblParentFuncId.Tag = "rsid:Label.R0014903";
            this.lblParentFuncId.Text = "Parent Func Id";
            // 
            // numlevelno
            // 
            this.numlevelno.Location = new System.Drawing.Point(161, 46);
            this.numlevelno.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numlevelno.Name = "numlevelno";
            this.numlevelno.Size = new System.Drawing.Size(148, 21);
            this.numlevelno.TabIndex = 60;
            this.numlevelno.Tag = "rsid:Label.R0014901,updt:Y,dbfd:levelno";
            // 
            // lblLevelNo
            // 
            this.lblLevelNo.AutoSize = true;
            this.lblLevelNo.Location = new System.Drawing.Point(20, 46);
            this.lblLevelNo.Name = "lblLevelNo";
            this.lblLevelNo.Size = new System.Drawing.Size(53, 12);
            this.lblLevelNo.TabIndex = 59;
            this.lblLevelNo.Tag = "rsid:Label.R0014901";
            this.lblLevelNo.Text = "Level No";
            // 
            // txtFuncUrl
            // 
            this.txtFuncUrl.Location = new System.Drawing.Point(161, 74);
            this.txtFuncUrl.Name = "txtFuncUrl";
            this.txtFuncUrl.Size = new System.Drawing.Size(466, 21);
            this.txtFuncUrl.TabIndex = 47;
            this.txtFuncUrl.Tag = "rsid:label.R0014902,updt:Y,dbfd:funcurl";
            // 
            // lblFuncUrl
            // 
            this.lblFuncUrl.AutoSize = true;
            this.lblFuncUrl.Location = new System.Drawing.Point(20, 74);
            this.lblFuncUrl.Name = "lblFuncUrl";
            this.lblFuncUrl.Size = new System.Drawing.Size(53, 12);
            this.lblFuncUrl.TabIndex = 46;
            this.lblFuncUrl.Tag = "rsid:Label.R0014902";
            this.lblFuncUrl.Text = "Func URL";
            // 
            // txtCreatedTime
            // 
            this.txtCreatedTime.Enabled = false;
            this.txtCreatedTime.Location = new System.Drawing.Point(479, 172);
            this.txtCreatedTime.Name = "txtCreatedTime";
            this.txtCreatedTime.Size = new System.Drawing.Size(148, 21);
            this.txtCreatedTime.TabIndex = 45;
            this.txtCreatedTime.Tag = "rsid:label.r00148,dbfd:createdtime";
            // 
            // txtCreatedUser
            // 
            this.txtCreatedUser.Enabled = false;
            this.txtCreatedUser.Location = new System.Drawing.Point(161, 172);
            this.txtCreatedUser.Name = "txtCreatedUser";
            this.txtCreatedUser.Size = new System.Drawing.Size(148, 21);
            this.txtCreatedUser.TabIndex = 44;
            this.txtCreatedUser.Tag = "rsid:label.r00147,dbfd:createduser";
            // 
            // lblCreatedTime
            // 
            this.lblCreatedTime.AutoSize = true;
            this.lblCreatedTime.Location = new System.Drawing.Point(338, 172);
            this.lblCreatedTime.Name = "lblCreatedTime";
            this.lblCreatedTime.Size = new System.Drawing.Size(77, 12);
            this.lblCreatedTime.TabIndex = 43;
            this.lblCreatedTime.Tag = "rsid:Label.R00148";
            this.lblCreatedTime.Text = "Created Time";
            // 
            // lblCreatedUser
            // 
            this.lblCreatedUser.AutoSize = true;
            this.lblCreatedUser.Location = new System.Drawing.Point(20, 172);
            this.lblCreatedUser.Name = "lblCreatedUser";
            this.lblCreatedUser.Size = new System.Drawing.Size(77, 12);
            this.lblCreatedUser.TabIndex = 42;
            this.lblCreatedUser.Tag = "rsid:Label.R00147";
            this.lblCreatedUser.Text = "Created User";
            // 
            // cmbFuncType
            // 
            this.cmbFuncType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFuncType.FormattingEnabled = true;
            this.cmbFuncType.Location = new System.Drawing.Point(479, 20);
            this.cmbFuncType.Name = "cmbFuncType";
            this.cmbFuncType.Size = new System.Drawing.Size(148, 20);
            this.cmbFuncType.TabIndex = 39;
            this.cmbFuncType.Tag = "rsid:Label.R00144,isrq:Y,updt:Y,dbfd:functype";
            // 
            // lblFuncType
            // 
            this.lblFuncType.AutoSize = true;
            this.lblFuncType.Location = new System.Drawing.Point(338, 23);
            this.lblFuncType.Name = "lblFuncType";
            this.lblFuncType.Size = new System.Drawing.Size(59, 12);
            this.lblFuncType.TabIndex = 38;
            this.lblFuncType.Tag = "rsid:Label.R00144,isrq:Y";
            this.lblFuncType.Text = "Func Type";
            // 
            // txtFuncDesc
            // 
            this.txtFuncDesc.Location = new System.Drawing.Point(161, 101);
            this.txtFuncDesc.Multiline = true;
            this.txtFuncDesc.Name = "txtFuncDesc";
            this.txtFuncDesc.Size = new System.Drawing.Size(466, 65);
            this.txtFuncDesc.TabIndex = 37;
            this.txtFuncDesc.Tag = "rsid:label.r00145,maxl:250,updt:Y,dbfd:funcdesc";
            // 
            // lblFuncDesc
            // 
            this.lblFuncDesc.AutoSize = true;
            this.lblFuncDesc.Location = new System.Drawing.Point(20, 101);
            this.lblFuncDesc.Name = "lblFuncDesc";
            this.lblFuncDesc.Size = new System.Drawing.Size(59, 12);
            this.lblFuncDesc.TabIndex = 36;
            this.lblFuncDesc.Tag = "rsid:Label.R00145";
            this.lblFuncDesc.Text = "Func Desc";
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Enabled = false;
            this.txtLastModifiedTime.Location = new System.Drawing.Point(479, 199);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.Size = new System.Drawing.Size(148, 21);
            this.txtLastModifiedTime.TabIndex = 35;
            this.txtLastModifiedTime.Tag = "rsid:label.r00013,dbfd:lastmodifiedtime";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Enabled = false;
            this.txtLastModifiedUser.Location = new System.Drawing.Point(161, 199);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.Size = new System.Drawing.Size(148, 21);
            this.txtLastModifiedUser.TabIndex = 34;
            this.txtLastModifiedUser.Tag = "rsid:label.r00012,dbfd:lastmodifieduser";
            // 
            // lblLastModifiedTime
            // 
            this.lblLastModifiedTime.AutoSize = true;
            this.lblLastModifiedTime.Location = new System.Drawing.Point(338, 199);
            this.lblLastModifiedTime.Name = "lblLastModifiedTime";
            this.lblLastModifiedTime.Size = new System.Drawing.Size(113, 12);
            this.lblLastModifiedTime.TabIndex = 33;
            this.lblLastModifiedTime.Tag = "rsid:Label.R00013";
            this.lblLastModifiedTime.Text = "Last Modified Time";
            // 
            // lblLastModifiedUser
            // 
            this.lblLastModifiedUser.AutoSize = true;
            this.lblLastModifiedUser.Location = new System.Drawing.Point(20, 199);
            this.lblLastModifiedUser.Name = "lblLastModifiedUser";
            this.lblLastModifiedUser.Size = new System.Drawing.Size(113, 12);
            this.lblLastModifiedUser.TabIndex = 32;
            this.lblLastModifiedUser.Tag = "rsid:Label.R00012";
            this.lblLastModifiedUser.Text = "Last Modified User";
            // 
            // txtFuncId
            // 
            this.txtFuncId.Location = new System.Drawing.Point(161, 17);
            this.txtFuncId.Name = "txtFuncId";
            this.txtFuncId.Size = new System.Drawing.Size(148, 21);
            this.txtFuncId.TabIndex = 31;
            this.txtFuncId.Tag = "rsid:Label.R00143,isrq:Y,maxl:64,updt:Y,dbfd:funcid";
            // 
            // lblFuncId
            // 
            this.lblFuncId.AutoSize = true;
            this.lblFuncId.Location = new System.Drawing.Point(20, 20);
            this.lblFuncId.Name = "lblFuncId";
            this.lblFuncId.Size = new System.Drawing.Size(47, 12);
            this.lblFuncId.TabIndex = 30;
            this.lblFuncId.Tag = "rsid:Label.R00143,isrq:Y";
            this.lblFuncId.Text = "Func Id";
            // 
            // frmFunctionsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 336);
            this.Controls.Add(this.tabControlFunctions);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFunctionsEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "rsid:Label.R00149";
            this.Text = "frmFunctionEdit";
            this.Load += new System.EventHandler(this.frmFunctionsEdit_Load);
            this.panel1.ResumeLayout(false);
            this.tabControlFunctions.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucmbParentFuncId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numlevelno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControlFunctions;
        private System.Windows.Forms.TabPage tabGeneral;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucmbParentFuncId;
        private System.Windows.Forms.Label lblParentFuncId;
        private System.Windows.Forms.NumericUpDown numlevelno;
        private System.Windows.Forms.Label lblLevelNo;
        private System.Windows.Forms.TextBox txtFuncUrl;
        private System.Windows.Forms.Label lblFuncUrl;
        private System.Windows.Forms.TextBox txtCreatedTime;
        private System.Windows.Forms.TextBox txtCreatedUser;
        private System.Windows.Forms.Label lblCreatedTime;
        private System.Windows.Forms.Label lblCreatedUser;
        private System.Windows.Forms.ComboBox cmbFuncType;
        private System.Windows.Forms.Label lblFuncType;
        private System.Windows.Forms.TextBox txtFuncDesc;
        private System.Windows.Forms.Label lblFuncDesc;
        private System.Windows.Forms.TextBox txtLastModifiedTime;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.Label lblLastModifiedTime;
        private System.Windows.Forms.Label lblLastModifiedUser;
        private System.Windows.Forms.TextBox txtFuncId;
        private System.Windows.Forms.Label lblFuncId;

    }
}
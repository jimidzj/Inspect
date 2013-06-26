namespace GENLSYS.MES.Win.INP.Supplement
{
    partial class frmSupplementList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplementList));
            this.ucToolbar1 = new GENLSYS.MES.UserControls.ucToolbar();
            this.ucStatusBar1 = new GENLSYS.MES.UserControls.ucStatusBar();
            this.pQuery = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStyleNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSupplementNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustOrderNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.grdQuery = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.txtFactory = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pQuery.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // ucToolbar1
            // 
            this.ucToolbar1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ucToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbar1.Location = new System.Drawing.Point(0, 0);
            this.ucToolbar1.Name = "ucToolbar1";
            this.ucToolbar1.Size = new System.Drawing.Size(1038, 26);
            this.ucToolbar1.TabIndex = 0;
            this.ucToolbar1.NewEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarNewEventHandler(this.ucToolbar1_NewEventHandler);
            this.ucToolbar1.ExitEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarExitEventHandler(this.ucToolbar1_ExitEventHandler);
            this.ucToolbar1.QueryEventHandler += new GENLSYS.MES.UserControls.ucToolbar.ucToolbarQueryEventHandler(this.ucToolbar1_QueryEventHandler);
            // 
            // ucStatusBar1
            // 
            this.ucStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStatusBar1.Location = new System.Drawing.Point(0, 455);
            this.ucStatusBar1.Name = "ucStatusBar1";
            this.ucStatusBar1.Size = new System.Drawing.Size(1038, 22);
            this.ucStatusBar1.TabIndex = 1;
            // 
            // pQuery
            // 
            this.pQuery.BackColor = System.Drawing.SystemColors.Info;
            this.pQuery.Controls.Add(this.groupBox1);
            this.pQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.pQuery.Location = new System.Drawing.Point(0, 26);
            this.pQuery.Name = "pQuery";
            this.pQuery.Size = new System.Drawing.Size(1038, 85);
            this.pQuery.TabIndex = 15;
            this.pQuery.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFactory);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSize);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtColor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtStyleNo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSupplementNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCustOrderNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1038, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "rsid:Label.R01024";
            this.groupBox1.Text = "查询条件";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(611, 54);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(137, 21);
            this.txtSize.TabIndex = 30;
            this.txtSize.Tag = "rsid:Label.R01028,maxl:64,dbfd:size,dbty:string";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(546, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 29;
            this.label4.Tag = "rsid:Label.R01028";
            this.label4.Text = "Size:";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(370, 51);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(137, 21);
            this.txtColor.TabIndex = 28;
            this.txtColor.Tag = "rsid:Label.R01027,maxl:64,dbfd:color,dbty:string";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 27;
            this.label2.Tag = "rsid:Label.R01027";
            this.label2.Text = "Color:";
            // 
            // txtStyleNo
            // 
            this.txtStyleNo.Location = new System.Drawing.Point(108, 51);
            this.txtStyleNo.Name = "txtStyleNo";
            this.txtStyleNo.Size = new System.Drawing.Size(137, 21);
            this.txtStyleNo.TabIndex = 26;
            this.txtStyleNo.Tag = "rsid:Label.R01026,maxl:64,dbfd:styleno,dbty:string";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 25;
            this.label6.Tag = "rsid:Label.R01026";
            this.label6.Text = "Style No:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(611, 24);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(137, 21);
            this.txtCustomer.TabIndex = 24;
            this.txtCustomer.Tag = "rsid:Label.R01020,maxl:64,dbfd:customername,dbty:string";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(546, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 23;
            this.label5.Tag = "rsid:Label.R01020";
            this.label5.Text = "Customer:";
            // 
            // txtSupplementNo
            // 
            this.txtSupplementNo.Location = new System.Drawing.Point(108, 24);
            this.txtSupplementNo.Name = "txtSupplementNo";
            this.txtSupplementNo.Size = new System.Drawing.Size(137, 21);
            this.txtSupplementNo.TabIndex = 22;
            this.txtSupplementNo.Tag = "rsid:Label.R02042,maxl:64,dbfd:rsupplementno,dbty:string";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 21;
            this.label3.Tag = "rsid:Label.R02042";
            this.label3.Text = "Supplement No:";
            // 
            // txtCustOrderNo
            // 
            this.txtCustOrderNo.Location = new System.Drawing.Point(370, 24);
            this.txtCustOrderNo.Name = "txtCustOrderNo";
            this.txtCustOrderNo.Size = new System.Drawing.Size(137, 21);
            this.txtCustOrderNo.TabIndex = 20;
            this.txtCustOrderNo.Tag = "rsid:Label.R01019,maxl:64,dbfd:custorderno,dbty:string";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 19;
            this.label1.Tag = "rsid:Label.R01025";
            this.label1.Text = "Cust Order No:";
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::GENLSYS.MES.Win.Properties.Resources.query;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(852, 52);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Tag = "rsid:Button.R00003";
            this.btnQuery.Text = "Query";
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
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
            this.grdQuery.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdQuery.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.grdQuery.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdQuery.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdQuery.Location = new System.Drawing.Point(0, 111);
            this.grdQuery.Name = "grdQuery";
            this.grdQuery.Size = new System.Drawing.Size(1038, 344);
            this.grdQuery.TabIndex = 18;
            this.grdQuery.Tag = resources.GetString("grdQuery.Tag");
            this.grdQuery.Text = "ultraGrid1";
            this.grdQuery.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdQuery_InitializeLayout);
            // 
            // txtFactory
            // 
            this.txtFactory.Location = new System.Drawing.Point(838, 22);
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.Size = new System.Drawing.Size(137, 21);
            this.txtFactory.TabIndex = 46;
            this.txtFactory.Tag = "rsid:Label.R01021,dbty:string,updt:Y,dbfd:factory";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(768, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 45;
            this.label7.Tag = "rsid:Label.R01021";
            this.label7.Text = "Factory:";
            // 
            // frmSupplementList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 477);
            this.Controls.Add(this.grdQuery);
            this.Controls.Add(this.pQuery);
            this.Controls.Add(this.ucStatusBar1);
            this.Controls.Add(this.ucToolbar1);
            this.Name = "frmSupplementList";
            this.Tag = "rsid:Label.R01071";
            this.Text = "frmComplementList";
            this.Load += new System.EventHandler(this.frmComplementList_Load);
            this.pQuery.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucToolbar ucToolbar1;
        private UserControls.ucStatusBar ucStatusBar1;
        private System.Windows.Forms.Panel pQuery;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQuery;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdQuery;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSupplementNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustOrderNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStyleNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFactory;
        private System.Windows.Forms.Label label7;
    }
}
namespace GENLSYS.MES.Win.INP.Ship
{
    partial class frmRequestPay
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtShipNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.grdDetail = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 24;
            this.label3.Tag = "rsid:Label.R01078,isrq:Y";
            this.label3.Text = "Ship No:";
            // 
            // txtShipNo
            // 
            this.txtShipNo.BackColor = System.Drawing.Color.White;
            this.txtShipNo.Enabled = false;
            this.txtShipNo.Location = new System.Drawing.Point(101, 16);
            this.txtShipNo.Name = "txtShipNo";
            this.txtShipNo.Size = new System.Drawing.Size(164, 21);
            this.txtShipNo.TabIndex = 25;
            this.txtShipNo.Tag = "rsid:Label.R01078,isrq:Y,maxl:64,updt:Y,dbfd:workorderno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 36;
            this.label2.Tag = "rsid:Label.R01020";
            this.label2.Text = "Customer:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.White;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(380, 16);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(164, 21);
            this.txtCustomer.TabIndex = 37;
            this.txtCustomer.Tag = "rsid:Label.R01020,isrq:Y,maxl:64,updt:Y,dbfd:workorderno";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbTemplate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbCurrency);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCustomer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtShipNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 79);
            this.panel1.TabIndex = 36;
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.Location = new System.Drawing.Point(380, 43);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(164, 20);
            this.cmbTemplate.TabIndex = 41;
            this.cmbTemplate.Tag = "rsid:Label.R0104402,maxl:64,updt:Y,dbfd:currency,dbty:string";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 40;
            this.label4.Tag = "rsid:Label.R0104402,isrq:Y";
            this.label4.Text = "Template:";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(101, 43);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(164, 20);
            this.cmbCurrency.TabIndex = 39;
            this.cmbCurrency.Tag = "rsid:Label.R01040,maxl:64,updt:Y,dbfd:currency,dbty:string";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 38;
            this.label1.Tag = "rsid:Label.R01040,isrq:Y";
            this.label1.Text = "Currency:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 41);
            this.panel2.TabIndex = 37;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(217, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 21);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Tag = "rsid:Button.R00031";
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(298, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.grdDetail);
            this.groupBox.Controls.Add(this.toolStrip1);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 79);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(591, 273);
            this.groupBox.TabIndex = 38;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "其他费用";
            // 
            // grdDetail
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdDetail.DisplayLayout.Appearance = appearance1;
            this.grdDetail.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdDetail.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdDetail.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdDetail.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grdDetail.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdDetail.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.grdDetail.DisplayLayout.MaxColScrollRegions = 1;
            this.grdDetail.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdDetail.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdDetail.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.grdDetail.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdDetail.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.grdDetail.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdDetail.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdDetail.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdDetail.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grdDetail.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.grdDetail.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.grdDetail.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdDetail.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.grdDetail.DisplayLayout.Override.RowAppearance = appearance10;
            this.grdDetail.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdDetail.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.grdDetail.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdDetail.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.Location = new System.Drawing.Point(3, 42);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.Size = new System.Drawing.Size(585, 228);
            this.grdDetail.TabIndex = 47;
            this.grdDetail.Tag = "rsid:|rsid:Label.R0104401|rsid:Label.R01042|rsid:Label.R01040|rsid:Label.R01041|r" +
                "sid:Label.R0104403";
            this.grdDetail.Text = "grdOtherFee";
            this.grdDetail.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdDetail_AfterCellUpdate);
            this.grdDetail.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdDetail_InitializeLayout);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.toolStripSeparator1,
            this.tsbDelete,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(585, 25);
            this.toolStrip1.TabIndex = 46;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::GENLSYS.MES.Win.Properties.Resources.addline;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(52, 22);
            this.tsbAdd.Tag = "rsid:Button.R00007";
            this.tsbAdd.Text = "增行";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::GENLSYS.MES.Win.Properties.Resources.deleteline;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(52, 22);
            this.tsbDelete.Tag = "rsid:Button.R00008";
            this.tsbDelete.Text = "删行";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 22);
            // 
            // frmRequestPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 393);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRequestPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "rsid:Label.R02065";
            this.Text = "frmRequestPay";
            this.Load += new System.EventHandler(this.frmRequestPay_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShipNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdDetail;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}
namespace GENLSYS.MES.Win.INP.Supplement
{
    partial class frmSupplement
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFactory = new System.Windows.Forms.TextBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustOrderNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSupplementNo = new System.Windows.Forms.TextBox();
            this.cmbWorkGroup = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbStep = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdDetail = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFactory);
            this.groupBox1.Controls.Add(this.cmbCustomer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCustOrderNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSupplementNo);
            this.groupBox1.Controls.Add(this.cmbWorkGroup);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbStep);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 99);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // txtFactory
            // 
            this.txtFactory.Location = new System.Drawing.Point(465, 14);
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.Size = new System.Drawing.Size(159, 21);
            this.txtFactory.TabIndex = 44;
            this.txtFactory.Tag = "rsid:Label.R01021,dbty:string,updt:Y,dbfd:factory";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(141, 41);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(159, 20);
            this.cmbCustomer.TabIndex = 38;
            this.cmbCustomer.Tag = "rsid:Label.R01020,isrq:Y,maxl:64,updt:Y,dbfd:customerid";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 43;
            this.label5.Tag = "rsid:Label.R01021";
            this.label5.Text = "Factory:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 37;
            this.label4.Tag = "rsid:Label.R01020,isrq:Y";
            this.label4.Text = "Customer:";
            // 
            // txtCustOrderNo
            // 
            this.txtCustOrderNo.BackColor = System.Drawing.Color.White;
            this.txtCustOrderNo.Location = new System.Drawing.Point(465, 41);
            this.txtCustOrderNo.Name = "txtCustOrderNo";
            this.txtCustOrderNo.Size = new System.Drawing.Size(159, 21);
            this.txtCustOrderNo.TabIndex = 36;
            this.txtCustOrderNo.Tag = "rsid:Label.R01025,isrq:Y,maxl:64,updt:Y,dbfd:supplementno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 35;
            this.label2.Tag = "rsid:Label.R01025,isrq:Y";
            this.label2.Text = "Cust Order No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 34;
            this.label1.Tag = "rsid:Label.R02042,isrq:Y";
            this.label1.Text = "Supplement No:";
            // 
            // txtSupplementNo
            // 
            this.txtSupplementNo.BackColor = System.Drawing.Color.White;
            this.txtSupplementNo.Location = new System.Drawing.Point(141, 12);
            this.txtSupplementNo.Name = "txtSupplementNo";
            this.txtSupplementNo.Size = new System.Drawing.Size(159, 21);
            this.txtSupplementNo.TabIndex = 33;
            this.txtSupplementNo.Tag = "rsid:Label.R02042,isrq:Y,maxl:64,updt:Y,dbfd:supplementno";
            // 
            // cmbWorkGroup
            // 
            this.cmbWorkGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkGroup.FormattingEnabled = true;
            this.cmbWorkGroup.Location = new System.Drawing.Point(465, 69);
            this.cmbWorkGroup.Name = "cmbWorkGroup";
            this.cmbWorkGroup.Size = new System.Drawing.Size(159, 20);
            this.cmbWorkGroup.TabIndex = 25;
            this.cmbWorkGroup.Tag = "rsid:Label.R01016,isrq:Y,maxl:64,updt:Y,dbfd:workgroup";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 24;
            this.label9.Tag = "rsid:Label.R01016,isrq:Y";
            this.label9.Text = "Work Group:";
            // 
            // cmbStep
            // 
            this.cmbStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStep.FormattingEnabled = true;
            this.cmbStep.Items.AddRange(new object[] {
            "检品",
            "X线"});
            this.cmbStep.Location = new System.Drawing.Point(141, 67);
            this.cmbStep.Name = "cmbStep";
            this.cmbStep.Size = new System.Drawing.Size(159, 20);
            this.cmbStep.TabIndex = 23;
            this.cmbStep.Tag = "rsid:Label.R00950,isrq:Y,maxl:64,updt:Y,dbfd:step";
            this.cmbStep.SelectedIndexChanged += new System.EventHandler(this.cmbStep_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 22;
            this.label3.Tag = "rsid:Label.R00950,isrq:Y";
            this.label3.Text = "Step:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 409);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 41);
            this.panel2.TabIndex = 31;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(256, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 12;
            this.btnSave.Tag = "rsid:Button.R00001";
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(337, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdDetail);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 310);
            this.panel1.TabIndex = 32;
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
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdDetail.Location = new System.Drawing.Point(0, 25);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.Size = new System.Drawing.Size(668, 285);
            this.grdDetail.TabIndex = 46;
            this.grdDetail.Tag = "rsid:Label.R01025|rsid:Label.R01026|rsid:Label.R01027|rsid:Label.R01028|rsid:Labe" +
                "l.R01065|rsid:Label.R02026|rsid:Label.R02066";
            this.grdDetail.Text = "ultraGrid1";
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(668, 25);
            this.toolStrip1.TabIndex = 45;
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
            // frmSupplement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSupplement";
            this.Tag = "rsid:Label.R01071";
            this.Text = "frmComplement";
            this.Load += new System.EventHandler(this.frmComplement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbWorkGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupplementNo;
        private System.Windows.Forms.TextBox txtCustOrderNo;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdDetail;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFactory;
        private System.Windows.Forms.Label label5;
    }
}
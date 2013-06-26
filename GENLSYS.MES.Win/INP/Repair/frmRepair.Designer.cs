namespace GENLSYS.MES.Win.INP.Repair
{
    partial class frmRepair
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSignature = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbJointType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbToStep = new System.Windows.Forms.ComboBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.cmbWorkGroup = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numFailedQty = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numSuccessQty = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRepairQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStyleNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustOrderNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdDetail = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFailedQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSuccessQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 446);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(941, 41);
            this.panel2.TabIndex = 32;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(396, 10);
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
            this.btnCancel.Location = new System.Drawing.Point(477, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSignature);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbJointType);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbToStep);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.cmbWorkGroup);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numFailedQty);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numSuccessQty);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtRepairQty);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSize);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtColor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtStyleNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCustOrderNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(941, 157);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // txtSignature
            // 
            this.txtSignature.Location = new System.Drawing.Point(462, 126);
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.Size = new System.Drawing.Size(160, 21);
            this.txtSignature.TabIndex = 33;
            this.txtSignature.Tag = "rsid:Label.R010763,isrq:N,maxl:64,updt:Y,dbfd:signature";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(334, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 32;
            this.label12.Tag = "rsid:Label.R010763";
            this.label12.Text = "Signature:";
            // 
            // cmbJointType
            // 
            this.cmbJointType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJointType.FormattingEnabled = true;
            this.cmbJointType.Location = new System.Drawing.Point(146, 126);
            this.cmbJointType.Name = "cmbJointType";
            this.cmbJointType.Size = new System.Drawing.Size(160, 20);
            this.cmbJointType.TabIndex = 31;
            this.cmbJointType.Tag = "rsid:Label.R010762,maxl:64,updt:Y,dbfd:jointtype";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 30;
            this.label11.Tag = "rsid:Label.R010762,isrq:N";
            this.label11.Text = "Joint Type:";
            // 
            // cmbToStep
            // 
            this.cmbToStep.FormattingEnabled = true;
            this.cmbToStep.Location = new System.Drawing.Point(146, 74);
            this.cmbToStep.Name = "cmbToStep";
            this.cmbToStep.Size = new System.Drawing.Size(160, 20);
            this.cmbToStep.TabIndex = 29;
            this.cmbToStep.Tag = "rsid:Label.R02053,maxl:64,updt:Y,dbfd:toStep";
            this.cmbToStep.SelectedIndexChanged += new System.EventHandler(this.cmbToStep_SelectedIndexChanged);
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(462, 20);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(160, 21);
            this.txtCustomer.TabIndex = 28;
            this.txtCustomer.Tag = "rsid:Label.R01020,maxl:64,updt:Y,dbfd:customerid";
            // 
            // cmbWorkGroup
            // 
            this.cmbWorkGroup.FormattingEnabled = true;
            this.cmbWorkGroup.Location = new System.Drawing.Point(462, 73);
            this.cmbWorkGroup.Name = "cmbWorkGroup";
            this.cmbWorkGroup.Size = new System.Drawing.Size(160, 20);
            this.cmbWorkGroup.TabIndex = 27;
            this.cmbWorkGroup.Tag = "rsid:Label.R01016,isrq:Y,maxl:64,updt:Y,dbfd:workgroup";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(334, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 26;
            this.label10.Tag = "rsid:Label.R01016,isrq:N";
            this.label10.Text = "Work Group:";
            // 
            // numFailedQty
            // 
            this.numFailedQty.Enabled = false;
            this.numFailedQty.Location = new System.Drawing.Point(770, 99);
            this.numFailedQty.Name = "numFailedQty";
            this.numFailedQty.Size = new System.Drawing.Size(159, 21);
            this.numFailedQty.TabIndex = 25;
            this.numFailedQty.Tag = "rsid:Label.R01076,isrq:Y,maxl:64,updt:Y,dbfd:failedqty";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(650, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 24;
            this.label9.Tag = "rsid:Label.R01076,isrq:Y";
            this.label9.Text = "Failed Qty:";
            // 
            // numSuccessQty
            // 
            this.numSuccessQty.Location = new System.Drawing.Point(462, 99);
            this.numSuccessQty.Name = "numSuccessQty";
            this.numSuccessQty.Size = new System.Drawing.Size(160, 21);
            this.numSuccessQty.TabIndex = 23;
            this.numSuccessQty.Tag = "rsid:Label.R01075,isrq:Y,maxl:64,updt:Y,dbfd:successqty";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(334, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 22;
            this.label8.Tag = "rsid:Label.R01075,isrq:Y";
            this.label8.Text = "Success Qty:";
            // 
            // txtRepairQty
            // 
            this.txtRepairQty.Enabled = false;
            this.txtRepairQty.Location = new System.Drawing.Point(146, 100);
            this.txtRepairQty.Name = "txtRepairQty";
            this.txtRepairQty.Size = new System.Drawing.Size(160, 21);
            this.txtRepairQty.TabIndex = 21;
            this.txtRepairQty.Tag = "rsid:Label.R01074,isrq:N,maxl:64,updt:Y,dbfd:factory";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 20;
            this.label7.Tag = "rsid:Label.R01074";
            this.label7.Text = "Repair Qty:";
            // 
            // txtSize
            // 
            this.txtSize.Enabled = false;
            this.txtSize.Location = new System.Drawing.Point(769, 46);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(160, 21);
            this.txtSize.TabIndex = 19;
            this.txtSize.Tag = "rsid:Label.R01028,isrq:N,maxl:64,updt:Y,dbfd:factory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(650, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 18;
            this.label6.Tag = "rsid:Label.R01028";
            this.label6.Text = "Size:";
            // 
            // txtColor
            // 
            this.txtColor.Enabled = false;
            this.txtColor.Location = new System.Drawing.Point(462, 46);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(160, 21);
            this.txtColor.TabIndex = 17;
            this.txtColor.Tag = "rsid:Label.R01027,isrq:N,maxl:64,updt:Y,dbfd:factory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 16;
            this.label5.Tag = "rsid:Label.R01027";
            this.label5.Text = "Color:";
            // 
            // txtStyleNo
            // 
            this.txtStyleNo.Enabled = false;
            this.txtStyleNo.Location = new System.Drawing.Point(146, 47);
            this.txtStyleNo.Name = "txtStyleNo";
            this.txtStyleNo.Size = new System.Drawing.Size(160, 21);
            this.txtStyleNo.TabIndex = 15;
            this.txtStyleNo.Tag = "rsid:Label.R01026,isrq:N,maxl:64,updt:Y,dbfd:factory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 14;
            this.label3.Tag = "rsid:Label.R01026";
            this.label3.Text = "Style No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Tag = "rsid:Label.R02053,isrq:N";
            this.label4.Text = "To Step:";
            // 
            // txtCustOrderNo
            // 
            this.txtCustOrderNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustOrderNo.Enabled = false;
            this.txtCustOrderNo.Location = new System.Drawing.Point(146, 20);
            this.txtCustOrderNo.Name = "txtCustOrderNo";
            this.txtCustOrderNo.Size = new System.Drawing.Size(160, 21);
            this.txtCustOrderNo.TabIndex = 9;
            this.txtCustOrderNo.Tag = "rsid:Label.R01025,isrq:Y,maxl:64,updt:Y,dbfd:workorderno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 7;
            this.label2.Tag = "rsid:Label.R01020";
            this.label2.Text = "Customer:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 6;
            this.label1.Tag = "rsid:Label.R01025";
            this.label1.Text = "Cust Order No:";
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
            this.grdDetail.Location = new System.Drawing.Point(0, 157);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.Size = new System.Drawing.Size(941, 289);
            this.grdDetail.TabIndex = 36;
            this.grdDetail.Tag = "rsid:|rsid:|rsid:Label.R00038|rsid:Label.R02027|rsid:Label.R02037|rsid:Label.R010" +
                "761|rsid:Label.R02025";
            this.grdDetail.Text = "ultraGrid1";
            this.grdDetail.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdDetail_AfterCellUpdate);
            this.grdDetail.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdDetail_InitializeLayout);
            this.grdDetail.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.grdDetail_InitializeRow);
            // 
            // frmRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 487);
            this.Controls.Add(this.grdDetail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepair";
            this.Tag = "rsid:Label.R01072";
            this.Text = "frmRepair";
            this.Load += new System.EventHandler(this.frmRepair_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFailedQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSuccessQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustOrderNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStyleNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numFailedQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numSuccessQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRepairQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbWorkGroup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.ComboBox cmbToStep;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdDetail;
        private System.Windows.Forms.TextBox txtSignature;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbJointType;
        private System.Windows.Forms.Label label11;
    }
}
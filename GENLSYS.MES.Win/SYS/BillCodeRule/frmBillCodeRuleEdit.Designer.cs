namespace GENLSYS.MES.Win.SYS.BillCodeRule
{
    partial class frmBillCodeRuleEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbBaseValue = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbBCRStatus = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTimeFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBCRName = new System.Windows.Forms.TextBox();
            this.txtLastModifiedTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBCRId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grdBillCode = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.txtBillNoFormat = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillCode)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 309);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 49);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(297, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(216, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Tag = "rsid:Button.R00001";
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(588, 309);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtBillNoFormat);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.cmbBaseValue);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.cmbBCRStatus);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.numericUpDown5);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.numericUpDown4);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.numericUpDown3);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.numericUpDown2);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.numericUpDown1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmbTimeFormat);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtBCRName);
            this.tabPage1.Controls.Add(this.txtLastModifiedTime);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtLastModifiedUser);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtBCRId);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(580, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "rsid:Label.R00007";
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbBaseValue
            // 
            this.cmbBaseValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaseValue.FormattingEnabled = true;
            this.cmbBaseValue.Location = new System.Drawing.Point(432, 47);
            this.cmbBaseValue.Name = "cmbBaseValue";
            this.cmbBaseValue.Size = new System.Drawing.Size(125, 20);
            this.cmbBaseValue.TabIndex = 63;
            this.cmbBaseValue.Tag = "rsid:Label.R00827,isrq:Y,maxl:64,updt:Y,dbfd:basevalue";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(301, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 12);
            this.label14.TabIndex = 64;
            this.label14.Tag = "rsid:Label.R00827,isrq:Y";
            this.label14.Text = "Base Value:";
            // 
            // cmbBCRStatus
            // 
            this.cmbBCRStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBCRStatus.Enabled = false;
            this.cmbBCRStatus.FormattingEnabled = true;
            this.cmbBCRStatus.Location = new System.Drawing.Point(153, 154);
            this.cmbBCRStatus.Name = "cmbBCRStatus";
            this.cmbBCRStatus.Size = new System.Drawing.Size(125, 20);
            this.cmbBCRStatus.TabIndex = 11;
            this.cmbBCRStatus.Tag = "rsid:Label.R00501,isrq:Y,maxl:64,updt:Y,dbfd:bcrstatus";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 12);
            this.label13.TabIndex = 62;
            this.label13.Tag = "rsid:Label.R00501,isrq:Y";
            this.label13.Text = "BCR Status:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(432, 154);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Tag = "rsid:Label.R00497,isrq:Y,maxl:64,updt:Y,dbfd:iscycle";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(301, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 60;
            this.label12.Tag = "rsid:Label.R00497,YN";
            this.label12.Text = "Is Cycle:";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(153, 127);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(125, 21);
            this.numericUpDown5.TabIndex = 9;
            this.numericUpDown5.Tag = "rsid:Label.R00498,isrq:Y,maxl:64,updt:Y,dbfd:seqvaluelength";
            this.numericUpDown5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 58;
            this.label11.Tag = "rsid:Label.R00498,isrq:Y";
            this.label11.Text = "Seq Length:";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(432, 127);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(125, 21);
            this.numericUpDown4.TabIndex = 8;
            this.numericUpDown4.Tag = "rsid:Label.R00496,isrq:Y,maxl:64,updt:Y,dbfd:incrementby";
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(301, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 56;
            this.label8.Tag = "rsid:Label.R00496,isrq:Y";
            this.label8.Text = "Increment By:";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(153, 100);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(125, 21);
            this.numericUpDown3.TabIndex = 7;
            this.numericUpDown3.Tag = "rsid:Label.R00495,isrq:Y,maxl:64,updt:Y,dbfd:maxvalue";
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 54;
            this.label7.Tag = "rsid:Label.R00495,isrq:Y";
            this.label7.Text = "Max Value:";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(432, 100);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(125, 21);
            this.numericUpDown2.TabIndex = 6;
            this.numericUpDown2.Tag = "rsid:Label.R00494,isrq:Y,maxl:64,updt:Y,dbfd:minvalue";
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(301, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 52;
            this.label6.Tag = "rsid:Label.R00494,isrq:Y";
            this.label6.Text = "Min Value:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(153, 73);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(125, 21);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Tag = "rsid:Label.R00492,isrq:Y,maxl:64,updt:Y,dbfd:startwith";
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 50;
            this.label4.Tag = "rsid:Label.R00492,isrq:Y";
            this.label4.Text = "Start With:";
            // 
            // cmbTimeFormat
            // 
            this.cmbTimeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeFormat.FormattingEnabled = true;
            this.cmbTimeFormat.Location = new System.Drawing.Point(432, 73);
            this.cmbTimeFormat.Name = "cmbTimeFormat";
            this.cmbTimeFormat.Size = new System.Drawing.Size(125, 20);
            this.cmbTimeFormat.TabIndex = 4;
            this.cmbTimeFormat.Tag = "rsid:Label.R00491,isrq:N,maxl:64,updt:Y,dbfd:timeformat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 48;
            this.label3.Tag = "rsid:Label.R00491,isrq:N";
            this.label3.Text = "Time Format:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(153, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.Tag = "rsid:Label.R00489,isrq:N,maxl:64,updt:Y,dbfd:ffchars";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 45;
            this.label2.Tag = "rsid:Label.R00489,isrq:N";
            this.label2.Text = "First Free Chars";
            // 
            // txtBCRName
            // 
            this.txtBCRName.Location = new System.Drawing.Point(432, 20);
            this.txtBCRName.Multiline = true;
            this.txtBCRName.Name = "txtBCRName";
            this.txtBCRName.Size = new System.Drawing.Size(125, 21);
            this.txtBCRName.TabIndex = 2;
            this.txtBCRName.Tag = "rsid:Label.R00500,isrq:Y,maxl:64,updt:Y,dbfd:bcrname";
            // 
            // txtLastModifiedTime
            // 
            this.txtLastModifiedTime.Location = new System.Drawing.Point(432, 207);
            this.txtLastModifiedTime.Name = "txtLastModifiedTime";
            this.txtLastModifiedTime.ReadOnly = true;
            this.txtLastModifiedTime.Size = new System.Drawing.Size(125, 21);
            this.txtLastModifiedTime.TabIndex = 13;
            this.txtLastModifiedTime.Tag = "rsid:Label.R00013,isrq:N,maxl:64,updt:N,dbfd:lastmodifiedtime";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(301, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 12);
            this.label9.TabIndex = 42;
            this.label9.Tag = "rsid:Label.R00013,isrq:N";
            this.label9.Text = "Last Modified Time:";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Location = new System.Drawing.Point(153, 207);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.ReadOnly = true;
            this.txtLastModifiedUser.Size = new System.Drawing.Size(125, 21);
            this.txtLastModifiedUser.TabIndex = 12;
            this.txtLastModifiedUser.Tag = "rsid:Label.R00012,isrq:N,maxl:64,updt:N,dbfd:lastmodifieduser";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 12);
            this.label10.TabIndex = 40;
            this.label10.Tag = "rsid:Label.R00012,isrq:N";
            this.label10.Text = "Last Modified User:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 23;
            this.label5.Tag = "rsid:Label.R00500,isrq:Y";
            this.label5.Text = "BCR Name:";
            // 
            // txtBCRId
            // 
            this.txtBCRId.Location = new System.Drawing.Point(153, 20);
            this.txtBCRId.Name = "txtBCRId";
            this.txtBCRId.Size = new System.Drawing.Size(125, 21);
            this.txtBCRId.TabIndex = 1;
            this.txtBCRId.Tag = "rsid:Label.R00487,isrq:Y,maxl:64,updt:Y,dbfd:bcrid";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 15;
            this.label1.Tag = "rsid:Label.R00487,isrq:Y";
            this.label1.Text = "BCR Id:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdBillCode);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(580, 284);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "rsid:Tab.R00022";
            this.tabPage2.Text = "Value History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grdBillCode
            // 
            this.grdBillCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBillCode.Location = new System.Drawing.Point(3, 3);
            this.grdBillCode.Name = "grdBillCode";
            this.grdBillCode.Size = new System.Drawing.Size(574, 278);
            this.grdBillCode.TabIndex = 0;
            this.grdBillCode.Tag = "rsid:|rsid:Label.R00827|rsid:Label.R00490|rsid:Label.R00493|rsid:Label.R00502|rsi" +
                "d:Label.R00617|rsid:Label.R00618|rsid:Label.R00619|rsid:Label.R00620";
            this.grdBillCode.Text = "ultraGrid1";
            this.grdBillCode.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdBillCode_InitializeLayout);
            this.grdBillCode.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.grdBillCode_InitializeRow);
            // 
            // txtBillNoFormat
            // 
            this.txtBillNoFormat.Location = new System.Drawing.Point(153, 180);
            this.txtBillNoFormat.Name = "txtBillNoFormat";
            this.txtBillNoFormat.Size = new System.Drawing.Size(404, 21);
            this.txtBillNoFormat.TabIndex = 65;
            this.txtBillNoFormat.Tag = "rsid:Label.R00488,isrq:N,maxl:500,updt:Y,dbfd:billformat";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 180);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 12);
            this.label15.TabIndex = 66;
            this.label15.Tag = "rsid:Label.R00488,isrq:N";
            this.label15.Text = "Bill No Format";
            // 
            // frmBillCodeRuleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 358);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBillCodeRuleEdit";
            this.ShowInTaskbar = false;
            this.Tag = "rsid:Menu.M10506";
            this.Text = "frmBillCodeRuleEdit";
            this.Load += new System.EventHandler(this.frmBillCodeRuleEdit_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBillCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cmbBCRStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTimeFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBCRName;
        private System.Windows.Forms.TextBox txtLastModifiedTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBCRId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdBillCode;
        private System.Windows.Forms.ComboBox cmbBaseValue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBillNoFormat;
        private System.Windows.Forms.Label label15;

    }
}
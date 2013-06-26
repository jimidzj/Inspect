namespace GENLSYS.MES.Win.INP.Adjust
{
    partial class frmSupplementAdjust
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckTwiceInspect = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSupplementNo = new System.Windows.Forms.TextBox();
            this.cmbToStep = new System.Windows.Forms.ComboBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.cmbWorkGroup = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numPairQty = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPairQty)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckTwiceInspect);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSupplementNo);
            this.groupBox1.Controls.Add(this.cmbToStep);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.cmbWorkGroup);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numPairQty);
            this.groupBox1.Controls.Add(this.label9);
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
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 164);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // ckTwiceInspect
            // 
            this.ckTwiceInspect.AutoSize = true;
            this.ckTwiceInspect.Location = new System.Drawing.Point(286, 130);
            this.ckTwiceInspect.Name = "ckTwiceInspect";
            this.ckTwiceInspect.Size = new System.Drawing.Size(102, 16);
            this.ckTwiceInspect.TabIndex = 37;
            this.ckTwiceInspect.Tag = "rsid:Label.R02066,isrq:Y,maxl:64,updt:Y,dbfd:isreinspect";
            this.ckTwiceInspect.Text = "Twice Inspect";
            this.ckTwiceInspect.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 36;
            this.label7.Tag = "rsid:Label.R02042";
            this.label7.Text = "Supplement No:";
            // 
            // txtSupplementNo
            // 
            this.txtSupplementNo.BackColor = System.Drawing.Color.White;
            this.txtSupplementNo.Enabled = false;
            this.txtSupplementNo.Location = new System.Drawing.Point(136, 18);
            this.txtSupplementNo.Name = "txtSupplementNo";
            this.txtSupplementNo.Size = new System.Drawing.Size(122, 21);
            this.txtSupplementNo.TabIndex = 35;
            this.txtSupplementNo.Tag = "rsid:Label.R02042,isrq:Y,maxl:64,updt:Y,dbfd:supplementno";
            // 
            // cmbToStep
            // 
            this.cmbToStep.Enabled = false;
            this.cmbToStep.FormattingEnabled = true;
            this.cmbToStep.Location = new System.Drawing.Point(411, 46);
            this.cmbToStep.Name = "cmbToStep";
            this.cmbToStep.Size = new System.Drawing.Size(121, 20);
            this.cmbToStep.TabIndex = 29;
            this.cmbToStep.Tag = "rsid:Label.R02053,maxl:64,updt:Y,dbfd:toStep";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(411, 18);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(121, 21);
            this.txtCustomer.TabIndex = 28;
            this.txtCustomer.Tag = "rsid:Label.R01020,maxl:64,updt:Y,dbfd:customerid";
            // 
            // cmbWorkGroup
            // 
            this.cmbWorkGroup.Enabled = false;
            this.cmbWorkGroup.FormattingEnabled = true;
            this.cmbWorkGroup.Location = new System.Drawing.Point(411, 71);
            this.cmbWorkGroup.Name = "cmbWorkGroup";
            this.cmbWorkGroup.Size = new System.Drawing.Size(121, 20);
            this.cmbWorkGroup.TabIndex = 27;
            this.cmbWorkGroup.Tag = "rsid:Label.R01016,isrq:Y,maxl:64,updt:Y,dbfd:workgroup";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(284, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 26;
            this.label10.Tag = "rsid:Label.R01016,isrq:N";
            this.label10.Text = "Work Group:";
            // 
            // numPairQty
            // 
            this.numPairQty.Location = new System.Drawing.Point(136, 125);
            this.numPairQty.Name = "numPairQty";
            this.numPairQty.Size = new System.Drawing.Size(120, 21);
            this.numPairQty.TabIndex = 25;
            this.numPairQty.Tag = "rsid:Label.R02026,isrq:Y,maxl:64,updt:Y,dbfd:pairqty";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 24;
            this.label9.Tag = "rsid:Label.R02026,isrq:Y";
            this.label9.Text = "Pair Qty:";
            // 
            // txtSize
            // 
            this.txtSize.Enabled = false;
            this.txtSize.Location = new System.Drawing.Point(411, 98);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(121, 21);
            this.txtSize.TabIndex = 19;
            this.txtSize.Tag = "rsid:Label.R01028,isrq:N,maxl:64,updt:Y,dbfd:factory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 18;
            this.label6.Tag = "rsid:Label.R01028";
            this.label6.Text = "Size:";
            // 
            // txtColor
            // 
            this.txtColor.Enabled = false;
            this.txtColor.Location = new System.Drawing.Point(137, 98);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(121, 21);
            this.txtColor.TabIndex = 17;
            this.txtColor.Tag = "rsid:Label.R01027,isrq:N,maxl:64,updt:Y,dbfd:factory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 16;
            this.label5.Tag = "rsid:Label.R01027";
            this.label5.Text = "Color:";
            // 
            // txtStyleNo
            // 
            this.txtStyleNo.Enabled = false;
            this.txtStyleNo.Location = new System.Drawing.Point(137, 71);
            this.txtStyleNo.Name = "txtStyleNo";
            this.txtStyleNo.Size = new System.Drawing.Size(121, 21);
            this.txtStyleNo.TabIndex = 15;
            this.txtStyleNo.Tag = "rsid:Label.R01026,isrq:N,maxl:64,updt:Y,dbfd:factory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 14;
            this.label3.Tag = "rsid:Label.R01026";
            this.label3.Text = "Style No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 46);
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
            this.txtCustOrderNo.Location = new System.Drawing.Point(137, 45);
            this.txtCustOrderNo.Name = "txtCustOrderNo";
            this.txtCustOrderNo.Size = new System.Drawing.Size(121, 21);
            this.txtCustOrderNo.TabIndex = 9;
            this.txtCustOrderNo.Tag = "rsid:Label.R01025,isrq:Y,maxl:64,updt:Y,dbfd:workorderno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 7;
            this.label2.Tag = "rsid:Label.R01020";
            this.label2.Text = "Customer:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 6;
            this.label1.Tag = "rsid:Label.R01025";
            this.label1.Text = "Cust Order No:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 41);
            this.panel2.TabIndex = 36;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(199, 10);
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
            this.btnCancel.Location = new System.Drawing.Point(280, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSupplementAdjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 205);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Name = "frmSupplementAdjust";
            this.Tag = "rsid:Menu.M20020002";
            this.Text = "frmSupplementAdjust";
            this.Load += new System.EventHandler(this.frmSupplementAdjust_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPairQty)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbToStep;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.ComboBox cmbWorkGroup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numPairQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStyleNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustOrderNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSupplementNo;
        private System.Windows.Forms.CheckBox ckTwiceInspect;
    }
}
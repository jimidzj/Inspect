namespace GENLSYS.MES.Win.MDL.ReasonCode
{
    partial class frmReasonCodeQuery
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ttxReasonCodeDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbReasonCategory = new System.Windows.Forms.ComboBox();
            this.txtReasonCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ttxReasonCodeDesc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbReasonCategory);
            this.groupBox1.Controls.Add(this.txtReasonCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 188);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "rsid:Label.R00537";
            this.groupBox1.Text = "Conditions";
            // 
            // ttxReasonCodeDesc
            // 
            this.ttxReasonCodeDesc.Location = new System.Drawing.Point(150, 47);
            this.ttxReasonCodeDesc.Name = "ttxReasonCodeDesc";
            this.ttxReasonCodeDesc.Size = new System.Drawing.Size(208, 21);
            this.ttxReasonCodeDesc.TabIndex = 5;
            this.ttxReasonCodeDesc.Tag = "rsid:Label.R00036,dbfd:reasoncodedesc,dbty:string";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 4;
            this.label3.Tag = "rsid:Label.R00036";
            this.label3.Text = "Reason Code Desc:";
            // 
            // cmbReasonCategory
            // 
            this.cmbReasonCategory.FormattingEnabled = true;
            this.cmbReasonCategory.Location = new System.Drawing.Point(150, 74);
            this.cmbReasonCategory.Name = "cmbReasonCategory";
            this.cmbReasonCategory.Size = new System.Drawing.Size(208, 20);
            this.cmbReasonCategory.TabIndex = 3;
            this.cmbReasonCategory.Tag = "rsid:Label.R00035,dbfd:reasoncategory,dbty:string";
            // 
            // txtReasonCode
            // 
            this.txtReasonCode.Location = new System.Drawing.Point(150, 20);
            this.txtReasonCode.Name = "txtReasonCode";
            this.txtReasonCode.Size = new System.Drawing.Size(208, 21);
            this.txtReasonCode.TabIndex = 2;
            this.txtReasonCode.Tag = "rsid:Label.R00037,dbfd:reasoncode,dbty:string";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Tag = "rsid:Label.R00035";
            this.label2.Text = "Reason Category:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Tag = "rsid:Label.R00037";
            this.label1.Text = "Reason Code:";
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::GENLSYS.MES.Win.Properties.Resources.query;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(115, 14);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Tag = "rsid:Button.R00003";
            this.btnQuery.Text = "&Query";
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.Location = new System.Drawing.Point(196, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 49);
            this.panel1.TabIndex = 10;
            // 
            // frmReasonCodeQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 188);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReasonCodeQuery";
            this.ShowInTaskbar = false;
            this.Tag = "rsid:Label.R00039";
            this.Text = "frmReasonCodeQuery";
            this.Load += new System.EventHandler(this.frmReasonCodeQuery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ttxReasonCodeDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbReasonCategory;
        private System.Windows.Forms.TextBox txtReasonCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
    }
}
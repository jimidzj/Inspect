namespace GENLSYS.MES.Win.SEC.Function
{
    partial class frmFunctionsQuery
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFuncType = new System.Windows.Forms.ComboBox();
            this.lblFuncType = new System.Windows.Forms.Label();
            this.txtFuncId = new System.Windows.Forms.TextBox();
            this.lblFuncId = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(160, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::GENLSYS.MES.Win.Properties.Resources.query;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(79, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 21);
            this.btnQuery.TabIndex = 13;
            this.btnQuery.Tag = "rsid:Button.R00003";
            this.btnQuery.Text = "&Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 35);
            this.panel1.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFuncType);
            this.groupBox1.Controls.Add(this.lblFuncType);
            this.groupBox1.Controls.Add(this.txtFuncId);
            this.groupBox1.Controls.Add(this.lblFuncId);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 77);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // cmbFuncType
            // 
            this.cmbFuncType.FormattingEnabled = true;
            this.cmbFuncType.Location = new System.Drawing.Point(119, 44);
            this.cmbFuncType.Name = "cmbFuncType";
            this.cmbFuncType.Size = new System.Drawing.Size(150, 20);
            this.cmbFuncType.TabIndex = 45;
            this.cmbFuncType.Tag = "rsid:Label.R00093,updt:Y,dbfd:functype,dbty:string";
            // 
            // lblFuncType
            // 
            this.lblFuncType.AutoSize = true;
            this.lblFuncType.Location = new System.Drawing.Point(20, 47);
            this.lblFuncType.Name = "lblFuncType";
            this.lblFuncType.Size = new System.Drawing.Size(59, 12);
            this.lblFuncType.TabIndex = 44;
            this.lblFuncType.Tag = "rsid:Label.R00144";
            this.lblFuncType.Text = "Func Type";
            // 
            // txtFuncId
            // 
            this.txtFuncId.Location = new System.Drawing.Point(119, 17);
            this.txtFuncId.Name = "txtFuncId";
            this.txtFuncId.Size = new System.Drawing.Size(150, 21);
            this.txtFuncId.TabIndex = 43;
            this.txtFuncId.Tag = "rsid:Label.R00143,maxl:64,updt:Y,dbfd:funcid,dbty:string";
            // 
            // lblFuncId
            // 
            this.lblFuncId.AutoSize = true;
            this.lblFuncId.Location = new System.Drawing.Point(20, 20);
            this.lblFuncId.Name = "lblFuncId";
            this.lblFuncId.Size = new System.Drawing.Size(47, 12);
            this.lblFuncId.TabIndex = 42;
            this.lblFuncId.Tag = "rsid:Label.R00143";
            this.lblFuncId.Text = "Func Id";
            // 
            // frmFunctionsQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 112);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(330, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(330, 150);
            this.Name = "frmFunctionsQuery";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "rsid:Label.R00149";
            this.Text = "frmFunctionsQuery";
            this.Load += new System.EventHandler(this.frmFunctionsQuery_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbFuncType;
        private System.Windows.Forms.Label lblFuncType;
        private System.Windows.Forms.TextBox txtFuncId;
        private System.Windows.Forms.Label lblFuncId;
    }
}
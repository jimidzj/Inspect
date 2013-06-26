namespace GENLSYS.MES.Win.SYS.AttributeTemplate
{
    partial class frmAttributeAttemplateQuery
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
            this.cmbUsedBy = new System.Windows.Forms.ComboBox();
            this.txtAttributeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbUsedBy);
            this.groupBox1.Controls.Add(this.txtAttributeName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 189);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbUsedBy
            // 
            this.cmbUsedBy.FormattingEnabled = true;
            this.cmbUsedBy.Location = new System.Drawing.Point(150, 68);
            this.cmbUsedBy.Name = "cmbUsedBy";
            this.cmbUsedBy.Size = new System.Drawing.Size(242, 20);
            this.cmbUsedBy.TabIndex = 3;
            this.cmbUsedBy.Tag = "rsid:Label.R00004,dbfd:usedby,dbty:string";
            this.cmbUsedBy.SelectedIndexChanged += new System.EventHandler(this.cmbUsedBy_SelectedIndexChanged);
            // 
            // txtAttributeName
            // 
            this.txtAttributeName.Location = new System.Drawing.Point(150, 39);
            this.txtAttributeName.Name = "txtAttributeName";
            this.txtAttributeName.Size = new System.Drawing.Size(242, 21);
            this.txtAttributeName.TabIndex = 2;
            this.txtAttributeName.Tag = "rsid:Label.R00001,dbfd:attributename,dbty:string";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Tag = "rsid:Label.R00004";
            this.label2.Text = "Used By:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Tag = "rsid:Label.R00001";
            this.label1.Text = "Attribute Name:";
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::GENLSYS.MES.Win.Properties.Resources.query;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(206, 202);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Tag = "rsid:Button.R00003";
            this.btnQuery.Text = "&Query";
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.Location = new System.Drawing.Point(287, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAttributeAttemplateQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 245);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAttributeAttemplateQuery";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "rsid:Label.R00006";
            this.Text = "frmAttributeAttemplateQuery";
            this.Load += new System.EventHandler(this.frmAttributeAttemplateQuery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbUsedBy;
        private System.Windows.Forms.TextBox txtAttributeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnCancel;
    }
}
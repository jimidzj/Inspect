namespace GENLSYS.MES.Win.SEC.Role
{
    partial class frmRoleQuery
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
            this.cmbRoleFlag = new System.Windows.Forms.ComboBox();
            this.lblRoleFlag = new System.Windows.Forms.Label();
            this.txtRoleId = new System.Windows.Forms.TextBox();
            this.lblRoleId = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(170, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::GENLSYS.MES.Win.Properties.Resources.query;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(89, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 21);
            this.btnQuery.TabIndex = 15;
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
            this.panel1.Size = new System.Drawing.Size(334, 40);
            this.panel1.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRoleFlag);
            this.groupBox1.Controls.Add(this.lblRoleFlag);
            this.groupBox1.Controls.Add(this.txtRoleId);
            this.groupBox1.Controls.Add(this.lblRoleId);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 77);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // cmbRoleFlag
            // 
            this.cmbRoleFlag.FormattingEnabled = true;
            this.cmbRoleFlag.Location = new System.Drawing.Point(117, 44);
            this.cmbRoleFlag.Name = "cmbRoleFlag";
            this.cmbRoleFlag.Size = new System.Drawing.Size(177, 20);
            this.cmbRoleFlag.TabIndex = 59;
            this.cmbRoleFlag.Tag = "rsid:Label.R00168,updt:Y,dbfd:rolestatus,dbty:string";
            // 
            // lblRoleFlag
            // 
            this.lblRoleFlag.AutoSize = true;
            this.lblRoleFlag.Location = new System.Drawing.Point(20, 47);
            this.lblRoleFlag.Name = "lblRoleFlag";
            this.lblRoleFlag.Size = new System.Drawing.Size(59, 12);
            this.lblRoleFlag.TabIndex = 58;
            this.lblRoleFlag.Tag = "rsid:Label.R00168";
            this.lblRoleFlag.Text = "Role Status";
            // 
            // txtRoleId
            // 
            this.txtRoleId.Location = new System.Drawing.Point(117, 17);
            this.txtRoleId.Name = "txtRoleId";
            this.txtRoleId.Size = new System.Drawing.Size(177, 21);
            this.txtRoleId.TabIndex = 57;
            this.txtRoleId.Tag = "rsid:Label.R00167,maxl:64,updt:Y,dbfd:roleid,dbty:string";
            // 
            // lblRoleId
            // 
            this.lblRoleId.AutoSize = true;
            this.lblRoleId.Location = new System.Drawing.Point(20, 20);
            this.lblRoleId.Name = "lblRoleId";
            this.lblRoleId.Size = new System.Drawing.Size(47, 12);
            this.lblRoleId.TabIndex = 56;
            this.lblRoleId.Tag = "rsid:Label.R00167";
            this.lblRoleId.Text = "Role Id";
            // 
            // frmRoleQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 117);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 155);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 155);
            this.Name = "frmRoleQuery";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "rsid:Label.R00170";
            this.Text = "frmRoleQuery";
            this.Load += new System.EventHandler(this.frmRoleQuery_Load);
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
        private System.Windows.Forms.ComboBox cmbRoleFlag;
        private System.Windows.Forms.Label lblRoleFlag;
        private System.Windows.Forms.TextBox txtRoleId;
        private System.Windows.Forms.Label lblRoleId;
    }
}
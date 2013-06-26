namespace GENLSYS.MES.UserControls
{
    partial class ucAttribute
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.grdAttribute = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttribute)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripSplitButton1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 347);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(429, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel2.Text = "Attribute Id:";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(27, 20);
            this.toolStripSplitButton1.Text = "|";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel1.Text = "Mode:";
            // 
            // grdAttribute
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            this.grdAttribute.DisplayLayout.Appearance = appearance1;
            this.grdAttribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAttribute.Location = new System.Drawing.Point(0, 0);
            this.grdAttribute.Name = "grdAttribute";
            this.grdAttribute.Size = new System.Drawing.Size(429, 347);
            this.grdAttribute.TabIndex = 2;
            this.grdAttribute.Tag = "rsid:Label.R00001|rsid:Label.R00002|rsid:Label.R00003|rsid:Label.R00279";
            this.grdAttribute.Text = "ultraGrid1";
            this.grdAttribute.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdAttribute_InitializeLayout);
            // 
            // ucAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdAttribute);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ucAttribute";
            this.Size = new System.Drawing.Size(429, 369);
            this.Load += new System.EventHandler(this.ucAttribute_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttribute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdAttribute;
    }
}

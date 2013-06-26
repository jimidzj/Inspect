namespace GENLSYS.MES.AutoUpdate
{
    partial class frmAutoUpdate
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.lblVersionInfo = new Infragistics.Win.Misc.UltraLabel();
            this.lblUpdateInfo = new Infragistics.Win.Misc.UltraLabel();
            this.processTotal = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblVersionInfo
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.lblVersionInfo.Appearance = appearance1;
            this.lblVersionInfo.Location = new System.Drawing.Point(3, 1);
            this.lblVersionInfo.Name = "lblVersionInfo";
            this.lblVersionInfo.Size = new System.Drawing.Size(383, 28);
            this.lblVersionInfo.TabIndex = 1;
            // 
            // lblUpdateInfo
            // 
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance3.TextVAlignAsString = "Middle";
            this.lblUpdateInfo.Appearance = appearance3;
            this.lblUpdateInfo.Location = new System.Drawing.Point(3, 35);
            this.lblUpdateInfo.Name = "lblUpdateInfo";
            this.lblUpdateInfo.Size = new System.Drawing.Size(383, 26);
            this.lblUpdateInfo.TabIndex = 2;
            // 
            // processTotal
            // 
            this.processTotal.Location = new System.Drawing.Point(3, 125);
            this.processTotal.Name = "processTotal";
            this.processTotal.Size = new System.Drawing.Size(383, 23);
            this.processTotal.TabIndex = 4;
            this.processTotal.Text = "[Formatted]";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmAutoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 164);
            this.Controls.Add(this.processTotal);
            this.Controls.Add(this.lblUpdateInfo);
            this.Controls.Add(this.lblVersionInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAutoUpdate";
            this.Text = "AutoUpdate";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAutoUpdate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblVersionInfo;
        private Infragistics.Win.Misc.UltraLabel lblUpdateInfo;
        private Infragistics.Win.UltraWinProgressBar.UltraProgressBar processTotal;
        private System.Windows.Forms.Timer timer1;
    }
}


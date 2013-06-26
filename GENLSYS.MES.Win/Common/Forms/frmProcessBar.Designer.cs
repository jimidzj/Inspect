namespace GENLSYS.MES.Win.Common.Forms
{
    partial class frmProcessBar
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ProgressBar = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProgressBar
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Control;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.Name = "Arial";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.ProgressBar.Appearance = appearance1;
            this.ProgressBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance2.BackColor = System.Drawing.Color.RoyalBlue;
            appearance2.BackColor2 = System.Drawing.Color.Aqua;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            this.ProgressBar.FillAppearance = appearance2;
            this.ProgressBar.Location = new System.Drawing.Point(0, 0);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.SegmentWidth = 10;
            this.ProgressBar.Size = new System.Drawing.Size(405, 30);
            this.ProgressBar.Style = Infragistics.Win.UltraWinProgressBar.ProgressBarStyle.SegmentedPartial;
            this.ProgressBar.TabIndex = 1;
            this.ProgressBar.Text = "Processing...";
            this.ProgressBar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // frmProcessBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(405, 30);
            this.ControlBox = false;
            this.Controls.Add(this.ProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcessBar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProcessBar";
            this.Load += new System.EventHandler(this.frmProcessBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Infragistics.Win.UltraWinProgressBar.UltraProgressBar ProgressBar;
    }
}
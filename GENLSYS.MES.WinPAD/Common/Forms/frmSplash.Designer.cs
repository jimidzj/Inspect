namespace GENLSYS.MES.WinPAD.Common.Forms
{
    partial class frmSplash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.lblRevision = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEnvironment = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblLoading = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbLogo = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.BackColor = System.Drawing.Color.Transparent;
            this.lblApplicationName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApplicationName.Font = new System.Drawing.Font("YouYuan", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApplicationName.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblApplicationName.Location = new System.Drawing.Point(0, 0);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(734, 66);
            this.lblApplicationName.TabIndex = 0;
            this.lblApplicationName.Text = "XXX公司检品管理系统";
            this.lblApplicationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRevision
            // 
            this.lblRevision.BackColor = System.Drawing.Color.Transparent;
            this.lblRevision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRevision.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevision.ForeColor = System.Drawing.Color.LightYellow;
            this.lblRevision.Location = new System.Drawing.Point(0, 0);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(734, 33);
            this.lblRevision.TabIndex = 1;
            this.lblRevision.Text = "Version 2.0.0.0";
            this.lblRevision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRevision.Click += new System.EventHandler(this.lblRevision_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 23;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblEnvironment);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 92);
            this.panel1.TabIndex = 3;
            // 
            // lblEnvironment
            // 
            this.lblEnvironment.AutoSize = true;
            this.lblEnvironment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnvironment.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnvironment.ForeColor = System.Drawing.Color.White;
            this.lblEnvironment.Location = new System.Drawing.Point(0, 0);
            this.lblEnvironment.Name = "lblEnvironment";
            this.lblEnvironment.Padding = new System.Windows.Forms.Padding(10);
            this.lblEnvironment.Size = new System.Drawing.Size(130, 39);
            this.lblEnvironment.TabIndex = 0;
            this.lblEnvironment.Text = "Development";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lblApplicationName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 66);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.lblRevision);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 158);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(734, 33);
            this.panel3.TabIndex = 5;
            // 
            // lblLoading
            // 
            this.lblLoading.BackColor = System.Drawing.Color.Transparent;
            this.lblLoading.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.ForeColor = System.Drawing.Color.Cyan;
            this.lblLoading.Location = new System.Drawing.Point(118, 248);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(439, 22);
            this.lblLoading.TabIndex = 6;
            this.lblLoading.Text = "Loading";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(0, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "2011 All rights reserved.";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BorderShadowColor = System.Drawing.Color.Empty;
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbLogo.Image = ((object)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 437);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(734, 20);
            this.pbLogo.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(-1, 343);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(616, 1);
            this.panel4.TabIndex = 13;
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = global::GENLSYS.MES.WinPAD.Properties.Resources.screen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(734, 473);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSplash_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblEnvironment;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox pbLogo;
        private System.Windows.Forms.Panel panel4;
    }
}
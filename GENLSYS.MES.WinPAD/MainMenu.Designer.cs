
 
namespace GENLSYS.MES.WinPAD{
    partial class MainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butXAssy = new System.Windows.Forms.Button();
            this.butXOpen = new System.Windows.Forms.Button();
            this.butIOpen = new System.Windows.Forms.Button();
            this.butIAss = new System.Windows.Forms.Button();
            this.butQuit = new System.Windows.Forms.Button();
            this.butShutdown = new System.Windows.Forms.Button();
            this.butUpdate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(148, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.butXAssy);
            this.panel1.Controls.Add(this.butXOpen);
            this.panel1.Controls.Add(this.butIOpen);
            this.panel1.Controls.Add(this.butIAss);
            this.panel1.Location = new System.Drawing.Point(154, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 526);
            this.panel1.TabIndex = 2;
            // 
            // butXAssy
            // 
            this.butXAssy.Enabled = false;
            this.butXAssy.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butXAssy.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.okbut;
            this.butXAssy.Location = new System.Drawing.Point(368, 18);
            this.butXAssy.Name = "butXAssy";
            this.butXAssy.Size = new System.Drawing.Size(280, 242);
            this.butXAssy.TabIndex = 3;
            this.butXAssy.Tag = "fai03";
            this.butXAssy.Text = "检品装箱";
            this.butXAssy.UseVisualStyleBackColor = true;
            this.butXAssy.Click += new System.EventHandler(this.butXAssy_Click);
            // 
            // butXOpen
            // 
            this.butXOpen.Enabled = false;
            this.butXOpen.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butXOpen.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.key;
            this.butXOpen.Location = new System.Drawing.Point(368, 283);
            this.butXOpen.Name = "butXOpen";
            this.butXOpen.Size = new System.Drawing.Size(280, 232);
            this.butXOpen.TabIndex = 2;
            this.butXOpen.Tag = "fax01";
            this.butXOpen.Text = "X线封箱";
            this.butXOpen.UseVisualStyleBackColor = true;
            this.butXOpen.Click += new System.EventHandler(this.butXOpen_Click);
            // 
            // butIOpen
            // 
            this.butIOpen.Enabled = false;
            this.butIOpen.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold);
            this.butIOpen.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.box_open;
            this.butIOpen.Location = new System.Drawing.Point(45, 18);
            this.butIOpen.Name = "butIOpen";
            this.butIOpen.Size = new System.Drawing.Size(285, 232);
            this.butIOpen.TabIndex = 1;
            this.butIOpen.Tag = "fai01";
            this.butIOpen.Text = "检品开箱";
            this.butIOpen.UseVisualStyleBackColor = true;
            this.butIOpen.Click += new System.EventHandler(this.butIOpen_Click);
            // 
            // butIAss
            // 
            this.butIAss.BackgroundImage = global::GENLSYS.MES.WinPAD.Properties.Resources.box;
            this.butIAss.Enabled = false;
            this.butIAss.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold);
            this.butIAss.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.box;
            this.butIAss.Location = new System.Drawing.Point(45, 280);
            this.butIAss.Name = "butIAss";
            this.butIAss.Size = new System.Drawing.Size(274, 239);
            this.butIAss.TabIndex = 0;
            this.butIAss.Tag = "fai02";
            this.butIAss.Text = "检品封箱";
            this.butIAss.UseVisualStyleBackColor = true;
            this.butIAss.Click += new System.EventHandler(this.butIAss_Click);
            // 
            // butQuit
            // 
            this.butQuit.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.Lock;
            this.butQuit.Location = new System.Drawing.Point(60, 22);
            this.butQuit.Name = "butQuit";
            this.butQuit.Size = new System.Drawing.Size(75, 65);
            this.butQuit.TabIndex = 3;
            this.butQuit.Text = "退出系统";
            this.butQuit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butQuit.UseVisualStyleBackColor = true;
            this.butQuit.Click += new System.EventHandler(this.butQuit_Click);
            // 
            // butShutdown
            // 
            this.butShutdown.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.cancel1;
            this.butShutdown.Location = new System.Drawing.Point(60, 101);
            this.butShutdown.Name = "butShutdown";
            this.butShutdown.Size = new System.Drawing.Size(75, 65);
            this.butShutdown.TabIndex = 4;
            this.butShutdown.Text = "关闭系统";
            this.butShutdown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butShutdown.UseVisualStyleBackColor = true;
            this.butShutdown.Click += new System.EventHandler(this.butShutdown_Click);
            // 
            // butUpdate
            // 
            this.butUpdate.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.reporting;
            this.butUpdate.Location = new System.Drawing.Point(60, 245);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(75, 65);
            this.butUpdate.TabIndex = 5;
            this.butUpdate.Text = "更新系统";
            this.butUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butUpdate.UseVisualStyleBackColor = true;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GENLSYS.MES.WinPAD.Properties.Resources.screen;
            this.ClientSize = new System.Drawing.Size(1014, 565);
            this.Controls.Add(this.butUpdate);
            this.Controls.Add(this.butShutdown);
            this.Controls.Add(this.butQuit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.Text = "菜单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butXAssy;
        private System.Windows.Forms.Button butXOpen;
        private System.Windows.Forms.Button butIOpen;
        private System.Windows.Forms.Button butIAss;
        private System.Windows.Forms.Button butQuit;
        private System.Windows.Forms.Button butShutdown;
        private System.Windows.Forms.Button butUpdate;
    }
}
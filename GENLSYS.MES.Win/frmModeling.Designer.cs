using System.Windows.Forms;
namespace GENLSYS.MES.Win
{
    partial class frmModeling
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
            //Application.Exit();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.upgradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.colseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ucStatusBar1 = new GENLSYS.MES.UserControls.ucStatusBar();
            this.uTabbedMdiManager = new Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager(this.components);
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uTabbedMdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upgradeToolStripMenuItem,
            this.toolStripSeparator2,
            this.colseAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.changePasswordToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.toolStripSeparator3,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 21);
            this.helpMenu.Text = "帮助";
            // 
            // upgradeToolStripMenuItem
            // 
            this.upgradeToolStripMenuItem.Image = global::GENLSYS.MES.Win.Properties.Resources.close;
            this.upgradeToolStripMenuItem.Name = "upgradeToolStripMenuItem";
            this.upgradeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.upgradeToolStripMenuItem.Text = "在线更新";
            this.upgradeToolStripMenuItem.Click += new System.EventHandler(this.upgradeToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // colseAllToolStripMenuItem
            // 
            this.colseAllToolStripMenuItem.Name = "colseAllToolStripMenuItem";
            this.colseAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.colseAllToolStripMenuItem.Text = "关闭所有";
            this.colseAllToolStripMenuItem.Click += new System.EventHandler(this.colseAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = global::GENLSYS.MES.Win.Properties.Resources.logout;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logoutToolStripMenuItem.Tag = "";
            this.logoutToolStripMenuItem.Text = "登出";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "退出系统";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::GENLSYS.MES.Win.Properties.Resources.help;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "关于";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click_1);
            // 
            // ucStatusBar1
            // 
            this.ucStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStatusBar1.Location = new System.Drawing.Point(0, 396);
            this.ucStatusBar1.Name = "ucStatusBar1";
            this.ucStatusBar1.Size = new System.Drawing.Size(632, 22);
            this.ucStatusBar1.TabIndex = 23;
            this.ucStatusBar1.Visible = false;
            // 
            // uTabbedMdiManager
            // 
            this.uTabbedMdiManager.MdiParent = this;
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.changePasswordToolStripMenuItem.Text = "修改密码";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // frmModeling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(632, 418);
            this.Controls.Add(this.ucStatusBar1);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmModeling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "System Modeling";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModeling_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmModeling_FormClosed);
            this.Load += new System.EventHandler(this.frmModeling_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uTabbedMdiManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem colseAllToolStripMenuItem;
        private UserControls.ucStatusBar ucStatusBar1;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem upgradeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager uTabbedMdiManager;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
    }
}




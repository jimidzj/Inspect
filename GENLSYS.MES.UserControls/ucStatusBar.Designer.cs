namespace GENLSYS.MES.UserControls
{
    partial class ucStatusBar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStatusBar));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblText1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblText2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFormName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton4,
            this.lblText1,
            this.lblText2,
            this.toolStripSplitButton2,
            this.lblFormName,
            this.toolStripSplitButton1,
            this.lblCurrentUser,
            this.toolStripSplitButton3,
            this.lblCurrentTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(607, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSplitButton4
            // 
            this.toolStripSplitButton4.BackColor = System.Drawing.Color.Transparent;
            this.toolStripSplitButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton4.Image")));
            this.toolStripSplitButton4.ImageTransparentColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.toolStripSplitButton4.Name = "toolStripSplitButton4";
            this.toolStripSplitButton4.Size = new System.Drawing.Size(16, 17);
            this.toolStripSplitButton4.Text = "toolStripSplitButton4";
            // 
            // lblText1
            // 
            this.lblText1.ForeColor = System.Drawing.Color.Blue;
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(193, 17);
            this.lblText1.Spring = true;
            this.lblText1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblText2
            // 
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(193, 17);
            this.lblText2.Spring = true;
            this.lblText2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(16, 17);
            this.toolStripSplitButton2.Text = "toolStripSplitButton2";
            // 
            // lblFormName
            // 
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(53, 17);
            this.lblFormName.Text = "FormName";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(16, 17);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(29, 17);
            this.lblCurrentUser.Text = "User";
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton3.Image")));
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(16, 17);
            this.toolStripSplitButton3.Text = "toolStripSplitButton3";
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(29, 17);
            this.lblCurrentTime.Text = "Time";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucStatusBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Name = "ucStatusBar";
            this.Size = new System.Drawing.Size(607, 22);
            this.Load += new System.EventHandler(this.ucStatusBar_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblText1;
        private System.Windows.Forms.ToolStripStatusLabel lblText2;
        private System.Windows.Forms.ToolStripStatusLabel lblFormName;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentUser;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton3;
    }
}

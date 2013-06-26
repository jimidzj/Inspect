namespace GENLSYS.MES.WinPAD.Common.Forms
{
    partial class frmContext
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContext));
            this.btn2 = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn2
            // 
            this.btn2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn2.Image = global::GENLSYS.MES.WinPAD.Properties.Resources.exit;
            this.btn2.Location = new System.Drawing.Point(177, 231);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 23);
            this.btn2.TabIndex = 18;
            this.btn2.Tag = "rsid:Button.R00010";
            this.btn2.Text = "&Close";
            this.btn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn2.UseVisualStyleBackColor = true;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(63, 231);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 17;
            this.logoPictureBox.TabStop = false;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.LightYellow;
            this.txtMessage.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(6, 12);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(411, 213);
            this.txtMessage.TabIndex = 19;
            this.txtMessage.Text = "Test";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn2);
            this.panel2.Controls.Add(this.txtMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(83, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 266);
            this.panel2.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.logoPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(83, 266);
            this.panel1.TabIndex = 20;
            // 
            // frmContext
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn2;
            this.ClientSize = new System.Drawing.Size(512, 266);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmContext";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "rsid:Label.R00966";
            this.Text = "frmText";
            this.Load += new System.EventHandler(this.frmContext_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}
namespace GENLSYS.MES.Win.INP.Ship
{
    partial class frmShipRpt
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCartonQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtFactory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShipNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdShipForCustomer = new System.Windows.Forms.RadioButton();
            this.rdShipForSaving = new System.Windows.Forms.RadioButton();
            this.rdPaymentRequest = new System.Windows.Forms.RadioButton();
            this.rdPackingList = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 41);
            this.panel2.TabIndex = 34;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::GENLSYS.MES.Win.Properties.Resources.save;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(153, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 21);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Tag = "rsid:Button.R00031";
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GENLSYS.MES.Win.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(234, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "rsid:Button.R00002";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtCartonQty);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCustomer);
            this.panel1.Controls.Add(this.txtFactory);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtShipNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rdShipForCustomer);
            this.panel1.Controls.Add(this.rdShipForSaving);
            this.panel1.Controls.Add(this.rdPaymentRequest);
            this.panel1.Controls.Add(this.rdPackingList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 150);
            this.panel1.TabIndex = 35;
            // 
            // txtCartonQty
            // 
            this.txtCartonQty.BackColor = System.Drawing.Color.White;
            this.txtCartonQty.Enabled = false;
            this.txtCartonQty.Location = new System.Drawing.Point(318, 16);
            this.txtCartonQty.Name = "txtCartonQty";
            this.txtCartonQty.Size = new System.Drawing.Size(121, 21);
            this.txtCartonQty.TabIndex = 39;
            this.txtCartonQty.Tag = "rsid:Label.R02021,isrq:Y,maxl:64,updt:Y,dbfd:workorderno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 38;
            this.label4.Tag = "rsid:Label.R02021";
            this.label4.Text = "Carton Qty:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.White;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(101, 42);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(121, 21);
            this.txtCustomer.TabIndex = 37;
            this.txtCustomer.Tag = "rsid:Label.R01020,isrq:Y,maxl:64,updt:Y,dbfd:workorderno";
            // 
            // txtFactory
            // 
            this.txtFactory.BackColor = System.Drawing.Color.White;
            this.txtFactory.Enabled = false;
            this.txtFactory.Location = new System.Drawing.Point(318, 42);
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.Size = new System.Drawing.Size(121, 21);
            this.txtFactory.TabIndex = 27;
            this.txtFactory.Tag = "rsid:Label.R01021,isrq:Y,maxl:64,updt:Y,dbfd:workorderno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 36;
            this.label2.Tag = "rsid:Label.R01020";
            this.label2.Text = "Customer:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 26;
            this.label1.Tag = "rsid:Label.R01021";
            this.label1.Text = "Factory:";
            // 
            // txtShipNo
            // 
            this.txtShipNo.BackColor = System.Drawing.Color.White;
            this.txtShipNo.Enabled = false;
            this.txtShipNo.Location = new System.Drawing.Point(101, 16);
            this.txtShipNo.Name = "txtShipNo";
            this.txtShipNo.Size = new System.Drawing.Size(121, 21);
            this.txtShipNo.TabIndex = 25;
            this.txtShipNo.Tag = "rsid:Label.R01078,isrq:Y,maxl:64,updt:Y,dbfd:workorderno";
            this.txtShipNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShipNo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 24;
            this.label3.Tag = "rsid:Label.R01078,isrq:Y";
            this.label3.Text = "Ship No:";
            // 
            // rdShipForCustomer
            // 
            this.rdShipForCustomer.AutoSize = true;
            this.rdShipForCustomer.Location = new System.Drawing.Point(244, 118);
            this.rdShipForCustomer.Name = "rdShipForCustomer";
            this.rdShipForCustomer.Size = new System.Drawing.Size(149, 16);
            this.rdShipForCustomer.TabIndex = 3;
            this.rdShipForCustomer.TabStop = true;
            this.rdShipForCustomer.Tag = "rsid:Label.R02064";
            this.rdShipForCustomer.Text = "Shipping For Customer";
            this.rdShipForCustomer.UseVisualStyleBackColor = true;
            // 
            // rdShipForSaving
            // 
            this.rdShipForSaving.AutoSize = true;
            this.rdShipForSaving.Location = new System.Drawing.Point(27, 118);
            this.rdShipForSaving.Name = "rdShipForSaving";
            this.rdShipForSaving.Size = new System.Drawing.Size(137, 16);
            this.rdShipForSaving.TabIndex = 2;
            this.rdShipForSaving.TabStop = true;
            this.rdShipForSaving.Tag = "rsid:Label.R02063";
            this.rdShipForSaving.Text = "Shipping For Saving";
            this.rdShipForSaving.UseVisualStyleBackColor = true;
            // 
            // rdPaymentRequest
            // 
            this.rdPaymentRequest.AutoSize = true;
            this.rdPaymentRequest.Location = new System.Drawing.Point(244, 83);
            this.rdPaymentRequest.Name = "rdPaymentRequest";
            this.rdPaymentRequest.Size = new System.Drawing.Size(113, 16);
            this.rdPaymentRequest.TabIndex = 1;
            this.rdPaymentRequest.TabStop = true;
            this.rdPaymentRequest.Tag = "rsid:Label.R02065";
            this.rdPaymentRequest.Text = "Payment Request";
            this.rdPaymentRequest.UseVisualStyleBackColor = true;
            // 
            // rdPackingList
            // 
            this.rdPackingList.AutoSize = true;
            this.rdPackingList.Checked = true;
            this.rdPackingList.Location = new System.Drawing.Point(27, 83);
            this.rdPackingList.Name = "rdPackingList";
            this.rdPackingList.Size = new System.Drawing.Size(95, 16);
            this.rdPackingList.TabIndex = 0;
            this.rdPackingList.TabStop = true;
            this.rdPackingList.Tag = "rsid:Label.R02062";
            this.rdPackingList.Text = "Packing List";
            this.rdPackingList.UseVisualStyleBackColor = true;
            // 
            // frmShipRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 191);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShipRpt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "rsid:Label.R02061";
            this.Text = "frmShipRpt";
            this.Load += new System.EventHandler(this.frmShipRpt_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdShipForCustomer;
        private System.Windows.Forms.RadioButton rdShipForSaving;
        private System.Windows.Forms.RadioButton rdPaymentRequest;
        private System.Windows.Forms.RadioButton rdPackingList;
        private System.Windows.Forms.TextBox txtShipNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCartonQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtFactory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.WinPAD.Common.Forms
{
    public partial class frmProcessBar : Form
    {
        public frmProcessBar()
        {
            InitializeComponent();
        }

        private void frmProcessBar_Load(object sender, EventArgs e)
        {
            this.ProgressBar.Text = UtilCulture.GetString("Label.R00931");
            this.ProgressBar.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.ProgressBar.Value == this.ProgressBar.Maximum)
                this.ProgressBar.Value = this.ProgressBar.Minimum;

            this.ProgressBar.Value++;
        }
    }
}

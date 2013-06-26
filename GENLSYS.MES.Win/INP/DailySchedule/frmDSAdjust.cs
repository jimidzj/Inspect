using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GENLSYS.MES.Win.INP.DailySchedule
{
    public partial class frmDSAdjust : Form
    {
        public frmDSAdjust()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
                    }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ck2_CheckedChanged(object sender, EventArgs e)
        {
            if (ck2.Checked)
            {
                nud2.Enabled = true;
                dtp2.Enabled = true;
            }
            else
            {
                nud2.Enabled = false;
                dtp2.Enabled = false;
            }
        }

        private void ck3_CheckedChanged(object sender, EventArgs e)
        {
            if (ck3.Checked)
            {
                nud3.Enabled = true;
                dtp3.Enabled = true;
            }
            else
            {
                nud3.Enabled = false;
                dtp3.Enabled = false;
            }
        }

        private void ck4_CheckedChanged(object sender, EventArgs e)
        {
            if (ck4.Checked)
            {
                nud4.Enabled = true;
                dtp4.Enabled = true;
            }
            else
            {
                nud4.Enabled = false;
                dtp4.Enabled = false;
            }
        }

        private void ck5_CheckedChanged(object sender, EventArgs e)
        {
            if (ck5.Checked)
            {
                nud5.Enabled = true;
                dtp5.Enabled = true;
            }
            else
            {
                nud5.Enabled = false;
                dtp5.Enabled = false;
            }
        }

        private void ck1_CheckedChanged(object sender, EventArgs e)
        {
            if (ck1.Checked)
            {
                nud1.Enabled = true;
                dtp1.Enabled = true;
            }
            else
            {
                nud1.Enabled = false;
                dtp1.Enabled = false;
            }
        }

       
    }
}

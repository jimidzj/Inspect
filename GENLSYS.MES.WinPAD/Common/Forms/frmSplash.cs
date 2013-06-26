using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.WinPAD.SEC;
using GENLSYS.MES.WinPAD.Common.Classes;
using System.Diagnostics;

namespace GENLSYS.MES.WinPAD.Common.Forms
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            FileVersionInfo appVserionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\GENLSYS.MES.WinPAD.exe");
            string ClientVersion = string.Format("{0}.{1}.{2}.{3}", appVserionInfo.FileMajorPart, appVserionInfo.FileMinorPart, appVserionInfo.FileBuildPart, appVserionInfo.FilePrivatePart);

            this.lblApplicationName.Text = ConfigReader.getApplicationName();
            this.lblRevision.Text = "Version " + ClientVersion;
            this.lblEnvironment.Text = ConfigReader.getEnvironmentName();
            //this.lblCustomer.Text = "For " + ConfigReader.getCustomerName().Trim();

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.Hide();
                this.WindowState = FormWindowState.Normal;
            }

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Show(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblLoading.Text += ".";
        }

        private void lblRevision_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

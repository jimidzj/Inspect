using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.SEC;
using GENLSYS.MES.Win.Common.Classes;
using System.Diagnostics;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.Common.Forms
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            FileVersionInfo appVserionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\GENLSYS.MES.Win.exe");
            string ClientVersion = string.Format("{0}.{1}.{2}.{3}", appVserionInfo.FileMajorPart, appVserionInfo.FileMinorPart, appVserionInfo.FileBuildPart, appVserionInfo.FilePrivatePart);

            this.lblApplicationName.Text = ConfigReader.getApplicationName();
            this.lblRevision.Text = "Version " + ClientVersion;
            //this.lblRevision.Text = "Version " + ConfigReader.getCurrentRevision();
            //this.lblEnvironment.Text = ConfigReader.getEnvironmentName();
            this.lblEnvironment.Text = RSALicense.LICENSEN_INFO.LicenseInformation;
            //this.lblCustomer.Text = "For " + ConfigReader.getCustomerName().Trim();
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

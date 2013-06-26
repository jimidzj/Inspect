using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.WinPAD.Common.Classes;
using GENLSYS.MES.WinPAD.Common;
using System.Net;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;

namespace GENLSYS.MES.WinPAD.SEC
{
    public partial class frmCheckRevision : Form
    {
        private BaseForm baseForm = null;
        private string localFileName = string.Empty;
        public bool NewRevisionFound = false;
        public bool isCancelled = false;

        public frmCheckRevision()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }

        #region Events
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.btnOK.Enabled = false;
            //this.btnCancel.Enabled = false;
            DownloadNewRevision();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isCancelled = true;
            this.Close();
        }

        private void frmCheckRevision_Load(object sender, EventArgs e)
        {
            //CheckRevision();
        }
        #endregion

        #region Methods
        public void CheckRevision()
        {
            string clientRevision = ConfigReader.getCurrentRevision();
            string serverRevision = string.Empty;

            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            try
            {
                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>();
                List<tsysappinfo> lstAppInfo = client.GetAppInfoList(baseForm.CurrentContextInfo,
                    lstParameter.ToArray<MESParameterInfo>()).ToList<tsysappinfo>();

                if (lstAppInfo.Count > 0)
                {
                    serverRevision = lstAppInfo[0].revision;
                }
                else
                {
                    serverRevision = MES_Misc.Unknown.ToString();
                }
            }
            catch (Exception ex)
            {
                serverRevision = MES_Misc.Unknown.ToString();
                this.txtLog.Text += "Call WCF error.(" + ExceptionParser.Parse(ex) + ")\r\n";
            }
            finally
            {
                baseForm.CloseWCF(client);
            }

            if (serverRevision.Trim() != clientRevision.Trim())
            {
                this.txtLog.Text += "New revision found." + "\r\n";
                this.txtLog.Text += "Server revision: " + serverRevision + "\r\n";
                this.txtLog.Text += "Client revision: " + clientRevision + "\r\n";
                this.txtLog.Text += "Click OK button to download and install new revision." + "\r\n";
                this.btnOK.Enabled = true;

                NewRevisionFound = true;

                return;
            }

            this.txtLog.Text += "New revision not found." + "\r\n";
            this.btnOK.Enabled = false;
            NewRevisionFound = false;
            isCancelled = false;
            this.Close();
        }

        private void OpenDownloadURL()
        {
            try
            {
                System.Diagnostics.Process ie = new System.Diagnostics.Process();
                ie.StartInfo.FileName = "IEXPLORE.EXE";
                string sURL = ConfigReader.getDownloadURL();
                ie.StartInfo.Arguments = sURL;
                ie.Start();
            }
            catch (Exception ex)
            {
                this.txtLog.Text += ExceptionParser.Parse(ex) + "\r\n";
            }
        }

        private void DownloadNewRevision()
        {
            try
            {
                baseForm.SetCursor();

                this.txtLog.Text += "Start to download new revision file." + "\r\n";

                if (Parameter.CURRENT_SYSTEM_CONFIG == null)
                {
                    Parameter.CURRENT_SYSTEM_CONFIG = baseForm.GetAllSystemConfig();
                    baseForm.SetParameter();
                }

                WebClient webClient = new WebClient();
                string user = baseForm.GetSystemConfig("SYS_AD_USER");
                string password = baseForm.GetSystemConfig("SYS_AD_PASSWORD");
                webClient.Credentials = new System.Net.NetworkCredential(user, password);

                string tempDir = System.Environment.GetEnvironmentVariable("TMP") + @"\";

                if (tempDir == null)
                    tempDir = System.Environment.GetEnvironmentVariable("TEMP") + @"\";

                if (tempDir == null)
                    tempDir = @"c:\";

                localFileName = tempDir + ConfigReader.getSetupFileName();
                this.txtLog.Text += "File name: " + localFileName + "\r\n";

                Uri url = new Uri(ConfigReader.getDownloadURL() + ConfigReader.getSetupFileName());
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                webClient.DownloadFileAsync(url, localFileName);
            }
            catch (Exception ex)
            {
                this.txtLog.Text += ExceptionParser.Parse(ex) + "\r\n";
                baseForm.ResetCursor();
            }
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            baseForm.ResetCursor();

            this.txtLog.Text += "\r\nEnd to download new revision file." + "\r\n";
            RunSetup(localFileName);
            isCancelled = true;
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.txtLog.Text += ".";
        }

        private void RunSetup(string fileName)
        {
            try
            {
                if (fileName.Trim() == null) return;

                Application.Exit();

                //this.txtLog.Text += "Start to install new revision." + "\r\n";

                System.Diagnostics.Process setup = new System.Diagnostics.Process();
                setup.StartInfo.FileName = fileName;
                setup.Start();

                //this.txtLog.Text += "End to install new revision." + "\r\n";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

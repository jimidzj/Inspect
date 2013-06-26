using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Win.SYS.UpgradeAssistant
{
    public partial class frmUpgradeAssistant : Form
    {
        private string projectPath = Application.StartupPath.Replace(@"GENLSYS.MES.Win\bin\Debug", "");
        public frmUpgradeAssistant()
        {
            InitializeComponent();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                this.btnCancel.Enabled = false;
                DoUpdate();
            }
            catch (Exception ex)
            {
                LogMsg(ex.Message);
                LogMsg("Upgrade halt");
            }
            finally
            {
                this.btnCancel.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogMsg(string msg)
        {
            this.txtLog.Text += msg + "\r\n";
        }

        private void DoUpdate()
        {
            LogMsg("Start...");
            LogMsg("New revision: " + this.txtNewRevision.Text);

            UpdateWCF();

            UpdateWin();

            UpdateSmartClient();

            UpdateSetup();

            UpdateAssemblyInfo();

            LogMsg("Done!");
        }

        private void UpdateWCF()
        {
            LogMsg("Update and Copy WCF web.config");

            string fileName = "";
            switch (this.cmbEnvironment.Text)
            {
                case "DEV":
                    fileName = "STD_";
                    break;
                case "QAS":
                    fileName = "UAT_";
                    break;
                case "PRD":
                    fileName = "PRD_";
                    break;
            }

            fileName = projectPath + @"\GENLSYS.MES.WCF\" + fileName + this.txtModule.Text.Trim() + "_web.config";
            FileInfo fi = new FileInfo(fileName);
            if (!fi.Exists)
            {
                LogMsg("Unknown file:" + fileName);
                LogMsg("Upgrade halt");
            }

            Encoding code = Encoding.GetEncoding("utf-8");
            StreamReader sr = new StreamReader(fileName, code);
            string fileContext = sr.ReadToEnd();
            sr.Close();
            fileContext = fileContext.Replace("currentrevision=\"" + this.txtOldRevision.Text.Trim() + "\"",
                                "currentrevision=\"" + this.txtNewRevision.Text.Trim() + "\"");

            StreamWriter sw = new StreamWriter(fileName, false, code);
            sw.Write(fileContext);
            sw.Flush();
            sw.Close();

            sr = new StreamReader(fileName, code);
            fileContext = sr.ReadToEnd();
            sr.Close();

            string webConfigFileName = projectPath + @"\GENLSYS.MES.WCF\web.config";
            sw = new StreamWriter(webConfigFileName, false, code);
            sw.Write(fileContext);
            sw.Flush();
            sw.Close();
        }

        private void UpdateWin()
        {
            LogMsg("Update and Copy Win app.config");

            string fileName = "";
            switch (this.cmbEnvironment.Text)
            {
                case "DEV":
                    fileName = "STD_";
                    break;
                case "QAS":
                    fileName = "UAT_";
                    break;
                case "PRD":
                    fileName = "PRD_";
                    break;
            }

            fileName = projectPath + @"\GENLSYS.MES.Win\" + fileName + this.txtModule.Text.Trim() + "_app.config";
            FileInfo fi = new FileInfo(fileName);
            if (!fi.Exists)
            {
                LogMsg("Unknown file:" + fileName);
                LogMsg("Upgrade halt");
            }

            Encoding code = Encoding.GetEncoding("utf-8");
            StreamReader sr = new StreamReader(fileName, code);
            string fileContext = sr.ReadToEnd();
            sr.Close();
            fileContext = fileContext.Replace("currentrevision=\"" + this.txtOldRevision.Text.Trim() + "\"",
                                "currentrevision=\"" + this.txtNewRevision.Text.Trim() + "\"");

            StreamWriter sw = new StreamWriter(fileName, false, code);
            sw.Write(fileContext);
            sw.Flush();
            sw.Close();

            sr = new StreamReader(fileName, code);
            fileContext = sr.ReadToEnd();
            sr.Close();

            string webConfigFileName = projectPath + @"\GENLSYS.MES.Win\app.config";
            sw = new StreamWriter(webConfigFileName, false, code);
            sw.Write(fileContext);
            sw.Flush();
            sw.Close();
        }

        private void UpdateSmartClient()
        {
            LogMsg("Update and Copy Smart Client app.config");

            string fileName = "";
            switch (this.cmbEnvironment.Text)
            {
                case "DEV":
                    fileName = "STD_";
                    break;
                case "QAS":
                    fileName = "UAT_";
                    break;
                case "PRD":
                    fileName = "PRD_";
                    break;
            }

            fileName = projectPath + @"\GENLSYS.MES.SmartClient\" + fileName + this.txtModule.Text.Trim() + "_app.config";
            FileInfo fi = new FileInfo(fileName);
            if (!fi.Exists)
            {
                LogMsg("Unknown file:" + fileName);
                LogMsg("Upgrade halt");
            }

            Encoding code = Encoding.GetEncoding("utf-8");
            StreamReader sr = new StreamReader(fileName, code);
            string fileContext = sr.ReadToEnd();
            sr.Close();
            fileContext = fileContext.Replace("currentrevision=\"" + this.txtOldRevision.Text.Trim() + "\"",
                                "currentrevision=\"" + this.txtNewRevision.Text.Trim() + "\"");

            StreamWriter sw = new StreamWriter(fileName, false, code);
            sw.Write(fileContext);
            sw.Flush();
            sw.Close();

            sr = new StreamReader(fileName, code);
            fileContext = sr.ReadToEnd();
            sr.Close();

            string webConfigFileName = projectPath + @"\GENLSYS.MES.SmartClient\app.config";
            sw = new StreamWriter(webConfigFileName, false, code);
            sw.Write(fileContext);
            sw.Flush();
            sw.Close();
        }

        private void UpdateSetup()
        {
            if (this.cmbEnvironment.Text == "QAS")
                UpdateSetupQAS();

            if (this.cmbEnvironment.Text == "PRD")
                UpdateSetupPRD();
        }

        private void UpdateSetupQAS()
        {
            LogMsg("Update setup project for QAS");

            string fileName = "GENLSYS.MES.Setup.vdproj";
            fileName = projectPath + @"\GENLSYS.MES.Setup\" + fileName;
            FileInfo fi = new FileInfo(fileName);
            if (!fi.Exists)
            {
                LogMsg("Unknown file:" + fileName);
                LogMsg("Upgrade halt");
            }

            Encoding code = Encoding.GetEncoding("utf-8");
            StreamReader sr = new StreamReader(fileName, code);
            string fileContext = sr.ReadToEnd();
            sr.Close();
            fileContext = fileContext.Replace("\"ProductVersion\" = \"8:" + this.txtOldRevision.Text.Trim() + "\"",
                                "\"ProductVersion\" = \"8:" + this.txtNewRevision.Text.Trim() + "\"");

            string productCode = Function.GetGUID().ToUpper();
            //"ProductCode" = "8:{73177E4C-D339-4D68-93A8-E19E70F8F8F7}"
            string idxStr = "\"ProductCode\" = \"8:{";
            int idx = fileContext.IndexOf(idxStr);
            string oldProductCode = string.Empty;
            if (idx > 1)
            {
                oldProductCode = fileContext.Substring(idx + idxStr.Length, 36);
            }
            fileContext = fileContext.Replace(oldProductCode, productCode);

            StreamWriter sw = new StreamWriter(fileName, false, code);
            sw.Write(fileContext);
            sw.Flush();
            sw.Close();
        }

        private void UpdateSetupPRD()
        {
            LogMsg("Update setup project for PRD");

            string fileName = "GENLSYS.MES.Setup.PRD.vdproj";
            fileName = projectPath + @"\GENLSYS.MES.Setup.PRD\" + fileName;
            FileInfo fi = new FileInfo(fileName);
            if (!fi.Exists)
            {
                LogMsg("Unknown file:" + fileName);
                LogMsg("Upgrade halt");
            }

            Encoding code = Encoding.GetEncoding("utf-8");
            StreamReader sr = new StreamReader(fileName, code);
            string fileContext = sr.ReadToEnd();
            sr.Close();
            fileContext = fileContext.Replace("\"ProductVersion\" = \"8:" + this.txtOldRevision.Text.Trim() + "\"",
                                "\"ProductVersion\" = \"8:" + this.txtNewRevision.Text.Trim() + "\"");

            string productCode = Function.GetGUID().ToUpper();
            //"ProductCode" = "8:{73177E4C-D339-4D68-93A8-E19E70F8F8F7}"
            string idxStr = "\"ProductCode\" = \"8:{";
            int idx = fileContext.IndexOf(idxStr);
            string oldProductCode = string.Empty;
            if (idx > 1)
            {
                oldProductCode = fileContext.Substring(idx + idxStr.Length, 36);
            }
            fileContext = fileContext.Replace(oldProductCode, productCode);

            StreamWriter sw = new StreamWriter(fileName, false, code);
            sw.Write(fileContext);
            sw.Flush();
            sw.Close();
        }

        private void UpdateAssemblyInfo()
        {
            LogMsg("Update Win's Assembly Info");

            string fileName = "AssemblyInfo.cs";
            fileName = projectPath + @"\GENLSYS.MES.Win\Properties\" + fileName;
            FileInfo fi = new FileInfo(fileName);
            if (!fi.Exists)
            {
                LogMsg("Unknown file:" + fileName);
                LogMsg("Upgrade halt");
            }

            Encoding code = Encoding.GetEncoding("utf-8");
            StreamReader sr = new StreamReader(fileName, code);
            string fileContext = sr.ReadToEnd();
            sr.Close();

            //[assembly: AssemblyVersion("2.2.1")]
            fileContext = fileContext.Replace("[assembly: AssemblyVersion(\"" + this.txtOldRevision.Text.Trim() + "\")]",
                                "[assembly: AssemblyVersion(\"" + this.txtNewRevision.Text.Trim() + "\")]");

            //[assembly: AssemblyFileVersion("2.2.1")]
            fileContext = fileContext.Replace("[assembly: AssemblyFileVersion(\"" + this.txtOldRevision.Text.Trim() + "\")]",
                                "[assembly: AssemblyFileVersion(\"" + this.txtNewRevision.Text.Trim() + "\")]");

            StreamWriter sw = new StreamWriter(fileName, false, code);
            sw.Write(fileContext);
            sw.Flush();
            sw.Close();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.WinPAD.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Common;
using System.Net;
using GENLSYS.MES.DataContracts.Common;
using Infragistics.Win.UltraMessageBox;
using Infragistics.Win;
using GENLSYS.MES.WinPAD.Common.Classes;
using GENLSYS.MES.WinPAD.Common.Forms;
using GENLSYS.MES.DataContracts;
using System.Xml;
using System.IO;
using System.Diagnostics;
using GENLSYS.MES.AutoUpdate;

namespace GENLSYS.MES.WinPAD.SEC
{
    public partial class frmLogon : Form
    {
        private BaseForm baseForm;
        private frmSplash fSplash;
        private int errorCount = 0;

        #region Construct
        public frmLogon()
        {
            InitializeComponent();
            baseForm = new BaseForm();

            this.lblEnvironment.Text = ConfigReader.getEnvironmentName();

            FileVersionInfo appVserionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\GENLSYS.MES.WinPAD.exe");
            string ClientVersion = string.Format("{0}.{1}.{2}.{3}", appVserionInfo.FileMajorPart, appVserionInfo.FileMinorPart, appVserionInfo.FileBuildPart, appVserionInfo.FilePrivatePart);
         
            //UpdateInfo info = new UpdateInfo();
            //FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(info.ExecuteFile);
            //string currVesion = myFileVersionInfo.FileVersion;

            this.lblRevision.Text = ClientVersion;

            GetAppConfig();
            GetUserProfile();

        }
        #endregion

        #region Events
        private void btnOK_Click(object sender, EventArgs e)
        {
            DoLogon();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Parameter.ApplicationExitFlag = true;
            this.Close();
        }

        private void frmLogon_Load(object sender, EventArgs e)
        {
            try
            {
                //fSplash = new frmSplash();

                this.timer1.Enabled = true;

                //  fSplash.ShowDialog();

                //
                Screen screen = Screen.PrimaryScreen;
                int screenW = screen.Bounds.Width;         //宽 
                int screenH = screen.Bounds.Height;         //高 
                panel3.Left = (screenW - panel3.Width) / 2;
                panel3.Top = (screenH - panel3.Height) / 2-100;
                //check version in smart client
                //if (!CheckClientRevision()) this.Close();

                baseForm.SetFace(this, false);
                SetLayout();
                lblAppName.Text = ConfigReader.getApplicationName();

                cmbUser.Height = 40;
                //this.cmbUser.Text = "Admin";
                //this.txtPassword.Text = "222";
                this.cmbShift.SelectedIndex = this.cmbShift.Items.Count - 1;
                this.cmbLanguage.SelectedIndex = 0;


            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
            finally
            {
                //fSplash.Close();
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            //  fSplash.Close();
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbUser.SelectedItem == null) return;
            DropDown.SelectCMBValue(this.cmbShift, (this.cmbUser.SelectedItem as ValueInfo).Misc2Field);
            DropDown.SelectCMBValue(this.cmbLanguage, (this.cmbUser.SelectedItem as ValueInfo).Misc1Field);

            if ((this.cmbUser.SelectedItem as ValueInfo).Misc3Field == "Modeling")
            {
                this.chkLogonToBasis.Checked = true;
            }
            else
            {
                this.chkLogonToBasis.Checked = false;
            }

            if (this.cmbLanguage.SelectedItem == null) return;
            baseForm.InitResourceFile((this.cmbLanguage.SelectedItem as ValueInfo).ValueField);
            baseForm.SetFace(this, false);
        }

        private void frmLogon_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbLanguage.SelectedItem == null) return;
            baseForm.InitResourceFile((this.cmbLanguage.SelectedItem as ValueInfo).ValueField);
            baseForm.SetFace(this, false);

        }

        private void cmbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;

            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoLogon();
            }
        }
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
           // Parameter.ApplicationExitFlag = true;
           // this.Close();
            DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                          MessageBoxButtons.YesNo,
                                          null, "选择是“是”将关闭系统，“否”将取消操作");

            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                ShutDown.DoExitWin(ShutDown.EWX_SHUTDOWN);
            }

        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            DoLogon();
        }

        private void cmbUser_Enter(object sender, EventArgs e)
        {
            vkForm.showKeyboard();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            vkForm.showKeyboard();
        }
        private void frmLogon_Activated(object sender, EventArgs e)
        {
            // vkForm.iniKeyboard();
            //  this.cmbUser.Focus();
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();
        }

        private void SetCombobox()
        {
            DropDown.InitCMB_Shift_All(this.cmbShift);
            DropDown.InitCMB_Language(this.cmbLanguage);
        }

        private bool CheckClientRevision()
        {
            frmCheckRevision f = new frmCheckRevision();
            f.CheckRevision();

            if (f.NewRevisionFound)
            {
                f.ShowDialog();

                if (f.isCancelled)
                {
                    this.Close();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
                f.Close();

            return true;
        }

        private void DoLogon()
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            wsMDL.IwsMDLClient clientMDL = new wsMDL.IwsMDLClient();

            try
            {
                baseForm.SetCursor();

                baseForm.ValidateData(this);

                if (this.chkLogonToBasis.Checked)
                    baseForm.CurrentContextInfo.MiscValue1 = "Modeling";
                else
                    baseForm.CurrentContextInfo.MiscValue1 = "WIP Client";

                client.Logon(baseForm.CurrentContextInfo, this.cmbUser.Text, UtilSecurity.EncryptPassword(txtPassword.Text));

                #region Set public variables
                Parameter.LOGON_USER = this.cmbUser.Text.Trim();
                Parameter.SHIFT = (this.cmbShift.SelectedItem as ValueInfo).ValueField;
                Parameter.SESSION_ID = GENLSYS.MES.Common.Function.GetGUID();
                Parameter.LANGUAGE = (this.cmbLanguage.SelectedItem as ValueInfo).ValueField;
                // Parameter.WORKGROUP = "G1";//getWorkGroupByIP
                InitResourceFile(Parameter.LANGUAGE);

                string machine = Dns.GetHostName();

                baseForm.CurrentContextInfo.SessionId = Parameter.SESSION_ID;
                baseForm.CurrentContextInfo.CurrentUser = Parameter.LOGON_USER;
                baseForm.CurrentContextInfo.WorkGroup = Parameter.WORKGROUP;
                client.UpdateLogonTime(baseForm.CurrentContextInfo, Parameter.SESSION_ID, this.cmbUser.Text, machine, Parameter.SHIFT);
                //get authorization
                Parameter.ALL_FUNCTIONS = client.GetFunctionsRecords(baseForm.CurrentContextInfo,
                    (new List<MESParameterInfo>()).ToArray<MESParameterInfo>()).Tables[0];
                Parameter.USER_FUNCTIONS = client.GetFunctionsByUserId(baseForm.CurrentContextInfo,
                    Parameter.LOGON_USER).Tables[0];
                //get user object
                List<tsecuser> lstUser = client.GetUserList(baseForm.CurrentContextInfo,
                    new List<MESParameterInfo>() { 
                        new MESParameterInfo(){
                            ParamName ="userid",
                            ParamValue=Parameter.LOGON_USER
                        }
                    }.ToArray<MESParameterInfo>()).ToList<tsecuser>();

                if (lstUser.Count > 0)
                {
                    Parameter.CURRENT_USER_OBJECT = lstUser[0];
                }
                //get employee object
                List<tmdlemployee> lstEmployee = clientMDL.GetEmployeeList(baseForm.CurrentContextInfo,
                    new List<MESParameterInfo>() { 
                        new MESParameterInfo(){
                            ParamName ="employeeid",
                            ParamValue=lstUser[0].employeeid
                        }
                    }.ToArray()).ToList();

                //   if (lstEmployee.Count > 0)
                //   {
                //       Parameter.WORKGROUP = lstEmployee[0].workgroup;
                //       baseForm.CurrentContextInfo.WorkGroup = Parameter.WORKGROUP;
                //   }
                //get system config
                if (Parameter.CURRENT_SYSTEM_CONFIG == null)
                {
                    Parameter.CURRENT_SYSTEM_CONFIG = baseForm.GetAllSystemConfig();
                    baseForm.SetParameter();
                }
                //get static value
                if (Parameter.CURRENT_STATIC_VALUE == null)
                    Parameter.CURRENT_STATIC_VALUE = baseForm.GetAllStaticValue();
                //set host name as work group
                string host = Dns.GetHostName();
                string lineGroup = "unknow";
                foreach (tsysstaticvalue item in baseForm.GetStaticValue(MES_StaticValue_Type.LineGroup))
                {
                    if (item.svtext == host)
                    {
                        lineGroup = item.svvalue;
                        break;
                    }
                }

                Parameter.WORKGROUP = lineGroup;
                baseForm.CurrentContextInfo.WorkGroup = Parameter.WORKGROUP;

                //update user profile
                UpdateUserProfile();
                #endregion

                ShowModeling(false);


                Parameter.LOGON_FORM = this;

                this.Hide();
            }
            catch (Exception ex)
            {
                switch (ExceptionParser.Parse(ex))
                {
                    case "-300001":
                        errorCount++;
                        baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00011"));
                        break;
                    case "-300002":
                        errorCount++;
                        baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00012"));
                        break;
                    case "-300003":
                        errorCount++;
                        baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00013"));
                        break;
                    case "-300004":
                        errorCount++;
                        baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00014"));
                        break;
                    case "-300005":
                        errorCount++;
                        baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00046"));
                        break;
                    default:
                        baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, ExceptionParser.Parse(ex));
                        break;
                }


                if (errorCount >= 5)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00122"));
                    this.Dispose();
                }
            }
            finally
            {
                baseForm.ResetCursor();
                if (client.State == System.ServiceModel.CommunicationState.Opened)
                    baseForm.CloseWCF(client);
            }
        }

        private void InitResourceFile(string language)
        {
            UtilCulture.InitialResource("GENLSYS.MES.Res", Application.StartupPath + "\\Resources", language);
            string x = UtilCulture.GetString("Label.R00001");
        }

        private void GetAppConfig()
        {
            //Parameter.MES_DATABASE_CONNECTION = ConfigReader.getDBConnectionString_MES();
            //Parameter.SAP_CONNECTION_STRING = ConfigReader.getDBConnectionString_SAP();
        }

        private void GetUserProfile()
        {
            string clientFile = Application.StartupPath + @"\client.xml";
            FileInfo file = new FileInfo(clientFile);
            if (!file.Exists) return;

            XmlDocument doc = new XmlDocument();
            doc.Load(clientFile);
            XmlNodeList nodeList = doc.SelectNodes("/Users/User");

            for (int i = 0; i < nodeList.Count; i++)
            {
                ValueInfo val = new ValueInfo();
                val.DisplayField = nodeList[i].Attributes["userid"].Value.ToString();
                val.ValueField = nodeList[i].Attributes["userid"].Value.ToString();

                XmlNode node = nodeList[i].SelectSingleNode("DefaultLanguage");
                val.Misc1Field = node.InnerText.ToString();

                node = nodeList[i].SelectSingleNode("DefaultShift");
                val.Misc2Field = node.InnerText.ToString();

                node = nodeList[i].SelectSingleNode("DefaultModule");
                val.Misc3Field = node.InnerText.ToString();

                this.cmbUser.DisplayMember = "DisplayField";
                this.cmbUser.ValueMember = "ValueField";
                this.cmbUser.Items.Add(val);
            }

            doc = null;
        }


        private void UpdateUserProfile()
        {
            try
            {
                string clientFile = Application.StartupPath + @"\client.xml";
                FileInfo file = new FileInfo(clientFile);
                if (!file.Exists) return;

                XmlDocument doc = new XmlDocument();
                doc.Load(clientFile);

                //create
                XmlNode rootNode = doc.SelectSingleNode("/Users");

                XmlNode checkNode = doc.SelectSingleNode("/Users/User[@userid='" + this.cmbUser.Text + "']");
                if (checkNode != null)
                {
                    rootNode.RemoveChild(checkNode);
                }

                if (rootNode == null) return;

                XmlNode userNode = doc.CreateNode(XmlNodeType.Element, "User", "");
                XmlAttribute att = doc.CreateAttribute("userid");
                att.Value = this.cmbUser.Text;
                userNode.Attributes.Append(att);

                XmlNode node = doc.CreateNode(XmlNodeType.Element, "DefaultLanguage", "");
                node.InnerText = (this.cmbLanguage.SelectedItem as ValueInfo).ValueField;
                userNode.AppendChild(node);

                node = doc.CreateNode(XmlNodeType.Element, "DefaultShift", "");
                node.InnerText = (this.cmbShift.SelectedItem as ValueInfo).ValueField;
                userNode.AppendChild(node);

                node = doc.CreateNode(XmlNodeType.Element, "DefaultModule", "");
                if (this.chkLogonToBasis.Checked)
                    node.InnerText = "Modeling";
                else
                    node.InnerText = "WIPClient";
                userNode.AppendChild(node);

                node = doc.CreateNode(XmlNodeType.Element, "LastLogOnTime", "");
                node.InnerText = UtilDatetime.FormateDateTime1(DateTime.Now);
                userNode.AppendChild(node);

                rootNode.AppendChild(userNode);

                doc.Save(clientFile);

                doc = null;
            }
            catch
            {
            }
        }

        public void ShowModeling(bool isClose)
        {
            if (isClose)
            {
                if (Parameter.MAIN_FORM_MODELING != null)
                {
                    (Parameter.MAIN_FORM_MODELING as Form).Close();
                    Parameter.MAIN_FORM_MODELING = null;
                }
            }
            else
            {

                MainMenu f = new MainMenu();
                Parameter.MAIN_FORM_MODELING = f;
                f.Show(this);

            }
        }

        public void ClearPassword()
        {
            this.txtPassword.Text = string.Empty;
        }
        #endregion

        private void lblAppName_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }




    }
}

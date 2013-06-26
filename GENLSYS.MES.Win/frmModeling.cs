using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.MDL;
using GENLSYS.MES.Win.SYS;
using GENLSYS.MES.Win.SEC;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Win.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.Win.Common.Forms;
using GENLSYS.MES.Win.SYS.UpgradeAssistant;
using GENLSYS.MES.AutoUpdate;
using System.Diagnostics; 

namespace GENLSYS.MES.Win
{
    public partial class frmModeling : Form
    {
        BaseForm baseForm;
        private bool isLogon = false;

        #region Constrcut
        public frmModeling()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            (new MenuConfig()).CreateMenu(this.menuStrip, MES_MenuType.M, new System.EventHandler(MenuItem_Click));            
        }
        #endregion

        #region Events
        private void MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                if (item.Tag != null && !item.Tag.ToString().Trim().Equals(""))
                {
                    Form[] arrForm = this.MdiChildren;

                    for (int i = 0; i < arrForm.Length; i++)
                    {
                        if (item.Tag.ToString().Contains(arrForm[i].Name))
                        {
                            arrForm[i].Activate();
                            return;
                        }
                    }

                    Form frm = MenuConfig.CreateFormInstance(item.Tag.ToString().Trim());
                    if (MenuConfig.IsMDIChildren(frm))
                    {
                        frm.WindowState = FormWindowState.Maximized;
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        frm.ShowDialog(this);
                    }
                    

                }
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
        }

        

        private void colseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren) 
            {
                childForm.Close();
            }
        }


        private void frmModeling_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Parameter.MAIN_FORM_WIPCLIENT != null) return;

            if (!isLogon)
            {
                DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                            MessageBoxButtons.OKCancel,
                                            null, UtilCulture.GetString("Msg.R00051"));

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    Parameter.ApplicationExitFlag = true;
                }
            }

            DoLogout();
        }

        private void frmModeling_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            #region Set backgroud color
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    MdiClient ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = this.BackColor;
                }
                catch
                {
                }
            }
            #endregion

            FileVersionInfo appVserionInfo = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\GENLSYS.MES.Win.exe");
            string ClientVersion = string.Format("{0}.{1}.{2}.{3}", appVserionInfo.FileMajorPart, appVserionInfo.FileMinorPart, appVserionInfo.FileBuildPart, appVserionInfo.FilePrivatePart);

            this.Text = UtilCulture.GetString("Label.R03001") + " @ " + ConfigReader.getApplicationName() + "[" + ClientVersion + "]" +
                " - " + ConfigReader.getCustomerName() + " - " + RSALicense.LICENSEN_INFO.LicenseInformation;

            Preparation();
        }

        private void upgradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //UpdateInfo info = new UpdateInfo();
            //info.ClientVersion = ConfigReader.getCurrentRevision();
            //if (info.checkUpdate(info.ClientVersion))
            //{
            //    if (MessageBox.Show("最新版本为" + info.Version + ",是否确认更新？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            //    {
            //        Process.Start(Application.StartupPath + @"\GENLSYS.MES.AutoUpdate.exe");
            //        Application.Exit();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("当前已经是最新版本", "提示");
            //}
            //frmUpgradeAssistant f = new frmUpgradeAssistant();
            //f.ShowDialog(this);
            UpdateInfo info = new UpdateInfo();
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(info.ExecuteFile);
            string currVesion = myFileVersionInfo.FileVersion;

            if (info.checkUpdate(currVesion))
            {
                if (MessageBox.Show("当前版本是" + currVesion + ",最新版本为" + info.Version + ",是否更新？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Process.Start(Application.StartupPath + @"\GENLSYS.MES.AutoUpdate.exe");
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("当前已经是最新版本", "提示");
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MESMsgBox.ShowQuestion(string.Empty, UtilCulture.GetString("Msg.R00017"), Public_MessageBox.Question, MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;

            try
            {
                isLogon = true;

                #region Clean
                DoLogout();
                Parameter.LOGON_USER = string.Empty;
                Parameter.SESSION_ID = string.Empty;
                Parameter.ALL_FUNCTIONS = null;
                Parameter.SHIFT = string.Empty;
                Parameter.CURRENT_USER_OBJECT = null;

                if (Parameter.MAIN_FORM_WIPCLIENT != null)
                {
                    (Parameter.MAIN_FORM_WIPCLIENT as Form).Close();
                    Parameter.MAIN_FORM_WIPCLIENT = null;
                }

                if (Parameter.MAIN_FORM_MODELING != null)
                {
                    (Parameter.MAIN_FORM_MODELING as Form).Close();
                    Parameter.MAIN_FORM_MODELING = null;
                }

                #endregion

                if (Parameter.LOGON_FORM != null)
                {
                    (Parameter.LOGON_FORM as frmLogon).Show();
                }
                else
                {
                    frmLogon f = new frmLogon();
                    Parameter.LOGON_FORM = f;
                    f.ShowDialog();
                }

                (Parameter.LOGON_FORM as frmLogon).ClearPassword();
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog(this);
        }

        private void wipClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Parameter.LOGON_FORM != null)
            {
                (Parameter.LOGON_FORM as frmLogon).ShowWIP(false);
            }
         }

        private void frmModeling_FormClosed(object sender, FormClosedEventArgs e)
        {
            Parameter.MAIN_FORM_MODELING = null;

            try
            {
                if (Parameter.ApplicationExitFlag == true)
                {
                    this.Owner.Dispose();
                    System.Environment.Exit(0);
                }
            }
            catch
            {
            }
        }

        
        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }
        #endregion

        #region Methods
        public void Preparation()
        {
            this.ucStatusBar1.SetCurrentUser(Parameter.LOGON_USER);

            if (Parameter.CURRENT_SYSTEM_CONFIG == null)
            {
                Parameter.CURRENT_SYSTEM_CONFIG = baseForm.GetAllSystemConfig();
                baseForm.SetParameter();
            }

            if (Parameter.CURRENT_STATIC_VALUE==null)
                Parameter.CURRENT_STATIC_VALUE = baseForm.GetAllStaticValue();

            frmMain frm = new frmMain();
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();

        }

        private void DoLogout()
        {          
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            try
            {
                baseForm.SetCursor();
                client.Logout(baseForm.CurrentContextInfo, Parameter.SESSION_ID);
            }
            catch (Exception ex)
            {
                if (ex.Message == "-200024")
                    this.Close();
                else
                    MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
        }
        #endregion

       

        

        

        
    }
}

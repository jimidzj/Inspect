using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Common;
using System.Net;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.WinPAD.Common.Classes;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.WinPAD.Common.Forms;
using GENLSYS.MES.WinPAD.SEC;
using GENLSYS.MES.AutoUpdate;
using System.Diagnostics;

namespace GENLSYS.MES.WinPAD
{
    public partial class MainMenu : Form
    {
        private BaseForm baseForm;
        String fun = "";
        public MainMenu()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            //
            Screen screen = Screen.PrimaryScreen;
            int screenW = screen.Bounds.Width;         //宽 
            int screenH = screen.Bounds.Height;         //高 
            panel1.Left = (screenW - panel1.Width) / 2;
            panel1.Top = (screenH - panel1.Height) / 2;
        }
        private void showPOList()
        {
            frmMain mainList = new frmMain(fun);
            mainList.Show();
           // this.Close();
        }
        private void butIAss_Click(object sender, EventArgs e)
        {
           fun = ((Button)sender).Tag.ToString();
           showPOList();

        }

        private void butXOpen_Click(object sender, EventArgs e)
        {
            fun = ((Button)sender).Tag.ToString();
            showPOList();
        }

        private void butIOpen_Click(object sender, EventArgs e)
        {
            fun = ((Button)sender).Tag.ToString();
            showPOList();
        }

        private void butXAssy_Click(object sender, EventArgs e)
        {
            fun = ((Button)sender).Tag.ToString();
            showPOList();
        }

        private string iniPermission()
        {
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {                
             string function=   client.GetFuncByUser( baseForm.CurrentContextInfo );
             return function;
            }
            catch (Exception ex)
            {
               baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00122"));
               return null;
            }
            finally
            {
                baseForm.ResetCursor();
                if (client.State == System.ServiceModel.CommunicationState.Opened)
                    baseForm.CloseWCF(client);
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
           string fun= "$"+iniPermission();
           if ( fun.IndexOf(  this.butIAss.Tag.ToString().ToUpper()) >0 )
	       {
               this.butIAss.Enabled = true;
	       }

           if (fun.IndexOf(this.butIOpen.Tag.ToString().ToUpper()) > 0)
           {
               this.butIOpen.Enabled = true;
           }

           if (fun.IndexOf(this.butXAssy.Tag.ToString().ToUpper()) > 0)
           {
               this.butXAssy.Enabled = true;
           }

           if (fun.IndexOf(this.butXOpen.Tag.ToString().ToUpper()) > 0)
           {
               this.butXOpen.Enabled = true;
           }
        }

        private void butQuit_Click(object sender, EventArgs e)
        {
            this.Close();
            ((Form)(Parameter.LOGON_FORM)).Show();
            
        }

        private void butShutdown_Click(object sender, EventArgs e)
        {
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

        private void butUpdate_Click(object sender, EventArgs e)
        { 
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
            //  frmUpgradeAssistant f = new frmUpgradeAssistant();
            //f.ShowDialog(this);
        }
     
    }
}

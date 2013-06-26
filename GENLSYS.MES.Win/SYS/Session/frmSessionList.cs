using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Utility;
using Infragistics.Win.UltraWinGrid;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;

namespace GENLSYS.MES.Win.SYS.Session
{
    public partial class frmSessionList : Form
    {
        private BaseForm baseForm;

        #region Construct
        public frmSessionList()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.gridSessionList, new string[] { "SESSIONID", "USERID", "MACHINE", "IPADDRESS", "LOGONTIME", "SHIFT", "ISLOCKED", "ISKILLED" });
        }
        #endregion

        #region Event
        private void frmSessionList_Load(object sender, EventArgs e)
        {
            baseForm.SetQueryGridStyle(this.gridSessionList);
            baseForm.SetFace(this);
            this.gridSessionList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            ShowSessionList();
        }

        private void gridSessionList_AfterRowActivate(object sender, EventArgs e)
        {
            //ControlButton();
        }
        private void gridSessionList_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UltraGridColumn lockColumn = e.Layout.Bands[0].Columns["ISLOCKED"];
            lockColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.TriStateCheckBox;
            lockColumn.Editor.DataFilter = new CheckEditorStringDataFilter();
            UltraGridColumn killColumn = e.Layout.Bands[0].Columns["ISKILLED"];
            killColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.TriStateCheckBox;
            killColumn.Editor.DataFilter = new CheckEditorStringDataFilter();

            this.gridSessionList.DisplayLayout.Bands[0].Columns["LOGONTIME"].Format = Parameter.DATETIME_FORMAT;
        }

        private void toolStripButtonLock_Click(object sender, EventArgs e)
        {
            DoLock();
        }

        private void toolStripButtonUnLock_Click(object sender, EventArgs e)
        {
            DoUnLock();
        }

        private void toolStripButtonKill_Click(object sender, EventArgs e)
        {
            DoKill();
        }

        private void toolStripButtonExport_Click(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.gridSessionList);
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowSessionList();
        }
        #endregion


        #region Method
        private void ControlButton()
        {
            if (this.gridSessionList.ActiveRow != null)
            {
                if (this.gridSessionList.ActiveRow.Cells["ISKILLED"].Value.ToString() == MES_Misc.Y.ToString())
                {
                    this.btnLock.Enabled = false;
                    this.btnUnlock.Enabled = false;
                    this.btnKill.Enabled = false;
                }
                else
                {
                    this.btnKill.Enabled = true;
                    if (this.gridSessionList.ActiveRow.Cells["ISLOCKED"].Value.ToString() == MES_Misc.Y.ToString())
                    {
                        this.btnLock.Enabled = false;
                        this.btnUnlock.Enabled = true;
                    }
                    else
                    {
                        this.btnLock.Enabled = true;
                        this.btnUnlock.Enabled = false;
                    }
                }
            }
        }

        private void ShowSessionList()
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            try
            {
                baseForm.SetCursor();
                DataSet ds = client.GetSessionRecords(baseForm.CurrentContextInfo, (new List<MESParameterInfo>()).ToArray<MESParameterInfo>());
                this.gridSessionList.SetDataBinding(ds.Tables[0], "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.btnExport.Enabled = true;
                    this.gridSessionList.Rows[0].Selected = true;
                }
                else
                {
                    this.btnExport.Enabled = false;
                }

                this.ucStatusBarSessionList.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + ds.Tables[0].Rows.Count.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
        }
        private tsyssession GetSingleSession(string _sessionid)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            tsyssession result = null;
            try
            {
                baseForm.SetCursor();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "sessionid",
                    ParamValue = _sessionid,
                    ParamType = "string"
                });
                result = client.GetSingleSession(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
            return result;
        }

        private void DoLock()
        {
            if (this.gridSessionList.Selected.Rows.Count>0)
            {
                List<string> lstSession = new List<string>();
                foreach (UltraGridRow row in this.gridSessionList.Selected.Rows)
                {
                    lstSession.Add(row.Cells["SESSIONID"].Value.ToString());
                }
                DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                 MessageBoxButtons.OKCancel,null,
                                                                 UtilCulture.GetString("Msg.R00047"));
                if (result == DialogResult.OK)
                {
                    baseForm.SetCursor();
                     wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
                     try
                     {
                         client.DoUpdateLock(baseForm.CurrentContextInfo, lstSession.ToArray<string>(), MES_Misc.Y.ToString());
                         foreach (UltraGridRow row in this.gridSessionList.Selected.Rows)
                         {
                             row.Cells["ISLOCKED"].Value = MES_Misc.Y.ToString();
                         }
                     }
                     catch (Exception ex)
                     {
                         MESMsgBox.ShowError(ExceptionParser.Parse(ex));
                     }
                     finally
                     {
                         baseForm.ResetCursor();
                         baseForm.CloseWCF(client);
                     }
                 }

            }
        }
        private void DoUnLock()
        {
            if (this.gridSessionList.Selected.Rows.Count > 0)
            {
                List<string> lstSession = new List<string>();
                foreach (UltraGridRow row in this.gridSessionList.Selected.Rows)
                {
                    lstSession.Add(row.Cells["SESSIONID"].Value.ToString());
                }
                DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                 MessageBoxButtons.OKCancel,null,
                                                                 UtilCulture.GetString("Msg.R00048"));
                if (result == DialogResult.OK)
                {
                    baseForm.SetCursor();
                    wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
                    try
                    {
                        client.DoUpdateLock(baseForm.CurrentContextInfo, lstSession.ToArray<string>(), MES_Misc.N.ToString());
                        foreach (UltraGridRow row in this.gridSessionList.Selected.Rows)
                        {
                            row.Cells["ISLOCKED"].Value = MES_Misc.N.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MESMsgBox.ShowError(ExceptionParser.Parse(ex));
                    }
                    finally
                    {
                        baseForm.ResetCursor();
                        baseForm.CloseWCF(client);
                    }
                }

            }
        }
        private void DoKill()
        {
            if (this.gridSessionList.Selected.Rows.Count > 0)
            {
                List<string> lstSession = new List<string>();
                foreach (UltraGridRow row in this.gridSessionList.Selected.Rows)
                {
                    lstSession.Add(row.Cells["SESSIONID"].Value.ToString());
                }
                DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                 MessageBoxButtons.OKCancel,null,
                                                                 UtilCulture.GetString("Msg.R00049"));
                if (result == DialogResult.OK)
                {
                    baseForm.SetCursor();
                    wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
                    try
                    {
                        client.DoUpdateKill(baseForm.CurrentContextInfo, lstSession.ToArray<string>());
                        foreach (UltraGridRow row in this.gridSessionList.Selected.Rows)
                        {
                            row.Cells["ISKILLED"].Value = MES_Misc.Y.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MESMsgBox.ShowError(ExceptionParser.Parse(ex));
                    }
                    finally
                    {
                        baseForm.ResetCursor();
                        baseForm.CloseWCF(client);
                    }
                }

            }
        }
        #endregion
    }
}

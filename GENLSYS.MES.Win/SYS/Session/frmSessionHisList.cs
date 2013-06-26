using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Common;
using Infragistics.Win.UltraWinGrid;

namespace GENLSYS.MES.Win.SYS.Session
{
    public partial class frmSessionHisList : Form
    {
        public  Dictionary<string,object> QueryParameters { get; set; }
        private BaseForm baseForm;

        #region Construct
        public frmSessionHisList()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.gridSessionHisList, new string[] { "SESSIONID", "USERID", "MACHINE", "IPADDRESS", "LOGONTIME", "SHIFT" });
        }
        #endregion

        #region Event
        private void frmSessionHisList_Load(object sender, EventArgs e)
        {
            baseForm.SetQueryGridStyle(this.gridSessionHisList);
            baseForm.SetFace(this);
            this.ucToolbarSessionHisList.SetNewVisible(false);
            this.ucToolbarSessionHisList.SetEditVisible(false);
            this.gridSessionHisList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;

            QueryParameters = new Dictionary<string, object>();
        }

        private void gridSessionHisList_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.gridSessionHisList.ActiveRow != null)
            {
                this.ucToolbarSessionHisList.SetToolbarWithSelection();
            }
            else
            {
                this.ucToolbarSessionHisList.SetToolbarWithoutSelection();
            }
        }

        private void ucToolbarSessionHisList_QueryEventHandler(object sender, EventArgs e)
        {
            QuerySessionHis();
        }
        private void ucToolbarSessionHisList_DeleteEventHandler(object sender, EventArgs e)
        {
            DoMultiDelete();
        }
        private void ucToolbarSessionHisList_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.gridSessionHisList);
        }

        private void ucToolbarSessionHisList_ExitEventHandler(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion

        #region Method
        public void ShowSessionHisList()
        {
            wsSYS.IwsSYSClient client =new wsSYS.IwsSYSClient();
            try
            {
                baseForm.SetCursor();
                DateTime fromLogonTime = DateTime.Parse(((DateTime)QueryParameters["fromlogontime"]).ToString("yyyy-MM-dd")+" 00:00:00");
                DateTime toLogonTime = DateTime.Parse(((DateTime)QueryParameters["tologontime"]).ToString("yyyy-MM-dd") + " 23:59:59");
                DataSet ds = client.GetSessionHisRecords(baseForm.CurrentContextInfo, (string)QueryParameters["userid"], (string)QueryParameters["machine"], (string)QueryParameters["ipaddress"], (string)QueryParameters["shift"], fromLogonTime, toLogonTime);
                this.gridSessionHisList.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.ucToolbarSessionHisList.SetToolbarWithRows();
                    this.gridSessionHisList.Rows[0].Selected = true;
                }
                else
                {
                    this.ucToolbarSessionHisList.SetToolbarWithoutRows();
                }

                this.ucStatusBarSessionHisList.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + ds.Tables[0].Rows.Count.ToString());
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
        private void QuerySessionHis()
        {
            frmSessionHisQuery frm = new frmSessionHisQuery();
            frm.QueryParameters = QueryParameters;
            frm.ShowDialog(this);
            QueryParameters = frm.QueryParameters;
            ShowSessionHisList();
        }

        public void DoMultiDelete()
        {
            if (this.gridSessionHisList.Selected.Rows.Count>0)
            {
                List<string> lstSession = new List<string>();
                foreach (UltraGridRow row in this.gridSessionHisList.Selected.Rows)
                {
                    lstSession.Add(row.Cells["SESSIONID"].Value.ToString());
                }
                DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                 MessageBoxButtons.OKCancel,null,
                                                                 UtilCulture.GetString("Msg.R00004"));
                if (result == DialogResult.OK)
                {
                     wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
                     try
                     {
                         baseForm.SetCursor();
                         client.DoSessionMultiDelete(baseForm.CurrentContextInfo, lstSession.ToArray<string>());
                         ShowSessionHisList();
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

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
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Win.SYS.BillCodeRule
{
    public partial class frmBillCodeRuleList : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmBillCodeRuleList()
        {
            InitializeComponent();

            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { "bcrid","bcrname","basevalue",
                    "ffchars","timeformat","bcrstatus","lastmodifieduser","lastmodifiedtime" });
        }
        #endregion

        #region Events
        private void frmBillCodeRuleList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            GetData(new List<MESParameterInfo>() { });
        }

        private void ucToolbar1_DeleteEventHandler(object sender, EventArgs e)
        {
            DoDelete();
        }

        private void ucToolbar1_EditEventHandler(object sender, EventArgs e)
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
            lstParameters.Add(new MESParameterInfo()
            {
                ParamName = "bcrid",
                ParamValue = this.grdQuery.ActiveRow.Cells["bcrid"].Value.ToString(),
                ParamType = "string"
            });

            frmBillCodeRuleEdit f = new frmBillCodeRuleEdit();
            f.UpdateMode = GENLSYS.MES.Common.Public_UpdateMode.Update;
            f.PrimaryKeys = lstParameters;
            f.ShowDialog();
            GetData(QueryParameters);
        }

        private void ucToolbar1_ExitEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucToolbar1_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.grdQuery);
        }

        private void ucToolbar1_NewEventHandler(object sender, EventArgs e)
        {
            frmBillCodeRuleEdit f = new frmBillCodeRuleEdit();
            f.UpdateMode = GENLSYS.MES.Common.Public_UpdateMode.Insert;
            f.ShowDialog();
            GetData(QueryParameters);
        }

        private void ucToolbar1_QueryEventHandler(object sender, EventArgs e)
        {
            GetData(new List<MESParameterInfo>() { });
        }

        private void grdQuery_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.grdQuery.ActiveRow != null)
            {
                this.ucToolbar1.SetToolbarWithSelection();

                if (this.grdQuery.ActiveRow.Cells["bcrstatus"].Value.ToString() != MES_BillCodeRule_BCRStatus.Unused.ToString())
                {
                    this.ucToolbar1.SetDeleteVisible(false);
                }
            }
            else
            {
                this.ucToolbar1.SetToolbarWithoutSelection();
            }
        }
        #endregion

        #region Methods
        private void GetData(List<MESParameterInfo> lstParameters)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetBillCodeRuleRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                this.grdQuery.SetDataBinding(ds.Tables[0], "");

                if (this.grdQuery.Rows.Count < 1)
                {
                    this.ucToolbar1.SetToolbarWithoutRows();
                }
                else
                {
                    this.ucToolbar1.SetToolbarWithRows();
                }

                this.ucStatusBar1.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + ds.Tables[0].Rows.Count.ToString());
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

        public void DoDelete()
        {
            if (this.grdQuery.ActiveRow == null) return;

            DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                        MessageBoxButtons.OKCancel,
                        UtilCulture.GetString("Msg.R00004"),
                        "<span style='font-weight:bold;'>" + UtilCulture.GetString("Label.R00487") + ": </span> " +
                            this.grdQuery.ActiveRow.Cells["bcrid"].Value.ToString());

            if (result == DialogResult.Cancel) return;

            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            try
            {
                baseForm.SetCursor();

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                    new MESParameterInfo(){
                        ParamName="bcrid",
                        ParamValue=this.grdQuery.ActiveRow.Cells["bcrid"].Value.ToString(),
                        ParamType="string"
                    }
                };
                client.DoDeleteBillCodeRule(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00003"));

                GetData(QueryParameters);
            }
            catch (Exception ex)
            {
                baseForm.ResetCursor();
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

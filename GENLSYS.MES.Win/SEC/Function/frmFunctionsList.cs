using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Win.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.Common;
using Infragistics.Win.UltraWinGrid;

namespace GENLSYS.MES.Win.SEC.Function
{
    public partial class frmFunctionsList : Form
    {
        public List<MESParameterInfo> QueryParameters { get; set; }
        private BaseForm baseForm;

        #region Construct
        public frmFunctionsList()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.gridFunctionsList, new string[] { "FUNCID", "FUNCTYPE", "FUNCDESC", "LEVELNO", "FUNCURL", "PARENTFUNCID", "CREATEDUSER", "CREATEDTIME", "LASTMODIFIEDUSER", "LASTMODIFIEDTIME" });
        }
        #endregion

        #region Event
        private void frmFunctionsList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.gridFunctionsList);

            this.gridFunctionsList.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

            QueryParameters = new List<MESParameterInfo>();
            ShowFunctionsList();
        }

        private void ucToolbarFunctionsList_NewEventHandler(object sender, EventArgs e)
        {
            NewFunctions();
        }

        private void ucToolbarFunctionsList_DeleteEventHandler(object sender, EventArgs e)
        {
            DeleteFunctions();
        }

        private void ucToolbarFunctionsList_EditEventHandler(object sender, EventArgs e)
        {
            UpdateFunctions();
        }

        private void ucToolbarFunctionsList_QueryEventHandler(object sender, EventArgs e)
        {
            QueryFunctions();
        }

        private void ucToolbarFunctionsList_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.gridFunctionsList);
        }

        private void ucToolbarFunctionsList_ExitEventHandler(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
        private void gridFunctionsList_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.gridFunctionsList.ActiveRow!=null)
            {
                this.ucToolbarFunctionsList.SetToolbarWithSelection();
            }
            else
            {
                this.ucToolbarFunctionsList.SetToolbarWithoutSelection();
            }
        }
        #endregion

        #region Method
        public void ShowFunctionsList()
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            try
            {
                baseForm.SetCursor();
                DataSet ds = client.GetFunctionsRecords(baseForm.CurrentContextInfo, QueryParameters.ToArray<MESParameterInfo>());
                this.gridFunctionsList.SetDataBinding(ds.Tables[0],"");
                if (ds.Tables[0].Rows.Count < 1)
                {
                    this.ucToolbarFunctionsList.SetToolbarWithoutRows();
                }
                else
                {
                    this.ucToolbarFunctionsList.SetToolbarWithRows();
                }
                this.ucStatusBarFunctionsList.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + ds.Tables[0].Rows.Count.ToString());
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

        private void UpdateFunctions()
        {
            if (this.gridFunctionsList.ActiveRow!=null)
            {
                frmFunctionsEdit frm = new frmFunctionsEdit();
                frm.FuncId = this.gridFunctionsList.ActiveRow.Cells["FUNCID"].Value.ToString();
                frm.ShowDialog(this);
                ShowFunctionsList();
            }
        }

        private void NewFunctions()
        {
            frmFunctionsEdit frm = new frmFunctionsEdit();
            frm.ShowDialog(this);
            ShowFunctionsList();
        }

        private void DeleteFunctions()
        {
            if (this.gridFunctionsList.ActiveRow!=null)
            {
                Dictionary<string, object> dir = new Dictionary<string, object>();
                dir.Add(UtilCulture.GetString("Label.R00143") , this.gridFunctionsList.ActiveRow.Cells["FUNCID"].Value.ToString());
                DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                MessageBoxButtons.OKCancel,
                                                                UtilCulture.GetString("Msg.R00004"),
                                                                dir);
                if (result.ToString().Equals("OK"))
                {
                    baseForm.SetCursor();
                    wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
                    try
                    {
                        List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                        lstParameters.Add(new MESParameterInfo()
                        {
                            ParamName = "funcid",
                            ParamValue = this.gridFunctionsList.ActiveRow.Cells["FUNCID"].Value.ToString(),
                            ParamType = "string"
                        });
                        client.DoDeleteFunctions(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                        ShowFunctionsList();
                        baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00003"));
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

        private void QueryFunctions()
        {
            frmFunctionsQuery frm = new frmFunctionsQuery();
            frm.QueryParameters = QueryParameters;
            frm.ShowDialog(this);
            QueryParameters = frm.QueryParameters;
            ShowFunctionsList();
        }
        #endregion

       
    }
}

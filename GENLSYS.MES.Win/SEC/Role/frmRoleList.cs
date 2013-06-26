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

namespace GENLSYS.MES.Win.SEC.Role
{
    public partial class frmRoleList : Form
    {
        public List<MESParameterInfo> QueryParameters { get; set; }
        private BaseForm baseForm;

        #region Construct
        public frmRoleList()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.gridRoleList, new string[] { "ROLEID", "ROLESTATUS", "ROLEDESC", "CREATEDUSER", "CREATEDTIME", "LASTMODIFIEDUSER", "LASTMODIFIEDTIME" });
        }
        #endregion

        #region Event
        private void frmRoleList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.gridRoleList);

            QueryParameters = new List<MESParameterInfo>();
            ShowRoleList();
        }

        private void ucToolbarRoleList_NewEventHandler(object sender, EventArgs e)
        {
            NewRole();
        }

        private void ucToolbarRoleList_DeleteEventHandler(object sender, EventArgs e)
        {
            DeleteRole();
        }

        private void ucToolbarRoleList_EditEventHandler(object sender, EventArgs e)
        {
            UpdateRole();
        }

        private void ucToolbarRoleList_QueryEventHandler(object sender, EventArgs e)
        {
            QueryRole();
        }

        private void ucToolbarRoleList_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.gridRoleList);
        }

        private void ucToolbarRoleList_ExitEventHandler(object sender, EventArgs e)
        {
            this.Dispose();
        }
                
        private void gridRoleList_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.gridRoleList.ActiveRow!=null)
            {
                this.ucToolbarRoleList.SetToolbarWithSelection();
            }
            else
            {
                this.ucToolbarRoleList.SetToolbarWithoutSelection();
            }
        }
        #endregion

        #region Method
        public void ShowRoleList()
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            try
            {
                baseForm.SetCursor();
                DataSet ds = client.GetRoleRecords(baseForm.CurrentContextInfo, QueryParameters.ToArray<MESParameterInfo>());
                this.gridRoleList.SetDataBinding(ds.Tables[0], "");
                if (ds.Tables[0].Rows.Count < 1)
                {
                    this.ucToolbarRoleList.SetToolbarWithoutRows();
                }
                else
                {
                    this.ucToolbarRoleList.SetToolbarWithRows();
                }
                this.ucStatusBarRoleList.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + ds.Tables[0].Rows.Count.ToString());
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

        private void UpdateRole()
        {
            if (this.gridRoleList.ActiveRow != null)
            {
                frmRoleEdit frm = new frmRoleEdit();
                frm.RoleId = this.gridRoleList.ActiveRow.Cells["ROLEID"].Value.ToString();
                frm.ShowDialog(this);
                ShowRoleList();
            }
        }

        private void NewRole()
        {
            frmRoleEdit frm = new frmRoleEdit();
            frm.ShowDialog(this);
            ShowRoleList();
        }

        private void DeleteRole()
        {
            if (this.gridRoleList.ActiveRow != null)
            {
                Dictionary<string, object> dir = new Dictionary<string, object>();
                dir.Add(UtilCulture.GetString("Label.R00167") , this.gridRoleList.ActiveRow.Cells["ROLEID"].Value.ToString());
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
                            ParamName = "roleid",
                            ParamValue = this.gridRoleList.ActiveRow.Cells["ROLEID"].Value.ToString(),
                            ParamType = "string"
                        });
                        client.DoDeleteRole(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                        ShowRoleList();
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

        private void QueryRole()
        {
            frmRoleQuery frm = new frmRoleQuery();
            frm.QueryParameters = QueryParameters;
            frm.ShowDialog(this);
            QueryParameters = frm.QueryParameters;
            ShowRoleList();
        }
        #endregion

       
    }
}

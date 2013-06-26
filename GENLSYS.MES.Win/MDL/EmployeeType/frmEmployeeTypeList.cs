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

namespace GENLSYS.MES.Win.MDL.EmployeeType
{
    public partial class frmEmployeeTypeList : Form
    {
        public List<MESParameterInfo> QueryParameters { get; set; }
        private BaseForm baseForm;

        public frmEmployeeTypeList()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.gridEmployeeTypeList, new string[] { "EMPLOYEETYPEID", "EMPLOYEETYPENAME", "LASTMODIFIEDUSER", "LASTMODIFIEDTIME" });
        }
        #region Event
        private void frmEmployeeTypeList_Load(object sender, EventArgs e)
        {
            baseForm.SetQueryGridStyle(this.gridEmployeeTypeList);
            baseForm.SetFace(this);

            QueryParameters = new List<MESParameterInfo>();
            ShowEmployeeTypeList();
        }

        private void gridEmployeeTypeList_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.gridEmployeeTypeList.ActiveRow != null)
            {
                this.ucToolbarEmployeeTypeList.SetToolbarWithSelection();
            }
            else
            {
                this.ucToolbarEmployeeTypeList.SetToolbarWithoutSelection();
            }
        }

        private void ucToolbarEmployeeTypeList_NewEventHandler(object sender, EventArgs e)
        {
            NewEmployeeType();
        }

        private void ucToolbarEmployeeTypeList_DeleteEventHandler(object sender, EventArgs e)
        {
            DeleteEmployeeType();
        }

        private void ucToolbarEmployeeTypeList_ExitEventHandler(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ucToolbarEmployeeTypeList_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.gridEmployeeTypeList);
        }

        private void ucToolbarEmployeeTypeList_EditEventHandler(object sender, EventArgs e)
        {
            UpdateEmployeeType();
        }

        private void ucToolbarEmployeeTypeList_QueryEventHandler(object sender, EventArgs e)
        {
            ShowEmployeeTypeList();
        }

        #endregion

        #region Method
        public void ShowEmployeeTypeList()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                baseForm.SetCursor();
                DataSet ds = client.GetEmployeeTypeRecords(baseForm.CurrentContextInfo, QueryParameters.ToArray<MESParameterInfo>());
                this.gridEmployeeTypeList.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.ucToolbarEmployeeTypeList.SetToolbarWithRows();
                }
                else
                {
                    this.ucToolbarEmployeeTypeList.SetToolbarWithoutRows();
                }

                this.ucStatusBarEmployeeTypeList.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + ds.Tables[0].Rows.Count.ToString());
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

        private void UpdateEmployeeType()
        {
            if (this.gridEmployeeTypeList.ActiveRow != null)
            {
                frmEmployeeTypeEdit frm = new frmEmployeeTypeEdit();
                frm.EmployeeTypeId = this.gridEmployeeTypeList.ActiveRow.Cells["EMPLOYEETYPEID"].Value.ToString();
                frm.ShowDialog(this);
                ShowEmployeeTypeList();
            }
        }

        private void NewEmployeeType()
        {
            frmEmployeeTypeEdit frm = new frmEmployeeTypeEdit();
            frm.ShowDialog(this);
            ShowEmployeeTypeList();
        }

        private void DeleteEmployeeType()
        {

            if (this.gridEmployeeTypeList.ActiveRow != null)
            {
                Dictionary<string, object> dir = new Dictionary<string, object>();
                dir.Add(UtilCulture.GetString("Label.R00380"), this.gridEmployeeTypeList.ActiveRow.Cells["EMPLOYEETYPEID"].Value.ToString());
                DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                MessageBoxButtons.OKCancel,
                                                                UtilCulture.GetString("Msg.R00004"),
                                                                dir);
                if (result == DialogResult.OK)
                {
                    baseForm.SetCursor();
                    wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
                    try
                    {
                        List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                        lstParameters.Add(new MESParameterInfo()
                        {
                            ParamName = "employeetypeid",
                            ParamValue = this.gridEmployeeTypeList.ActiveRow.Cells["EMPLOYEETYPEID"].Value.ToString(),
                            ParamType = "string"
                        });
                        client.DoDeleteEmployeeType(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                        ShowEmployeeTypeList();
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
        #endregion 

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Win.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.Common;
using Infragistics.Win.UltraWinGrid;

namespace GENLSYS.MES.Win.MDL.Employee
{
    public partial class frmEmployeeList : Form
    {
        public List<MESParameterInfo> QueryParameters { get; set; }
        private BaseForm baseForm;

        #region Construct
        public frmEmployeeList()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.gridEmployeeList, new string[] { "employeeid", "employeename", "employeetypeid", "department", 
                "email", "telno", "mobileno", "employeestatus", "defaultshift","grade","workgroup","probationdate","effectdate","lastmodifieduser", "lastmodifiedtime" });
        }
        #endregion

        #region Event
        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.gridEmployeeList);

            this.gridEmployeeList.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

            QueryParameters = new List<MESParameterInfo>();
            ShowEmployeeList();
        }              

        private void ucToolbarEmployeeList_EditEventHandler(object sender, EventArgs e)
        {
            UpdateEmployee();
        }

        private void ucToolbarEmployeeList_ExitEventHandler(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ucToolbarEmployeeList_DeleteEventHandler(object sender, EventArgs e)
        {
            DeleteEmployee();
        }

        private void ucToolbarEmployeeList_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.gridEmployeeList);
        }

        private void ucToolbarEmployeeList_NewEventHandler(object sender, EventArgs e)
        {
            NewEmployee();
        }

        private void ucToolbarEmployeeList_QueryEventHandler(object sender, EventArgs e)
        {
            QueryEmployee();
        }
               
        private void gridEmployeeList_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.gridEmployeeList.ActiveRow!=null)
            {
                this.ucToolbarEmployeeList.SetToolbarWithSelection();
            }
            else
            {
                this.ucToolbarEmployeeList.SetToolbarWithoutSelection();
            }
        }
        private void gridEmployeeList_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["department"].Hidden = true;
            e.Layout.Bands[0].Columns["email"].Hidden = true;
            e.Layout.Bands[0].Columns["telno"].Hidden = true;
            e.Layout.Bands[0].Columns["mobileno"].Hidden = true;
            e.Layout.Bands[0].Columns["grade"].Hidden = true;

            if (!e.Layout.ValueLists.Exists("vlemployeetypeid"))
            {
                e.Layout.ValueLists.Add("vlemployeetypeid");
                e.Layout.ValueLists["vlemployeetypeid"].ValueListItems.AddRange(DropDown.GetValueList_DataTable(GetEmployeeType(), "employeetypename", "employeetypeid"));
                e.Layout.Bands[0].Columns["employeetypeid"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["employeetypeid"].ValueList = e.Layout.ValueLists["vlemployeetypeid"];
            }
            if (!e.Layout.ValueLists.Exists("vlworkgroup"))
            {
                e.Layout.ValueLists.Add("vlworkgroup");
                e.Layout.ValueLists["vlworkgroup"].ValueListItems.AddRange(DropDown.GetValueList_DataTable(GetWorkGroup(), "workgroupdesc", "workgroup"));
                e.Layout.Bands[0].Columns["workgroup"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["workgroup"].ValueList = e.Layout.ValueLists["vlworkgroup"];
            }
        }
        #endregion

        public void ShowEmployeeList()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                baseForm.SetCursor();
                DataSet employeeDs = client.GetEmployeeRecords(baseForm.CurrentContextInfo, QueryParameters.ToArray<MESParameterInfo>());
                this.gridEmployeeList.SetDataBinding( employeeDs.Tables[0],"");
                if (employeeDs.Tables[0].Rows.Count < 1)
                {
                    this.ucToolbarEmployeeList.SetToolbarWithoutRows();
                }
                else
                {
                    this.ucToolbarEmployeeList.SetToolbarWithRows();
                }
                this.ucStatusBarEmployeeList.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + employeeDs.Tables[0].Rows.Count.ToString());
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

        private void UpdateEmployee()
        {
            if (this.gridEmployeeList.ActiveRow!=null)
            {
                frmEmployeeEdit frm = new frmEmployeeEdit();
                frm.EmployeeId = this.gridEmployeeList.ActiveRow.Cells["EMPLOYEEID"].Value.ToString();
                frm.ShowDialog(this);
                ShowEmployeeList();
            }
        }

        private void NewEmployee()
        {
            frmEmployeeEdit frm = new frmEmployeeEdit();
            frm.ShowDialog(this);
            ShowEmployeeList();
        }

        private void DeleteEmployee()
        {
            if (this.gridEmployeeList.ActiveRow != null)
            {
                Dictionary<string, object> dir = new Dictionary<string, object>();
                dir.Add(UtilCulture.GetString("Label.R00022"), this.gridEmployeeList.ActiveRow.Cells["EMPLOYEEID"].Value.ToString());
                //DialogResult result = MessageBox.Show(UtilCulture.GetString("Msg.R00004"), UtilCulture.GetString("Msg.R00005"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                            ParamName = "employeeid",
                            ParamValue = this.gridEmployeeList.ActiveRow.Cells["EMPLOYEEID"].Value.ToString(),
                            ParamType = "string"
                        });
                        client.DoDeleteEmployee(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                        ShowEmployeeList();
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

        private void QueryEmployee()
        {
            frmEmployeeQuery frm = new frmEmployeeQuery();
            frm.QueryParameters = QueryParameters;
            frm.ShowDialog(this);
            QueryParameters = frm.QueryParameters;
            ShowEmployeeList();
        }

        private DataTable GetEmployeeType()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            DataTable dt = null;
            try
            {
                dt = client.GetEmployeeTypeRecords(baseForm.CurrentContextInfo, (new List<MESParameterInfo>()).ToArray<MESParameterInfo>()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return dt;
        }

        private DataTable GetWorkGroup()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            DataTable dt = null;
            try
            {
                dt = client.GetWorkGroupRecords(baseForm.CurrentContextInfo, (new List<MESParameterInfo>()).ToArray<MESParameterInfo>()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return dt;
        }
        
            
        
                
    }
}

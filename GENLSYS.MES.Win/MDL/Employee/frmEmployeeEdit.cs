using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;

namespace GENLSYS.MES.Win.MDL.Employee
{
    public partial class frmEmployeeEdit : Form
    {
        public string EmployeeId { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode { get; set; }

        #region Construct
        public frmEmployeeEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Event
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            if (EmployeeId != null)
            {
                UpdateMode = Public_UpdateMode.Update;
            }
            else
            {
                UpdateMode = Public_UpdateMode.Insert;
            }
            SetLayout();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                tmdlemployee employee = GetSingleEmployee(EmployeeId);
                baseForm.OriginalObject = employee;
                baseForm.ShowSingleObjectToUI<tmdlemployee>(employee, this);
            }
            else
            {
                baseForm.setDefaultValue(this);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion

        #region Method
        private void SetLayout()
        {
            SetCombobox();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                this.txtEmployeeId.Enabled = false;
            }
        }

        private void SetCombobox()
        {
            DropDown.InitCMB_EmployeeType_All(this.cmbEmployeeType);
            DropDown.InitCMB_Shift_All(this.cmbShift);
            DropDown.InitCMB_Enums(this.cmbEmployeeStatus, typeof(MES_Flag));
            DropDown.InitCMB_WorkGroup(this.cboWorkGroup);
        }

        private tmdlemployee GetSingleEmployee(string _employeeId)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            tmdlemployee result = null;
            try
            {
                baseForm.SetCursor();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "employeeid",
                    ParamValue = _employeeId,
                    ParamType = "string"
                });
                result = client.GetSingleEmployee(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
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


        private void DoSave()
        {
            try
            {
                baseForm.SetCursor();
                baseForm.ValidateData(this);

                tmdlemployee employee = new tmdlemployee();
                if (UpdateMode == Public_UpdateMode.Update)
                {
                    employee = baseForm.OriginalObject as tmdlemployee;
                }
                baseForm.CreateSingleObject<tmdlemployee>(employee, this, UpdateMode);



                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    InsertEmployee(employee);
                }
                else
                {
                    UpdateEmployee(employee);
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                else if (UpdateMode == Public_UpdateMode.Update)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));

                this.Dispose();
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
            finally
            {
                baseForm.ResetCursor();
            }
        }
            

        private void InsertEmployee(tmdlemployee _employee)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                client.DoInsertEmployee(baseForm.CurrentContextInfo, _employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
        }

        private void UpdateEmployee(tmdlemployee _employee)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                client.DoUpdateEmployee(baseForm.CurrentContextInfo, _employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
        }    
        #endregion
    }
}

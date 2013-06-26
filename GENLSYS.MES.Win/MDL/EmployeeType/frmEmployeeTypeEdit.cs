using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Win.MDL.EmployeeType
{
    public partial class frmEmployeeTypeEdit : Form
    {
        public string EmployeeTypeId { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode { get; set; }

        #region Construct
        public frmEmployeeTypeEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Event
        private void frmEmployeeTypeEdit_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            if (EmployeeTypeId != null)
            {
                UpdateMode = Public_UpdateMode.Update;
            }
            else
            {
                UpdateMode = Public_UpdateMode.Insert;
            }

            if (UpdateMode == Public_UpdateMode.Update)
            {
                tmdlemployeetype employeetype = GetSingleEmployeeType(EmployeeTypeId);
                baseForm.OriginalObject = employeetype;
                baseForm.ShowSingleObjectToUI<tmdlemployeetype>(employeetype, this);
                this.txtEmployeeTypeId.Enabled = false;
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

        #region Mothed
        private tmdlemployeetype GetSingleEmployeeType(string _employeeTypeId)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            tmdlemployeetype result = null;
            try
            {
                baseForm.SetCursor();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "employeetypeid",
                    ParamValue = _employeeTypeId,
                    ParamType = "string"
                });
                result = client.GetSingleEmployeeType(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
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

                tmdlemployeetype employeetype = new tmdlemployeetype();
                if (UpdateMode == Public_UpdateMode.Update)
                {
                    employeetype = baseForm.OriginalObject as tmdlemployeetype;
                }
                baseForm.CreateSingleObject<tmdlemployeetype>(employeetype, this, UpdateMode);

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    InsertEmployeeType(employeetype);
                }
                else
                {
                    UpdateEmployeeType(employeetype);
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                }
                else if (UpdateMode == Public_UpdateMode.Update)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));
                }
                this.Dispose();
            }
            catch (UtilException uex)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, ExceptionParser.Parse(uex));
            }
            catch (Exception ex)
            {
                baseForm.ResetCursor();
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
        }


        private void InsertEmployeeType(tmdlemployeetype _employeetype)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                client.DoInsertEmployeeType(baseForm.CurrentContextInfo, _employeetype);
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

        private void UpdateEmployeeType(tmdlemployeetype _employeetype)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                client.DoUpdateEmployeeType(baseForm.CurrentContextInfo, _employeetype);
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

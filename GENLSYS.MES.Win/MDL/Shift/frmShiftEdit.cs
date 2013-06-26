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
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.MDL.Shift
{
    public partial class frmShiftEdit : Form
    {
        public string Shift { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode { get; set; }

        #region Construct
        public frmShiftEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Event
        private void frmShiftEdit_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            if (Shift != null)
            {
                UpdateMode = Public_UpdateMode.Update;
            }
            else
            {
                UpdateMode = Public_UpdateMode.Insert;
            }
            SetLayout();
          //  dtEndTime.Value = new DateTime();
          //  dtStartTime.Value = new DateTime();
            if (UpdateMode == Public_UpdateMode.Update)
            {
                tmdlshift shiftObj = GetSingleShift(Shift);
                baseForm.OriginalObject = shiftObj;
                baseForm.ShowSingleObjectToUI<tmdlshift>(shiftObj, this);
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
            if (UpdateMode == Public_UpdateMode.Update)
            {
                this.txtShift.Enabled = false;
            }
           
        }
        

        private tmdlshift GetSingleShift(string _shift)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            tmdlshift result = null;
            try
            {
                baseForm.SetCursor();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "shift",
                    ParamValue = _shift,
                    ParamType = "string"
                });
                result = client.GetSingleShift(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
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

                tmdlshift shiftObj = new tmdlshift();
                if (UpdateMode == Public_UpdateMode.Update)
                {
                    shiftObj = baseForm.OriginalObject as tmdlshift;
                }
                baseForm.CreateSingleObject<tmdlshift>(shiftObj, this, UpdateMode);

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    InsertShift(shiftObj);
                }
                else
                {
                    UpdateShift(shiftObj);
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                else if (UpdateMode == Public_UpdateMode.Update)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));

                this.Dispose();
            }
            catch (Exception ex)
            {
                baseForm.ResetCursor();
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
        }


        private void InsertShift(tmdlshift _shift)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                client.DoInsertShift(baseForm.CurrentContextInfo, _shift);
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

        private void UpdateShift(tmdlshift _shift)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                client.DoUpdateShift(baseForm.CurrentContextInfo, _shift);
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

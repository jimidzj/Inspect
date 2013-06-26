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
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.MDL.WorkGroup
{
    public partial class frmWorkGroupEdit : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;

        #region Construct
        public frmWorkGroupEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSaveSingleObject();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmWorkGroupEdit_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            SetLayout();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                DoShowSingleObject<tmdlworkgroup>(PrimaryKeys);
            }
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();

            if (UpdateMode == GENLSYS.MES.Common.Public_UpdateMode.Update)
            {
                this.txtWorkGroup.Enabled = false;
            }
        }

        private void SetCombobox()
        {
            DropDown.InitCMB_StaticValue(this.cboStep, MES_StaticValue_Type.Step);
        }

        public void DoSaveSingleObject()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                baseForm.SetCursor();

                baseForm.ValidateData(this);
                tmdlworkgroup workGroup = new tmdlworkgroup();

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                }
                else
                {
                    workGroup = baseForm.OriginalObject as tmdlworkgroup;
                }

                baseForm.CreateSingleObject<tmdlworkgroup>(workGroup, this, UpdateMode);


                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.DoInsertWorkGroup(baseForm.CurrentContextInfo, workGroup);
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.DoUpdateWorkGroup(baseForm.CurrentContextInfo, workGroup);
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                else if (UpdateMode == Public_UpdateMode.Update)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));

                this.Close();
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

        public void DoShowSingleObject<T>(List<MESParameterInfo> lstParameters)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                baseForm.SetCursor();

                tmdlworkgroup workGroup = client.GetSingleWorkGroup(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                baseForm.OriginalObject = workGroup;
                baseForm.ShowSingleObjectToUI<tmdlworkgroup>(workGroup, this);
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
        #endregion
    }
}

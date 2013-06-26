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
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;

namespace GENLSYS.MES.Win.MDL.ReasonCategory
{
    public partial class frmReasonCategoryEdit : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;

        #region Construct
        public frmReasonCategoryEdit()
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

        private void frmReasonCategoryEdit_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            SetLayout();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                DoShowSingleObject<tmdlreasoncategory>(PrimaryKeys);
            }
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();

            if (UpdateMode == GENLSYS.MES.Common.Public_UpdateMode.Update)
            {
                this.txtLocationId.Enabled = false;
            }
        }

        private void SetCombobox()
        {
            #region Attribute Template
           // DropDown.InitCMB_AttributeTemplate_All(this.cmbAttributeTemplate, MES_AttributeTemplate_UsedBy.ReasonCode);
            #endregion
        }

        public void DoSaveSingleObject()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                baseForm.SetCursor();

                baseForm.ValidateData(this);
                tmdlreasoncategory category = new tmdlreasoncategory();

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                }
                else
                {
                    category = baseForm.OriginalObject as tmdlreasoncategory;
                }

                baseForm.CreateSingleObject<tmdlreasoncategory>(category, this, UpdateMode);


                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.DoInsertReasonCategory(baseForm.CurrentContextInfo, category);
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.DoUpdateReasonCategory(baseForm.CurrentContextInfo, category);
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

                tmdlreasoncategory category = client.GetSingleReasonCategory(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                baseForm.OriginalObject = category;
                baseForm.ShowSingleObjectToUI<tmdlreasoncategory>(category, this);
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

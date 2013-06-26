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

namespace GENLSYS.MES.Win.SYS.SystemConfig
{
    public partial class frmSystemConfigEdit : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;

        #region Construct
        public frmSystemConfigEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events
        private void frmSystemConfigEdit_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            SetLayout();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                DoShowSingleObject<tsyssystemconfig>(PrimaryKeys);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSaveSingleObject();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();

            if (UpdateMode == GENLSYS.MES.Common.Public_UpdateMode.Update)
            {
                this.txtConfigName.Enabled = false;
            }
        }

        private void SetCombobox()
        {
            //#region Container Type
            //DropDown.InitCMB_Enums(this.cmbFlag, typeof(Public_ActiveFlag));
            //#endregion
        }

        public void DoSaveSingleObject()
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                baseForm.ValidateData(this);
                tsyssystemconfig systemConfig = new tsyssystemconfig();

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                }
                else
                {
                    systemConfig = baseForm.OriginalObject as tsyssystemconfig;
                }

                baseForm.CreateSingleObject<tsyssystemconfig>(systemConfig, this, UpdateMode);


                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.DoInsertSystemConfig(baseForm.CurrentContextInfo, systemConfig);
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.DoUpdateSystemConfig(baseForm.CurrentContextInfo, systemConfig);
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                    MESMsgBox.ShowInformation(UtilCulture.GetString("Msg.R00001"));
                else if (UpdateMode == Public_UpdateMode.Update)
                    MESMsgBox.ShowInformation(UtilCulture.GetString("Msg.R00002"));

                this.Close();

            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
            finally
            {
                this.Cursor = Cursors.Default;
                baseForm.CloseWCF(client);
            }
        }

        public void DoShowSingleObject<T>(List<MESParameterInfo> lstParameters)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();

            try
            {
                baseForm.SetCursor();
                tsyssystemconfig staticValue = client.GetSingleSystemConfig(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                baseForm.OriginalObject = staticValue;
                baseForm.ShowSingleObjectToUI<tsyssystemconfig>(staticValue, this);
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

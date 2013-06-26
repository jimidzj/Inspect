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
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;

namespace GENLSYS.MES.Win.SYS.StaticValue
{
    public partial class frmStaticValueEdit : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;

        #region Construct
        public frmStaticValueEdit()
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

        private void frmStaticValueEdit_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            SetLayout();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                DoShowSingleObject<tsysstaticvalue>(PrimaryKeys);
            }
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();            
        }

        private void SetCombobox()
        {
            #region Container Type
            DropDown.InitCMB_Enums(this.cmbFlag, typeof(Public_ActiveFlag));
            DropDown.InitCMB_Enums(this.cmbType, typeof(Public_StaticValueType));
            #endregion
        }

        public void DoSaveSingleObject()
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                baseForm.ValidateData(this);
                tsysstaticvalue staticValue = new tsysstaticvalue();

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    staticValue.svid = Function.GetGUID();
                }
                else
                {
                    staticValue = baseForm.OriginalObject as tsysstaticvalue;
                }

                baseForm.CreateSingleObject<tsysstaticvalue>(staticValue, this, UpdateMode);


                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.DoInsertStaticValue(baseForm.CurrentContextInfo, staticValue);
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.DoUpdateStaticValue(baseForm.CurrentContextInfo, staticValue);
                }

                Parameter.CURRENT_STATIC_VALUE = baseForm.GetAllStaticValue();

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
                tsysstaticvalue staticValue = client.GetSingleStaticValue(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                baseForm.OriginalObject = staticValue;
                baseForm.ShowSingleObjectToUI<tsysstaticvalue>(staticValue, this);
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

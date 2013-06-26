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
using GENLSYS.MES.Utility;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Win.Common.Classes;

namespace GENLSYS.MES.Win.SEC.Function
{
    public partial class frmFunctionsEdit : Form
    {
        public string FuncId { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode { get; set; }

        #region Construct
        public frmFunctionsEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Event
        private void frmFunctionsEdit_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            if (FuncId != null)
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
                tsecfunctions functions = GetSingleFunctions(FuncId);
                baseForm.OriginalObject = functions;
                baseForm.ShowSingleObjectToUI<tsecfunctions>(functions, this);
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

        #region Mothed
        private void SetLayout()
        {
            SetCombobox();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                this.txtFuncId.Enabled = false;
            }
        }

        private void SetCombobox()
        {
            DropDown.InitCMB_Enums(this.cmbFuncType, typeof(MES_FuncType));
            baseForm.SetUltraComboResource(this.ucmbParentFuncId, "Label.R00143|Label.R00145");
            this.ucmbParentFuncId.DisplayMember = "FUNCID";
            this.ucmbParentFuncId.ValueMember = "FUNCID";            
            this.ucmbParentFuncId.SetDataBinding(GetAllFunctions(),"",true);
        }
        private tsecfunctions GetSingleFunctions(string _funcId)
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            tsecfunctions result = null;
            try
            {
                baseForm.SetCursor();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "funcid",
                    ParamValue = _funcId,
                    ParamType = "string"
                });
                result = client.GetSingleFunctions(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
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

        public DataTable GetAllFunctions()
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            try
            {
                baseForm.SetCursor();
                DataSet ds = client.GetFunctionsRecords(baseForm.CurrentContextInfo, (new List<MESParameterInfo>()).ToArray<MESParameterInfo>());
                return ds.Tables[0];
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


        private void DoSave()
        {
            try
            {
                baseForm.SetCursor();
                baseForm.ValidateData(this);

                tsecfunctions functions = new tsecfunctions();
                if (UpdateMode == Public_UpdateMode.Update)
                {
                    functions = baseForm.OriginalObject as tsecfunctions;
                }
                baseForm.CreateSingleObject<tsecfunctions>(functions, this, UpdateMode);



                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    InsertFunctions(functions);
                }
                else
                {
                    UpdateFunctions(functions);
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


        private void InsertFunctions(tsecfunctions _functions)
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            try
            {
                client.DoInsertFunctions(baseForm.CurrentContextInfo, _functions);
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

        private void UpdateFunctions(tsecfunctions _functions)
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            try
            {
                client.DoUpdateFunctions(baseForm.CurrentContextInfo, _functions);
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

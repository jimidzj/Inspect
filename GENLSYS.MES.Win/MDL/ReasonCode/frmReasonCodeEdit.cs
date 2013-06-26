using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Common;
using GENLSYS.MES.Win.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;
using Infragistics.Win.UltraWinGrid;

namespace GENLSYS.MES.Win.MDL.ReasonCode
{
    public partial class frmReasonCodeEdit : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;

        #region Construct
        public frmReasonCodeEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            
            this.ucAttribute.CurrentContextInfo = baseForm.CurrentContextInfo;

            //baseForm.CreateUltraGridColumns(this.grdStep, new string[] { "custfield1", "stepsysid", "stepid", "stepversion", "stepname", "stepdesc" });

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

        private void frmReasonCodeEdit_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            //baseForm.SetQueryGridStyle(this.grdStep);
            SetLayout();

            this.ucAttribute.AllowToUpdate = true;
            if (UpdateMode == Public_UpdateMode.Update)
            {
                DoShowSingleObject<tmdlreasoncategory>(PrimaryKeys);
            }
            else
            {
                //GetReasonCodeStep(MES_DummyData.Dummy_Data_XXX_111.ToString());

                this.ucAttribute.UpdateMode = GENLSYS.MES.Common.Public_UpdateMode.Insert;
                this.ucAttribute.WhereUsed = GENLSYS.MES.Common.MES_AttributeTemplate_UsedBy.ReasonCode;
                this.ucAttribute.AttributeTemplateID = string.Empty;
                this.ucAttribute.DoShow();
            }
        }

        private void cmbReasonCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueInfo v = (this.cmbReasonCategory.SelectedItem as ValueInfo);
            if (v == null) return;
            tmdlreasoncategory category = GetReasonCategoryObject(v.ValueField);

            if (category.attrtplatid != null)
            {
                tsysattrtplate template = baseForm.GetAttributeTemplateObject(category.attrtplatid);
                if (template != null)
                {
                    baseForm.ShowAttributeDetail(this.ucAttribute,MES_AttributeTemplate_UsedBy.ReasonCode, template.attrtplatid);
                }
                else
                {
                    //show default template
                    baseForm.ShowAttributeDetail(this.ucAttribute, MES_AttributeTemplate_UsedBy.ReasonCode, "*");
                }
            }
            else
            {
                //show default template
                baseForm.ShowAttributeDetail(this.ucAttribute, MES_AttributeTemplate_UsedBy.ReasonCode, "*");
            }
        }

        private void grdStep_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            /*this.grdStep.DisplayLayout.Bands[0].Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.grdStep.DisplayLayout.Bands[0].Columns["stepsysid"].Hidden = true;

            this.grdStep.DisplayLayout.Bands[0].Columns["custfield1"].CellActivation = Activation.AllowEdit;
            this.grdStep.DisplayLayout.Bands[0].Columns["custfield1"].CellClickAction = CellClickAction.Edit;
            this.grdStep.DisplayLayout.Bands[0].Columns["custfield1"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            this.grdStep.DisplayLayout.Bands[0].Columns["custfield1"].Editor.DataFilter = new CheckEditorStringDataFilter();
            */
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();

            if (UpdateMode == GENLSYS.MES.Common.Public_UpdateMode.Update)
            {
                this.txtReasonCode.Enabled = false;
            }
        }

        private void SetCombobox()
        {
            #region Container Type
            DropDown.InitCMB_ReasonCategory_All(this.cmbReasonCategory);
            #endregion
        }

        public void DoSaveSingleObject()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                baseForm.SetCursor();

                baseForm.ValidateData(this);
                tmdlreasoncode reasoncode = new tmdlreasoncode();

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                }
                else
                {
                    reasoncode = baseForm.OriginalObject as tmdlreasoncode;
                }

                baseForm.CreateSingleObject<tmdlreasoncode>(reasoncode, this, UpdateMode);
                
                reasoncode.attributeid = Function.GetGUID();

                #region prepare attribute
                this.ucAttribute.AttributeID = reasoncode.attributeid;
                List<tsysattributevalue> lstAttribute = this.ucAttribute.GenerateAttributeList();

                if (lstAttribute.Count == 0)
                    reasoncode.attributeid = string.Empty;
                #endregion

                #region Step
                List<tmdlreasoncodestep> lstReasonCodeStep = new List<tmdlreasoncodestep>();
                /*for (int i = 0; i < this.grdStep.Rows.Count; i++)
                {
                    if (this.grdStep.Rows[i].Cells["custfield1"].Value.ToString() == MES_Misc.Y.ToString())
                    {
                        tmdlreasoncodestep step = new tmdlreasoncodestep();
                        step.reasoncode = this.txtReasonCode.Text;
                        step.stepsysid = this.grdStep.Rows[i].Cells["stepsysid"].Value.ToString();
                        step.lastmodifiedtime = DateTime.Now;
                        step.lastmodifieduser = Function.GetCurrentUser();

                        lstReasonCodeStep.Add(step);
                    }
                }*/
                #endregion

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.DoInsertReasonCode(baseForm.CurrentContextInfo, 
                        reasoncode,lstReasonCodeStep.ToArray<tmdlreasoncodestep>(), 
                        lstAttribute.ToArray<tsysattributevalue>());
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.DoUpdateReasonCode(baseForm.CurrentContextInfo,
                        reasoncode, lstReasonCodeStep.ToArray<tmdlreasoncodestep>(), 
                        lstAttribute.ToArray<tsysattributevalue>());
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
                tmdlreasoncode reasoncode = client.GetSingleReasonCode(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                baseForm.OriginalObject = reasoncode;
                baseForm.ShowSingleObjectToUI<tmdlreasoncode>(reasoncode, this);

                #region show attribute
                if (reasoncode.attributeid != null)
                {
                    this.ucAttribute.AttributeID = reasoncode.attributeid;
                }
                else
                {
                    tmdlreasoncategory category = GetReasonCategoryObject(reasoncode.reasoncategory);

                    this.ucAttribute.UpdateMode = GENLSYS.MES.Common.Public_UpdateMode.Insert;
                    this.ucAttribute.WhereUsed = GENLSYS.MES.Common.MES_AttributeTemplate_UsedBy.ReasonCode;
                    this.ucAttribute.AttributeTemplateID = category.attrtplatid;
                }

                this.ucAttribute.DoShow();

                //GetReasonCodeStep(reasoncode.reasoncode);
                #endregion
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

        private tmdlreasoncategory GetReasonCategoryObject(string reasonCategory)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                baseForm.SetCursor();

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                    new MESParameterInfo(){
                        ParamName="reasoncategory",
                        ParamValue=reasonCategory,
                        ParamType="string"
                    }
                };

                tmdlreasoncategory rc = client.GetSingleReasonCategory(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                return rc;
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

        private void GetReasonCodeStep(string reasonCode)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetReasonCodeStep(baseForm.CurrentContextInfo, reasonCode);

                //this.grdStep.SetDataBinding(ds.Tables[0], string.Empty);
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
        #endregion
    }
}

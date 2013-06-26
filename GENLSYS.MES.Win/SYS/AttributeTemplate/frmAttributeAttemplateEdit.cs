using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;
using Infragistics.Win.UltraWinGrid;

namespace GENLSYS.MES.Win.SYS.AttributeTemplate
{
    public partial class frmAttributeAttemplateEdit : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;

        public frmAttributeAttemplateEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdAttribute, new string[] { "seqno","attributename","attributetype","valuetype","defaultvalue" });
        }

        #region events
        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSaveSingleObject();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAttributeAttemplateEdit_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdAttribute);
            this.grdAttribute.DisplayLayout.Bands[0].Columns["defaultvalue"].Hidden = true;

            SetLayout();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                DoShowSingleObject<tsysattrtplate>(PrimaryKeys,false);
            }
            else
            {
                List<MESParameterInfo> lstPrameters = new List<MESParameterInfo>();
                lstPrameters.Add(new MESParameterInfo()
                {
                    ParamName = "attrtplatid",
                    ParamType= "string",
                    ParamValue = MES_DummyData.Dummy_Data_XXX_111.ToString()
                });
                DoShowSingleObject<tsysattrtplate>(lstPrameters, true);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = this.grdAttribute.DataSource as DataTable;
            DataRow dr = dt.NewRow();

            //attributename,attributetype,valuetype,attributevalue,seqno,lu,lt
            dr.ItemArray = new object[]{
                string.Empty,
                MES_AttributeTemplate_AttributeType.User.ToString(),
                MES_AttributeTemplate_ValueType.String.ToString(),
                string.Empty,
                this.grdAttribute.Rows.Count + 1,
                string.Empty,
                DateTime.Now
            };

            dt.Rows.Add(dr);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.grdAttribute.Selected.Rows.Count < 1) return;

            for (int i = this.grdAttribute.Selected.Rows.Count - 1; i >= 0; i--)
            {
                this.grdAttribute.Rows[this.grdAttribute.Selected.Rows[i].Index].Delete();
            }
        }

        private void grdAttribute_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdAttribute.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;

            this.grdAttribute.DisplayLayout.Bands[0].Columns["attributename"].CellActivation = Activation.AllowEdit;
            this.grdAttribute.DisplayLayout.Bands[0].Columns["attributename"].CellClickAction = CellClickAction.Edit;
            
            //set attribute type
            if (!this.grdAttribute.DisplayLayout.ValueLists.Exists("valuelist"))
            {
                this.grdAttribute.DisplayLayout.ValueLists.Add("valuelist");
                this.grdAttribute.DisplayLayout.ValueLists["valuelist"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.AttributeTemplateAttributeType));
                this.grdAttribute.DisplayLayout.Bands[0].Columns["attributetype"].CellActivation = Activation.AllowEdit;
                this.grdAttribute.DisplayLayout.Bands[0].Columns["attributetype"].CellClickAction = CellClickAction.Edit;
                this.grdAttribute.DisplayLayout.Bands[0].Columns["attributetype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdAttribute.DisplayLayout.Bands[0].Columns["attributetype"].ValueList = this.grdAttribute.DisplayLayout.ValueLists["valuelist"];
            }

            //set attribute type
            if (!this.grdAttribute.DisplayLayout.ValueLists.Exists("valuelist1"))
            {
                this.grdAttribute.DisplayLayout.ValueLists.Add("valuelist1");
                this.grdAttribute.DisplayLayout.ValueLists["valuelist1"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.AttributeTemplateValueType));
                this.grdAttribute.DisplayLayout.Bands[0].Columns["valuetype"].CellActivation = Activation.AllowEdit;
                this.grdAttribute.DisplayLayout.Bands[0].Columns["valuetype"].CellClickAction = CellClickAction.Edit;
                this.grdAttribute.DisplayLayout.Bands[0].Columns["valuetype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdAttribute.DisplayLayout.Bands[0].Columns["valuetype"].ValueList = this.grdAttribute.DisplayLayout.ValueLists["valuelist1"];
            }
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();

            if (UpdateMode == GENLSYS.MES.Common.Public_UpdateMode.Update)
            {
                this.txtTemplateId.Enabled = false;
                this.cmbUsedBy.Enabled = false;
            }

        }

        private void SetCombobox()
        {
            #region Used By
            DropDown.InitCMB_StaticValue(this.cmbUsedBy, MES_StaticValue_Type.AttributeTemplateUsedBy);
            #endregion
        }

        public void DoSaveSingleObject()
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();

            try
            {
                baseForm.SetCursor();

                baseForm.ValidateData(this);
                tsysattrtplate template = new tsysattrtplate();

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    //template.attrtplatid = Function.GetGUID();
                    //template.attrtplatname = template.attrtplatid;
                    //////template.seqno = client.GetMaxSeqno((cmbUsedBy.SelectedItem as ValueInfo).ValueField) + 1;
                }
                else
                {
                    template = baseForm.OriginalObject as tsysattrtplate;
                }

                baseForm.CreateSingleObject<tsysattrtplate>(template, this, UpdateMode);
                
                //Create Attributes
                List<tsysattrtplatedtl> lstAttributes = new List<tsysattrtplatedtl>();
                for (int i = 0; i < grdAttribute.Rows.Count; i++)
                {
                    tsysattrtplatedtl attribute = new tsysattrtplatedtl();
                    
                    attribute.attrtplatid = this.txtTemplateId.Text;
                    attribute.attributename = this.grdAttribute.Rows[i].Cells["attributename"].Value.ToString();
                    attribute.attributetype = this.grdAttribute.Rows[i].Cells["attributetype"].Value.ToString();
                    //if (this.grdAttribute.Rows[i].Cells["defaultvalue"].Value == null)
                    //{
                    //    attribute.defaultvalue = string.Empty;
                    //}
                    //else
                    //{
                    //    attribute.defaultvalue = this.grdAttribute.Rows[i].Cells["defaultvalue"].Value.ToString();
                    //}

                    attribute.optionalvalue = string.Empty;
                    attribute.seqno = Int16.Parse(this.grdAttribute.Rows[i].Cells["seqno"].Value.ToString());
                    attribute.valuetype = this.grdAttribute.Rows[i].Cells["valuetype"].Value.ToString();
                    attribute.lastmodifiedtime = template.lastmodifiedtime;
                    attribute.lastmodifieduser = template.lastmodifieduser;

                    lstAttributes.Add(attribute);
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.InsertAttributeTemplate(baseForm.CurrentContextInfo, template, lstAttributes.ToArray<tsysattrtplatedtl>());
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.UpdateAttributeTemplate(baseForm.CurrentContextInfo, template, lstAttributes.ToArray<tsysattrtplatedtl>());
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

        public void DoShowSingleObject<T>(List<MESParameterInfo> lstParameters,bool isOnlyShowDetail)
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();

            try
            {
                if (!isOnlyShowDetail)
                {
                    tsysattrtplate template = client.GetSingleAttributeTemplate(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                    baseForm.OriginalObject = template;
                    baseForm.ShowSingleObjectToUI<tsysattrtplate>(template, this);
                }

                //show attributes
                DataSet ds = client.GetAttributeTemplateDetailRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                this.grdAttribute.SetDataBinding(ds.Tables[0], "");
                

            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
            finally
            {
                baseForm.CloseWCF(client);
            }

        }
        #endregion

       
    }
}

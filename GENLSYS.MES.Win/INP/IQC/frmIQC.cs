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
using Infragistics.Win.UltraWinGrid;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.INP.IQC
{
    public partial class frmIQC : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;
        private tinpiqc OriginalIQC;
        private string PrevStyleNo = string.Empty;

        #region Construct
        public frmIQC()
        {
            InitializeComponent();
            baseForm = new BaseForm();

            baseForm.CreateUltraGridColumns(this.grdFail, new string[] { 
            "reasoncategory","selected","reasoncode","reasoncomment","reasoncodeid"});

            baseForm.CreateUltraGridColumns(this.grdReturn, new string[] { 
            "selected","custorderno","cartonno","styleno","color","size","pairqty"});
        }
        #endregion

        #region Events
        private void frmIQC_Load(object sender, EventArgs e)
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 50;
            this.Left = 10;
            this.Top = 10;

            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdFail);
            baseForm.SetQueryGridStyle(this.grdReturn);
            SetLayout();
            this.grdReturn.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;

            if (UpdateMode == Public_UpdateMode.Update)
            {
                //this.txtStyleNo.Enabled = false;
                baseForm.SetControlReadOnly(this.txtStyleNo,true);
                this.cboCustomer.Enabled = false;
                DoShowSingleObject<tinpiqc>(PrimaryKeys);
            }
            else
            {
                DoShowEmptyData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DoSaveSingleObject();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void grdDetail_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdFail.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.grdFail.DisplayLayout.Override.CellClickAction = CellClickAction.Edit;
            
            this.grdFail.DisplayLayout.Bands[0].Columns["reasoncategory"].MergedCellStyle = MergedCellStyle.Always;
            this.grdFail.DisplayLayout.Bands[0].Columns["reasoncategory"].Width = 50;

            this.grdFail.DisplayLayout.Bands[0].Columns["selected"].CellActivation = Activation.AllowEdit;
            this.grdFail.DisplayLayout.Bands[0].Columns["selected"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            this.grdFail.DisplayLayout.Bands[0].Columns["selected"].Editor.DataFilter = new CheckEditorStringDataFilter();
            this.grdFail.DisplayLayout.Bands[0].Columns["selected"].Width = 50;
            this.grdFail.DisplayLayout.Bands[0].Columns["selected"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
            this.grdFail.DisplayLayout.Bands[0].Columns["selected"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Left;

            this.grdFail.DisplayLayout.Bands[0].Columns["reasoncode"].Width = 150;

            this.grdFail.DisplayLayout.Bands[0].Columns["reasoncomment"].CellActivation = Activation.AllowEdit;

            this.grdFail.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;

            this.grdFail.DisplayLayout.Bands[0].Columns["reasoncodeid"].Hidden = true;
        }

        private void grdReturn_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.grdReturn.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.grdReturn.DisplayLayout.Override.CellClickAction = CellClickAction.Edit;
            //set shoe color
            if (!this.grdReturn.DisplayLayout.ValueLists.Exists("vlcolor"))
            {
                this.grdReturn.DisplayLayout.ValueLists.Add("vlcolor");
                this.grdReturn.DisplayLayout.ValueLists["vlcolor"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.ShoeColor));
                this.grdReturn.DisplayLayout.Bands[0].Columns["color"].CellActivation = Activation.AllowEdit;
                this.grdReturn.DisplayLayout.Bands[0].Columns["color"].CellClickAction = CellClickAction.Edit;
                this.grdReturn.DisplayLayout.Bands[0].Columns["color"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdReturn.DisplayLayout.Bands[0].Columns["color"].ValueList = this.grdReturn.DisplayLayout.ValueLists["vlcolor"];
            }

            //set shoe size
            if (!this.grdReturn.DisplayLayout.ValueLists.Exists("vlsize"))
            {
                this.grdReturn.DisplayLayout.ValueLists.Add("vlsize");
                this.grdReturn.DisplayLayout.ValueLists["vlsize"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.ShoeSize));
                this.grdReturn.DisplayLayout.Bands[0].Columns["size"].CellActivation = Activation.AllowEdit;
                this.grdReturn.DisplayLayout.Bands[0].Columns["size"].CellClickAction = CellClickAction.Edit;
                this.grdReturn.DisplayLayout.Bands[0].Columns["size"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdReturn.DisplayLayout.Bands[0].Columns["size"].ValueList = this.grdReturn.DisplayLayout.ValueLists["vlsize"];
            }
           
            this.grdReturn.DisplayLayout.Bands[0].Columns["selected"].CellActivation = Activation.AllowEdit;
            this.grdReturn.DisplayLayout.Bands[0].Columns["selected"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            this.grdReturn.DisplayLayout.Bands[0].Columns["selected"].Editor.DataFilter = new CheckEditorStringDataFilter();
            this.grdReturn.DisplayLayout.Bands[0].Columns["selected"].Editor.ValueChanged += new EventHandler(ReturnCheckBox_Changed);
            this.grdReturn.DisplayLayout.Bands[0].Columns["selected"].Width = 50;
            this.grdReturn.DisplayLayout.Bands[0].Columns["selected"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
            this.grdReturn.DisplayLayout.Bands[0].Columns["selected"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Left;

        }

        private void ReturnCheckBox_Changed(object sender, EventArgs e)
        {
            if (this.grdReturn.ActiveCell.Column.Key != "selected") return;

            if (this.grdReturn.ActiveCell.Column.Editor.Value.ToString() == MES_Misc.Y.ToString())
            {
                this.nudReturnCTQty.Value++;
            }
            else
            {
                this.nudReturnCTQty.Value--;
            }
        }

        private void cboReturnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboReturnType.SelectedItem == null) return;

            if ((this.cboReturnType.SelectedItem as ValueInfo).ValueField.ToString().ToUpper() == "NOT")
                this.grdReturn.Enabled = false;
            else
                this.grdReturn.Enabled = true;
        }

        private void txtStyleNo_Leave(object sender, EventArgs e)
        {
            if (PrevStyleNo != this.txtStyleNo.Text.Trim())
            {
                ShowCartonInfo();
                PrevStyleNo = this.txtStyleNo.Text.Trim();
            }
            if (!this.txtStyleNo.Text.Trim().Equals("") && this.cboCustomer.SelectedItem!=null)
            {
                DataTable dt = GetIQCByCustomerAndStyleNo(((ValueInfo)this.cboCustomer.SelectedItem).DisplayField,this.txtStyleNo.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    var q = from p in dt.AsEnumerable()
                            orderby p["lastmodifiedtime"] descending
                            select p;
                    foreach (DataRow row in q)
                    {
                        this.nudBootHeight.Value = Convert.ToDecimal(row["bootheight"]);
                        DropDown.SelectCMBValue(this.cboCategory, row["category"].ToString());
                        break;
                    }
                }
            }
        }
        #endregion

        
        #region Methods
        private void SetLayout()
        {
            SetCombobox();
            this.dtIQCDate.Value = Function.GetCurrentTime();
            if (UpdateMode == Public_UpdateMode.Update)
            {
            }
        }

        private void SetCombobox()
        {
            DropDown.InitCMB_Customer_All(this.cboCustomer);
            DropDown.InitCMB_StaticValue(this.cboCheckResult, MES_StaticValue_Type.QCCheckResult);
            DropDown.InitCMB_StaticValue(this.cboCheckType, MES_StaticValue_Type.QCCheckType);
            DropDown.InitCMB_StaticValue(this.cboReturnType, MES_StaticValue_Type.QCReturnType);
            DropDown.InitCMB_StaticValue(this.cboCategory, MES_StaticValue_Type.ShoeCategory);
        }

        public void DoShowSingleObject<T>(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                #region Show to UI
                tinpiqc iqc = client.GetSingleIQC(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                OriginalIQC = iqc;
                baseForm.ShowSingleObjectToUI<tinpiqc>(iqc, this);
                #endregion

                #region Show work order detail
                List<MESParameterInfo> lstParameter = new List<MESParameterInfo>()
                {
                    new MESParameterInfo()
                    {
                        ParamName="iqcsysid",
                        ParamValue=iqc.iqcsysid,
                        ParamType="string"
                    }
                };

                DataSet ds = client.GetIQCFail(baseForm.CurrentContextInfo, iqc.iqcsysid);
                this.grdFail.DataSource = ds.Tables[0];

                DataSet ds1 = client.GetIQCReturn(baseForm.CurrentContextInfo, iqc.iqcsysid,iqc.styleno);
                this.grdReturn.DataSource = ds1.Tables[0];
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

        public void DoShowEmptyData()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetIQCFail(baseForm.CurrentContextInfo, MES_DummyData.Dummy_Data_XXX_111.ToString());
                this.grdFail.DataSource = ds.Tables[0];
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

        public void ShowCartonInfo()
        {
            if (this.txtStyleNo.Text.Trim() == string.Empty) return;

            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();
                string iqcsysid = UpdateMode == Public_UpdateMode.Insert ? string.Empty : OriginalIQC.iqcsysid;

                DataSet ds = client.GetIQCReturn(baseForm.CurrentContextInfo, iqcsysid, this.txtStyleNo.Text.Trim());
                this.grdReturn.DataSource = ds.Tables[0];
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

        private DataTable GetIQCByCustomerAndStyleNo(string customerid, string styleno)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="customerid",ParamValue=customerid},
                            new MESParameterInfo(){ParamName="styleno",ParamValue=styleno}
                        };
                dt = client.GetIQCRecords(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return dt;
        }
        public void DoSaveSingleObject()
        {

            wsINP.IwsINPClient client = new wsINP.IwsINPClient();

            try
            {
                baseForm.SetCursor();

                #region Validate & build object from UI
                baseForm.ValidateData(this);

                //if (!CheckBeforeSave()) return;

                tinpiqc iqc = new tinpiqc();

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    iqc = OriginalIQC;
                }

                //Build Product Ext Object
                baseForm.CreateSingleObject<tinpiqc>(iqc, this, UpdateMode);

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    iqc.iqcsysid = Function.GetGUID();
                }

                iqc.lastmodifiedtime = Function.GetCurrentTime();
                iqc.lastmodifieduser = Function.GetCurrentUser();

                #endregion

                #region Prepare IQC Fail
                List<tinpiqcfail> lstFail = new List<tinpiqcfail>();
                for (int i = 0; i < grdFail.Rows.Count; i++)
                {
                    if (this.grdFail.Rows[i].Cells["selected"].Value.ToString() == MES_Misc.Y.ToString())
                    {
                        tinpiqcfail fail = new tinpiqcfail();

                        fail.iqcsysid = iqc.iqcsysid;
                        fail.reasoncode = this.grdFail.Rows[i].Cells["reasoncodeid"].Value.ToString();
                        fail.reasoncomment = this.grdFail.Rows[i].Cells["reasoncomment"].Value.ToString();

                        baseForm.PrepareObject<tinpiqcfail>(fail, Public_UpdateMode.Insert);
                        lstFail.Add(fail);
                    }
                }
                #endregion

                #region Prepare IQC Return
                List<tinpiqcreturn> lstReturn = new List<tinpiqcreturn>();
                for (int i = 0; i < grdReturn.Rows.Count; i++)
                {
                    if (this.grdReturn.Rows[i].Cells["selected"].Value.ToString() == MES_Misc.Y.ToString())
                    {
                        tinpiqcreturn iqcreturn = new tinpiqcreturn();
                        iqcreturn.cartonno = this.grdReturn.Rows[i].Cells["cartonno"].Value.ToString();
                        iqcreturn.custorderno= this.grdReturn.Rows[i].Cells["custorderno"].Value.ToString();
                        iqcreturn.iqcsysid=iqc.iqcsysid;
                        iqcreturn.pairqty= Decimal.Parse(this.grdReturn.Rows[i].Cells["pairqty"].Value.ToString());

                        baseForm.PrepareObject<tinpiqcreturn>(iqcreturn, Public_UpdateMode.Insert);
                        lstReturn.Add(iqcreturn);
                    }
                }
                iqc.returncartonqty = lstReturn.Count;
                #endregion

                #region call WCF

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    client.DoInsertIQC(baseForm.CurrentContextInfo, iqc,
                        lstFail.ToArray<tinpiqcfail>(),lstReturn.ToArray<tinpiqcreturn>());
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    client.DoUpdateIQC(baseForm.CurrentContextInfo, iqc,
                        lstFail.ToArray<tinpiqcfail>(),lstReturn.ToArray<tinpiqcreturn>());
                }
                #endregion

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
        #endregion

    }
}

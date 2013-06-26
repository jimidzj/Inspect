using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.INP.IQC
{
    public partial class frmIQCList : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmIQCList()
        {
            InitializeComponent();

            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();

            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { 
                "iqcsysid","customername","factory","styleno","bootheight","checkrequest","checktype",
                "checkresult","returntype","returncartonqty","iqcdate","remark",
                "createdtime","createduser","lastmodifiedtime","lastmodifieduser" });
        }
        #endregion

        #region Events
        private void ucToolbar1_DeleteEventHandler(object sender, EventArgs e)
        {
            DoDelete();
        }

        private void ucToolbar1_EditEventHandler(object sender, EventArgs e)
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
            lstParameters.Add(new MESParameterInfo()
            {
                ParamName = "iqcsysid",
                ParamValue = this.grdQuery.ActiveRow.Cells["iqcsysid"].Value.ToString(),
                ParamType = "string"
            });

            frmIQC f = new frmIQC();
            f.UpdateMode = GENLSYS.MES.Common.Public_UpdateMode.Update;
            f.PrimaryKeys = lstParameters;
            f.ShowDialog();
            GetData(QueryParameters);
        }

        private void ucToolbar1_ExitEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucToolbar1_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.grdQuery);
        }

        private void ucToolbar1_NewEventHandler(object sender, EventArgs e)
        {
            frmIQC f = new frmIQC();
            f.UpdateMode = GENLSYS.MES.Common.Public_UpdateMode.Insert;
            f.ShowDialog();
            GetData(QueryParameters);
        }

        private void ucToolbar1_QueryEventHandler(object sender, EventArgs e)
        {
            if (pQuery.Visible == false)
                pQuery.Visible = true;
            else
                pQuery.Visible = false;
        }

        private void frmIQCList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            SetLayout();

            GetData(new List<MESParameterInfo>() {
                new MESParameterInfo(){ParamName="iqcsysid",ParamValue=MES_DummyData.Dummy_Data_XXX_111.ToString()}
            });

            this.grdQuery.DisplayLayout.Bands[0].Columns["iqcsysid"].Hidden = true;
            this.pQuery.BackColor = Color.FromName("Info");
        }

        private void grdQuery_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.grdQuery.ActiveRow != null)
            {
                this.ucToolbar1.SetToolbarWithSelection();
            }
            else
            {
                this.ucToolbar1.SetToolbarWithoutSelection();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery);
            QueryParameters = lstParameters;
            GetData(lstParameters);
        }

        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            if (!this.grdQuery.DisplayLayout.ValueLists.Exists("vlchecktype"))
            {
                this.grdQuery.DisplayLayout.ValueLists.Add("vlchecktype");
                this.grdQuery.DisplayLayout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.QCCheckType));
                this.grdQuery.DisplayLayout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdQuery.DisplayLayout.Bands[0].Columns["checktype"].ValueList = this.grdQuery.DisplayLayout.ValueLists["vlchecktype"];
            }

            if (!this.grdQuery.DisplayLayout.ValueLists.Exists("vlcheckresult"))
            {
                this.grdQuery.DisplayLayout.ValueLists.Add("vlcheckresult");
                this.grdQuery.DisplayLayout.ValueLists["vlcheckresult"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.QCCheckResult));
                this.grdQuery.DisplayLayout.Bands[0].Columns["checkresult"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdQuery.DisplayLayout.Bands[0].Columns["checkresult"].ValueList = this.grdQuery.DisplayLayout.ValueLists["vlcheckresult"];
            }
            if (!this.grdQuery.DisplayLayout.ValueLists.Exists("vlreturnresult"))
            {
                this.grdQuery.DisplayLayout.ValueLists.Add("vlreturnresult");
                this.grdQuery.DisplayLayout.ValueLists["vlreturnresult"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.QCReturnType));
                this.grdQuery.DisplayLayout.Bands[0].Columns["returntype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdQuery.DisplayLayout.Bands[0].Columns["returntype"].ValueList = this.grdQuery.DisplayLayout.ValueLists["vlreturnresult"];
            }


            this.grdQuery.DisplayLayout.Bands[0].Columns["iqcdate"].Format = "yyyy-MM-dd";
            this.grdQuery.DisplayLayout.Bands[0].Columns["lastmodifiedtime"].Format = "yyyy-MM-dd HH:mm:ss";

            this.grdQuery.DisplayLayout.Bands[0].Columns["createdtime"].Format = "yyyy-MM-dd HH:mm:ss";
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();
        }

        private void SetCombobox()
        {
            DropDown.InitCMB_Customer_All(this.cboCustomer);
            DropDown.InitCMB_StaticValue(this.cboCheckType, MES_StaticValue_Type.QCCheckType);
        }

        private void GetData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetIQCRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                this.grdQuery.SetDataBinding(ds.Tables[0], "");

                if (this.grdQuery.Rows.Count < 1)
                {
                    this.ucToolbar1.SetToolbarWithoutRows();
                }
                else
                {
                    this.ucToolbar1.SetToolbarWithRows();
                }

                this.ucStatusBar1.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + ds.Tables[0].Rows.Count.ToString());
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

        public void DoDelete()
        {
            if (this.grdQuery.ActiveRow == null) return;

            DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                        MessageBoxButtons.OKCancel,
                        UtilCulture.GetString("Msg.R00004"),
                        "" + UtilCulture.GetString("Label.R01023") + ": " +
                            this.grdQuery.ActiveRow.Cells["iqcsysid"].Value.ToString());

            if (result == DialogResult.Cancel) return;

            wsINP.IwsINPClient client = new wsINP.IwsINPClient(); 
            try
            {
                baseForm.SetCursor();

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                    new MESParameterInfo(){
                        ParamName="iqcsysid",
                        ParamValue=this.grdQuery.ActiveRow.Cells["iqcsysid"].Value.ToString(),
                        ParamType="string"
                    }
                };

                client.DoDeleteIQC(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                MESMsgBox.ShowInformation(UtilCulture.GetString("Msg.R00003"));

                GetData(QueryParameters);
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

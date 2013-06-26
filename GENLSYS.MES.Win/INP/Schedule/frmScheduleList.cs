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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace GENLSYS.MES.Win.INP.Schedule
{
    public partial class frmScheduleList : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmScheduleList()
        {
            InitializeComponent();

            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { 
            "yearmonth","customerid","factory","fullcheckqty","xrayqty","ttlqty","remark","lastmodifiedtime","lastmodifieduser"            
            });
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
                ParamName = "yearmonth",
                ParamValue = this.grdQuery.ActiveRow.Cells["yearmonth"].Value.ToString(),
                ParamType = "string"
            });

            frmSchedule f = new frmSchedule();
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
            frmSchedule f = new frmSchedule();
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

        private void frmScheduleList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            SetLayout();

            GetData(new List<MESParameterInfo>() {
                new MESParameterInfo(){ParamName="yearmonth",ParamValue=MES_DummyData.Dummy_Data_XXX_111.ToString()}
            });

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
            //baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            string yearmonth=string.Empty;

            if (this.cboYear.Text != string.Empty)
            {
                yearmonth = this.cboYear.Text;

                if (this.cboMonth.Text != string.Empty)
                {
                    yearmonth += this.cboMonth.Text.PadLeft(2, '0');
                }

                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "yearmonth",
                    ParamValue = yearmonth
                });
            }

            if (this.cboCustomer.SelectedItem!=null)
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "customerid",
                    ParamValue = (this.cboCustomer.SelectedItem as ValueInfo).ValueField
                });

            GetData(lstParameters);
        }

        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            if (!this.grdQuery.DisplayLayout.ValueLists.Exists("vlcustomer"))
            {
                this.grdQuery.DisplayLayout.ValueLists.Add("vlcustomer");
                this.grdQuery.DisplayLayout.ValueLists["vlcustomer"].ValueListItems.AddRange(DropDown.GetValueList_Customer_All());
                this.grdQuery.DisplayLayout.Bands[0].Columns["customerid"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdQuery.DisplayLayout.Bands[0].Columns["customerid"].ValueList = this.grdQuery.DisplayLayout.ValueLists["vlcustomer"];
            }

            e.Layout.Override.SummaryDisplayArea =SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumFullcheckqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumFullcheckqty", SummaryType.Sum, e.Layout.Bands[0].Columns["fullcheckqty"], SummaryPosition.UseSummaryPositionColumn);
            }
            if (!e.Layout.Bands[0].Summaries.Exists("SumXrayqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumXrayqty", SummaryType.Sum, e.Layout.Bands[0].Columns["xrayqty"], SummaryPosition.UseSummaryPositionColumn);
            }
            if (!e.Layout.Bands[0].Summaries.Exists("SumTtlqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumTtlqty", SummaryType.Sum, e.Layout.Bands[0].Columns["ttlqty"], SummaryPosition.UseSummaryPositionColumn);
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
            DropDown.InitCMB_StaticValue(this.cboYear, MES_StaticValue_Type.Year);
            DropDown.InitCMB_StaticValue(this.cboMonth, MES_StaticValue_Type.Month);
            DropDown.InitCMB_Customer_All(this.cboCustomer);
        }

        private void GetData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetScheduleRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

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
                        "<span style='font-weight:bold;'>" + UtilCulture.GetString("Label.R01023") + ": </span> " +
                            this.grdQuery.ActiveRow.Cells["yearmonth"].Value.ToString() + "," +
                            this.grdQuery.ActiveRow.Cells["customerid"].Value.ToString() + "," +
                            this.grdQuery.ActiveRow.Cells["factory"].Value.ToString());

            if (result == DialogResult.Cancel) return;

            wsINP.IwsINPClient client = new wsINP.IwsINPClient(); 
            try
            {
                baseForm.SetCursor();

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                    new MESParameterInfo(){
                        ParamName="yearmonth",
                        ParamValue=this.grdQuery.ActiveRow.Cells["yearmonth"].Value.ToString(),
                        ParamType="string"
                    },
                    new MESParameterInfo(){
                        ParamName="customerid",
                        ParamValue=this.grdQuery.ActiveRow.Cells["customerid"].Value.ToString(),
                        ParamType="string"
                    },
                    new MESParameterInfo(){
                        ParamName="factory",
                        ParamValue=this.grdQuery.ActiveRow.Cells["factory"].Value.ToString(),
                        ParamType="string"
                    }
                };

                client.DoDeleteSchedule(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

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

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
using Infragistics.Win.UltraWinGrid;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.INP.Pricing
{
    public partial class frmPricingList : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmPricingList()
        {
            InitializeComponent();

            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdPricing, new string[] {
                "prisysid" ,"pridtlsysid","customername","reworkratio","category",
                "sbootheight","ebootheight","checktype","effectivedate","expireddate",
                "currency","price","unit","remark"});
        }
        #endregion

        #region Events
        private void frmPricingList_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdPricing);
            SetLayout();
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { 
                new MESParameterInfo(){ParamName="prisysid",ParamValue = MES_DummyData.Dummy_Data_XXX_111.ToString()}
            };
            GetData(lstParameters);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            GetData(lstParameters);
        }
       
        private void grdPricing_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {           
            //hide
            this.grdPricing.DisplayLayout.Bands[0].Columns["effectivedate"].Format = "yyyy-MM-dd";
            this.grdPricing.DisplayLayout.Bands[0].Columns["expireddate"].Format = "yyyy-MM-dd";

            this.grdPricing.DisplayLayout.Bands[0].Columns["prisysid"].Hidden = true;
            this.grdPricing.DisplayLayout.Bands[0].Columns["pridtlsysid"].Hidden = true;

            if (!this.grdPricing.DisplayLayout.ValueLists.Exists("vlchecktype"))
            {
                this.grdPricing.DisplayLayout.ValueLists.Add("vlchecktype");
                this.grdPricing.DisplayLayout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                this.grdPricing.DisplayLayout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdPricing.DisplayLayout.Bands[0].Columns["checktype"].ValueList = this.grdPricing.DisplayLayout.ValueLists["vlchecktype"];
            }

            if (!this.grdPricing.DisplayLayout.ValueLists.Exists("vlunit"))
            {
                this.grdPricing.DisplayLayout.ValueLists.Add("vlunit");
                this.grdPricing.DisplayLayout.ValueLists["vlunit"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.Unit));
                this.grdPricing.DisplayLayout.Bands[0].Columns["unit"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.grdPricing.DisplayLayout.Bands[0].Columns["unit"].ValueList = this.grdPricing.DisplayLayout.ValueLists["vlunit"];
            }
        }

        private void ucToolbar1_EditEventHandler(object sender, EventArgs e)
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
            lstParameters.Add(new MESParameterInfo()
            {
                ParamName = "prisysid",
                ParamValue = this.grdPricing.ActiveRow.Cells["prisysid"].Value.ToString(),
                ParamType = "string"
            });

            frmPricing f = new frmPricing();
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
            baseForm.ExportExcel(this.grdPricing);
        }

        private void ucToolbar1_NewEventHandler(object sender, EventArgs e)
        {
            frmPricing f = new frmPricing();
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

        private void grdPricing_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.grdPricing.ActiveRow != null)
            {
                this.ucToolbar1.SetToolbarWithSelection();
            }
            else
            {
                this.ucToolbar1.SetToolbarWithoutSelection();
            }
        }
        #endregion

        #region Methods
        private void GetData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetPricingRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                this.grdPricing.SetDataBinding(ds.Tables[0], "");

                if (ds.Tables[0].Rows.Count < 1)
                {
                    this.ucToolbar1.SetToolbarWithoutRows();
                }
                else
                {
                    this.ucToolbar1.SetToolbarWithRows();
                }
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

        private void SetLayout()
        {
            SetCombobox();

            this.ucToolbar1.SetDeleteVisible(false);
        }

        private void SetCombobox()
        {
            DropDown.InitCMB_Customer_All(this.cboCustomer);
            DropDown.InitCMB_StaticValue(this.cboCheckType, MES_StaticValue_Type.CheckType);
            DropDown.InitCMB_StaticValue(this.cboCategory, MES_StaticValue_Type.ShoeCategory);
        }
        #endregion

        
    }
}

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

namespace GENLSYS.MES.Win.INP.History
{
    public partial class frmCustOrderHistory : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;

        #region Construct
        public frmCustOrderHistory()
        {
            InitializeComponent();

            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();

            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] {
                "ohsysid","eventname","customerid","custorderno","styleno","color","size","cartonno",
                "cartonqty","pairqty","remark","refsysid","eventgroup","eventtime",
                "eventuser","workgroup","shift" });
        }
        #endregion

        #region Events
        private void ucToolbar1_ExitEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucToolbar1_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.grdQuery);
        }

        private void ucToolbar1_QueryEventHandler(object sender, EventArgs e)
        {
            if (pQuery.Visible == false)
                pQuery.Visible = true;
            else
                pQuery.Visible = false;
        }

        private void frmCustOrderHistory_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            SetLayout();

            GetData(new List<MESParameterInfo>() {
                new MESParameterInfo(){ParamName="ohsysid",ParamValue=MES_DummyData.Dummy_Data_XXX_111.ToString()}
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
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            GetData(lstParameters);
        }

        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdQuery.DisplayLayout.Bands[0].Columns["ohsysid"].Hidden = true;
            this.grdQuery.DisplayLayout.Bands[0].Columns["refsysid"].Hidden = true;
            this.grdQuery.DisplayLayout.Bands[0].Columns["eventgroup"].Hidden = true;

            this.grdQuery.DisplayLayout.Bands[0].Columns["eventtime"].Format = "yyyy-MM-dd HH:mm:ss";
        }
        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();

            this.ucToolbar1.SetDeleteVisible(false);
            this.ucToolbar1.SetEditVisible(false);
            this.ucToolbar1.SetNewVisible(false);
        }

        private void SetCombobox()
        {
            DropDown.InitCMB_Customer_All(this.cboCustomer);
        }

        private void GetData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetCustOrderHistoryRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

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
        #endregion

        
    }
}

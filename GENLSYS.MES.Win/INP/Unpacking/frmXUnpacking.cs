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
using GENLSYS.MES.Utility;
using GENLSYS.MES.Common;
using Infragistics.Win;

namespace GENLSYS.MES.Win.INP.Unpacking
{
    public partial class frmXUnpacking : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;
        //private string IsMDI = MES_Misc.N.ToString();
        private string[] subColumns = new string[] { "styleno", "color", "size", "pairqty" };

        #region Construct
        public frmXUnpacking()
        {
            InitializeComponent();
            //IsMDI = MES_Misc.N.ToString();
            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] {"customerid", "ck", "customername", "custorderno", "cartonno" ,"pairqty","workgroup"});
        }
        #endregion

        #region Event
        private void frmXUnpacking_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            this.grdQuery.DisplayLayout.Bands[0].Columns["customerid"].Hidden = true;

            this.ucToolbar1.SetSaveVisible(true);
            this.ucToolbar1.SetNewVisible(false);
            this.ucToolbar1.SetDeleteVisible(false);
            this.ucToolbar1.SetEditVisible(false);
            this.ucToolbar1.SetExportVisible(false);

            this.pQuery.BackColor = Color.FromName("Info");
        }
        private void ucToolbar1_QueryEventHandler(object sender, EventArgs e)
        {
            if (pQuery.Visible == false)
                pQuery.Visible = true;
            else
                pQuery.Visible = false;
        }

        private void ucToolbar1_SaveEventHandler(object sender, EventArgs e)
        {
            DoXUnpacking();
        }

        private void ucToolbar1_ExitEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.CellClickAction = CellClickAction.Edit;
            e.Layout.NewColumnLoadStyle = NewColumnLoadStyle.Show;
            e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;

            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();

            e.Layout.Bands[0].Columns["customerid"].Hidden = true;

            e.Layout.Bands[0].Columns["ck"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.HeaderCheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
            e.Layout.Override.HeaderCheckBoxAlignment = HeaderCheckBoxAlignment.Center;

            UltraGridColumn column = e.Layout.Bands[0].Columns["ck"];
            column.Header.Caption = "";
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            column.Editor.DataFilter = new CheckEditorStringDataFilter();
            column.Width = 40;

            if (!e.Layout.ValueLists.Exists("vlworkgroup"))
            {
                e.Layout.ValueLists.Add("vlworkgroup");
                e.Layout.ValueLists["vlworkgroup"].ValueListItems.AddRange(DropDown.GetValueList_DataTable(GetWorkGroupXStep().Tables[0], "workgroupdesc", "workgroup"));
                e.Layout.Bands[0].Columns["workgroup"].CellActivation = Activation.AllowEdit;
                e.Layout.Bands[0].Columns["workgroup"].CellClickAction = CellClickAction.Edit;
                e.Layout.Bands[0].Columns["workgroup"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["workgroup"].ValueList = e.Layout.ValueLists["vlworkgroup"];
            }

            if (e.Layout.Bands.Count > 1)
            {
                foreach (UltraGridColumn col in e.Layout.Bands[1].Columns)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    if (!subColumns.Contains(col.Key))
                    {
                        col.Hidden = true;
                    }
                }
                for (int i = 0; i < subColumns.Count(); i++)
                {
                    e.Layout.Bands[1].Columns[subColumns[i]].Header.VisiblePosition = i;
                }

                e.Layout.Bands[1].Columns["styleno"].Header.Caption = UtilCulture.GetString("Label.R01026");
                e.Layout.Bands[1].Columns["color"].Header.Caption = UtilCulture.GetString("Label.R01027");
                e.Layout.Bands[1].Columns["size"].Header.Caption = UtilCulture.GetString("Label.R01028");
                e.Layout.Bands[1].Columns["pairqty"].Header.Caption = UtilCulture.GetString("Label.R02026");
            }

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumCartonQty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumCartonQty", SummaryType.Count, e.Layout.Bands[0].Columns["cartonno"], SummaryPosition.UseSummaryPositionColumn);
            }
            if (!e.Layout.Bands[0].Summaries.Exists("SumPairqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[0].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
            }
        }
        private void grdQuery_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "workgroup")
            {
                foreach (UltraGridRow row in this.grdQuery.Rows)
                {
                    if (row.Cells["ck"].Value.ToString().Equals(MES_Misc.Y.ToString()) && row.Cells["workgroup"].Value.ToString().Equals(""))
                    {
                        row.Cells["workgroup"].Value = e.Cell.Value;
                    }
                }
            }
        }
        #endregion

        #region Methods
        private void DoXUnpacking()
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();
                grdQuery.UpdateData();
                List<string[]> lstunpacking = new List<string[]>();
                foreach (UltraGridRow row in this.grdQuery.Rows)
                {
                    if (row.Cells["ck"].Value.ToString().Equals(MES_Misc.Y.ToString()))
                    {
                        if (row.Cells["workgroup"].Value.ToString().Equals(""))
                        {
                            throw new Exception(UtilCulture.GetString("Msg.R01020", UtilCulture.GetString("Label.R01016")));
                        }
                        else
                        {
                            lstunpacking.Add(new string[] { row.Cells["customerid"].Value.ToString(), row.Cells["custorderno"].Value.ToString(), row.Cells["cartonno"].Value.ToString(), row.Cells["workgroup"].Value.ToString() });
                        }
                    }
                }
                if (lstunpacking.Count == 0)
                {
                    throw new Exception(UtilCulture.GetString("Msg.R01018"));
                }
                
                client.DoXUnpacking(baseForm.CurrentContextInfo,lstunpacking.ToArray());
                baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00028"));
                RefreshGrid();
            }
            catch (Exception ex)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, ex.Message);
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
        }

        private void RefreshGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue = "%" + param.ParamValue + "%";
            }
            lstParameters.Add(new MESParameterInfo()
            {
                ParamName = "cartonstatus",
                ParamValue = MES_CartonStatus.Active.ToString(),
                ParamType = "string"
            });
            lstParameters.Add(new MESParameterInfo()
            {
                ParamName = "cartonlocation",
                ParamValue = MES_CartonLocation.Warehouse.ToString(),
                ParamType = "string"
            });
            lstParameters.Add(new MESParameterInfo()
            {
                ParamName = "checktype",
                ParamValue = MES_WIPStatus.X.ToString(),
                ParamType = "string"
            });
            GetData(lstParameters);
        }
        private void GetData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = new DataSet();
                DataSet mainds = client.GetReceivingSumCtnDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataSet subds = client.GetReceivingCtnDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataTable maindt = mainds.Tables[0];
                DataTable subdt = subds.Tables[0];
                maindt.TableName = "Main";
                subdt.TableName = "Sub";
                mainds.Tables.Clear();
                subds.Tables.Clear();

                if (maindt != null)
                {
                    maindt.Columns.Add(new DataColumn("ck", typeof(string)));
                    maindt.Columns.Add(new DataColumn("workgroup", typeof(string)));
                    foreach (DataRow row in maindt.Rows)
                    {
                        row["ck"] = "N";
                        row["workgroup"] = "";                        
                    }
                    ds.Tables.Add(maindt);
                    ds.Tables.Add(subdt);
                    ds.Relations.Add("ps", new DataColumn[] { ds.Tables["Main"].Columns["customerid"], ds.Tables["Main"].Columns["custorderno"], ds.Tables["Main"].Columns["cartonno"] }, new DataColumn[] { ds.Tables["Sub"].Columns["customerid"], ds.Tables["Sub"].Columns["custorderno"], ds.Tables["Sub"].Columns["cartonno"] },false);
                    this.grdQuery.SetDataBinding(ds, "");
                }

                this.ucStatusBar1.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + maindt.Rows.Count.ToString());
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
        
        private DataSet GetWorkGroupXStep()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            DataSet ds = null;
            try
            {
                baseForm.SetCursor();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "step",
                    ParamValue = MES_WIPStatus.X.ToString(),
                    ParamType = "string"
                });
                ds = client.GetWorkGroupRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
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
            return ds;
        }
        #endregion

       

        

    }
}

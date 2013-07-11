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
using GENLSYS.MES.Utility;
using GENLSYS.MES.Common;
using Infragistics.Win.UltraWinGrid;
using GENLSYS.MES.Win.Report;
using GENLSYS.MES.Win.Common.Forms;
using Infragistics.Win;

namespace GENLSYS.MES.Win
{
    public partial class frmMain : Form
    {
        private BaseForm baseForm;
        private List<MESParameterInfo> QueryParameters = null;
        private string[] warehouseColumns = new string[] { "customerid", "customername", "custorderno", "cartonno", "pairqty", "checktype" };
        private string[] subWarehouseColumns = new string[] { "styleno", "color", "size", "pairqty" };
        private string[] unpackingColumns = new string[] { "customerid", "customername", "custorderno", "cartonno", "pairqty", "checktype" };
        private string[] subUnpackingColumns = new string[] { "styleno", "color", "size", "pairqty" };
        private string[] movingColumns = new string[] { "customerid", "customername", "custorderno", "cartonno", "pairqty", "checktype" };
        private string[] subMovingColumns = new string[] { "styleno", "color", "size", "pairqty" };
        private string[] packingColumns = new string[] { "customerid", "customername", "custorderno", "cartonno", "pairqty", "checktype" };
        private string[] subPackingColumns = new string[] { "styleno", "color", "size", "pairqty", "reqairqty" };
        private string[] unShippingColumns = new string[] { "customerid", "customername", "custorderno", "cartonno", "pairqty", "checktype" };
        private string[] subUnShippingColumns = new string[] { "styleno", "color", "size", "pairqty" };
        private string[] shippingColumns = new string[] { "customerid", "customername", "custorderno", "cartonno", "pairqty", "checktype" };
        private string[] subShippingColumns = new string[] { "styleno", "color", "size", "pairqty" };
        private string[] lineWarehouseColumns = new string[] { "customerid", "customername", "custorderno", "cartonno", "pairqty", "checktype" };
        private string[] subLineWarehouseColumns = new string[] { "styleno", "color", "size", "pairqty" };

        private string[] haveNotMovingColumns = new string[] { "customerid", "customername", "custorderno", "cartonno", "pairqty", "checktype" };
        private string[] subHaveNotMovingColumns = new string[] { "styleno", "color", "size", "pairqty" };

        private string[] haveNotPackingColumns = new string[] { "customerid", "customername", "custorderno", "cartonno", "pairqty", "checktype" };
        private string[] subHaveNotPackingColumns = new string[] { "styleno", "color", "size", "pairqty" };


        public frmMain()
        {
            InitializeComponent();

            QueryParameters = new List<MESParameterInfo>();
            baseForm = new BaseForm();
            DropDown.InitCMB_Customer_All_Name(this.cboCustomer);
            baseForm.CreateUltraGridColumns(this.grdQuery, new string[] { "customername", "custorderno", "styleno", "color", "size", "checktype", "pairqty", "status", "workgroup" });
            baseForm.CreateUltraGridColumns(this.grdWarehouse, warehouseColumns);
            baseForm.CreateUltraGridColumns(this.grdUnpacking, unpackingColumns);
            baseForm.CreateUltraGridColumns(this.grdMoving, unpackingColumns);
            baseForm.CreateUltraGridColumns(this.grdPacking, packingColumns);
            baseForm.CreateUltraGridColumns(this.grdUnshipping, unShippingColumns);
            baseForm.CreateUltraGridColumns(this.grdShipping, shippingColumns);
            baseForm.CreateUltraGridColumns(this.grdLineWarehouse, lineWarehouseColumns);
            baseForm.CreateUltraGridColumns(this.grdHaveNotMoving, haveNotMovingColumns);
            baseForm.CreateUltraGridColumns(this.grdHaveNotPacking, haveNotPackingColumns);
        }
        #region Event
        private void frmMain_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            baseForm.SetQueryGridStyle(this.grdQuery);
            baseForm.SetQueryGridStyle(this.grdWarehouse);
            baseForm.SetQueryGridStyle(this.grdUnpacking);
            baseForm.SetQueryGridStyle(this.grdMoving);
            baseForm.SetQueryGridStyle(this.grdPacking);
            baseForm.SetQueryGridStyle(this.grdUnshipping);
            baseForm.SetQueryGridStyle(this.grdShipping);
            baseForm.SetQueryGridStyle(this.grdLineWarehouse);
            baseForm.SetQueryGridStyle(this.grdHaveNotMoving);
            baseForm.SetQueryGridStyle(this.grdHaveNotPacking);
            this.pQuery.BackColor = Color.FromName("Info");

            RefreshGrid();
            this.grdWarehouse.SetDataBinding(createWarehouseEmptyTable(),"");
            this.grdUnpacking.SetDataBinding(createUnpackingTable(), "");
            this.grdMoving.SetDataBinding(createMovingTable(), "");
            this.grdPacking.SetDataBinding(createPackingTable(), "");
            this.grdUnshipping.SetDataBinding(createUnShippingTable(), "");
            this.grdShipping.SetDataBinding(createShippingTable(), "");
            this.grdLineWarehouse.SetDataBinding(createLineWarehouseTable(), "");
            this.grdHaveNotMoving.SetDataBinding(createHaveNotMovingTable(), "");
            this.grdHaveNotPacking.SetDataBinding(createHaveNotPackingTable(), "");


            if (RSALicense.LICENSEN_INFO.ValidateLicense())
            {
                this.ToolStripMenuItemInspectRpt.Enabled = true;
                this.ToolStripMenuItemInspectRptJP.Enabled = true;
            }
            else
            {
                this.ToolStripMenuItemInspectRpt.Enabled = false;
                this.ToolStripMenuItemInspectRptJP.Enabled = false;
            }
           
        }

        #region InitializeLayout
        private void grdQuery_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;
            e.Layout.Bands[0].Columns["size"].SortComparer = new SizeComparer();

            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }
            if (!e.Layout.ValueLists.Exists("vlstatus"))
            {
                e.Layout.ValueLists.Add("vlstatus");
                e.Layout.ValueLists["vlstatus"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.WIPStatus));
                e.Layout.Bands[0].Columns["status"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["status"].ValueList = e.Layout.ValueLists["vlstatus"];
            }
            if (!e.Layout.ValueLists.Exists("vlworkgroup"))
            {
                e.Layout.ValueLists.Add("vlworkgroup");
                e.Layout.ValueLists["vlworkgroup"].ValueListItems.AddRange(DropDown.GetValueList_DataTable(GetWorkGroup(), "workgroupdesc", "workgroup"));
                e.Layout.Bands[0].Columns["workgroup"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["workgroup"].ValueList = e.Layout.ValueLists["vlworkgroup"];
            }

            e.Layout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            if (!e.Layout.Bands[0].Summaries.Exists("SumPairqty"))
            {
                e.Layout.Bands[0].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[0].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
            }
            
        }
        private void grdWarehouse_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.NewColumnLoadStyle = NewColumnLoadStyle.Show;
            e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;

            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();

            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }

            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                if (!warehouseColumns.Contains(col.Key))
                {
                    col.Hidden = true;
                }
            }
            e.Layout.Bands[0].Columns["customerid"].Hidden = true;

            if (e.Layout.Bands.Count > 1)
            {
                foreach (UltraGridColumn col in e.Layout.Bands[1].Columns)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    if (!subWarehouseColumns.Contains(col.Key))
                    {
                        col.Hidden = true;
                    }
                }
                for (int i = 0; i < subWarehouseColumns.Count(); i++)
                {
                    e.Layout.Bands[1].Columns[subWarehouseColumns[i]].Header.VisiblePosition = i;
                }

                e.Layout.Bands[1].Columns["styleno"].Header.Caption = UtilCulture.GetString("Label.R01026");
                e.Layout.Bands[1].Columns["color"].Header.Caption = UtilCulture.GetString("Label.R01027");
                e.Layout.Bands[1].Columns["size"].Header.Caption = UtilCulture.GetString("Label.R01028");
                e.Layout.Bands[1].Columns["pairqty"].Header.Caption = UtilCulture.GetString("Label.R02026");
                
                //e.Layout.Bands[1].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;                
                //if (!e.Layout.Bands[1].Summaries.Exists("SumPairqty"))
                //{
                //    e.Layout.Bands[1].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[1].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
                //}
            }

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

        private void grdUnpacking_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.NewColumnLoadStyle = NewColumnLoadStyle.Show;
            e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;

            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();


            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }

            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                if (!unpackingColumns.Contains(col.Key))
                {
                    col.Hidden = true;
                }
            }
            e.Layout.Bands[0].Columns["customerid"].Hidden = true;

            if (e.Layout.Bands.Count > 1)
            {
                foreach (UltraGridColumn col in e.Layout.Bands[1].Columns)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    if (!subUnpackingColumns.Contains(col.Key))
                    {
                        col.Hidden = true;
                    }
                }
                for (int i = 0; i < subUnpackingColumns.Count(); i++)
                {
                    e.Layout.Bands[1].Columns[subUnpackingColumns[i]].Header.VisiblePosition = i;
                }

                e.Layout.Bands[1].Columns["styleno"].Header.Caption = UtilCulture.GetString("Label.R01026");
                e.Layout.Bands[1].Columns["color"].Header.Caption = UtilCulture.GetString("Label.R01027");
                e.Layout.Bands[1].Columns["size"].Header.Caption = UtilCulture.GetString("Label.R01028");
                e.Layout.Bands[1].Columns["pairqty"].Header.Caption = UtilCulture.GetString("Label.R02026");

                //e.Layout.Bands[1].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
                //if (!e.Layout.Bands[1].Summaries.Exists("SumPairqty"))
                //{
                //    e.Layout.Bands[1].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[1].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
                //}
            }

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
        private void grdMoving_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.NewColumnLoadStyle = NewColumnLoadStyle.Show;
            e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;

            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();


            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }

            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                if (!movingColumns.Contains(col.Key))
                {
                    col.Hidden = true;
                }
            }
            e.Layout.Bands[0].Columns["customerid"].Hidden = true;

            if (e.Layout.Bands.Count > 1)
            {
                foreach (UltraGridColumn col in e.Layout.Bands[1].Columns)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    if (!subMovingColumns.Contains(col.Key))
                    {
                        col.Hidden = true;
                    }
                }
                for (int i = 0; i < subMovingColumns.Count(); i++)
                {
                    e.Layout.Bands[1].Columns[subMovingColumns[i]].Header.VisiblePosition = i;
                }

                e.Layout.Bands[1].Columns["styleno"].Header.Caption = UtilCulture.GetString("Label.R01026");
                e.Layout.Bands[1].Columns["color"].Header.Caption = UtilCulture.GetString("Label.R01027");
                e.Layout.Bands[1].Columns["size"].Header.Caption = UtilCulture.GetString("Label.R01028");
                e.Layout.Bands[1].Columns["pairqty"].Header.Caption = UtilCulture.GetString("Label.R02026");

                //e.Layout.Bands[1].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
                //if (!e.Layout.Bands[1].Summaries.Exists("SumPairqty"))
                //{
                //    e.Layout.Bands[1].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[1].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
                //}
            }

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
        private void grdPacking_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.NewColumnLoadStyle = NewColumnLoadStyle.Show;
            e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;

            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();


            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }

            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                if (!packingColumns.Contains(col.Key))
                {
                    col.Hidden = true;
                }
            }
            e.Layout.Bands[0].Columns["customerid"].Hidden = true;

            if (e.Layout.Bands.Count > 1)
            {
                foreach (UltraGridColumn col in e.Layout.Bands[1].Columns)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    if (!subPackingColumns.Contains(col.Key))
                    {
                        col.Hidden = true;
                    }
                }
                for (int i = 0; i < subPackingColumns.Count(); i++)
                {
                    e.Layout.Bands[1].Columns[subPackingColumns[i]].Header.VisiblePosition = i;
                }

                e.Layout.Bands[1].Columns["styleno"].Header.Caption = UtilCulture.GetString("Label.R01026");
                e.Layout.Bands[1].Columns["color"].Header.Caption = UtilCulture.GetString("Label.R01027");
                e.Layout.Bands[1].Columns["size"].Header.Caption = UtilCulture.GetString("Label.R01028");
                e.Layout.Bands[1].Columns["pairqty"].Header.Caption = UtilCulture.GetString("Label.R02026");
                e.Layout.Bands[1].Columns["reqairqty"].Header.Caption = UtilCulture.GetString("Label.R010765");
                

                //e.Layout.Bands[1].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
                //if (!e.Layout.Bands[1].Summaries.Exists("SumPairqty"))
                //{
                //    e.Layout.Bands[1].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[1].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
                //}
            }

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

        private void grdShipping_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.NewColumnLoadStyle = NewColumnLoadStyle.Show;
            e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;

            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();


            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }

            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                if (!shippingColumns.Contains(col.Key))
                {
                    col.Hidden = true;
                }
            }
            e.Layout.Bands[0].Columns["customerid"].Hidden = true;

            if (e.Layout.Bands.Count > 1)
            {
                foreach (UltraGridColumn col in e.Layout.Bands[1].Columns)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    if (!subShippingColumns.Contains(col.Key))
                    {
                        col.Hidden = true;
                    }
                }
                for (int i = 0; i < subShippingColumns.Count(); i++)
                {
                    e.Layout.Bands[1].Columns[subShippingColumns[i]].Header.VisiblePosition = i;
                }

                e.Layout.Bands[1].Columns["styleno"].Header.Caption = UtilCulture.GetString("Label.R01026");
                e.Layout.Bands[1].Columns["color"].Header.Caption = UtilCulture.GetString("Label.R01027");
                e.Layout.Bands[1].Columns["size"].Header.Caption = UtilCulture.GetString("Label.R01028");
                e.Layout.Bands[1].Columns["pairqty"].Header.Caption = UtilCulture.GetString("Label.R02026");

                //e.Layout.Bands[1].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
                //if (!e.Layout.Bands[1].Summaries.Exists("SumPairqty"))
                //{
                //    e.Layout.Bands[1].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[1].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
                //}
            }

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

        private void grdUnshipping_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.NewColumnLoadStyle = NewColumnLoadStyle.Show;
            e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;

            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();

            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }

            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                if (!unShippingColumns.Contains(col.Key))
                {
                    col.Hidden = true;
                }
            }
            e.Layout.Bands[0].Columns["customerid"].Hidden = true;

            if (e.Layout.Bands.Count > 1)
            {
                foreach (UltraGridColumn col in e.Layout.Bands[1].Columns)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    if (!subUnShippingColumns.Contains(col.Key))
                    {
                        col.Hidden = true;
                    }
                }
                for (int i = 0; i < subUnShippingColumns.Count(); i++)
                {
                    e.Layout.Bands[1].Columns[subUnShippingColumns[i]].Header.VisiblePosition = i;
                }

                e.Layout.Bands[1].Columns["styleno"].Header.Caption = UtilCulture.GetString("Label.R01026");
                e.Layout.Bands[1].Columns["color"].Header.Caption = UtilCulture.GetString("Label.R01027");
                e.Layout.Bands[1].Columns["size"].Header.Caption = UtilCulture.GetString("Label.R01028");
                e.Layout.Bands[1].Columns["pairqty"].Header.Caption = UtilCulture.GetString("Label.R02026");

                //e.Layout.Bands[1].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
                //if (!e.Layout.Bands[1].Summaries.Exists("SumPairqty"))
                //{
                //    e.Layout.Bands[1].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[1].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
                //}
            }

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

        private void grdLineWarehouse_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.NewColumnLoadStyle = NewColumnLoadStyle.Show;
            e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;

            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();


            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }

            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                if (!lineWarehouseColumns.Contains(col.Key))
                {
                    col.Hidden = true;
                }
            }
            e.Layout.Bands[0].Columns["customerid"].Hidden = true;

            if (e.Layout.Bands.Count > 1)
            {
                foreach (UltraGridColumn col in e.Layout.Bands[1].Columns)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    if (!subLineWarehouseColumns.Contains(col.Key))
                    {
                        col.Hidden = true;
                    }
                }
                for (int i = 0; i < subLineWarehouseColumns.Count(); i++)
                {
                    e.Layout.Bands[1].Columns[subLineWarehouseColumns[i]].Header.VisiblePosition = i;
                }

                e.Layout.Bands[1].Columns["styleno"].Header.Caption = UtilCulture.GetString("Label.R01026");
                e.Layout.Bands[1].Columns["color"].Header.Caption = UtilCulture.GetString("Label.R01027");
                e.Layout.Bands[1].Columns["size"].Header.Caption = UtilCulture.GetString("Label.R01028");
                e.Layout.Bands[1].Columns["pairqty"].Header.Caption = UtilCulture.GetString("Label.R02026");

                //e.Layout.Bands[1].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
                //if (!e.Layout.Bands[1].Summaries.Exists("SumPairqty"))
                //{
                //    e.Layout.Bands[1].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[1].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
                //}
            }

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

        private void grdHaveNotMoving_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.NewColumnLoadStyle = NewColumnLoadStyle.Show;
            e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;

            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();


            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }

            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                if (!haveNotMovingColumns.Contains(col.Key))
                {
                    col.Hidden = true;
                }
            }
            e.Layout.Bands[0].Columns["customerid"].Hidden = true;

            if (e.Layout.Bands.Count > 1)
            {
                foreach (UltraGridColumn col in e.Layout.Bands[1].Columns)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    if (!subHaveNotMovingColumns.Contains(col.Key))
                    {
                        col.Hidden = true;
                    }
                }
                for (int i = 0; i < subHaveNotMovingColumns.Count(); i++)
                {
                    e.Layout.Bands[1].Columns[subHaveNotMovingColumns[i]].Header.VisiblePosition = i;
                }

                e.Layout.Bands[1].Columns["styleno"].Header.Caption = UtilCulture.GetString("Label.R01026");
                e.Layout.Bands[1].Columns["color"].Header.Caption = UtilCulture.GetString("Label.R01027");
                e.Layout.Bands[1].Columns["size"].Header.Caption = UtilCulture.GetString("Label.R01028");
                e.Layout.Bands[1].Columns["pairqty"].Header.Caption = UtilCulture.GetString("Label.R02026");

                //e.Layout.Bands[1].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
                //if (!e.Layout.Bands[1].Summaries.Exists("SumPairqty"))
                //{
                //    e.Layout.Bands[1].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[1].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
                //}
            }

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

        private void grdHaveNotPacking_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.NewColumnLoadStyle = NewColumnLoadStyle.Show;
            e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Default;

            e.Layout.Bands[0].Columns["cartonno"].SortComparer = new CartonNoComparer();


            if (!e.Layout.ValueLists.Exists("vlchecktype"))
            {
                e.Layout.ValueLists.Add("vlchecktype");
                e.Layout.ValueLists["vlchecktype"].ValueListItems.AddRange(DropDown.GetValueList_StaticValue(MES_StaticValue_Type.CheckType));
                e.Layout.Bands[0].Columns["checktype"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                e.Layout.Bands[0].Columns["checktype"].ValueList = e.Layout.ValueLists["vlchecktype"];
            }

            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                if (!haveNotPackingColumns.Contains(col.Key))
                {
                    col.Hidden = true;
                }
            }
            e.Layout.Bands[0].Columns["customerid"].Hidden = true;

            if (e.Layout.Bands.Count > 1)
            {
                foreach (UltraGridColumn col in e.Layout.Bands[1].Columns)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    if (!subHaveNotPackingColumns.Contains(col.Key))
                    {
                        col.Hidden = true;
                    }
                }
                for (int i = 0; i < subHaveNotPackingColumns.Count(); i++)
                {
                    e.Layout.Bands[1].Columns[subHaveNotPackingColumns[i]].Header.VisiblePosition = i;
                }

                e.Layout.Bands[1].Columns["styleno"].Header.Caption = UtilCulture.GetString("Label.R01026");
                e.Layout.Bands[1].Columns["color"].Header.Caption = UtilCulture.GetString("Label.R01027");
                e.Layout.Bands[1].Columns["size"].Header.Caption = UtilCulture.GetString("Label.R01028");
                e.Layout.Bands[1].Columns["pairqty"].Header.Caption = UtilCulture.GetString("Label.R02026");

                //e.Layout.Bands[1].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
                //if (!e.Layout.Bands[1].Summaries.Exists("SumPairqty"))
                //{
                //    e.Layout.Bands[1].Summaries.Add("SumPairqty", SummaryType.Sum, e.Layout.Bands[1].Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
                //}
            }

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
        #endregion

        private void btnQuery_Click(object sender, EventArgs e)
        {
            RefreshActiveGrid();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.uTabQuery.ActiveTab.Key == "tabWIP")
            {
                RefreshGrid();
            }
        }

        private void uTabQuery_ActiveTabChanged(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e)
        {
            int rowCount = 0;
            if (this.uTabQuery.ActiveTab.Key == "tabWIP")
            {
                rowCount = this.grdQuery.Rows.Count;                
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabWarehouse")
            {
                rowCount = this.grdWarehouse.Rows.Count;                
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabUnpacking")
            {
                rowCount = this.grdUnpacking.Rows.Count;
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabMoving")
            {
                rowCount = this.grdMoving.Rows.Count;
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabPacking")
            {
                rowCount = this.grdPacking.Rows.Count;
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabShipping")
            {
                rowCount = this.grdShipping.Rows.Count;
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabLineWarehouse")
            {
                rowCount = this.grdLineWarehouse.Rows.Count;
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabUnshipping")
            {
                rowCount = this.grdUnshipping.Rows.Count;
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabHaveNotMoving")
            {
                rowCount = this.grdHaveNotMoving.Rows.Count;
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabHaveNotPacking")
            {
                rowCount = this.grdHaveNotPacking.Rows.Count;
            }
            this.ucStatusBar1.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + rowCount);
        }

        private void ToolStripMenuItemInspectRpt_Click(object sender, EventArgs e)
        {
            ExportInspectRpt(null);
            
        }

        private void ToolStripMenuItemInspectRptJP_Click(object sender, EventArgs e)
        {
            ExportInspectRpt("JP");
        }

        #endregion

        #region Methods
        private void ExportInspectRpt(string lang)
        {
            string customerid = "";
            string custorderno = "";
            if (this.uTabQuery.ActiveTab.Key == "tabWIP" && this.grdQuery.ActiveRow != null)
            {
                customerid = this.grdQuery.ActiveRow.Cells["customerid"].Value.ToString();
                custorderno = this.grdQuery.ActiveRow.Cells["custorderno"].Value.ToString();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabUnpacking" && this.grdUnpacking.ActiveRow != null)
            {
                customerid = this.grdUnpacking.ActiveRow.Cells["customerid"].Value.ToString();
                custorderno = this.grdUnpacking.ActiveRow.Cells["custorderno"].Value.ToString();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabMoving" && this.grdMoving.ActiveRow != null)
            {
                customerid = this.grdMoving.ActiveRow.Cells["customerid"].Value.ToString();
                custorderno = this.grdMoving.ActiveRow.Cells["custorderno"].Value.ToString();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabPacking" && this.grdPacking.ActiveRow != null)
            {
                customerid = this.grdPacking.ActiveRow.Cells["customerid"].Value.ToString();
                custorderno = this.grdPacking.ActiveRow.Cells["custorderno"].Value.ToString();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabShipping" && this.grdShipping.ActiveRow != null)
            {
                customerid = this.grdShipping.ActiveRow.Cells["customerid"].Value.ToString();
                custorderno = this.grdShipping.ActiveRow.Cells["custorderno"].Value.ToString();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabLineWarehouse" && this.grdLineWarehouse.ActiveRow != null)
            {
                customerid = this.grdLineWarehouse.ActiveRow.Cells["customerid"].Value.ToString();
                custorderno = this.grdLineWarehouse.ActiveRow.Cells["custorderno"].Value.ToString();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabUnshipping" && this.grdUnshipping.ActiveRow != null)
            {
                customerid = this.grdUnshipping.ActiveRow.Cells["customerid"].Value.ToString();
                custorderno = this.grdUnshipping.ActiveRow.Cells["custorderno"].Value.ToString();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabHaveNotMoving" && this.grdHaveNotMoving.ActiveRow != null)
            {
                customerid = this.grdUnshipping.ActiveRow.Cells["customerid"].Value.ToString();
                custorderno = this.grdUnshipping.ActiveRow.Cells["custorderno"].Value.ToString();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabHaveNotPacking" && this.grdHaveNotPacking.ActiveRow != null)
            {
                customerid = this.grdUnshipping.ActiveRow.Cells["customerid"].Value.ToString();
                custorderno = this.grdUnshipping.ActiveRow.Cells["custorderno"].Value.ToString();
            }

            WaitingForm.CreateWaitForm();
            WaitingForm.SetWaitMessage("正在生成检验报告，请稍候...");
            (new ExcelExport()).ExportInspectRpt(GetHeaderInfoForInspectRpt(customerid, custorderno),
                GetReasonCode(), GetRepairInfoForInspectRpt(customerid, custorderno),
                GetRepairFailForInspectRpt(customerid, custorderno), GetRepairHisForInspectRpt(customerid, custorderno),
                GetShippedForInspectRpt(customerid, custorderno),GeUserList(), lang, custorderno);

            WaitingForm.CloseWaitForm();
        }

        private void RefreshActiveGrid()
        {
            if (this.uTabQuery.ActiveTab.Key == "tabWIP")
            {
                RefreshGrid();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabWarehouse")
            {
                RefreshWarehouseGrid();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabUnpacking")
            {
                RefreshUnpackingGrid();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabMoving")
            {
                RefreshMovingGrid();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabPacking")
            {
                RefreshPackingGrid();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabShipping")
            {
                RefreshShippingGrid();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabLineWarehouse")
            {
                RefreshLineWarehouseGrid();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabUnshipping")
            {
                RefreshUnShippingGrid();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabHaveNotMoving")
            {
                RefreshHaveNotMovingGrid();
            }
            else if (this.uTabQuery.ActiveTab.Key == "tabHaveNotPacking")
            {
                RefreshHaveNotPackingGrid();
            }
        }

        private void RefreshLineWarehouseGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue = "%" + param.ParamValue + "%";
            }
            GetLineWarehouseData(lstParameters);
        }

        private void GetLineWarehouseData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = new DataSet();
                DataSet mainds = client.GetLineWarehouseSumRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataSet subds = client.GetLineWarehouseSumDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataTable maindt = mainds.Tables[0];
                DataTable subdt = subds.Tables[0];
                maindt.TableName = "Main";
                subdt.TableName = "Sub";
                mainds.Tables.Clear();
                subds.Tables.Clear();

                if (maindt != null)
                {
                    ds.Tables.Add(maindt);
                    ds.Tables.Add(subdt);
                    ds.Relations.Add("ps", new DataColumn[] { ds.Tables["Main"].Columns["customerid"], ds.Tables["Main"].Columns["custorderno"], ds.Tables["Main"].Columns["cartonno"] }, new DataColumn[] { ds.Tables["Sub"].Columns["customerid"], ds.Tables["Sub"].Columns["custorderno"], ds.Tables["Sub"].Columns["cartonno"] }, false);
                    this.grdLineWarehouse.SetDataBinding(ds, "");
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

        private void RefreshUnShippingGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue = "%" + param.ParamValue + "%";
            }
            GetUnShippingData(lstParameters);
        }

        private void GetUnShippingData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = new DataSet();
                DataSet mainds = client.GetUnShippingSumRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataSet subds = client.GetUnShippingSumDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataTable maindt = mainds.Tables[0];
                DataTable subdt = subds.Tables[0];
                maindt.TableName = "Main";
                subdt.TableName = "Sub";
                mainds.Tables.Clear();
                subds.Tables.Clear();

                if (maindt != null)
                {
                    ds.Tables.Add(maindt);
                    ds.Tables.Add(subdt);
                    ds.Relations.Add("ps", new DataColumn[] { ds.Tables["Main"].Columns["customerid"], ds.Tables["Main"].Columns["custorderno"], ds.Tables["Main"].Columns["cartonno"] }, new DataColumn[] { ds.Tables["Sub"].Columns["customerid"], ds.Tables["Sub"].Columns["custorderno"], ds.Tables["Sub"].Columns["cartonno"] }, false);
                    this.grdUnshipping.SetDataBinding(ds, "");
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

        private void RefreshShippingGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue = "%" + param.ParamValue + "%";
            }
            GetShippingData(lstParameters);
        }

        private void GetShippingData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = new DataSet();
                DataSet mainds = client.GetShippingSumRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataSet subds = client.GetShippingSumDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataTable maindt = mainds.Tables[0];
                DataView dv = maindt.DefaultView;
                dv.RowFilter = "pairqty<>0";
                maindt = dv.ToTable();

                DataTable subdt = subds.Tables[0];
                maindt.TableName = "Main";
                subdt.TableName = "Sub";
                mainds.Tables.Clear();
                subds.Tables.Clear();

                if (maindt != null)
                {
                    ds.Tables.Add(maindt);
                    ds.Tables.Add(subdt);
                    ds.Relations.Add("ps", new DataColumn[] { ds.Tables["Main"].Columns["customerid"], ds.Tables["Main"].Columns["custorderno"], ds.Tables["Main"].Columns["cartonno"] }, new DataColumn[] { ds.Tables["Sub"].Columns["customerid"], ds.Tables["Sub"].Columns["custorderno"], ds.Tables["Sub"].Columns["cartonno"] }, false);
                    this.grdShipping.SetDataBinding(ds, "");

                    //foreach (UltraGridBand band in this.grdShipping.DisplayLayout.Bands)
                    //{
                    //    if (band.Columns.Exists("pairqty"))
                    //        band.Summaries.Add(SummaryType.Sum, band.Columns["pairqty"], SummaryPosition.UseSummaryPositionColumn);
                    //}
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

        private void RefreshPackingGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue = "%" + param.ParamValue + "%";
            }
            lstParameters.Add(new MESParameterInfo()
            {
                ParamName = "pktype",
                ParamValue = MES_PackingType.Packing.ToString(),
                ParamType = "string"
            });
            GetPackingData(lstParameters);
        }

        private void GetPackingData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = new DataSet();
                DataSet mainds = client.GetPackingDtlSumRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataSet subds = client.GetPackingDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataTable maindt = mainds.Tables[0];
                DataView dv = maindt.DefaultView;
                dv.RowFilter = "pairqty<>0";
                maindt = dv.ToTable();

                DataTable subdt = subds.Tables[0];
                maindt.TableName = "Main";
                subdt.TableName = "Sub";
                mainds.Tables.Clear();
                subds.Tables.Clear();

                if (maindt != null)
                {
                    ds.Tables.Add(maindt);
                    ds.Tables.Add(subdt);
                    ds.Relations.Add("ps", new DataColumn[] { ds.Tables["Main"].Columns["customerid"], ds.Tables["Main"].Columns["custorderno"], ds.Tables["Main"].Columns["cartonno"] }, new DataColumn[] { ds.Tables["Sub"].Columns["customerid"], ds.Tables["Sub"].Columns["custorderno"], ds.Tables["Sub"].Columns["cartonno"] }, false);
                    this.grdPacking.SetDataBinding(ds, "");
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


        private void RefreshMovingGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue = "%" + param.ParamValue + "%";
            }
            lstParameters.Add(new MESParameterInfo()
            {
                ParamName = "pktype",
                ParamValue = MES_PackingType.Moving.ToString(),
                ParamType = "string"
            });
            GetMovingData(lstParameters);
        }

        private void GetMovingData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = new DataSet();
                DataSet mainds = client.GetPackingDtlSumRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataSet subds = client.GetPackingDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataTable maindt = mainds.Tables[0];
                DataTable subdt = subds.Tables[0];
                maindt.TableName = "Main";
                subdt.TableName = "Sub";
                mainds.Tables.Clear();
                subds.Tables.Clear();

                if (maindt != null)
                {
                    ds.Tables.Add(maindt);
                    ds.Tables.Add(subdt);
                    ds.Relations.Add("ps", new DataColumn[] { ds.Tables["Main"].Columns["customerid"], ds.Tables["Main"].Columns["custorderno"], ds.Tables["Main"].Columns["cartonno"] }, new DataColumn[] { ds.Tables["Sub"].Columns["customerid"], ds.Tables["Sub"].Columns["custorderno"], ds.Tables["Sub"].Columns["cartonno"] }, false);
                    this.grdMoving.SetDataBinding(ds, "");
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

        private void RefreshUnpackingGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue = "%" + param.ParamValue + "%";
            }
            lstParameters.Add(new MESParameterInfo()
            {
                ParamName = "pktype",
                ParamValue = MES_PackingType.Unpacking.ToString(),
                ParamType = "string"
            });
            GetUnpackingData(lstParameters);
        }

        private void GetUnpackingData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = new DataSet();
                DataSet mainds = client.GetPackingDtlSumRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataSet subds = client.GetPackingDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataTable maindt = mainds.Tables[0];
                DataTable subdt = subds.Tables[0];
                maindt.TableName = "Main";
                subdt.TableName = "Sub";
                mainds.Tables.Clear();
                subds.Tables.Clear();

                if (maindt != null)
                {
                    ds.Tables.Add(maindt);
                    ds.Tables.Add(subdt);
                    ds.Relations.Add("ps", new DataColumn[] { ds.Tables["Main"].Columns["customerid"], ds.Tables["Main"].Columns["custorderno"], ds.Tables["Main"].Columns["cartonno"] }, new DataColumn[] { ds.Tables["Sub"].Columns["customerid"], ds.Tables["Sub"].Columns["custorderno"], ds.Tables["Sub"].Columns["cartonno"] }, false);
                    this.grdUnpacking.SetDataBinding(ds, "");
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

        private void RefreshWarehouseGrid()
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
            GetWarehouseData(lstParameters);
        }

        private void GetWarehouseData(List<MESParameterInfo> lstParameters)
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
                    ds.Tables.Add(maindt);
                    ds.Tables.Add(subdt);
                    ds.Relations.Add("ps", new DataColumn[] { ds.Tables["Main"].Columns["customerid"], ds.Tables["Main"].Columns["custorderno"], ds.Tables["Main"].Columns["cartonno"] }, new DataColumn[] { ds.Tables["Sub"].Columns["customerid"], ds.Tables["Sub"].Columns["custorderno"], ds.Tables["Sub"].Columns["cartonno"] }, false);
                    this.grdWarehouse.SetDataBinding(ds, "");
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

        private void RefreshHaveNotMovingGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue = "%" + param.ParamValue + "%";
            }
            GetHaveNotMovingData(lstParameters);
        }

        private void GetHaveNotMovingData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = new DataSet();
                DataSet mainds = client.GetHaveNotMovingDtlSumRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataSet subds = client.GetHaveNotMovingDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataTable maindt = mainds.Tables[0];
                DataTable subdt = subds.Tables[0];
                maindt.TableName = "Main";
                subdt.TableName = "Sub";
                mainds.Tables.Clear();
                subds.Tables.Clear();

                if (maindt != null)
                {
                    ds.Tables.Add(maindt);
                    ds.Tables.Add(subdt);
                    ds.Relations.Add("ps", new DataColumn[] { ds.Tables["Main"].Columns["customerid"], ds.Tables["Main"].Columns["custorderno"], ds.Tables["Main"].Columns["cartonno"] }, new DataColumn[] { ds.Tables["Sub"].Columns["customerid"], ds.Tables["Sub"].Columns["custorderno"], ds.Tables["Sub"].Columns["cartonno"] }, false);
                    this.grdHaveNotMoving.SetDataBinding(ds, "");
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

        private void RefreshHaveNotPackingGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue = "%" + param.ParamValue + "%";
            }
            GetHaveNotPackingData(lstParameters);
        }

        private void GetHaveNotPackingData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = new DataSet();
                DataSet mainds = client.GetHaveNotPackingDtlSumRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataSet subds = client.GetHaveNotPackingDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                DataTable maindt = mainds.Tables[0];
                DataTable subdt = subds.Tables[0];
                maindt.TableName = "Main";
                subdt.TableName = "Sub";
                mainds.Tables.Clear();
                subds.Tables.Clear();

                if (maindt != null)
                {
                    ds.Tables.Add(maindt);
                    ds.Tables.Add(subdt);
                    ds.Relations.Add("ps", new DataColumn[] { ds.Tables["Main"].Columns["customerid"], ds.Tables["Main"].Columns["custorderno"], ds.Tables["Main"].Columns["cartonno"] }, new DataColumn[] { ds.Tables["Sub"].Columns["customerid"], ds.Tables["Sub"].Columns["custorderno"], ds.Tables["Sub"].Columns["cartonno"] }, false);
                    this.grdHaveNotPacking.SetDataBinding(ds, "");
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


        private void RefreshGrid()
        {
            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
            baseForm.BuildQueryParameters(lstParameters, this.pQuery); ;
            foreach (MESParameterInfo param in lstParameters)
            {
                param.ParamValue = "%" + param.ParamValue + "%";
            }
            GetData(lstParameters);
        }
        private void GetData(List<MESParameterInfo> lstParameters)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            try
            {
                baseForm.SetCursor();

                DataSet ds = client.GetWipRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                this.grdQuery.SetDataBinding(ds.Tables[0], "");

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

        private DataTable GetWorkGroup()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            DataTable dt = null;
            try
            {
                dt = client.GetWorkGroupRecords(baseForm.CurrentContextInfo, (new List<MESParameterInfo>()).ToArray<MESParameterInfo>()).Tables[0];
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

        private DataTable GetReasonCode()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            DataTable dt = null;
            try
            {
                dt = client.GetReasonCodeRecords(baseForm.CurrentContextInfo, (new List<MESParameterInfo>()).ToArray<MESParameterInfo>()).Tables[0];
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

        private DataTable GetRepairInfoForInspectRpt(string customerid,string custorderno)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="customerid",ParamValue=customerid},
                            new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno}
                        };
                dt = client.GetRepairInfoForInspectRpt(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];

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

        private DataTable GetRepairFailForInspectRpt(string customerid, string custorderno)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="customerid",ParamValue=customerid},
                            new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno}
                        };
                dt = client.GetRepairFailForInspectRpt(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];

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

        private DataTable GetShippedForInspectRpt(string customerid, string custorderno)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="customerid",ParamValue=customerid},
                            new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno}
                        };
                dt = client.GetShippedForInspectRpt(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];

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

        private DataTable GetHeaderInfoForInspectRpt(string customerid, string custorderno)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="customerid",ParamValue=customerid},
                            new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno}
                        };
                dt = client.GetHeaderInfoForInspectRpt(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];

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

        private DataTable GetRepairHisForInspectRpt(string customerid, string custorderno)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="customerid",ParamValue=customerid},
                            new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno}
                        };
                dt = client.GetRepairHisRecords(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];

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

        private DataTable GeUserList()
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            DataTable dt = null;
            try
            {
                
                dt = client.GetUserRecords(baseForm.CurrentContextInfo, (new List<MESParameterInfo>()).ToArray<MESParameterInfo>()).Tables[0];

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

        private DataTable createWarehouseEmptyTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("customerid");
            dt.Columns.Add("customername");
            dt.Columns.Add("custorderno");
            dt.Columns.Add("cartonno");
            dt.Columns.Add("pairqty");
            dt.Columns.Add("checktype");
            return dt;
        }
        private DataTable createUnpackingTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("customerid");
            dt.Columns.Add("customername");
            dt.Columns.Add("custorderno");
            dt.Columns.Add("cartonno");
            dt.Columns.Add("pairqty");
            dt.Columns.Add("checktype");
            return dt;
        }
        private DataTable createMovingTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("customerid");
            dt.Columns.Add("customername");
            dt.Columns.Add("custorderno");
            dt.Columns.Add("cartonno");
            dt.Columns.Add("pairqty");
            dt.Columns.Add("checktype");
            return dt;
        }
        private DataTable createPackingTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("customerid");
            dt.Columns.Add("customername");
            dt.Columns.Add("custorderno");
            dt.Columns.Add("cartonno");
            dt.Columns.Add("pairqty");
            dt.Columns.Add("checktype");
            return dt;
        }

        private DataTable createHaveNotMovingTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("customerid");
            dt.Columns.Add("customername");
            dt.Columns.Add("custorderno");
            dt.Columns.Add("cartonno");
            dt.Columns.Add("pairqty");
            dt.Columns.Add("checktype");
            return dt;
        }

        private DataTable createHaveNotPackingTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("customerid");
            dt.Columns.Add("customername");
            dt.Columns.Add("custorderno");
            dt.Columns.Add("cartonno");
            dt.Columns.Add("pairqty");
            dt.Columns.Add("checktype");
            return dt;
        }

        private DataTable createShippingTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("customerid");
            dt.Columns.Add("customername");
            dt.Columns.Add("custorderno");
            dt.Columns.Add("cartonno");
            dt.Columns.Add("pairqty");
            dt.Columns.Add("checktype");
            return dt;
        }
        private DataTable createUnShippingTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("customerid");
            dt.Columns.Add("customername");
            dt.Columns.Add("custorderno");
            dt.Columns.Add("cartonno");
            dt.Columns.Add("pairqty");
            dt.Columns.Add("checktype");
            return dt;
        }
        private DataTable createLineWarehouseTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("customerid");
            dt.Columns.Add("customername");
            dt.Columns.Add("custorderno");
            dt.Columns.Add("cartonno");
            dt.Columns.Add("pairqty");
            dt.Columns.Add("checktype");
            return dt;
        }
        #endregion

               

            
       
    }
}

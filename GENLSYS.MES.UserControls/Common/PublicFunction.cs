using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using GENLSYS.MES.Common;
using System.Drawing;

namespace GENLSYS.MES.UserControls.Common
{
    public class PublicFunction
    {
        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void CreateUltraGridColumns(Infragistics.Win.UltraWinGrid.UltraGrid grid, string[] cols)
        {
            UltraGridBand ultraGridBand = new UltraGridBand("", -1);
            List<UltraGridColumn> list = new List<UltraGridColumn>();
            int i = 0;
            foreach (string col in cols)
            {
                UltraGridColumn ultraGridColumn = new Infragistics.Win.UltraWinGrid.UltraGridColumn(col.ToUpper());
                ultraGridColumn.Header.VisiblePosition = i++;
                list.Add(ultraGridColumn);
            }
            ultraGridBand.Columns.AddRange(list.ToArray());
            grid.DisplayLayout.BandsSerializer.Add(ultraGridBand);
        }

        public static void SetQueryGridStyle(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            SetGridReadOnly(grid, true);
            grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            grid.DisplayLayout.Override.SelectTypeCell = SelectType.Extended;
            grid.DisplayLayout.Override.SelectTypeCol = SelectType.Extended;

            grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

            grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal;
            grid.DisplayLayout.NewColumnLoadStyle = NewColumnLoadStyle.Hide;
            grid.DisplayLayout.CaptionVisible = DefaultableBoolean.False;

            grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            grid.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            grid.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;

            grid.DisplayLayout.Appearance.BackColor = Color.White;
            grid.DisplayLayout.Override.CellAppearance.BorderColor = System.Drawing.Color.Silver;
            grid.DisplayLayout.Override.RowAppearance.BorderColor = System.Drawing.Color.Silver;

            grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;

            //Grid cell can be copy to clipboard
            grid.DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy;
            grid.PerformAction(UltraGridAction.Copy);

        }

        public static void SetGridReadOnly(Infragistics.Win.UltraWinGrid.UltraGrid grid, bool flag)
        {
            foreach (UltraGridColumn col in grid.DisplayLayout.Bands[0].Columns)
            {
                if (flag)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
                else
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                if (col.Key.ToUpper().Equals("LASTMODIFIEDTIME") || col.Key.ToUpper().Equals("CLAIMTIME") || col.Key.ToUpper().Equals("CREATEDTIME"))
                {
                    col.Format = Parameter.DATETIME_FORMAT;
                }
            }
        }

        public static void CloseWCF(object client)
        {
            if (client is wsUCSYS.IwsSYSClient)
            {
                if ((client as wsUCSYS.IwsSYSClient).State == System.ServiceModel.CommunicationState.Opened)
                {
                    (client as wsUCSYS.IwsSYSClient).Close();
                }
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinGrid;

namespace GENLSYS.MES.Win.Common.Classes
{
    public class CustomMergedCellEvaluator: Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
    {
        public CustomMergedCellEvaluator()
        {

        }

        public bool ShouldCellsBeMerged(UltraGridRow row1,UltraGridRow row2, UltraGridColumn column)
        {
            // Test to make sure the Type is not DBNull since we allow the ShippedDate to be null
            if (row1.GetCellValue(column).GetType().ToString() != "System.DBNull" && row2.GetCellValue(column).GetType().ToString() != "System.DBNull")
            {
                string value1 = row1.GetCellValue(column).ToString();
                string value2 = row2.GetCellValue(column).ToString();
                // Merge cells according to the date portions of the underlying DateTime cell
                // values, ignoring any time portion. For example, "1/1/2004 10:30 AM" will be
                //  merged with "1/1/2004 1:15 AM" since the dates are the same.
                return value1.Equals(value2);
            }
            else
                return false;
        }
    }
}

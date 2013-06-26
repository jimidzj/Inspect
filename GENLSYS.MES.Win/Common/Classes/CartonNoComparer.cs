using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Infragistics.Win.UltraWinGrid;
using MicroMES2.Common;

namespace GENLSYS.MES.Win.Common.Classes
{
    public class CartonNoComparer:IComparer
    {
        public int Compare(object x, object y)
        {
            string valx = ((UltraGridCell)x).Value.ToString();
            string valy = ((UltraGridCell)y).Value.ToString();
            return SortHelper.CompareString(valx,valy);
        }
    }
}

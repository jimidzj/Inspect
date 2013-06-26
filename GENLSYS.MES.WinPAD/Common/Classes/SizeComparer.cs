using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Infragistics.Win.UltraWinGrid;
using MicroMES2.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.WinPAD.Common.Classes
{
    public class SizeComparer:IComparer
    {
        public int Compare(object x, object y)
        {
            string xVal = ((UltraGridCell)x).Value.ToString();
            string yVal = ((UltraGridCell)y).Value.ToString();
            string xSeqVal = GetSequenceValue(xVal);
            string ySeqVal = GetSequenceValue(yVal);
            if (xSeqVal != null && SortHelper.isNumeric(xSeqVal) && ySeqVal != null && SortHelper.isNumeric(ySeqVal))
            {
                if (Double.Parse(xSeqVal) > Double.Parse(ySeqVal))
                {
                    return 1;
                }
                else if (Double.Parse(xSeqVal) < Double.Parse(ySeqVal))
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return xVal.CompareTo(yVal);
            }
        }

        private string GetSequenceValue(string v)
        {
            string result = null;
            List<tsysstaticvalue> lstValue = Parameter.CURRENT_STATIC_VALUE as List<tsysstaticvalue>;
            var q = from p in lstValue
                    where p.svvalue == v && p.svtype == Public_StaticValueType.ShoeSize.ToString()
                    select p;
            if (q.Count() > 0)
            {
                result = q.ElementAt(0).svresourceid;
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using MicroMES2.Common;

namespace GENLSYS.MES.Win.Common.Classes
{
    public class SizeStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string xSeqVal = GetSequenceValue(x);
            string ySeqVal = GetSequenceValue(y);
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
                return x.CompareTo(y);
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

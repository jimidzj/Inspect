using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;
using System.Data;
using MicroMES2.Common;

namespace GENLSYS.MES.Win.Common.Classes
{
    public class DataRowComparer:IComparer<DataRow>
    {
        public int Compare(DataRow x, DataRow y)
        {
            int custordernoCompare = x["custorderno"].ToString().CompareTo(y["custorderno"].ToString());
            if (custordernoCompare == 0)
            {
                int stylenoCompare = x["styleno"].ToString().CompareTo(y["styleno"].ToString());
                if (stylenoCompare == 0)
                {
                    int colorCompare = x["color"].ToString().CompareTo(y["color"].ToString());
                    if (colorCompare == 0)
                    {
                        string xSeqVal = GetSequenceValue(x["size"].ToString());
                        string ySeqVal = GetSequenceValue(y["size"].ToString());
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
                            return x["size"].ToString().CompareTo(y["size"].ToString());
                        }
                    }
                    else
                    {
                        return colorCompare;
                    }
                }
                else
                {
                    return stylenoCompare;
                }
            }
            else
            {
                return custordernoCompare;
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

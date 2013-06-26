using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MicroMES2.Common
{
    public class SortHelper
    {
        public static int CompareString(string x, string y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    if (isNumeric(x))
                    {
                        if (isNumeric(y))
                        {
                            if (Double.Parse(x) > Double.Parse(y))
                            {
                                return 1;
                            }
                            else if (Double.Parse(x) < Double.Parse(y))
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
                            return 1;
                        }
                    }
                    else
                    {
                        if (isNumeric(y))
                        {
                            return -1;
                        }
                        else
                        {
                            int length = x.Length;
                            if (y.Length > length)
                            {
                                length = y.Length;
                            }
                            return fixString(x, length).CompareTo(fixString(y, length));
                        }
                    }
                }
            }
        }

        public static bool isNumeric(string value)
        {
            if (value == null)
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(value, @"^[+-]?\d*$");
            }
        }

        public static string fixString(string value, int length)
        {
            string prefix = "";
            string suffix = "";
            for (int i = 0; i < value.Length; i++)
            {
                if (isNumeric(value.Substring(i)))
                {
                    prefix = value.Substring(0, i);
                    suffix = value.Substring(i);
                    break;
                }
            }
            for (int i = 0; i < length - prefix.Length - suffix.Length; i++)
            {
                suffix = "0" + suffix;
            }
            return prefix + suffix;
        }
    }
}

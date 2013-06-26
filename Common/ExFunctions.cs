using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GENLSYS.MES.Common
{
    public static class ExFunctions
    {
        public static string GetPageName(this string controllerName)
        {
            return controllerName.Replace("Controller", "");

        }

        public static string EscapeHtml(this string escapedString)
        {
            return Regex.Escape(escapedString).Replace("'","\\'").Replace("\r\n","\\r\\n");
        }
    }
}

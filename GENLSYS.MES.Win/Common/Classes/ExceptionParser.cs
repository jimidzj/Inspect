using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.Common.Classes
{
    public class ExceptionParser
    {
        public static string Parse(object _ex)
        {
            return subParse(_ex, string.Empty, string.Empty, false);
        }

        public static string Parse(object _ex, bool _colorIt)
        {
            return subParse(_ex, string.Empty, string.Empty, _colorIt);
        }

        public static string Parse(object _ex, string _additionalMessage)
        {
            return subParse(_ex, string.Empty, _additionalMessage, false);
        }

        public static string Parse(string _additionalMessage, object _ex)
        {
            return subParse(_ex, _additionalMessage, string.Empty, false);
        }

        public static string Parse(object _ex, string _additionalMessage, bool _colorIt)
        {
            return subParse(_ex, string.Empty, _additionalMessage, _colorIt);
        }

        public static string Parse(string _additionalMessage, object _ex, bool _colorIt)
        {
            return subParse(_ex, _additionalMessage, string.Empty, _colorIt);
        }

        private static string subParse(object _ex, string _additionalMessageFront, string _additionalMessageBack, bool _colorIt)
        {
            string sMessage = string.Empty;

            if (_ex.GetType().FullName == "GENLSYS.MES.Utility.UtilException")
                sMessage = subParseUtilException((UtilException)_ex, _additionalMessageFront, _additionalMessageBack);
            else
                sMessage = subParseException((Exception)_ex, _additionalMessageFront, _additionalMessageBack);



            if (!sMessage.Equals(string.Empty))
            {
                if (_colorIt)
                {
                    //sMessage = "<font color=red>" + sMessage + "</font>";
                }
            }

            return sMessage;
        }

        private static string subParseException(Exception _ex, string _additionalMessageFront, string _additionalMessageBack)
        {
            string sReturn = string.Empty;
            switch (_ex.Message)
            {
                case "-200001":
                    sReturn = UtilCulture.GetString("Msg.R00019", _additionalMessageFront);
                    break;
                case "-200002":
                    sReturn = UtilCulture.GetString("Msg.R00020", _additionalMessageFront);
                    break;
                case "-200003":
                    sReturn = UtilCulture.GetString("Msg.R00021", _additionalMessageFront);
                    break;
                case "-200004":
                    sReturn = UtilCulture.GetString("Msg.R00022", _additionalMessageFront);
                    break;
                case "-200005":
                    sReturn = UtilCulture.GetString("Msg.R00023", _additionalMessageFront);
                    break;
                case "-200006":
                    sReturn = UtilCulture.GetString("Msg.R00024", _additionalMessageFront);
                    break;
                case "-200007":
                    sReturn = UtilCulture.GetString("Msg.R00025", _additionalMessageFront);
                    break;
                case "-200008":
                    sReturn = UtilCulture.GetString("Msg.R00035", _additionalMessageFront);
                    break;
                case "-200009":
                    sReturn = UtilCulture.GetString("Msg.R00036", _additionalMessageFront);
                    break;
                case "-200010":
                    sReturn = UtilCulture.GetString("Msg.R00039", _additionalMessageFront);
                    break;
                case "-200011":
                    sReturn = UtilCulture.GetString("Msg.R00044", _additionalMessageFront);
                    break;
                case "-200012":
                    sReturn = UtilCulture.GetString("Msg.R00052", _additionalMessageFront);
                    break;
                case "-200013":
                    sReturn = UtilCulture.GetString("Msg.R00053", _additionalMessageFront);
                    break;
                case "-200014":
                    sReturn = UtilCulture.GetString("Msg.R00054", _additionalMessageFront);
                    break;
                case "-200015":
                    sReturn = UtilCulture.GetString("Msg.R00055", _additionalMessageFront);
                    break;
                case "-200016":
                    sReturn = UtilCulture.GetString("Msg.R00059", _additionalMessageFront);
                    break;
                case "-200017":
                    sReturn = UtilCulture.GetString("Msg.R00060", _additionalMessageFront);
                    break;
                case "-200018":
                    sReturn = UtilCulture.GetString("Msg.R00062", _additionalMessageFront);
                    break;
                case "-200019":
                    sReturn = UtilCulture.GetString("Msg.R00029", _additionalMessageFront);
                    break;
                case "-200020":
                    sReturn = UtilCulture.GetString("Msg.R00114", _additionalMessageFront);
                    break;
                case "-200021":
                    sReturn = UtilCulture.GetString("Msg.R00115", _additionalMessageFront);
                    break;
                case "-200022":
                    sReturn = UtilCulture.GetString("Msg.R00120", _additionalMessageFront);
                    break;
                case "-200023":
                    sReturn = UtilCulture.GetString("Msg.R00123", _additionalMessageFront);
                    break;
                case "-200024":
                    sReturn = UtilCulture.GetString("Msg.R00124", _additionalMessageFront);
                    break;
                case "-200025":
                    sReturn = UtilCulture.GetString("Msg.R00125", _additionalMessageFront);
                    break;
                case "-200026":
                    sReturn = UtilCulture.GetString("Msg.R00126", _additionalMessageFront);
                    break;
                case "-200027":
                    sReturn = UtilCulture.GetString("Msg.R00132", _additionalMessageFront);
                    break;
                case "-200028":
                    sReturn = UtilCulture.GetString("Msg.R00188", _additionalMessageFront);
                    break;
                case "-200029":
                    sReturn = UtilCulture.GetString("Msg.R00195", _additionalMessageFront);
                    break;
                case "-200030":
                    sReturn = UtilCulture.GetString("Msg.R00223", _additionalMessageFront);
                    break;
                case "-200031":
                    sReturn = UtilCulture.GetString("Msg.R00236", _additionalMessageFront);
                    break;
                default:
                    sReturn = _ex.Message;
                    break;
            }

            //if (!_additionalMessageFront.Equals(string.Empty))
            //    sReturn = _additionalMessageFront + "[" + sReturn + "]";

            //if (!_additionalMessageBack.Equals(string.Empty))
            //    sReturn = sReturn + "[" + _additionalMessageFront + "]";

            return sReturn.ToString();
        }

        private static string subParseUtilException(UtilException _ex, string _additionalMessageFront, string _additionalMessageBack)
        {
            string sReturn = string.Empty;
            switch (_ex.Code)
            {
                
                case 2291: //Oracle Exception: FK violation
                    sReturn = _ex.Message;// + "[" + AddLinkToTrace(_ex.TraceFileName) + "]";
                    break;
                case 1: //Oracle Exception: Unique violation
                    sReturn = _ex.Message ;//+ "[" + AddLinkToTrace(_ex.TraceFileName) + "]";
                    break;
                case 1400://Oracle Exception: Cannot insert null
                    sReturn = _ex.Message ;//+ "[" + AddLinkToTrace(_ex.TraceFileName) + "]";
                    break;
                default:
                    sReturn = _ex.Message;
                    break;
            }

            if (!_additionalMessageFront.Equals(string.Empty))
                sReturn = _additionalMessageFront + "[" + sReturn + "]";

            if (!_additionalMessageBack.Equals(string.Empty))
                sReturn = sReturn + "[" + _additionalMessageFront + "]";

            return sReturn.ToString();
        }

    }
}

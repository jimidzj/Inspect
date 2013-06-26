using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GENLSYS.MES.DataContracts.Common
{
    public class FailInfo
    {
        public string ReasonCode { get; set; }
        public string ReasonCodeDesc { get; set; }
        public Decimal Quantity { get; set; }
        public string Comment { get; set; }
        public string MiscField1 { get; set; }
        public string MiscField2 { get; set; }
        public string MiscField3 { get; set; }
        public string MiscField4 { get; set; }
        public string MiscField5 { get; set; }
    }
}

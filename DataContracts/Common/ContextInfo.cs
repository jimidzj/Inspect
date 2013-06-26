using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.DataContracts.Common
{
    [Serializable]
    public class ContextInfo
    {
        public string CurrentUser { get; set; }
        public DateTime CurrentTime { get; set; }
        public string Shift { get; set; }
        public string SessionId { get; set; }
        public MES_ActionType Action { get; set; }
        public string BillRefId { get; set; }
        public string BCRId { get; set; }
        public string MiscValue1 { get; set; }
        public string MiscValue2 { get; set; }
        public string MiscValue3 { get; set; }
        public string MiscValue4 { get; set; }
        public string WorkGroup { get; set; }
    }
}

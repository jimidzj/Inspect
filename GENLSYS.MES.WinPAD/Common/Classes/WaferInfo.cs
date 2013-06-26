using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GENLSYS.MES.WinPAD.Common.Classes
{
    public class WaferInfo
    {
        public string componentid { get; set; }
        public string testprogram { get; set; }
        public string testprogramname {get;set;}
        public string prober { get; set; }
        public string probername { get; set; }
        public string disflag { get; set; }
        public string eqpsysid { get; set; }
        public string eqpname { get; set; }      
        public Int32  dspseqno { get; set; }
        public string dspsysid { get; set; }
        public string selectcontrol { get; set; }
        public string flowid { get; set; }
        public string priority { get; set; }
        public int stepuid { get; set; }
        public string lotsysid { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GENLSYS.MES.WinPAD.Common.Classes
{
    public class TagInfo
    {
        //resource id
        public string rsid { get; set; }

        //is required?
        public string isrq { get; set; }

        //max length
        public string maxl { get; set; }

        //update field?
        public string updt { get; set; }

        //db field name
        public string dbfd { get; set; }

        //db type
        public string dbty { get; set; }

        //column width, for layout
        public string colw { get; set; }
    }
}

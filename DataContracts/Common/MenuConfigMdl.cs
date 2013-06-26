using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GENLSYS.MES.DataContracts.Common
{
    public class MenuConfigMdl
    {
        public int MenuItem_Id { set; get; }
        public string Func_Id { set; get; }
        public string MenuItem_Name { set; get; }
        public string MenuItem_Desc { set; get; }
        public string Resource_Id { set; get; }
        public int Level_No { set; get; }
        public int Sort_No { set; get; }
        public int Parent_MenuItem { set; get; }
        public string Url { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using System.Data;
using GENLSYS.MES.Utility.Database;
using GENLSYS.MES.DataContracts.Common;

namespace GENLSYS.MES.Repositories.SYS
{
    public class AttributeTemplateDal : BaseDal
    {
        public AttributeTemplateDal(DBInstance dbi)     : base(dbi)
        {
            TableName = "tsysattrtplate";
        }
    }
}

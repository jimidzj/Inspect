using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Repositories.Common;
using GENLSYS.MES.Utility.Database;

namespace GENLSYS.MES.Repositories.Inspection.INP
{
    public class PackingRecDal:BaseDal
    {
        public PackingRecDal(DBInstance dbi)
            : base(dbi)
        {
            this.TableName = "tinppackingrec";
        }
    }
}

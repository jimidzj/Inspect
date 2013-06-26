using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GENLSYS.MES.DataContracts.Common
{
    public class EventCancelResult
    {
        public bool needtocanceleqp { get; set; }

        public EventCancelResult()
        {
            needtocanceleqp = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GENLSYS.MES.Utility
{
    public struct ReverserInfo
    {
        /**//// <summary>
        /// 比较的方向，如下：
        /// ASC：升序
        /// DESC：降序
        /// </summary>
        public enum Direction
        {
            ASC = 0,
            DESC,
        };

        public enum Target
        {
            CUSTOMER = 0,
            FORM,
            FIELD,
            SERVER,
        };

        public string name;
        public Direction direction;
        public Target target;

    }
}

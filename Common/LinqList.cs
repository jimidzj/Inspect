using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GENLSYS.MES.Common
{
    public class LinqList<T> : IEnumerable<T>, IEnumerable
    {
        IEnumerable items;

        public LinqList(IEnumerable items)
        {
            this.items = items;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (T item in items)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerable<T> ie = this;
            return ie.GetEnumerator();
        }
    }
}

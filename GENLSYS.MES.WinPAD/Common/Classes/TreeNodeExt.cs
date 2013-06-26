using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GENLSYS.MES.WinPAD.Common.Classes
{
    public class TreeNodeExt : TreeNode
    {
        public string Value { get; set; }
        public TreeNodeExt(string text,string value,bool isCheck)
        {
            this.Text = text;
            this.Value = value;
            this.Checked = isCheck;
        }
    }
}

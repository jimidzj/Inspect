using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GENLSYS.MES.Win.Common.Forms
{
    public partial class frmWaiting : Form
    {
        public frmWaiting()
        {
            InitializeComponent();
        }

        public void SetMessage(string msg)
        {
            this.lblMsg.Text = msg;            
        }
    }
}

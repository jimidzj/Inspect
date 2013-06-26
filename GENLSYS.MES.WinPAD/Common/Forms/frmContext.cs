using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GENLSYS.MES.WinPAD.Common.Forms
{
    public partial class frmContext : Form
    {
        public frmContext()
        {
            InitializeComponent();
        }

        public frmContext(string context)
        {
            InitializeComponent();

            this.txtMessage.Text = context;
        }

        private void frmContext_Load(object sender, EventArgs e)
        {

        }
    }
}

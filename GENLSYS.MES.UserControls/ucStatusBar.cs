using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.UserControls
{
    public partial class ucStatusBar : UserControl
    {
        public ucStatusBar()
        {
            InitializeComponent();
        }
        private void SetStatusBar()
        {
            if (this.Parent != null)
            {
                this.lblFormName.Text = this.Parent.Name;
            }
            else
            {
                this.lblFormName.Text = this.Name;
            }
            this.lblCurrentUser.Text = Function.GetCurrentUser();
            this.lblCurrentTime.Text = UtilDatetime.FormateDateTime1(Function.GetCurrentTime());
            timer1.Enabled = true;
        }

        public void ShowText1(string _text)
        {
            this.lblText1.Text = _text;
        }

        public void ShowText2(string _text)
        {
            this.lblText2.Text = _text;
        }

        public void SetCurrentUser(string user)
        {
            this.lblCurrentUser.Text = user;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblCurrentTime.Text = UtilDatetime.FormateDateTime1(Function.GetCurrentTime()); 
        }

        private void ucStatusBar_Load(object sender, EventArgs e)
        {
            SetStatusBar();
        }
    }
}

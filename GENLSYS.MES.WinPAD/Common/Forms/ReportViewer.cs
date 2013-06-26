using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GENLSYS.MES.WinPAD.Common.Classes
{
    public partial class ReportViewer : Form
    {
        private BaseForm baseForm;
       
        #region Constructs
        public ReportViewer()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
     
        #endregion

        #region Methods
        public void ShowWebReport(string url)
        {
             object   x   =   System.Reflection.Missing.Value;
             this.webBrowser1.Navigate(url);
        }

         public void ShowWebReport(string url,string user ,string pwd)
        {
             object   x   =   System.Reflection.Missing.Value;
             string httpHead = "Authorization: Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("WEB\\user" + ":" + "pass")) + System.Environment.NewLine;
             this.webBrowser1.Navigate(url, null, null, httpHead);
         }

        #endregion
    }
}

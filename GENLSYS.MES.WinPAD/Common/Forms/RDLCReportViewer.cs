using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Reporting.WinForms;

namespace GENLSYS.MES.WinPAD.Common.Forms
{
    public partial class RDLCReportViewer : Form
    {
        public RDLCReportViewer()
        {
            InitializeComponent();
        }

        private void RDLCReportViewer_Load(object sender, EventArgs e)
        {
            this.reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer.RefreshReport();
            
        }

        public void SetReportEmbeddedResource(string embeddedResource)
        {
            this.reportViewer.LocalReport.ReportEmbeddedResource = embeddedResource;
        }

        public void SetDataSource(Dictionary<string, DataTable> dic)
        {
            foreach (string key in dic.Keys)
            {
                this.reportViewer.LocalReport.DataSources.Add(new ReportDataSource(key, dic[key]));
            }
        }

        public void SetParameter(ReportParameter param)
        {
            this.reportViewer.LocalReport.SetParameters(param);
        }
    }
}

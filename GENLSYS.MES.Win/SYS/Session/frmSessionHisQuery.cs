using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common.Classes;

namespace GENLSYS.MES.Win.SYS.Session
{
    public partial class frmSessionHisQuery : Form
    {
        public Dictionary<string, object> QueryParameters { get; set; }
        private BaseForm baseForm;
        public frmSessionHisQuery()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }

        private void frmSessionHisQuery_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            DropDown.InitCMB_Shift_All(this.cmbShift);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryParameters = new Dictionary<string, object>();
            BuildQueryParameters(QueryParameters, this); ;
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void BuildQueryParameters(Dictionary<string, object> lstParameters, Control _parentControl)
        {
            foreach (Control ctrl in _parentControl.Controls)
            {
                if (ctrl.Tag != null)
                {
                    TagInfo tag = baseForm.ParseTag(ctrl.Tag);

                    if (tag.dbfd != null && tag.dbfd.Trim() != string.Empty)
                    {
                        object value = baseForm.GetControlValue(ctrl);
                        if (value != null && value.ToString() != string.Empty)
                        {
                            lstParameters.Add(tag.dbfd,value);
                        }
                        else
                        {
                            lstParameters.Add(tag.dbfd, "");
                        }
                    }
                }

                BuildQueryParameters(lstParameters, ctrl);
            }
        }

        
    }
}

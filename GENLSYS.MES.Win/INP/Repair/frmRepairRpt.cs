using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common.Classes;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Common;
using GENLSYS.MES.Win.Report;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.INP.Repair
{
    public partial class frmRepairRpt : Form
    {
        private BaseForm baseForm;

        #region Construct
        public frmRepairRpt()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events
        private void frmRepairRpt_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetRepairFailed(this.txtCustOrderNo.Text);
                if (dt.Rows.Count > 0)
                {
                    (new ExcelExport()).ExportFinalFailedRpt(dt);
                }
                else
                {
                    throw new Exception(UtilCulture.GetString("Msg.R00263"));
                }
            }
            catch (Exception ex)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        private DataTable GetRepairFailed(string custorderno)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParams = new List<MESParameterInfo>() { 
                            new MESParameterInfo(){ParamName="custorderno",ParamValue=custorderno},
                            new MESParameterInfo(){ParamName="reptype",ParamValue=MES_RepairType.RepairFail.ToString()}
                        };
                dt = client.GetRepairHisRecords(baseForm.CurrentContextInfo, lstParams.ToArray<MESParameterInfo>()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return dt;
        }
    }
}

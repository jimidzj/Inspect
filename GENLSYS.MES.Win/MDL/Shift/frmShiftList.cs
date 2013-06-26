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
using GENLSYS.MES.Utility;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Win.MDL.Shift
{
    public partial class frmShiftList : Form
    {
        private BaseForm baseForm;
        public frmShiftList()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            baseForm.CreateUltraGridColumns(this.gridShiftList, new string[] { "SHIFT", "SHIFTNAME", "STARTTIME", "ENDTIME", "REMARK", "LASTMODIFIEDUSER", "LASTMODIFIEDTIME" });
       
        }

        #region Event
        private void frmShiftList_Load(object sender, EventArgs e)
        {
            baseForm.SetQueryGridStyle(this.gridShiftList);
            baseForm.SetFace(this);

            ShowShiftList();
        }

        private void gridShiftList_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.gridShiftList.ActiveRow != null)
            {
                this.ucToolbarShiftList.SetToolbarWithSelection();
            }
            else
            {
                this.ucToolbarShiftList.SetToolbarWithoutSelection();
            }
        }

        private void ucToolbarShiftList_NewEventHandler(object sender, EventArgs e)
        {
            NewShift();
        }

        private void ucToolbarShiftList_EditEventHandler(object sender, EventArgs e)
        {
            UpdateShift();
        }

        private void ucToolbarShiftList_DeleteEventHandler(object sender, EventArgs e)
        {
            DeleteShift();
        }

        private void ucToolbarShiftList_ExportEventHandler(object sender, EventArgs e)
        {
            baseForm.ExportExcel(this.gridShiftList);
        }

        private void ucToolbarShiftList_ExitEventHandler(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ucToolbarShiftList_QueryEventHandler(object sender, EventArgs e)
        {
            ShowShiftList();
        }

        private void gridShiftList_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["starttime"].Format = "HH:mm ";
            e.Layout.Bands[0].Columns["endtime"].Format = "HH:mm ";
        }
        #endregion

        #region Method
        public void ShowShiftList()
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                baseForm.SetCursor();
                DataSet ds = client.GetShiftRecords(baseForm.CurrentContextInfo, (new List<MESParameterInfo>()).ToArray<MESParameterInfo>());
               
                this.gridShiftList.SetDataBinding(ds.Tables[0],"");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.ucToolbarShiftList.SetToolbarWithRows();
                }
                else
                {
                    this.ucToolbarShiftList.SetToolbarWithoutRows();
                }

                this.ucStatusBarShiftList.ShowText1(UtilCulture.GetString("Msg.R00006") + ": " + ds.Tables[0].Rows.Count.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
        }

        private void UpdateShift()
        {
            if (this.gridShiftList.ActiveRow != null)
            {
                frmShiftEdit frm = new frmShiftEdit();
                frm.Shift = this.gridShiftList.ActiveRow.Cells["SHIFT"].Value.ToString();
                frm.ShowDialog(this);
                ShowShiftList();
            }
        }

        private void NewShift()
        {
            frmShiftEdit frm = new frmShiftEdit();
            frm.ShowDialog(this);
            ShowShiftList();
        }

        private void DeleteShift()
        {

            if (this.gridShiftList.ActiveRow != null)
            {
                Dictionary<string, object> dir = new Dictionary<string, object>();
                dir.Add(UtilCulture.GetString("Label.R00394"), this.gridShiftList.ActiveRow.Cells["SHIFT"].Value.ToString());
                DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                MessageBoxButtons.OKCancel,
                                                                UtilCulture.GetString("Msg.R00004"),
                                                                dir);
                if (result == DialogResult.OK)
                {
                    baseForm.SetCursor();
                    wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
                    try
                    {
                        List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                        lstParameters.Add(new MESParameterInfo()
                        {
                            ParamName = "shift",
                            ParamValue = this.gridShiftList.ActiveRow.Cells["SHIFT"].Value.ToString(),
                            ParamType = "string"
                        });
                        client.DoDeleteShift(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                        ShowShiftList();
                        baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00003"));
                    }
                    catch (Exception ex)
                    {
                        MESMsgBox.ShowError(ExceptionParser.Parse(ex));
                    }
                    finally
                    {
                        baseForm.ResetCursor();
                        baseForm.CloseWCF(client);
                    }
                }
            }
        }
        #endregion 

      

       
    }
}

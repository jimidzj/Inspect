using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.UserControls.Common;

namespace GENLSYS.MES.UserControls
{
    public partial class ucAttribute : UserControl
    {
        public string AttributeID { get; set; }
        public string AttributeTemplateID { get; set; }
        public bool AllowToUpdate { get; set; }
        public Public_UpdateMode UpdateMode { get; set; }
        public MES_AttributeTemplate_UsedBy WhereUsed { get; set; }
        public ContextInfo CurrentContextInfo { get; set; }

        #region Construct
        public ucAttribute()
        {
            InitializeComponent();
            PublicFunction.CreateUltraGridColumns(this.grdAttribute, new string[] { "attributename","attributetype","valuetype","attributevalue","seqno"});
        }
        #endregion

        #region Events
        private void ucAttribute_Load(object sender, EventArgs e)
        {
            PublicFunction.SetQueryGridStyle(this.grdAttribute);

            this.grdAttribute.DisplayLayout.Bands[0].Columns["valuetype"].Hidden = true;
            this.grdAttribute.DisplayLayout.Bands[0].Columns["seqno"].Hidden = true;
            this.grdAttribute.DisplayLayout.Appearance.BackColor = Color.White;
        }

        private void grdAttribute_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdAttribute.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
        }
        #endregion

        #region Methods
        public void DoShow()
        {
            if (AttributeID == null || AttributeID.Trim() == string.Empty)
                GetAttributesFromTemplate();
            else
                GetAttributesByID();
        }

        #region Unused
        //public void DoSave()
        //{
        //    if (UpdateMode == Public_UpdateMode.Insert)
        //    {
        //        //get a new attribute Id
        //        this.AttributeID = Function.GetGUID();
        //    }

        //    List<tsysattributevalue> lstAttributea = GenerateAttributeList();
        //    wsUCSYS.IwsSYSClient client = new wsUCSYS.IwsSYSClient();

        //    try
        //    {
        //        if (UpdateMode == Public_UpdateMode.Update)
        //        {
        //            //delete old
        //            List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
        //            lstParameters.Add(new MESParameterInfo()
        //            {
        //                ParamName = "attributeid",
        //                ParamValue = AttributeID,
        //                ParamType = "string"
        //            });
                    
        //            client.DeleteMultiAttribute(lstParameters.ToArray<MESParameterInfo>());
        //        }
        //        client.InsertMultiAttribute(lstAttributea.ToArray<tsysattributevalue>());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        baseForm.CloseWCF(client);
        //    }
        //}

        //public void DoDelete()
        //{
        //    List<tsysattributevalue> lstAttributea = GenerateAttributeList();
        //    wsUCSYS.IwsSYSClient client = new wsUCSYS.IwsSYSClient();

        //    try
        //    {
        //        List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
        //        lstParameters.Add(new MESParameterInfo()
        //        {
        //            ParamName = "attributeid",
        //            ParamValue = AttributeID,
        //            ParamType = "string"
        //        });

        //        client.DeleteMultiAttribute(lstParameters.ToArray<MESParameterInfo>());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        baseForm.CloseWCF(client);
        //    }
        //}
        #endregion

        public void GetAttributesByID()
        {
            wsUCSYS.IwsSYSClient client = new wsUCSYS.IwsSYSClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "attributeid",
                    ParamValue = AttributeID,
                    ParamType = "string"
                });
                DataSet ds = client.GetAttributeRecords(CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                this.grdAttribute.SetDataBinding(ds.Tables[0], "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PublicFunction.CloseWCF(client);
            }
        }

        public List<tsysattributevalue> GenerateAttributeList()
        {
            try
            {
                List<tsysattributevalue> lstAttribute = new List<tsysattributevalue>();
                for (int i = 0; i < this.grdAttribute.Rows.Count; i++)
                {
                    tsysattributevalue attr = new tsysattributevalue();
                    attr.attributeid = AttributeID;
                    attr.attributename = this.grdAttribute.Rows[i].Cells["attributename"].Value.ToString();
                    attr.attributetype = this.grdAttribute.Rows[i].Cells["attributetype"].Value.ToString();
                    
                    if (this.grdAttribute.Rows[i].Cells["attributevalue"].Value != null)
                        attr.attributevalue = this.grdAttribute.Rows[i].Cells["attributevalue"].Value.ToString();
                    else
                        attr.attributevalue = string.Empty;

                    attr.seqno = Decimal.Parse(this.grdAttribute.Rows[i].Cells["seqno"].Value.ToString());
                    attr.usedby = this.WhereUsed.ToString();
                    attr.valuetype = this.grdAttribute.Rows[i].Cells["valuetype"].Value.ToString();
                    attr.lastmodifiedtime = Function.GetCurrentTime();
                    attr.lastmodifieduser = Function.GetCurrentUser();

                    lstAttribute.Add(attr);
                }

                return lstAttribute;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GenerateAttributeSQL()
        {

        }

        public void GetAttributesFromTemplate()
        {
            wsUCSYS.IwsSYSClient client = new wsUCSYS.IwsSYSClient();

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (AttributeTemplateID == null) AttributeTemplateID = string.Empty;

                if (AttributeTemplateID.Trim() == "*")
                {
                    List<MESParameterInfo> lstParams = new List<MESParameterInfo>();
                    lstParams.Add(new MESParameterInfo()
                    {
                        ParamName = "usedby",
                        ParamValue = WhereUsed.ToString(),
                        ParamType = "string"
                    });

                    lstParams.Add(new MESParameterInfo()
                    {
                        ParamName = "isdefault",
                        ParamValue = MES_Misc.Y.ToString(),
                        ParamType = "string"
                    });

                    tsysattrtplate template = client.GetSingleAttributeTemplate(CurrentContextInfo,lstParams.ToArray<MESParameterInfo>());

                    if (template != null)
                    {
                        AttributeTemplateID = template.attrtplatid;
                    }
                    else
                    {
                        AttributeTemplateID = string.Empty;
                    }

                }

                if (AttributeTemplateID.Trim() != string.Empty)
                {
                    List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                    lstParameters.Add(new MESParameterInfo()
                    {
                        ParamName = "attrtplatid",
                        ParamValue = AttributeTemplateID,
                        ParamType = "string"
                    });

                    DataSet ds = client.GetAttributeTemplateDetailRecords(CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());

                    this.grdAttribute.SetDataBinding(ds.Tables[0], "");
                }

                SetLayout();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                PublicFunction.CloseWCF(client);
            }
        }

        private void SetLayout()
        {
            if (!AllowToUpdate)
            {
                this.grdAttribute.DisplayLayout.Bands[0].Columns["attributevalue"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            else
            {
                this.grdAttribute.DisplayLayout.Bands[0].Columns["attributevalue"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                this.grdAttribute.DisplayLayout.Bands[0].Columns["attributevalue"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            }

            this.statusStrip1.Items[0].Text = "Attribute Id: " + (AttributeID==null?"":AttributeID.ToString());

            if (!AllowToUpdate)
                this.statusStrip1.Items[2].Text = "Mode: " + "Readonly";
            else
                this.statusStrip1.Items[2].Text = "Mode: " + "Writeable";
        }

        public bool ValidateData()
        {
            for (int i = 0; i < this.grdAttribute.Rows.Count; i++)
            {
                string value = this.grdAttribute.Rows[i].Cells["attributevalue"].Value.ToString();

                if (this.grdAttribute.Rows[i].Cells["valuetype"].Value.ToString() == "Number")
                {
                    if (!UtilValidator.IsNumber(value))
                    {
                        return false;
                    }
                }

                if (this.grdAttribute.Rows[i].Cells["valuetype"].Value.ToString() == "Date")
                {
                    if (!UtilValidator.IsDate(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        
    }
}

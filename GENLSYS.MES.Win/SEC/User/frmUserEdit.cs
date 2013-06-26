using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Common;
using GENLSYS.MES.Win.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;

namespace GENLSYS.MES.Win.SEC.User
{
    public partial class frmUserEdit : Form
    {
        public List<MESParameterInfo> PrimaryKeys { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode;

        #region Construct
        public frmUserEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();
        }
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSaveSingleObject();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserEdit_Load(object sender, EventArgs e)
        {
            baseForm.SetFace(this);
            SetLayout();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                DoShowSingleObject<tsecuser>(PrimaryKeys);
            }
            else
            {
                GetAvailableRoles();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.lstAvaiable.SelectedItems.Count < 1) return;

            for (int i = lstAvaiable.SelectedItems.Count - 1; i >= 0; i--)
            {
                lstSelected.Items.Add(lstAvaiable.SelectedItems[i]);
                lstAvaiable.Items.Remove(lstAvaiable.SelectedItems[i]);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.lstSelected.SelectedItems.Count < 1) return;

            for (int i = lstSelected.SelectedItems.Count - 1; i >= 0; i--)
            {
                lstAvaiable.Items.Add(lstSelected.SelectedItems[i]);
                lstSelected.Items.Remove(lstSelected.SelectedItems[i]);
            }
        }

        #endregion

        #region Methods
        private void SetLayout()
        {
            SetCombobox();

            if (UpdateMode == GENLSYS.MES.Common.Public_UpdateMode.Update)
            {
                this.txtUserId.Enabled = false;
            }
        }

        private void SetCombobox()
        {
            #region Container Type
            DropDown.InitCMB_Enums(this.cmbUserStatus, typeof(Security_UserStatus));
            DropDown.InitCMB_StaticValue(this.cmbUserType, MES_StaticValue_Type.SecurityUserType);
            DropDown.InitCMB_Employee_Valid(this.cmbEmployeeId);
            //DropDown.InitCMB_Printer(this.cmbPrinter);
            #endregion
        }

        public void DoSaveSingleObject()
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();

            try
            {
                baseForm.SetCursor();

                baseForm.ValidateData(this);
                tsecuser user = new tsecuser();

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                }
                else
                {
                    user = baseForm.OriginalObject as tsecuser;
                }

                string oldPassword = user.password;
                baseForm.CreateSingleObject<tsecuser>(user, this, UpdateMode);

                #region Get User Role
                List<tsecuserrole> lstUserRole = new List<tsecuserrole>();
                for (int i = 0; i < lstSelected.Items.Count; i++)
                {
                    tsecuserrole userRole = new tsecuserrole();
                    userRole.userid = txtUserId.Text;
                    userRole.roleid = lstSelected.Items[i].ToString();
                    baseForm.PrepareObject<tsecuserrole>(userRole, Public_UpdateMode.Update);

                    lstUserRole.Add(userRole);
                }

                #endregion

                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    //Encrypt password
                    user.password = UtilSecurity.EncryptPassword(user.password);

                    client.DoInsertUser(baseForm.CurrentContextInfo, user, lstUserRole.ToArray<tsecuserrole>());
                }

                if (UpdateMode == Public_UpdateMode.Update)
                {
                    if (user.password != oldPassword)
                    {
                        //Encrypt password
                        user.password = UtilSecurity.EncryptPassword(user.password);
                    }

                    client.DoUpdateUser(baseForm.CurrentContextInfo, user, lstUserRole.ToArray<tsecuserrole>());
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                else if (UpdateMode == Public_UpdateMode.Update)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));

                this.Close();

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

        public void DoShowSingleObject<T>(List<MESParameterInfo> lstParameters)
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();

            try
            {
                baseForm.SetCursor();

                tsecuser user = client.GetSingleUser(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
                baseForm.OriginalObject = user;
                baseForm.ShowSingleObjectToUI<tsecuser>(user, this);
                GetSelectedRoles(lstParameters);
                GetAvailableRoles();
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

        private void GetAvailableRoles()
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();

            try
            {
                baseForm.SetCursor();

                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>()
                {
                    new MESParameterInfo(){
                        ParamName="rolestatus",
                        ParamValue = Public_Status.Active.ToString(),
                        ParamType="string"
                    }

                };

                List<tsecrole> lstRoles = client.GetRoleList(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tsecrole>();

                for (int i=0;i<lstRoles.Count;i++)
                {
                    bool isSelected = false;

                    for (int j = 0; j < lstSelected.Items.Count; j++)
                    {
                        if (lstRoles[i].roleid == lstSelected.Items[j].ToString())
                        {
                            isSelected = true;
                        }
                    }

                    if (!isSelected)
                    {
                        lstAvaiable.Items.Add(lstRoles[i].roleid);
                    }
                }

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

        private void GetSelectedRoles(List<MESParameterInfo> lstParameters)
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();

            try
            {
                baseForm.SetCursor();

                List<tsecuserrole> lstRoles = client.GetUserRoleList(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tsecuserrole>();

                for (int i = 0; i < lstRoles.Count; i++)
                {
                    lstSelected.Items.Add(lstRoles[i].roleid);
                }

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
        #endregion

       
    }
}

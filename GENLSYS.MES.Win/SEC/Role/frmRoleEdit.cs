using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Win.Common;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Win.Common.Classes;
using Infragistics.Win.UltraWinGrid;

namespace GENLSYS.MES.Win.SEC.Role
{
    public partial class frmRoleEdit : Form
    {
        public string RoleId { get; set; }
        private BaseForm baseForm;
        public Public_UpdateMode UpdateMode { get; set; }

        #region Construct
        public frmRoleEdit()
        {
            InitializeComponent();
            baseForm = new BaseForm();
            //baseForm.CreateUltraGridColumns(this.gridEqpGroup, new string[] {"ROLEEQPGROUP", "EQPGROUP", "EQPGROUPDESC"});
        }
        #endregion

        #region Event
        private void frmRoleEdit_Load(object sender, EventArgs e)
        {            
            baseForm.SetFace(this);
            //baseForm.SetQueryGridStyle(this.gridEqpGroup);
            
            if (RoleId != null)
            {
                UpdateMode = Public_UpdateMode.Update;
            }
            else
            {
                UpdateMode = Public_UpdateMode.Insert;
            }
            SetLayout();


            baseForm.SetCursor();
            if (UpdateMode == Public_UpdateMode.Update)
            {
                tsecrole role = GetSingleRole(RoleId);
                baseForm.OriginalObject = role;
                baseForm.ShowSingleObjectToUI<tsecrole>(role, this);
            }
            else
            {
                baseForm.setDefaultValue(this);
            }
            InitFunctionTree();

            //InitStepTree();

            //InitEqpGroupGrid();
            baseForm.ResetCursor();
                        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
               

        private void treeStep_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                CheckAllChildNodes(e.Node, e.Node.Checked);

                //选中父节点 
                bool bol = true;
                if (e.Node.Parent != null)
                {
                    for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                    {
                        if (!e.Node.Parent.Nodes[i].Checked)
                            bol = false;
                    }
                    if (bol)
                    {
                        e.Node.Parent.Checked = bol;
                    }
                }
            } 
        }

        private void treeFunction_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                CheckAllChildNodes(e.Node, e.Node.Checked);

                //选中父节点 
                bool bol = true;
                if (e.Node.Parent != null)
                {
                    for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                    {
                        if (!e.Node.Parent.Nodes[i].Checked)
                            bol = false;
                    }
                    if (bol)
                    {
                        e.Node.Parent.Checked = bol;
                    }
                }
            } 
        }


        private void gridEqpGroup_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Bands[0].Columns["ROLEEQPGROUP"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.HeaderCheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
            e.Layout.Override.HeaderCheckBoxAlignment = HeaderCheckBoxAlignment.Center;

            UltraGridColumn column = e.Layout.Bands[0].Columns["ROLEEQPGROUP"];
            column.Header.Caption = "";
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            column.Editor.DataFilter = new CheckEditorStringDataFilter();
            column.Width = 40;

            e.Layout.Bands[0].Columns["EQPGROUP"].SortIndicator = SortIndicator.Ascending;
            
        }
        #endregion


        #region Mothed
        private void SetLayout()
        {
            SetCombobox();

            if (UpdateMode == Public_UpdateMode.Update)
            {
                this.txtRoleId.Enabled = false;
            }
        }

        private void SetCombobox()
        {
            DropDown.InitCMB_Enums(this.cmbRoleStatus, typeof(Public_ActiveFlag));
        }

        private void DoSave()
        {
            try
            {
                baseForm.SetCursor();
                baseForm.ValidateData(this);

                tsecrole role = new tsecrole();
                if (UpdateMode == Public_UpdateMode.Update)
                {
                    role = baseForm.OriginalObject as tsecrole;
                }
                baseForm.CreateSingleObject<tsecrole>(role, this, UpdateMode);


                List<tsecrolefunction> lstRoleFunctions = GetRoleFunctions(role.roleid);
                List<tsecrolestep> lstRoleSteps = new List<tsecrolestep>() { };//GetRoleSteps(role.roleid);
                List<tsecroleeqpgroup> lstRoleEqpGroups = new List<tsecroleeqpgroup>() { };// GetRoleEqpGroups(role.roleid);


                if (UpdateMode == Public_UpdateMode.Insert)
                {
                    InsertRole(role, lstRoleFunctions, lstRoleSteps, lstRoleEqpGroups);
                }
                else
                {
                    UpdateRole(role, lstRoleFunctions, lstRoleSteps, lstRoleEqpGroups);
                }

                if (UpdateMode == Public_UpdateMode.Insert)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00001"));
                else if (UpdateMode == Public_UpdateMode.Update)
                    baseForm.CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, UtilCulture.GetString("Msg.R00002"));

                this.Dispose();
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
            }
            finally
            {
                baseForm.ResetCursor();
            }

        }

        private tsecrole GetSingleRole(string _roleId)
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            tsecrole result = null;
            try
            {
                baseForm.SetCursor();
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "roleid",
                    ParamValue = _roleId,
                    ParamType = "string"
                });
                result = client.GetSingleRole(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
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
            return result;
        }

        private DataSet GetRoleEqpGroup()
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            DataSet result = null;
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                result = client.GetRoleEqpGroupRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return result;
        }

        private DataSet GetRoleEqpGroupByRoleId(string _roleId)
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            DataSet result = null;
            try
            {
                result = client.GetRoleEqpGroupRecordsByRoleId(baseForm.CurrentContextInfo, _roleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return result;
        }

        private DataSet GetRoleFunction()
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            DataSet result = null;
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "functype",
                    ParamValue = MES_FuncType.Menu.ToString(),
                    ParamType = "string"
                });
                result = client.GetRoleFunctionRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return result;
        }

        private DataSet GetRoleFunctionByRoleId(string _roleId)
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            DataSet result = null;
            try
            {
                result = client.GetRoleFunctionRecordsByRoleId(baseForm.CurrentContextInfo, _roleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return result;
        }

        //private tprpstep[] GetStepByAreaSysId(string _areaSysId)
        //{
        //    wsPRP.IwsPRPClient client = new wsPRP.IwsPRPClient();
        //    tprpstep[] result = null;
        //    try
        //    {
        //        List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
        //        lstParameters.Add(new MESParameterInfo()
        //        {
        //            ParamName = "areasysid",
        //            ParamValue = _areaSysId,
        //            ParamType = "string"
        //        });
        //        result = client.GetStepList(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        baseForm.CloseWCF(client);
        //    }
        //    return result;
        //}

        private tsecrolestep[] GetRoleStepByRoleId(string _roleId)
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            tsecrolestep[] result = null;
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "roleid",
                    ParamValue = _roleId,
                    ParamType = "string"
                });
                result = client.GetRoleStepList(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
            return result;
        }

        private void InitFunctionTree()
        {
            DataTable dt = null;
            if (UpdateMode == Public_UpdateMode.Update)
            {
                dt = GetRoleFunctionByRoleId(RoleId).Tables[0];
            }
            else
            {
                dt = GetRoleFunction().Tables[0];
            }
            foreach (DataRow row in dt.Select("PARENTFUNCID is null", "FUNCID ASC"))
            {
                TreeNodeExt node = null;
                if (row["ROLEFUNCTION"].ToString().Equals(MES_Misc.Y.ToString()))
                {
                    node = new TreeNodeExt(row["FUNCDESC"].ToString(), row["FUNCID"].ToString(), true);
                }
                else
                {
                    node = new TreeNodeExt(row["FUNCDESC"].ToString(), row["FUNCID"].ToString(), false);
                }
                InitFunctionNode(node, dt);
                this.treeFunction.Nodes.Add(node);
            }
        }

        private void InitFunctionNode(TreeNodeExt parentNode,DataTable dt)
        {
            foreach (DataRow row in dt.Select("PARENTFUNCID = '"+parentNode.Value+"'", "FUNCID ASC"))
            {
                TreeNodeExt node = null;
                if (row["ROLEFUNCTION"].ToString().Equals(MES_Misc.Y.ToString()))
                {
                    node = new TreeNodeExt(row["FUNCDESC"].ToString(), row["FUNCID"].ToString(), true);
                }
                else
                {
                    node = new TreeNodeExt(row["FUNCDESC"].ToString(), row["FUNCID"].ToString(), false);
                }
                InitFunctionNode(node,dt);
                parentNode.Nodes.Add(node);
            }
        }

        //private void InitEqpGroupGrid()
        //{
        //    if (UpdateMode == Public_UpdateMode.Update)
        //    {
        //        this.gridEqpGroup.SetDataBinding(GetRoleEqpGroupByRoleId(RoleId).Tables[0], "");
        //    }
        //    else
        //    {
        //        this.gridEqpGroup.SetDataBinding(GetRoleEqpGroup().Tables[0], "");
        //    }
            
        //}

        private List<tsecrolefunction> GetRoleFunctions(string _roleId)
        {
            List<tsecrolefunction> result = new List<tsecrolefunction>();
            foreach (TreeNodeExt node in this.treeFunction.Nodes)
            {
                if (node.Checked)
                {
                    tsecrolefunction rolefunction = new tsecrolefunction();
                    rolefunction.roleid = _roleId;
                    rolefunction.funcid =node.Value.ToString();
                    rolefunction.permis = "Allow";
                    rolefunction.createduser = GENLSYS.MES.Common.Function.GetCurrentUser();
                    rolefunction.createdtime = GENLSYS.MES.Common.Function.GetCurrentTime();
                    rolefunction.lastmodifieduser = GENLSYS.MES.Common.Function.GetCurrentUser();
                    rolefunction.lastmodifiedtime = GENLSYS.MES.Common.Function.GetCurrentTime();
                    result.Add(rolefunction);
                }
                GetRoleFunctionsNode(result, node, _roleId);
            }
            return result;
        }

        private void GetRoleFunctionsNode(List<tsecrolefunction> list, TreeNodeExt parentNode, string _roleId)
        {
            foreach (TreeNodeExt node in parentNode.Nodes)
            {
                if (node.Checked)
                {
                    tsecrolefunction rolefunction = new tsecrolefunction();
                    rolefunction.roleid = _roleId;
                    rolefunction.funcid = node.Value.ToString();
                    rolefunction.permis = "Allow";
                    rolefunction.createduser = GENLSYS.MES.Common.Function.GetCurrentUser();
                    rolefunction.createdtime = GENLSYS.MES.Common.Function.GetCurrentTime();
                    rolefunction.lastmodifieduser = GENLSYS.MES.Common.Function.GetCurrentUser();
                    rolefunction.lastmodifiedtime = GENLSYS.MES.Common.Function.GetCurrentTime();
                    list.Add(rolefunction);
                }
                GetRoleFunctionsNode(list,node,_roleId);
            }
        }

        //private List<tsecroleeqpgroup> GetRoleEqpGroups(string _roleId)
        //{
        //    List<tsecroleeqpgroup> result = new List<tsecroleeqpgroup>();
        //    foreach (UltraGridRow row in this.gridEqpGroup.Rows)
        //    {
        //        if (row.Cells["ROLEEQPGROUP"].Value.ToString().Equals(MES_Misc.Y.ToString()))
        //        {
        //            tsecroleeqpgroup roleeqpgroup= new tsecroleeqpgroup();
        //            roleeqpgroup.roleid = _roleId;
        //            roleeqpgroup.eqpgroup = row.Cells["EQPGROUP"].Value.ToString();
        //            roleeqpgroup.lastmodifieduser = GENLSYS.MES.Common.Function.GetCurrentUser();
        //            roleeqpgroup.lastmodifiedtime = GENLSYS.MES.Common.Function.GetCurrentTime();
        //            result.Add(roleeqpgroup);
        //        }
        //    }
        //    return result;
        //}

        //private void InitStepTree()
        //{
        //    tsecrolestep[] rolesteps=null;
        //    if (UpdateMode == Public_UpdateMode.Update)
        //    {
        //        rolesteps = GetRoleStepByRoleId(RoleId);
        //    }
        //    TreeNodeExt root = new TreeNodeExt("Fab","root",false);
        //    foreach (tmdlarea area in GetAreaList())
        //    {
        //        TreeNodeExt areaNode = new TreeNodeExt(area.areaid, area.areasysid, false);
        //        foreach (tprpstep step in GetStepByAreaSysId(area.areasysid))
        //        {
        //            bool isCheck = false;
        //            if (rolesteps != null)
        //            {
        //                isCheck = ContainsStep(rolesteps, step.stepsysid);
        //            }
        //            TreeNodeExt stepNode = new TreeNodeExt(step.stepid, step.stepsysid, isCheck);
        //            areaNode.Nodes.Add(stepNode);
        //        }
        //        root.Nodes.Add(areaNode);
        //    }
        //    this.treeStep.Nodes.Add(root);
        //    CheckParentNode(root);
        //    this.treeStep.ExpandAll();
            
        //}

        //private bool ContainsStep(tsecrolestep[] _roleSteps,string stepSysId)
        //{
        //    bool result = false;
        //    foreach (tsecrolestep rolestep in _roleSteps)
        //    {
        //        if (rolestep.stepid.Trim().Equals(stepSysId.Trim()))
        //        {
        //            result = true;
        //            break;
        //        }
        //    }
        //    return result;
        //}

        //private List<tsecrolestep> GetRoleSteps(string _roleId)
        //{
        //    List<tsecrolestep> result = new List<tsecrolestep>();
        //    foreach (TreeNodeExt areaNode in this.treeStep.Nodes[0].Nodes)
        //    {
        //        if (areaNode.Nodes.Count > 0)
        //        {
        //            foreach (TreeNodeExt stepNode in areaNode.Nodes)
        //            {
        //                if (stepNode.Checked)
        //                {
        //                    tsecrolestep rolestep = new tsecrolestep();
        //                    rolestep.roleid = _roleId;
        //                    rolestep.areaid = areaNode.Value;
        //                    rolestep.stepid = stepNode.Value;
        //                    rolestep.createduser = GENLSYS.MES.Common.Function.GetCurrentUser();
        //                    rolestep.createdtime = GENLSYS.MES.Common.Function.GetCurrentTime();
        //                    rolestep.lastmodifieduser = GENLSYS.MES.Common.Function.GetCurrentUser();
        //                    rolestep.lastmodifiedtime = GENLSYS.MES.Common.Function.GetCurrentTime();
        //                    result.Add(rolestep);
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}

        public void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void CheckParentNode(TreeNode treeNode)
        {
            if (treeNode.Nodes.Count > 0)
            {
                bool bol = true;
                foreach (TreeNode node in treeNode.Nodes)
                {
                    if (!node.Checked && node.Nodes.Count > 0)
                    {
                        CheckParentNode(node);
                    }
                    if (!node.Checked) bol = false;
                }
                treeNode.Checked = bol;
            }
        }


        private void InsertRole(tsecrole role, List<tsecrolefunction> lstRoleFunctions, List<tsecrolestep> lstRoleSteps, List<tsecroleeqpgroup> lstRoleEqpGroups)
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            try
            {
                client.DoInsertRole(baseForm.CurrentContextInfo, role, lstRoleFunctions.ToArray<tsecrolefunction>(), lstRoleSteps.ToArray<tsecrolestep>(), lstRoleEqpGroups.ToArray<tsecroleeqpgroup>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
        }

        private void UpdateRole(tsecrole role, List<tsecrolefunction> lstRoleFunctions, List<tsecrolestep> lstRoleSteps, List<tsecroleeqpgroup> lstRoleEqpGroups)
        {
            wsSEC.IwsSECClient client = new wsSEC.IwsSECClient();
            try
            {
                client.DoUpdateRole(baseForm.CurrentContextInfo, role, lstRoleFunctions.ToArray<tsecrolefunction>(), lstRoleSteps.ToArray<tsecrolestep>(),lstRoleEqpGroups.ToArray<tsecroleeqpgroup>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baseForm.CloseWCF(client);
            }
        }  

        #endregion

        
       

        

       
    }
}

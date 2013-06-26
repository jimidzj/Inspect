using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.DataContracts.Common;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using GENLSYS.MES.Common;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.WinPAD.Common.Classes
{
    public class MenuConfig
    {
        BaseForm baseForm = null;
        public MenuConfig()
        {
            baseForm = new BaseForm();
        }

        public void CreateMenu(MenuStrip menuStrip, MES_MenuType menuType, EventHandler handler)
        {
            List<tsysmenuconfig> lstAllMenu = GetAllMenu();
            List<tsysmenuconfig> menus = GetTopMenuList(lstAllMenu, menuType.ToString()).ToList();
            Reverser<tsysmenuconfig> reverser = new Reverser<tsysmenuconfig>(typeof(tsysmenuconfig), "sortno", ReverserInfo.Direction.DESC);
            menus.Sort(reverser);
            foreach (tsysmenuconfig menuconfig in menus)
            {
                ToolStripMenuItem topMenu = new ToolStripMenuItem();
                topMenu.Name = menuconfig.menuitemid;
                if (menuconfig.resourceid != null && !menuconfig.resourceid.Trim().Equals(""))
                {
                    topMenu.Text = UtilCulture.GetString(menuconfig.resourceid);
                }
                else
                {
                    topMenu.Text = menuconfig.menuitemname;
                }
                if (menuconfig.menuicon != null && !menuconfig.menuicon.Trim().Equals(""))
                {
                    topMenu.Image = (System.Drawing.Image)global::GENLSYS.MES.WinPAD.Properties.Resources.ResourceManager.GetObject(menuconfig.menuicon);
                }
                topMenu.Enabled = CheckFunctionPrivilege(menuconfig.funcid, Parameter.USER_FUNCTIONS);
                if (topMenu.Enabled == true)
                {
                    CreateSubMenu(lstAllMenu, topMenu, menuType, handler);
                }
                menuStrip.Items.Insert(0, topMenu);
            }
        }

        public void CreateMenu(ContextMenuStrip menuStrip, MES_MenuType menuType, EventHandler handler)
        {

            List<tsysmenuconfig> lstAllMenu = GetAllMenu();
            List<tsysmenuconfig> menus = GetTopMenuList(lstAllMenu, menuType.ToString()).ToList();
            Reverser<tsysmenuconfig> reverser = new Reverser<tsysmenuconfig>(typeof(tsysmenuconfig), "sortno", ReverserInfo.Direction.ASC);
            menus.Sort(reverser);
            bool separatorFlag = false;
            foreach (tsysmenuconfig menuconfig in menus)
            {
                if (menuconfig.menuitemname.Trim().Equals("-"))
                {
                    if (!separatorFlag)
                    {
                        ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
                        toolStripSeparator.Name = menuconfig.menuitemid;
                        menuStrip.Items.Add(toolStripSeparator);
                        separatorFlag = true;
                    }
                }
                else
                {
                    if (CheckFunctionPrivilege(menuconfig.funcid, Parameter.USER_FUNCTIONS))
                    {
                        ToolStripMenuItem topMenu = new ToolStripMenuItem();
                        topMenu.Name = menuconfig.menuitemid;
                        if (menuconfig.resourceid != null && !menuconfig.resourceid.Trim().Equals(""))
                        {
                            topMenu.Text = UtilCulture.GetString(menuconfig.resourceid);
                        }
                        else
                        {
                            topMenu.Text = menuconfig.menuitemname;
                        }
                        if (menuconfig.menuitemurl != null && !menuconfig.menuitemurl.Trim().Equals(""))
                        {
                            topMenu.Tag = menuconfig.menuitemurl;
                            topMenu.Click += handler;
                        }
                        if (menuconfig.menuicon != null && !menuconfig.menuicon.Trim().Equals(""))
                        {
                            topMenu.Image = (System.Drawing.Image)global::GENLSYS.MES.WinPAD.Properties.Resources.ResourceManager.GetObject(menuconfig.menuicon);
                        }
                        //topMenu.Enabled = CheckFunctionPrivilege(menuconfig.funcid, Parameter.USER_FUNCTIONS);
                        //if (topMenu.Enabled == true)
                        //{
                        //    CreateSubMenu(lstAllMenu, topMenu, menuType, handler);
                        //}
                        CreateSubMenu(lstAllMenu, topMenu, menuType, handler);
                        menuStrip.Items.Add(topMenu);
                        separatorFlag = false;
                    }
                }
            }
        }

        private void CreateSubMenu(List<tsysmenuconfig> lstAllMenu, ToolStripMenuItem parentMenu, MES_MenuType menuType, EventHandler handler)
        {
            List<tsysmenuconfig> menus = GetSubMenuList(lstAllMenu, parentMenu.Name, menuType.ToString()).ToList();
            Reverser<tsysmenuconfig> reverser = new Reverser<tsysmenuconfig>(typeof(tsysmenuconfig), "sortno", ReverserInfo.Direction.ASC);
            menus.Sort(reverser);
            bool separatorFlag = false;
            foreach (tsysmenuconfig menuconfig in menus)
            {
                if (menuconfig.menuitemname.Trim().Equals("-"))
                {
                    if (!separatorFlag)
                    {
                        ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
                        toolStripSeparator.Name = menuconfig.menuitemid;
                        parentMenu.DropDownItems.Add(toolStripSeparator);
                        separatorFlag = true;
                    }
                }
                else
                {
                    if (CheckFunctionPrivilege(menuconfig.funcid, Parameter.USER_FUNCTIONS))
                    {
                        ToolStripMenuItem menu = new ToolStripMenuItem();
                        menu.Name = menuconfig.menuitemid;

                        if (menuconfig.resourceid != null && !menuconfig.resourceid.Trim().Equals(""))
                        {
                            menu.Text = UtilCulture.GetString(menuconfig.resourceid);
                        }
                        else
                        {
                            menu.Text = menuconfig.menuitemname;
                        }
                        if (menuconfig.menuicon != null && !menuconfig.menuicon.Trim().Equals(""))
                        {
                            menu.Image = (System.Drawing.Image)global::GENLSYS.MES.WinPAD.Properties.Resources.ResourceManager.GetObject(menuconfig.menuicon);
                        }
                        if (menuconfig.menuitemurl != null && !menuconfig.menuitemurl.Trim().Equals(""))
                        {
                            menu.Tag = menuconfig.menuitemurl;
                            menu.Click += handler;
                        }
                        //menu.Enabled = CheckFunctionPrivilege(menuconfig.funcid, Parameter.USER_FUNCTIONS);
                        //if (menu.Enabled == true)
                        //{
                        //    CreateSubMenu(lstAllMenu, menu, menuType, handler);
                        //}
                        CreateSubMenu(lstAllMenu, menu, menuType, handler);
                        parentMenu.DropDownItems.Add(menu);
                        separatorFlag = false;
                    }
                }
            }
        }

        public tsysmenuconfig[] GetTopMenuList(List<tsysmenuconfig> lstAllMenu, string menutype)
        {
            var q = (from p in lstAllMenu
                     where p.menutype == menutype
                     & p.parentmenuitemid == null
                     select p).ToArray<tsysmenuconfig>();

            return q;
        }

        public tsysmenuconfig[] GetSubMenuList(List<tsysmenuconfig> lstAllMenu, string parentmenuid, string menutype)
        {
            var q = (from p in lstAllMenu
                     where p.menutype == menutype
                     & p.parentmenuitemid == parentmenuid
                     select p).ToArray<tsysmenuconfig>();

            return q;
        }

        public List<tsysmenuconfig> GetAllMenu()
        {
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();

                BaseForm baseForm = new BaseForm();
                return client.GetMenuConfigList(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tsysmenuconfig>();
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

        public bool CheckFunctionPrivilege(string funcid, DataTable userFunctions)
        {
            bool result = false;
            foreach (DataRow row in userFunctions.Rows)
            {
                if (funcid.Trim().Equals(row["funcid"].ToString().Trim()))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool CheckStepPrivilege(string areasysid, string stepsysid, DataTable userSteps)
        {
            bool result = false;
            foreach (DataRow row in userSteps.Rows)
            {
                if (areasysid.Trim().Equals(row["areasysid"].ToString().Trim()) && stepsysid.Trim().Equals(row["stepsysid"].ToString().Trim()))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static Form CreateFormInstance(string typeName)
        {
            Form form = null;
            Type type = null;
            try
            {
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    type = assembly.GetType(typeName);
                    if (type != null)
                    {
                        break;
                    }
                }

                if (type != null)
                {
                    form = (Form)type.Assembly.CreateInstance(typeName);
                }
                return form;
            }
            catch (Exception)
            {  //--------
                return null;
            }
           
            /*catch (Exception ex)
            { 
                thr
            }*/
        }
    }
}

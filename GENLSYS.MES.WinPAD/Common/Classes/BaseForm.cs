using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Utility;
using Newtonsoft.Json;
using System.Data;
using GENLSYS.MES.DataContracts;
using Infragistics.Win.UltraMessageBox;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using GENLSYS.MES.UserControls;
using System.Drawing;
using GENLSYS.MES.WinPAD.Common.Forms;
using System.Resources;

namespace GENLSYS.MES.WinPAD.Common.Classes
{
    public class BaseForm : BaseWCF
    {
        #region Variables
        //public Public_UpdateMode UpdateMode { get; set; }
        public object OriginalObject { get; set; }
        #endregion

        #region Construct
        public BaseForm()
        {
            SetCurrentContextInfo();
        }
        #endregion

        #region Layout
        public void SetFace(Form _form)
        {
            SetFace(_form, true);
        }

        public void SetFace(Form _form, bool isDoPrivilege)
        {
            #region Set Form
            TagInfo tag = ParseTag(_form.Tag);
           // _form.Text = UtilCulture.GetString(tag.rsid);
           //  _form.ShowInTaskbar = false;
           // _form.BackColor = System.Drawing.Color.FromName("InactiveCaptionText");
           // load icon
            _form.Icon = GENLSYS.MES.WinPAD.Properties.Resources.MES_Logo3;
            #endregion

            //Set resource
            SetControlsFormat(_form);
            if (isDoPrivilege)
            {
                DoPrivilege(_form.Name.ToLower(), _form);
            }
        }

        public void SetControlsFormat(Control _parentControl)
        {
            foreach (Control ctrl in _parentControl.Controls)
            {
                if (ctrl.GetType().FullName == "System.Windows.Forms.TabControl")
                {
                    System.Windows.Forms.TabControl tabcontrol = ctrl as System.Windows.Forms.TabControl;
                    LoadTabControlPages(tabcontrol);
                }

                if (ctrl.GetType().FullName == "GENLSYS.MES.UserControls.ucBanner")
                {
                    continue;
                }

                if (ctrl.Tag != null)
                {
                    TagInfo tag = ParseTag(ctrl.Tag);

                    if (ctrl.GetType().FullName == "System.Windows.Forms.Button")
                    {
                        ctrl.Height = 23;
                        ctrl.Width = 75;
                    }

                    if (ctrl.GetType().FullName == "System.Windows.Forms.NumericUpDown")
                    {
                        System.Windows.Forms.NumericUpDown nud = ctrl as System.Windows.Forms.NumericUpDown;
                        nud.ThousandsSeparator = true;
                        nud.Minimum = 0;
                        nud.Maximum = 1000000000;
                    }

                    if (ctrl.GetType().FullName == "System.Windows.Forms.ToolStrip")
                    {
                        System.Windows.Forms.ToolStrip tool = ctrl as System.Windows.Forms.ToolStrip;
                        for (int i = 0; i < tool.Items.Count; i++)
                        {
                            if (tool.Items[i].Tag != null)
                            {
                                TagInfo toolTag = ParseTag(tool.Items[i].Tag);
                                if (toolTag.rsid != null && toolTag.rsid.Trim() != string.Empty)
                                {
                                    tool.Items[i].Text = UtilCulture.GetString(toolTag.rsid);
                                }
                            }
                        }
                    }

                    //set resource
                    if (tag.rsid != null && tag.rsid.Trim() != string.Empty)
                    {
                        if (ctrl.GetType().FullName == "System.Windows.Forms.Label" ||
                            ctrl.GetType().FullName == "System.Windows.Forms.Button" ||
                            ctrl.GetType().FullName == "System.Windows.Forms.CheckBox" ||
                            ctrl.GetType().FullName == "System.Windows.Forms.RadioButton")
                            ctrl.Text = UtilCulture.GetString(tag.rsid);

                        if (ctrl.GetType().FullName == "System.Windows.Forms.TabControl")
                        {
                            ctrl.Text = UtilCulture.GetString(tag.rsid);
                            //ctrl.BackColor = System.Drawing.Color.FromName("InactiveCaptionText");
                        }

                        if (ctrl.GetType().FullName == "System.Windows.Forms.TabPage")
                        {
                            //ctrl.BackColor = System.Drawing.Color.FromName("InactiveCaptionText");
                            ctrl.Text = UtilCulture.GetString(tag.rsid);
                        }

                        if (ctrl.GetType().FullName == "GENLSYS.MES.UserControls.ucAttribute")
                        {
                            GENLSYS.MES.UserControls.ucAttribute ucAttribute = ctrl as GENLSYS.MES.UserControls.ucAttribute;
                            ucAttribute.BorderStyle = BorderStyle.None;
                        }

                        if (ctrl.GetType().FullName == "System.Windows.Forms.GroupBox")
                        {
                            //ctrl.BackColor = System.Drawing.Color.FromName("InactiveCaptionText");
                            ctrl.Text = UtilCulture.GetString(tag.rsid);
                        }

                        if (ctrl.GetType().FullName == "System.Windows.Forms.DataGridView")
                        {
                            System.Windows.Forms.DataGridView grid = ctrl as System.Windows.Forms.DataGridView;
                            SetDataGridResource(grid);
                            grid.BackgroundColor = System.Drawing.Color.FromName("InactiveCaptionText");
                        }
                        if (ctrl.GetType().FullName == "Infragistics.Win.UltraWinGrid.UltraGrid")
                        {
                            Infragistics.Win.UltraWinGrid.UltraGrid grid = ctrl as Infragistics.Win.UltraWinGrid.UltraGrid;
                            SetDataGridResource(grid);
                        }
                        if (ctrl.GetType().FullName == "System.Windows.Forms.Panel")
                        {
                            //ctrl.BackColor = System.Drawing.Color.FromName("InactiveCaptionText");
                        }
                    }

                    //set required
                    if (tag.isrq != null && tag.isrq.ToUpper() == "Y")
                    {
                        if (ctrl.GetType().FullName == "System.Windows.Forms.Label")
                        {
                            //ctrl.Text += "(*)";
                            ctrl.ForeColor = System.Drawing.Color.Red;
                        }
                    }

                    //set max length
                    if (tag.maxl != null)
                    {
                        if (ctrl.GetType().FullName == "System.Windows.Forms.TextBox")
                        {
                            (ctrl as System.Windows.Forms.TextBox).MaxLength = Int16.Parse(tag.maxl);
                        }
                    }
                }
                else
                {
                    try
                    {
                        if (ctrl.GetType().FullName == "System.Windows.Forms.Panel")
                        {
                            //ctrl.BackColor = System.Drawing.Color.FromName("InactiveCaptionText");
                        }
                    }
                    catch 
                    { 
                    }
                }

                SetControlsFormat(ctrl);
            }
        }

        private void LoadTabControlPages(System.Windows.Forms.TabControl ctrl)
        {
            TabPage defaultTab = ctrl.SelectedTab;
            foreach (TabPage tab in ctrl.TabPages)
            {
                ctrl.SelectedTab = tab;
            }
            ctrl.SelectedTab = defaultTab;
        }

        private void SetDataGridResource(System.Windows.Forms.DataGridView ctrl)
        {
            if (ctrl.Tag == null) return;

            string[] arrTags = ctrl.Tag.ToString().Split('|');

            for (int i = 0; i < arrTags.Length; i++)
            {
                TagInfo tag = ParseTag(arrTags[i]);

                ctrl.Columns[i].HeaderText = UtilCulture.GetString(tag.rsid);
            }
        }

        public void SetDataGridResource(Infragistics.Win.UltraWinGrid.UltraGrid ctrl)
        {
            ctrl.DisplayLayout.Bands[0].Override.SelectedRowAppearance.BackColor = Color.Cornsilk;//Color.Teal;
            ctrl.DisplayLayout.Bands[0].Override.SelectedRowAppearance.BackColor2 = Color.Cornsilk;
            ctrl.DisplayLayout.Bands[0].Override.SelectedRowAppearance.ForeColor = Color.Black;

            ctrl.DisplayLayout.Bands[0].Override.ActiveRowAppearance.BackColor = Color.Cornsilk;
            ctrl.DisplayLayout.Bands[0].Override.ActiveRowAppearance.BackColor2 = Color.Cornsilk;
            ctrl.DisplayLayout.Bands[0].Override.ActiveRowAppearance.ForeColor = Color.Black;
            if (ctrl.Tag == null) return;

            string[] arrTags = ctrl.Tag.ToString().Split('|');

            for (int i = 0; i < arrTags.Length; i++)
            {
                TagInfo tag = ParseTag(arrTags[i]);

                ctrl.DisplayLayout.Bands[0].Columns[i].Header.Caption = UtilCulture.GetString(tag.rsid);
                ctrl.DisplayLayout.Bands[0].Columns[i].Header.Appearance.BackColor = Color.PowderBlue;
                ctrl.DisplayLayout.Bands[0].Columns[i].Header.Appearance.BackColor2 = Color.PowderBlue;
                //set column width
                //if (tag.colw != null)
                //    ctrl.DisplayLayout.Bands[0].Columns[i].Width = Int32.Parse(tag.colw);
            }
        }

        public void SetContextMenuStripResource(System.Windows.Forms.ContextMenuStrip menu)
        {
            for (int i = 0; i < menu.Items.Count; i++)
            {
                if (menu.Items[i].Tag != null)
                {
                    TagInfo toolTag = ParseTag(menu.Items[i].Tag);
                    if (toolTag.rsid != null && toolTag.rsid.Trim() != string.Empty)
                    {
                        menu.Items[i].Text = UtilCulture.GetString(toolTag.rsid);
                    }
                }
            }
        }

        public void ChangeLotGridResource(Infragistics.Win.UltraWinGrid.UltraGrid grid, string[] columnFields)
        {
            if (grid.Tag == null) return;

            string[] arrTags = grid.Tag.ToString().Split('|');

            List<string> lstColumn = columnFields.ToList<string>();
            for (int i = 0; i < lstColumn.Count; i++)
            {

                TagInfo tag = ParseTag(arrTags[i]);

                grid.DisplayLayout.Bands[0].Columns[lstColumn[i]].Header.Caption = UtilCulture.GetString(tag.rsid);

                //set column width
                if (tag.colw != null)
                    grid.DisplayLayout.Bands[0].Columns[lstColumn[i]].Width = Int32.Parse(tag.colw);
            }
        }

        public void SetUltraComboResource(Infragistics.Win.UltraWinGrid.UltraCombo ctrl, string resource)
        {
            if (resource == string.Empty || resource == null) return;

            string[] arrRes = resource.Split('|');

            for (int i = 0; i < arrRes.Length; i++)
            {
                ctrl.DisplayLayout.Bands[0].Columns[i].Header.Caption = UtilCulture.GetString(arrRes[i]);
            }
        }

        public void SetQueryGridStyle(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            SetGridReadOnly(grid, true);
            grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            grid.DisplayLayout.Override.SelectTypeCell = SelectType.Extended;
            grid.DisplayLayout.Override.SelectTypeCol = SelectType.Extended;

            grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

            grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal;
            grid.DisplayLayout.NewColumnLoadStyle = NewColumnLoadStyle.Hide;
            grid.DisplayLayout.CaptionVisible = DefaultableBoolean.False;

            grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            grid.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            grid.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;

            grid.DisplayLayout.Appearance.BackColor = Color.White;
            grid.DisplayLayout.Override.CellAppearance.BorderColor = System.Drawing.Color.Silver;
            grid.DisplayLayout.Override.RowAppearance.BorderColor = System.Drawing.Color.Silver;

            grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;

            //Grid cell can be copy to clipboard
            grid.DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy;
            grid.PerformAction(UltraGridAction.Copy);

            //grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
        }

        public void SetEditGridStyle(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            SetGridReadOnly(grid, false);
            grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;

            grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;

            grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal;
            grid.DisplayLayout.NewColumnLoadStyle = NewColumnLoadStyle.Hide;
            grid.DisplayLayout.CaptionVisible = DefaultableBoolean.False;

            grid.DisplayLayout.Appearance.BackColor = Color.White;
            grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            grid.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            grid.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;

            grid.DisplayLayout.Override.CellAppearance.BorderColor = System.Drawing.Color.Silver;
            grid.DisplayLayout.Override.RowAppearance.BorderColor = System.Drawing.Color.Silver;
           
            grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;

            //Grid cell can be copy to clipboard
            grid.DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy;
            grid.PerformAction(UltraGridAction.Copy);
        }

        public void SetGridReadOnly(Infragistics.Win.UltraWinGrid.UltraGrid grid, bool flag)
        {
            foreach (UltraGridColumn col in grid.DisplayLayout.Bands[0].Columns)
            {
                if (flag)
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
                else
                {
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                if (col.Key.ToUpper().Equals("LASTMODIFIEDTIME") || col.Key.ToUpper().Equals("CLAIMTIME") || col.Key.ToUpper().Equals("CREATEDTIME"))
                {
                    col.Format = Parameter.DATETIME_FORMAT;
                }
            }
        }



        public void CreateUltraGridColumns(Infragistics.Win.UltraWinGrid.UltraGrid grid, string[] cols)
        {
            UltraGridBand ultraGridBand = new UltraGridBand("", -1);
            List<UltraGridColumn> list = new List<UltraGridColumn>();
            int i = 0;
            foreach (string col in cols)
            {
                UltraGridColumn ultraGridColumn = new Infragistics.Win.UltraWinGrid.UltraGridColumn(col.ToLower());
                ultraGridColumn.Header.VisiblePosition = i++;
                list.Add(ultraGridColumn);
            }
            ultraGridBand.Columns.AddRange(list.ToArray());
            grid.DisplayLayout.BandsSerializer.Add(ultraGridBand);
        }

        public void CreateUltraComboColumns(Infragistics.Win.UltraWinGrid.UltraCombo ucmb, string[] cols)
        {
            UltraGridBand ultraGridBand = new UltraGridBand("", -1);
            List<UltraGridColumn> list = new List<UltraGridColumn>();
            int i = 0;
            foreach (string col in cols)
            {
                UltraGridColumn ultraGridColumn = new Infragistics.Win.UltraWinGrid.UltraGridColumn(col.ToLower());
                ultraGridColumn.Header.VisiblePosition = i++;
                list.Add(ultraGridColumn);
            }
            ultraGridBand.Columns.AddRange(list.ToArray());
            ucmb.DisplayLayout.BandsSerializer.Add(ultraGridBand);
        }

        public void SetUltraComboStyle(Infragistics.Win.UltraWinGrid.UltraCombo ucmb)
        {
            ucmb.DisplayLayout.NewColumnLoadStyle = NewColumnLoadStyle.Hide;
            ucmb.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
        }

        public void SetQueryGridStyle(System.Windows.Forms.DataGridView grdQuery)
        {
            grdQuery.AllowUserToAddRows = false;
            grdQuery.AllowUserToDeleteRows = false;
            grdQuery.EditMode = DataGridViewEditMode.EditProgrammatically;
            grdQuery.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdQuery.MultiSelect = false;
            grdQuery.ReadOnly = true;
            grdQuery.AutoSize = true;
            grdQuery.ShowEditingIcon = false;
        }

        public void SetEditGridStyle(System.Windows.Forms.DataGridView grdQuery)
        {
            grdQuery.AllowUserToAddRows = false;
            grdQuery.AllowUserToDeleteRows = false;
            //grdQuery.EditMode = DataGridViewEditMode.EditProgrammatically;
            grdQuery.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdQuery.MultiSelect = false;
            grdQuery.ReadOnly = false;
            grdQuery.AutoSize = true;
            grdQuery.ShowEditingIcon = false;
        }

        public void ShowSingleObjectToUI<T>(T obj, Control _parentControl) where T : class
        {
            foreach (Control ctrl in _parentControl.Controls)
            {
                if (ctrl.Tag != null)
                {
                    TagInfo tag = ParseTag(ctrl.Tag);

                    if (tag.dbfd != null && tag.dbfd.Trim() != string.Empty)
                    {
                        PropertyInfo prop = typeof(T).GetProperty(tag.dbfd);
                        if (prop != null)
                        {
                            SetControlValue(ctrl, prop.GetValue(obj, null) == null ? "" : prop.GetValue(obj, null).ToString());
                        }
                    }
                }

                ShowSingleObjectToUI<T>(obj, ctrl);
            }
        }

        public void ShowSingleObjectToUI(DataSet ds, Control _parentControl)
        {
            foreach (Control ctrl in _parentControl.Controls)
            {
                if (ctrl.Tag != null)
                {
                    TagInfo tag = ParseTag(ctrl.Tag);

                    if (tag.dbfd != null && tag.dbfd.Trim() != string.Empty)
                    {
                        if (ds.Tables[0].Columns.Contains(tag.dbfd.Trim()))
                        {
                            SetControlValue(ctrl, ds.Tables[0].Rows[0][tag.dbfd.Trim()] == null ? string.Empty : ds.Tables[0].Rows[0][tag.dbfd.Trim()].ToString());
                        }
                    }
                }

                ShowSingleObjectToUI(ds, ctrl);
            }
        }

        public T PrepareObject<T>(T obj, Public_UpdateMode mode) where T : class
        {
            PropertyInfo prop = typeof(T).GetProperty("lastmodifieduser");
            if (prop != null)
                prop.SetValue(obj, Function.GetCurrentUser(), null);

            prop = typeof(T).GetProperty("lastmodifiedtime");
            if (prop != null)
                prop.SetValue(obj, Function.GetCurrentTime(), null);

            if (mode == Public_UpdateMode.Insert)
            {
                prop = typeof(T).GetProperty("claimuser");
                if (prop != null)
                    prop.SetValue(obj, Function.GetCurrentUser(), null);

                prop = typeof(T).GetProperty("claimtime");
                if (prop != null)
                    prop.SetValue(obj, Function.GetCurrentTime(), null);

                prop = typeof(T).GetProperty("createduser");
                if (prop != null)
                    prop.SetValue(obj, Function.GetCurrentUser(), null);

                prop = typeof(T).GetProperty("createdtime");
                if (prop != null)
                    prop.SetValue(obj, Function.GetCurrentTime(), null);
            }
            return obj;
        }

        public void BuildQueryParameters(List<MESParameterInfo> lstParameters, Control _parentControl)
        {
            foreach (Control ctrl in _parentControl.Controls)
            {
                if (ctrl.Tag != null)
                {
                    TagInfo tag = ParseTag(ctrl.Tag);

                    if (tag.dbfd != null && tag.dbfd.Trim() != string.Empty)
                    {
                        object value = GetControlValue(ctrl);
                        if (value != null && value.ToString() != string.Empty)
                        {
                            string tmpValue = value.ToString().Replace('*', '%');
                            lstParameters.Add(new MESParameterInfo()
                            {
                                ParamName = tag.dbfd,
                                ParamValue = tmpValue.ToString(),
                                ParamType = tag.dbty.ToLower()
                            });
                        }
                    }
                }

                BuildQueryParameters(lstParameters, ctrl);
            }
        }

        public void SortGrid(DataGridView grid, int ClickColumnIndex)
        {
            int oldSortIndex = -1;
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].HeaderCell.SortGlyphDirection != SortOrder.None)
                {
                    oldSortIndex = i;
                    break;
                }
            }

            if ((oldSortIndex == -1) || (oldSortIndex != ClickColumnIndex))
            {
                if (grid.SortedColumn == null)
                    grid.Columns[ClickColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.None;

                grid.Sort(grid.Columns[ClickColumnIndex], ListSortDirection.Ascending);
                grid.Columns[ClickColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            }
            else
            {
                if (grid.SortOrder == SortOrder.Ascending)
                {
                    grid.Sort(grid.Columns[ClickColumnIndex], ListSortDirection.Descending);
                    grid.Columns[ClickColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                }
                else
                {
                    grid.Sort(grid.Columns[ClickColumnIndex], ListSortDirection.Ascending);
                    grid.Columns[ClickColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                }
            }
        }

        public void SetCursor()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        public void ResetCursor()
        {
            Cursor.Current = Cursors.Default;
        }

        public void SetAllObjectsReadonly(Control _parentControl)
        {
            foreach (System.Windows.Forms.Control control in _parentControl.Controls)//遍历Form上的所有控件   
            {

                if (control is System.Windows.Forms.Label || control is TabControl || control is Panel)
                {
                    control.Enabled = true;
                }
                else
                {
                    control.Enabled = false;
                }
                SetAllObjectsReadonly(control);

            }

        }

        public void UncheckUltraGridCheckBox(UltraGrid grid, int excludeRowIndex, string columnName)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (i != excludeRowIndex)
                {
                    grid.Rows[i].Cells[columnName].Value = MES_Misc.N.ToString();
                }
            }
        }

        public void InitResourceFile(string language)
        {
            UtilCulture.InitialResource("GENLSYS.MES.Res", Application.StartupPath + "\\Resources", language);
            string x = UtilCulture.GetString("Label.R00001");
        }

        #endregion

        #region Validate
        public void ValidateData(Control _parentControl)
        {
            foreach (Control ctrl in _parentControl.Controls)
            {
                if (ctrl.Tag != null)
                {
                    TagInfo tag = ParseTag(ctrl.Tag);

                    //set required
                    if (tag.isrq != null && tag.isrq.ToUpper() == "Y")
                    {
                        bool b = false;
                        if (tag.updt != null && tag.updt.Trim() != string.Empty)
                        {
                        object value = GetControlValue(ctrl);
                        if (value == null || value.ToString().Equals("") || value.ToString() == string.Empty)
                            b = true;
                        }
                        if (b)
                            throw new UtilException("[" + UtilCulture.GetString(tag.rsid) + "]" + UtilCulture.GetString("Msg.R00176"));
                    }
                }

                ValidateData(ctrl);
            }
        }
        #endregion

        #region Tag
        public TagInfo ParseTag(object _tag)
        {
            TagInfo tagInfo = new TagInfo();

            if (_tag == null) return tagInfo;

            string[] arrTag = _tag.ToString().Split(',');

            for (int i = 0; i < arrTag.Length; i++)
            {
                string[] arrTagField = arrTag[i].Split(':');
                PropertyInfo prop = typeof(TagInfo).GetProperty(arrTagField[0].Trim());
                if (prop != null)
                    prop.SetValue(tagInfo, arrTagField[1].Trim(), null);
            }

            return tagInfo;
        }

        public TagInfo ParseTag(string _tag)
        {
            TagInfo tagInfo = new TagInfo();

            string[] arrTag = _tag.Split(',');

            for (int i = 0; i < arrTag.Length; i++)
            {
                string[] arrTagField = arrTag[i].Split(':');
                PropertyInfo prop = typeof(TagInfo).GetProperty(arrTagField[0].Trim());
                if (prop != null)
                    prop.SetValue(tagInfo, arrTagField[1].Trim(), null);
            }

            return tagInfo;
        }

        public object GetControlValue(Control ctrl)
        {
            if (ctrl is System.Windows.Forms.TextBox)
                return ctrl.Text;

            if (ctrl is System.Windows.Forms.ComboBox)
            {
                System.Windows.Forms.ComboBox cmb = ctrl as System.Windows.Forms.ComboBox;
                if (cmb.SelectedItem == null) return null;
                return (cmb.SelectedItem as ValueInfo).ValueField;
            }

            if (ctrl is System.Windows.Forms.CheckBox)
            {
                System.Windows.Forms.CheckBox chk = ctrl as System.Windows.Forms.CheckBox;
                if (chk.Checked)
                    return "Y";
                else
                    return "N";
            }

            if (ctrl is System.Windows.Forms.NumericUpDown)
            {
                System.Windows.Forms.NumericUpDown nud = ctrl as System.Windows.Forms.NumericUpDown;
                return Convert.ToDecimal(nud.Value.ToString());
            }

            if (ctrl is System.Windows.Forms.DateTimePicker)
            {
                System.Windows.Forms.DateTimePicker dtp = ctrl as System.Windows.Forms.DateTimePicker;
                return dtp.Value;
            }
            if (ctrl is Infragistics.Win.UltraWinEditors.UltraColorPicker)
            {
                Infragistics.Win.UltraWinEditors.UltraColorPicker ucp = ctrl as Infragistics.Win.UltraWinEditors.UltraColorPicker;
                return ColorTranslator.ToHtml((Color)ucp.Value);
            }
            if (ctrl is Infragistics.Win.UltraWinGrid.UltraCombo)
            {
                Infragistics.Win.UltraWinGrid.UltraCombo ucmb = ctrl as Infragistics.Win.UltraWinGrid.UltraCombo;
                return ucmb.Value;
            }
            if (ctrl is Infragistics.Win.UltraWinEditors.UltraComboEditor)
            {
                Infragistics.Win.UltraWinEditors.UltraComboEditor ucmb = ctrl as Infragistics.Win.UltraWinEditors.UltraComboEditor;
                return ucmb.Value;
            }
            if (ctrl is Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)
            {
                Infragistics.Win.UltraWinEditors.UltraDateTimeEditor ucmb = ctrl as Infragistics.Win.UltraWinEditors.UltraDateTimeEditor;
                return ucmb.Value;
            }
            return string.Empty;
        }

        public void setDefaultValue(Control _parentControl)
        {
            foreach (Control ctrl in _parentControl.Controls)
            {
                if (ctrl is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox cmb = ctrl as System.Windows.Forms.ComboBox;
                    if (cmb.DropDownStyle == ComboBoxStyle.DropDownList && cmb.Items.Count > 0)
                    {
                        cmb.SelectedIndex = 0;
                    }
                }
                setDefaultValue(ctrl);
            }
        }

        private void SetControlValue(Control ctrl, string value)
        {
            if (ctrl is System.Windows.Forms.TextBox)
                ctrl.Text = value;

            if (ctrl is System.Windows.Forms.ComboBox)
            {
                System.Windows.Forms.ComboBox cmb = ctrl as System.Windows.Forms.ComboBox;
                DropDown.SelectCMBValue(cmb, value);
                //cmb.Text = value;
            }

            if (ctrl is System.Windows.Forms.CheckBox)
            {
                System.Windows.Forms.CheckBox chk = ctrl as System.Windows.Forms.CheckBox;
                if (value == "Y")
                    chk.Checked = true;
                else
                    chk.Checked = false;
            }

            if (ctrl is System.Windows.Forms.NumericUpDown)
            {
                System.Windows.Forms.NumericUpDown nud = ctrl as System.Windows.Forms.NumericUpDown;
                nud.Value = Decimal.Parse(value == null || value == string.Empty ? "0" : value);
            }
            if (ctrl is System.Windows.Forms.DateTimePicker)
            {
                System.Windows.Forms.DateTimePicker dtp = ctrl as System.Windows.Forms.DateTimePicker;
                if (!value.ToString().Equals(""))
                {
                    dtp.Value = DateTime.Parse(value);
                }
            }
            if (ctrl is Infragistics.Win.UltraWinEditors.UltraColorPicker)
            {
                Infragistics.Win.UltraWinEditors.UltraColorPicker ucp = ctrl as Infragistics.Win.UltraWinEditors.UltraColorPicker;
                ucp.Value = ColorTranslator.FromHtml(value);
            }
            if (ctrl is Infragistics.Win.UltraWinGrid.UltraCombo)
            {
                Infragistics.Win.UltraWinGrid.UltraCombo ucmb = ctrl as Infragistics.Win.UltraWinGrid.UltraCombo;
                ucmb.Value = value;
            }
            if (ctrl is Infragistics.Win.UltraWinEditors.UltraComboEditor)
            {
                Infragistics.Win.UltraWinEditors.UltraComboEditor ucmb = ctrl as Infragistics.Win.UltraWinEditors.UltraComboEditor;
                ucmb.Value = value;
            }

            if (ctrl is Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)
            {
                Infragistics.Win.UltraWinEditors.UltraDateTimeEditor ucmb = ctrl as Infragistics.Win.UltraWinEditors.UltraDateTimeEditor;
                ucmb.Value = value;
            }
        }
        #endregion

        #region Actions
        public virtual void CreateSingleObject<T>(T obj, Control _parentControl, Public_UpdateMode updateMode) where T : class
        {
            foreach (Control ctrl in _parentControl.Controls)
            {
                if (ctrl.Tag != null)
                {
                    TagInfo tag = ParseTag(ctrl.Tag);

                    //check updt
                    if (tag.updt != null && tag.updt.ToUpper() == "Y" && tag.dbfd != null && tag.dbfd.Trim() != string.Empty)
                    {
                        PropertyInfo prop = typeof(T).GetProperty(tag.dbfd.ToLower().Trim());
                        if (prop != null)
                        {
                            prop.SetValue(obj, GetControlValue(ctrl), null);
                        }
                    }
                }

                CreateSingleObject<T>(obj, ctrl, updateMode);
            }

            PrepareObject<T>(obj, updateMode);
        }

        public virtual void CreateCollectionFromUI(Dictionary<string, object> dic, Control _parentControl)
        {
            foreach (Control ctrl in _parentControl.Controls)
            {
                if (ctrl.Tag != null)
                {
                    TagInfo tag = ParseTag(ctrl.Tag);

                    //check updt
                    if (tag.updt != null && tag.updt.ToUpper() == "Y" && tag.dbfd != null && tag.dbfd.Trim() != string.Empty)
                    {
                        if (dic.ContainsKey(tag.dbfd.ToLower().Trim()))
                        {
                            dic.Remove(tag.dbfd.ToLower().Trim());
                        }
                        dic.Add(tag.dbfd.ToLower().Trim(), GetControlValue(ctrl));
                    }
                };

                CreateCollectionFromUI(dic, ctrl);
            }
            if (dic.ContainsKey("lastmodifieduser"))
            {
                dic.Remove("lastmodifieduser");
            }
            dic.Add("lastmodifieduser", Function.GetCurrentUser());
            if (dic.ContainsKey("lastmodifiedtime"))
            {
                dic.Remove("lastmodifiedtime");
            }
            dic.Add("lastmodifiedtime", Function.GetCurrentTime());
            if (dic.ContainsKey("claimuser"))
            {
                dic.Remove("claimuser");
            }
            dic.Add("claimuser", Function.GetCurrentUser());
            if (dic.ContainsKey("claimtime"))
            {
                dic.Remove("claimtime");
            }
            dic.Add("claimtime", Function.GetCurrentTime());
            if (dic.ContainsKey("createduser"))
            {
                dic.Remove("createduser");
            }
            dic.Add("createduser", Function.GetCurrentUser());
            if (dic.ContainsKey("createdtime"))
            {
                dic.Remove("createdtime");
            }
            dic.Add("createdtime", Function.GetCurrentTime());

        }
        #endregion

        #region Export to Excel
        public void ExportExcel(Infragistics.Win.UltraWinGrid.UltraGrid _grid)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel|*.xls";
            saveDialog.ShowDialog();
            string saveFileName = saveDialog.FileName;

            if (saveFileName.IndexOf(":") < 0) return;

            UltraGridExcelExporter export = new UltraGridExcelExporter();
            export.Export(_grid, saveFileName);
            CreateMessageBox(Public_MessageBox.Information, MessageBoxButtons.OK, null, "Export excel successful.");

        }

        public void ExportExcel(DataGridView _grid)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel|*.xls";
            saveDialog.ShowDialog();
            string saveFileName = saveDialog.FileName;

            if (saveFileName.IndexOf(":") < 0) return;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MESMsgBox.ShowError("can not create excel application");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            int cellNum = 1;
            for (int i = 0; i < _grid.ColumnCount; i++)
            {

                if (_grid.Columns[i].Visible == true)
                {
                    worksheet.Cells[1, cellNum] = _grid.Columns[i].HeaderText;
                    worksheet.Cells[1, cellNum].Font.Size = 12;
                    worksheet.Cells[1, cellNum].Font.Bold = true;
                    worksheet.Cells[1, cellNum].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    cellNum++;
                }
            }
            for (int r = 1; r < _grid.Rows.Count + 1; r++)
            {
                cellNum = 1;
                for (int i = 0; i < _grid.ColumnCount; i++)
                {
                    if (_grid.Columns[i].Visible == true)
                    {
                        string str = _grid.Rows[r - 1].Cells[i].Value.ToString();
                        if (string.IsNullOrEmpty(str))
                        {
                            str = " ";
                        }

                        worksheet.Cells[r + 1, cellNum++] = str;
                    }
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MESMsgBox.ShowError("Save excel file failed." + ExceptionParser.Parse(ex));
                }
            }
            xlApp.Quit();
            GC.Collect();
            MESMsgBox.ShowInformation("Export excel successful.");
        }
        #endregion

        #region Message Box
        public DialogResult CreateMessageBox(Public_MessageBox msgBox, MessageBoxButtons msgButtons, string msgHeaderText, string msgContents)
        {
            frmMessage f = new frmMessage();
            if (msgHeaderText != string.Empty && msgContents == string.Empty)
            {
                msgContents = msgHeaderText;
                f.ShowMessage(string.Empty, msgContents, msgBox, msgButtons);
            }
            else
                f.ShowMessage(msgHeaderText, msgContents, msgBox, msgButtons);
            
            f.ShowDialog();

            return f.ReturnDialogResult;
        }

        public DialogResult CreateMessageBox(Public_MessageBox msgBox, MessageBoxButtons msgButtons, string msgHeaderText, string msgContents ,string[] butText)
        {
            frmMessage f = new frmMessage();
            if (msgHeaderText != string.Empty && msgContents == string.Empty)
            {
                msgContents = msgHeaderText;
                f.ShowMessage(string.Empty, msgContents, msgBox, msgButtons, butText);
            }
            else
                f.ShowMessage(msgHeaderText, msgContents, msgBox, msgButtons, butText);

            f.ShowDialog();

            return f.ReturnDialogResult;
        }

        public DialogResult CreateMessageBox(Public_MessageBox messagebox, MessageBoxButtons buttons, string headermsg, Dictionary<string, object> contentmsgDir)
        {
            string contentmsg = string.Empty;
            foreach (string key in contentmsgDir.Keys)
            {
                if (contentmsg == string.Empty)
                {
                    //contentmsg = "<span style='font-weight:bold;'>" + key + ": </span> " + contentmsgDir[key].ToString();
                    contentmsg = "" + key + ": " + contentmsgDir[key].ToString();
                }
                else
                {
                    //contentmsg = contentmsg + "<br/><span style='font-weight:bold;'>" + key + ": </span> " + contentmsgDir[key].ToString();
                    contentmsg = contentmsg + " " + key + ":  " + contentmsgDir[key].ToString();
                }
            }
            return CreateMessageBox(messagebox, buttons, headermsg, contentmsg);
        }
        #endregion

        #region Attribute
        public void ShowAttributeDetail(ucAttribute attributeControl, MES_AttributeTemplate_UsedBy whereUsed, string attributeTemplateId)
        {
            if (attributeControl == null) return;

            attributeControl.UpdateMode = GENLSYS.MES.Common.Public_UpdateMode.Insert;
            attributeControl.WhereUsed = whereUsed;
            attributeControl.AttributeTemplateID = attributeTemplateId;

            attributeControl.DoShow();
        }

        public void SetCurrentContextInfo()
        {
            CurrentContextInfo = new ContextInfo();
            CurrentContextInfo.SessionId = Parameter.SESSION_ID;
            CurrentContextInfo.Shift = Parameter.SHIFT;
            CurrentContextInfo.CurrentUser = Function.GetCurrentUser();
            CurrentContextInfo.WorkGroup = Parameter.WORKGROUP;
        }
        #endregion

        #region Privilege
        private void DoPrivilege(string formName, Control _parentControl)
        {
            foreach (Control ctrl in _parentControl.Controls)
            {
                if (ctrl is GENLSYS.MES.UserControls.ucToolbar)
                {
                    GENLSYS.MES.UserControls.ucToolbar utb = ctrl as GENLSYS.MES.UserControls.ucToolbar;
                    utb.DoPrivilege(formName);
                }
                else if (ctrl is System.Windows.Forms.Button)
                {
                    System.Windows.Forms.Button btn = ctrl as System.Windows.Forms.Button;
                    btn.Enabled = CheckPrivilege(formName + Parameter.FUNC_SEPARATOR + btn.Name.ToLower());
                }
                else if (ctrl is System.Windows.Forms.ContextMenuStrip)
                {
                    System.Windows.Forms.ContextMenuStrip cms = ctrl as System.Windows.Forms.ContextMenuStrip;
                    foreach (ToolStripItem item in cms.Items)
                    {
                        if (item is System.Windows.Forms.ToolStripMenuItem)
                        {
                            item.Enabled = CheckPrivilege(formName + Parameter.FUNC_SEPARATOR + item.Name.ToLower());
                        }
                    }
                }
                else if (ctrl is System.Windows.Forms.ToolStrip)
                {
                    if (ctrl.Parent.Name.Contains("ucToolbar")) return;
                    System.Windows.Forms.ToolStrip tools = ctrl as System.Windows.Forms.ToolStrip;
                    foreach (ToolStripItem item in tools.Items)
                    {
                        if (item is System.Windows.Forms.ToolStripButton)
                        {
                            string funcurl = formName + Parameter.FUNC_SEPARATOR + item.Name.ToLower();
                            item.Visible = CheckPrivilege(funcurl);
                        }
                    }
                }

                DoPrivilege(formName, ctrl);
            }
        }

        private bool CheckPrivilege(string funcurl)
        {
            bool result = true;
            string selectStr = "funcurl='" + funcurl + "'";
            if (Parameter.ALL_FUNCTIONS.Select(selectStr).Count() > 0)
            {
                if (Parameter.USER_FUNCTIONS.Select(selectStr).Count() == 0)
                {
                    result = false;
                }
            }
            return result;
        }
        #endregion

        #region Misc
        public void MoveRow(UltraGrid grid, int upIndex, int downIndex, Public_MoveDirection moveType)
        {
            DataTable dt = (grid.DataSource as DataTable);

            if (moveType ==  Public_MoveDirection.Up)
            {
                if (downIndex <1) return;

                DataRow dr = dt.NewRow();
                dr.ItemArray = dt.Rows[upIndex].ItemArray;
                dt.Rows[upIndex].ItemArray = dt.Rows[downIndex].ItemArray;
                dt.Rows[downIndex].ItemArray = dr.ItemArray;
            }

            if (moveType == Public_MoveDirection.Down)
            {
                if (upIndex == (grid.Rows.Count - 1)) return;

                DataRow dr = dt.NewRow();
                dr.ItemArray = dt.Rows[downIndex].ItemArray;
                dt.Rows[downIndex].ItemArray = dt.Rows[upIndex].ItemArray;
                dt.Rows[upIndex].ItemArray = dr.ItemArray;
            }
        }

        public T ConvertUltraGridRowToObject<T>(UltraGridRow row) where T : class
        {
            T obj = typeof(T).GetConstructor(new Type[] { }).Invoke(new object[] { }) as T;

            for (int i = 0; i < row.Cells.Count; i++)
            {
                PropertyInfo prop = typeof(T).GetProperty(row.Cells[i].Column.Key.ToLower());
                if (prop != null)
                {
                    if (row.Cells[i].Value is DBNull)
                        prop.SetValue(obj, null, null);
                    else
                    {
                        if (prop.PropertyType.FullName.Contains("System.Double"))
                        {
                            prop.SetValue(obj, Double.Parse(row.Cells[i].Value.ToString()), null);
                        }
                        else if (prop.PropertyType.FullName.Contains("System.Decimal"))
                        {
                            prop.SetValue(obj, Decimal.Parse(row.Cells[i].Value.ToString()), null);
                        }
                        else
                        {
                            prop.SetValue(obj, row.Cells[i].Value, null);
                        }

                    }
                }
            }

            return obj;
        }
        #endregion

        #region System Config & Static Value
        public string GetSystemConfig(string configName)
        {
            if (configName.Trim() == string.Empty) return string.Empty;

            var q = (from p in ((Parameter.CURRENT_SYSTEM_CONFIG) as List<tsyssystemconfig>)
                     where p.configname == configName.Trim()
                     select p).SingleOrDefault();

            if (q == null) return string.Empty;

            return q.configvalue;
        }

        public List<tsysstaticvalue> GetStaticValue(MES_StaticValue_Type _type)
        {
            List<tsysstaticvalue> lstValue = Parameter.CURRENT_STATIC_VALUE as List<tsysstaticvalue>;
            var q = (from p in lstValue
                     where p.svtype == _type.ToString()
                     select p).ToList<tsysstaticvalue>();
            return q;
        }

        public void SetParameter()
        {            
        }
        #endregion

        #region Date Code
        public bool CheckDateCode(string baseDateCode, string targetDateCode)
        {
            #region Compare chars in date code
            DateCodeInfo baseDateCodeInfo = ParseDateCode(baseDateCode);
            DateCodeInfo targetDateCodeInfo = ParseDateCode(targetDateCode);

            if (baseDateCodeInfo.Vendor != targetDateCodeInfo.Vendor)
                return false;
            #endregion

            #region Check week difference
            if (targetDateCodeInfo.Year == baseDateCodeInfo.Year)
            {
                //at same year
                if (Math.Abs(Decimal.Parse(targetDateCodeInfo.Week) - Decimal.Parse(baseDateCodeInfo.Week)) > 8)
                {
                    //larger than 8 week
                    return false;
                }
            }
            else
            {
                //at difference year
                int weekAmount = Function.GetWeekAmount(Int32.Parse(ParseYearInDateCode(baseDateCodeInfo.Year)));
                if (((weekAmount - Int16.Parse(baseDateCodeInfo.Week)) + Int16.Parse(targetDateCodeInfo.Week)) > 8)
                {
                    //larger than 8 week
                    return false;
                }
            }
            #endregion

            return true;
        }

        public DateCodeInfo ParseDateCode(string dateCode)
        {
            DateCodeInfo dateCodeInfo = new DateCodeInfo();

            if (dateCode.Trim() == string.Empty) return dateCodeInfo;

            dateCodeInfo.Year = dateCode.Substring(0, 1);
            dateCodeInfo.Week = dateCode.Substring(1, 2);
            dateCodeInfo.Vendor = dateCode.Substring(3, 1);
            //dateCodeInfo.Extension = dateCode.Substring(4, 2);

            return dateCodeInfo;
        }

        public string ParseYearInDateCode(string year)
        {
            string sReturn = string.Empty;
            int iYear = int.Parse(year);
            int iCurrentYear = -1;
            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();
            try
            {
                string serverDateTime = client.GetServerDateTime();
                iCurrentYear = DateTime.Parse(serverDateTime).Year;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWCF(client);
            }

            if (iCurrentYear == -1)
                iCurrentYear = DateTime.Now.Year;

            int iCurrentShortYear = int.Parse(iCurrentYear.ToString().Substring(2, 2));
            int iCurrentYearNoDecade = int.Parse(iCurrentYear.ToString().Substring(3, 1));
            int iDecade = 0;
            //
            if (iYear > iCurrentYearNoDecade)
            {
                iDecade = int.Parse(iCurrentYear.ToString().Substring(2, 1)) * 10 - 10;
            }
            else
            {
                iDecade = int.Parse(iCurrentYear.ToString().Substring(2, 1)) * 10;
            }

            if (iCurrentShortYear.ToString().Length == 2)
            {
                sReturn = (iCurrentYear - int.Parse(iCurrentYear.ToString().Substring(2, 2)) + iYear + iDecade).ToString();
            }
            else
            {
                sReturn =(iCurrentYear - int.Parse(iCurrentYear.ToString().Substring(2, 2)) + iYear).ToString();
            }

            return sReturn;
        }

        public string GetMaxDateCode(string dateCode1, string dateCode2)
        {
            DateCodeInfo dateCodeInfo1 = ParseDateCode(dateCode1);
            DateCodeInfo dateCodeInfo2 = ParseDateCode(dateCode2);

            string year1 = ParseYearInDateCode(dateCodeInfo1.Year);
            string year2 = ParseYearInDateCode(dateCodeInfo1.Year);

            if (decimal.Parse(year1) > decimal.Parse(year2))
                return dateCode1;

            if (decimal.Parse(year1) < decimal.Parse(year2))
                return dateCode2;

            if (decimal.Parse(dateCodeInfo1.Week) > decimal.Parse(dateCodeInfo2.Year))
            {
                return dateCode1;
            }

            if (decimal.Parse(dateCodeInfo1.Week) < decimal.Parse(dateCodeInfo2.Year))
            {
                return dateCode2;
            }

            return dateCode1;
        }
        #endregion

        #region Get Cust Short Name
        public string GetCustShortName(string datecode, string custlotid,DataTable custDt)
        {
            string dcchar = "";
            string custchar = "";
            if (datecode.Trim().Length >= 4)
            {
                dcchar = datecode.Substring(3, 1);
            }
            if (custlotid.Trim().Length >= 2)
            {
                custchar = custlotid.Substring(1, 1);
            }

            //By CustLotId
            var q = (from p in custDt.AsEnumerable()
                     where p.Field<string>("manager") == custchar
                     select p).ToList();
            if (q.Count > 0)
            {
                return q[0]["short_name"].ToString();
            }
            //By DateCode
            var q1 = (from p in custDt.AsEnumerable()
                      where p.Field<string>("gno") == dcchar
                      select p).ToList();
            if (q1.Count > 0)
            {
                return q1[0]["short_name"].ToString();
            }
            return null;
        }
        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.WinPAD.Common.Classes;
using GENLSYS.MES.Utility;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.WinPAD.SEC;
namespace GENLSYS.MES.WinPAD
{
    public partial class frmPackBox : Form
    {
        #region 变量
        System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox(); //this textBox is used for soft keyboard
        int focusLocation = 0;
        string poID;         //订单号
        string customerid;   //客户编号
        string customerName; //客户名字
        string currStep; //当前站别
        private BaseForm baseForm;
        System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        DataSet ds = new DataSet();  //存放箱子和箱内明细
        DataTable cartonDt;  //托盘上的箱子
        DataTable boxDt;    //箱内明细
        // column name
        private string[] cartonColumns = new string[] { "cartonNumber", "qty", "qty2", "valid", "status" };
        private string[] BoxColumns = new string[] { "cartonNumber", "type", "color", "size", "qty", "qty2" };
        //订单内的颜色/型号/尺寸
        private string[] colour;
        private string[] size;// = new string[] { "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46" };
        private string[] type;

        bool lineChecked = false;
        #endregion

        #region 构造函数
        public frmPackBox(string _poid, string _customerid, string _customername, string _currStep)
        {
            //从主窗口传入订单/客户等
            poID = _poid;
            customerid = _customerid;
            customerName = _customername;
            currStep = _currStep;
            //辅助类
            baseForm = new BaseForm();
            //当前组
            baseForm.CurrentContextInfo.WorkGroup = Parameter.WORKGROUP;
            InitializeComponent();
            //构造grid
            this.CreateUltraGridColumns(this.ultraGrid1, cartonColumns);
            this.lblCustomer.Text = lblCustomer.Text + customerName;
            this.lblPO.Text = lblPO.Text + poID;
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            #region  maximized window
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            #endregion

            #region soft keyboard event
            but_0.Click += new EventHandler(but_Click);
            but_1.Click += new EventHandler(but_Click);
            but_2.Click += new EventHandler(but_Click);
            but_3.Click += new EventHandler(but_Click);
            but_4.Click += new EventHandler(but_Click);
            but_5.Click += new EventHandler(but_Click);
            but_6.Click += new EventHandler(but_Click);
            but_7.Click += new EventHandler(but_Click);
            but_8.Click += new EventHandler(but_Click);
            but_9.Click += new EventHandler(but_Click);
            but_Q.Click += new EventHandler(but_Click);
            but_W.Click += new EventHandler(but_Click);
            but_R.Click += new EventHandler(but_Click);
            but_E.Click += new EventHandler(but_Click);
            but_T.Click += new EventHandler(but_Click);
            but_Y.Click += new EventHandler(but_Click);
            but_U.Click += new EventHandler(but_Click);
            but_I.Click += new EventHandler(but_Click);
            but_O.Click += new EventHandler(but_Click);
            but_P.Click += new EventHandler(but_Click);
            but_A.Click += new EventHandler(but_Click);
            but_S.Click += new EventHandler(but_Click);
            but_D.Click += new EventHandler(but_Click);
            but_F.Click += new EventHandler(but_Click);
            but_G.Click += new EventHandler(but_Click);
            but_H.Click += new EventHandler(but_Click);
            but_J.Click += new EventHandler(but_Click);
            but_K.Click += new EventHandler(but_Click);
            but_L.Click += new EventHandler(but_Click);
            but_Z.Click += new EventHandler(but_Click);
            but_X.Click += new EventHandler(but_Click);
            but_C.Click += new EventHandler(but_Click);
            but_V.Click += new EventHandler(but_Click);
            but_B.Click += new EventHandler(but_Click);
            but_N.Click += new EventHandler(but_Click);
            but_M.Click += new EventHandler(but_Click);
            but_del.Click += new EventHandler(but_del_Click);
            #endregion

            #region ini grid
            this.SetQueryGridStyle(this.ultraGrid1);
            this.ultraGrid1.DisplayLayout.NewColumnLoadStyle = NewColumnLoadStyle.Show;
            this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;

            //构造grid数据的结构
            ds = new DataSet();
            cartonDt = GetTestData();
            cartonDt.TableName = "carton";
            boxDt = GetTestData2();
            boxDt.TableName = "box";
            ds.Tables.Add(cartonDt);
            ds.Tables.Add(boxDt);
            //构造表之间的关系
            ds.Relations.Add("ps", ds.Tables["carton"].Columns["cartonNumber"], ds.Tables["box"].Columns["cartonNumber"]);
            try
            {
                this.ultraGrid1.SetDataBinding(ds, "carton");
            }
            catch (Exception ex)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, System.Windows.Forms.MessageBoxButtons.OK, "错误", ExceptionParser.Parse(ex));
            }
            this.ultraGrid1.DisplayLayout.Bands[1].Columns[0].Hidden = true;
            ultraGrid1.DisplayLayout.Bands[0].Columns[0].Width = 70;
            boxDt.Clear();
            cartonDt.Clear();
            #endregion

            #region iniRadioButton
            GetPOColorAndType();
            CreateRadioButton();
            #endregion

            #region setFocurs
            btnNewTray.Focus();
            #endregion
            toolTip.IsBalloon = true;
            toolTip.SetToolTip(this.btnNewTray, "单击此处开始输入");
            toolTip.Show("单击此处开始输入", btnNewTray, 2000);

        }

        #region softkey button
        private void but_del_Click(object sender, EventArgs e)
        {
            Button l = (Button)sender;
            focusLocation = textBox.SelectionStart;
            if (textBox.Text.Length == 0 || (textBox.SelectionStart == 0 && textBox.SelectionLength == 0))
            {
                return;
            }
            if (textBox.SelectedText.Length > 0)
            {
                textBox.Text = textBox.Text.Replace(textBox.SelectedText, "");
                textBox.SelectionStart = focusLocation;
                return;
            }
            string s1 = textBox.Text.Substring(0, textBox.SelectionStart - 1);
            string s2 = textBox.Text.Substring(textBox.SelectionStart, textBox.Text.Length - s1.Length - 1);
            textBox.Text = s1 + s2;
            textBox.SelectionStart = focusLocation - 1;
        }

        void but_Click(object sender, EventArgs e)
        {
            Button l = (Button)sender;
            string s = l.Name.Substring(4, 1);
            textBox.Text = textBox.Text.Insert(textBox.SelectionStart, s);
            textBox.SelectionStart = textBox.Text.Length;

        }

        private void but_quit_Click(object sender, EventArgs e)
        {
            int target = 0;  //本托盘箱数
            if (txtQty.Text.Trim().Length > 0)
            {
                target = int.Parse(txtQty.Text);
            }

            int saved = 0;  //已经保存的箱子
            var rs = (from p in cartonDt.AsEnumerable()
                      where p.Field<string>("status") == "已保存"
                        || p.Field<string>("status") == "已保存(暂存线上)"
                      select p).ToList();

            int keyin = cartonDt.Rows.Count;  //已经输入的箱数
            if (rs.Count != 0)
            {
                saved = rs.Count();
            }

            if (target != keyin)  //输入的箱数和目标不等
            {

                DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                          MessageBoxButtons.YesNo,
                                                         null, "输入的箱数与托盘上的箱数不符，是否继续输入。\r\n选择“是”将继续输入，“否”将停止本托盘输入");

                if (result == DialogResult.No)
                {
                    if (saved != keyin)  //不再继续输入，但有未保存的
                    {
                        DialogResult result2 = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                        MessageBoxButtons.YesNo,
                                                       null, "存在没有保存的箱子，是放弃没有保存的数据。\r\n选择“是”将放弃，“否”请手动保存");

                        if (result2 == DialogResult.Yes)
                        {
                            Close(); //不保存未保存的信息
                        }
                        else
                        {
                            return;  //不退出，手动保存
                        }
                    }
                    else  //所有的都已经把偶才能
                    {
                        Close();
                    }

                }  //继续输入  
                else
                {
                    return;
                }
            }  //输入的箱和托盘上的箱子数相等
            else
            {
                if (saved != keyin) //但存在没有保存的
                {
                    DialogResult result3 = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                    MessageBoxButtons.YesNo,
                                                   null, "存在没有保存的箱子，是放弃没有保存的数据。\r\n选择“是”将放弃，“否”请手动保存");

                    if (result3 == DialogResult.Yes) //放弃没有保存的
                    {
                        Close();
                    }
                    else  //手动保存
                    {
                        return;
                    }
                }
                else  //都已经保存
                {
                    Close();
                }

            }
        }
        #endregion

        #region hightlight current text box
        private void textBox2_Enter(object sender, EventArgs e)
        {
            enterTextCarton();
        }

        private void enterTextCarton()
        {
            textBox.BackColor = Color.White;
            textBox = textBox2;
            textBox.BackColor = Color.Cyan;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox.BackColor = Color.White;
            textBox = textBox1;
            textBox.BackColor = Color.Cyan;
        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            textBox.BackColor = Color.White;
            textBox = txtQty;
            textBox.BackColor = Color.Cyan;
            toolTip.SetToolTip(this.txtQty, "请输入本托盘箱数");
            toolTip.Show("请输入本托盘箱数", txtQty, 2000);


        }

        #endregion

        #region after keyin tray number,auto skip to Qty
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 8)
            {
                txtQty.Focus();
            }
        }
        #endregion


        #region build radio button
        public void CreateRadioButton()
        {
            int typeCount = type.Length;
            RadioButton[] r = new RadioButton[typeCount];
            for (int i = 0; i < typeCount; i++)
            {
                r[i] = new RadioButton();
                r[i].Width = 80;
                r[i].Height = 45;
                r[i].Name = "radioButtonType" + i;
                r[i].Text = type[i];
                if (i % 2 == 0)
                {
                    r[i].BackColor = Color.LightGray;
                }
                else
                {
                    r[i].BackColor = Color.LightCoral;
                }

                r[i].Location = new System.Drawing.Point(15, 10 + 45 * i);
                r[i].Click += new EventHandler(typeRadio_Click);
            }
            this.panelType.Controls.AddRange(r);
            //colour
            int colourCount = colour.Length;
            RadioButton[] r2 = new RadioButton[colourCount];
            for (int i = 0; i < colourCount; i++)
            {
                r2[i] = new RadioButton();
                r2[i].Width = 80;
                r2[i].Height = 45;
                r2[i].Name = "radioButtonColour" + i;
                r2[i].Text = colour[i];
                if (i % 2 == 0)
                {
                    r2[i].BackColor = Color.LightGray;
                }
                else
                {
                    r2[i].BackColor = Color.LightCoral;
                }
                r2[i].Location = new System.Drawing.Point(15, 10 + 45 * i);
                r2[i].Click += new EventHandler(colorRadio_Click);
            }
            this.panelColor.Controls.AddRange(r2);

            //size
            int sizeCount = size.Length;
            RadioButton[] r3 = new RadioButton[sizeCount];
            for (int i = 0; i < sizeCount; i++)
            {
                r3[i] = new RadioButton();
                r3[i].Width = 80;
                r3[i].Height = 45;
                r3[i].Name = "radioButtonSize" + i;
                r3[i].Text = size[i];
                if (i % 2 == 0)
                {
                    r3[i].BackColor = Color.LightGray;
                }
                else
                {
                    r3[i].BackColor = Color.LightCoral;
                }
                r3[i].Location = new System.Drawing.Point(15, 10 + 45 * i);
                r3[i].Click += new EventHandler(sizeRadio_Click);
            }
            // this.groupBoxColor.Controls.AddRange(r2);
            this.panelSize.Controls.AddRange(r3);
            // r.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
        }
        void typeRadio_Click(object sender, EventArgs e)
        {
            if (!lineChecked)
            {
                checkLineWH();
            }
            RadioButton typeBut = (RadioButton)sender;
            if (typeBut.Checked)
            {
                textType.Text = typeBut.Text;
                toolTip.SetToolTip(this.panelColor, "请输选择颜色");
                toolTip.Show("请输选择颜色", panelColor);
            }
        }

        void colorRadio_Click(object sender, EventArgs e)
        {
            RadioButton typeBut = (RadioButton)sender;
            if (typeBut.Checked)
            {
                textColor.Text = typeBut.Text;
                toolTip.Show("请输选择尺码", panelSize, 1000);
            }
        }

        void sizeRadio_Click(object sender, EventArgs e)
        {
            RadioButton sizeBut = (RadioButton)sender;
            if (sizeBut.Checked)
            {
                textSize.Text = sizeBut.Text;
                toolTip.SetToolTip(this.textPairQty, "请输入双数");
                toolTip.Show("请输入双数", textPairQty, 1000);
            }

            textBox.BackColor = Color.White;
            textBox = textPairQty;
            textBox.BackColor = Color.Cyan;
        }
        #endregion

        //build grid column
        public void CreateUltraGridColumns(Infragistics.Win.UltraWinGrid.UltraGrid grid, string[] cols)
        {
            UltraGridBand ultraGridBand = new UltraGridBand("", -1);
            List<UltraGridColumn> list = new List<UltraGridColumn>();
            int i = 0;
            foreach (string col in cols)
            {
                UltraGridColumn ultraGridColumn = new Infragistics.Win.UltraWinGrid.UltraGridColumn(col.ToUpper());
                ultraGridColumn.Header.VisiblePosition = i++;
                list.Add(ultraGridColumn);
                ultraGridColumn.Header.Appearance.TextHAlign = HAlign.Center;

            }
            ultraGridBand.Columns.AddRange(list.ToArray());
            grid.DisplayLayout.BandsSerializer.Add(ultraGridBand);

        }

        public void SetQueryGridStyle(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            foreach (UltraGridColumn col in grid.DisplayLayout.Bands[0].Columns)
            {
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            grid.DisplayLayout.Override.SelectTypeCell = SelectType.Extended;
            grid.DisplayLayout.Override.SelectTypeCol = SelectType.Extended;

            grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

            grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal;
            grid.DisplayLayout.NewColumnLoadStyle = NewColumnLoadStyle.Hide;
            //    grid.DisplayLayout.CaptionVisible = DefaultableBoolean.False;

            grid.DisplayLayout.Appearance.BackColor = Color.White;
            grid.DisplayLayout.Override.CellAppearance.BorderColor = System.Drawing.Color.Silver;
            grid.DisplayLayout.Override.RowAppearance.BorderColor = System.Drawing.Color.Silver;
            // grid.DisplayLayout.Appearance.FontData.SizeInPoints = 10;
            grid.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.VisibleRows);
            grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;

            //Grid cell can be copy to clipboard
            grid.DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy;
            grid.PerformAction(UltraGridAction.Copy);


        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[1].Columns["size"].SortComparer = new SizeComparer();
            e.Layout.Bands[1].Columns["size"].SortIndicator = SortIndicator.Ascending;
            //this.ultraGrid1.Rows[0].Height = 25;

            e.Layout.Override.SelectTypeRow = SelectType.Single;
            e.Layout.Override.CellClickAction = CellClickAction.RowSelect;
            //列名
            e.Layout.Bands[0].Columns["cartonNumber"].Header.Caption = "箱号";

            // e.Layout.Bands[0].Columns["cartonNumber"].Layout.Override.DefaultColWidth = 60;
            e.Layout.Bands[0].Columns["qty"].Header.Caption = "开箱双数";
            e.Layout.Bands[0].Columns["qty2"].Header.Caption = "封箱双数";
            e.Layout.Bands[0].Columns["valid"].Header.Caption = "满箱";
            e.Layout.Bands[0].Columns["status"].Header.Caption = "状态";

            //   e.Layout.Bands[0].Columns["valid"].Header.Caption = "是否满箱";
            e.Layout.Bands[1].Columns["cartonNumber"].Header.Caption = "箱号";
            e.Layout.Bands[1].Columns["type"].Header.Caption = "款号";
            e.Layout.Bands[1].Columns["color"].Header.Caption = "颜色";
            e.Layout.Bands[1].Columns["size"].Header.Caption = "尺码";
            e.Layout.Bands[1].Columns["qty"].Header.Caption = "开箱双数";
            e.Layout.Bands[1].Columns["qty2"].Header.Caption = "封箱双数";
            e.Layout.Appearance.FontData.SizeInPoints = 12;
            e.Layout.Appearance.TextVAlign = VAlign.Middle;
            //  grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            ConditionValueAppearance cva = new ConditionValueAppearance();
            OperatorCondition oc = new OperatorCondition(ConditionOperator.Contains, "未保存");
            Infragistics.Win.Appearance apce1 = new Infragistics.Win.Appearance("apce1");
            apce1.ForeColor = Color.Red;
            apce1.BackColor = Color.Yellow;
            cva.Add(oc, apce1);
            e.Layout.Bands[0].Columns["status"].ValueBasedAppearance = cva;

            ConditionValueAppearance cva2 = new ConditionValueAppearance();
            OperatorCondition oc2 = new OperatorCondition(ConditionOperator.Contains, "否");
            Infragistics.Win.Appearance apce2 = new Infragistics.Win.Appearance("apce2");
            apce2.ForeColor = Color.Red;
            apce2.BackColor = Color.Yellow;
            cva2.Add(oc2, apce2);
            e.Layout.Bands[0].Columns["valid"].ValueBasedAppearance = cva2;

        }


        private DataTable GetTestData()
        {
            try
            {
                DataSet ds = new DataSet();
                //build new table
                DataTable dt = new DataTable("carton");
                dt.Columns.Add(new DataColumn("cartonNumber", typeof(System.String)));
                dt.Columns.Add(new DataColumn("qty", typeof(System.Int32)));
                dt.Columns.Add(new DataColumn("qty2", typeof(System.Int32)));
                dt.Columns.Add(new DataColumn("valid", typeof(System.String)));
                dt.Columns.Add(new DataColumn("status", typeof(System.String)));

                DataRow dr = dt.NewRow();
                dr["cartonNumber"] = "";
                dr["qty"] = 0;
                dr["qty2"] = 0;
                dr["status"] = "";
                dr["valid"] = "";
                dt.Rows.Add(dr);

                ds.Tables.Clear();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

                ;
            }
        }

        private DataTable GetTestData2()
        {
            try
            {
                DataSet ds = new DataSet();

                //build new table
                DataTable dt = new DataTable("box");
                dt.Columns.Add(new DataColumn("cartonNumber", typeof(System.String)));
                dt.Columns.Add(new DataColumn("type", typeof(System.String)));
                dt.Columns.Add(new DataColumn("color", typeof(System.String)));
                dt.Columns.Add(new DataColumn("size", typeof(System.String)));
                dt.Columns.Add(new DataColumn("qty", typeof(System.Int32)));
                dt.Columns.Add(new DataColumn("qty2", typeof(System.Int32)));
                //put data to new table

                //for (int j = 1; j <= 10; j++)
                //{
                //    string binno = "BIN" + j + "QTY";
                //    DataRow dr = dt.NewRow();
                //    dr["cartonNumber"] = j + "";
                //    dr["type"] = "BType";
                //    dr["color"] = "Blue";
                //    dr["size"] = "35";
                //    dr["qty"] = j * 10;
                //    dt.Rows.Add(dr);

                //    DataRow dr2 = dt.NewRow();
                //    dr2["cartonNumber"] = j + "";
                //    dr2["type"] = "BType2";
                //    dr2["color"] = "Blue2";
                //    dr2["size"] = "35";
                //    dr2["qty"] = j * 10 + 1;
                //    dt.Rows.Add(dr2);
                //}


                ds.Tables.Clear();
                return dt;

            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {

                ;
            }
        }


        private void ultraGrid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Row.Expanded)
            {
                e.Cell.Row.CollapseAll();
            }
            else
            {
                e.Cell.Row.ExpandAll();
            }
        }

        private void btnNewTray_Click(object sender, EventArgs e)
        {
            #region ini text box
            toolTip.SetToolTip(this.textBox1, "请输入托盘编号");
            toolTip.Show("请输入托盘编号", textBox1, 2000);

            textBox1.Enabled = true;
            textBox1.Focus();
            txtQty.Enabled = true;

            textBox1.Text = "";
            textBox.Text = "";
            textBox2.Text = "";
            textColor.Text = "";
            textSize.Text = "";
            textType.Text = "";
            textPairQty.Text = "";

            txtQty.Text = "";
            ////201306 George --begin
            this.txtOpened.Text = "0";
            ////201306 George --end
            #endregion

            #region clear grid
            boxDt.Clear();
            cartonDt.Clear();

            while (ultraGrid1.Rows.Count >= 1)
            {
                this.ultraGrid1.Selected.Rows.Add(this.ultraGrid1.Rows[0]);
                this.ultraGrid1.DeleteSelectedRows(false);
            }
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, "请输入托盘号");
                textBox1.Focus();
                return;
            }
            if (txtQty.Text.Trim() == "")
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK, null, "请输入本托盘箱数");
                txtQty.Focus();
                return;
            }
            toolTip.SetToolTip(textBox2, "请输入箱号");
            toolTip.Show("请输入箱号", textBox2, 1000);

            textBox2.Enabled = true;
            textBox2.Focus();
            textBox2.Text = "";
            textSize.Text = "";
            textType.Text = "";
            textColor.Text = "";
            textPairQty.Text = "";
            textPairQty.Enabled = true;
            enterTextCarton(); //获得输入焦点

        }

        #region only number can be inputed
        private void textBox2_TextChanged(object sender, System.EventArgs e)
        {
            toolTip.SetToolTip(this.panelType, "请输选择款号");
            toolTip.Show("请输选择款号", panelType, 1000);
            lineChecked = false;
        }
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(txtQty.Text);
            }
            catch (Exception)
            {
                String s = System.Text.RegularExpressions.Regex.Replace(txtQty.Text, @"\D", "");
                txtQty.Text = s;
                txtQty.Focus();
            }
        }

        private void textPairQty_Enter(object sender, EventArgs e)
        {
            textBox.BackColor = Color.White;
            textBox = textPairQty;
            textBox.BackColor = Color.Cyan;

        }

        private void textPairQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(textPairQty.Text);
                toolTip.SetToolTip(this.butSaveRow, "请单击确认");
                toolTip.Show("请单击确认", butSaveRow, 1000);
            }
            catch (Exception)
            {
                String s = System.Text.RegularExpressions.Regex.Replace(textPairQty.Text, @"\D", "");
                textPairQty.Text = s;
                textPairQty.Focus();
            }
        }
        #endregion


        private void butSaveRow_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || textType.Text.Length == 0 || textSize.Text.Length == 0 || textPairQty.Text.Length == 0 || textColor.Text.Length == 0)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Error, System.Windows.Forms.MessageBoxButtons.OK, "输入错误", "款号，颜色，尺码，数量必须输入");
            }
            try
            {
                #region create table if it's null
                if (cartonDt == null)
                {
                    cartonDt = new DataTable("carton");
                    cartonDt.TableName = "carton";
                    cartonDt.Columns.Add(new DataColumn("cartonNumber", typeof(System.String)));
                    cartonDt.Columns.Add(new DataColumn("qty", typeof(System.Int32)));
                    cartonDt.Columns.Add(new DataColumn("qty2", typeof(System.Int32)));
                    cartonDt.Columns.Add(new DataColumn("valid", typeof(System.Int32)));
                    cartonDt.Columns.Add(new DataColumn("status", typeof(System.String)));

                }

                if (boxDt == null)
                {
                    boxDt = new DataTable("box");
                    boxDt.TableName = "box";
                    boxDt.Columns.Add(new DataColumn("cartonNumber", typeof(System.String)));
                    boxDt.Columns.Add(new DataColumn("type", typeof(System.String)));
                    boxDt.Columns.Add(new DataColumn("color", typeof(System.String)));
                    boxDt.Columns.Add(new DataColumn("size", typeof(System.String)));
                    boxDt.Columns.Add(new DataColumn("qty", typeof(System.Int32)));
                    boxDt.Columns.Add(new DataColumn("qty2", typeof(System.Int32)));
                }
                #endregion

                #region check befor save
                #region 构造当前箱
                DataTable checkCarton = new DataTable("box");
                checkCarton.TableName = "box";
                checkCarton.Columns.Add(new DataColumn("cartonNumber", typeof(System.String)));
                checkCarton.Columns.Add(new DataColumn("type", typeof(System.String)));
                checkCarton.Columns.Add(new DataColumn("color", typeof(System.String)));
                checkCarton.Columns.Add(new DataColumn("size", typeof(System.String)));
                checkCarton.Columns.Add(new DataColumn("qty", typeof(System.Int32)));
                checkCarton.Columns.Add(new DataColumn("qty2", typeof(System.Int32)));
                checkCarton.Columns.Add(new DataColumn("poid", typeof(System.String)));
                checkCarton.Columns.Add(new DataColumn("customerid", typeof(System.String)));

                DataRow dr3 = checkCarton.NewRow();
                dr3["cartonNumber"] = textBox2.Text;
                dr3["type"] = textType.Text;
                dr3["color"] = textColor.Text;
                dr3["size"] = textSize.Text;
                dr3["qty"] = int.Parse(textPairQty.Text); ;
                dr3["qty2"] = int.Parse(textPairQty.Text);
                dr3["poid"] = poID;
                dr3["customerid"] = customerid;

                checkCarton.Rows.Add(dr3);


                #endregion
                wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
                try
                {
                    //check 条件
                    string checkresult = client.PackBoxCheckGroup(checkCarton);
                    if (checkresult != "OK")
                    {
                        //检查条件不通过
                        baseForm.CreateMessageBox(Public_MessageBox.Error,
                                                     MessageBoxButtons.OK,
                                                      null, checkresult);
                        return;
                    }
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

                #endregion
                #region 获得开箱信息
                int openQtyGroup = 0;
                int openQtyBox = 0;
                string cartonNumber = textBox2.Text;
                DataSet rs = getOpenDetail(cartonNumber);
                if (rs != null)
                {
                    var resultGroup1 = (from p in rs.Tables[0].AsEnumerable()
                                        where p.Field<string>("styleno") == textType.Text
                                        && p.Field<string>("color") == textColor.Text
                                        && p.Field<string>("size") == textSize.Text
                                        select p).ToList();
                    if (resultGroup1.Count != 0)
                    {
                        DataRow currentGroup = resultGroup1[0];
                        openQtyGroup = int.Parse(currentGroup["pairqty"].ToString());
                    }


                    var openQtyOfCarton = (from p in rs.Tables[0].AsEnumerable()
                                           //   where p.Field<string>("styleno") == textType.Text
                                           //  && p.Field<string>("color") == textColor.Text
                                           //  && p.Field<string>("size") == textSize.Text
                                           select p.Field<Decimal>("pairqty")).Sum();

                    if (openQtyOfCarton != 0)
                    {
                        openQtyBox = (int)openQtyOfCarton;
                    }
                }
                #endregion

                #region 封箱与开箱数量不符

                if (openQtyBox == 0)   //没有开箱  
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Error, System.Windows.Forms.MessageBoxButtons.OK,
                                                   "提示信息", "没有开箱数据 ");
                    return;
                }
                else
                {
                    //已经开箱，但与开箱数量不符
                    if (openQtyGroup != int.Parse(textPairQty.Text))
                    {
                        DialogResult resultDlg = baseForm.CreateMessageBox(Public_MessageBox.Question, System.Windows.Forms.MessageBoxButtons.YesNo, "提示信息", "输入的数据与开箱数据不一致，是否继续？");
                        if (resultDlg == DialogResult.No)
                        {
                            return;  //放弃本次输入
                        }  ////201306 George --begin
                        else
                        {
                            frmLineCheck frm = new frmLineCheck();
                            DialogResult res = frm.ShowDialog();
                            if (res == System.Windows.Forms.DialogResult.Cancel)
                            {
                                return;
                            }

                        }
                        ////201306 George --end
                    }
                }
                #endregion

                #region WIP 不够Move
                int wip = getWIPQty(textType.Text, textColor.Text, textSize.Text);
                if (wip < int.Parse(textPairQty.Text))
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Error, System.Windows.Forms.MessageBoxButtons.OK,
                                                   "提示信息", "线上没有这么多制品，你输入的数量不对");
                    return;
                }

                #endregion

                #region if carton don't exists, insert it

                var result = (from p in cartonDt.AsEnumerable()
                              where p.Field<string>("cartonNumber") == textBox2.Text
                              select p).ToList();

                if (result == null || result.Count == 0)
                {
                    //put data to new table
                    DataRow dr = cartonDt.NewRow();
                    dr["cartonNumber"] = textBox2.Text;
                    dr["qty"] = openQtyBox;
                    dr["qty2"] = 0;
                    dr["valid"] = "";

                    dr["status"] = "未保存";
                    cartonDt.Rows.Add(dr);
                }
                else
                {
                    //如已经保存到数据库，不可以再修改//////////
                    string status = result[0]["status"].ToString();
                    if (status == "已保存")
                    {
                        baseForm.CreateMessageBox(Public_MessageBox.Warning, MessageBoxButtons.OK, "警告信息", "已经保存到数据库，不可以修改！");
                        return;
                    }
                    ////////////////////////////////////////////

                }
                #endregion

                #region if group exists, update qty, else insert
                var resultGroup = (from p in boxDt.AsEnumerable()
                                   where p.Field<string>("cartonNumber") == textBox2.Text
                                   && p.Field<string>("type") == textType.Text
                                   && p.Field<string>("color") == textColor.Text
                                   && p.Field<string>("size") == textSize.Text
                                   select p);


                if (resultGroup.ToList().Count > 0)
                {
                    foreach (DataRow item in resultGroup)
                    {
                        item["qty2"] = int.Parse(textPairQty.Text);
                    }
                }
                else
                {
                    DataRow dr2 = boxDt.NewRow();
                    dr2["cartonNumber"] = textBox2.Text;
                    dr2["type"] = textType.Text;
                    dr2["color"] = textColor.Text;
                    dr2["size"] = textSize.Text;
                    dr2["qty"] = openQtyGroup;
                    dr2["qty2"] = int.Parse(textPairQty.Text);
                    boxDt.Rows.Add(dr2);

                }
                #endregion

                #region   update shoes qty of this carton
                var curentCarton = (from p in cartonDt.AsEnumerable()
                                    where p.Field<string>("cartonNumber") == textBox2.Text
                                    select p).ToList();


                var qtyOfCarton = (from p in boxDt.AsEnumerable()
                                   where p.Field<string>("cartonNumber") == textBox2.Text
                                   select p.Field<Int32>("qty2")).Sum();

                DataRow currentCarton = curentCarton[0];
                currentCarton["qty2"] = qtyOfCarton;
                currentCarton["status"] = "未保存";

                if (qtyOfCarton == openQtyBox)
                {
                    currentCarton["valid"] = "是";
                }
                else
                {
                    currentCarton["valid"] = "否";
                }

                #endregion

                #region bind data
                try
                {
                    this.ultraGrid1.SetDataBinding(ds, "");
                }
                catch (Exception ex)
                {
                    ;// MicroMESMsgBox.ShowError(ExceptionParser.Parse(ex));
                }

                #endregion

                #region 展开当前箱，闭合其他箱
                foreach (UltraGridRow row in this.ultraGrid1.Rows)
                {
                    if (null != row.ChildBands)
                    {
                        string carton1 = row.GetCellValue("cartonNumber").ToString();
                        if (carton1 == textBox2.Text)
                        {

                            row.Activate();
                            row.ExpandAll();
                        }
                        else
                        {
                            row.CollapseAll();
                        }
                    }

                }
                #endregion

                System.Windows.Forms.ToolTip toolTip2 = new System.Windows.Forms.ToolTip();
                toolTip2.IsBalloon = true;
                toolTip2.UseAnimation = true;
                toolTip2.UseFading = true;
                toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                toolTip2.SetToolTip(butSave, "如果是本箱数据已经输入完成，请单击这里保存");
                toolTip2.Show("如果是本箱数据已经输入完成，请单击这里保存", butSave, 1000);

                toolTip.SetToolTip(panelType, "如果本箱还没完成，请继续选择款号");
                toolTip.Show("如果本箱还没完成，请继续选择款号", panelType, 2000);
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                ;
            }
        }

        private void checkLineWH()
        {
            lineChecked = true;
            if (textBox2.Text.Trim().Length > 0)
            {
                DataSet rs = getLineWarehouse(this.textBox2.Text);
                if (rs != null)
                {
                    //put data to new table
                    DataRow dr = cartonDt.NewRow();
                    dr["cartonNumber"] = textBox2.Text;
                    dr["qty"] = 0;
                    dr["status"] = "未保存";
                    dr["valid"] = "否";
                    cartonDt.Rows.Add(dr);

                    int cartonpair = 0;
                    int cartonpair2 = 0;
                    for (int i = 0; i < rs.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr2 = boxDt.NewRow();
                        dr2["cartonNumber"] = rs.Tables[0].Rows[i]["cartonNumber"];
                        dr2["type"] = rs.Tables[0].Rows[i]["styleno"];
                        dr2["color"] = rs.Tables[0].Rows[i]["color"];
                        dr2["size"] = rs.Tables[0].Rows[i]["size"];

                        int pair1 = int.Parse(rs.Tables[0].Rows[i]["qty1"].ToString());
                        int pair2 = int.Parse(rs.Tables[0].Rows[i]["qty2"].ToString());
                        dr2["qty"] = pair1;
                        dr2["qty2"] = pair2;

                        cartonpair += pair1;
                        cartonpair2 += pair2;
                        boxDt.Rows.Add(dr2);
                    }
                    dr["qty"] = cartonpair;
                    dr["qty2"] = cartonpair2;
                }




            }
            else
            {
                textBox2.Focus();
            }

        }

        #region delete shoes group
        private void butDelRow_Click(object sender, System.EventArgs e)
        {
            if (!(ultraGrid1.Rows.Count > 0 && ultraGrid1.ActiveRow.Activated))
            {
                return;
            }
            if (ultraGrid1.ActiveRow.Band.Index == 1)
            {
                string carton = this.ultraGrid1.ActiveRow.Cells["cartonNumber"].Text;
                string type = this.ultraGrid1.ActiveRow.Cells["type"].Text;
                string color = this.ultraGrid1.ActiveRow.Cells["color"].Text;
                string size = this.ultraGrid1.ActiveRow.Cells["size"].Text;
                int removeQty = int.Parse(this.ultraGrid1.ActiveRow.Cells["qty2"].Text);

                //如已经保存到数据库，就不允许删除
                var resultCarton = (from p in cartonDt.AsEnumerable()
                                    where p.Field<string>("cartonNumber") == carton
                                    select p).ToList();
                string status = resultCarton[0]["status"].ToString();
                if (status == "已保存")
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Warning, MessageBoxButtons.OK, "警告信息", "已经保存到数据库，不可以修改！");
                    return;
                }
                //如还没有保存到数据库，允许删除

                var resultGroup = (from p in boxDt.AsEnumerable()
                                   where p.Field<string>("cartonNumber") == carton
                                   && p.Field<string>("type") == type
                                   && p.Field<string>("color") == color
                                   && p.Field<string>("size") == size
                                   select p).ToList();
                ds.Tables["box"].Rows.Remove(resultGroup[0]);

                #region 修改carton数据
                for (int i = 0; i < cartonDt.Rows.Count; i++)
                {
                    if (cartonDt.Rows[i]["cartonNumber"].ToString() == carton)
                    {

                        cartonDt.Rows[i]["qty2"] = int.Parse((cartonDt.Rows[i]["qty2"]).ToString()) - removeQty;
                        if (int.Parse((cartonDt.Rows[i]["qty"]).ToString()) != int.Parse((cartonDt.Rows[i]["qty2"]).ToString()))
                        {
                            cartonDt.Rows[i]["valid"] = "否";
                        }

                        cartonDt.Rows[i]["status"] = "未保存";
                        break;
                    }
                }
                #endregion
            }

        }
        #endregion

        #region delete carton  --修改
        private void butDelBox_Click(object sender, System.EventArgs e)
        {
            if (!(ultraGrid1.Rows.Count > 0 && ultraGrid1.ActiveRow.Activated))
            {
                return;
            }
            if (ultraGrid1.ActiveRow.Band.Index == 0)
            {
                string carton = this.ultraGrid1.ActiveRow.Cells["cartonNumber"].Text;
                string status = this.ultraGrid1.ActiveRow.Cells["status"].Text;
                if (status == "已保存" || status == "已保存(暂存线上)")
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Warning, System.Windows.Forms.MessageBoxButtons.OK, "警告信息", "已经保存到数据库，不能删除");
                }
                else
                {
                    // bool res = this.deleteCarton(carton);

                    var resultGroup = (from p in boxDt.AsEnumerable()
                                       where p.Field<string>("cartonNumber") == carton
                                       select p).ToList();
                    int groupCount = resultGroup.Count;
                    for (int i = 0; i < groupCount; i++)
                    {
                        ds.Tables["box"].Rows.Remove(resultGroup[i]);
                    }

                    var boxGroup = (from p in cartonDt.AsEnumerable()
                                    where p.Field<string>("cartonNumber") == carton
                                    select p).ToList();
                    ds.Tables["carton"].Rows.Remove(boxGroup[0]);
                }

            }

        }
        private void butSave_Click(object sender, System.EventArgs e)
        {
            if (this.textBox2.Text.Trim().Length == 0)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Warning, System.Windows.Forms.MessageBoxButtons.OK, "警告信息", "请先输入箱号");
                return;
            }
            int cartonNo = int.Parse(textBox2.Text);
            ////201306 George   --Begin
            if (cartonDt.Rows.Count <= 0)
            {

                //    baseForm.CreateMessageBox(Public_MessageBox.Warning ,   MessageBoxButtons.OK,         null, "没有输入数据");
                //    return ;
                DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                 MessageBoxButtons.YesNo,
                                                     null, "没有输入数据,你是否要装空箱?");

                if (result == DialogResult.Yes)
                {    //空箱装，但要输入密码验证
                    frmLineCheck frm = new frmLineCheck();
                    DialogResult res = frm.ShowDialog();
                    if (res == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        ////装空箱
                        if (saveCarton(cartonNo + ""))
                        {
                            this.txtOpened.Text = (int.Parse(txtOpened.Text) + 1) + "";
                            baseForm.CreateMessageBox(Public_MessageBox.Error, MessageBoxButtons.OK,
                                                       null, "保存成功！");
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {   //空箱不装，返回
                    return;
                }

            }
            ////201306 George   --End
            String checkresult = "";
            #region check with original info
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {
                #region 构造当前箱
                DataTable curentCarton = (from p in boxDt.AsEnumerable()
                                          where p.Field<string>("cartonNumber") == cartonNo.ToString()
                                          select p).CopyToDataTable();
                curentCarton.TableName = "curentCarton";
                curentCarton.Columns.Add(new DataColumn("poid", typeof(System.String)));
                curentCarton.Columns.Add(new DataColumn("customerid", typeof(System.String)));
                foreach (DataRow item in curentCarton.Rows)
                {
                    item["poid"] = poID;
                    item["customerid"] = customerid;
                }
                #endregion
                //check 条件
                checkresult = client.PackBoxCheckGroup(curentCarton);
                if (checkresult == "OK")
                {

                    List<string> status = (from p in cartonDt.AsEnumerable()
                                           where p.Field<string>("cartonNumber") == cartonNo.ToString()
                                           select p.Field<string>("valid")).ToList<string>();
                    if (status[0] == "否")
                    {
                        #region 不满箱
                        string[] butText = { "直接封箱", "暂时保存" };
                        DialogResult result = baseForm.CreateMessageBox(Public_MessageBox.Question,
                                                                           MessageBoxButtons.YesNo,
                                                          null, "本箱不满箱，是否要封箱?", butText);

                        if (result == DialogResult.No)
                        {
                            this.saveTempInfo(curentCarton);
                            #region 修改为已经保存
                            for (int i = 0; i < cartonDt.Rows.Count; i++)
                            {
                                if (cartonDt.Rows[i]["cartonNumber"].ToString() == textBox2.Text)
                                {
                                    cartonDt.Rows[i]["status"] = "已保存(暂存线上)";

                                    break;
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            ////201307  George --Begin
                        //    frmLineCheck frm = new frmLineCheck();
                        //    DialogResult res = frm.ShowDialog();
                        //    if (res == System.Windows.Forms.DialogResult.Cancel)
                        //    {
                        //        return;
                        //    }
                            ////201307  George --End
                            saveCarton(curentCarton);
                            #region 修改为已经保存
                            for (int i = 0; i < cartonDt.Rows.Count; i++)
                            {
                                if (cartonDt.Rows[i]["cartonNumber"].ToString() == textBox2.Text)
                                {
                                    cartonDt.Rows[i]["status"] = "已保存";
                                    break;
                                }
                            }
                            ////201306 George --begin
                            this.txtOpened.Text = (int.Parse(txtOpened.Text) + 1) + "";
                            ////201306 George --end
                        }
                            #endregion
                        #endregion
                    }
                    else
                    {
                        #region 满箱
                        saveCarton(curentCarton);
                        #region 修改为已经保存
                        for (int i = 0; i < cartonDt.Rows.Count; i++)
                        {
                            if (cartonDt.Rows[i]["cartonNumber"].ToString() == textBox2.Text)
                            {
                                cartonDt.Rows[i]["status"] = "已保存";
                                break;
                            }
                        }
                        ////201306 George --begin
                        this.txtOpened.Text = (int.Parse(txtOpened.Text) + 1) + "";
                        ////201306 George --end
                        #endregion
                    }

                        #endregion
                }
                else
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Error,
                                                 MessageBoxButtons.OK,
                                                  null, checkresult);
                }

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
            #endregion
        }



        private void butView_Click(object sender, System.EventArgs e)
        {
            if (this.textBox2.Text.Trim().Length == 0)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Warning, System.Windows.Forms.MessageBoxButtons.OK, "警告信息", "请先输入箱号");
                return;
            }
            var result = (from p in cartonDt.AsEnumerable()
                          where p.Field<string>("cartonNumber") == textBox2.Text
                          select p).ToList();
            if (result.Count != 0)
            {
                baseForm.CreateMessageBox(Public_MessageBox.Warning, System.Windows.Forms.MessageBoxButtons.OK, "警告信息", "该箱号已经输入，不可重复");
                return;
            }

            DataSet rs = getMixCarton(this.textBox2.Text);

            if (rs != null && rs.Tables[0].Rows.Count != 0)
            {

                #region WIP 不够  2012/7/14
                for (int i = 0; i < rs.Tables[0].Rows.Count; i++)
                {
                    string type = rs.Tables[0].Rows[i]["type"].ToString();
                    string color = rs.Tables[0].Rows[i]["color"].ToString();
                    string size = rs.Tables[0].Rows[i]["size"].ToString();
                    string qty = rs.Tables[0].Rows[i]["qty"].ToString();
                    int wip = getWIPQty(type, color, size);

                    if (wip < int.Parse(qty))
                    {
                        baseForm.CreateMessageBox(Public_MessageBox.Error, System.Windows.Forms.MessageBoxButtons.OK,
                                                       "提示信息", "线上没有这么多制品，你输入的数量不对");
                        return;
                    }
                }
                #endregion

                //put data to new table
                DataRow dr = cartonDt.NewRow();
                dr["cartonNumber"] = textBox2.Text;
                dr["qty"] = 0;
                dr["status"] = "未保存";
                cartonDt.Rows.Add(dr);

                int cartonpair = 0;
                for (int i = 0; i < rs.Tables[0].Rows.Count; i++)
                {
                    DataRow dr2 = boxDt.NewRow();
                    dr2["cartonNumber"] = rs.Tables[0].Rows[i]["cartonNumber"];
                    dr2["type"] = rs.Tables[0].Rows[i]["type"];
                    dr2["color"] = rs.Tables[0].Rows[i]["color"];
                    dr2["size"] = rs.Tables[0].Rows[i]["size"];
                    int pair = int.Parse(rs.Tables[0].Rows[i]["qty"].ToString());
                    dr2["qty"] = pair;
                    dr2["qty2"] = pair;
                    cartonpair += pair;
                    boxDt.Rows.Add(dr2);
                }
                dr["qty"] = cartonpair;
                dr["qty2"] = cartonpair;
                dr["valid"] = "是";
            }


        }

        #endregion

        #region call WCF

        private void saveTempInfo(DataTable curentCarton)
        {
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {
                client.lineWarehouseSave(curentCarton, baseForm.CurrentContextInfo);
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

        private void saveCarton(DataTable curentCarton)
        {
            string trayID = textBox1.Text;
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {
                client.PackBoxSaveCarton(curentCarton, trayID, baseForm.CurrentContextInfo);
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

        //201306 George --Begin
        //save dummy carton
        private bool saveCarton(string curentCartonNumber)
        {
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {
                //check 
                int checkResult = client.canSaveEnptycarton(customerid, poID, curentCartonNumber, "Packing", currStep, "", baseForm.CurrentContextInfo);
                if (checkResult == 0)
                {
                    bool saved = client.PackBoxSaveDummyCarton(customerid, poID, curentCartonNumber, baseForm.CurrentContextInfo);
                    if (saved)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (checkResult == 1)
                    {
                        baseForm.CreateMessageBox(Public_MessageBox.Warning, System.Windows.Forms.MessageBoxButtons.OK, "警告信息", "组上还有鞋子，不能装空箱");

                    }
                    if (checkResult == 2)
                    {
                        baseForm.CreateMessageBox(Public_MessageBox.Warning, System.Windows.Forms.MessageBoxButtons.OK, "警告信息", "该箱已经装箱或封箱");

                    }
                    if (checkResult == 3)
                    {
                        baseForm.CreateMessageBox(Public_MessageBox.Warning, System.Windows.Forms.MessageBoxButtons.OK, "警告信息", " 如果是检品+X线，请检查该箱是否已经装箱；如果仅X线，请检查是否开箱。）");

                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
                return false;
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
        }
        //201306 George --End
        private void updateCarton(DataTable curentCarton)
        {
            string trayID = textBox1.Text;
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {
                client.OpenBoxUpdateCarton(curentCarton, trayID, baseForm.CurrentContextInfo, this.customerid, textBox2.Text, poID);
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

        private void GetPOColorAndType()
        {
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {

                colour = client.GetColorListByPO(poID, baseForm.CurrentContextInfo);


                type = client.GetTypeListByPO(poID, baseForm.CurrentContextInfo);
                size = client.GetSizeListByPO(poID, baseForm.CurrentContextInfo);

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

        private bool deleteCarton(string carton)
        {
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {
                bool res = client.isShipped(this.customerid, this.poID, carton, baseForm.CurrentContextInfo);

                if (res)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, System.Windows.Forms.MessageBoxButtons.OK, "警告信息", "该箱不可以删除，已经发货了");
                    return false;
                }
                else
                {
                    bool res2 = client.DeleteBox(this.customerid, carton, this.poID, baseForm.CurrentContextInfo.CurrentUser, baseForm.CurrentContextInfo);
                    return res2;
                }

            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
                return false;
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
        }

        private DataSet getOpenDetail(string carton)
        {
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {
                DataSet res = client.GetOpenBox(this.customerid, this.poID, carton, "Pack", currStep, baseForm.CurrentContextInfo);

                if (res.Tables[0].Rows.Count > 0)
                {
                    // baseForm.CreateMessageBox(Public_MessageBox.Information, System.Windows.Forms.MessageBoxButtons.OK, "信息", "本箱套装，可按‘保存本箱’直接保存");
                    return res;
                }
                else
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, System.Windows.Forms.MessageBoxButtons.OK, "信息", "没有开箱信息。");
                    return null;
                }

            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
                return null;
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
        }


        private DataSet getMixCarton(string carton)
        {
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {
                DataSet res = client.GetMixBox(this.customerid, this.poID, carton, baseForm.CurrentContextInfo);

                if (res.Tables[0].Rows.Count > 0)
                {
                    // baseForm.CreateMessageBox(Public_MessageBox.Information, System.Windows.Forms.MessageBoxButtons.OK, "信息", "本箱套装，可按‘保存本箱’直接保存");
                    return res;
                }
                else
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, System.Windows.Forms.MessageBoxButtons.OK, "信息", "本箱不是套装，请输入详细装箱信息。");
                    return null;
                }

            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
                return null;
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
        }
        private DataSet getLineWarehouse(string carton)
        {
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();
            try
            {
                DataSet res = client.getLineWarehouse(this.customerid, this.poID, carton, baseForm.CurrentContextInfo.WorkGroup, baseForm.CurrentContextInfo);

                if (res.Tables[0].Rows.Count > 0)
                {
                    baseForm.CreateMessageBox(Public_MessageBox.Information, System.Windows.Forms.MessageBoxButtons.OK, "信息", "本箱暂存在线上，系统将显示上次输入的数据，请按实际情况修改");
                    return res;
                }
                return null;
            }
            catch (Exception ex)
            {
                MESMsgBox.ShowError(ExceptionParser.Parse(ex));
                return null;
            }
            finally
            {
                baseForm.ResetCursor();
                baseForm.CloseWCF(client);
            }
        }

        private int getWIPQty(string style, string color, string size)
        {
            int wip = -1;
            wsPAD.IwsPADClient client = new wsPAD.IwsPADClient();

            try
            {
                wip = client.getWIPByPO(customerid, poID, style, color, size, baseForm.CurrentContextInfo.WorkGroup, "Pack", currStep, baseForm.CurrentContextInfo);
                return wip;
            }
            catch (Exception ex)
            {
                return -1;
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

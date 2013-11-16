using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using GENLSYS.MES.Common;
using GENLSYS.MES.DataContracts;
using MicroMES2.Common;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.Win.Common.Classes;

namespace GENLSYS.MES.Win.Report
{
    public class ExcelExport
    {
        Application app;
        Workbook workBook;
        Worksheet workSheet;
        private string templatePath = System.Windows.Forms.Application.StartupPath + "\\Report\\Template\\";
        private string excelRptPath = System.Windows.Forms.Application.StartupPath + "\\Report\\ExcelRpt\\";
        private BaseForm baseForm = new BaseForm();

        public void ExportRequestPay(string templateFile, DateTime rptDate, string currency, System.Data.DataTable shippingDt, System.Data.DataTable dtlDt, System.Data.DataTable retrieveDt, System.Data.DataTable iqcDt
            , System.Data.DataTable pricingDt, System.Data.DataTable exDt, List<tinprequestpaydtl> lstRequestPayDtl)
        {
            try
            {
                OpenExcel(templatePath + templateFile+".xls", 1);

                app.ActiveWindow.DisplayGridlines = false;

                string customerId = "";
                string checkType = "";
                string lang = "ZH";

                List<tsysstaticvalue> lstStaticValue = GENLSYS.MES.Common.Parameter.CURRENT_STATIC_VALUE as List<tsysstaticvalue>;
                var langq = from p in lstStaticValue
                            where p.svvalue.Equals(templateFile)
                            select p;
                if (langq.Count() > 0)
                {
                    lang = langq.ElementAt(0).svresourceid.ToUpper();
                }

                #region Header
                //入库时间
                var custordernoq = (from p in dtlDt.AsEnumerable()
                                    select p["custorderno"].ToString()).Distinct();
                List<string> lstOrder = new List<string>();
                foreach (string custorderno in custordernoq)
                {
                    if (!lstOrder.Contains(custorderno))
                    {
                        lstOrder.Add(custorderno);
                    }
                }

                setCellValue(5, 9, "契約NO," + shippingDt.Rows[0]["shippingno"].ToString());

                DateTime rdate = GetReceiveDate(lstOrder.ToArray<string>());
                setCellValue(11, 3, rdate);
                ((Range)workSheet.Cells[11, 3]).NumberFormat = "yyyy-MM-dd";

                
                setCellValue(7, 5, currency);
                if (shippingDt.Rows.Count > 0)
                {
                    setCellValue(4, 3, shippingDt.Rows[0]["invoicetitle"].ToString());
                    setCellValue(12, 3, Convert.ToDateTime(shippingDt.Rows[0]["shippeddate"]));
                    ((Range)workSheet.Cells[12, 3]).NumberFormat = "yyyy-MM-dd";
                    setCellValue(6, 9, Convert.ToDateTime(shippingDt.Rows[0]["shippeddate"]));
                    ((Range)workSheet.Cells[6, 9]).NumberFormat = "yyyy年MM月dd日";
                    setCellValue(13, 3, shippingDt.Rows[0]["customername"]);
                    customerId = shippingDt.Rows[0]["customerid"].ToString();
                }
               
                #endregion

                int startRow = 17;
                int rownum = 0;

                #region 一次检
                var qByStyleNo = from p in dtlDt.AsEnumerable()
                                 group p by new
                                 {
                                     custorderno = p["custorderno"].ToString(),
                                     styleno = p["styleno"].ToString(),
                                     factory = p["factory"].ToString(),
                                     checktype = p["checktype"].ToString()
                                 } into g
                                 select new
                                 {                                     
                                     g.Key.custorderno,
                                     g.Key.styleno,
                                     g.Key.factory,
                                     g.Key.checktype,
                                     totalpairqty = g.Sum(p => Convert.ToInt16(p["pairqty"]))
                                 };

                foreach (var data in qByStyleNo)
                {
                    int row = startRow + rownum;
                    ((Range)workSheet.Rows[row, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                    setCellValue(row, 2, data.factory);
                    setCellValue(row, 3, data.custorderno);
                    ((Range)workSheet.Cells[row, 3]).NumberFormatLocal = "@";
                    setCellValue(row, 4, data.styleno);
                    setCellValue(row, 8, data.totalpairqty);
                    if (data.checktype.Equals("I"))
                    {
                        setCellValue(row, 5, lang.Equals("ZH") ? "检品" : "一次検品");
                    }
                    else if (data.checktype.Equals("X"))
                    {
                        setCellValue(row, 5, lang.Equals("ZH") ? "X线" : "Ｘ線");
                    }
                    else
                    {
                        setCellValue(row, 5, lang.Equals("ZH") ? "检品+X线" : "一次検品、Ｘ線");
                    }
                    var iqcq = from p in iqcDt.AsEnumerable()
                                where p["styleno"].ToString().Equals(data.styleno.ToString())
                                    && p["customerid"].ToString().Equals(customerId)
                                select p;
                    if (iqcq.Count() > 0)
                    {
                        string shoeCategory = iqcq.ElementAt(0)["category"].ToString();
                        Double bootHeight = Convert.ToDouble(iqcq.ElementAt(0)["bootheight"]);
                        setCellValue(row, 6, GetShoeCategory(shoeCategory, lang));

                        var pricingq = from p in pricingDt.AsEnumerable()
                                         where p["category"].ToString().Equals(shoeCategory)
                                         && Convert.ToDouble(p["sbootheight"]) <= bootHeight
                                         && Convert.ToDouble(p["ebootheight"]) >= bootHeight
                                         && p["checktype"].ToString().Equals(data.checktype)
                                         select p;

                        if (pricingq.Count() > 0)
                        {
                            setCellValue(row, 9, pricingq.ElementAt(0)["unit"].ToString());

                            if (!pricingq.ElementAt(0)["currency"].ToString().Trim().Equals(currency))
                            {
                                var exckq = from p in exDt.AsEnumerable()
                                            where p["fromcurrency"].ToString().Equals(pricingq.ElementAt(0)["currency"].ToString())
                                            && p["tocurrency"].ToString().Equals(currency)
                                            select p;
                                if (exckq.Count() > 0)
                                {
                                    setCellValue(row, 7, Convert.ToDouble(pricingq.ElementAt(0)["price"]) * Convert.ToDouble(exckq.ElementAt(0)["rate"]));
                                }
                            }
                            else
                            {
                                setCellValue(row, 7, pricingq.ElementAt(0)["price"]);
                            }
                            SetCurrencyFormat((Range)workSheet.Cells[row, 7], currency, true);
                            
                        }
                       
                    }

                    ((Range)workSheet.Cells[row, 10]).Formula = "=G"+row+"*H"+row;
                    SetCurrencyFormat((Range)workSheet.Cells[row, 10],currency,true);

                    if (checkType.Equals(""))
                    {
                        checkType = data.checktype;
                    }
                    else
                    {
                        if (checkType.Equals(data.checktype))
                        {
                            checkType = "IX";
                        }
                    }

                    rownum++;
                }                
                #endregion

                #region 再检
                var qRetrieve = from p in retrieveDt.AsEnumerable()
                                where !p["checktype"].ToString().Equals("X")
                                 group p by new
                                 {
                                     custorderno = p["custorderno"].ToString(),
                                     styleno = p["styleno"].ToString(),
                                     factory = p["factory"].ToString(),
                                     checktype = p["checktype"].ToString()
                                 } into g
                                 select new
                                 {
                                     g.Key.custorderno,
                                     g.Key.styleno,
                                     g.Key.factory,
                                     g.Key.checktype,
                                     totalpairqty = g.Sum(p => Convert.ToInt16(p["pairqty"]))
                                 };
                foreach (var data in qRetrieve)
                {                    
                    int row = startRow + rownum;
                    ((Range)workSheet.Rows[row, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                    setCellValue(row, 2, data.factory);
                    setCellValue(row, 3, data.custorderno);
                    ((Range)workSheet.Cells[row, 3]).NumberFormatLocal = "@";
                    setCellValue(row, 4, data.styleno);
                    setCellValue(row, 8, data.totalpairqty);
                    if (data.checktype.Equals("I"))
                    {
                        //setCellValue(row, 5, "检品再检");
                        setCellValue(row, 5, lang.Equals("ZH") ? "再检" : "再検品");
                    }
                    //else if (data.checktype.Equals("X"))
                    //{
                    //    //setCellValue(row, 5, "X线再检");
                    //    setCellValue(row, 5, "再検品");
                    //}
                    else
                    {
                        //setCellValue(row, 5, "全检再检");
                        setCellValue(row, 5, lang.Equals("ZH") ? "再检" : "再検品");
                    }
                    var iqcq = from p in iqcDt.AsEnumerable()
                                where p["styleno"].ToString().Equals(data.styleno.ToString())
                                    && p["customerid"].ToString().Equals(customerId)
                                select p;
                    if (iqcq.Count() > 0)
                    {
                        string shoeCategory = iqcq.ElementAt(0)["category"].ToString();
                        Double bootHeight = Convert.ToDouble(iqcq.ElementAt(0)["bootheight"]);
                        setCellValue(row, 6, GetShoeCategory(shoeCategory,lang));

                        var pricingq = from p in pricingDt.AsEnumerable()
                                       where p["category"].ToString().Equals(shoeCategory)
                                       && Convert.ToDouble(p["sbootheight"]) <= bootHeight
                                       && Convert.ToDouble(p["ebootheight"]) >= bootHeight
                                       && p["checktype"].ToString().Equals(data.checktype.ToString().Equals("IX")?"I":data.checktype)
                                       select p;
                        if (pricingq.Count() > 0)
                        {
                            setCellValue(row, 9, pricingq.ElementAt(0)["unit"].ToString());
                            double price = 0;
                            if (pricingq.ElementAt(0)["reworkprice"] == null || Convert.ToDouble(pricingq.ElementAt(0)["reworkprice"]) == 0)
                            {
                                price = Convert.ToDouble(pricingq.ElementAt(0)["price"]) * Convert.ToDouble(pricingq.ElementAt(0)["reworkratio"]);
                            }
                            else
                            {
                                price = Convert.ToDouble(pricingq.ElementAt(0)["reworkprice"]);
                            }
                            if (!pricingq.ElementAt(0)["currency"].ToString().Trim().Equals(currency))
                            {
                                
                                var exckq = from p in exDt.AsEnumerable()
                                            where p["fromcurrency"].ToString().Equals(pricingq.ElementAt(0)["currency"].ToString())
                                            && p["tocurrency"].ToString().Equals(currency)
                                            select p;
                                if (exckq.Count() > 0)
                                {                                    
                                    setCellValue(row, 7, price * Convert.ToDouble(exckq.ElementAt(0)["rate"]));
                                }
                            }
                            else
                            {
                                setCellValue(row, 7, price);
                            }
                            SetCurrencyFormat((Range)workSheet.Cells[row, 7], currency, true);
                        }
                    }

                    ((Range)workSheet.Cells[row, 10]).Formula = "=G" + row + "*H" + row;
                    SetCurrencyFormat((Range)workSheet.Cells[row, 10], currency, true);
                    rownum++;
                }
                #endregion

                for (int i = 17; i < startRow + rownum; i++)
                {
                    for (int j = 2; j <= 10; j++)
                    {
                        ((Range)workSheet.Cells[i, j]).Borders.LineStyle = 1;
                        ((Range)workSheet.Cells[i, j]).ShrinkToFit = true;
                    }
                }

                #region 其他费用
                foreach (tinprequestpaydtl dtl in lstRequestPayDtl)
                {
                    int row = startRow + rownum;
                    ((Range)workSheet.Rows[row, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                    setCellValue(row, 2, dtl.itemname);
                    setCellValue(row, 8, dtl.qty);
                    setCellValue(row, 9, dtl.unit);
                    if (!dtl.currency.Trim().Equals(currency))
                    {
                        var exckq = from p in exDt.AsEnumerable()
                                    where p["fromcurrency"].ToString().Equals(dtl.currency)
                                    && p["tocurrency"].ToString().Equals(currency)
                                    select p;
                        if (exckq.Count() > 0)
                        {
                            setCellValue(row, 7, Convert.ToDouble(dtl.price) * Convert.ToDouble(exckq.ElementAt(0)["rate"]));
                        }
                    }
                    else
                    {
                        setCellValue(row, 7, dtl.price);
                    }
                    SetCurrencyFormat((Range)workSheet.Cells[row, 7], currency, true);

                    ((Range)workSheet.Cells[row, 10]).Formula = "=G" + row + "*H" + row;
                    SetCurrencyFormat((Range)workSheet.Cells[row, 10], currency, true);
                    rownum++;
                }
                for (int i = startRow + rownum -lstRequestPayDtl.Count; i < startRow + rownum; i++)
                {
                    workSheet.get_Range("B" + i, "F" + i).MergeCells = true;
                    workSheet.get_Range("B" + i, "F" + i).Borders.LineStyle = 1;
                    ((Range)workSheet.Cells[i, 7]).Borders.LineStyle = 1;
                    ((Range)workSheet.Cells[i, 8]).Borders.LineStyle = 1;
                    ((Range)workSheet.Cells[i, 9]).Borders.LineStyle = 1;
                    ((Range)workSheet.Cells[i, 10]).Borders.LineStyle = 1;                    
                }
                #endregion
                               

                Range rowRange = workSheet.Range["B17", "J" + (startRow + rownum - 1)];
                FormatCondition cond = rowRange.FormatConditions.Add(XlFormatConditionType.xlExpression, Type.Missing, "=MOD(ROW(),2)=0");
                cond.Interior.Color = Color.FromArgb(255, 255, 153);
                
                ((Range)workSheet.Cells[startRow + rownum, 10]).Formula = "=SUM(J" + startRow + ":J" + (startRow+rownum-1)+")";
                ((Range)workSheet.Cells[startRow + rownum, 10]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                SetCurrencyFormat((Range)workSheet.Cells[startRow + rownum, 10], currency, true);

                ((Range)workSheet.Cells[7, 6]).Formula = "=J" + (startRow + rownum);
                SetCurrencyFormat((Range)workSheet.Cells[7,6], currency, false);

                if (checkType.Equals("I")){
                    setCellValue(10, 3, lang.Equals("ZH") ? "检品" : "一次検品");
                }else if (checkType.Equals("X")){
                    setCellValue(10, 3, lang.Equals("ZH") ? "X线" : "Ｘ線");
                }else{
                    setCellValue(10, 3, lang.Equals("ZH") ? "检品+X线" : "一次検品、Ｘ線");
                }
                ((Range)workSheet.Cells[7, 6]).Formula = "=J" + (startRow + rownum);                

                saveAsExcel(templateFile + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");

                app.Visible = true;
            }
            catch (Exception ex)
            {
                CloseExcel();
                throw ex;
            }
        }

        public void ExportInspectRpt(System.Data.DataTable headerDt, System.Data.DataTable reasonCodeDt, System.Data.DataTable infoDt, System.Data.DataTable failDt, System.Data.DataTable hisDt, System.Data.DataTable shipDt, System.Data.DataTable userDt, string lang, string custorderno)
        {
            try
            {                
                if (lang != null && lang.Equals("JP"))
                {
                    OpenExcel(templatePath + "InspectRptJP.xls", 1);
                }
                else
                {
                    OpenExcel(templatePath + "InspectRpt.xls", 1);
                }

                #region Prepare data
                DateTime rdate = GetReceiveDate(new string[] { custorderno });
                DateTime sdate = GetShippingDate(new string[] { custorderno });
                List<string> managerList = new List<string>();
                List<string> responderList = new List<string>();
                List<string> xresponderList = new List<string>();
                List<string> checktypeList = new List<string>();
                var muq= from p in userDt.AsEnumerable() 
                         where p["usertype"].ToString().Equals("BusinessManager")
                         select p;
                foreach (DataRow muRow in muq)
                {
                    if (!managerList.Contains(muRow["username"].ToString()))
                    {
                        managerList.Add(muRow["username"].ToString());
                    }
                }
                var rpq = from p in userDt.AsEnumerable()
                          where p["usertype"].ToString().Equals("Responder")
                          select p;
                foreach (DataRow rpRow in rpq)
                {
                    if (!responderList.Contains(rpRow["username"].ToString()))
                    {
                        responderList.Add(rpRow["username"].ToString());
                    }
                }
                var xrpq = from p in userDt.AsEnumerable()
                          where p["usertype"].ToString().Equals("XResponder")
                          select p;
                foreach (DataRow xrpRow in xrpq)
                {
                    if (!xresponderList.Contains(xrpRow["username"].ToString()))
                    {
                        xresponderList.Add(xrpRow["username"].ToString());
                    }
                }

                var ixq = (from p in infoDt.AsEnumerable()
                           where p["checktype"].Equals("IX")
                           select p).Count();
                if (ixq > 0)
                {
                    checktypeList.Add("I");
                    checktypeList.Add("X");
                }
                else
                {
                    var iq = (from p in infoDt.AsEnumerable()
                               where p["checktype"].Equals("I")
                               select p).Count();
                    if (iq > 0)
                    {
                        checktypeList.Add("I");
                    }
                    var xq = (from p in infoDt.AsEnumerable()
                              where p["checktype"].Equals("X")
                              select p).Count();
                    if (xq > 0)
                    {
                        checktypeList.Add("X");
                    }
                }

                List<System.Data.DataRow> lstInfo = infoDt.AsEnumerable().ToList<System.Data.DataRow>();
                lstInfo.Sort(new GENLSYS.MES.Win.Common.Classes.DataRowComparer());
                #endregion

                #region 检品
                if (checktypeList.Contains("I"))
                {
                    int rcNum1 = 0;
                    int rcNum2 = 0;
                    int rcNum3 = 0;
                    int rcNum4 = 0;
                    int col = 0;

                    if (lang != null && lang.Equals("JP"))
                    {
                        setCellValue(6, 7, "外観");
                        setCellValue(6, 12, "底部");
                        setCellValue(6, 14, "その他");
                    }
                    else
                    {
                        setCellValue(6, 7, "帮面部分");
                        setCellValue(6, 12, "底部、跟部不良");
                        setCellValue(6, 14, "其他");
                    }

                    #region 帮面部分 ReasonCode
                    var reasoncodeq1 = from p in reasonCodeDt.AsEnumerable()
                                       where p["reasoncategory"].ToString().Equals("Repair-检品-帮面部分")
                                       select p;
                    rcNum1 = reasoncodeq1.Count();
                    if (rcNum1 > 5)
                    {
                        for (int i = 0; i < rcNum1 - 5; i++)
                        {
                            ((Range)workSheet.Columns[i + 11, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                            ((Range)workSheet.Cells[7, i + 11]).Borders.LineStyle = 1;
                            ((Range)workSheet.Cells[8, i + 11]).Borders.LineStyle = 1;
                        }
                        workSheet.get_Range(IndexToColumn(11) + "3", IndexToColumn(11 + rcNum1 - 5) + "3").MergeCells = true;
                        workSheet.get_Range(IndexToColumn(11) + "4", IndexToColumn(11 + rcNum1 - 5) + "4").MergeCells = true;
                    }
                    else
                    {
                        rcNum1 = 5;
                    }

                    col = 7;
                    foreach (System.Data.DataRow rcrow in reasoncodeq1)
                    {
                        if (lang != null && lang.Equals("JP"))
                        {
                            setCellValue(7, col++, rcrow["jpdesc"].ToString());
                        }
                        else
                        {
                            setCellValue(7, col++, rcrow["reasoncodedesc"].ToString());
                        }
                    }
                    #endregion

                    #region 底部、跟部不良 ReasonCode
                    var reasoncodeq2 = from p in reasonCodeDt.AsEnumerable()
                                       where p["reasoncategory"].ToString().Equals("Repair-检品-底部、跟部不良")
                                       select p;
                    rcNum2 = reasoncodeq2.Count();
                    if (rcNum2 > 2)
                    {
                        for (int i = 0; i < rcNum2 - 2; i++)
                        {
                            ((Range)workSheet.Columns[i + 7 + rcNum1 + 1, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                            ((Range)workSheet.Cells[7, i + 7 + rcNum1 + 1]).Borders.LineStyle = 1;
                            ((Range)workSheet.Cells[8, i + 7 + rcNum1 + 1]).Borders.LineStyle = 1;
                        }
                    }
                    else
                    {
                        rcNum2 = 2;
                    }

                    foreach (System.Data.DataRow rcrow in reasoncodeq2)
                    {
                        if (lang != null && lang.Equals("JP"))
                        {
                            setCellValue(7, col++, rcrow["jpdesc"].ToString());
                        }
                        else
                        {
                            setCellValue(7, col++, rcrow["reasoncodedesc"].ToString());
                        }
                    }
                    #endregion

                    #region 其他 ReasonCode
                    var reasoncodeq3 = from p in reasonCodeDt.AsEnumerable()
                                       where p["reasoncategory"].ToString().Equals("Repair-检品-其他")
                                       select p;
                    rcNum3 = reasoncodeq3.Count();
                    if (rcNum3 > 4)
                    {
                        for (int i = 0; i < rcNum3 - 4; i++)
                        {
                            ((Range)workSheet.Columns[i + 7 + rcNum1 + rcNum2 + 3, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                            ((Range)workSheet.Cells[7, i + 7 + rcNum1 + rcNum2 + 3]).Borders.LineStyle = 1;
                            ((Range)workSheet.Cells[8, i + 7 + rcNum1 + rcNum2 + 3]).Borders.LineStyle = 1;
                        }
                    }
                    else
                    {
                        rcNum3 = 4;
                    }

                    foreach (System.Data.DataRow rcrow in reasoncodeq3)
                    {
                        if (lang != null && lang.Equals("JP"))
                        {
                            setCellValue(7, col++, rcrow["jpdesc"].ToString());
                        }
                        else
                        {
                            setCellValue(7, col++, rcrow["reasoncodedesc"].ToString());
                        }
                    }
                    #endregion

                    #region 最終不良明細 ReasonCode
                    var reasoncodeq4 = from p in reasonCodeDt.AsEnumerable()
                                       where p["reasoncategory"].ToString().Equals("Repair-全检-最終不良明細")
                                       select p;
                    rcNum4 = reasoncodeq4.Count();
                    if (rcNum4 > 4)
                    {
                        for (int i = 0; i < rcNum4 - 4; i++)
                        {
                            ((Range)workSheet.Columns[i + 7 + rcNum1 + rcNum2 + rcNum3 + 6, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                            ((Range)workSheet.Cells[7, i + 7 + rcNum1 + rcNum2 + rcNum3 + 6]).Borders.LineStyle = 1;
                            ((Range)workSheet.Cells[8, i + 7 + rcNum1 + rcNum2 + rcNum3 + 6]).Borders.LineStyle = 1;
                        }
                    }
                    else
                    {
                        rcNum4 = 4;
                    }

                    col += 3;
                    foreach (System.Data.DataRow rcrow in reasoncodeq4)
                    {
                        if (lang != null && lang.Equals("JP"))
                        {
                            setCellValue(7, col++, rcrow["jpdesc"].ToString());
                        }
                        else
                        {
                            setCellValue(7, col++, rcrow["reasoncodedesc"].ToString());
                        }
                    }
                    #endregion

                    int rownum = 0;
                    #region Create basic info
                    
                    foreach (System.Data.DataRow row in lstInfo)
                    {
                        if (rownum != 0)
                        {
                            ((Range)workSheet.Rows[rownum + 8, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                        }
                        ((Range)workSheet.Cells[rownum + 8, 1]).NumberFormatLocal = "@";
                        ((Range)workSheet.Cells[rownum + 8, 2]).NumberFormatLocal = "@";
                        ((Range)workSheet.Cells[rownum + 8, 3]).NumberFormatLocal = "@";
                        ((Range)workSheet.Cells[rownum + 8, 4]).NumberFormatLocal = "@";
                        setCellValue(rownum + 8, 1, row["custorderno"].ToString());
                        setCellValue(rownum + 8, 2, row["styleno"].ToString());
                        setCellValue(rownum + 8, 3, row["color"].ToString());
                        setCellValue(rownum + 8, 4, row["size"].ToString());



                        setCellValue(rownum + 8, 5, row["orderpairqty"].ToString());
                        setCellValue(rownum + 8, 6, row["unpackingpairqty"].ToString());
                        ((Range)workSheet.Cells[rownum + 8, 7 + rcNum1 + rcNum2 + rcNum3]).Formula = "=SUM(" + IndexToColumn(7) + (rownum + 8) + ":" + IndexToColumn(7 + rcNum1 + rcNum2 + rcNum3 - 1) + (rownum + 8) + ")";
                        ((Range)workSheet.Cells[rownum + 8, 7 + rcNum1 + rcNum2 + rcNum3 + 1]).Formula = "=" + IndexToColumn(6) + (rownum + 8) + "-" + IndexToColumn(7 + rcNum1 + rcNum2 + rcNum3) + (rownum + 8);
                        ((Range)workSheet.Cells[rownum + 8, rcNum1 + rcNum2 + rcNum3 + rcNum4 + 10]).Formula = "=SUM(" + IndexToColumn(rcNum1 + rcNum2 + rcNum3 + 10) + (rownum + 8) + ":" + IndexToColumn(10 + rcNum1 + rcNum2 + rcNum3 + rcNum4 - 1) + (rownum + 8) + ")";
                        ((Range)workSheet.Cells[rownum + 8, 10 + rcNum1 + rcNum2 + rcNum3 + rcNum4 + 1]).Formula = "=" + IndexToColumn(6) + (rownum + 8) + "-" + IndexToColumn(10 + rcNum1 + rcNum2 + rcNum3 + rcNum4) + (rownum + 8);
                        ((Range)workSheet.Cells[rownum + 8, 10 + rcNum1 + rcNum2 + rcNum3 + rcNum4 + 3]).Formula = "=" + IndexToColumn(10 + rcNum1 + rcNum2 + rcNum3 + rcNum4 + 1) + (rownum + 8) + "-" + IndexToColumn(10 + rcNum1 + rcNum2 + rcNum3 + rcNum4 + 2) + (rownum + 8);
                        for (int j = 7; j < rcNum1 + rcNum2 + rcNum3 + rcNum4 + 14; j++)
                        {
                            ((Range)workSheet.Cells[rownum + 8, j]).Borders.LineStyle = 1;
                        }
                        ((Range)workSheet.Cells[rownum + 8, 7]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                        ((Range)workSheet.Cells[rownum + 8, 7 + rcNum1]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                        ((Range)workSheet.Cells[rownum + 8, 7 + rcNum1 + rcNum2]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                        ((Range)workSheet.Cells[rownum + 8, 7 + rcNum1 + rcNum2 + rcNum3 - 1]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                        ((Range)workSheet.Cells[rownum + 8, 7 + rcNum1 + rcNum2 + rcNum3 + 2]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble;
                        ((Range)workSheet.Cells[rownum + 8, 7 + rcNum1 + rcNum2 + rcNum3 + 2]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble;
                        ((Range)workSheet.Cells[rownum + 8, 10 + rcNum1 + rcNum2 + rcNum3 + rcNum4 - 1]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble;
                        rownum++;
                    }
                    #endregion

                    #region 帮面部分 Failed
                    var q1 = from p in failDt.AsEnumerable()
                             where p["reasoncategory"].ToString().Equals("Repair-检品-帮面部分")
                             && p["isfirst"].ToString().Equals(MES_Misc.Y.ToString())
                             select p;
                    foreach (System.Data.DataRow row in q1)
                    {
                        for (int i = 8; i < rownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(row["custorderno"].ToString())
                                && getCellValue(i, 2).ToString().Equals(row["styleno"].ToString())
                                && getCellValue(i, 3).ToString().Equals(row["color"].ToString())
                                && getCellValue(i, 4).ToString().Equals(row["size"].ToString()))
                            {
                                for (int j = 7; j < rcNum1 + 7; j++)
                                {
                                    string reasoncodedesc = "";
                                    if (lang != null && lang.Equals("JP"))
                                    {
                                        reasoncodedesc = row["jpdesc"].ToString();
                                    }
                                    else
                                    {
                                        reasoncodedesc = row["reasoncodedesc"].ToString();
                                    }
                                    if (getCellValue(7, j).ToString().Equals(reasoncodedesc))
                                    {
                                        setCellValue(i, j, row["pairqty"].ToString());
                                    }

                                }
                            }
                        }
                    }
                    #endregion

                    #region 底部、跟部不良 Failed
                    var q2 = from p in failDt.AsEnumerable()
                             where p["reasoncategory"].ToString().Equals("Repair-检品-底部、跟部不良")
                             && p["isfirst"].ToString().Equals(MES_Misc.Y.ToString())
                             select p;
                    foreach (System.Data.DataRow row in q2)
                    {
                        for (int i = 8; i < rownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(row["custorderno"].ToString())
                                && getCellValue(i, 2).ToString().Equals(row["styleno"].ToString())
                                && getCellValue(i, 3).ToString().Equals(row["color"].ToString())
                                && getCellValue(i, 4).ToString().Equals(row["size"].ToString()))
                            {
                                for (int j = rcNum1 + 7; j < rcNum1 + rcNum2 + 7; j++)
                                {
                                    string reasoncodedesc = "";
                                    if (lang != null && lang.Equals("JP"))
                                    {
                                        reasoncodedesc = row["jpdesc"].ToString();
                                    }
                                    else
                                    {
                                        reasoncodedesc = row["reasoncodedesc"].ToString();
                                    }
                                    if (getCellValue(7, j).ToString().Equals(reasoncodedesc))
                                    {
                                        setCellValue(i, j, row["pairqty"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region 其他 Failed
                    var q3 = from p in failDt.AsEnumerable()
                             where p["reasoncategory"].ToString().Equals("Repair-检品-其他")
                             && p["isfirst"].ToString().Equals(MES_Misc.Y.ToString())
                             select p;
                    foreach (System.Data.DataRow row in q3)
                    {
                        for (int i = 8; i < rownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(row["custorderno"].ToString())
                                && getCellValue(i, 2).ToString().Equals(row["styleno"].ToString())
                                && getCellValue(i, 3).ToString().Equals(row["color"].ToString())
                                && getCellValue(i, 4).ToString().Equals(row["size"].ToString()))
                            {
                                for (int j = rcNum1 + rcNum2 + 7; j < rcNum1 + rcNum2 + rcNum3 + 7; j++)
                                {
                                    string reasoncodedesc = "";
                                    if (lang != null && lang.Equals("JP"))
                                    {
                                        reasoncodedesc = row["jpdesc"].ToString();
                                    }
                                    else
                                    {
                                        reasoncodedesc = row["reasoncodedesc"].ToString();
                                    }
                                    if (getCellValue(7, j).ToString().Equals(reasoncodedesc))
                                    {
                                        setCellValue(i, j, row["pairqty"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region 最終不良明細 Failed
                    var q4 = from p in failDt.AsEnumerable()
                             where p["reasoncategory"].ToString().Equals("Repair-全检-最終不良明細")
                             select p;
                    foreach (System.Data.DataRow row in q4)
                    {
                        for (int i = 8; i < rownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(row["custorderno"].ToString())
                                && getCellValue(i, 2).ToString().Equals(row["styleno"].ToString())
                                && getCellValue(i, 3).ToString().Equals(row["color"].ToString())
                                && getCellValue(i, 4).ToString().Equals(row["size"].ToString()))
                            {
                                for (int j = rcNum1 + rcNum2 + rcNum3 + 10; j < rcNum1 + rcNum2 + rcNum3 + rcNum4 + 10; j++)
                                {
                                    string reasoncodedesc = "";
                                    if (lang != null && lang.Equals("JP"))
                                    {
                                        reasoncodedesc = row["jpdesc"].ToString();
                                    }
                                    else
                                    {
                                        reasoncodedesc = row["reasoncodedesc"].ToString();
                                    }
                                    if (getCellValue(7, j).ToString().Equals(reasoncodedesc))
                                    {
                                        setCellValue(i, j, row["pairqty"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region X线一次不良
                    var xq = from p in failDt.AsEnumerable()
                             where p["reasoncategory"].ToString().IndexOf("Repair-X线") >= 0
                             && p["isfirst"].ToString().Equals(MES_Misc.Y.ToString())
                             group p by new
                             {
                                 custorderno = p["custorderno"].ToString(),
                                 styleno = p["styleno"].ToString(),
                                 color = p["color"].ToString(),
                                 size = p["size"].ToString()
                             } into g
                             select new
                             {
                                 g.Key,
                                 pairqty = g.Sum(p => Convert.ToInt16(p["pairqty"]))
                             };

                    foreach (var data in xq)
                    {
                        for (int i = 8; i < rownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(data.Key.custorderno)
                                && getCellValue(i, 2).ToString().Equals(data.Key.styleno)
                                && getCellValue(i, 3).ToString().Equals(data.Key.color)
                                && getCellValue(i, 4).ToString().Equals(data.Key.size))
                            {
                                for (int j = 7; j < rcNum1 + rcNum2 + rcNum3 + 7; j++)
                                {
                                    string reasoncodedesc = "";
                                    if (lang != null && lang.Equals("JP"))
                                    {
                                        reasoncodedesc = "X線不良品";
                                    }
                                    else
                                    {
                                        reasoncodedesc = "X光机不良品";
                                    }
                                    if (getCellValue(7, j).ToString().Equals(reasoncodedesc))
                                    {
                                        setCellValue(i, j, data.pairqty);
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region 再检次数
                    var mutilq = from p in hisDt.AsEnumerable()
                                 where p["reptype"].ToString().Equals(MES_RepairType.RepairSuccess.ToString())
                                 //&& p["step"].ToString().Equals("I")
                                 group p by new
                                 {
                                     custorderno = p["custorderno"].ToString(),
                                     styleno = p["styleno"].ToString(),
                                     color = p["color"].ToString(),
                                     size = p["size"].ToString()
                                 } into g
                                 select new
                                 {
                                     g.Key,
                                     pairqty = g.Sum(p => Convert.ToInt16(p["pairqty"]))
                                 };

                    foreach (var data in mutilq)
                    {
                        for (int i = 8; i < rownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(data.Key.custorderno)
                                && getCellValue(i, 2).ToString().Equals(data.Key.styleno)
                                && getCellValue(i, 3).ToString().Equals(data.Key.color)
                                && getCellValue(i, 4).ToString().Equals(data.Key.size))
                            {
                                setCellValue(i, rcNum1 + rcNum2 + rcNum3 + 9, data.pairqty);
                            }
                        }
                    }
                    #endregion

                    #region 出库数量
                    foreach (System.Data.DataRow row in shipDt.Rows)
                    {
                        for (int i = 8; i < rownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(row["custorderno"].ToString())
                               && getCellValue(i, 2).ToString().Equals(row["styleno"].ToString())
                               && getCellValue(i, 3).ToString().Equals(row["color"].ToString())
                               && getCellValue(i, 4).ToString().Equals(row["size"].ToString()))
                            {
                                setCellValue(i, rcNum1 + rcNum2 + rcNum3 + rcNum4 + 12, row["pairqty"].ToString());
                            }
                        }
                    }
                    #endregion

                    #region Summary
                    for (int j = 5; j < rcNum1 + rcNum2 + rcNum3 + rcNum4 + 14; j++)
                    {
                        ((Range)workSheet.Cells[rownum + 8, j]).Formula = "=SUM(" + IndexToColumn(j) + "8:" + IndexToColumn(j) + (rownum + 7) + ")";
                    }
                    #endregion

                    #region Header Info

                    setCellValue(3, rcNum1 + rcNum2 + 10, rdate);
                    ((Range)workSheet.Cells[3, rcNum1 + rcNum2 + 10]).NumberFormat = "yyyy-MM-dd";
                    workSheet.get_Range(IndexToColumn(rcNum1 + rcNum2 + 10) + "3", IndexToColumn(rcNum1 + rcNum2 + rcNum3 + 9) + "3").MergeCells = true;

                    if (sdate != Function.GetNullDateTime())
                    {
                        setCellValue(3, rcNum1 + rcNum2 + rcNum3 + rcNum4 + 10, sdate);
                        ((Range)workSheet.Cells[3, rcNum1 + rcNum2 + rcNum3 + rcNum4 + 10]).NumberFormat = "yyyy-MM-dd";
                    }

                    if (headerDt.Rows.Count > 0)
                    {
                        setCellValue(3, 2, headerDt.Rows[0]["customername"].ToString());
                        setCellValue(4, 2, headerDt.Rows[0]["factory"].ToString());
                    }

                    #endregion

                    #region Bottom
                    setCellValue(rownum + 10, rcNum1 + rcNum2 + rcNum3 + rcNum4 + 10, string.Join("\n", managerList.ToArray<string>()));
                    setCellValue(rownum + 10, rcNum1 + rcNum2 + rcNum3 + rcNum4 + 12, string.Join("\n", responderList.ToArray<string>()));
                    #endregion
                }
                #endregion

                #region X线
                if (checktypeList.Contains("X"))
                {
                    workSheet = (Worksheet)workBook.Sheets.get_Item(2);

                    int xrcNum1 = 0;
                    int xrcNum2 = 0;
                    int xrcNum3 = 0;
                    int xcol = 0;

                    if (lang != null && lang.Equals("JP"))
                    {
                        setCellValue(6, 7, "アッパー");
                        setCellValue(6, 9, "底部、跟部不良");
                        setCellValue(6, 17, "其他");
                    }
                    else
                    {
                        setCellValue(6, 7, "帮面部分");
                        setCellValue(6, 9, "底部、跟部不良");
                        setCellValue(6, 17, "其他");
                    }

                    #region 帮面部分 ReasonCode
                    var xreasoncodeq1 = from p in reasonCodeDt.AsEnumerable()
                                        where p["reasoncategory"].ToString().Equals("Repair-X线-帮面部分")
                                        select p;
                    xrcNum1 = xreasoncodeq1.Count();
                    if (xrcNum1 > 2)
                    {
                        for (int i = 0; i < xrcNum1 - 2; i++)
                        {
                            ((Range)workSheet.Columns[i + 8, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                            ((Range)workSheet.Cells[7, i + 8]).Borders.LineStyle = 1;
                            ((Range)workSheet.Cells[8, i + 8]).Borders.LineStyle = 1;
                        }
                    }
                    else
                    {
                        xrcNum1 = 2;
                    }

                    xcol = 7;
                    foreach (System.Data.DataRow xrcrow in xreasoncodeq1)
                    {
                        if (lang != null && lang.Equals("JP"))
                        {
                            setCellValue(7, xcol++, xrcrow["jpdesc"].ToString());
                        }
                        else
                        {
                            setCellValue(7, xcol++, xrcrow["reasoncodedesc"].ToString());
                        }
                    }
                    #endregion

                    #region 底部、跟部不良 ReasonCode
                    var xreasoncodeq2 = from p in reasonCodeDt.AsEnumerable()
                                        where p["reasoncategory"].ToString().Equals("Repair-X线-底部、跟部不良")
                                        select p;
                    xrcNum2 = xreasoncodeq2.Count();
                    if (xrcNum2 > 8)
                    {
                        for (int i = 0; i < xrcNum2 - 8; i++)
                        {
                            ((Range)workSheet.Columns[i + 7 + xrcNum1 + 7, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                            ((Range)workSheet.Cells[7, i + 7 + xrcNum1 + 7]).Borders.LineStyle = 1;
                            ((Range)workSheet.Cells[8, i + 7 + xrcNum1 + 7]).Borders.LineStyle = 1;
                        }
                    }
                    else
                    {
                        xrcNum2 = 8;
                    }

                    foreach (System.Data.DataRow xrcrow in xreasoncodeq2)
                    {
                        if (lang != null && lang.Equals("JP"))
                        {
                            setCellValue(7, xcol++, xrcrow["jpdesc"].ToString());
                        }
                        else
                        {
                            setCellValue(7, xcol++, xrcrow["reasoncodedesc"].ToString());
                        }
                    }
                    #endregion

                    #region 其他 ReasonCode
                    var xreasoncodeq3 = from p in reasonCodeDt.AsEnumerable()
                                        where p["reasoncategory"].ToString().Equals("Repair-X线-其他")
                                        select p;
                    xrcNum3 = xreasoncodeq3.Count();
                    if (xrcNum3 > 4)
                    {
                        for (int i = 0; i < xrcNum3 - 4; i++)
                        {
                            ((Range)workSheet.Columns[i + 7 + xrcNum1 + xrcNum2 + 3, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                            ((Range)workSheet.Cells[7, i + 7 + xrcNum1 + xrcNum2 + 3]).Borders.LineStyle = 1;
                            ((Range)workSheet.Cells[8, i + 7 + xrcNum1 + xrcNum2 + 3]).Borders.LineStyle = 1;
                        }
                    }
                    else
                    {
                        xrcNum3 = 4;
                    }

                    foreach (System.Data.DataRow xrcrow in xreasoncodeq3)
                    {
                        if (lang != null && lang.Equals("JP"))
                        {
                            setCellValue(7, xcol++, xrcrow["jpdesc"].ToString());
                        }
                        else
                        {
                            setCellValue(7, xcol++, xrcrow["reasoncodedesc"].ToString());
                        }
                    }
                    #endregion

                    int xrownum = 0;
                    #region Create basic info
                    foreach (System.Data.DataRow row in lstInfo)
                    {
                        if (xrownum != 0)
                        {
                            ((Range)workSheet.Rows[xrownum + 8, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                        }
                        ((Range)workSheet.Cells[xrownum + 8, 1]).NumberFormatLocal = "@";
                        ((Range)workSheet.Cells[xrownum + 8, 2]).NumberFormatLocal = "@";
                        ((Range)workSheet.Cells[xrownum + 8, 3]).NumberFormatLocal = "@";
                        ((Range)workSheet.Cells[xrownum + 8, 4]).NumberFormatLocal = "@";
                        setCellValue(xrownum + 8, 1, row["custorderno"].ToString());
                        setCellValue(xrownum + 8, 2, row["styleno"].ToString());
                        setCellValue(xrownum + 8, 3, row["color"].ToString());
                        setCellValue(xrownum + 8, 4, row["size"].ToString());


                        setCellValue(xrownum + 8, 5, row["orderpairqty"].ToString());
                        if (row["checktype"].ToString().Equals("X"))
                        {
                            setCellValue(xrownum + 8, 6, row["unpackingpairqty"].ToString());
                        }
                        else
                        {
                            setCellValue(xrownum + 8, 6, row["movingpairqty"].ToString());
                        }
                        ((Range)workSheet.Cells[xrownum + 8, 7 + xrcNum1 + xrcNum2 + xrcNum3]).Formula = "=SUM(" + IndexToColumn(7) + (xrownum + 8) + ":" + IndexToColumn(7 + xrcNum1 + xrcNum2 + xrcNum3 - 1) + (xrownum + 8) + ")";
                        ((Range)workSheet.Cells[xrownum + 8, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 5]).Formula = "=" + IndexToColumn(6) + (xrownum + 8) + "-" + IndexToColumn(7 + xrcNum1 + xrcNum2 + xrcNum3 + 4) + (xrownum + 8);
                        ((Range)workSheet.Cells[xrownum + 8, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 7]).Formula = "=" + IndexToColumn(7 + xrcNum1 + xrcNum2 + xrcNum3 + 5) + (xrownum + 8) + "-" + IndexToColumn(7 + xrcNum1 + xrcNum2 + xrcNum3 + 6) + (xrownum + 8);
                        for (int j = 7; j < xrcNum1 + xrcNum2 + xrcNum3 + 7; j++)
                        {
                            ((Range)workSheet.Cells[xrownum + 8, j]).Borders.LineStyle = 1;
                        }
                        ((Range)workSheet.Cells[xrownum + 8, 7]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                        ((Range)workSheet.Cells[xrownum + 8, 7 + xrcNum1]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                        ((Range)workSheet.Cells[xrownum + 8, 7 + xrcNum1 + xrcNum2]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                        ((Range)workSheet.Cells[xrownum + 8, 7 + xrcNum1 + xrcNum2 + xrcNum3 - 1]).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                        xrownum++;
                    }
                    #endregion

                    #region 帮面部分 Failed
                    var xq1 = from p in failDt.AsEnumerable()
                              where p["reasoncategory"].ToString().Equals("Repair-X线-帮面部分")
                              && p["isfirst"].ToString().Equals(MES_Misc.Y.ToString())
                              select p;
                    foreach (System.Data.DataRow row in xq1)
                    {
                        for (int i = 8; i < xrownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(row["custorderno"].ToString())
                                && getCellValue(i, 2).ToString().Equals(row["styleno"].ToString())
                                && getCellValue(i, 3).ToString().Equals(row["color"].ToString())
                                && getCellValue(i, 4).ToString().Equals(row["size"].ToString()))
                            {
                                for (int j = 7; j < xrcNum1 + 7; j++)
                                {
                                    string reasoncodedesc = "";
                                    if (lang != null && lang.Equals("JP"))
                                    {
                                        reasoncodedesc = row["jpdesc"].ToString();
                                    }
                                    else
                                    {
                                        reasoncodedesc = row["reasoncodedesc"].ToString();
                                    }
                                    if (getCellValue(7, j).ToString().Equals(reasoncodedesc))
                                    {
                                        setCellValue(i, j, row["pairqty"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region 底部、跟部不良 Failed
                    var xq2 = from p in failDt.AsEnumerable()
                              where p["reasoncategory"].ToString().Equals("Repair-X线-底部、跟部不良")
                             && p["isfirst"].ToString().Equals(MES_Misc.Y.ToString())
                              select p;
                    foreach (System.Data.DataRow row in xq2)
                    {
                        for (int i = 8; i < xrownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(row["custorderno"].ToString())
                                && getCellValue(i, 2).ToString().Equals(row["styleno"].ToString())
                                && getCellValue(i, 3).ToString().Equals(row["color"].ToString())
                                && getCellValue(i, 4).ToString().Equals(row["size"].ToString()))
                            {
                                for (int j = xrcNum1 + 7; j < xrcNum1 + xrcNum2 + 7; j++)
                                {
                                    string reasoncodedesc = "";
                                    if (lang != null && lang.Equals("JP"))
                                    {
                                        reasoncodedesc = row["jpdesc"].ToString();
                                    }
                                    else
                                    {
                                        reasoncodedesc = row["reasoncodedesc"].ToString();
                                    }
                                    if (getCellValue(7, j).ToString().Equals(reasoncodedesc))
                                    {
                                        setCellValue(i, j, row["pairqty"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region 其他 Failed
                    var xq3 = from p in failDt.AsEnumerable()
                              where p["reasoncategory"].ToString().Equals("Repair-X线-其他")
                             && p["isfirst"].ToString().Equals(MES_Misc.Y.ToString())
                              select p;
                    foreach (System.Data.DataRow row in xq3)
                    {
                        for (int i = 8; i < xrownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(row["custorderno"].ToString())
                                && getCellValue(i, 2).ToString().Equals(row["styleno"].ToString())
                                && getCellValue(i, 3).ToString().Equals(row["color"].ToString())
                                && getCellValue(i, 4).ToString().Equals(row["size"].ToString()))
                            {
                                for (int j = xrcNum1 + xrcNum2 + 7; j < xrcNum1 + xrcNum2 + xrcNum3 + 7; j++)
                                {
                                    string reasoncodedesc = "";
                                    if (lang != null && lang.Equals("JP"))
                                    {
                                        reasoncodedesc = row["jpdesc"].ToString();
                                    }
                                    else
                                    {
                                        reasoncodedesc = row["reasoncodedesc"].ToString();
                                    }
                                    if (getCellValue(7, j).ToString().Equals(reasoncodedesc))
                                    {
                                        setCellValue(i, j, row["pairqty"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region 最终不良品
                    var failq = from p in failDt.AsEnumerable()
                                where p["reptype"].ToString().Equals(MES_RepairType.RepairFail.ToString())
                                && p["step"].ToString().Equals(MES_WIPStatus.X.ToString())
                                group p by new
                                {
                                    custorderno = p["custorderno"].ToString(),
                                    styleno = p["styleno"].ToString(),
                                    color = p["color"].ToString(),
                                    size = p["size"].ToString()
                                } into g
                                select new
                                {
                                    g.Key,
                                    pairqty = g.Sum(p => Convert.ToInt16(p["pairqty"]))
                                };

                    foreach (var data in failq)
                    {
                        for (int i = 8; i < xrownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(data.Key.custorderno)
                                && getCellValue(i, 2).ToString().Equals(data.Key.styleno)
                                && getCellValue(i, 3).ToString().Equals(data.Key.color)
                                && getCellValue(i, 4).ToString().Equals(data.Key.size))
                            {

                                setCellValue(i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 4, data.pairqty);
                            }
                        }
                    }
                    #endregion

                    #region 出库数量
                    foreach (System.Data.DataRow row in shipDt.Rows)
                    {
                        for (int i = 8; i < xrownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(row["custorderno"].ToString())
                               && getCellValue(i, 2).ToString().Equals(row["styleno"].ToString())
                               && getCellValue(i, 3).ToString().Equals(row["color"].ToString())
                               && getCellValue(i, 4).ToString().Equals(row["size"].ToString()))
                            {
                                setCellValue(i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 6, row["pairqty"].ToString());
                            }
                        }
                    }
                    #endregion

                    #region 脚拼 签名
                    for (int i = 8; i < xrownum + 8; i++)
                    {
                        workSheet.get_Range(IndexToColumn(7 + xrcNum1 + xrcNum2 + xrcNum3 + 2) + i, IndexToColumn(7 + xrcNum1 + xrcNum2 + xrcNum3 + 3) + i).MergeCells = true;
                    }

                    //var jointq = from p in hisDt.AsEnumerable()
                    //             where p["reptype"].ToString().Equals(MES_RepairType.RepairSuccess.ToString())
                    //             && p["jointtype"].ToString().Equals("拼脚")
                    //             select p;
                    //foreach (DataRow jointr in jointq)
                    //{
                    //    for (int i = 8; i < xrownum + 8; i++)
                    //    {
                    //        if (getCellValue(i, 1).ToString().Equals(jointr["custorderno"].ToString())
                    //           && getCellValue(i, 2).ToString().Equals(jointr["styleno"].ToString())
                    //           && getCellValue(i, 3).ToString().Equals(jointr["color"].ToString())
                    //           && getCellValue(i, 4).ToString().Equals(jointr["size"].ToString()))
                    //        {
                    //            if (getCellValue(i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 1)==null || getCellValue(i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 1).ToString().Equals(""))
                    //            {
                    //                setCellValue(i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 1, Convert.ToInt16(jointr["pairqty"].ToString()));
                    //            }
                    //            else
                    //            {
                    //                int jointQty = Convert.ToInt16(jointr["pairqty"].ToString()) + Convert.ToInt16(getCellValue(i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 1).ToString());
                    //                setCellValue(i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 1, jointQty);
                    //            }
                    //        }
                    //    }
                    //}

                    var jointsq = from p in hisDt.AsEnumerable()
                                  where p["reptype"].ToString().Equals(MES_RepairType.RepairSuccess.ToString())
                                  && p["jointtype"].ToString().Equals("签名")
                                  select p;
                    List<string> signatureList = new List<string>();
                    foreach (DataRow jointr in jointsq)
                    {
                        if (!signatureList.Contains(jointr["signature"].ToString().Trim()))
                        {
                            signatureList.Add(jointr["signature"].ToString().Trim());
                        }
                        for (int i = 8; i < xrownum + 8; i++)
                        {
                            if (getCellValue(i, 1).ToString().Equals(jointr["custorderno"].ToString())
                               && getCellValue(i, 2).ToString().Equals(jointr["styleno"].ToString())
                               && getCellValue(i, 3).ToString().Equals(jointr["color"].ToString())
                               && getCellValue(i, 4).ToString().Equals(jointr["size"].ToString()))
                            {
                                if (getCellValue(i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 2) == null || getCellValue(i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 2).ToString().Equals(""))
                                {
                                    setCellValue(i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 2, Convert.ToInt16(jointr["pairqty"].ToString()));
                                }
                                else
                                {
                                    int jointQty = Convert.ToInt16(jointr["pairqty"].ToString()) + Convert.ToInt16(getCellValue(i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 2).ToString());
                                    setCellValue(i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 2, jointQty);
                                }
                            }
                        }
                    }

                    for (int i = 8; i < xrownum + 8; i++)
                    {
                        ((Range)workSheet.Cells[i, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 1]).Formula = "=" + IndexToColumn(7 + xrcNum1 + xrcNum2 + xrcNum3) + i + "-" + IndexToColumn(7 + xrcNum1 + xrcNum2 + xrcNum3 + 2) + i + "-" + IndexToColumn(7 + xrcNum1 + xrcNum2 + xrcNum3 + 4) + i;
                    }

                    #endregion

                    #region Summary
                    for (int j = 5; j <= xrcNum1 + xrcNum2 + xrcNum3 + 14; j++)
                    {
                        ((Range)workSheet.Cells[xrownum + 8, j]).Formula = "=SUM(" + IndexToColumn(j) + "8:" + IndexToColumn(j) + (xrownum + 7) + ")";
                    }
                    #endregion

                    #region Header Info
                    setCellValue(3, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 2, rdate);
                    setCellValue(4, 7 + xrcNum1 + 6, rdate);
                    ((Range)workSheet.Cells[3, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 2]).NumberFormat = "yyyy-MM-dd";
                    ((Range)workSheet.Cells[4, 7 + xrcNum1 + 6]).NumberFormat = "yyyy-MM-dd";
                    if (sdate != Function.GetNullDateTime())
                    {
                        setCellValue(4, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 2, sdate);
                        ((Range)workSheet.Cells[4, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 2]).NumberFormat = "yyyy-MM-dd";
                    }

                    if (headerDt.Rows.Count > 0)
                    {
                        setCellValue(3, 2, headerDt.Rows[0]["customername"].ToString());
                        setCellValue(4, 2, headerDt.Rows[0]["factory"].ToString());
                    }
                    #endregion

                    #region Bottom
                    setCellValue(xrownum + 9, 2, string.Join(",", signatureList.ToArray<string>()));
                    setCellValue(xrownum + 10, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 4, string.Join("\n", xresponderList.ToArray<string>()));
                    setCellValue(xrownum + 10, 7 + xrcNum1 + xrcNum2 + xrcNum3 + 6, string.Join("\n", managerList.ToArray<string>()));
                    
                    workSheet.get_Range(IndexToColumn(xrcNum1 + xrcNum2 + 7) + Convert.ToString(xrownum + 10), IndexToColumn(xrcNum1 + xrcNum2 + xrcNum3 + 5) + Convert.ToString(xrownum + 10)).MergeCells = true;
                    workSheet.get_Range(IndexToColumn(xrcNum1 + xrcNum2 + 7) + Convert.ToString(xrownum + 11), IndexToColumn(xrcNum1 + xrcNum2 + xrcNum3 + 5) + Convert.ToString(xrownum + 11)).MergeCells = true;
                    #endregion
                }
                #endregion

                if (!checktypeList.Contains("X"))
                {
                    ((Worksheet)workBook.Sheets.get_Item(2)).Delete();
                }
                if (!checktypeList.Contains("I"))
                {
                    ((Worksheet)workBook.Sheets.get_Item(1)).Delete();
                }
                saveAsExcel("InspectRpt_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");

                app.Visible = true;
            }
            catch (Exception ex)
            {
                CloseExcel();
                throw ex;
            }
        }

        public void ExportPackingListRpt(System.Data.DataTable headerDt, System.Data.DataTable detailDt)
        {
            try
            {
                OpenExcel(templatePath + "PackingList.xls", 1);

                //saveAsExcel("PackingList_" + headerDt.Rows[0]["shippingno"].ToString().Trim() + ".xls");
                setCellValue(2, 2, headerDt.Rows[0]["customername"].ToString());
                //setCellValue(2, 10, headerDt.Rows[0]["shippingno"].ToString());
                setCellValue(3, 2, headerDt.Rows[0]["factory"].ToString());                

                #region create columns for size
                List<string> lstSize = new List<string>();
                List<string> sizeq = ((from p in detailDt.AsEnumerable()
                                       select p["size"].ToString()).Distinct()).ToList<string>();

                bool isFirstSize = true;
                int beforeCol = 7;
                sizeq.Sort(new SizeStringComparer());
                foreach (string size in sizeq)
                {
                    lstSize.Add(size);
                    int nowCol = isFirstSize ? beforeCol : ++beforeCol;

                    if (!isFirstSize)
                    {
                        ((Range)workSheet.Columns[nowCol, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftToRight, Type.Missing);
                    }
                    setCellValue(8, nowCol, size);
                    Range sizeRange=(Range)workSheet.Cells[8, nowCol];
                    sizeRange.Borders.LineStyle = 1;
                    isFirstSize = false;
                }
                workSheet.get_Range(IndexToColumn(7) + "7", IndexToColumn(beforeCol)+"7").MergeCells=true;
                
                #endregion

                int emptyCartonQty = 0;
                bool isFirstDtl = true;
                int beforeRow = 9;
                int custorderrow = beforeRow;
                var custordernoq = (from p in detailDt.AsEnumerable()
                                    select p["custorderno"].ToString()).Distinct();

                //合同号，出入库时间
                List<string> lstOrder = new List<string>();
                foreach (string custorderno in custordernoq)
                {
                    lstOrder.Add(custorderno);
                }

                setCellValue(2, 9 + sizeq.Count(), headerDt.Rows[0]["shippingno"]);

                DateTime rdate = GetReceiveDate(lstOrder.ToArray<string>());
                DateTime sdate = Convert.ToDateTime(headerDt.Rows[0]["shippeddate"]);
                setCellValue(3, 9 + sizeq.Count(), rdate);
                ((Range)workSheet.Cells[3, 9 + sizeq.Count()]).NumberFormat = "yyyy-MM-dd";
                setCellValue(4, 9 + sizeq.Count(), sdate);
                ((Range)workSheet.Cells[4, 9 + sizeq.Count()]).NumberFormat = "yyyy-MM-dd";


                foreach (string custorderno in custordernoq)
                {
                    custorderrow = isFirstDtl ? beforeRow : beforeRow+1;
                    var cartonnoq = (from p in detailDt.AsEnumerable()
                                     where p["custorderno"].ToString().Equals(custorderno)
                                     orderby p["cartonno"].ToString()
                                     select p["cartonno"].ToString()).Distinct();

                    bool isFirstRowOfCustOrderNo = true;
                   
                    
                    List<string> lstCartonNo = new List<string>();
                    List<string> lstCartonNoSort = new List<string>();
                    foreach (string cartonno in cartonnoq)
                    {
                        lstCartonNo.Add(cartonno);
                        lstCartonNoSort.Add(cartonno);
                    }
                    lstCartonNoSort.Sort(SortHelper.CompareString);

                    foreach (string cartonno in lstCartonNoSort)
                    {
                        string orgStyleColorStr = "";
                        string nowStyleColorStr = "";
                        int rownum = 0;
                        if (lstCartonNo.Contains(cartonno))
                        {
                            var stylecolorq = (from p in detailDt.AsEnumerable()
                                       where p["custorderno"].ToString().Equals(custorderno) && p["cartonno"].ToString().Equals(cartonno)
                                               orderby p["styleno"].ToString(), p["color"].ToString(), p["size"].ToString(), p["pairqty"].ToString()
                                       select new {styleno=p["styleno"].ToString(), color=p["color"].ToString(),size= p["size"].ToString(), pairqty=p["pairqty"].ToString()}).Distinct();
                           

                            foreach (var stylecolor in stylecolorq)
                            {
                                if (Convert.ToInt16(stylecolor.pairqty) != 0)
                                {
                                    if (!orgStyleColorStr.Equals(""))
                                    {
                                        orgStyleColorStr += "|";
                                    }
                                    orgStyleColorStr += stylecolor.styleno + "," + stylecolor.color + "," + stylecolor.size + "," + stylecolor.pairqty;
                                }
                            }

                            if (orgStyleColorStr.Equals(""))
                            {
                                emptyCartonQty++;
                                continue;
                            }

                            var dtlq = from p in detailDt.AsEnumerable()
                                       where p["custorderno"].ToString().Equals(custorderno) && p["cartonno"].ToString().Equals(cartonno)
                                       orderby p["styleno"].ToString(), p["color"].ToString()
                                       select p;

                            foreach (System.Data.DataRow dtl in dtlq)
                            {
                                if (rownum == 0)
                                {
                                    int nowRow = isFirstDtl ? beforeRow : ++beforeRow;
                                    if (!isFirstDtl)
                                    {
                                        ((Range)workSheet.Rows[nowRow, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                                    }
                                    if (isFirstRowOfCustOrderNo)
                                    {
                                        setCellValue(nowRow, 1, dtl["custorderno"].ToString());
                                        ((Range)workSheet.Cells[nowRow, 1]).Font.Bold=true;
                                        isFirstRowOfCustOrderNo = false;
                                    }
                                    setCellValue(nowRow, 2, dtl["cartonno"].ToString());
                                    ((Range)workSheet.Cells[nowRow, 2]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                    setCellValue(nowRow, 3, "-");
                                    setCellValue(nowRow, 4, dtl["cartonno"].ToString());
                                    ((Range)workSheet.Cells[nowRow, 4]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                                    setCellValue(nowRow, 5, dtl["styleno"].ToString());
                                    ((Range)workSheet.Cells[nowRow, 5]).ShrinkToFit = true;
                                    setCellValue(nowRow, 6, dtl["color"].ToString());
                                    ((Range)workSheet.Cells[nowRow, 6]).ShrinkToFit = true;
                                    for (int i = 7; i <= beforeCol; i++)
                                    {
                                        if (getCellValue(8, i).ToString().Equals(dtl["size"].ToString()))
                                        {
                                            setCellValue(nowRow, i, dtl["pairqty"].ToString());
                                        }
                                        ((Range)workSheet.Cells[nowRow, i]).Borders.LineStyle = 1;
                                    }
                                    setCellValue(nowRow, beforeCol + 1, dtl["pairqty"].ToString()); //足箱
                                    setCellValue(nowRow, beforeCol + 2, "1");
                                    setCellValue(nowRow, beforeCol + 3, dtl["pairqty"].ToString());                                    
                                    //((Range)workSheet.Cells[nowRow, beforeCol + 3]).Formula = "=SUM(" + IndexToColumn(7) + nowRow.ToString() + ":" + IndexToColumn(beforeCol)+nowRow.ToString()+")";
                                    isFirstDtl = false;
                                    rownum++;
                                }
                                else
                                {
                                    bool isExist = false;
                                    for (int cntrow = 0; cntrow < rownum; cntrow++)
                                    {
                                        int fixrow=beforeRow - rownum + 1 + cntrow;
                                        if (getCellValue(fixrow, 5).ToString().Equals(dtl["styleno"].ToString())
                                            && getCellValue(fixrow, 6).ToString().Equals(dtl["color"].ToString()))
                                        {
                                            for (int i = 7; i <= beforeCol; i++)
                                            {
                                                if (getCellValue(8, i).ToString().Equals(dtl["size"].ToString()))
                                                {
                                                    setCellValue(fixrow, i, (Convert.ToInt16(getCellValue(fixrow, i)) + Convert.ToInt16(dtl["pairqty"])).ToString());
                                                }                                               
                                            }
                                            setCellValue(beforeRow - rownum + 1, beforeCol + 1, (Convert.ToInt16(getCellValue(beforeRow - rownum + 1, beforeCol + 1)) + Convert.ToInt16(dtl["pairqty"])).ToString());
                                            setCellValue(beforeRow - rownum + 1, beforeCol + 3, (Convert.ToInt16(getCellValue(beforeRow - rownum + 1, beforeCol + 3)) + Convert.ToInt16(dtl["pairqty"])).ToString());
                                            isExist = true;
                                        }                                        
                                    }
                                    if (!isExist)
                                    {
                                        int nowRow = ++beforeRow;
                                        ((Range)workSheet.Rows[nowRow, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                                        setCellValue(nowRow, 5, dtl["styleno"].ToString());
                                        setCellValue(nowRow, 6, dtl["color"].ToString());
                                        for (int i = 7; i <= beforeCol; i++)
                                        {
                                            if (getCellValue(8, i).ToString().Equals(dtl["size"].ToString()))
                                            {
                                                setCellValue(nowRow, i, dtl["pairqty"].ToString());
                                            }
                                            ((Range)workSheet.Cells[nowRow, i]).Borders.LineStyle = 1;
                                        }
                                        setCellValue(beforeRow - rownum, beforeCol + 1, (Convert.ToInt16(getCellValue(beforeRow - rownum, beforeCol + 1)) + Convert.ToInt16(dtl["pairqty"])).ToString());
                                        setCellValue(beforeRow - rownum , beforeCol + 3, (Convert.ToInt16(getCellValue(beforeRow - rownum, beforeCol + 3)) + Convert.ToInt16(dtl["pairqty"])).ToString());
                                        //setCellValue(nowRow, beforeCol + 1, dtl["orgpairty"].ToString());
                                        //setCellValue(nowRow, beforeCol + 2, "1");
                                        //setCellValue(nowRow, beforeCol + 3, dtl["pairqty"].ToString());
                                        //((Range)workSheet.Cells[nowRow, beforeCol + 3]).Formula = "=SUM(" + IndexToColumn(7) + nowRow.ToString() + ":" + IndexToColumn(beforeCol) + nowRow.ToString() + ")";
                                        rownum++;
                                    }
                                }
                            }

                            workSheet.get_Range("B" + (beforeRow - rownum + 1), "B" + beforeRow).MergeCells = true;
                            workSheet.get_Range("B" + (beforeRow - rownum + 1), "B" + beforeRow).Borders.LineStyle = 1;
                            workSheet.get_Range("B" + (beforeRow - rownum + 1), "B" + beforeRow).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                            workSheet.get_Range("C" + (beforeRow - rownum + 1), "C" + beforeRow).MergeCells = true;
                            workSheet.get_Range("C" + (beforeRow - rownum + 1), "C" + beforeRow).Borders.LineStyle = 1;
                            workSheet.get_Range("C" + (beforeRow - rownum + 1), "C" + beforeRow).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                            workSheet.get_Range("C" + (beforeRow - rownum + 1), "C" + beforeRow).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                            workSheet.get_Range("D" + (beforeRow - rownum + 1), "D" + beforeRow).MergeCells = true;
                            workSheet.get_Range("D" + (beforeRow - rownum + 1), "D" + beforeRow).Borders.LineStyle = 1;
                            workSheet.get_Range("D" + (beforeRow - rownum + 1), "D" + beforeRow).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

                            workSheet.get_Range(IndexToColumn(beforeCol + 1) + (beforeRow - rownum + 1), IndexToColumn(beforeCol + 1) + beforeRow).MergeCells = true;
                            workSheet.get_Range(IndexToColumn(beforeCol + 1) + (beforeRow - rownum + 1), IndexToColumn(beforeCol + 1) + beforeRow).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            workSheet.get_Range(IndexToColumn(beforeCol + 2) + (beforeRow - rownum + 1), IndexToColumn(beforeCol + 2) + beforeRow).MergeCells = true;
                            workSheet.get_Range(IndexToColumn(beforeCol + 2) + (beforeRow - rownum + 1), IndexToColumn(beforeCol + 2) + beforeRow).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            workSheet.get_Range(IndexToColumn(beforeCol + 3) + (beforeRow - rownum + 1), IndexToColumn(beforeCol + 3) + beforeRow).MergeCells = true;
                            workSheet.get_Range(IndexToColumn(beforeCol + 3) + (beforeRow - rownum + 1), IndexToColumn(beforeCol + 3) + beforeRow).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                            lstCartonNo.Remove(cartonno);

                            string nextCnt=GetNextCartonNo(cartonno);
                            while (nextCnt != null && lstCartonNo.Contains(nextCnt))
                            {
                                var nextstylecolorq = (from p in detailDt.AsEnumerable()
                                                       where p["custorderno"].ToString().Equals(custorderno) && p["cartonno"].ToString().Equals(nextCnt)
                                                   orderby p["styleno"].ToString(), p["color"].ToString(), p["size"].ToString(), p["pairqty"].ToString()
                                                   select new { styleno = p["styleno"].ToString(), color = p["color"].ToString(), size = p["size"].ToString(), pairqty = p["pairqty"].ToString() }).Distinct();

                                nowStyleColorStr = "";
                                foreach (var stylecolor in nextstylecolorq)
                                {                                    
                                    if (!nowStyleColorStr.Equals(""))
                                    {
                                        nowStyleColorStr += "|";
                                    }
                                    nowStyleColorStr += stylecolor.styleno + "," + stylecolor.color + "," + stylecolor.size + "," + stylecolor.pairqty;
                                    
                                }

                                

                                if (nowStyleColorStr.Equals(orgStyleColorStr))
                                {
                                    var nextdtlq = from p in detailDt.AsEnumerable()
                                                   where p["custorderno"].ToString().Equals(custorderno) && p["cartonno"].ToString().Equals(nextCnt)
                                               orderby p["styleno"].ToString(), p["color"].ToString()
                                               select p;

                                    setCellValue(beforeRow - rownum + 1, 4, nextCnt);
                                    setCellValue(beforeRow - rownum + 1, beforeCol + 2, (Convert.ToInt16(getCellValue(beforeRow - rownum + 1, beforeCol + 2)) + 1).ToString());

                                    foreach (System.Data.DataRow dtl in nextdtlq)
                                    {
                                        for (int cntrow = 0; cntrow < rownum; cntrow++)
                                        {
                                            int fixrow = beforeRow - rownum + 1 + cntrow;
                                            if (getCellValue(fixrow, 5).ToString().Equals(dtl["styleno"].ToString())
                                                && getCellValue(fixrow, 6).ToString().Equals(dtl["color"].ToString()))
                                            {
                                                //for (int i = 7; i <= beforeCol; i++)
                                                //{
                                                //    if (getCellValue(8, i).ToString().Equals(dtl["size"].ToString()))
                                                //    {
                                                //        setCellValue(fixrow, i, (Convert.ToInt16(getCellValue(fixrow, i)) + Convert.ToInt16(dtl["pairqty"])).ToString());
                                                //    }
                                                //}
                                                
                                                setCellValue(beforeRow - rownum+1, beforeCol + 3, (Convert.ToInt16(getCellValue(beforeRow - rownum +1, beforeCol + 3)) + Convert.ToInt16(dtl["pairqty"])).ToString());
                                                //setCellValue(fixrow, beforeCol + 2, (Convert.ToInt16(getCellValue(fixrow, beforeCol + 2))+1).ToString());
                                                //setCellValue(fixrow, beforeCol + 3, (Convert.ToInt16(getCellValue(fixrow, beforeCol + 3)) + Convert.ToInt16(dtl["pairqty"])).ToString());
                                            }
                                        }
                                    }
                                    lstCartonNo.Remove(nextCnt);
                                    nextCnt = GetNextCartonNo(nextCnt);
                                }
                                else
                                {
                                    nextCnt = null;
                                }
                            }
                        }

                        workSheet.get_Range("A"+custorderrow, "A"+beforeRow).MergeCells = true;
                        workSheet.get_Range("A" + custorderrow, "A" + beforeRow).Font.Name = "宋体";
                        workSheet.get_Range("A" + custorderrow, "A" + beforeRow).Font.Size = 11;
                        workSheet.get_Range("A" + custorderrow, "A" + beforeRow).Font.Bold = true;
                        workSheet.get_Range("A" + custorderrow, "A" + beforeRow).VerticalAlignment = XlVAlign.xlVAlignCenter;
                        workSheet.get_Range("A" + custorderrow, "A" + beforeRow).HorizontalAlignment = XlHAlign.xlHAlignCenter;

                    }
                }

                
                //for (int i = 7; i <= beforeCol; i++)
                //{
                //    ((Range)workSheet.Cells[beforeRow + 1, i]).Formula = "=SUM(" + IndexToColumn(i) + "9:" + IndexToColumn(i) + beforeRow + ")";
                //}
                setCellValue(beforeRow + 1, beforeCol + 2, Convert.ToInt16(headerDt.Rows[0]["cartonqty"]) - emptyCartonQty);
                ((Range)workSheet.Cells[beforeRow + 1, beforeCol + 3]).Formula = "=SUM(" + IndexToColumn(beforeCol + 3) + "9:" + IndexToColumn(beforeCol + 3) + beforeRow + ")";

                #region Summary
                int sumrow = 0;
                var sumq = (from p in detailDt.AsEnumerable()
                            orderby p["styleno"].ToString(), p["color"].ToString(), p["size"].ToString(), p["pairqty"].ToString()
                            select new
                            {
                                custorderno = p["custorderno"].ToString(),
                                styleno = p["styleno"].ToString(),
                                color = p["color"].ToString()
                            }).Distinct();

                if (sumq.Count() > 2)
                {
                    for (int i = 0; i < sumq.Count()-2 + 1; i++)
                    {
                        int nowrow = beforeRow + 11 + i;
                        ((Range)workSheet.Rows[nowrow, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                        workSheet.get_Range("B" + nowrow, "D" + nowrow).MergeCells = true;
                        workSheet.get_Range("B" + nowrow, "D" + nowrow).Borders.LineStyle = 1;
                    }
                }

                foreach (var s in sumq)
                {
                    int nowRow = beforeRow + 9 + (++sumrow);
                    setCellValue(nowRow, 2, s.custorderno);                    
                    setCellValue(nowRow, 5, s.styleno);
                    setCellValue(nowRow, 6, s.color);

                    ((Range)workSheet.Cells[nowRow, 2]).Borders.LineStyle = 1;
                    ((Range)workSheet.Cells[nowRow, 5]).Borders.LineStyle = 1;
                    ((Range)workSheet.Cells[nowRow, 6]).Borders.LineStyle = 1;
                }

                var sumsizeq = from p in detailDt.AsEnumerable()
                               group p by new
                               {
                                   custorderno = p["custorderno"].ToString(),
                                   styleno = p["styleno"].ToString(),
                                   color = p["color"].ToString(),
                                   size = p["size"].ToString()
                               } into q
                               select new
                               {
                                   custorderno = q.Key.custorderno,
                                   styleno = q.Key.styleno,
                                   color = q.Key.color,
                                   size = q.Key.size,
                                   sumpairqty = q.Sum(p => Convert.ToInt16(p["pairqty"])),
                                   cartonqty=q.Count()
                               };

                foreach (var s in sumsizeq)
                {
                    for (int i = 0; i < sumq.Count(); i++)
                    {
                        int nowrow = beforeRow + 10 + i;
                        if (getCellValue(nowrow, 2).ToString().Equals(s.custorderno) &&
                            getCellValue(nowrow, 5).ToString().Equals(s.styleno) &&
                            getCellValue(nowrow, 6).ToString().Equals(s.color))
                        {
                            for (int j = 7; j <= beforeCol; j++)
                            {
                                if (getCellValue(8, j).ToString().Equals(s.size))
                                {
                                    setCellValue(nowrow, j, s.sumpairqty);
                                    ((Range)workSheet.Cells[nowrow, j]).Borders.LineStyle = 1;
                                }
                            }
                            //int cartonqty = s.cartonqty;
                            //if (getCellValue(nowrow, beforeCol + 2) != null && !getCellValue(nowrow, beforeCol + 2).ToString().Equals(""))
                            //{
                            //    cartonqty = cartonqty + Convert.ToInt16(getCellValue(nowrow, beforeCol + 2));
                            //}
                            //setCellValue(nowrow, beforeCol + 2, cartonqty);
                            ((Range)workSheet.Cells[nowrow, beforeCol + 2]).Borders.LineStyle = 1;
                        }
                    }
                }
                string preCustOrderNo = "";
                string preStyleNo = "";
                int sameStyleNoRow = beforeRow + 10;
                for (int i = 0; i < sumq.Count(); i++)
                {
                    int nowrow = beforeRow + 10 + i;
                    ((Range)workSheet.Cells[nowrow, beforeCol + 1]).Formula = "=SUM(" + IndexToColumn(7) + nowrow + ":" + IndexToColumn(beforeCol) + nowrow + ")";
                    ((Range)workSheet.Cells[nowrow, beforeCol + 1]).Borders.LineStyle = 1;
                    if (!getCellValue(nowrow, 2).ToString().Equals(preCustOrderNo) || !getCellValue(nowrow, 5).ToString().Equals(preStyleNo))
                    {
                        if (!preCustOrderNo.Equals("") && !preStyleNo.Equals(""))
                        {
                            ((Range)workSheet.Cells[sameStyleNoRow, beforeCol + 3]).Formula = "=SUM(" + IndexToColumn(beforeCol + 1) + sameStyleNoRow + ":" + IndexToColumn(beforeCol + 1) + (nowrow - 1) + ")";
                            ((Range)workSheet.Cells[sameStyleNoRow, beforeCol + 3]).Borders.LineStyle = 1;
                            workSheet.get_Range(IndexToColumn(beforeCol + 3) +  sameStyleNoRow, IndexToColumn(beforeCol + 3) + (nowrow - 1)).MergeCells = true;
                            workSheet.get_Range(IndexToColumn(beforeCol + 3) + sameStyleNoRow, IndexToColumn(beforeCol + 3) + (nowrow - 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            
                            if (sameStyleNoRow != beforeRow + 10)
                            {
                                workSheet.get_Range(IndexToColumn(beforeCol + 3) + sameStyleNoRow, IndexToColumn(beforeCol + 3) + (nowrow - 1)).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            }                            
                            workSheet.get_Range(IndexToColumn(beforeCol + 3) + sameStyleNoRow, IndexToColumn(beforeCol + 3) + (nowrow - 1)).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            
                        }
                        sameStyleNoRow = nowrow;
                        preCustOrderNo = getCellValue(nowrow, 2).ToString();
                        preStyleNo = getCellValue(nowrow, 5).ToString();
                    }
                }
                if (sumq.Count() > 0)
                {
                    ((Range)workSheet.Cells[sameStyleNoRow, beforeCol + 3]).Formula = "=SUM(" + IndexToColumn(beforeCol + 1) + sameStyleNoRow + ":" + IndexToColumn(beforeCol + 1) + (beforeRow + 9 + sumq.Count()) + ")";
                    workSheet.get_Range(IndexToColumn(beforeCol + 3) +  sameStyleNoRow, IndexToColumn(beforeCol + 3) + (beforeRow + 9 + sumq.Count())).MergeCells = true;
                    workSheet.get_Range(IndexToColumn(beforeCol + 3) + sameStyleNoRow, IndexToColumn(beforeCol + 3) + (beforeRow + 9 + sumq.Count())).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    
                    if (sameStyleNoRow != beforeRow + 10)
                    {
                        workSheet.get_Range(IndexToColumn(beforeCol + 3) + sameStyleNoRow, IndexToColumn(beforeCol + 3) + (beforeRow + 9 + sumq.Count())).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    }
                    if (sumq.Count() < 2)
                    {
                        workSheet.get_Range(IndexToColumn(beforeCol + 3) + sameStyleNoRow, IndexToColumn(beforeCol + 3) + (beforeRow + 9 + sumq.Count())).Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    }
                    //((Range)workSheet.Rows[beforeRow + 10 + sumq.Count(), Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                    //workSheet.get_Range("B" + (beforeRow + 10 + sumq.Count()), IndexToColumn(beforeCol + 1) + (beforeRow + 10 + sumq.Count())).MergeCells = true;
                    ((Range)workSheet.Cells[beforeRow + 10 + sumq.Count(), 1]).Borders.LineStyle = 1;
                    workSheet.get_Range("B" + (beforeRow + 10 + sumq.Count()), IndexToColumn(beforeCol + 1) + (beforeRow + 10 + sumq.Count())).Borders.LineStyle = 1;
                    ((Range)workSheet.Cells[beforeRow + 10 + sumq.Count(), beforeCol + 2]).Borders.LineStyle = 1;
                    ((Range)workSheet.Cells[beforeRow + 10 + sumq.Count(), beforeCol + 3]).Borders.LineStyle = 1;
                    ((Range)workSheet.Cells[beforeRow + 10 + sumq.Count(), beforeCol + 2]).Formula = "=" + IndexToColumn(beforeCol + 2) + (beforeRow + 1);
                    ((Range)workSheet.Cells[beforeRow + 10 + sumq.Count(), beforeCol + 3]).Formula = "=SUM(" + IndexToColumn(beforeCol + 3) + (beforeRow + 10) + ":" + IndexToColumn(beforeCol + 3) + (beforeRow + 9 + sumq.Count()) + ")";
                    ((Range)workSheet.Cells[beforeRow + 10 + sumq.Count(), beforeCol + 3]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                }

                
                #endregion

                
                saveAsExcel("PackingList_" + headerDt.Rows[0]["shippingno"].ToString().Trim() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");

                app.Visible = true;
            }
            catch (Exception ex)
            {
                CloseExcel();
                throw ex;
            }
        }

        public void ExportWarehouseOutRpt(System.Data.DataTable headerDt, System.Data.DataTable detailDt, int rptNum)
        {
            try
            {
                OpenExcel(templatePath + "WarehouseOut.xls", 1);
                if (rptNum == 1)
                {
                    setCellValue(1, 8, "第一联 存根联");
                }
                else
                {
                    setCellValue(1, 8, "第二联 客户联");
                }
                setCellValue(3, 8, "单号：" + headerDt.Rows[0]["shippingno"].ToString());
                setCellValue(5, 2, headerDt.Rows[0]["customername"].ToString());
                setCellValue(5, 5, headerDt.Rows[0]["factory"].ToString());
                ((Range)workSheet.Cells[5, 8]).NumberFormatLocal = @"yyyy-mm-dd";
                setCellValue(5, 8, Convert.ToDateTime(headerDt.Rows[0]["shippeddate"]).ToString("yyyy-MM-dd"));
                ((Range)workSheet.Cells[5, 8]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                int beforeRow = 6;
                foreach (System.Data.DataRow row in detailDt.Rows)
                {
                    int nowRow = ++beforeRow;
                    ((Range)workSheet.Rows[nowRow, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                    workSheet.get_Range("A" + nowRow, "B" + nowRow).MergeCells = true;
                    workSheet.get_Range("C" + nowRow, "D" + nowRow).MergeCells = true;
                    workSheet.get_Range("G" + nowRow, "H" + nowRow).MergeCells = true;

                    ((Range)workSheet.Cells[nowRow, 1]).NumberFormatLocal = "@";
                    setCellValue(nowRow, 1, row["custorderno"].ToString());
                    setCellValue(nowRow, 3, row["styleno"].ToString());
                    setCellValue(nowRow, 5, row["stylecartonqty"]);
                    setCellValue(nowRow, 6, row["pairqty"]);
                    setCellValue(nowRow, 7, "");


                }

                if (beforeRow > 6)
                {
                    setCellValue(beforeRow + 1, 5, headerDt.Rows[0]["actcartonqty"]);
                    ((Range)workSheet.Cells[beforeRow + 1, 6]).Formula = "=SUM(F7:F" + beforeRow + ")";
                }

                saveAsExcel("WarehouseOut_" + headerDt.Rows[0]["shippingno"].ToString().Trim() + "_" + rptNum + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");

                app.Visible = true;
            }
            catch (Exception ex)
            {
                CloseExcel();
                throw ex;
            }
        }

        public void ExportFinalFailedRpt(System.Data.DataTable dt)
        {
            try
            {
                OpenExcel(templatePath + "FinalFailedRpt.xls", 1);

                if (dt.Rows.Count > 0)
                {
                    setCellValue(5, 2, dt.Rows[0]["customername"].ToString());
                    setCellValue(5, 5, dt.Rows[0]["custorderno"].ToString());

                    var sumq = from p in dt.AsEnumerable()
                                   group p by new
                                   {
                                       custorderno = p["custorderno"].ToString(),
                                       styleno = p["styleno"].ToString(),
                                       color = p["color"].ToString(),
                                       size = p["size"].ToString()
                                   } into q
                                   select new
                                   {
                                       custorderno = q.Key.custorderno,
                                       styleno = q.Key.styleno,
                                       color = q.Key.color,
                                       size = q.Key.size,
                                       sumpairqty = q.Sum(p => Convert.ToInt16(p["pairqty"]))
                                   };

                    int beforeRow = 6;
                    foreach (var s in sumq)
                    {
                        int nowRow = ++beforeRow;
                        ((Range)workSheet.Rows[nowRow, Type.Missing]).Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                        workSheet.get_Range("A" + nowRow, "B" + nowRow).MergeCells = true;
                        workSheet.get_Range("C" + nowRow, "D" + nowRow).MergeCells = true;
                        workSheet.get_Range("G" + nowRow, "H" + nowRow).MergeCells = true;

                        ((Range)workSheet.Cells[nowRow, 1]).NumberFormatLocal = "@";
                        ((Range)workSheet.Cells[nowRow, 3]).NumberFormatLocal = "@";
                        ((Range)workSheet.Cells[nowRow, 5]).NumberFormatLocal = "@";
                        setCellValue(nowRow, 1, s.styleno.ToString());
                        setCellValue(nowRow, 3, s.color.ToString());
                        setCellValue(nowRow, 5, s.size);
                        setCellValue(nowRow, 6, s.sumpairqty);
                    }

                    if (beforeRow > 6)
                    {
                        ((Range)workSheet.Cells[beforeRow + 1, 6]).Formula = "=SUM(F7:F" + beforeRow + ")";
                        //((Range)workSheet.Cells[beforeRow + 1, 6]).Font.a
                    }
                }

                saveAsExcel("FinalFailedRpt_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");

                app.Visible = true;
            }
            catch (Exception ex)
            {
                CloseExcel();
                throw ex;
            }

        }

        private void OpenExcel(string fileName,int sheetIndex)
        {
            if (!File.Exists(fileName))
                throw new Exception("指定路径的Excel文件不存在！");

            if (app == null)
                app = new Microsoft.Office.Interop.Excel.Application();

            app.DisplayAlerts = false;
            //打开一个WorkBook
            workBook = app.Workbooks.Open(fileName,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //得到WorkSheet对象
            workSheet = (Worksheet)workBook.Sheets.get_Item(sheetIndex);                                  
        }

        private object getCellValue(int row, int col)
        {
            Range cell = (Range)workSheet.Cells[row, col];
            return cell.Value;
        }

        private void setCellValue(int row, int col, object value)
        {
            Range cell = (Range)workSheet.Cells[row, col];
            cell.Value = value;
        }

        private void saveAsExcel(string fileName)
        {
            if (!Directory.Exists(excelRptPath))
            {
                Directory.CreateDirectory(excelRptPath);
            }
            workBook.SaveAs(excelRptPath + fileName);
        }

        private void CloseExcel()
        {
            try
            {
                workBook.Close();
                workSheet = null;
                workBook = null;
                app.Quit();
                app = null;
            }
            catch
            {
            }
        }

                /// <summary>
        /// 用于excel表格中列号字母转成列索引，从1对应A开始
        /// </summary>
        /// <param name="column">列号</param>
        /// <returns>列索引</returns>
        private int ColumnToIndex(string column)
        {
            if (!Regex.IsMatch(column.ToUpper(), @"[A-Z]+"))
            {
                throw new Exception("Invalid parameter");
            }
            int index = 0;
            char[] chars = column.ToUpper().ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                index += ((int)chars[i] - (int)'A' + 1) * (int)Math.Pow(26, chars.Length - i - 1);
            }
            return index;
        }
 
        /// <summary>
        /// 用于将excel表格中列索引转成列号字母，从A对应1开始
        /// </summary>
        /// <param name="index">列索引</param>
        /// <returns>列号</returns>
        private string IndexToColumn(int index)
        {
            if (index <= 0)
            {
                throw new Exception("Invalid parameter");
            }
            index--;
            string column = string.Empty;
            do
            {
                if (column.Length > 0)
                {
                    index--;
                }
                column = ((char)(index % 26 + (int)'A')).ToString() + column;
                index = (int)((index - index % 26) / 26);
            } while (index > 0);
            return column;
        }

        private string GetNextCartonNo(string cartonno)
        {
            string result = null;
            for (int i = 0; i < cartonno.Length; i++)
            {
                if (i == 0)
                {
                    if (isNumberic(cartonno))
                    {
                        result = (Convert.ToInt16(cartonno) + 1).ToString();
                        break;
                    }
                }
                else
                {
                    string str = cartonno.Substring(i);
                    if (isNumberic(str))
                    {
                        result = cartonno.Substring(0, i) + (Convert.ToInt16(str) + 1).ToString();
                        break;
                    }
                }
            }
            return result;
        }

        private bool isNumberic(string str)
        {
            System.Text.RegularExpressions.Regex rex = new System.Text.RegularExpressions.Regex(@"^\d+$");
            if (rex.IsMatch(str))
            {
                return true;
            }
            else
                return false;
        }

        private DateTime GetReceiveDate(string[] orderNos)
        {
            DateTime result = DateTime.Parse("9999-01-01 00:00:00");
            foreach (string orderNo in orderNos)
            {
                System.Data.DataTable dt = GetReceivingDetail(orderNo);
                var q = (from p in dt.AsEnumerable()
                         select p["receivedate"]).Min();
                if (Convert.ToDateTime(q) < result)
                {
                    result = Convert.ToDateTime(q);
                }
            }

            return result;
        }

        private void SetCurrencyFormat(Range rg, string currency, bool hasSymbol)
        {
            rg.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            if (currency.Equals("RMB"))
            {
                if (hasSymbol)
                {
                    rg.NumberFormat = "¥#,##0.00";
                }
                else
                {
                    rg.NumberFormat = "#,##0.00";
                }
            }
            else if (currency.Equals("JPY"))
            {
                if (hasSymbol)
                {
                    rg.NumberFormat = "¥#,###";
                }
                else
                {
                    rg.NumberFormat = "#,###";
                }
            }
        }

        private DateTime GetShippingDate(string[] orderNos)
        {
            DateTime result = Function.GetNullDateTime();
            foreach (string orderNo in orderNos)
            {
                System.Data.DataTable dt = GetShippingDetail(orderNo);
                var q = (from p in dt.AsEnumerable()
                         select p["shippeddate"]).Max();
                if (Convert.ToDateTime(q) > result)
                {
                    result = Convert.ToDateTime(q);
                }
            }

            return result;
        }

        private System.Data.DataTable GetReceivingDetail(string orderNo)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            System.Data.DataTable dt =null;
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "custorderno",
                    ParamValue = orderNo,
                    ParamType = "string"
                });
               dt = client.GetReceivingDetailRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).Tables[0];
                
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

        private System.Data.DataTable GetShippingDetail(string orderNo)
        {
            wsINP.IwsINPClient client = new wsINP.IwsINPClient();
            System.Data.DataTable dt = null;
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "custorderno",
                    ParamValue = orderNo,
                    ParamType = "string"
                });
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "shippingstatus",
                    ParamValue = MES_ShippingStatus.Shipped.ToString(),
                    ParamType = "string"
                });
                dt = client.GetShippingDtlRecords(baseForm.CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).Tables[0];

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

        private string GetShoeCategory(string ShoeCategory, string lang)
        {
            string result=ShoeCategory;
            if (!lang.Equals("ZH"))
            {
                List<tsysstaticvalue> lstStaticValue = GENLSYS.MES.Common.Parameter.CURRENT_STATIC_VALUE as List<tsysstaticvalue>;
                var langq = from p in lstStaticValue
                            where p.svvalue.Equals(ShoeCategory)
                            select p;
                if (langq.Count() > 0)
                {
                    result = langq.ElementAt(0).svresourceid.Equals("") ? ShoeCategory : langq.ElementAt(0).svresourceid;
                }
            }
            return result;
        }
    }
}

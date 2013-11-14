using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.DataContracts.Common;
using GENLSYS.MES.DataContracts;
using GENLSYS.MES.Common;
using System.Data;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win;
using GENLSYS.MES.Utility;

namespace GENLSYS.MES.Win.Common.Classes
{
    public class DropDown
    {
        private static BaseForm baseForm = new BaseForm();

        public DropDown()
        {
        }

        public static void InitCMB_ValueType(ComboBox cmd)
        {
            cmd.Items.Clear();
            cmd.DisplayMember = "DisplayField";
            cmd.ValueMember = "ValueField";
            cmd.Items.Add(new ValueInfo()
            {
                DisplayField = "String",
                ValueField = "String"
            });
            cmd.Items.Add(new ValueInfo()
            {
                DisplayField = "Number",
                ValueField = "Number"
            });
            cmd.Items.Add(new ValueInfo()
            {
                DisplayField = "DateTime",
                ValueField = "DateTime"
            });
        }

        public static void InitCMB_ValueType(DataGridViewComboBoxColumn cmd)
        {
            cmd.Items.Clear();
            cmd.DisplayMember = "DisplayField";
            cmd.ValueMember = "ValueField";
            cmd.Items.Add(new ValueInfo()
            {
                DisplayField = "String",
                ValueField = "String"
            });
            cmd.Items.Add(new ValueInfo()
            {
                DisplayField = "Number",
                ValueField = "Number"
            });
            cmd.Items.Add(new ValueInfo()
            {
                DisplayField = "DateTime",
                ValueField = "DateTime"
            });
        }

        public static void InitCMB_AttributeType(ComboBox cmd)
        {
            cmd.Items.Clear();
            cmd.DisplayMember = "DisplayField";
            cmd.ValueMember = "ValueField";
            cmd.Items.Add(new ValueInfo()
            {
                DisplayField = "System",
                ValueField = "System"
            });
            cmd.Items.Add(new ValueInfo()
            {
                DisplayField = "User",
                ValueField = "User"
            });

        }

        public static void InitCMB_AttributeType(DataGridViewComboBoxColumn cmd)
        {
            cmd.Items.Clear();
            cmd.DisplayMember = "DisplayField";
            cmd.ValueMember = "ValueField";
            cmd.Items.Add(new ValueInfo()
            {
                DisplayField = "System",
                ValueField = "System"
            });
            cmd.Items.Add(new ValueInfo()
            {
                DisplayField = "User",
                ValueField = "User"
            });

        }

        public static void InitCMB_StaticValue(ComboBox cmb, MES_StaticValue_Type StaticValueType)
        {
            #region UsedBy
            cmb.Items.Clear();
            cmb.DisplayMember = "DisplayField";
            cmb.ValueMember = "ValueField";
            string res = string.Empty;

            foreach (tsysstaticvalue item in baseForm.GetStaticValue(StaticValueType))
            {
                res = item.svresourceid == null ? string.Empty : item.svresourceid;
                cmb.Items.Add(new ValueInfo()
                {
                    DisplayField = (res == string.Empty || UtilCulture.GetString(res) == null )? item.svtext : UtilCulture.GetString(res),
                    ValueField = item.svvalue
                });
            }
            #endregion
        }

        public static void InitCMB_StaticValue(ComboBox cmb, MES_StaticValue_Type StaticValueType,bool hasEmpty)
        {
            #region UsedBy
            cmb.Items.Clear();
            cmb.DisplayMember = "DisplayField";
            cmb.ValueMember = "ValueField";
            string res = string.Empty;

            if (hasEmpty)
            {
                cmb.Items.Add(new ValueInfo()
                {
                    DisplayField = "",
                    ValueField = ""
                });
            }

            foreach (tsysstaticvalue item in baseForm.GetStaticValue(StaticValueType))
            {
                res = item.svresourceid == null ? string.Empty : item.svresourceid;
                cmb.Items.Add(new ValueInfo()
                {
                    DisplayField = res == string.Empty ? item.svtext : UtilCulture.GetString(res),
                    ValueField = item.svvalue
                });
            }
            #endregion
        }

        public static void InitCMB_Language(ComboBox cmd)
        {
            cmd.Items.Clear();
            cmd.DisplayMember = "DisplayField";
            cmd.ValueMember = "ValueField";
            cmd.Items.Add(new ValueInfo()
            {
                DisplayField = "简体中文",
                ValueField = "zh-CHS"
            });
            cmd.Items.Add(new ValueInfo()
            {
                DisplayField = "English",
                ValueField = "en-US"
            });
        }

        public static void InitCMB_Customer_All(ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.DisplayMember = "DisplayField";
            cmb.ValueMember = "ValueField";

            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                List<tmdlcustomer> lstCustomer = client.GetCustomerList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tmdlcustomer>();

                var q =from p in lstCustomer orderby p.customername ascending select p;

                for (int i = 0; i < q.Count(); i++)
                {
                    cmb.Items.Add(new ValueInfo()
                    {
                        DisplayField = q.ElementAt(i).customername,
                        ValueField = q.ElementAt(i).customerid
                    });
                }
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
        public static void InitCMB_Customer_All_Name(ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.DisplayMember = "DisplayField";
            cmb.ValueMember = "ValueField";

            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                List<tmdlcustomer> lstCustomer = client.GetCustomerList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tmdlcustomer>();
                var q = from p in lstCustomer orderby p.customername ascending select p;
                for (int i = 0; i < q.Count(); i++)
                {
                    cmb.Items.Add(new ValueInfo()
                    {
                        DisplayField = q.ElementAt(i).customername,
                        ValueField = q.ElementAt(i).customername
                    });
                }
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

        public static void InitCMB_ReasonCategory_All(ComboBox cmd)
        {
            cmd.Items.Clear();
            cmd.DisplayMember = "DisplayField";
            cmd.ValueMember = "ValueField";

            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                List<tmdlreasoncategory> lstReasonCategory = client.GetReasonCategoryList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tmdlreasoncategory>();
                var q = from p in lstReasonCategory orderby p.reasoncategory ascending select p;
                for (int i = 0; i < q.Count(); i++)
                {
                    cmd.Items.Add(new ValueInfo()
                    {
                        DisplayField = q.ElementAt(i).reasoncategory,
                        ValueField = q.ElementAt(i).reasoncategory
                    });
                }
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

        public static void InitCMB_Enums(ComboBox cmd, Type myenum)
        {
            cmd.Items.Clear();
            cmd.DisplayMember = "DisplayField";
            cmd.ValueMember = "ValueField";

            foreach (object item in Enum.GetValues(myenum))
            {
                string resource = UtilCulture.GetString("Enum." + item.ToString());
                if (resource == null || resource.Equals("---"))
                {
                    cmd.Items.Add(new ValueInfo()
                    {
                        DisplayField = item.ToString(),
                        ValueField = item.ToString()
                    });
                }
                else
                {
                    cmd.Items.Add(new ValueInfo()
                    {
                        DisplayField = resource,
                        ValueField = item.ToString()
                    });
                }
            }
        }

        public static void InitCMB_Enums(ComboBox cmd, Type myenum,bool hasEmpty)
        {
            cmd.Items.Clear();
            cmd.DisplayMember = "DisplayField";
            cmd.ValueMember = "ValueField";

            if (hasEmpty)
            {
                cmd.Items.Add(new ValueInfo()
                {
                    DisplayField = "",
                    ValueField = ""
                });
            }

            foreach (object item in Enum.GetValues(myenum))
            {
                string resource = UtilCulture.GetString("Enum." + item.ToString());
                if (resource == null || resource.Equals("---"))
                {
                    cmd.Items.Add(new ValueInfo()
                    {
                        DisplayField = item.ToString(),
                        ValueField = item.ToString()
                    });
                }
                else
                {
                    cmd.Items.Add(new ValueInfo()
                    {
                        DisplayField = resource,
                        ValueField = item.ToString()
                    });
                }
            }
            
        }

        public static void InitCMB_Enums_NoResource(ComboBox cmd, Type myenum)
        {
            cmd.Items.Clear();
            cmd.DisplayMember = "DisplayField";
            cmd.ValueMember = "ValueField";

            foreach (object item in Enum.GetValues(myenum))
            {
                cmd.Items.Add(new ValueInfo()
                {
                    DisplayField = item.ToString(),
                    ValueField = item.ToString()
                });
            }
        }

        public static void InitCMB_Enums(DataGridViewComboBoxColumn column, Type myenum)
        {
            column.Items.Clear();
            column.DisplayMember = "DisplayField";
            column.ValueMember = "ValueField";

            foreach (object item in Enum.GetValues(myenum))
            {
                column.Items.Add(new ValueInfo()
                {
                    DisplayField = item.ToString(),
                    ValueField = item.ToString()
                });
            }
        }

        public static void InitCMB_Employee_Valid(ComboBox cmd)
        {
            cmd.Items.Clear();
            cmd.DisplayMember = "DisplayField";
            cmd.ValueMember = "ValueField";

            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "employeestatus",
                    ParamValue = MES_Flag.Valid.ToString(),
                    ParamType = "string"
                });

                List<tmdlemployee> lseEmployee = client.GetEmployeeList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tmdlemployee>();
                var q = from p in lseEmployee orderby p.employeeid ascending select p;
                for (int i = 0; i < q.Count(); i++)
                {
                    cmd.Items.Add(new ValueInfo()
                    {
                        DisplayField = q.ElementAt(i).employeeid + "(" + q.ElementAt(i).employeename + ")",
                        ValueField = q.ElementAt(i).employeeid
                    });
                }
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

        public static void InitCMB_ReasonCode_ByCategory(ComboBox cmd, MES_ReasonCategory reasonCategory)
        {
            cmd.Items.Clear();
            cmd.DisplayMember = "DisplayField";
            cmd.ValueMember = "ValueField";

            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "reasoncategory",
                    ParamValue = reasonCategory.ToString()
                });

                List<tmdlreasoncode> lstReasonCode = client.GetReasonCodeList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tmdlreasoncode>();
                var q = from p in lstReasonCode orderby p.reasoncodedesc ascending select p;
                for (int i = 0; i < q.Count(); i++)
                {
                    cmd.Items.Add(new ValueInfo()
                    {
                        DisplayField = q.ElementAt(i).reasoncodedesc,
                        ValueField = q.ElementAt(i).reasoncode
                    });
                }
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

        public static void InitCMB_ReasonCode_ByCategoryStep(ComboBox cmd,
            MES_ReasonCategory reasonCategory, string stepsysid)
        {
            cmd.Items.Clear();
            cmd.DisplayMember = "DisplayField";
            cmd.ValueMember = "ValueField";

            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                List<tmdlreasoncode> lstReasonCode = client.GetReasonCodeList_ByCategoryStep(
                    (new BaseForm()).CurrentContextInfo, reasonCategory.ToString(), stepsysid).ToList<tmdlreasoncode>();

                var q = from p in lstReasonCode orderby p.reasoncodedesc ascending select p;
                for (int i = 0; i < q.Count(); i++)
                {
                    cmd.Items.Add(new ValueInfo()
                    {
                        DisplayField = q.ElementAt(i).reasoncodedesc,
                        ValueField = q.ElementAt(i).reasoncode
                    });
                }
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

        public static void InitCMB_Shift_All(ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.DisplayMember = "DisplayField";
            cmb.ValueMember = "ValueField";

            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                List<tmdlshift> lstShift = client.GetShiftList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tmdlshift>();
                var q = (from p in lstShift
                         orderby p.shift ascending
                         select p);

                foreach (tmdlshift sf in q)
                {
                    cmb.Items.Add(new ValueInfo()
                    {
                        DisplayField = sf.shiftname,
                        ValueField = sf.shift
                    });
                }
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

        public static void InitCMB_WorkGroup(ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.DisplayMember = "DisplayField";
            cmb.ValueMember = "ValueField";

            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                List<tmdlworkgroup> lstShift = client.GetWorkGroupList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tmdlworkgroup>();

                var q = from p in lstShift orderby p.workgroupdesc ascending select p;
                foreach (tmdlworkgroup workgroup in q)
                {
                    cmb.Items.Add(new ValueInfo()
                    {
                        DisplayField = workgroup.workgroupdesc,
                        ValueField = workgroup.workgroup
                    });
                }
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

        public static void InitCMB_Shift_All(UltraComboEditor cmb)
        {
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                cmb.DataSource = client.GetShiftRecords((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).Tables[0];
                cmb.DisplayMember = "shiftname";
                cmb.ValueMember = "shift";
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

        public static void InitCMB_AttributeTemplate_All(ComboBox cmb, MES_AttributeTemplate_UsedBy usedBy)
        {
            cmb.Items.Clear();
            cmb.DisplayMember = "DisplayField";
            cmb.ValueMember = "ValueField";

            wsSYS.IwsSYSClient client = new wsSYS.IwsSYSClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>()
                {
                    new MESParameterInfo()
                    {
                        ParamName="usedby",
                        ParamValue = usedBy.ToString(),
                        ParamType="string"
                    }
                };
                List<tsysattrtplate> lstArrtibueteTemplate = client.GetAttributeTemplateList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tsysattrtplate>();

                var q = from p in lstArrtibueteTemplate orderby p.attrtplatname ascending select p;
                for (int i = 0; i < q.Count(); i++)
                {
                    cmb.Items.Add(new ValueInfo()
                    {
                        DisplayField = q.ElementAt(i).attrtplatname,
                        ValueField = q.ElementAt(i).attrtplatid
                    });
                }
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

        public static void InitCMB_EmployeeType_All(ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.DisplayMember = "DisplayField";
            cmb.ValueMember = "ValueField";

            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                List<tmdlemployeetype> lstemtype = client.GetEmployeeTypeList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tmdlemployeetype>();

                var q = from p in lstemtype orderby p.employeetypename ascending select p;
                for (int i = 0; i < q.Count(); i++)
                {
                    cmb.Items.Add(new ValueInfo()
                    {
                        DisplayField = q.ElementAt(i).employeetypename,
                        ValueField = q.ElementAt(i).employeetypeid
                    });
                }
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

        public static void SelectCMBValue(ComboBox cmb, string value)
        {
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                ValueInfo valueInfo = cmb.Items[i] as ValueInfo;
                if (valueInfo.ValueField.Equals(value))
                {
                    cmb.SelectedIndex = i;
                    return;
                }
            }
        }

        public static void InitCMB_DataTable(ComboBox cmb, DataTable dt, string displayField, string valueField)
        {
            cmb.Items.Clear();
            cmb.DisplayMember = "DisplayField";
            cmb.ValueMember = "ValueField";

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmb.Items.Add(new ValueInfo()
                    {
                        DisplayField = dt.Rows[i][displayField].ToString(),
                        ValueField = dt.Rows[i][valueField].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
      
        #region UltraGrid ValueList
        public static ValueListItem[] GetValueList_Enums(Type myenum)
        {
            List<ValueListItem> lstEnum = new List<ValueListItem>();

            foreach (object item in Enum.GetValues(myenum))
            {
                string resource = UtilCulture.GetString("Enum." + item.ToString());
                if (resource == null || resource.Equals("---"))
                {
                    ValueListItem list = new ValueListItem()
                    {
                        DisplayText = item.ToString(),
                        DataValue = item.ToString()
                    };
                    lstEnum.Add(list);
                }
                else
                {
                    ValueListItem list = new ValueListItem()
                    {
                        DisplayText = resource,
                        DataValue = item.ToString()
                    };
                    lstEnum.Add(list);
                }

            }

            return lstEnum.ToArray<ValueListItem>();
        }

        public static ValueListItem[] GetValueList_StaticValue(MES_StaticValue_Type staticValueType)
        {
            List<ValueListItem> lstStaticValue = new List<ValueListItem>();

            string res = string.Empty;

            foreach (tsysstaticvalue item in baseForm.GetStaticValue(staticValueType))
            {
                res = item.svresourceid == null ? string.Empty : item.svresourceid;
                ValueListItem list = new ValueListItem()
                {
                    DisplayText = res == string.Empty ? item.svtext : UtilCulture.GetString(res),
                    DataValue = item.svvalue
                };
                lstStaticValue.Add(list);
            }

            return lstStaticValue.ToArray<ValueListItem>();
        }

        public static ValueListItem[] GetValueList_Employee(string employeeType)
        {
            List<ValueListItem> lstVL = new List<ValueListItem>();
            ValueListItem emptyitem = new ValueListItem()
            {
                DisplayText = "　",
                DataValue = ""
            };
            lstVL.Add(emptyitem);

            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo()
                {
                    ParamName = "employeetypeid",
                    ParamValue = employeeType,
                    ParamType = "string"
                });
                List<tmdlemployee> lstEmployee = client.GetEmployeeList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tmdlemployee>();
                var q = from p in lstEmployee orderby p.employeename ascending select p;
                for (int i = 0; i < q.Count(); i++)
                {
                    ValueListItem item = new ValueListItem()
                    {
                        DisplayText = q.ElementAt(i).employeename.Trim(),
                        DataValue = q.ElementAt(i).employeeid
                    };
                    lstVL.Add(item);
                }

                return lstVL.ToArray<ValueListItem>();
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

        public static ValueListItem[] GetValueList_Employee()
        {
            List<ValueListItem> lstVL = new List<ValueListItem>();
            ValueListItem emptyitem = new ValueListItem()
            {
                DisplayText = "　",
                DataValue = ""
            };
            lstVL.Add(emptyitem);

            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();

            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                //lstParameters.Add(new MESParameterInfo()
                //{
                //    ParamName = "employeestatus",
                //    ParamValue = MES_Flag.Valid.ToString(),
                //    ParamType = "string"
                //});
                List<tmdlemployee> lstEmployee = client.GetEmployeeList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<tmdlemployee>();
                var q = from p in lstEmployee orderby p.employeename ascending select p;
                for (int i = 0; i < q.Count(); i++)
                {
                    ValueListItem item = new ValueListItem()
                    {
                        DisplayText = q.ElementAt(i).employeename.Trim(),
                        DataValue = q.ElementAt(i).employeeid
                    };
                    lstVL.Add(item);
                }

                return lstVL.ToArray<ValueListItem>();
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

        public static ValueListItem[] GetValueList_ReasonCode(MES_ReasonCategory reasonCategory)
        {
            List<ValueListItem> lstVL = new List<ValueListItem>();
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
                lstParameters.Add(new MESParameterInfo() { 
                    ParamName="reasoncategory",
                    ParamValue=reasonCategory.ToString()
                });
                List<tmdlreasoncode> lstReasonCode = client.GetReasonCodeList((new BaseForm()).CurrentContextInfo,
                    lstParameters.ToArray<MESParameterInfo>()).ToList();

                var q = from p in lstReasonCode orderby p.reasoncodedesc ascending select p;
                for (int i = 0; i < q.Count(); i++)
                {
                    ValueListItem item = new ValueListItem()
                    {
                        DisplayText = q.ElementAt(i).reasoncodedesc,
                        DataValue = q.ElementAt(i).reasoncode
                    };
                    lstVL.Add(item);
                }
                return lstVL.ToArray<ValueListItem>();
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

        public static ValueListItem[] GetValueList_Customer_All()
        {
            List<ValueListItem> lstVL = new List<ValueListItem>();
            wsMDL.IwsMDLClient client = new wsMDL.IwsMDLClient();
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
                List<tmdlcustomer> lstCustomer = client.GetCustomerList((new BaseForm()).CurrentContextInfo,
                    lstParameters.ToArray<MESParameterInfo>()).ToList();
                var q = from p in lstCustomer orderby p.customername ascending select p;
                for (int i = 0; i < q.Count(); i++)
                {
                    ValueListItem item = new ValueListItem()
                    {
                        DisplayText = q.ElementAt(i).customername,
                        DataValue = q.ElementAt(i).customerid
                    };
                    lstVL.Add(item);
                }
                return lstVL.ToArray<ValueListItem>();
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

        public static ValueListItem[] GetValueList_DataTable(DataTable dt, string displayField, string valueField)
        {
            List<ValueListItem> lstVL = new List<ValueListItem>();
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
                foreach(DataRow row in dt.Rows)
                {
                    ValueListItem item = new ValueListItem()
                    {
                        DisplayText = row[displayField].ToString(),
                        DataValue = row[valueField].ToString()
                    };
                    lstVL.Add(item);
                }
                return lstVL.ToArray<ValueListItem>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ValueListItem[] GetValueList_DataTable(DataRow[] rows, string displayField, string valueField)
        {
            List<ValueListItem> lstVL = new List<ValueListItem>();
            try
            {
                List<MESParameterInfo> lstParameters = new List<MESParameterInfo>() { };
                foreach (DataRow row in rows)
                {
                    ValueListItem item = new ValueListItem()
                    {
                        DisplayText = row[displayField].ToString(),
                        DataValue = row[valueField].ToString()
                    };
                    lstVL.Add(item);
                }
                return lstVL.ToArray<ValueListItem>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Warehouse
        //public static void InitCMB_Warehouse_All(ComboBox cmb)
        //{
        //    cmb.Items.Clear();
        //    cmb.DisplayMember = "DisplayField";
        //    cmb.ValueMember = "ValueField";

        //    wsWHS.IwsWHSClient client = new wsWHS.IwsWHSClient();

        //    try
        //    {
        //        List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
        //        List<twhswarehouse> lstWarehouse = client.GetWarehouseList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<twhswarehouse>();
        //        for (int i = 0; i < lstWarehouse.Count; i++)
        //        {
        //            cmb.Items.Add(new ValueInfo()
        //            {
        //                DisplayField = lstWarehouse[i].whno,
        //                ValueField = lstWarehouse[i].whno
        //            });
        //        }
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

        //public static void InitCMB_Warehouse_Valid(ComboBox cmb)
        //{
        //    cmb.Items.Clear();
        //    cmb.DisplayMember = "DisplayField";
        //    cmb.ValueMember = "ValueField";

        //    wsWHS.IwsWHSClient client = new wsWHS.IwsWHSClient();

        //    try
        //    {
        //        List<MESParameterInfo> lstParameters = new List<MESParameterInfo>()
        //        {
        //            new MESParameterInfo(){
        //                ParamName="whstatus",
        //                ParamValue=MES_Warehouse_Status.Valid.ToString()
        //            }
        //        };
        //        List<twhswarehouse> lstWarehouse = client.GetWarehouseList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<twhswarehouse>();
        //        for (int i = 0; i < lstWarehouse.Count; i++)
        //        {
        //            cmb.Items.Add(new ValueInfo()
        //            {
        //                DisplayField = lstWarehouse[i].whno,
        //                ValueField = lstWarehouse[i].whno
        //            });
        //        }
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

        //public static void InitCMB_Location_All(ComboBox cmb)
        //{
        //    cmb.Items.Clear();
        //    cmb.DisplayMember = "DisplayField";
        //    cmb.ValueMember = "ValueField";

        //    wsWHS.IwsWHSClient client = new wsWHS.IwsWHSClient();

        //    try
        //    {
        //        List<MESParameterInfo> lstParameters = new List<MESParameterInfo>();
        //        List<twhslocation> lstLocation = client.GetLocationList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<twhslocation>();
        //        for (int i = 0; i < lstLocation.Count; i++)
        //        {
        //            cmb.Items.Add(new ValueInfo()
        //            {
        //                DisplayField = lstLocation[i].location,
        //                ValueField = lstLocation[i].location
        //            });
        //        }
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

        //public static void InitCMB_WOType_Valid(ComboBox cmb, MES_WOType_Flag? woFlag)
        //{
        //    cmb.Items.Clear();
        //    cmb.DisplayMember = "DisplayField";
        //    cmb.ValueMember = "ValueField";

        //    wsWHS.IwsWHSClient client = new wsWHS.IwsWHSClient();

        //    try
        //    {
        //        List<MESParameterInfo> lstParameters = new List<MESParameterInfo>()
        //        {
        //            new MESParameterInfo(){
        //                ParamName="wotypestatus",
        //                ParamValue=MES_Warehouse_Status.Valid.ToString()
        //            }
        //        };

        //        if (woFlag.HasValue)
        //        {
        //            lstParameters.Add(new MESParameterInfo()
        //            {
        //                ParamName = "wotypeflag",
        //                ParamValue = woFlag.Value.ToString()
        //            });
        //        }

        //        List<twhswotype> lstWOType = client.GetWOTypeList((new BaseForm()).CurrentContextInfo, lstParameters.ToArray<MESParameterInfo>()).ToList<twhswotype>();
        //        for (int i = 0; i < lstWOType.Count; i++)
        //        {
        //            cmb.Items.Add(new ValueInfo()
        //            {
        //                DisplayField = lstWOType[i].wotypedesc,
        //                ValueField = lstWOType[i].wotype
        //            });
        //        }
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
    }
}

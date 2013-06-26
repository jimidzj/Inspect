using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using GENLSYS.MES.Common;
using System.Globalization;

namespace GENLSYS.MES.Services.Common
{
    public class XMLLogBuilder
    {
        public static string BuildLog(MES_ActionType action, object newobj, object oldobj)
        {
            string lgtx = string.Empty;

            object obj = oldobj == null ? newobj : oldobj;

            if (action == MES_ActionType.Update)
            {
                lgtx = BuildOperationDescUpdate(newobj, oldobj, Function.GetGUID());
            }
            else if (action ==  MES_ActionType.Insert)
            {
                lgtx = BuildOperationDesc(newobj, action, Function.GetGUID());
            }
            else if (action == MES_ActionType.Delete)
            {
                lgtx = BuildOperationDesc(newobj, action, Function.GetGUID());
            }

            return lgtx;
        }

        private static string BuildOperationDesc(object obj, MES_ActionType action, string lgid)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            string operationDesc = string.Empty;

            operationDesc = "<Log>";  //<Log>
            string actionText = string.Empty;

            if (action ==  MES_ActionType.Insert) actionText = "Add";
            if (action ==  MES_ActionType.Delete) actionText = "Delete";

            operationDesc += "<Action>" + actionText + "</Action>";

            operationDesc += "<LogId>" + lgid + "</LogId>";
            operationDesc += "<Reference></Reference>";

            operationDesc += "<LogText>";
            for (int i = 0; i < properties.Length; i++)
            {
                if (((properties[i].PropertyType.IsValueType) || (properties[i].PropertyType.FullName == "System.String"))
                    && (properties[i].Name != "lastmodifiedtime" && properties[i].Name != "lastmodifieduser"
                    && properties[i].Name != "rfid" && properties[i].Name != "creatededtime" && properties[i].Name != "createduser"))
                {
                    object o = properties[i].GetValue(obj, null);
                    string fieldName = properties[i].Name; // GetFieldRes(obj.GetType().Name, properties[i].Name, cultureInfo);

                    operationDesc += "<" + fieldName + ">" + o + "</" + fieldName + ">";
                }
            }
            operationDesc += "</LogText>";  //</Data>
            operationDesc += "</Log>";
            return operationDesc;
        }

        private static string BuildOperationDescUpdate(object objNew, object objOld, string lgid)
        {
            PropertyInfo[] propertiesNew = objNew.GetType().GetProperties();
            PropertyInfo[] propertiesOld = objOld.GetType().GetProperties();
            string operationDesc = string.Empty;
            bool isModified = false;

            operationDesc = "<Log>";  //<Log>
            operationDesc += "<Action>Update</Action>";

            operationDesc += "<LogId>" + lgid + "</LogId>";
            operationDesc += "<Reference></Reference>";

            operationDesc += "<LogText>";

            for (int i = 0; i < propertiesNew.Length; i++)
            {
                if (((propertiesNew[i].PropertyType.IsValueType) || (propertiesNew[i].PropertyType.FullName == "System.String"))
                    && (propertiesNew[i].Name != "lastmodifiedtime" && propertiesNew[i].Name != "lastmodifieduser"
                    && propertiesNew[i].Name != "rfid" && propertiesNew[i].Name != "creatededtime" && propertiesNew[i].Name != "createduser"))
                {
                    object oNew = propertiesNew[i].GetValue(objNew, null);
                    object oOld = propertiesOld[i].GetValue(objOld, null);

                    oNew = oNew == null ? string.Empty : oNew;
                    oOld = oOld == null ? string.Empty : oOld;

                    if (!oNew.Equals(oOld))
                    {
                        string fieldName = propertiesNew[i].Name;
                        operationDesc += "<" + fieldName + "><New>" + oNew + "</New>" +
                            "<Old>" + oOld + "</Old></" + fieldName + ">";

                        isModified = true;
                    }
                }
            }

            operationDesc += "</LogText>";  //</Data>
            operationDesc += "</Log>";

            if (isModified == false)
                operationDesc = string.Empty;

            return operationDesc;
        }
    }
}

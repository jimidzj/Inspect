using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Web;

namespace GENLSYS.MES.Utility
{
    public class UtilSecurity
    {
        #region EncryptPassword
        //Encrypt password
        public static string EncryptPassword(string _password)
        {
            //MD5 32λ����
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(_password, "MD5").ToLower();
        }
        #endregion EncryptPassword
    }
}

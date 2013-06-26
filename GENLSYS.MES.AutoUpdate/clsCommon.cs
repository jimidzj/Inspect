using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Win32;


namespace GENLSYS.MES.AutoUpdate
{
    public class clsCommon
    {
        public static bool FILESYSTEMWATCHERFLAG = false;
        public static bool ISFIRSTTIMESTART = true;
        public static List<LogBlock> LOGPOOL = null;
        public static List<string> LSTDISPLAYTEXT = null;
        public const  Int32 SECONDTOHIDE = 120;
        public static Int32 SECONDLEFT = SECONDTOHIDE;
        public static int TIMER_DOADDITIONACTION_INTERVAL = 10000;
        public static int TIMER_DOADDITIONACTION_FIRSTTIME_INTERVAL = 2000;
        public static int BALLOONTIP_TIMEOUT = 1000;
        private const Char XOR_STRING = 'a';

        public static string EncryptPassword_MD5(string unEncryptPassword)
        {
            string cl = unEncryptPassword;
            string encryptPassword = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            for (int i = 0; i < s.Length; i++)
            {
                encryptPassword = encryptPassword + s[i].ToString("X");
            }
            return encryptPassword;
        }

        public static String EncryptString(String sourceString)
        {
            Char[] sourceArray = sourceString.ToCharArray();
            System.Text.StringBuilder temp = new System.Text.StringBuilder();
            for (Int32 i = 0; i < sourceArray.Length; i++)
            {
                sourceArray[i] = (Char)(sourceArray[i] ^ XOR_STRING);
                temp.Append(sourceArray[i].ToString());
            }
            return temp.ToString();
        }

        public static String DencryptString(String ciphertext)
        {
            Char[] ciphertextArray = ciphertext.ToCharArray();
            System.Text.StringBuilder temp = new System.Text.StringBuilder();
            for (Int32 i = 0; i < ciphertextArray.Length; i++)
            {
                ciphertextArray[i] = (Char)(ciphertextArray[i] ^ XOR_STRING);
                temp.Append(ciphertextArray[i].ToString());
            }
            return temp.ToString();
        }

     }
}

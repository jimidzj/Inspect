using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace GENLSYS.MES.Utility
{
    public class RSALicense
    {
        public string publicKeyPath { get; set; }
        public string privateKeyPath { get; set; }
        public string licensePath { get; set; }
        public static LicenseInfo LICENSEN_INFO = new LicenseInfo();

        public void GenerateRSAKey()
        {
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                this.CreateFile(privateKeyPath, provider.ToXmlString(true));
                this.CreateFile(publicKeyPath, provider.ToXmlString(false));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void GenerateRSAKey(string privateKeyPath, string publicKeyPath)
        {
            this.privateKeyPath = privateKeyPath;
            this.publicKeyPath = publicKeyPath;
            GenerateRSAKey();
        }

        public void GenerateLicense(int usedDays)
        {
            string publicKey = ReadFile(publicKeyPath);

            LicenseInfo licenseInfo = new LicenseInfo();
            licenseInfo.usedDays = usedDays;
            string encryptString = RSAEncrypt(publicKey, licenseInfo.GenerateLicenseString());
            CreateFile(licensePath, encryptString);
        }

        public LicenseInfo GetLicense()
        {
            string privateKey = ReadFile(privateKeyPath);

            LicenseInfo licenseInfo = new LicenseInfo();

            string encryptString = ReadFile(licensePath);
            string licenseString = RSADecrypt(privateKey, encryptString);
            licenseInfo.GetInfo(licenseString);
            return licenseInfo;
        }

        public string RSAEncrypt(string publicKey, string encryptString)
        {
            string str;
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.FromXmlString(publicKey);
                byte[] bytes = new UnicodeEncoding().GetBytes(encryptString);
                str = Convert.ToBase64String(provider.Encrypt(bytes, false));
            }
            catch (Exception e)
            {
                throw e;
            }
            return str;
        }

        public string RSADecrypt(string privateKey, string decryptString)
        {
            string str;
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.FromXmlString(privateKey);
                byte[] rgb = Convert.FromBase64String(decryptString);
                byte[] buffer = provider.Decrypt(rgb, false);
                str = new UnicodeEncoding().GetString(buffer);

            }
            catch (Exception e)
            {
                throw e;
            }
            return str;
        }


        public void CreateFile(string path, string str)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(str);
                sw.Close();
                fs.Close();
            }
            catch
            {
                throw;
            }
        }

        public string ReadFile(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                string str = sr.ReadToEnd();
                sr.Close();

                return str;
            }
            catch
            {
                throw;
            }
        }
    }

    public class LicenseInfo
    {
        public string LicenseInformation { get; set; }
        public int usedDays { get; set; }
        public int leftDays { get; set; }
        public DateTime ExpiredDate { get; set; }


        public LicenseInfo()
        {
            this.LicenseInformation = "Unlimited Edition";
            this.usedDays = -1;
            this.ExpiredDate = DateTime.Now;
        }

        public void SetNoLicenseInfo()
        {
            this.LicenseInformation = "No License";
            this.usedDays = 0;
            this.leftDays = 0;
            this.ExpiredDate = DateTime.Now;
        }

        public string GenerateLicenseString()
        {
            if (usedDays < 0)
            {
                this.LicenseInformation = "Unlimited Edition";
            }
            else
            {
                this.LicenseInformation = "Trail Edition, {0} days left.";
                this.ExpiredDate = DateTime.Now.AddDays(usedDays);
            }
            return this.LicenseInformation + "||" + this.usedDays + "||" + this.ExpiredDate.ToString("yyyy-MM-dd");
        }

        public void GetInfo(string str)
        {
            string[] splitStr = str.Split(new string[] { "||" }, StringSplitOptions.None);
            this.LicenseInformation = splitStr[0];
            this.usedDays = Convert.ToInt16(splitStr[1]);
            this.ExpiredDate = DateTime.Parse(splitStr[2]);

            if (usedDays > 0)
            {
                TimeSpan ts = this.ExpiredDate - DateTime.Now;
                this.leftDays = (int)ts.TotalDays + 1;
                if (this.leftDays < 0) this.leftDays = 0;
                this.LicenseInformation = string.Format(this.LicenseInformation, new object[] { this.leftDays });
            }
        }

        public bool ValidateLicense()
        {
            if (usedDays < 0)
            {
                return true;
            }
            else
            {
                if (leftDays > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

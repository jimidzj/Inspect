using System;
using System.Collections.Generic;
using System.Text;
using EnterpriseDT.Net.Ftp;
using System.IO;

namespace GENLSYS.MES.AutoUpdate
{
    public class clsFTP : FTPConnection
    {
        private clsLog log = null;
        frmAutoUpdate face;
        public clsFTP()
        {
        }

        public clsFTP(clsLog _log)
        {
            log = _log;
        }

         public void setFace(frmAutoUpdate _face)
        {
            face = _face;
        }

        


        public enum UtilFTPTransferType
        {
            ASCII = 1,
            BINARY = 2
        }

        public void Connect(string host, int port, string user, string password, string serverDirectory, string encoding)
        {
            try
            {
                if (host.Trim() == "")
                {
                    throw new Exception("Host is empty.");
                }

                this.ServerAddress = host.Trim();
                this.ServerPort = port;
                this.UserName = user.Trim();
                this.Password = password;
                this.ServerDirectory = serverDirectory;
                this.DataEncoding = Encoding.Default;

                Encoding cmdEncoding = Encoding.Default;

                if (encoding.ToUpper() == "DEFAULT" || encoding == string.Empty)
                    cmdEncoding = Encoding.Default;
                else
                {
                    try
                    {
                        cmdEncoding = Encoding.GetEncoding(encoding);
                    }
                    catch
                    {
                        cmdEncoding = Encoding.Default;
                    }
                }
                this.CommandEncoding = cmdEncoding;

                this.Connect();
                this.SetTransferType(UtilFTPTransferType.BINARY);
            }
            catch (Exception ex)
            {
                if (this.IsConnected)
                {
                    this.Close();
                }

                throw ex;
            }
            finally
            {
            }
        }

        public void Disconnect()
        {
            if (this.IsConnected)
            {
                this.Close();
            }
        }

        public void SetTransferType(UtilFTPTransferType type)
        {
            if (type == UtilFTPTransferType.ASCII)
            {
                this.TransferType = FTPTransferType.ASCII;
            }

            if (type == UtilFTPTransferType.BINARY)
            {
                this.TransferType = FTPTransferType.BINARY;
            }
        }

        public void FTPUploadFile(string localFile, string remoteFile)
        {
            try
            {
                this.SetTransferType(clsFTP.UtilFTPTransferType.BINARY);
                this.UploadFile(localFile, remoteFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public void FTPDownloadFile(string localFile, string remoteFile)
        {
            log.WriteSingleLog("download " + remoteFile);
            try
            {
                if (remoteFile.IndexOf("GENLSYS.MES.AutoUpdate")>=0 || remoteFile.IndexOf("edtFTPnet")>=0 || remoteFile.IndexOf("Infragistics2")>=0  )
                {
                    log.WriteSingleLog("cancel download " + remoteFile);
                    return;
                }
                this.SetTransferType(clsFTP.UtilFTPTransferType.BINARY);
                this.DownloadFile(localFile, remoteFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public void FTPDeleteFile(string remoteFile)
        {
            try
            {
                this.SetTransferType(clsFTP.UtilFTPTransferType.BINARY);

                this.DeleteFile(remoteFile);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public void FTPDownloadDir (string localFile, string remoteFile)
        {
            try
            {
                //this.SetTransferType(clsFTP.UtilFTPTransferType.BINARY);
                
                this.ftpClient.ChDir(remoteFile);
                //string[]  files =     this.ftpClient.Dir();
                FTPFile[] files=this.ftpClient.DirDetails();
                for (int i = 0; i < files.Length  ; i++)
                {

                    if (files[i].Name == "." || files[i].Name == "..")
                    {
                        continue;
                    }
                    try
                    {
                        this.ftpClient.ChDir(files[i].Name);

                        DirectoryInfo info1 = new DirectoryInfo(localFile + "\\" + files[i].Name);
                        if (!info1.Exists)
                        {
                           info1.Create();
                        }

                        this.ftpClient.CdUp();
                        FTPDownloadDir(localFile + "\\" + files[i].Name, files[i].Name);
                    }
                    catch (Exception ex)
                    {
                        face.setInfo("正在下载：" + files[i].Name);
                        face.setPersent(i);
                        face.Refresh();
                        FTPDownloadFile(localFile + "\\" + files[i].Name, files[i].Name);
                    }

                }
                this.ftpClient.CdUp();
                 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
    }
}

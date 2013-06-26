using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.IO;
using System.Diagnostics;
using System.Threading;
using GENLSYS.MES.Utility;
using System.Windows.Forms;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Utility
{
    /// <summary>
    /// 注册表主键枚举
    /// </summary>
    public enum RootKey : uint
    {
        HKEY_CLASSES_ROOT = 0x80000000,
        HKEY_CURRENT_USER = 0x80000001,
        HKEY_LOCAL_MACHINE = 0x80000002,
        HKEY_USERS = 0x80000003,
        HKEY_CURRENT_CONFIG = 0x80000005
    }

    /// <summary>
    /// 端机信息结构
    /// </summary>
    public struct ServerInfo
    {
        public string ServerID;
        public string ServerSec;
        public string ServerIP;
        public string ServerUser;
        public string ServerPw;
        /// <summary>
        /// 远程推送的目标目录
        /// </summary>
        public string FolderPath;
        /// <summary>
        /// 远程共享名？
        /// </summary>
        public string ShareName;
        /// <summary>
        /// 远程推送的说明
        /// </summary>
        public string Description;
        /// <summary>
        /// 远程推送的文件集合
        /// </summary>
        public string [] strSource;
        /// <summary>
        /// 推送成功后，要设置的注册表自动启动项名称
        /// </summary>
        public string strTarget;
        /// <summary>
        /// 传送类型
        /// </summary>
        public int transType;
        public bool Result;
    }

    /// <summary>
    /// 用于WMI连接的用户信息结构
    /// </summary>
    public struct UserInfo
    {
        public string UserName;
        public string UserPW;
        public bool IsEnable;
    }

    /// <summary>
    /// WMI基本封装
    /// </summary>
    public class UtilWMI
    {
        public static UtilLog Wmilog = new UtilLog(Application.StartupPath + @"\\Log\\Wmi.log");

        /// <summary>
        /// 创建远程目录
        /// </summary>
        /// <param name="scope">ManagementScope Instance</param>
        /// <param name="DirectoryName">要建立的目录名</param>
        /// <param name="CurrentDirectory">根目录所在位置，缺省为C:\</param>
        /// <returns>0表示建立成功，-1表示建立失败</returns>
        public static int CreateRemoteDirectory(ManagementScope scope, string DirectoryName, string CurrentDirectory)
        {
            try
            {
                string currentDirectory = CurrentDirectory;
                if (String.IsNullOrEmpty(CurrentDirectory))
                {
                    currentDirectory = @"C:\";
                }
                ObjectGetOptions objectGetOptions = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);
                ManagementPath managementPath = new ManagementPath("Win32_Process");

                ManagementClass processBatch = new ManagementClass(scope, managementPath, objectGetOptions);
                ManagementBaseObject inParams = processBatch.GetMethodParameters("Create");

                inParams["CommandLine"] = @"cmd /CMd " + DirectoryName;
                inParams["CurrentDirectory"] = currentDirectory;

                ManagementBaseObject outParams = null;
                outParams = processBatch.InvokeMethod("Create", inParams, null);

                Wmilog.LogInfoWithLevel("Excute CreateRemoteDirectory:" + outParams.ToString(), Log_LoggingLevel.Admin);
            }
            catch (Exception ex)
            {
                Wmilog.LogInfoWithLevel("in CreateRemoteDirectory Exception:" + ex.Message, Log_LoggingLevel.Admin);
                return -1;
            }
            Wmilog.LogInfoWithLevel("建远程目录成功!", Log_LoggingLevel.Admin);
            return 0;
        }

        /// <summary>
        /// 在远程目标机器上创建一个注册表主键
        /// </summary>
        /// <param name="connectionScope">ManagementScope</param>
        /// <param name="machineName">目标机器IP</param>
        /// <param name="BaseKey">注册表分支名</param>
        /// <param name="key">主键名称</param>
        /// <returns>创建成功则返回0</returns>
        public static int CreateRemoteKey(ManagementScope connectionScope,
                                  string machineName,
                                  RootKey BaseKey,
                                  string key)
        {
            try
            {
                ObjectGetOptions objectGetOptions = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);
                connectionScope.Path = new ManagementPath(@"\\" + machineName + @"\root\DEFAULT:StdRegProv");
                connectionScope.Connect();
                ManagementClass registryTask = new ManagementClass(connectionScope,
                               new ManagementPath(@"DEFAULT:StdRegProv"), objectGetOptions);
                ManagementBaseObject methodParams = registryTask.GetMethodParameters("CreateKey");

                methodParams["hDefKey"] = BaseKey;
                methodParams["sSubKeyName"] = key;

                ManagementBaseObject exitCode = registryTask.InvokeMethod("CreateKey",
                                                                      methodParams, null);

                Wmilog.LogInfoWithLevel("in CreateRemoteKey:" + exitCode.ToString(), Log_LoggingLevel.Admin);
            }
            catch (ManagementException e)
            {
                Wmilog.LogInfoWithLevel("in CreateRemoteKey(ManagementException):" + e.Message, Log_LoggingLevel.Admin);
                return -1;
            }
            Wmilog.LogInfoWithLevel("注册表主键创建成功！", Log_LoggingLevel.Admin);
            return 0;
        }

        /// <summary>
        /// 在远程目标机器上创建一个注册表键值
        /// </summary>
        /// <param name="connectionScope">ManagementScope</param>
        /// <param name="machineName">目标机器IP</param>
        /// <param name="BaseKey">注册表分支名</param>
        /// <param name="key">主键名称</param>
        /// <param name="valueName">键值名称</param>
        /// <param name="value">键值</param>
        /// <returns>创建成功则返回0</returns>
        public static int CreateRemoteValue(ManagementScope connectionScope,
                                    string machineName,
                                    RootKey BaseKey,
                                    string key,
                                    string valueName,
                                    string value)
        {
            try
            {
                ObjectGetOptions objectGetOptions = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);
                connectionScope.Path = new ManagementPath(@"\\" + machineName + @"\root\DEFAULT:StdRegProv");
                connectionScope.Connect();
                ManagementClass registryTask = new ManagementClass(connectionScope,
                               new ManagementPath(@"DEFAULT:StdRegProv"), objectGetOptions);
                ManagementBaseObject methodParams = registryTask.GetMethodParameters("SetStringValue");

                methodParams["hDefKey"] = BaseKey;
                methodParams["sSubKeyName"] = key;
                methodParams["sValue"] = value;
                methodParams["sValueName"] = valueName;

                ManagementBaseObject exitCode = registryTask.InvokeMethod("SetStringValue",
                                                                         methodParams, null);

                Wmilog.LogInfoWithLevel("in CreateRemoteValue:" + exitCode.ToString(), Log_LoggingLevel.Admin);
            }
            catch (ManagementException e)
            {
                Wmilog.LogInfoWithLevel("in CreateRemoteValue(ManagementException):" + e.Message, Log_LoggingLevel.Admin);
                return -1;
            }
            Wmilog.LogInfoWithLevel("注册表键值写入成功！", Log_LoggingLevel.Admin);
            return 0;
        }

        /// <summary>
        /// 执行远程文件/目录推送
        /// </summary>
        /// <param name="Server">目标地址</param>
        /// <param name="Username">目标设备登录用户</param>
        /// <param name="Password">目标设备登录PWD</param>
        /// <param name="FolderPath">远程目标目录</param>
        /// <param name="ShareName">网络共享名</param>
        /// <param name="Description">网络共享描述</param>
        /// <param name="reginfo">推送成功后，可以设置的注册表项名称</param>
        /// <param name="strSources">要推送的源文件信息</param>
        /// <param name="iType">推送类型;0表示推送文件，1表示推送目录</param>
        /// <returns>推送成功则返回true</returns>
        public static bool WmiFileCopyToRemote(string Server,
                      string Username,
                      string Password,
                      string FolderPath,
                      string ShareName,
                      string Description,
                      string reginfo,
                      string[] strSources,
                      int iType
                     )
        {
            #region 远程共享目录组合

            //远程共享名
            StringBuilder TargetDir = new StringBuilder();
            TargetDir.Append(@"\\");
            TargetDir.Append(Server);
            TargetDir.Append("\\");
            TargetDir.Append(ShareName);
            TargetDir.Append("\\");

            #endregion

            #region 注册表值组合

            StringBuilder KeyValue = new StringBuilder();
            KeyValue.Append(FolderPath);
            KeyValue.Append("\\");

            #endregion

            #region WMI连接设置

            ConnectionOptions options = new ConnectionOptions();
            options.Username = Username;
            options.Password = Password;

            //options.Authority = "ntdlmdomain:DOMAIN";
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.EnablePrivileges = true;
            //options.Authentication = AuthenticationLevel.Connect;
            //options.Authority
            ManagementScope scope = new ManagementScope(
                    "\\\\" + Server + "\\root\\cimv2",
                    options);
            #endregion

            try
            {
                Wmilog.LogInfoWithLevel("开始WMI连接...... ", Log_LoggingLevel.Admin);
                scope.Connect();
                if (scope.IsConnected)
                {
                    Wmilog.LogInfoWithLevel("WMI连接成功......", Log_LoggingLevel.Admin);

                    Wmilog.LogInfoWithLevel("建远程目录开始......", Log_LoggingLevel.Admin);
                    CreateRemoteDirectory(scope, FolderPath, "");
                    Wmilog.LogInfoWithLevel("建远程目录结束......", Log_LoggingLevel.Admin);

                    Wmilog.LogInfoWithLevel("建远程共享目录开始......", Log_LoggingLevel.Admin);
                    CreateShareNetFolder(scope, FolderPath, ShareName, Description);
                    Wmilog.LogInfoWithLevel("建远程共享目录结束......", Log_LoggingLevel.Admin);

                    Wmilog.LogInfoWithLevel("连接远程共享开始......", Log_LoggingLevel.Admin);
                    CreateShareNetConnect(Server, ShareName, Username, Password);
                    Wmilog.LogInfoWithLevel("连接远程共享结束......", Log_LoggingLevel.Admin);

                    //通过远程共享名，向远程共享目录中拷贝文件
                    if (iType == 0)
                    {
                        //文件拷贝
                        Wmilog.LogInfoWithLevel("in CopyFiles:" + "Start".ToString(), Log_LoggingLevel.Admin);
                        System.Diagnostics.Debug.WriteLine("in CopyFiles:" + "Start".ToString());
                        foreach (string filename in strSources)
                        {
                            if (!String.IsNullOrEmpty(filename))
                            {
                                FileInfo fileinfo = new FileInfo(filename);
                                File.Copy(filename, TargetDir + fileinfo.Name, true);
                                System.Diagnostics.Debug.WriteLine(filename + " " + TargetDir + fileinfo.Name);

                            }
                        }
                        KeyValue.Append(reginfo);
                        Wmilog.LogInfoWithLevel("in CopyFiles:" + "End".ToString(), Log_LoggingLevel.Admin);
                        System.Diagnostics.Debug.WriteLine("in CopyFiles:" + "End".ToString());
                    }
                    else if (iType == 1)
                    {
                        //目录拷贝
                        DirectoryInfo DirInfo = new DirectoryInfo(strSources[0]);
                        KeyValue.Append(DirInfo.Name);
                        KeyValue.Append("\\");
                        KeyValue.Append(reginfo);
                        Wmilog.LogInfoWithLevel("in CopyDirectory:" + "Start".ToString(), Log_LoggingLevel.Admin);
                        System.Diagnostics.Debug.WriteLine("in CopyDirectory:" + "Start".ToString());
                        CopyDirectory(strSources[0], TargetDir + DirInfo.Name);
                        Wmilog.LogInfoWithLevel("in CopyDirectory:" + "End".ToString(), Log_LoggingLevel.Admin);
                        System.Diagnostics.Debug.WriteLine("in CopyDirectory:" + "End".ToString());
                    }

                    Wmilog.LogInfoWithLevel("断开远程共享开始", Log_LoggingLevel.Admin);
                    RemoveShareNetConnect(Server, ShareName, Username, Password);
                    Wmilog.LogInfoWithLevel("断开远程共享结束", Log_LoggingLevel.Admin);

                    Wmilog.LogInfoWithLevel("删除远程共享目录开始", Log_LoggingLevel.Admin);
                    RemoveShareNetFolder(scope, ShareName);
                    Wmilog.LogInfoWithLevel("删除远程共享目录结束", Log_LoggingLevel.Admin);

                    if (!String.IsNullOrEmpty(reginfo))
                    {
                        Wmilog.LogInfoWithLevel("查找或建立注册表主键开始", Log_LoggingLevel.Admin);
                        CreateRemoteKey(scope, Server, RootKey.HKEY_LOCAL_MACHINE, @"Software\Microsoft\Windows\CurrentVersion\Run");
                        Wmilog.LogInfoWithLevel("查找或建立注册表主键结束", Log_LoggingLevel.Admin);

                        Wmilog.LogInfoWithLevel("设置注册表值开始", Log_LoggingLevel.Admin);
                        CreateRemoteValue(scope, Server, RootKey.HKEY_LOCAL_MACHINE, @"Software\Microsoft\Windows\CurrentVersion\Run", reginfo, KeyValue.ToString());
                        Wmilog.LogInfoWithLevel("设置注册表值结", Log_LoggingLevel.Admin);
                    }
                }
            }
            catch (Exception e)
            {
                Wmilog.LogInfoWithLevel("WMI连接失败(Exception): " + e.Message, Log_LoggingLevel.Admin);
                System.Diagnostics.Debug.WriteLine("in WmiFileCopyToRemote Exception:" + e.Message);
                return false;
            }
            Wmilog.LogInfoWithLevel("WMI操作成功结束 ", Log_LoggingLevel.Admin);

            return true;
        }

        /// <summary>
        /// 执行远程文件/目录推送
        /// </summary>
        /// <param name="Server">目标地址</param>
        /// <param name="Username">目标设备登录用户</param>
        /// <param name="Password">目标设备登录PWD</param>
        /// <param name="FolderPath">远程目标目录</param>
        /// <param name="ShareName">网络共享名</param>
        /// <param name="Description">网络共享描述</param>
        /// <param name="reginfo">推送成功后，可以设置的注册表项名称</param>
        /// <param name="strSources">要推送的源文件信息</param>
        /// <param name="iType">推送类型;0表示推送文件，1表示推送目录</param>
        /// <returns>推送成功则返回true</returns>
        public static bool WmiFileCopyToRemote(string Server,
                      string Username,
                      string Password,
                      string ShareName,
                      string[] strSources,
                      int iType
                     )
        {
            #region 远程共享目录组合

            //远程共享名
            StringBuilder TargetDir = new StringBuilder();
            TargetDir.Append(@"\\");
            TargetDir.Append(Server);
            TargetDir.Append("\\");
            TargetDir.Append(ShareName);
            TargetDir.Append("\\");

            #endregion

            #region WMI连接设置

            ConnectionOptions options = new ConnectionOptions();
            options.Username = Username;
            options.Password = Password;

            //options.Authority = "ntdlmdomain:DOMAIN";
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.EnablePrivileges = true;
            //options.Authentication = AuthenticationLevel.Connect;
            //options.Authority
            ManagementScope scope = new ManagementScope(
                    "\\\\" + Server + "\\root\\cimv2",
                    options);
            #endregion

            try
            {
                scope.Connect();
                if (scope.IsConnected)
                {
                    CreateShareNetConnect(Server, ShareName, Username, Password);

                    //通过远程共享名，向远程共享目录中拷贝文件
                    if (iType == 0)
                    {
                        //文件拷贝
                        foreach (string filename in strSources)
                        {
                            if (!String.IsNullOrEmpty(filename))
                            {
                                FileInfo fileinfo = new FileInfo(filename);
                                File.Copy(filename, TargetDir + fileinfo.Name, true);
                                System.Diagnostics.Debug.WriteLine(filename + " " + TargetDir + fileinfo.Name);

                            }
                        }
                    }
                    else if (iType == 1)
                    {
                        //目录拷贝
                        DirectoryInfo DirInfo = new DirectoryInfo(strSources[0]);
                        CopyDirectory(strSources[0], TargetDir + DirInfo.Name);
                    }

                    RemoveShareNetConnect(Server, ShareName, Username, Password);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 创建远程共享目录
        /// </summary>
        /// <param name="scope">ManagementScope</param>
        /// <param name="FolderPath">要共享的目录路径</param>
        /// <param name="ShareName">共享名</param>
        /// <param name="Description">网络共享文件夹的描述</param>
        /// <returns>0表示创建成功，-1表示创建失败</returns>
        public static int CreateShareNetFolder(ManagementScope scope, string FolderPath, string ShareName, string Description)
        {
            try
            {
                //创建一个ManagementClass对像
                ManagementClass managementClass = new ManagementClass(scope, new ManagementPath("Win32_Share"), null);

                //创建ManagementBaseObject的输入和输出参数
                ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");
                ManagementBaseObject outParams;

                //设置输入参数
                inParams["Description"] = Description;
                inParams["Name"] = ShareName;
                inParams["Path"] = FolderPath;
                inParams["Type"] = 0x0;//DISK_DRIVE

                //其它类型
                //DISK_DRIVE=0x0
                //PRINT_QUEUE=0x1
                //DEVICE = 0x2
                //IPC = 0x3
                //DISK_DRIVE_ADMIN = 0x80000000
                //PRINT_QUEUE_ADMIN=0x80000001
                //DEVICE_ADMIN=0x80000002
                //IPC_ADMIN=0x80000003
                //inParams["MaximunAllowed"] = intMaxConnectionsNum;

                //调用方法ManagementClass对像
                outParams = managementClass.InvokeMethod("Create", inParams, null);

                Wmilog.LogInfoWithLevel("Excute ShareNetFolder Result:" + outParams.ToString(), Log_LoggingLevel.Admin);
                //检测方法是否调用成功
                if ((uint)(outParams.Properties["RetrunValue"].Value) != 0)
                {
                    throw new Exception("Unable to create net share directiory!");
                }
            }
            catch (Exception ex)
            {
                Wmilog.LogInfoWithLevel("创建远程共享目录失败:" + ex.Message, Log_LoggingLevel.Admin);
                return -1;
            }
            Wmilog.LogInfoWithLevel("创建远程共享目录成功！", Log_LoggingLevel.Admin);
            return 0;
        }

        /// <summary>
        /// 移除远程共享目录
        /// </summary>
        /// <param name="scope">ManagementScope</param>
        /// <param name="ShareName">共享名</param>
        /// <returns>移除成功则返回0</returns>
        public static int RemoveShareNetFolder(ManagementScope scope, string ShareName)
        {
            try
            {
                //SelectQuery selectQuery = new SelectQuery("Select * from Win32_Share Where Name = '" + ShareName + "'");
                ObjectQuery selectQuery = new ObjectQuery("Select * from Win32_Share Where Name = '" + ShareName + "'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, selectQuery);
                foreach (ManagementObject mo in searcher.Get())
                {
                    mo.InvokeMethod("Delete", null, null);
                }
                System.Diagnostics.Debug.WriteLine("in CancelShareNetFolder:" + ShareName);
            }
            catch (ManagementException me)
            {
                Wmilog.LogInfoWithLevel("移除远程共享目录失败(ManagementException):" + me.Message, Log_LoggingLevel.Admin);
                return -1;
            }
            catch (Exception e)
            {
                Wmilog.LogInfoWithLevel("移除远程共享目录失败(Exception):" + e.Message, Log_LoggingLevel.Admin);
                return -1;
            }

            Wmilog.LogInfoWithLevel("移除远程共享目录成功！", Log_LoggingLevel.Admin);
            return 0;
        }

        /// <summary>
        /// 使用net use命令远程连接目标机器，拷贝文件
        /// </summary>
        /// <param name="strSource">源文件</param>
        /// <param name="strTarget">目标文件</param>
        /// <param name="Server">目标ip</param>
        /// <param name="ShareName">远程共享名</param>
        /// <param name="Username">远程登录用户</param>
        /// <param name="Password">远程登录密码</param>
        /// <returns>拷贝成功则返回0</returns>
        public static int FileCopy(string strSource, string strTarget, string Server, string ShareName, string Username, string Password)
        {
            Process process = new Process();
            try
            {

                process.StartInfo.FileName = "net.exe";
                process.StartInfo.Arguments = @"use \\" + Server + @"\" + ShareName + " \"" + Password + "\" /user:\"" + Username + "\" ";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                System.Diagnostics.Debug.WriteLine(process.StartInfo.FileName + " " + process.StartInfo.Arguments);
                process.WaitForExit();
                System.Diagnostics.Debug.WriteLine("Start Copy File.....");
                File.Copy(strSource, strTarget, true);
                System.Diagnostics.Debug.WriteLine("End Copy File.....");
                process.StartInfo.Arguments = @"use \\" + Server + @"\" + ShareName + " /delete";
                process.Start();
                process.Close();
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.WriteLine("in FileCopy IOException:" + ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("in FileCopy Exception:" + ex.Message);
                return -1;
            }
            finally
            {
                process.Dispose();
            }
            return 0;
        }

        /// <summary>
        /// 使用net use命令远程连接目标机器，拷贝文件 (用当前登录的用户)
        /// </summary>
        /// <param name="strSource">源文件</param>
        /// <param name="strTarget">目标文件</param>
        /// <param name="Server">目标ip</param>
        /// <param name="ShareName">远程共享名</param>
        /// <returns>拷贝成功则返回0</returns>
        public static int FileCopy(string strSource, string strTarget, string Server, string ShareName)
        {
            Process process = new Process();
            try
            {

                process.StartInfo.FileName = "net.exe";
                process.StartInfo.Arguments = @"use \\" + Server + @"\" + ShareName ;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                System.Diagnostics.Debug.WriteLine(process.StartInfo.FileName + " " + process.StartInfo.Arguments);
                process.WaitForExit();
                System.Diagnostics.Debug.WriteLine("Start Copy File.....");
                File.Copy(strSource, strTarget, true);
                System.Diagnostics.Debug.WriteLine("End Copy File.....");
                process.StartInfo.Arguments = @"use \\" + Server + @"\" + ShareName + " /delete";
                process.Start();
                process.Close();
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.WriteLine("in FileCopy IOException:" + ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("in FileCopy Exception:" + ex.Message);
                return -1;
            }
            finally
            {
                process.Dispose();
            }
            return 0;
        }

        /// <summary>
        /// 使用net use命令远程连接目标机器，拷贝文件 (用当前登录的用户)到本地目录
        /// </summary>
        /// <param name="fileName">远程源文件名</param>
        /// <param name="strTarget">目标文件</param>
        /// <param name="Server">远程机器IP</param>
        /// <param name="ShareName">远程共享名</param>
        /// <returns>拷贝成功则返回0</returns>  //File.Copy("\\机器B\文件路径\文件名称","机器A存放文件完整路径",true);

        public static int FileCopyToLocal(string fileName, string strTarget, string Server, string ShareName)
        {
            Process process = new Process();
            try
            {

                process.StartInfo.FileName = "net.exe";
                process.StartInfo.Arguments = @"use \\" + Server + @"\" + ShareName;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                System.Diagnostics.Debug.WriteLine(process.StartInfo.FileName + " " + process.StartInfo.Arguments);
                process.WaitForExit();
                System.Diagnostics.Debug.WriteLine("Start Copy File.....");
                File.Copy(@"\\"+Server +  @"\"+ ShareName + @"\" + fileName, strTarget, true);
                System.Diagnostics.Debug.WriteLine("End Copy File.....");
                process.StartInfo.Arguments = @"use \\" + Server + @"\" + ShareName + " /delete";
                process.Start();
                process.Close();
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.WriteLine("in FileCopy IOException:" + ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("in FileCopy Exception:" + ex.Message);
                return -1;
            }
            finally
            {
                process.Dispose();
            }
            return 0;
        }

        public static int FileCopyToRemote(string fileName, string strOrg, string Server, string remoteFile, string ShareName)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = "net.exe";
                process.StartInfo.Arguments = @"use \\" + Server + @"\" + ShareName;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();
                File.Copy(fileName, @"\\" + Server + @"\" + remoteFile, true);
                process.StartInfo.Arguments = @"use \\" + Server + @"\" + ShareName + " /delete";
                process.Start();
                process.Close();
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.WriteLine("in FileCopy IOException:" + ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("in FileCopy Exception:" + ex.Message);
                return -1;
            }
            finally
            {
                process.Dispose();
            }
            return 0;
        }


        /// <summary>
        /// 通过远程共享名，递归拷贝指定目录下的所有信息到目标目录
        /// </summary>
        /// <param name="sPath">源目录</param>
        /// <param name="dPath">目的目录</param>
        public static void CopyDirectory(string sPath, string dPath)
        {
            string[] directories = System.IO.Directory.GetDirectories(sPath);
            if (!System.IO.Directory.Exists(dPath))
                System.IO.Directory.CreateDirectory(dPath);
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(sPath);
            System.IO.DirectoryInfo[] dirs = dir.GetDirectories();
            CopyFile(dir, dPath);

            if (dirs.Length > 0)
            {
                foreach (System.IO.DirectoryInfo temDirectoryInfo in dirs)
                {
                    string sourceDirectoryFullName = temDirectoryInfo.FullName;
                    string destDirectoryFullName = sourceDirectoryFullName.Replace(sPath, dPath);
                    if (!System.IO.Directory.Exists(destDirectoryFullName))
                    {
                        System.IO.Directory.CreateDirectory(destDirectoryFullName);
                    }
                    CopyFile(temDirectoryInfo, destDirectoryFullName);
                    CopyDirectory(sourceDirectoryFullName, destDirectoryFullName);
                }
            }
        }

        /// <summary>
        /// 通过远程共享名，拷贝指定目录下的所有文件到目标目录
        /// </summary>
        /// <param name="path">源路径</param>
        /// <param name="desPath">目的路径（\\targetServer\\shareName\\DirectoryPath）</param>
        public static void CopyFile(System.IO.DirectoryInfo path, string desPath)
        {
            string sourcePath = path.FullName;
            System.IO.FileInfo[] files = path.GetFiles();
            foreach (System.IO.FileInfo file in files)
            {
                string sourceFileFullName = file.FullName;
                string destFileFullName = sourceFileFullName.Replace(sourcePath, desPath);
                file.CopyTo(destFileFullName, true);
            }
        }

        public static void CopySingleFile(string fileName, string desPath)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            string sourcePath = fileInfo.Directory.FullName;
            if (fileInfo.Exists)
            {
                string sourceFileFullName = fileInfo.FullName;
                string destFileFullName = sourceFileFullName.Replace(sourcePath, desPath);
                fileInfo.CopyTo(destFileFullName, true);
            }
        }

        /// <summary>
        /// 用net use命令连接到远程共享目录上，创建网络共享连接
        /// </summary>
        /// <param name="Server">目标ip</param>
        /// <param name="ShareName">远程共享名</param>
        /// <param name="Username">远程登录用户</param>
        /// <param name="Password">远程登录密码</param>
        public static void CreateShareNetConnect(string Server, string ShareName, string Username, string Password)
        {
            Process process = new Process();
            process.StartInfo.FileName = "net.exe";
            process.StartInfo.Arguments = @"use \\" + Server + @"\" + ShareName + " \"" + Password + "\" /user:\"" + Username + "\" ";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();
            process.Close();
            process.Dispose();
        }

        /// <summary>
        /// 用net use delete命令移除网络共享连接
        /// </summary>
        /// <param name="Server">目标ip</param>
        /// <param name="ShareName">远程共享名</param>
        /// <param name="Username">远程登录用户</param>
        /// <param name="Password">远程登录密码</param>
        public static void RemoveShareNetConnect(string Server, string ShareName, string Username, string Password)
        {
            //System.Diagnostics.Process.Start("net.exe", @"use \\" + Server + @"\" + ShareName + " \"" + Password + "\" /user:\"" + Username + "\" ");
            Process process = new Process();
            process.StartInfo.FileName = "net.exe";
            process.StartInfo.Arguments = @"use \\" + Server + @"\" + ShareName + " /delete";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();
            process.Close();
            process.Dispose();

        }

        /// <summary>
        /// 得到远程文件列表
        /// </summary>
        /// <param name="scope">ManagementScope Instance</param>
        /// <param name="DirectoryName">远程目录名</param>
        /// <param name="CurrentDirectory">文件名通配符</param>

        public static  string[] GetFileList(string fileNameLike,   string Server, string ShareName)
        {
            List<string> fileList = new List<string>();
            Process process = new Process();
            try
            {

                process.StartInfo.FileName = "net.exe";
                process.StartInfo.Arguments = @"use \\" + Server + @"\" + ShareName;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                System.Diagnostics.Debug.WriteLine(process.StartInfo.FileName + " " + process.StartInfo.Arguments);
                process.WaitForExit();
                System.Diagnostics.Debug.WriteLine("Start get file list.....");
                string[] files = Directory.GetFiles( @"\\" + Server + @"\" + ShareName + @"\" , fileNameLike );
                process.Start();
                process.Close();
                return files;
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.WriteLine("in FileCopy IOException:" + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("in FileCopy Exception:" + ex.Message);
                return null;
            }
            finally
            {
                process.Dispose();
            }

           
 
           /* try
            {
                scope.Connect();
                if (scope.IsConnected)
                {
                    CreateShareNetConnect(Server, ShareName, Username, Password);

                    ObjectGetOptions objectGetOptions = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);
                    ManagementPath managementPath = new ManagementPath("Win32_Process");
                    ManagementClass processBatch = new ManagementClass(scope, managementPath, objectGetOptions);
                    ManagementBaseObject inParams = processBatch.GetMethodParameters("Create");
                    inParams["CommandLine"] = @"cmd /CMd " + DirectoryName;
                    ManagementBaseObject outParams = null;
                    outParams = processBatch.InvokeMethod("Create", inParams, null);

                    string myQuery = "Select * from CIM_DataFile Where NAME like = '" + fileNameLike + "'";
                    scope.Connect();
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, new ObjectQuery(myQuery));
                    ManagementObjectCollection myResults = searcher.Get();
                    foreach (ManagementObject oReturn in myResults)
                    {
                        fileList.Add(oReturn["Name"].ToString());

                    }

                    Wmilog.LogInfoWithLevel("Get File List(like:" + fileNameLike + "):" + outParams.ToString(), Log_LoggingLevel.Admin);
                    //obj.Properties["LastModified"].Value.ToString().Substring(0, 14);
                }
            }
            catch (Exception ex)
            {
                Wmilog.LogInfoWithLevel("in CreateRemoteDirectory Exception:" + ex.Message, Log_LoggingLevel.Admin);
                return null;
            }
            Wmilog.LogInfoWithLevel("获得远程文件列表成功，得到" + fileList.Count+"个文件", Log_LoggingLevel.Admin);*/
         }


        }

    }


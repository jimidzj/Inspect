using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

 namespace GENLSYS.MES.AutoUpdate
{
   
        public class LogBlock
        {
            public string LogBlockId { get; set; }
            public List<string> LogEntry { get; set; }
            public bool CanWrite { get; set; }
        }

        public class clsLog
        {
            string logDirectory = string.Empty;
            clsConfig config = null;

            public clsLog(clsConfig _config)
            {
                config = _config;
                InitLogDirectory();
            }

            private void InitLogDirectory()
            {
                clsConfig config = new clsConfig();
                logDirectory = config.GetConfigValue(clsConfig.ConfigItem.LogFilePath);
                if (logDirectory == string.Empty)
                    logDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                else
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(logDirectory);
                    if (!dirInfo.Exists)
                    {
                        //logDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                        dirInfo.Create();
                    }
                    dirInfo = null;
                }
            }

            public void WriteLogToBlock(string blockId, string logContext)
            {
                if (blockId.Trim() == string.Empty)
                {
                    WriteSingleLog(logContext);
                    return;
                }

                bool isNew = true;
                for (int i = 0; i < clsCommon.LOGPOOL.Count; i++)
                {
                    if (clsCommon.LOGPOOL[i].LogBlockId == blockId)
                    {
                        isNew = false;
                        clsCommon.LOGPOOL[i].LogEntry.Add(logContext);
                    }
                }

                if (isNew)
                {
                    LogBlock block = new LogBlock();
                    block.LogBlockId = blockId;
                    block.LogEntry = new List<string>();
                    block.LogEntry.Add(logContext);
                    block.CanWrite = false;
                    clsCommon.LOGPOOL.Add(block);
                }
            }

            public void CompleteLog(string blockId)
            {
                for (int i = 0; i < clsCommon.LOGPOOL.Count; i++)
                {
                    if (clsCommon.LOGPOOL[i].LogBlockId == blockId)
                    {
                        clsCommon.LOGPOOL[i].CanWrite = true;
                    }
                }
            }

            public void WriteSingleLog(string logContext)
            {
                StreamWriter sw = null;
                bool fileUnexists = false;
                try
                {
                    string logFileName = logDirectory + "\\" + "Log_"  + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                    FileInfo fi = new FileInfo(logFileName);
                    FileStream fs = null;
                    if (!fi.Exists)
                    {
                        DirectoryInfo di = new DirectoryInfo(logDirectory);
                        if (!di.Exists)
                            di.Create();

                        fs = fi.Create();
                        fs.Close();

                        fileUnexists = true;
                    }
                    sw = new StreamWriter(logFileName, true, Encoding.Default);

                    if (fileUnexists)
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "    " + "Log file created.");
                    }
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "    " + logContext);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }

            public void DeleteExpiredLog()
            {
                try
                {
                    int iLogKeepDays = 0;
                    string logKeepDays = config.GetConfigValue(clsConfig.ConfigItem.LogFileKeepDays);
                    if (logKeepDays == string.Empty)
                        iLogKeepDays = 14;
                    else
                    {
                        try
                        {
                            iLogKeepDays = int.Parse(logKeepDays);
                        }
                        catch
                        {
                            iLogKeepDays = 14;
                        }
                    }

                    //WriteSingleLog("Log file keep day=> " + iLogKeepDays.ToString());

                    DirectoryInfo dir = new DirectoryInfo(logDirectory);
                    FileInfo[] files = dir.GetFiles();
                    foreach (FileInfo fi in files)
                    {
                        if ((DateTime.Now - fi.CreationTime).Days > iLogKeepDays)
                        {
                            WriteSingleLog("Log file[" + fi.FullName + " deleted ok.]");
                            fi.Delete();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

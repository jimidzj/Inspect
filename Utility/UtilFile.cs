using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace GENLSYS.MES.Utility
{
    public class UtilFile
    {
        /// <summary>
        /// Gets the json from file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-7-10 13:06
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static List<Dictionary<string, string>> GetJsonFromFile(string path, string fileName)
        {
            StreamReader reader = null;
            try
            {
                string filePath = path;

                if (filePath == null || filePath.Equals(string.Empty))
                {
                    filePath = AppDomain.CurrentDomain.BaseDirectory + @"\Log\";
                }

                reader = new StreamReader(filePath + @"\" + fileName);
                string line = reader.ReadToEnd();
                int start = line.IndexOf("[{");
                if (start == -1)
                {
                    start = 0;
                }
                line = line.Substring(start);

                return JavaScriptConvert.DeserializeObject<List<Dictionary<string, string>>>(line);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        /// <Remarks>
        /// Created Time: 2008-7-10 13:19
        /// Created By: jack_que
        /// Last Modified Time:  
        /// Last Modified By: 
        /// </Remarks>
        public static List<Dictionary<string, string>> GetFiles(string path)
        {
            StreamReader reader = null;
            try
            {
                string filePath = path;

                if (filePath == null || filePath.Equals(string.Empty))
                {
                    filePath = AppDomain.CurrentDomain.BaseDirectory + @"\Log\";
                }
                List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
                string[] fileNames = Directory.GetFiles(filePath);
                for (int i = 0; i < fileNames.Length; i++)
                {
                    if (fileNames[i].EndsWith(".trc"))
                    {
                        reader = new StreamReader(fileNames[i]);
                        string line = reader.ReadLine();
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        int lastIndex = fileNames[i].LastIndexOf('\\');
                        string fileName = fileNames[i];
                        if (lastIndex != -1)
                        {
                            fileName = fileName.Substring(lastIndex + 1, fileName.Length - lastIndex - 1);
                        }
                        dic.Add("fileName", fileName);
                        dic.Add("description", line);
                        list.Add(dic);
                    }
                }
                return list;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public static void WriteFile(string strContent, string strFile)
        {
            FileInfo finFile = new FileInfo(strFile);

            FileStream fsStream = null;

            try
            {
                if (!finFile.Exists)
                {
                    fsStream = finFile.Create();
                }
                else
                {
                    fsStream = finFile.OpenWrite();
                }

                byte[] bys = Encoding.Default.GetBytes(strContent.ToCharArray());

                fsStream.Write(bys, 0, bys.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fsStream != null)
                {
                    fsStream.Close();
                }
            }
        }
    }
}

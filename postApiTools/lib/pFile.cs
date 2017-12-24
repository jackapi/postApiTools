using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// by:(chenran)apiziliao@gmail.com
/// </summary>
namespace postApiTools.lib
{
    public class pFile
    {
        /// <summary>
        /// 创建一个文件进行写入操作
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public static void Write(string path, string content, string encoding = "utf-8")
        {
            StreamWriter sw1 = new StreamWriter(path, false, Encoding.GetEncoding(encoding));
            sw1.WriteLine(content);
            sw1.Close();
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Read(string path, string encoding = "utf-8")
        {
            try
            {
                return File.ReadAllText(path, Encoding.GetEncoding(encoding));
            }
            catch (Exception ex) {
                return ex.ToString();
            }

        }
    }
}

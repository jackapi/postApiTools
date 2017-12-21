using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools
{
    public class pLogs
    {
        /// <summary>
        /// 日志输出功能
        /// </summary>
        /// <param name="logs"></param>
        public static void logs(string logs)
        {
            try
            {
                using (StreamWriter w = File.AppendText(Config.exePath + "/" + DateTime.Now.ToLongDateString().ToString() + " - log.txt"))
                {
                    w.Write(DateTime.Now.ToLocalTime().ToString() + "\r\n" + logs + "\r\n\r\n\r\n");
                    w.Close();
                }
            }
            catch { }


        }
    }
}

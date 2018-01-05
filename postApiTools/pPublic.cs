using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools
{
    public class pPublic
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public static string error = "";

        /// <summary>
        /// 获取配置中超时
        /// </summary>
        /// <returns></returns>
        public static int readTimeOut()
        {
            string timeout = lib.pIni.read("http", "http-time-out");
            if (timeout == "")
            {
                lib.pIni.write("http", "http-time-out", (1000 * 60).ToString());
                return 1000 * 60;
            }
            return Int32.Parse(timeout);
        }

        /// <summary>
        /// 写入超时时间
        /// </summary>
        /// <param name="timeOut"></param>
        public static bool writeTimeOut(int timeOut)
        {
            if (timeOut > 0)
            {
                error = "超时不能为负数";
                return false;
            }
            lib.pIni.write("http", "http-time-out", timeOut.ToString());
            return true;
        }
    }
}

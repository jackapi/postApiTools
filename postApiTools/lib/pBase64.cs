using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    public class pBase64
    {
        /// <summary>
        /// 字符串转base64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string stringToBase64(string str)
        {
            try
            {
                byte[] bytes = Encoding.Default.GetBytes(str);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
                return "";
            }
        }
        /// <summary>
        /// base64转字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string base64ToString(string str)
        {
            try
            {
                byte[] outputb = Convert.FromBase64String(str);
                return Encoding.Default.GetString(outputb);
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
                return str;

            }

        }
    }
}

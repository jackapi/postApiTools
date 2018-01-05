using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    public class pRegex
    {
        /// <summary>
        /// 验证ip是否正确
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static bool isIp(string ipAddress)
        {
            Regex validipregex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
            return (ipAddress != "" && validipregex.IsMatch(ipAddress.Trim())) ? true : false;
        }

        /// <summary>
        /// 验证URL是否正确
        /// </summary>
        /// <param name="str_url"></param>
        /// <returns></returns>
        public static bool IsUrl(string str_url)
        {
            bool f = System.Text.RegularExpressions.Regex.IsMatch(str_url, @"((http|ftp|https)://)(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,4})*(/[a-zA-Z0-9\&%_\./-~-]*)?");
            return f;
        }
    }
}

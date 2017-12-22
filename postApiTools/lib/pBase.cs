using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    public class pBase
    {
        /// <summary>
        /// 枚举获取值
        /// Convert.ToInt32(Enum.Parse(typeof(pHttpCode.HttpStatusCode), response.StatusCode.ToString()));
        /// </summary>
        /// <param name="t"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int enumToValueInt(Type t,string key) {
            int code = Convert.ToInt32(Enum.Parse(t, key));//获取异常状态码
            return code;
        }
        /// <summary>
        /// 字符串转md5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CreateMD5Hash(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
                // To force the hex string to lower-case letters instead of
                // upper-case, use he following line instead:
                // sb.Append(hashBytes[i].ToString("x2")); 
            }
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    using System.IO;
    public class pBase
    {

        /// <summary>
        /// 字典转二维
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string[,] dicToStringArray(Dictionary<string, string> d)
        {
            int i = 0;
            string[,] temp = new string[d.Count, 2];
            if (d.Count <= 0)
            {
                return temp;
            }
            foreach (var item in d)
            {
                temp[i, 0] = item.Key;
                temp[i, 1] = item.Value;
                i++;
            }
            return temp;
        }

        /// <summary>
        /// 打开浏览器
        /// </summary>
        /// <param name="url"></param>
        public static void openWeb(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
        /// <summary>
        /// gethash
        /// </summary>
        /// <returns></returns>
        public static string getHash()
        {
            Random r = new Random();
            return lib.pBase.CreateMD5Hash(lib.pDate.getTimeStamp().ToString() + r.Next(10000, 99999).ToString());
        }
        /// <summary>
        /// 获取参数类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string dataGridViewHttpDataValueToTypeListName(string str)
        {
            if (File.Exists(str))
            {
                return "文件";
            }
            return "字符串";
        }
        /// <summary>
        /// 判断判断是否为字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool isNumber(object obj)
        {
            try
            {
                int number = Int32.Parse(obj.ToString());
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 枚举获取值
        /// Convert.ToInt32(Enum.Parse(typeof(pHttpCode.HttpStatusCode), response.StatusCode.ToString()));
        /// </summary>
        /// <param name="t"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int enumToValueInt(Type t, string key)
        {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    public class pJson
    {
        /// <summary>
        /// 格式化json
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string jsonStrToFormat(string str)
        {
            try
            {
                JObject job = (JObject)JsonConvert.DeserializeObject(str);
                return job.ToString();
            }
            catch (Exception ex) { return ex.ToString(); }

        }
        /// <summary>
        /// object 转成字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string objectToJsonStr(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 字符串转object数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public static object[,] jsonStrToObjectArray(string str, int line = 3)
        {
            object[,] obj = null;
            JArray jarray = (JArray)JsonConvert.DeserializeObject(str);
            obj = new object[jarray.Count, line];
            for (int i = 0; i < jarray.Count; i++)
            {
                for (int q = 0; q < line; q++)
                {
                    obj[i, q] = jarray[i][q];
                }
            }
            return obj;
        }
    }
}

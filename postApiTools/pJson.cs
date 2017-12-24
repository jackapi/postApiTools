using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// by:(chenran)apiziliao@gmail.com
/// </summary>
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
        /// 字符串转list[]
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<string> jsonStrToListString(string json)
        {
            List<string> array = null;
            try
            {
                JArray job = (JArray)JsonConvert.DeserializeObject(json);
                array = new List<string> { };
                for (int i = 0; i < job.Count; i++)
                {
                    array.Add(job[i].ToString());
                }
                return array;
            }
            catch (Exception ex)
            {
                pLogs.logs("string:" + json + ex.ToString());
                return array;
            }
        }

        /// <summary>
        /// 字符串转list[]
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<string> jsonStrToArrayOne(string json)
        {
            List<string> array = null;
            try
            {
                JObject job = (JObject)JsonConvert.DeserializeObject(json);
                array = new List<string> { };
                for (int i = 0; i < job.Count; i++)
                {
                    array.Add(job[i].ToString());
                }
                return array;
            }
            catch (Exception ex)
            {
                pLogs.logs("string:" + json + ex.ToString());
                return array;
            }
        }

        /// <summary>
        /// list 转字符串
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string listToJson(List<string> json)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(json);
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
        /// <summary>
        /// 字符串转object数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string[,] jsonStrToObjectArrayString(string str, int line = 3)
        {
            string[,] obj = null;
            JArray jarray = (JArray)JsonConvert.DeserializeObject(str);
            obj = new string[jarray.Count, line];
            for (int i = 0; i < jarray.Count; i++)
            {
                for (int q = 0; q < line; q++)
                {
                    obj[i, q] = jarray[i][q].ToString();
                }
            }
            return obj;
        }
    }
}

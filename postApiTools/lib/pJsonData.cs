using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    using Newtonsoft;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    public class pJsonData
    {
        /// <summary>
        /// 错误提示
        /// </summary>
        public static string error = "";

        /// <summary>
        /// 字符串转对象
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JObject stringToJobject(string json)
        {
            error = "";
            try
            {
                JObject job = (JObject)JsonConvert.DeserializeObject(json);
                return job;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                pLogs.logs("json:" + json + " " + ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 字符串转array对象
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JArray stringToJArray(string json)
        {
            error = "";
            try
            {
                JArray jar = (JArray)JsonConvert.DeserializeObject(json);
                return jar;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                pLogs.logs("json:" + json + " " + ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 对象转json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string objectToString(object obj)
        {
            error = "";
            try
            {
                string str = JsonConvert.SerializeObject(obj);
                return str;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                pLogs.logs("json:" + obj.ToString() + " " + ex.ToString());
                return null;
            }
        }


    }
}

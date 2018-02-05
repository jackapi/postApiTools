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
        /// 字符串转对象
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JObject stringToJobject(string json)
        {
            try
            {
                JObject job = (JObject)JsonConvert.DeserializeObject(json);
                return job;
            }
            catch (Exception ex)
            {
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
            try
            {
                JArray jar = (JArray)JsonConvert.DeserializeObject(json);
                return jar;
            }
            catch (Exception ex)
            {
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
            try
            {
                string str = JsonConvert.SerializeObject(obj);
                return str;
            }
            catch (Exception ex)
            {
                pLogs.logs("json:" + obj.ToString() + " " + ex.ToString());
                return null;
            }
        }


    }
}

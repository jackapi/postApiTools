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
            catch (Exception ex ) {
                pLogs.logs(ex.ToString());
                return null;
            }
        }
    }
}

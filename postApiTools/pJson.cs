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
    }
}

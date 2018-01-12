using Newtonsoft.Json.Linq;
using postApiTools.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// formall通用类
/// by:chenran (apiziliao@gmail.com)
/// </summary>
namespace postApiTools.FormAll
{
    public class pFormAll
    {
        public static string error = "";
        /// <summary>
        /// 通用请求接口方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static JObject getHttpData(string url, string[,] data)
        {
            error = "";
            if (Config.openServerUpdate != CheckState.Checked.ToString())
            {
                error = "已关闭自动更新";
                return null;
            }
            string json = phttp.HttpUploadFile(url, data);
            if (json.Length <= 0)
            {
                error = "数据请求失败";
                return null;
            }
            JObject job = pJsonData.stringToJobject(json);
            if (job == null)
            {
                error = "服务器异常";
                return null;
            }
            return job;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static JObject login(string name, string password)
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools
{
    public class Config
    {
        /// <summary>
        /// 当前exe路径
        /// </summary>
        public static string exePath = System.Environment.CurrentDirectory;

        /// <summary>
        /// 配置记录存放地方
        /// </summary>
        public static string configIni = exePath + "/config.ini";

        /// <summary>
        /// 下载图片存放地址
        /// </summary>
        public static string downloadImagePath = exePath + "/image/";

        /// <summary>
        /// history存储
        /// </summary>
        public static string historyDataDb = exePath + "/data/database.db";

        /// <summary>
        /// 默认模板
        /// </summary>
        public static string templateTxt = exePath + "/data/template.txt";

        /// <summary>
        /// data目录
        /// </summary>
        public static string dataPath = exePath + "/data/";
        /// <summary>
        /// 模板目录
        /// </summary>
        public static string templatePath = exePath + "/data/template_";

        /// <summary>
        /// 开启更新服务
        /// </summary>
        public static string openServerUpdate = pSetting.openServerUpdateRead();
        /// <summary>
        /// 服务器url
        /// </summary>
        public static string openServerUrl = lib.pIni.read("setting", "web_url");
        /// <summary>
        /// 服务器用户名
        /// </summary>
        public static string openServerName = lib.pIni.read("setting", "web_name");
        /// <summary>
        /// 服务器用户密码
        /// </summary>
        public static string openServerPassword = lib.pIni.read("setting", "web_password");

        /// <summary>
        /// 服务器保持一致性
        /// </summary>
        public static string openServerAgreed = lib.pIni.read("setting", "web_agreed");

        /// <summary>
        /// memo db
        /// </summary>
        public static string memoDb = dataPath + "memodb.db";
    }
}

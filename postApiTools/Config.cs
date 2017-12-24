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
        /// 模板目录
        /// </summary>
        public static string templatePath = exePath + "/data/template_";
    }
}

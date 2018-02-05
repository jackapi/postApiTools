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
        /// 当前exe路径 AppDomain.CurrentDomain.BaseDirectory
        /// </summary>
        //public static string exePath = System.Environment.CurrentDirectory;
        public static string exePath = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 程序集版本获取
        /// </summary>
        public static string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        /// <summary>
        /// exe路径
        /// </summary>
        public static string exe = System.Windows.Forms.Application.ExecutablePath;

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
        public static string openServerUpdate = "";



        /// <summary>
        /// 服务器url
        /// </summary>
        public static string openServerUrl = "";

        /// <summary>
        /// 服务器用户名
        /// </summary>
        public static string openServerName = "";

        /// <summary>
        /// 服务器用户密码
        /// </summary>
        public static string openServerPassword = "";

        /// <summary>
        /// 服务器保持一致性
        /// </summary>
        public static string openServerAgreed = "";

        /// <summary>
        /// memo db
        /// </summary>
        public static string memoDb = dataPath + "memodb.db";

        /// <summary>
        /// websocket ip
        /// </summary>
        public static string openServerWebSocketIp = "";

        /// <summary>
        /// websocket port
        /// </summary>
        public static string openServerWebSocketPort = "";

        /// <summary>
        /// 强制更新到服务器
        /// </summary>
        public static string openServerWebForce = "";

        /// <summary>
        /// socket心跳延时时间
        /// </summary>
        public static string openServerSocketSleep = (10000).ToString();

        /// <summary>
        /// socket类
        /// </summary>
        public static lib.pUpdateServerSocket websocket = null;

        /// <summary>
        /// 用户token
        /// </summary>
        public static string userToken = "";

        /// <summary>
        /// 加载错误
        /// </summary>
        public static string start = Start();
        public static string Start()
        {
            ConfigReadWrite rw = new ConfigReadWrite();
            try
            {
                openServerUrl = lib.pIni.read("setting", "web_url");
                openServerName = lib.pIni.read("setting", "web_name");
                openServerPassword = rw.openServerPassword();
                openServerAgreed = lib.pIni.read("setting", "web_agreed");
                openServerWebSocketIp = lib.pIni.read("setting", "web_socket_ip");
                openServerWebSocketPort = lib.pIni.read("setting", "web_socket_port");
                openServerWebForce = lib.pIni.read("setting", "web_force");
                openServerUpdate = pSetting.openServerUpdateRead();
                websocket = new lib.pUpdateServerSocket();
                userToken = lib.pApizlHttp.getToken();
                return "";
            }
            catch (Exception ex)
            {
                pLogs.logs("config-error:" + ex.ToString());
                return ex.ToString();
            }

        }
    }
}

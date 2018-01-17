using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools
{
    public class ConfigReadWrite
    {

        //openServerUrl = lib.pIni.read("setting", "web_url");
        //openServerName = lib.pIni.read("setting", "web_name");
        //openServerPassword = lib.pIni.read("setting", "web_password");
        //openServerAgreed = lib.pIni.read("setting", "web_agreed");
        //openServerWebSocketIp = lib.pIni.read("setting", "web_socket_ip");
        //openServerWebSocketPort = lib.pIni.read("setting", "web_socket_port");
        //openServerWebForce = lib.pIni.read("setting", "web_force");
        //openServerUpdate = pSetting.openServerUpdateRead();
        //websocket = new lib.pUpdateServerSocket();
        //userToken = lib.pApizlHttp.getToken();

        /// <summary>
        /// 服务端URL
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string openServerUrl(string data = "")
        {
            if (data == "")
            {
                return lib.pIni.read("setting", "web_url");
            }
            else
            {
                Config.openServerUrl = data;
                lib.pIni.write("setting", "web_url", data);
                return "";
            }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string openServerName(string data = "")
        {
            if (data == "")
            {
                return lib.pIni.read("setting", "web_name");
            }
            else
            {
                Config.openServerName = data;
                lib.pIni.write("setting", "web_name", data);
                return "";
            }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string openServerPassword(string data = "")
        {
            if (data == "")
            {
                string password = lib.pIni.read("setting", "web_password");
                password = lib.pBase64.base64ToString(password);
                return password;
            }
            else
            {
                Config.openServerPassword = data;
                data = lib.pBase64.stringToBase64(data);
                lib.pIni.write("setting", "web_password", data);
                return "";
            }
        }
        /// <summary>
        /// 用户登录标识token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string userToken(string data = "")
        {
            if (data == "")
            {
                return lib.pApizlHttp.getToken();
            }
            else
            {
                Config.userToken = "";
                lib.pIni.write("apizlHttp", "usertoken", data);
                return lib.pApizlHttp.getToken(); ;
            }
        }

        public string openServerAgreed(string data = "")
        {
            if (data == "")
            {
                return lib.pIni.read("setting", "web_agreed");
            }
            else
            {
                Config.openServerAgreed = data;
                lib.pIni.write("setting", "web_agreed", data);
                return "";
            }
        }

        public string openServerWebSocketIp(string data = "")
        {
            if (data == "")
            {

                return lib.pIni.read("setting", "web_socket_ip");
            }
            else
            {
                Config.openServerWebSocketIp = data;
                lib.pIni.write("setting", "web_socket_ip", data);
                return "";
            }
        }

        public string openServerWebSocketPort(string data = "")
        {
            if (data == "")
            {
                return lib.pIni.read("setting", "web_socket_port");
            }
            else
            {
                Config.openServerWebSocketPort = data;
                lib.pIni.write("setting", "web_socket_port", data);
                return "";
            }
        }

        public string openServerWebForce(string data = "")
        {
            if (data == "")
            {
                return lib.pIni.read("setting", "web_force");
            }
            else
            {
                Config.openServerWebForce = data;
                lib.pIni.write("setting", "web_force", data);
                return "";
            }
        }
    }
}

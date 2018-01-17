using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools
{
    using System.IO;
    using System.Windows.Forms;
    public class pSetting
    {
        public static string fx = ".txt";
        /// <summary>
        /// 模板列表写入
        /// </summary>
        /// <param name="comboBox"></param>
        public static void templateListWrite(string filename, string text)
        {
            string result = lib.pIni.read("setting", "templateListWrite");//读取配置
            result = lib.pBase64.base64ToString(result);//64转字符串
            List<string> array = pJson.jsonStrToListString(result);//转成list
            if (array == null || array.Count == 0)
            {
                array = new List<string> { };
                array.Add("默认模板");
            }
            array.Add(filename);
            lib.pFile.Write(Config.templatePath + filename + fx, text);//写入到文件
            result = pJson.listToJson(array);
            result = lib.pBase64.stringToBase64(result);
            lib.pIni.write("setting", "templateListWrite", result);
        }

        /// <summary>
        /// 模板列表读取
        /// </summary>
        /// <param name="comboBox"></param>
        public static List<string> templateListReadList()
        {
            string result = lib.pIni.read("setting", "templateListWrite");//读取配置
            if (result == "")//默认模板string
            {
                result = "WyLErMjPxKOw5SJd";
            }
            result = lib.pBase64.base64ToString(result);//64转字符串
            List<string> array = pJson.jsonStrToListString(result);//转成list
            return array;
        }
        /// <summary>
        /// 刷新下拉框
        /// </summary>
        /// <param name="combobox"></param>
        public static void refreshTemplateList(ComboBox combobox)
        {
            combobox.DataSource = templateListReadList();
        }
        /// <summary>
        /// 输出打开模板
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string readTemplate(string name)
        {
            if (name == "默认模板")
            {
                return lib.pFile.Read(Config.templateTxt);
            }
            return lib.pFile.Read(Config.templatePath + name + fx);
        }
        /// <summary>
        /// 保存模板
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        public static void updateTemplate(string name, string text)
        {
            if (name == "默认模板")
            {
                lib.pFile.Write(Config.templateTxt, text);
            }
            else
            {
                lib.pFile.Write(Config.templatePath + name + fx, text);
            }
        }
        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="name"></param>
        public static void deleteTemplate(string name, ComboBox combobox)
        {
            if (name == "默认模板")
            {
                return;
            }
            List<string> list = templateListReadList();
            list.Remove(name);
            string result = pJson.listToJson(list);
            result = lib.pBase64.stringToBase64(result);
            lib.pIni.write("setting", "templateListWrite", result);
            refreshTemplateList(combobox);
            File.Delete(Config.templatePath + name + fx);//删除模板
        }

        /// <summary>
        /// 服务器URL
        /// </summary>
        public static string web_url = lib.pIni.read("setting", "web_url");

        /// <summary>
        /// 服务器用户名
        /// </summary>
        public static string web_name = lib.pIni.read("setting", "web_name");
        /// <summary>
        /// 服务器密码
        /// </summary>
        public static string web_password = lib.pIni.read("setting", "web_password");

        /// <summary>
        /// 服务器更新
        /// </summary>
        public static string web_update = lib.pIni.read("setting", "web_update");

        /// <summary>
        /// 保存服务器信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        public static void saveUrlNamePassword(string url, string name, string password, CheckState c, CheckState agreed)
        {
            ConfigReadWrite rw = new ConfigReadWrite();
            rw.openServerUrl(url);
            rw.openServerName(name);
            rw.openServerPassword(password);
            //lib.pIni.write("setting", "web_url", url);
            //lib.pIni.write("setting", "web_name", name);
            //lib.pIni.write("setting", "web_password", password);
            lib.pIni.write("setting", "web_update", c.ToString());
            lib.pIni.write("setting", "web_agreed", agreed.ToString());
        }

        /// <summary>
        /// socket 保存
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="force"></param>
        public static void saveSocket(string ip, string port, CheckState force)
        {
            ConfigReadWrite rw = new ConfigReadWrite();
            rw.openServerWebSocketIp(ip);
            rw.openServerWebSocketPort(port);
            rw.openServerWebForce(force.ToString());
            //lib.pIni.write("setting", "web_socket_ip", ip);
            //lib.pIni.write("setting", "web_socket_port", port);
            //lib.pIni.write("setting", "web_force", force.ToString());
        }
        /// <summary>
        /// 服务器更新服务配置
        /// </summary>
        /// <returns></returns>
        public static string openServerUpdateRead()
        {
            return lib.pIni.read("setting", "web_update");
        }
        /// <summary>
        /// 写入服务器更新服务配置
        /// </summary>
        /// <param name="value"></param>
        public static void openServerUpdateWrite(string value)
        {
            lib.pIni.write("setting", "web_update", value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 接口通讯类
/// by chenran(apiziliao@gmail.com)
/// </summary>
namespace postApiTools.lib
{
    using Newtonsoft;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Windows.Forms;
    public class pApizlHttp
    {
        /// <summary>
        /// 请求url
        /// </summary>
        public static string Url = Config.openServerUrl;

        /// <summary>
        /// 错误信息输出
        /// </summary>
        public static string error = "";

        /// <summary>
        /// 登录token信息
        /// </summary>
        public static string token = getToken();

        /// <summary>
        /// 读取token
        /// </summary>
        /// <returns></returns>
        public static string getToken()
        {
            if (Config.openServerUpdate != CheckState.Checked.ToString())
            {
                error = "已关闭自动更新";
                return "";
            }
            string token = pIni.read("apizlHttp", "usertoken");
            if (token != "")
            {
                if (isLogin(token))
                {
                    return token;
                }
                else
                {
                    if (!Login(Config.openServerName, Config.openServerPassword))
                    {
                        return "";
                    }
                }
            }
            else
            {
                if (!Login(Config.openServerName, Config.openServerPassword))
                {
                    return "";
                }
            }
            return pIni.read("apizlHttp", "usertoken");
        }

        /// <summary>
        /// 写入token数据
        /// </summary>
        /// <param name="token"></param>
        public static void writeToken(string token)
        {
            pIni.write("apizlHttp", "usertoken", token);
        }

        /// <summary>
        /// 判断是否为登录状态
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool isLogin(string token)
        {
            string urlStr = Url + "/index/register/isLogin";
            string[,] urlData = new string[1, 2];
            urlData[0, 0] = "token";
            urlData[0, 1] = token;
            string json = phttp.HttpUploadFile(urlStr, urlData);
            if (json.Length <= 0)
            {
                error = "数据请求失败";
                return false;
            }
            JObject job = pJsonData.stringToJobject(json);
            if (job == null)
            {
                error = "服务器异常";
                return false;
            }
            if (job["code"].ToString() == "1")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Login(string name, string password)
        {
            if (Config.openServerUpdate != CheckState.Checked.ToString())
            {
                error = "已关闭自动更新";
                return true;
            }
            string urlStr = Url + "/index/register/ajaxLoginToken";
            string[,] urlData = new string[2, 2];
            urlData[0, 0] = "name";
            urlData[0, 1] = name;
            urlData[1, 0] = "password";
            urlData[1, 1] = password;
            string json = phttp.HttpUploadFile(urlStr, urlData);
            if (json.Length <= 0)
            {
                error = "数据请求失败";
                return false;
            }
            JObject job = pJsonData.stringToJobject(json);
            if (job == null)
            {
                error = "服务器异常";
                return false;
            }
            if (job["code"].ToString() == "1")
            {
                token = job["result"]["token"].ToString();
                writeToken(token);//写入token
                error = job["msg"].ToString();
                return true;
            }
            error = job["msg"].ToString();
            return false;

        }

        /// <summary>
        /// 项目hash
        /// </summary>
        public static string project_hash = "";

        /// <summary>
        /// 创建主项目
        /// </summary>
        /// <param name="token"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public static bool createProject(string token, string name, string desc, string sort)
        {
            if (Config.openServerUpdate != CheckState.Checked.ToString())
            {
                error = "已关闭自动更新";
                return true;
            }
            string urlStr = Url + "/index/Document/createProjectAjax";
            string[,] urlData = new string[3, 2];
            urlData[0, 0] = "name";
            urlData[0, 1] = name;
            urlData[1, 0] = "desc";
            urlData[1, 1] = desc;
            urlData[2, 0] = "token";
            urlData[2, 1] = token;
            string json = phttp.HttpUploadFile(urlStr, urlData);
            if (json.Length <= 0)
            {
                error = "数据请求失败";
                return false;
            }
            JObject job = pJsonData.stringToJobject(json);
            if (job == null)
            {
                error = "服务器异常";
                return false;
            }
            if (job["code"].ToString() == "1")
            {
                error = job["msg"].ToString();
                project_hash = job["result"].ToString();//hash
                return true;
            }
            error = job["msg"].ToString();
            return false;
        }

        /// <summary>
        /// 创建子类项目
        /// </summary>
        /// <param name="token"></param>
        /// <param name="projectHash"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public static bool createProjectPid(string token, string projectHash, string name, string desc, string sort = "0")
        {
            if (Config.openServerUpdate != CheckState.Checked.ToString())
            {
                error = "已关闭自动更新";
                return true;
            }
            string urlStr = Url + "/index/Document/createProjectPidAjax";
            string[,] urlData = new string[5, 2];
            urlData[0, 0] = "name";
            urlData[0, 1] = name;
            urlData[1, 0] = "desc";
            urlData[1, 1] = desc;
            urlData[2, 0] = "sort";
            urlData[2, 1] = sort;
            urlData[3, 0] = "pid";
            urlData[3, 1] = projectHash;
            urlData[4, 0] = "token";
            urlData[4, 1] = token;
            string json = phttp.HttpUploadFile(urlStr, urlData);
            if (json.Length <= 0)
            {
                error = "数据请求失败";
                return false;
            }
            JObject job = pJsonData.stringToJobject(json);
            if (job == null)
            {
                error = "服务器异常";
                return false;
            }
            if (job["code"].ToString() == "1")
            {
                error = job["msg"].ToString();
                project_hash = job["result"].ToString();//hash
                return true;
            }
            error = job["msg"].ToString();
            return false;
        }

        /// <summary>
        /// 创建文档
        /// </summary>
        /// <param name="token"></param>
        /// <param name="projectHash"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public static bool createDocument(string token, string projectHash, string name, string desc, string url, string urldata, string method)
        {
            if (Config.openServerUpdate != CheckState.Checked.ToString())
            {
                error = "已关闭自动更新";
                return true;
            }
            string urlStr = Url + "/index/Document/createDocument";
            string[,] urlData = new string[7, 2];
            urlData[0, 0] = "name";
            urlData[0, 1] = name;
            urlData[1, 0] = "project_hash";
            urlData[1, 1] = projectHash;
            urlData[2, 0] = "token";
            urlData[2, 1] = token;
            urlData[3, 0] = "desc";
            urlData[3, 1] = desc;
            urlData[4, 0] = "url";
            urlData[4, 1] = url;
            urlData[5, 0] = "urldata";
            urlData[5, 1] = urldata;
            urlData[6, 0] = "method";
            urlData[6, 1] = method;
            string json = phttp.HttpUploadFile(urlStr, urlData);
            if (json.Length <= 0)
            {
                error = "数据请求失败";
                return false;
            }
            JObject job = pJsonData.stringToJobject(json);
            if (job == null)
            {
                error = "服务器异常";
                return false;
            }
            if (job["code"].ToString() == "1")
            {
                error = job["msg"].ToString();
                project_hash = job["result"].ToString();//hash
                return true;
            }
            error = job["msg"].ToString();
            return false;
        }


        /// <summary>
        /// 获取自己项目
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static JObject getUserProjectList(string token)
        {
            if (Config.openServerUpdate != CheckState.Checked.ToString())
            {
                error = "已关闭自动更新";
                return null;
            }
            string urlStr = Url + "/index/role/getProjectSettingList";
            string[,] urlData = new string[1, 2];
            urlData[0, 0] = "token";
            urlData[0, 1] = token;
            string json = phttp.HttpUploadFile(urlStr, urlData);
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
            if (job["code"].ToString() == "1")
            {
                error = job["msg"].ToString();
                return job;
            }
            error = job["msg"].ToString();
            return null;
        }

        /// <summary>
        /// 获取自己子类项目
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static JObject getProjectSettingPidList(string token, string hash)
        {
            if (Config.openServerUpdate != CheckState.Checked.ToString())
            {
                error = "已关闭自动更新";
                return null;
            }
            string urlStr = Url + "/index/role/getProjectSettingList";
            string[,] urlData = new string[2, 2];
            urlData[0, 0] = "token";
            urlData[0, 1] = token;
            urlData[1, 0] = "pid";
            urlData[1, 1] = hash;
            string json = phttp.HttpUploadFile(urlStr, urlData);
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
            if (job["code"].ToString() == "1")
            {
                error = job["msg"].ToString();
                return job;
            }
            error = job["msg"].ToString();
            return null;
        }


        /// <summary>
        /// 获取内容列表
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static JObject getDocumentList(string token, string hash)
        {
            if (Config.openServerUpdate != CheckState.Checked.ToString())
            {
                error = "已关闭自动更新";
                return null;
            }
            string urlStr = Url + "/index/role/getProjectList";
            string[,] urlData = new string[2, 2];
            urlData[0, 0] = "token";
            urlData[0, 1] = token;
            urlData[1, 0] = "hash";
            urlData[1, 1] = hash;
            string json = phttp.HttpUploadFile(urlStr, urlData);
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
            if (job["code"].ToString() == "1")
            {
                error = job["msg"].ToString();
                return job;
            }
            error = job["msg"].ToString();
            return null;
        }

        /// <summary>
        /// 通用登录请求接口方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static JObject getHttpData(string url, string[,] data)
        {
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
            if (job["code"].ToString() == "1")
            {
                error = job["msg"].ToString();
                return job;
            }
            error = job["msg"].ToString();
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static JObject getDocumentInfo(string hash)
        {
            string[,] urlData = new string[2, 2];
            urlData[0, 0] = "token";
            urlData[0, 1] = token;
            urlData[1, 0] = "hash";
            urlData[1, 1] = hash;
            string urlStr = Url + "/index/role/getProjectList";
            return getHttpData(urlStr, urlData);
        }

        /// <summary>
        /// 删除一个项目（包含子项目）
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static JObject deleteProject(string hash)
        {
            string[,] urlData = new string[2, 2];
            urlData[0, 0] = "token";
            urlData[0, 1] = token;
            urlData[1, 0] = "hash";
            urlData[1, 1] = hash;
            string urlStr = Url + "/index/Document/deleteProject";
            return getHttpData(urlStr, urlData);
        }

        /// <summary>
        ///获取子类列表
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static JObject getProjectPidList(string hash)
        {
            string[,] urlData = new string[2, 2];
            urlData[0, 0] = "token";
            urlData[0, 1] = token;
            urlData[1, 0] = "hash";
            urlData[1, 1] = hash;
            string urlStr = Url + "/index/Document/getProjectPidList";
            return getHttpData(urlStr, urlData);
        }

        /// <summary>
        ///获取文章列表
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static JObject getDocumentList(string hash)
        {
            string[,] urlData = new string[2, 2];
            urlData[0, 0] = "token";
            urlData[0, 1] = token;
            urlData[1, 0] = "hash";
            urlData[1, 1] = hash;
            string urlStr = Url + "/index/Document/getDocumentList";
            return getHttpData(urlStr, urlData);
        }

        /// <summary>
        ///编辑文档
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static JObject editDocument(string serverHash, string name, string desc, string url, string urldata, string method)
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("token", token);
            d.Add("hash", serverHash);
            d.Add("name", name);
            d.Add("desc", desc);
            d.Add("url", url);
            d.Add("urldata", urldata);
            d.Add("method", method);
            string urlStr = Url + "/index/Document/editDocument";
            return getHttpData(urlStr, dicToStringArray(d));
        }

        /// <summary>
        /// 字典转二维
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string[,] dicToStringArray(Dictionary<string, string> d)
        {
            int i = 0;
            string[,] temp = new string[d.Count, 2];
            if (d.Count <= 0)
            {
                return temp;
            }
            foreach (var item in d)
            {
                temp[i, 0] = item.Key;
                temp[i, 1] = item.Value;
                i++;
            }
            return temp;
        }


        /// <summary>
        ///获取文档
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static JObject getDocument(string serverHash)
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("token", token);
            d.Add("hash", serverHash);
            string urlStr = Url + "/index/Document/getDocument";
            return getHttpData(urlStr, dicToStringArray(d));
        }
    }
}

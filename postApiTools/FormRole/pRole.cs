using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 权限管理
/// by:chenran (apiziliao@gmail.com)
/// </summary>
namespace postApiTools.FormRole
{
    using postApiTools.lib;
    public class pRole
    {
        /// <summary>
        /// 
        /// </summary>
        public static string Url = Config.openServerUrl;

        /// <summary>
        /// error
        /// </summary>
        public static string error = "";

        /// <summary>
        /// token
        /// </summary>
        public static string token = pApizlHttp.getToken();

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
        /// 创建权限角色
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static JObject createRoleName(string name)
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("token", token);
            d.Add("name", name);
            string urlStr = Url + "/index/role/createRoleName";
            return getHttpData(urlStr, pBase.dicToStringArray(d));
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static JObject roleList()
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("token", token);
            string urlStr = Url + "/index/role/getRoleList";
            return getHttpData(urlStr, pBase.dicToStringArray(d));
        }

        /// <summary>
        /// 添加用户到权限中
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static JObject createUserToRole(string name, string role)
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("token", token);
            d.Add("role", role);
            d.Add("name", name);
            string urlStr = Url + "/index/role/setRoleUser";
            return getHttpData(urlStr, pBase.dicToStringArray(d));
        }


        /// <summary>
        /// 获取角色包含的用户列表
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static JObject getRoleUserList(string role)
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("token", token);
            d.Add("role", role);
            string urlStr = Url + "/index/role/getRoleUserList";
            return getHttpData(urlStr, pBase.dicToStringArray(d));
        }

        /// <summary>
        /// 清空某个权限角色所有用户
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static JObject roleUserClear(string role)
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("token", token);
            d.Add("role", role);
            string urlStr = Url + "/index/role/roleUserClear";
            return getHttpData(urlStr, pBase.dicToStringArray(d));
        }

        /// <summary>
        /// 获取自己主项目列表
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static JObject getProjectSettingList()
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("token", token);
            string urlStr = Url + "/index/role/getProjectSettingList";
            return getHttpData(urlStr, pBase.dicToStringArray(d));
        }

        /// <summary>
        /// 获取自己主项目子类列表
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static JObject getProjectSettingPidList(string hash)
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("token", token);
            d.Add("pid", hash);
            string urlStr = Url + "/index/role/getProjectSettingPidList";
            return getHttpData(urlStr, pBase.dicToStringArray(d));
        }

        /// <summary>
        /// 设置项目权限
        /// </summary>
        /// <param name="project_hash"></param>
        /// <param name="role_hash"></param>
        /// <param name="all"></param>
        /// <param name="read"></param>
        /// <param name="write"></param>
        /// <returns></returns>
        public static JObject createRoleProject(string project_hash, string role_hash, string all, string read, string write)
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("token", token);
            d.Add("project_hash", project_hash);
            d.Add("role_hash", role_hash);
            d.Add("all", all);
            d.Add("read", read);
            d.Add("write", write);
            string urlStr = Url + "/index/role/createRoleProject?XDEBUG_SESSION_START=netbeans-xdebug";
            return getHttpData(urlStr, pBase.dicToStringArray(d));
        }


        /// <summary>
        /// 获取项目包含的角色
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static JObject getRoleProjectSettingRoleList(string hash)
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            d.Add("token", token);
            d.Add("hash", hash);
            string urlStr = Url + "/index/role/getRoleProjectSettingRoleList";
            return getHttpData(urlStr, pBase.dicToStringArray(d));
        }
    }
}

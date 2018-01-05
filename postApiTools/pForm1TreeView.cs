using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 首页树的操作
/// by:chenran (apiziliao@gmail.com)
/// </summary>
namespace postApiTools
{
    using System.IO;
    using System.Windows.Forms;
    public class pForm1TreeView
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public static string error = "";
        /// <summary>
        /// 实例化sqlite
        /// </summary>
        public static lib.pSqlite sqlite = new lib.pSqlite(Config.historyDataDb);

        /// <summary>
        /// 存储信息表
        /// </summary>
        const string table = "treeview_project";
        /// <summary>
        /// setting表名
        /// </summary>
        const string tableSetting = "treeview_project_setting";

        /// <summary>
        /// 获取文档表
        /// </summary>
        /// <returns></returns>
        public static string getTable()
        {
            return table;
        }
        /// <summary>
        /// 获取栏目表
        /// </summary>
        /// <returns></returns>
        public static string getTableSetting()
        {
            return tableSetting;
        }
        /// <summary>
        /// 创建表
        /// </summary>
        public static void create()
        {
            sqlite.executeNonQuery("CREATE TABLE IF NOT EXISTS " + table + "(hash varchar(200),project_id varchar(200),sort integer , name varchar(200), desc varchar(2000),url varchar(200),urldata varchar(20000),method varchar(200),server_hash varchar(200),server_update integer,addtime integer);");//创建详情表
            sqlite.executeNonQuery("CREATE TABLE IF NOT EXISTS " + tableSetting + "(hash varchar(200),pid varchar(200) ,sort integer , name varchar(200), desc varchar(2000),server_hash varchar(200),server_update integer,addtime integer);");//创建配置表
        }
        /// <summary>
        /// 插入主要项目名称
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="desc">描述</param>
        /// <returns></returns>
        public static bool insertMain(string name, string desc)
        {
            create();//运行就进行判断
            Dictionary<string, string> result = sqlite.getOne("select *from " + tableSetting + " where pid=0 and name='" + name + "'");
            if (result.Count > 0)
            {
                error = "项目名称必须唯一";
                return false;
            }
            string hash = lib.pBase.getHash();//生成hash
            if (lib.pApizlHttp.createProject(lib.pApizlHttp.token, name, desc, "0")) //创建在线
            {
                string sql = "insert into " + tableSetting + "(hash,pid,sort,name,desc,server_hash,server_update,addtime)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
                sql = string.Format(sql, hash, 0, 0, name, desc, lib.pApizlHttp.project_hash, lib.pDate.getTimeStamp(), lib.pDate.getTimeStamp());
                if (sqlite.executeNonQuery(sql) > 0)
                {
                    return true;
                }
            }
            error = sqlite.error;
            return false;
        }


        /// <summary>
        /// 获取数据库中主要项目到二维数组
        /// </summary>
        /// <returns></returns>
        public static string[,] getAllToStringArray()
        {
            Dictionary<int, object> data = sqlite.getRows("select *from " + tableSetting + " where pid=0 order by sort ASC");
            string[,] temp = new string[data.Count, 2];
            for (int i = 0; i < data.Count; i++)
            {
                Dictionary<string, string> row = (Dictionary<string, string>)data[i];
                temp[i, 0] = row["name"];
                temp[i, 1] = row["hash"];

            }
            return temp;
        }

        /// <summary>
        /// 递归刷新树
        /// </summary>
        /// <param name="hash">上级hash</param>
        /// <param name="tn">子类TreeNode</param>
        /// <returns></returns>
        public static string[,] getPidResultToStringArray(string hash, TreeNode tn)
        {
            string sql = string.Format("select *from {0} where pid='{1}' order by sort ASC", tableSetting, hash);
            Dictionary<int, object> data = sqlite.getRows(sql);
            string[,] temp = new string[data.Count, 2];
            for (int i = 0; i < data.Count; i++)
            {
                Dictionary<string, string> row = (Dictionary<string, string>)data[i];
                temp[i, 0] = row["name"];
                temp[i, 1] = row["hash"];
                TreeNode tp = tn.Nodes.Add(temp[i, 1], temp[i, 0]);
                getPidResultToStringArray(row["hash"], tp);//输出
                getApiPidAll(tp, temp[i, 1]);//输出接口

            }
            return temp;
        }
        /// <summary>
        /// 输出接口文档到树
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="hash"></param>
        public static void getApiPidAll(TreeNode tn, string hash)
        {
            string sql = string.Format("select *from {0} where project_id='{1}' order by sort ASC", table, hash);
            Dictionary<int, object> data = sqlite.getRows(sql);
            string[,] temp = new string[data.Count, 2];
            for (int i = 0; i < data.Count; i++)
            {
                Dictionary<string, string> row = (Dictionary<string, string>)data[i];
                temp[i, 0] = row["name"];
                temp[i, 1] = row["hash"];
                TreeNode tp = tn.Nodes.Add(temp[i, 1], "文档-" + temp[i, 0]);
                tp.ImageIndex = 1;
                getPidResultToStringArray(row["hash"], tp);

            }

        }
        /// <summary>
        /// 显示项目
        /// </summary>
        /// <param name="t"></param>
        public static void showMainData(TreeView t, ImageList image)
        {
            t.Invoke(new Action(() =>
            {
                t.Nodes.Clear();
                t.ImageList = image;
                string[,] data = getAllToStringArray();
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    TreeNode pidNode = t.Nodes.Add(data[i, 1], data[i, 0]);
                    //t.ImageList.Images.Add(data[i, 1], image.Images[0]);
                    pidNode.ImageIndex = 0;
                    string[,] pidResult = getPidResultToStringArray(data[i, 1], pidNode);//递归刷新树
                    getApiPidAll(pidNode, data[i, 1]);//查询接口
                }
            }));
        }
        /// <summary>
        /// 更新项目中服务器hash
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="serverHash"></param>
        /// <returns>int</returns>
        public static int updateProjectServerHash(string hash, string serverHash)
        {
            string sql = string.Format("update {0} set server_hash='{1}' ,server_update='{2}' where hash='{3}'", tableSetting, serverHash, lib.pDate.getTimeStamp(), hash);
            return sqlite.executeNonQuery(sql);
        }
        /// <summary>
        /// 添加子类
        /// </summary>
        /// <param name="t"></param>
        /// <param name="name"></param>
        public static void insertPid(TreeView t, string name)
        {
            string idHash = t.SelectedNode.Name;
            string getSql = string.Format("select *from {0} where hash='{1}' ", tableSetting, idHash);
            Dictionary<string, string> mainResult = sqlite.getOne(getSql);
            if (mainResult.Count <= 0) { error = "需要一个上级"; return; }
            string hash = lib.pBase.getHash();
            if (lib.pApizlHttp.createProjectPid(lib.pApizlHttp.token, mainResult["server_hash"], name, "", "0"))
            {
                string mainHash = mainResult["hash"];
                insertPidData(name, hash, mainHash, lib.pApizlHttp.project_hash);
                //string sql = "insert into " + tableSetting + "(hash,pid,sort,name,desc,server_hash,server_update,addtime)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
                //sql = string.Format(sql, hash, mainHash, 0, name, "", lib.pApizlHttp.project_hash, lib.pDate.getTimeStamp(), lib.pDate.getTimeStamp());
                //sqlite.executeNonQuery(sql);
            }
            t.SelectedNode.Nodes.Add(hash, name);
        }


        /// <summary>
        /// 更新子类serverHash
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static int updateProjectPidServerHash(string hash, string serverHash)
        {
            string sql = string.Format("update {0} set server_hash='{1}' ,server_update='{2}' where hash='{3}'", tableSetting, serverHash, lib.pDate.getTimeStamp(), hash);
            return sqlite.executeNonQuery(sql);
        }

        /// <summary>
        /// 添加子类
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hash"></param>
        /// <param name="projectHash"></param>
        /// <param name="serverHash"></param>
        public static void insertPidData(string name, string hash, string projectHash, string serverHash)
        {
            string sql = "insert into " + tableSetting + "(hash,pid,sort,name,desc,server_hash,server_update,addtime)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
            sql = string.Format(sql, hash, projectHash, 0, name, "", serverHash, lib.pDate.getTimeStamp(), lib.pDate.getTimeStamp());
            sqlite.executeNonQuery(sql);
        }
        /// <summary>
        /// 添加接口文档
        /// </summary>
        /// <param name="t"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="url"></param>
        /// <param name="urlType"></param>
        /// <param name="urlData"></param>
        public static bool addApi(TreeView t, string name, string desc, string url, string urlType, string[,] urlData)
        {
            string hash = lib.pBase.getHash();
            string project_id = t.SelectedNode.Name;
            string urlDataStr = lib.pBase64.stringToBase64(pJson.objectToJsonStr(urlData));
            Dictionary<string, string> d = sqlite.getOne(string.Format("select *from {0} where hash='{1}'", tableSetting, project_id));
            if (d.Count <= 0)
            {
                error = sqlite.error;
                return false;
            }
            if (lib.pApizlHttp.createDocument(lib.pApizlHttp.token, d["server_hash"], name, desc, url, urlDataStr, urlType))
            {
                string sql = string.Format("insert into {0} (hash,project_id,sort,name,desc,url,urldata,method,server_hash,server_update,addtime)values('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", table, hash, project_id, 0, name, desc, url, urlDataStr, urlType, lib.pApizlHttp.project_hash, lib.pDate.getTimeStamp(), lib.pDate.getTimeStamp());
                if (sqlite.executeNonQuery(sql) > 0)
                {
                    return true;
                }
                else
                {
                    error = sqlite.error;
                    return false;
                }
            }
            error = sqlite.error;
            return false;
        }

        /// <summary>
        /// 添加接口文档sql
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="project_id"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="url"></param>
        /// <param name="urlDataStr"></param>
        /// <param name="urlType"></param>
        /// <returns></returns>
        public static int addApiSql(string hash, string project_id, string name, string desc, string url, string urlDataStr, string urlType, string server_hash)
        {
            string sql = string.Format("insert into {0} (hash,project_id,sort,name,desc,url,urldata,method,server_hash,server_update,addtime)values('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", table, hash, project_id, 0, name, desc, url, urlDataStr, urlType, server_hash, lib.pDate.getTimeStamp(), lib.pDate.getTimeStamp());
            return sqlite.executeNonQuery(sql);
        }
        /// <summary>
        /// 删除树
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool deleteTreeViewSetting(TreeView t)
        {
            string hash = t.SelectedNode.Name;
            Dictionary<string, string> d = sqlite.getOne(string.Format("select *from {0} where pid='{1}'", tableSetting, hash));
            Dictionary<string, string> dApi = sqlite.getOne(string.Format("select *from {0} where hash='{1}'", table, hash));
            if (d.Count > 0 && dApi.Count <= 0) { error = "先删除子类"; return false; }
            string sql = "";
            if (dApi.Count > 0)
            {
                sql = string.Format("delete from {0} where hash='{1}'", table, hash);//删除api
            }
            else
            {
                sql = string.Format("delete from {0} where hash='{1}'", tableSetting, hash);//删除项目或子类
            }
            if (sqlite.executeNonQuery(sql) > 0)
            {
                return true;
            }
            else
            {
                error = sqlite.error;
                return false;
            }
        }
        /// <summary>
        /// 重命名树
        /// </summary>
        /// <param name="t"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool updateNameTreeViewSetting(TreeView t, string name)
        {
            string hash = t.SelectedNode.Name;
            string sql = string.Format("update  {0} set name='{1}'  where hash='{2}'", tableSetting, name, hash);
            if (sqlite.executeNonQuery(sql) > 0)
            {
                return true;
            }
            else
            {
                error = sqlite.error;
                return false;
            }
        }
        /// <summary>
        /// 打开一个api赋值到界面
        /// </summary>
        /// <param name="t"></param>
        /// <param name="url"></param>
        /// <param name="urlType"></param>
        /// <param name="dd"></param>
        /// <returns></returns>
        public static bool openApiDataShow(TreeView t, TextBox url, ComboBox urlType, DataGridView dd)
        {
            string idHash = t.SelectedNode.Name;
            string sql = string.Format("select *from {0} where hash='{1}' ", table, idHash);
            Dictionary<string, string> list = sqlite.getOne(sql);
            if (list.Count <= 0)
            {
                //error = "没有数据";
                return false;
            }
            url.Text = list["url"];
            urlType.Text = list["method"];
            string urlDataStr = list["urldata"];
            urlDataStr = lib.pBase64.base64ToString(urlDataStr);
            object[,] obj = pJson.jsonStrToObjectArray(urlDataStr, 4);
            pform1.objecArrayToDataViewShow(dd, obj);//刷新显示
            return false;
        }

        /// <summary>
        /// 搜索接口文档
        /// </summary>
        /// <param name="search"></param>
        public static void apidocSearch(TreeView t, string search, TextBox text)
        {
            t.Invoke(new Action(() =>
            {
                string sql = string.Format("select *from {0} where name like  '%{1}%' or desc like  '%{1}%'", table, search);
                Dictionary<int, object> list = sqlite.getRows(sql);
                for (int i = 0; i < list.Count; i++)
                {
                    Dictionary<string, string> d = (Dictionary<string, string>)list[i];
                    TreeNode tn = FindNodeByName(t.Nodes, d["hash"]);
                    tn.BackColor = System.Drawing.Color.Red;
                    t.ExpandAll();
                }
            }));
        }


        /// <summary>
        /// 根据名称查找节点
        /// </summary>
        /// <param name="ParentNods">节点集合</param>
        /// <param name="name">要查找的名字</param>
        /// <returns>目标节点</returns>
        private static TreeNode FindNodeByName(TreeNodeCollection ParentNods, string name)
        {
            TreeNode temNode = null;
            foreach (TreeNode tn in ParentNods)
            {
                if (tn.Name.Equals(name))
                    return tn;
                else
                {
                    temNode = FindNodeByName(tn.Nodes, name);
                    if (temNode != null)
                        return temNode;
                }
            }
            return temNode;
        }
    }
}

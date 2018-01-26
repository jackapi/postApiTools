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
    using FastColoredTextBoxNS;
    using Newtonsoft.Json.Linq;
    using System.IO;
    using System.Threading;
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
            sqlite.executeNonQuery("CREATE UNIQUE INDEX IF Not Exists name_server_hash ON treeview_project (name, server_hash);");//index     
            sqlite.executeNonQuery("CREATE UNIQUE INDEX IF Not Exists server_hash ON treeview_project_setting (name, server_hash);");//index

        }
        /// <summary>
        /// 插入主要项目名称
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="desc">描述</param>
        /// <returns></returns>
        public static bool insertMain(string name, string desc, TreeView tv)
        {
            error = "";
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
                Config.websocket.sendServerProjectHashCreate(lib.pApizlHttp.project_hash);//项目创建消息推送
                string sql = "insert into " + tableSetting + "(hash,pid,sort,name,desc,server_hash,server_update,addtime)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
                sql = string.Format(sql, hash, 0, 0, name, desc, lib.pApizlHttp.project_hash, lib.pDate.getTimeStamp(), lib.pDate.getTimeStamp());
                if (sqlite.executeNonQuery(sql) > 0)
                {
                    //无刷新添加
                    tv.Invoke(new Action(() =>
                    {
                        TreeNode tn = tv.Nodes.Add(hash, name);
                        tn.ImageIndex = 0;
                        tn.SelectedImageIndex = 0;
                    }));
                    return true;
                }
            }
            error = sqlite.error;
            return false;
        }
        /// <summary>
        /// 创建主要项目方法sql
        /// </summary>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static int insertMainSql(string name, string desc, string serverHash)
        {
            create();
            string hash = lib.pBase.getHash();//生成hash
            string sql = "insert into " + tableSetting + "(hash,pid,sort,name,desc,server_hash,server_update,addtime)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
            sql = string.Format(sql, hash, 0, 0, name, desc, serverHash, lib.pDate.getTimeStamp(), lib.pDate.getTimeStamp());
            return sqlite.executeNonQuery(sql);
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
                TreeNode tp = tn.Nodes.Add(temp[i, 1], "" + temp[i, 0]);
                tp.ImageIndex = 1;
                tp.SelectedImageIndex = 1;
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
                    pidNode.SelectedImageIndex = 0;
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
            error = "";
            string idHash = t.SelectedNode.Name;
            string getSql = string.Format("select *from {0} where hash='{1}' ", tableSetting, idHash);
            Dictionary<string, string> mainResult = sqlite.getOne(getSql);
            if (mainResult.Count <= 0) { error = "需要一个上级"; return; }
            string hash = lib.pBase.getHash();
            if (lib.pApizlHttp.createProjectPid(lib.pApizlHttp.token, mainResult["server_hash"], name, "", "0"))
            {

                Config.websocket.sendServerProjectHashCreate(lib.pApizlHttp.project_hash);//项目创建消息推送
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
            create();
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
        /// 添加文档创建果
        /// </summary>
        public static string addApiHash = "";

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
            addApiHash = "";
            string hash = lib.pBase.getHash();
            if (t.SelectedNode == null) { error = "选择节点保存！"; return false; }
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

                    addApiHash = hash;//返回id
                    Config.websocket.sendServerHashCreate(lib.pApizlHttp.project_hash);//发送文档创建推送
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
        /// 删除项目和文档 树
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool deleteTreeViewSetting(TreeView t)
        {
            if (t.SelectedNode == null) { return false; }
            string hash = t.SelectedNode.Name;
            Dictionary<string, string> d = sqlite.getOne(string.Format("select *from {0} where pid='{1}'", tableSetting, hash));
            Dictionary<string, string> dApi = sqlite.getOne(string.Format("select *from {0} where hash='{1}'", table, hash));
            if (d.Count > 0 && dApi.Count <= 0) { error = "先删除子类"; return false; }
            string sql = "";
            if (dApi.Count > 0)
            {
                sql = string.Format("delete from {0} where hash='{1}'", table, hash);//删除api
                Dictionary<string, string> nowHash = sqlite.getOne(string.Format("select *from {0} where hash='{1}'", table, hash));
                if (nowHash.Count > 0)
                {
                    if (nowHash["server_hash"] != null || nowHash["server_hash"].Length > 0)
                    {
                        Dictionary<string, string> nowProjectHash = sqlite.getOne(string.Format("select *from {0} where hash='{1}'", tableSetting, nowHash["project_id"]));//获取栏目id

                        JObject job = lib.pApizlHttp.deleteDocument(nowHash["server_hash"]);//删除远程文档
                        if (job != null)
                        {
                            if (job["code"].ToString() != "1")
                            {
                                error = "删除失败:" + job["msg"].ToString();
                                return false;
                            }
                            else
                            {
                                Config.websocket.sendServerHashDelete(nowProjectHash["server_hash"], nowHash["server_hash"]);//发送删除消息通知 }
                            }
                        }
                    }
                }
            }
            else
            {
                sql = string.Format("delete from {0} where hash='{1}'", tableSetting, hash);//删除项目或子类
                Dictionary<string, string> nowHash = sqlite.getOne(string.Format("select *from {0} where hash='{1}'", tableSetting, hash));
                if (nowHash.Count > 0)
                {
                    Config.websocket.sendServerProjectHashDelete(nowHash["server_hash"]);//项目删除消息推送
                    lib.pApizlHttp.deleteProject(nowHash["server_hash"]);//删除远程项目
                }
            }
            if (sqlite.executeNonQuery(sql) > 0)
            {
                t.SelectedNode.Remove();//删除当前
                return true;
            }
            else
            {
                error = sqlite.error;
                return false;
            }
        }
        /// <summary>
        /// 重命名项目名树
        /// </summary>
        /// <param name="t"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool updateNameTreeViewSetting(TreeView t, string name)
        {
            if (t.SelectedNode == null) { error = "请选中在修改"; return false; }
            string hash = t.SelectedNode.Name;
            if (isApiHash(hash))//判断是否为文档
            {
                error = "此处无法重命名文档";
                return false;
            }
            Dictionary<string, string> nowHash = getOneProjectSettingHash(hash);//当项目详情
            if (nowHash == null) { error = "项目不存在无法修改"; return false; }
            string sql = string.Format("update  {0} set name='{1}'  where hash='{2}'", tableSetting, name, hash);
            if (sqlite.executeNonQuery(sql) > 0)
            {
                t.SelectedNode.Text = name;
                if (nowHash["server_hash"].Length > 0)
                {
                    lib.pApizlHttp.editProjectInfo(nowHash["server_hash"], name, "", "0");//远程项目修改 
                    Config.websocket.sendServerProjectHashUpdate(nowHash["server_hash"]);//发送修改项目推送消息
                }

                return true;
            }
            else
            {
                error = sqlite.error;
                return false;
            }
        }

        /// <summary>
        /// web打开api赋值到界面
        /// </summary>
        /// <param name="t"></param>
        /// <param name="url"></param>
        /// <param name="urlType"></param>
        /// <param name="dd"></param>
        /// <returns></returns>
        public static bool webOpenApiDataShow(string serverHash, TextBox url, ComboBox urlType, DataGridView dd, TextBox textBox_api_name, TextBox doc)
        {
            if (serverHash == "") { return false; }
            Dictionary<string, string> list = sqlite.getOne(string.Format("select *from {0} where server_hash='{1}' ", table, serverHash));
            if (list.Count <= 0)
            {
                error = "本地没有数据或没有权限！请重新拉取！";
                return false;
            }
            if (list["server_hash"] != "" || list["server_hash"] != null)//直接读取线上最新
            {
                updateDocument(list["server_hash"]);
                list = sqlite.getOne(string.Format("select *from {0} where server_hash='{1}' ", table, serverHash));
            }
            url.Text = list["url"];
            urlType.Text = list["method"];
            textBox_api_name.Text = list["name"];
            doc.Text = list["desc"];
            string urlDataStr = list["urldata"];
            urlDataStr = lib.pBase64.base64ToString(urlDataStr);
            object[,] obj = pJson.jsonStrToObjectArray(urlDataStr, 4);
            pform1.objecArrayToDataViewShow(dd, obj);//刷新显示
            return true;
        }
        /// <summary>
        /// 打开一个api赋值到界面
        /// </summary>
        /// <param name="t"></param>
        /// <param name="url"></param>
        /// <param name="urlType"></param>
        /// <param name="dd"></param>
        /// <returns></returns>
        public static bool openApiDataShow(TreeView t, TextBox url, ComboBox urlType, DataGridView dd, TextBox textBox_api_name, TextBox doc)
        {
            if (t.SelectedNode == null) { return false; }
            string idHash = t.SelectedNode.Name;
            Dictionary<string, string> list = sqlite.getOne(string.Format("select *from {0} where hash='{1}' ", table, idHash));
            if (list.Count <= 0)
            {
                //error = "没有数据";
                return false;
            }
            if (list["server_hash"] != "" || list["server_hash"] != null)//直接读取线上最新
            {
                updateDocument(list["server_hash"]);
                list = sqlite.getOne(string.Format("select *from {0} where hash='{1}' ", table, idHash));
            }
            url.Text = list["url"];
            urlType.Text = list["method"];
            textBox_api_name.Text = list["name"];
            doc.Text = list["desc"];
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
        public static void apidocSearch(TreeView t, string search, FastColoredTextBox text)
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
        public static TreeNode FindNodeByName(TreeNodeCollection ParentNods, string name)
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

        /// <summary>
        /// 无刷新修改treeview
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="hash"></param>
        /// <param name="text"></param>
        public static void updateTreeViewText(TreeView tv, string hash, string text)
        {
            TreeNode tn = FindNodeByName(tv.Nodes, hash);
            tn.Text = text;
        }

        /// <summary>
        /// 刷新重新节点文档显示
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="serverHash"></param>
        public static void refreshTreeViewText(TreeView tv, string serverHash)
        {
            Dictionary<string, string> d = sqlite.getOne(string.Format("select *from {0} where server_hash='{1}'", table, serverHash));
            if (d.Count <= 0) { return; }
            TreeNode tn = FindNodeByName(tv.Nodes, d["hash"]);
            tn.Text = d["name"];
        }

        /// <summary>
        /// 判断文档是否存在
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool isApiHash(string hash)
        {
            create();
            if (hash == "")
            {
                error = "hash error";
                return false;
            }
            string sql = string.Format("select *from {0} where hash='{1}'", table, hash);
            error = sqlite.error;
            Dictionary<string, string> d = sqlite.getOne(sql);
            return d.Count > 0 ? true : false;

        }
        /// <summary>
        /// 编辑API
        /// </summary>
        public static bool editApi(string hash, string name, string desc, string url, string urldata, string urlType)
        {
            create();
            if (hash == "")
            {
                error = "hash error";
                return false;
            }
            Dictionary<string, string> d = sqlite.getOne(string.Format("select *from {0} where hash='{1}'", table, hash));
            if (d.Count <= 0)
            {
                error = "不存在数据";
                return false;
            }

            string sql = "update {0} set name='{1}' , desc='{2}',url='{3}',urldata='{4}',method='{5}' where hash='{6}'";
            sql = string.Format(sql, table, name, desc, url, urldata, urlType, hash);
            if (sqlite.executeNonQuery(sql) > 0)
            {
                lib.pApizlHttp.editDocument(d["server_hash"], name, desc, url, urldata, urlType);//编辑线上
                Config.websocket.sendServerHashUpdate(d["server_hash"]);//发送更新推送
                return true;
            }
            error = sqlite.error;
            return false;
        }

        /// <summary>
        /// pull判断是否存在文章
        /// </summary>
        /// <param name="serverHash"></param>
        /// <param name="name"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static bool getIsDocumentServer(string serverHash, string name, string pid)
        {
            Dictionary<string, string> d = sqlite.getOne(string.Format("select *from {0} where server_hash='{1}' and name='{2}'  and project_id = '{3}'", table, serverHash, name, pid));
            return d.Count > 0 ? true : false;
        }

        /// <summary>
        /// 创建子类列表
        /// </summary>
        /// <param name="jar"></param>
        /// <param name="localHash"></param>
        public static void createProjectPidList(JArray jar, string localHash)
        {
            create();
            for (int i = 0; i < jar.Count; i++)
            {
                sqlite.executeNonQuery(string.Format("insert into {0} (hash,pid,sort,name,desc,server_hash,server_update,addtime)values('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", pForm1TreeView.tableSetting, lib.pBase.getHash(), localHash, 0, jar[i]["name"], jar[i]["desc"], jar[i]["hash"], lib.pDate.getTimeStamp(), lib.pDate.getTimeStamp()));
            }
        }
        /// <summary>
        /// pull创建服务器文章列表
        /// </summary>
        /// <param name="jar"></param>
        /// <param name="localHash"></param>
        public static void createDocumentList(JArray jar, string localHash)
        {
            create();
            for (int i = 0; i < jar.Count; i++)
            {
                if (getIsDocumentServer(jar[i]["hash"].ToString(), jar[i]["name"].ToString(), localHash)) { continue; }
                sqlite.executeNonQuery(string.Format("insert into {0} (hash,project_id,sort,name,desc,url,urldata,method,server_hash,server_update,addtime)values('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", pForm1TreeView.table, lib.pBase.getHash(), localHash, 0, jar[i]["name"], jar[i]["desc"], jar[i]["url"], jar[i]["urldata"], jar[i]["method"], jar[i]["hash"], lib.pDate.getTimeStamp(), lib.pDate.getTimeStamp()));
            }
        }
        /// <summary>
        /// 获取文档详情
        /// </summary>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static Dictionary<string, string> getLocalDocumentInfo(string serverHash)
        {
            return sqlite.getOne(string.Format("select *from {0} where server_hash='{1}'", table, serverHash));
        }

        /// <summary>
        /// 更新一个文档
        /// </summary>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static bool updateDocument(string serverHash)
        {
            JObject job = lib.pApizlHttp.getDocument(serverHash);
            if (job == null)
            {
                error = lib.pApizlHttp.error;
                Form1.f.TextShowlogs("自动更新文档失败:" + error, "error");
                return false;
            }
            if (job["code"].ToString() == "0") { error = job["msg"].ToString(); return false; }
            JObject result = (JObject)job["result"];
            string sql = "update {0} set name='{1}' , desc='{2}',url='{3}',urldata='{4}',method='{5}',server_update='{6}' where server_hash='{7}'";
            sql = string.Format(sql, table, result["name"].ToString(), result["desc"].ToString(), result["url"].ToString(), result["urldata"].ToString(), result["method"].ToString(), lib.pDate.getTimeStamp(), serverHash);
            int rows = sqlite.executeNonQuery(sql);
            error = sqlite.error;
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 判断一个线上文章是否存在
        /// </summary>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static bool isDocumentServerHash(string serverHash)
        {
            return sqlite.getOne(string.Format("select *from {0} where server_hash='{1}'", table, serverHash)).Count > 0 ? true : false;
        }
        /// <summary>
        /// 线上推送创建文档
        /// </summary>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static bool webSocketDocumentCreate(string serverHash, TreeView tv)
        {
            string hash = lib.pBase.getHash();
            JObject job = lib.pApizlHttp.getDocument(serverHash);
            if (job == null)
            {
                error = lib.pApizlHttp.error;
                Form1.f.TextShowlogs("自动创建文档失败:" + error, "error");
                return false;
            }
            if (job["code"].ToString() == "0") { error = job["msg"].ToString(); return false; }
            JObject result = (JObject)job["result"];

            if (isDocumentServerHash(serverHash)) { return true; }//判断文章是否存在

            Dictionary<string, string> d = sqlite.getOne(string.Format("select *from {0} where server_hash='{1}'", tableSetting, result["project_id"].ToString()));

            if (d.Count <= 0) { error = "创建文档错误！请重新拉取！"; return false; }//判断上级是否为空

            tv.Invoke(new Action(() =>
            {
                TreeNode tn = pForm1TreeView.FindNodeByName(tv.Nodes, d["hash"]);//返回节点
                TreeNode addtn = tn.Nodes.Add(hash, result["name"].ToString());//无刷新显示添加
                addtn.ImageIndex = 1; //设置显示图片
                addtn.SelectedImageIndex = 1;//设置显示图片
            }));

            int rows = addApiSql(hash, d["hash"], result["name"].ToString(), result["desc"].ToString(), result["url"].ToString(), result["urldata"].ToString(), result["method"].ToString(), serverHash);
            error = sqlite.error;
            return rows > 0 ? true : false;
        }
        /// <summary>
        /// 删除文档前数据
        /// </summary>
        public static Dictionary<string, string> webSocketDocumentDeleteResult = null;
        /// <summary>
        /// 删除文档
        /// </summary>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static bool webSocketDocumentDelete(string serverHash, TreeView tv)
        {
            webSocketDocumentDeleteResult = sqlite.getOne(string.Format("select *from {0} where server_hash='{1}'", table, serverHash));//输出删除前数据
            if (webSocketDocumentDeleteResult.Count <= 0) { error = "不存在文档"; return false; }
            int rows = sqlite.executeNonQuery(string.Format("delete from {0} where server_hash='{1}'", table, serverHash));//删除文档
            if (rows <= 0)
            {
                Form1.f.TextShowlogs("自动删除文档失败:" + serverHash, "error");
            }
            if (rows > 0)
            {
                tv.Invoke(new Action(() =>
                {
                    TreeNode tn = pForm1TreeView.FindNodeByName(tv.Nodes, webSocketDocumentDeleteResult["hash"]);//返回节点
                    tn.Remove();//删除节点
                }));
            }
            error = sqlite.error;
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 通过服务器hash获取项目或子项目
        /// </summary>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static Dictionary<string, string> getOneProjectSettingServerHash(string serverHash)
        {
            return sqlite.getOne(string.Format("select * from {0} where server_hash='{1}'", tableSetting, serverHash));
        }


        /// <summary>
        /// 通过hash获取项目或子项目
        /// </summary>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static Dictionary<string, string> getOneProjectSettingHash(string hash)
        {
            return sqlite.getOne(string.Format("select * from {0} where hash='{1}'", tableSetting, hash));
        }

        /// <summary>
        /// 判断projectSetting serverHash是否存在
        /// </summary>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static bool isOneProjectSettingServerHash(string serverHash)
        {
            Dictionary<string, string> d = getOneProjectSettingServerHash(serverHash);
            if (d == null) { return false; }
            if (d.Count <= 0) { return false; }
            return true;
        }

        public static JObject webSocketProjectCreateResult = null;

        /// <summary>
        /// 推送消息创建项目
        /// </summary>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static bool webSocketProjectCreate(string serverHash, TreeView tv)
        {
            JObject job = lib.pApizlHttp.getProjectInfo(serverHash);
            if (job == null) { error = lib.pApizlHttp.error; return false; }
            if (job["result"] == null) { error = lib.pApizlHttp.error; return false; }
            if (job["code"].ToString() != "1")
            {
                error = lib.pApizlHttp.error;
                Form1.f.TextShowlogs("自动创建项目失败:" + error, "error");
                return false;
            }
            string hash = lib.pBase.getHash();
            string nowHash = job["result"]["hash"].ToString();
            string pidHash = job["result"]["pid"].ToString();
            JObject result = (JObject)job["result"];
            webSocketProjectCreateResult = result;
            if (pidHash != "0")
            {
                Dictionary<string, string> d = getOneProjectSettingServerHash(pidHash);
                if (d == null) { error = "远程项目错误"; return false; }
                if (!isOneProjectSettingServerHash(nowHash))//判断是否存在  存在就不进行创建操作
                {
                    sqlite.executeNonQuery(string.Format("insert into {0} (hash,pid,sort,name,desc,server_hash,server_update,addtime)values('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", tableSetting, hash, d["hash"], 0, result["name"].ToString(), result["desc"].ToString(), result["hash"].ToString(), lib.pDate.getTimeStamp(), lib.pDate.getTimeStamp()));
                    tv.Invoke(new Action(() =>
                    {
                        TreeNode tn = pForm1TreeView.FindNodeByName(tv.Nodes, d["hash"]);//返回节点
                        TreeNode addtn = tn.Nodes.Add(hash, result["name"].ToString());//无刷新显示添加
                        addtn.ImageIndex = 0; //设置显示图片
                        addtn.SelectedImageIndex = 0;//设置显示图片
                    }));
                }
            }
            else
            {

            }
            return true;
        }

        /// <summary>
        /// 推送消息修改项目
        /// </summary>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static bool webSocketProjectUpdate(string serverHash, TreeView tv)
        {
            JObject job = lib.pApizlHttp.getProjectInfo(serverHash);
            if (job == null) { error = lib.pApizlHttp.error; return false; }
            if (job["result"] == null) { error = lib.pApizlHttp.error; return false; }
            if (job["code"].ToString() != "1")
            {
                error = lib.pApizlHttp.error;
                Form1.f.TextShowlogs("自动修改项目失败:" + error, "error");
                return false;
            }
            string nowHash = job["result"]["hash"].ToString();
            string pidHash = job["result"]["pid"].ToString();
            JObject result = (JObject)job["result"];
            webSocketProjectCreateResult = result;
            if (pidHash != "0")
            {
                Dictionary<string, string> d = getOneProjectSettingServerHash(pidHash);
                if (d == null) { error = "远程项目错误"; return false; }
                if (isOneProjectSettingServerHash(nowHash))//判断是否存在  存在就不进行创建操作
                {
                    sqlite.executeNonQuery(string.Format("update {0} set name='{1}',desc='{2}',sort='{3}' ,server_update='{4}' where server_hash='{5}'", tableSetting, result["name"].ToString(), result["desc"].ToString(), result["sort"].ToString(), lib.pDate.getTimeStamp(), serverHash));
                    tv.Invoke(new Action(() =>
                    {
                        Dictionary<string, string> nowResult = getOneProjectSettingServerHash(nowHash);
                        TreeNode tn = pForm1TreeView.FindNodeByName(tv.Nodes, nowResult["hash"]);//返回节点
                        tn.Text = result["name"].ToString();
                    }));
                }
                else
                {
                    error = "更新项目出错！";
                    return false;
                }
            }
            return true;
        }

        public static Dictionary<string, string> webSocketProjectDeleteResult;

        /// <summary>
        /// 推送消息删除项目
        /// </summary>
        /// <param name="serverHash"></param>
        /// <returns></returns>
        public static bool webSocketProjectDelete(string serverHash)
        {
            Dictionary<string, string> d = getOneProjectSettingServerHash(serverHash);
            webSocketProjectDeleteResult = d;
            if (d == null)
            {
                error = "项目错误";
                Form1.f.TextShowlogs("自动删除项目失败:" + error, "error");
                return false;
            }
            int rows = sqlite.executeNonQuery(string.Format("delete from {0} where server_hash='{1}'", tableSetting, serverHash));
            error = sqlite.error;
            return rows > 0 ? true : false;
        }
    }
}

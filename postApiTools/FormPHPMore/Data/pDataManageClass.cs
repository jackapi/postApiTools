using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// data数据库管理类
/// </summary>
namespace postApiTools.FormPHPMore.Data
{
    public class pDataManageClass
    {
        public static string dbPath = Config.dataPath + "data-manage.db";

        public static lib.pSqlite sqlite = new lib.pSqlite(dbPath);

        /// <summary>
        /// 错误信息
        /// </summary>
        public string error = "";

        /// <summary>
        /// 存储数据库表名
        /// </summary>
        public static string dataTable = "data_config";

        /// <summary>
        /// hash
        /// </summary>
        public string hash = "";

        /// <summary>
        /// 实例化
        /// </summary>
        public pDataManageClass()
        {
            sqlite.executeNonQuery("CREATE TABLE IF NOT EXISTS " + dataTable + "(hash varchar(200),name varchar(200),type  varchar(200), path varchar(200), ip varchar(2000),port varchar(200),username varchar(20000),password varchar(200),addtime integer);");//创建详情表
        }

        /// <summary>
        /// 添加sqlite到配置
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool addSqliteDataBase(string name, string path)
        {
            string hash = lib.pBase.getHash();
            this.hash = hash;
            string sql = string.Format("insert into {0} (hash,name,type,path,addtime)values('{1}','{2}','{3}','{4}','{5}')", dataTable, hash, name, DataBaseType.Sqlite, path, lib.pDate.getTimeStamp());
            bool b = sqlite.executeNonQuery(sql) > 0 ? true : false;
            error = sqlite.error;
            return b;
        }

        /// <summary>
        /// 添加sqlite到配置
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool addMysqlDataBase(string name, string ip, string port, string username, string password)
        {
            string hash = lib.pBase.getHash();
            this.hash = hash;
            string sql = string.Format("insert into {0} (hash,name,type,ip,port,username,password,addtime)values('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", dataTable, hash, name, DataBaseType.Mysql, ip, port, username, password, lib.pDate.getTimeStamp());
            bool b = sqlite.executeNonQuery(sql) > 0 ? true : false;
            error = sqlite.error;
            return b;
        }


        /// <summary>
        /// 获取所有数据库
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, object> getDataBaseAll()
        {
            Dictionary<int, object> d = sqlite.getRows(string.Format("select *from {0}", dataTable));
            error = sqlite.error;
            return d;
        }

        /// <summary>
        /// 获取表
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, object> getSqliteTable(string path)
        {
            Dictionary<int, object> list = new Dictionary<int, object> { };
            lib.pSqlite p = new lib.pSqlite(path);
            DataTable data = p.getTable();
            p.close();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Dictionary<string, string> d = new Dictionary<string, string> { };
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    d.Add(data.Columns[j].ToString(), data.Rows[i][j].ToString());
                }
                list.Add(i, d);
            }
            return list;
        }

        /// <summary>
        /// 修改数据库名称
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int updateDataBaseName(string hash, string name)
        {
            return sqlite.executeNonQuery(string.Format("update {0} set name='{1}' where hash='{2}'", dataTable, name, hash));
        }

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public Dictionary<string, string> getDataBaseHash(string hash)
        {
            return sqlite.getOne(string.Format("select *from {0} where hash='{1}'", dataTable, hash));
        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public int deleteDataBaseHash(string hash)
        {
            return sqlite.executeNonQuery(string.Format("delete from {0} where hash='{1}'", dataTable, hash));
        }
        /// <summary>
        /// 刷新treeview
        /// </summary>
        /// <param name="tv"></param>
        public void refreshTreeView(TreeView tv)
        {
            Dictionary<int, object> list = getDataBaseAll();
            tv.Invoke(new Action(() =>
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Dictionary<string, string> item = (Dictionary<string, string>)list[i];
                    TreeNode tn = pForm1TreeView.FindNodeByName(tv.Nodes, item["hash"]);
                    if (tn == null)
                    {
                        tv.Nodes.Add(item["hash"], item["type"] + " : " + item["name"]);
                    }
                }
            }));
        }


        /// <summary>
        /// 列表字段数据转json
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public string dToJson(Dictionary<int, object> d)
        {
            Dictionary<string, string> tableInfo = new Dictionary<string, string> { };
            if (d.Count <= 0) { return ""; }
            Dictionary<string, string> temp = (Dictionary<string, string>)d[0];
            foreach (var item in temp)
            {
                tableInfo.Add(item.Key, item.Value);
            }
            return pJson.objectToJsonStr(tableInfo);
        }
    }
}

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
        /// 创建表
        /// </summary>
        public static void create()
        {
            sqlite.executeNonQuery("CREATE TABLE IF NOT EXISTS " + table + "(hash varchar(200),project_id integer , name varchar(200), desc varchar(2000),url varchar(200),urldata varchar(20000),method varchar(200),addtime integer);");//创建详情表
            sqlite.executeNonQuery("CREATE TABLE IF NOT EXISTS " + tableSetting + "(hash varchar(200),pid integer ,sort integer , name varchar(200), desc varchar(2000),addtime integer);");//创建配置表
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
            Random r = new Random();
            string hash = lib.pBase.CreateMD5Hash(lib.pDate.getTimeStamp().ToString() + r.Next(10000, 99999).ToString());//生成hash
            string sql = "insert into " + tableSetting + "(hash,pid,sort,name,desc,addtime)values('{0}','{1}','{2}','{3}','{4}','{5}')";
            sql = string.Format(sql, hash, 0, 0, name, desc, lib.pDate.getTimeStamp());
            if (sqlite.executeNonQuery(sql) > 0)
            {
                return true;
            }
            error = sqlite.error;
            return false;
        }

        public static bool insertPid(string name, string hash)
        {
            return false;
        }
        /// <summary>
        /// 获取数据库中主要项目到二维数组
        /// </summary>
        /// <returns></returns>
        public static string[,] getAllToStringArray()
        {
            Dictionary<int, object> data = sqlite.getRows("select *from " + tableSetting + " order by sort ASC");
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
        /// 显示项目
        /// </summary>
        /// <param name="t"></param>
        public static void showMainData(TreeView t)
        {
            string[,] data = getAllToStringArray();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                t.Invoke(new Action(() => { t.Nodes.Add(data[i, 0]).Tag = data[i, 1]; }));
                //t.Nodes.Add(data[i, 0]);
            }
        }


        public delegate void CreateNodeDelegate();


    }
}

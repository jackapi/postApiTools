using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.FormClass
{
    using lib;
    public class pMemo
    {
        public static string error = "";
        /// <summary>
        /// memodb
        /// </summary>
        public static pSqlite sqlite = new pSqlite(Config.memoDb);
        /// <summary>
        /// 表名
        /// </summary>
        public const string table = "memo";

        public pMemo()
        {
            create();
        }
        /// <summary>
        /// 创建表
        /// </summary>
        public static void create()
        {
            sqlite.executeNonQuery("CREATE TABLE IF NOT EXISTS " + table + "(hash varchar(200),content varchar(200),click integer,addtime integer);");
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool insert(string content)
        {
            create();
            string getSql = string.Format("select *from {0} where content = '{1}'", table, content);
            Dictionary<string, string> t = sqlite.getOne(getSql);
            if (t.Count > 0)
            {
                return true;
            }
            string sql = "insert into {0} (hash,content,click,addtime)values('{1}','{2}',0,'{3}')";
            sql = string.Format(sql, table, pBase.getHash(), content, pDate.getTimeStamp());
            if (sqlite.executeNonQuery(sql) > 0)
            {
                return true;
            }
            error = sqlite.error;
            return false;
        }

        /// <summary>
        /// 删除所有
        /// </summary>
        /// <returns></returns>
        public static int deleteAll()
        {
            create();
            string sql = "delete from {0}";
            sql = string.Format(sql, table);
            return sqlite.executeNonQuery(sql);
        }
        /// <summary>
        /// 删除单个文件
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static int delete(string content)
        {
            create();
            string sql = "delete from {0} where content='{1}'";
            sql = string.Format(sql, table, content);
            return sqlite.executeNonQuery(sql);
        }
        /// <summary>
        /// 输出结果
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, object> getRows()
        {
            create();
            string sql = "select *from {0} order by click desc";
            sql = string.Format(sql, table);
            Dictionary<int, object> list = sqlite.getRows(sql);
            return list;
        }

        /// <summary>
        /// 更新click
        /// </summary>
        /// <param name="content"></param>
        /// <param name="click"></param>
        /// <returns></returns>
        public static int editClick(string content, int click = 1)
        {
            string sql = "";
            if (click == 1)
            {
                sql = string.Format("update {0} set click=click+1 where content= '{1}' ", table, content);
            }
            if (click == 0)
            {
                sql = string.Format("update {0} set click=0 where content= '{1}' ", table, content);
            }
            return sqlite.executeNonQuery(sql);
        }
    }
}

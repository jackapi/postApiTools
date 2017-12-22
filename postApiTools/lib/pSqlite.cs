using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// sqlite 类
/// by:(chenran)apiziliao@gmail.com
/// </summary>
namespace postApiTools.lib
{

    using System.Data.SQLite;
    public class pSqlite
    {

        /// <summary>
        /// 打开连接
        /// </summary>
        public SQLiteConnection conn = null;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string error = "";
        /// <summary>
        /// 实例化打开数据库
        /// </summary>
        /// <param name="path"></param>
        public pSqlite(string path = "")
        {
            if (path == "")
            {
                link();
            }
            else
            {
                conn = null;
                string dbPath = path;
                conn = new SQLiteConnection("data source=" + dbPath);
                conn.Open();
            }
        }

        public void link(string path = "")
        {
            if (path == "")
            {
                conn = new SQLiteConnection("data source=" + path);
                conn.Open();
            }
            if (conn == null)
            {
                conn = null;
                string dbPath = Config.exePath + "/web.db";
                conn = new SQLiteConnection("data source=" + dbPath);
                conn.Open();
            }
        }

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int executeNonQuery(string sql)
        {
            try
            {
                SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
                return cmdCreateTable.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.error = ex.ToString();
                pLogs.logs("sql:" + sql + " " + ex.ToString());
                return 0;
            }

        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int insert(string sql)
        {
            try
            {
                SQLiteCommand cmdInsert = new SQLiteCommand(conn);
                cmdInsert.CommandText = sql;
                return cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this.error = ex.ToString();
                pLogs.logs("sql:" + sql + " " + ex.ToString());
                return 0;
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Dictionary<int, object> getRows(string sql)
        {
            Dictionary<int, object> d = new Dictionary<int, object> { };
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                int rowI = 0;
                while (reader.Read())
                {
                    Dictionary<string, string> rowsList = new Dictionary<string, string> { };
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rowsList.Add(reader.GetName(i), reader[reader.GetName(i)].ToString());
                    }
                    d.Add(rowI, rowsList);
                    rowI++;
                }
                return d;
            }
            catch (Exception ex)
            {
                this.error = ex.ToString();
                pLogs.logs("sql:" + sql + " " + ex.ToString());
                return d;
            }
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Dictionary<string, string> getOne(string sql)
        {
            Dictionary<string, string> rowsList = new Dictionary<string, string> { };
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                int rowI = 0;
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rowsList.Add(reader.GetName(i), reader[reader.GetName(i)].ToString());
                    }
                    rowI++;
                    break;
                }
                return rowsList;
            }
            catch (Exception ex)
            {
                this.error = ex.ToString();
                pLogs.logs("sql:" + sql + " " + ex.ToString());
                return rowsList;
            }
        }
    }
}

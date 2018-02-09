using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// mysql
/// by:chenran (apiziliao@gmail.com)
/// </summary>
namespace postApiTools.lib
{
    using MySql.Data.MySqlClient;
    public class pMysql
    {
        MySqlConnection conn;

        public string error = "";
        public string Database = "";
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="databsse"></param>
        public pMysql(string ip, string port, string username, string password, string database, string encodingString = "utf8")
        {
            this.Database = database;
            string constructorString = string.Format("server={0};port={1};User Id='{2}';password='{3}';database='{4}';charset='{5}'", ip, port, username, password, database, encodingString);
            if (database == "")
            {
                constructorString = string.Format("server={0};port={1};User Id='{2}';password='{3}';database='{4}'", ip, port, username, password, database);
            }
            try
            {
                conn = new MySqlConnection(constructorString);
                conn.Open();
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }

        }
        /// <summary>
        /// 关闭
        /// </summary>
        public void close()
        {
            if (conn == null) { return; }
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
        }
        /// <summary>
        /// 判断是否打开
        /// </summary>
        /// <returns></returns>
        public bool isConnOpen()
        {
            try
            {
                if (conn == null) { return false; }
                if (conn.State == System.Data.ConnectionState.Open) { return true; }
                return false;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return false;
            }
        }

        /// <summary>
        /// 运行sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int executeNonQuery(string sql)
        {
            MySqlCommand myCmd = new MySqlCommand(sql, conn);
            return myCmd.ExecuteNonQuery();
        }

        /// <summary>
        ///  获取单个
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Dictionary<string, string> getOne(string sql)
        {
            Dictionary<string, string> rowsList = new Dictionary<string, string> { };
            MySqlCommand cmd = new MySqlCommand(sql, conn); //数据库查询
            MySqlDataReader dr = cmd.ExecuteReader();   //读出数据
            int rowI = 0;
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    rowsList.Add(dr.GetName(i), dr[dr.GetName(i)].ToString());
                }
                rowI++;
                break;
            }
            return rowsList;
        }

        /// <summary>
        ///  获取多个
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Dictionary<int, object> getRows(string sql)
        {
            Dictionary<int, object> d = new Dictionary<int, object> { };
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn); //数据库查询
                MySqlDataReader dr = cmd.ExecuteReader();   //读出数据
                int rowI = 0;
                while (dr.Read())
                {
                    Dictionary<string, string> rowsList = new Dictionary<string, string> { };
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        rowsList.Add(dr.GetName(i), dr[dr.GetName(i)].ToString());
                    }
                    d.Add(rowI, rowsList);
                    rowI++;
                }
                return d;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return d;
            }
        }

        /// <summary>
        /// 获取所有数据库
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, object> getDataBaseList()
        {
            return getRows("show databases;");
        }

        /// <summary>
        /// 获取所有表
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, object> getDataBaseTableList()
        {
            return getRows("SHOW TABLES;");
        }

        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, object> getTableInfo(string table)
        {
            return getRows(string.Format("select COLUMN_NAME as Field ,DATA_TYPE as Type,COLUMN_COMMENT as Content,IS_NULLABLE as IsNull,COLUMN_KEY as IsKey from information_schema.columns where table_schema ='{0}' and table_name = '{1}'", this.Database, table));

        }


        /// <summary>
        /// 获取查询指定表
        /// </summary>
        /// <param name="table"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public Dictionary<int, object> getTableListData(string table, string page = "0", string size = "1000")
        {
            string sql = string.Format("select *from {0} limit {1},{2}", table, page, size);
            return getRows(sql);
        }

    }
}

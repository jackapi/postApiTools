using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// SqlServer
/// by:chenran
/// </summary>
namespace postApiTools.lib
{
    using System.Data;
    using System.Data.SqlClient;
    public class pSqlServer
    {
        public SqlConnection conn;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string error = "";
        public pSqlServer()
        {
            try
            {
                //string constr = "server=.;database=myschool;integrated security=SSPI";
                string constr = "server=192.168.119.128:49156;database=test;uid=sa;pwd=121212";
                //string constr = "data source=.;initial catalog=myschool;user id=sa;pwd=sa";
                conn = new SqlConnection(constr);
                conn.Open();
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void close()
        {
            try
            {
                if (conn == null) { return; }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
            }
        }


        /// <summary>
        /// 运行sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int executeNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }


        /// <summary>
        ///  获取单个
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Dictionary<string, string> getOne(string sql)
        {
            Dictionary<string, string> rowsList = new Dictionary<string, string> { };
            SqlCommand cmd = new SqlCommand(sql, conn); //数据库查询
            SqlDataReader dr = cmd.ExecuteReader();   //读出数据
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
                SqlCommand cmd = new SqlCommand(sql, conn); //数据库查询
                SqlDataReader dr = cmd.ExecuteReader();   //读出数据
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
    }
}

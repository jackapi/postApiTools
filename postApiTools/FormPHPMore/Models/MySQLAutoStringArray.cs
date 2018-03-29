using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.FormPHPMore.Models
{
    public class MySQLAutoStringArray
    {
        /// <summary>
        /// 返回mysql sql 自动补全数组
        /// </summary>
        /// <returns></returns>
        public static string[] result(bool isIo = false)
        {
            if (isIo)
            {
                string content = lib.pFile.Read(Config.dataPath + "sqlAuto.txt");
                string[] array = System.Text.RegularExpressions.Regex.Split(content, @"\n{1,}");
                string[] temp = new string[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    string[] pid = array[i].Split('"');
                    if (pid.Length == 3)
                    {
                        temp[i] = pid[1];
                    }
                }
                return temp;
            }
            else
            {
                return new string[] {
                "select",
                "update",
                "insert",
                "delete",
                "from",
                "FROM",
                "into",
                "values",
                "set",
                "where",
                "and",
                "left",
                "join",
                "like",
                "union",
                "order by",
                "desc",
                "asc",
                "group by",
                "null",
                "not",
                "*",
            };
            }
        }
    }
}

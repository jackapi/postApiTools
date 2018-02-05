using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.FormPHPMore.Data
{
    public class pYiiMigrateType
    {
        /*const TYPE_PK = 'pk';
        const TYPE_UPK = 'upk';
        const TYPE_BIGPK = 'bigpk';
        const TYPE_UBIGPK = 'ubigpk';
        const TYPE_CHAR = 'char';
        const TYPE_STRING = 'string';
        const TYPE_TEXT = 'text';
        const TYPE_SMALLINT = 'smallint';
        const TYPE_INTEGER = 'integer';
        const TYPE_BIGINT = 'bigint';
        const TYPE_FLOAT = 'float';
        const TYPE_DOUBLE = 'double';
        const TYPE_DECIMAL = 'decimal';
        const TYPE_DATETIME = 'datetime';
        const TYPE_TIMESTAMP = 'timestamp';
        const TYPE_TIME = 'time';
        const TYPE_DATE = 'date';
        const TYPE_BINARY = 'binary';
        const TYPE_BOOLEAN = 'boolean';
        const TYPE_MONEY = 'money';
        */

        public static string Type(string type)
        {
            string result = "";
            type = type.ToLower();//转小写
            if (type.IndexOf("varchar") >= 0)//字符串
            {

                result = "TYPE_STRING.' NOT NULL'";
            }
            if (type.IndexOf("integer") >= 0)//int
            {

                result = "TYPE_INTEGER.' NOT NULL'";
            }
            if (type.IndexOf("char") >= 0)
            {

                result = "TYPE_CHAR.' NOT NULL'";
            }
            if (type.IndexOf("string") >= 0)
            {

                result = "TYPE_STRING.' NOT NULL'";
            }
            if (type.IndexOf("text") >= 0)
            {

                result = "TYPE_TEXT.' NOT NULL'";
            }
            if (type.IndexOf("smallint") >= 0)
            {

                result = "TYPE_SMALLINT.' NOT NULL'";
            }
            if (type.IndexOf("bigint") >= 0)
            {

                result = "TYPE_BIGINT.' NOT NULL'";
            }
            if (type.IndexOf("float") >= 0)
            {

                result = "TYPE_FLOAT.' NOT NULL'";
            }
            if (type.IndexOf("double") >= 0)
            {

                result = "TYPE_DOUBLE.' NOT NULL'";
            }
            if (type.IndexOf("decimal") >= 0)
            {

                result = "TYPE_DECIMAL.' NOT NULL'";
            }
            if (type.IndexOf("datetime") >= 0)
            {

                result = "TYPE_DATETIME.' NOT NULL'";
            }
            if (type.IndexOf("timestamp") >= 0)
            {

                result = "TYPE_TIMESTAMP.' NOT NULL'";
            }
            if (type.IndexOf("time") >= 0)
            {

                result = "TYPE_TIME.' NOT NULL'";
            }
            if (type.IndexOf("date") >= 0)
            {

                result = "TYPE_DATE.' NOT NULL'";
            }
            if (type.IndexOf("binary") >= 0)
            {

                result = "TYPE_BINARY.' NOT NULL'";
            }
            if (type.IndexOf("boolean") >= 0)
            {

                result = "TYPE_BOOLEAN.' NOT NULL'";
            }
            if (type.IndexOf("money") >= 0)
            {

                result = "TYPE_MONEY.' NOT NULL'";
            }
            return result;
        }


        public static string ReturnType(string type)
        {
            string result = "";
            type = type.ToLower();//转小写
            if (type.IndexOf("integer") >= 0)//int
            {

                result = "integer";
            }
            if (type.IndexOf("int") >= 0)//int
            {

                result = "integer";
            }
            if (type.IndexOf("char") >= 0)
            {

                result = "char";
            }
            if (type.IndexOf("varchar") >= 0)//字符串
            {

                result = "varchar";
            }
            if (type.IndexOf("string") >= 0)
            {

                result = "string";
            }
            if (type.IndexOf("text") >= 0)
            {

                result = "text";
            }
            if (type.IndexOf("smallint") >= 0)
            {

                result = "smallint";
            }
            if (type.IndexOf("bigint") >= 0)
            {

                result = "bigint";
            }
            if (type.IndexOf("float") >= 0)
            {

                result = "float";
            }
            if (type.IndexOf("double") >= 0)
            {

                result = "double";
            }
            if (type.IndexOf("decimal") >= 0)
            {

                result = "decimal";
            }
            if (type.IndexOf("date") >= 0)
            {

                result = "date";
            }
            if (type.IndexOf("datetime") >= 0)
            {

                result = "datetime";
            }
            if (type.IndexOf("timestamp") >= 0)
            {

                result = "timestamp";
            }
            if (type.IndexOf("time") >= 0)
            {

                result = "time";
            }
            if (type.IndexOf("binary") >= 0)
            {

                result = "binary";
            }
            if (type.IndexOf("boolean") >= 0)
            {

                result = "boolean";
            }
            if (type.IndexOf("money") >= 0)
            {

                result = "money";
            }
            return result;
        }
    }
}

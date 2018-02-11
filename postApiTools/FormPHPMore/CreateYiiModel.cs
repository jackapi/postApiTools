using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.FormPHPMore
{
    using CCWin;
    using FastColoredTextBoxNS;
    public partial class CreateYiiModel : CCSkinMain
    {
        string hash = "";
        string tableName = "";//表名
        Dictionary<int, object> CreateTableInfoList = new Dictionary<int, object> { };

        /// <summary>
        /// 场景常量
        /// </summary>
        List<Models.YiiConstScenario> ModelsScenarioConstList = new List<Models.YiiConstScenario>();
        public CreateYiiModel(string hash)
        {
            InitializeComponent();
            this.hash = hash;
        }
        /// <summary>
        /// 启动加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateYiiModel_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.hash == "")
                {
                    return;
                }
                string[] array = hash.Split('|');
                if (array.Length < 4)
                {
                    return;
                }
                tableName = array[3];
                if (array[1] == "table" && array[2] == Data.DataBaseType.Sqlite.ToString())//sqlite数据库
                {
                    sqliteLoad(array[0], array[3]);//加载sqlite表结构
                    textBox_model_name.Text = array[3];//自动加载表名
                }

                if (array[1] == "mysql_table" && array[2] == Data.DataBaseType.Mysql.ToString())//mysql数据库
                {
                    mysqlLoad(array[0], array[3], array[4]);//mysql表结构
                    textBox_model_name.Text = array[4];//自动加载表名
                    tableName = array[4];
                }
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
            }
        }
        /// <summary>
        /// 加载mysql表结构
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="database"></param>
        /// <param name="table"></param>
        public void mysqlLoad(string hash, string database, string table)
        {
            Data.pDataManageClass pData = new Data.pDataManageClass();
            Dictionary<string, string> d = pData.getDataBaseHash(hash);
            lib.pMysql mysql = new lib.pMysql(d["ip"], d["port"], d["username"], d["password"], database);
            showDataGridViewDictionary(mysql.getTableInfo(table), Data.DataBaseType.Mysql);
        }

        /// <summary>
        /// 加载sqlite表结构
        /// </summary>
        /// <param name="hash"></param>
        public void sqliteLoad(string hash, string table)
        {
            Data.pDataManageClass pData = new Data.pDataManageClass();
            Dictionary<string, string> d = pData.getDataBaseHash(hash);
            if (d.Count <= 0) { return; }
            lib.pSqlite sqlite = new lib.pSqlite(d["path"]);
            showDataGridViewDictionary(sqlite.getTableInfo(table), Data.DataBaseType.Sqlite);
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="tableListInfo"></param>
        public void showDataGridViewDictionary(Dictionary<int, object> tableListInfo, Data.DataBaseType type)
        {

            dataGridView_table_info.BeginInvoke(new Action(() =>
            {
                if (tableListInfo.Count <= 0) { return; }
                dataGridView_table_info.Rows.Clear();
                dataGridView_table_info.Rows.Add(tableListInfo.Count);
                for (int i = 0; i < tableListInfo.Count; i++)
                {
                    Dictionary<string, string> data = new Dictionary<string, string> { };
                    Dictionary<string, string> temp = (Dictionary<string, string>)tableListInfo[i];
                    if (type == Data.DataBaseType.Sqlite)
                    {
                        dataGridView_table_info.Rows[i].Cells[0].Value = temp["name"];
                        dataGridView_table_info.Rows[i].Cells[1].Value = temp["type"];
                        data.Add("name", temp["name"]);
                        data.Add("type", temp["type"]);
                    }
                    if (type == Data.DataBaseType.Mysql)
                    {
                        dataGridView_table_info.Rows[i].Cells[0].Value = temp["Field"];
                        dataGridView_table_info.Rows[i].Cells[1].Value = temp["Type"];
                        data.Add("name", temp["Field"]);
                        data.Add("type", temp["Type"]);
                        data.Add("content", temp["Content"]);
                        data.Add("isnull", temp["IsNull"]);
                        data.Add("iskey", temp["IsKey"]);
                    }
                    CreateTableInfoList.Add(i, data);//添加到主列
                }
            }));
        }

        /// <summary>
        /// 生成YII模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_create_Click(object sender, EventArgs e)
        {
            string modelName = textBox_model_name.Text;
            string content = lib.pFile.Read(Config.dataPath + "yii-models.txt");
            content = content.Replace("{$model-name-f}", NameF(modelName));
            content = content.Replace("{$model-name}", modelName);
            content = YiiTabelInfoProperty(content);//字段输出
            content = YiiTableScenario(content);//场景常量输出 以及场景输出
            content = AttributeLabels(content);//生成表结构以及注释
            content = Fields(content);//字段映射
            content = Rules(content);//规则验证生成
            fastColoredTextBox_result.BeginInvoke(new Action(() =>
            {
                fastColoredTextBox_result.Clear();
                fastColoredTextBox_result.Language = Language.PHP;
                fastColoredTextBox_result.Text = content;
            }));
        }

        /// <summary>
        /// 生成注释备注
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string YiiTabelInfoProperty(string content)
        {
            string temp = "";
            for (int i = 0; i < CreateTableInfoList.Count; i++)
            {
                Dictionary<string, string> d = (Dictionary<string, string>)CreateTableInfoList[i];
                temp += string.Format("* @property {0} ${1}\r\n", Data.pYiiMigrateType.ReturnType(d["type"]), d["name"]);
            }
            return content.Replace("{$model-table-info-property}", temp);
        }

        /// <summary>
        /// 场景常量及其场景生成
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string YiiTableScenario(string content)
        {
            string temp = "";
            ModelsScenarioConstList.Add(new Models.YiiConstScenario { Const = "SCENARIO_LOGIN", String = "login", Description = "登陆" });
            ModelsScenarioConstList.Add(new Models.YiiConstScenario { Const = "SCENARIO_ADD", String = "add", Description = "添加数据" });
            ModelsScenarioConstList.Add(new Models.YiiConstScenario { Const = "SCENARIO_UPDATE", String = "update", Description = "更新数据" });
            ModelsScenarioConstList.Add(new Models.YiiConstScenario { Const = "SCENARIO_DELETE", String = "delete", Description = "删除数据" });
            for (int i = 0; i < ModelsScenarioConstList.Count; i++)
            {
                temp += string.Format("/**\r\n* {2} \r\n*/ \r\n  const {0} = '{1}';\r\n ", ModelsScenarioConstList[i].Const, ModelsScenarioConstList[i].String, ModelsScenarioConstList[i].Description);
            }
            content = content.Replace("{$const}", temp);
            //生成操作字段场景
            string scenarios = "\t//场景需要验证操作的字段\r\n";//场景
            for (int i = 0; i < ModelsScenarioConstList.Count; i++)
            {
                scenarios += string.Format("\tself::{0} => [],//{1}\r\n", ModelsScenarioConstList[i].Const, ModelsScenarioConstList[i].Description);
            }

            content = content.Replace("{$scenarios}", scenarios);
            return content;
        }

        /// <summary>
        /// 生成表结构以及注释
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string AttributeLabels(string content)
        {
            string temp = "";
            try
            {
                for (int i = 0; i < CreateTableInfoList.Count; i++)
                {
                    Dictionary<string, string> d = (Dictionary<string, string>)CreateTableInfoList[i];
                    if (d.ContainsKey("content"))
                    {
                        if (d["content"].Length > 0)
                        {
                            temp += string.Format("\t'{0}' => '{1}',//{2}\r\n", d["name"], d["content"], d["content"]);
                        }
                        else
                        {
                            temp += string.Format("\t'{0}' => '{1}',//{2}\r\n", d["name"], d["name"], d["name"]);
                        }
                    }
                }
            }
            catch (Exception ex) { pLogs.logs(ex.ToString()); }
            content = content.Replace("{$attributeLabels}", temp);
            return content;
        }

        /// <summary>
        /// 字段映射
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string Fields(string content)
        {

            string temp = "";
            try
            {
                for (int i = 0; i < CreateTableInfoList.Count; i++)
                {
                    Dictionary<string, string> d = (Dictionary<string, string>)CreateTableInfoList[i];
                    if (d.ContainsKey("content"))
                    {
                        temp += string.Format("\t\t'{0}',//{1} {2}\r\n", d["name"], d["name"], d["content"]);
                    }
                }
            }
            catch (Exception ex) { pLogs.logs(ex.ToString()); }
            content = content.Replace("{$fields}", temp);
            return content;
        }
        /// <summary>
        /// 规则验证生成
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string Rules(string content)
        {
            string temp = "";
            List<string> required = new List<string>();//必填
            try
            {
                for (int i = 0; i < CreateTableInfoList.Count; i++)
                {
                    Dictionary<string, string> d = (Dictionary<string, string>)CreateTableInfoList[i];
                    if (d.ContainsKey("isnull"))
                    {

                        if (d["isnull"].ToLower() == "no")
                        {
                            if (d["iskey"].Length > 0) { continue; }
                            required.Add(d["name"]);//添加必填
                        }
                    }
                }
                if (required.Count > 0)
                {
                    temp += string.Format("\t\t[{0}, 'required'],//{1} \r\n", lib.pJsonData.objectToString(required), "必须有值");
                }
            }
            catch (Exception ex) { pLogs.logs(ex.ToString()); }
            content = content.Replace("{$rules}", temp);
            return content;
        }
        /// <summary>
        /// 名称驼峰
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string NameF(string name)
        {
            string[] array = name.Split('_');
            if (array.Length == 1)
            {
                return array[0].Substring(0, 1).ToUpper() + array[0].Substring(1, array[0].Length - 1);
            }
            if (array.Length > 1)
            {
                string temp = "";
                for (int i = 0; i < array.Length; i++)
                {
                    temp += array[i].Substring(0, 1).ToUpper() + array[i].Substring(1, array[i].Length - 1);
                }
                return temp;

            }
            return "";
        }
    }
}

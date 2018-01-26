using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// yii迁移生成
/// </summary>
namespace postApiTools.FormPHPMore
{
    using CCWin;
    using FastColoredTextBoxNS;
    using System.IO;
    using System.Text.RegularExpressions;

    public partial class CreateYiiMigrate : CCSkinMain
    {

        string hash = "";//选中的hash
        string tableName = "";//表名

        public CreateYiiMigrate(string hash)
        {
            InitializeComponent();
            this.hash = hash;
        }

        Dictionary<int, object> CreateTableInfoList = new Dictionary<int, object> { };

        /// <summary>
        /// 启动加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateYiiMigrate_Load(object sender, EventArgs e)
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
                textBox_model_name.Text = array[3];//自动加载表名
            }

            textBox_yii_path.Text = lib.pIni.read("database", "yii_path");//加载
            textBox_php_path.Text = lib.pIni.read("database", "php_path");//加载
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

            dataGridView_table_info.Invoke(new Action(() =>
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
                    }
                    CreateTableInfoList.Add(i, data);//添加到主列
                }
            }));
        }


        /// <summary>
        /// 生成模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_create_Click(object sender, EventArgs e)
        {
            string modelName = textBox_model_name.Text;
            string yiiPath = textBox_yii_path.Text;
            string phpPath = textBox_php_path.Text;
            if (yiiPath == "")
            {
                MessageBox.Show("请先选择Yii路径", "提示");
                return;
            }
            if (modelName == "")
            {
                MessageBox.Show("模型名称不能为空！请用驼峰命名！", "提示");
                return;
            }
            if (modelName.IndexOf("_") > 0)
            {
                MessageBox.Show("模型名称不能包含下划线！", "提示");
                return;
            }
            if (!File.Exists(yiiPath))
            {
                MessageBox.Show("Yii不存在！", "提示");
                return;
            }
            if (!File.Exists(phpPath))
            {
                MessageBox.Show("PHP不存在！", "提示");
                return;
            }
            lib.pIni.write("database", "yii_path", yiiPath);
            lib.pIni.write("database", "php_path", phpPath);
            string path = Path.GetDirectoryName(yiiPath) + "/";//目录切换
            string cmd = string.Format("echo yes | {2} {1}yii migrate/create {0}", modelName, path, phpPath);
            string batPath = Config.exePath + "/runtime/yiimigrate.bat";
            lib.pFile.Write(batPath, cmd, "GBK");
            string cmdResult = lib.pProcess.ExeCommand(batPath);
            if (cmdResult.IndexOf("New migration created successfully") < 0)
            {
                MessageBox.Show("创建失败！", "提示");
                return;
            }
            Regex reg = new Regex(@"'(.*)'");
            var result = reg.Match(cmdResult).Groups;
            if (result.Count <= 0)
            {
                MessageBox.Show("创建失败！", "提示");
                return;
            }
            string yiiMigratePath = result[0].Value.ToString();//路径
            yiiMigratePath = yiiMigratePath.Substring(1, yiiMigratePath.Length - 2);
            string yiiMigrate = lib.pFile.Read(yiiMigratePath);//读取文件
            yiiMigrate = up(yiiMigrate);
            lib.pFile.Write(yiiMigratePath, yiiMigrate, "UTF-8");
            showResultYii(yiiMigrate);//显示处理结果
        }

        /// <summary>
        /// 结果输出
        /// </summary>
        /// <param name="yiiMigrate"></param>
        public void showResultYii(string yiiMigrate)
        {
            fastColoredTextBox_result.Language = Language.PHP;
            fastColoredTextBox_result.Text = yiiMigrate;
        }

        /// <summary>
        /// up
        /// </summary>
        /// <param name="yiiMigrate"></param>
        /// <returns></returns>
        public string up(string yiiMigrate)
        {
            yiiMigrate = yiiMigrate.Replace("use yii\\db\\Migration;", "use yii\\db\\Schema;\r\nuse yii\\db\\Migration; ");//use
            string tableClass = "";
            for (int i = 0; i < CreateTableInfoList.Count; i++)
            {
                Dictionary<string, string> d = (Dictionary<string, string>)CreateTableInfoList[i];
                tableClass += string.Format("\r\n'{0}'=> Schema::{1},", d["name"], Data.pYiiMigrateType.Type(d["type"]));

            }
            string upString = string.Format("$this->createTable('{1}', [{0}\r\n]); ", tableClass, this.tableName);//迁移
            yiiMigrate = yiiMigrate.Replace("/*", " public function up()\r\n     {\r\n    " + upString + " \r\n     }\r\n\r\n/*");
            return yiiMigrate;
        }

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox_yii_path.Text = ofd.FileName;
            }
        }


        /// <summary>
        /// 选择PHP文件
        /// </summary>
        /// <param name="sender"></param>
        /// <pa
        private void button_php_path_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox_php_path.Text = ofd.FileName;
            }

        }
    }
}

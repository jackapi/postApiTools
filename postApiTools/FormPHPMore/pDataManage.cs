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
/// 数据库管理
/// </summary>
namespace postApiTools.FormPHPMore
{
    using CCWin;
    using System.IO;
    using System.Threading;

    public partial class pDataManage : CCSkinMain
    {
        public static CCSkinMain f;
        public pDataManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选中数据
        /// </summary>
        public string treeviewSelectHash = "";

        /// <summary>
        /// 输出数据
        /// </summary>
        Dictionary<int, object> tableListData = new Dictionary<int, object> { };

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pMysqlManage_Load(object sender, EventArgs e)
        {
            f = this;
            showTreeView();
        }

        public void showTreeView()
        {
            Data.pDataManageClass p = new Data.pDataManageClass();
            TreeView tv = treeView_database;
            Dictionary<int, object> list = p.getDataBaseAll();
            tv.Invoke(new Action(() =>
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Dictionary<string, string> item = (Dictionary<string, string>)list[i];
                    tv.Nodes.Add(item["hash"], item["type"] + " : " + item["name"]);
                }
            }));
        }

        /// <summary>
        /// 添加数据库到treeview
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="name"></param>
        public void addMianTreeView(string hash, string name)
        {
            treeView_database.Nodes.Add(hash, name);
        }

        /// <summary>
        /// 添加SQLITE数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sqliteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.addSqlite add = new Data.addSqlite(treeView_database);
            add.ShowDialog();
        }
        /// <summary>
        /// add database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_add_database_Click(object sender, EventArgs e)
        {
            this.skinContextMenuStrip_add_database.Show(MousePosition);
        }

        /// <summary>
        /// 双击treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_database_DoubleClick(object sender, EventArgs e)
        {
            treeView_database_DoubleClickFun();
            //Thread th = new Thread(treeView_database_DoubleClickFun);
            //th.Start();
        }

        public void treeView_database_DoubleClickFun()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Data.pDataManageClass p = new Data.pDataManageClass();
                TreeView tv = treeView_database;
                this.treeviewSelectHash = "";
                if (tv.SelectedNode == null)
                {
                    this.Cursor = Cursors.Default; return;
                }
                string hash = tv.SelectedNode.Name;
                this.treeviewSelectHash = hash;
                Dictionary<string, string> database = p.getDataBaseHash(hash);
                if (database.Count > 0)//是数据库
                {
                    if (database["type"] == Data.DataBaseType.Sqlite.ToString())//sqlite
                    {
                        if (!File.Exists(database["path"]))
                        {
                            MessageBox.Show("数据库不存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        showSqliteTreeViewTableList(tv, hash, database);
                        return;
                    }
                    if (database["type"] == Data.DataBaseType.Mysql.ToString())//mysql
                    {
                        lib.pMysql mysql = new lib.pMysql(database["ip"], database["port"], database["username"], database["password"], "");
                        if (!mysql.isConnOpen())
                        {
                            MessageBox.Show("无法打开数据库!" + mysql.error, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Cursor = Cursors.Default; return;
                        }
                        showMysqlTreeViewTableList(tv, hash, database, mysql);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                string[] array = hash.Split('|');
                if (array.Length < 2)
                {
                    this.Cursor = Cursors.Default; return;
                }
                if (array[1] == "table")//打开表
                {
                    Dictionary<string, string> list = p.getDataBaseHash(array[0]);
                    if (list.Count <= 0)
                    {
                        this.Cursor = Cursors.Default; return;
                    }
                    if (list["type"] == Data.DataBaseType.Sqlite.ToString())//sqlite
                    {
                        lib.pSqlite sqlite = new lib.pSqlite(list["path"]);
                        Dictionary<int, object> tableList = sqlite.getTableListData(array[3]);
                        showDataViewTableListData(tableList);
                    }
                }
                if (array[1] == "mysql_database")//打开mysql数据库显示表
                {
                    database = p.getDataBaseHash(array[0]);
                    string databaseName = array[3];//数据库
                    lib.pMysql mysql = new lib.pMysql(database["ip"], database["port"], database["username"], database["password"], databaseName);
                    showMysqlTableTreeViewTableList(treeView_database, array[0], database, mysql, databaseName);
                    mysql.close();
                }
                if (array[1] == "mysql_table")//打开mysql表
                {
                    database = p.getDataBaseHash(array[0]);
                    string databaseName = array[3];//数据库
                    string table = array[4];//数据库
                    lib.pMysql mysql = new lib.pMysql(database["ip"], database["port"], database["username"], database["password"], databaseName);
                    if (!mysql.isConnOpen())
                    {
                        MessageBox.Show("操作不正常");
                        this.Cursor = Cursors.Default; return;
                    }
                    Dictionary<int, object> tableList = mysql.getTableListData(table);
                    showDataViewTableListData(tableList);
                }
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
                this.Cursor = Cursors.Default;
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 输出mysql表到树
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="hash"></param>
        /// <param name="database"></param>
        /// 
        public void showMysqlTableTreeViewTableList(TreeView tv, string hash, Dictionary<string, string> database, lib.pMysql mysql, string table)
        {
            Dictionary<int, object> list = mysql.getDataBaseTableList();
            if (list.Count <= 0)
            {
                return;
            }
            tv.Invoke(new Action(() =>
            {
                TreeNode tn = tv.SelectedNode;
                for (int i = 0; i < list.Count; i++)
                {
                    Dictionary<string, string> d = new Dictionary<string, string> { };
                    d = (Dictionary<string, string>)list[i];
                    string pidHash = hash + "|mysql_table|" + Data.DataBaseType.Mysql.ToString() + "|" + table + "|" + d["Tables_in_" + table];
                    TreeNode pidTn = pForm1TreeView.FindNodeByName(tn.Nodes, pidHash);
                    if (pidTn != null) { return; }
                    TreeNode show = tn.Nodes.Add(pidHash, d["Tables_in_" + table]);
                    show.ImageIndex = 1;
                    show.SelectedImageIndex = 1;
                    show.ContextMenuStrip = contextMenuStrip_table;
                }
            }));
        }

        /// <summary>
        /// 输出mysql数据库的树
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="hash"></param>
        /// <param name="database"></param>
        public void showMysqlTreeViewTableList(TreeView tv, string hash, Dictionary<string, string> database, lib.pMysql mysql)
        {
            Dictionary<int, object> list = mysql.getDataBaseList();
            if (list.Count <= 0)
            {
                return;
            }
            tv.Invoke(new Action(() =>
            {
                TreeNode tn = tv.SelectedNode;
                for (int i = 0; i < list.Count; i++)
                {
                    Dictionary<string, string> d = new Dictionary<string, string> { };
                    d = (Dictionary<string, string>)list[i];
                    string pidHash = hash + "|mysql_database|" + Data.DataBaseType.Mysql.ToString() + "|" + d["Database"];
                    TreeNode pidTn = pForm1TreeView.FindNodeByName(tn.Nodes, pidHash);
                    if (pidTn != null) { return; }
                    TreeNode show = tn.Nodes.Add(pidHash, d["Database"]);
                    show.ImageIndex = 2;
                    show.SelectedImageIndex = 2;
                }
            }));
        }

        /// <summary>
        /// 输出包含表的树
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="hash"></param>
        /// <param name="database"></param>
        public void showSqliteTreeViewTableList(TreeView tv, string hash, Dictionary<string, string> database)
        {
            Data.pDataManageClass p = new Data.pDataManageClass();
            Dictionary<int, object> list = p.getSqliteTable(database["path"]);
            if (list.Count <= 0)
            {
                return;
            }
            TreeNode tn = tv.SelectedNode;
            for (int i = 0; i < list.Count; i++)
            {
                Dictionary<string, string> d = new Dictionary<string, string> { };
                d = (Dictionary<string, string>)list[i];
                string pidHash = hash + "|table|" + Data.DataBaseType.Sqlite.ToString() + "|" + d["TABLE_NAME"];
                TreeNode pidTn = pForm1TreeView.FindNodeByName(tn.Nodes, pidHash);
                if (pidTn != null) { return; }
                TreeNode show = tn.Nodes.Add(pidHash, d["TABLE_NAME"]);
                show.ImageIndex = 1;
                show.SelectedImageIndex = 1;
            }
        }


        /// <summary>
        /// treeview 右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinContextMenuStrip_treeview_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            skinContextMenuStrip_treeview.Close();//关闭
            if (e.ClickedItem == null)
            {
                return;
            }
            if (e.ClickedItem.ToString() == "删除数据库")
            {
                string hash = treeView_database.SelectedNode.Name;
                string[] array = hash.Split('|');
                if (array.Length <= 1)
                {
                    return;
                }
                string database = treeView_database.SelectedNode.Text;
                if (MessageBox.Show("删除" + database + "?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) { return; }
                Data.pDataManageClass p = new Data.pDataManageClass();
                Dictionary<string, string> d = p.getDataBaseHash(hash);
                if (d.Count <= 0) { return; }
                if (p.deleteDataBaseHash(hash) > 0)
                {
                    treeView_database.SelectedNode.Remove();//删除节点
                }
                else
                {
                    MessageBox.Show(p.error, "提示");
                    return;
                }

            }
            else if (e.ClickedItem.ToString() == "重命名")
            {
                string hash = treeView_database.SelectedNode.Name;
                string name = treeView_database.SelectedNode.Text;
                string[] array = hash.Split('|');
                if (array.Length == 1)
                {
                    string[] nameArray = name.Split(':');
                    Data.pRen ren = new Data.pRen(hash, nameArray[1].Trim());
                    ren.ShowDialog();//重命名
                    if (ren.result)
                    {
                        treeView_database.SelectedNode.Text = nameArray[0] + ": " + ren.name;
                    }
                    else
                    {
                        MessageBox.Show(ren.error, "提示");
                    }
                }
            }
            else if (e.ClickedItem.ToString() == "关闭")
            {

                TreeNode tn = treeView_database.SelectedNode;
                tn.Nodes.Clear();//关闭
            }
            else if (e.ClickedItem.ToString() == "重命名")
            {

            }
        }

        /// <summary>
        /// 动态输出
        /// </summary>
        /// <param name="list"></param>
        public void showDataViewTableListData(Dictionary<int, object> list)
        {
            try
            {
                skinTabPage1.Controls.Clear();
                DataGridView dgv = new DataGridView();

                if (list.Count <= 0)
                {
                }
                else
                {
                    tableListData = list;
                    Dictionary<string, string> d = (Dictionary<string, string>)list[0];
                    foreach (var item in d)
                    {
                        dgv.Columns.Add(item.Value, item.Key);
                    }
                    dgv.Rows.Clear();//清理行数
                    dgv.Rows.Add(list.Count);
                    for (int i = 0; i < list.Count; i++)
                    {
                        Dictionary<string, string> item = (Dictionary<string, string>)list[i];
                        object[] arr = new object[item.Count];
                        int g = 0;
                        foreach (var value in item)
                        {
                            dgv.Rows[i].Cells[g].Value = value.Value;
                            g++;
                        }
                    }
                }
                Label label = new Label();
                string table = treeView_database.SelectedNode.Text;
                label.Text = table;
                label.Location = new Point(5, 10);//绘制
                skinTabPage1.Controls.Add(label);
                dgv.Location = new Point(0, 40);//绘制
                dgv.Width = skinTabPage1.Width;
                dgv.Height = skinTabPage1.Height - 50;
                dgv.ContextMenuStrip = this.skinContextMenuStrip_table_create_tools;
                skinTabPage1.Controls.Add(dgv);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 右键功能选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinContextMenuStrip_table_create_tools_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null) { return; }

            if (e.ClickedItem.ToString() == "Yii生成模型")
            {
                CreateYiiModel model = new CreateYiiModel(treeviewSelectHash);
                model.Show();
            }

            if (e.ClickedItem.ToString() == "Yii迁移数据")
            {
                CreateYiiMigrate model = new CreateYiiMigrate(treeviewSelectHash);
                model.Show();
            }

            if (e.ClickedItem.ToString() == "转POST参数")
            {
                Data.pDataManageClass p = new Data.pDataManageClass();
                FormAll.pStringUrlDataTo to = new FormAll.pStringUrlDataTo();
                to.Show();
                to.showContent(p.dToJson(tableListData));
            }
        }

        /// <summary>
        /// 添加MySQL数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mysqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.addMysql p = new Data.addMysql();
            p.ShowDialog();
            Data.pDataManageClass data = new Data.pDataManageClass();
            data.refreshTreeView(treeView_database);//刷新
        }

        /// <summary>
        /// 运行sql
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_run_sql_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 右键操作表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_table_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null) { return; }
        }
        /// <summary>
        /// 添加Oracle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("敬请期待");
        }
        /// <summary>
        /// 添加mssql
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mssqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("敬请期待");
        }
    }
}

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
        public string treeviewSelect = "";

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
            Data.pDataManageClass p = new Data.pDataManageClass();
            TreeView tv = treeView_database;
            this.treeviewSelect = "";
            if (tv.SelectedNode == null) { return; }
            string hash = tv.SelectedNode.Name;
            this.treeviewSelect = hash;
            Dictionary<string, string> database = p.getDataBaseHash(hash);
            if (database.Count > 0)//是数据库
            {
                if (database["type"] == Data.DataBaseType.Sqlite.ToString())
                {
                    if (!File.Exists(database["path"])) { MessageBox.Show("数据库不存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    showTreeViewTableList(tv, hash, database);
                    return;
                }
            }
            string[] array = hash.Split('|');
            if (array.Length < 2) { return; }
            if (array[1] == "table")//打开表
            {
                Dictionary<string, string> list = p.getDataBaseHash(array[0]);
                if (list.Count <= 0) { return; }
                if (list["type"] == Data.DataBaseType.Sqlite.ToString())//sqlite
                {
                    lib.pSqlite sqlite = new lib.pSqlite(list["path"]);
                    Dictionary<int, object> tableList = sqlite.getTableListData(array[3]);
                    showDataView(tableList);
                }
            }
        }

        public void showTreeViewTableList(TreeView tv, string hash, Dictionary<string, string> database)
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
            if (e.ClickedItem == null)
            {
                return;
            }
            if (e.ClickedItem.ToString() == "删除数据库")
            {
            }
        }

        public void showDataView(Dictionary<int, object> list)
        {
            skinTabPage1.Controls.Clear();
            DataGridView dgv = new DataGridView();
            if (list.Count <= 0) { return; }
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
            dgv.Width = skinTabPage1.Width;
            dgv.Height = skinTabPage1.Height - 50;
            skinTabPage1.Controls.Add(dgv);

            //d.Invoke(new Action(() =>
            //{
            //    d.Rows.Clear();
            //    for ()
            //    {

            //    }

            //}));
        }
    }
}

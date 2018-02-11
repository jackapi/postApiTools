using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.FormPHPMore.Data
{
    using CCWin;
    public partial class createDatabase : CCSkinMain
    {
        string hash = "";
        public createDatabase(string hash)
        {
            InitializeComponent();
            this.hash = hash;
        }
        /// <summary>
        /// 加载提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createDatabase_Load(object sender, EventArgs e)
        {
            string[] array = this.hash.Split('|');
            if (array.Length > 1)
            {
                MessageBox.Show("创建位置错误!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_create_Click(object sender, EventArgs e)
        {
            TreeView tv = pDataManage.f.getTreeView();
            string name = textBox_name.Text;
            string encoding = textBox_encoding.Text;
            if (name == "")
            {
                MessageBox.Show("数据库名称不能为空!", "提示");
                return;
            }
            Data.pDataManageClass p = new pDataManageClass();
            Dictionary<string, string> database = p.getDataBaseHash(this.hash);
            if (database.Count <= 0)
            {
                MessageBox.Show("找不到相关配置!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lib.pMysql mysql = new lib.pMysql(database["ip"], database["port"], database["username"], database["password"], "", encoding);
            //CREATE DATABASE IF NOT EXISTS yourdbname DEFAULT CHARSET utf8 COLLATE utf8_general_ci;
            string sql = string.Format("CREATE DATABASE IF NOT EXISTS {0} DEFAULT CHARSET {1} COLLATE {2}", name, encoding, encoding + "_general_ci");
            if (mysql.executeNonQuery(sql) > 0)
            {
                tv.BeginInvoke(new Action(() =>
                {
                    TreeNode tn = pForm1TreeView.FindNodeByName(tv.Nodes, this.hash);
                    TreeNode pid = tn.Nodes.Add(name);
                    pid.ImageIndex = 2;
                    pid.SelectedImageIndex = 2;
                }));
                this.Close();
            }
            else
            {
                MessageBox.Show("创建失败!\r\n" + mysql.error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

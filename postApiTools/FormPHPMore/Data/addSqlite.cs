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
    using System.IO;

    public partial class addSqlite : CCSkinMain
    {

        TreeView tv;
        public addSqlite(TreeView tv)
        {
            InitializeComponent();
            this.tv = tv;
        }

        private void addSqlite_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 关闭软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 添加数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_add_Click(object sender, EventArgs e)
        {
            string name = skinTextBox_name.Text;
            string path = skinTextBox_path.Text;
            if (name == "")
            {
                MessageBox.Show("数据名称不能为空!");
                return;
            }
            if (path == "")
            {
                MessageBox.Show("数据库地址不能为空!");
                return;
            }
            if (!File.Exists(path))
            {
                MessageBox.Show("数据库地址不正确!");
                return;
            }
            else
            {
                lib.pSqlite sql = new lib.pSqlite(path);
                if (sql.conn == null)
                {
                    MessageBox.Show("无法打开数据库", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Data.pDataManageClass data = new pDataManageClass();
            if (data.addSqliteDataBase(name, path))
            {
                tv.Nodes.Add(data.hash, DataBaseType.Sqlite + " : " + name);
                this.Close();
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
        /// <summary>
        /// 文件对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string strFileName = ofd.FileName;
                skinTextBox_path.Text = strFileName;
            }
        }
    }
}

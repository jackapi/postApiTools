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
    public partial class addMysql : CCSkinMain
    {
        public addMysql()
        {
            InitializeComponent();
        }

        private void addMysql_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 添加一个数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_add_Click(object sender, EventArgs e)
        {
            string databaseName = textBox_name.Text;
            string ip = textBox_ip.Text;
            string port = textBox_port.Text;
            string username = textBox_username.Text;
            string password = textBox_password.Text;
            string encoding = textBox_encoding.Text;
            if (databaseName.Trim() == "")
            {
                MessageBox.Show("数据库名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lib.pMysql mysql = new lib.pMysql(ip, port, username, password, "");
            if (!mysql.isConnOpen())
            {
                MessageBox.Show("MySQL无法打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pDataManageClass p = new pDataManageClass();

            if (!p.addMysqlDataBase(databaseName, ip, port, username, password, encoding))
            {
                MessageBox.Show("添加出错！" + p.error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
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

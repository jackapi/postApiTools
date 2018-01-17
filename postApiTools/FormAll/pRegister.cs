using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.FormAll
{
    using CCWin;
    using Newtonsoft.Json.Linq;

    public partial class pRegister : CCSkinMain
    {
        public pRegister()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_create_Click(object sender, EventArgs e)
        {
            string name = skinTextBox_name.Text;
            string password = skinTextBox_password.Text;
            string password2 = skinTextBox_password2.Text;
            if (name == "") { MessageBox.Show("用户名为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (password != password2) { MessageBox.Show("密码不相同", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            JObject job = pFormAll.Register(name, password2);
            if (job == null) { MessageBox.Show("服务器错误:" + pFormAll.error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (job["code"].ToString() != "1") { MessageBox.Show("错误:" + job["msg"].ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            MessageBox.Show("注册成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.Close();
        }
        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && skinTextBox_password2.Focus())//确认密码回车键事件
            {
                skinButton_create_Click(null, null);
            }
        }

        private void pRegister_Load(object sender, EventArgs e)
        {

        }
    }
}

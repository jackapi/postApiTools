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

    public partial class pLogin : CCSkinMain
    {
        public pLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_login_Click(object sender, EventArgs e)
        {
            ConfigReadWrite wr = new ConfigReadWrite();
            string name = skinComboBox_name.Text;
            string password = skinTextBox_password.Text;
            if (name == "") { MessageBox.Show("用户名不能为空", "提示"); return; }
            if (password == "") { MessageBox.Show("密码不能为空", "提示"); return; }
            JObject job = pFormAll.login(name, password);
            if (job == null) { return; }
            if (job["code"].ToString() != "1") { MessageBox.Show("错误:" + job["msg"].ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }//登录错误提示
            if (MessageBox.Show("是否替换本地用户！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                wr.openServerName(name);
                wr.openServerPassword(password);
                wr.userToken(job["result"]["token"].ToString());
                Config.websocket.stop();//关闭
                Config.websocket.start();//重新启动
                this.Close();
            }
            else
            {
                MessageBox.Show("账号有效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
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
        private void pLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && skinTextBox_password.Focus())//密码框回车键事件
            {
                skinButton_login_Click(null, null);
            }
        }
    }
}

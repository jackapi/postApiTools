using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.FormRole
{
    using CCWin;
    using Newtonsoft.Json.Linq;

    public partial class addUserToRole : CCSkinMain
    {
        private string hash = "";
        public addUserToRole(string setHash = "", string name = "")
        {
            InitializeComponent();
            if (setHash == "")
            {
                MessageBox.Show("请进行正确操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.hash = setHash;
            skinLabel_name.Text = "添加到:" + name;
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_create_Click(object sender, EventArgs e)
        {
            string name = skinTextBox_name.Text;
            JObject job = pRole.createUserToRole(name, hash);
            if (job == null) { MessageBox.Show("错误:" + pRole.error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (job["code"].ToString() == "1")
            {
                MessageBox.Show("添加成功");
                this.Close();
                return;
            }
            MessageBox.Show("错误:" + job["msg"].ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

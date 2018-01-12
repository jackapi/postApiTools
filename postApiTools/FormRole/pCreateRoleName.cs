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
/// 创建角色名
/// </summary>
namespace postApiTools.FormRole
{
    using CCWin;
    using Newtonsoft.Json.Linq;

    public partial class pCreateRoleName : CCSkinMain
    {
        public pCreateRoleName()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_create_Click(object sender, EventArgs e)
        {
            string name = skinTextBox_name.Text;
            if (name == "") { MessageBox.Show("名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            JObject job = pRole.createRoleName(name);
            if (job == null) { MessageBox.Show("错误:" + pRole.error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (job["code"].ToString() == "1") { MessageBox.Show("创建成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.None); this.Close(); return; } else { MessageBox.Show("错误:" + job["msg"].ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }
    }
}

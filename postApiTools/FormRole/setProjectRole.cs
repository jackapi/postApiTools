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
/// 设置项目权限角色
/// by:chenran (apiziliao@gmail.com)
/// </summary>
namespace postApiTools.FormRole
{
    using CCWin;
    using Newtonsoft.Json.Linq;

    public partial class setProjectRole : CCSkinMain
    {

        /// <summary>
        /// hash
        /// </summary>
        private string hash = "";
        /// <summary>
        /// name
        /// </summary>
        private string name = "";

        public setProjectRole(string hash, string name)
        {
            InitializeComponent();
            this.hash = hash;
            this.name = name;
            skinLabel_role_name.Text = name;
        }

        /// <summary>
        /// 启动加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setProjectRole_Load(object sender, EventArgs e)
        {
            showTreeView();
        }

        /// <summary>
        /// 显示所有角色
        /// </summary>
        private void showTreeView()
        {
            JObject job = pRole.roleList();
            if (job == null) { return; }
            if (job["result"] == null) { return; }
            JArray jar = (JArray)job["result"];
            TreeView tv = skinTreeView1;
            tv.Invoke(new Action(() =>
            {
                tv.Nodes.Clear();
                foreach (JObject item in jar)
                {
                    tv.Nodes.Add(item.GetValue("hash").ToString(), item.GetValue("name").ToString());
                }
            }));
        }

        /// <summary>
        /// 设置项目权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_set_Click(object sender, EventArgs e)
        {
            string roleHash = skinTextBox_hash.Text;
            string roleName = skinTextBox_role_name.Text;
            if (roleHash == "" && roleName == "")
            {
                MessageBox.Show("请双击选择角色!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int all = skinCheckBox_all.CheckState == CheckState.Checked ? 1 : 0;//全部
            int read = skinCheckBox_read.CheckState == CheckState.Checked ? 1 : 0;//读
            int write = skinCheckBox_write.CheckState == CheckState.Checked ? 1 : 0;//写
            JObject job = pRole.createRoleProject(hash, roleHash, all.ToString(), read.ToString(), write.ToString());
            if (job == null) { return; }
            if (job["code"].ToString() != "1")
            {
                MessageBox.Show("错误" + job["msg"].ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("设置成功", "提示");
            this.Close();
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 双击节点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinTreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            string hash = tv.SelectedNode.Name;
            string name = tv.SelectedNode.Text;
            skinTextBox_hash.Text = hash;
            skinTextBox_role_name.Text = name;
        }

        /// <summary>
        /// 全部check值改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinCheckBox_all_CheckedChanged(object sender, EventArgs e)
        {
            if (skinCheckBox_all.CheckState == CheckState.Checked)
            {
                skinCheckBox_write.CheckState = CheckState.Checked;
                skinCheckBox_read.CheckState = CheckState.Checked;
            }
            else
            {
                skinCheckBox_write.CheckState = CheckState.Unchecked;
                skinCheckBox_read.CheckState = CheckState.Unchecked;
            }
        }
    }
}

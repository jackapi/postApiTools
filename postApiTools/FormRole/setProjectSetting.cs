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
    using System.Threading;

    public partial class setProjectSetting : CCSkinMain
    {
        /// <summary>
        /// 角色
        /// </summary>
        private string roleHash = "";

        public setProjectSetting(string roleHash = "")
        {
            InitializeComponent();
            this.roleHash = roleHash;
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setProjectSetting_Load(object sender, EventArgs e)
        {
            showTreeView();
        }

        /// <summary>
        /// 显示服务器上项目
        /// </summary>
        private void showTreeView()
        {
            JObject job = pRole.getProjectSettingList();
            if (job == null) { }
            JArray jar = (JArray)job["result"];
            foreach (JObject item in jar)
            {
                TreeNode tn = skinTreeView_project.Nodes.Add(item.GetValue("hash").ToString(), item.GetValue("name").ToString());
            }
        }

        /// <summary>
        /// 递归子类
        /// </summary>
        /// <param name="th"></param>
        /// <param name="hash"></param>
        private void pidShowFun(TreeNode tn, string hash)
        {
            JObject job = pRole.getProjectSettingPidList(hash);
            if (job == null) { return; }
            JArray jar = (JArray)job["result"];
            foreach (JObject item in jar)
            {
                TreeNode tns = tn.Nodes.Add(item.GetValue("hash").ToString(), item.GetValue("name").ToString());
                //pidShowFun(tns, item.GetValue("hash").ToString());//创建子类 不循环创建
            }
        }
        private int nodeLock = 0;

        /// <summary>
        /// 双击节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinTreeView_project_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (nodeLock == 1) { MessageBox.Show("等待加载完成！"); return; }
            TreeView tv = (TreeView)sender;
            tv.Enabled = false;
            nodeLock = 1;
            tv.Invoke(new Action(() =>
            {
                string hash = tv.SelectedNode.Name.ToString();
                string text = tv.SelectedNode.Text.ToString();
                tv.SelectedNode.Nodes.Clear();
                pidShowFun(tv.SelectedNode, hash);
                showRoleList(hash);
            }));
            nodeLock = 0;
            tv.Enabled = true;
        }

        private void showRoleList(string hash)
        {
            JObject job = pRole.getRoleProjectSettingRoleList(hash);
            if (job==null) { return; }
            JArray jar = (JArray)job["result"];
            skinDataGridView_role_list.Rows.Clear();
            skinDataGridView_role_list.Invoke(new Action(() =>
            {
                foreach (JObject item in jar)
                {
                    skinDataGridView_role_list.Rows.Add(new string[] { item.GetValue("hash").ToString(), item.GetValue("name").ToString() });
                }
            }));
        }

        /// <summary>
        /// 右键菜单绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinContextMenuStrip_project_setting_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null) { return; }
            if (e.ClickedItem.Text == "添加角色")
            {
                TreeView tv = skinTreeView_project;
                string hash = tv.SelectedNode.Name;
                string name = tv.SelectedNode.Text;
                setProjectRole role = new setProjectRole(hash, name);//设置项目权限角色
                role.ShowDialog();
                return;
            }

        }
    }
}

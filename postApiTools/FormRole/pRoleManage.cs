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
/// 权限管理主界面
/// by:chenran
/// </summary>
namespace postApiTools.FormRole
{
    using CCWin;
    using CCWin.SkinControl;
    using Newtonsoft.Json.Linq;

    public partial class pRoleManage : CCSkinMain
    {
        public pRoleManage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 启动加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pRoleManage_Load(object sender, EventArgs e)
        {
            showRoleList();
        }

        /// <summary>
        /// 显示角色列表
        /// </summary>
        private void showRoleList()
        {
            skinDataGridView_role_list.Rows.Clear();
            JObject job = pRole.roleList();
            if (job == null) { return; }
            JArray jar = (JArray)job["result"];
            skinDataGridView_role_list.Invoke(new Action(() =>
            {
                foreach (JObject item in jar)
                {
                    skinDataGridView_role_list.Rows.Add(new string[] { item.GetValue("hash").ToString(), item.GetValue("name").ToString() });
                }
            }));
        }

        /// <summary>
        /// 生成显示
        /// </summary>
        /// <param name="d"></param>
        /// <param name="jar"></param>
        /// <param name="key"></param>
        private void showDataView(SkinDataGridView d, JArray jar, string[] key)
        {
            if (jar == null) { return; }
            d.Invoke(new Action(() =>
            {
                d.Rows.Clear();
                if (key.Length < 0) { d.DataSource = jar; return; }
                foreach (JObject item in jar)
                {
                    string[] temp = new string[key.Length];
                    for (int i = 0; i < key.Length; i++)
                    {
                        temp[i] = item.GetValue(key[i]).ToString();
                    }
                    d.Rows.Add(temp);
                }
            }));
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pRoleManage_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)//关闭窗体
            {
                this.Close();
            }
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_create_role_Click(object sender, EventArgs e)
        {
            pCreateRoleName create = new pCreateRoleName();
            create.ShowDialog();
            showRoleList();

        }


        /// <summary>
        /// 角色列表右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinContextMenuStrip_role_list_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null)
            {
                return;
            }
            if (skinDataGridView_role_list.CurrentRow.Index < 0) { return; }
            if (skinDataGridView_role_list.CurrentRow.Index > skinDataGridView_role_list.Rows.Count - 2) { return; }//判断是否超出列表选择
            string hash = skinDataGridView_role_list.Rows[skinDataGridView_role_list.CurrentRow.Index].Cells["hash"].Value.ToString();//hash
            string name = skinDataGridView_role_list.Rows[skinDataGridView_role_list.CurrentRow.Index].Cells["name"].Value.ToString();//名称
            if (e.ClickedItem.Text == "添加用户")
            {
                addUserToRole role = new addUserToRole(hash, name);
                role.ShowDialog();
                JObject job = pRole.getRoleUserList(hash);
                if (job == null) { return; }
                showDataView(skinDataGridView_more, (JArray)job["result"], new string[] { "hash", "name" });//显示数据
            }
            if (e.ClickedItem.Text == "添加项目")
            {
                setProjectSetting set = new setProjectSetting(hash);
                set.ShowDialog();
            }
            if (e.ClickedItem.Text == "查看用户")
            {
                JObject job = pRole.getRoleUserList(hash);
                if (job == null) { return; }
                showDataView(skinDataGridView_more, (JArray)job["result"], new string[] { "hash", "name" });//显示数据
            }
        }

        /// <summary>
        /// 管理项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_project_setting_Click(object sender, EventArgs e)
        {
            setProjectSetting set = new setProjectSetting();
            set.ShowDialog();
        }

        /// <summary>
        /// 用户列表管理右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinContextMenuStrip_more_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null) { return; }
            if (skinDataGridView_more.CurrentRow.Index < 0) { return; }
            if (skinDataGridView_more.CurrentRow.Index > skinDataGridView_more.Rows.Count - 2) { return; }//判断是否超出列表选择
            if (skinDataGridView_more.Rows[skinDataGridView_more.CurrentRow.Index].Cells["role_hash"] == null) { return; }
            string hash = skinDataGridView_more.Rows[skinDataGridView_more.CurrentRow.Index].Cells["role_hash"].Value.ToString();//hash
            string name = skinDataGridView_more.Rows[skinDataGridView_more.CurrentRow.Index].Cells["user_name"].Value.ToString();//名称
            skinContextMenuStrip_more.Close();
            if (e.ClickedItem.Text == "删除")
            {
                JObject job = pRole.deleteRoleUserList(hash);
                if (job == null) { return; }
                if (job["code"].ToString() == "1")
                {
                    JObject jobHash = pRole.getRoleUserList(hash);
                    if (jobHash == null) { return; }
                    showDataView(skinDataGridView_more, (JArray)jobHash["result"], new string[] { "hash", "name" });//显示数据
                    MessageBox.Show("清理完成");
                    return;
                }
                MessageBox.Show(job["msg"].ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (e.ClickedItem.Text == "清空")
            {
                skinContextMenuStrip_more.Close();
                JObject job = pRole.roleUserClear(hash);
                if (job == null) { return; }
                if (job["code"].ToString() == "1")
                {
                    JObject jobHash = pRole.getRoleUserList(hash);
                    if (jobHash == null) { return; }
                    showDataView(skinDataGridView_more, (JArray)jobHash["result"], new string[] { "hash", "name" });//显示数据
                    MessageBox.Show("清理完成");
                    return;
                }
                MessageBox.Show(job["msg"].ToString());
                return;
            }
        }

        /// <summary>
        /// 单击单元格显示用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView_role_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > skinDataGridView_role_list.Rows.Count - 2) { return; }
            if (e.RowIndex < 0) { return; }
            string hash = skinDataGridView_role_list.Rows[e.RowIndex].Cells["hash"].Value.ToString();//hash
            JObject job = pRole.getRoleUserList(hash);
            if (job == null) { return; }
            showDataView(skinDataGridView_more, (JArray)job["result"], new string[] { "hash", "name" });//显示数据
        }
    }
}

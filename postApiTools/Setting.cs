using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools
{
    using CCWin;
    public partial class Setting : CCSkinMain
    {
        public Setting()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 新建模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_new_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {
            string name = textBox_save_name.Text;
            string listName = comboBox_template_list.Text;
            string content = textBox_template.Text;
            if (name == "" && listName == "默认模板")
            {
                lib.pFile.Write(Config.templateTxt, content);
                MessageBox.Show("保存成功");
            }
            if (name != "" && listName == "默认模板")
            {
                pSetting.templateListWrite(name, content);
                textBox_save_name.Text = "";
                textBox_template.Text = "";
                pSetting.refreshTemplateList(comboBox_template_list);
                MessageBox.Show("新建模板" + name + "成功!");
            }
            if (name == "" && listName != "默认模板")
            {
                pSetting.updateTemplate(listName, content);//保存更新模板
                MessageBox.Show("保存模板" + listName + "成功!");
            }
        }

        /// <summary>
        /// 界面打开加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Setting_Load(object sender, EventArgs e)
        {
            string template = lib.pFile.Read(Config.templateTxt);
            textBox_template.Text = template;
            pSetting.refreshTemplateList(comboBox_template_list);
            comboBox_template_list.Text = "默认模板";

            textBox_web_url.Text = Config.openServerUrl;
            textBox_web_username.Text = Config.openServerName;
            textBox_web_password.Text = Config.openServerPassword;
            checkBox_open_server_update.CheckState = Config.openServerUpdate == "Checked" ? CheckState.Checked : CheckState.Unchecked;//是否开启更新

            checkBox_agreed.CheckState = Config.openServerAgreed == "Checked" ? CheckState.Checked : CheckState.Unchecked;//服务器保持一致

            textBox_websocket_ip.Text = Config.openServerWebSocketIp;
            textBox_websocket_port.Text = Config.openServerWebSocketPort;

            checkBox_force_server.CheckState = Config.openServerWebForce == "Checked" ? CheckState.Checked : CheckState.Unchecked;//强制更新
        }

        /// <summary>
        /// 改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_template_list_SelectedIndexChanged(object sender, EventArgs e)
        {

            string listName = comboBox_template_list.Text;
            textBox_template.Text = pSetting.readTemplate(listName);

        }

        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_delete_template_Click(object sender, EventArgs e)
        {
            string listName = comboBox_template_list.Text;
            if (listName == "默认模板")
            {
                MessageBox.Show("无法删除默认模板!");
                return;
            }
            string path = Config.templatePath + listName + pSetting.fx;
            if (File.Exists(path))
            {
                pSetting.deleteTemplate(listName, comboBox_template_list);
            }
            else
            {
                MessageBox.Show("不存在模板 无法删除");
            }

        }

        /// <summary>
        /// 清理历史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_history_Click(object sender, EventArgs e)
        {
            int rows = pHistory.historyAllDelete();

            MessageBox.Show(string.Format("成功清理历史{0}个！", rows));
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_web_save_Click(object sender, EventArgs e)
        {
            string url = textBox_web_url.Text;
            string name = textBox_web_username.Text;
            string password = textBox_web_password.Text;
            string ip = textBox_websocket_ip.Text;
            string port = textBox_websocket_port.Text;
            CheckState update = checkBox_open_server_update.CheckState;
            CheckState agreed = checkBox_agreed.CheckState;
            CheckState force = checkBox_force_server.CheckState;//强制更新
            if (!lib.pRegex.IsUrl(url))
            {
                MessageBox.Show("请填写正确URL");
                return;
            }
            if (url == "")
            {
                MessageBox.Show("url不能为空");
                return;
            }
            if (name == "" || password == "")
            {
                MessageBox.Show("账号密码不能为空!");
                return;
            }
            pSetting.saveUrlNamePassword(url, name, password, update, agreed);
            pSetting.saveSocket(ip, port, force);//socket
            MessageBox.Show("设置成功！");

        }
        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Setting_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)//关闭窗体
            {
                this.Close();
            }
        }
    }
}

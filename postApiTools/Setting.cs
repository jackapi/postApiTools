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
    public partial class Setting : Form
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Setting_Load(object sender, EventArgs e)
        {
            string template = lib.pFile.Read(Config.templateTxt);
            textBox_template.Text = template;
            pSetting.refreshTemplateList(comboBox_template_list);
            comboBox_template_list.Text = "默认模板";
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
    }
}

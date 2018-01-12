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
/// 添加项目-添加项目名称
/// by:chenran (apiziliao@gmail.com)
/// </summary>
namespace postApiTools
{
    using CCWin;
    public partial class AddProject : CCSkinMain
    {

        public AddProject()
        {
            InitializeComponent();
        }
        public string projectName = "";
        public string projectDesc = "";
        private void button_save_Click(object sender, EventArgs e)
        {
            string textName = textBox_name.Text;
            string textDesc = textBox_desc.Text;
            if (textName == "")
            {
                MessageBox.Show("项目名称不能为空");
            }
            this.projectName = textName;
            this.projectDesc = textDesc;
            this.Hide();
        }

        /// <summary>
        /// 关闭当前窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddProject_Load(object sender, EventArgs e)
        {
            textBox_name.Focus();
        }
    }
}

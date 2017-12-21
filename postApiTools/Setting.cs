using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Setting_Load(object sender, EventArgs e)
        {
            string template = lib.pFile.Read(Config.exePath + "/data/template.txt");
            textBox_template.Text = template;
        }
    }
}

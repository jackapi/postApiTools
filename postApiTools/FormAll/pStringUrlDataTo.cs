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
    public partial class pStringUrlDataTo : CCSkinMain
    {
        public pStringUrlDataTo()
        {
            InitializeComponent();
            skinComboBox1.Text = "JSON";//json
        }


        /// <summary>
        /// 导入参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_save_Click(object sender, EventArgs e)
        {
            string type = skinComboBox1.Text;
            if (type == "JSON")
            {
            }
            if (type == "URLDATA")
            {
            }
        }
        /// <summary>
        /// 转换成参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_create_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pStringUrlDataTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)//关闭界面
            {
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
    }
}

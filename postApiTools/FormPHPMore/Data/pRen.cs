using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.FormPHPMore.Data
{
    using CCWin;
    public partial class pRen : CCSkinMain
    {
        public string hash = "";
        public string name = "";
        public bool result = false;//结果
        public string error = "";//error
        public pRen(string hash, string name)
        {
            InitializeComponent();
            this.hash = hash;
            this.name = name;
        }

        private void pRen_Load(object sender, EventArgs e)
        {
            skinTextBox_name.Text = this.name;//名称
        }

        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_ren_Click(object sender, EventArgs e)
        {
            name = skinTextBox_name.Text;
            if (name.Trim() == "") { MessageBox.Show("名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string[] array = this.hash.Split('|');
            if (array.Length == 1)//数据库重命名
            {
                Data.pDataManageClass p = new pDataManageClass();
                if (p.updateDataBaseName(this.hash, name) > 0)
                {
                    this.result = true;
                }
                else {
                    this.error = p.error;//error
                    this.result = false;
                }
            }
            this.Close();
        }

        /// <summary>
        /// 关闭重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

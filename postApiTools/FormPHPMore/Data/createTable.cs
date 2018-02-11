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
    public partial class createTable : CCSkinMain
    {
        string hash = "";
        public createTable(string hash)
        {
            InitializeComponent();
            this.hash = hash;
        }

        private void createTable_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 新建表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_create_Click(object sender, EventArgs e)
        {

        }
    }
}

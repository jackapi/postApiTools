using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.FormPHPMore
{
    using CCWin;
    public partial class pDataBaseInfo : CCSkinMain
    {
        string hash = "";
        public pDataBaseInfo(string hash)
        {
            InitializeComponent();
            this.hash = hash;
        }

        /// <summary>
        /// 加载详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pDataBaseInfo_Load(object sender, EventArgs e)
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
    }
}

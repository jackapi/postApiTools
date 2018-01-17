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
    public partial class pDataManage : CCSkinMain
    {
        public pDataManage()
        {
            InitializeComponent();
        }

        private void pMysqlManage_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 双击控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinTreeView_mysql_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeView tv = skinTreeView_mysql;
        }
    }
}

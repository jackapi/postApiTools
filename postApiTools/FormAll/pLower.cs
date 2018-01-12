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
/// 右下角提示框界面
/// by:chenran（apiziliao@gmail.com）
/// </summary>
namespace postApiTools.FormAll
{
    using CCWin;
    public partial class pLower : CCSkinMain
    {
        public pLower()
        {
            InitializeComponent();
            int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width - this.Width;
            int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height - this.Height;
            this.SetDesktopLocation(x, y);
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string title = "";

        /// <summary>
        /// 内容
        /// </summary>
        public string mssage = "";

        /// <summary>
        /// 启动时间
        /// </summary>
        private int start = 0;

        /// <summary>
        /// 处理时间
        /// </summary>
        private int end = 0;

        /// <summary>
        /// 启动运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pLower_Load(object sender, EventArgs e)
        {
            this.Text = title;
            label1.Text = mssage;
            this.timer_tools.Start();
            start = lib.pDate.getTimeStamp();
        }
        /// <summary>
        /// 定时器 自动关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_tools_Tick(object sender, EventArgs e)
        {
            end = lib.pDate.getTimeStamp() - start;
            if (this.Focused == false && end >= (10))
            {
                this.Close();
            }
        }
    }
}

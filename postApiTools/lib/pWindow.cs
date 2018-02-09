using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.lib
{
    public class pWindow
    {
        /// <summary>
        /// 获取显示器宽
        /// </summary>
        /// <returns></returns>
        public static int getWidth()
        {
            return Screen.PrimaryScreen.Bounds.Width;
        }
        /// <summary>
        /// 获取显示器高
        /// </summary>
        /// <returns></returns>
        public static int getHeight()
        {
            return Screen.PrimaryScreen.Bounds.Height;
        }
    }
}

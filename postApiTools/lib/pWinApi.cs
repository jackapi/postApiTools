using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    public class pWinApi
    {
        /// <summary>
        /// 窗口置顶
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="fAltTab"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        ///通过窗口的标题来查找窗口的句柄
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
    }
}

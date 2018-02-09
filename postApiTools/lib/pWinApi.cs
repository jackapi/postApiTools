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

        /// <summary>
        /// 释放内存
        /// IntPtr pHandle = GetCurrentProcess();
        /// SetProcessWorkingSetSize(pHandle, -1, -1);
        /// </summary>
        /// <param name="pProcess"></param>
        /// <param name="dwMinimumWorkingSetSize"></param>
        /// <param name="dwMaximumWorkingSetSize"></param>
        /// <returns></returns>
        [DllImport("KERNEL32.DLL", EntryPoint = "SetProcessWorkingSetSize", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        /// <summary>
        /// 获取句柄
        /// </summary>
        /// <returns></returns>
        [DllImport("KERNEL32.DLL", EntryPoint = "GetCurrentProcess", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr GetCurrentProcess();
    }
}

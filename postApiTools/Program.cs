using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (lib.pWinApi.FindWindow(null, "PostApiTools 开发助手") > 0)
                {
                    //return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
                MessageBox.Show("错误:" + ex.ToString().Substring(0, 200) + "...", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
        }
    }
}

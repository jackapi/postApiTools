using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// ie相关检测
/// </summary>
namespace postApiTools.lib
{
    public class pIe
    {

        /// <summary>
        /// 获取IE版本
        /// </summary>
        /// <returns></returns>
        public static string getIe()
        {
            string ver = (new WebBrowser()).Version.ToString();
            return ver;
        }

        /// <summary>
        /// 获取IE版本
        /// </summary>
        /// <returns></returns>
        public static string getIeInt()
        {
            string mainVer = (new WebBrowser()).Version.Major.ToString();
            return mainVer;
        }

        /// <summary>
        /// 判断是否下载
        /// </summary>
        /// <returns></returns>
        public static bool isUpdate()
        {
            try
            {
                string okVersion = "11.0.0.0";
                string nowVersion = getIe();
                Version now = new Version(nowVersion);
                Version ok = new Version(okVersion);
                if (ok > now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString()); return false;
            }
        }

        /// <summary>
        /// 检测并自动下载
        /// </summary>
        public static void isIeDownload()
        {
            if (!isUpdate()) { return; }
            if (MessageBox.Show("立刻更新IE11！否则无法正常使用部分文档系统功能！", "警告提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lib.pBase.openWeb("https://support.microsoft.com/zh-cn/help/17621/internet-explorer-downloads");
                Form1.f.close();
            }
        }
    }
}

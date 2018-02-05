using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace postApiTools.lib
{
    /// <summary>
    /// webkit处理
    /// </summary>
    public class pWebkit
    {
        /// <summary>
        /// 显示网页
        /// </summary>
        /// <param name="cc"></param>
        /// <param name="content"></param>
        public void ShowControlWebkit(ControlCollection cc, string content)
        {
            cc.Clear();
            WebKit.WebKitBrowser browser = new WebKit.WebKitBrowser();
            browser.Dock = DockStyle.Fill;
            cc.Add(browser);
            browser.DocumentText = content;
        }
    }
}

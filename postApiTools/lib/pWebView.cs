using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace postApiTools.lib
{
    public class pWebView
    {
        public WebBrowser webBrowser;
        /// <summary>
        /// 加载网页
        /// </summary>
        /// <param name="cc"></param>
        /// <param name="url"></param>
        public void ShowControlWebkit(ControlCollection cc, string url)
        {
            cc.Clear();
            WebBrowser browser = new WebBrowser();
            browser.Dock = DockStyle.Fill;
            cc.Add(browser);
            browser.ScriptErrorsSuppressed = true;
            browser.ScrollBarsEnabled = false;
            browser.Url = new Uri(url);
            webBrowser = browser;
        }
        /// <summary>
        /// 网页HTML
        /// </summary>
        /// <param name="cc"></param>
        /// <param name="content"></param>
        public void ShowControlHtml(ControlCollection cc, string content)
        {
            cc.Clear();
            WebBrowser browser = new WebBrowser();
            browser.Dock = DockStyle.Fill;
            cc.Add(browser);
            browser.ScriptErrorsSuppressed = true;
            browser.ScrollBarsEnabled = false;
            browser.DocumentText = content;
            webBrowser = browser;
        }
    }
}

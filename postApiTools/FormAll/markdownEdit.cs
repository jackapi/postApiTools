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
/// 编辑markdown文档
/// </summary>
namespace postApiTools.FormAll
{
    using CCWin;
    using System.Threading;

    public partial class markdownEdit : CCSkinMain
    {
        public markdownEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 编辑内容
        /// </summary>
        public string content = "";

        /// <summary>
        /// 启动加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void markdownEdit_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                this.Width = 1200;
                this.Height = 700;
                webBrowser_markdown.Url = new Uri(Config.openServerUrl + "/index/document/editMarkdown?token=" + Config.userToken);
                this.KeyDown += keyDown;
                int iActulaWidth = lib.pWindow.getWidth();
                int iActulaHeight = lib.pWindow.getHeight();
                this.Location = new Point((iActulaWidth - this.Width) / 2, (iActulaHeight - this.Height) / 2);//自动居中
                webBrowser_markdown.PreviewKeyDown += webKeyDown;//浏览器中事件
                webBrowser_markdown.DocumentCompleted += webBrowser_markdown_DocumentCompleted;//加载完成事件

            }));
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void keyDown(object sender, EventArgs e)
        {
            KeyEventArgs key = (KeyEventArgs)e;
            if (key.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 浏览器键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void webKeyDown(object sender, EventArgs e)
        {
            PreviewKeyDownEventArgs key = (PreviewKeyDownEventArgs)e;
            if (key.KeyCode == Keys.S && key.Modifiers == Keys.Control)
            {
                skinButton_save_Click(null, null);//保存文档
                return;
            }
            skinButton_save_Click(null, null);//保存文档
        }

        /// <summary>
        /// 系统延时
        /// </summary>
        /// <param name="Millisecond"></param>
        private void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();//转让控制权            
            }
            return;
        }
        int webLock = 1;
        /// <summary>
        /// 加载完事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser_markdown_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            while (webBrowser_markdown.IsBusy)
            {
                Delay(50);  //系统延迟判断   
            }
            if (webBrowser_markdown.ReadyState == WebBrowserReadyState.Complete) //先判断是否发生完成事件。
            {
                webLock = 0;
                HtmlElement contentDocument = webBrowser_markdown.Document.All["content"];
                if (contentDocument == null)
                    return;
                contentDocument.SetAttribute("value", content);

            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_save_Click(object sender, EventArgs e)
        {
            if (webLock != 0) { MessageBox.Show("无法操作！未加载完成！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            HtmlElement contentDocument = webBrowser_markdown.Document.All["content"];
            if (contentDocument == null)
                return;
            string markdown = contentDocument.GetAttribute("value");
            markdown = markdown.Replace("\n", "\r\n");
            Form1.f.textBoxDocDataShow(markdown);
        }
    }
}

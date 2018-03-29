using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.FormAll
{
    using CCWin;
    using Newtonsoft.Json.Linq;

    public partial class getDocumentContent : CCSkinMain
    {
        string hash = "";
        string name = "";
        string content = "";
        public getDocumentContent(string hash = "", string name = "")
        {
            InitializeComponent();
            this.hash = hash;
            this.name = name;
            this.Text = this.Text + name;
        }
        /// <summary>
        /// 启动加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getDocumentContent_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> d = pForm1TreeView.getApi(this.hash);
            if (d.Count <= 0) { return; }
            textBox_url.Text = d["url"];
            label_urltype.Text = d["method"];
            this.content = d["desc"];
            string urlData = d["urldata"];
            urlData = lib.pBase64.base64ToString(urlData);
            JArray jar = pJson.jsonToJArray(urlData);
            showDataView(jar);//显示参数
            this.BeginInvoke(new Action(() =>
            {
                webBrowser_content.Url = new Uri(Config.openServerUrl + "/index/document/editMarkdown?token=" + Config.userToken);
                int iActulaWidth = lib.pWindow.getWidth();
                int iActulaHeight = lib.pWindow.getHeight();
                this.Location = new Point((iActulaWidth - this.Width) / 2, (iActulaHeight - this.Height) / 2);//自动居中
                webBrowser_content.PreviewKeyDown += webKeyDown;//浏览器中事件
                webBrowser_content.DocumentCompleted += webBrowser_markdown_DocumentCompleted;//加载完成事件

            }));
            formSize();//调整窗体大小
        }

        /// <summary>
        /// 显示数据框内容
        /// </summary>
        /// <param name="jar"></param>
        public void showDataView(JArray jar)
        {
            DataGridView d = dataGridView_data;
            int w = d.Width;
            int showW = w - 10;
            d.Columns[0].Width = showW / 3;
            d.Columns[1].Width = showW / 3;
            d.Columns[2].Width = showW / 3;
            d.BeginInvoke(new Action(() =>
            {
                if (jar.Count <= 0) { return; }
                foreach (var item in jar)
                {
                    d.Rows.Add(item[0], item[1], item[2]);
                }
            }));
        }

        /// <summary>
        /// 调整窗体大小
        /// </summary>
        public void formSize()
        {
            try
            {
                string w = lib.pIni.read("get-content-form", "form-w");
                string h = lib.pIni.read("get-content-form", "form-h");
                if (w != "" && h != "")
                {
                    this.Width = Int32.Parse(w);
                    this.Height = Int32.Parse(h);
                }
            }
            catch (Exception ex) { pLogs.logs(ex.ToString()); }
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
                saveDoc();//保存文档
                return;
            }
        }

        /// <summary>
        /// 保存文档并通知
        /// </summary>
        public void saveDoc()
        {
            if (webLock != 0) { MessageBox.Show("无法操作！未加载完成！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            HtmlElement contentDocument = webBrowser_content.Document.All["content"];
            if (contentDocument == null)
                return;
            string markdown = contentDocument.GetAttribute("value");
            markdown = markdown.Replace("\n", "\r\n");
            Dictionary<string, string> d = pForm1TreeView.getApi(this.hash);//获取原有
            if (pForm1TreeView.editApi(this.hash, d["name"], markdown, d["url"], d["urldata"], d["method"]))
            {
                return;
            }
            Form1.f.textBoxDocDataShow(markdown);
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
            while (webBrowser_content.IsBusy)
            {
                Delay(50);  //系统延迟判断   
            }
            if (webBrowser_content.ReadyState == WebBrowserReadyState.Complete) //先判断是否发生完成事件。
            {
                webLock = 0;
                HtmlElement contentDocument = webBrowser_content.Document.All["content"];
                if (contentDocument == null)
                    return;
                contentDocument.SetAttribute("value", content);

            }
        }
        /// <summary>
        /// 窗体改变时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getDocumentContent_Resize(object sender, EventArgs e)
        {
            try
            {
                int w = this.Width;
                int h = this.Height;
                lib.pIni.write("get-content-form", "form-w", w.ToString());
                lib.pIni.write("get-content-form", "form-h", h.ToString());
            }
            catch (Exception ex) { pLogs.logs(ex.ToString()); }
        }
    }
}

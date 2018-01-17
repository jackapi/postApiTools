using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.WebSocket
{
    using CCWin;
    using WebSocketSharp;
    using WebSocketSharp.Net;
    public partial class pMain : CCSkinMain
    {
        public pMain()
        {
            InitializeComponent();
        }
        WebSocket socket = null;

        private void skinButton_open_Click(object sender, EventArgs e)
        {
            string ip = skinTextBox_ip.Text;
            string port = skinTextBox_port.Text;
            if (ip == "")
            {
                MessageBox.Show("IP不能为空");
                return;
            }
            if (port == "")
            {
                MessageBox.Show("端口不能为空");
                return;
            }
            if (skinButton_open.Text == "打开连接")
            {
                skinButton_open.Text = "关闭连接";
            }
            else
            {
                socket = null;
                skinButton_open.Text = "打开连接";
            }
            lib.pIni.write("websocket-tools", "ip", ip);
            lib.pIni.write("websocket-tools", "port", port);
            if (socket == null)
            {
                socket = new WebSocket(string.Format("ws://{0}:{1}", ip, port));
                getContent();
            }
        }

        /// <summary>
        /// 获取接收内容
        /// </summary>
        public void getContent()
        {
            try
            {
                socket.OnOpen += (sender, e) => { };//打开
                socket.Connect();
                socket.OnError += (sender, e) => { };//错误
                socket.OnClose += (sender, e) => { };//远程关闭
                socket.OnMessage += (sender, e) =>
                {
                    skinChatRichTextBox2.AppendText(DateTime.Now.ToLocalTime().ToString() + ":" + e.Data + "\r\n");
                };//返回信息
            }
            catch (Exception ex){
                pLogs.logs(ex.ToString());
            }
        }
        /// <summary>
        /// 发送框回车键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinChatRichTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && skinChatRichTextBox1.Focus())
            {
                send();
            }
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (socket != null)
            {
                socket.Close();
                socket = null;
                this.Dispose();
            }
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pMain_Load(object sender, EventArgs e)
        {

            skinTextBox_ip.Text = lib.pIni.read("websocket-tools", "ip");
            skinTextBox_port.Text = lib.pIni.read("websocket-tools", "port");
        }
        /// <summary>
        /// 发送
        /// </summary>
        public void send()
        {
            if (socket == null) { skinButton_open_Click(null, null); }
            if (skinChatRichTextBox1.Text == "") { return; }
            skinChatRichTextBox1.Text = "";
            socket.Send(skinChatRichTextBox1.Text);
        }
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinContextMenuStrip_send_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "发送")
            {
                send();
            }
            if (e.ClickedItem.Text == "粘贴")
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    skinChatRichTextBox1.Text = (String)iData.GetData(DataFormats.Text);
                }

            }
        }
        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinContextMenuStrip_content_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "清空")
            {
                skinChatRichTextBox2.Text = "";
            }
        }
        Memo m = null;
        /// <summary>
        /// 主窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q)//打开便签
            {
                if (m == null) { m = new Memo(); }
                if (m.IsDisposed) { m = new Memo(); }
                m.Show();
            }
        }
    }
}

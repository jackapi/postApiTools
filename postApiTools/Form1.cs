using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// by:(chenran)apiziliao@gmail.com  
/// </summary>
namespace postApiTools
{
    using FormAll;
    using System.Data.OleDb;
    using lib;
    using System.Diagnostics;
    using System.Net;
    using System.Runtime.InteropServices;
    using CCWin;
    using Newtonsoft.Json.Linq;
    using WebKit;
    using FastColoredTextBoxNS;

    public partial class Form1 : CCSkinMain
    {
        /// <summary>
        /// 浏览器
        /// </summary>

        public static Form1 f;
        /// <summary>
        /// 右下角提示框
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="dwTime"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        const int AW_HOR_POSITIVE = 0x0001;
        const int AW_HOR_NEGATIVE = 0x0002;
        const int AW_VER_POSITIVE = 0x0004;
        const int AW_VER_NEGATIVE = 0x0008;
        const int AW_CENTER = 0x0010;
        const int AW_HIDE = 0x10000;
        const int AW_ACTIVATE = 0x20000;
        const int AW_SLIDE = 0x40000;
        const int AW_BLEND = 0x80000;





        public string cmdData = "";

        public Form1(string data = "")
        {
            InitializeComponent();
            f = this;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            this.dataGridView_http_data.EditMode = DataGridViewEditMode.EditOnEnter;
            lib.pReg.install();
            lib.pReg.createPrice(lib.pReg.createData, "path", Config.exe);
            this.cmdData = data;
        }
        /// <summary>
        /// 软件更新服务
        /// </summary>
        public lib.updateServer update = new lib.updateServer();

        /// <summary>
        /// 加载锁
        /// </summary>
        public int loadInt = 1;
        /// <summary>
        /// 启动加载线程
        /// </summary>
        Thread formLoadTh = null;

        /// <summary>
        /// 界面启动时运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            formLoadTh = new Thread(formLoadFun);
            formLoadTh.Start();
            timer_server.Start();//启动定时器 不能再线程中使用
            this.Text = this.Text + " 开发助手";
            lib.pWinApi.SwitchToThisWindow(this.Handle, true);//启动后置顶
            IEVersion.BrowserEmulationSet();//指定IE
        }

        /// <summary>
        /// 显示浏览器
        /// </summary>
        /// <param name="html"></param>
        public void webkitShowOpenLocal(string html = "")
        {
            this.tabPage5.Invoke(new Action(() =>
            {
                this.tabPage5.Controls.Clear();
                WebKit.WebKitBrowser browser = new WebKit.WebKitBrowser();
                browser.Dock = DockStyle.Fill;
                //browser.Url =new Uri("http://postApiTools.cn/index/document/getMarkdownHash?hash=11b7a71ce52341cbf3b74567cec8949a");
                this.tabPage5.Controls.Add(browser);
                browser.DocumentText = html;
            }));
        }
        /// <summary>
        /// 使用线程加载
        /// </summary>
        private void formLoadFun()
        {
            Thread.Sleep(100);
            label_version.Text = Config.version;//版本显示
            //窗口自动调整
            int[] size = pform1.formSizeRead();
            this.Width = size[0];
            this.Height = size[1];
            //this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            comboBox_bm.Text = "UTF-8";
            pform1.textBoxUrlRead(textBox_url);//url读取
            pform1.httpHtmlTypeDataRead(comboBox_html_show_type);//httpHTML源码类型
            pform1.httpTypeWriteRead(comboBox_url_type);//http类型
            pform1.dataviewUrlDataRead(dataGridView_http_data);//请求参数列表
            pHistory.dataViewRefresh(dataGridView_history);//刷新历史记录
            pSetting.refreshTemplateList(comboBox_template);//刷新模板列表
            fTextBox.TextBoxAutoComplete(textBox_url, pHistory.urlHistoryList);//自动textbox填充
            pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);//显示项目列表树
            pform1.toRnShow(checkBox_to_rn);//自动转换选中显示
            Config.websocket.start();//启动websocket
            message();//启动消息检测
            loadInt = 0;
            //UpdateFun();///老方法更新
            label_update_Click(null, null);//更新新方法
            showUserName();//显示用户名
            this.BeginInvoke(new Action(() =>
            {
                pIe.isIeDownload();//检测浏览器版本 
            }));
            loadingCloseTab();
        }

        /// <summary>
        /// 判断是否自动隐藏
        /// </summary>
        public bool loadingCloseTabBool = false;

        /// <summary>
        /// 加载关闭左侧选项卡
        /// </summary>
        public void loadingCloseTab()
        {
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.Add("关闭左侧");
            cms.ItemClicked += closeTab3;//绑定事件
            tabControl3.ContextMenuStrip = cms;

            ContextMenuStrip form1Cms = new ContextMenuStrip();
            form1Cms.Items.Add("显示左侧");
            form1Cms.ItemClicked += showTab3;//绑定事件
            this.ContextMenuStrip = form1Cms;
            string visible = pIni.read("form1", "tab3-visible");
            if (visible == "yes")
            {
                loadingCloseTabBool = true;
                closeTab3(null, null);
            }
        }

        /// <summary>
        /// 显示左侧控件tab3
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public void showTab3(object obj1, object obj2)
        {
            ToolStripItemClickedEventArgs t = (ToolStripItemClickedEventArgs)obj2;
            if (t.ClickedItem == null) { return; }
            if (t.ClickedItem.ToString() == "显示左侧")
            {
                if (tabControl3.Visible) { return; }//已经显示就不处理
                int w = tabControl3.Width;
                tabControl3.Show();//隐藏当前控件
                Point p = tabControl1.Location;//获取控件位置坐标
                p.X = w + 10;//指定10
                tabControl1.Location = p;//重新指定设置
                tabControl1.Width = tabControl1.Width - w;//重新设置宽度
            }
        }

        /// <summary>
        /// 关闭隐藏tab3控件的事件操作
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public void closeTab3(object obj1, object obj2)
        {
            if (loadingCloseTabBool)
            {
                closeTab3Fun();
            }
            else
            {
                ToolStripItemClickedEventArgs t = (ToolStripItemClickedEventArgs)obj2;
                if (t.ClickedItem == null) { return; }
                if (t.ClickedItem.ToString() == "关闭左侧")
                {
                    closeTab3Fun();
                }
            }
        }

        /// <summary>
        /// 实现关闭tab3的方法
        /// </summary>
        public void closeTab3Fun() {
            pIni.write("form1", "tab3-visible", "yes");
            int w = tabControl3.Width;
            tabControl3.Hide();//隐藏当前控件
            Point p = tabControl1.Location;//获取控件位置坐标
            p.X = 10;//指定10
            tabControl1.Location = p;//重新指定设置
            tabControl1.Width = tabControl1.Width + w;//重新设置宽度
        }

        /// <summary>
        /// 判断是否登录
        /// </summary>
        public void showUserName()
        {
            label_show_user_name.Text = "";
            if (lib.pApizlHttp.isLogin(Config.userToken))
            {
                label_show_user_name.Text = Config.openServerName;//用户名显示
            }
        }

        /// <summary>
        /// 更新方法
        /// </summary>
        public void UpdateFun(bool message = false)
        {
            if (update.isUpdate())//判断更新
            {
                if (MessageBox.Show("确认更新,将关闭当前软件！", "操作提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    this.Enabled = false;//界面不可使用
                    update.download();
                    Process process = new Process();//声明一个进程类对象
                    process.StartInfo.FileName = update.setup;
                    process.Start();
                    this.Close();
                }
            }
            else
            {
                if (message)
                {
                    MessageBox.Show("当前软件是最新", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
        }

        Thread testTh = null;
        /// <summary>
        /// 测试接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_test_Click(object sender, EventArgs e)
        {
            if (loadInt != 0) { MessageBox.Show("数据没有加载完成！无法进行操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (button_test.Text == "提交测试")
            {
                this.testTh = new Thread(testButton);
                this.testTh.Start();
                button_test.Text = "loading...";
            }
            else
            {
                this.testTh = null;
                button_test.Text = "提交测试";
            }
        }
        public string testHtml = "";
        /// <summary>
        /// 点击测试按钮
        /// </summary>
        public void testButton()
        {
            string encoding = comboBox_bm.Text;
            dataGridView_http_data.EndEdit();//编辑完成
            if (encoding == "")
            {
                encoding = "utf-8";
            }
            showHtml("");//html
            label_code.Text = "";//httpcode
            label_runtime.Text = "";//ms
            string url = textBox_url.Text;
            if (url == "")
            {
                button_test.Text = "提交测试";
                MessageBox.Show("url不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lib.pRunTimeNumber.start();
            string html = "";
            string urldata = pform1.objectArrayToUrlData(pform1.dataViewToObjectArray(dataGridView_http_data));
            if (comboBox_url_type.Text == "GET")
            {
                html = lib.phttp.HttpGetCustom(url, urldata, encoding);//get请求获取
            }
            else if (comboBox_url_type.Text == "POST")
            {
                html = pform1.postFile(url, dataGridView_http_data, dataGridView_header, encoding);//post文件
            }
            pform1.dataViewResponseShow(dataGridView_Response);//显示返回报文头
            pform1.webViewShow(html);//浏览器显示
            this.testHtml = html;
            lib.pRunTimeNumber.end();
            pform1.labelShowStatusRunTime(label_code, label_runtime, lib.phttp.HttpCustom_code, lib.pRunTimeNumber.result());//显示运行时间和状态
            html = pform1.toRn(checkBox_to_rn, pform1.htmlToFormatting(this.testHtml, comboBox_html_show_type, tabControl2, fastColoredTextBox_html));//格式化输出源码结果
            showHtml(html);//显示
            button_test.Text = "提交测试";
            pform1.textBoxUrlWrite(textBox_url, url);
            pform1.httpHtmlTypeDataWrite(comboBox_html_show_type);//写入HTML类型
            pform1.httpTypeWrite(comboBox_url_type);
            pform1.dataviewUrlDataWrite(dataGridView_http_data);//写入dataurl配置
            pHistory.dataViewShow(dataGridView_history, dataGridView_http_data, textBox_url.Text, comboBox_url_type.Text);//刷新历史数据
        }

        /// <summary>
        /// 变化时处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_html_show_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadInt != 0) { return; }
            showHtml(pform1.htmlToFormatting(this.testHtml, comboBox_html_show_type, tabControl2, fastColoredTextBox_html));
        }


        /// <summary>
        /// 设置可以全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_html_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }



        /// <summary>
        /// 生成文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_creation_doc_Click(object sender, EventArgs e)
        {
            pform1.createTemplateString(textBox_doc, comboBox_template, textBox_api_name.Text, comboBox_url_type.Text, pform1.dataViewUrlDataToObjectArray(dataGridView_http_data), getHtml(), textBox_url.Text);//调用生成文档模板方法
            tabControl1.SelectedIndex = 3;//切换显示生成文档
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                //System.Environment.Exit(0);
                this.Hide();
                notifyIcon_postapitools.Visible = true;
                notifyIcon_postapitools.BalloonTipText = "双击显示软件主界面";
                notifyIcon_postapitools.ShowBalloonTip(1000);
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
            }

        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        public void close()
        {
            try
            {
                System.Environment.Exit(0);
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
            }
        }

        /// <summary>
        /// 打开设置界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_setting_Click(object sender, EventArgs e)
        {
            if (loadInt != 0) { MessageBox.Show("数据没有加载完成！无法进行操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Setting setting = new Setting();
            setting.ShowDialog();
            formLoadTh = new Thread(formLoadFun);
            formLoadTh.Start();
            setting.Close();
        }

        private void textBox_doc_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }
        /// <summary>
        /// 测试文档 测试方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_test_creation_doc_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 默认浏览器打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.apizl.com");
        }

        /// <summary>
        /// 赞助支持
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label7_Click(object sender, EventArgs e)
        {
            Support support = new Support();
            support.ShowDialog();
        }


        /// <summary>
        /// 记录窗口大小变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
            int w = this.Width;
            int h = this.Height;
            if (w <= 160)
            {
                return;
            }
            if (h <= 39)
            {
                return;
            }
            //if (w < 1138)
            //{
            //    this.Size = new Size(1138, this.Size.Height);
            //    return;
            //}
            //if (h < 732)
            //{
            //    this.Size = new Size(this.Size.Width, 732);
            //    return;
            //}
            pform1.formSizeWrite(w, h);
        }

        /// <summary>
        /// 回车键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//判断回车键  
            {
                button_test_Click(null, null);//回车事件
            }
        }

        /// <summary>
        /// 历史记录单元格单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_history_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                button_new_url_http_Click(null, null);//先清理在添加数据
                string hash = dataGridView_history.Rows[e.RowIndex].Cells[0].ToolTipText;
                pHistory.fillData(dataGridView_http_data, hash, comboBox_url_type, textBox_url, fastColoredTextBox_html);//填充数据
            }
        }
        Thread buttonSaveApiTh;
        /// <summary>
        /// api接口保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_api_Click(object sender, EventArgs e)
        {
            buttonSaveApiTh = new Thread(button_save_api_ClickFun);
            buttonSaveApiTh.Start();

        }
        /// <summary>
        /// api接口保存Fun
        /// </summary>
        public void button_save_api_ClickFun()
        {
            string url = textBox_url.Text;
            string urlType = comboBox_url_type.Text;
            string[,] urlData = pform1.dataViewToStringArray(dataGridView_http_data);
            if (pForm1TreeView.isApiHash(this.editApiHash))
            {
                string name = textBox_api_name.Text;
                string desc = textBox_doc.Text;
                if (MessageBox.Show("保存文档[" + name + "]", "操作提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string urlDataStr = lib.pBase64.stringToBase64(pJson.objectToJsonStr(urlData));
                    if (pForm1TreeView.editApi(editApiHash, name, desc, url, urlDataStr, urlType))
                    {
                        pForm1TreeView.updateTreeViewText(treeView_save_list, editApiHash, name);//无刷新修改
                        //MessageBox.Show("编辑成功", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    MessageBox.Show("编辑失败:" + pForm1TreeView.error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.editApiHash = "";
            }
            SavePostApi api = new SavePostApi(urlData, url, urlType, textBox_doc.Text, treeView_save_list);
            api.ShowDialog();
            buttonSaveApiTh.Abort();
        }

        /// <summary>
        /// 请求参数单元格改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_http_data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_http_data.EndEdit();
        }

        /// <summary>
        /// 请求参数单元格删除 单击单元格内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_http_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                if ((dataGridView_http_data.Rows.Count - 1) == e.RowIndex)
                {
                    return;
                }
                dataGridView_http_data.Rows.Remove(dataGridView_http_data.Rows[e.RowIndex]);//删除单元格
            }
        }
        /// <summary>
        /// 单击单元格内容事件（打开文件对话框）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_http_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }//防止闪退
            if (dataGridView_http_data.Rows[e.RowIndex].Cells[3].Value == null && dataGridView_http_data.Rows[e.RowIndex].Cells[4].Value == null)
            {//判断是否点击了 空白
                return;
            }
            if (dataGridView_http_data.Rows[e.RowIndex].Cells[4].Value.ToString() == "删除")//创建新的列指定类型
            {
                if (dataGridView_http_data.Rows[e.RowIndex].Cells[3].Value == null)
                {
                    dataGridView_http_data.Rows[e.RowIndex].Cells[3].Value = "字符串";
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 1 && dataGridView_http_data.Rows[e.RowIndex].Cells[3].Value.ToString() == "文件")//只有选择文件时候才打开
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "所有文件|*.*";
                ofd.ValidateNames = true;
                ofd.CheckPathExists = true;
                ofd.CheckFileExists = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = ofd.FileName;
                    //其他代码
                    dataGridView_http_data.Rows[e.RowIndex].Cells[1].Value = strFileName;
                }
            }
        }


        /// <summary>
        /// 添加保存项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_add_project_Click(object sender, EventArgs e)
        {
            string name = "";
            string desc = "";
            AddProject add = new AddProject();
            add.ShowDialog();
            name = add.projectName;
            if (name == "")
            {
                return;
            }
            desc = add.projectDesc;
            add.Close();
            if (pForm1TreeView.insertMain(name, desc, treeView_save_list))
            {
                //pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);//刷新树
            }
            else
            {
                MessageBox.Show("创建项目失败:" + pForm1TreeView.error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 右键菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_save_list_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null)
            {
                return;
            }
            if (e.ClickedItem.Text == "添加")
            {
                AddPid pid = new AddPid();
                pid.ShowDialog();
                string name = pid.name;
                pid.Close();
                if (name == "") { return; }
                pForm1TreeView.insertPid(treeView_save_list, name);
                if (pForm1TreeView.error != "")
                {
                    MessageBox.Show(pForm1TreeView.error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (e.ClickedItem.Text == "删除")
            {
                if (!pForm1TreeView.deleteTreeViewSetting(treeView_save_list))
                {
                    if (pForm1TreeView.error == "") { return; }
                    MessageBox.Show(pForm1TreeView.error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);//显示项目列表树
            }
            if (e.ClickedItem.Text == "重命名")
            {
                AddPid pid = new AddPid(treeView_save_list.SelectedNode.Text);
                pid.Text = "重命名";
                pid.ShowDialog();
                string name = pid.name;
                pid.Close();
                if (name == "") { return; }
                pForm1TreeView.updateNameTreeViewSetting(treeView_save_list, name);
                //pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);//显示项目列表树
            }
            if (e.ClickedItem.Text == "查看")
            {
                string hash = treeView_save_list.SelectedNode.Name;//hash
                string text = treeView_save_list.SelectedNode.Text;//text
                if (pForm1TreeView.isApiHash(hash))
                {
                    getDocumentContent document = new getDocumentContent(hash, text);
                    document.Show();
                }
                else
                {
                    getProjectContent project = new getProjectContent(hash, text);
                    project.Show();
                }

            }
        }
        /// <summary>
        /// 刷新树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_treeview_refresh_Click(object sender, EventArgs e)
        {

            pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);//显示项目列表树
        }

        /// <summary>
        /// 编辑文档hash
        /// </summary>
        public string editApiHash = "";

        /// <summary>
        /// 双击treeView_save_list事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_save_list_DoubleClick(object sender, EventArgs e)
        {

            if (treeView_save_list.SelectedNode == null) { return; }
            if (treeView_save_list.SelectedNode.Name == null) { return; }
            string hash = treeView_save_list.SelectedNode.Name;
            string name = treeView_save_list.SelectedNode.Text;
            if (pForm1TreeView.isApiHash(hash))
            {
                this.editApiHash = hash;
            }
            pForm1TreeView.getMarkdown = "";
            pForm1TreeView.openApiDataShow(treeView_save_list, textBox_url, comboBox_url_type, dataGridView_http_data, textBox_api_name, textBox_doc);
            //Thread th = new Thread(treeView_save_list_DoubleClickFun);
            //th.Start();
        }


        private void treeView_save_list_DoubleClickFun()
        {
            if (treeView_save_list.SelectedNode == null) { return; }
            if (treeView_save_list.SelectedNode.Name == null) { return; }
            string hash = treeView_save_list.SelectedNode.Name;
            string name = treeView_save_list.SelectedNode.Text;
            if (pForm1TreeView.isApiHash(hash))
            {
                editApiHash = hash;
            }
            showHtml("");
            pForm1TreeView.openApiDataShow(treeView_save_list, textBox_url, comboBox_url_type, dataGridView_http_data, textBox_api_name, textBox_doc);
        }

        /// <summary>
        ///显示源码
        /// </summary>
        /// <param name="html"></param>
        public void showHtml(string html)
        {
            try
            {
                fastColoredTextBox_html.BeginInvoke(new Action(() =>
                {
                    fastColoredTextBox_html.Clear();
                    fastColoredTextBox_html.Text = html;
                    /**
                     * TEXT
                        JSON
                        HTML
                        XML
                        AUTO
                     **/
                    if (comboBox_html_show_type.Text == "TEXT")
                    {
                        fastColoredTextBox_html.Language = Language.CSharp;
                    }
                    if (comboBox_html_show_type.Text == "JSON")
                    {
                        fastColoredTextBox_html.Language = Language.JS;
                    }
                    if (comboBox_html_show_type.Text == "HTML")
                    {
                        fastColoredTextBox_html.Language = Language.HTML;
                    }
                    if (comboBox_html_show_type.Text == "XML")
                    {
                        fastColoredTextBox_html.Language = Language.XML;
                    }
                    if (comboBox_html_show_type.Text == "AUTO")
                    {
                        fastColoredTextBox_html.Language = Language.Custom;
                    }
                }));

            }
            catch { }

        }

        /// <summary>
        /// 获取源码
        /// </summary>
        /// <returns></returns>
        public string getHtml()
        {
            return fastColoredTextBox_html.Text;
        }
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_http_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }


        /// <summary>
        /// 搜索内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_search_Click(object sender, EventArgs e)
        {
            string search = textBox_search.Text;
            if (search == "")
            {
                pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);
                return;
            }
            pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);
            pForm1TreeView.apidocSearch(treeView_save_list, search, fastColoredTextBox_html);
        }

        /// <summary>
        /// 清理历史按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_delete_history_Click(object sender, EventArgs e)
        {
            int rows = pHistory.historyAllDelete();
            pHistory.dataViewRefresh(dataGridView_history);//刷新历史
            MessageBox.Show(string.Format("成功清理历史{0}个！", rows), "提示", MessageBoxButtons.OK, MessageBoxIcon.None);

        }

        /// <summary>
        /// 转换换行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_to_rn_Click(object sender, EventArgs e)
        {
            string html = this.testHtml;
            html = html.Replace("\n", "\r\n");
            showHtml(html);
        }

        /// <summary>
        /// 改变发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_to_rn_CheckStateChanged(object sender, EventArgs e)
        {
            pform1.toRnEvent(checkBox_to_rn);
        }

        /// <summary>
        /// 定时器任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_server_Tick(object sender, EventArgs e)
        {
            //lib.pUpdateServerWeb.updateProjectMain2();//更新主项目
            IntPtr pHandle = lib.pWinApi.GetCurrentProcess();
            lib.pWinApi.SetProcessWorkingSetSize(pHandle, -1, -1);
        }

        /// <summary>
        /// 历史滚动dataview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_history_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                //pHistory.dataViewHistoryLoading(dataGridView_history);
            }
        }

        /// <summary>
        /// 清空urldata  dataview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_urldata_dataview_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.ToString() == "清空")
            {
                dataGridView_http_data.Rows.Clear();
            }
        }

        /// <summary>
        /// url改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_url_TextChanged(object sender, EventArgs e)
        {
            if (loadInt != 0)
            {
                return;
            }
            string url = textBox_url.Text;
            if (url == "")
            {
                return;
            }
        }

        /// <summary>
        /// 新建操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_new_url_http_Click(object sender, EventArgs e)
        {
            dataGridView_http_data.Rows.Clear();
            editApiHash = "";
            textBox_url.Text = "";
            textBox_api_name.Text = "";
            textBox_doc.Text = "";
            label_code.Text = "200";
            label_runtime.Text = "0";
            showHtml("");
            webkitShowOpenLocal();
        }

        /// <summary>
        /// 便签界面
        /// </summary>
        public Memo m = null;
        /// <summary>
        /// 快捷键注册绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();//esc 隐藏窗体
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.W)//新建操作
            {
                button_new_url_http_Click(null, null);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)//保存接口事件
            {
                button_save_api_Click(null, null);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q)//打开便签
            {
                if (m == null) { m = new Memo(); }
                if (m.IsDisposed) { m = new Memo(); }
                m.Show();
            }
        }

        /// <summary>
        /// 帮助说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_help_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.ShowDialog();
        }
        /// <summary>
        /// 判断软件是否在更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Click(object sender, EventArgs e)
        {
            if (this.Enabled == false)
            {
                MessageBox.Show("请耐心等待更新结束！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void dataGridView_header_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (lib.phttp.HttpCustom_Request_Headers_Object != null)
            //{
            //    lib.phttp.HttpCustom_Request_Headers_Object.Clear();
            //}
            //WebHeaderCollection webHeader = new WebHeaderCollection();
            //for(int r=0;r<dataGridView_header.RowCount;r++)
            //{
            //    if(!dataGridView_header.Rows[r].Cells[0].Value.ToString().Trim().Equals(""))
            //    {
            //        webHeader.Add(dataGridView_header.Rows[r].Cells[0].Value.ToString().Trim(), dataGridView_header.Rows[r].Cells[1].Value.ToString().Trim());

            //    }
            //}
            //lib.phttp.HttpCustom_Request_Headers_Object = webHeader;

        }

        /// <summary>
        /// 拉取同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_pull_Click(object sender, EventArgs e)
        {
            if (Config.openServerUrl.Length <= 0) { MessageError("没有配置服务器URL无法进行操作!", "提示"); return; }

            if (MessageBox.Show("将同步所有项目！此过程很漫长！", "更新提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                button_pull.Enabled = false;
                pUpdateServerWeb.t = treeView_save_list;
                pUpdateServerWeb.image = imageList_treeview;
                pUpdateServerWeb.buttonPull = button_pull;
                pUpdateServerWeb.pullProjectMainTh();
            }
        }

        /// <summary>
        /// 权限操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_role_Click(object sender, EventArgs e)
        {
            if (Config.userToken.Length <= 0) { MessageError("没有配置服务器无法进行操作!", "提示"); return; }
            Thread th = new System.Threading.Thread((System.Threading.ThreadStart)delegate
            {
                Application.Run(new FormRole.pRoleManage());
            });
            th.SetApartmentState(ApartmentState.STA);
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            close();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 用户登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAll.pLogin login = new pLogin();
            login.ShowDialog();
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting set = new Setting();
            set.ShowDialog();
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 用户注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAll.pRegister register = new pRegister();
            register.ShowDialog();
        }

        /// <summary>
        /// 清理登录状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 清除登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认清理登录状态!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Config.websocket.stop();
                Config.userToken = "";
                pIni.write("apizlHttp", "usertoken", "");
                return;
            }
        }

        /// <summary>
        /// 帮助说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 帮助说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        /// <summary>
        /// 检测更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 检测更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateFun(true);
        }

        /// <summary>
        /// 拉取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 拉取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_pull_Click(null, null);
        }

        /// <summary>
        /// websocket 测试工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_websocket_tools_Click(object sender, EventArgs e)
        {
            WebSocket.pMain main = new WebSocket.pMain();
            main.Show();
        }



        /// <summary>
        /// 启动消息循环检测
        /// </summary>
        public void message()
        {
            Thread th = new Thread(messageTh);
            th.Start();
        }

        /// <summary>
        /// 消息循环线程检测
        /// </summary>
        public void messageTh()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (Config.websocket.messageList.Count <= 0) { continue; }
                try
                {
                    foreach (var item in Config.websocket.messageList)
                    {
                        JObject job = pJson.jsonToJobject(item.Value);
                        if (job.Count <= 0) { continue; }
                        if (job["type"].ToString() == "document_hash_update")//文档更新线程
                        {
                            Config.websocket.messageList.Remove(item.Key);
                            Thread th = new Thread(message_document_hash_update);
                            th.Start(job);
                        }
                        if (job["type"].ToString() == "document_hash_create")//文档创建线程
                        {
                            Config.websocket.messageList.Remove(item.Key);
                            Thread th = new Thread(message_document_hash_create);
                            th.Start(job);
                        }
                        if (job["type"].ToString() == "document_hash_delete")//文档删除线程
                        {
                            Config.websocket.messageList.Remove(item.Key);
                            Thread th = new Thread(message_document_hash_delete);
                            th.Start(job);
                        }

                        if (job["type"].ToString() == "project_hash_create")//创建项目线程
                        {
                            Config.websocket.messageList.Remove(item.Key);
                            Thread th = new Thread(message_project_hash_create);
                            th.Start(job);
                        }
                        if (job["type"].ToString() == "project_hash_update")//修改项目线程
                        {
                            Config.websocket.messageList.Remove(item.Key);
                            Thread th = new Thread(message_project_hash_update);
                            th.Start(job);
                        }
                        if (job["type"].ToString() == "project_hash_delete")//项目删除线程
                        {
                            Config.websocket.messageList.Remove(item.Key);
                            Thread th = new Thread(message_project_hash_delete);
                            th.Start(job);
                        }

                    }
                }
                catch { }

            }
        }


        /// <summary>
        /// project_hash_create提示线程
        /// </summary>
        /// <param name="obj"></param>
        public void message_project_hash_create(object obj)
        {
            if (obj == null) { return; }
            JObject job = (JObject)obj;
            bool resultBool = pForm1TreeView.webSocketProjectCreate(job["hash"].ToString(), treeView_save_list);//推送创建项目
            if (!resultBool) { return; }
            JObject result = pForm1TreeView.webSocketProjectCreateResult;
            if (result == null) { MessageError(pForm1TreeView.error, "提示"); return; }
            if (result.Count <= 0) { return; }
            FormAll.pLower pLower = new FormAll.pLower();
            pLower.title = "项目创建通知！ 已推送相关人员！";
            pLower.mssage = result.Count > 0 ? result["name"].ToString() : "没有相关消息";
            AnimateWindow(pLower.Handle, 1000, AW_VER_NEGATIVE | AW_ACTIVATE);//从下到上且不占其它程序焦点  
            pLower.ShowDialog();
        }

        /// <summary>
        /// project_hash_update提示线程
        /// </summary>
        /// <param name="obj"></param>
        public void message_project_hash_update(object obj)
        {
            JObject job = (JObject)obj;
            bool resultBool = pForm1TreeView.webSocketProjectUpdate(job["hash"].ToString(), treeView_save_list);//推送修改项目
            if (!resultBool) { return; }
            JObject result = pForm1TreeView.webSocketProjectCreateResult;
            if (result == null) { MessageError(pForm1TreeView.error, "提示"); return; }
            if (result.Count <= 0) { return; }
            FormAll.pLower pLower = new FormAll.pLower();
            pLower.title = "项目修改通知！ 已推送相关人员！";
            pLower.mssage = result.Count > 0 ? result["name"].ToString() : "没有相关消息";
            AnimateWindow(pLower.Handle, 1000, AW_VER_NEGATIVE | AW_ACTIVATE);//从下到上且不占其它程序焦点  
            pLower.ShowDialog();
        }

        /// <summary>
        /// project_hash_delete提示线程
        /// </summary>
        /// <param name="obj"></param>
        public void message_project_hash_delete(object obj)
        {
            JObject job = (JObject)obj;
            pForm1TreeView.webSocketProjectDelete(job["hash"].ToString());//推送删除项目
            pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);//刷新树
            Dictionary<string, string> d = pForm1TreeView.webSocketProjectDeleteResult;
            if (d == null) { return; }
            if (d.Count <= 0) { return; }
            FormAll.pLower pLower = new FormAll.pLower();
            pLower.title = "项目删除通知！ 已推送相关人员！";
            pLower.mssage = d.Count > 0 ? d["name"] : "没有相关消息";
            AnimateWindow(pLower.Handle, 1000, AW_VER_NEGATIVE | AW_ACTIVATE);//从下到上且不占其它程序焦点  
            pLower.ShowDialog();
        }


        /// <summary>
        /// document_hash_delete提示线程
        /// </summary>
        /// <param name="obj"></param>
        public void message_document_hash_delete(object obj)
        {
            JObject job = (JObject)obj;
            pForm1TreeView.webSocketDocumentDelete(job["docHash"].ToString(), treeView_save_list);//推送删除文档
            Dictionary<string, string> d = pForm1TreeView.webSocketDocumentDeleteResult;
            if (d.Count <= 0) { return; }
            FormAll.pLower pLower = new FormAll.pLower();
            pLower.title = "文档删除通知！ 已推送相关人员！";
            pLower.mssage = d.Count > 0 ? d["name"] : "没有相关消息";
            AnimateWindow(pLower.Handle, 1000, AW_VER_NEGATIVE | AW_ACTIVATE);//从下到上且不占其它程序焦点  
            pLower.ShowDialog();
        }

        /// <summary>
        /// document_hash_create提示线程
        /// </summary>
        /// <param name="obj"></param>
        public void message_document_hash_create(object obj)
        {
            JObject job = (JObject)obj;
            pForm1TreeView.webSocketDocumentCreate(job["hash"].ToString(), treeView_save_list);//推送创建一个线上文档
            Dictionary<string, string> d = pForm1TreeView.getLocalDocumentInfo(job["hash"].ToString());
            FormAll.pLower pLower = new FormAll.pLower();
            pLower.title = "文档创建通知！ 已推送相关人员！";
            pLower.mssage = d.Count > 0 ? d["name"] : "没有相关消息";
            AnimateWindow(pLower.Handle, 1000, AW_VER_NEGATIVE | AW_ACTIVATE);//从下到上且不占其它程序焦点  
            pLower.ShowDialog();
        }

        /// <summary>
        /// document_hash_update提示线程
        /// </summary>
        /// <param name="obj"></param>
        public void message_document_hash_update(object obj)
        {
            JObject job = (JObject)obj;
            pForm1TreeView.updateDocument(job["hash"].ToString());//更新一个线上文档
            pForm1TreeView.refreshTreeViewText(treeView_save_list, job["hash"].ToString());
            Dictionary<string, string> d = pForm1TreeView.getLocalDocumentInfo(job["hash"].ToString());
            FormAll.pLower pLower = new FormAll.pLower();
            pLower.title = "文档更新通知！ 已推送相关人员！";
            pLower.mssage = d.Count > 0 ? d["name"] : "没有相关消息";
            AnimateWindow(pLower.Handle, 1000, AW_VER_NEGATIVE | AW_ACTIVATE);//从下到上且不占其它程序焦点  
            pLower.ShowDialog();
        }

        /// <summary>
        /// 用户名点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_show_user_name_Click(object sender, EventArgs e)
        {
            this.skinContextMenuStrip_user_name.Show(MousePosition);
        }

        /// <summary>
        /// 用户名右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinContextMenuStrip_user_name_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.skinContextMenuStrip_user_name.Close();
            if (e.ClickedItem.ToString() == "用户登录")
            {
                用户登录ToolStripMenuItem_Click(null, null);
            }
            if (e.ClickedItem.ToString() == "清理登录")
            {
                清除登录ToolStripMenuItem_Click(null, null);
            }
        }

        /// <summary>
        /// 显示日志输出
        /// </summary>
        /// <param name="text"></param>
        public void TextShowlogs(string text, string type = "")
        {
            try
            {
                skinChatRichTextBox_logs.BeginInvoke(new Action(() =>
                {
                    string content = skinChatRichTextBox_logs.Text;
                    string newString = DateTime.Now.ToLongTimeString().ToString() + ":" + text + "\r\n";
                    skinChatRichTextBox_logs.AppendText(newString);
                    if (type == "error")
                    {
                        skinChatRichTextBox_logs.Select(content.Length, newString.Length);
                        skinChatRichTextBox_logs.SelectionColor = Color.Red;
                    }
                    this.skinChatRichTextBox_logs.SelectionStart = this.skinChatRichTextBox_logs.TextLength;
                    this.skinChatRichTextBox_logs.ScrollToCaret();
                }));
            }
            catch { }
        }

        /// <summary>
        /// 显示错误的提示框
        /// </summary>
        /// <param name="content"></param>
        /// <param name="title"></param>
        public void MessageError(string content, string title)
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 数据库管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_dataManage_Click(object sender, EventArgs e)
        {
            OpenDataBaseManage();
        }

        /// <summary>
        /// 打开databasemanage窗体
        /// </summary>
        public void OpenDataBaseManage()
        {
            Thread th = new System.Threading.Thread((System.Threading.ThreadStart)delegate
           {
               Application.Run(new FormPHPMore.pDataManage());
           });
            th.SetApartmentState(ApartmentState.STA);
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 线程中打开窗体
        /// </summary>
        public void OpenDataBaseManageFun()
        {
            FormPHPMore.pDataManage manage = new FormPHPMore.pDataManage();
            manage.Show();
        }
        /// <summary>
        /// 停止服务器更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_stop_server_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuItem_stop_server.Text == "停止更新")
            {
                Config.websocket.stop();
                ToolStripMenuItem_stop_server.Text = "启动更新";
            }
            else if (ToolStripMenuItem_stop_server.Text == "启动更新")
            {
                Config.websocket.start();
                ToolStripMenuItem_stop_server.Text = "停止更新";
            }
        }
        /// <summary>
        /// 字符串快速转换参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_stringToUrlData_Click(object sender, EventArgs e)
        {
            FormAll.pStringUrlDataTo p = new pStringUrlDataTo();
            p.Show();
        }

        /// <summary>
        /// 参数导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_out_urldata_Click(object sender, EventArgs e)
        {
            FormAll.pOutUrlData p = new pOutUrlData();
            p.Show();
        }


        /// <summary>
        /// 输出urldata显示
        /// </summary>
        /// <param name="d"></param>
        public void outUrlDataView(Dictionary<string, string> d)
        {
            DataGridView dataview = dataGridView_http_data;
            if (d.Count <= 0) { dataview.Rows.Clear(); return; }
            dataview.Invoke(new Action(() =>
            {
                dataview.Rows.Clear();
                dataview.Rows.Add(d.Count);
                int i = 0;
                foreach (var item in d)
                {
                    dataview.Rows[i].Cells[0].Value = item.Key;
                    dataview.Rows[i].Cells[1].Value = item.Value;
                    dataview.Rows[i].Cells[2].Value = "";
                    dataview.Rows[i].Cells[3].Value = "字符串";
                    dataview.Rows[i].Cells[4].Value = "删除";
                    i++;
                }
            }));
        }


        /// <summary>
        /// 输出追加urldata显示
        /// </summary>
        /// <param name="d"></param>
        public void outAppendUrlDataView(Dictionary<string, string> d)
        {
            DataGridView dataview = dataGridView_http_data;
            dataview.BeginInvoke(new Action(() =>
            {
                if (d.Count == 0) { return; }
                foreach (var item in d)
                {
                    dataview.Rows.Add(item.Key, item.Value, "", "字符串", "删除");//动态添加
                }
            }));
        }

        /// <summary>
        /// yii相关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_yii_Click(object sender, EventArgs e)
        {
            OpenDataBaseManage();
        }

        /// <summary>
        /// tp相关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_tp_Click(object sender, EventArgs e)
        {
            OpenDataBaseManage();
        }


        //WM_COPYDATA消息所要求的数据结构
        public struct CopyDataStruct
        {
            public IntPtr dwData;
            public int cbData;

            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        private const int WM_COPYDATA = 0x004A;

        /// <summary>
        /// 接收exe消息方法
        /// </summary>
        /// <param name="e"></param>
        protected override void WndProc(ref System.Windows.Forms.Message e)
        {
            if (e.Msg == WM_COPYDATA)
            {
                CopyDataStruct cds = (CopyDataStruct)e.GetLParam(typeof(CopyDataStruct));
                string result = cds.lpData.ToString();
                string[] mainArray = result.Split(':');
                if (mainArray.Length <= 1) { return; }
                string[] dataArray = mainArray[1].Split('/');
                string type = dataArray[2];
                string hash = dataArray[3];
                if (type == "getDocument")
                {
                    button_new_url_http_Click(null, null);//清空
                    editApiHash = hash;//编辑文档
                    bool s = pForm1TreeView.webOpenApiDataShow(hash, textBox_url, comboBox_url_type, dataGridView_http_data, textBox_api_name, textBox_doc);
                    lib.pWinApi.SwitchToThisWindow(f.Handle, true);//置顶
                    if (!s) { MessageBox.Show("错误:" + pForm1TreeView.error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }

            }
            base.WndProc(ref e);
        }

        /// <summary>
        /// agency
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未开放!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 加入交流群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label8_Click(object sender, EventArgs e)
        {
            lib.pBase.openWeb("https://jq.qq.com/?_wv=1027&k=5p3VuiP");
        }

        /// <summary>
        /// 检测更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_update_Click(object sender, EventArgs e)
        {
            string json = phttp.HttpGetCustom(Config.openServerUrl + "/index/api/version/", "");
            if (json.Length <= 0) { MessageBox.Show("获取更新失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            JObject job = pJsonData.stringToJobject(json);
            if (job == null) { MessageBox.Show("获取更新解析失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (job["code"].ToString() != "1") { MessageBox.Show("获取更新解析code失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            JObject result = (JObject)job["result"];
            string ServerVersion = result["version"].ToString();
            string desc = result["desc"].ToString();
            string NowVersion = Config.version;
            NowVersion = NowVersion.Replace("*", "0");
            Version now = new Version(NowVersion);
            Version server = new Version(ServerVersion);
            if (desc.Length > 100)
            {
                desc = desc.Substring(0, 100) + "...";
            }
            if (server > now)
            {
                if (MessageBox.Show("发现新版本:" + ServerVersion + "\r\n" + desc + "\r\n确定开始更新软件!", "更新提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(Config.exePath + "postApiToolsUpdate.exe");
                    close();
                }
            }
            else
            {
                if (sender == null && e == null) { return; }
                MessageBox.Show("当前已是最新版本!", "更新提示");
            }
        }

        /// <summary>
        /// 双击托盘显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_postapitools_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            lib.pWinApi.SwitchToThisWindow(f.Handle, true);//置顶
        }

        /// <summary>
        /// 托盘菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_postapitools_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null) { return; }
            if (e.ClickedItem.ToString() == "显示")
            {
                notifyIcon_postapitools_DoubleClick(null, null);
            }
            if (e.ClickedItem.ToString() == "关于")
            {
                Help help = new Help();
                help.ShowDialog();
            }
            if (e.ClickedItem.ToString() == "退出")
            {
                close();
            }
        }

        /// <summary>
        /// 获取urldata datagridview 数据
        /// </summary>
        /// <returns></returns>
        public DataGridView GetUrlDataGridViewData()
        {
            return dataGridView_http_data;
        }

        /// <summary>
        /// 关闭软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_close_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("是否关闭程序?",
                                                    "PostApiTools",
                                                    MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
                close();
        }

        /// <summary>
        /// 往doc添加文本数据
        /// </summary>
        /// <param name="text"></param>
        public void textBoxDocDataShow(string text)
        {
            this.BeginInvoke(new Action(() =>
            {
                textBox_doc.Text = text;
            }));
        }

        /// <summary>
        /// 编辑markdown右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_markdown_edit_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null) { return; }
            if (e.ClickedItem.ToString() == "markdown编辑")
            {
                markdownEdit edit = new markdownEdit();
                edit.content = textBox_doc.Text;
                edit.Show();
            }
            if (e.ClickedItem.ToString() == "清空")
            {
                this.BeginInvoke(new Action(() =>
                {
                    textBox_doc.Clear();//清空内容
                }));
            }
        }

        /// <summary>
        /// 双击文档框打开markdown界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_doc_DoubleClick(object sender, EventArgs e)
        {
            markdownEdit edit = new markdownEdit();
            edit.content = textBox_doc.Text;
            edit.Show();
        }

        /// <summary>
        /// 手动更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_update_data_Click(object sender, EventArgs e)
        {
            string hash = treeView_save_list.SelectedNode.Name;
            string name = treeView_save_list.SelectedNode.Text;
            if (Config.openServerUpdate != CheckState.Checked.ToString())
            {
                f.TextShowlogs("没有开启更新！无法使用此功能！", "error");
                return;
            }
            pUpdateServerWeb.buttonPull = button_pull;
            pUpdateServerWeb.t = treeView_save_list;
            pUpdateServerWeb.image = imageList_treeview;
            if (pForm1TreeView.isApiHash(hash))
            {
                f.TextShowlogs("开始更新文章:" + name);
                Dictionary<string, string> d = pForm1TreeView.getApi(hash);
                pForm1TreeView.updateDocument(d["server_hash"]);//更新一个线上文档
                pForm1TreeView.refreshTreeViewText(treeView_save_list, hash);
                f.TextShowlogs("更新完成:" + name);
            }
            else
            {
                f.TextShowlogs("开始更新栏目:" + name);
                pUpdateServerWeb.pullProjecrOne(hash);
                f.TextShowlogs("更新完成:" + name);
            }
        }

        /// <summary>
        /// dataview 添加新行指定参数类型 修复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_http_data_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e != null)
            {
                if (e.RowIndex == 0) { return; }
                dgv.BeginInvoke(new Action(() =>
                {
                    dgv.Rows[e.RowIndex - 1].Cells[3].Value = "字符串";
                }));
            }
        }
    }
}

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
    public partial class Form1 : CCSkinMain
    {


        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            this.dataGridView_http_data.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        public lib.updateServer update = new lib.updateServer();
        public int loadInt = 1;
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
            //timer_server.Start();//启动定时器 不能再线程中使用
            this.Text = this.Text + " 开发助手 v" + update.version + " (测试接口、生成文档) 作者:apiziliao@gmail.com  qq群:616318658";
        }
        /// <summary>
        /// 使用线程加载
        /// </summary>
        private void formLoadFun()
        {
            Thread.Sleep(500);
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
            pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);//显示项目列表树
            pform1.toRnShow(checkBox_to_rn);//自动转换选中显示
            Config.websocket.start();//启动websocket
            pform1.message();//启动消息检测
            loadInt = 0;
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
        }

        Thread testTh = null;
        /// <summary>
        /// 测试接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_test_Click(object sender, EventArgs e)
        {
            if (loadInt != 0) { MessageBox.Show("数据没有加载完成！无法进行操作！"); return; }
            if (button_test.Text == "提交测试")
            {
                this.testTh = new Thread(testButton);
                this.testTh.Start();
                button_test.Text = "loading...";
            }
            else
            {
                this.testTh.Suspend();
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
            if (encoding == "")
            {
                encoding = "utf-8";
            }
            textBox_html.Text = "";//html
            label_code.Text = "";//httpcode
            label_runtime.Text = "";//ms
            string url = textBox_url.Text;
            if (url == "")
            {
                MessageBox.Show("url不能为空");
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
            pform1.webViewShow(webBrowser1, html);//浏览器显示
            this.testHtml = html;
            lib.pRunTimeNumber.end();
            pform1.labelShowStatusRunTime(label_code, label_runtime, lib.phttp.HttpCustom_code, lib.pRunTimeNumber.result());//显示运行时间和状态

            pform1.htmlToFormatting(this.testHtml, comboBox_html_show_type, textBox_html, tabControl2);//格式化输出源码结果
            button_test.Text = "提交测试";
            pform1.textBoxUrlWrite(textBox_url, url);
            pform1.httpHtmlTypeDataWrite(comboBox_html_show_type);//写入HTML类型
            pform1.httpTypeWrite(comboBox_url_type);
            pform1.dataviewUrlDataWrite(dataGridView_http_data);//写入dataurl配置
            pHistory.dataViewShow(dataGridView_history, dataGridView_http_data, textBox_url.Text, comboBox_url_type.Text);//刷新历史数据
            pform1.toRn(checkBox_to_rn, textBox_html.Text, textBox_html);//自动换行
        }

        /// <summary>
        /// 变化时处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_html_show_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            pform1.htmlToFormatting(this.testHtml, comboBox_html_show_type, textBox_html, tabControl2);
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
            pform1.createTemplateString(textBox_html, textBox_doc, comboBox_template, textBox_api_name.Text, comboBox_url_type.Text, pform1.dataViewUrlDataToObjectArray(dataGridView_http_data), textBox_html.Text, textBox_url.Text);//调用生成文档模板方法
            tabControl1.SelectedIndex = 3;//切换显示生成文档
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { System.Environment.Exit(0); }
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
            if (loadInt != 0) { MessageBox.Show("数据没有加载完成！无法进行操作！"); return; }
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
                pHistory.fillData(dataGridView_http_data, hash, comboBox_url_type, textBox_url, textBox_html);//填充数据
            }
        }
        /// <summary>
        /// api接口保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_api_Click(object sender, EventArgs e)
        {
            string url = textBox_url.Text;
            string urlType = comboBox_url_type.Text;
            string[,] urlData = pform1.dataViewToStringArray(dataGridView_http_data);
            if (pForm1TreeView.isApiHash(editApiHash))
            {
                string name = textBox_api_name.Text;
                string desc = textBox_doc.Text;
                if (MessageBox.Show("保存文档[" + name + "]", "操作提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string urlDataStr = lib.pBase64.stringToBase64(pJson.objectToJsonStr(urlData));
                    if (pForm1TreeView.editApi(editApiHash, name, desc, url, urlDataStr, urlType))
                    {
                        pForm1TreeView.updateTreeViewText(treeView_save_list, editApiHash, name);//无刷新修改
                        MessageBox.Show("编辑成功");
                        return;
                    }
                    MessageBox.Show("编辑失败:" + pForm1TreeView.error);
                    return;
                }
                else
                {
                    return;
                }
            }
            else
            {
                editApiHash = "";
            }
            SavePostApi api = new SavePostApi(urlData, url, urlType, textBox_doc.Text);
            api.ShowDialog();
            pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);//显示项目列表树
        }

        /// <summary>
        /// 请求参数单元格改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_http_data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //textBox_html.Text = e.RowIndex.ToString() + " " + e.ColumnIndex.ToString();
            //if (e.ColumnIndex == 3 && e.RowIndex != -1 && loadInt == 0)//列内容改变事件
            //{
            //    if (dataGridView_http_data.Rows[e.RowIndex].Cells[3].Value.ToString() == "文件")//改变为文件
            //    {
            //        //DataGridViewCheckBoxColumn colDel = new DataGridViewCheckBoxColumn();
            //        DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            //        button.Name = "Column2";
            //        button.HeaderText = "值(文件)";
            //        dataGridView_http_data.Columns.RemoveAt(1);
            //        dataGridView_http_data.Columns.Insert(1, button);
            //        //dataGridView_http_data.Rows[e.RowIndex].Cells[0].
            //    }
            //    else if (dataGridView_http_data.Rows[e.RowIndex].Cells[3].Value.ToString() == "字符串")//改变为字符串
            //    {
            //        DataGridViewTextBoxColumn clumn = new DataGridViewTextBoxColumn();
            //        clumn.Name = "Column2";
            //        clumn.HeaderText = "值(字符串)";
            //        dataGridView_http_data.Columns.RemoveAt(1);
            //        dataGridView_http_data.Columns.Insert(1, clumn);
            //    }
            //}
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
            if (pForm1TreeView.insertMain(name, desc))
            {
                pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);//刷新树
            }
            else
            {
                MessageBox.Show("创建项目失败:" + pForm1TreeView.error);
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
                    MessageBox.Show(pForm1TreeView.error);
                    return;
                }
            }
            if (e.ClickedItem.Text == "删除")
            {
                if (!pForm1TreeView.deleteTreeViewSetting(treeView_save_list))
                {
                    MessageBox.Show(pForm1TreeView.error);
                }
                pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);//显示项目列表树
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
                pForm1TreeView.showMainData(treeView_save_list, imageList_treeview);//显示项目列表树
            }
            if (e.ClickedItem.Text == "查看")
            {
                openApiForm open = new openApiForm();
                open.Show();
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
            string hash = treeView_save_list.SelectedNode.Name;
            string name = treeView_save_list.SelectedNode.Text;
            if (pForm1TreeView.isApiHash(hash))
            {
                editApiHash = hash;
            }
            pForm1TreeView.openApiDataShow(treeView_save_list, textBox_url, comboBox_url_type, dataGridView_http_data, textBox_api_name, textBox_doc);
        }

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
            pForm1TreeView.apidocSearch(treeView_save_list, search, textBox_html);
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
            MessageBox.Show(string.Format("成功清理历史{0}个！", rows));

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
            textBox_html.Text = html;
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
            textBox_html.Text = "";
            webBrowser1.Navigate("about:blank");
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
                MessageBox.Show("请耐心等待更新结束！");
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
            button_pull.Enabled = false;
            pUpdateServerWeb.t = treeView_save_list;
            pUpdateServerWeb.image = imageList_treeview;
            pUpdateServerWeb.buttonPull = button_pull;
            pUpdateServerWeb.pullProjectMainTh();
        }

        private void treeView_save_list_MouseClick(object sender, MouseEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            if (tv.SelectedNode == null) { return; }
            tv.Focus();
            string Text = tv.SelectedNode.Text;
            string hash = tv.SelectedNode.Name;
            if (pForm1TreeView.isApiHash(hash))
            {
                tv.SelectedImageIndex = 1;
            }
            else
            {
                tv.SelectedImageIndex = 0;
            }
        }

        /// <summary>
        /// 权限操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_role_Click(object sender, EventArgs e)
        {
            using (FormRole.pRoleManage manage = new FormRole.pRoleManage())
            {
                manage.ShowDialog();
            }
        }
        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 用户登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Config.openServerUrl == "") { MessageBox.Show("没有设置服务器URL！","提示",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
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
            if (Config.openServerUrl == "") { MessageBox.Show("没有设置服务器URL！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
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
            if (Config.openServerUrl == "") { MessageBox.Show("没有设置服务器URL！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (MessageBox.Show("确认清理登录状态!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
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

        }

        private void 拉取ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

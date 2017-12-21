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

namespace postApiTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 界面启动时运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            pform1.textBoxUrlRead(textBox_url);
            pform1.httpHtmlTypeDataRead(comboBox_html_show_type);
            pform1.httpTypeWriteRead(comboBox_url_type);
        }

        Thread testTh = null;
        /// <summary>
        /// 测试接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_test_Click(object sender, EventArgs e)
        {
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
            textBox_html.Text = "";
            pform1.httpHtmlTypeDataWrite(comboBox_html_show_type);//写入HTML类型
            pform1.httpTypeWrite(comboBox_url_type);
            string url = textBox_url.Text;
            if (url == "")
            {
                MessageBox.Show("url不能为空");
            }
            pform1.textBoxUrlWrite(textBox_url, url);
            lib.pRunTimeNumber.start();
            string html = "";
            string urldata = pform1.objectArrayToUrlData(pform1.dataViewToObjectArray(dataGridView_http_data));
            if (comboBox_url_type.Text == "GET")
            {
                html = lib.phttp.HttpGetCustom(url, urldata);//get请求获取
            }
            else if (comboBox_url_type.Text == "POST")
            {
                html = lib.phttp.HttpPostCustom(url, urldata);//get请求获取
            }
            pform1.dataViewResponseShow(dataGridView_Response);//显示返回报文头
            pform1.webViewShow(webBrowser1, html);//浏览器显示
            this.testHtml = html;
            lib.pRunTimeNumber.end();
            pform1.labelShowStatusRunTime(label_code, label_runtime, lib.phttp.HttpCustom_code, lib.pRunTimeNumber.result());//显示运行时间和状态
            if (comboBox_html_show_type.Text == "JSON")
            {
                textBox_html.Text = pJson.jsonStrToFormat(html);//格式化json
            }
            else
            {
                textBox_html.Text = html;//显示
            }
            button_test.Text = "提交测试";
        }

        /// <summary>
        /// 变化时处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_html_show_type_SelectedIndexChanged(object sender, EventArgs e)
        {

            string html = this.testHtml;
            if (html == "")
            {
                return;
            }
            if (comboBox_html_show_type.Text == "JSON")
            {
                textBox_html.Text = pJson.jsonStrToFormat(html);//格式化json
            }
            else if (comboBox_html_show_type.Text == "HTML")
            {
                tabControl2.SelectedIndex = 1;
            }
            else
            {
                textBox_html.Text = html;//显示
            }
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
            System.Environment.Exit(0);
        }

        private void button_setting_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void textBox_doc_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }
    }
}

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

    public partial class pOutUrlData : CCSkinMain
    {
        public pOutUrlData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数据
        /// </summary>
        public List<Models.UrlDataView> UrlList = new List<Models.UrlDataView>();

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pOutUrlData_Load(object sender, EventArgs e)
        {
            this.KeyDown += keyDown;
            OutUrlList();//处理数据
            comboBox_type.SelectedIndex = 0;
        }

        /// <summary>
        /// 窗体注册事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void keyDown(object sender, EventArgs e)
        {
            if (e == null) { return; }
            KeyEventArgs key = (KeyEventArgs)e;
            if (key.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 界面启动加载
        /// </summary>
        public void OutUrlList()
        {
            DataGridView dgv = Form1.f.GetUrlDataGridViewData();
            if (dgv == null) { MessageBox.Show("获取数据列表失败！或重新启动软件！"); return; }
            int row = dgv.Rows.Count - 1;
            for (int i = 0; i < row; i++)
            {
                var temp = new Models.UrlDataView
                {
                    name = dgv.Rows[i].Cells[0].Value.ToString(),
                    value = dgv.Rows[i].Cells[1].Value.ToString(),
                    desc = dgv.Rows[i].Cells[2].Value.ToString(),
                    type = dgv.Rows[i].Cells[3].Value.ToString(),
                };
                UrlList.Add(temp);
            }

        }

        /// <summary>
        /// 生成导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_create_Click(object sender, EventArgs e)
        {

            if (UrlList.Count <= 0) { return; }

            lib.pFormRichTextBox f = new lib.pFormRichTextBox();
            StringBuilder sb = new StringBuilder();
            JObject job = new JObject();
            List<Models.NameValue> list = new List<Models.NameValue>();
            foreach (var item in UrlList)
            {
                if (comboBox_type.Text == "JSON")
                {
                    var temp = new Models.NameValue { name = item.name, value = item.value };
                    list.Add(temp);
                }
                if (comboBox_type.Text == "JSON-键值对")
                {
                    job.Add(item.name, item.value);
                }
                if (comboBox_type.Text == "Input")
                {
                    if (checkBox_name.CheckState == CheckState.Checked && checkBox_value.CheckState == CheckState.Checked && checkBox_desc.CheckState == CheckState.Unchecked)
                    {
                        sb.AppendLine(string.Format("<input type='text' name='{0}' value='{1}'/>", item.name, item.value));
                    }
                    if (checkBox_name.CheckState == CheckState.Checked && checkBox_value.CheckState == CheckState.Checked && checkBox_desc.CheckState == CheckState.Checked)
                    {
                        sb.AppendLine(string.Format("<input type='text' name='{0}' value='{1}' placeholder='{2}'/>", item.name, item.value, item.desc));
                    }
                }

            }
            //循环结束

            if (comboBox_type.Text == "JSON")
            {
                f.textShow(richTextBox_result, lib.pJsonData.objectToString(list));
            }
            if (comboBox_type.Text == "Input")
            {
                f.textShow(richTextBox_result, sb.ToString());
            }
            if (comboBox_type.Text == "JSON-键值对")
            {
                f.textShow(richTextBox_result, job.ToString());
            }
        }
    }
}

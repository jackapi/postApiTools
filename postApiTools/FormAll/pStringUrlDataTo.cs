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
    using CCWin.SkinControl;
    using Newtonsoft.Json.Linq;

    public partial class pStringUrlDataTo : CCSkinMain
    {
        public pStringUrlDataTo()
        {
            InitializeComponent();
            skinComboBox1.Text = "JSON";//json
        }

        /// <summary>
        /// 显示传入参数
        /// </summary>
        /// <param name="content"></param>
        public void showContent(string content)
        {
            skinChatRichTextBox_content.Text = content;
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="content"></param>
        public void contentWrite(string content)
        {
            content = lib.pBase64.stringToBase64(content);
            lib.pFile.Write(Config.dataPath + "StringUrlDataTo.ini", content);
        }

        /// <summary>
        /// 读取
        /// </summary>
        public string contentRead()
        {
            string content = lib.pFile.Read(Config.dataPath + "StringUrlDataTo.ini");
            content = lib.pBase64.base64ToString(content);
            return content;
        }


        /// <summary>
        /// 导入参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_save_Click(object sender, EventArgs e)
        {
            Form1.f.outUrlDataView(changeDataView());//输出
        }

        Dictionary<string, string> urlData = new Dictionary<string, string> { };

        /// <summary>
        /// 转换成参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_create_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> d = new Dictionary<string, string> { };
            string type = skinComboBox1.Text;
            string content = skinChatRichTextBox_content.Text;
            if (content == "")
            {
                return;
            }
            contentWrite(content);//写入
            if (type == "JSON")
            {
                JObject job = lib.pJsonData.stringToJobject(content);
                if (lib.pJsonData.error.Length > 0)//判断是否有转换错误
                {
                    MessageBox.Show("转换错误：" + lib.pJsonData.error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (job == null) { return; }
                foreach (var item in job)
                {
                    d.Add(item.Key, item.Value.ToString());
                }
                urlData = d;
                outDataView(d);//显示
            }
            if (type == "URLDATA")
            {
                try
                {
                    string[] item = content.Split('&');
                    for (int i = 0; i < item.Length; i++)
                    {
                        string[] data = item[i].Split('=');
                        d.Add(data[0], data[1]);
                    }
                    urlData = d;
                    outDataView(urlData);//显示
                }
                catch
                {
                    MessageBox.Show("转换错误 请使用正确的URL", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        /// <summary>
        /// 输出data显示
        /// </summary>
        /// <param name="d"></param>
        public void outDataView(Dictionary<string, string> d)
        {
            SkinDataGridView dataview = skinDataGridView1;
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
                    dataview.Rows[i].Cells[2].Value = "删除";
                    i++;
                }
            }));
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pStringUrlDataTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)//关闭界面
            {
                this.Close();
            }
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pStringUrlDataTo_Load(object sender, EventArgs e)
        {
            skinChatRichTextBox_content.Text = contentRead();
        }

        /// <summary>
        /// 右键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinContextMenuStrip_text_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null) { return; }
            if (e.ClickedItem.ToString() == "清空")
            {
                skinChatRichTextBox_content.Text = "";
            }
            if (e.ClickedItem.ToString() == "粘贴")
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    skinChatRichTextBox_content.Text = (String)iData.GetData(DataFormats.Text);
                }

            }
        }

        /// <summary>
        /// 修改时候处理数据
        /// </summary>
        public Dictionary<string, string> changeDataView()
        {
            try
            {
                SkinDataGridView dataview = skinDataGridView1;
                dataview.EndEdit();//编辑完成
                Dictionary<string, string> newUrlData = new Dictionary<string, string> { };
                int count = dataview.Rows.Count - 1;
                for (int i = 0; i < count; i++)
                {
                    newUrlData.Add(dataview.Rows[i].Cells[0].Value.ToString(), dataview.Rows[i].Cells[1].Value.ToString());
                }
                return newUrlData;
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
                MessageBox.Show("导入表格错误提示:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_append_Click(object sender, EventArgs e)
        {
            Form1.f.outAppendUrlDataView(changeDataView());//追加输出
        }

        /// <summary>
        /// 删除dataview内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2) { return; }
            SkinDataGridView dataview = skinDataGridView1;
            if (dataview.Rows[e.RowIndex].Cells[2].Value != "删除") { return; }
            DataGridViewRow rowsData = dataview.Rows[e.RowIndex];
            if (rowsData == null) { return; }
            string key = dataview.Rows[e.RowIndex].Cells[0].Value.ToString();//获取key
            urlData.Remove(key);//删除list
            dataview.Rows.Remove(rowsData);
        }
    }
}

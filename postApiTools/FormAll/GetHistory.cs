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
/// 查看历史请求参数数据
/// </summary>
namespace postApiTools.FormAll
{
    using CCWin;
    using FastColoredTextBoxNS;

    public partial class GetHistory : CCSkinMain
    {
        string html = "";
        string dataUrl = "";
        public GetHistory(string title, string hash, Dictionary<string, string> data)
        {
            InitializeComponent();
            LoadFormSizeChange();//控制窗体大小
            this.Text = title;
            textBox_url.Text = data["url"];
            label_urltype.Text = data["method"];
            fastColoredTextBox_result.Text = lib.pBase64.base64ToString(data["result"]);
            fastColoredTextBox_postjson.Text = lib.pBase64.base64ToString(data["postjson"]);
            fastColoredTextBox_result.Language = Language.JS;
            html = lib.pBase64.base64ToString(data["result"]);
            dataUrl = data["dataurl"];
        }

        /// <summary>
        /// 改变窗体大小
        /// </summary>
        public void LoadFormSizeChange()
        {
            string wString = lib.pIni.read("GetHistory", "form-w");
            string hString = lib.pIni.read("GetHistory", "form-h");
            if (wString != "" && hString != "")
            {
                this.Width = Int32.Parse(wString);//宽
                this.Height = Int32.Parse(hString);//高
            }
        }

        /// <summary>
        /// 加载dataview 请求参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetHistory_Load(object sender, EventArgs e)
        {
            DataGridView dd = dataGridView_urldata;
            string str = lib.pBase64.base64ToString(dataUrl);
            string[,] array = pJson.jsonStrToObjectArrayString(str, 3);//获取字符串数组
            dd.Invalidate();//重新绘制
            dd.Rows.Clear();//清理行数
            if (array != null)
            {
                if (array.GetLength(0) > 0)
                {
                    dd.Rows.Add(array.GetLength(0));
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        dd.Rows[i].Cells[0].Value = array[i, 0];
                        dd.Rows[i].Cells[1].Value = array[i, 1];
                        //dd.Rows[i].Cells[2].Value = array[i, 2];
                        dd.Rows[i].Cells[2].Value = lib.pBase.dataGridViewHttpDataValueToTypeListName(array[i, 2]);//输出类型
                    }
                }
            }
        }

        /// <summary>
        /// 调整窗体大小时候进行记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetHistory_Resize(object sender, EventArgs e)
        {
            int w = this.Width;//宽
            int h = this.Height;//高
            lib.pIni.write("GetHistory", "form-w", w.ToString());
            lib.pIni.write("GetHistory", "form-h", h.ToString());
        }
    }
}

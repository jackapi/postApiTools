using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.lib
{
    public class pFormRichTextBox
    {
        /// <summary>
        /// 延时
        /// </summary>
        public int sleep = 10;

        /// <summary>
        /// 数据长度清理
        /// </summary>
        public int textLengthClear = 90000;

        /// <summary>
        /// 单次显示
        /// </summary>
        /// <param name="rtb"></param>
        /// <param name="text"></param>
        public void textShow(RichTextBox rtb, string text)
        {
            rtb.Invoke(new Action(() =>
            {
                rtb.Clear();
                rtb.AppendText(text);
                rtb.SelectionStart = rtb.TextLength;
                rtb.ScrollToCaret();
            }));
        }
        /// <summary>
        /// 追加字符串
        /// </summary>
        /// <param name="rtb"></param>
        /// <param name="text"></param>
        public void textAppend(RichTextBox rtb, string text)
        {
            rtb.Invoke(new Action(() =>
            {
                if (rtb.Text.Length >= textLengthClear) { rtb.Clear(); }//超出清理
                rtb.AppendText(text + "\r\n");
                rtb.SelectionStart = rtb.TextLength;
                rtb.ScrollToCaret();
                Thread.Sleep(sleep);
            }));
        }

        public void textAppend(RichTextBox rtb, string text, Color color)
        {

        }
    }
}

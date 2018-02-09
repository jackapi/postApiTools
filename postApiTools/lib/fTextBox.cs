using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// textbox 相关处理
/// </summary>
namespace postApiTools.lib
{
    public class fTextBox
    {
        /// <summary>
        /// textbox 自动填充
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="list"></param>
        public static void TextBoxAutoComplete(TextBox tb, string[] list)
        {
            try
            {
                var source = new AutoCompleteStringCollection();
                source.AddRange(list);
                tb.BeginInvoke(new Action(() =>
                {
                    tb.AutoCompleteCustomSource = source;
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }));
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
            }
        }
    }
}

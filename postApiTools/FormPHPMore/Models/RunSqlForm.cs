using CCWin.SkinControl;
using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.FormPHPMore.Models
{
    /// <summary>
    /// RunSqlForm 自定义sql查询
    /// </summary>
    public class RunSqlForm
    {
        public SkinButton button { set; get; }//查询按钮
        public FastColoredTextBox fctb { set; get; }//输入框
        public FastColoredTextBox errorFctb { set; get; }//错误信息显示
        public DataGridView datagridview { set; get; }//结果显示框
        public SkinTabPage stp { set; get; }//当前tabpage框
        public string selectHash { set; get; }
    }
}

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
/// tp迁移生成
/// </summary>
namespace postApiTools.FormPHPMore
{
    using CCWin;
    using FastColoredTextBoxNS;

    public partial class CreateTpMigrate : CCSkinMain
    {
        string hash = "";

        public CreateTpMigrate(string hash)
        {
            InitializeComponent();
            this.hash = hash;
        }

        /// <summary>
        /// 启动加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateTpMigrate_Load(object sender, EventArgs e)
        {

            textBox_php.Text = lib.pIni.read("database", "php_path");//加载 
            textBox_tp.Text = lib.pIni.read("database", "tp_path");//加载
            fastColoredTextBox_result.BeginInvoke(new Action(() =>
            {
                fastColoredTextBox_result.Language = Language.PHP;
            }));
        }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_create_Click(object sender, EventArgs e)
        {
            string php = textBox_php.Text;
            string tp = textBox_tp.Text;
            if (php == "")
            {
                MessageBox.Show("请先选择PHP路径", "提示");
                return;
            }
            if (tp == "")
            {
                MessageBox.Show("请先选择Tp路径", "提示");
                return;
            }
            lib.pIni.write("database", "php_path", php);//
            lib.pIni.write("database", "tp_path", tp);//
        }

        private void button_php_Click(object sender, EventArgs e)
        {

        }

        private void button_tp_Click(object sender, EventArgs e)
        {

        }
    }
}

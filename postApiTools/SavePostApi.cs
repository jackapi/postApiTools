using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools
{
    using CCWin;
    public partial class SavePostApi : CCSkinMain
    {
        /// <summary>
        /// url参数
        /// </summary>
        private string[,] urlData = null;
        /// <summary>
        /// url
        /// </summary>
        private string url = "";
        /// <summary>
        /// url类型
        /// </summary>
        private string urlType = "";
        /// <summary>
        /// 接口文档
        /// </summary>
        private string desc = "";
        private TreeView tv = null;
        public SavePostApi(string[,] urlData, string url, string urlType, string desc, TreeView tv)
        {
            InitializeComponent();
            this.urlData = urlData;
            this.url = url;
            this.urlType = urlType;
            this.desc = desc;
            this.tv = tv;
        }

        /// <summary>
        /// 数据加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavePostApi_Load(object sender, EventArgs e)
        {
            textBox_url.Text = this.url;
            textBox_desc.Text = this.desc;
            pForm1TreeView.showMainData(treeView, imageList_treeview);//加载树
        }

        /// <summary>
        /// 保存接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text;
            string desc = textBox_desc.Text;
            if (name == "")
            {
                MessageBox.Show("名称不能为空");
                return;
            }

            if (desc == "")
            {
                if (MessageBox.Show("没有接口文档还是保存么？？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }
            }
            if (pForm1TreeView.addApi(treeView, name, desc, url, urlType, urlData))
            {
                TreeNode tn = pForm1TreeView.FindNodeByName(tv.Nodes, treeView.SelectedNode.Name);//返回节点
                tv.Invoke(new Action(() =>
                {
                    TreeNode addtn = tn.Nodes.Add(pForm1TreeView.addApiHash, name);//无刷新显示添加
                    addtn.ImageIndex = 1; //设置显示图片
                    addtn.SelectedImageIndex = 1;//设置显示图片
                }));
            }
            else
            {
                MessageBox.Show("添加失败 请重试：" + pForm1TreeView.error);
                return;
            }
            this.Close();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 键盘注册事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavePostApi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)//esc按键关闭窗口
            {
                this.Close();
            }
        }
    }
}

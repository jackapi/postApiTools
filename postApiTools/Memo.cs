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
    using FormClass;
    using MaterialSkin;
    using MaterialSkin.Controls;

    public partial class Memo : lib.pMaterialSkin
    {
        private readonly MaterialSkinManager materialSkinManager;
        public Memo()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            seedListView();
        }
        /// <summary>
        /// 界面关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Memo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close();
        }


        private void seedListView()
        {
            materialListView1.Items.Clear();
            Dictionary<int, object> list = pMemo.getRows();
            string[][] temp = new string[list.Count][];
            for (int i = 0; i < list.Count; i++)
            {
                Dictionary<string, string> array = (Dictionary<string, string>)list[i];
                temp[i] = new[] { array["content"] };
                var item = new ListViewItem(temp[i]);
                materialListView1.Items.Add(item);
            }
        }


        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Memo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)//esc 关闭
            {
                this.Close();
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q)//关闭
            {
                this.Close();
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)//快速保存
            {
                materialRaisedButton1_Click(null, null);
            }
        }
        /// <summary>
        /// 添加便签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            string content = textBox1.Text;
            if (content == "")
            {
                return;
            }
            if (!pMemo.insert(content))
            {
                MessageBox.Show("添加失败:" + pMemo.error);
            }
            textBox1.Text = "";
            seedListView();
        }


        /// <summary>
        /// 右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void materialContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            materialContextMenuStrip1.Close();
            if (e.ClickedItem.ToString() == "清空")
            {
                if (MessageBox.Show("确认清空", "操作提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                int count = pMemo.deleteAll();
                MessageBox.Show(string.Format("清空了:{0}个", count.ToString()));
                materialListView1.Items.Clear();
                return;
            }
            if (e.ClickedItem.ToString() == "删除")
            {

                if (MessageBox.Show("确认删除", "操作提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                string content = materialListView1.FocusedItem.Text.ToString();
                pMemo.delete(content);
                seedListView();
                return;
            }
            if (e.ClickedItem.ToString() == "归零")
            {
                string content = materialListView1.FocusedItem.Text.ToString();
                pMemo.editClick(content, 0);//更新click
                seedListView();
                return;
            }
        }

        /// <summary>
        /// 双击控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void materialListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MaterialListView m = (MaterialListView)sender;
            if (m.FocusedItem.Text.ToString() != "")
            {
                pMemo.editClick(m.FocusedItem.Text.ToString());//更新click
                Clipboard.SetDataObject(m.FocusedItem.Text.ToString());//复制到剪切板
                this.Close();//隐藏界面
            }
        }
    }
}

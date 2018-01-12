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
    public partial class AddPid : CCSkinMain
    {
        public AddPid(string name = "")
        {
            InitializeComponent();
            textBox_name.Text = name;
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public string name = "";
        private void button_save_Click(object sender, EventArgs e)
        {
            this.name = textBox_name.Text;
            if (name == "")
            {
                MessageBox.Show("名称不能为空");
                return;
            }
            this.Hide();
        }

        private void AddPid_Load(object sender, EventArgs e)
        {

        }
    }
}

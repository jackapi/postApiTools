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
    using lib;
    public partial class Help : CCSkinMain
    {
        updateServer update = new updateServer();
        public Help()
        {
            InitializeComponent();
        }
        Dictionary<string, string> supply = new Dictionary<string, string> { };

        /// <summary>
        /// 项目显示
        /// </summary>
        public void supplyAdd()
        {
            supply.Add("MaterialSkin", "https://github.com/IgnaceMaes/MaterialSkin");
            supply.Add("cskin", "http://www.cskin.net");
            supply.Add("Newtonsoft.Json", "https://www.newtonsoft.com/json");
            supply.Add("websocket-sharp", "https://github.com/sta/websocket-sharp");
            supply.Add("mysql", "https://dev.mysql.com/");
            supply.Add("WebKit .NET", "http://webkitdotnet.sourceforge.net/");
            int i = 1;
            foreach (var item in supply)
            {
                int y = i * 20;
                Label label = new Label();
                label.Name = "lable_" + item.Key;
                label.Text = item.Key;
                label.Width = 100;
                label.Tag = item.Key;
                label.Location = new Point(12, y);
                tabPage2.Controls.Add(label);

                LinkLabel link = new LinkLabel();
                link.Name = "link_" + item.Key;
                link.Text = item.Value;
                link.Location = new Point(120, y);
                link.Width = 239;
                link.Tag = item.Value;
                link.Click += new EventHandler(linkLabel_Clicked);
                tabPage2.Controls.Add(link);
                i++;

            }
        }

        private void Help_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = lib.pFile.Read(Config.dataPath + "help.key.txt");
            richTextBox2.Text = update.getVersionDesc();
            supplyAdd();
        }

        private void linkLabel_Clicked(object sender, EventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            if (link == null) { return; }
            pBase.openWeb(link.Text);
        }
    }
}

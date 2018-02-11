using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.FormPHPMore.Data
{
    using CCWin;
    public partial class DataBaseInfo : CCSkinMain
    {
        string hash = "";
        public DataBaseInfo(string hash)
        {
            InitializeComponent();
            this.hash = hash;
        }

        private void DataBaseInfo_Load(object sender, EventArgs e)
        {
            Data.pDataManageClass p = new Data.pDataManageClass();
            Dictionary<string, string> database = p.getDataBaseHash(this.hash);
            if (database.Count <= 0) { return; }
            try
            {
                ContextMenuStrip cms = new ContextMenuStrip();
                cms.Name = "cms";
                cms.ItemClicked += cmsClick;
                cms.Items.Add("复制");

                Label labelName = new Label();
                labelName.Text = "名称";
                labelName.Width = 50;
                labelName.Location = new Point(30, 50);
                Label labelNameContent = new Label();
                labelNameContent.Text = database["name"];
                labelNameContent.Location = new Point(100, 50);
                labelNameContent.ContextMenuStrip = cms;
                this.Controls.Add(labelName);
                this.Controls.Add(labelNameContent);

                Label labelType = new Label();
                labelType.Text = "类型";
                labelType.Width = 50;
                labelType.Location = new Point(30, 80);
                Label labelTypeContent = new Label();
                labelTypeContent.Text = database["type"];
                labelTypeContent.Location = new Point(100, 80);
                this.Controls.Add(labelType);
                this.Controls.Add(labelTypeContent);

                Label labelpath = new Label();
                labelpath.Text = "路径";
                labelpath.Width = 50;
                labelpath.Location = new Point(30, 110);
                Label labelpathContent = new Label();
                labelpathContent.Text = database["path"];
                labelpathContent.Location = new Point(100, 110);
                this.Controls.Add(labelpath);
                this.Controls.Add(labelpathContent);

                Label labelIP = new Label();
                labelIP.Text = "IP";
                labelIP.Width = 50;
                labelIP.Location = new Point(30, 140);
                Label labelIPContent = new Label();
                labelIPContent.Text = database["ip"];
                labelIPContent.Location = new Point(100, 140);
                this.Controls.Add(labelIP);
                this.Controls.Add(labelIPContent);

                Label labelPort = new Label();
                labelPort.Text = "PORT";
                labelPort.Width = 50;
                labelPort.Location = new Point(30, 170);
                Label labelPortContent = new Label();
                labelPortContent.Text = database["port"];
                labelPortContent.Location = new Point(100, 170);
                this.Controls.Add(labelPort);
                this.Controls.Add(labelPortContent);

                Label labelUserName = new Label();
                labelUserName.Text = "UserName";
                labelUserName.Width = 50;
                labelUserName.Location = new Point(30, 200);
                Label labelUserNameContent = new Label();
                labelUserNameContent.Text = database["username"];
                labelUserNameContent.Location = new Point(100, 200);
                this.Controls.Add(labelUserName);
                this.Controls.Add(labelUserNameContent);

                Label labelPassword = new Label();
                labelPassword.Text = "password";
                labelPassword.Width = 50;
                labelPassword.Location = new Point(30, 230);
                Label labelPasswordContent = new Label();
                labelPasswordContent.Text = database["password"];
                labelPasswordContent.Location = new Point(100, 230);
                this.Controls.Add(labelPassword);
                this.Controls.Add(labelPasswordContent);

                Label labelEncoding = new Label();
                labelEncoding.Text = "编码";
                labelEncoding.Width = 50;
                labelEncoding.Location = new Point(30, 270);
                Label labelEncodingContent = new Label();
                labelEncodingContent.Text = database["encoding"];
                labelEncodingContent.Location = new Point(100, 270);
                this.Controls.Add(labelEncoding);
                this.Controls.Add(labelPasswordContent);
            }
            catch (Exception ex)
            {
                pLogs.logs(ex.ToString());
            }
        }

        public void cmsClick(object obj1, object obj2)
        {

        }
        public void copyInfo()
        {
        }

        private void skinButton_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

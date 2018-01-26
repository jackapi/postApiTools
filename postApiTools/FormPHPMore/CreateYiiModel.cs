using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.FormPHPMore
{
    using CCWin;
    public partial class CreateYiiModel : CCSkinMain
    {
        string hash = "";
        Dictionary<int, object> list = new Dictionary<int, object> { };
        public CreateYiiModel(Dictionary<int, object> list = null, string hash = "")
        {
            InitializeComponent();
            this.list = list;
            this.hash = hash;
        }

        private void CreateYiiModel_Load(object sender, EventArgs e)
        {

        }

        private void skinButton_create_Click(object sender, EventArgs e)
        {
            string modelName = textBox_model_name.Text;
            string content = lib.pFile.Read(Config.dataPath + "yii-models.txt");
            content = content.Replace("{$model-name}", modelName);
            skinChatRichTextBox1.Text = content;
        }
    }
}

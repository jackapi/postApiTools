using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiTools.FormAll
{
    using CCWin;
    public partial class getProjectContent : CCSkinMain
    {
        string hash = "";
        string name = "";

        public getProjectContent(string hash = "", string name = "")
        {
            InitializeComponent();
            this.hash = hash;
            this.name = name;
            this.Text = this.Text + name;
        }
    }
}

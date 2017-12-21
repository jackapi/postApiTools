namespace postApiTools
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_test = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.comboBox_url_type = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView_http_data = new System.Windows.Forms.DataGridView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.comboBox_html_show_type = new System.Windows.Forms.ComboBox();
            this.textBox_html = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView_Response = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.textBox_doc = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_creation_doc = new System.Windows.Forms.Button();
            this.button_test_creation_doc = new System.Windows.Forms.Button();
            this.comboBox_template = new System.Windows.Forms.ComboBox();
            this.button_setting = new System.Windows.Forms.Button();
            this.comboBox_bm = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_code = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_runtime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_api_name = new System.Windows.Forms.TextBox();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_http_data)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Response)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(764, 12);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 23);
            this.button_test.TabIndex = 0;
            this.button_test.Text = "提交测试";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(152, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 10);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL";
            // 
            // textBox_url
            // 
            this.textBox_url.Location = new System.Drawing.Point(187, 11);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(571, 21);
            this.textBox_url.TabIndex = 2;
            // 
            // comboBox_url_type
            // 
            this.comboBox_url_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_url_type.FormattingEnabled = true;
            this.comboBox_url_type.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.comboBox_url_type.Location = new System.Drawing.Point(19, 14);
            this.comboBox_url_type.Name = "comboBox_url_type";
            this.comboBox_url_type.Size = new System.Drawing.Size(121, 20);
            this.comboBox_url_type.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(191, 76);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(919, 580);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_http_data);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(911, 554);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView_http_data
            // 
            this.dataGridView_http_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_http_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column12});
            this.dataGridView_http_data.Location = new System.Drawing.Point(10, 3);
            this.dataGridView_http_data.Name = "dataGridView_http_data";
            this.dataGridView_http_data.RowTemplate.Height = 23;
            this.dataGridView_http_data.Size = new System.Drawing.Size(888, 120);
            this.dataGridView_http_data.TabIndex = 8;
            this.dataGridView_http_data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_http_data_CellContentClick);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(6, 129);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(899, 419);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.comboBox_html_show_type);
            this.tabPage4.Controls.Add(this.textBox_html);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(891, 393);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "源码";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // comboBox_html_show_type
            // 
            this.comboBox_html_show_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_html_show_type.FormattingEnabled = true;
            this.comboBox_html_show_type.Items.AddRange(new object[] {
            "TEXT",
            "JSON",
            "HTML",
            "XML",
            "AUTO"});
            this.comboBox_html_show_type.Location = new System.Drawing.Point(9, 6);
            this.comboBox_html_show_type.Name = "comboBox_html_show_type";
            this.comboBox_html_show_type.Size = new System.Drawing.Size(128, 20);
            this.comboBox_html_show_type.TabIndex = 1;
            this.comboBox_html_show_type.SelectedIndexChanged += new System.EventHandler(this.comboBox_html_show_type_SelectedIndexChanged);
            // 
            // textBox_html
            // 
            this.textBox_html.Location = new System.Drawing.Point(9, 32);
            this.textBox_html.Multiline = true;
            this.textBox_html.Name = "textBox_html";
            this.textBox_html.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_html.Size = new System.Drawing.Size(879, 355);
            this.textBox_html.TabIndex = 0;
            this.textBox_html.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_html_KeyPress);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.webBrowser1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(891, 393);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "浏览器";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(3, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(885, 390);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(911, 554);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "提交报文";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView3.Location = new System.Drawing.Point(3, 3);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(902, 545);
            this.dataGridView3.TabIndex = 0;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "键";
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "值";
            this.Column5.Name = "Column5";
            this.Column5.Width = 300;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "说明";
            this.Column6.Name = "Column6";
            this.Column6.Width = 200;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView_Response);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(911, 554);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "返回报文";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Response
            // 
            this.dataGridView_Response.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Response.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridView_Response.Location = new System.Drawing.Point(3, 0);
            this.dataGridView_Response.Name = "dataGridView_Response";
            this.dataGridView_Response.RowTemplate.Height = 23;
            this.dataGridView_Response.Size = new System.Drawing.Size(905, 551);
            this.dataGridView_Response.TabIndex = 0;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "键";
            this.Column7.Name = "Column7";
            this.Column7.Width = 200;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "值";
            this.Column8.Name = "Column8";
            this.Column8.Width = 300;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "说明";
            this.Column9.Name = "Column9";
            this.Column9.Width = 200;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.textBox_doc);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(911, 554);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "生成文档";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // textBox_doc
            // 
            this.textBox_doc.AcceptsReturn = true;
            this.textBox_doc.Location = new System.Drawing.Point(6, 6);
            this.textBox_doc.Multiline = true;
            this.textBox_doc.Name = "textBox_doc";
            this.textBox_doc.Size = new System.Drawing.Size(902, 545);
            this.textBox_doc.TabIndex = 0;
            this.textBox_doc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_doc_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(173, 575);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "类型";
            this.Column10.Name = "Column10";
            this.Column10.Width = 60;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "URL";
            this.Column11.Name = "Column11";
            // 
            // button_creation_doc
            // 
            this.button_creation_doc.Location = new System.Drawing.Point(548, 41);
            this.button_creation_doc.Name = "button_creation_doc";
            this.button_creation_doc.Size = new System.Drawing.Size(75, 23);
            this.button_creation_doc.TabIndex = 5;
            this.button_creation_doc.Text = "生成文档";
            this.button_creation_doc.UseVisualStyleBackColor = true;
            this.button_creation_doc.Click += new System.EventHandler(this.button_creation_doc_Click);
            // 
            // button_test_creation_doc
            // 
            this.button_test_creation_doc.Location = new System.Drawing.Point(629, 41);
            this.button_test_creation_doc.Name = "button_test_creation_doc";
            this.button_test_creation_doc.Size = new System.Drawing.Size(75, 23);
            this.button_test_creation_doc.TabIndex = 5;
            this.button_test_creation_doc.Text = "测试文档";
            this.button_test_creation_doc.UseVisualStyleBackColor = true;
            this.button_test_creation_doc.Click += new System.EventHandler(this.button_test_creation_doc_Click);
            // 
            // comboBox_template
            // 
            this.comboBox_template.FormattingEnabled = true;
            this.comboBox_template.Location = new System.Drawing.Point(463, 44);
            this.comboBox_template.Name = "comboBox_template";
            this.comboBox_template.Size = new System.Drawing.Size(79, 20);
            this.comboBox_template.TabIndex = 6;
            this.comboBox_template.Text = "默认模板";
            // 
            // button_setting
            // 
            this.button_setting.Location = new System.Drawing.Point(710, 41);
            this.button_setting.Name = "button_setting";
            this.button_setting.Size = new System.Drawing.Size(75, 23);
            this.button_setting.TabIndex = 7;
            this.button_setting.Text = "设置";
            this.button_setting.UseVisualStyleBackColor = true;
            this.button_setting.Click += new System.EventHandler(this.button_setting_Click);
            // 
            // comboBox_bm
            // 
            this.comboBox_bm.FormattingEnabled = true;
            this.comboBox_bm.Items.AddRange(new object[] {
            "UTF-8",
            "GBK",
            "GB2312",
            "GB18030",
            "Unicode"});
            this.comboBox_bm.Location = new System.Drawing.Point(847, 14);
            this.comboBox_bm.Name = "comboBox_bm";
            this.comboBox_bm.Size = new System.Drawing.Size(92, 20);
            this.comboBox_bm.TabIndex = 8;
            this.comboBox_bm.Text = "UTF-8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(791, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Code:";
            // 
            // label_code
            // 
            this.label_code.AutoSize = true;
            this.label_code.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_code.ForeColor = System.Drawing.Color.Green;
            this.label_code.Location = new System.Drawing.Point(832, 40);
            this.label_code.Name = "label_code";
            this.label_code.Size = new System.Drawing.Size(43, 21);
            this.label_code.TabIndex = 10;
            this.label_code.Text = "200";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(885, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 11;
            this.label4.Tag = "";
            this.label4.Text = "时间:";
            // 
            // label_runtime
            // 
            this.label_runtime.AutoSize = true;
            this.label_runtime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_runtime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label_runtime.Location = new System.Drawing.Point(924, 43);
            this.label_runtime.Name = "label_runtime";
            this.label_runtime.Size = new System.Drawing.Size(16, 16);
            this.label_runtime.TabIndex = 12;
            this.label_runtime.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "模板";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "接口名称";
            // 
            // textBox_api_name
            // 
            this.textBox_api_name.Location = new System.Drawing.Point(293, 43);
            this.textBox_api_name.Name = "textBox_api_name";
            this.textBox_api_name.Size = new System.Drawing.Size(125, 21);
            this.textBox_api_name.TabIndex = 15;
            // 
            // tabControl3
            // 
            this.tabControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Location = new System.Drawing.Point(-1, 49);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(186, 607);
            this.tabControl3.TabIndex = 16;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.dataGridView1);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(178, 581);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "历史";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(178, 581);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "保存";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 663);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "网址:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(42, 663);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(125, 12);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.apizl.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(185, 663);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "赞助支持";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "键";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "值";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "说明";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "删除";
            this.Column12.Name = "Column12";
            this.Column12.Text = "删除";
            this.Column12.ToolTipText = "删除";
            this.Column12.UseColumnTextForButtonValue = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 684);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.textBox_api_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_runtime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_bm);
            this.Controls.Add(this.button_setting);
            this.Controls.Add(this.comboBox_template);
            this.Controls.Add(this.button_test_creation_doc);
            this.Controls.Add(this.button_creation_doc);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comboBox_url_type);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_test);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PostApiTools(测试接口、生成文档) 作者:apiziliao@gmail.com  qq群:616318658";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_http_data)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Response)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.ComboBox comboBox_url_type;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button_creation_doc;
        private System.Windows.Forms.Button button_test_creation_doc;
        private System.Windows.Forms.ComboBox comboBox_template;
        private System.Windows.Forms.Button button_setting;
        private System.Windows.Forms.DataGridView dataGridView_http_data;
        private System.Windows.Forms.ComboBox comboBox_bm;
        private System.Windows.Forms.TextBox textBox_html;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_code;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_runtime;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ComboBox comboBox_html_show_type;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView_Response;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_api_name;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox textBox_doc;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column12;
    }
}


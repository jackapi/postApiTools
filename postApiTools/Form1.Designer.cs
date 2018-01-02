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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_test = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.comboBox_url_type = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView_http_data = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.checkBox_to_rn = new System.Windows.Forms.CheckBox();
            this.button_to_rn = new System.Windows.Forms.Button();
            this.comboBox_html_show_type = new System.Windows.Forms.ComboBox();
            this.textBox_html = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView_header = new System.Windows.Forms.DataGridView();
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
            this.dataGridView_history = new System.Windows.Forms.DataGridView();
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
            this.button_delete_history = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_treeview_refresh = new System.Windows.Forms.Button();
            this.button_add_project = new System.Windows.Forms.Button();
            this.treeView_save_list = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_save_list = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.button_save_api = new System.Windows.Forms.Button();
            this.imageList_treeview = new System.Windows.Forms.ImageList(this.components);
            this.timer_server = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_http_data)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_header)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Response)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_history)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.contextMenuStrip_save_list.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(871, 3);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 25);
            this.button_test.TabIndex = 0;
            this.button_test.Text = "提交测试";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(253, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL";
            // 
            // textBox_url
            // 
            this.textBox_url.Location = new System.Drawing.Point(294, 5);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(571, 21);
            this.textBox_url.TabIndex = 2;
            this.textBox_url.WordWrap = false;
            this.textBox_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_url_KeyDown);
            // 
            // comboBox_url_type
            // 
            this.comboBox_url_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_url_type.FormattingEnabled = true;
            this.comboBox_url_type.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.comboBox_url_type.Location = new System.Drawing.Point(119, 5);
            this.comboBox_url_type.Name = "comboBox_url_type";
            this.comboBox_url_type.Size = new System.Drawing.Size(121, 20);
            this.comboBox_url_type.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(263, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(993, 592);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_http_data);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(985, 566);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView_http_data
            // 
            this.dataGridView_http_data.AllowUserToResizeColumns = false;
            this.dataGridView_http_data.AllowUserToResizeRows = false;
            this.dataGridView_http_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_http_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_http_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column13,
            this.Column12});
            this.dataGridView_http_data.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_http_data.Name = "dataGridView_http_data";
            this.dataGridView_http_data.RowHeadersVisible = false;
            this.dataGridView_http_data.RowTemplate.Height = 23;
            this.dataGridView_http_data.Size = new System.Drawing.Size(985, 151);
            this.dataGridView_http_data.TabIndex = 8;
            this.dataGridView_http_data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_http_data_CellClick);
            this.dataGridView_http_data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_http_data_CellContentClick);
            this.dataGridView_http_data.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_http_data_CellValueChanged);
            this.dataGridView_http_data.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_http_data_DataError);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "键";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "值(字符串)";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "说明";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "类型";
            this.Column13.Items.AddRange(new object[] {
            "字符串",
            "文件"});
            this.Column13.Name = "Column13";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "删除";
            this.Column12.Name = "Column12";
            this.Column12.Text = "删除";
            this.Column12.ToolTipText = "删除";
            this.Column12.UseColumnTextForButtonValue = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(6, 157);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(976, 402);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.checkBox_to_rn);
            this.tabPage4.Controls.Add(this.button_to_rn);
            this.tabPage4.Controls.Add(this.comboBox_html_show_type);
            this.tabPage4.Controls.Add(this.textBox_html);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(968, 376);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "源码";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // checkBox_to_rn
            // 
            this.checkBox_to_rn.AutoSize = true;
            this.checkBox_to_rn.Location = new System.Drawing.Point(139, 7);
            this.checkBox_to_rn.Name = "checkBox_to_rn";
            this.checkBox_to_rn.Size = new System.Drawing.Size(72, 16);
            this.checkBox_to_rn.TabIndex = 3;
            this.checkBox_to_rn.Text = "自动换行";
            this.checkBox_to_rn.UseVisualStyleBackColor = true;
            this.checkBox_to_rn.CheckStateChanged += new System.EventHandler(this.checkBox_to_rn_CheckStateChanged);
            // 
            // button_to_rn
            // 
            this.button_to_rn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_to_rn.Location = new System.Drawing.Point(885, 4);
            this.button_to_rn.Name = "button_to_rn";
            this.button_to_rn.Size = new System.Drawing.Size(77, 24);
            this.button_to_rn.TabIndex = 2;
            this.button_to_rn.Text = "转换行";
            this.button_to_rn.UseVisualStyleBackColor = true;
            this.button_to_rn.Click += new System.EventHandler(this.button_to_rn_Click);
            // 
            // comboBox_html_show_type
            // 
            this.comboBox_html_show_type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_html_show_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_html_show_type.FormattingEnabled = true;
            this.comboBox_html_show_type.Items.AddRange(new object[] {
            "TEXT",
            "JSON",
            "HTML",
            "XML",
            "AUTO"});
            this.comboBox_html_show_type.Location = new System.Drawing.Point(5, 4);
            this.comboBox_html_show_type.Name = "comboBox_html_show_type";
            this.comboBox_html_show_type.Size = new System.Drawing.Size(128, 20);
            this.comboBox_html_show_type.TabIndex = 1;
            this.comboBox_html_show_type.SelectedIndexChanged += new System.EventHandler(this.comboBox_html_show_type_SelectedIndexChanged);
            // 
            // textBox_html
            // 
            this.textBox_html.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_html.Location = new System.Drawing.Point(0, 30);
            this.textBox_html.Multiline = true;
            this.textBox_html.Name = "textBox_html";
            this.textBox_html.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_html.Size = new System.Drawing.Size(968, 350);
            this.textBox_html.TabIndex = 0;
            this.textBox_html.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_html_KeyPress);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.webBrowser1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(968, 376);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "浏览器";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(3, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(962, 373);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView_header);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(985, 566);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "提交报文";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView_header
            // 
            this.dataGridView_header.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_header.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_header.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView_header.Location = new System.Drawing.Point(3, 0);
            this.dataGridView_header.Name = "dataGridView_header";
            this.dataGridView_header.RowHeadersVisible = false;
            this.dataGridView_header.RowTemplate.Height = 23;
            this.dataGridView_header.Size = new System.Drawing.Size(982, 560);
            this.dataGridView_header.TabIndex = 0;
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
            this.tabPage3.Size = new System.Drawing.Size(985, 566);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "返回报文";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Response
            // 
            this.dataGridView_Response.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Response.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Response.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridView_Response.Location = new System.Drawing.Point(3, 0);
            this.dataGridView_Response.Name = "dataGridView_Response";
            this.dataGridView_Response.RowHeadersVisible = false;
            this.dataGridView_Response.RowTemplate.Height = 23;
            this.dataGridView_Response.Size = new System.Drawing.Size(982, 562);
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
            this.tabPage6.Size = new System.Drawing.Size(985, 566);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "生成文档";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // textBox_doc
            // 
            this.textBox_doc.AcceptsReturn = true;
            this.textBox_doc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_doc.Location = new System.Drawing.Point(-4, 0);
            this.textBox_doc.Multiline = true;
            this.textBox_doc.Name = "textBox_doc";
            this.textBox_doc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_doc.Size = new System.Drawing.Size(993, 562);
            this.textBox_doc.TabIndex = 0;
            this.textBox_doc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_doc_KeyPress);
            // 
            // dataGridView_history
            // 
            this.dataGridView_history.AllowUserToResizeColumns = false;
            this.dataGridView_history.AllowUserToResizeRows = false;
            this.dataGridView_history.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_history.ColumnHeadersHeight = 30;
            this.dataGridView_history.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11});
            this.dataGridView_history.Location = new System.Drawing.Point(3, 27);
            this.dataGridView_history.Name = "dataGridView_history";
            this.dataGridView_history.RowHeadersVisible = false;
            this.dataGridView_history.RowTemplate.Height = 23;
            this.dataGridView_history.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_history.Size = new System.Drawing.Size(247, 567);
            this.dataGridView_history.TabIndex = 0;
            this.dataGridView_history.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_history_CellClick);
            // 
            // Column10
            // 
            this.Column10.HeaderText = "类型";
            this.Column10.Name = "Column10";
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column10.Width = 55;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "URL";
            this.Column11.Name = "Column11";
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column11.Width = 200;
            // 
            // button_creation_doc
            // 
            this.button_creation_doc.Location = new System.Drawing.Point(605, 34);
            this.button_creation_doc.Name = "button_creation_doc";
            this.button_creation_doc.Size = new System.Drawing.Size(75, 23);
            this.button_creation_doc.TabIndex = 5;
            this.button_creation_doc.Text = "生成文档";
            this.button_creation_doc.UseVisualStyleBackColor = true;
            this.button_creation_doc.Click += new System.EventHandler(this.button_creation_doc_Click);
            // 
            // button_test_creation_doc
            // 
            this.button_test_creation_doc.Location = new System.Drawing.Point(685, 34);
            this.button_test_creation_doc.Name = "button_test_creation_doc";
            this.button_test_creation_doc.Size = new System.Drawing.Size(75, 23);
            this.button_test_creation_doc.TabIndex = 5;
            this.button_test_creation_doc.Text = "测试文档";
            this.button_test_creation_doc.UseVisualStyleBackColor = true;
            this.button_test_creation_doc.Click += new System.EventHandler(this.button_test_creation_doc_Click);
            // 
            // comboBox_template
            // 
            this.comboBox_template.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_template.FormattingEnabled = true;
            this.comboBox_template.Location = new System.Drawing.Point(519, 36);
            this.comboBox_template.Name = "comboBox_template";
            this.comboBox_template.Size = new System.Drawing.Size(79, 20);
            this.comboBox_template.TabIndex = 6;
            // 
            // button_setting
            // 
            this.button_setting.Location = new System.Drawing.Point(766, 34);
            this.button_setting.Name = "button_setting";
            this.button_setting.Size = new System.Drawing.Size(75, 23);
            this.button_setting.TabIndex = 7;
            this.button_setting.Text = "设置";
            this.button_setting.UseVisualStyleBackColor = true;
            this.button_setting.Click += new System.EventHandler(this.button_setting_Click);
            // 
            // comboBox_bm
            // 
            this.comboBox_bm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bm.FormattingEnabled = true;
            this.comboBox_bm.Items.AddRange(new object[] {
            "UTF-8",
            "GBK",
            "GB2312",
            "GB18030",
            "Unicode"});
            this.comboBox_bm.Location = new System.Drawing.Point(955, 5);
            this.comboBox_bm.Name = "comboBox_bm";
            this.comboBox_bm.Size = new System.Drawing.Size(92, 20);
            this.comboBox_bm.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(847, 38);
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
            this.label_code.Location = new System.Drawing.Point(888, 32);
            this.label_code.Name = "label_code";
            this.label_code.Size = new System.Drawing.Size(43, 21);
            this.label_code.TabIndex = 10;
            this.label_code.Text = "200";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(941, 38);
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
            this.label_runtime.Location = new System.Drawing.Point(980, 35);
            this.label_runtime.Name = "label_runtime";
            this.label_runtime.Size = new System.Drawing.Size(16, 16);
            this.label_runtime.TabIndex = 12;
            this.label_runtime.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "模板";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "接口名称";
            // 
            // textBox_api_name
            // 
            this.textBox_api_name.Location = new System.Drawing.Point(349, 35);
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
            this.tabControl3.Location = new System.Drawing.Point(-1, 39);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(258, 623);
            this.tabControl3.TabIndex = 16;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.button_delete_history);
            this.tabPage7.Controls.Add(this.dataGridView_history);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(250, 597);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "历史";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // button_delete_history
            // 
            this.button_delete_history.Location = new System.Drawing.Point(171, 3);
            this.button_delete_history.Name = "button_delete_history";
            this.button_delete_history.Size = new System.Drawing.Size(75, 23);
            this.button_delete_history.TabIndex = 21;
            this.button_delete_history.Text = "清理";
            this.button_delete_history.UseVisualStyleBackColor = true;
            this.button_delete_history.Click += new System.EventHandler(this.button_delete_history_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.button_search);
            this.tabPage8.Controls.Add(this.textBox_search);
            this.tabPage8.Controls.Add(this.button_treeview_refresh);
            this.tabPage8.Controls.Add(this.button_add_project);
            this.tabPage8.Controls.Add(this.treeView_save_list);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(250, 597);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "保存";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(174, 30);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(70, 23);
            this.button_search.TabIndex = 21;
            this.button_search.Text = "搜索";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(9, 32);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(155, 21);
            this.textBox_search.TabIndex = 21;
            // 
            // button_treeview_refresh
            // 
            this.button_treeview_refresh.Location = new System.Drawing.Point(83, 2);
            this.button_treeview_refresh.Name = "button_treeview_refresh";
            this.button_treeview_refresh.Size = new System.Drawing.Size(45, 23);
            this.button_treeview_refresh.TabIndex = 10;
            this.button_treeview_refresh.Text = "刷新";
            this.button_treeview_refresh.UseVisualStyleBackColor = true;
            this.button_treeview_refresh.Click += new System.EventHandler(this.button_treeview_refresh_Click);
            // 
            // button_add_project
            // 
            this.button_add_project.Location = new System.Drawing.Point(9, 2);
            this.button_add_project.Name = "button_add_project";
            this.button_add_project.Size = new System.Drawing.Size(68, 24);
            this.button_add_project.TabIndex = 9;
            this.button_add_project.Text = "添加项目";
            this.button_add_project.UseVisualStyleBackColor = true;
            this.button_add_project.Click += new System.EventHandler(this.button_add_project_Click);
            // 
            // treeView_save_list
            // 
            this.treeView_save_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView_save_list.ContextMenuStrip = this.contextMenuStrip_save_list;
            this.treeView_save_list.Location = new System.Drawing.Point(0, 59);
            this.treeView_save_list.Name = "treeView_save_list";
            this.treeView_save_list.Size = new System.Drawing.Size(254, 536);
            this.treeView_save_list.TabIndex = 2;
            this.treeView_save_list.DoubleClick += new System.EventHandler(this.treeView_save_list_DoubleClick);
            // 
            // contextMenuStrip_save_list
            // 
            this.contextMenuStrip_save_list.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2});
            this.contextMenuStrip_save_list.Name = "contextMenuStrip_save_list";
            this.contextMenuStrip_save_list.Size = new System.Drawing.Size(113, 70);
            this.contextMenuStrip_save_list.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_save_list_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItem1.Text = "添加";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItem3.Text = "重命名";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItem2.Text = "删除";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 665);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "网址:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(42, 665);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(125, 12);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.apizl.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(185, 665);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "赞助支持";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // button_save_api
            // 
            this.button_save_api.Location = new System.Drawing.Point(1055, 2);
            this.button_save_api.Name = "button_save_api";
            this.button_save_api.Size = new System.Drawing.Size(75, 23);
            this.button_save_api.TabIndex = 20;
            this.button_save_api.Text = "保存";
            this.button_save_api.UseVisualStyleBackColor = true;
            this.button_save_api.Click += new System.EventHandler(this.button_save_api_Click);
            // 
            // imageList_treeview
            // 
            this.imageList_treeview.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_treeview.ImageStream")));
            this.imageList_treeview.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_treeview.Images.SetKeyName(0, "folder");
            this.imageList_treeview.Images.SetKeyName(1, "article");
            // 
            // timer_server
            // 
            this.timer_server.Interval = 1000;
            this.timer_server.Tick += new System.EventHandler(this.timer_server_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 686);
            this.Controls.Add(this.button_save_api);
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
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_http_data)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_header)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Response)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_history)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.contextMenuStrip_save_list.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dataGridView_history;
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
        private System.Windows.Forms.DataGridView dataGridView_header;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_save_api;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column13;
        private System.Windows.Forms.DataGridViewButtonColumn Column12;
        private System.Windows.Forms.TreeView treeView_save_list;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_save_list;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button button_add_project;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.ImageList imageList_treeview;
        private System.Windows.Forms.Button button_treeview_refresh;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_delete_history;
        private System.Windows.Forms.Button button_to_rn;
        private System.Windows.Forms.CheckBox checkBox_to_rn;
        private System.Windows.Forms.Timer timer_server;
    }
}


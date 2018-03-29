namespace postApiTools.FormAll
{
    partial class GetHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetHistory));
            this.label_url = new System.Windows.Forms.Label();
            this.fastColoredTextBox_result = new FastColoredTextBoxNS.FastColoredTextBox();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.label_one = new System.Windows.Forms.Label();
            this.label_urltype = new System.Windows.Forms.Label();
            this.dataGridView_urldata = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fastColoredTextBox_postjson = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_urldata)).BeginInit();
            this.tabControl_main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_postjson)).BeginInit();
            this.SuspendLayout();
            // 
            // label_url
            // 
            this.label_url.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_url.AutoSize = true;
            this.label_url.Location = new System.Drawing.Point(42, 48);
            this.label_url.Name = "label_url";
            this.label_url.Size = new System.Drawing.Size(29, 12);
            this.label_url.TabIndex = 0;
            this.label_url.Text = "URL:";
            // 
            // fastColoredTextBox_result
            // 
            this.fastColoredTextBox_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastColoredTextBox_result.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox_result.AutoScrollMinSize = new System.Drawing.Size(0, 14);
            this.fastColoredTextBox_result.BackBrush = null;
            this.fastColoredTextBox_result.CharHeight = 14;
            this.fastColoredTextBox_result.CharWidth = 8;
            this.fastColoredTextBox_result.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox_result.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox_result.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fastColoredTextBox_result.ImeMode = System.Windows.Forms.ImeMode.On;
            this.fastColoredTextBox_result.IsReplaceMode = false;
            this.fastColoredTextBox_result.Location = new System.Drawing.Point(7, 277);
            this.fastColoredTextBox_result.Name = "fastColoredTextBox_result";
            this.fastColoredTextBox_result.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox_result.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox_result.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox_result.ServiceColors")));
            this.fastColoredTextBox_result.Size = new System.Drawing.Size(373, 152);
            this.fastColoredTextBox_result.TabIndex = 2;
            this.fastColoredTextBox_result.WordWrap = true;
            this.fastColoredTextBox_result.Zoom = 100;
            // 
            // textBox_url
            // 
            this.textBox_url.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_url.Location = new System.Drawing.Point(77, 45);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(281, 21);
            this.textBox_url.TabIndex = 3;
            // 
            // label_one
            // 
            this.label_one.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_one.AutoSize = true;
            this.label_one.Location = new System.Drawing.Point(13, 83);
            this.label_one.Name = "label_one";
            this.label_one.Size = new System.Drawing.Size(59, 12);
            this.label_one.TabIndex = 4;
            this.label_one.Text = "请求方式:";
            // 
            // label_urltype
            // 
            this.label_urltype.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_urltype.AutoSize = true;
            this.label_urltype.Location = new System.Drawing.Point(81, 83);
            this.label_urltype.Name = "label_urltype";
            this.label_urltype.Size = new System.Drawing.Size(23, 12);
            this.label_urltype.TabIndex = 5;
            this.label_urltype.Text = "GET";
            // 
            // dataGridView_urldata
            // 
            this.dataGridView_urldata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_urldata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_urldata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView_urldata.Location = new System.Drawing.Point(-2, 0);
            this.dataGridView_urldata.Name = "dataGridView_urldata";
            this.dataGridView_urldata.RowTemplate.Height = 23;
            this.dataGridView_urldata.Size = new System.Drawing.Size(371, 150);
            this.dataGridView_urldata.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "参数";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "值";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "类型";
            this.Column3.Name = "Column3";
            // 
            // tabControl_main
            // 
            this.tabControl_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_main.Controls.Add(this.tabPage1);
            this.tabControl_main.Controls.Add(this.tabPage2);
            this.tabControl_main.Location = new System.Drawing.Point(7, 98);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(373, 173);
            this.tabControl_main.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_urldata);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(365, 147);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "表单数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fastColoredTextBox_postjson);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(365, 147);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PostJson";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fastColoredTextBox_postjson
            // 
            this.fastColoredTextBox_postjson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastColoredTextBox_postjson.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox_postjson.AutoScrollMinSize = new System.Drawing.Size(0, 14);
            this.fastColoredTextBox_postjson.BackBrush = null;
            this.fastColoredTextBox_postjson.CharHeight = 14;
            this.fastColoredTextBox_postjson.CharWidth = 8;
            this.fastColoredTextBox_postjson.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox_postjson.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox_postjson.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fastColoredTextBox_postjson.ImeMode = System.Windows.Forms.ImeMode.On;
            this.fastColoredTextBox_postjson.IsReplaceMode = false;
            this.fastColoredTextBox_postjson.Location = new System.Drawing.Point(4, 0);
            this.fastColoredTextBox_postjson.Name = "fastColoredTextBox_postjson";
            this.fastColoredTextBox_postjson.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox_postjson.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox_postjson.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox_postjson.ServiceColors")));
            this.fastColoredTextBox_postjson.Size = new System.Drawing.Size(361, 144);
            this.fastColoredTextBox_postjson.TabIndex = 0;
            this.fastColoredTextBox_postjson.WordWrap = true;
            this.fastColoredTextBox_postjson.Zoom = 100;
            // 
            // GetHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 447);
            this.Controls.Add(this.tabControl_main);
            this.Controls.Add(this.label_urltype);
            this.Controls.Add(this.label_one);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(this.fastColoredTextBox_result);
            this.Controls.Add(this.label_url);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.Load += new System.EventHandler(this.GetHistory_Load);
            this.Resize += new System.EventHandler(this.GetHistory_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_urldata)).EndInit();
            this.tabControl_main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_postjson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_url;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox_result;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.Label label_one;
        private System.Windows.Forms.Label label_urltype;
        private System.Windows.Forms.DataGridView dataGridView_urldata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox_postjson;
    }
}
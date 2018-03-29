namespace postApiTools.FormAll
{
    partial class getDocumentContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(getDocumentContent));
            this.label_url = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.label_urltype = new System.Windows.Forms.Label();
            this.dataGridView_data = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser_content = new System.Windows.Forms.WebBrowser();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_url
            // 
            this.label_url.AutoSize = true;
            this.label_url.Location = new System.Drawing.Point(38, 44);
            this.label_url.Name = "label_url";
            this.label_url.Size = new System.Drawing.Size(29, 12);
            this.label_url.TabIndex = 0;
            this.label_url.Text = "地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "请求方式";
            // 
            // textBox_url
            // 
            this.textBox_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_url.Location = new System.Drawing.Point(73, 41);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(598, 21);
            this.textBox_url.TabIndex = 2;
            // 
            // label_urltype
            // 
            this.label_urltype.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_urltype.AutoSize = true;
            this.label_urltype.Location = new System.Drawing.Point(71, 72);
            this.label_urltype.Name = "label_urltype";
            this.label_urltype.Size = new System.Drawing.Size(23, 12);
            this.label_urltype.TabIndex = 3;
            this.label_urltype.Text = "GET";
            // 
            // dataGridView_data
            // 
            this.dataGridView_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView_data.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_data.Name = "dataGridView_data";
            this.dataGridView_data.RowTemplate.Height = 23;
            this.dataGridView_data.Size = new System.Drawing.Size(653, 422);
            this.dataGridView_data.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 102);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 444);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_data);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(653, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "请求参数";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser_content);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(653, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "文档内容";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webBrowser_content
            // 
            this.webBrowser_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser_content.Location = new System.Drawing.Point(0, 0);
            this.webBrowser_content.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_content.Name = "webBrowser_content";
            this.webBrowser_content.ScrollBarsEnabled = false;
            this.webBrowser_content.Size = new System.Drawing.Size(653, 412);
            this.webBrowser_content.TabIndex = 0;
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
            this.Column3.HeaderText = "说明";
            this.Column3.Name = "Column3";
            // 
            // getDocumentContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 553);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label_urltype);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_url);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "getDocumentContent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看文档:";
            this.Load += new System.EventHandler(this.getDocumentContent_Load);
            this.Resize += new System.EventHandler(this.getDocumentContent_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_url;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.Label label_urltype;
        private System.Windows.Forms.DataGridView dataGridView_data;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser webBrowser_content;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
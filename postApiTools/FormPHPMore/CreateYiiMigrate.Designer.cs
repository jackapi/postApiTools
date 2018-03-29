namespace postApiTools.FormPHPMore
{
    partial class CreateYiiMigrate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateYiiMigrate));
            this.dataGridView_table_info = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinButton_create = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_model_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_yii_path = new System.Windows.Forms.TextBox();
            this.button_open = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_php_path = new System.Windows.Forms.TextBox();
            this.button_php_path = new System.Windows.Forms.Button();
            this.fastColoredTextBox_result = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_table_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_result)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_table_info
            // 
            this.dataGridView_table_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_table_info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView_table_info.Location = new System.Drawing.Point(7, 84);
            this.dataGridView_table_info.Name = "dataGridView_table_info";
            this.dataGridView_table_info.RowTemplate.Height = 23;
            this.dataGridView_table_info.Size = new System.Drawing.Size(450, 457);
            this.dataGridView_table_info.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "字段";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "类型";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "说明";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "其他";
            this.Column4.Name = "Column4";
            // 
            // skinButton_create
            // 
            this.skinButton_create.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_create.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_create.DownBack = null;
            this.skinButton_create.Location = new System.Drawing.Point(805, 42);
            this.skinButton_create.MouseBack = null;
            this.skinButton_create.Name = "skinButton_create";
            this.skinButton_create.NormlBack = null;
            this.skinButton_create.Size = new System.Drawing.Size(75, 23);
            this.skinButton_create.TabIndex = 2;
            this.skinButton_create.Text = "生成";
            this.skinButton_create.UseVisualStyleBackColor = false;
            this.skinButton_create.Click += new System.EventHandler(this.skinButton_create_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(580, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "模型名称:";
            // 
            // textBox_model_name
            // 
            this.textBox_model_name.Location = new System.Drawing.Point(645, 44);
            this.textBox_model_name.Name = "textBox_model_name";
            this.textBox_model_name.Size = new System.Drawing.Size(154, 21);
            this.textBox_model_name.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "项目Yii路径:";
            // 
            // textBox_yii_path
            // 
            this.textBox_yii_path.Location = new System.Drawing.Point(378, 41);
            this.textBox_yii_path.Name = "textBox_yii_path";
            this.textBox_yii_path.Size = new System.Drawing.Size(154, 21);
            this.textBox_yii_path.TabIndex = 6;
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(538, 41);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(28, 23);
            this.button_open.TabIndex = 7;
            this.button_open.Text = "+";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "PHP路径:";
            // 
            // textBox_php_path
            // 
            this.textBox_php_path.Location = new System.Drawing.Point(89, 39);
            this.textBox_php_path.Name = "textBox_php_path";
            this.textBox_php_path.Size = new System.Drawing.Size(154, 21);
            this.textBox_php_path.TabIndex = 6;
            // 
            // button_php_path
            // 
            this.button_php_path.Location = new System.Drawing.Point(249, 39);
            this.button_php_path.Name = "button_php_path";
            this.button_php_path.Size = new System.Drawing.Size(28, 23);
            this.button_php_path.TabIndex = 7;
            this.button_php_path.Text = "+";
            this.button_php_path.UseVisualStyleBackColor = true;
            this.button_php_path.Click += new System.EventHandler(this.button_php_path_Click);
            // 
            // fastColoredTextBox_result
            // 
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
            this.fastColoredTextBox_result.AutoScrollMinSize = new System.Drawing.Size(0, 18);
            this.fastColoredTextBox_result.BackBrush = null;
            this.fastColoredTextBox_result.CharHeight = 18;
            this.fastColoredTextBox_result.CharWidth = 9;
            this.fastColoredTextBox_result.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox_result.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox_result.Font = new System.Drawing.Font("Consolas", 12F);
            this.fastColoredTextBox_result.ImeMode = System.Windows.Forms.ImeMode.On;
            this.fastColoredTextBox_result.IsReplaceMode = false;
            this.fastColoredTextBox_result.Location = new System.Drawing.Point(463, 84);
            this.fastColoredTextBox_result.Name = "fastColoredTextBox_result";
            this.fastColoredTextBox_result.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox_result.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox_result.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox_result.ServiceColors")));
            this.fastColoredTextBox_result.Size = new System.Drawing.Size(444, 457);
            this.fastColoredTextBox_result.TabIndex = 0;
            this.fastColoredTextBox_result.WordWrap = true;
            this.fastColoredTextBox_result.Zoom = 100;
            // 
            // CreateYiiMigrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 552);
            this.Controls.Add(this.fastColoredTextBox_result);
            this.Controls.Add(this.button_php_path);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.textBox_php_path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_yii_path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_model_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.skinButton_create);
            this.Controls.Add(this.dataGridView_table_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateYiiMigrate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yii迁移生成";
            this.Load += new System.EventHandler(this.CreateYiiMigrate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_table_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_table_info;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private CCWin.SkinControl.SkinButton skinButton_create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_model_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_yii_path;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_php_path;
        private System.Windows.Forms.Button button_php_path;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox_result;
    }
}
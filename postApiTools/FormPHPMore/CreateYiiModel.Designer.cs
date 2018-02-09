namespace postApiTools.FormPHPMore
{
    partial class CreateYiiModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateYiiModel));
            this.dataGridView_table_info = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinButton_create = new CCWin.SkinControl.SkinButton();
            this.textBox_model_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.Column3});
            this.dataGridView_table_info.Location = new System.Drawing.Point(7, 62);
            this.dataGridView_table_info.Name = "dataGridView_table_info";
            this.dataGridView_table_info.RowTemplate.Height = 23;
            this.dataGridView_table_info.Size = new System.Drawing.Size(338, 464);
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
            this.Column3.HeaderText = "场景";
            this.Column3.Name = "Column3";
            // 
            // skinButton_create
            // 
            this.skinButton_create.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_create.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_create.DownBack = null;
            this.skinButton_create.Location = new System.Drawing.Point(148, 29);
            this.skinButton_create.MouseBack = null;
            this.skinButton_create.Name = "skinButton_create";
            this.skinButton_create.NormlBack = null;
            this.skinButton_create.Size = new System.Drawing.Size(75, 23);
            this.skinButton_create.TabIndex = 2;
            this.skinButton_create.Text = "生成";
            this.skinButton_create.UseVisualStyleBackColor = false;
            this.skinButton_create.Click += new System.EventHandler(this.skinButton_create_Click);
            // 
            // textBox_model_name
            // 
            this.textBox_model_name.Location = new System.Drawing.Point(42, 31);
            this.textBox_model_name.Name = "textBox_model_name";
            this.textBox_model_name.Size = new System.Drawing.Size(100, 21);
            this.textBox_model_name.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "名称";
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
            this.fastColoredTextBox_result.AutoScrollMinSize = new System.Drawing.Size(29, 18);
            this.fastColoredTextBox_result.BackBrush = null;
            this.fastColoredTextBox_result.CharHeight = 18;
            this.fastColoredTextBox_result.CharWidth = 9;
            this.fastColoredTextBox_result.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox_result.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox_result.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastColoredTextBox_result.ImeMode = System.Windows.Forms.ImeMode.On;
            this.fastColoredTextBox_result.IsReplaceMode = false;
            this.fastColoredTextBox_result.Location = new System.Drawing.Point(351, 62);
            this.fastColoredTextBox_result.Name = "fastColoredTextBox_result";
            this.fastColoredTextBox_result.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox_result.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox_result.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox_result.ServiceColors")));
            this.fastColoredTextBox_result.Size = new System.Drawing.Size(576, 464);
            this.fastColoredTextBox_result.TabIndex = 5;
            this.fastColoredTextBox_result.Zoom = 100;
            // 
            // CreateYiiModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 541);
            this.Controls.Add(this.fastColoredTextBox_result);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_model_name);
            this.Controls.Add(this.skinButton_create);
            this.Controls.Add(this.dataGridView_table_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateYiiModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成YII模型";
            this.Load += new System.EventHandler(this.CreateYiiModel_Load);
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
        private CCWin.SkinControl.SkinButton skinButton_create;
        private System.Windows.Forms.TextBox textBox_model_name;
        private System.Windows.Forms.Label label1;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox_result;
    }
}
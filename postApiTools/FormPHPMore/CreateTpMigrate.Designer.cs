namespace postApiTools.FormPHPMore
{
    partial class CreateTpMigrate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTpMigrate));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_php = new System.Windows.Forms.TextBox();
            this.textBox_tp = new System.Windows.Forms.TextBox();
            this.button_php = new System.Windows.Forms.Button();
            this.button_tp = new System.Windows.Forms.Button();
            this.button_create = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.fastColoredTextBox_result = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_result)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(7, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(464, 459);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "PHP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "TP";
            // 
            // textBox_php
            // 
            this.textBox_php.Location = new System.Drawing.Point(50, 38);
            this.textBox_php.Name = "textBox_php";
            this.textBox_php.Size = new System.Drawing.Size(161, 21);
            this.textBox_php.TabIndex = 4;
            // 
            // textBox_tp
            // 
            this.textBox_tp.Location = new System.Drawing.Point(270, 38);
            this.textBox_tp.Name = "textBox_tp";
            this.textBox_tp.Size = new System.Drawing.Size(181, 21);
            this.textBox_tp.TabIndex = 4;
            // 
            // button_php
            // 
            this.button_php.Location = new System.Drawing.Point(217, 36);
            this.button_php.Name = "button_php";
            this.button_php.Size = new System.Drawing.Size(24, 23);
            this.button_php.TabIndex = 5;
            this.button_php.Text = "+";
            this.button_php.UseVisualStyleBackColor = true;
            this.button_php.Click += new System.EventHandler(this.button_php_Click);
            // 
            // button_tp
            // 
            this.button_tp.Location = new System.Drawing.Point(457, 36);
            this.button_tp.Name = "button_tp";
            this.button_tp.Size = new System.Drawing.Size(24, 23);
            this.button_tp.TabIndex = 5;
            this.button_tp.Text = "+";
            this.button_tp.UseVisualStyleBackColor = true;
            this.button_tp.Click += new System.EventHandler(this.button_tp_Click);
            // 
            // button_create
            // 
            this.button_create.Location = new System.Drawing.Point(498, 36);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(75, 23);
            this.button_create.TabIndex = 5;
            this.button_create.Text = "生成";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
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
            this.fastColoredTextBox_result.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fastColoredTextBox_result.BackBrush = null;
            this.fastColoredTextBox_result.CharHeight = 14;
            this.fastColoredTextBox_result.CharWidth = 8;
            this.fastColoredTextBox_result.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox_result.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox_result.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fastColoredTextBox_result.IsReplaceMode = false;
            this.fastColoredTextBox_result.Location = new System.Drawing.Point(477, 76);
            this.fastColoredTextBox_result.Name = "fastColoredTextBox_result";
            this.fastColoredTextBox_result.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox_result.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox_result.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox_result.ServiceColors")));
            this.fastColoredTextBox_result.Size = new System.Drawing.Size(453, 459);
            this.fastColoredTextBox_result.TabIndex = 6;
            this.fastColoredTextBox_result.Zoom = 100;
            // 
            // CreateTpMigrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 542);
            this.Controls.Add(this.fastColoredTextBox_result);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.button_tp);
            this.Controls.Add(this.button_php);
            this.Controls.Add(this.textBox_tp);
            this.Controls.Add(this.textBox_php);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateTpMigrate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TP迁移生成";
            this.Load += new System.EventHandler(this.CreateTpMigrate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_php;
        private System.Windows.Forms.TextBox textBox_tp;
        private System.Windows.Forms.Button button_php;
        private System.Windows.Forms.Button button_tp;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox_result;
    }
}
namespace postApiTools
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_delete_template = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_template = new System.Windows.Forms.TextBox();
            this.comboBox_template_list = new System.Windows.Forms.ComboBox();
            this.textBox_save_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(882, 572);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_delete_template);
            this.tabPage1.Controls.Add(this.button_save);
            this.tabPage1.Controls.Add(this.textBox_template);
            this.tabPage1.Controls.Add(this.comboBox_template_list);
            this.tabPage1.Controls.Add(this.textBox_save_name);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(874, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "生成文档";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_delete_template
            // 
            this.button_delete_template.Location = new System.Drawing.Point(560, 8);
            this.button_delete_template.Name = "button_delete_template";
            this.button_delete_template.Size = new System.Drawing.Size(75, 23);
            this.button_delete_template.TabIndex = 6;
            this.button_delete_template.Text = "删除模板";
            this.button_delete_template.UseVisualStyleBackColor = true;
            this.button_delete_template.Click += new System.EventHandler(this.button_delete_template_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(479, 8);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 5;
            this.button_save.Text = "保存模板";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_template
            // 
            this.textBox_template.Location = new System.Drawing.Point(8, 71);
            this.textBox_template.Multiline = true;
            this.textBox_template.Name = "textBox_template";
            this.textBox_template.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_template.Size = new System.Drawing.Size(860, 469);
            this.textBox_template.TabIndex = 4;
            // 
            // comboBox_template_list
            // 
            this.comboBox_template_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_template_list.FormattingEnabled = true;
            this.comboBox_template_list.Items.AddRange(new object[] {
            "默认模板"});
            this.comboBox_template_list.Location = new System.Drawing.Point(232, 11);
            this.comboBox_template_list.Name = "comboBox_template_list";
            this.comboBox_template_list.Size = new System.Drawing.Size(241, 20);
            this.comboBox_template_list.TabIndex = 3;
            this.comboBox_template_list.SelectedIndexChanged += new System.EventHandler(this.comboBox_template_list_SelectedIndexChanged);
            // 
            // textBox_save_name
            // 
            this.textBox_save_name.Location = new System.Drawing.Point(59, 10);
            this.textBox_save_name.Name = "textBox_save_name";
            this.textBox_save_name.Size = new System.Drawing.Size(163, 21);
            this.textBox_save_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "模板名:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(874, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "其他";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 609);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件设置";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox_template;
        private System.Windows.Forms.ComboBox comboBox_template_list;
        private System.Windows.Forms.TextBox textBox_save_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_delete_template;
    }
}
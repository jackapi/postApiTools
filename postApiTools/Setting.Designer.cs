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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBox_force_server = new System.Windows.Forms.CheckBox();
            this.textBox_websocket_port = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_websocket_ip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_agreed = new System.Windows.Forms.CheckBox();
            this.checkBox_open_server_update = new System.Windows.Forms.CheckBox();
            this.button_web_save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_web_password = new System.Windows.Forms.TextBox();
            this.textBox_web_username = new System.Windows.Forms.TextBox();
            this.textBox_web_url = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_history = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(892, 590);
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
            this.tabPage1.Size = new System.Drawing.Size(884, 564);
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
            this.textBox_template.Size = new System.Drawing.Size(870, 487);
            this.textBox_template.TabIndex = 0;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBox_force_server);
            this.tabPage3.Controls.Add(this.textBox_websocket_port);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.textBox_websocket_ip);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.checkBox_agreed);
            this.tabPage3.Controls.Add(this.checkBox_open_server_update);
            this.tabPage3.Controls.Add(this.button_web_save);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.textBox_web_password);
            this.tabPage3.Controls.Add(this.textBox_web_username);
            this.tabPage3.Controls.Add(this.textBox_web_url);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(884, 564);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "配置服务器";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkBox_force_server
            // 
            this.checkBox_force_server.AutoSize = true;
            this.checkBox_force_server.Location = new System.Drawing.Point(49, 126);
            this.checkBox_force_server.Name = "checkBox_force_server";
            this.checkBox_force_server.Size = new System.Drawing.Size(72, 16);
            this.checkBox_force_server.TabIndex = 9;
            this.checkBox_force_server.Text = "强制更新";
            this.checkBox_force_server.UseVisualStyleBackColor = true;
            // 
            // textBox_websocket_port
            // 
            this.textBox_websocket_port.Location = new System.Drawing.Point(49, 192);
            this.textBox_websocket_port.Name = "textBox_websocket_port";
            this.textBox_websocket_port.Size = new System.Drawing.Size(235, 21);
            this.textBox_websocket_port.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "端口";
            // 
            // textBox_websocket_ip
            // 
            this.textBox_websocket_ip.Location = new System.Drawing.Point(49, 155);
            this.textBox_websocket_ip.Name = "textBox_websocket_ip";
            this.textBox_websocket_ip.Size = new System.Drawing.Size(235, 21);
            this.textBox_websocket_ip.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "服务器";
            // 
            // checkBox_agreed
            // 
            this.checkBox_agreed.AutoSize = true;
            this.checkBox_agreed.Location = new System.Drawing.Point(139, 102);
            this.checkBox_agreed.Name = "checkBox_agreed";
            this.checkBox_agreed.Size = new System.Drawing.Size(72, 16);
            this.checkBox_agreed.TabIndex = 6;
            this.checkBox_agreed.Text = "保持一致";
            this.checkBox_agreed.UseVisualStyleBackColor = true;
            // 
            // checkBox_open_server_update
            // 
            this.checkBox_open_server_update.AutoSize = true;
            this.checkBox_open_server_update.Location = new System.Drawing.Point(49, 102);
            this.checkBox_open_server_update.Name = "checkBox_open_server_update";
            this.checkBox_open_server_update.Size = new System.Drawing.Size(72, 16);
            this.checkBox_open_server_update.TabIndex = 5;
            this.checkBox_open_server_update.Text = "开启同步";
            this.checkBox_open_server_update.UseVisualStyleBackColor = true;
            // 
            // button_web_save
            // 
            this.button_web_save.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_web_save.Location = new System.Drawing.Point(290, 3);
            this.button_web_save.Name = "button_web_save";
            this.button_web_save.Size = new System.Drawing.Size(129, 210);
            this.button_web_save.TabIndex = 4;
            this.button_web_save.Text = "保存";
            this.button_web_save.UseVisualStyleBackColor = true;
            this.button_web_save.Click += new System.EventHandler(this.button_web_save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "账号";
            // 
            // textBox_web_password
            // 
            this.textBox_web_password.Location = new System.Drawing.Point(49, 75);
            this.textBox_web_password.Name = "textBox_web_password";
            this.textBox_web_password.Size = new System.Drawing.Size(235, 21);
            this.textBox_web_password.TabIndex = 1;
            this.textBox_web_password.UseSystemPasswordChar = true;
            // 
            // textBox_web_username
            // 
            this.textBox_web_username.Location = new System.Drawing.Point(49, 42);
            this.textBox_web_username.Name = "textBox_web_username";
            this.textBox_web_username.Size = new System.Drawing.Size(235, 21);
            this.textBox_web_username.TabIndex = 1;
            // 
            // textBox_web_url
            // 
            this.textBox_web_url.Location = new System.Drawing.Point(49, 10);
            this.textBox_web_url.Name = "textBox_web_url";
            this.textBox_web_url.Size = new System.Drawing.Size(235, 21);
            this.textBox_web_url.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "URL";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_history);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(884, 564);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "其他";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_history
            // 
            this.button_history.Location = new System.Drawing.Point(6, 6);
            this.button_history.Name = "button_history";
            this.button_history.Size = new System.Drawing.Size(75, 23);
            this.button_history.TabIndex = 0;
            this.button_history.Text = "清理历史";
            this.button_history.UseVisualStyleBackColor = true;
            this.button_history.Click += new System.EventHandler(this.button_history_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 628);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件设置";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Setting_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox_web_url;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_web_password;
        private System.Windows.Forms.TextBox textBox_web_username;
        private System.Windows.Forms.Button button_web_save;
        private System.Windows.Forms.Button button_history;
        private System.Windows.Forms.CheckBox checkBox_open_server_update;
        private System.Windows.Forms.CheckBox checkBox_agreed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_websocket_port;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_websocket_ip;
        private System.Windows.Forms.CheckBox checkBox_force_server;
    }
}
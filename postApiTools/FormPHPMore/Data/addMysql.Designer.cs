namespace postApiTools.FormPHPMore.Data
{
    partial class addMysql
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addMysql));
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.skinButton_add = new CCWin.SkinControl.SkinButton();
            this.skinButton_close = new CCWin.SkinControl.SkinButton();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(89, 53);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(161, 21);
            this.textBox_name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库名";
            // 
            // skinButton_add
            // 
            this.skinButton_add.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_add.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_add.DownBack = null;
            this.skinButton_add.Location = new System.Drawing.Point(47, 268);
            this.skinButton_add.MouseBack = null;
            this.skinButton_add.Name = "skinButton_add";
            this.skinButton_add.NormlBack = null;
            this.skinButton_add.Size = new System.Drawing.Size(75, 23);
            this.skinButton_add.TabIndex = 2;
            this.skinButton_add.Text = "添加";
            this.skinButton_add.UseVisualStyleBackColor = false;
            this.skinButton_add.Click += new System.EventHandler(this.skinButton_add_Click);
            // 
            // skinButton_close
            // 
            this.skinButton_close.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_close.DownBack = null;
            this.skinButton_close.Location = new System.Drawing.Point(212, 268);
            this.skinButton_close.MouseBack = null;
            this.skinButton_close.Name = "skinButton_close";
            this.skinButton_close.NormlBack = null;
            this.skinButton_close.Size = new System.Drawing.Size(75, 23);
            this.skinButton_close.TabIndex = 2;
            this.skinButton_close.Text = "关闭";
            this.skinButton_close.UseVisualStyleBackColor = false;
            this.skinButton_close.Click += new System.EventHandler(this.skinButton_close_Click);
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(89, 91);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(161, 21);
            this.textBox_ip.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP ";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(89, 127);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(161, 21);
            this.textBox_port.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "端口";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(89, 164);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(161, 21);
            this.textBox_username.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "用户名";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(89, 204);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(161, 21);
            this.textBox_password.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "密码";
            // 
            // addMysql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 321);
            this.Controls.Add(this.skinButton_close);
            this.Controls.Add(this.skinButton_add);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.textBox_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addMysql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加MySQL";
            this.Load += new System.EventHandler(this.addMysql_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinButton skinButton_add;
        private CCWin.SkinControl.SkinButton skinButton_close;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label5;
    }
}
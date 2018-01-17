namespace postApiTools.FormAll
{
    partial class pLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pLogin));
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinTextBox_password = new CCWin.SkinControl.SkinTextBox();
            this.skinButton_login = new CCWin.SkinControl.SkinButton();
            this.skinButton_close = new CCWin.SkinControl.SkinButton();
            this.skinComboBox_name = new CCWin.SkinControl.SkinComboBox();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(12, 55);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(44, 17);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "用户名";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(24, 101);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 0;
            this.skinLabel2.Text = "密码";
            // 
            // skinTextBox_password
            // 
            this.skinTextBox_password.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_password.DownBack = null;
            this.skinTextBox_password.Icon = null;
            this.skinTextBox_password.IconIsButton = false;
            this.skinTextBox_password.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_password.IsPasswordChat = '●';
            this.skinTextBox_password.IsSystemPasswordChar = true;
            this.skinTextBox_password.Lines = new string[0];
            this.skinTextBox_password.Location = new System.Drawing.Point(84, 94);
            this.skinTextBox_password.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_password.MaxLength = 32767;
            this.skinTextBox_password.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_password.MouseBack = null;
            this.skinTextBox_password.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_password.Multiline = false;
            this.skinTextBox_password.Name = "skinTextBox_password";
            this.skinTextBox_password.NormlBack = null;
            this.skinTextBox_password.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_password.ReadOnly = false;
            this.skinTextBox_password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox_password.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.skinTextBox_password.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_password.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_password.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_password.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_password.SkinTxt.Name = "BaseText";
            this.skinTextBox_password.SkinTxt.PasswordChar = '●';
            this.skinTextBox_password.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.skinTextBox_password.SkinTxt.TabIndex = 0;
            this.skinTextBox_password.SkinTxt.UseSystemPasswordChar = true;
            this.skinTextBox_password.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_password.SkinTxt.WaterText = "";
            this.skinTextBox_password.TabIndex = 1;
            this.skinTextBox_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox_password.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_password.WaterText = "";
            this.skinTextBox_password.WordWrap = true;
            // 
            // skinButton_login
            // 
            this.skinButton_login.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_login.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_login.DownBack = null;
            this.skinButton_login.Location = new System.Drawing.Point(38, 154);
            this.skinButton_login.MouseBack = null;
            this.skinButton_login.Name = "skinButton_login";
            this.skinButton_login.NormlBack = null;
            this.skinButton_login.Size = new System.Drawing.Size(72, 23);
            this.skinButton_login.TabIndex = 2;
            this.skinButton_login.Text = "登录";
            this.skinButton_login.UseVisualStyleBackColor = false;
            this.skinButton_login.Click += new System.EventHandler(this.skinButton_login_Click);
            // 
            // skinButton_close
            // 
            this.skinButton_close.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_close.DownBack = null;
            this.skinButton_close.Location = new System.Drawing.Point(179, 154);
            this.skinButton_close.MouseBack = null;
            this.skinButton_close.Name = "skinButton_close";
            this.skinButton_close.NormlBack = null;
            this.skinButton_close.Size = new System.Drawing.Size(72, 23);
            this.skinButton_close.TabIndex = 2;
            this.skinButton_close.Text = "关闭";
            this.skinButton_close.UseVisualStyleBackColor = false;
            this.skinButton_close.Click += new System.EventHandler(this.skinButton_close_Click);
            // 
            // skinComboBox_name
            // 
            this.skinComboBox_name.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_name.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinComboBox_name.FormattingEnabled = true;
            this.skinComboBox_name.ItemHeight = 20;
            this.skinComboBox_name.Location = new System.Drawing.Point(84, 55);
            this.skinComboBox_name.Name = "skinComboBox_name";
            this.skinComboBox_name.Size = new System.Drawing.Size(185, 26);
            this.skinComboBox_name.TabIndex = 0;
            this.skinComboBox_name.WaterText = "";
            // 
            // pLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(291, 199);
            this.Controls.Add(this.skinComboBox_name);
            this.Controls.Add(this.skinButton_close);
            this.Controls.Add(this.skinButton_login);
            this.Controls.Add(this.skinTextBox_password);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pLogin_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinTextBox skinTextBox_password;
        private CCWin.SkinControl.SkinButton skinButton_login;
        private CCWin.SkinControl.SkinButton skinButton_close;
        private CCWin.SkinControl.SkinComboBox skinComboBox_name;
    }
}
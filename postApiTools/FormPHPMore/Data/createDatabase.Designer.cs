namespace postApiTools.FormPHPMore.Data
{
    partial class createDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createDatabase));
            this.skinButton_create = new CCWin.SkinControl.SkinButton();
            this.skinButton_close = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_encoding = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // skinButton_create
            // 
            this.skinButton_create.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_create.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_create.DownBack = null;
            this.skinButton_create.Location = new System.Drawing.Point(41, 160);
            this.skinButton_create.MouseBack = null;
            this.skinButton_create.Name = "skinButton_create";
            this.skinButton_create.NormlBack = null;
            this.skinButton_create.Size = new System.Drawing.Size(75, 23);
            this.skinButton_create.TabIndex = 0;
            this.skinButton_create.Text = "创建";
            this.skinButton_create.UseVisualStyleBackColor = false;
            this.skinButton_create.Click += new System.EventHandler(this.skinButton_create_Click);
            // 
            // skinButton_close
            // 
            this.skinButton_close.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_close.DownBack = null;
            this.skinButton_close.Location = new System.Drawing.Point(181, 160);
            this.skinButton_close.MouseBack = null;
            this.skinButton_close.Name = "skinButton_close";
            this.skinButton_close.NormlBack = null;
            this.skinButton_close.Size = new System.Drawing.Size(75, 23);
            this.skinButton_close.TabIndex = 1;
            this.skinButton_close.Text = "关闭";
            this.skinButton_close.UseVisualStyleBackColor = false;
            this.skinButton_close.Click += new System.EventHandler(this.skinButton_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "数据库";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(76, 57);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(180, 21);
            this.textBox_name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "编码";
            // 
            // textBox_encoding
            // 
            this.textBox_encoding.Location = new System.Drawing.Point(76, 114);
            this.textBox_encoding.Name = "textBox_encoding";
            this.textBox_encoding.Size = new System.Drawing.Size(180, 21);
            this.textBox_encoding.TabIndex = 3;
            this.textBox_encoding.Text = "utf8";
            // 
            // createDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 246);
            this.Controls.Add(this.textBox_encoding);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.skinButton_close);
            this.Controls.Add(this.skinButton_create);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "createDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建数据库";
            this.Load += new System.EventHandler(this.createDatabase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton skinButton_create;
        private CCWin.SkinControl.SkinButton skinButton_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_encoding;
    }
}
namespace postApiTools
{
    partial class SavePostApi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavePostApi));
            this.treeView = new System.Windows.Forms.TreeView();
            this.button_save = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_desc = new System.Windows.Forms.TextBox();
            this.imageList_treeview = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 200);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(326, 202);
            this.treeView.TabIndex = 0;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(60, 423);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(186, 423);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 23);
            this.button_back.TabIndex = 1;
            this.button_back.Text = "返回";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "接口";
            // 
            // textBox_url
            // 
            this.textBox_url.Enabled = false;
            this.textBox_url.Location = new System.Drawing.Point(69, 12);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(269, 21);
            this.textBox_url.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "名称";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(69, 39);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(269, 21);
            this.textBox_name.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "描述";
            // 
            // textBox_desc
            // 
            this.textBox_desc.Location = new System.Drawing.Point(69, 66);
            this.textBox_desc.Multiline = true;
            this.textBox_desc.Name = "textBox_desc";
            this.textBox_desc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_desc.Size = new System.Drawing.Size(269, 128);
            this.textBox_desc.TabIndex = 3;
            // 
            // imageList_treeview
            // 
            this.imageList_treeview.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_treeview.ImageStream")));
            this.imageList_treeview.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_treeview.Images.SetKeyName(0, "folder");
            // 
            // SavePostApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 468);
            this.Controls.Add(this.textBox_desc);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.treeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SavePostApi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保存接口";
            this.Load += new System.EventHandler(this.SavePostApi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SavePostApi_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_desc;
        private System.Windows.Forms.ImageList imageList_treeview;
    }
}
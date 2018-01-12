namespace postApiTools.FormRole
{
    partial class setProjectRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setProjectRole));
            this.skinTreeView1 = new CCWin.SkinControl.SkinTreeView();
            this.skinButton_set = new CCWin.SkinControl.SkinButton();
            this.skinButton_back = new CCWin.SkinControl.SkinButton();
            this.skinCheckBox_read = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBox_write = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBox_all = new CCWin.SkinControl.SkinCheckBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinTextBox_hash = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinTextBox_role_name = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel_role_name = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // skinTreeView1
            // 
            this.skinTreeView1.Location = new System.Drawing.Point(16, 64);
            this.skinTreeView1.Name = "skinTreeView1";
            this.skinTreeView1.Size = new System.Drawing.Size(280, 95);
            this.skinTreeView1.TabIndex = 0;
            this.skinTreeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.skinTreeView1_NodeMouseDoubleClick);
            // 
            // skinButton_set
            // 
            this.skinButton_set.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_set.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_set.DownBack = null;
            this.skinButton_set.Location = new System.Drawing.Point(31, 272);
            this.skinButton_set.MouseBack = null;
            this.skinButton_set.Name = "skinButton_set";
            this.skinButton_set.NormlBack = null;
            this.skinButton_set.Size = new System.Drawing.Size(75, 23);
            this.skinButton_set.TabIndex = 1;
            this.skinButton_set.Text = "设置";
            this.skinButton_set.UseVisualStyleBackColor = false;
            this.skinButton_set.Click += new System.EventHandler(this.skinButton_set_Click);
            // 
            // skinButton_back
            // 
            this.skinButton_back.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_back.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_back.DownBack = null;
            this.skinButton_back.Location = new System.Drawing.Point(205, 272);
            this.skinButton_back.MouseBack = null;
            this.skinButton_back.Name = "skinButton_back";
            this.skinButton_back.NormlBack = null;
            this.skinButton_back.Size = new System.Drawing.Size(75, 23);
            this.skinButton_back.TabIndex = 1;
            this.skinButton_back.Text = "返回";
            this.skinButton_back.UseVisualStyleBackColor = false;
            this.skinButton_back.Click += new System.EventHandler(this.skinButton_back_Click);
            // 
            // skinCheckBox_read
            // 
            this.skinCheckBox_read.AutoSize = true;
            this.skinCheckBox_read.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox_read.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox_read.DownBack = null;
            this.skinCheckBox_read.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox_read.Location = new System.Drawing.Point(136, 240);
            this.skinCheckBox_read.MouseBack = null;
            this.skinCheckBox_read.Name = "skinCheckBox_read";
            this.skinCheckBox_read.NormlBack = null;
            this.skinCheckBox_read.SelectedDownBack = null;
            this.skinCheckBox_read.SelectedMouseBack = null;
            this.skinCheckBox_read.SelectedNormlBack = null;
            this.skinCheckBox_read.Size = new System.Drawing.Size(39, 21);
            this.skinCheckBox_read.TabIndex = 2;
            this.skinCheckBox_read.Text = "读";
            this.skinCheckBox_read.UseVisualStyleBackColor = false;
            // 
            // skinCheckBox_write
            // 
            this.skinCheckBox_write.AutoSize = true;
            this.skinCheckBox_write.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox_write.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox_write.DownBack = null;
            this.skinCheckBox_write.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox_write.Location = new System.Drawing.Point(190, 240);
            this.skinCheckBox_write.MouseBack = null;
            this.skinCheckBox_write.Name = "skinCheckBox_write";
            this.skinCheckBox_write.NormlBack = null;
            this.skinCheckBox_write.SelectedDownBack = null;
            this.skinCheckBox_write.SelectedMouseBack = null;
            this.skinCheckBox_write.SelectedNormlBack = null;
            this.skinCheckBox_write.Size = new System.Drawing.Size(39, 21);
            this.skinCheckBox_write.TabIndex = 2;
            this.skinCheckBox_write.Text = "写";
            this.skinCheckBox_write.UseVisualStyleBackColor = false;
            // 
            // skinCheckBox_all
            // 
            this.skinCheckBox_all.AutoSize = true;
            this.skinCheckBox_all.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox_all.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox_all.DownBack = null;
            this.skinCheckBox_all.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox_all.Location = new System.Drawing.Point(80, 240);
            this.skinCheckBox_all.MouseBack = null;
            this.skinCheckBox_all.Name = "skinCheckBox_all";
            this.skinCheckBox_all.NormlBack = null;
            this.skinCheckBox_all.SelectedDownBack = null;
            this.skinCheckBox_all.SelectedMouseBack = null;
            this.skinCheckBox_all.SelectedNormlBack = null;
            this.skinCheckBox_all.Size = new System.Drawing.Size(51, 21);
            this.skinCheckBox_all.TabIndex = 2;
            this.skinCheckBox_all.Text = "全部";
            this.skinCheckBox_all.UseVisualStyleBackColor = false;
            this.skinCheckBox_all.CheckedChanged += new System.EventHandler(this.skinCheckBox_all_CheckedChanged);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(20, 175);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(32, 17);
            this.skinLabel1.TabIndex = 3;
            this.skinLabel1.Text = "编号";
            // 
            // skinTextBox_hash
            // 
            this.skinTextBox_hash.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_hash.DownBack = null;
            this.skinTextBox_hash.Enabled = false;
            this.skinTextBox_hash.Icon = null;
            this.skinTextBox_hash.IconIsButton = false;
            this.skinTextBox_hash.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_hash.IsPasswordChat = '\0';
            this.skinTextBox_hash.IsSystemPasswordChar = false;
            this.skinTextBox_hash.Lines = new string[0];
            this.skinTextBox_hash.Location = new System.Drawing.Point(55, 166);
            this.skinTextBox_hash.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_hash.MaxLength = 32767;
            this.skinTextBox_hash.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_hash.MouseBack = null;
            this.skinTextBox_hash.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_hash.Multiline = false;
            this.skinTextBox_hash.Name = "skinTextBox_hash";
            this.skinTextBox_hash.NormlBack = null;
            this.skinTextBox_hash.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_hash.ReadOnly = false;
            this.skinTextBox_hash.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox_hash.Size = new System.Drawing.Size(231, 28);
            // 
            // 
            // 
            this.skinTextBox_hash.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_hash.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_hash.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_hash.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_hash.SkinTxt.Name = "BaseText";
            this.skinTextBox_hash.SkinTxt.Size = new System.Drawing.Size(221, 18);
            this.skinTextBox_hash.SkinTxt.TabIndex = 0;
            this.skinTextBox_hash.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_hash.SkinTxt.WaterText = "";
            this.skinTextBox_hash.TabIndex = 4;
            this.skinTextBox_hash.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox_hash.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_hash.WaterText = "";
            this.skinTextBox_hash.WordWrap = true;
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(20, 213);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 3;
            this.skinLabel2.Text = "角色";
            // 
            // skinTextBox_role_name
            // 
            this.skinTextBox_role_name.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_role_name.DownBack = null;
            this.skinTextBox_role_name.Enabled = false;
            this.skinTextBox_role_name.Icon = null;
            this.skinTextBox_role_name.IconIsButton = false;
            this.skinTextBox_role_name.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_role_name.IsPasswordChat = '\0';
            this.skinTextBox_role_name.IsSystemPasswordChar = false;
            this.skinTextBox_role_name.Lines = new string[0];
            this.skinTextBox_role_name.Location = new System.Drawing.Point(55, 204);
            this.skinTextBox_role_name.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_role_name.MaxLength = 32767;
            this.skinTextBox_role_name.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_role_name.MouseBack = null;
            this.skinTextBox_role_name.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_role_name.Multiline = false;
            this.skinTextBox_role_name.Name = "skinTextBox_role_name";
            this.skinTextBox_role_name.NormlBack = null;
            this.skinTextBox_role_name.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_role_name.ReadOnly = false;
            this.skinTextBox_role_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox_role_name.Size = new System.Drawing.Size(231, 28);
            // 
            // 
            // 
            this.skinTextBox_role_name.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_role_name.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_role_name.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_role_name.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_role_name.SkinTxt.Name = "BaseText";
            this.skinTextBox_role_name.SkinTxt.Size = new System.Drawing.Size(221, 18);
            this.skinTextBox_role_name.SkinTxt.TabIndex = 0;
            this.skinTextBox_role_name.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_role_name.SkinTxt.WaterText = "";
            this.skinTextBox_role_name.TabIndex = 4;
            this.skinTextBox_role_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox_role_name.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_role_name.WaterText = "";
            this.skinTextBox_role_name.WordWrap = true;
            // 
            // skinLabel_role_name
            // 
            this.skinLabel_role_name.AutoSize = true;
            this.skinLabel_role_name.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_role_name.BorderColor = System.Drawing.Color.White;
            this.skinLabel_role_name.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_role_name.Location = new System.Drawing.Point(101, 35);
            this.skinLabel_role_name.Name = "skinLabel_role_name";
            this.skinLabel_role_name.Size = new System.Drawing.Size(64, 17);
            this.skinLabel_role_name.TabIndex = 5;
            this.skinLabel_role_name.Text = "Loading...";
            // 
            // setProjectRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 320);
            this.Controls.Add(this.skinLabel_role_name);
            this.Controls.Add(this.skinTextBox_role_name);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinTextBox_hash);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.skinCheckBox_write);
            this.Controls.Add(this.skinCheckBox_all);
            this.Controls.Add(this.skinCheckBox_read);
            this.Controls.Add(this.skinButton_back);
            this.Controls.Add(this.skinButton_set);
            this.Controls.Add(this.skinTreeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setProjectRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置项目权限角色";
            this.Load += new System.EventHandler(this.setProjectRole_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinTreeView skinTreeView1;
        private CCWin.SkinControl.SkinButton skinButton_set;
        private CCWin.SkinControl.SkinButton skinButton_back;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox_read;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox_write;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox_all;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinTextBox skinTextBox_hash;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinTextBox skinTextBox_role_name;
        private CCWin.SkinControl.SkinLabel skinLabel_role_name;
    }
}
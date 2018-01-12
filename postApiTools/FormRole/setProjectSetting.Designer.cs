namespace postApiTools.FormRole
{
    partial class setProjectSetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setProjectSetting));
            this.skinTreeView_project = new CCWin.SkinControl.SkinTreeView();
            this.skinContextMenuStrip_project_setting = new CCWin.SkinControl.SkinContextMenuStrip();
            this.添加角色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看角色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinDataGridView_role_list = new CCWin.SkinControl.SkinDataGridView();
            this.hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinContextMenuStrip_project_setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView_role_list)).BeginInit();
            this.SuspendLayout();
            // 
            // skinTreeView_project
            // 
            this.skinTreeView_project.ContextMenuStrip = this.skinContextMenuStrip_project_setting;
            this.skinTreeView_project.Location = new System.Drawing.Point(7, 45);
            this.skinTreeView_project.Name = "skinTreeView_project";
            this.skinTreeView_project.Size = new System.Drawing.Size(201, 364);
            this.skinTreeView_project.TabIndex = 0;
            this.skinTreeView_project.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.skinTreeView_project_MouseDoubleClick);
            // 
            // skinContextMenuStrip_project_setting
            // 
            this.skinContextMenuStrip_project_setting.Arrow = System.Drawing.Color.Black;
            this.skinContextMenuStrip_project_setting.Back = System.Drawing.Color.White;
            this.skinContextMenuStrip_project_setting.BackRadius = 4;
            this.skinContextMenuStrip_project_setting.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.skinContextMenuStrip_project_setting.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip_project_setting.Fore = System.Drawing.Color.Black;
            this.skinContextMenuStrip_project_setting.HoverFore = System.Drawing.Color.White;
            this.skinContextMenuStrip_project_setting.ItemAnamorphosis = true;
            this.skinContextMenuStrip_project_setting.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_project_setting.ItemBorderShow = true;
            this.skinContextMenuStrip_project_setting.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_project_setting.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_project_setting.ItemRadius = 4;
            this.skinContextMenuStrip_project_setting.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_project_setting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加角色ToolStripMenuItem,
            this.查看角色ToolStripMenuItem});
            this.skinContextMenuStrip_project_setting.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_project_setting.Name = "skinContextMenuStrip_project_setting";
            this.skinContextMenuStrip_project_setting.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_project_setting.Size = new System.Drawing.Size(153, 70);
            this.skinContextMenuStrip_project_setting.SkinAllColor = true;
            this.skinContextMenuStrip_project_setting.TitleAnamorphosis = true;
            this.skinContextMenuStrip_project_setting.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStrip_project_setting.TitleRadius = 4;
            this.skinContextMenuStrip_project_setting.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_project_setting.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.skinContextMenuStrip_project_setting_ItemClicked);
            // 
            // 添加角色ToolStripMenuItem
            // 
            this.添加角色ToolStripMenuItem.Name = "添加角色ToolStripMenuItem";
            this.添加角色ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加角色ToolStripMenuItem.Text = "添加角色";
            // 
            // 查看角色ToolStripMenuItem
            // 
            this.查看角色ToolStripMenuItem.Name = "查看角色ToolStripMenuItem";
            this.查看角色ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查看角色ToolStripMenuItem.Text = "查看角色";
            // 
            // skinDataGridView_role_list
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.skinDataGridView_role_list.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.skinDataGridView_role_list.BackgroundColor = System.Drawing.SystemColors.Window;
            this.skinDataGridView_role_list.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinDataGridView_role_list.ColumnFont = null;
            this.skinDataGridView_role_list.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.skinDataGridView_role_list.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.skinDataGridView_role_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.skinDataGridView_role_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hash,
            this.role_name});
            this.skinDataGridView_role_list.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.skinDataGridView_role_list.DefaultCellStyle = dataGridViewCellStyle3;
            this.skinDataGridView_role_list.EnableHeadersVisualStyles = false;
            this.skinDataGridView_role_list.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.skinDataGridView_role_list.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinDataGridView_role_list.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView_role_list.Location = new System.Drawing.Point(214, 45);
            this.skinDataGridView_role_list.Name = "skinDataGridView_role_list";
            this.skinDataGridView_role_list.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.skinDataGridView_role_list.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView_role_list.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.skinDataGridView_role_list.RowTemplate.Height = 23;
            this.skinDataGridView_role_list.Size = new System.Drawing.Size(255, 364);
            this.skinDataGridView_role_list.TabIndex = 2;
            this.skinDataGridView_role_list.TitleBack = null;
            this.skinDataGridView_role_list.TitleBackColorBegin = System.Drawing.Color.White;
            this.skinDataGridView_role_list.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            // 
            // hash
            // 
            this.hash.HeaderText = "编号";
            this.hash.Name = "hash";
            // 
            // role_name
            // 
            this.role_name.HeaderText = "角色";
            this.role_name.Name = "role_name";
            // 
            // setProjectSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 420);
            this.Controls.Add(this.skinDataGridView_role_list);
            this.Controls.Add(this.skinTreeView_project);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setProjectSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目权限设置";
            this.Load += new System.EventHandler(this.setProjectSetting_Load);
            this.skinContextMenuStrip_project_setting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView_role_list)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinTreeView skinTreeView_project;
        private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStrip_project_setting;
        private System.Windows.Forms.ToolStripMenuItem 添加角色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看角色ToolStripMenuItem;
        private CCWin.SkinControl.SkinDataGridView skinDataGridView_role_list;
        private System.Windows.Forms.DataGridViewTextBoxColumn hash;
        private System.Windows.Forms.DataGridViewTextBoxColumn role_name;
    }
}
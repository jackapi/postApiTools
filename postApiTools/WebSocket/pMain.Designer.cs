namespace postApiTools.WebSocket
{
    partial class pMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pMain));
            this.skinButton_open = new CCWin.SkinControl.SkinButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinTextBox_ip = new CCWin.SkinControl.SkinTextBox();
            this.skinTextBox_port = new CCWin.SkinControl.SkinTextBox();
            this.skinChatRichTextBox1 = new CCWin.SkinControl.SkinChatRichTextBox();
            this.skinContextMenuStrip_send = new CCWin.SkinControl.SkinContextMenuStrip();
            this.发送ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinChatRichTextBox2 = new CCWin.SkinControl.SkinChatRichTextBox();
            this.skinContextMenuStrip_content = new CCWin.SkinControl.SkinContextMenuStrip();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinContextMenuStrip_send.SuspendLayout();
            this.skinContextMenuStrip_content.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinButton_open
            // 
            this.skinButton_open.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_open.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_open.DownBack = null;
            this.skinButton_open.Location = new System.Drawing.Point(389, 44);
            this.skinButton_open.MouseBack = null;
            this.skinButton_open.Name = "skinButton_open";
            this.skinButton_open.NormlBack = null;
            this.skinButton_open.Size = new System.Drawing.Size(75, 27);
            this.skinButton_open.TabIndex = 0;
            this.skinButton_open.Text = "打开连接";
            this.skinButton_open.UseVisualStyleBackColor = false;
            this.skinButton_open.Click += new System.EventHandler(this.skinButton_open_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(19, 50);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(55, 17);
            this.skinLabel1.TabIndex = 1;
            this.skinLabel1.Text = "IP：端口";
            // 
            // skinTextBox_ip
            // 
            this.skinTextBox_ip.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_ip.DownBack = null;
            this.skinTextBox_ip.Icon = null;
            this.skinTextBox_ip.IconIsButton = false;
            this.skinTextBox_ip.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_ip.IsPasswordChat = '\0';
            this.skinTextBox_ip.IsSystemPasswordChar = false;
            this.skinTextBox_ip.Lines = new string[0];
            this.skinTextBox_ip.Location = new System.Drawing.Point(77, 43);
            this.skinTextBox_ip.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_ip.MaxLength = 32767;
            this.skinTextBox_ip.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_ip.MouseBack = null;
            this.skinTextBox_ip.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_ip.Multiline = false;
            this.skinTextBox_ip.Name = "skinTextBox_ip";
            this.skinTextBox_ip.NormlBack = null;
            this.skinTextBox_ip.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_ip.ReadOnly = false;
            this.skinTextBox_ip.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox_ip.Size = new System.Drawing.Size(203, 28);
            // 
            // 
            // 
            this.skinTextBox_ip.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_ip.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_ip.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_ip.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_ip.SkinTxt.Name = "BaseText";
            this.skinTextBox_ip.SkinTxt.Size = new System.Drawing.Size(193, 18);
            this.skinTextBox_ip.SkinTxt.TabIndex = 0;
            this.skinTextBox_ip.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_ip.SkinTxt.WaterText = "";
            this.skinTextBox_ip.TabIndex = 2;
            this.skinTextBox_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox_ip.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_ip.WaterText = "";
            this.skinTextBox_ip.WordWrap = true;
            // 
            // skinTextBox_port
            // 
            this.skinTextBox_port.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_port.DownBack = null;
            this.skinTextBox_port.Icon = null;
            this.skinTextBox_port.IconIsButton = false;
            this.skinTextBox_port.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_port.IsPasswordChat = '\0';
            this.skinTextBox_port.IsSystemPasswordChar = false;
            this.skinTextBox_port.Lines = new string[0];
            this.skinTextBox_port.Location = new System.Drawing.Point(290, 43);
            this.skinTextBox_port.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_port.MaxLength = 32767;
            this.skinTextBox_port.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_port.MouseBack = null;
            this.skinTextBox_port.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_port.Multiline = false;
            this.skinTextBox_port.Name = "skinTextBox_port";
            this.skinTextBox_port.NormlBack = null;
            this.skinTextBox_port.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_port.ReadOnly = false;
            this.skinTextBox_port.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox_port.Size = new System.Drawing.Size(80, 28);
            // 
            // 
            // 
            this.skinTextBox_port.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_port.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_port.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_port.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_port.SkinTxt.Name = "BaseText";
            this.skinTextBox_port.SkinTxt.Size = new System.Drawing.Size(70, 18);
            this.skinTextBox_port.SkinTxt.TabIndex = 0;
            this.skinTextBox_port.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_port.SkinTxt.WaterText = "";
            this.skinTextBox_port.TabIndex = 3;
            this.skinTextBox_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox_port.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_port.WaterText = "";
            this.skinTextBox_port.WordWrap = true;
            // 
            // skinChatRichTextBox1
            // 
            this.skinChatRichTextBox1.ContextMenuStrip = this.skinContextMenuStrip_send;
            this.skinChatRichTextBox1.Location = new System.Drawing.Point(17, 102);
            this.skinChatRichTextBox1.Name = "skinChatRichTextBox1";
            this.skinChatRichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.skinChatRichTextBox1.SelectControl = null;
            this.skinChatRichTextBox1.SelectControlIndex = 0;
            this.skinChatRichTextBox1.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.skinChatRichTextBox1.Size = new System.Drawing.Size(466, 114);
            this.skinChatRichTextBox1.TabIndex = 5;
            this.skinChatRichTextBox1.Text = "";
            this.skinChatRichTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.skinChatRichTextBox1_KeyDown);
            // 
            // skinContextMenuStrip_send
            // 
            this.skinContextMenuStrip_send.Arrow = System.Drawing.Color.Black;
            this.skinContextMenuStrip_send.Back = System.Drawing.Color.White;
            this.skinContextMenuStrip_send.BackRadius = 4;
            this.skinContextMenuStrip_send.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.skinContextMenuStrip_send.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip_send.Fore = System.Drawing.Color.Black;
            this.skinContextMenuStrip_send.HoverFore = System.Drawing.Color.White;
            this.skinContextMenuStrip_send.ItemAnamorphosis = true;
            this.skinContextMenuStrip_send.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_send.ItemBorderShow = true;
            this.skinContextMenuStrip_send.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_send.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_send.ItemRadius = 4;
            this.skinContextMenuStrip_send.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_send.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发送ToolStripMenuItem,
            this.粘贴ToolStripMenuItem});
            this.skinContextMenuStrip_send.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_send.Name = "skinContextMenuStrip_send";
            this.skinContextMenuStrip_send.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_send.Size = new System.Drawing.Size(101, 48);
            this.skinContextMenuStrip_send.SkinAllColor = true;
            this.skinContextMenuStrip_send.TitleAnamorphosis = true;
            this.skinContextMenuStrip_send.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStrip_send.TitleRadius = 4;
            this.skinContextMenuStrip_send.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_send.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.skinContextMenuStrip_send_ItemClicked);
            // 
            // 发送ToolStripMenuItem
            // 
            this.发送ToolStripMenuItem.Name = "发送ToolStripMenuItem";
            this.发送ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.发送ToolStripMenuItem.Text = "发送";
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            // 
            // skinChatRichTextBox2
            // 
            this.skinChatRichTextBox2.ContextMenuStrip = this.skinContextMenuStrip_content;
            this.skinChatRichTextBox2.Location = new System.Drawing.Point(17, 242);
            this.skinChatRichTextBox2.Name = "skinChatRichTextBox2";
            this.skinChatRichTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.skinChatRichTextBox2.SelectControl = null;
            this.skinChatRichTextBox2.SelectControlIndex = 0;
            this.skinChatRichTextBox2.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.skinChatRichTextBox2.Size = new System.Drawing.Size(466, 253);
            this.skinChatRichTextBox2.TabIndex = 6;
            this.skinChatRichTextBox2.Text = "";
            // 
            // skinContextMenuStrip_content
            // 
            this.skinContextMenuStrip_content.Arrow = System.Drawing.Color.Black;
            this.skinContextMenuStrip_content.Back = System.Drawing.Color.White;
            this.skinContextMenuStrip_content.BackRadius = 4;
            this.skinContextMenuStrip_content.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.skinContextMenuStrip_content.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip_content.Fore = System.Drawing.Color.Black;
            this.skinContextMenuStrip_content.HoverFore = System.Drawing.Color.White;
            this.skinContextMenuStrip_content.ItemAnamorphosis = true;
            this.skinContextMenuStrip_content.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_content.ItemBorderShow = true;
            this.skinContextMenuStrip_content.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_content.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_content.ItemRadius = 4;
            this.skinContextMenuStrip_content.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_content.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空ToolStripMenuItem});
            this.skinContextMenuStrip_content.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_content.Name = "skinContextMenuStrip_content";
            this.skinContextMenuStrip_content.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_content.Size = new System.Drawing.Size(101, 26);
            this.skinContextMenuStrip_content.SkinAllColor = true;
            this.skinContextMenuStrip_content.TitleAnamorphosis = true;
            this.skinContextMenuStrip_content.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStrip_content.TitleRadius = 4;
            this.skinContextMenuStrip_content.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_content.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.skinContextMenuStrip_content_ItemClicked);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(19, 222);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 7;
            this.skinLabel2.Text = "接收";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(19, 82);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(56, 17);
            this.skinLabel3.TabIndex = 7;
            this.skinLabel3.Text = "发送内容";
            // 
            // pMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 512);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinChatRichTextBox2);
            this.Controls.Add(this.skinChatRichTextBox1);
            this.Controls.Add(this.skinTextBox_port);
            this.Controls.Add(this.skinTextBox_ip);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.skinButton_open);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebSocket工具测试";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pMain_FormClosed);
            this.Load += new System.EventHandler(this.pMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pMain_KeyDown);
            this.skinContextMenuStrip_send.ResumeLayout(false);
            this.skinContextMenuStrip_content.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton skinButton_open;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinTextBox skinTextBox_ip;
        private CCWin.SkinControl.SkinTextBox skinTextBox_port;
        private CCWin.SkinControl.SkinChatRichTextBox skinChatRichTextBox1;
        private CCWin.SkinControl.SkinChatRichTextBox skinChatRichTextBox2;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStrip_send;
        private System.Windows.Forms.ToolStripMenuItem 发送ToolStripMenuItem;
        private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStrip_content;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
    }
}
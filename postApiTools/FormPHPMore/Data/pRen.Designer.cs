namespace postApiTools.FormPHPMore.Data
{
    partial class pRen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pRen));
            this.skinTextBox_name = new CCWin.SkinControl.SkinTextBox();
            this.skinButton_ren = new CCWin.SkinControl.SkinButton();
            this.skinButton_close = new CCWin.SkinControl.SkinButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // skinTextBox_name
            // 
            this.skinTextBox_name.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_name.DownBack = null;
            this.skinTextBox_name.Icon = null;
            this.skinTextBox_name.IconIsButton = false;
            this.skinTextBox_name.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_name.IsPasswordChat = '\0';
            this.skinTextBox_name.IsSystemPasswordChar = false;
            this.skinTextBox_name.Lines = new string[0];
            this.skinTextBox_name.Location = new System.Drawing.Point(82, 65);
            this.skinTextBox_name.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_name.MaxLength = 32767;
            this.skinTextBox_name.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_name.MouseBack = null;
            this.skinTextBox_name.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_name.Multiline = false;
            this.skinTextBox_name.Name = "skinTextBox_name";
            this.skinTextBox_name.NormlBack = null;
            this.skinTextBox_name.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_name.ReadOnly = false;
            this.skinTextBox_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox_name.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.skinTextBox_name.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_name.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_name.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_name.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_name.SkinTxt.Name = "BaseText";
            this.skinTextBox_name.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.skinTextBox_name.SkinTxt.TabIndex = 0;
            this.skinTextBox_name.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_name.SkinTxt.WaterText = "";
            this.skinTextBox_name.TabIndex = 0;
            this.skinTextBox_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox_name.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_name.WaterText = "";
            this.skinTextBox_name.WordWrap = true;
            // 
            // skinButton_ren
            // 
            this.skinButton_ren.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_ren.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_ren.DownBack = null;
            this.skinButton_ren.Location = new System.Drawing.Point(32, 128);
            this.skinButton_ren.MouseBack = null;
            this.skinButton_ren.Name = "skinButton_ren";
            this.skinButton_ren.NormlBack = null;
            this.skinButton_ren.Size = new System.Drawing.Size(75, 23);
            this.skinButton_ren.TabIndex = 1;
            this.skinButton_ren.Text = "修改";
            this.skinButton_ren.UseVisualStyleBackColor = false;
            this.skinButton_ren.Click += new System.EventHandler(this.skinButton_ren_Click);
            // 
            // skinButton_close
            // 
            this.skinButton_close.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_close.DownBack = null;
            this.skinButton_close.Location = new System.Drawing.Point(166, 128);
            this.skinButton_close.MouseBack = null;
            this.skinButton_close.Name = "skinButton_close";
            this.skinButton_close.NormlBack = null;
            this.skinButton_close.Size = new System.Drawing.Size(75, 23);
            this.skinButton_close.TabIndex = 1;
            this.skinButton_close.Text = "关闭";
            this.skinButton_close.UseVisualStyleBackColor = false;
            this.skinButton_close.Click += new System.EventHandler(this.skinButton_close_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(10, 71);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(32, 17);
            this.skinLabel1.TabIndex = 2;
            this.skinLabel1.Text = "名称";
            // 
            // pRen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 178);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.skinButton_close);
            this.Controls.Add(this.skinButton_ren);
            this.Controls.Add(this.skinTextBox_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pRen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "重命名";
            this.Load += new System.EventHandler(this.pRen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinTextBox skinTextBox_name;
        private CCWin.SkinControl.SkinButton skinButton_ren;
        private CCWin.SkinControl.SkinButton skinButton_close;
        private CCWin.SkinControl.SkinLabel skinLabel1;
    }
}
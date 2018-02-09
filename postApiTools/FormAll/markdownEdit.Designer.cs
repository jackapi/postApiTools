namespace postApiTools.FormAll
{
    partial class markdownEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(markdownEdit));
            this.skinButton_save = new CCWin.SkinControl.SkinButton();
            this.webBrowser_markdown = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // skinButton_save
            // 
            this.skinButton_save.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_save.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_save.DownBack = null;
            this.skinButton_save.Location = new System.Drawing.Point(7, 27);
            this.skinButton_save.MouseBack = null;
            this.skinButton_save.Name = "skinButton_save";
            this.skinButton_save.NormlBack = null;
            this.skinButton_save.Size = new System.Drawing.Size(75, 23);
            this.skinButton_save.TabIndex = 1;
            this.skinButton_save.Text = "保存";
            this.skinButton_save.UseVisualStyleBackColor = false;
            this.skinButton_save.Click += new System.EventHandler(this.skinButton_save_Click);
            // 
            // webBrowser_markdown
            // 
            this.webBrowser_markdown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser_markdown.Location = new System.Drawing.Point(7, 56);
            this.webBrowser_markdown.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_markdown.Name = "webBrowser_markdown";
            this.webBrowser_markdown.ScrollBarsEnabled = false;
            this.webBrowser_markdown.Size = new System.Drawing.Size(954, 552);
            this.webBrowser_markdown.TabIndex = 2;
            // 
            // markdownEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 615);
            this.Controls.Add(this.webBrowser_markdown);
            this.Controls.Add(this.skinButton_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "markdownEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑markdown";
            this.Load += new System.EventHandler(this.markdownEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinButton skinButton_save;
        private System.Windows.Forms.WebBrowser webBrowser_markdown;
    }
}
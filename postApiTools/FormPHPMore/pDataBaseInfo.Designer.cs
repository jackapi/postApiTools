namespace postApiTools.FormPHPMore
{
    partial class pDataBaseInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pDataBaseInfo));
            this.skinButton_close = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // skinButton_close
            // 
            this.skinButton_close.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_close.DownBack = null;
            this.skinButton_close.Location = new System.Drawing.Point(239, 324);
            this.skinButton_close.MouseBack = null;
            this.skinButton_close.Name = "skinButton_close";
            this.skinButton_close.NormlBack = null;
            this.skinButton_close.Size = new System.Drawing.Size(78, 26);
            this.skinButton_close.TabIndex = 0;
            this.skinButton_close.Text = "关闭";
            this.skinButton_close.UseVisualStyleBackColor = false;
            this.skinButton_close.Click += new System.EventHandler(this.skinButton_close_Click);
            // 
            // pDataBaseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 367);
            this.Controls.Add(this.skinButton_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pDataBaseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库详情";
            this.Load += new System.EventHandler(this.pDataBaseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton skinButton_close;
    }
}
namespace postApiTools.FormPHPMore
{
    partial class pDataManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pDataManage));
            this.skinTreeView_mysql = new CCWin.SkinControl.SkinTreeView();
            this.SuspendLayout();
            // 
            // skinTreeView_mysql
            // 
            this.skinTreeView_mysql.Location = new System.Drawing.Point(11, 78);
            this.skinTreeView_mysql.Name = "skinTreeView_mysql";
            this.skinTreeView_mysql.Size = new System.Drawing.Size(214, 576);
            this.skinTreeView_mysql.TabIndex = 0;
            this.skinTreeView_mysql.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.skinTreeView_mysql_MouseDoubleClick);
            // 
            // pDataManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 661);
            this.Controls.Add(this.skinTreeView_mysql);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pDataManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MySQL管理";
            this.Load += new System.EventHandler(this.pMysqlManage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinTreeView skinTreeView_mysql;
    }
}
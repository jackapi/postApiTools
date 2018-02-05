namespace postApiTools.FormAll
{
    partial class pOutUrlData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pOutUrlData));
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.skinButton_create = new CCWin.SkinControl.SkinButton();
            this.richTextBox_result = new System.Windows.Forms.RichTextBox();
            this.checkBox_name = new System.Windows.Forms.CheckBox();
            this.checkBox_value = new System.Windows.Forms.CheckBox();
            this.checkBox_desc = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBox_type
            // 
            this.comboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "JSON",
            "Input"});
            this.comboBox_type.Location = new System.Drawing.Point(202, 50);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(136, 20);
            this.comboBox_type.TabIndex = 0;
            // 
            // skinButton_create
            // 
            this.skinButton_create.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_create.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_create.DownBack = null;
            this.skinButton_create.Location = new System.Drawing.Point(354, 47);
            this.skinButton_create.MouseBack = null;
            this.skinButton_create.Name = "skinButton_create";
            this.skinButton_create.NormlBack = null;
            this.skinButton_create.Size = new System.Drawing.Size(75, 23);
            this.skinButton_create.TabIndex = 1;
            this.skinButton_create.Text = "转换";
            this.skinButton_create.UseVisualStyleBackColor = false;
            this.skinButton_create.Click += new System.EventHandler(this.skinButton_create_Click);
            // 
            // richTextBox_result
            // 
            this.richTextBox_result.Location = new System.Drawing.Point(7, 79);
            this.richTextBox_result.Name = "richTextBox_result";
            this.richTextBox_result.Size = new System.Drawing.Size(565, 316);
            this.richTextBox_result.TabIndex = 2;
            this.richTextBox_result.Text = "";
            // 
            // checkBox_name
            // 
            this.checkBox_name.AutoSize = true;
            this.checkBox_name.Checked = true;
            this.checkBox_name.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_name.Enabled = false;
            this.checkBox_name.Location = new System.Drawing.Point(7, 54);
            this.checkBox_name.Name = "checkBox_name";
            this.checkBox_name.Size = new System.Drawing.Size(60, 16);
            this.checkBox_name.TabIndex = 3;
            this.checkBox_name.Text = "参数名";
            this.checkBox_name.UseVisualStyleBackColor = true;
            // 
            // checkBox_value
            // 
            this.checkBox_value.AutoSize = true;
            this.checkBox_value.Checked = true;
            this.checkBox_value.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_value.Enabled = false;
            this.checkBox_value.Location = new System.Drawing.Point(73, 54);
            this.checkBox_value.Name = "checkBox_value";
            this.checkBox_value.Size = new System.Drawing.Size(60, 16);
            this.checkBox_value.TabIndex = 3;
            this.checkBox_value.Text = "参数值";
            this.checkBox_value.UseVisualStyleBackColor = true;
            // 
            // checkBox_desc
            // 
            this.checkBox_desc.AutoSize = true;
            this.checkBox_desc.Location = new System.Drawing.Point(139, 54);
            this.checkBox_desc.Name = "checkBox_desc";
            this.checkBox_desc.Size = new System.Drawing.Size(48, 16);
            this.checkBox_desc.TabIndex = 3;
            this.checkBox_desc.Text = "说明";
            this.checkBox_desc.UseVisualStyleBackColor = true;
            // 
            // pOutUrlData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 412);
            this.Controls.Add(this.checkBox_desc);
            this.Controls.Add(this.checkBox_value);
            this.Controls.Add(this.checkBox_name);
            this.Controls.Add(this.richTextBox_result);
            this.Controls.Add(this.skinButton_create);
            this.Controls.Add(this.comboBox_type);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pOutUrlData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 参数导出";
            this.Load += new System.EventHandler(this.pOutUrlData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_type;
        private CCWin.SkinControl.SkinButton skinButton_create;
        private System.Windows.Forms.RichTextBox richTextBox_result;
        private System.Windows.Forms.CheckBox checkBox_name;
        private System.Windows.Forms.CheckBox checkBox_value;
        private System.Windows.Forms.CheckBox checkBox_desc;
    }
}
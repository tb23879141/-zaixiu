namespace WinFrmTalk.Controls.CustomControls
{
    partial class UserNoticeLeft
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_file = new System.Windows.Forms.Panel();
            this.lab_fileSize = new System.Windows.Forms.Label();
            this.lab_fileName = new System.Windows.Forms.Label();
            this.richTextBoxEx1 = new RichTextBoxLinks.RichTextBoxEx();
            this.panel_file.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_file
            // 
            this.panel_file.BackColor = System.Drawing.Color.White;
            this.panel_file.Controls.Add(this.lab_fileSize);
            this.panel_file.Controls.Add(this.richTextBoxEx1);
            this.panel_file.Controls.Add(this.lab_fileName);
            this.panel_file.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_file.Location = new System.Drawing.Point(0, 0);
            this.panel_file.Name = "panel_file";
            this.panel_file.Size = new System.Drawing.Size(444, 55);
            this.panel_file.TabIndex = 14;
            // 
            // lab_fileSize
            // 
            this.lab_fileSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_fileSize.AutoEllipsis = true;
            this.lab_fileSize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_fileSize.ForeColor = System.Drawing.Color.Gray;
            this.lab_fileSize.Location = new System.Drawing.Point(312, 33);
            this.lab_fileSize.Name = "lab_fileSize";
            this.lab_fileSize.Size = new System.Drawing.Size(129, 17);
            this.lab_fileSize.TabIndex = 14;
            this.lab_fileSize.Text = "王冰冷  2022-01-21";
            // 
            // lab_fileName
            // 
            this.lab_fileName.AutoEllipsis = true;
            this.lab_fileName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_fileName.Location = new System.Drawing.Point(3, 8);
            this.lab_fileName.Name = "lab_fileName";
            this.lab_fileName.Size = new System.Drawing.Size(441, 23);
            this.lab_fileName.TabIndex = 13;
            this.lab_fileName.Text = "1349f14ff0c3b27dfce.amr";
            // 
            // richTextBoxEx1
            // 
            this.richTextBoxEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxEx1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxEx1.DetectUrls = false;
            this.richTextBoxEx1.Location = new System.Drawing.Point(7, 34);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.Size = new System.Drawing.Size(434, 18);
            this.richTextBoxEx1.TabIndex = 15;
            this.richTextBoxEx1.Text = "";
            // 
            // UserNoticeLeft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_file);
            this.Name = "UserNoticeLeft";
            this.Size = new System.Drawing.Size(444, 55);
            this.panel_file.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_file;
        public System.Windows.Forms.Label lab_fileSize;
        public System.Windows.Forms.Label lab_fileName;
        public RichTextBoxLinks.RichTextBoxEx richTextBoxEx1;
    }
}

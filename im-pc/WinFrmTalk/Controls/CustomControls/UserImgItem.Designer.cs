namespace WinFrmTalk.Controls.CustomControls
{
    partial class UserImgItem
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
            this.pictureBox_view = new System.Windows.Forms.PictureBox();
            this.lab_fileSize = new System.Windows.Forms.Label();
            this.lab_fileName = new System.Windows.Forms.Label();
            this.lab_icon = new System.Windows.Forms.PictureBox();
            this.panel_file.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lab_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_file
            // 
            this.panel_file.BackColor = System.Drawing.Color.Transparent;
            this.panel_file.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_file.Controls.Add(this.pictureBox_view);
            this.panel_file.Controls.Add(this.lab_fileSize);
            this.panel_file.Controls.Add(this.lab_fileName);
            this.panel_file.Controls.Add(this.lab_icon);
            this.panel_file.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_file.Location = new System.Drawing.Point(0, 0);
            this.panel_file.Name = "panel_file";
            this.panel_file.Size = new System.Drawing.Size(80, 80);
            this.panel_file.TabIndex = 14;
            // 
            // pictureBox_view
            // 
            this.pictureBox_view.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_view.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_view.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_view.Image = global::WinFrmTalk.Properties.Resources.imgvieweye;
            this.pictureBox_view.Location = new System.Drawing.Point(0, 63);
            this.pictureBox_view.Name = "pictureBox_view";
            this.pictureBox_view.Size = new System.Drawing.Size(13, 13);
            this.pictureBox_view.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_view.TabIndex = 16;
            this.pictureBox_view.TabStop = false;
            // 
            // lab_fileSize
            // 
            this.lab_fileSize.AutoEllipsis = true;
            this.lab_fileSize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_fileSize.ForeColor = System.Drawing.Color.Gray;
            this.lab_fileSize.Location = new System.Drawing.Point(53, 33);
            this.lab_fileSize.Name = "lab_fileSize";
            this.lab_fileSize.Size = new System.Drawing.Size(388, 17);
            this.lab_fileSize.TabIndex = 14;
            this.lab_fileSize.Text = "400.0 KB";
            this.lab_fileSize.Visible = false;
            // 
            // lab_fileName
            // 
            this.lab_fileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_fileName.AutoEllipsis = true;
            this.lab_fileName.BackColor = System.Drawing.Color.Transparent;
            this.lab_fileName.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_fileName.ForeColor = System.Drawing.Color.White;
            this.lab_fileName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lab_fileName.Location = new System.Drawing.Point(11, 62);
            this.lab_fileName.Name = "lab_fileName";
            this.lab_fileName.Size = new System.Drawing.Size(70, 13);
            this.lab_fileName.TabIndex = 13;
            this.lab_fileName.Text = "2022-01-24";
            this.lab_fileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_icon
            // 
            this.lab_icon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lab_icon.Location = new System.Drawing.Point(0, 53);
            this.lab_icon.Name = "lab_icon";
            this.lab_icon.Size = new System.Drawing.Size(80, 27);
            this.lab_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lab_icon.TabIndex = 15;
            this.lab_icon.TabStop = false;
            this.lab_icon.Visible = false;
            // 
            // UserImgItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_file);
            this.Name = "UserImgItem";
            this.Size = new System.Drawing.Size(80, 80);
            this.Load += new System.EventHandler(this.FilePanel_Load);
            this.panel_file.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lab_icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel_file;
        public System.Windows.Forms.Label lab_fileSize;
        public System.Windows.Forms.Label lab_fileName;
        public System.Windows.Forms.PictureBox pictureBox_view;
        public System.Windows.Forms.PictureBox lab_icon;
    }
}

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    partial class GroupPageFile
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
            this.label1 = new System.Windows.Forms.Label();
            this.tvTitle = new System.Windows.Forms.Label();
            this.filePanel = new WinFrmTalk.Controls.SystemControls.RoundPanel();
            this.tvFileName = new System.Windows.Forms.Label();
            this.tvFileIcon = new System.Windows.Forms.PictureBox();
            this.filePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvFileIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.label1.Location = new System.Drawing.Point(20, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 1);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // tvTitle
            // 
            this.tvTitle.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvTitle.Location = new System.Drawing.Point(20, 80);
            this.tvTitle.Name = "tvTitle";
            this.tvTitle.Size = new System.Drawing.Size(630, 30);
            this.tvTitle.TabIndex = 4;
            this.tvTitle.Text = "label1";
            // 
            // filePanel
            // 
            this.filePanel.Controls.Add(this.tvFileName);
            this.filePanel.Controls.Add(this.tvFileIcon);
            this.filePanel.FillColor = System.Drawing.Color.White;
            this.filePanel.FrameColor = System.Drawing.Color.WhiteSmoke;
            this.filePanel.Location = new System.Drawing.Point(115, 160);
            this.filePanel.Name = "filePanel";
            this.filePanel.Raduis = 10;
            this.filePanel.Size = new System.Drawing.Size(440, 145);
            this.filePanel.TabIndex = 6;
            // 
            // tvFileName
            // 
            this.tvFileName.AutoEllipsis = true;
            this.tvFileName.BackColor = System.Drawing.Color.White;
            this.tvFileName.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvFileName.Location = new System.Drawing.Point(121, 22);
            this.tvFileName.Name = "tvFileName";
            this.tvFileName.Size = new System.Drawing.Size(290, 95);
            this.tvFileName.TabIndex = 5;
            this.tvFileName.Text = "最新消息";
            // 
            // tvFileIcon
            // 
            this.tvFileIcon.BackColor = System.Drawing.Color.Transparent;
            this.tvFileIcon.Location = new System.Drawing.Point(33, 22);
            this.tvFileIcon.Name = "tvFileIcon";
            this.tvFileIcon.Size = new System.Drawing.Size(70, 95);
            this.tvFileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tvFileIcon.TabIndex = 0;
            this.tvFileIcon.TabStop = false;
            // 
            // GroupPageFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.filePanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvTitle);
            this.Name = "GroupPageFile";
            this.Size = new System.Drawing.Size(670, 640);
            this.filePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvFileIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tvTitle;
        private SystemControls.RoundPanel filePanel;
        private System.Windows.Forms.Label tvFileName;
        private System.Windows.Forms.PictureBox tvFileIcon;
    }
}

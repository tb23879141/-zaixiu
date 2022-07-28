namespace WinFrmTalk.Controls.LayouotControl.Items
{
    partial class SocialCommentItem
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
            this.tvTitle = new System.Windows.Forms.Label();
            this.tvFileName = new System.Windows.Forms.Label();
            this.tvTime = new System.Windows.Forms.Label();
            this.ivIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ivIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tvTitle
            // 
            this.tvTitle.AutoEllipsis = true;
            this.tvTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvTitle.Location = new System.Drawing.Point(46, 10);
            this.tvTitle.Name = "tvTitle";
            this.tvTitle.Size = new System.Drawing.Size(370, 20);
            this.tvTitle.TabIndex = 30;
            this.tvTitle.Text = "2019/11/11";
            // 
            // tvFileName
            // 
            this.tvFileName.AutoEllipsis = true;
            this.tvFileName.AutoSize = true;
            this.tvFileName.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvFileName.Location = new System.Drawing.Point(45, 34);
            this.tvFileName.MaximumSize = new System.Drawing.Size(380, 50);
            this.tvFileName.Name = "tvFileName";
            this.tvFileName.Size = new System.Drawing.Size(268, 19);
            this.tvFileName.TabIndex = 32;
            this.tvFileName.Text = "微软雅黑,微软雅黑,微软雅黑,微软雅黑,微软雅";
            // 
            // tvTime
            // 
            this.tvTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvTime.Location = new System.Drawing.Point(45, 57);
            this.tvTime.Name = "tvTime";
            this.tvTime.Size = new System.Drawing.Size(300, 19);
            this.tvTime.TabIndex = 34;
            this.tvTime.Text = "2019/11/11 11:22:33 4444";
            // 
            // ivIcon
            // 
            this.ivIcon.Location = new System.Drawing.Point(10, 6);
            this.ivIcon.Name = "ivIcon";
            this.ivIcon.Size = new System.Drawing.Size(30, 30);
            this.ivIcon.TabIndex = 33;
            this.ivIcon.TabStop = false;
            // 
            // SocialCommentItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.tvTime);
            this.Controls.Add(this.tvFileName);
            this.Controls.Add(this.ivIcon);
            this.Controls.Add(this.tvTitle);
            this.Name = "SocialCommentItem";
            this.Size = new System.Drawing.Size(430, 85);
            ((System.ComponentModel.ISupportInitialize)(this.ivIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label tvTitle;
        private System.Windows.Forms.PictureBox ivIcon;
        private System.Windows.Forms.Label tvTime;
        private System.Windows.Forms.Label tvFileName;
    }
}
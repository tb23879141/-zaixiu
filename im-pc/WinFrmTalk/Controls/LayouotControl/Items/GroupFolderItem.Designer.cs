namespace WinFrmTalk.Controls.LayouotControl.Items
{
    partial class GroupFolderItem
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
            this.components = new System.ComponentModel.Container();
            this.tvName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tvCount = new System.Windows.Forms.Label();
            this.imageViewxFloder1 = new WinFrmTalk.Controls.ImageViewxFloder2();
            this.SuspendLayout();
            // 
            // tvName
            // 
            this.tvName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvName.AutoEllipsis = true;
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tvName.Location = new System.Drawing.Point(0, 101);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(126, 19);
            this.tvName.TabIndex = 36;
            this.tvName.Text = "2019/11/11";
            this.tvName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tvCount
            // 
            this.tvCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tvCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(218)))), ((int)(((byte)(116)))));
            this.tvCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(151)))), ((int)(((byte)(0)))));
            this.tvCount.Location = new System.Drawing.Point(55, 74);
            this.tvCount.Name = "tvCount";
            this.tvCount.Size = new System.Drawing.Size(54, 19);
            this.tvCount.TabIndex = 38;
            this.tvCount.Text = "6张";
            this.tvCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageViewxFloder1
            // 
            this.imageViewxFloder1.FolderType = 0;
            this.imageViewxFloder1.Image = null;
            this.imageViewxFloder1.Location = new System.Drawing.Point(13, 10);
            this.imageViewxFloder1.Name = "imageViewxFloder1";
            this.imageViewxFloder1.Size = new System.Drawing.Size(100, 86);
            this.imageViewxFloder1.TabIndex = 37;
            this.imageViewxFloder1.Text = "imageViewxFloder1";
            // 
            // GroupFolderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvCount);
            this.Controls.Add(this.imageViewxFloder1);
            this.Controls.Add(this.tvName);
            this.Name = "GroupFolderItem";
            this.Size = new System.Drawing.Size(126, 125);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label tvName;
        private ImageViewxFloder2 imageViewxFloder1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label tvCount;
    }
}
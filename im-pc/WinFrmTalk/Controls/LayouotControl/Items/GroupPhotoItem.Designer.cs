namespace WinFrmTalk.Controls.LayouotControl.Items
{
    partial class GroupPhotoItem
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
            this.tvCount = new System.Windows.Forms.Label();
            this.tvName = new System.Windows.Forms.Label();
            this.imageViewxFloder1 = new WinFrmTalk.Controls.ImageViewxFloder();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // tvCount
            // 
            this.tvCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tvCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvCount.Location = new System.Drawing.Point(170, 175);
            this.tvCount.Name = "tvCount";
            this.tvCount.Size = new System.Drawing.Size(29, 19);
            this.tvCount.TabIndex = 35;
            this.tvCount.Text = "6张";
            this.tvCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tvName
            // 
            this.tvName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvName.AutoEllipsis = true;
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvName.Location = new System.Drawing.Point(3, 173);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(161, 19);
            this.tvName.TabIndex = 36;
            this.tvName.Text = "2019/11/11";
            // 
            // imageViewxFloder1
            // 
            this.imageViewxFloder1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageViewxFloder1.Image = null;
            this.imageViewxFloder1.Location = new System.Drawing.Point(5, 0);
            this.imageViewxFloder1.Name = "imageViewxFloder1";
            this.imageViewxFloder1.Size = new System.Drawing.Size(195, 165);
            this.imageViewxFloder1.TabIndex = 37;
            this.imageViewxFloder1.Text = "imageViewxFloder1";
            // 
            // GroupPhotoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvCount);
            this.Controls.Add(this.imageViewxFloder1);
            this.Controls.Add(this.tvName);
            this.Name = "GroupPhotoItem";
            this.Size = new System.Drawing.Size(202, 200);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label tvCount;
        private System.Windows.Forms.Label tvName;
        private ImageViewxFloder imageViewxFloder1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
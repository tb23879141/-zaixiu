namespace WinFrmTalk.Controls.LayouotControl.Items
{
    partial class GroupVideoItem
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
            this.tvName = new System.Windows.Forms.Label();
            this.tvLength = new System.Windows.Forms.Label();
            this.imageViewxVideo1 = new WinFrmTalk.Controls.ImageViewxVideo();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewxVideo1)).BeginInit();
            this.SuspendLayout();
            // 
            // tvName
            // 
            this.tvName.AutoEllipsis = true;
            this.tvName.AutoSize = true;
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvName.Location = new System.Drawing.Point(1, 105);
            this.tvName.MaximumSize = new System.Drawing.Size(175, 44);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(129, 20);
            this.tvName.TabIndex = 7;
            this.tvName.Text = "付费付费付费付费";
            // 
            // tvLength
            // 
            this.tvLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvLength.AutoEllipsis = true;
            this.tvLength.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvLength.Location = new System.Drawing.Point(3, 130);
            this.tvLength.Name = "tvLength";
            this.tvLength.Size = new System.Drawing.Size(196, 18);
            this.tvLength.TabIndex = 8;
            this.tvLength.Text = "付费";
            // 
            // imageViewxVideo1
            // 
            this.imageViewxVideo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageViewxVideo1.Image = null;
            this.imageViewxVideo1.Location = new System.Drawing.Point(0, 0);
            this.imageViewxVideo1.Name = "imageViewxVideo1";
            this.imageViewxVideo1.Size = new System.Drawing.Size(202, 100);
            this.imageViewxVideo1.TabIndex = 9;
            this.imageViewxVideo1.TabStop = false;
            // 
            // GroupVideoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.Controls.Add(this.tvLength);
            this.Controls.Add(this.tvName);
            this.Controls.Add(this.imageViewxVideo1);
            this.Name = "GroupVideoItem";
            this.Size = new System.Drawing.Size(202, 150);
            ((System.ComponentModel.ISupportInitialize)(this.imageViewxVideo1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label tvName;
        private System.Windows.Forms.Label tvLength;
        private ImageViewxVideo imageViewxVideo1;
    }
}
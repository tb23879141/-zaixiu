
namespace WinFrmTalk.Controls.CustomControls
{
    partial class LeftlayoutItem
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
            this.tvText = new System.Windows.Forms.Label();
            this.ivImage = new WinFrmTalk.Controls.ImageViewx();
            ((System.ComponentModel.ISupportInitialize)(this.ivImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tvText
            // 
            this.tvText.BackColor = System.Drawing.Color.Transparent;
            this.tvText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvText.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvText.ForeColor = System.Drawing.Color.White;
            this.tvText.Location = new System.Drawing.Point(39, 18);
            this.tvText.Margin = new System.Windows.Forms.Padding(0);
            this.tvText.Name = "tvText";
            this.tvText.Size = new System.Drawing.Size(58, 21);
            this.tvText.TabIndex = 14;
            this.tvText.Text = "1111";
            // 
            // ivImage
            // 
            this.ivImage.BackColor = System.Drawing.Color.Transparent;
            this.ivImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ivImage.Location = new System.Drawing.Point(2, 8);
            this.ivImage.Name = "ivImage";
            this.ivImage.Padding = new System.Windows.Forms.Padding(5);
            this.ivImage.Size = new System.Drawing.Size(41, 41);
            this.ivImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ivImage.TabIndex = 13;
            this.ivImage.TabStop = false;
            this.ivImage.UnreadCount = 0;
            this.ivImage.UnreadMargin = 0;
            this.ivImage.UnreadSize = 20;
            // 
            // LeftlayoutItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.ivImage);
            this.Controls.Add(this.tvText);
            this.DoubleBuffered = true;
            this.Name = "LeftlayoutItem";
            this.Size = new System.Drawing.Size(100, 60);
            ((System.ComponentModel.ISupportInitialize)(this.ivImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label tvText;
        private ImageViewx ivImage;
    }
}

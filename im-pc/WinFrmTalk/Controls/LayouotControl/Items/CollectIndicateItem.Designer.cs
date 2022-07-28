namespace WinFrmTalk.Controls.LayouotControl.Items
{
    partial class CollectIndicateItem
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
            this.ivImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ivImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tvText
            // 
            this.tvText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tvText.Location = new System.Drawing.Point(1, 34);
            this.tvText.Name = "tvText";
            this.tvText.Size = new System.Drawing.Size(52, 16);
            this.tvText.TabIndex = 1;
            this.tvText.Text = "相册";
            this.tvText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ivImage
            // 
            this.ivImage.Image = global::WinFrmTalk.Properties.Resources.ic_group_tab_p0;
            this.ivImage.Location = new System.Drawing.Point(11, 3);
            this.ivImage.Name = "ivImage";
            this.ivImage.Size = new System.Drawing.Size(30, 30);
            this.ivImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ivImage.TabIndex = 0;
            this.ivImage.TabStop = false;
            // 
            // CollectIndicateItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ivImage);
            this.Controls.Add(this.tvText);
            this.Name = "CollectIndicateItem";
            this.Size = new System.Drawing.Size(52, 52);
            ((System.ComponentModel.ISupportInitialize)(this.ivImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ivImage;
        private System.Windows.Forms.Label tvText;
    }
}

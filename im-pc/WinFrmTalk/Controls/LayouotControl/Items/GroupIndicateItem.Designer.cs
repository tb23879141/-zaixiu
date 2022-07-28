namespace WinFrmTalk.Controls.LayouotControl.Items
{
    partial class GroupIndicateItem
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
            this.tvText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tvText.Location = new System.Drawing.Point(3, 39);
            this.tvText.Name = "tvText";
            this.tvText.Size = new System.Drawing.Size(50, 12);
            this.tvText.TabIndex = 1;
            this.tvText.Text = "相册";
            this.tvText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ivImage
            // 
            this.ivImage.Image = global::WinFrmTalk.Properties.Resources.ic_group_tab_p0;
            this.ivImage.Location = new System.Drawing.Point(9, 3);
            this.ivImage.Name = "ivImage";
            this.ivImage.Size = new System.Drawing.Size(34, 34);
            this.ivImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ivImage.TabIndex = 0;
            this.ivImage.TabStop = false;
            // 
            // GroupIndicateItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tvText);
            this.Controls.Add(this.ivImage);
            this.Name = "GroupIndicateItem";
            this.Size = new System.Drawing.Size(50, 55);
            ((System.ComponentModel.ISupportInitialize)(this.ivImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ivImage;
        private System.Windows.Forms.Label tvText;
    }
}

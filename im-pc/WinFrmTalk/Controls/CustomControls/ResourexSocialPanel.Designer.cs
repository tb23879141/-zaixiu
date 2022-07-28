namespace WinFrmTalk.Controls
{
    partial class ResourexSocialPanel
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
            this.lab_lineSilver = new System.Windows.Forms.Label();
            this.tvTitle = new System.Windows.Forms.Label();
            this.ivImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ivImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_lineSilver
            // 
            this.lab_lineSilver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_lineSilver.BackColor = System.Drawing.Color.Silver;
            this.lab_lineSilver.Location = new System.Drawing.Point(0, 28);
            this.lab_lineSilver.Name = "lab_lineSilver";
            this.lab_lineSilver.Size = new System.Drawing.Size(210, 1);
            this.lab_lineSilver.TabIndex = 15;
            // 
            // tvTitle
            // 
            this.tvTitle.AutoSize = true;
            this.tvTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvTitle.Location = new System.Drawing.Point(5, 4);
            this.tvTitle.Name = "tvTitle";
            this.tvTitle.Size = new System.Drawing.Size(51, 20);
            this.tvTitle.TabIndex = 13;
            this.tvTitle.Text = "我是谁";
            // 
            // ivImage
            // 
            this.ivImage.Location = new System.Drawing.Point(2, 38);
            this.ivImage.Name = "ivImage";
            this.ivImage.Size = new System.Drawing.Size(200, 112);
            this.ivImage.TabIndex = 16;
            this.ivImage.TabStop = false;
            // 
            // ResourexPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lab_lineSilver);
            this.Controls.Add(this.ivImage);
            this.Controls.Add(this.tvTitle);
            this.Name = "ResourexPanel";
            this.Size = new System.Drawing.Size(210, 161);
            ((System.ComponentModel.ISupportInitialize)(this.ivImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lab_lineSilver;
        public System.Windows.Forms.Label tvTitle;
        public System.Windows.Forms.PictureBox ivImage;
    }
}

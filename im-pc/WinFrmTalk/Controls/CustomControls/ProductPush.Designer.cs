namespace WinFrmTalk.Controls.CustomControls
{
    partial class ProductPush
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
            this.picImg = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.TextBoxlabelGoodName = new RichTextBoxLinks.RichTextBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.SuspendLayout();
            // 
            // picImg
            // 
            this.picImg.BackColor = System.Drawing.Color.White;
            this.picImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picImg.Location = new System.Drawing.Point(0, 0);
            this.picImg.Margin = new System.Windows.Forms.Padding(0);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(260, 260);
            this.picImg.TabIndex = 5;
            this.picImg.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(0, 261);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(53, 21);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "￥360";
            // 
            // TextBoxlabelGoodName
            // 
            this.TextBoxlabelGoodName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxlabelGoodName.DetectUrls = false;
            this.TextBoxlabelGoodName.Location = new System.Drawing.Point(0, 283);
            this.TextBoxlabelGoodName.Name = "TextBoxlabelGoodName";
            this.TextBoxlabelGoodName.Size = new System.Drawing.Size(260, 96);
            this.TextBoxlabelGoodName.TabIndex = 6;
            this.TextBoxlabelGoodName.Text = "";
            // 
            // ProductPush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.picImg);
            this.Controls.Add(this.TextBoxlabelGoodName);
            this.Controls.Add(this.lblTitle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ProductPush";
            this.Size = new System.Drawing.Size(260, 395);
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox picImg;
        public System.Windows.Forms.Label lblTitle;
        private RichTextBoxLinks.RichTextBoxEx TextBoxlabelGoodName;
    }
}

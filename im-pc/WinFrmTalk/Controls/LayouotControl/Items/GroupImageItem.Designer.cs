namespace WinFrmTalk.Controls.LayouotControl.Items
{
    partial class GroupImageItem
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
            this.imageViewxFloder1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageViewxFloder1)).BeginInit();
            this.SuspendLayout();
            // 
            // tvName
            // 
            this.tvName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvName.AutoEllipsis = true;
            this.tvName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.White;
            this.tvName.Location = new System.Drawing.Point(0, 130);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(120, 20);
            this.tvName.TabIndex = 36;
            this.tvName.Text = "2019/11/11";
            this.tvName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageViewxFloder1
            // 
            this.imageViewxFloder1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageViewxFloder1.Location = new System.Drawing.Point(0, 0);
            this.imageViewxFloder1.Name = "imageViewxFloder1";
            this.imageViewxFloder1.Size = new System.Drawing.Size(120, 130);
            this.imageViewxFloder1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageViewxFloder1.TabIndex = 37;
            this.imageViewxFloder1.TabStop = false;
            this.imageViewxFloder1.Text = "imageViewxFloder1";
            // 
            // GroupImageItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvName);
            this.Controls.Add(this.imageViewxFloder1);
            this.Name = "GroupImageItem";
            this.Size = new System.Drawing.Size(120, 150);
            ((System.ComponentModel.ISupportInitialize)(this.imageViewxFloder1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label tvName;
        private System.Windows.Forms.PictureBox imageViewxFloder1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
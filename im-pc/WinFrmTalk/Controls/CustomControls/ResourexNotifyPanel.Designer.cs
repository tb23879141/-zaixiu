namespace WinFrmTalk.Controls
{
    partial class ResourexNotifyPanel
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
            this.tvContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_lineSilver
            // 
            this.lab_lineSilver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_lineSilver.BackColor = System.Drawing.Color.Silver;
            this.lab_lineSilver.Location = new System.Drawing.Point(0, 28);
            this.lab_lineSilver.Name = "lab_lineSilver";
            this.lab_lineSilver.Size = new System.Drawing.Size(236, 1);
            this.lab_lineSilver.TabIndex = 15;
            // 
            // tvTitle
            // 
            this.tvTitle.AutoEllipsis = true;
            this.tvTitle.AutoSize = true;
            this.tvTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvTitle.Location = new System.Drawing.Point(2, 4);
            this.tvTitle.MaximumSize = new System.Drawing.Size(230, 20);
            this.tvTitle.Name = "tvTitle";
            this.tvTitle.Size = new System.Drawing.Size(51, 20);
            this.tvTitle.TabIndex = 13;
            this.tvTitle.Text = "我是谁";
            // 
            // tvContent
            // 
            this.tvContent.AutoEllipsis = true;
            this.tvContent.AutoSize = true;
            this.tvContent.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tvContent.Location = new System.Drawing.Point(2, 39);
            this.tvContent.MaximumSize = new System.Drawing.Size(230, 800);
            this.tvContent.MinimumSize = new System.Drawing.Size(230, 0);
            this.tvContent.Name = "tvContent";
            this.tvContent.Size = new System.Drawing.Size(230, 20);
            this.tvContent.TabIndex = 16;
            this.tvContent.Text = "我是谁";
            // 
            // ResourexNotifyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tvContent);
            this.Controls.Add(this.lab_lineSilver);
            this.Controls.Add(this.tvTitle);
            this.Name = "ResourexNotifyPanel";
            this.Size = new System.Drawing.Size(236, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lab_lineSilver;
        public System.Windows.Forms.Label tvTitle;
        public System.Windows.Forms.Label tvContent;
    }
}

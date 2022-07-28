namespace WinFrmTalk.Controls.LayouotControl.Items
{
    partial class GroupNotifyItem
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
            this.tvTime = new System.Windows.Forms.Label();
            this.tvTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ivIcon = new System.Windows.Forms.PictureBox();
            this.tvContent = new RichTextBoxLinks.RichTextBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.ivIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tvTime
            // 
            this.tvTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tvTime.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tvTime.Location = new System.Drawing.Point(373, 107);
            this.tvTime.Name = "tvTime";
            this.tvTime.Size = new System.Drawing.Size(305, 24);
            this.tvTime.TabIndex = 26;
            this.tvTime.Text = "2019/11/11";
            this.tvTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tvTitle
            // 
            this.tvTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvTitle.AutoEllipsis = true;
            this.tvTitle.BackColor = System.Drawing.Color.Transparent;
            this.tvTitle.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tvTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvTitle.Location = new System.Drawing.Point(3, 5);
            this.tvTitle.Name = "tvTitle";
            this.tvTitle.Size = new System.Drawing.Size(587, 34);
            this.tvTitle.TabIndex = 27;
            this.tvTitle.Text = "Name";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(12, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(660, 1);
            this.label1.TabIndex = 29;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ivIcon
            // 
            this.ivIcon.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ivIcon.Location = new System.Drawing.Point(12, 44);
            this.ivIcon.Name = "ivIcon";
            this.ivIcon.Size = new System.Drawing.Size(60, 60);
            this.ivIcon.TabIndex = 30;
            this.ivIcon.TabStop = false;
            this.ivIcon.Visible = false;
            // 
            // tvContent
            // 
            this.tvContent.BackColor = System.Drawing.SystemColors.Control;
            this.tvContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvContent.DetectUrls = false;
            this.tvContent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tvContent.Location = new System.Drawing.Point(8, 44);
            this.tvContent.Name = "tvContent";
            this.tvContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tvContent.Size = new System.Drawing.Size(660, 37);
            this.tvContent.TabIndex = 28;
            this.tvContent.Text = "正文部分";
            // 
            // GroupNotifyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ivIcon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvContent);
            this.Controls.Add(this.tvTime);
            this.Controls.Add(this.tvTitle);
            this.Name = "GroupNotifyItem";
            this.Size = new System.Drawing.Size(689, 150);
            ((System.ComponentModel.ISupportInitialize)(this.ivIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label tvTime;
        private System.Windows.Forms.Label tvTitle;
        private RichTextBoxLinks.RichTextBoxEx tvContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ivIcon;
    }
}
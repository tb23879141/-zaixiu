namespace WinFrmTalk.Controls
{
    partial class CardPanel
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
            this.ivIcon = new System.Windows.Forms.PictureBox();
            this.lab_txt = new System.Windows.Forms.Label();
            this.lab_lineSilver = new System.Windows.Forms.Label();
            this.tvName = new System.Windows.Forms.Label();
            this.tvAccount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ivIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // ivIcon
            // 
            this.ivIcon.Location = new System.Drawing.Point(9, 17);
            this.ivIcon.Name = "ivIcon";
            this.ivIcon.Size = new System.Drawing.Size(47, 47);
            this.ivIcon.TabIndex = 16;
            this.ivIcon.TabStop = false;
            // 
            // lab_txt
            // 
            this.lab_txt.AutoSize = true;
            this.lab_txt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lab_txt.ForeColor = System.Drawing.Color.White;
            this.lab_txt.Location = new System.Drawing.Point(6, 88);
            this.lab_txt.Name = "lab_txt";
            this.lab_txt.Size = new System.Drawing.Size(56, 17);
            this.lab_txt.TabIndex = 0;
            this.lab_txt.Text = "个人名片";
            // 
            // lab_lineSilver
            // 
            this.lab_lineSilver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_lineSilver.BackColor = System.Drawing.Color.White;
            this.lab_lineSilver.Location = new System.Drawing.Point(10, 78);
            this.lab_lineSilver.Name = "lab_lineSilver";
            this.lab_lineSilver.Size = new System.Drawing.Size(208, 1);
            this.lab_lineSilver.TabIndex = 15;
            // 
            // tvName
            // 
            this.tvName.AutoEllipsis = true;
            this.tvName.AutoSize = true;
            this.tvName.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tvName.ForeColor = System.Drawing.Color.White;
            this.tvName.Location = new System.Drawing.Point(66, 21);
            this.tvName.MaximumSize = new System.Drawing.Size(158, 19);
            this.tvName.Name = "tvName";
            this.tvName.Size = new System.Drawing.Size(156, 19);
            this.tvName.TabIndex = 17;
            this.tvName.Text = "label1label1label1label1label1";
            // 
            // tvAccount
            // 
            this.tvAccount.AutoEllipsis = true;
            this.tvAccount.AutoSize = true;
            this.tvAccount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvAccount.ForeColor = System.Drawing.Color.White;
            this.tvAccount.Location = new System.Drawing.Point(66, 47);
            this.tvAccount.MaximumSize = new System.Drawing.Size(158, 17);
            this.tvAccount.Name = "tvAccount";
            this.tvAccount.Size = new System.Drawing.Size(53, 17);
            this.tvAccount.TabIndex = 18;
            this.tvAccount.Text = "label2la";
            // 
            // CardPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::WinFrmTalk.Properties.Resources.ic_card_bg;
            this.Controls.Add(this.tvAccount);
            this.Controls.Add(this.tvName);
            this.Controls.Add(this.ivIcon);
            this.Controls.Add(this.lab_txt);
            this.Controls.Add(this.lab_lineSilver);
            this.Name = "CardPanel";
            this.Size = new System.Drawing.Size(227, 118);
            ((System.ComponentModel.ISupportInitialize)(this.ivIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lab_txt;
        private System.Windows.Forms.Label lab_lineSilver;
        public System.Windows.Forms.PictureBox ivIcon;
        private System.Windows.Forms.Label tvName;
        private System.Windows.Forms.Label tvAccount;
    }
}

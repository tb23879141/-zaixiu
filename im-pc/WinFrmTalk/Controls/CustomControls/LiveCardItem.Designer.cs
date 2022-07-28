namespace WinFrmTalk.Controls.CustomControls
{
    partial class LiveCardItem
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
            this.iv_cover = new System.Windows.Forms.PictureBox();
            this.tv_title = new System.Windows.Forms.Label();
            this.iv_head = new System.Windows.Forms.PictureBox();
            this.tv_nickname = new System.Windows.Forms.Label();
            this.tv_count = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iv_cover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iv_head)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // iv_cover
            // 
            this.iv_cover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iv_cover.Dock = System.Windows.Forms.DockStyle.Top;
            this.iv_cover.Location = new System.Drawing.Point(0, 0);
            this.iv_cover.Name = "iv_cover";
            this.iv_cover.Size = new System.Drawing.Size(240, 135);
            this.iv_cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iv_cover.TabIndex = 0;
            this.iv_cover.TabStop = false;
            // 
            // tv_title
            // 
            this.tv_title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tv_title.AutoSize = true;
            this.tv_title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_title.Location = new System.Drawing.Point(15, 142);
            this.tv_title.Name = "tv_title";
            this.tv_title.Size = new System.Drawing.Size(35, 20);
            this.tv_title.TabIndex = 1;
            this.tv_title.Text = "title";
            // 
            // iv_head
            // 
            this.iv_head.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iv_head.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iv_head.Location = new System.Drawing.Point(15, 168);
            this.iv_head.Name = "iv_head";
            this.iv_head.Size = new System.Drawing.Size(30, 30);
            this.iv_head.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iv_head.TabIndex = 2;
            this.iv_head.TabStop = false;
            // 
            // tv_nickname
            // 
            this.tv_nickname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tv_nickname.AutoSize = true;
            this.tv_nickname.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_nickname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tv_nickname.Location = new System.Drawing.Point(54, 175);
            this.tv_nickname.Name = "tv_nickname";
            this.tv_nickname.Size = new System.Drawing.Size(66, 17);
            this.tv_nickname.TabIndex = 3;
            this.tv_nickname.Text = "nickName";
            this.tv_nickname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tv_count
            // 
            this.tv_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_count.AutoSize = true;
            this.tv_count.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_count.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tv_count.Location = new System.Drawing.Point(211, 175);
            this.tv_count.Name = "tv_count";
            this.tv_count.Size = new System.Drawing.Size(22, 17);
            this.tv_count.TabIndex = 5;
            this.tv_count.Text = "15";
            this.tv_count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::WinFrmTalk.Properties.Resources.Numbers;
            this.pictureBox3.Location = new System.Drawing.Point(189, 174);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 18);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // LiveCardItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tv_count);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.tv_nickname);
            this.Controls.Add(this.iv_head);
            this.Controls.Add(this.tv_title);
            this.Controls.Add(this.iv_cover);
            this.Margin = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.Name = "LiveCardItem";
            this.Size = new System.Drawing.Size(240, 208);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LiveCardItem_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LiveCardItem_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.iv_cover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iv_head)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox iv_cover;
        private System.Windows.Forms.Label tv_title;
        private System.Windows.Forms.PictureBox iv_head;
        private System.Windows.Forms.Label tv_nickname;
        private System.Windows.Forms.Label tv_count;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

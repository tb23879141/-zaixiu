namespace WinFrmTalk.Controls
{
    partial class UserAudioMeet
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
            this.lblName = new System.Windows.Forms.Label();
            this.pics = new WinFrmTalk.RoundPicBox();
            ((System.ComponentModel.ISupportInitialize)(this.pics)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(3, 87);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(114, 20);
            this.lblName.TabIndex = 6;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pics
            // 
            this.pics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pics.isDrawRound = true;
            this.pics.Location = new System.Drawing.Point(30, 15);
            this.pics.Name = "pics";
            this.pics.Size = new System.Drawing.Size(60, 60);
            this.pics.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pics.TabIndex = 5;
            this.pics.TabStop = false;
            // 
            // UserAudioMeet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pics);
            this.Name = "UserAudioMeet";
            this.Size = new System.Drawing.Size(120, 120);
            ((System.ComponentModel.ISupportInitialize)(this.pics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public RoundPicBox pics;
        public System.Windows.Forms.Label lblName;
    }
}

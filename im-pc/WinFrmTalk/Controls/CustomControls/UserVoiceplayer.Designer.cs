namespace WinFrmTalk.Controls.CustomControls
{
    partial class UserVoiceplayer
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
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblStopTime = new System.Windows.Forms.Label();
            this.pboxStart = new System.Windows.Forms.PictureBox();
            this.musicBar1 = new WinFrmTalk.Controls.MusicBar();
            ((System.ComponentModel.ISupportInitialize)(this.pboxStart)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStartTime
            // 
            this.lblStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.ForeColor = System.Drawing.Color.Black;
            this.lblStartTime.Location = new System.Drawing.Point(51, 24);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(35, 12);
            this.lblStartTime.TabIndex = 12;
            this.lblStartTime.Text = "00:00";
            // 
            // lblStopTime
            // 
            this.lblStopTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStopTime.AutoSize = true;
            this.lblStopTime.ForeColor = System.Drawing.Color.Black;
            this.lblStopTime.Location = new System.Drawing.Point(402, 24);
            this.lblStopTime.Name = "lblStopTime";
            this.lblStopTime.Size = new System.Drawing.Size(35, 12);
            this.lblStopTime.TabIndex = 13;
            this.lblStopTime.Text = "00:00";
            // 
            // pboxStart
            // 
            this.pboxStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pboxStart.Image = global::WinFrmTalk.Properties.Resources.ic_voice_play;
            this.pboxStart.Location = new System.Drawing.Point(15, 15);
            this.pboxStart.Name = "pboxStart";
            this.pboxStart.Size = new System.Drawing.Size(30, 30);
            this.pboxStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxStart.TabIndex = 14;
            this.pboxStart.TabStop = false;
            this.pboxStart.Click += new System.EventHandler(this.pboxStart_Click);
            // 
            // musicBar1
            // 
            this.musicBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.musicBar1.BackColor = System.Drawing.Color.Transparent;
            this.musicBar1.BarWidth = 4;
            this.musicBar1.Location = new System.Drawing.Point(96, 15);
            this.musicBar1.MaxValue = 100D;
            this.musicBar1.Name = "musicBar1";
            this.musicBar1.Size = new System.Drawing.Size(293, 25);
            this.musicBar1.TabIndex = 26;
            this.musicBar1.Value = 0D;
            // 
            // UserVoiceplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.musicBar1);
            this.Controls.Add(this.pboxStart);
            this.Controls.Add(this.lblStopTime);
            this.Controls.Add(this.lblStartTime);
            this.Name = "UserVoiceplayer";
            this.Size = new System.Drawing.Size(445, 60);
            ((System.ComponentModel.ISupportInitialize)(this.pboxStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblStopTime;
        private System.Windows.Forms.PictureBox pboxStart;
        private MusicBar musicBar1;
    }
}

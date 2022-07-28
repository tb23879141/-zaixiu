namespace WinFrmTalk.Live.Controls
{
    partial class UserLivePlayer
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
            this.playwnd1 = new System.Windows.Forms.PictureBox();
            this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            ((System.ComponentModel.ISupportInitialize)(this.playwnd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // playwnd1
            // 
            this.playwnd1.BackColor = System.Drawing.Color.Black;
            this.playwnd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playwnd1.Location = new System.Drawing.Point(0, 0);
            this.playwnd1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.playwnd1.Name = "playwnd1";
            this.playwnd1.Size = new System.Drawing.Size(947, 683);
            this.playwnd1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playwnd1.TabIndex = 1;
            this.playwnd1.TabStop = false;
            this.playwnd1.Visible = false;
            // 
            // vlcControl1
            // 
            this.vlcControl1.BackColor = System.Drawing.Color.Black;
            this.vlcControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcControl1.Location = new System.Drawing.Point(0, 0);
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Size = new System.Drawing.Size(947, 683);
            this.vlcControl1.Spu = -1;
            this.vlcControl1.TabIndex = 2;
            this.vlcControl1.Text = "vlcControl1";
            this.vlcControl1.VlcLibDirectory = null;
            this.vlcControl1.VlcMediaplayerOptions = null;
            this.vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
            this.vlcControl1.Playing += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs>(this.vlcControl1_Playing);
            this.vlcControl1.Stopped += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs>(this.VlcControl1_Stopped);
            // 
            // UserLivePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vlcControl1);
            this.Controls.Add(this.playwnd1);
            this.Name = "UserLivePlayer";
            this.Size = new System.Drawing.Size(947, 683);
            this.Load += new System.EventHandler(this.UserLivePlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playwnd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox playwnd1;
        public Vlc.DotNet.Forms.VlcControl vlcControl1;
    }
}

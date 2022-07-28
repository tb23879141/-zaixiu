using TestListView;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    partial class GroupIndicateLayout
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
            this.skinLine1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNotify = new WinFrmTalk.Controls.LayouotControl.Items.GroupIndicateItem();
            this.btnActive = new WinFrmTalk.Controls.LayouotControl.Items.GroupIndicateItem();
            this.btnFiles = new WinFrmTalk.Controls.LayouotControl.Items.GroupIndicateItem();
            this.btnVideo = new WinFrmTalk.Controls.LayouotControl.Items.GroupIndicateItem();
            this.btnPhotos = new WinFrmTalk.Controls.LayouotControl.Items.GroupIndicateItem();
            this.btnTopic = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinLine1
            // 
            this.skinLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.skinLine1.BackColor = System.Drawing.Color.Gainsboro;
            this.skinLine1.Location = new System.Drawing.Point(0, 0);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(1, 500);
            this.skinLine1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel1.Controls.Add(this.btnNotify);
            this.flowLayoutPanel1.Controls.Add(this.btnActive);
            this.flowLayoutPanel1.Controls.Add(this.btnFiles);
            this.flowLayoutPanel1.Controls.Add(this.btnVideo);
            this.flowLayoutPanel1.Controls.Add(this.btnPhotos);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(51, 331);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // btnNotify
            // 
            this.btnNotify.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNotify.Desname = "公告";
            this.btnNotify.Image = global::WinFrmTalk.Properties.Resources.ic_group_tab_n0;
            this.btnNotify.Location = new System.Drawing.Point(0, 0);
            this.btnNotify.Margin = new System.Windows.Forms.Padding(0);
            this.btnNotify.Name = "btnNotify";
            this.btnNotify.Size = new System.Drawing.Size(51, 55);
            this.btnNotify.TabIndex = 0;
            this.btnNotify.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnNotify_MouseClick);
            // 
            // btnActive
            // 
            this.btnActive.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnActive.Desname = "活动";
            this.btnActive.Image = global::WinFrmTalk.Properties.Resources.ic_group_tab_a0;
            this.btnActive.Location = new System.Drawing.Point(0, 65);
            this.btnActive.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(51, 55);
            this.btnActive.TabIndex = 3;
            this.btnActive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnActive_MouseClick);
            // 
            // btnFiles
            // 
            this.btnFiles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFiles.Desname = "文件";
            this.btnFiles.Image = global::WinFrmTalk.Properties.Resources.ic_group_tab_f0;
            this.btnFiles.Location = new System.Drawing.Point(0, 130);
            this.btnFiles.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(51, 55);
            this.btnFiles.TabIndex = 4;
            this.btnFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnFiles_MouseClick);
            // 
            // btnVideo
            // 
            this.btnVideo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVideo.Desname = "视频";
            this.btnVideo.Image = global::WinFrmTalk.Properties.Resources.ic_group_tab_v0;
            this.btnVideo.Location = new System.Drawing.Point(0, 195);
            this.btnVideo.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(51, 55);
            this.btnVideo.TabIndex = 5;
            this.btnVideo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnVideo_MouseClick);
            // 
            // btnPhotos
            // 
            this.btnPhotos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPhotos.Desname = "相册";
            this.btnPhotos.Image = global::WinFrmTalk.Properties.Resources.ic_group_tab_p0;
            this.btnPhotos.Location = new System.Drawing.Point(0, 260);
            this.btnPhotos.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnPhotos.Name = "btnPhotos";
            this.btnPhotos.Size = new System.Drawing.Size(51, 55);
            this.btnPhotos.TabIndex = 6;
            this.btnPhotos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPhotos_MouseClick);
            // 
            // btnTopic
            // 
            this.btnTopic.BackColor = System.Drawing.Color.Transparent;
            this.btnTopic.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnTopic.ForeColor = System.Drawing.Color.White;
            this.btnTopic.Image = global::WinFrmTalk.Properties.Resources.ic_group_topicbg;
            this.btnTopic.Location = new System.Drawing.Point(2, 360);
            this.btnTopic.Margin = new System.Windows.Forms.Padding(1, 60, 3, 0);
            this.btnTopic.Name = "btnTopic";
            this.btnTopic.Size = new System.Drawing.Size(50, 24);
            this.btnTopic.TabIndex = 24;
            this.btnTopic.Text = "群话题";
            this.btnTopic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTopic.Click += new System.EventHandler(this.btnTopic_Click);
            // 
            // GroupIndicateLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.btnTopic);
            this.Name = "GroupIndicateLayout";
            this.Size = new System.Drawing.Size(52, 500);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label skinLine1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Items.GroupIndicateItem btnNotify;
        private Items.GroupIndicateItem btnActive;
        private Items.GroupIndicateItem btnFiles;
        private Items.GroupIndicateItem btnVideo;
        private Items.GroupIndicateItem btnPhotos;
        private System.Windows.Forms.Label btnTopic;
    }
}

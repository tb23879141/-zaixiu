namespace WinFrmTalk
{
    partial class LeftLayout
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRecent = new System.Windows.Forms.Panel();
            this.btnRecent = new WinFrmTalk.Controls.ImageViewx();
            this.panelContacts = new System.Windows.Forms.Panel();
            this.btnContacts = new WinFrmTalk.Controls.ImageViewx();
            this.panelGroup = new System.Windows.Forms.Panel();
            this.btnGroup = new System.Windows.Forms.PictureBox();
            this.panelColleague = new System.Windows.Forms.Panel();
            this.btnColleague = new System.Windows.Forms.PictureBox();
            this.panelCollect = new System.Windows.Forms.Panel();
            this.btnCollect = new System.Windows.Forms.PictureBox();
            this.panelTags = new System.Windows.Forms.Panel();
            this.btnTags = new System.Windows.Forms.PictureBox();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.btnSettings = new WinFrmTalk.Controls.ImageViewx();
            this.pic_myIcon = new WinFrmTalk.RoundPicBox();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.panelRecent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecent)).BeginInit();
            this.panelContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnContacts)).BeginInit();
            this.panelGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGroup)).BeginInit();
            this.panelColleague.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnColleague)).BeginInit();
            this.panelCollect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCollect)).BeginInit();
            this.panelTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTags)).BeginInit();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_myIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Controls.Add(this.panelRecent);
            this.flowLayoutPanel1.Controls.Add(this.panelContacts);
            this.flowLayoutPanel1.Controls.Add(this.panelGroup);
            this.flowLayoutPanel1.Controls.Add(this.panelColleague);
            this.flowLayoutPanel1.Controls.Add(this.panelCollect);
            this.flowLayoutPanel1.Controls.Add(this.panelTags);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 70);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(60, 510);
            this.flowLayoutPanel1.TabIndex = 14;
            this.flowLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanel1_MouseDown);
            // 
            // panelRecent
            // 
            this.panelRecent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelRecent.BackColor = System.Drawing.Color.Transparent;
            this.panelRecent.Controls.Add(this.btnRecent);
            this.panelRecent.Location = new System.Drawing.Point(0, 0);
            this.panelRecent.Margin = new System.Windows.Forms.Padding(0);
            this.panelRecent.Name = "panelRecent";
            this.panelRecent.Size = new System.Drawing.Size(60, 60);
            this.panelRecent.TabIndex = 17;
            // 
            // btnRecent
            // 
            this.btnRecent.BackColor = System.Drawing.Color.Transparent;
            this.btnRecent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecent.Image = global::WinFrmTalk.Properties.Resources.msg01;
            this.btnRecent.Location = new System.Drawing.Point(6, 6);
            this.btnRecent.Margin = new System.Windows.Forms.Padding(0);
            this.btnRecent.Name = "btnRecent";
            this.btnRecent.Padding = new System.Windows.Forms.Padding(10);
            this.btnRecent.Size = new System.Drawing.Size(48, 48);
            this.btnRecent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnRecent.TabIndex = 11;
            this.btnRecent.TabStop = false;
            this.btnRecent.UnreadCount = 0;
            this.btnRecent.UnreadMargin = 0;
            this.btnRecent.UnreadSize = 20;
            this.btnRecent.Click += new System.EventHandler(this.btnRecent_Click);
            this.btnRecent.DoubleClick += new System.EventHandler(this.OnDoubleClickRecent);
            this.btnRecent.MouseLeave += new System.EventHandler(this.btnRecent_MouseLeave);
            this.btnRecent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRecent_MouseMove);
            // 
            // panelContacts
            // 
            this.panelContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelContacts.BackColor = System.Drawing.Color.Transparent;
            this.panelContacts.Controls.Add(this.btnContacts);
            this.panelContacts.Location = new System.Drawing.Point(0, 60);
            this.panelContacts.Margin = new System.Windows.Forms.Padding(0);
            this.panelContacts.Name = "panelContacts";
            this.panelContacts.Size = new System.Drawing.Size(60, 60);
            this.panelContacts.TabIndex = 18;
            // 
            // btnContacts
            // 
            this.btnContacts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContacts.BackColor = System.Drawing.Color.Transparent;
            this.btnContacts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContacts.Image = global::WinFrmTalk.Properties.Resources.contact01;
            this.btnContacts.Location = new System.Drawing.Point(6, 6);
            this.btnContacts.Margin = new System.Windows.Forms.Padding(0);
            this.btnContacts.Name = "btnContacts";
            this.btnContacts.Padding = new System.Windows.Forms.Padding(10);
            this.btnContacts.Size = new System.Drawing.Size(48, 48);
            this.btnContacts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnContacts.TabIndex = 11;
            this.btnContacts.TabStop = false;
            this.btnContacts.UnreadCount = 0;
            this.btnContacts.UnreadMargin = 0;
            this.btnContacts.UnreadSize = 20;
            this.btnContacts.Click += new System.EventHandler(this.btnContacts_Click);
            this.btnContacts.MouseLeave += new System.EventHandler(this.btnContacts_MouseLeave);
            this.btnContacts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnContacts_MouseMove);
            // 
            // panelGroup
            // 
            this.panelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelGroup.BackColor = System.Drawing.Color.Transparent;
            this.panelGroup.Controls.Add(this.btnGroup);
            this.panelGroup.Location = new System.Drawing.Point(0, 120);
            this.panelGroup.Margin = new System.Windows.Forms.Padding(0);
            this.panelGroup.Name = "panelGroup";
            this.panelGroup.Size = new System.Drawing.Size(60, 60);
            this.panelGroup.TabIndex = 19;
            // 
            // btnGroup
            // 
            this.btnGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroup.BackColor = System.Drawing.Color.Transparent;
            this.btnGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGroup.Image = global::WinFrmTalk.Properties.Resources.group01;
            this.btnGroup.Location = new System.Drawing.Point(6, 6);
            this.btnGroup.Margin = new System.Windows.Forms.Padding(0);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Padding = new System.Windows.Forms.Padding(10);
            this.btnGroup.Size = new System.Drawing.Size(48, 48);
            this.btnGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnGroup.TabIndex = 11;
            this.btnGroup.TabStop = false;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            this.btnGroup.MouseLeave += new System.EventHandler(this.btnGroup_MouseLeave);
            this.btnGroup.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnGroup_MouseMove);
            // 
            // panelColleague
            // 
            this.panelColleague.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelColleague.BackColor = System.Drawing.Color.Transparent;
            this.panelColleague.Controls.Add(this.btnColleague);
            this.panelColleague.Location = new System.Drawing.Point(0, 180);
            this.panelColleague.Margin = new System.Windows.Forms.Padding(0);
            this.panelColleague.Name = "panelColleague";
            this.panelColleague.Size = new System.Drawing.Size(60, 60);
            this.panelColleague.TabIndex = 20;
            // 
            // btnColleague
            // 
            this.btnColleague.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColleague.BackColor = System.Drawing.Color.Transparent;
            this.btnColleague.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnColleague.Image = global::WinFrmTalk.Properties.Resources.company01;
            this.btnColleague.Location = new System.Drawing.Point(6, 6);
            this.btnColleague.Margin = new System.Windows.Forms.Padding(0);
            this.btnColleague.Name = "btnColleague";
            this.btnColleague.Padding = new System.Windows.Forms.Padding(10);
            this.btnColleague.Size = new System.Drawing.Size(48, 48);
            this.btnColleague.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnColleague.TabIndex = 12;
            this.btnColleague.TabStop = false;
            this.btnColleague.Click += new System.EventHandler(this.BtnCon_Click);
            this.btnColleague.MouseLeave += new System.EventHandler(this.btnColleague_MouseLeave);
            this.btnColleague.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnColleague_MouseMove);
            // 
            // panelCollect
            // 
            this.panelCollect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelCollect.BackColor = System.Drawing.Color.Transparent;
            this.panelCollect.Controls.Add(this.btnCollect);
            this.panelCollect.Location = new System.Drawing.Point(0, 240);
            this.panelCollect.Margin = new System.Windows.Forms.Padding(0);
            this.panelCollect.Name = "panelCollect";
            this.panelCollect.Size = new System.Drawing.Size(60, 60);
            this.panelCollect.TabIndex = 21;
            // 
            // btnCollect
            // 
            this.btnCollect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollect.BackColor = System.Drawing.Color.Transparent;
            this.btnCollect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCollect.Image = global::WinFrmTalk.Properties.Resources.collection01;
            this.btnCollect.Location = new System.Drawing.Point(6, 6);
            this.btnCollect.Margin = new System.Windows.Forms.Padding(0);
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Padding = new System.Windows.Forms.Padding(10);
            this.btnCollect.Size = new System.Drawing.Size(48, 48);
            this.btnCollect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnCollect.TabIndex = 13;
            this.btnCollect.TabStop = false;
            this.btnCollect.Click += new System.EventHandler(this.BtnCollect_Click);
            this.btnCollect.MouseLeave += new System.EventHandler(this.btnCollect_MouseLeave);
            this.btnCollect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCollect_MouseMove);
            // 
            // panelTags
            // 
            this.panelTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelTags.BackColor = System.Drawing.Color.Transparent;
            this.panelTags.Controls.Add(this.btnTags);
            this.panelTags.Location = new System.Drawing.Point(0, 300);
            this.panelTags.Margin = new System.Windows.Forms.Padding(0);
            this.panelTags.Name = "panelTags";
            this.panelTags.Size = new System.Drawing.Size(60, 60);
            this.panelTags.TabIndex = 22;
            // 
            // btnTags
            // 
            this.btnTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTags.BackColor = System.Drawing.Color.Transparent;
            this.btnTags.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTags.Image = global::WinFrmTalk.Properties.Resources.tap_groups011;
            this.btnTags.Location = new System.Drawing.Point(6, 6);
            this.btnTags.Margin = new System.Windows.Forms.Padding(0);
            this.btnTags.Name = "btnTags";
            this.btnTags.Padding = new System.Windows.Forms.Padding(10);
            this.btnTags.Size = new System.Drawing.Size(48, 48);
            this.btnTags.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnTags.TabIndex = 11;
            this.btnTags.TabStop = false;
            this.btnTags.Click += new System.EventHandler(this.BtnTags_Click);
            this.btnTags.MouseLeave += new System.EventHandler(this.btnTags_MouseLeave);
            this.btnTags.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnTags_MouseMove);
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSettings.Controls.Add(this.btnSettings);
            this.panelSettings.Location = new System.Drawing.Point(0, 600);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(60, 60);
            this.panelSettings.TabIndex = 16;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Image = global::WinFrmTalk.Properties.Resources.setting;
            this.btnSettings.Location = new System.Drawing.Point(16, 16);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(28, 28);
            this.btnSettings.TabIndex = 15;
            this.btnSettings.TabStop = false;
            this.btnSettings.UnreadCount = 0;
            this.btnSettings.UnreadMargin = 0;
            this.btnSettings.UnreadSize = 20;
            this.btnSettings.Click += new System.EventHandler(this.Settings_Click);
            this.btnSettings.MouseLeave += new System.EventHandler(this.btnSettings_MouseLeave);
            this.btnSettings.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSettings_MouseMove);
            // 
            // pic_myIcon
            // 
            this.pic_myIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_myIcon.isDrawRound = true;
            this.pic_myIcon.Location = new System.Drawing.Point(5, 10);
            this.pic_myIcon.Margin = new System.Windows.Forms.Padding(0);
            this.pic_myIcon.Name = "pic_myIcon";
            this.pic_myIcon.Size = new System.Drawing.Size(50, 50);
            this.pic_myIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_myIcon.TabIndex = 10;
            this.pic_myIcon.TabStop = false;
            this.pic_myIcon.Click += new System.EventHandler(this.pic_myIcon_Click);
            this.pic_myIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.pic_myIcon_Paint);
            // 
            // LeftLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(24)))), ((int)(((byte)(219)))));
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pic_myIcon);
            this.Controls.Add(this.panelSettings);
            this.Name = "LeftLayout";
            this.Size = new System.Drawing.Size(60, 660);
            this.Load += new System.EventHandler(this.LeftLayout_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelRecent.ResumeLayout(false);
            this.panelRecent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecent)).EndInit();
            this.panelContacts.ResumeLayout(false);
            this.panelContacts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnContacts)).EndInit();
            this.panelGroup.ResumeLayout(false);
            this.panelGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGroup)).EndInit();
            this.panelColleague.ResumeLayout(false);
            this.panelColleague.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnColleague)).EndInit();
            this.panelCollect.ResumeLayout(false);
            this.panelCollect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCollect)).EndInit();
            this.panelTags.ResumeLayout(false);
            this.panelTags.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTags)).EndInit();
            this.panelSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_myIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private RoundPicBox pic_myIcon;
        private System.Windows.Forms.PictureBox btnTags;
        private System.Windows.Forms.PictureBox btnCollect;
        private System.Windows.Forms.PictureBox btnColleague;
        private System.Windows.Forms.PictureBox btnGroup;
        private WinFrmTalk.Controls.ImageViewx btnRecent;
        private WinFrmTalk.Controls.ImageViewx btnContacts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Controls.ImageViewx btnSettings;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Panel panelRecent;
        private System.Windows.Forms.Panel panelContacts;
        private System.Windows.Forms.Panel panelGroup;
        private System.Windows.Forms.Panel panelColleague;
        private System.Windows.Forms.Panel panelCollect;
        private System.Windows.Forms.Panel panelTags;
        private System.Windows.Forms.ToolTip toolTips;
    }
}

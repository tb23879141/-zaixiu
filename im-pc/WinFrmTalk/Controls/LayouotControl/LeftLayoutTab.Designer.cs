namespace WinFrmTalk
{
    partial class LeftLayoutTab
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
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnRecent = new WinFrmTalk.Controls.CustomControls.LeftlayoutItem();
            this.btnContact = new WinFrmTalk.Controls.CustomControls.LeftlayoutItem();
            this.btnGroup = new WinFrmTalk.Controls.CustomControls.LeftlayoutItem();
            this.btnSquare = new WinFrmTalk.Controls.CustomControls.LeftlayoutItem();
            this.btnFiles = new WinFrmTalk.Controls.CustomControls.LeftlayoutItem();
            this.btnLabels = new WinFrmTalk.Controls.CustomControls.LeftlayoutItem();
            this.pic_myIcon = new WinFrmTalk.RoundPicBox();
            this.btnSetting = new WinFrmTalk.Controls.CustomControls.LeftlayoutItem();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_myIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnRecent);
            this.flowLayoutPanel1.Controls.Add(this.btnContact);
            this.flowLayoutPanel1.Controls.Add(this.btnGroup);
            this.flowLayoutPanel1.Controls.Add(this.btnSquare);
            this.flowLayoutPanel1.Controls.Add(this.btnFiles);
            this.flowLayoutPanel1.Controls.Add(this.btnLabels);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 99);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(100, 450);
            this.flowLayoutPanel1.TabIndex = 14;
            this.flowLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanel1_MouseDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.label1.Location = new System.Drawing.Point(99, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 660);
            this.label1.TabIndex = 30;
            // 
            // btnRecent
            // 
            this.btnRecent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecent.Desname = "消息";
            this.btnRecent.Image = global::WinFrmTalk.Properties.Resources.ic_nav_tab00;
            this.btnRecent.MouseImage = global::WinFrmTalk.Properties.Resources.ic_nav_tab02;
            this.btnRecent.Location = new System.Drawing.Point(0, 0);
            this.btnRecent.Margin = new System.Windows.Forms.Padding(0);
            this.btnRecent.Name = "btnRecent";
            this.btnRecent.Size = new System.Drawing.Size(100, 60);
            this.btnRecent.TabIndex = 23;
            this.btnRecent.DoubleClick += new System.EventHandler(this.btnRecent_DoubleClick);
            this.btnRecent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnRecent_MouseClick);
            // 
            // btnContact
            // 
            this.btnContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnContact.Desname = "通讯录";
            this.btnContact.Image = global::WinFrmTalk.Properties.Resources.ic_nav_tab10;
            this.btnContact.MouseImage = global::WinFrmTalk.Properties.Resources.ic_nav_tab12;
            this.btnContact.Location = new System.Drawing.Point(0, 60);
            this.btnContact.Margin = new System.Windows.Forms.Padding(0);
            this.btnContact.Name = "btnContact";
            this.btnContact.Size = new System.Drawing.Size(100, 60);
            this.btnContact.TabIndex = 24;
            this.btnContact.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnContact_MouseClick);
            // 
            // btnGroup
            // 
            this.btnGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGroup.Desname = "群组";
            this.btnGroup.Image = global::WinFrmTalk.Properties.Resources.ic_nav_tab20;
            this.btnGroup.MouseImage = global::WinFrmTalk.Properties.Resources.ic_nav_tab22;
            this.btnGroup.Location = new System.Drawing.Point(0, 120);
            this.btnGroup.Margin = new System.Windows.Forms.Padding(0);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(100, 60);
            this.btnGroup.TabIndex = 25;
            this.btnGroup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnGroup_MouseClick);
            // 
            // btnSquare
            // 
            this.btnSquare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSquare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSquare.Desname = "群广场";
            this.btnSquare.Image = global::WinFrmTalk.Properties.Resources.ic_nav_tab30;
            this.btnSquare.MouseImage = global::WinFrmTalk.Properties.Resources.ic_nav_tab32;
            this.btnSquare.Location = new System.Drawing.Point(0, 180);
            this.btnSquare.Margin = new System.Windows.Forms.Padding(0);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(100, 60);
            this.btnSquare.TabIndex = 26;
            this.btnSquare.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSquare_MouseClick);
            // 
            // btnFiles
            // 
            this.btnFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFiles.Desname = "保存";
            this.btnFiles.Image = global::WinFrmTalk.Properties.Resources.ic_nav_tab40;
            this.btnFiles.MouseImage = global::WinFrmTalk.Properties.Resources.ic_nav_tab42;
            this.btnFiles.Location = new System.Drawing.Point(0, 240);
            this.btnFiles.Margin = new System.Windows.Forms.Padding(0);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(100, 60);
            this.btnFiles.TabIndex = 27;
            this.btnFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnFiles_MouseClick);
            // 
            // btnLabels
            // 
            this.btnLabels.AccessibleDescription = "";
            this.btnLabels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLabels.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLabels.Desname = "标签";
            this.btnLabels.Image = global::WinFrmTalk.Properties.Resources.ic_nav_tab50;
            this.btnLabels.MouseImage = global::WinFrmTalk.Properties.Resources.ic_nav_tab52;
            this.btnLabels.Location = new System.Drawing.Point(0, 300);
            this.btnLabels.Margin = new System.Windows.Forms.Padding(0);
            this.btnLabels.Name = "btnLabels";
            this.btnLabels.Size = new System.Drawing.Size(100, 60);
            this.btnLabels.TabIndex = 28;
            this.btnLabels.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnLabels_MouseClick);
            // 
            // pic_myIcon
            // 
            this.pic_myIcon.BackColor = System.Drawing.Color.Transparent;
            this.pic_myIcon.isDrawRound = true;
            this.pic_myIcon.Location = new System.Drawing.Point(20, 20);
            this.pic_myIcon.Margin = new System.Windows.Forms.Padding(0);
            this.pic_myIcon.Name = "pic_myIcon";
            this.pic_myIcon.Size = new System.Drawing.Size(60, 60);
            this.pic_myIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_myIcon.TabIndex = 10;
            this.pic_myIcon.TabStop = false;
            this.pic_myIcon.Click += new System.EventHandler(this.pic_myIcon_Click);
            this.pic_myIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.pic_myIcon_Paint);
            // 
            // btnSetting
            // 
            this.btnSetting.AccessibleDescription = "";
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.Desname = "设置";
            this.btnSetting.Image = global::WinFrmTalk.Properties.Resources.mainSet;
            this.btnSetting.MouseImage = global::WinFrmTalk.Properties.Resources.mainSet2;
            this.btnSetting.Location = new System.Drawing.Point(0, 550);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(100, 60);
            this.btnSetting.TabIndex = 29;
            this.btnSetting.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSettings_MouseClick);
            // 
            // LeftLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pic_myIcon);
            this.Controls.Add(this.btnSetting);
            this.Name = "LeftLayout";
            this.Size = new System.Drawing.Size(100, 610);
            this.Load += new System.EventHandler(this.LeftLayout_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_myIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private RoundPicBox pic_myIcon;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolTip toolTips;
        private Controls.CustomControls.LeftlayoutItem btnRecent;
        private Controls.CustomControls.LeftlayoutItem btnContact;
        private Controls.CustomControls.LeftlayoutItem btnGroup;
        private Controls.CustomControls.LeftlayoutItem btnSquare;
        private Controls.CustomControls.LeftlayoutItem btnFiles;
        private Controls.CustomControls.LeftlayoutItem btnLabels;
        private Controls.CustomControls.LeftlayoutItem btnSetting;
        private System.Windows.Forms.Label label1;
    }
}

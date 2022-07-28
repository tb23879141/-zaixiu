namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    partial class GroupPageMain
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
            this.bottomLayout = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenu = new CCWin.SkinControl.SkinContextMenuStrip();
            this.menuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.separator_one = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.separator_two = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_Forward = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Collect = new System.Windows.Forms.ToolStripMenuItem();
            this.separator_four = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.dataLayout = new System.Windows.Forms.Panel();
            this.bottomLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomLayout
            // 
            this.bottomLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomLayout.BackColor = System.Drawing.Color.White;
            this.bottomLayout.Controls.Add(this.pictureBox2);
            this.bottomLayout.Controls.Add(this.pictureBox1);
            this.bottomLayout.Controls.Add(this.label1);
            this.bottomLayout.Location = new System.Drawing.Point(0, 640);
            this.bottomLayout.Name = "bottomLayout";
            this.bottomLayout.Size = new System.Drawing.Size(670, 160);
            this.bottomLayout.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WinFrmTalk.Properties.Resources.ic_group_news2;
            this.pictureBox2.Location = new System.Drawing.Point(418, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(72, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinFrmTalk.Properties.Resources.ic_group_news1;
            this.pictureBox1.Location = new System.Drawing.Point(176, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(266, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "最新消息";
            // 
            // contextMenu
            // 
            this.contextMenu.Arrow = System.Drawing.Color.Black;
            this.contextMenu.Back = System.Drawing.Color.White;
            this.contextMenu.BackRadius = 1;
            this.contextMenu.Base = System.Drawing.Color.White;
            this.contextMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.contextMenu.DropShadowEnabled = false;
            this.contextMenu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contextMenu.Fore = System.Drawing.Color.Black;
            this.contextMenu.HoverFore = System.Drawing.Color.Black;
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.ItemAnamorphosis = false;
            this.contextMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.contextMenu.ItemBorderShow = false;
            this.contextMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.contextMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.contextMenu.ItemRadius = 1;
            this.contextMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Open,
            this.separator_one,
            this.menuItem_Copy,
            this.separator_two,
            this.menuItem_Forward,
            this.menuItem_Collect,
            this.separator_four,
            this.menuItem_SaveAs});
            this.contextMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.contextMenu.Name = "contentMenuStrip";
            this.contextMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenu.Size = new System.Drawing.Size(122, 132);
            this.contextMenu.SkinAllColor = true;
            this.contextMenu.TitleAnamorphosis = false;
            this.contextMenu.TitleColor = System.Drawing.Color.White;
            this.contextMenu.TitleRadius = 4;
            this.contextMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // menuItem_Open
            // 
            this.menuItem_Open.Name = "menuItem_Open";
            this.menuItem_Open.Size = new System.Drawing.Size(121, 22);
            this.menuItem_Open.Text = "打开";
            this.menuItem_Open.Click += new System.EventHandler(this.menuItem_Open_Click);
            // 
            // separator_one
            // 
            this.separator_one.Name = "separator_one";
            this.separator_one.Size = new System.Drawing.Size(118, 6);
            // 
            // menuItem_Copy
            // 
            this.menuItem_Copy.Name = "menuItem_Copy";
            this.menuItem_Copy.Size = new System.Drawing.Size(121, 22);
            this.menuItem_Copy.Text = "复制";
            this.menuItem_Copy.Click += new System.EventHandler(this.menuItem_Copy_Click);
            // 
            // separator_two
            // 
            this.separator_two.Name = "separator_two";
            this.separator_two.Size = new System.Drawing.Size(118, 6);
            // 
            // menuItem_Forward
            // 
            this.menuItem_Forward.Name = "menuItem_Forward";
            this.menuItem_Forward.Size = new System.Drawing.Size(121, 22);
            this.menuItem_Forward.Text = "转发";
            this.menuItem_Forward.Click += new System.EventHandler(this.menuItem_Forward_Click);
            // 
            // menuItem_Collect
            // 
            this.menuItem_Collect.Name = "menuItem_Collect";
            this.menuItem_Collect.Size = new System.Drawing.Size(121, 22);
            this.menuItem_Collect.Text = "保存";
            this.menuItem_Collect.Click += new System.EventHandler(this.menuItem_Collect_Click);
            // 
            // separator_four
            // 
            this.separator_four.Name = "separator_four";
            this.separator_four.Size = new System.Drawing.Size(118, 6);
            // 
            // menuItem_SaveAs
            // 
            this.menuItem_SaveAs.Name = "menuItem_SaveAs";
            this.menuItem_SaveAs.Size = new System.Drawing.Size(121, 22);
            this.menuItem_SaveAs.Text = "另存为...";
            this.menuItem_SaveAs.Click += new System.EventHandler(this.menuItem_SaveAs_Click);
            // 
            // dataLayout
            // 
            this.dataLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLayout.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataLayout.Location = new System.Drawing.Point(0, 0);
            this.dataLayout.Name = "dataLayout";
            this.dataLayout.Size = new System.Drawing.Size(670, 640);
            this.dataLayout.TabIndex = 1;
            this.dataLayout.SizeChanged += new System.EventHandler(this.dataLayout_SizeChanged);
            // 
            // GroupPageMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.dataLayout);
            this.Controls.Add(this.bottomLayout);
            this.Name = "GroupPageMain";
            this.Size = new System.Drawing.Size(670, 800);
            this.bottomLayout.ResumeLayout(false);
            this.bottomLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private CCWin.SkinControl.SkinContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Open;
        private System.Windows.Forms.ToolStripSeparator separator_one;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Copy;
        private System.Windows.Forms.ToolStripSeparator separator_two;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Forward;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Collect;
        private System.Windows.Forms.ToolStripSeparator separator_four;
        private System.Windows.Forms.ToolStripMenuItem menuItem_SaveAs;
        private System.Windows.Forms.Panel dataLayout;
    }
}
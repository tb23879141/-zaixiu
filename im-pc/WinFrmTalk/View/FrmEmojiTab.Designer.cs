namespace WinFrmTalk.View
{
    partial class FrmEmojiTab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmojiTab));
            this.tabPanel = new System.Windows.Forms.Panel();
            this.btnInit = new BaseControls.ButtonEx();
            this.tlblCustom = new System.Windows.Forms.Label();
            this.tlblGif = new System.Windows.Forms.Label();
            this.tlblEmoji = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.layoutPanel = new System.Windows.Forms.Panel();
            this.vScrollBar = new TestListView.XScrollBar();
            this.cmsCustomizeMenu = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tsmiDeleted = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPanel.SuspendLayout();
            this.cmsCustomizeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPanel
            // 
            this.tabPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tabPanel.Controls.Add(this.btnInit);
            this.tabPanel.Controls.Add(this.tlblCustom);
            this.tabPanel.Controls.Add(this.tlblGif);
            this.tabPanel.Controls.Add(this.tlblEmoji);
            this.tabPanel.Location = new System.Drawing.Point(0, 260);
            this.tabPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.Size = new System.Drawing.Size(460, 36);
            this.tabPanel.TabIndex = 6;
            // 
            // btnInit
            // 
            this.btnInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInit.EnterColor = System.Drawing.Color.LightGray;
            this.btnInit.FillColor = System.Drawing.Color.Silver;
            this.btnInit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnInit.FrameColor = System.Drawing.Color.Silver;
            this.btnInit.Location = new System.Drawing.Point(378, 8);
            this.btnInit.Name = "btnInit";
            this.btnInit.Raduis = 6;
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 12;
            this.btnInit.Text = "初始化表情";
            this.btnInit.Visible = false;
            this.btnInit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnInit_MouseClick);
            // 
            // tlblCustom
            // 
            this.tlblCustom.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlblCustom.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tlblCustom.Location = new System.Drawing.Point(150, 0);
            this.tlblCustom.Name = "tlblCustom";
            this.tlblCustom.Size = new System.Drawing.Size(75, 36);
            this.tlblCustom.TabIndex = 11;
            this.tlblCustom.Tag = "3";
            this.tlblCustom.Text = "自定义表情";
            this.tlblCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tlblCustom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseClick);
            this.tlblCustom.MouseEnter += new System.EventHandler(this.Tab_MouseEnter);
            this.tlblCustom.MouseLeave += new System.EventHandler(this.Tab_MouseLeave);
            // 
            // tlblGif
            // 
            this.tlblGif.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlblGif.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tlblGif.Location = new System.Drawing.Point(75, 0);
            this.tlblGif.Name = "tlblGif";
            this.tlblGif.Size = new System.Drawing.Size(75, 36);
            this.tlblGif.TabIndex = 10;
            this.tlblGif.Tag = "2";
            this.tlblGif.Text = "动画表情";
            this.tlblGif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tlblGif.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseClick);
            this.tlblGif.MouseEnter += new System.EventHandler(this.Tab_MouseEnter);
            this.tlblGif.MouseLeave += new System.EventHandler(this.Tab_MouseLeave);
            // 
            // tlblEmoji
            // 
            this.tlblEmoji.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlblEmoji.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tlblEmoji.Location = new System.Drawing.Point(0, 0);
            this.tlblEmoji.Name = "tlblEmoji";
            this.tlblEmoji.Size = new System.Drawing.Size(75, 36);
            this.tlblEmoji.TabIndex = 9;
            this.tlblEmoji.Tag = "1";
            this.tlblEmoji.Text = "表情";
            this.tlblEmoji.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tlblEmoji.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseClick);
            this.tlblEmoji.MouseEnter += new System.EventHandler(this.Tab_MouseEnter);
            this.tlblEmoji.MouseLeave += new System.EventHandler(this.Tab_MouseLeave);
            // 
            // layoutPanel
            // 
            this.layoutPanel.BackColor = System.Drawing.Color.White;
            this.layoutPanel.Location = new System.Drawing.Point(14, 32);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Size = new System.Drawing.Size(433, 214);
            this.layoutPanel.TabIndex = 9;
            // 
            // vScrollBar
            // 
            this.vScrollBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vScrollBar.BackgroundImage")));
            this.vScrollBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vScrollBar.Location = new System.Drawing.Point(448, 32);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(10, 215);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.ScrollChangeListener += new TestListView.XScrollBar.EventProgressHandler(this.ScrollChangeListener);
            // 
            // cmsCustomizeMenu
            // 
            this.cmsCustomizeMenu.Arrow = System.Drawing.Color.Black;
            this.cmsCustomizeMenu.Back = System.Drawing.Color.White;
            this.cmsCustomizeMenu.BackRadius = 4;
            this.cmsCustomizeMenu.Base = System.Drawing.Color.White;
            this.cmsCustomizeMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsCustomizeMenu.Fore = System.Drawing.Color.Black;
            this.cmsCustomizeMenu.HoverFore = System.Drawing.Color.Black;
            this.cmsCustomizeMenu.ItemAnamorphosis = false;
            this.cmsCustomizeMenu.ItemBorder = System.Drawing.Color.White;
            this.cmsCustomizeMenu.ItemBorderShow = false;
            this.cmsCustomizeMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.cmsCustomizeMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.cmsCustomizeMenu.ItemRadius = 4;
            this.cmsCustomizeMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.cmsCustomizeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDeleted});
            this.cmsCustomizeMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.cmsCustomizeMenu.Name = "cmsCustomizeMenu";
            this.cmsCustomizeMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.cmsCustomizeMenu.Size = new System.Drawing.Size(101, 26);
            this.cmsCustomizeMenu.SkinAllColor = true;
            this.cmsCustomizeMenu.TitleAnamorphosis = false;
            this.cmsCustomizeMenu.TitleColor = System.Drawing.Color.White;
            this.cmsCustomizeMenu.TitleRadius = 4;
            this.cmsCustomizeMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tsmiDeleted
            // 
            this.tsmiDeleted.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tsmiDeleted.Name = "tsmiDeleted";
            this.tsmiDeleted.Size = new System.Drawing.Size(100, 22);
            this.tsmiDeleted.Text = "删除";
            this.tsmiDeleted.Click += new System.EventHandler(this.menuItem_deleted_Click);
            // 
            // FrmEmojiTab
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(460, 296);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.layoutPanel);
            this.Controls.Add(this.tabPanel);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Mobile = CCWin.MobileStyle.None;
            this.Name = "FrmEmojiTab";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "符号表情";
            this.TitleNeed = false;
            this.TopMost = true;
            this.tabPanel.ResumeLayout(false);
            this.cmsCustomizeMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tabPanel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label tlblEmoji;
        private System.Windows.Forms.Label tlblGif;
        private System.Windows.Forms.Label tlblCustom;
        private System.Windows.Forms.Panel layoutPanel;
        private TestListView.XScrollBar vScrollBar;
        private CCWin.SkinControl.SkinContextMenuStrip cmsCustomizeMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleted;
        private BaseControls.ButtonEx btnInit;
    }
}

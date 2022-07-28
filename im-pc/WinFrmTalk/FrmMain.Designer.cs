namespace WinFrmTalk
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.leftlayout = new WinFrmTalk.LeftLayout();
            this.NotifyControl = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayMenu = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tsbManin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbCloseFlicker = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbClosevoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPageLayout = new WinFrmTalk.Controls.LayouotControl.MainPageLayout();
            this.plList = new System.Windows.Forms.Panel();
            this.mFriendLabelLayout = new WinFrmTalk.FriendLabelLayout();
            this.mCollectionLayout = new WinFrmTalk.CollectionListLayout();
            this.recentListLayout = new WinFrmTalk.RecentListLayout();
            this.groupListLayout = new WinFrmTalk.GroupListLayout();
            this.groupSquareLayout = new WinFrmTalk.GroupListLayoutSquare();
            this.friendListLayout = new WinFrmTalk.FriendListLayout();
            this.listLayoutTitleBar1 = new WinFrmTalk.Controls.CustomControls.ListLayoutTitleBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsTrayMenu.SuspendLayout();
            this.plList.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftlayout
            // 
            this.leftlayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftlayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(24)))), ((int)(((byte)(219)))));
            this.leftlayout.Cursor = System.Windows.Forms.Cursors.Default;
            this.leftlayout.Location = new System.Drawing.Point(0, 50);
            this.leftlayout.MainForm = null;
            this.leftlayout.Margin = new System.Windows.Forms.Padding(0);
            this.leftlayout.Name = "leftlayout";
            this.leftlayout.SelectIndex = WinFrmTalk.MainTabIndex.RecentListPage_null;
            this.leftlayout.Size = new System.Drawing.Size(60, 610);
            this.leftlayout.TabIndex = 14;
            this.leftlayout.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Leftlayout_MouseDoubleClick);
            // 
            // NotifyControl
            // 
            this.NotifyControl.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NotifyControl.BalloonTipText = "IM";
            this.NotifyControl.BalloonTipTitle = "IM";
            this.NotifyControl.ContextMenuStrip = this.cmsTrayMenu;
            this.NotifyControl.Text = "在秀";
            this.NotifyControl.Visible = true;
            this.NotifyControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyControl_MouseDoubleClick);
            // 
            // cmsTrayMenu
            // 
            this.cmsTrayMenu.Arrow = System.Drawing.Color.Black;
            this.cmsTrayMenu.Back = System.Drawing.Color.White;
            this.cmsTrayMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsTrayMenu.BackRadius = 4;
            this.cmsTrayMenu.Base = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsTrayMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsTrayMenu.Fore = System.Drawing.Color.Black;
            this.cmsTrayMenu.HoverFore = System.Drawing.Color.Black;
            this.cmsTrayMenu.ItemAnamorphosis = false;
            this.cmsTrayMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsTrayMenu.ItemBorderShow = false;
            this.cmsTrayMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsTrayMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsTrayMenu.ItemRadius = 4;
            this.cmsTrayMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbManin,
            this.tsbCloseFlicker,
            this.tsbClosevoice,
            this.tsbSet,
            this.tsbExit});
            this.cmsTrayMenu.ItemSplitter = System.Drawing.Color.Silver;
            this.cmsTrayMenu.Name = "contextMenuStrip1";
            this.cmsTrayMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsTrayMenu.Size = new System.Drawing.Size(137, 114);
            this.cmsTrayMenu.SkinAllColor = true;
            this.cmsTrayMenu.Tag = "";
            this.cmsTrayMenu.TitleAnamorphosis = true;
            this.cmsTrayMenu.TitleColor = System.Drawing.Color.White;
            this.cmsTrayMenu.TitleRadius = 4;
            this.cmsTrayMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // tsbManin
            // 
            this.tsbManin.Name = "tsbManin";
            this.tsbManin.Size = new System.Drawing.Size(136, 22);
            this.tsbManin.Text = "显示主界面";
            this.tsbManin.Click += new System.EventHandler(this.tsbManin_Click);
            // 
            // tsbCloseFlicker
            // 
            this.tsbCloseFlicker.Name = "tsbCloseFlicker";
            this.tsbCloseFlicker.Size = new System.Drawing.Size(136, 22);
            this.tsbCloseFlicker.Text = "关闭闪动";
            this.tsbCloseFlicker.Click += new System.EventHandler(this.tsbCloseFlicker_Click);
            // 
            // tsbClosevoice
            // 
            this.tsbClosevoice.Name = "tsbClosevoice";
            this.tsbClosevoice.Size = new System.Drawing.Size(136, 22);
            this.tsbClosevoice.Text = "关闭声音";
            this.tsbClosevoice.Click += new System.EventHandler(this.tsbClosevoice_Click);
            // 
            // tsbSet
            // 
            this.tsbSet.Name = "tsbSet";
            this.tsbSet.Size = new System.Drawing.Size(136, 22);
            this.tsbSet.Text = "设置";
            this.tsbSet.Click += new System.EventHandler(this.tsbSet_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(136, 22);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // mainPageLayout
            // 
            this.mainPageLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPageLayout.AutoSize = true;
            this.mainPageLayout.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPageLayout.Location = new System.Drawing.Point(336, 1);
            this.mainPageLayout.MainForm = null;
            this.mainPageLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainPageLayout.Name = "mainPageLayout";
            this.mainPageLayout.SelectedIndex = WinFrmTalk.MainTabIndex.RecentListPage_null;
            this.mainPageLayout.Size = new System.Drawing.Size(721, 658);
            this.mainPageLayout.TabIndex = 56;
            // 
            // plList
            // 
            this.plList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.plList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.plList.Controls.Add(this.mFriendLabelLayout);
            this.plList.Controls.Add(this.mCollectionLayout);
            this.plList.Controls.Add(this.recentListLayout);
            this.plList.Controls.Add(this.groupListLayout);
            this.plList.Controls.Add(this.groupSquareLayout);
            this.plList.Controls.Add(this.friendListLayout);
            this.plList.Location = new System.Drawing.Point(60, 50);
            this.plList.Margin = new System.Windows.Forms.Padding(0);
            this.plList.Name = "plList";
            this.plList.Size = new System.Drawing.Size(275, 610);
            this.plList.TabIndex = 55;
            this.plList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
            // 
            // mFriendLabelLayout
            // 
            this.mFriendLabelLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mFriendLabelLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.mFriendLabelLayout.Location = new System.Drawing.Point(0, 0);
            this.mFriendLabelLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mFriendLabelLayout.Name = "mFriendLabelLayout";
            this.mFriendLabelLayout.Size = new System.Drawing.Size(275, 610);
            this.mFriendLabelLayout.TabIndex = 19;
            // 
            // mCollectionLayout
            // 
            this.mCollectionLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mCollectionLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.mCollectionLayout.Location = new System.Drawing.Point(0, 0);
            this.mCollectionLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mCollectionLayout.Name = "mCollectionLayout";
            this.mCollectionLayout.Size = new System.Drawing.Size(275, 610);
            this.mCollectionLayout.TabIndex = 18;
            // 
            // recentListLayout
            // 
            this.recentListLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.recentListLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.recentListLayout.Location = new System.Drawing.Point(0, 0);
            this.recentListLayout.MainForm = null;
            this.recentListLayout.Margin = new System.Windows.Forms.Padding(0);
            this.recentListLayout.Name = "recentListLayout";
            this.recentListLayout.Size = new System.Drawing.Size(275, 610);
            this.recentListLayout.TabIndex = 17;
            this.recentListLayout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
            // 
            // groupListLayout
            // 
            this.groupListLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupListLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.groupListLayout.Location = new System.Drawing.Point(0, 0);
            this.groupListLayout.MainForm = null;
            this.groupListLayout.Margin = new System.Windows.Forms.Padding(0);
            this.groupListLayout.Name = "groupListLayout";
            this.groupListLayout.SelectedItem = null;
            this.groupListLayout.Size = new System.Drawing.Size(275, 610);
            this.groupListLayout.TabIndex = 16;
            this.groupListLayout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
            // 
            // groupSquareLayout
            // 
            this.groupSquareLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupSquareLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.groupSquareLayout.Location = new System.Drawing.Point(0, 0);
            this.groupSquareLayout.MainForm = null;
            this.groupSquareLayout.Margin = new System.Windows.Forms.Padding(0);
            this.groupSquareLayout.Name = "groupSquareLayout";
            this.groupSquareLayout.SelectedItem = null;
            this.groupSquareLayout.Size = new System.Drawing.Size(275, 610);
            this.groupSquareLayout.TabIndex = 16;
            this.groupSquareLayout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
            // 
            // friendListLayout
            // 
            this.friendListLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.friendListLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.friendListLayout.Location = new System.Drawing.Point(0, 0);
            this.friendListLayout.MainForm = null;
            this.friendListLayout.Margin = new System.Windows.Forms.Padding(0);
            this.friendListLayout.Name = "friendListLayout";
            this.friendListLayout.SelectedItem = null;
            this.friendListLayout.Size = new System.Drawing.Size(275, 610);
            this.friendListLayout.TabIndex = 15;
            this.friendListLayout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
            // 
            // listLayoutTitleBar1
            // 
            this.listLayoutTitleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.listLayoutTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.listLayoutTitleBar1.Name = "listLayoutTitleBar1";
            this.listLayoutTitleBar1.Size = new System.Drawing.Size(335, 50);
            this.listLayoutTitleBar1.TabIndex = 100;
            this.listLayoutTitleBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(335, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 660);
            this.label1.TabIndex = 105;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionHeight = 36;
            this.ClientSize = new System.Drawing.Size(1060, 660);
            this.CloseBoxSize = new System.Drawing.Size(34, 24);
            this.ControlBoxOffset = new System.Drawing.Point(0, 0);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listLayoutTitleBar1);
            this.Controls.Add(this.leftlayout);
            this.Controls.Add(this.plList);
            this.Controls.Add(this.mainPageLayout);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.isClose = false;
            this.KeyPreview = true;
            this.MaxSize = new System.Drawing.Size(34, 24);
            this.MdiBackColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.MiniSize = new System.Drawing.Size(34, 24);
            this.Name = "FrmMain";
            this.ShadowColor = System.Drawing.Color.DimGray;
            this.ShadowWidth = 5;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在秀";
            this.TitleNeed = false;
            this.Activated += new System.EventHandler(this.FrmMain_Activated);
            this.Deactivate += new System.EventHandler(this.FrmMain_Deactivate);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.DoubleClick += new System.EventHandler(this.FrmMain_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmMain_KeyPress);
            this.Leave += new System.EventHandler(this.FrmMain_Leave);
            this.cmsTrayMenu.ResumeLayout(false);
            this.plList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LeftLayout leftlayout;
        private System.Windows.Forms.NotifyIcon NotifyControl;
        private CCWin.SkinControl.SkinContextMenuStrip cmsTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem tsbManin;
        private System.Windows.Forms.ToolStripMenuItem tsbCloseFlicker;
        private System.Windows.Forms.ToolStripMenuItem tsbClosevoice;
        private System.Windows.Forms.ToolStripMenuItem tsbSet;
        private System.Windows.Forms.ToolStripMenuItem tsbExit;
        public Controls.LayouotControl.MainPageLayout mainPageLayout;
        private System.Windows.Forms.Panel plList;
        private RecentListLayout recentListLayout;
        private FriendListLayout friendListLayout;
        private GroupListLayout groupListLayout;
        private GroupListLayoutSquare groupSquareLayout;
        private CollectionListLayout mCollectionLayout;
        private FriendLabelLayout mFriendLabelLayout;
        private Controls.CustomControls.ListLayoutTitleBar listLayoutTitleBar1;
        private System.Windows.Forms.Label label1;
  
    }
}
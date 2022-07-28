using WinFrmTalk.Controls.CustomControls;

namespace WinFrmTalk
{
    partial class CollectionListLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectionListLayout));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.skLine = new System.Windows.Forms.Label();
            this.tabLayoutPanel1 = new WinFrmTalk.Controls.TabLayoutPanel();
            this.limitPanel = new System.Windows.Forms.Panel();
            this.skinContextMenuStrip1 = new CCWin.SkinControl.SkinContextMenuStrip();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.vScrollBar = new TestListView.XScrollBar();
            this.contextMenu = new CCWin.SkinControl.SkinContextMenuStrip();
            this.menuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.separator_one = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.separator_two = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_Forward = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.separator_three = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_Emoji = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Moveto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Floder = new System.Windows.Forms.ToolStripMenuItem();
            this.separator_four = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_del = new System.Windows.Forms.ToolStripMenuItem();
            this.folderMenu = new CCWin.SkinControl.SkinContextMenuStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMoveto = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFolderDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.collectionToolbar1 = new WinFrmTalk.Controls.LayouotControl.Groups.CollectionToolbar();
            this.limitPanel.SuspendLayout();
            this.skinContextMenuStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.folderMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // skLine
            // 
            this.skLine.BackColor = System.Drawing.Color.Gainsboro;
            this.skLine.Location = new System.Drawing.Point(0, 55);
            this.skLine.Name = "skLine";
            this.skLine.Size = new System.Drawing.Size(275, 1);
            this.skLine.TabIndex = 30;
            // 
            // tabLayoutPanel1
            // 
            this.tabLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tabLayoutPanel1.DelimitLineHeight = 38;
            this.tabLayoutPanel1.ItemMaginLeft = -1;
            this.tabLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tabLayoutPanel1.Name = "tabLayoutPanel1";
            this.tabLayoutPanel1.Size = new System.Drawing.Size(275, 55);
            this.tabLayoutPanel1.TabIndex = 29;
            // 
            // limitPanel
            // 
            this.limitPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.limitPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.limitPanel.ContextMenuStrip = this.skinContextMenuStrip1;
            this.limitPanel.Controls.Add(this.flowLayoutPanel1);
            this.limitPanel.Location = new System.Drawing.Point(0, 56);
            this.limitPanel.Name = "limitPanel";
            this.limitPanel.Size = new System.Drawing.Size(265, 554);
            this.limitPanel.TabIndex = 32;
            // 
            // skinContextMenuStrip1
            // 
            this.skinContextMenuStrip1.Arrow = System.Drawing.Color.Black;
            this.skinContextMenuStrip1.Back = System.Drawing.Color.White;
            this.skinContextMenuStrip1.BackRadius = 1;
            this.skinContextMenuStrip1.Base = System.Drawing.Color.White;
            this.skinContextMenuStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip1.DropShadowEnabled = false;
            this.skinContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.skinContextMenuStrip1.Fore = System.Drawing.Color.Black;
            this.skinContextMenuStrip1.HoverFore = System.Drawing.Color.Black;
            this.skinContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinContextMenuStrip1.ItemAnamorphosis = false;
            this.skinContextMenuStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.skinContextMenuStrip1.ItemBorderShow = false;
            this.skinContextMenuStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.skinContextMenuStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.skinContextMenuStrip1.ItemRadius = 1;
            this.skinContextMenuStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.skinContextMenuStrip1.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.skinContextMenuStrip1.Name = "contentMenuStrip";
            this.skinContextMenuStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            this.skinContextMenuStrip1.SkinAllColor = true;
            this.skinContextMenuStrip1.TitleAnamorphosis = false;
            this.skinContextMenuStrip1.TitleColor = System.Drawing.Color.White;
            this.skinContextMenuStrip1.TitleRadius = 4;
            this.skinContextMenuStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.skinContextMenuStrip1_Opening);
            this.skinContextMenuStrip1.Click += new System.EventHandler(this.menuItem_Folder_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "新建文件夹";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.flowLayoutPanel1.ContextMenuStrip = this.skinContextMenuStrip1;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(265, 400);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // vScrollBar
            // 
            this.vScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.vScrollBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vScrollBar.BackgroundImage")));
            this.vScrollBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vScrollBar.Location = new System.Drawing.Point(264, 56);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(10, 554);
            this.vScrollBar.TabIndex = 31;
            this.vScrollBar.Visible = false;
            this.vScrollBar.ScrollChangeListener += new TestListView.XScrollBar.EventProgressHandler(this.VScrollBar_ScrollChangeListener);
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
            this.menuItem_SaveAs,
            this.separator_three,
            this.menuItem_Emoji,
            this.menuItem_Moveto,
            this.menuItem_Floder,
            this.separator_four,
            this.menuItem_del});
            this.contextMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.contextMenu.Name = "contentMenuStrip";
            this.contextMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenu.Size = new System.Drawing.Size(137, 204);
            this.contextMenu.SkinAllColor = true;
            this.contextMenu.TitleAnamorphosis = false;
            this.contextMenu.TitleColor = System.Drawing.Color.White;
            this.contextMenu.TitleRadius = 4;
            this.contextMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // menuItem_Open
            // 
            this.menuItem_Open.Name = "menuItem_Open";
            this.menuItem_Open.Size = new System.Drawing.Size(136, 22);
            this.menuItem_Open.Text = "打开";
            this.menuItem_Open.Click += new System.EventHandler(this.menuItem_Open_Click);
            // 
            // separator_one
            // 
            this.separator_one.Name = "separator_one";
            this.separator_one.Size = new System.Drawing.Size(133, 6);
            // 
            // menuItem_Copy
            // 
            this.menuItem_Copy.Name = "menuItem_Copy";
            this.menuItem_Copy.Size = new System.Drawing.Size(136, 22);
            this.menuItem_Copy.Text = "复制";
            this.menuItem_Copy.Click += new System.EventHandler(this.menuItem_Copy_Click);
            // 
            // separator_two
            // 
            this.separator_two.Name = "separator_two";
            this.separator_two.Size = new System.Drawing.Size(133, 6);
            // 
            // menuItem_Forward
            // 
            this.menuItem_Forward.Name = "menuItem_Forward";
            this.menuItem_Forward.Size = new System.Drawing.Size(136, 22);
            this.menuItem_Forward.Text = "转发";
            this.menuItem_Forward.Click += new System.EventHandler(this.menuItem_Forward_Click);
            // 
            // menuItem_SaveAs
            // 
            this.menuItem_SaveAs.Name = "menuItem_SaveAs";
            this.menuItem_SaveAs.Size = new System.Drawing.Size(136, 22);
            this.menuItem_SaveAs.Text = "另存为...";
            this.menuItem_SaveAs.Click += new System.EventHandler(this.menuItem_SaveAs_Click);
            // 
            // separator_three
            // 
            this.separator_three.Name = "separator_three";
            this.separator_three.Size = new System.Drawing.Size(133, 6);
            // 
            // menuItem_Emoji
            // 
            this.menuItem_Emoji.Name = "menuItem_Emoji";
            this.menuItem_Emoji.Size = new System.Drawing.Size(136, 22);
            this.menuItem_Emoji.Text = "存表情";
            this.menuItem_Emoji.Click += new System.EventHandler(this.menuItem_Emoji_Click);
            // 
            // menuItem_Moveto
            // 
            this.menuItem_Moveto.Name = "menuItem_Moveto";
            this.menuItem_Moveto.Size = new System.Drawing.Size(136, 22);
            this.menuItem_Moveto.Text = "移动至";
            // 
            // menuItem_Floder
            // 
            this.menuItem_Floder.Name = "menuItem_Floder";
            this.menuItem_Floder.Size = new System.Drawing.Size(136, 22);
            this.menuItem_Floder.Text = "新建文件夹";
            this.menuItem_Floder.Click += new System.EventHandler(this.menuItem_Folder_Click);
            // 
            // separator_four
            // 
            this.separator_four.Name = "separator_four";
            this.separator_four.Size = new System.Drawing.Size(133, 6);
            // 
            // menuItem_del
            // 
            this.menuItem_del.Name = "menuItem_del";
            this.menuItem_del.Size = new System.Drawing.Size(136, 22);
            this.menuItem_del.Text = "删除";
            this.menuItem_del.Click += new System.EventHandler(this.menuItem_Deletion_Click);
            // 
            // folderMenu
            // 
            this.folderMenu.Arrow = System.Drawing.Color.Black;
            this.folderMenu.Back = System.Drawing.Color.White;
            this.folderMenu.BackRadius = 1;
            this.folderMenu.Base = System.Drawing.Color.White;
            this.folderMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.folderMenu.DropShadowEnabled = false;
            this.folderMenu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.folderMenu.Fore = System.Drawing.Color.Black;
            this.folderMenu.HoverFore = System.Drawing.Color.Black;
            this.folderMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.folderMenu.ItemAnamorphosis = false;
            this.folderMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.folderMenu.ItemBorderShow = false;
            this.folderMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.folderMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.folderMenu.ItemRadius = 1;
            this.folderMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.folderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.toolStripSeparator1,
            this.btnRename,
            this.toolStripSeparator2,
            this.btnMoveto,
            this.btnCreate,
            this.toolStripSeparator3,
            this.btnDelete,
            this.toolStripSeparator4,
            this.btnFolderDetail});
            this.folderMenu.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.folderMenu.Name = "contentMenuStrip";
            this.folderMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.folderMenu.Size = new System.Drawing.Size(137, 160);
            this.folderMenu.SkinAllColor = true;
            this.folderMenu.TitleAnamorphosis = false;
            this.folderMenu.TitleColor = System.Drawing.Color.White;
            this.folderMenu.TitleRadius = 4;
            this.folderMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // btnOpen
            // 
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(136, 22);
            this.btnOpen.Text = "打开";
            this.btnOpen.Click += new System.EventHandler(this.menuItem_OpenFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // btnRename
            // 
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(136, 22);
            this.btnRename.Text = "重命名";
            this.btnRename.Click += new System.EventHandler(this.menuItem_Rename_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // btnMoveto
            // 
            this.btnMoveto.Name = "btnMoveto";
            this.btnMoveto.Size = new System.Drawing.Size(136, 22);
            this.btnMoveto.Text = "移动至";
            // 
            // btnCreate
            // 
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(136, 22);
            this.btnCreate.Text = "新建文件夹";
            this.btnCreate.Click += new System.EventHandler(this.menuItem_Folder_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(133, 6);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(136, 22);
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.menuItem_Delete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(133, 6);
            // 
            // btnFolderDetail
            // 
            this.btnFolderDetail.Name = "btnFolderDetail";
            this.btnFolderDetail.Size = new System.Drawing.Size(136, 22);
            this.btnFolderDetail.Text = "属性";
            this.btnFolderDetail.Click += new System.EventHandler(this.menuItem_Detail_Click);
            // 
            // collectionToolbar1
            // 
            this.collectionToolbar1.Location = new System.Drawing.Point(0, 56);
            this.collectionToolbar1.Name = "collectionToolbar1";
            this.collectionToolbar1.Size = new System.Drawing.Size(275, 36);
            this.collectionToolbar1.TabIndex = 33;
            this.collectionToolbar1.Visible = false;
            // 
            // CollectionListLayout
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.collectionToolbar1);
            this.Controls.Add(this.limitPanel);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.skLine);
            this.Controls.Add(this.tabLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CollectionListLayout";
            this.Size = new System.Drawing.Size(275, 610);
            this.limitPanel.ResumeLayout(false);
            this.skinContextMenuStrip1.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.folderMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ToolTip toolTip1;
        private Controls.TabLayoutPanel tabLayoutPanel1;
        private System.Windows.Forms.Label skLine;
        private System.Windows.Forms.Panel limitPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private TestListView.XScrollBar vScrollBar;
        private CCWin.SkinControl.SkinContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Open;
        private System.Windows.Forms.ToolStripSeparator separator_one;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Copy;
        private System.Windows.Forms.ToolStripSeparator separator_two;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Forward;
        private System.Windows.Forms.ToolStripSeparator separator_three;
        private System.Windows.Forms.ToolStripMenuItem menuItem_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuItem_del;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Floder;
        private System.Windows.Forms.ToolStripSeparator separator_four;
        private CCWin.SkinControl.SkinContextMenuStrip folderMenu;
        private System.Windows.Forms.ToolStripMenuItem btnOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnRename;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnMoveto;
        private System.Windows.Forms.ToolStripMenuItem btnCreate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem btnFolderDetail;
        private Controls.LayouotControl.Groups.CollectionToolbar collectionToolbar1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Emoji;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Moveto;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStrip1;

        #endregion
        /*
        private System.Windows.Forms.TextBox txtSearch;
        private MyTabLayoutPanel tlpRoomList;
        private System.Windows.Forms.Button btnPlus;
        */
    }
}

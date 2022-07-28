using TestListView;

namespace WinFrmTalk.Controls.CustomControls
{
    partial class GroupCollection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupCollection));
            this.lab_splitMultiSelect = new System.Windows.Forms.Label();
            this.panMultiSelect = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.multiSelectPanel = new WinFrmTalk.Controls.CustomControls.MultiSelectCollectPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelImgList = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxGQ = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.labelGroupInfo = new System.Windows.Forms.Label();
            this.panelImgFolder = new System.Windows.Forms.Panel();
            this.labelImgFolderTitle = new System.Windows.Forms.Label();
            this.SearchCollect = new WinFrmTalk.Controls.CustomControls.UserSearch();
            this.cc = new TestListView.XListView();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.cmsLecture = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSendLecture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCollection = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tsmPlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.separator_one = new System.Windows.Forms.ToolStripSeparator();
            this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.separator_two = new System.Windows.Forms.ToolStripSeparator();
            this.tsmForward = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMulti = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.separator_three = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRename = new System.Windows.Forms.ToolStripMenuItem();
            this.separator_four = new System.Windows.Forms.ToolStripSeparator();
            this.tsmDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tvClassTip = new System.Windows.Forms.Label();
            this.flowLayoutPanelRight = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLecture = new System.Windows.Forms.Button();
            this.btnWhole = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnImg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panMultiSelect.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGQ)).BeginInit();
            this.panelImgFolder.SuspendLayout();
            this.cmsLecture.SuspendLayout();
            this.cmsCollection.SuspendLayout();
            this.flowLayoutPanelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // lab_splitMultiSelect
            // 
            this.lab_splitMultiSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_splitMultiSelect.BackColor = System.Drawing.Color.Gainsboro;
            this.lab_splitMultiSelect.Location = new System.Drawing.Point(0, 0);
            this.lab_splitMultiSelect.Name = "lab_splitMultiSelect";
            this.lab_splitMultiSelect.Size = new System.Drawing.Size(1361, 1);
            this.lab_splitMultiSelect.TabIndex = 12;
            // 
            // panMultiSelect
            // 
            this.panMultiSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panMultiSelect.BackColor = System.Drawing.Color.White;
            this.panMultiSelect.Controls.Add(this.lblClose);
            this.panMultiSelect.Controls.Add(this.lab_splitMultiSelect);
            this.panMultiSelect.Controls.Add(this.multiSelectPanel);
            this.panMultiSelect.Location = new System.Drawing.Point(0, 565);
            this.panMultiSelect.Name = "panMultiSelect";
            this.panMultiSelect.Size = new System.Drawing.Size(536, 82);
            this.panMultiSelect.TabIndex = 19;
            this.panMultiSelect.Visible = false;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Image = global::WinFrmTalk.Properties.Resources.CloseDan;
            this.lblClose.Location = new System.Drawing.Point(522, 1);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(18, 18);
            this.lblClose.TabIndex = 10;
            this.lblClose.Click += new System.EventHandler(this.LblClose_Click);
            // 
            // multiSelectPanel
            // 
            this.multiSelectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multiSelectPanel.BackColor = System.Drawing.Color.Transparent;
            this.multiSelectPanel.FdTalking = null;
            this.multiSelectPanel.List_Msgs = null;
            this.multiSelectPanel.Location = new System.Drawing.Point(0, 1);
            this.multiSelectPanel.Name = "multiSelectPanel";
            this.multiSelectPanel.showInfo_panel = null;
            this.multiSelectPanel.Size = new System.Drawing.Size(536, 115);
            this.multiSelectPanel.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.flowLayoutPanelImgList);
            this.panel1.Controls.Add(this.flowLayoutPanelTop);
            this.panel1.Controls.Add(this.panelImgFolder);
            this.panel1.Controls.Add(this.SearchCollect);
            this.panel1.Controls.Add(this.cc);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 559);
            this.panel1.TabIndex = 5;
            // 
            // flowLayoutPanelImgList
            // 
            this.flowLayoutPanelImgList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanelImgList.Location = new System.Drawing.Point(3, 31);
            this.flowLayoutPanelImgList.Name = "flowLayoutPanelImgList";
            this.flowLayoutPanelImgList.Size = new System.Drawing.Size(477, 525);
            this.flowLayoutPanelImgList.TabIndex = 10;
            this.flowLayoutPanelImgList.Visible = false;
            // 
            // flowLayoutPanelTop
            // 
            this.flowLayoutPanelTop.Controls.Add(this.pictureBoxGQ);
            this.flowLayoutPanelTop.Controls.Add(this.lblTitle);
            this.flowLayoutPanelTop.Controls.Add(this.labelGroupInfo);
            this.flowLayoutPanelTop.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanelTop.Name = "flowLayoutPanelTop";
            this.flowLayoutPanelTop.Size = new System.Drawing.Size(476, 29);
            this.flowLayoutPanelTop.TabIndex = 9;
            // 
            // pictureBoxGQ
            // 
            this.pictureBoxGQ.BackgroundImage = global::WinFrmTalk.Properties.Resources.groupGQ;
            this.pictureBoxGQ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxGQ.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxGQ.Name = "pictureBoxGQ";
            this.pictureBoxGQ.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxGQ.TabIndex = 7;
            this.pictureBoxGQ.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(34, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(88, 25);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "全部收藏";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGroupInfo
            // 
            this.labelGroupInfo.AutoSize = true;
            this.labelGroupInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelGroupInfo.ForeColor = System.Drawing.Color.Black;
            this.labelGroupInfo.Location = new System.Drawing.Point(128, 0);
            this.labelGroupInfo.Name = "labelGroupInfo";
            this.labelGroupInfo.Size = new System.Drawing.Size(135, 20);
            this.labelGroupInfo.TabIndex = 8;
            this.labelGroupInfo.Text = "(总群员：1000W人)";
            this.labelGroupInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelImgFolder
            // 
            this.panelImgFolder.Controls.Add(this.labelImgFolderTitle);
            this.panelImgFolder.Location = new System.Drawing.Point(3, 28);
            this.panelImgFolder.Name = "panelImgFolder";
            this.panelImgFolder.Size = new System.Drawing.Size(476, 30);
            this.panelImgFolder.TabIndex = 8;
            this.panelImgFolder.Visible = false;
            // 
            // labelImgFolderTitle
            // 
            this.labelImgFolderTitle.AutoSize = true;
            this.labelImgFolderTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelImgFolderTitle.ForeColor = System.Drawing.Color.Black;
            this.labelImgFolderTitle.Location = new System.Drawing.Point(3, 11);
            this.labelImgFolderTitle.Name = "labelImgFolderTitle";
            this.labelImgFolderTitle.Size = new System.Drawing.Size(69, 17);
            this.labelImgFolderTitle.TabIndex = 7;
            this.labelImgFolderTitle.Text = "< 全部收藏";
            this.labelImgFolderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelImgFolderTitle.Click += new System.EventHandler(this.labelImgFolderTitle_Click);
            // 
            // SearchCollect
            // 
            this.SearchCollect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(217)))), ((int)(((byte)(216)))));
            this.SearchCollect.Location = new System.Drawing.Point(20, 3);
            this.SearchCollect.LoseFocusResume = true;
            this.SearchCollect.Name = "SearchCollect";
            this.SearchCollect.Size = new System.Drawing.Size(230, 22);
            this.SearchCollect.TabIndex = 7;
            this.SearchCollect.Visible = false;
            // 
            // cc
            // 
            this.cc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cc.BackColor = System.Drawing.Color.White;
            this.cc.ForeColor = System.Drawing.Color.Black;
            this.cc.Location = new System.Drawing.Point(3, 31);
            this.cc.Name = "cc";
            this.cc.ScrollBarWidth = 10;
            this.cc.Size = new System.Drawing.Size(477, 525);
            this.cc.TabIndex = 3;
            // 
            // skinLine1
            // 
            this.skinLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.skinLine1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(260, 39);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(289, 1);
            this.skinLine1.TabIndex = 2;
            this.skinLine1.Text = "skinLine1";
            this.skinLine1.Visible = false;
            // 
            // cmsLecture
            // 
            this.cmsLecture.Arrow = System.Drawing.Color.Black;
            this.cmsLecture.Back = System.Drawing.Color.White;
            this.cmsLecture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsLecture.BackRadius = 4;
            this.cmsLecture.Base = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsLecture.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsLecture.Fore = System.Drawing.Color.Black;
            this.cmsLecture.HoverFore = System.Drawing.Color.Black;
            this.cmsLecture.ItemAnamorphosis = false;
            this.cmsLecture.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsLecture.ItemBorderShow = false;
            this.cmsLecture.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsLecture.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsLecture.ItemRadius = 4;
            this.cmsLecture.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsLecture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEdit,
            this.tsmSendLecture,
            this.tsmDelete});
            this.cmsLecture.ItemSplitter = System.Drawing.Color.Silver;
            this.cmsLecture.Name = "cmsStaff";
            this.cmsLecture.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsLecture.Size = new System.Drawing.Size(125, 70);
            this.cmsLecture.SkinAllColor = true;
            this.cmsLecture.TitleAnamorphosis = true;
            this.cmsLecture.TitleColor = System.Drawing.Color.White;
            this.cmsLecture.TitleRadius = 4;
            this.cmsLecture.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(124, 22);
            this.tsmEdit.Text = "修改名称";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmSendLecture
            // 
            this.tsmSendLecture.Name = "tsmSendLecture";
            this.tsmSendLecture.Size = new System.Drawing.Size(124, 22);
            this.tsmSendLecture.Text = "发送课件";
            this.tsmSendLecture.Click += new System.EventHandler(this.tsmSendLecture_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(124, 22);
            this.tsmDelete.Text = "删除课件";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // cmsCollection
            // 
            this.cmsCollection.Arrow = System.Drawing.Color.Black;
            this.cmsCollection.Back = System.Drawing.Color.White;
            this.cmsCollection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsCollection.BackRadius = 4;
            this.cmsCollection.Base = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsCollection.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsCollection.Fore = System.Drawing.Color.Black;
            this.cmsCollection.HoverFore = System.Drawing.Color.Black;
            this.cmsCollection.ItemAnamorphosis = false;
            this.cmsCollection.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsCollection.ItemBorderShow = false;
            this.cmsCollection.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsCollection.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsCollection.ItemRadius = 4;
            this.cmsCollection.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsCollection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPlayer,
            this.tsmOpen,
            this.separator_one,
            this.tsmCopy,
            this.separator_two,
            this.tsmForward,
            this.tsmMulti,
            this.tsmNewFolder,
            this.separator_three,
            this.menuItem_SaveAs,
            this.tsmRename,
            this.separator_four,
            this.tsmDel});
            this.cmsCollection.ItemSplitter = System.Drawing.Color.Silver;
            this.cmsCollection.Name = "cmsStaff";
            this.cmsCollection.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsCollection.Size = new System.Drawing.Size(137, 226);
            this.cmsCollection.SkinAllColor = true;
            this.cmsCollection.TitleAnamorphosis = true;
            this.cmsCollection.TitleColor = System.Drawing.Color.White;
            this.cmsCollection.TitleRadius = 4;
            this.cmsCollection.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // tsmPlayer
            // 
            this.tsmPlayer.Name = "tsmPlayer";
            this.tsmPlayer.Size = new System.Drawing.Size(136, 22);
            this.tsmPlayer.Text = "静音播放";
            this.tsmPlayer.Visible = false;
            this.tsmPlayer.Click += new System.EventHandler(this.tsmPlayer_Click);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(136, 22);
            this.tsmOpen.Text = "打开";
            this.tsmOpen.Visible = false;
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // separator_one
            // 
            this.separator_one.Name = "separator_one";
            this.separator_one.Size = new System.Drawing.Size(133, 6);
            this.separator_one.Visible = false;
            // 
            // tsmCopy
            // 
            this.tsmCopy.Name = "tsmCopy";
            this.tsmCopy.Size = new System.Drawing.Size(136, 22);
            this.tsmCopy.Text = "复制";
            this.tsmCopy.Visible = false;
            this.tsmCopy.Click += new System.EventHandler(this.tsmCopy_Click);
            // 
            // separator_two
            // 
            this.separator_two.Name = "separator_two";
            this.separator_two.Size = new System.Drawing.Size(133, 6);
            this.separator_two.Visible = false;
            // 
            // tsmForward
            // 
            this.tsmForward.Name = "tsmForward";
            this.tsmForward.Size = new System.Drawing.Size(136, 22);
            this.tsmForward.Text = "转发";
            this.tsmForward.Visible = false;
            this.tsmForward.Click += new System.EventHandler(this.tsmForward_Click);
            // 
            // tsmMulti
            // 
            this.tsmMulti.Name = "tsmMulti";
            this.tsmMulti.Size = new System.Drawing.Size(136, 22);
            this.tsmMulti.Text = "多选";
            this.tsmMulti.Visible = false;
            this.tsmMulti.Click += new System.EventHandler(this.tsmMulti_Click);
            // 
            // tsmNewFolder
            // 
            this.tsmNewFolder.Name = "tsmNewFolder";
            this.tsmNewFolder.Size = new System.Drawing.Size(136, 22);
            this.tsmNewFolder.Text = "新建文件夹";
            this.tsmNewFolder.Visible = false;
            // 
            // separator_three
            // 
            this.separator_three.Name = "separator_three";
            this.separator_three.Size = new System.Drawing.Size(133, 6);
            this.separator_three.Visible = false;
            // 
            // menuItem_SaveAs
            // 
            this.menuItem_SaveAs.Name = "menuItem_SaveAs";
            this.menuItem_SaveAs.Size = new System.Drawing.Size(136, 22);
            this.menuItem_SaveAs.Text = "另存为...";
            this.menuItem_SaveAs.Visible = false;
            // 
            // tsmRename
            // 
            this.tsmRename.Name = "tsmRename";
            this.tsmRename.Size = new System.Drawing.Size(136, 22);
            this.tsmRename.Text = "重命名";
            // 
            // separator_four
            // 
            this.separator_four.Name = "separator_four";
            this.separator_four.Size = new System.Drawing.Size(133, 6);
            this.separator_four.Visible = false;
            // 
            // tsmDel
            // 
            this.tsmDel.Name = "tsmDel";
            this.tsmDel.Size = new System.Drawing.Size(136, 22);
            this.tsmDel.Text = "删除";
            this.tsmDel.Visible = false;
            this.tsmDel.Click += new System.EventHandler(this.tsmDel_Click);
            // 
            // tvClassTip
            // 
            this.tvClassTip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvClassTip.AutoSize = true;
            this.tvClassTip.ForeColor = System.Drawing.Color.Blue;
            this.tvClassTip.Location = new System.Drawing.Point(470, 504);
            this.tvClassTip.Name = "tvClassTip";
            this.tvClassTip.Size = new System.Drawing.Size(101, 12);
            this.tvClassTip.TabIndex = 7;
            this.tvClassTip.Text = "我的课件功能说明";
            this.tvClassTip.Visible = false;
            this.tvClassTip.Click += new System.EventHandler(this.tvClassTip_Click);
            // 
            // flowLayoutPanelRight
            // 
            this.flowLayoutPanelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelRight.Controls.Add(this.btnLecture);
            this.flowLayoutPanelRight.Controls.Add(this.btnWhole);
            this.flowLayoutPanelRight.Controls.Add(this.btnText);
            this.flowLayoutPanelRight.Controls.Add(this.btnVideo);
            this.flowLayoutPanelRight.Controls.Add(this.btnImg);
            this.flowLayoutPanelRight.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelRight.Location = new System.Drawing.Point(489, 31);
            this.flowLayoutPanelRight.Name = "flowLayoutPanelRight";
            this.flowLayoutPanelRight.Size = new System.Drawing.Size(47, 537);
            this.flowLayoutPanelRight.TabIndex = 20;
            // 
            // btnLecture
            // 
            this.btnLecture.BackColor = System.Drawing.Color.White;
            this.btnLecture.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btnLecture.FlatAppearance.BorderSize = 0;
            this.btnLecture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLecture.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLecture.Image = ((System.Drawing.Image)(resources.GetObject("btnLecture.Image")));
            this.btnLecture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLecture.Location = new System.Drawing.Point(3, 3);
            this.btnLecture.Name = "btnLecture";
            this.btnLecture.Size = new System.Drawing.Size(52, 60);
            this.btnLecture.TabIndex = 2;
            this.btnLecture.Text = "公告";
            this.btnLecture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLecture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLecture.UseVisualStyleBackColor = false;
            this.btnLecture.Click += new System.EventHandler(this.btnLecture_Click);
            // 
            // btnWhole
            // 
            this.btnWhole.BackColor = System.Drawing.Color.White;
            this.btnWhole.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btnWhole.FlatAppearance.BorderSize = 0;
            this.btnWhole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhole.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWhole.Image = ((System.Drawing.Image)(resources.GetObject("btnWhole.Image")));
            this.btnWhole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWhole.Location = new System.Drawing.Point(3, 69);
            this.btnWhole.Name = "btnWhole";
            this.btnWhole.Size = new System.Drawing.Size(52, 60);
            this.btnWhole.TabIndex = 0;
            this.btnWhole.Text = "活动";
            this.btnWhole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWhole.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnWhole.UseVisualStyleBackColor = false;
            this.btnWhole.Click += new System.EventHandler(this.btnWhole_Click);
            // 
            // btnText
            // 
            this.btnText.BackColor = System.Drawing.Color.White;
            this.btnText.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btnText.FlatAppearance.BorderSize = 0;
            this.btnText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnText.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnText.Image = global::WinFrmTalk.Properties.Resources.Note;
            this.btnText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnText.Location = new System.Drawing.Point(3, 135);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(52, 60);
            this.btnText.TabIndex = 1;
            this.btnText.Text = "文件";
            this.btnText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnText.UseVisualStyleBackColor = false;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.BackColor = System.Drawing.Color.White;
            this.btnVideo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btnVideo.FlatAppearance.BorderSize = 0;
            this.btnVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideo.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideo.Image = global::WinFrmTalk.Properties.Resources.video;
            this.btnVideo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVideo.Location = new System.Drawing.Point(3, 201);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(52, 60);
            this.btnVideo.TabIndex = 2;
            this.btnVideo.Text = "视频";
            this.btnVideo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVideo.UseVisualStyleBackColor = false;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // btnImg
            // 
            this.btnImg.BackColor = System.Drawing.Color.White;
            this.btnImg.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btnImg.FlatAppearance.BorderSize = 0;
            this.btnImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImg.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImg.Image = global::WinFrmTalk.Properties.Resources.Imag;
            this.btnImg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImg.Location = new System.Drawing.Point(3, 267);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(52, 60);
            this.btnImg.TabIndex = 2;
            this.btnImg.Text = "相册";
            this.btnImg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImg.UseVisualStyleBackColor = false;
            this.btnImg.Click += new System.EventHandler(this.btnImg_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(499, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // GroupCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowLayoutPanelRight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panMultiSelect);
            this.Controls.Add(this.tvClassTip);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.panel1);
            this.Name = "GroupCollection";
            this.Size = new System.Drawing.Size(540, 562);
            this.panMultiSelect.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanelTop.ResumeLayout(false);
            this.flowLayoutPanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGQ)).EndInit();
            this.panelImgFolder.ResumeLayout(false);
            this.panelImgFolder.PerformLayout();
            this.cmsLecture.ResumeLayout(false);
            this.cmsCollection.ResumeLayout(false);
            this.flowLayoutPanelRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lab_splitMultiSelect;
        public MultiSelectCollectPanel multiSelectPanel;
        private System.Windows.Forms.Button btnWhole;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Button btnImg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.Button btnLecture;
        public CCWin.SkinControl.SkinContextMenuStrip cmsLecture;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        public CCWin.SkinControl.SkinContextMenuStrip cmsCollection;
        private System.Windows.Forms.ToolStripMenuItem tsmForward;
        private System.Windows.Forms.ToolStripMenuItem tsmDel;
        private System.Windows.Forms.ToolStripMenuItem tsmSendLecture;
        private System.Windows.Forms.Button btnVideo;
        private UserSearch SearchCollect;
        public XListView cc;
        private System.Windows.Forms.Label tvClassTip;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmMulti;
        private System.Windows.Forms.ToolStripMenuItem menuItem_SaveAs;
        public System.Windows.Forms.ToolStripSeparator separator_one;
        private System.Windows.Forms.ToolStripSeparator separator_two;
        private System.Windows.Forms.ToolStripSeparator separator_three;
        private System.Windows.Forms.ToolStripSeparator separator_four;
        private System.Windows.Forms.ToolStripMenuItem tsmRename;
        private System.Windows.Forms.ToolStripMenuItem tsmPlayer;
        private System.Windows.Forms.ToolStripMenuItem tsmNewFolder;
        private System.Windows.Forms.Panel panMultiSelect;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Panel panelImgFolder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRight;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTop;
        private System.Windows.Forms.PictureBox pictureBoxGQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelGroupInfo;
        private System.Windows.Forms.Label labelImgFolderTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImgList;
    }
}

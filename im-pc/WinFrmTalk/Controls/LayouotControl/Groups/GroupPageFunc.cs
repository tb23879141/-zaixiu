using CCWin.SkinControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Controls.LayouotControl.GroupDomain;
using WinFrmTalk.Controls.LayouotControl.Items;
using WinFrmTalk.Helper;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;
using WinFrmTalk.View;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    public partial class GroupPageFunc : UserControl
    {

        private GroupTabIndex mGroupTab;
        private bool isManager;
        private bool isMember;
        /// <summary>
        /// 0 = 内部群
        /// 1 = 外部群
        /// 2 = 官群
        /// </summary>
        private int GroupType;

        private List<HttpFolderData> folderList;

        public GroupPageFunc()
        {
            InitializeComponent();

            this.flowLayoutPanel1.MouseWheel += View_MouseWheel;
            this.vScrollBar.MouseWheel += View_MouseWheel;

            // 工具栏功能事件
            this.groupFuncTools1.SearchEvent += GroupFuncTools_SearchEvent;
            this.groupFuncTools1.CreateFolderClick += GroupFuncTools_CreateFolderClick;
            this.groupFuncTools1.FilterClick += GroupFuncTools_FilterClick;
            this.groupFuncTools1.BackClick += GroupFuncTools_BackClick;

        }

        public void BindRoomData(Friend friend)
        {
            this.mFriend = friend;

            isManager = this.mFriend.Role == "1" || this.mFriend.Role == "2";
            isMember = this.mFriend.Role != "-1";
            if (friend.GroupType == 2)
            {
                // 官群
                GroupType = 2;
            }
            else if (friend.GroupType > 9 && friend.inside == 0)
            {
                // 内部群
                GroupType = 0;
            }
            else
            {
                // 外部群 或 社群
                GroupType = 1;
            }
        }

        public void SwitchGroupPage(GroupTabIndex type)
        {
            this.flowLayoutPanel1.Controls.Clear();
            this.flowLayoutPanel1.Location = new Point();
            this.vScrollBar.SetProgress(0);
            mGroupTab = type;

            switch (type)
            {
                case GroupTabIndex.notify:
                    HttpGroupNotice();
                    break;
                case GroupTabIndex.files:
                    HttpGroupFiles();
                    break;
                case GroupTabIndex.active:
                    HttpGroupActivity();
                    break;
                case GroupTabIndex.image:
                    HttpGroupPhoto();
                    break;
                case GroupTabIndex.video:
                    HttpGroupVideo();
                    break;
                default:
                    break;
            }

            ChangeToolbar();
        }




        /// <summary>
        /// 控制工具栏
        /// </summary>
        /// <param name="visiable"></param>
        /// <param name="level"></param>
        /// <param name="folderName"></param>
        /// <param name="count"></param>
        private void ChangeToolbar(HttpFolderData folder = null)
        {
            if (folder != null)
            {
                groupFuncTools1.Visible = true;
                groupFuncTools1.SetToolbarData(folder, GroupType, isManager, mGroupTab);
                limitPanel.Height = this.Height - 41;
                limitPanel.Location = new Point(limitPanel.Location.X, 41);
            }
            else
            {
                groupFuncTools1.Visible = false;
                limitPanel.Location = new Point(limitPanel.Location.X, 3);
                limitPanel.Height = this.Height - 3;
            }

        }

        private int CalcFixedHeight(GroupTabIndex type, int total)
        {
            switch (type)
            {
                case GroupTabIndex.files:
                    return Convert.ToInt32(Math.Ceiling(total / (float)2) * 115) + 20;
                case GroupTabIndex.active:
                    return Convert.ToInt32(Math.Ceiling(total / (float)2) * 210) + 20;
            }

            return 0;
        }

        private void UpdateListHeight(int height)
        {
            if (height > 0 && flowLayoutPanel1.Controls.Count > 0)
            {
                flowLayoutPanel1.Height = height;
                vScrollBar.Visible = flowLayoutPanel1.Height > limitPanel.Height;

            }
            else
            {
                vScrollBar.Visible = false;
                // 显示空页面
                var empty = CreateEmptyTip();
                flowLayoutPanel1.Controls.Add(empty);
                flowLayoutPanel1.Height = limitPanel.Height - 1;
            }
        }

        public Control CreateEmptyTip()
        {
            var item = new Label();
            item.AutoSize = false;
            item.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            item.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            item.Name = "item";
            item.Size = new System.Drawing.Size(74, 21);
            item.Text = "暂无内容";
            item.Margin = new System.Windows.Forms.Padding((limitPanel.Width - 74) / 2, (limitPanel.Height - 21) / 2, 0, 0);
            item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return item;
        }

        public Control CreateNotifyItem(MyGroupNotice data, bool first)
        {
            var item = new GroupNotifyItem();
            item.ListWidth = flowLayoutPanel1.Width;
            item.SetContentData(data, contextMenu);
            item.Margin = new Padding(0, first ? 16 : 6, 0, 0);
            item.Tag = data;
            item.AccessibleDescription = String.Concat(data.title, data.text);
            return item;

        }

        /// <summary>
        /// 创建活动项
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Control CreateActiveItem(MyGroupActivity data, bool frist)
        {
            var item = new GroupActiveItem();
            item.SetContentData(data);
            item.Margin = new Padding(10, frist ? 20 : 10, 0, 0); ;
            item.MouseClick += Active_MouseClick;
            item.Tag = data;
            item.AccessibleDescription = data.title;
            return item;

        }

        /// <summary>
        /// 创建文件项
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Control CreateFilesItem(GroupFilesx data)
        {
            var item = new Items.GroupFileItem();

            if (UIUtils.IsNull(data.resource.oFileName))
            {
                data.resource.oFileName = FileUtils.GetFileName(data.resource.oUrl);
            }

            item.SetContentData(data);
            item.Margin = new Padding(10, 10, 0, 0);

            item.AccessibleDescription = data.resource.oUrl;
            item.AccessibleName = data.resource.oFileName;
            item.MouseClick += File_MouseClick;
            item.Tag = data;
            return item;

        }

        /// <summary>
        /// 创建视频项
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Control CreateVideoItem(GroupFilesx data)
        {
            var item = new GroupVideoItem();
            item.SetContentData(data);

            item.Margin = new Padding(10, 10, 0, 0);

            item.AccessibleDescription = data.resource.oUrl;
            item.AccessibleName = data.resource.size.ToString();
            item.MouseClick += Video_MouseClick;
            item.Tag = data;
            return item;
        }

        /// <summary>
        /// 创建视频时间线
        /// </summary>
        /// <param name="timeText"></param>
        /// <returns></returns>
        public Control CreateVideoTimeLine(string timeText, bool frist)
        {
            var item = new Label();
            item.Name = timeText;
            item.AutoSize = false;
            item.Size = new Size(flowLayoutPanel1.Width - 10, 26);
            item.Text = timeText;
            item.Font = new Font("微软雅黑", 16f, FontStyle.Bold, GraphicsUnit.Pixel);
            item.ForeColor = Color.FromArgb(51, 51, 51);
            item.Margin = new Padding(8, frist ? 20 : 10, 0, 0);
            return item;
        }

        /// <summary>
        /// 创建文件夹项
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Control CreateFolderItem(HttpFolderData data)
        {
            var item = new GroupFolderItem();
            item.SetContentData(data);
            item.MouseClick += Folder_MouseClick;
            item.Margin = new Padding(32, 10, 0, 0);
            item.Tag = data;
            if (UIUtils.IsNull(data.folderId))
            {
                item.Name = "0";
            }
            else
            {
                item.Name = data.folderId;
            }

            item.AccessibleDescription = data.folderName;
            return item;
        }

        /// <summary>
        /// 创建照片项
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        private Control CreateImageItem(GroupFilesx photo, bool topLine)
        {
            var item = new GroupImageItem();
            item.SetContentData(photo);
            item.MouseClick += Image_MouseClick;
            if (topLine)
            {
                item.Margin = new Padding(8, 15, 0, 0);
            }
            else
            {
                item.Margin = new Padding(8, 5, 0, 0);
            }


            item.AccessibleDescription = photo.url;
            item.Tag = photo;
            return item;
        }


        /// <summary>
        /// 打开文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Folder_MouseClick(object sender, MouseEventArgs e)
        {

            if (e != null && e.Button == MouseButtons.Right)
            {
                mSelectControl = sender as Control;
                return;
            }

            var folder = sender as GroupFolderItem;

            ChangeToolbar(folder.itemData);

            // 显示数据
            if (folder.tabIndex == GroupTabIndex.notify)
            {
                ShowNoticeList(folder.itemData);
            }
            else if (folder.tabIndex == GroupTabIndex.files)
            {
                ShowFileList(folder.itemData);
            }
            else if (folder.tabIndex == GroupTabIndex.video)
            {
                ShowVideoList(folder.itemData);
            }
            else if (folder.tabIndex == GroupTabIndex.active)
            {
                ShowActiveList(folder.itemData);
            }
            else if (folder.tabIndex == GroupTabIndex.image)
            {
                ShowImageList(folder.itemData);
            }
        }

        /// <summary>
        /// 打开公告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notify_MouseClick(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button == MouseButtons.Right)
            {
                mSelectControl = sender as Control;
                return;
            }

            // 公告
            var item = sender as GroupNotifyItem;
            if (mFriend.Role == "-1" && item.itemData.isPublic == 1)
            {
                var frm = this.FindForm() as FrmBase;
                frm.ShowTip("围观不能查看公告");
                return;
            }
            CollectionSave data = item.toCollection();
            Messenger.Default.Send(data, MessageActions.ShowGroupNotify);
        }

        /// <summary>
        /// 打开活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Active_MouseClick(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button == MouseButtons.Right)
            {
                mSelectControl = sender as Control;
                return;
            }

            // 活动
            var item = sender as Items.GroupActiveItem;
            if (mFriend.Role == "-1" && item.itemData.isPublic == 1)
            {
                var frm = this.FindForm() as FrmBase;
                frm.ShowTip("围观不能查看活动");
                return;
            }

            // 去刷新群头像
            Messenger.Default.Send(item.itemData.id, MessageActions.ShowGroupActive);//发送刷新头像通知
        }

        /// <summary>
        /// 打开图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Image_MouseClick(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button == MouseButtons.Right)
            {
                mSelectControl = sender as Control;
                return;
            }

            var item = (Control)sender;
            var data = item.Tag as GroupFilesx;
            if (mFriend.Role == "-1" && data.isPublic == 1)
            {
                var frm = this.FindForm() as FrmBase;
                frm.ShowTip("围观不能查看图片");
                return;
            }

            //  管理员  || 成员可以下载 || 围观可以下载
            bool download = isManager || (isMember && data.isMemberDownload == 0) || (data.isWatchDownload == 0);

            FrmLookImage look = new FrmLookImage();
            string url = Convert.ToString(item.AccessibleDescription);
            look.pictureBox1_SetImage(url, false, download);
        }

        /// <summary>
        /// 打开视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Video_MouseClick(object sender, MouseEventArgs e)
        {
            var item = sender as Control;
            GroupFilesx data = item.Tag as GroupFilesx;
            if (mFriend.Role == "-1" && data.isPublic == 1)
            {
                var frm = this.FindForm() as FrmBase;
                frm.ShowTip("围观不能查看视频");
                return;
            }

            var url = Convert.ToString(item.AccessibleDescription);

            var messageObject = new MessageObject() { content = url };
            FrmVideoFlash frmVideoFlash = FrmVideoFlash.CreateInstrance();
            frmVideoFlash.noVolumn = e == null;
            frmVideoFlash.VidoShowList(messageObject);
            frmVideoFlash.Show();
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void File_MouseClick(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button == MouseButtons.Right)
            {
                mSelectControl = sender as Control;
                return;
            }

            var item = sender as Control;
            GroupFilesx data = item.Tag as GroupFilesx;
            if (mFriend.Role == "-1" && data.isPublic == 1)
            {
                var frm = this.FindForm() as FrmBase;
                frm.ShowTip("围观不能查看文件");
                return;
            }


            string url = item.AccessibleDescription;
            string localPath = Applicate.LocalConfigData.FileFolderPath + item.AccessibleName;

            OpenFile(url, localPath);
        }

        private void OpenFile(string url, string localPath)
        {
            if (File.Exists(localPath))
            {
                try
                {
                    var frm = this.FindForm() as FrmBase;
                    frm.ShowTip("文件打开中...");
                    //打开文件
                    System.Diagnostics.Process.Start(localPath);
                }
                catch (Exception)
                {
                    HttpUtils.Instance.ShowTip("不能打开此类型文件");
                }
            }
            else
            {

                var frm = this.FindForm() as FrmBase;
                frm.ShowTip("文件正在下载...");

                //下载文件
                DownloadEngine.Instance.DownUrl(url)
                .SavePath(localPath)
                .Down((path) =>
                {

                    var frm1 = this.FindForm() as FrmBase;

                    if (string.IsNullOrEmpty(path))
                    {
                        frm1.ShowTip("文件下载失败");
                        return;
                    }
                    else
                    {
                        frm.ShowTip("文件打开中...");
                        //打开文件
                        System.Diagnostics.Process.Start(localPath);
                    }

                });
            }

        }


        #region 显示文件夹中的列表数据

        private void ShowFolderList(List<HttpFolderData> folders, GroupTabIndex tabIndex)
        {
            this.flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Location = new Point();
            vScrollBar.SetProgress(0);

            int height = 125 + 15, width = 0;
            int type = Convert.ToInt32(GetFolderRoomType(tabIndex));
            foreach (var data in folders)
            {
                data.tabIndex = tabIndex;
                data.type = type;
                if (data.isPublic == 0 || isMember)
                {
                    var item = CreateFolderItem(data);

                    // 绑定右键菜单
                    item.ContextMenuStrip = folderMenu;

                    // 绑定滚动事件
                    AddCrlMouseWheel(item);

                    width += item.Width + item.Margin.Left;
                    if (width > flowLayoutPanel1.Width)
                    {
                        width = item.Width + 8;
                        height += item.Height + item.Margin.Top;
                    }

                    item.MouseDown += Folder_MouseDown;
                    this.flowLayoutPanel1.Controls.Add(item);
                }
            }

            UpdateListHeight(height);

            this.flowLayoutPanel1.ResumeLayout();
        }

        public int ShowSubFolderList(List<HttpFolderData> subList, GroupTabIndex index)
        {
            if (!UIUtils.IsNull(subList))
            {
                Control last = null;

                int height = 125 + 10, width = 0;

                foreach (var sub in subList)
                {
                    sub.tabIndex = index;
                    sub.SubFolder = true;
                    HttpFolderData data = sub;


                    if (data.isPublic == 0 || isMember)
                    {
                        var item = CreateFolderItem(data);

                        // 绑定右键菜单
                        item.ContextMenuStrip = folderMenu;

                        // 绑定滚动事件
                        AddCrlMouseWheel(item);

                        width += item.Width + item.Margin.Left;
                        if (width > flowLayoutPanel1.Width)
                        {
                            width = item.Width + 8;
                            height += item.Height + Margin.Top;
                        }

                        item.MouseDown += Folder_MouseDown;
                        this.flowLayoutPanel1.Controls.Add(item);
                        last = item;
                    }
                }

                if (last != null)
                {
                    flowLayoutPanel1.SetFlowBreak(last, true);
                }

                return height;
            }

            return 0;
        }

        private void ShowNoticeList(HttpFolderData folder, int filter = 0)
        {
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Location = new Point();
            vScrollBar.SetProgress(0);

            // 显示子文件夹
            int height = ShowSubFolderList(folder.groupAlbumList, GroupTabIndex.notify);

            if (folder.Count > 0)
            {
                bool first = true;
                foreach (var data in folder.noticeList)
                {
                    if ((data.isPublic == 0 || isMember) && FilterData(data.isWatchDownload, data.isMemberDownload, filter))
                    {
                        var item = CreateNotifyItem(data, first);

                        // 绑定右键菜单
                        item.ContextMenuStrip = contextMenu;

                        // 绑定滚动事件
                        AddCrlMouseWheel(item);

                        height += (item.Height + item.Margin.Top);

                        item.MouseDown += Item_MouseDown;
                        this.flowLayoutPanel1.Controls.Add(item);

                        first = false;
                    }
                }
            }

            UpdateListHeight(height);
            flowLayoutPanel1.ResumeLayout();
        }

        private void ShowFileList(HttpFolderData folder, int filter = 0)
        {
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Location = new Point();
            vScrollBar.SetProgress(0);


            int height = ShowSubFolderList(folder.groupAlbumList, GroupTabIndex.files);

            int count = 0;
            if (folder.Count > 0)
            {
                foreach (var data in folder.groupShareList)
                {
                    if ((data.isPublic == 0 || isMember) && FilterData(data.isWatchDownload, data.isMemberDownload, filter))
                    {
                        var item = CreateFilesItem(data);

                        // 绑定右键菜单
                        item.ContextMenuStrip = contextMenu;

                        // 绑定滚动事件
                        AddCrlMouseWheel(item);

                        item.MouseDown += Item_MouseDown;
                        this.flowLayoutPanel1.Controls.Add(item);
                        count++;
                    }
                }
            }

            var height1 = CalcFixedHeight(GroupTabIndex.files, count);
            UpdateListHeight(height + height1);

            flowLayoutPanel1.ResumeLayout();
        }

        private void ShowVideoList(HttpFolderData folder, int filter = 0)
        {

            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Location = new Point();
            vScrollBar.SetProgress(0);

            int height = ShowSubFolderList(folder.groupAlbumList, GroupTabIndex.video);
            int row = 0;

            if (folder.Count > 0)
            {
                bool frist = true;
                foreach (var data in folder.groupShareList)
                {
                    if ((data.isPublic == 0 || isMember) && FilterData(data.isWatchDownload, data.isMemberDownload, filter))
                    {
                        // 解析时间
                        string timeText = TimeUtils.FromatTime(data.time, "yyyy-MM-dd");
                        if (!flowLayoutPanel1.Controls.ContainsKey(timeText))
                        {
                            var time = CreateVideoTimeLine(timeText, frist);
                            height += (time.Height + time.Margin.Top);

                            // 绑定滚动事件
                            AddCrlMouseWheel(time);
                            this.flowLayoutPanel1.Controls.Add(time);
                            row = 0;
                            frist = false;
                        }

                        // 创建视频控件
                        var item = CreateVideoItem(data);
                        // 绑定右键菜单
                        item.ContextMenuStrip = contextMenu;
                        // 绑定滚动事件
                        AddCrlMouseWheel(item);
                        item.MouseDown += Item_MouseDown;

                        // 添加到列表
                        this.flowLayoutPanel1.Controls.Add(item);

                        if (row % 3 == 0)
                        {
                            height += (item.Height + item.Margin.Top);
                        }
                        row++;
                    }
                }
            }

            UpdateListHeight(height);

            flowLayoutPanel1.ResumeLayout();
        }

        private void ShowActiveList(HttpFolderData folder, int filter = 0)
        {
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Location = new Point();
            vScrollBar.SetProgress(0);

            int height = ShowSubFolderList(folder.groupAlbumList, GroupTabIndex.active);

            int count = 0;
            if (folder.Count > 0)
            {
                foreach (var data in folder.activityList)
                {
                    if ((data.isPublic == 0 || isMember) && FilterData(data.isWatchDownload, data.isMemberDownload, filter))
                    {
                        Control item = CreateActiveItem(data, count < 2);

                        // 绑定右键菜单
                        item.ContextMenuStrip = contextMenu;

                        // 绑定滚动事件
                        AddCrlMouseWheel(item);

                        item.MouseDown += Item_MouseDown;
                        this.flowLayoutPanel1.Controls.Add(item);

                        count++;
                    }
                }
            }
            var height1 = CalcFixedHeight(GroupTabIndex.active, count);
            UpdateListHeight(height + height1);

            flowLayoutPanel1.ResumeLayout();
        }

        private void ShowImageList(HttpFolderData folder, int filter = 0)
        {
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Location = new Point();
            vScrollBar.SetProgress(0);


            int height1 = ShowSubFolderList(folder.groupAlbumList, GroupTabIndex.image);

            int height = 175, width = 0;

            if (folder.Count > 0)
            {
                foreach (var photo in folder.groupShareList)
                {
                    if ((photo.isPublic == 0 || isMember) && FilterData(photo.isWatchDownload, photo.isMemberDownload, filter))
                    {
                        var con = CreateImageItem(photo, height == 158);
                        flowLayoutPanel1.Controls.Add(con);

                        // 绑定右键菜单
                        con.ContextMenuStrip = contextMenu;

                        // 绑定滚动事件
                        AddCrlMouseWheel(con);

                        con.MouseDown += Item_MouseDown;

                        width += con.Width + 8;
                        if (width > flowLayoutPanel1.Width)
                        {
                            width = con.Width + 8;
                            height += 158;
                        }
                    }
                }
            }

            UpdateListHeight(height + height1);

            flowLayoutPanel1.ResumeLayout();
        }

        /// <summary>
        /// 数据过滤
        /// </summary>
        /// <param name="isWatchDownload"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool FilterData(int isWatchDownload, int isMemberDownload, int filter)
        {
            if (filter == 0)
            {
                return true;
            }
            else if (filter == 1)
            {
                if (GroupType == 2)
                {
                    return isWatchDownload == 0;
                }
                else
                {
                    return isMemberDownload == 0;
                }

            }
            else if (filter == 2)
            {
                if (GroupType == 2)
                {
                    // 不允许围观下载
                    return isWatchDownload == 1;
                }
                else if (GroupType == 1)
                {
                    // 群员 | 围观可下载
                    return isWatchDownload == 0 || isMemberDownload == 0;
                }
                else
                {
                    // 不允许群员下载
                    return isMemberDownload == 1;
                }
            }
            else
            {
                // 群员 | 围观不可下载
                return isWatchDownload == 1 && isMemberDownload == 1;
            }
        }

        #endregion



        #region 给子控件添加滚轮事件
        private void AddCrlMouseWheel(Control crl)
        {
            crl.MouseWheel += View_MouseWheel;

            AddCrlMouseWheelList(crl.Controls);
        }

        private void AddCrlMouseWheelList(Control.ControlCollection controls)
        {
            if (controls == null)
            {
                return;
            }

            foreach (Control item in controls)
            {

                AddCrlMouseWheel(item);
            }
        }


        /// <summary>
        /// 鼠标滚动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_MouseWheel(object sender, MouseEventArgs e)
        {

            if (flowLayoutPanel1.Height <= limitPanel.Height)
            {
                return;
            }

            int totleHeight = flowLayoutPanel1.Height - limitPanel.Height;


            int movey = e.Delta > 0 ? 40 : -40;

            if (flowLayoutPanel1.Location.Y + movey > 0)
            {
                movey = -flowLayoutPanel1.Location.Y;
            }
            else if (flowLayoutPanel1.Location.Y + movey < -totleHeight)
            {
                movey = Math.Abs(flowLayoutPanel1.Location.Y) - totleHeight;
            }


            // 移动panel
            ModifyLocation(flowLayoutPanel1, movey, false);

            // 同步滚动条
            var pro = Math.Abs(flowLayoutPanel1.Location.Y) / (float)totleHeight * 100;
            vScrollBar.SetProgress((int)pro);
        }


        /// <summary>
        /// 修改控件位置
        /// </summary>
        /// <param name="control"></param>
        /// <param name="loc_y"></param>
        /// <param name="abs">是否绝对坐标</param>
        private void ModifyLocation(Control control, int loc_y, bool abs = true)
        {
            Point point = control.Location;

            if (abs)
            {
                point.Y = loc_y;
            }
            else
            {
                point.Y = point.Y + loc_y;
            }

            control.Location = point;
        }

        private int last_progress;
        private Friend mFriend;

        private void VScrollBar_ScrollChangeListener()
        {
            if (vScrollBar.Value == last_progress)
            {
                return;
            }

            if (limitPanel.Height > flowLayoutPanel1.Height)
            {
                return;
            }


            last_progress = vScrollBar.Value;


            float max = flowLayoutPanel1.Height - limitPanel.Height;

            int movey = Convert.ToInt32(last_progress / 100f * max * -1);

            // 移动panel
            ModifyLocation(flowLayoutPanel1, movey, true);
        }

        #endregion

        #region 右键菜单

        private Control mSelectControl;
        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            mSelectControl = sender as Control;

            int isMemberDownload = 0;
            int isWatchDownload = 0;

            if (!isManager)
            {
                switch (mGroupTab)
                {
                    case GroupTabIndex.notify:

                        var notify = mSelectControl.Tag as MyGroupNotice;
                        isMemberDownload = notify.isMemberDownload;
                        isWatchDownload = notify.isWatchDownload;
                        break;
                    case GroupTabIndex.active:
                        var active = mSelectControl.Tag as MyGroupActivity;
                        isMemberDownload = active.isMemberDownload;
                        isWatchDownload = active.isWatchDownload;
                        break;
                    case GroupTabIndex.files:
                    case GroupTabIndex.video:
                    case GroupTabIndex.image:
                        var video = mSelectControl.Tag as GroupFilesx;
                        isMemberDownload = video.isMemberDownload;
                        isWatchDownload = video.isWatchDownload;
                        break;
                    default:
                        break;
                }
            }

            UpdateMenuStrip(ref contextMenu, mGroupTab, isMemberDownload, isWatchDownload);
        }

        private void UpdateMenuStrip(ref SkinContextMenuStrip contextMenuScript, GroupTabIndex type, int isMemberDownload, int isWatchDownload)
        {
            //  管理员  || 成员可以下载 || 围观可以下载
            bool download = isManager || (isMember && isMemberDownload == 0) || (isWatchDownload == 0);


            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                // 只有打开可用
                item.Enabled = item == menuItem_Open;
                item.Visible = true;
            }

            btnDataMove.Visible = isManager;
            if (isManager)
            {
                btnDataMove.Enabled = true;
                RefreshMoveSubMenu(btnDataMove, groupFuncTools1.ItemData.folderId, false);
            }

            menuItem_Collect.Enabled = download;
            AddMenuItemIcon(menuItem_Collect, download);

            if (download)
            {
                string roomType = GetFolderRoomType(type);
                CollectUtils.HttpCollectionList(roomType, menuItem_Collect, menuItem_Collect_Click);
            }

            switch (type)
            {
                case GroupTabIndex.notify:
                    menuItem_Copy.Enabled = download;
                    menuItem_Forward.Enabled = download;

                    AddMenuItemIcon(menuItem_Copy, download);
                    AddMenuItemIcon(menuItem_Forward, download);


                    menuItem_Open.Visible = false;
                    separator_one.Visible = false;
                    menuItem_SaveAs.Visible = false;
                    separator_three.Visible = false;

                    break;
                case GroupTabIndex.active:
                    menuItem_Forward.Enabled = download;
                    menuItem_Copy.Enabled = download;
                    AddMenuItemIcon(menuItem_Forward, download);
                    AddMenuItemIcon(menuItem_Copy, download);

                    menuItem_Open.Text = "查看";
                    separator_two.Visible = false;
                    menuItem_SaveAs.Visible = false;
                    separator_three.Visible = false;
                    break;
                case GroupTabIndex.files:

                    menuItem_Forward.Enabled = download;
                    menuItem_SaveAs.Enabled = download;

                    AddMenuItemIcon(menuItem_Forward, download);
                    AddMenuItemIcon(menuItem_SaveAs, download);

                    menuItem_Open.Text = "查看";
                    menuItem_Copy.Visible = false;
                    separator_two.Visible = false;
                    break;
                case GroupTabIndex.video:
                    menuItem_Forward.Enabled = download;
                    menuItem_SaveAs.Enabled = download;

                    AddMenuItemIcon(menuItem_Forward, download);
                    AddMenuItemIcon(menuItem_SaveAs, download);

                    menuItem_Open.Text = "静音播放";
                    menuItem_Copy.Visible = false;
                    separator_two.Visible = false;
                    break;
                case GroupTabIndex.image:

                    /*
                     群组右侧相册图标内的文件夹，
                    群成员仅有打开功能，
                    群主/管理员右键则：打开、新建、重命名。文件夹中的图片，

                    群员允许下载时，鼠标右键功能有：打开、复制、转发、保存、存表情、另存为；
                    不允许下载，则仅有打开功能。
                     */
                    menuItem_Open.Text = "打开";

                    separator_three.Visible = false;


                    menuItem_Forward.Enabled = download;
                    menuItem_SaveAs.Enabled = download;
                    menuItem_Copy.Enabled = download;

                    AddMenuItemIcon(menuItem_Copy, download);
                    AddMenuItemIcon(menuItem_Forward, download);
                    AddMenuItemIcon(menuItem_SaveAs, download);


                    break;
            }
        }

        public void AddMenuItemIcon(ToolStripMenuItem item, bool able)
        {
            item.Image = able ? null : Resources.ic_menu_disable;
        }

        // 打开
        private void menuItem_Open_Click(object sender, EventArgs e)
        {
            switch (mGroupTab)
            {
                case GroupTabIndex.files:
                    File_MouseClick(mSelectControl, null);
                    break;
                case GroupTabIndex.active:
                    Active_MouseClick(mSelectControl, null);
                    break;
                case GroupTabIndex.video:
                    Video_MouseClick(mSelectControl, null);
                    break;
                case GroupTabIndex.image:
                    Image_MouseClick(mSelectControl, null);
                    break;
            }
        }

        // 复制
        private void menuItem_Copy_Click(object sender, EventArgs e)
        {
            string url = mSelectControl.AccessibleDescription;
            string localPath = Applicate.LocalConfigData.FileFolderPath + mSelectControl.AccessibleName;

            switch (mGroupTab)
            {
                case GroupTabIndex.files:
                    url = mSelectControl.AccessibleDescription;
                    localPath = Applicate.LocalConfigData.FileFolderPath + mSelectControl.AccessibleName;
                    break;
                case GroupTabIndex.image:
                    url = Convert.ToString(mSelectControl.AccessibleDescription);
                    localPath = Applicate.LocalConfigData.ImageFolderPath + FileUtils.GetFileName(url);
                    break;
                case GroupTabIndex.video:
                    url = Convert.ToString(mSelectControl.AccessibleDescription);
                    localPath = Applicate.LocalConfigData.VideoFolderPath + FileUtils.GetFileName(url);
                    break;
                case GroupTabIndex.notify:
                    var notify = mSelectControl as GroupNotifyItem;
                    Clipboard.SetText(notify.itemData.text);
                    return;
                case GroupTabIndex.active:
                    var active = mSelectControl as GroupActiveItem;
                    Clipboard.SetText(string.Format("http://hr.tnshow.com/active.html?id={0}", active.itemData.id));
                    return;
                default:
                    return;
            }

            if (File.Exists(localPath))
            {
                StringCollection strcoll = new StringCollection { localPath };
                Clipboard.SetFileDropList(strcoll);
                HttpUtils.Instance.ShowTip("复制成功");
            }
            else
            {
                //下载文件
                DownloadEngine.Instance.DownUrl(url).SavePath(localPath)
                    .Down((path) =>
                    {
                        if (File.Exists(path))
                        {
                            StringCollection strcoll = new StringCollection { localPath };
                            Clipboard.SetFileDropList(strcoll);
                            HttpUtils.Instance.ShowTip("复制成功");
                        }
                    });
            }

        }

        // 转发
        private void menuItem_Forward_Click(object sender, EventArgs e)
        {
            MessageObject messageObject = null;

            switch (mGroupTab)
            {
                case GroupTabIndex.notify:
                    var notify = mSelectControl as GroupNotifyItem;
                    messageObject = ShiKuManager.SendTextMessage(new Friend(), notify.itemData.text, false, false);
                    break;
                case GroupTabIndex.files:
                    var file = mSelectControl as Items.GroupFileItem;
                    messageObject = ShiKuManager.SendFileMessage(new Friend(), file.itemData.oUrl, file.itemData.oFileName, file.itemData.size, false, false);
                    break;
                case GroupTabIndex.active:
                    return;
                case GroupTabIndex.video:
                    var video = mSelectControl as Items.GroupVideoItem;
                    messageObject = ShiKuManager.SendVideoMessage(new Friend(), video.itemData.resource.oUrl, video.itemData.title, video.itemData.resource.size, false, false);
                    break;
                case GroupTabIndex.image:
                    var url = Convert.ToString(mSelectControl.Tag);
                    messageObject = ShiKuManager.SendImageMessage(new Friend(), url, FileUtils.GetFileName(url), 0, false, false);
                    break;
            }

            //选择转发的好友
            var frmFriendSelect = new FrmSortSelect();
            frmFriendSelect.LoadFriendsData(true, true, true, true, true);
            frmFriendSelect.Show();
            frmFriendSelect.AddConfrmListener((UserFriends) =>
            {
                Invoke(new Action(() =>
                {
                    var frmSchedule = new FrmSchedule(UserFriends, (fd) =>
                    {
                        if (fd.IsGroup == 1)
                        {

                            RoomMember roomMember = new RoomMember { roomId = fd.RoomId, userId = Applicate.MyAccount.userId };
                            roomMember = roomMember.GetRoomMember();

                            if (roomMember.role == 3)
                            {
                                //是否全体禁言
                                string all = LocalDataUtils.GetStringData(fd.UserId + "BANNED_TALK_ALL" + Applicate.MyAccount.userId, "0");
                                //管理员和群主除外
                                if (!"0".Equals(all))
                                {
                                    // 全体禁言
                                    HttpUtils.Instance.ShowTip("不能转发消息到全体禁言群");
                                    return;
                                }

                                string single = LocalDataUtils.GetStringData(fd.UserId + "BANNED_TALK" + Applicate.MyAccount.userId, "0");
                                //是否单个禁言
                                if (!"0".Equals(single))
                                {
                                    HttpUtils.Instance.ShowTip("您已被禁止在此群发言");
                                    return;
                                }
                            }


                            if (roomMember.role == 4)
                            {
                                HttpUtils.Instance.ShowTip("您在此群为隐身人，不能发送消息");
                                return;
                            }
                        }

                        //如果为群组，自己为隐身人或者被禁言
                        MessageObject msg = ShiKuManager.SendForwardMessage(fd, messageObject);

                    }, false);
                    frmSchedule.Show();
                }
                ));

            });
        }

        // 收藏
        private void menuItem_Collect_Click(string folderId)
        {
            string text = string.Empty;
            string type = string.Empty;
            string url = string.Empty;

            switch (mGroupTab)
            {
                case GroupTabIndex.notify:
                    var notify = mSelectControl as Items.GroupNotifyItem;
                    type = "5";
                    url = "";
                    text = GroupCollectUtils.GetNotifyParams(notify.itemData);
                    break;
                case GroupTabIndex.active:
                    var active = mSelectControl as Items.GroupActiveItem;
                    type = "5";
                    url = "";
                    text = GroupCollectUtils.GetActiveParams(active.itemData);
                    break;
                case GroupTabIndex.files:
                    var file = mSelectControl as Items.GroupFileItem;
                    type = "3";
                    url = Convert.ToString(mSelectControl.AccessibleDescription);
                    text = GroupCollectUtils.GetFileParams(url, file.fileSize);
                    break;

                case GroupTabIndex.video:
                    type = "2";
                    url = Convert.ToString(mSelectControl.AccessibleDescription);
                    text = GroupCollectUtils.GetVideoParams(url, Convert.ToInt64(mSelectControl.AccessibleName));
                    break;
                case GroupTabIndex.image:
                    type = "1";
                    url = Convert.ToString(mSelectControl.AccessibleDescription);
                    text = GroupCollectUtils.GetImageParams(url);
                    break;
            }

            // 保存
            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "user/emoji/add")
                  .AddParams("access_token", Applicate.Access_Token)
                  .AddParams("emoji", text)
                  .AddParams("type", type)
                  .AddParams("url", url)
                  .AddParams("folderId", folderId)
                  .NoErrorTip()
                   .Build().AddErrorListener((code, err) =>
                   {
                       if (code == 0)
                       {
                           HttpUtils.Instance.ShowTip("不能重复保存消息");
                       }
                       else
                       {
                           HttpUtils.Instance.ShowTip(err);
                       }
                   })
                  .Execute((sccess, room) =>
                  {
                      if (sccess)
                      {
                          HttpUtils.Instance.ShowTip("保存成功");
                          // 更新保存页
                          Messenger.Default.Send("1", MessageActions.UPDATE_COLLECT_LIST);
                      }
                  });
        }

        #region 等待符

        /// <summary>
        /// 登录打开等待符
        /// </summary>
        private LodingUtils mLoding = null;

        private void ShowLoading()
        {
            if (mLoding == null)
            {
                mLoding = new LodingUtils();
                mLoding.size = new Size(50, 50);
                mLoding.parent = limitPanel;
                mLoding.start();
            }
        }

        private void StopLoading()
        {
            if (mLoding != null)
            {
                mLoding.stop();
                mLoding = null;
            }
        }

        #endregion

        // 另存为
        private void menuItem_SaveAs_Click(object sender, EventArgs e)
        {
            string url = "";
            string localPath = "";

            switch (mGroupTab)
            {
                case GroupTabIndex.notify:
                    return;
                case GroupTabIndex.active:
                    return;
                case GroupTabIndex.image:
                    url = Convert.ToString(mSelectControl.Tag);
                    localPath = Applicate.LocalConfigData.ImageFolderPath + FileUtils.GetFileName(url);
                    return;
                case GroupTabIndex.files:
                    url = mSelectControl.AccessibleDescription;
                    localPath = Applicate.LocalConfigData.FileFolderPath + mSelectControl.AccessibleName;
                    break;
                case GroupTabIndex.video:
                    url = mSelectControl.AccessibleDescription;
                    localPath = Applicate.LocalConfigData.VideoFolderPath + FileUtils.GetFileName(url);
                    break;
            }


            string filename = FileUtils.GetFileName(localPath);

            //选择文件夹路径
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "另存为..",
                FileName = filename,
                Filter = @"所有文件|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //文件的本地路径
                var savepage = dialog.FileName;
                if (string.IsNullOrEmpty(savepage))
                    return;

                if (File.Exists(localPath))
                {
                    var frm = this.FindForm() as FrmBase;
                    frm.ShowTip("另存为成功:" + savepage);
                    File.Copy(localPath, savepage, true);
                    return;
                }

                //下载文件
                DownloadEngine.Instance.DownUrl(url).SavePath(savepage)
                    .Down((path) =>
                    {
                        HttpUtils.Instance.ShowTip("另存为成功:" + path);
                    });
            }
        }


        // 移动至
        private void menuItem_MoveAs_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (mSelectControl is GroupFolderItem folder)
            {
                HttpMovetoFolder(folder.itemData.folderId, item.Name, Convert.ToString(folder.itemData.type), true);
            }
            else
            {
                // 群文件夹类型 1群文件 2群视频 3群图片 4：公告 5：活动 虚拟文件夹 1001群文件 1002群视频 1003群图片 1004：公告 1005：活动
                Control ui_item = mSelectControl as Control;
                if (ui_item.Tag is GroupFilesx filex)
                {
                    var type = GetFolderRoomType(mGroupTab);
                    HttpMovetoFolder(filex.shareId, item.Name, type, false);

                }
                else if (ui_item.Tag is MyGroupActivity active)
                {
                    HttpMovetoFolder(active.id, item.Name, "5", false);
                }
                else if (ui_item.Tag is MyGroupNotice notice)
                {
                    HttpMovetoFolder(notice.id, item.Name, "4", false);
                }
            }

        }


        /// <summary>
        /// 刷新资源项的
        /// </summary>
        public void RefreshMoveSubMenu(ToolStripMenuItem baseItem, string folderId, bool isFolder)
        {
            baseItem.DropDownItems.Clear();

            if (!UIUtils.IsNull(this.folderList))
            {
                foreach (var item in folderList)
                {
                    var sub = CreateSubMenuItem(item, folderId, isFolder);
                    if (sub != null)
                    {
                        baseItem.DropDownItems.Add(sub);

                        if (!isFolder && item.SubCount > 0)
                        {
                            foreach (var item1 in item.groupAlbumList)
                            {
                                var sub1 = CreateSubMenuItem(item1, folderId, isFolder);
                                if (sub1 != null)
                                {
                                    sub.DropDownItems.Add(sub1);
                                }
                            }
                        }
                    }
                }
            }
        }

        public ToolStripMenuItem CreateSubMenuItem(HttpFolderData data, string folderId, bool isFolder)
        {
            // 资源可以往空文件夹中移动
            if (UIUtils.IsNull(data.folderId))
            {
                return null;
            }

            ToolStripMenuItem mnuPrintPageSet = new ToolStripMenuItem(data.folderName);
            mnuPrintPageSet.Name = data.folderId;
            mnuPrintPageSet.Text = UIUtils.LimitTextLength(data.folderName, 20, true);
            mnuPrintPageSet.Click += menuItem_MoveAs_Click;
            return mnuPrintPageSet;
        }


        #endregion

        private void Folder_MouseDown(object sender, MouseEventArgs e)
        {
            mSelectControl = sender as Control;
            var item = sender as GroupFolderItem;

            bool ismove = item.itemData.SubFolder;

            foreach (ToolStripItem menu in folderMenu.Items)
            {
                switch (menu.Name)
                {
                    case "btnOpen":
                    case "toolStripSeparator1":
                    case "btnFolderDetail":
                        menu.Visible = true;
                        break;
                    case "btnCreate":
                    case "toolStripSeparator3":
                        menu.Visible = isManager && !ismove;
                        break;
                    case "btnMoveto":
                        menu.Visible = isManager && ismove;
                        break;
                    default:
                        menu.Visible = isManager;
                        break;
                }
            }


            if (isManager && ismove)
            {
                RefreshMoveSubMenu(btnMoveto, item.itemData.folderId, true);
            }
        }

        // 获取群公告
        private void HttpGroupNotice(string key = "", string joinFolder = "")
        {
            ShowLoading();

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/notice/list/v2")
                .AddParams("roomId", mFriend.RoomId)
                .AddParams("keyword", key)
                .AddParams("fileType", "1")
                .AddParams("pageIndex", "0")
                .AddParams("pageSize", "1000")
                .Build().ExecuteJson<List<HttpFolderData>>((sccess, dataList) =>
                {

                    if (sccess && dataList != null)
                    {
                        this.folderList = dataList;
                        if (UIUtils.IsNull(joinFolder))
                        {
                            ShowFolderList(dataList, GroupTabIndex.notify);
                        }
                        else
                        {
                            FindFolderById(dataList, joinFolder, GroupTabIndex.notify);
                        }
                    }
                    else
                    {
                        this.folderList = null;
                        UpdateListHeight(0);
                    }

                    StopLoading();
                });
        }

        // 获取群活动
        private void HttpGroupActivity(string key = "", string joinFolder = "")
        {
            ShowLoading();

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "community/getActivityList/v2")
                .AddParams("roomId", mFriend.RoomId)
                .AddParams("fileType", "1")
                .AddParams("keyword", key)
                .AddParams("pageIndex", "0")
                .AddParams("pageSize", "1000")
                .Build().ExecuteJson<List<HttpFolderData>>((sccess, dataList) =>
                {
                    if (sccess && dataList != null)
                    {
                        this.folderList = dataList;
                        if (UIUtils.IsNull(joinFolder))
                        {
                            ShowFolderList(dataList, GroupTabIndex.active);
                        }
                        else
                        {
                            FindFolderById(dataList, joinFolder, GroupTabIndex.active);
                        }

                    }
                    else
                    {
                        this.folderList = null;
                        UpdateListHeight(0);
                    }

                    StopLoading();
                });
        }

        // 获取群文件
        private void HttpGroupFiles(string key = "", string joinFolder = "")
        {
            ShowLoading();
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "community/getGroupShare/v2")
                .AddParams("roomId", mFriend.RoomId)
                .AddParams("type", "1")
                .AddParams("fileType", "1")
                .AddParams("keyword", key)
                .AddParams("pageIndex", "0")
                .AddParams("pageSize", "1000")
                .Build().ExecuteJson<List<HttpFolderData>>((sccess, dataList) =>
                {
                    if (sccess && dataList != null)
                    {
                        this.folderList = dataList;
                        if (UIUtils.IsNull(joinFolder))
                        {
                            ShowFolderList(dataList, GroupTabIndex.files);
                        }
                        else
                        {
                            FindFolderById(dataList, joinFolder, GroupTabIndex.files);
                        }
                    }
                    else
                    {
                        this.folderList = null;
                        UpdateListHeight(0);
                    }

                    StopLoading();
                });
        }

        // 获取群视频
        private void HttpGroupVideo(string key = "", string joinFolder = "")
        {
            ShowLoading();

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "community/getGroupShare/v2")
              .AddParams("roomId", mFriend.RoomId)
              .AddParams("type", "2")
              .AddParams("fileType", "1")
              .AddParams("keyword", key)
              .AddParams("pageIndex", "0")
              .AddParams("pageSize", "1000")
              .Build().ExecuteJson<List<HttpFolderData>>((sccess, dataList) =>
                {
                    if (sccess && UIUtils.IsNull(dataList))
                    {

                        if (!UIUtils.IsNull(joinFolder))
                        {
                            FindFolderById(dataList, joinFolder, GroupTabIndex.video);
                        }
                    }

                    this.folderList = dataList;
                    ShowFolderList(dataList, GroupTabIndex.video);

                    StopLoading();
                });
        }



        // 获取群图片
        private void HttpGroupPhoto(string joinFolder = "")
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "community/getGroupAlbum/v2")
                .AddParams("roomId", mFriend.RoomId)
                .AddParams("fileType", "1")
                .AddParams("pageIndex", "0")
                .AddParams("pageSize", "1000")
                .Build().ExecuteJson<List<HttpFolderData>>((sccess, dataList) =>
                {

                    if (sccess && dataList != null)
                    {
                        this.folderList = dataList;
                        if (!UIUtils.IsNull(joinFolder))
                        {
                            FindFolderById(dataList, joinFolder, GroupTabIndex.image);
                        }
                        else
                        {
                            ShowFolderList(dataList, GroupTabIndex.image);
                        }

                    }
                    else
                    {
                        this.folderList = null;
                        UpdateListHeight(0);
                    }

                    StopLoading();
                });
        }

        private void FindFolderById(List<HttpFolderData> dataList, string joinFolder, GroupTabIndex tab)
        {
            foreach (var item in dataList)
            {
                if (item.folderId == joinFolder)
                {
                    item.tabIndex = tab;
                    var view = new GroupFolderItem();
                    view.SetContentData(item);
                    Folder_MouseClick(view, null);
                    return;
                }

                if (!UIUtils.IsNull(item.groupAlbumList))
                {
                    foreach (var album in item.groupAlbumList)
                    {
                        if (album.folderId == joinFolder)
                        {
                            album.tabIndex = tab;
                            var view = new GroupFolderItem();
                            view.SetContentData(album);
                            Folder_MouseClick(view, null);
                        }
                    }
                }
            }
        }

        #region 工具栏事件

        private void GroupFuncTools_BackClick(object sender, EventArgs e)
        {
            if (groupFuncTools1.ItemData.SubFolder)
            {
                var item = new GroupFolderItem();
                item.SetContentData(groupFuncTools1.BaseData);
                Folder_MouseClick(item, null);
            }
            else
            {
                SwitchGroupPage(mGroupTab);
            }
        }

        private void GroupFuncTools_FilterClick(object sender, EventArgs e)
        {
            var folder = groupFuncTools1.ItemData;
            // 显示数据
            if (folder.Count > 0)
            {
                if (folder.tabIndex == GroupTabIndex.notify)
                {
                    ShowNoticeList(folder, groupFuncTools1.Filter);
                }
                else if (folder.tabIndex == GroupTabIndex.files)
                {
                    ShowFileList(folder, groupFuncTools1.Filter);
                }
                else if (folder.tabIndex == GroupTabIndex.video)
                {
                    ShowVideoList(folder, groupFuncTools1.Filter);
                }
                else if (folder.tabIndex == GroupTabIndex.active)
                {
                    ShowActiveList(folder, groupFuncTools1.Filter);
                }
                else if (folder.tabIndex == GroupTabIndex.image)
                {
                    ShowImageList(folder, groupFuncTools1.Filter);
                }
            }
        }

        private void GroupFuncTools_CreateFolderClick(object sender, EventArgs e)
        {
            if (Applicate.GetWindow<FrmMyColleagueEidt>() != null)
            {
                Applicate.GetWindow<FrmMyColleagueEidt>().Activate();
                Applicate.GetWindow<FrmMain>().ShowTip("窗口已打开");
                return;
            }

            // 父级文件id
            string folderId = "";
            if (groupFuncTools1.Visible && groupFuncTools1.ItemData != null)
            {
                folderId = groupFuncTools1.ItemData.folderId;
            }

            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            frm.maxLength = 20;
            frm.ColleagueName((text) =>
            {
                HttpCreateFolder(text, mGroupTab, folderId);
                frm.Close();
            });
            string title = "创建文件夹";
            string name = "文件夹名称:";

            var baseFrm = this.FindForm();
            frm.Location = new Point((baseFrm.Location.X + (baseFrm.Width - frm.Width) / 2), baseFrm.Location.Y + (baseFrm.Height - frm.Height) / 2);
            frm.ShowThis(title, name);
        }

        private void GroupFuncTools_SearchEvent(string text)
        {
            if (UIUtils.IsNull(text))
            {
                var item = new GroupFolderItem();
                item.SetContentData(groupFuncTools1.ItemData);
                Folder_MouseClick(item, null);
            }
            else
            {
                flowLayoutPanel1.Location = new Point();
                vScrollBar.SetProgress(0);

                flowLayoutPanel1.SuspendLayout();

                foreach (Control item in flowLayoutPanel1.Controls)
                {
                    string str = string.Concat(item.AccessibleDescription, item.AccessibleName);
                    if (!str.Contains(text))
                    {
                        item.Visible = false;
                    }
                }

                flowLayoutPanel1.ResumeLayout();
            }
        }

        #endregion

        #region 文件夹菜单项

        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            Folder_MouseClick(mSelectControl, null);
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // 创建同级文件夹
            GroupFuncTools_CreateFolderClick(sender, e);
        }


        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (Applicate.GetWindow<FrmMyColleagueEidt>() != null)
            {
                Applicate.GetWindow<FrmMyColleagueEidt>().Activate();
                Applicate.GetWindow<FrmMain>().ShowTip("窗口已打开");
                return;
            }

            var item = mSelectControl as GroupFolderItem;
            var data = item.itemData;
            var baseFrm = FindForm() as FrmBase;


            if (UIUtils.IsNull(data.folderId))
            {
                baseFrm.ShowTip("不能修改默认文件夹的名称");
                return;
            }

            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            frm.maxLength = 20;
            frm.ColleagueName((text) =>
            {
                HttpUpdateFolder(data.folderId, text, mGroupTab);
                frm.Close();
            });
            string title = "修改文件夹";
            string name = "文件夹名称";
            frm.Location = new Point((baseFrm.Location.X + (baseFrm.Width - frm.Width) / 2), baseFrm.Location.Y + (baseFrm.Height - frm.Height) / 2);
            frm.ShowThis(title, name, data.folderName);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var item = mSelectControl as GroupFolderItem;
            var data = item.itemData;
            var frm = FindForm() as FrmBase;

            if (UIUtils.IsNull(data.folderId))
            {
                frm.ShowTip("默认文件夹不能删除");
                return;
            }

            var text = string.Format("确定要删除{0}文件夹和文件夹中的所有内容吗?", data.folderName);
            if (frm.ShowPromptBox(text))
            {
                HttpDeleteFolder(data.folderId, mGroupTab);
            }
        }


        /// <summary>
        /// 文件夹属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFolderDetail_Click(object sender, EventArgs e)
        {
            var item = mSelectControl as GroupFolderItem;

            var frm = Applicate.GetWindow<FrmDetailsFolder>();
            if (frm == null)
            {
                frm = new FrmDetailsFolder();
                frm.SetContentData(item, GroupType);
                frm.Show();
            }
            else
            {
                frm.SetContentData(item, GroupType);
                frm.Show();
            }
        }
        #endregion

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="floderId">父文件夹的ID</param>
        /// <param name="floderName"></param>
        /// <param name="roomType">群文件夹类型 1群文件 2群视频 3群图片 4：公告 5：活动  虚拟文件夹 1001群文件 1002群视频 1003群图片 1004：公告 1005：活动 </param>
        /// <param name=""></param>
        private void HttpCreateFolder(string floderName, GroupTabIndex index, string floderId = "")
        {
            //  [{"shareId":"","folderId":"","folderName":"文件夹1","roomType":1，"parentFolderId":"61a08ef5bbc4e31bfbe97622","opType":1}]
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("opType", "1");
            data.Add("folderName", floderName);
            data.Add("roomType", GetFolderRoomType(index));

            if (!UIUtils.IsNull(floderId))
            {
                data.Add("parentFolderId", floderId);
            }

            string text = string.Format("[{0}]", JsonConvert.SerializeObject(data));
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "community/updateFolder/v2")
                .AddParams("roomId", mFriend.RoomId)
                .AddParams("folders", text)
                .Build().Execute((sccess, dataList) =>
                {
                    if (sccess)
                    {
                        // 创建项
                        var baseFrm = this.FindForm() as FrmBase;
                        baseFrm.ShowTip("创建文件夹成功");

                        // 刷新页面
                        switch (mGroupTab)
                        {
                            case GroupTabIndex.notify:
                                HttpGroupNotice(joinFolder: floderId);
                                break;
                            case GroupTabIndex.files:
                                HttpGroupFiles(joinFolder: floderId);
                                break;
                            case GroupTabIndex.active:
                                HttpGroupActivity(joinFolder: floderId);
                                break;
                            case GroupTabIndex.image:
                                HttpGroupPhoto(joinFolder: floderId);
                                break;
                            case GroupTabIndex.video:
                                HttpGroupVideo(joinFolder: floderId);
                                break;
                            default:
                                break;
                        }


                    }
                });
        }

        /// <summary>
        /// 修改文件夹名称
        /// </summary>
        /// <param name="floderName"></param>
        /// <param name="floderId"></param>
        /// <param name="index"></param>
        private void HttpUpdateFolder(string floderId, string floderName, GroupTabIndex index)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("opType", "2");
            data.Add("folderName", floderName);
            data.Add("roomType", GetFolderRoomType(index));
            data.Add("folderId", floderId);

            string text = string.Format("[{0}]", JsonConvert.SerializeObject(data));
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "community/updateFolder/v2")
                .AddParams("roomId", mFriend.RoomId)
                .AddParams("folders", text)
                .Build().Execute((sccess, dataList) =>
                {
                    if (sccess)
                    {
                        if (flowLayoutPanel1.Controls.ContainsKey(floderId))
                        {
                            var item = flowLayoutPanel1.Controls[floderId] as GroupFolderItem;
                            item.itemData.folderName = floderName;
                            item.SetContentData(item.itemData);
                        };

                        var baseFrm = this.FindForm() as FrmBase;
                        baseFrm.ShowTip("修改成功");
                    }
                });
        }



        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="floderId"></param>
        /// <param name="type"></param>
        private void HttpDeleteFolder(string floderId, GroupTabIndex index)
        {
            // 删除文件夹
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "community/deleteFolder/v2")
                .AddParams("roomId", mFriend.RoomId)
                .AddParams("type", GetFolderRoomType(index))
                .AddParams("folderId", floderId)
                .Build().Execute((sccess, dataList) =>
                {
                    if (sccess)
                    {

                        if (flowLayoutPanel1.Controls.ContainsKey(floderId))
                        {
                            var item = flowLayoutPanel1.Controls[floderId];
                            flowLayoutPanel1.Controls.Remove(item);
                        };

                        var baseFrm = this.FindForm() as FrmBase;
                        baseFrm.ShowTip("删除成功");
                    }
                });
        }


        /// <summary>
        /// 移动文件夹
        /// </summary>
        /// <param name="floderId"></param>
        /// <param name="type"></param>
        private void HttpMovetoFolder(string fromId, string toId, string type, bool isFolderMove)
        {
            var baseFrm = this.FindForm() as FrmBase;

            if (fromId == toId)
            {
                baseFrm.ShowTip("无法移动到相同的文件夹");
                return;
            }

            if (GroupType != 1 && isFolderMove && !baseFrm.ShowPromptBox("该文件夹和文件夹中的内容将会一起被移动，是否确定移动。"))
            {
                return;
            }

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("opType", isFolderMove ? "4" : "3");
            data.Add(isFolderMove ? "parentFolderId" : "folderId", toId);
            data.Add(isFolderMove ? "folderId" : "shareId", fromId);
            data.Add("roomType", type);

            string text = string.Format("[{0}]", JsonConvert.SerializeObject(data));

            // 移动文件夹
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "community/updateFolder/v2")
                .AddParams("roomId", mFriend.RoomId)
                .AddParams("folders", text)
                .Build().Execute((sccess, dataList) =>
                {
                    if (sccess)
                    {
                        // 创建项
                        var frm = this.FindForm() as FrmBase;
                        if (isFolderMove)
                        {
                            frm.ShowTip("文件夹移动成功");
                        }
                        else
                        {
                            frm.ShowTip("数据移动成功");
                        }

                        string floderId = groupFuncTools1.ItemData.folderId;
                        // 刷新页面
                        switch (mGroupTab)
                        {
                            case GroupTabIndex.notify:
                                HttpGroupNotice(joinFolder: floderId);
                                break;
                            case GroupTabIndex.files:
                                HttpGroupFiles(joinFolder: floderId);
                                break;
                            case GroupTabIndex.active:
                                HttpGroupActivity(joinFolder: floderId);
                                break;
                            case GroupTabIndex.image:
                                HttpGroupPhoto(joinFolder: floderId);
                                break;
                            case GroupTabIndex.video:
                                HttpGroupVideo(joinFolder: floderId);
                                break;
                            default:
                                break;
                        }
                    }
                });
        }


        private string GetFolderRoomType(GroupTabIndex index)
        {
            //roomType 群文件夹类型 1群文件 2群视频 3群图片 4：公告 5：活动  虚拟文件夹 1001群文件 1002群视频 1003群图片 1004：公告 1005：活动 
            switch (index)
            {
                case GroupTabIndex.notify:
                    return "4";
                case GroupTabIndex.active:
                    return "5";
                case GroupTabIndex.files:
                    return "1";
                case GroupTabIndex.video:
                    return "2";
                case GroupTabIndex.image:
                    return "3";
                default:
                    return "0";
            }

        }


    }
}

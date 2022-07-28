using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Helper;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;
using WinFrmTalk.View;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    public partial class GroupPageMain : UserControl
    {
        private bool isManager;
        private bool isMember;
        private List<Control> ItemList = new List<Control>();
        private int ItemIndex;

        private Control leftArrow;
        private Control rightArrow;

        public GroupPageMain()
        {
            InitializeComponent();

            rightArrow = CreateRightArrow();
            leftArrow = CreateLeftArrow();
        }

        #region 创建页面项

        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="url"></param>
        private Control CreateImageControl(Information information)
        {
            PictureBox item = new PictureBox();
            item.Dock = DockStyle.Fill;
            item.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            item.ContextMenuStrip = this.contextMenu;
            item.Name = "image";
            item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            item.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Banner_MouseClick);
            item.SizeMode = PictureBoxSizeMode.Zoom;

            item.Tag = information;
            item.AccessibleName = information.title;
            item.AccessibleDescription = information.url;
            ImageLoader.Instance.DisplayImage(information.url, item);

            item.MouseDown += Item_MouseDown;
            return item;
        }

        /// <summary>
        /// 显示视频
        /// </summary>
        /// <param name="url"></param>
        private Control CreateVideoControl(Information information, bool full)
        {
            ImageViewxVideo item = new ImageViewxVideo();
            item.Dock = DockStyle.Fill;
            item.BackColor = full ? Color.FromArgb(51, 51, 51) : Color.White;
            item.BorderSize = full ? 0 : 47;
            item.StretchMode = true;
            item.ContextMenuStrip = this.contextMenu;
            item.Name = "video";
            item.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Video_MouseClick);
            item.Tag = information;
            item.AccessibleName = information.title;
            item.AccessibleDescription = information.url;
            ThubImageLoader.Instance.LoadImage(information.url, item);

            item.MouseDown += Item_MouseDown;
            return item;
        }


        /// <summary>
        /// 显示公告
        /// </summary>
        /// <param name="text"></param>
        private Control CreateNotifyControl(Information information, bool full)
        {
            var item = new GroupPageNotify();
            item.BackColor = Color.WhiteSmoke;
            item.Width = dataLayout.Width;
            item.Height = dataLayout.Height;
            item.Dock = DockStyle.Fill;
            item.ContextMenuStrip = this.contextMenu;
            item.Name = "notify";

            item.SetControlData(information, full);

            item.Tag = information;
            item.AccessibleName = information.title;

            item.MouseDown += Item_MouseDown;
            return item;

        }

        /// <summary>
        /// 显示文件
        /// </summary>
        /// <param name="url"></param>
        private Control CreateFileControl(Information information)
        {
            var item = new GroupPageFile();
            item.Dock = DockStyle.Fill;
            item.BackColor = Color.WhiteSmoke;
            item.ContextMenuStrip = this.contextMenu;
            item.Name = "file";
            item.MouseClick += new System.Windows.Forms.MouseEventHandler(this.File_MouseClick);

            item.SetControlData(information);

            item.Tag = information;
            item.AccessibleName = information.title;
            item.AccessibleDescription = information.url;

            item.MouseDown += Item_MouseDown;
            return item;

        }

        private Control GetItemControl(int type, Information data, bool full = false)
        {
            Control item = null;
            // 1文件 2视频 3群图片 4公告 5活动
            switch (type)
            {
                case 1:
                    item = CreateFileControl(data);
                    break;
                case 2:
                    item = CreateVideoControl(data, full);
                    break;
                case 3:
                    item = CreateImageControl(data);
                    break;
                case 4:
                case 0:
                    item = CreateNotifyControl(data, full);
                    break;

                default:
                    return null;
            }
            return item;
        }
        #endregion



        /// <summary>
        /// 显示空页面
        /// </summary>
        public void ShowEmptyPage()
        {
            dataLayout.Controls.Clear();

            var item = new Label();
            item.AutoSize = false;
            item.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            item.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            item.Name = "item";
            item.Size = new System.Drawing.Size(74, 21);
            item.Text = "暂无内容";
            item.Location = new Point((dataLayout.Width - 74) / 2, (dataLayout.Height - 21) / 2);
            item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            dataLayout.Controls.Add(item);

            ArrowVisiable(false, false);
        }


        /// <summary>
        /// 填充界面数据
        /// </summary>
        /// <param name="infoList"></param>
        /// <param name="friend"></param>
        internal void SetContentData(List<GroupTopInfo> infoList, Friend friend)
        {
            isManager = friend.Role == "1" || friend.Role == "2";
            isMember = friend.Role != "-1";

            dataLayout.Controls.Clear();
            ItemList.Clear();

            if (!UIUtils.IsNull(infoList))
            {
                foreach (var data in infoList)
                {
                    Control item = GetItemControl(data.information.type, data.information);

                    if (!isMember && data.information.isPublic == 1)
                    {
                        break;
                    }

                    dataLayout.Controls.Add(item);

                    if (item != null)
                    {
                        ItemList.Add(item);
                    }
                }
            }

            if (dataLayout.Controls.Count == 0)
            {
                // 显示空界面
                ShowEmptyPage();
                return;
            }
            else if (dataLayout.Controls.Count > 1)
            {
                ItemList.Reverse();
                ItemIndex = dataLayout.Controls.Count - 1;

                ArrowVisiable(true, true, ItemList[ItemIndex]);
            }
            else
            {
                ArrowVisiable(false, false);
            }
        }


        /// <summary>
        /// 填充界面数据
        /// </summary>
        /// <param name="infoList"></param>
        /// <param name="friend"></param>
        internal void SetContentData(GroupNewsInfo roomnews, Friend friend)
        {
            isManager = friend.Role == "1" || friend.Role == "2";
            isMember = friend.Role != "-1";

            if (roomnews == null)
            {
                // 显示空界面
                ShowEmptyPage();
                return;
            }


            if (!isMember && roomnews.information.isPublic == 1)
            {
                // 显示空界面
                ShowEmptyPage();
                return;
            }

            dataLayout.Controls.Clear();
            Control item = GetItemControl(roomnews.type, roomnews.information, true);
            //item.BackColor = Color.WhiteSmoke;
            dataLayout.Controls.Add(item);

            if (dataLayout.Controls.Count == 0)
            {
                // 显示空界面
                ShowEmptyPage();
            }
            else
            {
                ArrowVisiable(false, false);
            }


            ItemList.Clear();
        }




        #region 创建左右按钮


        private Control CreateRightArrow()
        {
            var arrow = new PictureBox();
            // arrow.Alpha = 100;
            arrow.Image = Resources.ic_group_arrow_right;
            arrow.SizeMode = PictureBoxSizeMode.Zoom;
            // arrow.TransparentBG = true;
            arrow.Size = new Size(27, 78);
            arrow.Location = new Point(this.Width - 17, (this.Height - 78) / 2);
            arrow.MouseClick += Right_MouseClick;
            arrow.Visible = false;
            this.Controls.Add(arrow);

            return arrow;
        }


        private Control CreateLeftArrow()
        {
            var arrow = new PictureBox();
            // arrow.Alpha = 100;
            arrow.Image = Resources.ic_group_arrow_left;
            arrow.SizeMode = PictureBoxSizeMode.Zoom;
            arrow.Size = new Size(27, 78);
            arrow.Location = new Point(10, (this.Height - 78) / 2);
            arrow.MouseClick += Left_MouseClick;
            arrow.Visible = false;
            this.Controls.Add(arrow);

            return arrow;
        }

        private void Right_MouseClick(object sender, MouseEventArgs e)
        {
            if (ItemList.Count > 1)
            {
                ItemIndex++;

                if (ItemIndex >= ItemList.Count)
                {
                    ItemIndex = 0;
                }

                ItemList[ItemIndex].BringToFront();

                ArrowVisiable(true, true, ItemList[ItemIndex]);
            }


        }

        private void Left_MouseClick(object sender, MouseEventArgs e)
        {
            if (ItemList.Count > 1)
            {
                ItemIndex--;

                if (ItemIndex < 0)
                {
                    ItemIndex = ItemList.Count - 1;
                }

                ItemList[ItemIndex].BringToFront();

                ArrowVisiable(true, true, ItemList[ItemIndex]);
            }
        }

        private void ArrowVisiable(bool left, bool right, Control arrow = null)
        {
            leftArrow.Visible = left;
            rightArrow.Visible = right;

            if (left)
            {
                leftArrow.Parent = arrow;
                leftArrow.BringToFront();

            }

            if (right)
            {
                rightArrow.Parent = arrow;
                rightArrow.BringToFront();
            }
        }

        #endregion

        /// <summary>
        /// 隐藏最新消息面板
        /// 用于聊天界面,切换到群话题
        /// </summary>
        internal void HideNewsControl()
        {
            this.SuspendLayout();
            bottomLayout.Visible = false;
            dataLayout.Size = this.Size;
            this.ResumeLayout();
        }

        #region 右键菜单

        private Control mSelectControl;
        private void Item_MouseDown(object sender, MouseEventArgs e)
        {

            if (sender is RichTextBox)
            {
                Control item = sender as Control;
                mSelectControl = item.Parent;
            }
            else
            {
                mSelectControl = sender as Control;
            }


            if (e.Button == MouseButtons.Right)
            {
                var itemData = mSelectControl.Tag as Information;

                int isMemberDownload = itemData.isMemberDownload;
                int isWatchDownload = itemData.isWatchDownload;
                int mGroupTab = itemData.type;

                UpdateMenuStrip(ref contextMenu, mGroupTab, isMemberDownload, isWatchDownload);
            }
        }

        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //UpdateMenuStrip(ref this.contextMenu);
        }

        private void UpdateMenuStrip(ref SkinContextMenuStrip contextMenuScript, int type, int isMemberDownload, int isWatchDownload)
        {
            //  管理员  || 成员可以下载 || 围观可以下载
            bool download = isManager || (isMember && isMemberDownload == 0) || (isWatchDownload == 0);

            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                // 只有打开可用
                item.Enabled = item == menuItem_Open;
                item.Visible = true;
            }

            switch (type)
            {
                case 2:
                    menuItem_Open.Text = "静音播放";
                    separator_two.Visible = false;
                    menuItem_Copy.Visible = false;

                    menuItem_Forward.Enabled = download;
                    menuItem_SaveAs.Enabled = download;
                    menuItem_Collect.Enabled = download;
                    break;
                case 3:
                    menuItem_Open.Text = "存表情";

                    menuItem_Forward.Enabled = download;
                    menuItem_SaveAs.Enabled = download;
                    menuItem_Collect.Enabled = download;
                    break;
                case 4:
                    menuItem_Open.Visible = false;
                    separator_one.Visible = false;

                    menuItem_Forward.Enabled = download;
                    menuItem_SaveAs.Enabled = download;
                    menuItem_Collect.Enabled = download;
                    break;
                default:
                    menuItem_Open.Text = "打开";
                    break;
            }
        }



        /// <summary>
        /// 打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Open_Click(object sender, EventArgs e)
        {
            var itemData = mSelectControl.Tag as Information;

            // 1文件 2视频 3群图片 4公告 5活动


            if (itemData.type == 1)
            {
                File_MouseClick(sender, null);
            }
            else if (itemData.type == 3)
            {
                Image_SaveExpression();
            }
            else
            {
                Video_MouseClick(sender, null);
            }
        }

        public void OpenFile(string url, string localPath)
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

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Copy_Click(object sender, EventArgs e)
        {

            //if (tvContent.Visible)
            //{
            //    Clipboard.SetText(tvContent.Text);
            //}
            //else
            //{
            //    string url = "";
            //    string localPath = "";
            //    if (filePanel.Visible)
            //    {
            //        url = tvFileName.AccessibleDescription;
            //        localPath = Applicate.LocalConfigData.FileFolderPath + tvFileName.Text;
            //    }
            //    else if (ivBanner.Visible)
            //    {
            //        url = ivBanner.AccessibleDescription;
            //        localPath = Applicate.LocalConfigData.ImageFolderPath + FileUtils.GetFileName(url);
            //    }
            //    else
            //    {
            //        url = ivVideo.AccessibleDescription;
            //        localPath = Applicate.LocalConfigData.VideoFolderPath + FileUtils.GetFileName(url);
            //    }


            //    if (!File.Exists(localPath))
            //    {
            //        StringCollection strcoll = new StringCollection { localPath };
            //        Clipboard.SetFileDropList(strcoll);
            //        HttpUtils.Instance.ShowTip("复制成功");
            //    }
            //    else
            //    {
            //        //下载文件
            //        DownloadEngine.Instance.DownUrl(url).SavePath(localPath)
            //            .Down((path) =>
            //            {
            //                StringCollection strcoll = new StringCollection { localPath };
            //                Clipboard.SetFileDropList(strcoll);
            //                HttpUtils.Instance.ShowTip("复制成功");
            //            });
            //    }
            //}
        }

        /// <summary>
        /// 转发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Forward_Click(object sender, EventArgs e)
        {
            MessageObject messageObject = null;
            //if (tvContent.Visible)
            //{
            //    messageObject = ShiKuManager.SendTextMessage(new Friend(), tvContent.Text, false, false);
            //}
            //else
            //{
            //    if (filePanel.Visible)
            //    {
            //        string url = tvFileName.AccessibleDescription;
            //        string name = tvFileName.Text;
            //        messageObject = ShiKuManager.SendFileMessage(new Friend(), url, name, 0, false, false);
            //    }
            //    else if (ivBanner.Visible)
            //    {

            //        string url = ivBanner.AccessibleDescription;
            //        string name = FileUtils.GetFileName(url);
            //        messageObject = ShiKuManager.SendImageMessage(new Friend(), url, name, 0, false, false);
            //    }
            //    else
            //    {

            //        string url = ivVideo.AccessibleDescription;
            //        string name = FileUtils.GetFileName(url);
            //        messageObject = ShiKuManager.SendVideoMessage(new Friend(), url, name, 0, false, false);
            //    }
            //}

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
        private void menuItem_Collect_Click(object sender, EventArgs e)
        {
            string text = string.Empty;
            string type = string.Empty;
            string url = string.Empty;


            //if (filePanel.Visible)
            //{
            //    url = tvFileName.AccessibleDescription;
            //    type = "3";
            //    text = GroupCollectUtils.GetFileParams(url, information.size);
            //}
            //else if (ivBanner.Visible)
            //{
            //    url = ivBanner.AccessibleDescription;
            //    type = "1";
            //    text = GroupCollectUtils.GetImageParams(url);
            //}
            //else
            //{

            //    url = ivVideo.AccessibleDescription;
            //    type = "2";
            //    text = GroupCollectUtils.GetVideoParams(url, information.size);
            //}

            //switch (mGroupTab)
            //{
            //    case GroupTabIndex.notify:
            //        var notify = mSelectControl as Items.GroupNotifyItem;
            //        type = "5";
            //        url = "";
            //        text = GroupCollectUtils.GetNotifyParams(notify.itemData);
            //        break;
            //    case GroupTabIndex.active:
            //        var active = mSelectControl as Items.GroupActiveItem;
            //        type = "5";
            //        url = "";
            //        text = GroupCollectUtils.GetActiveParams(active.itemData);
            //        break;
            //    case GroupTabIndex.files:
            //        var file = mSelectControl as Items.GroupFileItem;
            //        type = "3";
            //        url = Convert.ToString(mSelectControl.AccessibleDescription);
            //        text = GroupCollectUtils.GetFileParams(url);
            //        break;

            //    case GroupTabIndex.video:
            //        type = "2";
            //        url = Convert.ToString(mSelectControl.AccessibleDescription);
            //        text = GroupCollectUtils.GetVideoParams(url);
            //        break;
            //    case GroupTabIndex.image:
            //        type = "1";
            //        url = Convert.ToString(mSelectControl.AccessibleDescription);
            //        text = GroupCollectUtils.GetImageParams(url);
            //        break;
            //}

            // 保存
            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "user/emoji/add")
                  .AddParams("access_token", Applicate.Access_Token)
                  .AddParams("emoji", text)
                  .AddParams("type", type)
                  .AddParams("url", url)
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




        private void menuItem_SaveAs_Click(object sender, EventArgs e)
        {
            string url = "";
            string localPath = "";
            //if (filePanel.Visible)
            //{
            //    url = tvFileName.AccessibleDescription;
            //    localPath = Applicate.LocalConfigData.FileFolderPath + tvFileName.Text;
            //}
            //else if (ivBanner.Visible)
            //{
            //    url = ivBanner.AccessibleDescription;
            //    localPath = Applicate.LocalConfigData.ImageFolderPath + FileUtils.GetFileName(url);
            //}
            //else
            //{
            //    url = ivVideo.AccessibleDescription;
            //    localPath = Applicate.LocalConfigData.VideoFolderPath + FileUtils.GetFileName(url);
            //}

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


        #endregion

        private void Video_MouseClick(object sender, MouseEventArgs e)
        {

            var itemData = mSelectControl.Tag as Information;
            int isMemberDownload = itemData.isMemberDownload;
            int isWatchDownload = itemData.isWatchDownload;

            if (!isMember && isWatchDownload == 1)
            {
                var frm = this.FindForm() as FrmBase;
                frm.ShowTip("围观不能查看视频");
                return;
            }

            var messageObject = new MessageObject() { content = mSelectControl.AccessibleDescription };
            FrmVideoFlash frmVideoFlash = FrmVideoFlash.CreateInstrance();
            frmVideoFlash.noVolumn = e == null;
            frmVideoFlash.VidoShowList(messageObject);
            frmVideoFlash.Show();
        }

        /// <summary>
        /// 打开图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Banner_MouseClick(object sender, MouseEventArgs e)
        {
            var itemData = mSelectControl.Tag as Information;
            int isMemberDownload = itemData.isMemberDownload;
            int isWatchDownload = itemData.isWatchDownload;

            if (!isMember && isWatchDownload == 1)
            {
                var frm = this.FindForm() as FrmBase;
                frm.ShowTip("围观不能查看图片");
                return;
            }

            var url = mSelectControl.AccessibleDescription;
            var look = new FrmLookImage();
            look.pictureBox1_SetImage(url, false);
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void File_MouseClick(object sender, MouseEventArgs e)
        {

            var itemData = mSelectControl.Tag as Information;
            int isMemberDownload = itemData.isMemberDownload;
            int isWatchDownload = itemData.isWatchDownload;

            if (!isMember && isWatchDownload == 1)
            {
                var frm = this.FindForm() as FrmBase;
                frm.ShowTip("围观不能查看文件");
                return;
            }


            string url = mSelectControl.AccessibleDescription;
            string localPath = Applicate.LocalConfigData.FileFolderPath + FileUtils.GetFileName(url);
            OpenFile(url, localPath);
        }



        /// <summary>
        /// 存表情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_SaveExpression()
        {
            if (!isMember)
            {
                var frm = this.FindForm() as FrmBase;
                frm.ShowTip("围观不能查看文件");
                return;
            }


            var msg = new MessageObject();
            msg.messageId = Guid.NewGuid().ToString("N");//生成Guid
            msg.type = kWCMessageType.Image;
            msg.content = mSelectControl.AccessibleDescription;

            CollectUtils.CollectExpression(msg);
        }

        private void dataLayout_SizeChanged(object sender, EventArgs e)
        {
            rightArrow.Location = new Point(dataLayout.Width - 37, (dataLayout.Height - 50) / 2);
            leftArrow.Location = new Point(10, (dataLayout.Height - 50) / 2);
        }
    }
}

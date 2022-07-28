﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;
using WinFrmTalk.Model.dao;
using WinFrmTalk.View;

namespace WinFrmTalk
{

    /// <summary>
    /// 最近消息列表控件
    /// </summary>
    public partial class RecentListLayout : UserControl
    {

        #region Private Members

        private delegate void DelegateMessage(MessageObject msg);
        private delegate void DelegateFriend(Friend msg);
        private delegate void DelegateString(string msg);
        private delegate void DelegateMessages(List<MessageObject> msgs);
        //   private System.Timers.Timer mHideTipTimer;
        /// <summary>
        /// 主窗口对象
        /// </summary>
        public FrmMain MainForm { get; set; }

        /// <summary>
        /// 选中的项
        /// </summary>
        public NewsItem SelectedItem { get; set; } = new NewsItem();

        // 列表是否已经准备好了
        private bool isRead;
        private bool isSharch;
        // 
        private RecentListAdapter mAdapter;

        #endregion

        public RecentListLayout()
        {
            InitializeComponent();

            // 这行代码打开后-搜索聊天记录点击已搜索的项导致失去焦点关闭了搜索
            //RecentSearch.LoseFocusResume = true;
            CheckForIllegalCrossThreadCalls = false;

            mAdapter = new RecentListAdapter();
            RecentSearch.tips = LanguageXmlUtils.GetValue("search", "搜索");
            RecentSearch.SearchEvent += SearchMeesageContent;
        }

        #region 加载事件
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecentListLayoutLoad(object sender, EventArgs e)
        {
            //this.txtSearch.GotFocus += SearchFocused;
            //this.txtSearch.LostFocus += SearchUnFocused;

            RegisterMessengers();
        }
        #endregion

        #region 注册通知
        public void RegisterMessengers()
        {
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_SHOW_SINGLE_MESSAGE, ReceiveSingleMessage);
            Messenger.Default.Register<List<MessageObject>>(this, MessageActions.XMPP_SHOW_ALL_MESSAGE, ReceiveManyMessage);

            Messenger.Default.Register<Friend>(this, MessageActions.UPDATE_FRIEND_TOP, StickToTop);

            Messenger.Default.Register<Friend>(this, MessageActions.UPDATE_FRIEND_REMARKS, UpdateRemarks);

            Messenger.Default.Register<Friend>(this, MessageActions.DELETE_FRIEND, DeleteRecentItem);
            Messenger.Default.Register<Friend>(this, MessageActions.ADD_BLACKLIST, DeleteRecentItem);
            // 刷新最后一条聊天记录
            Messenger.Default.Register<Friend>(this, MessageActions.UPDATE_FRIEND_LAST_CONTENT, (friend) =>
            {
                // friend.UpdateClearContent();
                UpdateLastContent(friend);
            });

            // 清除聊天记录
            Messenger.Default.Register<Friend>(this, MessageActions.UPDATE_CHATLIST_CLEAR_FRIEND, (friend) =>
            {
                UpdateItemClearFriend(friend);
            });

            Messenger.Default.Register<string>(this, MessageActions.UPDATE_HEAD, RefreshFriendHead);
            Messenger.Default.Register<Friend>(this, MessageActions.UPDATE_FRIEND_DISTURB, UpdateDisturb);

            // 群聊被删除
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_ROOM_DELETE, (msg) =>
            {
                DeleteRecentItem(new Friend { UserId = msg.ChatJid });//删除控件
            });

            // 修改群组名称
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_ROOM_CHANGE_MESSAGE, (msg) =>
            {
                if (kWCMessageType.RoomNameChange == msg.type)
                {
                    UpdateRemarks(new Friend { UserId = msg.ChatJid, IsGroup = 1, NickName = msg.content });//删除控件
                }
            });

            // 收到消息列表下载完成
            Messenger.Default.Register<string>(this, MessageActions.DOWN_CHATLIST_COMPT, (msg) =>
            {
                DownChatsCompte(msg);
            });

            //// 收到正在接收离线消息的通知
            //Messenger.Default.Register<string>(this, MessageActions.OPEN_WAIT_DELAY_COMPTE, (msg) =>
            //{
            //    OpenWaitDelayCompte(msg);
            //});

            Messenger.Default.Register<string>(this, MessageActions.SearchEventRecent, SearchMeesageContent);
            Messenger.Default.Register<string>(this, MessageActions.MenuEventRecent, btnPlus_Click);
        }
        #endregion


        #region 收到最近消息列表刷新完成
        //public void OpenWaitDelayCompte(string msg)
        //{
        //    if (Thread.CurrentThread.IsBackground)
        //    {
        //        var main = new DelegateString(OpenWaitDelayCompte);
        //        Invoke(main, msg);
        //        return;
        //    }

        //    if (!labWaitDelay.Visible)
        //    {
        //        Console.WriteLine("OpenWaitDelayCompte");
        //        labWaitDelay.Visible = true;
        //        mHideTipTimer = new System.Timers.Timer();
        //        // 初始化消息队列
        //        mHideTipTimer.Interval = 5 * 1000; // 5秒没有消息就去更新界面
        //        mHideTipTimer.Elapsed += new ElapsedEventHandler(OnCloseWaitTip);
        //        mHideTipTimer.AutoReset = false;   //设置是执行一次（false）还是一直执行(true)；
        //        mHideTipTimer.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；
        //    }
        //}


        //private void OnCloseWaitTip(object source, ElapsedEventArgs e)
        //{

        //    if (mHideTipTimer != null)
        //    {
        //        mHideTipTimer.Stop();
        //        mHideTipTimer.Dispose();
        //        mHideTipTimer = null;

        //    }
        //    labWaitDelay.Visible = false;
        //}

        #endregion

        #region 收到最近消息列表刷新完成
        public void DownChatsCompte(string msg)
        {
            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateString(DownChatsCompte);
                Invoke(main, msg);
                return;
            }

            if (mLoding != null)
            {
                mLoding.stop();
                mLoding = null;
            }

            MainForm.mainPageLayout.SelectChat(new Friend());

            // 这里在去加载
            LoadRecentList();


            // 刷新联系人界面未读
            this.Invoke(new Action(() =>
            {
                // 获取新的朋友未读数量
                int count = new Friend() { UserId = Friend.ID_NEW_FRIEND }.GetNuRedNum();
                int totalCount = count;

                // 获取给黑名单未读数量
                count = new Friend() { UserId = Friend.ID_BAN_LIST }.GetNuRedNum();
                totalCount += count;
                Messenger.Default.Send(totalCount, LeftLayout.NOTIFY_CONTACT_UNREADCOUNT);
            }));
        }

        #endregion

        #region 刷新一个好友的备注
        private void UpdateRemarks(Friend friend)
        {
            int index = mAdapter.GetIndexByFriendId(friend.UserId);
            if (index > -1)
            {
                var f = mAdapter.GetData(index);
                f.RemarkName = friend.RemarkName;
                f.NickName = friend.NickName;
                mAdapter.ChangeData(index, f);
                var item = GetItemByFriend(index);
                if (item != null)
                {
                    item.FriendData.NickName = friend.NickName;
                    item.FriendData.RemarkName = friend.RemarkName;
                    item.RefreshNickName();
                }
            }
        }
        #endregion  

        #region 刷新一个好友免打扰
        private void UpdateDisturb(Friend friend)
        {
            int index = mAdapter.GetIndexByFriendId(friend.UserId);
            if (index > -1)
            {
                mAdapter.ChangeData(index, friend);
                var item = GetItemByFriend(index);
                if (item != null)
                {
                    item.FriendData = friend;
                }
            }
        }
        #endregion 

        #region 刷新最后一条聊天记录
        private void UpdateLastContent(Friend friend)
        {
            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateFriend(UpdateLastContent);
                Invoke(main, friend);
                return;
            }

            LogUtils.Log("刷新最后一条聊天记录");

            int index = mAdapter.GetIndexByFriendId(friend.UserId);
            if (index > -1)
            {
                mAdapter.ChangeData(index, friend);

                var item = GetItemByFriend(index);
                if (item != null)
                {
                    item.FriendData.Content = friend.Content;
                    item.RefreshContent();

                    //MessageObject ms = new MessageObject()
                    //{
                    //    FromId = friend.UserId,
                    //    ToId = Applicate.MyAccount.userId,
                    //    isGroup = friend.IsGroup
                    //}.GetLastMessage();

                    //if (UIUtils.IsNull(ms.messageId))
                    //{
                    //    item.FriendData = friend;
                    //    item.RefreshContent();
                    //    return;
                    //}

                    //if (ms.isReadDel == 1)
                    //{
                    //    item.FriendData.Content = "[阅后即焚消息]";
                    //    item.RefreshContent();
                    //    return;
                    //}

                    //double timeSend = friend.LastMsgTime == 0 ? TimeUtils.CurrentTimeDouble() : friend.LastMsgTime;
                    //if (ms.timeSend > 0)
                    //{
                    //    timeSend = ms.timeSend;
                    //}

                    //string content = friend.ToLastContentTip(ms.type, ms.content, ms.fromUserId, ms.fromUserName, ms.toUserName);

                    //if (ms.isGroup == 1)
                    //{
                    //    content = ms.fromUserName + ":" + content;
                    //}

                    //item.FriendData.UpdateLastContent(content, timeSend);
                    //item.RefreshContent();
                }
            }
        }
        #endregion

        #region 刷新用户头像
        private void RefreshFriendHead(string userId)
        {
            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateString(RefreshFriendHead);
                Invoke(main, userId);
                return;
            }

            var item = GetItemByFriend(userId);
            if (item != null)
            {
                item.RefreshFriendImage();
            }
        }
        #endregion

        #region 删除列表中的某一个项
        public void DeleteRecentItem(Friend friend)
        {

            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateFriend(DeleteRecentItem);
                Invoke(main, friend);
                return;
            }


            int index = mAdapter.GetIndexByFriendId(friend.UserId);

            if (index > -1)
            {
                xListView.RemoveItem(index);
                mAdapter.RemoveData(index);

                RefreChatUnReadTotalCount();

                if (MainForm.mainPageLayout.IsChatFriend(friend.UserId))//设置右侧页面为空
                {
                    SelectedItem.FriendData = new Friend();
                    MainForm.mainPageLayout.SelectChat(new Friend());
                }

                // 删除比较靠下的元素需要自动收缩列表
                if (xListView.Progress > 90 && index > mAdapter.GetItemCount() * 0.7)
                {
                    int locy = xListView.ListPanelLocationY() + mAdapter.OnMeasureHeight(0);
                    if (locy < 0)
                    {
                        xListView.MovePanelLocation(locy);
                        Console.WriteLine("向下移动列表" + locy);
                    }

                }
            }
        }
        #endregion

        #region 插入项到列表
        private void InsertRecentItem(int index, Friend friend, string str)
        {
            LogUtils.Error(str + ", InsertRecentItem" + index + " ， " + friend.NickName);
            mAdapter.InsertData(index, friend);
            xListView.InsertItem(index);
        }

        #endregion

        #region 置顶&取消置顶
        /// <summary>
        /// 置顶消息
        /// </summary>
        /// <param name="friend">需要置顶的好友</param>
        private void StickToTop(Friend friend)
        {
            //Console.WriteLine("StickToTop  " + friend.nickName);
            int index = mAdapter.GetIndexByFriendId(friend.UserId);

            if (index > -1)
            {
                mAdapter.ChangeData(index, friend);
                xListView.RefreshItem(index);

                int topIndex = GetFriendIndexByTime(friend, friend.TopTime == 0);
                xListView.MoveItem(index, topIndex);
                mAdapter.MoveData(index, topIndex);
                //if (topIndex > 8)
                //{
                //    xListView.ShowRangeStart(topIndex, 0, true);
                //}
            }
        }
        #endregion

        #region 根据消息更新最近消息列表
        private void UpdateItemView(MessageObject msg)
        {

            if (isSharch || msg == null || mLoding != null)
            {
                return;
            }

            var friend = msg.GetLastFriend();
            if (IsInvalidFriend(friend))
            {
                return;//如果查不到对应好友则为陌生人，跳出
            }

            if (friend.IsGroup == 1 && friend.Status == 0)
            {
                // 修改直播间消息会出现在在最近消息列表的问题
                return;
            }

            if (MainForm.IsSeparateChatFriend(msg.ChatJid))
            {
                LogUtils.Log("当前对象正在独立窗口聊天");
                return;
            }


            if (friend.LastMsgTime == 0)
            {
                if (msg.timeSend == 0)
                {
                    friend.LastMsgTime = TimeUtils.CurrentTimeDouble();
                }
                else
                {
                    friend.LastMsgTime = msg.timeSend;
                }
            }


            LogUtils.Log("刷新最近消息项");

            int index = mAdapter.GetIndexByFriendId(friend.UserId);
            if (index > -1)
            {
                mAdapter.ChangeData(index, friend);

                var item = GetItemByFriend(index);
                if (item != null)
                {
                    // 修改@我的消息
                    item.FriendData.IsAtMe = friend.IsAtMe;

                    if (item.FriendData.TopTime <= 0)//如果不为置顶项
                    {
                        //移动到置顶项下
                        int last = GetFriendIndexByTime(friend);//置顶数量7？
                        xListView.MoveItem(index, last);
                        mAdapter.MoveData(index, last);
                        if (last < 7)
                        {
                            xListView.ShowRangeStart(0, 0);
                        }
                        else
                        {
                            xListView.ShowRangeStart(last, 0);
                        }
                    }

                    // 刷新项数据
                    item.FriendData = friend;

                    if (SelectedItem != null && item.FriendData.UserId.Equals(SelectedItem.FriendData.UserId))//如果已选中当前聊天项
                    {
                        item.FriendData.MsgNum = 0;//清空未读数量
                        item.FriendData.UpdateRedNum(0);
                        item.RefreshUnreadNum();
                    }
                    else
                    {
                        item.FriendData.MsgNum = friend.MsgNum;//赋值未读数量
                        item.RefreshUnreadNum();
                    }

                    //recentitem.Refresh();
                    RefreChatUnReadTotalCount();
                }
                else
                {
                    var from = index;
                    index = GetFriendIndexByTime(friend);
                    // 刷新老位置上的数据
                    mAdapter.ChangeData(from, friend);

                    xListView.MoveItem(from, index);
                    mAdapter.MoveData(from, index);

                    RefreChatUnReadTotalCount();
                }
            }
            else
            {
                index = GetFriendIndexByTime(friend);
                InsertRecentItem(index, friend, "刷新最近消息项");
                RefreChatUnReadTotalCount();
            }
        }

        private bool IsInvalidFriend(Friend friend)
        {
            if (friend == null)
            {
                return true;
            }

            if (UIUtils.IsNull(friend.UserId))
            {
                return true;
            }

            if (Friend.ID_SYSTEM_NOTIFICATION.Equals(friend.UserId))
            {
                return true;
            }

            if (friend.Status == Friend.STATUS_BLACKLIST)
            {
                return true;
            }

            if (friend.GroupType == 2)
            {
                return true;
            }

            if (friend.Status >= Friend.STATUS_17 && friend.Status <= Friend.STATUS_19)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 收到单条消息
        public void ReceiveSingleMessage(MessageObject msg)
        {
            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateMessage(ReceiveSingleMessage);
                Invoke(main, msg);
                return;
            }


            if (isRead)
            {
                UpdateItemView(msg);
            }

        }

        #endregion

        #region 收到多条消息
        private void ReceiveManyMessage(List<MessageObject> msgs)
        {
            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateMessages(ReceiveManyMessage);
                Invoke(main, msgs);
                return;
            }

            if (isRead)
            {
                ProcessMessages(msgs.ToArray());
            }

        }
        #endregion

        #region 处理多条消息
        private void ProcessMessages(MessageObject[] list)
        {
            Dictionary<string, MessageObject> toFriend = new Dictionary<string, MessageObject>();
            foreach (var msg in list)
            {

                Console.WriteLine("============================on rece ProcessMessages:" + msg.content);

                if (toFriend.ContainsKey(msg.ChatJid))
                {
                    toFriend[msg.ChatJid] = msg;
                }
                else
                {
                    toFriend.Add(msg.ChatJid, msg);
                }

                if (toFriend.Count > 4)
                {
                    LoadRecentList();
                    return;
                }
            }

            foreach (var message in toFriend.Values)
            {
                UpdateItemView(message);
            }
        }
        #endregion

        #region 刷新左侧聊天图标未读角标数量

        /// <summary>
        /// 刷新左侧聊天图标未读角标数量  
        /// </summary>
        private void RefreChatUnReadTotalCount()
        {
            int totalcount = mAdapter.GetTotalUnReadCount();
            Messenger.Default.Send(totalcount, LeftLayout.NOTIFY_CHAT_UNREADCOUNT);//通知左侧导航栏显示未读角标
        }
        #endregion

        #region 清除聊天记录刷新项
        private void UpdateItemClearFriend(Friend friend)
        {
            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateFriend(UpdateItemClearFriend);
                Invoke(main, friend);
                return;
            }

            // 正在清除聊天记录，删除项
            if (friend.IsOnLine == -2)
            {
                DeleteRecentItem(friend);
                return;
            }

            int index = mAdapter.GetIndexByFriendId(friend.UserId);
            if (index > -1)
            {
                friend.MsgNum = 0;
                friend.Content = "";

                mAdapter.ChangeData(index, friend);

                var item = GetItemByFriend(index);
                if (item != null)
                {
                    item.FriendData.MsgNum = 0;
                    item.FriendData.Content = "";
                    item.RefreshContent();
                    item.RefreshUnreadNum();
                }

                RefreChatUnReadTotalCount();
            }
        }

        #endregion

        #region 加载数据
        public void LoadData()
        {
            // 这里去等待xmpp连接后 在去调用最近列表加载 
            // @see XmppStateChange
            //LoadRecentList();

            mLoding = new LodingUtils { parent = this.xListView, Title = LanguageXmlUtils.GetValue("loading", "加载中") };
            mLoding.start();
        }
        #endregion

        #region 加载最近消息列表
        /// <summary>
        /// 加载最近消息列表
        /// </summary>
        /// <param name="userId">设置需要选中的对应UserId的项</param>
        private void LoadRecentList(string userId = "")
        {
            var load = new LodingUtils { parent = this.xListView, Title = "加载中" };
            load.start();

            isRead = false;

            List<Friend> friends = new Friend().GetRecentList();

            Application.DoEvents();

            try
            {

                this.SuspendLayout();



                for (int i = friends.Count - 1; i > -1; i--)
                {
                    Friend friend = friends[i];
                    // 是否正在独立窗口聊天
                    if (MainForm.IsSeparateChatFriend(friend.UserId))
                    {
                        friends.RemoveAt(i);
                    }

                    if (friend.NickName.Equals("客服公众号") && friend.RemarkName.Equals("客服公众号")) friends.RemoveAt(i);
                }

                mAdapter.BindFriendData(friends);
                mAdapter.MainForm = MainForm;
                mAdapter.RecentList = this;
                isSharch = false;
                xListView.SetAdapter(mAdapter);

                //var controls = new List<Control>();
                //foreach (var friend in friends)
                //{
                //    // 是否正在独立窗口聊天
                //    if (MainForm.IsSeparateChatFriend(friend.userId))
                //    {
                //        continue;
                //    }

                //    var item = ModelToControl(friend);//Model转控件

                //    //如果为对应Friend设置为选中
                //    item.IsSelected = friend.userId.Equals(userId);
                //    controls.Add(item);
                //}

                //tlpRecentList.ClearTabel(true);//清除
                //tlpRecentList.AddViewsToPanel(controls);//集合添加
            }
            finally
            {
                this.ResumeLayout();
            }
            load.stop();
            isRead = true;
            RefreChatUnReadTotalCount();//重新显示全局消息未读角标

        }
        #endregion

        #region 左键和右键选中事件

        public void MouseClickItem(object sender, EventArgs e)
        {
            if (mLoding != null)
            {
                return;
            }

            // 过滤重复点击项
            NewsItem temp = sender as NewsItem;
            //Console.WriteLine("MouseClickItem  ");
            if (temp == null || temp == SelectedItem)
            {
                return;
            }

            SelectedItem = temp;


            Console.WriteLine("MouseClickItem  " + SelectedItem);
            if (SelectedItem != null && SelectedItem.FriendData != null)
            {

                UpdateItemBgColor();
                Console.WriteLine("MouseClickItem  " + SelectedItem.FriendData.NickName);
                var tempFriend = SelectedItem.FriendData.GetByUserId();

                // 更新最新状态
                SelectedItem.FriendData.IsDismiss = tempFriend.IsDismiss;

                MainForm.SetRecentSelectedItem(SelectedItem);//设置会话对象(显示消息气泡)
                SelectedItem.FriendData.MsgNum = 0;
                SelectedItem.FriendData.UpdateRedNum(0);//更新数据库未读消息数量为0
                SelectedItem.RefreshUnreadNum();//重置角标
                SelectedItem.ClearAtmeTip();

                int index = mAdapter.GetIndexByFriendId(SelectedItem.FriendData.UserId);
                if (index > -1)
                {
                    mAdapter.ChangeData(index, SelectedItem.FriendData);
                }

                RefreChatUnReadTotalCount();//更新对应的
            }
        }

        public void UpdateItemBgColor()
        {
            // 修改项背景颜色
            for (int i = 0; i < mAdapter.GetItemCount(); i++)
            {
                NewsItem item = GetItemByFriend(mAdapter.GetData(i).UserId);
                if (item != null)
                {
                    if (SelectedItem.FriendData == null || UIUtils.IsNull(SelectedItem.FriendData.UserId))
                    {
                        item.IsSelected = false;
                    }
                    else
                    {
                        item.IsSelected = SelectedItem.FriendData.UserId.Equals(item.FriendData.UserId);
                    }
                }
            }

            //if (SelectedItem != null && SelectedItem.friendData != null)
            //{
            //    // 把上一个取消选中
            //    SelectedItem.IsSelected = false;
            //}
            //temp.IsSelected = true;
        }
        #endregion

        #region 双击对应项
        public void SeparateChatForm(object sender, EventArgs e)
        {

            if (isSharch)
            {
                return;
            }

            //获取当前点击Item
            var currentItem = sender as NewsItem;

            var friend = currentItem.FriendData.Clone();
            // 隐藏最近消息列表

            DeleteRecentItem(currentItem.FriendData);
            //tlpRecentList.RemoveItem(currentItem);
            // 将右侧置空
            //MainForm.mainPageLayout.SelectChat(new Friend());

            // 分离消息窗口
            LogUtils.Log("双击 SeparateChatForm" + currentItem.FriendData.UserId);
            //FrmSeparateChat frmSeparateChat = new FrmSeparateChat();
            //frmSeparateChat.Show();
            //frmSeparateChat.sendMsgPanel.SetChooseFriend(currentItem.friendData, 0, "", 1);

            FrmNewTable frmNewTable = new FrmNewTable();

            ImageLoader.Instance.DisplayAvatar(friend.UserId, true, (bitmap) =>
            {
                frmNewTable.Icon = Icon.FromHandle(bitmap.GetHicon());
            });

            frmNewTable.Text = friend.GetRemarkName();
            frmNewTable.Show();
            frmNewTable.showMsgPanel.SetChooseFriend(friend, 0, "", 1);


            // FrmLiveTest frmLiveTest = new FrmLiveTest();

            //frmLiveTest.Show();
            //frmLiveTest.SetChooseFriend()

            //SelectedItem = null;
        }
        #endregion

        #region 发送消息
        public void SendMessageToFriend(Friend friend)
        {
            if (mLoding != null)
            {
                return;
            }

            int index = mAdapter.GetIndexByFriendId(friend.UserId);

            if (index == -1)
            {
                if (friend.LastMsgTime == 0)
                {
                    friend.LastMsgTime = TimeUtils.CurrentTimeDouble();
                }
                index = GetFriendIndexByTime(friend);
                InsertRecentItem(index, friend, "发送消息");
            }


            int count = xListView.Height / mAdapter.OnMeasureHeight(0);
            if (index < count)
            {
                xListView.ShowRangeStart(0, 0);
            }
            else
            {
                xListView.ShowRangeEnd(index, 0, true);
            }

            var item = xListView.GetItemControl(index) as NewsItem;
            mAdapter.ChangeData(index, friend);
            item.FriendData = friend;
            //item.content = GetFriendLastContent(friend);

            if (friend.Role == "0")
            {
                SelectedItem = null;
            }
            MouseClickItem(item, null);//选中

            //var item = tlpRecentList.GetNewsItemByFriend(friend.userId);
            //if (item == null)//如果没有对应项存在于最近聊天列表
            //{
            //    item = ModelToControl(friend);
            //    tlpRecentList.InsertItem(item, GetTopCount(friend.topTime) + 1);//插入至顶部
            //}

            //
        }
        #endregion

        #region 获取当前列表置顶的数量

        private int GetFriendIndexByTime(Friend friend, bool isuntop = false)
        {
            // 置顶项
            if (friend.TopTime > 0)
            {
                for (int i = 0; i < mAdapter.GetItemCount(); i++)
                {
                    if (mAdapter.GetData(i).TopTime <= friend.TopTime)
                    {
                        return i;
                    }
                }
                return 0;
                //int count = new Friend().GetTopFriendCount(friend.topTime);
                //return count;
            }
            else
            {

                if (isuntop)
                {
                    int index = mAdapter.GetIndexByFriendId(friend.UserId);

                    for (int i = index + 1; i < mAdapter.GetItemCount(); i++)
                    {
                        Friend temp = mAdapter.GetData(i);
                        if (temp.TopTime == 0 && temp.LastMsgTime <= friend.LastMsgTime)
                        {

                            if (i > 0)
                            {
                                return i - 1;
                            }

                            return i;
                        }
                    }

                    return mAdapter.GetItemCount() - 1;
                }


                for (int i = 0; i < mAdapter.GetItemCount(); i++)
                {
                    Friend temp = mAdapter.GetData(i);

                    if (temp.TopTime == 0)
                    {
                        if (temp.LastMsgTime <= friend.LastMsgTime)
                        {
                            return i;
                        }

                    }
                }

                ////int count = new Friend().GetLastTimeFriendCount(friend.lastMsgTime);
                //if (mAdapter.GetItemCount() == 0)
                //{
                //    return 0;
                //}

                return mAdapter.GetItemCount();
            }
        }

        #endregion

        #region 跳转到下一个未读数量
        public int NextUnpoint()
        {
            if (mLoding != null)
            {
                return 0;
            }

            // 置顶项
            int currt = Convert.ToInt32(Math.Floor(xListView.Progress / 100.0F * mAdapter.GetItemCount()));
            int next = mAdapter.NextUnpoint(currt);
            if (currt != next)
            {
                xListView.ShowRangeStart(next, 0, true);
                //xListView.RefreshFillControl();
            }

            int totalcount = mAdapter.GetTotalUnReadCount();
            return totalcount;
        }

        #endregion

        #region 搜索最近聊天记录
        private string lastSearchText;
        // 搜索聊天记录
        private void SearchMeesageContent(string inputStr)
        {

            if (string.IsNullOrEmpty(inputStr) && string.IsNullOrEmpty(lastSearchText))
            {
                LogUtils.Log("SearchTextChanged null");
                return;
            }

            if (string.Equals(lastSearchText, inputStr))
            {
                LogUtils.Log("SearchTextChanged Equals");
                return;
            }

            lastSearchText = inputStr;


            if (!string.IsNullOrEmpty(inputStr))
            {

                if (mLoding != null)
                {
                    mLoding.stop();
                }

                mLoding = new LodingUtils { parent = this.xListView, Title = "加载中" };
                mLoding.start();


                Task.Factory.StartNew(() =>
                {
                    //遍历我的所有朋友 去找聊天记录 如果改成查询最近好友速度会提示 N倍
                    List<Friend> allFriend = new Friend().GetRecentList(); // GetAllList
                    List<Friend> result = new List<Friend>();
                    for (int i = 0; i < allFriend.Count; i++)
                    {

                        if (UIUtils.IsNull(lastSearchText))
                        {
                            if (mLoding != null)
                            {
                                mLoding.stop();
                                mLoding = null;
                            }
                            return;
                        }

                        if (allFriend[i].NickName.Contains(inputStr) || (allFriend[i].RemarkName != null && allFriend[i].RemarkName.Contains(inputStr)))
                        {
                            result.Add(allFriend[i]);
                        }

                        // 优化sql查询 速度提升3倍 2020-3-17 15:33:45
                        List<MessageObject> listMessage = MessageObjectDao.Instance.GetTextContentList(inputStr, allFriend[i].UserId);

                        //List<MessageObject> listMessage = message.GetPageList(1, inputStr, 0, 100);

                        if (!UIUtils.IsNull(listMessage))
                        {
                            foreach (var item in listMessage)
                            {
                                if (UIUtils.IsNull(lastSearchText))
                                {
                                    if (mLoding != null)
                                    {
                                        mLoding.stop();
                                        mLoding = null;
                                    }
                                    return;
                                }

                                Friend friend = new Friend();
                                friend.UserId = allFriend[i].UserId;
                                friend.NickName = allFriend[i].NickName;
                                friend.RemarkName = allFriend[i].RemarkName;
                                friend.RoomId = allFriend[i].RoomId;
                                friend.IsGroup = allFriend[i].IsGroup;
                                friend.Status = allFriend[i].Status;

                                friend.LastMsgTime = item.timeSend;
                                friend.Content = item.content;

                                friend.IsSendRecipt = 10;
                                result.Add(friend);
                            }
                        }
                    }

                    mAdapter.BindFriendData(result);

                    var main = new DelegateString(ReSetAdapter);
                    Invoke(main, "str");
                });
            }
            else
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(200);

                    CancelSearchText("");

                });

                //xListView.ClearList();
                ////txtSearch.Enabled = true;
                ////txtSearch.Focus();
            }


        }

        public void CancelSearchText(string msg)
        {
            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateString(CancelSearchText);
                Invoke(main, msg);
                return;
            }

            LoadRecentList();
        }


        private LodingUtils mLoding;
        public void ReSetAdapter(string str)
        {

            this.xListView.ResumeLayout(false);
            this.ResumeLayout(false);
            if (mLoding != null)
            {
                mLoding.stop();
                mLoding = null;
            }
            isSharch = true;
            xListView.SetAdapter(mAdapter);
            //txtSearch.Enabled = true;
            //txtSearch.Focus();

        }
        #endregion


        #region +号点击
        private void btnPlus_Click(string tag)
        {
            //SkSSLUtils.RequestFriendKeyList(null);


            var tmpset = Applicate.GetWindow<FrmBuildGroups>();

            if (tmpset == null)
            {
                FrmBuildGroups create = new FrmBuildGroups();
                var parent = Applicate.GetWindow<FrmMain>();
                create.Location = new Point(parent.Location.X + (parent.Width - create.Width) / 2, parent.Location.Y + (parent.Height - create.Height) / 2);//居中
                create.Show();
            }
            else
            {
                tmpset.Activate();
                tmpset.WindowState = FormWindowState.Normal;
            }
        }

        #endregion

        #region   获取项方法
        private NewsItem GetItemByFriend(string userId)
        {
            int index = mAdapter.GetIndexByFriendId(userId);

            return GetItemByFriend(index);
        }

        private NewsItem GetItemByFriend(int index)
        {
            if (xListView.DataCreated(index))
            {
                NewsItem item = xListView.GetItemControl(index) as NewsItem;
                return item;
            }

            return null;
        }

        #endregion

    }
}

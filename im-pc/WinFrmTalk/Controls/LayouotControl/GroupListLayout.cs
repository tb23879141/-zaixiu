using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Model;
using WinFrmTalk.View;
using WinFrmTalk.View.list;

namespace WinFrmTalk
{
    /// <summary>
    /// 群组列表
    /// </summary>
    public partial class GroupListLayout : UserControl
    {

        #region Private Member

        private delegate void ProcesssMessage(MessageObject msg);
        private delegate void ProcesssFriend(Friend msg);

        /// <summary>
        /// 当前选中的项目
        /// </summary>
        public FriendItem SelectedItem { get; set; }
        public Label tabLabel { get; private set; }
        /// <summary>
        /// 主窗口对象
        /// </summary>
        public FrmMain MainForm { get; set; }

        #endregion

        #region 常量
        /// <summary>
        /// 删除群组Token
        /// </summary>
        public const string DELETE_GROUP_ITEM = nameof(DELETE_GROUP_ITEM);

        /// <summary>
        /// 发送群组消息Token
        /// </summary>
        public const string SEND_GROUP_MSG = nameof(SEND_GROUP_MSG);

        private delegate void DelegateString(string msg);

        private GroupListAdapter mAdapter;

        #endregion

        public GroupListLayout()
        {
            InitializeComponent();

            if (Program.Started)
            {
                mAdapter = new GroupListAdapter();
                mAdapter.MouseDown += MouseDownItem;

                this.Load += new System.EventHandler(this.GroupListLayout_Load);
            }
        }


        #region 加载事件
        private void GroupListLayout_Load(object sender, EventArgs e)
        {
            RegisterMessenger();

            mAdapter.ListWidth = this.Width - 10;

            var v1 = CreateTabItem("群主", true);
            tabLayoutPanel1.AppendControl(v1, true);

            var v2 = CreateTabItem("管理");
            tabLayoutPanel1.AppendControl(v2);

            var v3 = CreateTabItem("群员");
            tabLayoutPanel1.AppendControl(v3);

            tabLayoutPanel1.ItemSelected += TabLayout_ItemSelected;

            HttpLoadRoomsData();
        }

        private Control CreateTabItem(string name, bool foucs = false)
        {
            var item = new TabTextItem();
            item.Size = new Size(90, 20);
            item.Text = name;
            item.Name = "role" + tabLayoutPanel1.Controls.Count;
            item.TextAlign = ContentAlignment.MiddleCenter;

            if (foucs)
            {
                tabLabel = item;
            }
            return item;
        }

        private void TabLayout_ItemSelected(object sender, MouseEventArgs e)
        {
            // 切换列表项
            tabLabel = sender as Label;
            if (tabLabel.Name == "role0")
            {
                mAdapter.BindFriendData(myGroupCreateList);
                xListView.SetAdapter(mAdapter);
            }
            else if (tabLabel.Name == "role1")
            {
                mAdapter.BindFriendData(myGroupManageList);
                xListView.SetAdapter(mAdapter);
            }
            else
            {
                mAdapter.BindFriendData(myGroupJoinList);
                xListView.SetAdapter(mAdapter);
            }

        }
        #endregion
        #region 加载群列表

        #region 等待符


        private LodingUtils mLoding = null;

        public void ShowLoading()
        {
            if (mLoding == null)
            {
                mLoding = new LodingUtils { parent = this.xListView, Title = "加载中" };
                mLoding.start();
            }
        }


        public void StopLoading()
        {
            if (mLoding != null)
            {
                mLoding.stop();
            }
        }

        #endregion


        public static List<Friend> myGroupCreateList = new List<Friend>() { };
        public static List<Friend> myGroupJoinList = new List<Friend>() { };
        public static List<Friend> myGroupManageList = new List<Friend>() { };
        //获取群统计
        private void HttpLoadRoomsData()
        {
            ShowLoading();

            HttpUtils.Instance.InitHttp(this);
            string RequestUrl = Applicate.URLDATA.data.apiUrl + "community/getMyGroup";
            HttpUtils.Instance.Get().Url(RequestUrl)
                .Build().Execute((sccess, data) =>
                {
                    if (sccess)
                    {
                        try
                        {
                            var createList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyGroupGQModel>>(data["create"].ToString());
                            Friend friend = null;
                            foreach (var item in createList)
                            {
                                friend = item.ToRoom(false);
                                myGroupCreateList.Add(friend);
                            }

                            tabLayoutPanel1.Controls["role0"].Text = string.Format("群主({0})", myGroupCreateList.Count);
                        }
                        catch (Exception ex)
                        {
                            string tmpErr = ex.ToString();
                        }

                        try
                        {
                            var joinList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyGroupGQModel>>(data["join"].ToString());
                            Friend friend = null;
                            foreach (var item in joinList)
                            {
                                friend = item.ToRoom(false);
                                myGroupJoinList.Add(friend);
                            }
                            tabLayoutPanel1.Controls["role2"].Text = string.Format("群员({0})", myGroupJoinList.Count);


                        }
                        catch (Exception ex)
                        {
                            string tmpErr = ex.ToString();
                        }


                        try
                        {
                            var manageList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyGroupGQModel>>(data["manager"].ToString());
                            Friend friend = null;
                            foreach (var item in manageList)
                            {
                                friend = item.ToRoom(false);
                                myGroupManageList.Add(friend);
                            }
                            tabLayoutPanel1.Controls["role1"].Text = string.Format("管理({0})", myGroupManageList.Count);
                        }
                        catch (Exception ex)
                        {
                            string tmpErr = ex.ToString();
                        }

                        // 默认第一个
                        mAdapter.BindFriendData(myGroupCreateList);
                        xListView.SetAdapter(mAdapter);
                    }


                    StopLoading();
                });
        }


        #endregion


        #region 注册通知
        private void RegisterMessenger()
        {
            Messenger.Default.Register<bool>(this, GroupListLayout.DELETE_GROUP_ITEM, DeleteGroup);
            Messenger.Default.Register<bool>(this, GroupListLayout.SEND_GROUP_MSG, (_) =>
            {
                MainForm.SendMessageToFriend(SelectedItem.FriendData);
            });

            // 修改群组名称
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_ROOM_CHANGE_MESSAGE, UpdateRommItem);

            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_COMPANY_NAME_CHANGE_MESSAGE, UpdateRommItem);

            // 我退出了一个群
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_ROOM_DELETE, UpdateRommItem);

            // 我被邀请进入了一个群
            Messenger.Default.Register<Friend>(this, MessageActions.ROOM_UPDATE_INVITE, CreteItemView);

            Messenger.Default.Register<string>(this, MessageActions.UPDATE_HEAD, RefreshFriendHead);

            Messenger.Default.Register<string>(this, MessageActions.SearchEventGroups, SearchEvent);
            Messenger.Default.Register<string>(this, MessageActions.MenuEventGroups, btnPlus_Click);

            Messenger.Default.Register<Friend>(this, MessageActions.UPDATE_FRIEND_REMARKS, UpdateRommName);
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

            int index = mAdapter.GetIndexByFriendId(userId);
            if (xListView.DataCreated(index))
            {
                FriendItem item = xListView.GetItemControl(index) as FriendItem;
                // 刷新用户头像
                item.LoadHeadImage();
            }
        }
        #endregion

        #region 刷新群组名称
        private void UpdateRommName(Friend friend)
        {
            int index = mAdapter.GetIndexByFriendId(friend.UserId);
            if (index > -1)
            {
                mAdapter.ChangeData(index, friend);

                if (xListView.DataCreated(index))
                {
                    FriendItem item = xListView.GetItemControl(index) as FriendItem;
                    // 修改名称
                    item.FriendData.NickName = friend.NickName;
                    item.ChangeFriendName();

                    MainForm.mainPageLayout.ChangeGroupName(item.FriendData);
                }
            }
        }
        #endregion

        #region 修改群名称
        private void UpdateRommItem(MessageObject message)
        {
            if (Thread.CurrentThread.IsBackground == true)
            {
                var tmp = new ProcesssMessage(UpdateRommItem);
                this.Invoke(tmp, message);
                return;
            }


            switch (message.type)
            {
                case kWCMessageType.RoomNameChange:
                    Friend friend = message.GetFriend();
                    if (friend != null)
                    {
                        friend.NickName = message.content;
                        UpdateRommName(friend);
                    }
                    break;
                case kWCMessageType.RoomDismiss:
                case kWCMessageType.RoomExit:
                    if (!UIUtils.IsNull(message.toUserId))
                    {
                        if (string.Equals(message.toUserId, Applicate.MyAccount.userId))
                        {
                            RemoveItemView(message.ChatJid);
                        }
                    }
                    else
                    {
                        RemoveItemView(message.ChatJid);
                    }

                    break;
                case kWCMessageType.GroupCompanyName:

                    myGroupCreateList = new List<Friend>() { };
                    myGroupJoinList = new List<Friend>() { };
                    myGroupManageList = new List<Friend>() { };

                    // 刷新列表
                    HttpLoadRoomsData();

                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 根据RoomJId删除项
        private void RemoveItemView(string roomjid)
        {
            int index = mAdapter.GetIndexByFriendId(roomjid);
            if (index > -1)
            {
                xListView.RemoveItem(index);
                mAdapter.RemoveData(index);

                if (MainForm.mainPageLayout.IsCurrtGroup(roomjid))
                {
                    SelectedItem = new FriendItem();
                    MainForm.mainPageLayout.SelectedIndex = MainTabIndex.RecentListPage_null;
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

        #region 根据Friend创建项
        private void CreteItemView(Friend room)
        {
            if (Thread.CurrentThread.IsBackground == true)
            {
                var tmp = new ProcesssFriend(CreteItemView);
                this.Invoke(tmp, room);
                return;
            }

            int index = mAdapter.GetIndexByFriendId(room.UserId);

            // 没有就添加
            if (index == -1)
            {
                mAdapter.InsertData(0, room);
                xListView.InsertItem(0);
            }
        }
        #endregion

        #region 右键菜单-删除|退出群聊
        private void DeleteGroup(bool para)
        {


            var group = SelectedItem.FriendData.Clone();//获取选中群组
            if (CurrIsLeader(Applicate.MyAccount.userId, group.RoomId))
            {
                if (MessageBox.Show("是否解散  " + group.NickName + " ？", "删除群聊", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var load = new LodingUtils { parent = this.xListView, Title = "加载中" };
                    load.start();
                    HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + ApplicateConst.DeleteRoom)
                        .AddParams("access_token", Applicate.Access_Token)
                        .AddParams("roomId", SelectedItem.FriendData.RoomId)
                        .AddErrorListener((code, msg) =>
                        {
                            HttpUtils.Instance.ShowTip(msg);
                        })
                        .Build().Execute((state, data) =>
                        {
                            load.stop();

                            if (state)
                            {
                                RemoveItemView(SelectedItem.FriendData.UserId);
                            }

                        });
                }
            }
            else
            {
                if (MessageBox.Show("是否退出  " + group.NickName + " ？", "退出群聊", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var load = new LodingUtils { parent = this.xListView, Title = "加载中" };
                    load.start();
                    HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + ApplicateConst.DeleteRoomMember)
                        .AddParams("access_token", Applicate.Access_Token)
                        .AddParams("roomId", SelectedItem.FriendData.RoomId)
                        .AddParams("userId", Applicate.MyAccount.userId).NoErrorTip()
                        .AddErrorListener((code, msg) =>
                        {
                            load.stop();
                            RemoveItemView(SelectedItem.FriendData.UserId);
                            //HttpUtils.Instance.ShowTip(msg);
                        })
                        .Build().Execute((state, data) =>
                        {
                            load.stop();
                            if (state)
                            {
                                RemoveItemView(SelectedItem.FriendData.UserId);
                            }
                        });
                }
            }
        }
        #endregion

        #region 设置右键菜单
        public FriendItem BindContextMenu(FriendItem item)
        {

            var sendmsgitem = new MenuItem("发送消息", (sender, eve) =>
            {
                Messenger.Default.Send(true, GroupListLayout.SEND_GROUP_MSG);

            });
            //var detailitem = new MenuItem("群组详情", (sen, eve) => { Messenger.Default.Send(true, GroupListLayout.SHOW_GROUP_DETAIL); });
            string str = CurrIsLeader(Applicate.MyAccount.userId, item.FriendData.RoomId) ? "解散群组" : "退出群组";
            var blockitem = new MenuItem(str, (sender, eve) =>
            {
                Messenger.Default.Send(true, GroupListLayout.DELETE_GROUP_ITEM);
            });

            var cm = new ContextMenu();
            cm.MenuItems.Add(sendmsgitem);
            //cm.MenuItems.Add(detailitem);
            cm.MenuItems.Add(blockitem);
            item.ContextMenu = cm;//设置右键菜单
            return item;
        }
        #endregion

        #region 判断我在某个群里是否是群主
        private bool CurrIsLeader(string useruId, string roomid)
        {
            int role = new RoomMember() { userId = useruId, roomId = roomid }.GetRoleByUserId();
            return role == 1;
        }
        #endregion

        #region 双击群组开始聊天
        public void DoubleGroupItem(object sender, EventArgs e)
        {
            FriendItem item = sender as FriendItem;
            MainForm.SendMessageToFriend(item.FriendData);
        }

        #endregion

        #region 左键和右键选中事件
        public void MouseDownItem(object sender, MouseEventArgs e)
        {
            // 过滤重复点击项
            FriendItem temp = sender as FriendItem;
            //if (SelectedItem != null && SelectedItem.FriendData != null)
            //{
            //    if (temp.FriendData.UserId.Equals(SelectedItem.FriendData.UserId))
            //    {
            //        return;
            //    }
            //}

            // 改变选中背景颜色
            if (SelectedItem != null && SelectedItem.FriendData != null)
            {
                if (!temp.FriendData.UserId.Equals(SelectedItem.FriendData.UserId))
                {
                    // 把上一个取消选中
                    SelectedItem.IsSelected = false;
                }
            }
            temp.IsSelected = true;

            SelectedItem = temp;

            if (e == null || e.Button == MouseButtons.Left)
            {
                MainForm.SelectGroup(SelectedItem.FriendData);
                //MainForm.SelectIndex = MainTabIndex.GroupPage;//显示群组详情右侧面板
            }
        }

        #endregion

        #region +号点击
        private void btnPlus_Click(string sender)
        {
            if (Applicate.URLDATA.data.isOpenRoomSearch == 0)
            {
                #region 打开搜索群功能
                var tmpset = Applicate.GetWindow<FrmGroupQuery>();
                var parent = Applicate.GetWindow<FrmMain>();
                if (tmpset == null)//单例打开好友添加窗口
                {
                    var query = new FrmGroupQuery();
                    query.Location = new Point(parent.Location.X + (parent.Width - query.Width) / 2, parent.Location.Y + (parent.Height - query.Height) / 2);//居中
                    query.Show();
                }
                else
                {
                    tmpset.Activate();
                }
                #endregion
            }
            else
            {
                #region 创建群
                FrmBuildGroups create = new FrmBuildGroups();
                var parent = Applicate.GetWindow<FrmMain>();
                create.Location = new Point(parent.Location.X + (parent.Width - create.Width) / 2, parent.Location.Y + (parent.Height - create.Height) / 2);//居中
                create.Show();
                #endregion
            }
        }
        #endregion

        #region 搜索文本改变时

        private string lastSearchText;

        public void SearchEvent(string currText)
        {
            if (string.IsNullOrEmpty(currText) && string.IsNullOrEmpty(lastSearchText))
            {
                LogUtils.Log("SearchTextChanged null");
                return;
            }

            if (string.Equals(lastSearchText, currText))
            {
                LogUtils.Log("SearchTextChanged Equals");
                return;
            }

            // 清空了搜索框
            if (string.IsNullOrEmpty(currText) && !string.IsNullOrEmpty(lastSearchText))
            {
                lastSearchText = currText;
                // 恢复原列表
                SearchData();
                return;
            }

            lastSearchText = currText;
            if (!string.IsNullOrEmpty(currText))
            {
                // 加载搜索数据
                SearchData(currText);
                return;
            }
        }

        /// <summary>
        /// 搜索列表数据
        /// </summary>
        public void SearchData(string searchText = "")
        {
            if (UIUtils.IsNull(searchText))
            {
                // 恢复列表
                TabLayout_ItemSelected(tabLabel, null);

            }
            else
            {
                if (tabLabel.Name == "role0")
                {
                    mAdapter.BindFriendData(myGroupCreateList);
                }
                else if (tabLabel.Name == "role1")
                {
                    mAdapter.BindFriendData(myGroupManageList);
                }
                else
                {
                    mAdapter.BindFriendData(myGroupJoinList);
                }

                var data = mAdapter.GetListBySearch(searchText);
                mAdapter.BindFriendData(data);
                xListView.SetAdapter(mAdapter);
            }
        }

        #endregion
    }

    internal class TabTextItem : Label, FocusControl
    {
        public void FocusChanged(bool focus)
        {
            if (focus)
            {
                this.ForeColor = Color.Black;
                this.Font = new Font("微软雅黑", 16f, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            else
            {
                this.ForeColor = Color.Gray;
                this.Font = new Font("微软雅黑", 16f, FontStyle.Regular, GraphicsUnit.Pixel);
            }
        }
    }
}